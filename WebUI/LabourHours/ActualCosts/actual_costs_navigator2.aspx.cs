using System;
using System.Data;
using System.Web.UI;
using LiquiForce.LFSLive.BL.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_navigator2
    /// </summary>
    public partial class actual_costs_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ActualCostsNavigatorTDS actualCostsNavigatorTDS;
        protected ActualCostsNavigatorTDS.SubcontractorCostsDataTable subcontractorCosts;
        protected ActualCostsNavigatorTDS.HotelCostsDataTable hotelCosts;
        protected ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable insuranceCompaniesCosts;
        protected ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable bondingCompaniesCosts;
        protected ActualCostsNavigatorTDS.OtherCostsDataTable otherCosts;
        protected string tableCategory = "";






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
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if ((string)Request.QueryString["source_page"] == null)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in actual_costs_navigator.aspx");
                    }
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                Session.Remove("subcontractorCostsNewDummy");
                Session.Remove("hotelCostsNewDummy");
                Session.Remove("insuranceCompaniesCostsNewDummy");
                Session.Remove("bondingCompaniesCostsNewDummy");
                Session.Remove("OtherCostsNewDummy");

                // ... for conditions
                ddlCategory.SelectedIndex = 0;
                tbxTextForSearch.Visible = true;               
                ddlSubcontractor.Visible = false;                
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;    

                // RestoreNavigator
                RestoreNavigatorState();
                
                // If coming from 
                // ... actual_costs_navigator.aspx or actual_costs_navigator2.aspx
                if ((Request.QueryString["source_page"] == "actual_costs_navigator.aspx") || (Request.QueryString["source_page"] == "actual_costs_navigator2.aspx"))
                {                    
                    actualCostsNavigatorTDS = (ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"];
                }

                // ... actual_costs_edit.aspx, actual_costs_summary.aspx or actual_costs_delete.aspx
                if ((Request.QueryString["source_page"] == "actual_costs_edit.aspx") || (Request.QueryString["source_page"] == "actual_costs_summary.aspx") || (Request.QueryString["source_page"] == "actual_costs_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        actualCostsNavigatorTDS = (ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("actualCostsNavigatorTDS");

                        // ... Search data with updates                        
                        actualCostsNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                    }
                }

                Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                Session["subcontractorCosts"] = actualCostsNavigatorTDS.SubcontractorCosts;
                Session["hotelCosts"] = actualCostsNavigatorTDS.HotelCosts;
                Session["insuranceCompaniesCosts"] = actualCostsNavigatorTDS.InsuranceCompaniesCosts;
                Session["bondingCompaniesCosts"] = actualCostsNavigatorTDS.BondingCompaniesCosts;
                Session["otherCosts"] = actualCostsNavigatorTDS.OtherCosts;

                // ... For total rows
                // ... ... for the subcontractors total rows                                
                if (actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count > 0)
                {
                    lblSubcontratorRowsLabel.Text = " Total Subcontractors Rows: " + actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count;
                }

                // ... ... for the hotels total rows                                
                if (actualCostsNavigatorTDS.HotelCosts.Rows.Count > 0)
                {
                    lblHotelRowsLabel.Text = " Total Hotel Rows: " + actualCostsNavigatorTDS.HotelCosts.Rows.Count;
                }

                // ... ... for the insurance companies total rows                
                if (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count > 0)
                {
                    lblInsuranceRowsLabel.Text = " Total Insurance Companies Rows: " + actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count;
                }

                // ... ... for the bonding companies total rows                                
                if (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count > 0)
                {
                    lblBondingRowsLabel.Text = " Total Bonding Companies Rows: " + actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count;
                }

                // ... ... for the other total rows                                
                if (actualCostsNavigatorTDS.OtherCosts.Rows.Count > 0)
                {
                    lblOtherRowsLabel.Text = " Total Other Costs Rows: " + actualCostsNavigatorTDS.OtherCosts.Rows.Count;
                }

                // Make grids visible
                if (actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count <= 0)
                {
                    pnlGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.HotelCosts.Rows.Count <= 0)
                {
                    pnlHotelGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count <= 0)
                {
                    pnlInsuranceGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count <= 0)
                {
                    pnlBondingGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.OtherCosts.Rows.Count <= 0)
                {
                    pnlOtherGrid.Visible = false;
                }
            }
            else
            {
                // Restore searched data (if any)
                actualCostsNavigatorTDS = (ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"];
                subcontractorCosts = actualCostsNavigatorTDS.SubcontractorCosts;
                hotelCosts = actualCostsNavigatorTDS.HotelCosts;
                insuranceCompaniesCosts = actualCostsNavigatorTDS.InsuranceCompaniesCosts;
                bondingCompaniesCosts = actualCostsNavigatorTDS.BondingCompaniesCosts;
                otherCosts = actualCostsNavigatorTDS.OtherCosts;

                // ... For total rows
                // ... ... for the subcontractors total rows                                
                if (actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count > 0)
                {
                    lblSubcontratorRowsLabel.Text = " Total Subcontractors Rows: " + actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count;
                }

                // ... ... for the hotels total rows                                
                if (actualCostsNavigatorTDS.HotelCosts.Rows.Count > 0)
                {
                    lblHotelRowsLabel.Text = " Total Hotel Rows: " + actualCostsNavigatorTDS.HotelCosts.Rows.Count;
                }

                // ... ... for the insurance companies total rows                
                if (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count > 0)
                {
                    lblInsuranceRowsLabel.Text = " Total Insurance Companies Rows: " + actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count;
                }

                // ... ... for the bonding companies total rows                                
                if (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count > 0)
                {
                    lblBondingRowsLabel.Text = " Total Bonding Companies Rows: " + actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count;
                }

                // ... ... for the other total rows                                
                if (actualCostsNavigatorTDS.OtherCosts.Rows.Count > 0)
                {
                    lblOtherRowsLabel.Text = " Total Other Costs Rows: " + actualCostsNavigatorTDS.OtherCosts.Rows.Count;
                }

                // Make grids visible
                if (actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count <= 0)
                {
                    pnlGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.HotelCosts.Rows.Count <= 0)
                {
                    pnlHotelGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count <= 0)
                {
                    pnlInsuranceGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count <= 0)
                {
                    pnlBondingGrid.Visible = false;
                }

                if (actualCostsNavigatorTDS.OtherCosts.Rows.Count <= 0)
                {
                    pnlOtherGrid.Visible = false;
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Tag Page
                string url = "";

                // Delete store data
                Session.Contents.Remove("actualCostsNavigatorTDS");

                ActualCostsNavigatorTDS actualCostsNavigatorTDS = SubmitSearch();
                string category = ddlCategory.SelectedValue;

                // Show results
                if (category == "All")
                {
                    if ((actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.HotelCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.OtherCosts.Rows.Count > 0))
                    {
                        // ... Store data
                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                        // ... Go to the results page
                        Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                    }
                    else
                    {
                        // ... Go to the search page
                        url = "./actual_costs_navigator.aspx?source_page=actual_costs_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }                    
                }
                else
                {
                    if (category == "Subcontractors")
                    {
                        if (actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count > 0)
                        {
                            // ... Store data
                            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                            // ... Go to the results page
                            Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                        }
                        else
                        {
                            // ... Go to the search page
                            url = "./actual_costs_navigator.aspx?source_page=actual_costs_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                            Response.Redirect(url);
                        }
                    }
                    else
                    {
                        if (category == "Hotels")
                        {
                            if (actualCostsNavigatorTDS.HotelCosts.Rows.Count > 0)
                            {
                                // ... Store data
                                Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                // ... Go to the results page
                                Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                            }
                            else
                            {
                                // ... Go to the search page
                                url = "./actual_costs_navigator.aspx?source_page=actual_costs_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                                Response.Redirect(url);
                            }
                        }
                        else
                        {
                            if (category == "Insurance")
                            {
                                if (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count > 0)
                                {
                                    // ... Store data
                                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                    // ... Go to the results page
                                    Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                                }
                                else
                                {
                                    // ... Go to the search page
                                    url = "./actual_costs_navigator.aspx?source_page=actual_costs_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                                    Response.Redirect(url);
                                }
                            }
                            else
                            {
                                if (category == "Bonding")
                                {
                                    if (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count > 0)
                                    {
                                        // ... Store data
                                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                        // ... Go to the results page
                                        Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                                    }
                                    else
                                    {
                                        // ... Go to the search page
                                        url = "./actual_costs_navigator.aspx?source_page=actual_costs_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                                        Response.Redirect(url);
                                    }
                                }
                                else
                                {
                                    if (actualCostsNavigatorTDS.OtherCosts.Rows.Count > 0)
                                    {
                                        // ... Store data
                                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                        // ... Go to the results page
                                        Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                                    }
                                    else
                                    {
                                        // ... Go to the search page
                                        url = "./actual_costs_navigator.aspx?source_page=actual_costs_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                                        Response.Redirect(url);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "LabourHours";

            // For filter
            //SetFilterByDate();
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
        }       



        protected void grdSubcontractorNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewSubcontractorEmptyFix(grdSubcontractorNavigator);
        }



        protected void grdHotelNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewHotelEmptyFix(grdHotelNavigator);
        }



        protected void grdInsuranceNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewInsuranceEmptyFix(grdInsuranceNavigator);
        }



        protected void grdBondingNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewBondingEmptyFix(grdBondingNavigator);
        }



        protected void grdOtherNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewOtherEmptyFix(grdOtherNavigator);
        }



        protected void grdSubcontractorNavigator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectID")).Text);

                if (projectId != -1)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        ((Label)e.Row.FindControl("lblRateUsd")).Text = ((Label)e.Row.FindControl("lblRateCad")).Text;
                        ((Label)e.Row.FindControl("lblTotalUsd")).Text = ((Label)e.Row.FindControl("lblTotalCad")).Text;
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblRateCad")).Text = ((Label)e.Row.FindControl("lblRateUsd")).Text;

                        ((Label)e.Row.FindControl("lblTotalCad")).Text = ((Label)e.Row.FindControl("lblTotalUsd")).Text;
                    }
                }
            }
        }



        protected void grdHotelNavigator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);                
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblHotelProjectID")).Text);

                if (projectId != -1)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        ((Label)e.Row.FindControl("lblHotelRateUsd")).Text = ((Label)e.Row.FindControl("lblHotelRateCad")).Text;
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblHotelRateCad")).Text = ((Label)e.Row.FindControl("lblHotelRateUsd")).Text;
                    }
                }
            }
        }



        protected void grdInsuranceNavigator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblInsuranceProjectID")).Text);

                if (projectId != -1)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        ((Label)e.Row.FindControl("lblInsuranceRateUsd")).Text = ((Label)e.Row.FindControl("lblInsuranceRateCad")).Text;
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblInsuranceRateCad")).Text = ((Label)e.Row.FindControl("lblInsuranceRateUsd")).Text;
                    }
                }
            }
        }



        protected void grdBondingNavigator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblBondingProjectID")).Text);

                if (projectId != -1)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        ((Label)e.Row.FindControl("lblBondingRateUsd")).Text = ((Label)e.Row.FindControl("lblBondingRateCad")).Text;
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblBondingRateCad")).Text = ((Label)e.Row.FindControl("lblBondingRateUsd")).Text;
                    }
                }
            }
        }



        protected void grdOtherNavigator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblOtherProjectID")).Text);

                if (projectId != -1)
                {
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    if (projectGateway.GetCountryID(projectId) == 1) //Canada
                    {
                        ((Label)e.Row.FindControl("lblOtherRateUsd")).Text = ((Label)e.Row.FindControl("lblOtherRateCad")).Text;
                    }
                    else
                    {
                        ((Label)e.Row.FindControl("lblOtherRateCad")).Text = ((Label)e.Row.FindControl("lblOtherRateUsd")).Text;
                    }
                }
            }
        }



        protected void grdSubcontractorNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = actualCostsNavigatorTDS.SubcontractorCosts.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                actualCostsNavigatorTDS.SubcontractorCosts.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    actualCostsNavigatorTDS.SubcontractorCosts.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    actualCostsNavigatorTDS.SubcontractorCosts.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
            Session["subcontractorCosts"] = actualCostsNavigatorTDS.SubcontractorCosts;
        }



        protected void grdHotelNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = actualCostsNavigatorTDS.HotelCosts.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                actualCostsNavigatorTDS.HotelCosts.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    actualCostsNavigatorTDS.HotelCosts.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    actualCostsNavigatorTDS.HotelCosts.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
            Session["hotelCosts"] = actualCostsNavigatorTDS.HotelCosts;
        }



        protected void grdInsuranceNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = actualCostsNavigatorTDS.InsuranceCompaniesCosts.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                actualCostsNavigatorTDS.InsuranceCompaniesCosts.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    actualCostsNavigatorTDS.InsuranceCompaniesCosts.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    actualCostsNavigatorTDS.InsuranceCompaniesCosts.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
            Session["insuranceCompaniesCosts"] = actualCostsNavigatorTDS.InsuranceCompaniesCosts;
        }



        protected void grdBondingNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    actualCostsNavigatorTDS.BondingCompaniesCosts.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
            Session["bondingCompaniesCosts"] = actualCostsNavigatorTDS.BondingCompaniesCosts;
        }



        protected void grdOtherNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = actualCostsNavigatorTDS.OtherCosts.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                actualCostsNavigatorTDS.OtherCosts.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    actualCostsNavigatorTDS.OtherCosts.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    actualCostsNavigatorTDS.OtherCosts.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
            Session["otherCosts"] = actualCostsNavigatorTDS.OtherCosts;
        }



        /*protected void tkrdpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (!tkrdpEndDate.SelectedDate.HasValue)
            {
                tkrdpEndDate.SelectedDate = tkrdpStartDate.SelectedDate;
                upnlEndDate.Update();
            }

            SetFilterByDate();
        }*/



        /*protected void tkrdpEndDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (!tkrdpStartDate.SelectedDate.HasValue)
            {
                tkrdpStartDate.SelectedDate = tkrdpEndDate.SelectedDate;
                upnlStartDate.Update();
            }

            SetFilterByDate();
        }*/



        /*private void ApplyFilter()
        {
            odsNavigator.FilterExpression = (string)ViewState["filter_expression"];
            grdSubcontractorNavigator.DataBind();

            odsHotelNavigator.FilterExpression = (string)ViewState["filter_expression"];
            grdHotelNavigator.DataBind();

            odsInsuranceNavigator.FilterExpression = (string)ViewState["filter_expression"];
            grdInsuranceNavigator.DataBind();

            odsBondingNavigator.FilterExpression = (string)ViewState["filter_expression"];
            grdBondingNavigator.DataBind();

            odsOtherNavigator.FilterExpression = (string)ViewState["filter_expression"];
            grdOtherNavigator.DataBind();
        }*/



        /*protected void SetFilterByDate()
        {
            StringBuilder filterExpression = new StringBuilder();

            if (cbxFilterByRangeOfDates.Checked)
            {
                if (tkrdpStartDate.SelectedDate.HasValue)
                {
                    filterExpression.Append(string.Format(" Date >= '{0}' AND Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString()));
                }

                ViewState["filter_expression"] = filterExpression.ToString();

                ApplyFilter();
            }
        }*/



        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlCategory.SelectedValue == "(All)") || (ddlCategory.SelectedValue == "Rentals") || (ddlCategory.SelectedValue == "Fuel") || (ddlCategory.SelectedValue == "Traffic Control") || (ddlCategory.SelectedValue == "Testing") || (ddlCategory.SelectedValue == "Permits") || (ddlCategory.SelectedValue == "Meals") || (ddlCategory.SelectedValue == "Other"))
            {                
                ddlSubcontractor.Visible = false;                
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;
            }
            else
            {
                if (ddlCategory.SelectedValue == "Subcontractors")
                {                    
                    ddlSubcontractor.Visible = true;
                    ddlHotels.Visible = false;
                    ddlInsurance.Visible = false;
                    ddlBonding.Visible = false;
                }
                else
                {
                    if (ddlCategory.SelectedValue == "Hotels")
                    {                        
                        ddlSubcontractor.Visible = false;
                        ddlHotels.Visible = true;
                        ddlInsurance.Visible = false;
                        ddlBonding.Visible = false;
                    }
                    else
                    {
                        if (ddlCategory.SelectedValue == "Bonding")
                        {                            
                            ddlSubcontractor.Visible = false;
                            ddlHotels.Visible = false;
                            ddlInsurance.Visible = false;
                            ddlBonding.Visible = true;
                        }
                        else
                        {
                            if (ddlCategory.SelectedValue == "Insurance")
                            {                                
                                ddlSubcontractor.Visible = false;
                                ddlHotels.Visible = false;
                                ddlInsurance.Visible = true;
                                ddlBonding.Visible = false;
                            }
                            else
                            {                                
                                ddlSubcontractor.Visible = false;
                                ddlHotels.Visible = false;
                                ddlInsurance.Visible = false;
                                ddlBonding.Visible = false;
                            }
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        // General Buttons
        protected void btnPreviewList_Click(object sender, EventArgs e)
        {
            /*mForm7 master = (mForm7)this.Master;
            ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster7");
            if (!scriptManager.IsInAsyncPostBack)
            {*/
            string category = ddlCategory.SelectedValue;

            string script = "<script language='javascript'>";
            script += "window.open('./actual_costs_print_search_results_report.aspx?format=pdf" + "&category=" + category + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');";
            script += "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Wizard", script, false);

                // Report call                                
                //Response.Write("<script language='javascript'> {window.open('./actual_costs_print_search_results_report.aspx?format=pdf" + "&category=" + category + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            //}
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            /*mForm7 master = (mForm7)this.Master;
            ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster7");

            if (!scriptManager.IsInAsyncPostBack)
            {*/
            string category = ddlCategory.SelectedValue;

            string script = "<script language='javascript'>";
            script += "window.open('./actual_costs_print_search_results_report.aspx?format=pdf" + "&category=" + category + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');";
            script += "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Wizard", script, false);
                

                // Report call  
               // Response.Write("<script language='javascript'> {window.open('./actual_costs_print_search_results_report.aspx?format=pdf" + "&category=" + category + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            //}
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./actual_costs_navigator.aspx?source_page=lm";

            if (url != "") Response.Redirect(url);
        }



        // Buttons for subcontractors
        protected void btnSubcontractorsOpen_Click(object sender, EventArgs e)
        {            
            if (PostPageChangesSubcontractor() == 1)
            {
                int projectId = 0;
                int refId = 0;

                if (tableCategory == "Subcontractors")
                {
                    foreach (ActualCostsNavigatorTDS.SubcontractorCostsRow subcontractorCostsRow in actualCostsNavigatorTDS.SubcontractorCosts)
                    {
                        if (subcontractorCostsRow.Selected)
                        {
                            projectId = subcontractorCostsRow.ProjectID;
                            refId = subcontractorCostsRow.RefID;
                        }
                    }                
                }

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvSubcontractorGrid.IsValid = false;
                }
            }
            else
            { 
                // error message
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvSubcontractorGrid.IsValid = false;
            }
        }



        protected void btnSubcontractorsEdit_Click(object sender, EventArgs e)
        {            
            if (PostPageChangesSubcontractor() == 1)
            {
                int projectId = 0;
                int refId = 0;

                if (tableCategory == "Subcontractors")
                {
                    foreach (ActualCostsNavigatorTDS.SubcontractorCostsRow subcontractorCostsRow in actualCostsNavigatorTDS.SubcontractorCosts)
                    {
                        if (subcontractorCostsRow.Selected)
                        {
                            projectId = subcontractorCostsRow.ProjectID;
                            refId = subcontractorCostsRow.RefID;
                        }
                    }                                
                }

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_edit.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvSubcontractorGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvSubcontractorGrid.IsValid = false;
            }
        }                      



        protected void btnSubcontractorsDelete_Click(object sender, EventArgs e)
        {            
            if (PostPageChangesSubcontractor() == 1)
            {
                int projectId = 0;
                int refId = 0;

                if (tableCategory == "Subcontractors")
                {
                    foreach (ActualCostsNavigatorTDS.SubcontractorCostsRow subcontractorCostsRow in actualCostsNavigatorTDS.SubcontractorCosts)
                    {
                        if (subcontractorCostsRow.Selected)
                        {
                            projectId = subcontractorCostsRow.ProjectID;
                            refId = subcontractorCostsRow.RefID;
                        }
                    }
                }                

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_delete.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvSubcontractorGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvSubcontractorGrid.IsValid = false;
            }
        }       



        // Butons for hotels
        protected void btnHotelsOpen_Click(object sender, EventArgs e)
        {
            if (PostPageChangesHotels() == 1)
            {
                int projectId = 0;
                int refId = 0;
                
                if (tableCategory == "Hotels")
                {
                    foreach (ActualCostsNavigatorTDS.HotelCostsRow hotelCostsRow in actualCostsNavigatorTDS.HotelCosts)
                    {
                        if (hotelCostsRow.Selected)
                        {
                            projectId = hotelCostsRow.ProjectID;
                            refId = hotelCostsRow.RefID;
                        }
                    }
                }                    

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvHotelsGrid.IsValid = false;
                }
            }
            else
            {
                // error message
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvHotelsGrid.IsValid = false;
            }
        }



        protected void btnHotelsEdit_Click(object sender, EventArgs e)
        {
            if (PostPageChangesHotels() == 1)
            {
                int projectId = 0;
                int refId = 0;
                
                if (tableCategory == "Hotels")
                {
                    foreach (ActualCostsNavigatorTDS.HotelCostsRow hotelCostsRow in actualCostsNavigatorTDS.HotelCosts)
                    {
                        if (hotelCostsRow.Selected)
                        {
                            projectId = hotelCostsRow.ProjectID;
                            refId = hotelCostsRow.RefID;
                        }
                    }
                }
                   
                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_edit.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvHotelsGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvHotelsGrid.IsValid = false;
            }
        }       



        protected void btnHotelsDelete_Click(object sender, EventArgs e)
        {
            if (PostPageChangesHotels() == 1)
            {
                int projectId = 0;
                int refId = 0;
               
                if (tableCategory == "Hotels")
                {
                    foreach (ActualCostsNavigatorTDS.HotelCostsRow hotelCostsRow in actualCostsNavigatorTDS.HotelCosts)
                    {
                        if (hotelCostsRow.Selected)
                        {
                            projectId = hotelCostsRow.ProjectID;
                            refId = hotelCostsRow.RefID;
                        }
                    }
                }
                  
                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_delete.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvHotelsGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvHotelsGrid.IsValid = false;
            }
        }      



        // Butons for insurance
        protected void btnInsuranceOpen_Click(object sender, EventArgs e)
        {
            if (PostPageChangesInsurance() == 1)
            {
                int projectId = 0;
                int refId = 0;
                
                if (tableCategory == "Insurance")
                {
                    foreach (ActualCostsNavigatorTDS.InsuranceCompaniesCostsRow insuranceCompaniesCostsRow in actualCostsNavigatorTDS.InsuranceCompaniesCosts)
                    {
                        if (insuranceCompaniesCostsRow.Selected)
                        {
                            projectId = insuranceCompaniesCostsRow.ProjectID;
                            refId = insuranceCompaniesCostsRow.RefID;
                        }
                    }
                }
                     
                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvInsuranceGrid.IsValid = false;
                }
            }
            else
            {
                // error message
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvInsuranceGrid.IsValid = false;
            }
        }



        protected void btnInsuranceEdit_Click(object sender, EventArgs e)
        {
            if (PostPageChangesInsurance() == 1)
            {
                int projectId = 0;
                int refId = 0;
                
                if (tableCategory == "Insurance")
                {
                    foreach (ActualCostsNavigatorTDS.InsuranceCompaniesCostsRow insuranceCompaniesCostsRow in actualCostsNavigatorTDS.InsuranceCompaniesCosts)
                    {
                        if (insuranceCompaniesCostsRow.Selected)
                        {
                            projectId = insuranceCompaniesCostsRow.ProjectID;
                            refId = insuranceCompaniesCostsRow.RefID;
                        }
                    }
                }
                      
                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_edit.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvInsuranceGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvInsuranceGrid.IsValid = false;
            }
        }               



        protected void btnInsuranceDelete_Click(object sender, EventArgs e)
        {
            if (PostPageChangesInsurance() == 1)
            {
                int projectId = 0;
                int refId = 0;
                
                if (tableCategory == "Insurance")
                {
                    foreach (ActualCostsNavigatorTDS.InsuranceCompaniesCostsRow insuranceCompaniesCostsRow in actualCostsNavigatorTDS.InsuranceCompaniesCosts)
                    {
                        if (insuranceCompaniesCostsRow.Selected)
                        {
                            projectId = insuranceCompaniesCostsRow.ProjectID;
                            refId = insuranceCompaniesCostsRow.RefID;
                        }
                    }
                }
                       
                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_delete.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvInsuranceGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvInsuranceGrid.IsValid = false;
            }
        }        



        // Butons for bonding
        protected void btnBondingOpen_Click(object sender, EventArgs e)
        {
            if (PostPageChangesBonding() == 1)
            {
                int projectId = 0;
                int refId = 0;
               
                if (tableCategory == "Bonding")
                {
                    foreach (ActualCostsNavigatorTDS.BondingCompaniesCostsRow bondingCompaniesCostsRow in actualCostsNavigatorTDS.BondingCompaniesCosts)
                    {
                        if (bondingCompaniesCostsRow.Selected)
                        {
                            projectId = bondingCompaniesCostsRow.ProjectID;
                            refId = bondingCompaniesCostsRow.RefID;
                        }
                    }
                }
                            
                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvBondingGrid.IsValid = false;
                }
            }
            else
            {
                // error message
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvBondingGrid.IsValid = false;
            }
        }



        protected void btnBondingEdit_Click(object sender, EventArgs e)
        {
            if (PostPageChangesBonding() == 1)
            {
                int projectId = 0;
                int refId = 0;
               
                if (tableCategory == "Bonding")
                {
                    foreach (ActualCostsNavigatorTDS.BondingCompaniesCostsRow bondingCompaniesCostsRow in actualCostsNavigatorTDS.BondingCompaniesCosts)
                    {
                        if (bondingCompaniesCostsRow.Selected)
                        {
                            projectId = bondingCompaniesCostsRow.ProjectID;
                            refId = bondingCompaniesCostsRow.RefID;
                        }
                    }
                }                           

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_edit.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvBondingGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvBondingGrid.IsValid = false;
            }
        }



        protected void btnBondingDelete_Click(object sender, EventArgs e)
        {
            if (PostPageChangesBonding() == 1)
            {
                int projectId = 0;
                int refId = 0;
               
                if (tableCategory == "Bonding")
                {
                    foreach (ActualCostsNavigatorTDS.BondingCompaniesCostsRow bondingCompaniesCostsRow in actualCostsNavigatorTDS.BondingCompaniesCosts)
                    {
                        if (bondingCompaniesCostsRow.Selected)
                        {
                            projectId = bondingCompaniesCostsRow.ProjectID;
                            refId = bondingCompaniesCostsRow.RefID;
                        }
                    }
                }                          

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_delete.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvBondingGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvBondingGrid.IsValid = false;
            }
        }



        // Butons for other costs
        protected void btnOtherCostsOpen_Click(object sender, EventArgs e)
        {
            if (PostPageChangesOtherCosts() == 1)
            {
                int projectId = 0;
                int refId = 0;
                               
                // for other categories            
                foreach (ActualCostsNavigatorTDS.OtherCostsRow otherCostsRow in actualCostsNavigatorTDS.OtherCosts)
                {
                    if (otherCostsRow.Selected)
                    {
                        projectId = otherCostsRow.ProjectID;
                        refId = otherCostsRow.RefID;
                    }
                }                           

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_summary.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvOtherCostsGrid.IsValid = false;
                }
            }
            else
            {
                // error message
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvOtherCostsGrid.IsValid = false;
            }
        }



        protected void btnOtherCostsEdit_Click(object sender, EventArgs e)
        {
            if (PostPageChangesOtherCosts() == 1)
            {
                int projectId = 0;
                int refId = 0;
               
                // for other categories
                foreach (ActualCostsNavigatorTDS.OtherCostsRow otherCostsRow in actualCostsNavigatorTDS.OtherCosts)
                {
                    if (otherCostsRow.Selected)
                    {
                        projectId = otherCostsRow.ProjectID;
                        refId = otherCostsRow.RefID;
                    }
                }                           

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_edit.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvOtherCostsGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvOtherCostsGrid.IsValid = false;
            }
        }       



        protected void btnOtherCostsDelete_Click(object sender, EventArgs e)
        {
            if (PostPageChangesOtherCosts() == 1)
            {
                int projectId = 0;
                int refId = 0;
                
                // for other categories
                foreach (ActualCostsNavigatorTDS.OtherCostsRow otherCostsRow in actualCostsNavigatorTDS.OtherCosts)
                {
                    if (otherCostsRow.Selected)
                    {
                        projectId = otherCostsRow.ProjectID;
                        refId = otherCostsRow.RefID;
                    }
                }                           

                if ((projectId > 0) && (refId > 0))
                {
                    // Redirect
                    string url = "./actual_costs_delete.aspx?source_page=actual_costs_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + "&category=" + tableCategory + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                    cvOtherCostsGrid.IsValid = false;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
                cvOtherCostsGrid.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public ActualCostsNavigatorTDS.SubcontractorCostsDataTable GetNavigator()
        {
            subcontractorCosts = (ActualCostsNavigatorTDS.SubcontractorCostsDataTable)Session["subcontractorCostsNewDummy"];
            if (subcontractorCosts == null)
            {
                subcontractorCosts = ((ActualCostsNavigatorTDS.SubcontractorCostsDataTable)Session["subcontractorCosts"]);
            }

            return subcontractorCosts;
        }



        public ActualCostsNavigatorTDS.HotelCostsDataTable GetHotelNavigator()
        {
            hotelCosts = (ActualCostsNavigatorTDS.HotelCostsDataTable)Session["hotelCostsNewDummy"];
            if (hotelCosts == null)
            {
                hotelCosts = ((ActualCostsNavigatorTDS.HotelCostsDataTable)Session["hotelCosts"]);
            }

            return hotelCosts;
        }



        public ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable GetInsuranceCompaniesNavigator()
        {
            insuranceCompaniesCosts = (ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable)Session["insuranceCompaniesCostsNewDummy"];
            if (insuranceCompaniesCosts == null)
            {
                insuranceCompaniesCosts = ((ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable)Session["insuranceCompaniesCosts"]);
            }

            return insuranceCompaniesCosts;
        }



        public ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable GetBondingCompaniesNavigator()
        {
            bondingCompaniesCosts = (ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable)Session["bondingCompaniesCostsNewDummy"];
            if (bondingCompaniesCosts == null)
            {
                bondingCompaniesCosts = ((ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable)Session["bondingCompaniesCosts"]);
            }

            return bondingCompaniesCosts;
        }



        public ActualCostsNavigatorTDS.OtherCostsDataTable GetOtherNavigator()
        {
            otherCosts = (ActualCostsNavigatorTDS.OtherCostsDataTable)Session["otherCostsNewDummy"];
            if (otherCosts == null)
            {
                otherCosts = ((ActualCostsNavigatorTDS.OtherCostsDataTable)Session["otherCosts"]);
            }

            return otherCosts;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Resolve timeout problem
            ScriptManager scriptManager = (ScriptManager)this.Page.Master.FindControl("ScriptManagerMaster7");
            if (scriptManager != null)
            {
                scriptManager.AsyncPostBackTimeout = 2400;
            }

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./actual_costs_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition            
            // ...  for the client
            int companyId = Int32.Parse(hdfCompanyId.Value);
            CompaniesList companiesList = new CompaniesList(new DataSet());
            companiesList.LoadAndAddItem(-1, "(All)", companyId);
            ddlClient.DataSource = companiesList.Table;
            ddlClient.DataValueField = "COMPANIES_ID";
            ddlClient.DataTextField = "Name";
            ddlClient.DataBind();
            //ddlClient.SelectedIndex = 0;
            ddlClient.SelectedValue = Request.QueryString["search_ddlClient"];

            int clientId = -1;
            if (Request.QueryString["search_ddlClient"] != "" && Request.QueryString["search_ddlClient"] != null)
            {
                clientId = Int32.Parse(Request.QueryString["search_ddlClient"].ToString());
            }

            // ... for project
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", clientId);
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            //ddlProject.SelectedIndex = 0;
            ddlProject.SelectedValue = Request.QueryString["search_ddlProject"];

            // ... for category            
            ddlCategory.SelectedValue = Request.QueryString["search_category"];

            // ... for textForSearch
            tbxTextForSearch.Text = Request.QueryString["search_textForSearch"];

            // ... for subcontrator            
            if (Request.QueryString["search_category"] == "Subcontractors")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = true;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;

                // ... ... Load values
                odsSubcontractorsList.DataBind();
                ddlSubcontractor.DataSourceID = "odsSubcontractorsList";
                ddlSubcontractor.DataValueField = "SubcontractorID";
                ddlSubcontractor.DataTextField = "Name";
                ddlSubcontractor.DataBind();
                ddlSubcontractor.SelectedValue = Request.QueryString["search_ddlSubcontractor"];
            }

            // ... for hotel            
            if (Request.QueryString["search_category"] == "Hotels")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = true;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;

                // ... ... Load values                
                odsHotelsList.DataBind();
                ddlHotels.DataSourceID = "odsHotelsList";
                ddlHotels.DataValueField = "COMPANIES_ID";
                ddlHotels.DataTextField = "Name";
                ddlHotels.DataBind();
                ddlHotels.SelectedValue = Request.QueryString["search_ddlHotels"];
            }

            // ... for insurance            
            if (Request.QueryString["search_category"] == "Insurance")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = true;
                ddlBonding.Visible = false;

                // ... ... Load values                
                odsInsuranceList.DataBind();
                ddlInsurance.DataSourceID = "odsInsuranceList";
                ddlInsurance.DataValueField = "COMPANIES_ID";
                ddlInsurance.DataTextField = "Name";
                ddlInsurance.DataBind();
                ddlInsurance.SelectedValue = Request.QueryString["search_ddlInsurance"];
            }

            // ... for bonding         
            if (Request.QueryString["search_category"] == "Bonding")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = true;

                // ... ... Load values                
                odsBondingList.DataBind();
                ddlBonding.DataSourceID = "odsBondingList";
                ddlBonding.DataValueField = "COMPANIES_ID";
                ddlBonding.DataTextField = "Name";
                ddlBonding.DataBind();
                ddlBonding.SelectedValue = Request.QueryString["search_ddlBonding"];
            }

            //Other values
            //... For SortBy
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            if (!String.IsNullOrEmpty(Request.QueryString["search_tkrdpStartDate"].ToString()))
            {
                tkrdpStartDate.SelectedDate = DateTime.Parse(Request.QueryString["search_tkrdpStartDate"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["search_tkrdpEndDate"].ToString()))
            {
                tkrdpEndDate.SelectedDate = DateTime.Parse(Request.QueryString["search_tkrdpEndDate"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["search_cbxFilterByDateSelected"].ToString()))
            {
                cbxFilterByRangeOfDates.Checked = Convert.ToBoolean(Request.QueryString["search_cbxFilterByDateSelected"]);
            }

            // for panels
            MakePanelsVisible();
        }



        private string GetNavigatorState()
        {
            // SearchOptions for condition 
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlClient=" + ddlClient.SelectedValue;
            searchOptions = searchOptions + "&search_ddlProject=" + ddlProject.SelectedValue;
            searchOptions = searchOptions + "&search_ddlSubcontractor=" + ddlSubcontractor.SelectedValue;
            searchOptions = searchOptions + "&search_ddlHotels=" + ddlHotels.SelectedValue;
            searchOptions = searchOptions + "&search_ddlInsurance=" + ddlInsurance.SelectedValue;
            searchOptions = searchOptions + "&search_ddlBonding=" + ddlBonding.SelectedValue;
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&search_tkrdpStartDate=" + tkrdpStartDate.SelectedDate;
            searchOptions = searchOptions + "&search_tkrdpEndDate=" + tkrdpEndDate.SelectedDate;
            searchOptions = searchOptions + "&search_cbxFilterByDateSelected=" + cbxFilterByRangeOfDates.Checked.ToString();
            searchOptions = searchOptions + "&search_category=" + ddlCategory.SelectedValue;
            searchOptions = searchOptions + "&search_textForSearch=" + tbxTextForSearch.Text;

            // Return
            return searchOptions;
        }



        private ActualCostsNavigatorTDS SubmitSearch()
        {
            // Values to search            
            int projectId = Convert.ToInt32(ddlProject.SelectedValue);
            int clientId = Convert.ToInt32(ddlClient.SelectedValue);
            string textForSearch = tbxTextForSearch.Text;
            string category = ddlCategory.SelectedValue;
            ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch = new ActualCostsNavigatorTDS();

            // Retrieve  Where clause     
            if (category == "All")
            {
                // ... subcontractors                              
                LoadBySubcontractor(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... hotels                           
                LoadByHotel(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... insurance               
                LoadByInsurance(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... bonding                              
                LoadByBonding(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... others                               
                LoadByOther(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, "LoadAll");
            }
            else
            {
                if (category == "Subcontractors")
                {                    
                    int subcontractorId = Convert.ToInt32(ddlSubcontractor.SelectedValue);
                    LoadBySubcontractor(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, subcontractorId);
                }
                else
                {
                    if (category == "Hotels")
                    {                        
                        int hotelId = Convert.ToInt32(ddlHotels.SelectedValue);
                        LoadByHotel(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, hotelId);
                    }
                    else
                    {
                        if (category == "Insurance")
                        {
                            int insuranceCompanyId = Convert.ToInt32(ddlInsurance.SelectedValue);
                            LoadByInsurance(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, insuranceCompanyId);
                        }
                        else
                        {
                            if (category == "Bonding")
                            {
                                int bondingCompanyId = Convert.ToInt32(ddlBonding.SelectedValue);
                                LoadByBonding(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, bondingCompanyId);
                            }
                            else
                            {                                
                                LoadByOther(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, category);
                            }
                        }
                    }
                }
            }           

            return actualCostsNavigatorTDSForSearch;
        }


        private void LoadBySubcontractor(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int subcontractorId)
        {
            string whereClause = GetWhereClauseForSubcontractor(subcontractorId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorSubcontractorCosts actualCostsNavigatorSubcontractorCosts = new ActualCostsNavigatorSubcontractorCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorSubcontractorCosts.Load(whereClause, orderByClause);
        }



        private void LoadByHotel(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int hotelId)
        {
            string whereClause = GetWhereClauseForHotel(hotelId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorHotelCosts actualCostsNavigatorHotelCosts = new ActualCostsNavigatorHotelCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorHotelCosts.Load(whereClause, orderByClause);
        }


        private void LoadByInsurance(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int insuranceCompanyId)
        {
            string whereClause = GetWhereClauseForInsurance(insuranceCompanyId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorInsuranceCompaniesCosts actualCostsNavigatorInsuranceCompaniesCosts = new ActualCostsNavigatorInsuranceCompaniesCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorInsuranceCompaniesCosts.Load(whereClause, orderByClause);
        }



        private void LoadByBonding(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int bondingCompanyId)
        {
            string whereClause = GetWhereClauseForBonding(bondingCompanyId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorBondingCompaniesCosts actualCostsNavigatorBondingCompaniesCosts = new ActualCostsNavigatorBondingCompaniesCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorBondingCompaniesCosts.Load(whereClause, orderByClause);
        }



        private void LoadByOther(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, string category)
        {
            bool loadAll = false;
            if (category == "LoadAll") loadAll = true;
            string whereClause = GetWhereClauseForOther(category, projectId, clientId, textForSearch, loadAll);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorOtherCosts actualCostsNavigatorOtherCosts = new ActualCostsNavigatorOtherCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorOtherCosts.Load(whereClause, orderByClause);
        }



        private string GetWhereClauseForSubcontractor(int subcontractorId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(SC.Deleted = 0) AND (S.Deleted = 0) ";

            // Subcontractor selected
            if (subcontractorId != -1)
            {
                whereClause = whereClause + "AND (SC.SubcontractorID = " + subcontractorId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (SC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND SC.Date >= '{0}' AND SC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((SC.RateCad IS NULL) OR (SC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((SC.RateCad LIKE '%') OR (SC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (SC.RateCad IS NULL) OR (SC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((SC.RateCad " + operatorValue + textForSearch + ") or (SC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }


            return whereClause;
        }



        private string GetWhereClauseForHotel(int hotelId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(HC.Deleted = 0) AND (H.Deleted = 0) ";

            // Hotel selected
            if (hotelId != -1)
            {
                whereClause = whereClause + "AND (HC.HotelID = " + hotelId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (HC.ProjectID = " + projectId + ") ";
            }

            // Date Range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND HC.Date >= '{0}' AND HC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((HC.RateCad IS NULL) OR (HC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((HC.RateCad LIKE '%') OR (HC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (HC.RateCad IS NULL) OR (HC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((HC.RateCad " + operatorValue + textForSearch + ") or (HC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForInsurance(int insuranceId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(ICC.Deleted = 0) AND (IC.Deleted = 0) ";

            // Insurance selected
            if (insuranceId != -1)
            {
                whereClause = whereClause + "AND (ICC.InsuranceCompanyID = " + insuranceId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (ICC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND ICC.Date >= '{0}' AND ICC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((ICC.RateCad IS NULL) OR (ICC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((ICC.RateCad LIKE '%') OR (ICC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (ICC.RateCad IS NULL) OR (ICC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((ICC.RateCad " + operatorValue + textForSearch + ") or (ICC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForBonding(int bondingId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(BCC.Deleted = 0) AND (BC.Deleted = 0) ";

            // Bonding selected
            if (bondingId != -1)
            {
                whereClause = whereClause + "AND (BCC.BondingCompanyID = " + bondingId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (BCC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND BCC.Date >= '{0}' AND BCC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((BCC.RateCad IS NULL) OR (BCC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((BCC.RateCad LIKE '%') OR (BCC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (BCC.RateCad IS NULL) OR (BCC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((BCC.RateCad " + operatorValue + textForSearch + ") or (BCC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForOther(string category, int projectId, int clientId, string textForSearch, bool loadAll)
        {
            // General conditions
            string whereClause = " (OC.Deleted = 0) ";

            // Category selected    
            if (!loadAll)
            {
                whereClause = whereClause + "AND (OC.Category = '" + category + "')";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (OC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND OC.Date >= '{0}' AND OC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((OC.RateCad IS NULL) OR (OC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((OC.RateCad LIKE '%') OR (OC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (OC.RateCad IS NULL) OR (OC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((OC.RateCad " + operatorValue + textForSearch + ") or (OC.RateUSd " + operatorValue + textForSearch + ")) ";
                }
            }

            return whereClause;
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



        protected void AddNewSubcontractorEmptyFix(GridView grdSubcontractorNavigator)
        {
            if (grdSubcontractorNavigator.Rows.Count == 0)
            {
                ActualCostsNavigatorTDS.SubcontractorCostsDataTable dt = new ActualCostsNavigatorTDS.SubcontractorCostsDataTable();
                dt.AddSubcontractorCostsRow(-1, -1, -1, DateTime.Now, "", "", "", -1, -1, -1, -1, -1, false, false);
                Session["subcontractorCostsNewDummy"] = dt;

                grdSubcontractorNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdSubcontractorNavigator.Rows.Count == 1)
            {
                ActualCostsNavigatorTDS.SubcontractorCostsDataTable dt = (ActualCostsNavigatorTDS.SubcontractorCostsDataTable)Session["subcontractorCostsNewDummy"];
                if (dt != null)
                {
                    grdSubcontractorNavigator.Rows[0].Visible = false;
                    grdSubcontractorNavigator.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNewHotelEmptyFix(GridView grdHotelNavigator)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            if (grdHotelNavigator.Rows.Count == 0)
            {
                ActualCostsNavigatorTDS.HotelCostsDataTable dt = new ActualCostsNavigatorTDS.HotelCostsDataTable();
                dt.AddHotelCostsRow(-1, -1, -1, DateTime.Now, "", "", "", -1, -1, "", false, companyId, false);
                Session["hotelCostsNewDummy"] = dt;

                grdHotelNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdHotelNavigator.Rows.Count == 1)
            {
                ActualCostsNavigatorTDS.HotelCostsDataTable dt = (ActualCostsNavigatorTDS.HotelCostsDataTable)Session["hotelCostsNewDummy"];
                if (dt != null)
                {
                    grdHotelNavigator.Rows[0].Visible = false;
                    grdHotelNavigator.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNewInsuranceEmptyFix(GridView grdInsuranceNavigator)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            if (grdInsuranceNavigator.Rows.Count == 0)
            {
                ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable dt = new ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable();
                dt.AddInsuranceCompaniesCostsRow(-1, -1, -1, DateTime.Now, "", "", "", -1, -1, "", false, companyId, false);
                Session["insuranceCompaniesCostsNewDummy"] = dt;

                grdInsuranceNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdInsuranceNavigator.Rows.Count == 1)
            {
                ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable dt = (ActualCostsNavigatorTDS.InsuranceCompaniesCostsDataTable)Session["insuranceCompaniesCostsNewDummy"];
                if (dt != null)
                {
                    grdInsuranceNavigator.Rows[0].Visible = false;
                    grdInsuranceNavigator.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNewBondingEmptyFix(GridView grdBondingNavigator)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (grdBondingNavigator.Rows.Count == 0)
            {
                ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable dt = new ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable();
                dt.AddBondingCompaniesCostsRow(-1, -1, -1, DateTime.Now, "", "", "", -1, -1, "", false, companyId, false);
                Session["bondingCompaniesCostsNewDummy"] = dt;

                grdBondingNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdBondingNavigator.Rows.Count == 1)
            {
                ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable dt = (ActualCostsNavigatorTDS.BondingCompaniesCostsDataTable)Session["bondingCompaniesCostsNewDummy"];
                if (dt != null)
                {
                    grdBondingNavigator.Rows[0].Visible = false;
                    grdBondingNavigator.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNewOtherEmptyFix(GridView grdOtherNavigator)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (grdOtherNavigator.Rows.Count == 0)
            {
                ActualCostsNavigatorTDS.OtherCostsDataTable dt = new ActualCostsNavigatorTDS.OtherCostsDataTable();
                dt.AddOtherCostsRow(-1, -1, "", DateTime.Now, "", "", -1, -1, "", false, companyId, false);
                Session["otherCostsNewDummy"] = dt;

                grdOtherNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdOtherNavigator.Rows.Count == 1)
            {
                ActualCostsNavigatorTDS.OtherCostsDataTable dt = (ActualCostsNavigatorTDS.OtherCostsDataTable)Session["otherCostsNewDummy"];
                if (dt != null)
                {
                    grdOtherNavigator.Rows[0].Visible = false;
                    grdOtherNavigator.Rows[0].Controls.Clear();
                }
            }
        }




        private string GetOrderByClause()
        {
            // Get order by clause
            string orderBy = "";
            string category = ddlCategory.SelectedValue;

            switch (ddlSortBy.SelectedItem.Text)
            {                
                case "Client":
                    orderBy = " C.Name ASC";
                    break;

                case "Project":
                    orderBy = " P.Name ASC";
                    break;
            }

            return orderBy;
        }



        private int PostPageChangesSubcontractor()
        {
            int selectedRows = 0;

            // Update subcontractors
            if (pnlGrid.Visible)
            {
                ActualCostsNavigatorSubcontractorCosts actualCostsNavigatorSubcontractorCosts = new ActualCostsNavigatorSubcontractorCosts(actualCostsNavigatorTDS);
                if (actualCostsNavigatorSubcontractorCosts.Table.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdSubcontractorNavigator.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                        {
                            int projectId = Int32.Parse(((Label)row.FindControl("lblProjectID")).Text.Trim());
                            int refId = Int32.Parse(((Label)row.FindControl("lblRefIDID")).Text.Trim());
                            bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                            tableCategory = "Subcontractors";
                            selectedRows = selectedRows + 1;

                            actualCostsNavigatorSubcontractorCosts.Update(projectId, refId, selected);
                        }
                    }

                    actualCostsNavigatorSubcontractorCosts.Data.AcceptChanges();

                    // Store datasets
                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                }
            }

            return selectedRows;
        }



        private int PostPageChangesHotels()
        {
            int selectedRows = 0;

            if (pnlHotelGrid.Visible)
            {
                ActualCostsNavigatorHotelCosts actualCostsNavigatorHotelCosts = new ActualCostsNavigatorHotelCosts(actualCostsNavigatorTDS);
                
                if (actualCostsNavigatorHotelCosts.Table.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdHotelNavigator.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxHotelSelected")).Checked)
                        {
                            int hotelId = Int32.Parse(((Label)row.FindControl("lblHotelID")).Text.Trim());
                            int projectId = Int32.Parse(((Label)row.FindControl("lblHotelProjectID")).Text.Trim());
                            int refId = Int32.Parse(((Label)row.FindControl("lblHotelRefID")).Text.Trim());
                            bool selected = ((CheckBox)row.FindControl("cbxHotelSelected")).Checked;
                            tableCategory = "Hotels";
                            selectedRows = selectedRows + 1;

                            actualCostsNavigatorHotelCosts.Update(projectId, refId, selected);
                        }
                    }

                    actualCostsNavigatorHotelCosts.Data.AcceptChanges();

                    // Store datasets
                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                }
            }

            return selectedRows;
        }



        private int PostPageChangesInsurance()
        {
            int selectedRows = 0;

            if (pnlInsuranceGrid.Visible)
            {
                ActualCostsNavigatorInsuranceCompaniesCosts actualCostsNavigatorInsuranceCompaniesCosts = new ActualCostsNavigatorInsuranceCompaniesCosts(actualCostsNavigatorTDS);

                if (actualCostsNavigatorInsuranceCompaniesCosts.Table.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdInsuranceNavigator.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxInsuranceSelected")).Checked)
                        {
                            int insuranceCompanyId = Int32.Parse(((Label)row.FindControl("lblInsuranceCompanyID")).Text.Trim());
                            int projectId = Int32.Parse(((Label)row.FindControl("lblInsuranceProjectID")).Text.Trim());
                            int refId = Int32.Parse(((Label)row.FindControl("lblInsuranceRefID")).Text.Trim());
                            bool selected = ((CheckBox)row.FindControl("cbxInsuranceSelected")).Checked;
                            tableCategory = "Insurance";
                            selectedRows = selectedRows + 1;

                            actualCostsNavigatorInsuranceCompaniesCosts.Update(projectId, refId, selected);
                        }
                    }

                    actualCostsNavigatorInsuranceCompaniesCosts.Data.AcceptChanges();

                    // Store datasets
                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                }
            }

            return selectedRows;
        }



        private int PostPageChangesBonding()
        {
            int selectedRows = 0;

            if (pnlBondingGrid.Visible)
            {
                ActualCostsNavigatorBondingCompaniesCosts actualCostsNavigatorBondingCompaniesCosts = new ActualCostsNavigatorBondingCompaniesCosts(actualCostsNavigatorTDS);

                if (actualCostsNavigatorBondingCompaniesCosts.Table.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdBondingNavigator.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxBondingSelected")).Checked)
                        {
                            int insuranceCompanyId = Int32.Parse(((Label)row.FindControl("lblBondingCompanyID")).Text.Trim());
                            int projectId = Int32.Parse(((Label)row.FindControl("lblBondingProjectID")).Text.Trim());
                            int refId = Int32.Parse(((Label)row.FindControl("lblBondingRefID")).Text.Trim());
                            bool selected = ((CheckBox)row.FindControl("cbxBondingSelected")).Checked;
                            tableCategory = "Bonding";
                            selectedRows = selectedRows + 1;

                            actualCostsNavigatorBondingCompaniesCosts.Update(projectId, refId, selected);
                        }
                    }

                    actualCostsNavigatorBondingCompaniesCosts.Data.AcceptChanges();

                    // Store datasets
                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                }
            }

            return selectedRows;
        }



        private int PostPageChangesOtherCosts()
        {
            int selectedRows = 0;

            if (pnlOtherGrid.Visible)
            { 
                ActualCostsNavigatorOtherCosts actualCostsNavigatorOtherCosts = new ActualCostsNavigatorOtherCosts(actualCostsNavigatorTDS);
                if (actualCostsNavigatorOtherCosts.Table.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdOtherNavigator.Rows)
                    {
                        if (((CheckBox)row.FindControl("cbxOtherSelected")).Checked)
                        {
                            string category = ((Label)row.FindControl("lblCategory")).Text.Trim();
                            int projectId = Int32.Parse(((Label)row.FindControl("lblOtherProjectID")).Text.Trim());
                            int refId = Int32.Parse(((Label)row.FindControl("lblOtherRefID")).Text.Trim());
                            bool selected = ((CheckBox)row.FindControl("cbxOtherSelected")).Checked;
                            tableCategory = category;
                            selectedRows = selectedRows + 1;

                            actualCostsNavigatorOtherCosts.Update(projectId, refId, selected);
                        }
                    }

                    actualCostsNavigatorOtherCosts.Data.AcceptChanges();

                    // Store datasets
                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;
                }
            }

            return selectedRows;
        }



        /*protected void cbxFilterByRangeOfDates_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFilterByRangeOfDates.Checked)
            {
                SetFilterByDate();
            }
        }*/

        protected void MakePanelsVisible()
        { 
            // For visiblePanels
            string category = Request.QueryString["search_category"];
            if (category == "All")
            {                
                pnlGrid.Visible = true;                            
                pnlHotelGrid.Visible = true;                               
                pnlInsuranceGrid.Visible = true;                              
                pnlBondingGrid.Visible = true;                         
                pnlOtherGrid.Visible = true;                                
            }
            else
            {
                if (category == "Subcontractors")
                {
                    pnlGrid.Visible = true;                    
                    pnlHotelGrid.Visible = false;                    
                    pnlInsuranceGrid.Visible = false;                    
                    pnlBondingGrid.Visible = false;                    
                    pnlOtherGrid.Visible = false;
                }
                else
                {
                    if (category == "Hotels")
                    {
                        pnlGrid.Visible = false;                        
                        pnlHotelGrid.Visible = true;                        
                        pnlInsuranceGrid.Visible = false;                        
                        pnlBondingGrid.Visible = false;                        
                        pnlOtherGrid.Visible = false;
                    }
                    else
                    {
                        if (category == "Insurance")
                        {
                            pnlGrid.Visible = false;                            
                            pnlHotelGrid.Visible = false;                            
                            pnlInsuranceGrid.Visible = true;                            
                            pnlBondingGrid.Visible = false;                            
                            pnlOtherGrid.Visible = false;
                        }
                        else
                        {
                            if (category == "Bonding")
                            {
                                pnlGrid.Visible = false;                                
                                pnlHotelGrid.Visible = false;                                
                                pnlInsuranceGrid.Visible = false;                                
                                pnlBondingGrid.Visible = true;                                
                                pnlOtherGrid.Visible = false;
                            }
                            else
                            {
                                pnlGrid.Visible = false;                                
                                pnlHotelGrid.Visible = false;                                
                                pnlInsuranceGrid.Visible = false;                                
                                pnlBondingGrid.Visible = false;                                
                                pnlOtherGrid.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        

    }
}