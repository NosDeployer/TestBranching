using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.InsuranceCompanies;
using LiquiForce.LFSLive.DA.Resources.InsuranceCompanies;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.InsuranceCompanies
{
    /// <summary>
    /// insuranceCompanies_navigator
    /// </summary>
    public partial class insuranceCompanies_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected InsuranceCompaniesSetupTDS insuranceCompaniesSetupTDS;
        protected InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable insuranceCompaniesSetupTable;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_INSURANCECOMPANIES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_INSURANCECOMPANIES_EDIT"])) && Convert.ToBoolean(Session["sgLFS_RESOURCES_INSURANCECOMPANIES_DELETE"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in insuranceCompanies_navigator.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data
                Session.Remove("insuranceCompaniesSetupTableDummy");
                tdNoResults.Visible = false;

                // If coming from 
                // ... Left Menu or select_project
                if (Request.QueryString["source_page"] == "out")
                {
                    // Load            
                    insuranceCompaniesSetupTDS = new InsuranceCompaniesSetupTDS();

                    InsuranceCompaniesSetupInsuranceCompaniesSetup model = new InsuranceCompaniesSetupInsuranceCompaniesSetup(insuranceCompaniesSetupTDS);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    model.LoadAll(companyId);


                    // Check if there is data
                    InsuranceCompaniesSetupInsuranceCompaniesSetup modelForMessage = new InsuranceCompaniesSetupInsuranceCompaniesSetup(insuranceCompaniesSetupTDS);
                    modelForMessage.Load(companyId);

                    if (modelForMessage.Table.Rows.Count > 0)
                    {
                        tdNoResults.Visible = false;
                    }
                    else
                    {
                        tdNoResults.Visible = true;
                    }

                    // Store tables            
                    Session["insuranceCompaniesSetupTDS"] = insuranceCompaniesSetupTDS;
                    Session["insuranceCompaniesSetupTable"] = insuranceCompaniesSetupTDS.InsuranceCompaniesSetup;
                }
            }
            else
            {
                // Restore datasets
                insuranceCompaniesSetupTDS = (InsuranceCompaniesSetupTDS)Session["insuranceCompaniesSetupTDS"];
                Session["insuranceCompaniesSetupTable"] = insuranceCompaniesSetupTDS.InsuranceCompaniesSetup;
            }
        }



        protected void grdCompaniesSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Delete subcontractor
            int companiesId = (int)e.Keys["COMPANIES_ID"];
            DateTime date = (DateTime)e.Keys["Date"];

            InsuranceCompaniesSetupInsuranceCompaniesSetup model = new InsuranceCompaniesSetupInsuranceCompaniesSetup(insuranceCompaniesSetupTDS);
            model.Delete(companiesId, date);

            // Store dataset
            Session["insuranceCompaniesSetupTDS"] = insuranceCompaniesSetupTDS;
            Session["insuranceCompaniesSetupTable"] = insuranceCompaniesSetupTDS.InsuranceCompaniesSetup;
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm8 master = (mForm8)this.Master;
            master.ActiveToolbar = "Resources";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        // 

        protected void grdCompaniesSetup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                //int subcontractorId = int.Parse(((Label)e.Row.FindControl("lblCOMPANIES_IDId")).Text);
                //int companyId = Int32.Parse(hdfCompanyId.Value);

                //SubcontractorsSetupSubcontractorsSetupGateway subcontractorsSetupSubcontractorsSetupGateway = new SubcontractorsSetupSubcontractorsSetupGateway();
                //if (subcontractorsSetupSubcontractorsSetupGateway.IsUsedInSubcontractorHours(subcontractorId, companyId))
                //{
                //    ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = false;
                //}
                //else
                //{
                //    ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = true;
                //}
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //


        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSave":
                    this.Save();
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {

            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable GetCompaniesSetupNew()
        {
            insuranceCompaniesSetupTable = (InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable)Session["insuranceCompaniesSetupTableDummy"];

            if (insuranceCompaniesSetupTable == null)
            {
                insuranceCompaniesSetupTable = ((InsuranceCompaniesSetupTDS.InsuranceCompaniesSetupDataTable)Session["insuranceCompaniesSetupTable"]);
            }

            return insuranceCompaniesSetupTable;
        }



        public void DummyCompaniesSetupNew(int Companies_ID, int original_COMPANIES_ID, DateTime Date, DateTime original_Date)
        {
        }



        public void DummyCompaniesSetupNew(int original_COMPANIES_ID, DateTime original_Date)
        {
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./insuranceCompanies_navigator.js");
        }



        private void Save()
        {
            // Update database
            UpdateDatabase();
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save subcontractors
                InsuranceCompaniesSetupInsuranceCompaniesSetup insuranceCompaniesSetupInsuranceCompaniesSetup = new InsuranceCompaniesSetupInsuranceCompaniesSetup(insuranceCompaniesSetupTDS);
                insuranceCompaniesSetupInsuranceCompaniesSetup.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                insuranceCompaniesSetupTDS.AcceptChanges();
                Session["insuranceCompaniesSetupTDS"] = insuranceCompaniesSetupTDS;
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
