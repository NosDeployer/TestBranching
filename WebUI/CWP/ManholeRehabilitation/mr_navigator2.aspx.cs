using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_navigator2
    /// </summary>
    public partial class mr_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MrNavigatorTDS mrNavigatorTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["in_project"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_navigator2.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfInProject.Value = Request.QueryString["in_project"].ToString();
                hdfWorkType.Value = "Manhole Rehabilitation";

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

                // Validate top information
                if ((hdfCurrentClientId.Value != "0") && (hdfCurrentProjectId.Value != "0"))
                {
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
                }
                else
                {
                    lblTitleClientName.Text = "";
                    lblTitleProjectName.Text = "";
                }

                // If coming from 
                // ... mr_navigator.aspx or mr_navigator2.aspx
                if ((Request.QueryString["source_page"] == "mr_navigator.aspx") || (Request.QueryString["source_page"] == "mr_navigator2.aspx"))
                {
                    RestoreNavigatorState();

                    mrNavigatorTDS = (MrNavigatorTDS)Session["mrNavigatorTDS"];
                }

                // ... mr_edit.aspx, mr_summary.aspx or mr_delete.aspx
                if ((Request.QueryString["source_page"] == "mr_edit.aspx") || (Request.QueryString["source_page"] == "mr_summary.aspx") || (Request.QueryString["source_page"] == "mr_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        mrNavigatorTDS = (MrNavigatorTDS)Session["mrNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("mrNavigatorTDS");

                        // ... Search data with updates
                        if (hdfBtnOrigin.Value == "Search")
                        {
                            mrNavigatorTDS = SubmitSearch();
                        }
                        else
                        {
                            if (hdfBtnOrigin.Value == "Go")
                            {
                                mrNavigatorTDS = SubmitSearchForViews();
                            }
                        }

                        // ... store datasets
                        Session["mrNavigatorTDS"] = mrNavigatorTDS;
                    }
                }

                // ... mr_delete.aspx, mr_summary.aspx or mr_edit.aspx
                if ((Request.QueryString["source_page"] == "mr_delete.aspx") || (Request.QueryString["source_page"] == "mr_summary.aspx") || (Request.QueryString["source_page"] == "mr_edit.aspx"))
                {
                    if (mrNavigatorTDS.MrNavigator.Rows.Count == 0)
                    {
                        string url = "./mr_navigator.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                // For the grid
                grdMRNavigator.DataSource = mrNavigatorTDS.MrNavigator;
                grdMRNavigator.DataBind();

                //... for the total rows
                if (mrNavigatorTDS.MrNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + mrNavigatorTDS.MrNavigator.Rows.Count;
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
                mrNavigatorTDS = (MrNavigatorTDS)Session["mrNavigatorTDS"];

                // ... for the total rows
                if (mrNavigatorTDS.MrNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + mrNavigatorTDS.MrNavigator.Rows.Count;
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
                Session.Contents.Remove("mrNavigatorTDS");

                // Get data from DA gateway
                mrNavigatorTDS = SubmitSearch();

                // Show results
                if (mrNavigatorTDS.MrNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["mrNavigatorTDS"] = mrNavigatorTDS;

                    // ... Go to the results page
                    url = "./mr_navigator2.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./mr_navigator.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&no_results=yes";
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
                Session.Contents.Remove("mrNavigatorTDS");

                // Get data from DA gateway
                mrNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (mrNavigatorTDS.MrNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["mrNavigatorTDS"] = mrNavigatorTDS;

                    // ... Go to the results page
                    url = "./mr_navigator2.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./mr_navigator.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&no_results=yes";
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

            // Validate tools
            if (Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"]))
            {
                tkrpbLeftMenuTools.Items[0].Visible = true; // Add batch
            }
            else
            {
                tkrpbLeftMenuTools.Items[0].Visible = false; // Add batch
            }            
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// AUXILIAR EVENTS
        ///

        protected void cvInvalidOperator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Operator for Text and boolean fields
            if ((ddlCondition1.SelectedItem.Text == "ID (Manhole)") || (ddlCondition1.SelectedItem.Text == "Street") || (ddlCondition1.SelectedItem.Text == "Latitude") || (ddlCondition1.SelectedItem.Text == "Longitude") || (ddlCondition1.SelectedItem.Text == "Shape") || (ddlCondition1.SelectedItem.Text == "Location") || (ddlCondition1.SelectedItem.Text == "Comments") )
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
            if ((ddlCondition1.SelectedItem.Text == "Prepped Date") || (ddlCondition1.SelectedItem.Text == "Sprayed Date") || (ddlCondition1.SelectedItem.Text == "Batch Date") )
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
            if (ddlCondition1.SelectedItem.Text == "Condition Raiting") 
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
            if ((ddlCondition2.SelectedItem.Text == "ID (Manhole)") || (ddlCondition2.SelectedItem.Text == "Street") || (ddlCondition2.SelectedItem.Text == "Latitude") || (ddlCondition2.SelectedItem.Text == "Longitude") || (ddlCondition2.SelectedItem.Text == "Shape") || (ddlCondition2.SelectedItem.Text == "Location") || (ddlCondition2.SelectedItem.Text == "Comments"))
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
            if ((ddlCondition2.SelectedItem.Text == "Prepped Date") || (ddlCondition2.SelectedItem.Text == "Sprayed Date") || (ddlCondition2.SelectedItem.Text == "Batch Date"))
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
            if (ddlCondition2.SelectedItem.Text == "Condition Raiting")
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



        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ( (ddlCondition1.SelectedItem.Text == "Batch Date") || (ddlCondition1.SelectedItem.Text == "Prepped Date") || (ddlCondition1.SelectedItem.Text == "Sprayed Date"))
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



        protected void cvForDate2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition2.SelectedItem.Text == "Batch Date") || (ddlCondition2.SelectedItem.Text == "Prepped Date") || (ddlCondition2.SelectedItem.Text == "Sprayed Date"))
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
            if ((ddlCondition1.SelectedItem.Text == "Batch Date") || (ddlCondition1.SelectedItem.Text == "Prepped Date") || (ddlCondition1.SelectedItem.Text == "Sprayed Date"))
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



        protected void cvForDateRange2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition2.SelectedItem.Text == "Batch Date") || (ddlCondition2.SelectedItem.Text == "Prepped Date") || (ddlCondition2.SelectedItem.Text == "Sprayed Date"))
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



        protected void cvForNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if (ddlCondition1.SelectedItem.Text == "Condition Raiting") 
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



        protected void cvForNumberCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if (ddlCondition2.SelectedItem.Text == "Condition Raiting")
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
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //
        
        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=mr_navigator2.aspx&work_type=" + hdfWorkType.Value.Trim());
        }        
                              


        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabMr"] = "0";
                Session["dialogOpenedMr"] = "0";

                // Redirect
                string url = "./mr_summary.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + "&in_project=" + hdfInProject.Value + "&active_tab=0" + GetNavigatorState();
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
                Session["activeTabMr"] = "0";
                Session["dialogOpenedMr"] = "0";

                // Redirect
                string url = "./mr_edit.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + "&in_project=" + hdfInProject.Value + "&active_tab=0" + GetNavigatorState();
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
            mForm7 master = (mForm7)this.Master;
            ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster7");

            if (!scriptManager.IsInAsyncPostBack)
            {
                string url = "";
                string headerValues = "";
                int totalColumnsExport = 11;
                int totalColumnsPreview = 11;
                string client = "";
                string name = "";
                string project = "";
                string title = "Manhole Rehabilitation Search Results";

                // ... for client           
                int companyId = Int32.Parse(hdfCompanyId.Value);
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
                if (grdMRNavigator.Columns[1].Visible) headerValues += "Manhole No";
                if (grdMRNavigator.Columns[2].Visible) headerValues += " * Street";
                if (grdMRNavigator.Columns[3].Visible) headerValues += " * Latitude";
                if (grdMRNavigator.Columns[4].Visible) headerValues += " * Longitude";
                if (grdMRNavigator.Columns[5].Visible) headerValues += " * Shape";
                if (grdMRNavigator.Columns[6].Visible) headerValues += " * Location";
                if (grdMRNavigator.Columns[7].Visible) headerValues += " * Condition Rating";
                if (grdMRNavigator.Columns[8].Visible) headerValues += " * Prepped Date";
                if (grdMRNavigator.Columns[9].Visible) headerValues += " * Sprayed Date";
                if (grdMRNavigator.Columns[10].Visible) headerValues += " * Batch Date";               
                
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

                if (grdMRNavigator.Columns[11].Visible) comments = "Comments";

                // Report call
                Page.Validate();
                if (Page.IsValid)
                {
                    PostPageChanges();
                    title = title.Replace("'", "%27");
                    Response.Write("<script language='javascript'> {window.open('./mr_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                }                 

                if (url != "") Response.Redirect(url);
            }
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            mForm7 master = (mForm7)this.Master;
            ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster7");

            if (!scriptManager.IsInAsyncPostBack)
            {
                string url = "";
                string headerValues = "";
                int totalColumnsExport = 11;
                int totalColumnsPreview = 11;
                string client = "";
                string name = "";
                string project = "";
                string title = "Manhole Rehabilitation Search Results";
                string columnsForReport = "";
                int j;

                // ... for client           
                int companyId = Int32.Parse(hdfCompanyId.Value);
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

                headerValues = "";
                columnsForReport = "";

                // Establishing header values                        
                if (grdMRNavigator.Columns[1].Visible) headerValues += "Manhole No";
                if (grdMRNavigator.Columns[2].Visible) headerValues += " * Street";
                if (grdMRNavigator.Columns[3].Visible) headerValues += " * Latitude";
                if (grdMRNavigator.Columns[4].Visible) headerValues += " * Longitude";
                if (grdMRNavigator.Columns[5].Visible) headerValues += " * Shape";
                if (grdMRNavigator.Columns[6].Visible) headerValues += " * Location";
                if (grdMRNavigator.Columns[7].Visible) headerValues += " * Condition Rating";
                if (grdMRNavigator.Columns[8].Visible) headerValues += " * Prepped Date";
                if (grdMRNavigator.Columns[9].Visible) headerValues += " * Sprayed Date";
                if (grdMRNavigator.Columns[10].Visible) headerValues += " * Batch Date";                
                if (grdMRNavigator.Columns[11].Visible) headerValues += " * Comments";
                
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
                    Response.Write("<script language='javascript'> {window.open('./mr_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                }

                if (url != "") Response.Redirect(url);
            }
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
                Session["activeTabMr"] = "0";
                Session["dialogOpenedMr"] = "0";

                // Redirect
                string url = "./mr_delete.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + "&asset_id=" + assetId + GetNavigatorState();
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
            string url = "./mr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + "&in_project=" + hdfInProject.Value ;
            
            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            switch (e.Item.Value)
            {

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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./mr_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
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

            // ... ForView 
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

            cbxIdManhole.Checked = (columnsToDisplay2.IndexOf("MHID") >= 0 ? true : false);
            cbxStreet.Checked = (columnsToDisplay2.IndexOf("Address") >= 0 ? true : false);
            cbxLatitude.Checked = (columnsToDisplay2.IndexOf("Latitud") >= 0 ? true : false);
            cbxLongitude.Checked = (columnsToDisplay2.IndexOf("Longitude") >= 0 ? true : false);
            cbxShape.Checked = (columnsToDisplay2.IndexOf("ManholeShape") >= 0 ? true : false);
            cbxLocation.Checked = (columnsToDisplay2.IndexOf("Location") >= 0 ? true : false);
            cbxConditionRaiting.Checked = (columnsToDisplay2.IndexOf("ConditionRating") >= 0 ? true : false);
            cbxPreppedDate.Checked = (columnsToDisplay2.IndexOf("PreppedDate") >= 0 ? true : false);
            cbxSprayedDate.Checked = (columnsToDisplay2.IndexOf("SprayedDate") >= 0 ? true : false);
            cbxBatchDate.Checked = (columnsToDisplay2.IndexOf("Date") >= 0 ? true : false);
            cbxComments.Checked = (columnsToDisplay2.IndexOf("Comments") >= 0 ? true : false);

            // Grid's columns
            grdMRNavigator.Columns[1].Visible = (columnsToDisplay.IndexOf("MHID") >= 0 ? true : false);
            grdMRNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("Address") >= 0 ? true : false);
            grdMRNavigator.Columns[3].Visible = (columnsToDisplay.Contains("Latitud") ? true : false);
            grdMRNavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("Longitude") >= 0 ? true : false);            
            grdMRNavigator.Columns[5].Visible = (columnsToDisplay.Contains("ManholeShape") ? true : false);
            grdMRNavigator.Columns[6].Visible = (columnsToDisplay.IndexOf("Location") >= 0 ? true : false);
            grdMRNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf("ConditionRating") >= 0 ? true : false);
            grdMRNavigator.Columns[8].Visible = (columnsToDisplay.IndexOf("PreppedDate") >= 0 ? true : false);
            grdMRNavigator.Columns[9].Visible = (columnsToDisplay.IndexOf("SprayedDate") >= 0 ? true : false);
            grdMRNavigator.Columns[10].Visible = (columnsToDisplay.IndexOf("Date") >= 0 ? true : false);
            grdMRNavigator.Columns[11].Visible = (columnsToDisplay.IndexOf("Comments") >= 0 ? true : false);            
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
            searchOptions = searchOptions + "&btn_origin=" + hdfBtnOrigin.Value;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private MrNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string workType = hdfWorkType.Value.Trim();
            string conditionValue1 = "";
            string conditionValue2 = "";  

            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            bool inProject = bool.Parse(hdfInProject.Value);
            MrNavigator mrNavigator = new MrNavigator();

            // ... Load data
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

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
            mrNavigator.Load(whereClause, orderByClause, conditionValue1, conditionValue2, tbxCondition1.Text.Trim(),  tbxCondition2.Text.Trim(), companyId, currentProjectId, workType, inProject);

            return (MrNavigatorTDS)mrNavigator.Data;
        }



        private MrNavigatorTDS SubmitSearchForViews()
        {
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

            MrNavigator mrNavigator = new MrNavigator();
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            bool inProject = bool.Parse(hdfInProject.Value);

            // ... Load SqlCommand
            WorkViewGateway workViewGateway = new WorkViewGateway();
            workViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = workViewGateway.GetSqlCommand(viewId);

            // ... Load data
            mrNavigator.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, currentProjectId, companyId, workType, inProject);

            return (MrNavigatorTDS)mrNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND " +
                " (LASMH.Deleted = 0) AND (LASMH.COMPANY_ID = " + companyId + ") AND " +
                " (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND " +
                " (AASMH.Deleted = 0) AND (AASMH.COMPANY_ID = " + companyId + ") AND (AASMHP.ProjectID = " + Convert.ToInt32(hdfCurrentProjectId.Value) + ")";       

            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim(), ddlOperator1.SelectedValue);

            // ... Condition 2
            if (ddlCondition2.SelectedValue != "-1")
            {
                whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition2.SelectedValue), tbxCondition2.Text.Trim(), ddlOperator2.SelectedValue);
            }
            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch, string operatorValue)
        {
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, conditionId, companyId);

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, conditionId);
            string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, conditionId);

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "AM_ASSET_SEWER_MH") tableName = "AASMH";
            if (tableName == "LFS_WORK_MANHOLE_REHABILITATION_BATCH") tableName = "LWMRB";
            if (tableName == "LFS_WORK_MANHOLE_REHABILITATION") tableName = "LWMR";
            if (tableName == "LFS_ASSET_SEWER_MH") tableName = "LASMH";
            if (tableName == "LFS_WORK") tableName = "LW";

            // FOR TEXT FIELDS. (MHID, Address, Latitud, Comments, Longitude, ManholeShape, Location)
            if ((conditionValue == "MHID") || (conditionValue == "Address") || (conditionValue == "Latitud") || (conditionValue == "Comments")
                || (conditionValue == "Longitude") || (conditionValue == "ManholeShape") || (conditionValue == "Location"))
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

            // FOR DATE FIELDS. (PreppedDate, SprayedDate, Date)
            if ((conditionValue == "PreppedDate") || (conditionValue == "SprayedDate") || (conditionValue == "Date"))
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

            // FOR INTEGER AND DOUBLE FIELDS. (ConditionRating)
            if (conditionValue == "ConditionRating")
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

            return whereClause;
        }



        private string GetOrderByClause()
        {
            // Get tableName
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway();
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = workTypeViewSortGateway.GetColumn_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_ASSET_SEWER_MH") tableName = "LASMH";
            if (tableName == "LFS_WORK_MANHOLE_REHABILITATION") tableName = "LWMR";
            if (tableName == "LFS_WORK_MANHOLE_REHABILITATION_BATCH") tableName = "LWMRB";
            if (tableName == "AM_ASSET_SEWER_MH") tableName = "AASMH";

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));
            
            // Get order by clause
            string orderBy = "";
            if (columnName == "Date")
            {
                switch (conditionValue)
                {
                    case "PreppedDate":
                        orderBy = "LWMR.PreppedDate DESC";
                        break;

                    case "SprayedDate":
                        orderBy = "LWMR.SprayedDate DESC";
                        break;

                    case "Date":
                        orderBy = "LWMRB.Date DESC";
                        break;                                           

                    default:
                        orderBy = "AASMH.MHID ASC";
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
            MrNavigator mrNavigator = new MrNavigator(mrNavigatorTDS);

            // Update navigator rows
            foreach (GridViewRow row in grdMRNavigator.Rows)
            {
                string assetIdLabel = ((Label)row.FindControl("lblAssetId")).Text.Trim();
                int assetId = Int32.Parse(assetIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                mrNavigator.Update(assetId, selected);
            }

            mrNavigator.Data.AcceptChanges();

            // Store datasets
            Session["mrNavigatorTDS"] = mrNavigatorTDS;
        }



        private int GetAssetId()
        {
            int assetId = 0;

            foreach (MrNavigatorTDS.MrNavigatorRow mrNavigatorRow in mrNavigatorTDS.MrNavigator)
            {
                if (mrNavigatorRow.Selected)
                {
                    assetId = mrNavigatorRow.AssetID ;
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

            columnsToDisplay2 = columnsToDisplay2 + (cbxIdManhole.Checked ? "MHID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxStreet.Checked ? "Address," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLatitude.Checked ? "Latitud," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLongitude.Checked ? "Longitude," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxShape.Checked ? "ManholeShape," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLocation.Checked ? "Location," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxConditionRaiting.Checked ? "ConditionRating," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPreppedDate.Checked ? "PreppedDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSprayedDate.Checked ? "SprayedDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxBatchDate.Checked ? "Date," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxComments.Checked ? "Comments," : "");

            if (hdfBtnOrigin.Value == "Search")
            {
                columnsToDisplay = columnsToDisplay + (cbxIdManhole.Checked ? "MHID," : "");
                columnsToDisplay = columnsToDisplay + (cbxStreet.Checked ? "Address," : "");
                columnsToDisplay = columnsToDisplay + (cbxLatitude.Checked ? "Latitud," : "");
                columnsToDisplay = columnsToDisplay + (cbxLongitude.Checked ? "Longitude," : "");
                columnsToDisplay = columnsToDisplay + (cbxShape.Checked ? "ManholeShape," : "");
                columnsToDisplay = columnsToDisplay + (cbxLocation.Checked ? "Location," : "");
                columnsToDisplay = columnsToDisplay + (cbxConditionRaiting.Checked ? "ConditionRating," : "");
                columnsToDisplay = columnsToDisplay + (cbxPreppedDate.Checked ? "PreppedDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxSprayedDate.Checked ? "SprayedDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxBatchDate.Checked ? "Date," : "");
                columnsToDisplay = columnsToDisplay + (cbxComments.Checked ? "Comments," : "");
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