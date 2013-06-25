using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.BL.LabourHours.ActualCosts;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_delete
    /// </summary>
    public partial class actual_costs_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ActualCostsInformationTDS actualCostsInformationTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_DELETE"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null) || ((string)Request.QueryString["category"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in actual_costs_delete.aspx");
                    }
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"];
                hdfCurrentRefId.Value = Request.QueryString["ref_id"];
                hdfCategory.Value = Request.QueryString["category"];

                // ... for titles
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = int.Parse(hdfCurrentProjectId.Value);
                int currentRefId = int.Parse(hdfCurrentRefId.Value);
                string category = hdfCategory.Value;

                if (category == "Subcontractors")
                {                    
                    lblDelete.Text = "Are you sure you want to delete this subcontractor cost?";
                    ActualCostsInformationSubcontractorBasicInformationGateway actualCostsInformationSubcontractorBasicInformationGatewayForTitle = new ActualCostsInformationSubcontractorBasicInformationGateway();
                    actualCostsInformationSubcontractorBasicInformationGatewayForTitle.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                    lblTitle.Text = "Subcontractor: " + actualCostsInformationSubcontractorBasicInformationGatewayForTitle.GetSubcontractor(currentProjectId, currentRefId);
                }
                else
                {
                    if (category == "Hotels")
                    {                        
                        lblDelete.Text = "Are you sure you want to delete this hotel cost?";
                        ActualCostsInformationHotelCostsBasicInformationGateway actualCostsInformationHotelCostsBasicInformationGateway = new ActualCostsInformationHotelCostsBasicInformationGateway();
                        actualCostsInformationHotelCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                        lblTitle.Text = "Hotel: " + actualCostsInformationHotelCostsBasicInformationGateway.GetHotel(currentProjectId, currentRefId);
                    }
                    else
                    {
                        if (category == "Insurance")
                        {                            
                            lblDelete.Text = "Are you sure you want to delete this insurance company cost?";
                            ActualCostsInformationInsuranceCostsBasicInformationGateway actualCostsInformationInsuranceCostsBasicInformationGateway = new ActualCostsInformationInsuranceCostsBasicInformationGateway();
                            actualCostsInformationInsuranceCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                            lblTitle.Text = "Insurance Company:  " + actualCostsInformationInsuranceCostsBasicInformationGateway.GetInsurance(currentProjectId, currentRefId);
                        }
                        else
                        {
                            if (category == "Bonding")
                            {                                
                                lblDelete.Text = "Are you sure you want to delete this bonding company cost?";
                                ActualCostsInformationBondingCostsBasicInformationGateway actualCostsInformationBondingCostsBasicInformationGateway = new ActualCostsInformationBondingCostsBasicInformationGateway();
                                actualCostsInformationBondingCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                                lblTitle.Text = "Bonding Company: " + actualCostsInformationBondingCostsBasicInformationGateway.GetBonding(currentProjectId, currentRefId);
                            }
                            else
                            {
                                // for other categories                                
                                lblDelete.Text = "Are you sure you want to delete this insurance other cost?";
                                ActualCostsInformationOtherCostsBasicInformationGateway actualCostsInformationOtherCostsBasicInformationGateway = new ActualCostsInformationOtherCostsBasicInformationGateway();
                                actualCostsInformationOtherCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                                lblTitle.Text = "Category: " + actualCostsInformationOtherCostsBasicInformationGateway.GetCategory(currentProjectId, currentRefId);
                            }
                        }
                    }
                }

                // If coming from 
                // ... actual_costs_navigator2.aspx
                if (Request.QueryString["source_page"] == "actual_costs_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    actualCostsInformationTDS = new ActualCostsInformationTDS();

                    if (category == "Subcontractors")
                    {
                        ActualCostsInformationSubcontractorBasicInformationGateway actualCostsInformationSubcontractorBasicInformationGateway = new ActualCostsInformationSubcontractorBasicInformationGateway(actualCostsInformationTDS);
                        actualCostsInformationSubcontractorBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                    }
                    else
                    {
                        if (category == "Hotels")
                        {
                            ActualCostsInformationHotelCostsBasicInformationGateway actualCostsInformationHotelCostsBasicInformationGateway = new ActualCostsInformationHotelCostsBasicInformationGateway(actualCostsInformationTDS);
                            actualCostsInformationHotelCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                        }
                        else
                        {
                            if (category == "Insurance")
                            {
                                ActualCostsInformationInsuranceCostsBasicInformationGateway actualCostsInformationInsuranceCostsBasicInformationGateway = new ActualCostsInformationInsuranceCostsBasicInformationGateway(actualCostsInformationTDS);
                                actualCostsInformationInsuranceCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                            }
                            else
                            {
                                if (category == "Bonding")
                                {
                                    ActualCostsInformationBondingCostsBasicInformationGateway actualCostsInformationBondingCostsBasicInformationGateway = new ActualCostsInformationBondingCostsBasicInformationGateway(actualCostsInformationTDS);
                                    actualCostsInformationBondingCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                                }
                                else
                                { 
                                    // other categories
                                    ActualCostsInformationOtherCostsBasicInformationGateway actualCostsInformationOtherCostsBasicInformationGateway = new ActualCostsInformationOtherCostsBasicInformationGateway(actualCostsInformationTDS);
                                    actualCostsInformationOtherCostsBasicInformationGateway.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);

                                }
                            }
                        }
                    }

                    
                    // ... Store dataset
                    Session["actualCostsInformationTDS"] = actualCostsInformationTDS;
                }

                // ... actual_costs_summary.aspx
                if (Request.QueryString["source_page"] == "actual_costs_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    actualCostsInformationTDS = (ActualCostsInformationTDS)Session["actualCostsInformationTDS"];
                }               

            }
            else
            {
                // Restore dataset 
                actualCostsInformationTDS = (ActualCostsInformationTDS)Session["actualCostsInformationTDS"];
            }
        }        

                   

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            switch (e.Item.Value)
            {
                case "mDelete":
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        Delete();
                        UpdateDatabase();

                        // Redirect
                        if (Request.QueryString["source_page"] == "actual_costs_navigator2.aspx")
                        {
                            url = "./actual_costs_navigator2.aspx?source_page=actual_costs_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "actual_costs_summary.aspx")
                        {
                            url = "./actual_costs_summary.aspx?source_page=actual_costs_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=yes" ;
                        }


                        Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "actual_costs_navigator2.aspx")
                    {
                        url = "./actual_costs_navigator2.aspx?source_page=actual_costs_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "actual_costs_summary.aspx")
                    {
                        url = "./actual_costs_summary.aspx?source_page=actual_costs_delete.aspx&project_id=" + hdfCurrentProjectId.Value + "&ref_id=" + hdfCurrentRefId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (url != "") Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./actual_costs_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" + Request.QueryString["search_ddlSubcontractor"] + "&search_ddlHotels=" + Request.QueryString["search_ddlHotels"] + "&search_ddlInsurance=" + Request.QueryString["search_ddlInsurance"] + "&search_ddlBonding=" + Request.QueryString["search_ddlBonding"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"] + "&search_category=" + Request.QueryString["search_category"] + "&search_textForSearch=" + Request.QueryString["search_textForSearch"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            int currentProjectId = int.Parse(hdfCurrentProjectId.Value);
            int currentRefId = int.Parse(hdfCurrentRefId.Value);

            string category = hdfCategory.Value;

            if (category == "Subcontractors")
            {
                    ActualCostsInformationSubcontractorBasicInformation actualCostsInformationSubcontractorBasicInformation = new ActualCostsInformationSubcontractorBasicInformation(actualCostsInformationTDS);
                    actualCostsInformationSubcontractorBasicInformation.Delete(currentProjectId, currentRefId);
            }
            else
            {
                if (category == "Hotels")
                {
                    ActualCostsInformationHotelCostsBasicInformation actualCostsInformationHotelCostsBasicInformation = new ActualCostsInformationHotelCostsBasicInformation(actualCostsInformationTDS);
                    actualCostsInformationHotelCostsBasicInformation.Delete(currentProjectId, currentRefId);
                }
                else
                {
                    if (category == "Insurance")
                    {
                        ActualCostsInformationInsuranceCostsBasicInformation actualCostsInformationInsuranceCostsBasicInformation = new ActualCostsInformationInsuranceCostsBasicInformation(actualCostsInformationTDS);
                        actualCostsInformationInsuranceCostsBasicInformation.Delete(currentProjectId, currentRefId);
                    }
                    else
                    {
                        if (category == "Bonding")
                        {
                            ActualCostsInformationBondingCostsBasicInformation actualCostsInformationBondingCostsBasicInformation = new ActualCostsInformationBondingCostsBasicInformation(actualCostsInformationTDS);
                            actualCostsInformationBondingCostsBasicInformation.Delete(currentProjectId, currentRefId);
                        }
                        else
                        {
                            // other categories
                            ActualCostsInformationOtherCostsBasicInformation actualCostsInformationOtherCostsBasicInformation = new ActualCostsInformationOtherCostsBasicInformation(actualCostsInformationTDS);
                            actualCostsInformationOtherCostsBasicInformation.Delete(currentProjectId, currentRefId);
                        }
                    }
                }
            }

            // Store datasets
            Session["actualCostsInformationTDS"] = actualCostsInformationTDS;
        }



        private void UpdateDatabase()
        {
            // Get ids
            int companyId = int.Parse(hdfCompanyId.Value);            

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                string category = hdfCategory.Value;

                if (category == "Subcontractors")
                {
                    ActualCostsInformationSubcontractorBasicInformation actualCostsInformationSubcontractorBasicInformation = new ActualCostsInformationSubcontractorBasicInformation(actualCostsInformationTDS);
                    actualCostsInformationSubcontractorBasicInformation.Save(companyId);
                }
                else
                {
                    if (category == "Hotels")
                    {
                        ActualCostsInformationHotelCostsBasicInformation actualCostsInformationHotelCostsBasicInformation = new ActualCostsInformationHotelCostsBasicInformation(actualCostsInformationTDS);
                        actualCostsInformationHotelCostsBasicInformation.Save(companyId);
                    }
                    else
                    {
                        if (category == "Insurance")
                        {
                            ActualCostsInformationInsuranceCostsBasicInformation actualCostsInformationInsuranceCostsBasicInformation = new ActualCostsInformationInsuranceCostsBasicInformation(actualCostsInformationTDS);
                            actualCostsInformationInsuranceCostsBasicInformation.Save(companyId);
                        }
                        else
                        {
                            if (category == "Bonding")
                            {
                                ActualCostsInformationBondingCostsBasicInformation actualCostsInformationBondingCostsBasicInformation = new ActualCostsInformationBondingCostsBasicInformation(actualCostsInformationTDS);
                                actualCostsInformationBondingCostsBasicInformation.Save(companyId);
                            }
                            else
                            {
                                // other categories
                                ActualCostsInformationOtherCostsBasicInformation actualCostsInformationOtherCostsBasicInformation = new ActualCostsInformationOtherCostsBasicInformation(actualCostsInformationTDS);
                                actualCostsInformationOtherCostsBasicInformation.Save(companyId);
                            }
                        }
                    }
                }

                DB.CommitTransaction();
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