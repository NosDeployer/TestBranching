using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.BL.Company.Organization;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime
{
    /// <summary>
    /// subcontractor_hours_edit
    /// </summary>
    public partial class subcontractor_hours_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
        //

        protected SubcontractorHoursInformationTDS subcontractorHoursInformationTDS;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
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
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_EDIT"])))                    
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in subcontractor_hours_summary.aspx");
                    }
                }

                // Initialize  variables
                hdfProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfRefId.Value = Request.QueryString["ref_id"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();                               

                // If coming from 
                int refId = Int32.Parse(hdfRefId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);

                // ... subcontractor_hours_navigator2.aspx
                if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "si";

                    int companyId = Int32.Parse(hdfCompanyId.Value);                  

                    subcontractorHoursInformationTDS = new SubcontractorHoursInformationTDS();

                    SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(subcontractorHoursInformationTDS);
                    subcontractorHoursInformationBasicInformationGateway.LoadByProjectIdRefId(projectId, refId,companyId);
               
                    
                    // ... Store dataset
                    Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;
                }

                // ... subcontractor_hours_summary.aspx or subcontractor_hours_edit.aspx
                if ((Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx") || (Request.QueryString["source_page"] == "subcontractor_hours_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    // ... Restore dataset
                    subcontractorHoursInformationTDS = (SubcontractorHoursInformationTDS)Session["subcontractorHoursInformationTDS"];
                }

                // ... Data for current employee
                LoadData(projectId, refId);   
            }
            else
            {
                // Restore datasets
                subcontractorHoursInformationTDS = (SubcontractorHoursInformationTDS)Session["subcontractorHoursInformationTDS"];               
            }                
        }


                
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";            
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTORS - AUXILIAR EVENTS
        //

        protected void tbxQuantity_TextChanged(object sender, EventArgs e)
        {
            string quantity = tbxQuantity.Text.Trim();
            decimal rate = decimal.Parse(tbxRate.Text);            
            tbxTotal.Text = (decimal.Parse(quantity) * rate).ToString();            
        }



        protected void tbxRate_TextChanged(object sender, EventArgs e)
        {
            string quantity = tbxQuantity.Text.Trim();
            decimal rate = decimal.Parse(tbxRate.Text);
            tbxTotal.Text = (decimal.Parse(quantity) * rate).ToString();
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

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":                    
                    if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                    {
                        url = "./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_edit.aspx" + GetNavigatorState() + "&update=yes";
                    }                    
                    else
                    {
                        if (Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx")
                        {                            
                            url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_edit.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=yes" + "&ref_id=" + hdfRefId.Value;
                        }
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = SubcontractorHoursNavigator.GetPreviousId((SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                    if (previousId != Int32.Parse(hdfRefId.Value))
                    {
                        // Redirect
                        url = "./subcontractor_hours_edit.aspx?source_page=subcontractor_hours_navigator2.aspx&ref_id=" + previousId.ToString() + "&project_id=" + hdfProjectId.Value + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = SubcontractorHoursNavigator.GetNextId((SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                    if (nextId != Int32.Parse(hdfRefId.Value))
                    {
                        // Redirect
                        url = "./subcontractor_hours_edit.aspx?source_page=subcontractor_hours_navigator2.aspx&ref_id=" + nextId.ToString() + "&project_id=" + hdfProjectId.Value + GetNavigatorState();
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
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






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractor_hours_edit.js");
        }



        #region Load Functions

        private void LoadData(int projectId, int refId)
        {            
        // Load Data
            SubcontractorHoursInformationBasicInformationGateway subcontractorHoursInformationBasicInformationGateway = new SubcontractorHoursInformationBasicInformationGateway(subcontractorHoursInformationTDS);
            if (subcontractorHoursInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load subcontractor basic data
                tbxSubcontractor.Text = subcontractorHoursInformationBasicInformationGateway.GetSubcontractor(projectId, refId);
                
                if (subcontractorHoursInformationBasicInformationGateway.GetActive(projectId, refId))
                {
                    tbxState.Text = "Active";
                }
                else
                {
                    tbxState.Text = "Inactive";
                }

                tbxClient.Text = subcontractorHoursInformationBasicInformationGateway.GetClient(projectId, refId);
                tbxProject.Text = subcontractorHoursInformationBasicInformationGateway.GetProject(projectId, refId);
                hdfClientId.Value = subcontractorHoursInformationBasicInformationGateway.GetClientID(projectId, refId).ToString();               

                tkrdpDate_.SelectedDate = (DateTime)(subcontractorHoursInformationBasicInformationGateway.GetDate(projectId, refId));                
                    
                decimal quantity = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetQuantity(projectId, refId).ToString());
                tbxQuantity.Text = decimal.Round(quantity,1).ToString();

                if (subcontractorHoursInformationBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                {
                    decimal rate = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                    tbxRate.Text = decimal.Round(rate,2).ToString();

                    decimal total = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetTotalCad(projectId, refId).ToString());
                    tbxTotal.Text = decimal.Round(total,2).ToString();
                }
                else // Usa
                {
                    decimal rate = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                    tbxRate.Text = decimal.Round(rate, 2).ToString();

                    decimal total = decimal.Parse(subcontractorHoursInformationBasicInformationGateway.GetTotalUsd(projectId, refId).ToString());
                    tbxTotal.Text = decimal.Round(total, 2).ToString();
                }

                hdfCountryId.Value = subcontractorHoursInformationBasicInformationGateway.GetCountryId(projectId, refId).ToString();
                tbxComments.Text =  subcontractorHoursInformationBasicInformationGateway.GetComment(projectId, refId);      
            }  
        }

        #endregion



        private void Save()
        {
            // Validate data
            bool validData = false;

            Page.Validate("Data");
            if (Page.IsValid)
            {
                validData = true;
            }

            if (validData)
            {
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);
                int refId = Int32.Parse(hdfRefId.Value);
                Int64 countryId = Int64.Parse(hdfCountryId.Value);

                // ... Get subcontractor hors data
                DateTime? newDate = tkrdpDate_.SelectedDate;            
                double newQuantity = double.Parse(tbxQuantity.Text.Trim());

                decimal newRateCad = 0;
                decimal newTotalCad = 0;
                decimal newRateUsd = 0;
                decimal newTotalUsd = 0;
                if (countryId == 1) // Canada
                {
                    newRateCad = decimal.Parse(tbxRate.Text.Trim());
                    newTotalCad = decimal.Parse(tbxTotal.Text.Trim());
                }
                else
                {
                    newRateUsd = decimal.Parse(tbxRate.Text.Trim());
                    newTotalUsd = decimal.Parse(tbxTotal.Text.Trim());            
                }
                decimal newRate = decimal.Parse(tbxRate.Text.Trim());
                decimal newTotal = decimal.Parse(tbxTotal.Text.Trim());
                string newComment = tbxComments.Text.Trim();

                // Update basic information data
                SubcontractorHoursInformationBasicInformation subcontractorHoursInformationBasicInformation = new SubcontractorHoursInformationBasicInformation(subcontractorHoursInformationTDS);
                subcontractorHoursInformationBasicInformation.Update(projectId, refId, (DateTime)newDate, newQuantity, newRateCad, newTotalCad, newRateUsd, newTotalUsd, newComment);

                // Store datasets
                Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx" )
                {
                    url = "./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_edit.aspx&project_id=" + hdfProjectId.Value + "&ref_id=" + hdfRefId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx")
                {
                    url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_edit.aspx&project_id=" + hdfProjectId.Value + "&ref_id=" + hdfRefId.Value + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            // Validate data
            bool validData = false;

            Page.Validate("Data");
            if (Page.IsValid)
            {
                validData = true;
            }

            if (validData)
            {
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);
                int refId = Int32.Parse(hdfRefId.Value);
                Int64 countryId = Int64.Parse(hdfCountryId.Value);

                // ... Get subcontractor hors data
                DateTime? newDate = tkrdpDate_.SelectedDate;            
                double newQuantity = double.Parse(tbxQuantity.Text.Trim());

                decimal newRateCad = 0;
                decimal newTotalCad = 0;
                decimal newRateUsd = 0;
                decimal newTotalUsd = 0;
                if (countryId == 1) // Canada
                {
                    newRateCad = decimal.Parse(tbxRate.Text.Trim());
                    newTotalCad = decimal.Parse(tbxTotal.Text.Trim());
                }
                else
                {
                    newRateUsd = decimal.Parse(tbxRate.Text.Trim());
                    newTotalUsd = decimal.Parse(tbxTotal.Text.Trim());            
                }
                decimal newRate = decimal.Parse(tbxRate.Text.Trim());
                decimal newTotal = decimal.Parse(tbxTotal.Text.Trim());
                string newComment = tbxComments.Text.Trim();

                // Update basic information data
                SubcontractorHoursInformationBasicInformation subcontractorHoursInformationBasicInformation = new SubcontractorHoursInformationBasicInformation(subcontractorHoursInformationTDS);
                subcontractorHoursInformationBasicInformation.Update(projectId, refId, (DateTime)newDate, newQuantity, newRateCad, newTotalCad, newRateUsd, newTotalUsd, newComment);

                // Store datasets
                Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;
                    
                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }        



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                SubcontractorHoursInformationBasicInformation subcontractorHoursInformationBasicInformation = new SubcontractorHoursInformationBasicInformation(subcontractorHoursInformationTDS);
                subcontractorHoursInformationBasicInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                subcontractorHoursInformationTDS.AcceptChanges();
                Session["subcontractorHoursInformationTDS"] = subcontractorHoursInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
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


    }
}