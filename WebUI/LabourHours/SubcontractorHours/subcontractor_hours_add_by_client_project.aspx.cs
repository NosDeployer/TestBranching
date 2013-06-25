using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours
{
    /// <summary>
    /// subcontractor_hours_add_by_client_project
    /// </summary>
    public partial class subcontractor_hours_add_by_client_project : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SubcontractorHoursAddTDS subcontractorAddTDS;
        protected SubcontractorHoursAddTDS.SubcontractorHoursDataTable projectSubcontractorCost;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS 
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if ((string)Request.QueryString["source_page"] == null)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in subcontractor_hours_add_by_client_project.aspx");
                    }
                }

                // Tag page
                Session.Remove("projectSubcontractorCostDummyByClientProject");
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Store datasets
                subcontractorAddTDS = new SubcontractorHoursAddTDS();
                Session["subcontractorAddTDSByClientProject"] = subcontractorAddTDS;
                Session["projectSubcontractorCostByClientProject"] = subcontractorAddTDS.SubcontractorHours;

                StoreNavigatorState();
            }
            else
            {
                // Restore datasets
                subcontractorAddTDS = (SubcontractorHoursAddTDS)Session["subcontractorAddTDSByClientProject"];
                projectSubcontractorCost = subcontractorAddTDS.SubcontractorHours;
                Session["projectSubcontractorCostByClientProject"] = subcontractorAddTDS.SubcontractorHours;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
        }



        protected void grdSubcontractors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }

            // Delete subcontractor
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            // Delete team project time details
            SubcontractorHoursAddSubcontractorHours subcontractorAddProjectSubcontractorsCosts = new SubcontractorHoursAddSubcontractorHours(subcontractorAddTDS);
            subcontractorAddProjectSubcontractorsCosts.Delete(projectId, refId);

            // Store dataset
            Session["subcontractorAddTDSByClientProject"] = subcontractorAddTDS;
            Session.Remove("projectSubcontractorCostDummyByClientProject");
            projectSubcontractorCost = subcontractorAddTDS.SubcontractorHours;
            Session["projectSubcontractorCostByClientProject"] = subcontractorAddTDS.SubcontractorHours;
        }



        protected void grdSubcontractors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Project Time Gridview, if the gridview is edition mode
                    if (grdSubcontractors.EditIndex >= 0)
                    {
                        grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
                    }

                    // Add New Project Time
                    GrdSubcontractorsDetailAdd();
                    break;
            }
        }



        protected void grdSubcontractors_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("generalData");
            if (Page.IsValid)
            {
                Page.Validate("DataEdit");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int refId = Int32.Parse(((Label)grdSubcontractors.Rows[e.RowIndex].FindControl("lblRefIdEdit")).Text);
                    DateTime date = (DateTime)((RadDatePicker)grdSubcontractors.Rows[e.RowIndex].FindControl("tkrdpDateEdit")).SelectedDate;

                    int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractors.Rows[e.RowIndex].FindControl("ddlSubcontractorEdit")).SelectedValue);
                    string name = ((DropDownList)grdSubcontractors.Rows[e.RowIndex].FindControl("ddlSubcontractorEdit")).SelectedItem.Text;

                    string quantityString = ((TextBox)grdSubcontractors.Rows[e.RowIndex].FindControl("tbxQuantityEdit")).Text;
                    decimal quantity1 = decimal.Round(decimal.Parse(quantityString), 1);
                    double quantity = double.Parse(quantity1.ToString());

                    decimal rate = decimal.Round(decimal.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].FindControl("tbxRateEdit")).Text), 2);
                    decimal total = decimal.Round(decimal.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].FindControl("tbxTotalEdit")).Text), 2);
                    decimal rateCad = 0;
                    decimal totalCad = 0;
                    decimal rateUsd = 0;
                    decimal totalUsd = 0;
                    int projectId = Int32.Parse(ddlProject.SelectedValue);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        rateCad = rate;
                        totalCad = total;
                    }
                    else
                    {
                        rateUsd = rate;
                        totalUsd = total;
                    }

                    string comment = ((TextBox)grdSubcontractors.Rows[e.RowIndex].FindControl("tbxCommentEdit")).Text;
                    bool deleted = false;

                    // Update Data
                    SubcontractorHoursAddSubcontractorHours subcontractorAddProjectSubcontractorsCosts = new SubcontractorHoursAddSubcontractorHours(subcontractorAddTDS);
                    subcontractorAddProjectSubcontractorsCosts.Update(projectId, refId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId, name, ddlClient.SelectedItem.Text, ddlProject.SelectedItem.Text, Int32.Parse(ddlClient.SelectedValue));

                    // Store dataset
                    Session["subcontractorAddTDSByClientProject"] = subcontractorAddTDS;
                    Session.Remove("projectSubcontractorCostDummyByClientProject");
                    projectSubcontractorCost = subcontractorAddTDS.SubcontractorHours;
                    Session["projectSubcontractorCostByClientProject"] = subcontractorAddTDS.SubcontractorHours;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTORS - AUXILIAR EVENTS
        //

        protected void tbxQuantityFooter_TextChanged(object sender, EventArgs e)
        {
            string quantity = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxQuantityFooter")).Text;
            decimal rate = decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxRateFooter")).Text);
            ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxTotalFooter")).Text = (decimal.Parse(quantity) * rate).ToString();
        }



        protected void tbxQuantityEdit_TextChanged(object sender, EventArgs e)
        {
            string quantity = ((TextBox)grdSubcontractors.Rows[grdSubcontractors.EditIndex].FindControl("tbxQuantityEdit")).Text;
            decimal rate = decimal.Parse(((TextBox)grdSubcontractors.Rows[grdSubcontractors.EditIndex].FindControl("tbxRateEdit")).Text);
            ((TextBox)grdSubcontractors.Rows[grdSubcontractors.EditIndex].FindControl("tbxTotalEdit")).Text = (decimal.Parse(quantity) * rate).ToString();
        }



        protected void tbxRateFooter_TextChanged(object sender, EventArgs e)
        {
            string quantity = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxQuantityFooter")).Text;
            decimal rate = decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxRateFooter")).Text);
            ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxTotalFooter")).Text = (decimal.Parse(quantity) * rate).ToString();
        }



        protected void tbxRateEdit_TextChanged(object sender, EventArgs e)
        {
            string quantity = ((TextBox)grdSubcontractors.Rows[grdSubcontractors.EditIndex].FindControl("tbxQuantityEdit")).Text;
            decimal rate = decimal.Parse(((TextBox)grdSubcontractors.Rows[grdSubcontractors.EditIndex].FindControl("tbxRateEdit")).Text);
            ((TextBox)grdSubcontractors.Rows[grdSubcontractors.EditIndex].FindControl("tbxTotalEdit")).Text = (decimal.Parse(quantity) * rate).ToString();
        }



        protected void grdSubcontractors_DataBound(object sender, EventArgs e)
        {
            AddSubcontractorsNewEmptyFix(grdSubcontractors);
        }



        protected void grdSubcontractors_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                odsSubcontractorsListEdit.DataBind();

                string teamSubcontractorsId = ((Label)e.Row.FindControl("lblSubcontractorIdEdit")).Text.Trim();

                // Load actual id
                ((DropDownList)e.Row.FindControl("ddlSubcontractorEdit")).SelectedValue = teamSubcontractorsId;
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                // Get date
                DateTime date = DateTime.Parse(((Label)e.Row.FindControl("lblDate")).Text);

                // Set new format
                ((Label)e.Row.FindControl("lblDate")).Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();
            }
        }



        protected void grdSubcontractors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }
        }



        public SubcontractorHoursAddTDS.SubcontractorHoursDataTable GetSubcontractorsDetail()
        {
            projectSubcontractorCost = (SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Session["projectSubcontractorCostDummyByClientProject"];
            if (projectSubcontractorCost == null)
            {
                projectSubcontractorCost = ((SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Session["projectSubcontractorCostByClientProject"]);
            }

            return projectSubcontractorCost;
        }



        public void DummySubcontractorsDetail(int ProjectID, int RefID, int original_ProjectID, int original_RefID)
        {
        }



        public void DummySubcontractorsDetail(int original_ProjectID, int original_RefID)
        {
        }



        protected void AddSubcontractorsNewEmptyFix(GridView grdSubcontractors)
        {
            if (grdSubcontractors.Rows.Count == 0)
            {
                SubcontractorHoursAddTDS.SubcontractorHoursDataTable dt = new SubcontractorHoursAddTDS.SubcontractorHoursDataTable();
                dt.AddSubcontractorHoursRow(-1, -1, -1, DateTime.Now, -1, -1, -1, -1, -1, "", false, -1, false, "", 0, 0, "", "", 1);
                Session["projectSubcontractorCostDummyByClientProject"] = dt;

                grdSubcontractors.DataBind();
            }

            // normally executes at all postbacks
            if (grdSubcontractors.Rows.Count == 1)
            {
                SubcontractorHoursAddTDS.SubcontractorHoursDataTable dt = (SubcontractorHoursAddTDS.SubcontractorHoursDataTable)Session["projectSubcontractorCostDummyByClientProject"];
                if (dt != null)
                {
                    grdSubcontractors.Rows[0].Visible = false;
                    grdSubcontractors.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdSubcontractorsDetailAdd()
        {
            Page.Validate("generalData");
            if (Page.IsValid)
            {
                if (FooterValidate())
                {
                    Page.Validate("DataNew");
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        DateTime date = (DateTime)((RadDatePicker)grdSubcontractors.FooterRow.FindControl("tkrdpDateFooter")).SelectedDate;

                        int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorFooter")).SelectedValue);
                        string name = ((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorFooter")).SelectedItem.Text;

                        string quantityString = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxQuantityFooter")).Text;
                        decimal quantity1 = decimal.Round(decimal.Parse(quantityString), 1);
                        double quantity = double.Parse(quantity1.ToString());
                        decimal rate = decimal.Round(decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxRateFooter")).Text), 2);
                        decimal total = decimal.Round(decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxTotalFooter")).Text), 2);
                        string comment = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentFooter")).Text;
                        bool deleted = false;
                        bool inDatabase = false;
                        int projectId = Int32.Parse(ddlProject.SelectedValue);
                        decimal rateCad = 0;
                        decimal totalCad = 0;
                        decimal rateUsd = 0;
                        decimal totalUsd = 0;
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            rateCad = rate;
                            totalCad = total;
                            rateUsd = rate;
                            totalUsd = total;
                        }
                        else
                        {
                            rateCad = rate;
                            totalCad = total;
                            rateUsd = rate;
                            totalUsd = total;
                        }

                        // Insert Data
                        SubcontractorHoursAddSubcontractorHours subcontractorAddProjectSubcontractorsCosts = new SubcontractorHoursAddSubcontractorHours(subcontractorAddTDS);
                        subcontractorAddProjectSubcontractorsCosts.Insert(projectId, subcontractorId, date, quantity, rateCad, totalCad, rateUsd, totalUsd, comment, deleted, companyId, inDatabase, name, ddlClient.SelectedItem.Text, ddlProject.SelectedItem.Text, Int32.Parse(ddlClient.SelectedValue));

                        // Store dataset
                        Session["subcontractorAddTDSByClientProject"] = subcontractorAddTDS;
                        Session.Remove("projectSubcontractorCostDummyByClientProject");
                        projectSubcontractorCost = subcontractorAddTDS.SubcontractorHours;
                        Session["projectSubcontractorCostByClientProject"] = subcontractorAddTDS.SubcontractorHours;

                        grdSubcontractors.DataBind();
                        grdSubcontractors.PageIndex = grdSubcontractors.PageCount - 1;
                    }
                }
            }
        }



        protected bool FooterValidate()
        {
            int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorFooter")).SelectedValue);

            if (subcontractorId != -1)
            {
                return true;
            }

            return false;
        }



        private bool ValidatePage()
        {
            bool valid = true;

            Page.Validate("DataNew");
            if (Page.IsValid)
            {
                Page.Validate("DataEdit");
                if (!Page.IsValid) valid = false;
            }

            return valid;
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mAddHoursBySubcontractor":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_add_by_subcontractor.aspx?source_page=lm" + GetNavigatorState();
                    Response.Redirect(url);
                    break;

                case "mAddHoursByClientProject":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_add_by_client_project.aspx?source_page=lm" + GetNavigatorState();
                    Response.Redirect(url);
                    break;

                case "mSearch":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_navigator.aspx?source_page=out";
                    Response.Redirect(url);
                    break;
            }
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";
            switch (e.Item.Value)
            {
                case "mSave":
                    if (ValidatePage())
                    {
                        UpdateDatabase();
                        url = "./subcontractor_hours_navigator.aspx?source_page=lm" + GetNavigatorState();
                        if (url != "") Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    url = "./subcontractor_hours_navigator.aspx?source_page=lm" + GetNavigatorState();

                    if (url != "") Response.Redirect(url);
                    break;
            }
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" + Request.QueryString["search_ddlSubcontractor"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractor_hours_add_by_client_project.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Save subcontractor costs
                SubcontractorHoursAddSubcontractorHours subcontractorAddProjectSubcontractorsCosts = new SubcontractorHoursAddSubcontractorHours(subcontractorAddTDS);
                subcontractorAddProjectSubcontractorsCosts.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                subcontractorAddTDS.AcceptChanges();
                Session["subcontractorAddTDSByClientProject"] = subcontractorAddTDS;
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