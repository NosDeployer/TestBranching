using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Subcontractors;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Subcontractors
{
    /// <summary>
    /// subcontractors_navigator
    /// </summary>
    public partial class subcontractors_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SubcontractorsSetupTDS subcontractorsSetupTDS;
        protected SubcontractorsSetupTDS.SubcontractorsSetupDataTable subcontractorsSetupTable;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_SUBCONTRACTORS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_SUBCONTRACTORS_EDIT"]))  && Convert.ToBoolean(Session["sgLFS_RESOURCES_SUBCONTRACTORS_DELETE"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in subcontractors_navigator.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();               
                
                // Prepare initial data
                Session.Remove("subcontractorsSetupTableDummy");                                         
                
                // If coming from 
                // ... Left Menu or select_project
                if (Request.QueryString["source_page"] == "out")
                {
                    // Load            
                    subcontractorsSetupTDS = new SubcontractorsSetupTDS();

                    SubcontractorsSetupSubcontractorsSetup model = new SubcontractorsSetupSubcontractorsSetup(subcontractorsSetupTDS);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    model.LoadAll(companyId);

                    // Store tables            
                    Session["subcontractorsSetupTDS"] = subcontractorsSetupTDS;
                    subcontractorsSetupTable = subcontractorsSetupTDS.SubcontractorsSetup;
                    Session["subcontractorsSetupTable"] = subcontractorsSetupTable;
                }
            }             
            else
            {    
                // Restore datasets
                subcontractorsSetupTDS = (SubcontractorsSetupTDS)Session["subcontractorsSetupTDS"];
                subcontractorsSetupTable = subcontractorsSetupTDS.SubcontractorsSetup;
                Session["subcontractorsSetupTable"] = subcontractorsSetupTable;                             
            }
        }



        protected void grdCompaniesSetup_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int companiesId = (int)e.Keys["COMPANIES_ID"];
            DateTime date = (DateTime)e.Keys["Date"];

            bool active = ((CheckBox)grdCompaniesSetup.Rows[e.RowIndex].Cells[2].FindControl("cbxActiveEdit")).Checked;

            SubcontractorsSetupSubcontractorsSetup model = new SubcontractorsSetupSubcontractorsSetup(subcontractorsSetupTDS);
            model.Update(companiesId, date, active);

            // Store dataset
            Session["subcontractorsSetupTDS"] = subcontractorsSetupTDS;
            subcontractorsSetupTable = subcontractorsSetupTDS.SubcontractorsSetup;
            Session["subcontractorsSetupTable"] = subcontractorsSetupTable;
        }



        protected void grdCompaniesSetup_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Subcontractors Gridview, if the gridview is edition mode
            if (grdCompaniesSetup.EditIndex >= 0)
            {
                grdCompaniesSetup.UpdateRow(grdCompaniesSetup.EditIndex, true);
            }

            // Delete subcontractor
            int companiesId = (int)e.Keys["COMPANIES_ID"];
            DateTime date = (DateTime)e.Keys["Date"];

            SubcontractorsSetupSubcontractorsSetup model = new SubcontractorsSetupSubcontractorsSetup(subcontractorsSetupTDS);
            model.Delete(companiesId, date);

            // Store dataset
            Session["subcontractorsSetupTDS"] = subcontractorsSetupTDS;
            subcontractorsSetupTable = subcontractorsSetupTDS.SubcontractorsSetup;
            Session["subcontractorsSetupTable"] = subcontractorsSetupTable;
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

        protected void grdCompaniesSetup_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Catalysts Gridview, if the gridview is edition mode
            if (grdCompaniesSetup.EditIndex >= 0)
            {
                grdCompaniesSetup.UpdateRow(grdCompaniesSetup.EditIndex, true);
            }
        }



        protected void grdCompaniesSetup_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int subcontractorId = int.Parse(((Label)e.Row.FindControl("lblCOMPANIES_IDId")).Text);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                SubcontractorsSetupSubcontractorsSetupGateway subcontractorsSetupSubcontractorsSetupGateway = new SubcontractorsSetupSubcontractorsSetupGateway();
                if (subcontractorsSetupSubcontractorsSetupGateway.IsUsedInSubcontractorCosts(subcontractorId, companyId))
                {
                    ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = false;
                }
                else
                {
                    ((ImageButton)e.Row.FindControl("ibtnDelete")).Visible = true;
                }
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

        public SubcontractorsSetupTDS.SubcontractorsSetupDataTable GetCompaniesSetupNew()
        {
            subcontractorsSetupTable = (SubcontractorsSetupTDS.SubcontractorsSetupDataTable)Session["subcontractorsSetupTableDummy"];

            if (subcontractorsSetupTable == null)
            {
                subcontractorsSetupTable = ((SubcontractorsSetupTDS.SubcontractorsSetupDataTable)Session["subcontractorsSetupTable"]);
            }

            return subcontractorsSetupTable;
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractors_navigator.js");
        }



        private void Save()
        {           
            // Subcontractors Gridview
            // ... If the gridview is edition mode
            if (grdCompaniesSetup.EditIndex >= 0)
            {
                grdCompaniesSetup.UpdateRow(grdCompaniesSetup.EditIndex, true);
            }

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
                SubcontractorsSetupSubcontractorsSetup subcontractorsSetupSubcontractorsSetup = new SubcontractorsSetupSubcontractorsSetup(subcontractorsSetupTDS);
                subcontractorsSetupSubcontractorsSetup.Save(companyId);          

                DB.CommitTransaction();

                // Store datasets
                subcontractorsSetupTDS.AcceptChanges();
                Session["subcontractorsSetupTDS"] = subcontractorsSetupTDS;
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
