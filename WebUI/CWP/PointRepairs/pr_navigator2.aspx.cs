using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.BL.CWP.PointRepairs;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.PointRepairs
{
    /// <summary>
    /// pr_navigator2
    /// </summary>
    public partial class pr_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected PrNavigatorTDS prNavigatorTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in pr_navigator2.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = "Point Repairs";

                // Prepare initial data
                // ... For sortByList
                odsSortByList.DataBind();
                ddlSortBy.DataSourceID = "odsSortByList";
                ddlSortBy.DataValueField = "SortID";
                ddlSortBy.DataTextField = "Name";
                ddlSortBy.DataBind();

                // ... For 
                odsViewForDisplayList.DataBind();
                ddlCondition1.DataSourceID = "odsViewForDisplayList";
                ddlCondition1.DataValueField = "ConditionID";
                ddlCondition1.DataTextField = "Name";
                ddlCondition1.DataBind();

                // ... For view ddl
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                string workType = hdfWorkType.Value;
                int loginId = Convert.ToInt32(Session["loginID"]);
                string viewTypeGlobal = "";
                string viewTypePersonal = "Personal";

                // Global Views check
                if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
                {
                    viewTypeGlobal = "Global";
                }

                WorkViewList workViewList = new WorkViewList();
                workViewList.LoadAndAddItem(workType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
                ddlView.DataSource = workViewList.Table;
                ddlView.DataValueField = "ViewID";
                ddlView.DataTextField = "Name";
                ddlView.DataBind();
                ddlView.SelectedIndex = 1;

                WorkTypeViewSubAreaList workTypeViewSubAreaList = new WorkTypeViewSubAreaList();
                workTypeViewSubAreaList.LoadAndAddItem("Point Repairs", Int32.Parse(hdfCompanyId.Value), int.Parse(hdfCurrentProjectId.Value), "(All)");
                ddlSubArea.DataSource = workTypeViewSubAreaList.Table;
                ddlSubArea.DataValueField = "SubArea";
                ddlSubArea.DataTextField = "SubArea";
                ddlSubArea.DataBind();

                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // ... for project
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // If coming from 
                // ... pr_navigator.aspx or pr_navigator2.aspx
                if ((Request.QueryString["source_page"] == "pr_navigator.aspx") || (Request.QueryString["source_page"] == "pr_navigator2.aspx"))
                {
                    RestoreNavigatorState();

                    prNavigatorTDS = (PrNavigatorTDS)Session["prNavigatorTDS"];
                }

                // ... pr_edit.aspx, pr_summary.aspx or pr_delete.aspx
                if ((Request.QueryString["source_page"] == "pr_edit.aspx") || (Request.QueryString["source_page"] == "pr_summary.aspx") || (Request.QueryString["source_page"] == "pr_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        prNavigatorTDS = (PrNavigatorTDS)Session["prNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("prNavigatorTDS");

                        // ... Search data with updates
                        if (hdfBtnOrigin.Value == "Search")
                        {
                            prNavigatorTDS = SubmitSearch();
                        }
                        else
                        {
                            if (hdfBtnOrigin.Value == "Go")
                            {
                                prNavigatorTDS = SubmitSearchForViews();
                            }
                        }

                        // ... store datasets
                        Session["prNavigatorTDS"] = prNavigatorTDS;
                    }
                }

                // ... pr_delete.aspx, pr_summary.aspx or pr_edit.aspx
                if ((Request.QueryString["source_page"] == "pr_delete.aspx") || (Request.QueryString["source_page"] == "pr_summary.aspx") || (Request.QueryString["source_page"] == "pr_edit.aspx"))
                {
                    if (prNavigatorTDS.PrNavigator.Rows.Count == 0)
                    {
                        string url = "./pr_navigator.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                // For the grid
                grdPrNavigator.DataSource = prNavigatorTDS.PrNavigator;
                grdPrNavigator.DataBind();

                //... for the total rows
                if (prNavigatorTDS.PrNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + prNavigatorTDS.PrNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
            else
            {
                // Restore TDS
                prNavigatorTDS = (PrNavigatorTDS)Session["prNavigatorTDS"];
                
                // ... for the total rows
                if (prNavigatorTDS.PrNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + prNavigatorTDS.PrNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Tag Page
                hdfBtnOrigin.Value = "Search";

                string url = "";

                // Delete store data
                Session.Contents.Remove("prNavigatorTDS");

                // Get data from DA gateway
                prNavigatorTDS = SubmitSearch();

                // Show results
                if (prNavigatorTDS.PrNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["prNavigatorTDS"] = prNavigatorTDS;

                    // ... Go to the results page
                    url = "./pr_navigator2.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./pr_navigator.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }



        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Tag Page
                hdfBtnOrigin.Value = "Go";

                string url = "";

                // Delete store data
                Session.Contents.Remove("prNavigatorTDS");

                // Get data from DA gateway
                prNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (prNavigatorTDS.PrNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["prNavigatorTDS"] = prNavigatorTDS;

                    // ... Go to the results page
                    url = "./pr_navigator2.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./pr_navigator.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }


                
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "eSewers";

            // View buttons
            if (Convert.ToBoolean(Session["sgLFS_VIEWS_DELETE"]))
            {
                btnViewDelete.Visible = true;
            }
            else
            {
                btnViewDelete.Visible = false;
            }

            if (Convert.ToBoolean(Session["sgLFS_VIEWS_EDIT"]))
            {
                btnViewEdit.Visible = true;
            }
            else
            {
                btnViewEdit.Visible = false;
            }

            if (Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"]))
            {
                btnViewAdd.Visible = true;
            }
            else
            {
                btnViewAdd.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void cvInvalidOperator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Operator for Text and boolean fields
            if ((ddlCondition1.SelectedItem.Text == "ID (Section)") || (ddlCondition1.SelectedItem.Text == "ID (Repair)") || (ddlCondition1.SelectedItem.Text == "Street") || (ddlCondition1.SelectedItem.Text == "Street") || (ddlCondition1.SelectedItem.Text == "USMH") || (ddlCondition1.SelectedItem.Text == "USMH Address") || (ddlCondition1.SelectedItem.Text == "DSMH") || (ddlCondition1.SelectedItem.Text == "DSMH Address") || (ddlCondition1.SelectedItem.Text == "Map Size") || (ddlCondition1.SelectedItem.Text == "Confirmed Size") || (ddlCondition1.SelectedItem.Text == "Map Length") || (ddlCondition1.SelectedItem.Text == "Steel Tape Length") || (ddlCondition1.SelectedItem.Text == "Video Length") || (ddlCondition1.SelectedItem.Text == "Client ID") || (ddlCondition1.SelectedItem.Text == "Measurements Taken By") || (ddlCondition1.SelectedItem.Text == "Traffic Control") || (ddlCondition1.SelectedItem.Text == "Material") || (ddlCondition1.SelectedItem.Text == "Bypass Required?") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition1.SelectedItem.Text == "Robotic Distances") || (ddlCondition1.SelectedItem.Text == "Issue Identified?") || (ddlCondition1.SelectedItem.Text == "LFS Issue?") || (ddlCondition1.SelectedItem.Text == "Client Issue?") || (ddlCondition1.SelectedItem.Text == "Sales Issue?") || (ddlCondition1.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition1.SelectedItem.Text == "Issue Investigation?") || (ddlCondition1.SelectedItem.Text == "Issue Resolved?") || (ddlCondition1.SelectedItem.Text == "Comments") || (ddlCondition1.SelectedItem.Text == "Repair Type") || (ddlCondition1.SelectedItem.Text == "Defect Qualifier") || (ddlCondition1.SelectedItem.Text == "Defect Details") || (ddlCondition1.SelectedItem.Text == "Extra Repair") || (ddlCondition1.SelectedItem.Text == "Cancelled") || (ddlCondition1.SelectedItem.Text == "Approval") || (ddlCondition1.SelectedItem.Text == "Repair Comments") || (ddlCondition1.SelectedItem.Text == "Ream Distance") || (ddlCondition1.SelectedItem.Text == "Liner Distance") || (ddlCondition1.SelectedItem.Text == "Direction") || (ddlCondition1.SelectedItem.Text == "LT @ MH") || (ddlCondition1.SelectedItem.Text == "VT @ MH") || (ddlCondition1.SelectedItem.Text == "Distance") || (ddlCondition1.SelectedItem.Text == "Repair Size") || (ddlCondition1.SelectedItem.Text == "Repair Length") || (ddlCondition1.SelectedItem.Text == "MH Shot?") || (ddlCondition1.SelectedItem.Text == "Grout Distance"))
            {
                //  ... Only use equals to and not operators
                if ((ddlOperator1.SelectedValue == "=") || (ddlOperator1.SelectedValue == "<>"))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }

            // Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "Repair Confirmation Date") || (ddlCondition1.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition1.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition1.SelectedItem.Text == "Grout Date") || (ddlCondition1.SelectedItem.Text == "Final Video") || (ddlCondition1.SelectedItem.Text == "Ream Date") || (ddlCondition1.SelectedItem.Text == "Install Date"))
            {
                if ((tbxCondition1.Text.Trim() == "%") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                {
                    args.IsValid = false;
                }
                else
                {
                    if ((tbxCondition1.Text.Trim() == "") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }

            // For Integer fields
            if ((ddlCondition1.SelectedItem.Text == "Laterals") || (ddlCondition1.SelectedItem.Text == "Live Laterals") || (ddlCondition1.SelectedItem.Text == "CXI's Removed") || (ddlCondition1.SelectedItem.Text == "Estimated Joints") || (ddlCondition1.SelectedItem.Text == "Joints Test Sealed") || (ddlCondition1.SelectedItem.Text == "Reinstates"))
            {
                if ((tbxCondition1.Text.Trim() == "%") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                {
                    args.IsValid = false;
                }
                else
                {
                    if ((tbxCondition1.Text.Trim() == "") && (ddlOperator1.SelectedValue != "=") && (ddlOperator1.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvInvalidOperator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Operator for Text and boolean fields
            if ((ddlCondition2.SelectedItem.Text == "ID (Section)") || (ddlCondition2.SelectedItem.Text == "ID (Repair)") || (ddlCondition2.SelectedItem.Text == "Street") || (ddlCondition2.SelectedItem.Text == "Street") || (ddlCondition2.SelectedItem.Text == "USMH") || (ddlCondition2.SelectedItem.Text == "USMH Address") || (ddlCondition2.SelectedItem.Text == "DSMH") || (ddlCondition2.SelectedItem.Text == "DSMH Address") || (ddlCondition2.SelectedItem.Text == "Map Size") || (ddlCondition2.SelectedItem.Text == "Confirmed Size") || (ddlCondition2.SelectedItem.Text == "Map Length") || (ddlCondition2.SelectedItem.Text == "Steel Tape Length") || (ddlCondition2.SelectedItem.Text == "Video Length") || (ddlCondition2.SelectedItem.Text == "Client ID") || (ddlCondition2.SelectedItem.Text == "Measurements Taken By") || (ddlCondition2.SelectedItem.Text == "Traffic Control") || (ddlCondition2.SelectedItem.Text == "Material") || (ddlCondition2.SelectedItem.Text == "Bypass Required?") || (ddlCondition2.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition2.SelectedItem.Text == "Robotic Distances") || (ddlCondition2.SelectedItem.Text == "Issue Identified?") || (ddlCondition2.SelectedItem.Text == "LFS Issue?") || (ddlCondition2.SelectedItem.Text == "Client Issue?") || (ddlCondition2.SelectedItem.Text == "Sales Issue?") || (ddlCondition2.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition2.SelectedItem.Text == "Issue Investigation?") || (ddlCondition2.SelectedItem.Text == "Issue Resolved?") || (ddlCondition2.SelectedItem.Text == "Comments") || (ddlCondition2.SelectedItem.Text == "Repair Type") || (ddlCondition2.SelectedItem.Text == "Defect Qualifier") || (ddlCondition2.SelectedItem.Text == "Defect Details") || (ddlCondition2.SelectedItem.Text == "Extra Repair") || (ddlCondition2.SelectedItem.Text == "Cancelled") || (ddlCondition2.SelectedItem.Text == "Approval") || (ddlCondition2.SelectedItem.Text == "Repair Comments") || (ddlCondition2.SelectedItem.Text == "Ream Distance") || (ddlCondition2.SelectedItem.Text == "Liner Distance") || (ddlCondition2.SelectedItem.Text == "Direction") || (ddlCondition2.SelectedItem.Text == "LT @ MH") || (ddlCondition2.SelectedItem.Text == "VT @ MH") || (ddlCondition2.SelectedItem.Text == "Distance") || (ddlCondition2.SelectedItem.Text == "Repair Size") || (ddlCondition2.SelectedItem.Text == "Repair Length") || (ddlCondition2.SelectedItem.Text == "MH Shot?") || (ddlCondition2.SelectedItem.Text == "Grout Distance"))
            {
                // ... Only use equals to and not operators
                if ((ddlOperator2.SelectedValue == "=") || (ddlOperator2.SelectedValue == "<>"))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }

            // Date fields validate
            if ((ddlCondition2.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition2.SelectedItem.Text == "Pre-Video Date") || (ddlCondition2.SelectedItem.Text == "P1 Date") || (ddlCondition2.SelectedItem.Text == "Repair Confirmation Date") || (ddlCondition2.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition2.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition2.SelectedItem.Text == "Grout Date") || (ddlCondition2.SelectedItem.Text == "Final Video") || (ddlCondition2.SelectedItem.Text == "Ream Date") || (ddlCondition2.SelectedItem.Text == "Install Date"))
            {
                if ((tbxCondition2.Text.Trim() == "%") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                {
                    args.IsValid = false;
                }
                else
                {
                    if ((tbxCondition2.Text.Trim() == "") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }

            // For Integer fields
            if ((ddlCondition2.SelectedItem.Text == "Laterals") || (ddlCondition2.SelectedItem.Text == "Live Laterals") || (ddlCondition2.SelectedItem.Text == "CXI's Removed") || (ddlCondition2.SelectedItem.Text == "Estimated Joints") || (ddlCondition2.SelectedItem.Text == "Joints Test Sealed") || (ddlCondition2.SelectedItem.Text == "Reinstates"))
            {
                if ((tbxCondition2.Text.Trim() == "%") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                {
                    args.IsValid = false;
                }
                else
                {
                    if ((tbxCondition2.Text.Trim() == "") && (ddlOperator2.SelectedValue != "=") && (ddlOperator2.SelectedValue != "<>"))
                    {
                        args.IsValid = false;
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvInvalidOperatorForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "Bypass Required?") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition1.SelectedItem.Text == "Issue Identified?") || (ddlCondition1.SelectedItem.Text == "LFS Issue?") || (ddlCondition1.SelectedItem.Text == "Client Issue?") || (ddlCondition1.SelectedItem.Text == "Sales Issue?") || (ddlCondition1.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition1.SelectedItem.Text == "Issue Investigation?") || (ddlCondition1.SelectedItem.Text == "Issue Resolved?") || (ddlCondition1.SelectedItem.Text == "Extra Repair") || (ddlCondition1.SelectedItem.Text == "Cancelled"))
            {
                // ... The not operator can't be use with %
                if ((ddlOperator1.SelectedValue == "<>") && (tbxCondition1.Text.Trim() == "%"))
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvInvalidOperatorForBoolean2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition2.SelectedItem.Text == "Bypass Required?") || (ddlCondition2.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition2.SelectedItem.Text == "Issue Identified?") || (ddlCondition2.SelectedItem.Text == "LFS Issue?") || (ddlCondition2.SelectedItem.Text == "Client Issue?") || (ddlCondition2.SelectedItem.Text == "Sales Issue?") || (ddlCondition2.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition2.SelectedItem.Text == "Issue Investigation?") || (ddlCondition2.SelectedItem.Text == "Issue Resolved?") || (ddlCondition2.SelectedItem.Text == "Extra Repair") || (ddlCondition1.SelectedItem.Text == "Cancelled"))
            {
                // ... The not operator can't be use with %
                if ((ddlOperator2.SelectedValue == "<>") && (tbxCondition2.Text.Trim() == "%"))
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvSelectOperator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((ddlCondition2.SelectedValue != "-1") && (ddlOperator2.SelectedValue == ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvDeleteOperator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((ddlCondition2.SelectedValue == "-1") && (ddlOperator2.SelectedValue != ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvForDate2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition2.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition2.SelectedItem.Text == "Pre-Video Date") || (ddlCondition2.SelectedItem.Text == "P1 Date") || (ddlCondition2.SelectedItem.Text == "Repair Confirmation Date") || (ddlCondition2.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition2.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition2.SelectedItem.Text == "Grout Date") || (ddlCondition2.SelectedItem.Text == "Final Video") || (ddlCondition2.SelectedItem.Text == "Ream Date") || (ddlCondition2.SelectedItem.Text == "Install Date"))
            {
                // for complete date and only year
                if (((Validator.IsValidDate(args.Value.Trim()) && (args.Value.Trim().Length > 7))) || ((Validator.IsValidInt32(args.Value.Trim())) && (args.Value.Trim().Length == 4)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForDateRange2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition2.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition2.SelectedItem.Text == "Pre-Video Date") || (ddlCondition2.SelectedItem.Text == "P1 Date") || (ddlCondition2.SelectedItem.Text == "Repair Confirmation Date") || (ddlCondition2.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition2.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition2.SelectedItem.Text == "Grout Date") || (ddlCondition2.SelectedItem.Text == "Final Video") || (ddlCondition2.SelectedItem.Text == "Ream Date") || (ddlCondition2.SelectedItem.Text == "Install Date"))
            {
                // For dates before 1900
                if (cvForDate2.IsValid)
                {
                    string[] date = (args.Value.Trim()).Split('/');
                    if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition1.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition1.SelectedItem.Text == "Grout Date") || (ddlCondition1.SelectedItem.Text == "Final Video") || (ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "Repair Confirmation Date") || (ddlCondition1.SelectedItem.Text == "Ream Date") || (ddlCondition1.SelectedItem.Text == "Install Date") || (ddlCondition1.SelectedItem.Text == "Grout Date"))
            {
                // for complete date and only year
                if (((Validator.IsValidDate(args.Value.Trim()) && (args.Value.Trim().Length > 7))) || ((Validator.IsValidInt32(args.Value.Trim())) && (args.Value.Trim().Length == 4)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition1.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition1.SelectedItem.Text == "Grout Date") || (ddlCondition1.SelectedItem.Text == "Final Video") || (ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "Repair Confirmation Date") || (ddlCondition1.SelectedItem.Text == "Ream Date") || (ddlCondition1.SelectedItem.Text == "Install Date") || (ddlCondition1.SelectedItem.Text == "Grout Date"))
            {
                // For dates before 1900
                if (cvForDate.IsValid)
                {
                    string[] date = (args.Value.Trim()).Split('/');
                    if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvForBoolean2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition2.SelectedItem.Text == "Bypass Required?") || (ddlCondition2.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition2.SelectedItem.Text == "Issue Identified?") || (ddlCondition2.SelectedItem.Text == "LFS Issue?") || (ddlCondition2.SelectedItem.Text == "Client Issue?") || (ddlCondition2.SelectedItem.Text == "Sales Issue?") || (ddlCondition2.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition2.SelectedItem.Text == "Issue Investigation?") || (ddlCondition2.SelectedItem.Text == "Issue Resolved?") || (ddlCondition2.SelectedItem.Text == "Extra Repair") || (ddlCondition1.SelectedItem.Text == "Cancelled"))
            {
                if ((args.Value.Trim().ToUpper() == "Y") || (args.Value.Trim().ToUpper() == "YES") || (args.Value.Trim().ToUpper() == "N") || (args.Value.Trim().ToUpper() == "NO") || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForNumberCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if ((ddlCondition2.SelectedItem.Text != "") && (ddlOperator2.SelectedValue != ""))
            {
                if ((ddlCondition2.SelectedItem.Text == "Laterals") || (ddlCondition2.SelectedItem.Text == "Live Laterals") || (ddlCondition2.SelectedItem.Text == "CXI's Removed") || (ddlCondition2.SelectedItem.Text == "Estimated Joints") || (ddlCondition2.SelectedItem.Text == "Joints Test Sealed") || (ddlCondition2.SelectedItem.Text == "Reinstates"))
                {
                    if ((tbxCondition2.Text != "") && (tbxCondition2.Text != "%"))
                    {
                        if (Validator.IsValidInt32(args.Value.Trim()))
                        {
                            args.IsValid = true;
                        }
                        else
                        {
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvForNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if ((ddlCondition1.SelectedItem.Text == "CXI's Removed") || (ddlCondition1.SelectedItem.Text == "Laterals") || (ddlCondition1.SelectedItem.Text == "Live Laterals") || (ddlCondition1.SelectedItem.Text == "Estimated Joints") || (ddlCondition1.SelectedItem.Text == "Joints Test Sealed") || (ddlCondition1.SelectedItem.Text == "Reinstates")) 
            {
                if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                {
                    if (Validator.IsValidInt32(args.Value.Trim()))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }



        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "Bypass Required?") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition1.SelectedItem.Text == "Issue Identified?") || (ddlCondition1.SelectedItem.Text == "LFS Issue?") || (ddlCondition1.SelectedItem.Text == "Client Issue?") || (ddlCondition1.SelectedItem.Text == "Sales Issue?") || (ddlCondition1.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition1.SelectedItem.Text == "Issue Investigation?") || (ddlCondition1.SelectedItem.Text == "Issue Resolved?") || (ddlCondition1.SelectedItem.Text == "Extra Repair") || (ddlCondition1.SelectedItem.Text == "Cancelled"))
            {
                if ((args.Value.Trim().ToUpper() == "Y") || (args.Value.Trim().ToUpper() == "YES") || (args.Value.Trim().ToUpper() == "N") || (args.Value.Trim().ToUpper() == "NO") || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void grdPrNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = prNavigatorTDS.PrNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                prNavigatorTDS.PrNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                grdPrNavigator.DataSource = prNavigatorTDS.PrNavigator.DefaultView;
                grdPrNavigator.DataBind();
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    prNavigatorTDS.PrNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                    grdPrNavigator.DataSource = prNavigatorTDS.PrNavigator.DefaultView;
                    grdPrNavigator.DataBind();
                }
                else
                {
                    prNavigatorTDS.PrNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                    grdPrNavigator.DataSource = prNavigatorTDS.PrNavigator.DefaultView;
                    grdPrNavigator.DataBind();
                }
            }
        }



        protected void btnViewDelete_Click(object sender, EventArgs e)
        {
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            if (!Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_DELETE"]))
            {
                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(viewId, companyId);
                string viewType = workViewGateway.GetType(viewId);

                if (viewType == "Global")
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
            }

            UpdateDatabaseForViews();

            // ... For view ddl
            string workType = hdfWorkType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);
            string viewTypeGlobal = "";
            string viewTypePersonal = "Personal";

            // Global Views check
            if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
            {
                viewTypeGlobal = "Global";
            }

            WorkViewList workViewList = new WorkViewList();
            workViewList.LoadAndAddItem(workType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
            ddlView.DataSource = workViewList.Table;
            ddlView.DataValueField = "ViewID";
            ddlView.DataTextField = "Name";
            ddlView.DataBind();
            ddlView.SelectedIndex = 1;

            WorkTypeViewSubAreaList workTypeViewSubAreaList = new WorkTypeViewSubAreaList();
            workTypeViewSubAreaList.LoadAndAddItem("Point Repairs", Int32.Parse(hdfCompanyId.Value), int.Parse(hdfCurrentProjectId.Value), "(All)");
            ddlSubArea.DataSource = workTypeViewSubAreaList.Table;
            ddlSubArea.DataValueField = "SubArea";
            ddlSubArea.DataTextField = "SubArea";
            ddlSubArea.DataBind();
        }


        



        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //
                        
        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=pr_navigator2.aspx&work_type=" + hdfWorkType.Value.Trim());
        }                



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabPr"] = "0";
                Session["dialogOpenedPr"] = "0";

                // Redirect
                string url = "./pr_summary.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + "&active_tab=0" + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabPr"] = "0";
                Session["dialogOpenedPr"] = "0";

                // Redirect
                string url = "./pr_edit.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + "&active_tab=0" + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnPreviewList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 40;
            int totalColumnsPreview = 39;
            string client = "";
            string name = "";
            string project = "";
            string title = "Point Repairs Search Results";

            // ... for client            
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadByCompaniesId(currentClientId, companyId);
            client += "Client: " + companiesGateway.GetName(currentClientId);

            // ... for project            
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            project = projectGateway.GetName(currentProjectId);
            name = client + " > Project: " + project + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

            // ... for title view
            if (hdfBtnOrigin.Value == "Go")
            {
                int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

                // ... Load name view
                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(viewId, companyId);

                title = workViewGateway.GetName(viewId);
            }

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdPrNavigator.Columns[2].Visible) headerValues += "ID (Section)";
            if (grdPrNavigator.Columns[3].Visible) headerValues += " * Sub Area";
            if (grdPrNavigator.Columns[4].Visible) headerValues += " * Street";
            if (grdPrNavigator.Columns[5].Visible) headerValues += " * USMH";
            if (grdPrNavigator.Columns[6].Visible) headerValues += " * USMH Address";
            if (grdPrNavigator.Columns[7].Visible) headerValues += " * DSMH";
            if (grdPrNavigator.Columns[8].Visible) headerValues += " * DSMH Address";
            if (grdPrNavigator.Columns[9].Visible) headerValues += " * Map Size";
            if (grdPrNavigator.Columns[10].Visible) headerValues += " * Confirmed Size";
            if (grdPrNavigator.Columns[11].Visible) headerValues += " * Map Length";
            if (grdPrNavigator.Columns[12].Visible) headerValues += " * Steel Tape Length";
            if (grdPrNavigator.Columns[13].Visible) headerValues += " * Video Length";
            if (grdPrNavigator.Columns[14].Visible) headerValues += " * Laterals";
            if (grdPrNavigator.Columns[15].Visible) headerValues += " * Live Laterals";
            if (grdPrNavigator.Columns[16].Visible) headerValues += " * Client ID";
            if (grdPrNavigator.Columns[17].Visible) headerValues += " * Measurements Taken By";
            if (grdPrNavigator.Columns[18].Visible) headerValues += " * Pre-Flush Date";
            if (grdPrNavigator.Columns[19].Visible) headerValues += " * Pre-Video Date";
            if (grdPrNavigator.Columns[20].Visible) headerValues += " * P1 Date";
            if (grdPrNavigator.Columns[21].Visible) headerValues += " * Repair Confirmation Date";
            if (grdPrNavigator.Columns[22].Visible) headerValues += " * Traffic Control";
            if (grdPrNavigator.Columns[23].Visible) headerValues += " * Material";
            if (grdPrNavigator.Columns[24].Visible) headerValues += " * Bypass Required?";
            if (grdPrNavigator.Columns[25].Visible) headerValues += " * Robotic Prep Required?";
            if (grdPrNavigator.Columns[26].Visible) headerValues += " * CXI&rsquo;s Removed";
            if (grdPrNavigator.Columns[27].Visible) headerValues += " * Robotic Distances";
            if (grdPrNavigator.Columns[28].Visible) headerValues += " * Proposed Lining Date";
            if (grdPrNavigator.Columns[29].Visible) headerValues += " * Deadline Lining Date";
            if (grdPrNavigator.Columns[30].Visible) headerValues += " * Final Video";
            if (grdPrNavigator.Columns[31].Visible) headerValues += " * Estimated Joints";
            if (grdPrNavigator.Columns[32].Visible) headerValues += " * Joints Test Sealed";
            if (grdPrNavigator.Columns[33].Visible) headerValues += " * Issue Identified?";
            if (grdPrNavigator.Columns[34].Visible) headerValues += " * LFS Issue?";
            if (grdPrNavigator.Columns[35].Visible) headerValues += " * Client Issue?";
            if (grdPrNavigator.Columns[36].Visible) headerValues += " * Sales Issue?";
            if (grdPrNavigator.Columns[37].Visible) headerValues += " * Issue Given To Client?";
            if (grdPrNavigator.Columns[38].Visible) headerValues += " * Issue Investigation?";
            if (grdPrNavigator.Columns[39].Visible) headerValues += " * Issue Resolved?";
            if (grdPrNavigator.Columns[41].Visible) headerValues += " * Repair";

            // Establishing columns to display
            string[] columns = headerValues.Split('*');
            string columnsForReport = "";
            int j;

            // ... for visible columns
            for (int i = 0; i < columns.Length; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=" + columns[i].Trim();
            }

            // ... For not visible columns
            for (int i = columns.Length; i < totalColumnsPreview; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=None";
            }

            if (grdPrNavigator.Columns[40].Visible) comments = "Comments";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./pr_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                   

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 40;
            int totalColumnsPreview = 39;
            string client = "";
            string name = "";
            string project = "";
            string title = "Point Repairs Search Results";
            string columnsForReport = "";
            int j;

            // ... for client            
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadByCompaniesId(currentClientId, companyId);
            client += "Client: " + companiesGateway.GetName(currentClientId);

            // ... for project            
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            project = projectGateway.GetName(currentProjectId);
            name = client + " > Project: " + project + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

            // ... for title view
            if (hdfBtnOrigin.Value == "Go")
            {
                int viewId = Int32.Parse(ddlView.SelectedValue.Trim());                

                // ... Load name view
                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(viewId, companyId);

                title = workViewGateway.GetName(viewId);
            }

            // ... For comments option
            string comments = "None";            

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdPrNavigator.Columns[2].Visible) headerValues += "ID (Section)";
            if (grdPrNavigator.Columns[3].Visible) headerValues += " * Sub Area";
            if (grdPrNavigator.Columns[4].Visible) headerValues += " * Street";
            if (grdPrNavigator.Columns[5].Visible) headerValues += " * USMH";
            if (grdPrNavigator.Columns[6].Visible) headerValues += " * USMH Address";
            if (grdPrNavigator.Columns[7].Visible) headerValues += " * DSMH";
            if (grdPrNavigator.Columns[8].Visible) headerValues += " * DSMH Address";
            if (grdPrNavigator.Columns[9].Visible) headerValues += " * Map Size";
            if (grdPrNavigator.Columns[10].Visible) headerValues += " * Confirmed Size";
            if (grdPrNavigator.Columns[11].Visible) headerValues += " * Map Length";
            if (grdPrNavigator.Columns[12].Visible) headerValues += " * Steel Tape Length";
            if (grdPrNavigator.Columns[13].Visible) headerValues += " * Video Length";
            if (grdPrNavigator.Columns[14].Visible) headerValues += " * Laterals";
            if (grdPrNavigator.Columns[15].Visible) headerValues += " * Live Laterals";
            if (grdPrNavigator.Columns[16].Visible) headerValues += " * Client ID";
            if (grdPrNavigator.Columns[17].Visible) headerValues += " * Measurements Taken By";
            if (grdPrNavigator.Columns[18].Visible) headerValues += " * Pre-Flush Date";
            if (grdPrNavigator.Columns[19].Visible) headerValues += " * Pre-Video Date";
            if (grdPrNavigator.Columns[20].Visible) headerValues += " * P1 Date";
            if (grdPrNavigator.Columns[21].Visible) headerValues += " * Repair Confirmation Date";
            if (grdPrNavigator.Columns[22].Visible) headerValues += " * Traffic Control";
            if (grdPrNavigator.Columns[23].Visible) headerValues += " * Material";
            if (grdPrNavigator.Columns[24].Visible) headerValues += " * Bypass Required?";
            if (grdPrNavigator.Columns[25].Visible) headerValues += " * Robotic Prep Required?";
            if (grdPrNavigator.Columns[26].Visible) headerValues += " * CXI&rsquo;s Removed";
            if (grdPrNavigator.Columns[27].Visible) headerValues += " * Robotic Distances";
            if (grdPrNavigator.Columns[28].Visible) headerValues += " * Proposed Lining Date";
            if (grdPrNavigator.Columns[29].Visible) headerValues += " * Deadline Lining Date";
            if (grdPrNavigator.Columns[30].Visible) headerValues += " * Final Video";
            if (grdPrNavigator.Columns[31].Visible) headerValues += " * Estimated Joints";
            if (grdPrNavigator.Columns[32].Visible) headerValues += " * Joints Test Sealed";
            if (grdPrNavigator.Columns[33].Visible) headerValues += " * Issue Identified?";
            if (grdPrNavigator.Columns[34].Visible) headerValues += " * LFS Issue?";
            if (grdPrNavigator.Columns[35].Visible) headerValues += " * Client Issue?";
            if (grdPrNavigator.Columns[36].Visible) headerValues += " * Sales Issue?";
            if (grdPrNavigator.Columns[37].Visible) headerValues += " * Issue Given To Client?";
            if (grdPrNavigator.Columns[38].Visible) headerValues += " * Issue Investigation?";
            if (grdPrNavigator.Columns[39].Visible) headerValues += " * Issue Resolved?";
            if (grdPrNavigator.Columns[40].Visible) headerValues += " * Comments";
            if (grdPrNavigator.Columns[41].Visible) headerValues += " * Repair";

            // Establishing columns to display
            string[] columnsExcel = headerValues.Split('*');

            // ... for visible columns
            for (int i = 0; i < columnsExcel.Length; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=" + columnsExcel[i].Trim();
            }

            // ... For not visible columns
            for (int i = columnsExcel.Length; i < totalColumnsExport; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=None";
            }

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./pr_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();

            PostPageChanges();

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabPr"] = "0";
                Session["dialogOpenedPr"] = "0";

                // Redirect
                string url = "./pr_delete.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./pr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mPointRepairsPlan":
                    string url = "./pr_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
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
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfWorkTypeId = '" + hdfWorkType.ClientID + "';";
            contentVariables += "var ddlViewId = '" + ddlView.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./pr_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition 1
            // Columns To Display
            string columnsToDisplay = Request.QueryString["columns_to_display"];
            string columnsToDisplay2 = Request.QueryString["columns_to_display2"];

            // Search condition
            // ... For Condition 1
            odsViewForDisplayList.DataBind();
            ddlCondition1.DataSourceID = "odsViewForDisplayList";
            ddlCondition1.DataValueField = "ConditionID";
            ddlCondition1.DataTextField = "Name";
            ddlCondition1.DataBind();
            ddlCondition1.SelectedValue = Request.QueryString["search_ddlCondition1"];
            tbxCondition1.Text = Request.QueryString["search_tbxCondition1"];
            ddlOperator1.SelectedValue = Request.QueryString["search_ddlOperator1"];

            // ... For Condition 2
            odsViewForDisplayList2.DataBind();
            ddlCondition2.DataSourceID = "odsViewForDisplayList2";
            ddlCondition2.DataValueField = "ConditionID";
            ddlCondition2.DataTextField = "Name";
            ddlCondition2.DataBind();
            ddlCondition2.SelectedValue = Request.QueryString["search_ddlCondition2"];
            tbxCondition2.Text = Request.QueryString["search_tbxCondition2"];
            ddlOperator2.SelectedValue = Request.QueryString["search_ddlOperator2"];

            // ... For View 
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);
            string viewTypeGlobal = "";
            string viewTypePersonal = "Personal";

            // Global Views check
            if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
            {
                viewTypeGlobal = "Global";
            }

            WorkViewList workViewList = new WorkViewList();
            workViewList.LoadAndAddItem(workType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
            ddlView.DataSource = workViewList.Table;
            ddlView.DataValueField = "ViewID";
            ddlView.DataTextField = "Name";
            ddlView.DataBind();
            ddlView.SelectedValue = Request.QueryString["search_ddlView"];

            //Other values
            //... For SortBy
            odsSortByList.DataBind();
            ddlSortBy.DataSourceID = "odsSortByList";
            ddlSortBy.DataValueField = "SortID";
            ddlSortBy.DataTextField = "Name";
            ddlSortBy.DataBind();
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            // ... For BtnOrigin
            hdfBtnOrigin.Value = Request.QueryString["btn_origin"];

            cbxIdSection.Checked = (columnsToDisplay2.IndexOf("FlowOrderID") >= 0 ? true : false);
            cbxIdRepair.Checked = (columnsToDisplay2.IndexOf("RepairPointID") >= 0 ? true : false);
            cbxSubArea.Checked = (columnsToDisplay2.IndexOf("SubArea") >= 0 ? true : false);
            cbxStreet.Checked = (columnsToDisplay2.IndexOf("Street") >= 0 ? true : false);
            cbxUsmh.Checked = (columnsToDisplay2.IndexOf(" USMH,") >= 0 ? true : false);
            cbxUsmhAddress.Checked = (columnsToDisplay2.IndexOf("USMHAddress") >= 0 ? true : false);
            cbxDsmh.Checked = (columnsToDisplay2.IndexOf(" DSMH") >= 0 ? true : false);
            cbxDsmhAddress.Checked = (columnsToDisplay2.IndexOf("DSMHAddress") >= 0 ? true : false);
            cbxMapSize.Checked = (columnsToDisplay2.IndexOf("MapSize") >= 0 ? true : false);
            cbxConfirmedSize.Checked = (columnsToDisplay2.IndexOf("Size_") >= 0 ? true : false);
            cbxMapLength.Checked = (columnsToDisplay2.IndexOf("MapLength") >= 0 ? true : false);
            cbxSteelTapeLength.Checked = (columnsToDisplay2.IndexOf("Length") >= 0 ? true : false);
            cbxVideoLength.Checked = (columnsToDisplay2.IndexOf("VideoLength") >= 0 ? true : false);
            cbxLaterals.Checked = (columnsToDisplay2.IndexOf("Laterals") >= 0 ? true : false);
            cbxLiveLaterals.Checked = (columnsToDisplay2.IndexOf("LiveLaterals") >= 0 ? true : false);
            cbxClientId.Checked = (columnsToDisplay2.IndexOf("ClientID") >= 0 ? true : false);
            cbxMeasurementsTakenBy.Checked = (columnsToDisplay2.IndexOf("MeasurementTakenBy") >= 0 ? true : false);
            cbxPreFlushDate.Checked = (columnsToDisplay2.IndexOf("PreFlushDate") >= 0 ? true : false);
            cbxPreVideoDate.Checked = (columnsToDisplay2.IndexOf("PreVideoDate") >= 0 ? true : false);
            cbxP1Date.Checked = (columnsToDisplay2.IndexOf("P1Date") >= 0 ? true : false);
            cbxRepairConfirmationDate.Checked = (columnsToDisplay2.IndexOf("RepairConfirmationDate") >= 0 ? true : false);
            cbxTrafficControl.Checked = (columnsToDisplay2.IndexOf("TrafficControl") >= 0 ? true : false);
            cbxMaterial.Checked = (columnsToDisplay2.IndexOf("MaterialType") >= 0 ? true : false);
            cbxBypassRequired.Checked = (columnsToDisplay2.IndexOf("BypassRequired") >= 0 ? true : false);
            cbxRoboticPrepRequired.Checked = (columnsToDisplay2.IndexOf("RoboticPrepRequired") >= 0 ? true : false);
            cbxCXIsRemoved.Checked = (columnsToDisplay2.IndexOf("CXIsRemoved") >= 0 ? true : false);
            cbxRoboticDistances.Checked = (columnsToDisplay2.IndexOf("RoboticDistances") >= 0 ? true : false);
            cbxProposedLiningDate.Checked = (columnsToDisplay2.IndexOf("ProposedLiningDate") >= 0 ? true : false);
            cbxDeadlineLiningDate.Checked = (columnsToDisplay2.IndexOf("DeadlineLiningDate") >= 0 ? true : false);
            cbxGroutDate.Checked = (columnsToDisplay2.IndexOf("GroutDate") >= 0 ? true : false);
            cbxFinalVideo.Checked = (columnsToDisplay2.IndexOf("FinalVideoDate") >= 0 ? true : false);
            cbxEstimatedJoints.Checked = (columnsToDisplay2.IndexOf("EstimatedJoints") >= 0 ? true : false);
            cbxJointsTestSealed.Checked = (columnsToDisplay2.IndexOf("JointsTestSealed") >= 0 ? true : false);
            cbxIssueIdentified.Checked = (columnsToDisplay2.IndexOf("IssueIdentified") >= 0 ? true : false);
            cbxLFSIssue.Checked = (columnsToDisplay2.IndexOf("IssueLFS") >= 0 ? true : false);
            cbxClientIssue.Checked = (columnsToDisplay2.IndexOf("IssueClient") >= 0 ? true : false);
            cbxSalesIssue.Checked = (columnsToDisplay2.IndexOf("IssueSales") >= 0 ? true : false);
            cbxIssueGivenToClient.Checked = (columnsToDisplay2.IndexOf("IssueGivenToClient") >= 0 ? true : false);
            cbxIssueInvestigation.Checked = (columnsToDisplay2.IndexOf("IssueInvestigation") >= 0 ? true : false);
            cbxIssueResolved.Checked = (columnsToDisplay2.IndexOf("IssueResolved") >= 0 ? true : false);
            cbxComments.Checked = (columnsToDisplay2.IndexOf("Comments") >= 0 ? true : false);
            cbxRepairType.Checked = (columnsToDisplay2.IndexOf("Type") >= 0 ? true : false);
            cbxDefectQualifier.Checked = (columnsToDisplay2.IndexOf("DefectQualifier") >= 0 ? true : false);
            cbxDefectDetails.Checked = (columnsToDisplay2.IndexOf("DefectDetails") >= 0 ? true : false);
            cbxExtraRepair.Checked = (columnsToDisplay2.IndexOf("ExtraRepair") >= 0 ? true : false);
            cbxCancelled.Checked = (columnsToDisplay2.IndexOf("Cancelled") >= 0 ? true : false);
            cbxApproval.Checked = (columnsToDisplay2.IndexOf("Approval") >= 0 ? true : false);
            cbxRepairComments.Checked = (columnsToDisplay2.IndexOf("Comments") >= 0 ? true : false);
            cbxReamDistance.Checked = (columnsToDisplay2.IndexOf("ReamDistance") >= 0 ? true : false);
            cbxReamDate.Checked = (columnsToDisplay2.IndexOf("ReamDate") >= 0 ? true : false);
            cbxLinerDistance.Checked = (columnsToDisplay2.IndexOf("LinerDistance") >= 0 ? true : false);
            cbxDirection.Checked = (columnsToDisplay2.IndexOf("Direction") >= 0 ? true : false);
            cbxReinstates.Checked = (columnsToDisplay2.IndexOf("Reinstates") >= 0 ? true : false);
            cbxLtMh.Checked = (columnsToDisplay2.IndexOf("LTMH") >= 0 ? true : false);
            cbxVtMh.Checked = (columnsToDisplay2.IndexOf("VTMH") >= 0 ? true : false);
            cbxDistance.Checked = (columnsToDisplay2.IndexOf("Distance") >= 0 ? true : false);
            cbxRepairSize.Checked = (columnsToDisplay2.IndexOf("Size_") >= 0 ? true : false);
            cbxRepairLength.Checked = (columnsToDisplay2.IndexOf("Length") >= 0 ? true : false);
            cbxInstallDate.Checked = (columnsToDisplay2.IndexOf("InstallDate") >= 0 ? true : false);
            cbxMhShot.Checked = (columnsToDisplay2.IndexOf("MHShot") >= 0 ? true : false);
            cbxGroutDistance.Checked = (columnsToDisplay2.IndexOf("GroutDistance") >= 0 ? true : false);

            // Grid's columns
            grdPrNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("FlowOrderID") >= 0 ? true : false);
            grdPrNavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("SubArea") >= 0 ? true : false);
            grdPrNavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("Street") >= 0 ? true : false);
            grdPrNavigator.Columns[5].Visible = (columnsToDisplay.IndexOf(" USMH,") >= 0 ? true : false);
            grdPrNavigator.Columns[6].Visible = (columnsToDisplay.IndexOf("USMHAddress") >= 0 ? true : false);
            grdPrNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf(" DSMH") >= 0 ? true : false);
            grdPrNavigator.Columns[8].Visible = (columnsToDisplay.IndexOf("DSMHAddress") >= 0 ? true : false);
            grdPrNavigator.Columns[9].Visible = (columnsToDisplay.IndexOf("MapSize") >= 0 ? true : false);
            grdPrNavigator.Columns[10].Visible = (columnsToDisplay.IndexOf("Size_") >= 0 ? true : false);
            grdPrNavigator.Columns[11].Visible = (columnsToDisplay.IndexOf("MapLength") >= 0 ? true : false);
            grdPrNavigator.Columns[12].Visible = (columnsToDisplay.IndexOf("Length") >= 0 ? true : false);
            grdPrNavigator.Columns[13].Visible = (columnsToDisplay.IndexOf("VideoLength") >= 0 ? true : false);
            grdPrNavigator.Columns[14].Visible = (columnsToDisplay.IndexOf("Laterals") >= 0 ? true : false);
            grdPrNavigator.Columns[15].Visible = (columnsToDisplay.IndexOf("LiveLaterals") >= 0 ? true : false);
            grdPrNavigator.Columns[16].Visible = (columnsToDisplay.IndexOf("ClientID") >= 0 ? true : false);
            grdPrNavigator.Columns[17].Visible = (columnsToDisplay.IndexOf("MeasurementTakenBy") >= 0 ? true : false);
            grdPrNavigator.Columns[18].Visible = (columnsToDisplay.IndexOf("PreFlushDate") >= 0 ? true : false);
            grdPrNavigator.Columns[19].Visible = (columnsToDisplay.IndexOf("PreVideoDate") >= 0 ? true : false);
            grdPrNavigator.Columns[20].Visible = (columnsToDisplay.IndexOf("P1Date") >= 0 ? true : false);
            grdPrNavigator.Columns[21].Visible = (columnsToDisplay.IndexOf("RepairConfirmationDate") >= 0 ? true : false);
            grdPrNavigator.Columns[22].Visible = (columnsToDisplay.IndexOf("TrafficControl") >= 0 ? true : false);
            grdPrNavigator.Columns[23].Visible = (columnsToDisplay.IndexOf("MaterialType") >= 0 ? true : false);
            grdPrNavigator.Columns[24].Visible = (columnsToDisplay.IndexOf("BypassRequired") >= 0 ? true : false);
            grdPrNavigator.Columns[25].Visible = (columnsToDisplay.IndexOf("RoboticPrepRequired") >= 0 ? true : false);
            grdPrNavigator.Columns[26].Visible = (columnsToDisplay.IndexOf("CXIsRemoved") >= 0 ? true : false);
            grdPrNavigator.Columns[27].Visible = (columnsToDisplay.IndexOf("RoboticDistances") >= 0 ? true : false);
            grdPrNavigator.Columns[28].Visible = (columnsToDisplay.IndexOf("ProposedLiningDate") >= 0 ? true : false);
            grdPrNavigator.Columns[29].Visible = (columnsToDisplay.IndexOf("DeadlineLiningDate") >= 0 ? true : false);
            grdPrNavigator.Columns[30].Visible = (columnsToDisplay.IndexOf("FinalVideoDate") >= 0 ? true : false);
            grdPrNavigator.Columns[31].Visible = (columnsToDisplay.IndexOf("EstimatedJoints") >= 0 ? true : false);
            grdPrNavigator.Columns[32].Visible = (columnsToDisplay.IndexOf("JointsTestSealed") >= 0 ? true : false);
            grdPrNavigator.Columns[33].Visible = (columnsToDisplay.IndexOf("IssueIdentified") >= 0 ? true : false);
            grdPrNavigator.Columns[34].Visible = (columnsToDisplay.IndexOf("IssueLFS") >= 0 ? true : false);
            grdPrNavigator.Columns[35].Visible = (columnsToDisplay.IndexOf("IssueClient") >= 0 ? true : false);
            grdPrNavigator.Columns[36].Visible = (columnsToDisplay.IndexOf("IssueSales") >= 0 ? true : false);
            grdPrNavigator.Columns[37].Visible = (columnsToDisplay.IndexOf("IssueGivenToClient") >= 0 ? true : false);
            grdPrNavigator.Columns[38].Visible = (columnsToDisplay.IndexOf("IssueInvestigation") >= 0 ? true : false);
            grdPrNavigator.Columns[39].Visible = (columnsToDisplay.IndexOf("IssueResolved") >= 0 ? true : false);
            grdPrNavigator.Columns[40].Visible = (columnsToDisplay.IndexOf("Comments") >= 0 ? true : false);
            grdPrNavigator.Columns[41].Visible = false;
            grdPrNavigator.Columns[41].Visible = (columnsToDisplay.IndexOf("RepairPointID") >= 0 ? true : false);

            // Special case for repairs
            // For condition 1
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            string name = workTypeViewConditionGateway.GetName(workType, companyId, int.Parse(ddlCondition1.SelectedValue));
            string conditionValue1 = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));

            if ((conditionValue1 == "RepairPointID") || (conditionValue1 == "Type") || (conditionValue1 == "DefectQualifier") || (conditionValue1 == "DefectDetails") || (conditionValue1 == "ExtraRepair") || (conditionValue1 == "Cancelled") || (conditionValue1 == "Approval") || (conditionValue1 == "Comments" && name == "Repair Comments") || (conditionValue1 == "ReamDistance") || (conditionValue1 == "ReamDate") || (conditionValue1 == "LinerDistance") || (conditionValue1 == "Direction") || (conditionValue1 == "Reinstates") || (conditionValue1 == "LTMH") || (conditionValue1 == "VTMH") || (conditionValue1 == "Distance") || (conditionValue1 == "Size_" && name == "Repair Size") || (conditionValue1 == "Length" && name == "Repair Length") || (conditionValue1 == "InstallDate") || (conditionValue1 == "MHShot") || (conditionValue1 == "GroutDistance") || (conditionValue1 == "GroutDate"))
            {
                grdPrNavigator.Columns[41].Visible = true;
            }                      

            if (ddlCondition2.SelectedValue != "-1")
            {
                WorkTypeViewConditionGateway workTypeViewConditionGateway2 = new WorkTypeViewConditionGateway();
                workTypeViewConditionGateway2.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition2.SelectedValue), companyId);

                string name2 = workTypeViewConditionGateway2.GetName(workType, companyId, int.Parse(ddlCondition2.SelectedValue));              
                string conditionValue2 = workTypeViewConditionGateway2.GetColumn_(workType, companyId, int.Parse(ddlCondition2.SelectedValue));
                if ((conditionValue2 == "RepairPointID") || (conditionValue2 == "Type") || (conditionValue2 == "DefectQualifier") || (conditionValue2 == "DefectDetails") || (conditionValue2 == "ExtraRepair") || (conditionValue2 == "Cancelled") || (conditionValue2 == "Approval") || (conditionValue2 == "Comments" && name == "Repair Comments") || (conditionValue2 == "ReamDistance") || (conditionValue2 == "ReamDate") || (conditionValue2 == "LinerDistance") || (conditionValue2 == "Direction") || (conditionValue2 == "Reinstates") || (conditionValue2 == "LTMH") || (conditionValue2 == "VTMH") || (conditionValue2 == "Distance") || (conditionValue2 == "Size_" && name == "Repair Size") || (conditionValue2 == "Length" && name == "Repair Length") || (conditionValue2 == "InstallDate") || (conditionValue2 == "MHShot") || (conditionValue2 == "GroutDistance") || (conditionValue2 == "GroutDate"))
                {
                    grdPrNavigator.Columns[41].Visible = true;
                }
            }
        }



        private string GetNavigatorState()
        {
            // Columns to display
            string columnsToDisplay = "";
            columnsToDisplay = columnsToDisplay + GetColumnsToDisplay();

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=" + ddlCondition1.SelectedValue;
            searchOptions = searchOptions + "&search_ddlOperator1=" + ddlOperator1.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition1=" + tbxCondition1.Text.Trim();

            // SearchOptions for condition 2
            searchOptions = searchOptions + "&search_ddlCondition2=" + ddlCondition2.SelectedValue;
            searchOptions = searchOptions + "&search_ddlOperator2=" + ddlOperator2.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition2=" + tbxCondition2.Text.Trim();

            // For Views
            searchOptions = searchOptions + "&search_ddlView=" + ddlView.SelectedValue;

            // Other values
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&search_sub_area=" + ddlSubArea.SelectedValue;
            searchOptions = searchOptions + "&btn_origin=" + hdfBtnOrigin.Value;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private PrNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string workType = hdfWorkType.Value.Trim();
            string conditionValue1 = "";
            string conditionValue2 = "";  
            string name = "";

            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());            

            // ... Load data for condition 1
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            name = workTypeViewConditionGateway.GetName(workType, companyId, int.Parse(ddlCondition1.SelectedValue));
            conditionValue1 = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));

            // ... If condition 2 exists
            if (ddlCondition2.SelectedValue != "-1")
            {
                // ... Load data for condition 2
                WorkTypeViewConditionGateway workTypeViewConditionGateway2 = new WorkTypeViewConditionGateway();
                workTypeViewConditionGateway2.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition2.SelectedValue), companyId);
                conditionValue2 = workTypeViewConditionGateway2.GetColumn_(workType, companyId, int.Parse(ddlCondition2.SelectedValue));
            }

            // ... Load data
            PrNavigator prNavigator = new PrNavigator();
            prNavigator.Load(whereClause, orderByClause, conditionValue1, tbxCondition1.Text.Trim(), conditionValue2, tbxCondition2.Text.Trim(), companyId, currentProjectId, workType, name);

            return (PrNavigatorTDS)prNavigator.Data;
        }



        private PrNavigatorTDS SubmitSearchForViews()
        {
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

            PrNavigator prNavigator = new PrNavigator();
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());

            // ... Load SqlCommand
            WorkViewGateway workViewGateway = new WorkViewGateway();
            workViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = workViewGateway.GetSqlCommand(viewId);

            // ... Load data
            prNavigator.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, currentProjectId, companyId, workType);

            return (PrNavigatorTDS)prNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LW.Deleted = 0) AND (LW.COMPANY_ID = " + companyId + ") AND (LWPR.Deleted = 0) AND (LWPR.COMPANY_ID = " + companyId + ") AND (AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ")";
            whereClause = whereClause + "AND (LW.ProjectID = " + hdfCurrentProjectId.Value + ")AND (LW.WorkType='" + hdfWorkType.Value + "') ";

            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim(), ddlOperator1.SelectedValue);

            // ... Condition 2
            if (ddlCondition2.SelectedValue != "-1")
            {
                whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition2.SelectedValue), tbxCondition2.Text.Trim(), ddlOperator2.SelectedValue);
            }

            // Sub Area condition
            if (ddlSubArea.SelectedValue != "(All)")
            {
                if (ddlSubArea.SelectedValue != "")
                {
                    whereClause = whereClause + " AND (LASS.SubArea = '" + ddlSubArea.SelectedValue.ToString() + "') ";
                }
                else
                {
                    whereClause = whereClause + " AND (LASS.SubArea = '' OR LASS.SubArea IS NULL) ";
                }
            }
            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch, string operatorValue)
        {
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, conditionId, companyId);

            string name = workTypeViewConditionGateway.GetName(workType, companyId, conditionId);
            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, conditionId);
            string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, conditionId);

            if (tableName == "AM_ASSET_SEWER_MATERIAL") tableName = "AASM";
            if (tableName == "AM_ASSET_SEWER_MH") tableName = "AASMH";
            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK") tableName = "LW";
            if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWFLL";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M1") tableName = "LWFLLM1";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M2") tableName = "LWFLLM2";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_P1") tableName = "LWFLP1";
            if (tableName == "LFS_WORK_POINT_REPAIRS") tableName = "LWPR";
            if (tableName == "LFS_WORK_POINT_REPAIRS_REPAIR") tableName = "LWPRR";
            if (tableName == "LFS_WORK_REHABASSESSMENT") tableName = "LWRA";

            if (((conditionValue == "USMH") || (conditionValue == "DSMH") || (conditionValue == "CXIsRemoved") || (conditionValue == "USMHAddress") || (conditionValue == "DSMHAddress") || (conditionValue == "VideoLength") || (conditionValue == "TrafficControl") || (conditionValue == "MaterialType") || (conditionValue == "RoboticPrepRequired")) && (textForSearch == "%"))
            {
                whereClause = whereClause + " AND (( AASS.AssetID LIKE '%')";
                whereClause = whereClause + " OR (  AASS.AssetID IS NULL))";
            }

            // FOR TEXT FIELDS. (Id(Section), SubArea, Street, Comments, MapSize, Size_, MapLength, Length, ClientID, MeasurementTakenBy, RoboticDistances, RepairPointID, Type, DefectQualifier, DefectDetails, Approval, ReamDistance, LinerDistance, Direction, LTMH, VTMH, Distance, MHShot, GroutDistance, Repair Comments, Repair Size, Repair Length )
            if ((conditionValue == "FlowOrderID") || (conditionValue == "SubArea") || (conditionValue == "Street") || (conditionValue == "Comments" && name == "Comments") || (conditionValue == "MapSize") || (conditionValue == "Size_" && name == "Confirmed Size") || (conditionValue == "MapLength") || (conditionValue == "Length" && name == "Steel Tape Length") || (conditionValue == "ClientID") || (conditionValue == "MeasurementTakenBy") || (conditionValue == "RoboticDistances") || (conditionValue == "RepairPointID") || (conditionValue == "Type") || (conditionValue == "DefectQualifier") || (conditionValue == "DefectDetails") || (conditionValue == "Approval") || (conditionValue == "ReamDistance") || (conditionValue == "LinerDistance") || (conditionValue == "Direction") || (conditionValue == "LTMH") || (conditionValue == "VTMH") || (conditionValue == "Distance") || (conditionValue == "MHShot") || (conditionValue == "GroutDistance") || (conditionValue == "Comments" && name == "Repair Comments") || (conditionValue == "Size_" && name == "Repair Size") || (conditionValue == "Length" && name == "Repair Length"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    // Search
                    if (textForSearch == "%")
                    {
                        whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                        whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                    }
                    else
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                        }
                        else
                        {
                            if (textForSearch.Contains("\""))
                            {
                                if (conditionValue == "Comments")
                                {
                                    textForSearch = textForSearch.Replace("'", "''");
                                    whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                                }
                                else
                                {
                                    textForSearch = textForSearch.Replace("\"", "");
                                    whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " = '" + textForSearch + "')";
                                }
                            }
                            else
                            {
                                textForSearch = textForSearch.Replace("'", "''");
                                whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                            }
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NOT NULL))";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL)";
                            }
                            else
                            {
                                if (textForSearch.Contains("\""))
                                {
                                    if (conditionValue == "Comments")
                                    {
                                        textForSearch = textForSearch.Replace("'", "''");
                                        whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " NOT LIKE '%" + textForSearch + "%')";
                                        whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                                    }
                                    else
                                    {
                                        textForSearch = textForSearch.Replace("\"", "");
                                        whereClause = whereClause + "AND ((" + tableName + "." + conditionValue + " <> '" + textForSearch + "')";
                                        whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                                    }
                                }
                                else
                                {
                                    textForSearch = textForSearch.Replace("'", "''");
                                    whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " NOT LIKE '%" + textForSearch + "%')";
                                    whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (((conditionValue == "USMH") || (conditionValue == "DSMH")) && (textForSearch == "%"))
                {
                    whereClause = whereClause + " AND (( AASS.AssetID LIKE '%')";
                    whereClause = whereClause + " OR (  AASS.AssetID IS NULL))";
                }
            }

            // FOR DATE FIELDS. (ProposedLiningDate, DeadlineLiningDate, FinalVideoDate, RepairConfirmationDate, ReamDate, InstallDate, GroutDate)
            if ((conditionValue == "ProposedLiningDate") || (conditionValue == "DeadlineLiningDate") || (conditionValue == "FinalVideoDate") || (conditionValue == "RepairConfirmationDate") || (conditionValue == "ReamDate") || (conditionValue == "InstallDate") || (conditionValue == "GroutDate"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    // ... Search
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + "  AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL)";
                    }
                    else
                    {
                        if (textForSearch == "%")
                        {
                            whereClause = whereClause + " AND ((CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NOT NULL) OR ";
                            whereClause = whereClause + "(CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                        }
                        else
                        {
                            if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                            {
                                whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) = '" + textForSearch + "')";
                            }
                            else
                            {
                                whereClause = whereClause + " AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) LIKE '%" + textForSearch + "%')";
                            }
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        // ... Search
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + "  AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NOT NULL)";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + "  AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL)";
                            }
                            else
                            {
                                if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                                {
                                    whereClause = whereClause + " AND ((CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) != '" + textForSearch + "')";
                                    whereClause = whereClause + " OR (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                                }
                                else
                                {
                                    whereClause = whereClause + " AND ((CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) NOT LIKE '%" + textForSearch + "%')";
                                    whereClause = whereClause + " OR (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                                }
                            }
                        }
                    }
                    else
                    {
                        // ... For other operators

                        // ... Determine the operator
                        string whereOperator = "";
                        if (operatorValue == "'>='")
                        {
                            whereOperator = ">=";
                        }
                        else
                        {
                            if (operatorValue == "'<='")
                            {
                                whereOperator = "<=";
                            }
                            else
                            {
                                whereOperator = operatorValue;
                            }
                        }

                        // ... Determine the where clause
                        if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                        {
                            whereClause = whereClause + " AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime)" + whereOperator + " '" + textForSearch + "')";
                        }
                        else
                        {
                            if (operatorValue == ">" || operatorValue == "'<='")
                            {
                                whereClause = whereClause + " AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime)" + whereOperator + " '12/31/" + textForSearch + "')";
                            }
                            else
                            {
                                whereClause = whereClause + " AND (CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime)" + whereOperator + " '" + textForSearch + "')";
                            }
                        }
                    }
                }
            }

            // ... FOR INTEGER AND DOUBLE FIELDS. (Laterals, LiveLaterals, EstimatedJoints, JointsTestSealed, Reinstates)
            if ((conditionValue == "Laterals") || (conditionValue == "LiveLaterals") || (conditionValue == "EstimatedJoints") || (conditionValue == "JointsTestSealed") || (conditionValue == "Reinstates"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                    }
                    else
                    {
                        if (textForSearch == "%")
                        {
                            whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                        }
                        else
                        {
                            whereClause = whereClause + " AND (" + tableName + "." + conditionValue + operatorValue + textForSearch + ")";
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch == "")
                        {
                            whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NOT NULL))";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                            }
                            else
                            {
                                whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + operatorValue + textForSearch + ")";
                                whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                            }
                        }
                    }
                    else
                    {
                        // ... For other operators

                        // ... Determine the operator
                        string whereOperator = "";
                        if (operatorValue == "'>='")
                        {
                            whereOperator = ">=";
                        }
                        else
                        {
                            if (operatorValue == "'<='")
                            {
                                whereOperator = "<=";
                            }
                            else
                            {
                                whereOperator = operatorValue;
                            }
                        }

                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + whereOperator + textForSearch + ")";
                    }             
                }
            }

            // FOR BOOLEAN FIELDS (BypassRequired, IssueIdentified, IssueLFS, IssueClient, IssueSales, IssueGivenToClient, IssueInvestigation, IssueResolved, ExtraRepair, Cancelled)
            if ((conditionValue == "BypassRequired") || (conditionValue == "IssueIdentified") || (conditionValue == "IssueLFS") || (conditionValue == "IssueClient") || (conditionValue == "IssueSales") || (conditionValue == "IssueGivenToClient") || (conditionValue == "IssueInvestigation") || (conditionValue == "IssueResolved") || (conditionValue == "ExtraRepair") || (conditionValue == "Cancelled"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch != "")
                    {
                        if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                        {
                            whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " = 1)";
                        }
                        else
                        {
                            if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                            {
                                whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " = 0)";
                            }
                            else
                            {
                                if (textForSearch == "%")
                                {
                                    whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " = 1) OR (" + tableName + "." + conditionValue + " = 0))";
                                }
                            }
                        }
                    }
                }
                else
                {
                    // ... For operator <>
                    if (operatorValue == "<>")
                    {
                        if (textForSearch != "")
                        {
                            if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                            {
                                whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " = 0)";
                            }
                            else
                            {
                                if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                                {
                                    whereClause = whereClause + " AND(" + tableName + "." + conditionValue + " = 1)";
                                }
                                else
                                {
                                    if (textForSearch == "%")
                                    {
                                        whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " = 1) OR (" + tableName + "." + conditionValue + " = 0))";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return whereClause;
        }



        private string GetOrderByClause()
        {
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway();
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = workTypeViewSortGateway.GetColumn_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            string conditionValue1 = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK_POINT_REPAIRS") tableName = "LWPR";

            // Get order by clause
            string orderBy = "";

            if (columnName == "Date")
            {
                switch (conditionValue1)
                {
                    case "ProposedLiningDate":
                        orderBy = "LWPR.ProposedLiningDate DESC";
                        break;

                    case "DeadlineLiningDate":
                        orderBy = "LWPR.DeadlineLiningDate DESC";
                        break;

                    case "FinalVideoDate":
                        orderBy = "LWPR.FinalVideoDate DESC";
                        break;

                    default:
                        orderBy = "LWPR.WorkID ASC";
                        break;
                }
            }
            else
            {
                orderBy = tableName + "." + columnName;
            }

            return orderBy;
        }



        private void PostPageChanges()
        {
            PrNavigator prNavigator = new PrNavigator(prNavigatorTDS);

            // Update jlinernavigator rows
            foreach (GridViewRow row in grdPrNavigator.Rows)
            {
                string assetId_ = ((Label)row.FindControl("lblAssetId_")).Text.Trim();
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                prNavigator.Update(assetId_, selected);
            }

            prNavigator.Data.AcceptChanges();

            // Store datasets
            Session["prNavigatorTDS"] = prNavigatorTDS;
        }



        private int GetAssetId()
        {
            int assetId = 0;

            foreach (PrNavigatorTDS.PrNavigatorRow prNavigatorRow in prNavigatorTDS.PrNavigator)
            {
                if (prNavigatorRow.Selected)
                {
                    assetId = prNavigatorRow.AssetID;
                }
            }

            return assetId;
        }



        private void UpdateDatabaseForViews()
        {
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            DB.Open();
            DB.BeginTransaction();
            try
            {
                WorkView workView = new WorkView(null);
                workView.DeleteDirect(viewId, companyId);

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();
            string columnsToDisplay = "&columns_to_display=";                                    
            string columnsToDisplay2 = "&columns_to_display2=";

            columnsToDisplay2 = columnsToDisplay2 + (cbxIdSection.Checked ? "FlowOrderID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIdRepair.Checked ? "RepairPointID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSubArea.Checked ? "SubArea," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxStreet.Checked ? "Street," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUsmh.Checked ? " USMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUsmhAddress.Checked ? "USMHAddress," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDsmh.Checked ? " DSMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDsmhAddress.Checked ? "DSMHAddress," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMapSize.Checked ? "MapSize," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxConfirmedSize.Checked ? "Size_," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMapLength.Checked ? "MapLength," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSteelTapeLength.Checked ? "Length," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVideoLength.Checked ? "VideoLength," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLaterals.Checked ? "Laterals," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLiveLaterals.Checked ? "LiveLaterals," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxClientId.Checked ? "ClientID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMeasurementsTakenBy.Checked ? "MeasurementTakenBy," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPreFlushDate.Checked ? "PreFlushDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPreVideoDate.Checked ? "PreVideoDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxP1Date.Checked ? "P1Date," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRepairConfirmationDate.Checked ? "RepairConfirmationDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxTrafficControl.Checked ? "TrafficControl," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMaterial.Checked ? "MaterialType," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxBypassRequired.Checked ? "BypassRequired," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRoboticPrepRequired.Checked ? "RoboticPrepRequired," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCXIsRemoved.Checked ? "CXIsRemoved," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRoboticDistances.Checked ? "RoboticDistances," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxProposedLiningDate.Checked ? "ProposedLiningDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDeadlineLiningDate.Checked ? "DeadlineLiningDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxGroutDate.Checked ? "GroutDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxFinalVideo.Checked ? "FinalVideoDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxEstimatedJoints.Checked ? "EstimatedJoints," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxJointsTestSealed.Checked ? "JointsTestSealed," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueIdentified.Checked ? "IssueIdentified," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLFSIssue.Checked ? "IssueLFS," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxClientIssue.Checked ? "IssueClient," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSalesIssue.Checked ? "IssueSales," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueGivenToClient.Checked ? "IssueGivenToClient," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueInvestigation.Checked ? "IssueInvestigation," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueResolved.Checked ? "IssueResolved," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxComments.Checked ? "Comments," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRepairType.Checked ? "Type," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDefectQualifier.Checked ? "DefectQualifier," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDefectDetails.Checked ? "DefectDetails," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxExtraRepair.Checked ? "ExtraRepair," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCancelled.Checked ? "Cancelled," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxApproval.Checked ? "Approval," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRepairComments.Checked ? "Comments," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxReamDistance.Checked ? "ReamDistance," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxReamDate.Checked ? "ReamDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLinerDistance.Checked ? "LinerDistance," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDirection.Checked ? "Direction," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxReinstates.Checked ? "Reinstates," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLtMh.Checked ? "LTMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVtMh.Checked ? "VTMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDistance.Checked ? "Distance," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRepairSize.Checked ? "Size_," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRepairLength.Checked ? "Length," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxInstallDate.Checked ? "InstallDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMhShot.Checked ? "MHShot," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxGroutDistance.Checked ? "GroutDistance," : "");

            if (hdfBtnOrigin.Value == "Search")
            {
                columnsToDisplay = columnsToDisplay + (cbxIdSection.Checked ? "FlowOrderID," : "");
                columnsToDisplay = columnsToDisplay + (cbxIdRepair.Checked ? "RepairPointID," : "");
                columnsToDisplay = columnsToDisplay + (cbxSubArea.Checked ? "SubArea," : "");
                columnsToDisplay = columnsToDisplay + (cbxStreet.Checked ? "Street," : "");
                columnsToDisplay = columnsToDisplay + (cbxUsmh.Checked ? " USMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxUsmhAddress.Checked ? "USMHAddress," : "");
                columnsToDisplay = columnsToDisplay + (cbxDsmh.Checked ? " DSMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxDsmhAddress.Checked ? "DSMHAddress," : "");
                columnsToDisplay = columnsToDisplay + (cbxMapSize.Checked ? "MapSize," : "");
                columnsToDisplay = columnsToDisplay + (cbxConfirmedSize.Checked ? "Size_," : "");
                columnsToDisplay = columnsToDisplay + (cbxMapLength.Checked ? "MapLength," : "");
                columnsToDisplay = columnsToDisplay + (cbxSteelTapeLength.Checked ? "Length," : "");
                columnsToDisplay = columnsToDisplay + (cbxVideoLength.Checked ? "VideoLength," : "");
                columnsToDisplay = columnsToDisplay + (cbxLaterals.Checked ? "Laterals," : "");
                columnsToDisplay = columnsToDisplay + (cbxLiveLaterals.Checked ? "LiveLaterals," : "");
                columnsToDisplay = columnsToDisplay + (cbxClientId.Checked ? "ClientID," : "");
                columnsToDisplay = columnsToDisplay + (cbxMeasurementsTakenBy.Checked ? "MeasurementTakenBy," : "");
                columnsToDisplay = columnsToDisplay + (cbxPreFlushDate.Checked ? "PreFlushDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxPreVideoDate.Checked ? "PreVideoDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxP1Date.Checked ? "P1Date," : "");
                columnsToDisplay = columnsToDisplay + (cbxRepairConfirmationDate.Checked ? "RepairConfirmationDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxTrafficControl.Checked ? "TrafficControl," : "");
                columnsToDisplay = columnsToDisplay + (cbxMaterial.Checked ? "MaterialType," : "");
                columnsToDisplay = columnsToDisplay + (cbxBypassRequired.Checked ? "BypassRequired," : "");
                columnsToDisplay = columnsToDisplay + (cbxRoboticPrepRequired.Checked ? "RoboticPrepRequired," : "");
                columnsToDisplay = columnsToDisplay + (cbxCXIsRemoved.Checked ? "CXIsRemoved," : "");
                columnsToDisplay = columnsToDisplay + (cbxRoboticDistances.Checked ? "RoboticDistances," : "");
                columnsToDisplay = columnsToDisplay + (cbxProposedLiningDate.Checked ? "ProposedLiningDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxDeadlineLiningDate.Checked ? "DeadlineLiningDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxGroutDate.Checked ? "GroutDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxFinalVideo.Checked ? "FinalVideoDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxEstimatedJoints.Checked ? "EstimatedJoints," : "");
                columnsToDisplay = columnsToDisplay + (cbxJointsTestSealed.Checked ? "JointsTestSealed," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueIdentified.Checked ? "IssueIdentified," : "");
                columnsToDisplay = columnsToDisplay + (cbxLFSIssue.Checked ? "IssueLFS," : "");
                columnsToDisplay = columnsToDisplay + (cbxClientIssue.Checked ? "IssueClient," : "");
                columnsToDisplay = columnsToDisplay + (cbxSalesIssue.Checked ? "IssueSales," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueGivenToClient.Checked ? "IssueGivenToClient," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueInvestigation.Checked ? "IssueInvestigation," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueResolved.Checked ? "IssueResolved," : "");
                columnsToDisplay = columnsToDisplay + (cbxComments.Checked ? "Comments," : "");
                columnsToDisplay = columnsToDisplay + (cbxRepairType.Checked ? "Type," : "");
                columnsToDisplay = columnsToDisplay + (cbxDefectQualifier.Checked ? "DefectQualifier," : "");
                columnsToDisplay = columnsToDisplay + (cbxDefectDetails.Checked ? "DefectDetails," : "");
                columnsToDisplay = columnsToDisplay + (cbxExtraRepair.Checked ? "ExtraRepair," : "");
                columnsToDisplay = columnsToDisplay + (cbxCancelled.Checked ? "Cancelled," : "");
                columnsToDisplay = columnsToDisplay + (cbxApproval.Checked ? "Approval," : "");
                columnsToDisplay = columnsToDisplay + (cbxRepairComments.Checked ? "Comments," : "");
                columnsToDisplay = columnsToDisplay + (cbxReamDistance.Checked ? "ReamDistance," : "");
                columnsToDisplay = columnsToDisplay + (cbxReamDate.Checked ? "ReamDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxLinerDistance.Checked ? "LinerDistance," : "");
                columnsToDisplay = columnsToDisplay + (cbxDirection.Checked ? "Direction," : "");
                columnsToDisplay = columnsToDisplay + (cbxReinstates.Checked ? "Reinstates," : "");
                columnsToDisplay = columnsToDisplay + (cbxLtMh.Checked ? "LTMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxVtMh.Checked ? "VTMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxDistance.Checked ? "Distance," : "");
                columnsToDisplay = columnsToDisplay + (cbxRepairSize.Checked ? "Size_," : "");
                columnsToDisplay = columnsToDisplay + (cbxRepairLength.Checked ? "Length," : "");
                columnsToDisplay = columnsToDisplay + (cbxInstallDate.Checked ? "InstallDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxMhShot.Checked ? "MHShot," : "");
                columnsToDisplay = columnsToDisplay + (cbxGroutDistance.Checked ? "GroutDistance," : "");
            }
            else
            {
                if (hdfBtnOrigin.Value == "Go")
                {
                    int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
                    WorkViewDisplay workViewDisplay = new WorkViewDisplay();
                    columnsToDisplay = columnsToDisplay + workViewDisplay.GetColumnsToDisplayForViews(viewId, workType, companyId);
                }
            }

            return columnsToDisplay + columnsToDisplay2;
        }
               
        

    }
}