using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_summary
    /// </summary>
    public partial class employees_summary : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_summary.aspx");
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
                    ViewState["update"] = "yes";

                    // ... ... Set initial tab
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

                        Session["costIdSelected"] = 0;

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

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["employeeInformationTDS"] = employeeInformationTDS;
                }

                // ... employees_delete.aspx or employees_edit.aspx
                if ((Request.QueryString["source_page"] == "employees_delete.aspx") || (Request.QueryString["source_page"] == "employees_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
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

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
                }

                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", 0, 0);
                odsCostsExceptions.FilterExpression = filterOptions;

                // Prepare initial data
                // ... Data for current employee              
                LoadData();

                // Databind
                Page.DataBind();
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
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdVacations_DataBound(object sender, EventArgs e)
        {
            AddVacationsNewEmptyFix(grdVacations);
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix
            AddCostsNewEmptyFix(grdCosts);

            // Select last checkbox
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

                            // ... Show exceptions for first selected row
                            CheckBox checkbox = ((CheckBox)rowTemp1.FindControl("cbxSelected"));
                            int costId = 0;
                            Session["costIdSelected"] = 0;
                            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                            Session.Remove("employeesCostsExceptionsDummy");
                             
                            if (checkbox.Checked)
                            {
                                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                                foreach (GridViewRow rowTemp in grdCosts.Rows)
                                {
                                    int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                                    if (costId != costTemp)
                                    {
                                        ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
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



        protected void grdCostsExceptions_DataBound(object sender, EventArgs e)
        {
            AddCostsExceptionsNewEmptyFix(grdCostsExceptions);
        }



        protected void cbxSelectedCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("employeesCostsExceptionsDummy");

            if (checkbox.Checked)
            {
                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                foreach (GridViewRow rowTemp in grdCosts.Rows)
                {
                    int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                    if (costId != costTemp)
                    {
                        ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                    }
                }

                Session.Remove("costIdSelected");
                Session["costIdSelected"] = costId;
            }

            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
            odsCostsExceptions.FilterExpression = filterOptions;
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
                case "mEdit":
                    url = "./employees_edit.aspx?source_page=employees_summary.aspx&employee_id=" + hdfCurrentEmployeeId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mDelete":
                    url = "./employees_delete.aspx?source_page=employees_summary.aspx&employee_id=" + hdfCurrentEmployeeId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mLastSearch":
                    url = "./employees_navigator2.aspx?source_page=employees_summary.aspx&employee_id=" + hdfCurrentEmployeeId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = EmployeeNavigator.GetPreviousId((EmployeeNavigatorTDS)Session["employeeNavigatorTDS"], Int32.Parse(hdfCurrentEmployeeId.Value));
                    if (previousId != Int32.Parse(hdfCurrentEmployeeId.Value))
                    {
                        // Redirect
                        url = "./employees_summary.aspx?source_page=employees_navigator2.aspx&employee_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = EmployeeNavigator.GetNextId((EmployeeNavigatorTDS)Session["employeeNavigatorTDS"], Int32.Parse(hdfCurrentEmployeeId.Value));
                    if (nextId != Int32.Parse(hdfCurrentEmployeeId.Value))
                    {
                        // Redirect
                        url = "./employees_summary.aspx?source_page=employees_navigator2.aspx&employee_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
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






        // ////////////////////////////////////////////////////////////////////////
        // PROTECTED METHODS
        //

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
            contentVariables += "var hdfCurrentEmployeeIdId = '" + hdfCurrentEmployeeId.ClientID + "';";
            contentVariables += "var hdfResourceTypeId = '" + hdfResourceType.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }


        #region Load Functions

        private void LoadData()
        {
            // Load Data
            int employeeId = Int32.Parse(hdfCurrentEmployeeId.Value);

            LoadBasicData(employeeId);
            LoadCategoriesApproveTimesheets(employeeId);
            LoadVacationsData(employeeId);            
        }



        private void LoadBasicData(int employeeId)
        {
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
                tbxJobClassType.Text = employeeInformationBasicInformationGateway.GetJobClassType(employeeId);
                tbxCategory.Text = employeeInformationBasicInformationGateway.GetCategory(employeeId);
                tbxPersonalAgency.Text = employeeInformationBasicInformationGateway.GetPersonalAgencyName(employeeId);
                ckbxVacationsManager.Checked = employeeInformationBasicInformationGateway.GetIsVacationsManager(employeeId);
                ckbxApproveTimesheets.Checked = employeeInformationBasicInformationGateway.GetApproveTimesheets(employeeId);
                tbxCrew.Text = employeeInformationBasicInformationGateway.GetCrew(employeeId);

                string type = employeeInformationBasicInformationGateway.GetType(employeeId);
                EmployeeTypeGateway employeeTypeGateway = new EmployeeTypeGateway();
                employeeTypeGateway.LoadByType(type);
                tbxType.Text = employeeTypeGateway.GetDescription(type);

                string state = employeeInformationBasicInformationGateway.GetState(employeeId);
                EmployeeStateGateway employeeStateGateway = new EmployeeStateGateway();
                employeeStateGateway.LoadByState(state);
                tbxState.Text = employeeStateGateway.GetDescription(state);

                // Job costing factors
                decimal? bourdenFactor = employeeInformationBasicInformationGateway.GetBourdenFactor(employeeId);
                if (bourdenFactor.HasValue)
                {
                    tbxBourdenFactor.Text = decimal.Round((decimal)bourdenFactor,1).ToString();
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



    }
}