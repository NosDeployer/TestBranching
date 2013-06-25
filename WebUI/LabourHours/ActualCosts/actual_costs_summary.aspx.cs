using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.BL.LabourHours.ActualCosts;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_summary
    /// </summary>
    public partial class actual_costs_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // PROPERTIES AND FIELDS
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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["ref_id"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in actual_costs_summary.aspx");
                    }
                }

                // Initialize viewstate variables               
                hdfProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfRefId.Value = Request.QueryString["ref_id"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCategory.Value = Request.QueryString["category"].ToString();

                // If coming from 
                // ... actual_costs_navigator2.aspx
                int currentRefId = Int32.Parse(hdfRefId.Value);
                int currentProjectId = Int32.Parse(hdfProjectId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                string category = hdfCategory.Value;

                if (Request.QueryString["source_page"] == "actual_costs_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    actualCostsInformationTDS = new ActualCostsInformationTDS();

                    if (category == "Subcontractors")
                    {
                        lblTitle.Text = "Subcontractor Costs";
                        lblCategoryName.Text = "Subcontractor";
                        ActualCostsInformationSubcontractorBasicInformation actualCostsInformationSubcontractorBasicInformation = new ActualCostsInformationSubcontractorBasicInformation(actualCostsInformationTDS);
                        actualCostsInformationSubcontractorBasicInformation.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                    }
                    else
                    {
                        if (category == "Hotels")
                        {
                            lblTitle.Text = "Hotel Costs";
                            lblCategoryName.Text = "Hotels";
                            tbxState.Visible = false;
                            ActualCostsInformationHotelCostsBasicInformation actualCostsInformationHotelCostsBasicInformation = new ActualCostsInformationHotelCostsBasicInformation(actualCostsInformationTDS);
                            actualCostsInformationHotelCostsBasicInformation.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                        }
                        else
                        {
                            if (category == "Insurance")
                            {
                                lblTitle.Text = "Insurance Company Costs";
                                lblCategoryName.Text = "Insurance Company";
                                tbxState.Visible = false;
                                ActualCostsInformationInsuranceCostsBasicInformation actualCostsInformationInsuranceCostsBasicInformation = new ActualCostsInformationInsuranceCostsBasicInformation(actualCostsInformationTDS);
                                actualCostsInformationInsuranceCostsBasicInformation.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                            }
                            else
                            {
                                if (category == "Bonding")
                                {
                                    lblTitle.Text = "Bonding Company Costs";
                                    lblCategoryName.Text = "Bonding Company";
                                    tbxState.Visible = false;
                                    ActualCostsInformationBondingCostsBasicInformation actualCostsInformationBondingCostsBasicInformation = new ActualCostsInformationBondingCostsBasicInformation(actualCostsInformationTDS);
                                    actualCostsInformationBondingCostsBasicInformation.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                                }
                                else
                                {
                                    // Other categories
                                    lblTitle.Text = "Other Costs";
                                    lblCategoryName.Text = "Category";
                                    tbxState.Visible = false;
                                    ActualCostsInformationOtherCostsBasicInformation actualCostsInformationOtherCostsBasicInformation = new ActualCostsInformationOtherCostsBasicInformation(actualCostsInformationTDS);
                                    actualCostsInformationOtherCostsBasicInformation.LoadByProjectIdRefId(currentProjectId, currentRefId, companyId);
                                }
                            }
                        }
                    }
                    
                    // ... Store dataset
                    Session["actualCostsInformationTDS"] = actualCostsInformationTDS;
                }

                // ... actual_costs_delete.aspx or actual_costs_edit.aspx 
                if ((Request.QueryString["source_page"] == "actual_costs_delete.aspx") || (Request.QueryString["source_page"] == "actual_costs_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    actualCostsInformationTDS = (ActualCostsInformationTDS)Session["actualCostsInformationTDS"];
                }

                // ... Data for current employee
                LoadData(currentProjectId, currentRefId);

            }
            else
            {
                // Restore datasets
                actualCostsInformationTDS = (ActualCostsInformationTDS)Session["actualCostsInformationTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "LabourHours";

            string category = hdfCategory.Value;

            if (category == "Subcontractors")
            {
                lblQuantity.Visible = true;
                lblTotal.Visible = true;
                tbxQuantity.Visible = true;
                tbxTotal.Visible = true;
            }
            else
            {
                tbxQuantity.Text = "0";
                tbxTotal.Text = "0";

                lblQuantity.Visible = false;
                lblTotal.Visible = false;
                tbxQuantity.Visible = false;
                tbxTotal.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string category = hdfCategory.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./actual_costs_edit.aspx?source_page=actual_costs_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&ref_id=" + hdfRefId.Value + "&category=" + hdfCategory.Value; ;
                    break;

                case "mDelete":
                    url = "./actual_costs_delete.aspx?source_page=actual_costs_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&ref_id=" + hdfRefId.Value + "&category=" + hdfCategory.Value;
                    break;

                case "mLastSearch":
                    url = "./actual_costs_navigator2.aspx?source_page=actual_costs_summary.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = 0;
                    
                    if (category == "Subcontractors")
                    {
                        previousId = ActualCostsNavigatorSubcontractorCosts.GetPreviousId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                    }
                    else
                    {
                        if (category == "Hotels")
                        {
                            previousId = ActualCostsNavigatorHotelCosts.GetPreviousId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                        }
                        else
                        {
                            if (category == "Insurance")
                            {
                                previousId = ActualCostsNavigatorInsuranceCompaniesCosts.GetPreviousId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                            }
                            else
                            {
                                if (category == "Bonding")
                                {
                                    previousId = ActualCostsNavigatorBondingCompaniesCosts.GetPreviousId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                                }
                                else
                                {
                                    // other categories
                                    previousId = ActualCostsNavigatorOtherCosts.GetPreviousId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                                }
                            }
                        }                        
                    }  

                    if (previousId != Int32.Parse(hdfRefId.Value))
                    {
                        // Redirect
                        url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&ref_id=" + previousId.ToString() + "&project_id=" + hdfProjectId.Value + "&category="  +hdfCategory.Value + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = 0;

                    if (category == "Subcontractors")
                    {
                        nextId = ActualCostsNavigatorSubcontractorCosts.GetNextId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                    }
                    else
                    {
                        if (category == "Hotels")
                        {
                            nextId = ActualCostsNavigatorHotelCosts.GetNextId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                        }
                        else
                        {
                            if (category == "Insurance")
                            {
                                nextId = ActualCostsNavigatorInsuranceCompaniesCosts.GetNextId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                            }
                            else
                            {
                                if (category == "Bonding")
                                {
                                    nextId = ActualCostsNavigatorBondingCompaniesCosts.GetNextId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                                }
                                else
                                {
                                    // other categories
                                    nextId = ActualCostsNavigatorOtherCosts.GetNextId((ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"], Int32.Parse(hdfRefId.Value));
                                }                  
                            }
                        }
                    } 

                    if (nextId != Int32.Parse(hdfRefId.Value))
                    {
                        // Redirect
                        url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&ref_id=" + nextId.ToString() + "&project_id=" + hdfProjectId.Value + "&category=" + hdfCategory.Value + GetNavigatorState();
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
                case "mSearch":
                    url = "./../../LabourHours/ActualCosts/actual_costs_navigator.aspx?source_page=out";
                    Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./actual_costs_summary.js");
        }



        #region Load Functions

        private void LoadData(int projectId, int refId)
        {
            string category = hdfCategory.Value;
            
            // Load Data
            if (category == "Subcontractors")
            {
                ActualCostsInformationSubcontractorBasicInformationGateway actualCostsInformationSubcontractorBasicInformationGateway = new ActualCostsInformationSubcontractorBasicInformationGateway(actualCostsInformationTDS);
                if (actualCostsInformationSubcontractorBasicInformationGateway.Table.Rows.Count > 0)
                {
                    // Load subcontractor basic data                
                    tbxCategory.Text = actualCostsInformationSubcontractorBasicInformationGateway.GetSubcontractor(projectId, refId);

                    if (tbxState.Visible)
                    {
                        if (actualCostsInformationSubcontractorBasicInformationGateway.GetActive(projectId, refId))
                        {
                            tbxState.Text = "Active";
                        }
                        else
                        {
                            tbxState.Text = "Inactive";
                        }
                    }

                    tbxClient.Text = actualCostsInformationSubcontractorBasicInformationGateway.GetClient(projectId, refId);
                    tbxProject.Text = actualCostsInformationSubcontractorBasicInformationGateway.GetProject(projectId, refId);

                    DateTime date = (DateTime)(actualCostsInformationSubcontractorBasicInformationGateway.GetDate(projectId, refId));
                    tbxDateTime.Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                    if (tbxQuantity.Visible)
                    {
                        decimal quantity = decimal.Parse(actualCostsInformationSubcontractorBasicInformationGateway.GetQuantity(projectId, refId).ToString());
                        tbxQuantity.Text = decimal.Round(quantity, 1).ToString();
                    }

                    if (actualCostsInformationSubcontractorBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                    {
                        decimal rate = decimal.Parse(actualCostsInformationSubcontractorBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                        tbxRate.Text = decimal.Round(rate, 2).ToString();

                        if (tbxTotal.Visible)
                        {
                            decimal total = decimal.Parse(actualCostsInformationSubcontractorBasicInformationGateway.GetTotalCad(projectId, refId).ToString());
                            tbxTotal.Text = decimal.Round(total, 2).ToString();
                        }
                    }
                    else // Usa
                    {
                        decimal rate = decimal.Parse(actualCostsInformationSubcontractorBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                        tbxRate.Text = decimal.Round(rate, 2).ToString();

                        if (tbxTotal.Visible)
                        {
                            decimal total = decimal.Parse(actualCostsInformationSubcontractorBasicInformationGateway.GetTotalUsd(projectId, refId).ToString());
                            tbxTotal.Text = decimal.Round(total, 2).ToString();
                        }
                    }

                    tbxComments.Text = actualCostsInformationSubcontractorBasicInformationGateway.GetComment(projectId, refId);
                }
            }
            else
            {
                if (category == "Hotels")
                {
                    ActualCostsInformationHotelCostsBasicInformationGateway actualCostsInformationHotelCostsBasicInformationGateway = new ActualCostsInformationHotelCostsBasicInformationGateway(actualCostsInformationTDS);
                    if (actualCostsInformationHotelCostsBasicInformationGateway.Table.Rows.Count > 0)
                    {
                        // Load subcontractor basic data                
                        tbxCategory.Text = actualCostsInformationHotelCostsBasicInformationGateway.GetHotel(projectId, refId);

                        tbxClient.Text = actualCostsInformationHotelCostsBasicInformationGateway.GetClient(projectId, refId);
                        tbxProject.Text = actualCostsInformationHotelCostsBasicInformationGateway.GetProject(projectId, refId);

                        DateTime date = (DateTime)(actualCostsInformationHotelCostsBasicInformationGateway.GetDate(projectId, refId));
                        tbxDateTime.Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                        if (actualCostsInformationHotelCostsBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                        {
                            decimal rate = decimal.Parse(actualCostsInformationHotelCostsBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                            tbxRate.Text = decimal.Round(rate, 2).ToString();
                        }
                        else // Usa
                        {
                            decimal rate = decimal.Parse(actualCostsInformationHotelCostsBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                            tbxRate.Text = decimal.Round(rate, 2).ToString();
                        }

                        tbxComments.Text = actualCostsInformationHotelCostsBasicInformationGateway.GetComment(projectId, refId);
                    }
                }
                else
                {
                    if (category == "Insurance")
                    {
                        ActualCostsInformationInsuranceCostsBasicInformationGateway actualCostsInformationInsuranceCostsBasicInformationGateway = new ActualCostsInformationInsuranceCostsBasicInformationGateway(actualCostsInformationTDS);
                        if (actualCostsInformationInsuranceCostsBasicInformationGateway.Table.Rows.Count > 0)
                        {
                            // Load subcontractor basic data                
                            tbxCategory.Text = actualCostsInformationInsuranceCostsBasicInformationGateway.GetInsurance(projectId, refId);

                            tbxClient.Text = actualCostsInformationInsuranceCostsBasicInformationGateway.GetClient(projectId, refId);
                            tbxProject.Text = actualCostsInformationInsuranceCostsBasicInformationGateway.GetProject(projectId, refId);

                            DateTime date = (DateTime)(actualCostsInformationInsuranceCostsBasicInformationGateway.GetDate(projectId, refId));
                            tbxDateTime.Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                            if (actualCostsInformationInsuranceCostsBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                            {
                                decimal rate = decimal.Parse(actualCostsInformationInsuranceCostsBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                                tbxRate.Text = decimal.Round(rate, 2).ToString();
                            }
                            else // Usa
                            {
                                decimal rate = decimal.Parse(actualCostsInformationInsuranceCostsBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                                tbxRate.Text = decimal.Round(rate, 2).ToString();
                            }

                            tbxComments.Text = actualCostsInformationInsuranceCostsBasicInformationGateway.GetComment(projectId, refId);
                        }
                    }
                    else
                    {
                        if (category == "Bonding")
                        {
                            ActualCostsInformationBondingCostsBasicInformationGateway actualCostsInformationBondingCostsBasicInformationGateway = new ActualCostsInformationBondingCostsBasicInformationGateway(actualCostsInformationTDS);
                            if (actualCostsInformationBondingCostsBasicInformationGateway.Table.Rows.Count > 0)
                            {
                                // Load subcontractor basic data                
                                tbxCategory.Text = actualCostsInformationBondingCostsBasicInformationGateway.GetBonding(projectId, refId);

                                tbxClient.Text = actualCostsInformationBondingCostsBasicInformationGateway.GetClient(projectId, refId);
                                tbxProject.Text = actualCostsInformationBondingCostsBasicInformationGateway.GetProject(projectId, refId);

                                DateTime date = (DateTime)(actualCostsInformationBondingCostsBasicInformationGateway.GetDate(projectId, refId));
                                tbxDateTime.Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                                if (actualCostsInformationBondingCostsBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                                {
                                    decimal rate = decimal.Parse(actualCostsInformationBondingCostsBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                                    tbxRate.Text = decimal.Round(rate, 2).ToString();
                                }
                                else // Usa
                                {
                                    decimal rate = decimal.Parse(actualCostsInformationBondingCostsBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                                    tbxRate.Text = decimal.Round(rate, 2).ToString();
                                }

                                tbxComments.Text = actualCostsInformationBondingCostsBasicInformationGateway.GetComment(projectId, refId);
                            }
                        }
                        else
                        {
                            // Other categories
                            ActualCostsInformationOtherCostsBasicInformationGateway actualCostsInformationOtherCostsBasicInformationGateway = new ActualCostsInformationOtherCostsBasicInformationGateway(actualCostsInformationTDS);
                            if (actualCostsInformationOtherCostsBasicInformationGateway.Table.Rows.Count > 0)
                            {
                                // Load subcontractor basic data                
                                tbxCategory.Text = actualCostsInformationOtherCostsBasicInformationGateway.GetCategory(projectId, refId);

                                tbxClient.Text = actualCostsInformationOtherCostsBasicInformationGateway.GetClient(projectId, refId);
                                tbxProject.Text = actualCostsInformationOtherCostsBasicInformationGateway.GetProject(projectId, refId);

                                DateTime date = (DateTime)(actualCostsInformationOtherCostsBasicInformationGateway.GetDate(projectId, refId));
                                tbxDateTime.Text = date.Month.ToString() + "/" + date.Day.ToString() + "/" + date.Year.ToString();

                                if (actualCostsInformationOtherCostsBasicInformationGateway.GetCountryId(projectId, refId) == 1) // Canada
                                {
                                    decimal rate = decimal.Parse(actualCostsInformationOtherCostsBasicInformationGateway.GetRateCad(projectId, refId).ToString());
                                    tbxRate.Text = decimal.Round(rate, 2).ToString();
                                }
                                else // Usa
                                {
                                    decimal rate = decimal.Parse(actualCostsInformationOtherCostsBasicInformationGateway.GetRateUsd(projectId, refId).ToString());
                                    tbxRate.Text = decimal.Round(rate, 2).ToString();
                                }

                                tbxComments.Text = actualCostsInformationOtherCostsBasicInformationGateway.GetComment(projectId, refId);
                            }
                        }
                    }
                }            
            }                     
        }

        #endregion




        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" +  Request.QueryString["search_ddlSubcontractor"] + "&search_ddlHotels=" + Request.QueryString["search_ddlHotels"] +  "&search_ddlInsurance=" + Request.QueryString["search_ddlInsurance"]+  "&search_ddlBonding=" + Request.QueryString["search_ddlBonding"]  + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"] + "&search_category=" + Request.QueryString["search_category"] + "&search_textForSearch=" + Request.QueryString["search_textForSearch"]  ;
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



    }
}