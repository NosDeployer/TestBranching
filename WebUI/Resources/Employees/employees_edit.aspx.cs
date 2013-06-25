using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_edit
    /// </summary>
    public partial class employees_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected EmployeeInformationTDS employeeInformationTDS;
        protected EmployeeInformationTDS.NoteInformationDataTable employeeInformationNote;
        protected EmployeeInformationTDS.CostInformationDataTable employeeInformationCosts;
        protected EmployeeInformationTDS.CostExceptionsInformationDataTable employeeInformationCostsExceptions;
        protected EmployeeInformationTDS.VacationInformationDataTable employeeInformationVacations;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["employee_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_edit.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Employees";
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfCurrentEmployeeId.Value = Request.QueryString["employee_id"];

                // Prepare initial data                
                Session.Remove("employeesNotesDummy");
                Session.Remove("employeesCostsDummy");
                Session.Remove("employeesCostsExceptionsDummy");
                Session.Remove("employeesVacationsDummy");
                Session.Remove("costIdSelected");

                // ... for team member title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId(employeeId);
                lblTitleTeamMember.Text = "Team Member: " + employeeGateway.GetFullName(employeeId);

                // If coming from 
                // ... employees_navigator2.aspx, employees_add.aspx
                if ((Request.QueryString["source_page"] == "employees_navigator2.aspx") || (Request.QueryString["source_page"] == "employees_add.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedEmployees"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        employeeInformationTDS = new EmployeeInformationTDS();
                        
                        EmployeeInformationBasicInformation employeeInformationBasicInformation = new EmployeeInformationBasicInformation(employeeInformationTDS);
                        employeeInformationBasicInformation.LoadByEmployeeId(employeeId, companyId);

                        EmployeeInformationCostInformation employeeInformationCostInformation = new EmployeeInformationCostInformation(employeeInformationTDS);
                        employeeInformationCostInformation.LoadAllByEmployeeId(employeeId, companyId);

                        EmployeeInformationCostExceptionsInformation employeeInformationCostExceptionsInformation = new EmployeeInformationCostExceptionsInformation(employeeInformationTDS);
                        employeeInformationCostExceptionsInformation.LoadAllByEmployeeId(employeeId, companyId);                        

                        EmployeeInformationNoteInformation employeeInformationNoteInformationForEdit = new EmployeeInformationNoteInformation(employeeInformationTDS);
                        employeeInformationNoteInformationForEdit.LoadAllByEmployeeId(employeeId, companyId);

                        EmployeeInformationCategoryApproveTimesheetsInformation employeeInformationCategoryApproveTimesheetsInformation = new EmployeeInformationCategoryApproveTimesheetsInformation(employeeInformationTDS);
                        employeeInformationCategoryApproveTimesheetsInformation.LoadByEmployeeId(employeeId);
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabEmployees"];

                        // Restore datasets
                        employeeInformationTDS = (EmployeeInformationTDS)Session["employeeInformationTDS"];                        
                    }

                    // ... Store dataset
                    Session["employeeInformationTDS"] = employeeInformationTDS;
                }

                // ... employees_summary.aspx or employees_edit
                if ((Request.QueryString["source_page"] == "employees_summary.aspx") || (Request.QueryString["source_page"] == "employees_edit.aspx") )
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // ... Restore dataset
                    employeeInformationTDS = (EmployeeInformationTDS)Session["employeeInformationTDS"];                    

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedEmployees"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabEmployees"];
                    }

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        EmployeeInformationBasicInformation employeeInformationBasicInformation = new EmployeeInformationBasicInformation(employeeInformationTDS);
                        employeeInformationBasicInformation.LoadByEmployeeId(employeeId, companyId);

                        EmployeeInformationCostInformation employeeInformationCostInformation = new EmployeeInformationCostInformation(employeeInformationTDS);
                        employeeInformationCostInformation.LoadAllByEmployeeId(employeeId, companyId);

                        EmployeeInformationCostExceptionsInformation employeeInformationCostExceptionsInformation = new EmployeeInformationCostExceptionsInformation(employeeInformationTDS);
                        employeeInformationCostExceptionsInformation.LoadAllByEmployeeId(employeeId, companyId);

                        EmployeeInformationNoteInformation employeeInformationNoteInformationForEdit = new EmployeeInformationNoteInformation(employeeInformationTDS);
                        employeeInformationNoteInformationForEdit.LoadAllByEmployeeId(employeeId, companyId);

                        EmployeeInformationCategoryApproveTimesheetsInformation employeeInformationCategoryApproveTimesheetsInformation = new EmployeeInformationCategoryApproveTimesheetsInformation(employeeInformationTDS);
                        employeeInformationCategoryApproveTimesheetsInformation.LoadByEmployeeId(employeeId);

                        // ... Store dataset
                        Session["employeeInformationTDS"] = employeeInformationTDS;
                    }
                }

                Session["costIdSelected"] = 0;
                grdCostsExceptions.ShowFooter = false;
                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", 0, 0);
                odsCostsExceptions.FilterExpression = filterOptions;

                // Prepare initial data
                // ... Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTab;               

                // ... Data for current employee
                LoadData();               

                // Databind
                Page.DataBind();

                // Select Last cost row
                SelectLastCostRow();
            }
            else
            {
                // Restore datasets
                employeeInformationTDS = (EmployeeInformationTDS)Session["employeeInformationTDS"];               

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTab;
            }
        }       
       

        
        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }
            
            // Delete note
            int employeeId = (int)e.Keys["EmployeeID"];
            int refId = (int)e.Keys["RefID"];

            EmployeeInformationNoteInformation model = new EmployeeInformationNoteInformation(employeeInformationTDS);

            // ... Delete at model
            model.Delete(employeeId, refId);

            // ... Store dataset
            Session["employeeInformationTDS"] = employeeInformationTDS;
        }



        protected void grdCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }

            int costId = (int)e.Keys["CostID"];
            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

            EmployeeInformationCostInformation model = new EmployeeInformationCostInformation(employeeInformationTDS);

            // Delete cost
            model.Delete(costId, employeeId);

            // Store dataset
            Session["employeeInformationTDS"] = employeeInformationTDS;
        }



        protected void grdCostsExceptions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs exceptions Gridview, if the gridview is edition mode
            if (grdCostsExceptions.EditIndex >= 0)
            {
                grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
            }

            int costId = (int)e.Keys["CostID"];
            int refId = (int)e.Keys["RefID"];

            EmployeeInformationCostExceptionsInformation model = new EmployeeInformationCostExceptionsInformation(employeeInformationTDS);

            // Delete cost exception
            model.Delete(costId, refId);

            grdCostsExceptions.DataBind();
            grdCosts.DataBind();

            // Store dataset
            Session["employeeInformationTDS"] = employeeInformationTDS;
        }



        protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Notes Gridview, if the gridview is edition mode
                    if (grdNotes.EditIndex >= 0)
                    {
                        grdNotes.UpdateRow(grdNotes.EditIndex, true);
                    }

                    // Add New Note
                    GrdNotesAdd();
                    break;
            }
        }



        protected void grdCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Costs Gridview, if the gridview is edition mode
                    if (grdCosts.EditIndex >= 0)
                    {
                        grdCosts.UpdateRow(grdCosts.EditIndex, true);
                    }

                    Page.Validate("AddCost");
                    if (Page.IsValid)
                    {
                        GrdCostsAdd();
                    }
                    break;
            }
        }



        protected void grdCostsExceptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // CostsExceptions Gridview, if the gridview is edition mode
                    if (grdCostsExceptions.EditIndex >= 0)
                    {
                        grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                    }

                    Page.Validate("AddCostException");
                    if (Page.IsValid)
                    {
                        GrdCostsExceptionsAdd();
                    }
                    break;

                case "Edit":
                    string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", Convert.ToInt32(Session["costIdSelected"]), 0);
                    odsCostsExceptions.FilterExpression = filterOptions;
                    break;
            }
        }



        protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("notesDataEdit");
            if (Page.IsValid)
            {
                int employeeId = (int)e.Keys["EmployeeID"];
                int refId = (int)e.Keys["RefID"];

                string subject = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[2].FindControl("tbxNoteSubjectEdit")).Text.Trim();
                string Note = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("tbxNoteNoteEdit")).Text.Trim();

                // Update data
                EmployeeInformationNoteInformation model = new EmployeeInformationNoteInformation(employeeInformationTDS);
                model.Update(employeeId, refId, subject, Note);

                // Store dataset
                Session["employeeInformationTDS"] = employeeInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdNotes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }
        }
       


        protected void grdCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("EditCost");
            if (Page.IsValid)
            {
                int costId = (int)e.Keys["CostID"];
                int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

                string unitOfMeasurement = ((DropDownList)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementEdit")).SelectedValue;
                decimal payRateCad = Decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxPayRateCadEdit")).Text.Trim());
                decimal payRateUsd = Decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxPayRateUsdEdit")).Text.Trim());

                decimal burdenRateCad = 0;
                decimal burdenRateUsd = 0;
                decimal totalCostCad = 0;
                decimal totalCostUsd = 0;
                if (tbxBourdenFactor.Text != "")
                {
                    decimal boudenFactor = decimal.Parse(tbxBourdenFactor.Text) / 100;
                    burdenRateCad = payRateCad * boudenFactor;
                    totalCostCad = payRateCad + burdenRateCad;
                    totalCostCad = Decimal.Round(totalCostCad, 2);

                    burdenRateUsd = payRateUsd * boudenFactor;
                    totalCostUsd = payRateUsd + burdenRateUsd;
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                DateTime date = ((RadDatePicker)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpDateEdit")).SelectedDate.Value;

                decimal healthBenefitUsd = 0;
                if (tbxUSHealthBenefitFactor.Text != "")
                {
                    if (tbxBenefitFactorUsd.Text != "")
                    {
                        decimal healthBenefitFactor = Decimal.Parse(tbxUSHealthBenefitFactor.Text) / 100;
                        healthBenefitUsd = decimal.Parse(tbxBenefitFactorUsd.Text) * healthBenefitFactor;
                    }
                }

                // Update data
                EmployeeInformationCostInformation model = new EmployeeInformationCostInformation(employeeInformationTDS);
                model.Update(costId, employeeId, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalCostUsd, date, healthBenefitUsd);

                // Store dataset
                Session["employeeInformationTDS"] = employeeInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdCostsExceptions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("EditCostException");
            if (Page.IsValid)
            {
                int costId = Int32.Parse(((Label)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("lblExceptionCostIDEdit")).Text);
                int refId = Int32.Parse(((Label)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("lblExceptionRefIDEdit")).Text);

                string work_ = ((DropDownList)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("ddlExceptionWork_Edit")).SelectedValue;
                string unitOfMeasurement = ((DropDownList)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("ddlExceptionUnitOfMeasurementEdit")).SelectedValue;
                decimal payRateCad = Decimal.Parse(((TextBox)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("tbxExceptionPayRateCadEdit")).Text.Trim());
                decimal payRateUsd = Decimal.Parse(((TextBox)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("tbxExceptionPayRateUsdEdit")).Text.Trim());

                decimal burdenRateCad = 0;
                decimal burdenRateUsd = 0;
                decimal totalCostCad = 0;
                decimal totalCostUsd = 0;                
                
                if (tbxBourdenFactor.Text != "")
                {
                    decimal boudenFactor = decimal.Parse(tbxBourdenFactor.Text) / 100;
                    burdenRateCad = payRateCad * boudenFactor;
                    totalCostCad = payRateCad + burdenRateCad;
                    totalCostCad = Decimal.Round(totalCostCad, 2);

                    burdenRateUsd = payRateUsd * boudenFactor;
                    totalCostUsd = payRateUsd + burdenRateUsd;
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                decimal healthBenefitUsd = 0;
                if (tbxUSHealthBenefitFactor.Text != "")
                {
                    if (tbxBenefitFactorUsd.Text != "")
                    {
                        decimal healthBenefitFactor = Decimal.Parse(tbxUSHealthBenefitFactor.Text) / 100;
                        healthBenefitUsd = decimal.Parse(tbxBenefitFactorUsd.Text) * healthBenefitFactor;
                    }
                }

                // Update data
                EmployeeInformationCostExceptionsInformation model = new EmployeeInformationCostExceptionsInformation(employeeInformationTDS);
                model.Update(costId, refId, work_, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalCostUsd, healthBenefitUsd);

                // Store dataset
                Session["employeeInformationTDS"] = employeeInformationTDS;

                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                odsCostsExceptions.FilterExpression = filterOptions;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }
        }



        protected void grdCostsExceptions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdCostsExceptions.EditIndex >= 0)
            {
                grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Resources";

            // Cost information only visible for admin
            tpGeneralData.Visible = true;

            if (!Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_ADMIN"]))
            {
                tpGeneralData.Visible = false;
                tkrpbLeftMenuTools.Items[0].Items[0].Visible = false; // Personnel Agencies
            }

            if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"])))
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Vacations Setup
            }

            // For vacation error message
            EmployeeInformationPayVacationDaysInformationList employeeInformationPayVacationDaysInformationList = new EmployeeInformationPayVacationDaysInformationList();
            employeeInformationPayVacationDaysInformationList.LoadByEmployeeId(Int32.Parse(hdfCurrentEmployeeId.Value));

            if (employeeInformationPayVacationDaysInformationList.Table.Rows.Count < 1)
            {
                lblNoExistVacations.Visible = true;
            }

            // For job costing error message
            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
            EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway(employeeInformationTDS);
            decimal? bourdenFactor = employeeInformationBasicInformationGateway.GetBourdenFactor(employeeId);
            decimal? usHealthBenefitFactor = employeeInformationBasicInformationGateway.GetUSHealthBenefitFactor(employeeId);
            decimal? benefitFactorCad = employeeInformationBasicInformationGateway.GetBenefitFactorCad(employeeId);
            decimal? benefitFactorUsd = employeeInformationBasicInformationGateway.GetBenefitFactorUsd(employeeId);

            if ((!bourdenFactor.HasValue) || (!usHealthBenefitFactor.HasValue) || (!benefitFactorCad.HasValue) || (!benefitFactorUsd.HasValue))
            {
                lblJoxCostingFactorsError.Visible = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //     

        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix 
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdVacations_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix 
            AddVacationsNewEmptyFix(grdVacations);
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix 
            AddCostsNewEmptyFix(grdCosts);
        }



        protected void grdCostsExceptions_DataBound(object sender, EventArgs e)
        {
            AddCostsExceptionsNewEmptyFix(grdCostsExceptions);
        }



        protected void grdCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
                int costId = Int32.Parse(((Label)e.Row.FindControl("lblCostIDEdit")).Text.Trim());

                EmployeeInformationCostInformationGateway employeeInformationCostInformationGateway = new EmployeeInformationCostInformationGateway(employeeInformationTDS);
                string unitOfMeasurement = employeeInformationCostInformationGateway.GetUnitOfMeasurement(costId, employeeId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementEdit")).SelectedValue = unitOfMeasurement;               
            }

            // Control value for footer employees
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For benefit factors
                ((TextBox)e.Row.FindControl("tbxBenefitFactorCadNew")).Text = tbxBenefitFactorCad.Text;
                ((TextBox)e.Row.FindControl("tbxBenefitFactorUsdNew")).Text = tbxBenefitFactorUsd.Text;

                // Validation to add new rows
                if ((tbxBourdenFactor.Text == "") || (tbxUSHealthBenefitFactor.Text == "") || (tbxBenefitFactorCad.Text == "") || (tbxBenefitFactorUsd.Text == ""))
                {
                    ((ImageButton)e.Row.FindControl("ibtnAdd")).Visible = false;
                }
            }

            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Validation to edit rows
                if ((tbxBourdenFactor.Text == "") || (tbxUSHealthBenefitFactor.Text == "") || (tbxBenefitFactorCad.Text == "") || (tbxBenefitFactorUsd.Text == ""))
                {
                    ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = false;
                }
                else
                {
                    if (((Label)e.Row.FindControl("lblInDataBase")).Text == "1")
                    {
                        ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = false;
                    }
                }                
            }
        }



        protected void grdCostsExceptions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblExceptionRefIDEdit")).Text.Trim());
                int costId = Int32.Parse(((Label)e.Row.FindControl("lblExceptionCostIDEdit")).Text.Trim());

                EmployeeInformationCostExceptionsInformationGateway employeeInformationCostExceptionsInformationGateway = new EmployeeInformationCostExceptionsInformationGateway(employeeInformationTDS);
                string work_ = employeeInformationCostExceptionsInformationGateway.GetWork_(costId, refId);
                ((DropDownList)e.Row.FindControl("ddlExceptionWork_Edit")).SelectedValue = work_;

                string unitOfMeasurementException = employeeInformationCostExceptionsInformationGateway.GetUnitOfMeasurement(costId, refId);
                ((DropDownList)e.Row.FindControl("ddlExceptionUnitOfMeasurementEdit")).SelectedValue = unitOfMeasurementException;              
            }

            // Control value for footer employees
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For Material
                ((TextBox)e.Row.FindControl("tbxExceptionBenefitFactorCadNew")).Text = tbxBenefitFactorCad.Text;                                             
                ((TextBox)e.Row.FindControl("tbxExceptionBenefitFactorUsdNew")).Text = tbxBenefitFactorUsd.Text;

                // Validation to add new rows
                if ((tbxBourdenFactor.Text == "") || (tbxUSHealthBenefitFactor.Text == "") || (tbxBenefitFactorCad.Text == "") || (tbxBenefitFactorUsd.Text == ""))
                {
                    ((ImageButton)e.Row.FindControl("ibtnAdd")).Visible = false;
                }           
            }

            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Validation to edit rows
                if ((tbxBourdenFactor.Text == "") || (tbxUSHealthBenefitFactor.Text == "") || (tbxBenefitFactorCad.Text == "") || (tbxBenefitFactorUsd.Text == ""))
                {
                    ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = false;
                }
                else
                {
                    if (((Label)e.Row.FindControl("lblInDataBase")).Text == "1")
                    {
                        ((ImageButton)e.Row.FindControl("ibtnEdit")).Visible = false;
                    }
                }
            }
        }
        


        protected void cbxSelectedCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("employeesCostsExceptionsDummy");
            grdCostsExceptions.ShowFooter = true;
            
            if (checkbox.Checked)
            {
                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                foreach (GridViewRow rowTemp in grdCosts.Rows)
                {
                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                    {
                        if (Validator.IsValidInt32(((Label)rowTemp.FindControl("lblCostID")).Text))
                        {
                            int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                            if (costId != costTemp)
                            {
                                ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                            }
                        }
                    }
                }

                Session.Remove("costIdSelected");
                Session["costIdSelected"] = costId;
            }

            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
            odsCostsExceptions.FilterExpression = filterOptions;
        }



        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();

            if (ddlType.SelectedItem.Text.Contains("Canada"))
            {
                projectTimeJobClassTypeList.LoadAndAddItem(1, companyId, "");
                ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                ddlJobClassType.DataValueField = "JobClassType";
                ddlJobClassType.DataTextField = "JobClassType";
                ddlJobClassType.DataBind();
            }
            else
            {
                projectTimeJobClassTypeList.LoadAndAddItem(2, companyId, "");
                ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                ddlJobClassType.DataValueField = "JobClassType";
                ddlJobClassType.DataTextField = "JobClassType";
                ddlJobClassType.DataBind();
            }

            upnlJobClassType.Update();
        }



        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session.Remove("employeesVacationsDummy");

            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
            int year = Int32.Parse(ddlYear.SelectedValue);

            EmployeeInformationPayVacationDaysInformation employeeInformationPayVacationDaysInformation = new EmployeeInformationPayVacationDaysInformation(employeeInformationTDS);
            employeeInformationPayVacationDaysInformation.LoadByEmployeeIdYear(employeeId, year);

            EmployeeInformationPayVacationDaysInformationGateway employeeInformationPayVacationDaysInformationGateway = new EmployeeInformationPayVacationDaysInformationGateway(employeeInformationTDS);
            if (employeeInformationPayVacationDaysInformationGateway.Table.Rows.Count > 0)
            {
                tbxMax.Text = employeeInformationPayVacationDaysInformationGateway.GetVacationDays(employeeId, year).ToString();
                tbxRemaining.Text = employeeInformationPayVacationDaysInformationGateway.GetRemainingPayVacationDays(employeeId, year).ToString();
                tbxTotalApproved.Text = employeeInformationPayVacationDaysInformationGateway.GetTotalApprovedVacations(employeeId, year).ToString();

                DateTime startDate = new DateTime(Int32.Parse(ddlYear.SelectedValue), 1, 1);
                DateTime endDate = new DateTime(Int32.Parse(ddlYear.SelectedValue), 12, 31);

                EmployeeInformationVacationInformation employeeInformationVacationInformation = new EmployeeInformationVacationInformation(employeeInformationTDS);
                employeeInformationVacationInformation.LoadByEmployeeIdStartDateEndDate(Int32.Parse(hdfCurrentEmployeeId.Value), startDate, endDate, Int32.Parse(hdfCompanyId.Value));
            }

            grdVacations.DataBind();
        }



        protected void cvEditDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (((RadDatePicker)grdCosts.Rows[grdCosts.EditIndex].FindControl("tkrdpDateEdit")).SelectedDate.HasValue)
            {
                DateTime newDate = Convert.ToDateTime(((RadDatePicker)grdCosts.Rows[grdCosts.EditIndex].FindControl("tkrdpDateEdit")).SelectedDate.Value);

                if (grdCosts.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCosts.Rows)
                    {
                        if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            if (Validator.IsValidDate(((Label)row.FindControl("lblDate")).Text))
                            {
                                DateTime date = Convert.ToDateTime(((Label)row.FindControl("lblDate")).Text);
                                if (date == newDate)
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                args.IsValid = false;
            }
        }




        protected void cvAddDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.HasValue)
            {
                DateTime newDate = Convert.ToDateTime(((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value);

                if (grdCosts.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCosts.Rows)
                    {
                        if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            if (Validator.IsValidDate(((Label)row.FindControl("lblDate")).Text))
                            {
                                DateTime date = Convert.ToDateTime(((Label)row.FindControl("lblDate")).Text);
                                if (date == newDate)
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvCategoriesApproveTimesheets_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (ckbxApproveTimesheets.Checked)
            {
                if (ckbxField.Checked || ckbxField44.Checked || ckbxMechanicManufactoring.Checked || ckbxOfficeAdmin.Checked || ckbxSpecialForces.Checked)
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                    cvCategoriesApproveTimesheets.ErrorMessage = "You must select at least one category.";
                }
            }
            else
            {
                if (ckbxField.Checked || ckbxField44.Checked || ckbxMechanicManufactoring.Checked || ckbxOfficeAdmin.Checked || ckbxSpecialForces.Checked)
                {
                    args.IsValid = false;
                    cvCategoriesApproveTimesheets.ErrorMessage = "You can't select categories. The Approve Timesheets field is not checked.";
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabEmployees"] = "0";
            Session["dialogOpenedEmployees"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":                    
                    if (Request.QueryString["source_page"] == "employees_navigator2.aspx")
                    {
                        url = "./employees_navigator2.aspx?source_page=employees_edit.aspx" + GetNavigatorState() + "&update=yes";
                    }                    
                    else
                    {
                        if (Request.QueryString["source_page"] == "employees_summary.aspx")
                        {                            
                            url = "./employees_summary.aspx?source_page=employees_edit.aspx&employee_id=" + hdfCurrentEmployeeId.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTab;
                        }
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = EmployeeNavigator.GetPreviousId((EmployeeNavigatorTDS)Session["employeeNavigatorTDS"], Int32.Parse(hdfCurrentEmployeeId.Value));
                    if (previousId != Int32.Parse(hdfCurrentEmployeeId.Value))
                    {
                        this.Apply();

                        // Redirect
                        url = "./employees_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&employee_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = EmployeeNavigator.GetNextId((EmployeeNavigatorTDS)Session["employeeNavigatorTDS"], Int32.Parse(hdfCurrentEmployeeId.Value));
                    if (nextId != Int32.Parse(hdfCurrentEmployeeId.Value))
                    {
                        this.Apply();

                        // Redirect
                        url = "./employees_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&employee_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabEmployees"] = "0";

            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./employees_navigator.aspx?source_page=lm&resource_type=" + hdfResourceType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //    

        public EmployeeInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            employeeInformationNote = (EmployeeInformationTDS.NoteInformationDataTable)Session["employeesNotesDummy"];
            if (employeeInformationNote == null)
            {
                employeeInformationNote = ((EmployeeInformationTDS)Session["employeeInformationTDS"]).NoteInformation;
            }

            return employeeInformationNote;
        }



        public EmployeeInformationTDS.VacationInformationDataTable GetVacationsNew()
        {
            employeeInformationVacations = (EmployeeInformationTDS.VacationInformationDataTable)Session["employeesVacationsDummy"];

            if (employeeInformationVacations == null)
            {
                employeeInformationVacations = ((EmployeeInformationTDS)Session["employeeInformationTDS"]).VacationInformation;
            }

            return employeeInformationVacations;
        }



        public EmployeeInformationTDS.CostInformationDataTable GetCostsNew()
        {
            employeeInformationCosts = (EmployeeInformationTDS.CostInformationDataTable)Session["employeesCostsDummy"];
            if (employeeInformationCosts == null)
            {
                employeeInformationCosts = ((EmployeeInformationTDS)Session["employeeInformationTDS"]).CostInformation;
            }

            return employeeInformationCosts;
        }



        public EmployeeInformationTDS.CostExceptionsInformationDataTable GetCostsExceptionsNew()
        {
            employeeInformationCostsExceptions = (EmployeeInformationTDS.CostExceptionsInformationDataTable)Session["employeesCostsExceptionsDummy"];
            if (employeeInformationCostsExceptions == null)
            {
                employeeInformationCostsExceptions = ((EmployeeInformationTDS)Session["employeeInformationTDS"]).CostExceptionsInformation;
            }

            return employeeInformationCostsExceptions;
        }


        
        public void DummyNotesNew(int EmployeeID, int RefID)
        {
        }



        public void DummyCostsNew(string UnitOfMeasurement, int CostID)
        {
        }



        public void DummyCostsNew(int CostID)
        {
        }



        public void DummyCostsNew(int CostID, int EmployeeID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID, int RefID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID, int RefID, int EmployeeID)
        {
        }



        public void DummyCostsExceptionsNew(string UnitOfMeasurement, int CostID, int RefID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfEmployeeIdId = '" + hdfCurrentEmployeeId.ClientID + "';";
            contentVariables += "var hdfResourceTypeId = '" + hdfResourceType.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        #region Load Functions

        private void LoadData()
        {
            // Get employee id
            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

            LoadBasicData(employeeId);
            LoadCategoriesApproveTimesheets(employeeId);
            LoadVacationsData(employeeId);
        }



        private void LoadBasicData(int employeeId)
        {
            // Load Data
            EmployeeInformationBasicInformationGateway employeeInformationBasicInformationGateway = new EmployeeInformationBasicInformationGateway(employeeInformationTDS);
            if (employeeInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load employee basic data
                tbxFisrtName.Text = employeeInformationBasicInformationGateway.GetFirstName(employeeId);
                tbxLastName.Text = employeeInformationBasicInformationGateway.GetLastName(employeeId);
                tbxeMail.Text = employeeInformationBasicInformationGateway.GeteMail(employeeId);
                ckbxIsSalesman.Checked = employeeInformationBasicInformationGateway.GetIsSalesman(employeeId);
                ckbxRequestTimesheet.Checked = employeeInformationBasicInformationGateway.GetRequestProjectTime(employeeId);
                ckbxSalaried.Checked = employeeInformationBasicInformationGateway.GetSalaried(employeeId);
                ckbxAssignableSrs.Checked = employeeInformationBasicInformationGateway.GetAssignableSRS(employeeId);
                ddlType.SelectedValue = employeeInformationBasicInformationGateway.GetType(employeeId);
                ddlState.SelectedValue = employeeInformationBasicInformationGateway.GetState(employeeId);
                ddlCategory.SelectedValue = employeeInformationBasicInformationGateway.GetCategory(employeeId);
                ddlPersonalAgency.SelectedValue = employeeInformationBasicInformationGateway.GetPersonalAgencyName(employeeId);
                ckbxVacationsManager.Checked = employeeInformationBasicInformationGateway.GetIsVacationsManager(employeeId);
                ckbxApproveTimesheets.Checked = employeeInformationBasicInformationGateway.GetApproveTimesheets(employeeId);
				if (employeeInformationBasicInformationGateway.GetCrew(employeeId) != "")
				{
					ddlCrew.SelectedValue = employeeInformationBasicInformationGateway.GetCrew(employeeId);
				}
				else
				{
					ddlCrew.SelectedIndex = 0;
				}

                if (employeeInformationBasicInformationGateway.GetType(employeeId).Contains("CA"))
                {
                    ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();
                    projectTimeJobClassTypeList.LoadAndAddItem(1, 3, "");
                    ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                    ddlJobClassType.DataValueField = "JobClassType";
                    ddlJobClassType.DataTextField = "JobClassType";
                    ddlJobClassType.DataBind();
                }
                else
                {
                    ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();
                    projectTimeJobClassTypeList.LoadAndAddItem(2, 3, "");
                    ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                    ddlJobClassType.DataValueField = "JobClassType";
                    ddlJobClassType.DataTextField = "JobClassType";
                    ddlJobClassType.DataBind();
                }

                ddlJobClassType.SelectedValue = employeeInformationBasicInformationGateway.GetJobClassType(employeeId);

                // Job costing factors
                decimal? bourdenFactor = employeeInformationBasicInformationGateway.GetBourdenFactor(employeeId);
                if (bourdenFactor.HasValue)
                {
                    tbxBourdenFactor.Text = decimal.Round((decimal)bourdenFactor, 1).ToString();
                }

                decimal? usHealthBenefitFactor = employeeInformationBasicInformationGateway.GetUSHealthBenefitFactor(employeeId);
                if (usHealthBenefitFactor.HasValue)
                {
                    tbxUSHealthBenefitFactor.Text = decimal.Round((decimal)usHealthBenefitFactor, 1).ToString();
                }

                decimal? benefitFactorCad = employeeInformationBasicInformationGateway.GetBenefitFactorCad(employeeId);
                if (benefitFactorCad.HasValue)
                {
                    tbxBenefitFactorCad.Text = decimal.Round((decimal)benefitFactorCad, 2).ToString();
                }

                decimal? benefitFactorUsd = employeeInformationBasicInformationGateway.GetBenefitFactorUsd(employeeId);
                if (benefitFactorUsd.HasValue)
                {
                    tbxBenefitFactorUsd.Text = decimal.Round((decimal)benefitFactorUsd, 2).ToString();
                }    
            }
        }



        private void LoadCategoriesApproveTimesheets(int employeeID)
        {
            EmployeeInformationCategoryApproveTimesheetsInformationGateway employeeInformationCategoryApproveTimesheetsInformationGateway = new EmployeeInformationCategoryApproveTimesheetsInformationGateway(employeeInformationTDS);
            if (employeeInformationCategoryApproveTimesheetsInformationGateway.Table.Rows.Count > 0)
            {
                ckbxField.Checked = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheets(employeeID, "Field");
                ckbxField44.Checked = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheets(employeeID, "Field 44");
                ckbxOfficeAdmin.Checked = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheets(employeeID, "Office/Admin");
                ckbxMechanicManufactoring.Checked = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheets(employeeID, "Mechanic/Manufactoring");
                ckbxSpecialForces.Checked = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheets(employeeID, "Special Forces");
            }
        }



        private void LoadVacationsData(int employeeId)
        {
            EmployeeInformationPayVacationDaysInformationList employeeInformationPayVacationDaysInformationList = new EmployeeInformationPayVacationDaysInformationList();
            employeeInformationPayVacationDaysInformationList.LoadByEmployeeId(employeeId);

            if (employeeInformationPayVacationDaysInformationList.Table.Rows.Count > 0)
            {
                ddlYear.DataSource = employeeInformationPayVacationDaysInformationList.Table;
                ddlYear.DataValueField = "Year";
                ddlYear.DataTextField = "Year";
                ddlYear.DataBind();

                if (ddlYear.Items.Contains(new ListItem(DateTime.Now.Year.ToString())))
                {
                    ddlYear.SelectedValue = DateTime.Now.Year.ToString();
                }
                else
                {
                    ddlYear.SelectedIndex = 0;
                }

                int year = Int32.Parse(ddlYear.SelectedValue);

                EmployeeInformationPayVacationDaysInformation employeeInformationPayVacationDaysInformation = new EmployeeInformationPayVacationDaysInformation(employeeInformationTDS);
                employeeInformationPayVacationDaysInformation.LoadByEmployeeIdYear(employeeId, year);

                EmployeeInformationPayVacationDaysInformationGateway employeeInformationPayVacationDaysInformationGateway = new EmployeeInformationPayVacationDaysInformationGateway(employeeInformationTDS);
                if (employeeInformationPayVacationDaysInformationGateway.Table.Rows.Count > 0)
                {
                    tbxMax.Text = employeeInformationPayVacationDaysInformationGateway.GetVacationDays(employeeId, year).ToString();
                    tbxRemaining.Text = employeeInformationPayVacationDaysInformationGateway.GetRemainingPayVacationDays(employeeId, year).ToString();
                    tbxTotalApproved.Text = employeeInformationPayVacationDaysInformationGateway.GetTotalApprovedVacations(employeeId, year).ToString();

                    DateTime startDate = new DateTime(Int32.Parse(ddlYear.SelectedValue), 1, 1);
                    DateTime endDate = new DateTime(Int32.Parse(ddlYear.SelectedValue), 12, 31);

                    EmployeeInformationVacationInformation employeeInformationVacationInformation = new EmployeeInformationVacationInformation(employeeInformationTDS);
                    employeeInformationVacationInformation.LoadByEmployeeIdStartDateEndDate(employeeId, startDate, endDate, Int32.Parse(hdfCompanyId.Value));
                }
            }
        }

        #endregion



        private void Save()
        {
            // Validate data
            bool validData = false;

            Page.Validate("General");
            if (Page.IsValid)
            {
                validData = true;

                // ... Validate notes tab
                if (ValidateNotesFooter())
                {
                    Page.Validate("notesDataAdd");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("notesDataEdit");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }

            // For valid data
            if (validData)
            {              
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Save cost and notes data                
                GrdNotesAdd();

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Save costs data                
                GrdCostsAdd();

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }

                // Save costs exceptions data                
                GrdCostsExceptionsAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

                // ... Get basic employee data
                string newFirstName = tbxFisrtName.Text.Trim();
                string newLastName = tbxLastName.Text.Trim();
                string newEmail = tbxeMail.Text.Trim();
                string newType = ddlType.SelectedValue;
                string newState = ddlState.SelectedValue;
                bool newIsSalesman = ckbxIsSalesman.Checked;
                bool newRequestProjectTime = ckbxRequestTimesheet.Checked;
                bool newSalaried = ckbxSalaried.Checked;
                bool newAssignableSrs = ckbxAssignableSrs.Checked;
                string newJobClass = ddlJobClassType.SelectedValue;
                string newCategory = ddlCategory.SelectedValue;
                string newPersonalAgency = ddlPersonalAgency.SelectedValue;
                bool newVacationsManager = ckbxVacationsManager.Checked;
                bool newApproveTimesheets = ckbxApproveTimesheets.Checked;
                string newCrew = ""; if (ddlCrew.SelectedValue != "") newCrew = ddlCrew.SelectedValue;
                
                // Update basic information data
                EmployeeInformationBasicInformation employeeInformationBasicInformation = new EmployeeInformationBasicInformation(employeeInformationTDS);
                employeeInformationBasicInformation.Update(employeeId, newFirstName, newLastName, newType, newState, newIsSalesman, newRequestProjectTime, newSalaried, newEmail, newAssignableSrs, newJobClass, newCategory, newPersonalAgency, newVacationsManager, newApproveTimesheets, newCrew);

                // Update categories approve timesheets data
                EmployeeInformationCategoryApproveTimesheetsInformation employeeInformationCategoryApproveTimesheetsInformation = new EmployeeInformationCategoryApproveTimesheetsInformation(employeeInformationTDS);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Field", ckbxField.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Field 44", ckbxField44.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Mechanic/Manufactoring", ckbxMechanicManufactoring.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Office/admin", ckbxOfficeAdmin.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Special Forces", ckbxSpecialForces.Checked);

                // Insert type to history
                EmployeeInformationTypeHistoryInformation employeeInformationTypeHistoryInformation = new EmployeeInformationTypeHistoryInformation(employeeInformationTDS);
                employeeInformationTypeHistoryInformation.Insert(employeeId, DateTime.Now, newType, false, companyId, false);

                // Store datasets
                Session["employeeInformationTDS"] = employeeInformationTDS;
                
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "employees_navigator2.aspx" )
                {
                    url = "./employees_navigator2.aspx?source_page=employees_edit.aspx&employee_id=" + hdfCurrentEmployeeId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "employees_summary.aspx")
                {
                    string activeTab = hdfActiveTab.Value;
                    url = "./employees_summary.aspx?source_page=employees_edit.aspx&employee_id=" + hdfCurrentEmployeeId.Value + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            // Validate data
            bool validData = false;

            Page.Validate("General");
            if (Page.IsValid)
            {
                validData = true;

                // ... Validate notes tab
                if (ValidateNotesFooter())
                {
                    Page.Validate("notesDataAdd");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("notesDataEdit");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }

            // For valid data
            if (validData)
            {
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

                // ... Get basic employee data
                string newFirstName = tbxFisrtName.Text.Trim();
                string newLastName = tbxLastName.Text.Trim();
                string newEmail = tbxeMail.Text.Trim();
                string newType = ddlType.SelectedValue;
                string newState = ddlState.SelectedValue;
                bool newIsSalesman = ckbxIsSalesman.Checked;
                bool newRequestProjectTime = ckbxRequestTimesheet.Checked;
                bool newSalaried = ckbxSalaried.Checked;
                bool newAssignableSrs = ckbxAssignableSrs.Checked;
                string newJobClass = ddlJobClassType.SelectedValue;
                string newCategory = ddlCategory.SelectedValue;
                string newPersonalAgency = ddlPersonalAgency.SelectedValue;
                bool newVacationsManager = ckbxVacationsManager.Checked;
                bool newApproveTimesheets = ckbxApproveTimesheets.Checked;
                string newCrew = ""; if (ddlCrew.SelectedValue != "") newCrew = ddlCrew.SelectedValue;

                // Update service data
                EmployeeInformationBasicInformation employeeInformationBasicInformation = new EmployeeInformationBasicInformation(employeeInformationTDS);
                employeeInformationBasicInformation.Update(employeeId, newFirstName, newLastName, newType, newState, newIsSalesman, newRequestProjectTime, newSalaried, newEmail, newAssignableSrs, newJobClass, newCategory, newPersonalAgency, newVacationsManager, newApproveTimesheets, newCrew);

                // Update categories approve timesheets data
                EmployeeInformationCategoryApproveTimesheetsInformation employeeInformationCategoryApproveTimesheetsInformation = new EmployeeInformationCategoryApproveTimesheetsInformation(employeeInformationTDS);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Field", ckbxField.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Field 44", ckbxField44.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Mechanic/Manufactoring", ckbxMechanicManufactoring.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Office/admin", ckbxOfficeAdmin.Checked);
                employeeInformationCategoryApproveTimesheetsInformation.Update(employeeId, "Special Forces", ckbxSpecialForces.Checked);

                // Store datasets
                Session["employeeInformationTDS"] = employeeInformationTDS;
                
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void GrdNotesAdd()
        {
            if (ValidateNotesFooter())
            {
                Page.Validate("notesDataAdd");
                if (Page.IsValid)
                {
                    int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    string newNote = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
                    bool inServiceNoteDatabase = false;

                    EmployeeInformationNoteInformation model = new EmployeeInformationNoteInformation(employeeInformationTDS);
                    model.Insert(employeeId, newSubject, loginId, dateTime_, newNote, false, companyId, inServiceNoteDatabase);

                    Session.Remove("employeesNotesDummy");
                    Session["employeeInformationTDS"] = employeeInformationTDS;                    

                    grdNotes.DataBind();
                    grdNotes.PageIndex = grdNotes.PageCount - 1;
                }
            }
        }



        private void GrdCostsAdd()
        {
            if (ValidateCostsFooter())
            {
                Page.Validate("AddCost");
                if (Page.IsValid)
                {
                    int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date_ = ((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value;
                    string unitOfMeasurement = ((DropDownList)grdCosts.FooterRow.FindControl("ddlUnitOfMeasurementNew")).SelectedValue;
                    decimal payRateCad = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxPayRateCadNew")).Text.Trim());
                    decimal payRateUsd = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxPayRateUsdNew")).Text.Trim());

                    decimal burdenRateCad = 0;
                    decimal totalCostCad = 0;
                    decimal burdenRateUsd = 0;
                    decimal totalCostUsd = 0;

                    if (tbxBourdenFactor.Text != "")
                    {
                        decimal boudenFactor = decimal.Parse(tbxBourdenFactor.Text) / 100;
                        burdenRateCad = payRateCad * boudenFactor;
                        totalCostCad = payRateCad + burdenRateCad;
                        totalCostCad = Decimal.Round(totalCostCad, 2);

                        burdenRateUsd = payRateUsd * boudenFactor;
                        totalCostUsd = payRateUsd + burdenRateUsd;
                        totalCostUsd = Decimal.Round(totalCostUsd, 2);
                    }

                    decimal benefitFactorCad = Decimal.Parse(tbxBenefitFactorCad.Text);
                    decimal benefitFactorUsd = Decimal.Parse(tbxBenefitFactorUsd.Text);

                    decimal healthBenefitUsd = 0;
                    if (tbxUSHealthBenefitFactor.Text != "")
                    {
                        if (tbxBenefitFactorUsd.Text != "")
                        {
                            decimal healthBenefitFactor = Decimal.Parse(tbxUSHealthBenefitFactor.Text) / 100;
                            healthBenefitUsd = decimal.Parse(tbxBenefitFactorUsd.Text) * healthBenefitFactor;
                        }
                    }
                                    
                    EmployeeInformationCostInformation model = new EmployeeInformationCostInformation(employeeInformationTDS);
                    model.Insert(employeeId, date_, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalCostUsd, false, companyId, false, benefitFactorCad, benefitFactorUsd, healthBenefitUsd);

                    Session.Remove("employeesCostsDummy");
                    Session["employeeInformationTDS"] = employeeInformationTDS;

                    grdCosts.DataBind();
                }
            }
        }



        private void GrdCostsExceptionsAdd()
        {
            if (ValidateCostsExceptionsFooter())
            {
                Page.Validate("AddCostException");
                if (Page.IsValid)
                {
                    int costId = Convert.ToInt32(Session["costIdSelected"]);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    string work_ = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWork_New")).SelectedValue;
                    string unitOfMeasurement = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionUnitOfMeasurementNew")).SelectedValue;
                    
                    decimal payRateCad = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionPayRateCadNew")).Text.Trim());
                    decimal payRateUsd = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionPayRateUsdNew")).Text.Trim());

                    decimal burdenRateCad = 0;
                    decimal totalCostCad = 0;
                    decimal burdenRateUsd = 0;
                    decimal totalCostUsd = 0;

                    if (tbxBourdenFactor.Text != "")
                    {
                        decimal boudenFactor = decimal.Parse(tbxBourdenFactor.Text)/100;
                        burdenRateCad = payRateCad * boudenFactor;
                        totalCostCad = payRateCad + burdenRateCad;
                        totalCostCad = Decimal.Round(totalCostCad, 2);

                        burdenRateUsd = payRateUsd * boudenFactor;
                        totalCostUsd = payRateUsd + burdenRateUsd;
                        totalCostUsd = Decimal.Round(totalCostUsd, 2);
                    }
                    
                    decimal benefitFactorCad = Decimal.Parse(tbxBenefitFactorCad.Text);
                    decimal benefitFactorUsd = Decimal.Parse(tbxBenefitFactorUsd.Text);
                        
                    decimal healthBenefitUsd = 0;
                    if (tbxUSHealthBenefitFactor.Text != "")
                    {
                        if (tbxBenefitFactorUsd.Text != "")
                        {
                            decimal healthBenefitFactor = Decimal.Parse(tbxUSHealthBenefitFactor.Text) / 100;
                            healthBenefitUsd = decimal.Parse(tbxBenefitFactorUsd.Text) * healthBenefitFactor;
                        }
                    }

                    EmployeeInformationCostExceptionsInformation model = new EmployeeInformationCostExceptionsInformation(employeeInformationTDS);
                    model.Insert(costId, work_, unitOfMeasurement, payRateCad, burdenRateCad, totalCostCad, payRateUsd, burdenRateUsd, totalCostUsd, false, companyId, false, benefitFactorCad, benefitFactorUsd, healthBenefitUsd);

                    Session.Remove("employeesCostsExceptionsDummy");
                    Session["employeeInformationTDS"] = employeeInformationTDS;

                    string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                    odsCostsExceptions.FilterExpression = filterOptions;

                    grdCostsExceptions.DataBind();
                }
            }
        }



        
        private bool ValidateNotesFooter()
        {
            string subject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
            string note = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();

            if ((subject != "") || (note != ""))
            {
                return true;
            }

            return false;
        }



        private bool ValidateCostsFooter()
        {
            DateTime? date_ = null; if (((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.HasValue) date_ = ((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value;
            decimal? payRateCad = null; if (((TextBox)grdCosts.FooterRow.FindControl("tbxPayRateCadNew")).Text.Trim() != "") payRateCad = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxPayRateCadNew")).Text.Trim());
            decimal? payRateUsd = null; if (((TextBox)grdCosts.FooterRow.FindControl("tbxPayRateUsdNew")).Text.Trim() != "") payRateUsd = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxPayRateUsdNew")).Text.Trim());

            if ((date_.HasValue) || (payRateCad.HasValue) || (payRateUsd.HasValue))
            {
                return true;
            }

            return false;
        }



        private bool ValidateCostsExceptionsFooter()
        {
            string work_ = ""; if (((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWork_New")).SelectedValue != "(Select)") work_ = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWork_New")).SelectedValue;
            decimal? payRateCad = null; if (((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionPayRateCadNew")).Text.Trim() != "") payRateCad = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionPayRateCadNew")).Text.Trim());
            decimal? payRateUsd = null; if (((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionPayRateUsdNew")).Text.Trim() != "") payRateUsd = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionPayRateUsdNew")).Text.Trim());

            if ((work_ != "") || (payRateCad.HasValue) || (payRateUsd.HasValue))
            {
                return true;
            }

            return false;
        }



        protected void AddNotesNewEmptyFix(GridView grdView)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                EmployeeInformationTDS.NoteInformationDataTable dt = new EmployeeInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", false, companyId, false);
                Session["employeesNotesDummy"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                EmployeeInformationTDS.NoteInformationDataTable dt = (EmployeeInformationTDS.NoteInformationDataTable)Session["employeesNotesDummy"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddVacationsNewEmptyFix(GridView grdView)
        {
            if (grdVacations.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                EmployeeInformationTDS.VacationInformationDataTable dt = new EmployeeInformationTDS.VacationInformationDataTable();
                dt.AddVacationInformationRow(0, DateTime.Now, DateTime.Now, "", "", false, companyId, 0, 0);
                Session["employeesVacationsDummy"] = dt;

                grdVacations.DataBind();
            }

            // Normally executes at all postbacks
            if (grdVacations.Rows.Count == 1)
            {
                EmployeeInformationTDS.VacationInformationDataTable dt = (EmployeeInformationTDS.VacationInformationDataTable)Session["employeesVacationsDummy"];
                if (dt != null)
                {
                    grdVacations.Rows[0].Visible = false;
                    grdVacations.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsNewEmptyFix(GridView grdView)
        {
            if (grdCosts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                EmployeeInformationTDS.CostInformationDataTable dt = new EmployeeInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, DateTime.Now, "", 0, 0, 0, 0, 0, 0, false, companyId, false, 0, 0, 0);
                Session["employeesCostsDummy"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                EmployeeInformationTDS.CostInformationDataTable dt = (EmployeeInformationTDS.CostInformationDataTable)Session["employeesCostsDummy"];
                if (dt != null)
                {
                    grdCosts.Rows[0].Visible = false;
                    grdCosts.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsExceptionsNewEmptyFix(GridView grdView)
        {
            if (grdCostsExceptions.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                EmployeeInformationTDS.CostExceptionsInformationDataTable dt = new EmployeeInformationTDS.CostExceptionsInformationDataTable();
                dt.AddCostExceptionsInformationRow(Convert.ToInt32(Session["costIdSelected"]), -1, -1, "", "", 0, 0, 0, 0, 0, 0, false, companyId, false, 0, 0, 0);
                Session["employeesCostsExceptionsDummy"] = dt;

                grdCostsExceptions.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCostsExceptions.Rows.Count == 1)
            {
                EmployeeInformationTDS.CostExceptionsInformationDataTable dt = (EmployeeInformationTDS.CostExceptionsInformationDataTable)Session["employeesCostsExceptionsDummy"];
                if (dt != null)
                {
                    grdCostsExceptions.Rows[0].Visible = false;
                    grdCostsExceptions.Rows[0].Controls.Clear();
                }
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save type history information
                EmployeeInformationTypeHistoryInformation employeeInformationTypeHistoryInformation = new EmployeeInformationTypeHistoryInformation(employeeInformationTDS);
                employeeInformationTypeHistoryInformation.Save(employeeId, companyId);
                
                // Save notes information
                EmployeeInformationNoteInformation employeeInformationNoteInformation = new EmployeeInformationNoteInformation(employeeInformationTDS);
                employeeInformationNoteInformation.Save(companyId);

                // Save costs information
                EmployeeInformationCostInformation employeeInformationCostInformation = new EmployeeInformationCostInformation(employeeInformationTDS);
                employeeInformationCostInformation.Save(companyId);

                // Save costs exceptions information
                EmployeeInformationCostExceptionsInformation employeeInformationCostExceptionsInformation = new EmployeeInformationCostExceptionsInformation(employeeInformationTDS);
                employeeInformationCostExceptionsInformation.Save(companyId, employeeId);

                // Save categories approve timesheets information
                EmployeeInformationCategoryApproveTimesheetsInformation employeeInformationCategoryApproveTimesheetsInformation = new EmployeeInformationCategoryApproveTimesheetsInformation(employeeInformationTDS);
                employeeInformationCategoryApproveTimesheetsInformation.Save();

                // Save employee information 
                EmployeeInformationBasicInformation employeeInformationBasicInformation = new EmployeeInformationBasicInformation(employeeInformationTDS);
                employeeInformationBasicInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                employeeInformationTDS.AcceptChanges();
                Session["employeeInformationTDS"] = employeeInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void SelectLastCostRow()
        {
            // Check last row
            int totalRows = grdCosts.Rows.Count;
            if (totalRows != 0)
            {
                foreach (GridViewRow rowTemp1 in grdCosts.Rows)
                {
                    if (rowTemp1.RowIndex == totalRows - 1)
                    {
                        // ... Mark last row as selected
                        if ((grdCosts.Rows[0].Visible) && (rowTemp1.RowType == DataControlRowType.DataRow) && ((rowTemp1.RowState == DataControlRowState.Normal) || (rowTemp1.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            ((CheckBox)rowTemp1.FindControl("cbxSelected")).Checked = true;

                            // ... Show exceptions for last selected row
                            CheckBox checkbox = ((CheckBox)rowTemp1.FindControl("cbxSelected"));
                            int costId = 0;
                            Session["costIdSelected"] = 0;
                            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                            Session.Remove("employeesCostsExceptionsDummy");
                            grdCostsExceptions.ShowFooter = true;
                            if (checkbox.Checked)
                            {
                                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                                foreach (GridViewRow rowTemp in grdCosts.Rows)
                                {
                                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                                    {
                                        if (Validator.IsValidInt32(((Label)rowTemp.FindControl("lblCostID")).Text))
                                        {
                                            int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                                            if (costId != costTemp)
                                            {
                                                ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                                            }
                                        }
                                    }
                                }

                                Session.Remove("costIdSelected");
                                Session["costIdSelected"] = costId;
                            }

                            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                            odsCostsExceptions.FilterExpression = filterOptions;
                        }
                    }
                }
            }
        }



        protected string GetNoteCreatedBy(object userId)
        {
            if (userId != DBNull.Value)
            {
                if (Convert.ToInt32(userId) != -1)
                {
                    try
                    {
                        // Created By
                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

                        return userName.ToString();
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 2)
                {
                    return string.Format("{0:0.00}", Convert.ToDecimal(value));
                }
                else
                {
                    return string.Format("{0:0.0}", Convert.ToDecimal(value));
                }
            }
            else
            {
                return "";
            }
        }

        
        
    }
}