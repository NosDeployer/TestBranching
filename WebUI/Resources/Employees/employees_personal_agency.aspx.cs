using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.Server;
using System.Web.UI.HtmlControls;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_personal_agency
    /// </summary>
    public partial class employees_personal_agency : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected PersonalAgencyInformationTDS personalAgencyInformationTDS;
        protected PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable personalAgencyInformation;






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
                if (!Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_ADMIN"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_personal_agency.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "yes";
                Session.Remove("personalAgencyInformationDummy");
                Session.Remove("personalAgencyInformation");

                ViewState["update"] = Request.QueryString["update"];

                // ... Load personalAgency to edit
                personalAgencyInformationTDS = new PersonalAgencyInformationTDS();

                PersonalAgencyInformationGateway personalAgencyInformationGateway = new PersonalAgencyInformationGateway(personalAgencyInformationTDS);
                personalAgencyInformationGateway.Load(Int32.Parse(hdfCompanyId.Value.Trim()));

                // ... Store datasets
                Session["personalAgencyInformationTDS"] = personalAgencyInformationTDS;
                Session["personalAgencyInformation"] = personalAgencyInformationTDS.PersonalAgencyInformation;
            }
            else
            {
                // Restore datasets
                personalAgencyInformationTDS = (PersonalAgencyInformationTDS)Session["personalAgencyInformationTDS"];
                personalAgencyInformation = personalAgencyInformationTDS.PersonalAgencyInformation;
            }
        }



        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Personnel Agencies";
        }



        protected void grdPersonalAgency_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //Page.Validate("personalAgencyData");
            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway();

            string personalAgencyName = e.Keys["PersonalAgencyName"].ToString();
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (!employeePersonalAgencyGateway.IsUsedInEmployee(personalAgencyName, companyId))
            {
                // If the gridview is edition mode
                if (grdPersonalAgency.EditIndex >= 0)
                {
                    grdPersonalAgency.UpdateRow(grdPersonalAgency.EditIndex, true);
                }

                PersonalAgencyInformation model = new PersonalAgencyInformation(personalAgencyInformationTDS);

                // Delete Personnel Agency
                model.Delete(personalAgencyName, companyId);

                // Store dataset
                Session.Remove("personalAgencyInformationDummy");
                Session["personalAgencyInformationTDS"] = personalAgencyInformationTDS;
                Session["personalAgencyInformation"] = personalAgencyInformationTDS.PersonalAgencyInformation;
            }
            else
            {
                Page.Validate("personalAgencyData");
                e.Cancel = true;
            }
        }



        protected void grdPersonalAgency_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // If the gridview is edition mode
                    if (grdPersonalAgency.EditIndex >= 0)
                    {
                        grdPersonalAgency.UpdateRow(grdPersonalAgency.EditIndex, true);
                    }
                    GrdPersonalAgencyAdd();
                    break;
            }
        }



        protected void grdPersonalAgency_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("personalAgencyDataEdit");
            if (Page.IsValid)
            {
                string originalPersonalAgencyName = e.Keys["PersonalAgencyName"].ToString();
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string newPersonalAgencyName = ((TextBox)grdPersonalAgency.Rows[e.RowIndex].FindControl("tbxPersonalAgencyNameEdit")).Text.Trim();

                if (originalPersonalAgencyName != newPersonalAgencyName)
                {
                    // Update data
                    PersonalAgencyInformation model = new PersonalAgencyInformation(personalAgencyInformationTDS);
                    model.Update(originalPersonalAgencyName, newPersonalAgencyName, companyId);
                }

                // Store dataset
                Session.Remove("personalAgencyInformationDummy");
                Session["personalAgencyInformationTDS"] = personalAgencyInformationTDS;
                Session["personalAgencyInformation"] = personalAgencyInformationTDS.PersonalAgencyInformation;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void cvPersonalAgencyNameEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            string originalPersonalAgencyName = ((HiddenField)grdPersonalAgency.Rows[grdPersonalAgency.EditIndex].FindControl("hdfPersonalAgencyNameEdit")).Value;

            if (originalPersonalAgencyName != args.Value.Trim())
            {
                PersonalAgencyInformationGateway personalAgencyInformationGateway = new PersonalAgencyInformationGateway(personalAgencyInformationTDS);

                if (personalAgencyInformationGateway.Table.Rows.Count > 0)
                {
                    foreach (PersonalAgencyInformationTDS.PersonalAgencyInformationRow row in (PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)personalAgencyInformationGateway.Table)
                    {
                        if (row.PersonalAgencyName == args.Value.Trim())
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }



        protected void cvPersonalAgencyNameNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            PersonalAgencyInformationGateway personalAgencyInformationGateway = new PersonalAgencyInformationGateway(personalAgencyInformationTDS);

            if (personalAgencyInformationGateway.Table.Rows.Count > 0)
            {
                foreach (PersonalAgencyInformationTDS.PersonalAgencyInformationRow row in (PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)personalAgencyInformationGateway.Table)
                {
                    if (row.PersonalAgencyName == args.Value.Trim())
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvPersonalAgencyName_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            EmployeePersonalAgencyGateway employeePersonalAgencyGateway = new EmployeePersonalAgencyGateway();

            if (employeePersonalAgencyGateway.IsUsedInEmployee(args.Value.Trim(), Int32.Parse(hdfCompanyId.Value)))
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdPersonalAgency_DataBound(object sender, EventArgs e)
        {
            AddPersonalAgencyNewEmptyFix(grdPersonalAgency);
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable GetPersonalAgency()
        {
            personalAgencyInformation = (PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)Session["personalAgencyInformationDummy"];

            if (personalAgencyInformation == null)
            {
                personalAgencyInformation = ((PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)Session["personalAgencyInformation"]);
            }

            return personalAgencyInformation;
        }
        

        
        public void DummyPersonalAgencyNew(string original_PersonalAgencyName)
        {
        }



        public void DummyPersonalAgencyNew(string PersonalAgencyName, string original_PersonalAgencyName)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_personal_agency.js");
        }
                


        private void Save()
        {
            try
            {
                // Validate page
                // Add data if exist at grid's foot
                GrdPersonalAgencyAdd();

                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Update data
                UpdateDatabase();

                ViewState["update"] = "yes";
                Response.Write("<script language='javascript'> {window.close();}</script>");
            }
            catch
            {
                ViewState["update"] = "yes";
                Response.Write("<script language='javascript'> {window.close();}</script>");
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                PersonalAgencyInformation personalAgencyInformation = new PersonalAgencyInformation(personalAgencyInformationTDS);
                personalAgencyInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                personalAgencyInformationTDS.AcceptChanges();
                Session["personalAgencyInformationTDS"] = personalAgencyInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddPersonalAgencyNewEmptyFix(GridView grdPersonalAgency)
        {
            if (grdPersonalAgency.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable dt = new PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable();
                dt.AddPersonalAgencyInformationRow("", companyId, false, false, "", false);
                Session["personalAgencyInformationDummy"] = dt;

                grdPersonalAgency.DataBind();
            }

            // normally executes at all postbacks
            if (grdPersonalAgency.Rows.Count == 1)
            {
                PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable dt = (PersonalAgencyInformationTDS.PersonalAgencyInformationDataTable)Session["personalAgencyInformationDummy"];
                if (dt != null)
                {
                    grdPersonalAgency.Rows[0].Visible = false;
                    grdPersonalAgency.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdPersonalAgencyAdd()
        {
            if (ValidatePersonalAgencyFooter())
            {
                Page.Validate("personalAgencyDataNew");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string personalAgencyName = ((TextBox)grdPersonalAgency.FooterRow.FindControl("tbxPersonalAgencyNameNew")).Text.Trim();
                    
                    PersonalAgencyInformation model = new PersonalAgencyInformation(personalAgencyInformationTDS);
                    model.Insert(personalAgencyName, companyId, false, false);

                    Session.Remove("personalAgencyInformationDummy");
                    Session["personalAgencyInformationTDS"] = personalAgencyInformationTDS;
                    Session["personalAgencyInformation"] = personalAgencyInformationTDS.PersonalAgencyInformation;

                    grdPersonalAgency.DataBind();
                    grdPersonalAgency.PageIndex = grdPersonalAgency.PageCount - 1;
                }
            }
        }



        private bool ValidatePersonalAgencyFooter()
        {
            string personalAgency = ((TextBox)grdPersonalAgency.FooterRow.FindControl("tbxPersonalAgencyNameNew")).Text.Trim();

            if (personalAgency != "")
            {
                return true;
            }

            return false;
        }

        protected void grdPersonalAgency_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdPersonalAgency.EditIndex >= 0)
            {
                grdPersonalAgency.UpdateRow(grdPersonalAgency.EditIndex, true);
            }
        }



    }
}