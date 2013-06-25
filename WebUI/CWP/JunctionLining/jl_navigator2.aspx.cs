using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.CWP.Works;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jl_navigator2
    /// </summary>
    public partial class jl_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected JlNavigatorTDS jlNavigatorTDS;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jl_navigator2.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

                // Prepare initial data
                // ... For sortByList
                odsSortByList.DataBind();
                ddlSortBy.DataSourceID = "odsSortByList";
                ddlSortBy.DataValueField = "SortID";
                ddlSortBy.DataTextField = "Name";
                ddlSortBy.DataBind();

                // ... For 
                odsViewForDisplayList.DataBind();
                odsViewForDisplayList2.DataBind();
                
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
                workTypeViewSubAreaList.LoadAndAddItem("Junction Lining", Int32.Parse(hdfCompanyId.Value), int.Parse(hdfCurrentProjectId.Value), "(All)");
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
                // ... jl_navigator.aspx or jl_navigator2.aspx
                if ((Request.QueryString["source_page"] == "jl_navigator.aspx") || (Request.QueryString["source_page"] == "jl_navigator2.aspx"))
                {
                    // Restore data
                    RestoreNavigatorState();                    
                    jlNavigatorTDS = (JlNavigatorTDS)Session["jlNavigatorTDS"];                  
                }

                // ... flat_section_jl_edit.aspx, flat_section_jl_summary.aspx or jl_delete.aspx
                if ((Request.QueryString["source_page"] == "flat_section_jl_edit.aspx") || (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx") || (Request.QueryString["source_page"] == "jl_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        jlNavigatorTDS = (JlNavigatorTDS)Session["jlNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("jlNavigatorTDS");

                        // ... Search data with updates
                        if (hdfBtnOrigin.Value == "Search")
                        {
                            jlNavigatorTDS = SubmitSearch();
                        }
                        else
                        {
                            if (hdfBtnOrigin.Value == "Go")
                            {
                                jlNavigatorTDS = SubmitSearchForViews();
                            }
                        }

                        // ... store datasets
                        Session["jlNavigatorTDS"] = jlNavigatorTDS;                       
                    }                    
                }

                // ... jl_delete.aspx, flat_section_jl_summary.aspx or flat_section_jl_edit.aspx
                if ((Request.QueryString["source_page"] == "jl_delete.aspx") || (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx") || (Request.QueryString["source_page"] == "flat_section_jl_edit.aspx"))
                {
                    if (jlNavigatorTDS.JlNavigator.Rows.Count == 0)
                    {
                        string url = "./jl_navigator.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                // Update for comments
                JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);
                jlNavigator.UpdateEnterForComments();

                // Store data
                Session["jlNavigatorTDS"] = jlNavigatorTDS;
                
                // For the grid
                grdJLNavigator.DataSource = jlNavigatorTDS.JlNavigator;
                grdJLNavigator.DataBind();                

                // ... for the total rows
                if (jlNavigatorTDS.JlNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + jlNavigatorTDS.JlNavigator.Rows.Count;
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
                jlNavigatorTDS = (JlNavigatorTDS)Session["jlNavigatorTDS"];

                // Update for comments
                JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);
                jlNavigator.UpdateEnterForComments();

                // ... for the total rows
                if (jlNavigatorTDS.JlNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + jlNavigatorTDS.JlNavigator.Rows.Count;
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
            if (Page.IsValid)
            {
                // Tag Page
                hdfBtnOrigin.Value = "Search";

                string url = "";

                // Delete store data
                Session.Contents.Remove("jlNavigatorTDS");

                // Get data from DA gateway
                jlNavigatorTDS = SubmitSearch();

                // Show results
                if (jlNavigatorTDS.JlNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["jlNavigatorTDS"] = jlNavigatorTDS;

                    // ... Go to the results page
                    url = "./jl_navigator2.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./jl_navigator.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
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
                Session.Contents.Remove("jlNavigatorTDS");

                // Get data from DA gateway
                jlNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (jlNavigatorTDS.JlNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["jlNavigatorTDS"] = jlNavigatorTDS;

                    // ... Go to the results page
                    url = "./jl_navigator2.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./jl_navigator.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
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

        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Pipe Located") || (ddlCondition1.SelectedItem.Text == "Services Located") || (ddlCondition1.SelectedItem.Text == "C/O Installed") || (ddlCondition1.SelectedItem.Text == "Backfilled Con.") || (ddlCondition1.SelectedItem.Text == "Backfilled Soil") || (ddlCondition1.SelectedItem.Text == "Grouted") || (ddlCondition1.SelectedItem.Text == "Cored") || (ddlCondition1.SelectedItem.Text == "Prepped") || (ddlCondition1.SelectedItem.Text == "Measured") || (ddlCondition1.SelectedItem.Text == "In Process") || (ddlCondition1.SelectedItem.Text == "In Stock") || (ddlCondition1.SelectedItem.Text == "Delivered") || (ddlCondition1.SelectedItem.Text == "Pre-Video") || (ddlCondition1.SelectedItem.Text == "Liner Installed") || (ddlCondition1.SelectedItem.Text == "Final Video") || (ddlCondition1.SelectedItem.Text == "C/O Cut Down?") || (ddlCondition1.SelectedItem.Text == "V1 Inspection") || (ddlCondition1.SelectedItem.Text == "Final Restoration") || (ddlCondition1.SelectedItem.Text == "Notice Delivered") || (ddlCondition1.SelectedItem.Text == "Dig Req'd Prior To Lining Completed") || (ddlCondition1.SelectedItem.Text == "Dig Req'd After Lining Completed") || (ddlCondition1.SelectedItem.Text == "Hold - Client Issue Resolved") || (ddlCondition1.SelectedItem.Text == "Hold - LFS Issue Resolved") || (ddlCondition1.SelectedItem.Text == "Notice Delivered") || (ddlCondition1.SelectedItem.Text == "Requires Robotic Prep Completed") || (ddlCondition1.SelectedItem.Text == "Dye Test Complete"))
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
            if ((ddlCondition1.SelectedItem.Text == "Pipe Located") || (ddlCondition1.SelectedItem.Text == "Services Located") || (ddlCondition1.SelectedItem.Text == "C/O Installed") || (ddlCondition1.SelectedItem.Text == "Backfilled Con.") || (ddlCondition1.SelectedItem.Text == "Backfilled Soil") || (ddlCondition1.SelectedItem.Text == "Grouted") || (ddlCondition1.SelectedItem.Text == "Cored") || (ddlCondition1.SelectedItem.Text == "Prepped") || (ddlCondition1.SelectedItem.Text == "Measured") || (ddlCondition1.SelectedItem.Text == "In Process") || (ddlCondition1.SelectedItem.Text == "In Stock") || (ddlCondition1.SelectedItem.Text == "Delivered") || (ddlCondition1.SelectedItem.Text == "Pre-Video") || (ddlCondition1.SelectedItem.Text == "Liner Installed") || (ddlCondition1.SelectedItem.Text == "Final Video") || (ddlCondition1.SelectedItem.Text == "C/O Cut Down?") || (ddlCondition1.SelectedItem.Text == "V1 Inspection") || (ddlCondition1.SelectedItem.Text == "Final Restoration") || (ddlCondition1.SelectedItem.Text == "Notice Delivered") || (ddlCondition1.SelectedItem.Text == "Dig Req'd Prior To Lining Completed") || (ddlCondition1.SelectedItem.Text == "Dig Req'd After Lining Completed") || (ddlCondition1.SelectedItem.Text == "Hold - Client Issue Resolved") || (ddlCondition1.SelectedItem.Text == "Hold - LFS Issue Resolved") || (ddlCondition1.SelectedItem.Text == "Notice Delivered") || (ddlCondition1.SelectedItem.Text == "Requires Robotic Prep Completed") || (ddlCondition1.SelectedItem.Text == "Dye Test Complete")) 
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



        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "C/O Req.") || (ddlCondition1.SelectedItem.Text == "Pit Req.") || (ddlCondition1.SelectedItem.Text == "Post Contract Dig?") || (ddlCondition1.SelectedItem.Text == "Lining Thru C/O") || (ddlCondition1.SelectedItem.Text == "Dig Req'd Prior To Lining") || (ddlCondition1.SelectedItem.Text == "Dig Req'd After Lining") || (ddlCondition1.SelectedItem.Text == "Out Of Scope") || (ddlCondition1.SelectedItem.Text == "Hold - Client Issue") || (ddlCondition1.SelectedItem.Text == "Hold - LFS Issue") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Req'd") || (ddlCondition1.SelectedItem.Text == "Dye Test Req'd"))
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



        protected void cvForNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if ((ddlCondition1.SelectedItem.Text != "") && (ddlOperator1.SelectedValue != ""))
            {
                if (ddlCondition1.SelectedItem.Text == "Build / Rebuild #")
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
        }



        protected void cvForMoneyCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Double number fields validate
            if ((ddlCondition1.SelectedItem.Text != "") && (ddlOperator1.SelectedValue != ""))
            {
                if (ddlCondition1.SelectedItem.Text == "Cost")
                {
                    if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                    {
                        if (Validator.IsValidDouble(args.Value.Trim()))
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



        protected void cvForDate2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition2.SelectedItem.Text == "Pipe Located") || (ddlCondition2.SelectedItem.Text == "Services Located") || (ddlCondition2.SelectedItem.Text == "C/O Installed") || (ddlCondition2.SelectedItem.Text == "Backfilled Con.") || (ddlCondition2.SelectedItem.Text == "Backfilled Soil") || (ddlCondition2.SelectedItem.Text == "Grouted") || (ddlCondition2.SelectedItem.Text == "Cored") || (ddlCondition2.SelectedItem.Text == "Prepped") || (ddlCondition2.SelectedItem.Text == "Measured") || (ddlCondition2.SelectedItem.Text == "In Process") || (ddlCondition2.SelectedItem.Text == "In Stock") || (ddlCondition2.SelectedItem.Text == "Delivered") || (ddlCondition2.SelectedItem.Text == "Pre-Video") || (ddlCondition2.SelectedItem.Text == "Liner Installed") || (ddlCondition2.SelectedItem.Text == "Final Video") || (ddlCondition2.SelectedItem.Text == "C/O Cut Down?") || (ddlCondition2.SelectedItem.Text == "V1 Inspection") || (ddlCondition2.SelectedItem.Text == "Final Restoration") || (ddlCondition2.SelectedItem.Text == "Notice Delivered") || (ddlCondition2.SelectedItem.Text == "Dig Req'd Prior To Lining Completed") || (ddlCondition2.SelectedItem.Text == "Dig Req'd After Lining Completed") || (ddlCondition2.SelectedItem.Text == "Hold - Client Issue Resolved") || (ddlCondition2.SelectedItem.Text == "Hold - LFS Issue Resolved") || (ddlCondition2.SelectedItem.Text == "Notice Delivered") || (ddlCondition2.SelectedItem.Text == "Requires Robotic Prep Completed") || (ddlCondition2.SelectedItem.Text == "Dye Test Complete"))
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
            if ((ddlCondition2.SelectedItem.Text == "Pipe Located") || (ddlCondition2.SelectedItem.Text == "Services Located") || (ddlCondition2.SelectedItem.Text == "C/O Installed") || (ddlCondition2.SelectedItem.Text == "Backfilled Con.") || (ddlCondition2.SelectedItem.Text == "Backfilled Soil") || (ddlCondition2.SelectedItem.Text == "Grouted") || (ddlCondition2.SelectedItem.Text == "Cored") || (ddlCondition2.SelectedItem.Text == "Prepped") || (ddlCondition2.SelectedItem.Text == "Measured") || (ddlCondition2.SelectedItem.Text == "In Process") || (ddlCondition2.SelectedItem.Text == "In Stock") || (ddlCondition2.SelectedItem.Text == "Delivered") || (ddlCondition2.SelectedItem.Text == "Pre-Video") || (ddlCondition2.SelectedItem.Text == "Liner Installed") || (ddlCondition2.SelectedItem.Text == "Final Video") || (ddlCondition2.SelectedItem.Text == "C/O Cut Down?") || (ddlCondition2.SelectedItem.Text == "V1 Inspection") || (ddlCondition2.SelectedItem.Text == "Final Restoration") || (ddlCondition2.SelectedItem.Text == "Notice Delivered") || (ddlCondition2.SelectedItem.Text == "Dig Req'd Prior To Lining Completed") || (ddlCondition2.SelectedItem.Text == "Dig Req'd After Lining Completed") || (ddlCondition2.SelectedItem.Text == "Hold - Client Issue Resolved") || (ddlCondition2.SelectedItem.Text == "Hold - LFS Issue Resolved") || (ddlCondition2.SelectedItem.Text == "Notice Delivered") || (ddlCondition2.SelectedItem.Text == "Requires Robotic Prep Completed") || (ddlCondition2.SelectedItem.Text == "Dye Test Complete"))
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



        protected void cvForBoolean2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition2.SelectedItem.Text == "C/O Req.") || (ddlCondition2.SelectedItem.Text == "Pit Req.") || (ddlCondition2.SelectedItem.Text == "Post Contract Dig?") || (ddlCondition2.SelectedItem.Text == "Lining Thru C/O") || (ddlCondition2.SelectedItem.Text == "Dig Req'd Prior To Lining") || (ddlCondition2.SelectedItem.Text == "Dig Req'd After Lining") || (ddlCondition2.SelectedItem.Text == "Out Of Scope") || (ddlCondition2.SelectedItem.Text == "Hold - Client Issue") || (ddlCondition2.SelectedItem.Text == "Hold - LFS Issue") || (ddlCondition2.SelectedItem.Text == "Robotic Prep Req'd") || (ddlCondition2.SelectedItem.Text == "Dye Test Req'd"))
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
                if (ddlCondition2.SelectedItem.Text == "Build / Rebuild #")
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



        protected void cvForMoneyCondition2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Double number fields validate
            if ((ddlCondition2.SelectedItem.Text != "") && (ddlOperator2.SelectedValue != ""))
            {
                if (ddlCondition2.SelectedItem.Text == "Cost")
                {
                    if ((tbxCondition2.Text != "") && (tbxCondition2.Text != "%"))
                    {
                        if (Validator.IsValidDouble(args.Value.Trim()))
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



        protected void cvInvalidOperator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Operator for Text and boolean fields
            if ((ddlCondition1.SelectedItem.Text == "ID (Section)") || (ddlCondition1.SelectedItem.Text == "Old CWP ID") || (ddlCondition1.SelectedItem.Text == "Client Lateral ID") || (ddlCondition1.SelectedItem.Text == "Street") || (ddlCondition1.SelectedItem.Text == "Sub Area") || (ddlCondition1.SelectedItem.Text == "MN#") || (ddlCondition1.SelectedItem.Text == "USMH") || (ddlCondition1.SelectedItem.Text == "DSMH") || (ddlCondition1.SelectedItem.Text == "Liner Size") || (ddlCondition1.SelectedItem.Text == "C/O Req.") || (ddlCondition1.SelectedItem.Text == "Pit Req.") || (ddlCondition1.SelectedItem.Text == "CO/Pit Location") || (ddlCondition1.SelectedItem.Text == "Post Contract Dig?") || (ddlCondition1.SelectedItem.Text == "Lining Thru C/O") || (ddlCondition1.SelectedItem.Text == "Comments") || (ddlCondition1.SelectedItem.Text == "History") || (ddlCondition1.SelectedItem.Text == "Hamilton Insp.#") || (ddlCondition1.SelectedItem.Text == "Connection Type") || (ddlCondition1.SelectedItem.Text == "Main Size") || (ddlCondition1.SelectedItem.Text == "Flange") || (ddlCondition1.SelectedItem.Text == "Gasket") || (ddlCondition1.SelectedItem.Text == "Dig Req'd Prior To Lining") || (ddlCondition1.SelectedItem.Text == "Dig Req'd After Lining") || (ddlCondition1.SelectedItem.Text == "Out Of Scope") || (ddlCondition1.SelectedItem.Text == "Hold - Client Issue") || (ddlCondition1.SelectedItem.Text == "Hold - LFS Issue") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Req'd") || (ddlCondition1.SelectedItem.Text == "Prep Type") || (ddlCondition1.SelectedItem.Text == "Liner Type") || (ddlCondition1.SelectedItem.Text == "Dye Test Req'd") || (ddlCondition1.SelectedItem.Text == "Contract Year"))
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
            if ((ddlCondition1.SelectedItem.Text == "Pipe Located") || (ddlCondition1.SelectedItem.Text == "Services Located") || (ddlCondition1.SelectedItem.Text == "C/O Installed") || (ddlCondition1.SelectedItem.Text == "Backfilled Con.") || (ddlCondition1.SelectedItem.Text == "Backfilled Soil") || (ddlCondition1.SelectedItem.Text == "Grouted") || (ddlCondition1.SelectedItem.Text == "Cored") || (ddlCondition1.SelectedItem.Text == "Prepped") || (ddlCondition1.SelectedItem.Text == "Measured") || (ddlCondition1.SelectedItem.Text == "In Process") || (ddlCondition1.SelectedItem.Text == "In Stock") || (ddlCondition1.SelectedItem.Text == "Delivered") || (ddlCondition1.SelectedItem.Text == "Pre-Video") || (ddlCondition1.SelectedItem.Text == "Liner Installed") || (ddlCondition1.SelectedItem.Text == "Final Video") || (ddlCondition1.SelectedItem.Text == "C/O Cut Down?") || (ddlCondition1.SelectedItem.Text == "V1 Inspection") || (ddlCondition1.SelectedItem.Text == "Final Restoration") || (ddlCondition1.SelectedItem.Text == "Notice Delivered") || (ddlCondition1.SelectedItem.Text == "Dig Req'd Prior To Lining Completed") || (ddlCondition1.SelectedItem.Text == "Dig Req'd After Lining Completed") || (ddlCondition1.SelectedItem.Text == "Hold - Client Issue Resolved") || (ddlCondition1.SelectedItem.Text == "Hold - LFS Issue Resolved") || (ddlCondition1.SelectedItem.Text == "Notice Delivered") || (ddlCondition1.SelectedItem.Text == "Requires Robotic Prep Completed") || (ddlCondition1.SelectedItem.Text == "Dye Test Complete"))
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
            if (ddlCondition1.SelectedItem.Text == "Build / Rebuild #")
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

            // For Double fields
            if (ddlCondition1.SelectedItem.Text == "Cost")
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
            if ((ddlCondition2.SelectedItem.Text == "ID (Section)") || (ddlCondition2.SelectedItem.Text == "Old CWP ID") || (ddlCondition2.SelectedItem.Text == "Client Lateral ID") || (ddlCondition2.SelectedItem.Text == "Street") || (ddlCondition2.SelectedItem.Text == "Sub Area") || (ddlCondition2.SelectedItem.Text == "MN#") || (ddlCondition2.SelectedItem.Text == "USMH") || (ddlCondition2.SelectedItem.Text == "DSMH") || (ddlCondition2.SelectedItem.Text == "Liner Size") || (ddlCondition2.SelectedItem.Text == "C/O Req.") || (ddlCondition2.SelectedItem.Text == "Pit Req.") || (ddlCondition2.SelectedItem.Text == "CO/Pit Location") || (ddlCondition2.SelectedItem.Text == "Post Contract Dig?") || (ddlCondition2.SelectedItem.Text == "Lining Thru C/O") || (ddlCondition2.SelectedItem.Text == "Comments") || (ddlCondition2.SelectedItem.Text == "History") || (ddlCondition2.SelectedItem.Text == "Hamilton Insp.#") || (ddlCondition2.SelectedItem.Text == "Connection Type") || (ddlCondition2.SelectedItem.Text == "Main Size") || (ddlCondition2.SelectedItem.Text == "Flange") || (ddlCondition2.SelectedItem.Text == "Gasket") || (ddlCondition2.SelectedItem.Text == "Dig Req'd Prior To Lining") || (ddlCondition2.SelectedItem.Text == "Dig Req'd After Lining") || (ddlCondition2.SelectedItem.Text == "Out Of Scope") || (ddlCondition2.SelectedItem.Text == "Hold - Client Issue") || (ddlCondition2.SelectedItem.Text == "Hold - LFS Issue") || (ddlCondition2.SelectedItem.Text == "Robotic Prep Req'd") || (ddlCondition2.SelectedItem.Text == "Prep Type") || (ddlCondition2.SelectedItem.Text == "Liner Type") || (ddlCondition2.SelectedItem.Text == "Dye Test Req'd") || (ddlCondition2.SelectedItem.Text == "Contract Year"))
            {
                //  ... Text and boolean fields only use equals to and not operators
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
            if ((ddlCondition2.SelectedItem.Text == "Pipe Located") || (ddlCondition2.SelectedItem.Text == "Services Located") || (ddlCondition2.SelectedItem.Text == "C/O Installed") || (ddlCondition2.SelectedItem.Text == "Backfilled Con.") || (ddlCondition2.SelectedItem.Text == "Backfilled Soil") || (ddlCondition2.SelectedItem.Text == "Grouted") || (ddlCondition2.SelectedItem.Text == "Cored") || (ddlCondition2.SelectedItem.Text == "Prepped") || (ddlCondition2.SelectedItem.Text == "Measured") || (ddlCondition2.SelectedItem.Text == "In Process") || (ddlCondition2.SelectedItem.Text == "In Stock") || (ddlCondition2.SelectedItem.Text == "Delivered") || (ddlCondition2.SelectedItem.Text == "Pre-Video") || (ddlCondition2.SelectedItem.Text == "Liner Installed") || (ddlCondition2.SelectedItem.Text == "Final Video") || (ddlCondition2.SelectedItem.Text == "C/O Cut Down?") || (ddlCondition2.SelectedItem.Text == "V1 Inspection") || (ddlCondition2.SelectedItem.Text == "Final Restoration") || (ddlCondition2.SelectedItem.Text == "Notice Delivered") || (ddlCondition2.SelectedItem.Text == "Dig Req'd Prior To Lining Completed") || (ddlCondition2.SelectedItem.Text == "Dig Req'd After Lining Completed") || (ddlCondition2.SelectedItem.Text == "Hold - Client Issue Resolved") || (ddlCondition2.SelectedItem.Text == "Hold - LFS Issue Resolved") || (ddlCondition2.SelectedItem.Text == "Notice Delivered") || (ddlCondition2.SelectedItem.Text == "Requires Robotic Prep Completed") || (ddlCondition2.SelectedItem.Text == "Dye Test Complete"))
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
            if (ddlCondition2.SelectedItem.Text == "Build / Rebuild #")
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

            // For double fields
            if (ddlCondition2.SelectedItem.Text == "Cost")
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
            if ((ddlCondition1.SelectedItem.Text == "C/O Req.") || (ddlCondition1.SelectedItem.Text == "Pit Req.") || (ddlCondition1.SelectedItem.Text == "Post Contract Dig?") || (ddlCondition1.SelectedItem.Text == "Lining Thru C/O") || (ddlCondition1.SelectedItem.Text == "Dig Req'd Prior To Lining") || (ddlCondition1.SelectedItem.Text == "Dig Req'd After Lining") || (ddlCondition1.SelectedItem.Text == "Out Of Scope") || (ddlCondition1.SelectedItem.Text == "Hold - Client Issue") || (ddlCondition1.SelectedItem.Text == "Hold - LFS Issue") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Req'd") || (ddlCondition1.SelectedItem.Text == "Dye Test Req'd"))
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
            if ((ddlCondition2.SelectedItem.Text == "C/O Req.") || (ddlCondition2.SelectedItem.Text == "Pit Req.") || (ddlCondition2.SelectedItem.Text == "Post Contract Dig?") || (ddlCondition2.SelectedItem.Text == "Lining Thru C/O") || (ddlCondition2.SelectedItem.Text == "Dig Req'd Prior To Lining") || (ddlCondition2.SelectedItem.Text == "Dig Req'd After Lining") || (ddlCondition2.SelectedItem.Text == "Out Of Scope") || (ddlCondition2.SelectedItem.Text == "Hold - Client Issue") || (ddlCondition2.SelectedItem.Text == "Hold - LFS Issue") || (ddlCondition2.SelectedItem.Text == "Robotic Prep Req'd") || (ddlCondition1.SelectedItem.Text == "Dye Test Req'd"))
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
            Response.Redirect("./../Common/select_project.aspx?source_page=jl_navigator2.aspx&work_type=Junction Lining");
        }



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();

            PostPageChanges();

            ArrayList assetIdArrayList = GetAssetIdArrayList();
            if (assetIdArrayList.Count > 0)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl();
                flatSectionJl.LoadByAssetIdArrayList(assetIdArrayList, 1, currentProjectId, workType, companyId);

                if (flatSectionJl.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlTDS");

                    // Store datasets
                    Session["jlNavigatorTDS"] = jlNavigatorTDS;
                    Session["flatSectionJlTDS"] = flatSectionJl.Data;
                    Session["rowFocus"] = null;

                    // Redirect
                    string url = "./flat_section_jl_summary.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();
            
            PostPageChanges();

            ArrayList assetIdArrayList = GetAssetIdArrayList();
            if (assetIdArrayList.Count > 0)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl();
                flatSectionJl.LoadByAssetIdArrayList(assetIdArrayList, 1, currentProjectId, workType, companyId);

                if (flatSectionJl.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlTDS");

                    // Store datasets
                    Session["jlNavigatorTDS"] = jlNavigatorTDS;
                    Session["flatSectionJlTDS"] = flatSectionJl.Data;
                    Session["rowFocus"] = null;

                    // Redirect
                    string url = "./flat_section_jl_edit.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
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
            int totalColumnsPreview = 57;
            int totalColumnsExport = 59;
            string name = "";
            string client = "";
            string project = "";
            string title = "Junction Lining Search Results";
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);

            // ... for client
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

            // ... For comments and history options
            string comments = "None";
            string history = "None";
            JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);
                        
            // Update for comments                    
            jlNavigator.UpdateEnterForReport(projectId, companyId);

            // Establishing header values                        
            if (grdJLNavigator.Columns[2].Visible) headerValues += "LateralID";
            if (grdJLNavigator.Columns[3].Visible) headerValues += " * Old CWP ID";
            if (grdJLNavigator.Columns[4].Visible) headerValues += " * Client Lateral ID";
            if (grdJLNavigator.Columns[5].Visible) headerValues += " * Hamilton Inspection Number";
            if (grdJLNavigator.Columns[6].Visible) headerValues += " * Street";
            if (grdJLNavigator.Columns[7].Visible) headerValues += " * MN";
            if (grdJLNavigator.Columns[8].Visible) headerValues += " * USMH";
            if (grdJLNavigator.Columns[9].Visible) headerValues += " * DSMH";
            if (grdJLNavigator.Columns[10].Visible) headerValues += " * V1 Inspection";
            if (grdJLNavigator.Columns[11].Visible) headerValues += " * Video Length To PL";
            if (grdJLNavigator.Columns[12].Visible) headerValues += " * Depth Of Pipe";
            if (grdJLNavigator.Columns[13].Visible) headerValues += " * Pipe Located";
            if (grdJLNavigator.Columns[14].Visible) headerValues += " * Services Located";
            if (grdJLNavigator.Columns[15].Visible) headerValues += " * Prep Type";
            if (grdJLNavigator.Columns[16].Visible) headerValues += " * C/O Req.";
            if (grdJLNavigator.Columns[17].Visible) headerValues += " * Pit Req.";            
            if (grdJLNavigator.Columns[18].Visible) headerValues += " * CO/Pit Location";
            if (grdJLNavigator.Columns[19].Visible) headerValues += " * C/O Installed";
            if (grdJLNavigator.Columns[20].Visible) headerValues += " * Backfilled Con.";
            if (grdJLNavigator.Columns[21].Visible) headerValues += " * Backfilled Soil";
            if (grdJLNavigator.Columns[22].Visible) headerValues += " * Grouted";
            if (grdJLNavigator.Columns[23].Visible) headerValues += " * Cored";
            if (grdJLNavigator.Columns[24].Visible) headerValues += " * Prepped";
            if (grdJLNavigator.Columns[25].Visible) headerValues += " * Pre-Video";
            if (grdJLNavigator.Columns[26].Visible) headerValues += " * Measured";
            if (grdJLNavigator.Columns[27].Visible) headerValues += " * Connection Type";
            if (grdJLNavigator.Columns[28].Visible) headerValues += " * Liner Type";
            if (grdJLNavigator.Columns[29].Visible) headerValues += " * Flange";
            if (grdJLNavigator.Columns[30].Visible) headerValues += " * Gasket";
            if (grdJLNavigator.Columns[31].Visible) headerValues += " * Main Size";
            if (grdJLNavigator.Columns[32].Visible) headerValues += " * Liner Size";
            if (grdJLNavigator.Columns[33].Visible) headerValues += " * Lining Thru C/O";
            if (grdJLNavigator.Columns[34].Visible) headerValues += " * Notice Delivered";
            if (grdJLNavigator.Columns[35].Visible) headerValues += " * In Process";
            if (grdJLNavigator.Columns[36].Visible) headerValues += " * In Stock";
            if (grdJLNavigator.Columns[37].Visible) headerValues += " * Delivered";
            if (grdJLNavigator.Columns[38].Visible) headerValues += " * Liner Installed";
            if (grdJLNavigator.Columns[39].Visible) headerValues += " * Final Video";
            if (grdJLNavigator.Columns[40].Visible) headerValues += " * Dist. From USMH";
            if (grdJLNavigator.Columns[41].Visible) headerValues += " * Dist. From DSMH";
            if (grdJLNavigator.Columns[42].Visible) headerValues += " * Post Contract Dig?";
            if (grdJLNavigator.Columns[43].Visible) headerValues += " * C/O Cut Down?";
            if (grdJLNavigator.Columns[44].Visible) headerValues += " * Final Restoration";
            if (grdJLNavigator.Columns[45].Visible) headerValues += " * Cost";
            if (grdJLNavigator.Columns[46].Visible) headerValues += " * Build / Rebuild";
            if (grdJLNavigator.Columns[49].Visible) headerValues += " * Dig Required Prior To Lining";
            if (grdJLNavigator.Columns[50].Visible) headerValues += " * Dig Required Prior To Lining Completed";
            if (grdJLNavigator.Columns[51].Visible) headerValues += " * Dig Required After Lining";
            if (grdJLNavigator.Columns[52].Visible) headerValues += " * Dig Required After Lining Completed";
            if (grdJLNavigator.Columns[53].Visible) headerValues += " * Out Of Scope";
            if (grdJLNavigator.Columns[54].Visible) headerValues += " * Hold - Client Issue";
            if (grdJLNavigator.Columns[55].Visible) headerValues += " * Hold - Client Issue Resolved";
            if (grdJLNavigator.Columns[56].Visible) headerValues += " * Hold - LFS Issue";
            if (grdJLNavigator.Columns[57].Visible) headerValues += " * Hold - LFS Issue Resolved";
            if (grdJLNavigator.Columns[58].Visible) headerValues += " * Requires Robotic Prep";
            if (grdJLNavigator.Columns[59].Visible) headerValues += " * Requires Robotic Prep Completed";

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

            if (grdJLNavigator.Columns[47].Visible) { comments = "Comments"; }
            if (grdJLNavigator.Columns[48].Visible) { history = "History"; }

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./jl_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&history=" + history + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                           

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsPreview = 57;
            int totalColumnsExport = 59;
            string name = "";
            string client = "";
            string project = "";
            string title = "Junction Lining Search Results";
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);
            string columnsForReport = "";
            int j;

            // ... for client
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

            // ... For comments and history options
            string comments = "None";
            string history = "None";
            JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);

            // Update for comments
            jlNavigator.UpdateEnterForReport(projectId, companyId);

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdJLNavigator.Columns[2].Visible) headerValues += "LateralID";
            if (grdJLNavigator.Columns[3].Visible) headerValues += " * Old CWP ID";
            if (grdJLNavigator.Columns[4].Visible) headerValues += " * Client Lateral ID";
            if (grdJLNavigator.Columns[5].Visible) headerValues += " * Hamilton Inspection Number";
            if (grdJLNavigator.Columns[6].Visible) headerValues += " * Street";
            if (grdJLNavigator.Columns[7].Visible) headerValues += " * MN";
            if (grdJLNavigator.Columns[8].Visible) headerValues += " * USMH";
            if (grdJLNavigator.Columns[9].Visible) headerValues += " * DSMH";
            if (grdJLNavigator.Columns[10].Visible) headerValues += " * V1 Inspection";
            if (grdJLNavigator.Columns[11].Visible) headerValues += " * Video Length To PL";
            if (grdJLNavigator.Columns[12].Visible) headerValues += " * Depth Of Pipe";
            if (grdJLNavigator.Columns[13].Visible) headerValues += " * Pipe Located";
            if (grdJLNavigator.Columns[14].Visible) headerValues += " * Services Located";
            if (grdJLNavigator.Columns[15].Visible) headerValues += " * Prep Type";
            if (grdJLNavigator.Columns[16].Visible) headerValues += " * C/O Req.";
            if (grdJLNavigator.Columns[17].Visible) headerValues += " * Pit Req.";
            if (grdJLNavigator.Columns[18].Visible) headerValues += " * CO/Pit Location";
            if (grdJLNavigator.Columns[19].Visible) headerValues += " * C/O Installed";
            if (grdJLNavigator.Columns[20].Visible) headerValues += " * Backfilled Con.";
            if (grdJLNavigator.Columns[21].Visible) headerValues += " * Backfilled Soil";
            if (grdJLNavigator.Columns[22].Visible) headerValues += " * Grouted";
            if (grdJLNavigator.Columns[23].Visible) headerValues += " * Cored";
            if (grdJLNavigator.Columns[24].Visible) headerValues += " * Prepped";
            if (grdJLNavigator.Columns[25].Visible) headerValues += " * Pre-Video";
            if (grdJLNavigator.Columns[26].Visible) headerValues += " * Measured";
            if (grdJLNavigator.Columns[27].Visible) headerValues += " * Connection Type";
            if (grdJLNavigator.Columns[28].Visible) headerValues += " * Liner Type";
            if (grdJLNavigator.Columns[29].Visible) headerValues += " * Flange";
            if (grdJLNavigator.Columns[30].Visible) headerValues += " * Gasket";
            if (grdJLNavigator.Columns[31].Visible) headerValues += " * Main Size";
            if (grdJLNavigator.Columns[32].Visible) headerValues += " * Liner Size";
            if (grdJLNavigator.Columns[33].Visible) headerValues += " * Lining Thru C/O";
            if (grdJLNavigator.Columns[34].Visible) headerValues += " * Notice Delivered";
            if (grdJLNavigator.Columns[35].Visible) headerValues += " * In Process";
            if (grdJLNavigator.Columns[36].Visible) headerValues += " * In Stock";
            if (grdJLNavigator.Columns[37].Visible) headerValues += " * Delivered";
            if (grdJLNavigator.Columns[38].Visible) headerValues += " * Liner Installed";
            if (grdJLNavigator.Columns[39].Visible) headerValues += " * Final Video";
            if (grdJLNavigator.Columns[40].Visible) headerValues += " * Dist. From USMH";
            if (grdJLNavigator.Columns[41].Visible) headerValues += " * Dist. From DSMH";
            if (grdJLNavigator.Columns[42].Visible) headerValues += " * Post Contract Dig?";
            if (grdJLNavigator.Columns[43].Visible) headerValues += " * C/O Cut Down?";
            if (grdJLNavigator.Columns[44].Visible) headerValues += " * Final Restoration";
            if (grdJLNavigator.Columns[45].Visible) headerValues += " * Cost";
            if (grdJLNavigator.Columns[46].Visible) headerValues += " * Build / Rebuild";
            if (grdJLNavigator.Columns[47].Visible) headerValues += " * Comments";
            if (grdJLNavigator.Columns[48].Visible) headerValues += " * History";
            if (grdJLNavigator.Columns[49].Visible) headerValues += " * Dig Required Prior To Lining";
            if (grdJLNavigator.Columns[50].Visible) headerValues += " * Dig Required Prior To Lining Completed";
            if (grdJLNavigator.Columns[51].Visible) headerValues += " * Dig Required After Lining";
            if (grdJLNavigator.Columns[52].Visible) headerValues += " * Dig Required After Lining Completed";
            if (grdJLNavigator.Columns[53].Visible) headerValues += " * Out Of Scope";
            if (grdJLNavigator.Columns[54].Visible) headerValues += " * Hold - Client Issue";
            if (grdJLNavigator.Columns[55].Visible) headerValues += " * Hold - Client Issue Resolved";
            if (grdJLNavigator.Columns[56].Visible) headerValues += " * Hold - LFS Issue";
            if (grdJLNavigator.Columns[57].Visible) headerValues += " * Hold - LFS Issue Resolved";
            if (grdJLNavigator.Columns[58].Visible) headerValues += " * Requires Robotic Prep";
            if (grdJLNavigator.Columns[59].Visible) headerValues += " * Requires Robotic Prep Completed";

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
                Response.Write("<script language='javascript'> {window.open('./jl_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&history=" + history + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }            

            if (url != "") Response.Redirect(url);
        }



        protected void btnPrintLateralLocationSheet_Click(object sender, EventArgs e)
        {
            string url = "";
            string name = "";
            string client = "";
            string project = "";
            string title = "Junction Lining Search Results";
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfCurrentProjectId.Value);

            // ... for client
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

            // ... For comments and history options
            JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();

                int assetId = GetFirstSectionAssetId();
                if (assetId > 0)
                {
                    Response.Write("<script language='javascript'> {window.open('./../../CWP/Common/jl_lateral_location_sheet_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.Value + "&client_id=" + hdfCurrentClientId.Value + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                }
                else
                {
                    cvSelection.IsValid = false;
                }
            }                    

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();

            PostPageChanges();

            ArrayList assetIdArrayList = GetAssetIdArrayList();

            if (assetIdArrayList.Count > 0)
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl();
                flatSectionJl.LoadByAssetIdArrayList(assetIdArrayList, 1, currentProjectId, workType, companyId);

                if (flatSectionJl.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlTDS");

                    // Store datasets
                    Session["jlNavigatorTDS"] = jlNavigatorTDS;
                    Session["flatSectionJlTDS"] = flatSectionJl.Data;

                    // Redirect
                    string url = "./jl_delete.aspx?source_page=jl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./jl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mLiningPlan":
                    url = "./jl_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;

                case "mM1M2ReportByClient":
                    PostPageChanges();
                    ArrayList sectionIdArrayList2 = GetSectionIdArrayList();
                    if (sectionIdArrayList2.Count > 0)
                    {
                        Session["sectionsSelected"] = sectionIdArrayList2;
                    }

                    string script2 = "<script language='javascript'>";
                    url = "./../FullLengthLining/fl_m12_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_type=Junction Lining Section";
                    script2 = script2 + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680')", url);
                    script2 = script2 + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "M1Report", script2, false);
                    url = "";
                    break;

                case "mSearchS":
                    url = "./jls_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jl_navigator2.js");
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
            ddlSubArea.SelectedValue = Request.QueryString["search_sub_area"];

            // ... For BtnOrigin
            hdfBtnOrigin.Value = Request.QueryString["btn_origin"];

            // Grid's columns
            grdJLNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("SectionID") >= 0 ? true : false);
            grdJLNavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("OriginalSectionID") >= 0 ? true : false);
            grdJLNavigator.Columns[4].Visible = ((columnsToDisplay.IndexOf("ClientLateralId") >= 0 || columnsToDisplay.IndexOf("ClientLateralID") >= 0) ? true : false);
            grdJLNavigator.Columns[5].Visible = (columnsToDisplay.IndexOf("HamiltonInspectionNumber") >= 0 ? true : false);
            grdJLNavigator.Columns[6].Visible = (columnsToDisplay.IndexOf("Street") >= 0 ? true : false);
            grdJLNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf("MN") >= 0 ? true : false);
            grdJLNavigator.Columns[8].Visible = (columnsToDisplay.IndexOf("U_SMH") >= 0 ? true : false);
            grdJLNavigator.Columns[9].Visible = (columnsToDisplay.IndexOf("D_SMH") >= 0 ? true : false);
            grdJLNavigator.Columns[10].Visible = (columnsToDisplay.IndexOf("VideoInspection") >= 0 ? true : false);
            grdJLNavigator.Columns[11].Visible = (columnsToDisplay.IndexOf("VideoLengthToPropertyLine") >= 0 ? true : false);
            grdJLNavigator.Columns[12].Visible = (columnsToDisplay.IndexOf("DepthOfLocated") >= 0 ? true : false);
            grdJLNavigator.Columns[13].Visible = (columnsToDisplay.IndexOf("PipeLocated") >= 0 ? true : false);
            grdJLNavigator.Columns[14].Visible = (columnsToDisplay.IndexOf("ServicesLocated") >= 0 ? true : false);
            grdJLNavigator.Columns[15].Visible = (columnsToDisplay.IndexOf("PrepType") >= 0 ? true : false);
            grdJLNavigator.Columns[16].Visible = (columnsToDisplay.IndexOf("CoRequired") >= 0 ? true : false);
            grdJLNavigator.Columns[17].Visible = (columnsToDisplay.IndexOf("PitRequired") >= 0 ? true : false);
            grdJLNavigator.Columns[18].Visible = (columnsToDisplay.IndexOf("CoPitLocation") >= 0 ? true : false);
            grdJLNavigator.Columns[19].Visible = (columnsToDisplay.IndexOf("CoInstalled") >= 0 ? true : false);
            grdJLNavigator.Columns[20].Visible = (columnsToDisplay.IndexOf("BackfilledConcrete") >= 0 ? true : false);
            grdJLNavigator.Columns[21].Visible = (columnsToDisplay.IndexOf("BackfilledSoil") >= 0 ? true : false);
            grdJLNavigator.Columns[22].Visible = (columnsToDisplay.IndexOf("Grouted") >= 0 ? true : false);
            grdJLNavigator.Columns[23].Visible = (columnsToDisplay.IndexOf("Cored") >= 0 ? true : false);
            grdJLNavigator.Columns[24].Visible = (columnsToDisplay.IndexOf("Prepped") >= 0 ? true : false);
            grdJLNavigator.Columns[25].Visible = (columnsToDisplay.IndexOf("PreVideo") >= 0 ? true : false);
            grdJLNavigator.Columns[26].Visible = (columnsToDisplay.IndexOf("Measured") >= 0 ? true : false);
            grdJLNavigator.Columns[27].Visible = (columnsToDisplay.IndexOf("ConnectionType") >= 0 ? true : false);
            grdJLNavigator.Columns[28].Visible = (columnsToDisplay.IndexOf("LinerType") >= 0 ? true : false);
            grdJLNavigator.Columns[29].Visible = (columnsToDisplay.IndexOf("Flange") >= 0 ? true : false);
            grdJLNavigator.Columns[30].Visible = (columnsToDisplay.IndexOf("Gasket") >= 0 ? true : false);
            grdJLNavigator.Columns[31].Visible = ((columnsToDisplay.IndexOf("MainSize") >= 0 || columnsToDisplay.IndexOf("Size_") >= 0) ? true : false);
            grdJLNavigator.Columns[32].Visible = (columnsToDisplay.IndexOf("LinerSize") >= 0 ? true : false);
            grdJLNavigator.Columns[33].Visible = (columnsToDisplay.IndexOf("LiningThruCo") >= 0 ? true : false);
            grdJLNavigator.Columns[34].Visible = (columnsToDisplay.IndexOf("NoticeD_elivered") >= 0 ? true : false);
            grdJLNavigator.Columns[35].Visible = (columnsToDisplay.IndexOf("InProcess") >= 0 ? true : false);
            grdJLNavigator.Columns[36].Visible = (columnsToDisplay.IndexOf("InStock") >= 0 ? true : false);
            grdJLNavigator.Columns[37].Visible = (columnsToDisplay.IndexOf("Delivered") >= 0 ? true : false);
            grdJLNavigator.Columns[38].Visible = (columnsToDisplay.IndexOf("LinerInstalled") >= 0 ? true : false);
            grdJLNavigator.Columns[39].Visible = (columnsToDisplay.IndexOf("FinalVideo") >= 0 ? true : false);
            grdJLNavigator.Columns[40].Visible = (columnsToDisplay.IndexOf("DistanceFromUSMH") >= 0 ? true : false);
            grdJLNavigator.Columns[41].Visible = (columnsToDisplay.IndexOf("DistanceFromDSMH") >= 0 ? true : false);
            grdJLNavigator.Columns[42].Visible = (columnsToDisplay.IndexOf("PostContractDigRequired") >= 0 ? true : false);
            grdJLNavigator.Columns[43].Visible = (columnsToDisplay.IndexOf("CoCutDown") >= 0 ? true : false);
            grdJLNavigator.Columns[44].Visible = (columnsToDisplay.IndexOf("FinalRestoration") >= 0 ? true : false);
            grdJLNavigator.Columns[45].Visible = (columnsToDisplay.IndexOf("Cost") >= 0 ? true : false);
            grdJLNavigator.Columns[46].Visible = (columnsToDisplay.IndexOf("BuildRebuild") >= 0 ? true : false);
            grdJLNavigator.Columns[47].Visible = (columnsToDisplay.IndexOf("Comments") >= 0 ? true : false);
            grdJLNavigator.Columns[48].Visible = (columnsToDisplay.IndexOf("History") >= 0 ? true : false);
            grdJLNavigator.Columns[49].Visible = (columnsToDisplay.IndexOf("DigRequiredPriorToLining") >= 0 ? true : false);
            grdJLNavigator.Columns[50].Visible = (columnsToDisplay.IndexOf("DigRequiredPriorToLiningCompleted") >= 0 ? true : false);
            grdJLNavigator.Columns[51].Visible = (columnsToDisplay.IndexOf("DigRequiredAfterLining") >= 0 ? true : false);
            grdJLNavigator.Columns[52].Visible = (columnsToDisplay.IndexOf("DigRequiredAfterLiningCompleted") >= 0 ? true : false);
            grdJLNavigator.Columns[53].Visible = (columnsToDisplay.IndexOf("OutOfScope") >= 0 ? true : false);
            grdJLNavigator.Columns[54].Visible = (columnsToDisplay.IndexOf("HoldClientIssue") >= 0 ? true : false);
            grdJLNavigator.Columns[55].Visible = (columnsToDisplay.IndexOf("HoldClientIssueResolved") >= 0 ? true : false);
            grdJLNavigator.Columns[56].Visible = (columnsToDisplay.IndexOf("HoldLFSIssue") >= 0 ? true : false);
            grdJLNavigator.Columns[57].Visible = (columnsToDisplay.IndexOf("HoldLFSIssueResolved") >= 0 ? true : false);
            grdJLNavigator.Columns[58].Visible = (columnsToDisplay.IndexOf("LateralRequiresRoboticPrep") >= 0 ? true : false);
            grdJLNavigator.Columns[59].Visible = (columnsToDisplay.IndexOf("LateralRequiresRoboticPrepCompleted") >= 0 ? true : false);
            grdJLNavigator.Columns[60].Visible = (columnsToDisplay.IndexOf("DyeTestReq") >= 0 ? true : false);
            grdJLNavigator.Columns[61].Visible = (columnsToDisplay.IndexOf("DyeTestComplete") >= 0 ? true : false);
            grdJLNavigator.Columns[62].Visible = (columnsToDisplay.IndexOf("ContractYear") >= 0 ? true : false);

            cbxId.Checked = (columnsToDisplay2.IndexOf("SectionID") >= 0 ? true : false);
            cbxOldCwpId.Checked = (columnsToDisplay2.IndexOf("OriginalSectionID") >= 0 ? true : false);
            cbxClientLateralId.Checked = (columnsToDisplay2.IndexOf("ClientLateralId") >= 0 ? true : false);
            cbxHamiltonInspectionNumber.Checked = (columnsToDisplay2.IndexOf("HamiltonInspectionNumber") >= 0 ? true : false);
            cbxStreet.Checked = (columnsToDisplay2.IndexOf("Street") >= 0 ? true : false);
            cbxAddress.Checked = (columnsToDisplay2.IndexOf("MN") >= 0 ? true : false);
            cbxUSMH.Checked = (columnsToDisplay2.IndexOf("U_SMH") >= 0 ? true : false);
            cbxDSMH.Checked = (columnsToDisplay2.IndexOf("D_SMH") >= 0 ? true : false);
            cbxVideoInspection.Checked = (columnsToDisplay2.IndexOf("VideoInspection") >= 0 ? true : false);
            cbxVideoLengthToPropertyLine.Checked = (columnsToDisplay2.IndexOf("VideoLengthToPropertyLine") >= 0 ? true : false);
            cbxDepthOfLocated.Checked = (columnsToDisplay2.IndexOf("DepthOfLocated") >= 0 ? true : false);
            cbxPipeLocated.Checked = (columnsToDisplay2.IndexOf("PipeLocated") >= 0 ? true : false);
            cbxServicesLocated.Checked = (columnsToDisplay2.IndexOf("ServicesLocated") >= 0 ? true : false);
            //cbxCoRequired.Checked = (columnsToDisplay2.IndexOf("CoRequired") >= 0 ? true : false);
            //cbxPitRequired.Checked = (columnsToDisplay2.IndexOf("PitRequired") >= 0 ? true : false);
            cbxPrepType.Checked = (columnsToDisplay2.IndexOf("PrepType") >= 0 ? true : false);
            cbxCoPitLocation.Checked = (columnsToDisplay2.IndexOf("CoPitLocation") >= 0 ? true : false);
            cbxCoInstalled.Checked = (columnsToDisplay2.IndexOf("CoInstalled") >= 0 ? true : false);
            cbxBackfilledConcrete.Checked = (columnsToDisplay2.IndexOf("BackfilledConcrete") >= 0 ? true : false);
            cbxBackfilledSoil.Checked = (columnsToDisplay2.IndexOf("BackfilledSoil") >= 0 ? true : false);
            cbxGrouted.Checked = (columnsToDisplay2.IndexOf("Grouted") >= 0 ? true : false);
            cbxCored.Checked = (columnsToDisplay2.IndexOf("Cored") >= 0 ? true : false);
            cbxPrepped.Checked = (columnsToDisplay2.IndexOf("Prepped") >= 0 ? true : false);
            cbxPreVideo.Checked = (columnsToDisplay2.IndexOf("PreVideo") >= 0 ? true : false);
            cbxMeasured.Checked = (columnsToDisplay2.IndexOf("Measured") >= 0 ? true : false);
            cbxConnectionType.Checked = (columnsToDisplay2.IndexOf("ConnectionType") >= 0 ? true : false);
            cbxLinerType.Checked = (columnsToDisplay2.IndexOf("LinerType") >= 0 ? true : false);
            cbxFlange.Checked = (columnsToDisplay2.IndexOf("Flange") >= 0 ? true : false);
            cbxGasket.Checked = (columnsToDisplay2.IndexOf("Gasket") >= 0 ? true : false);
            cbxMainSize.Checked = (columnsToDisplay2.IndexOf("MainSize") >= 0 ? true : false);
            cbxLinerSize.Checked = (columnsToDisplay2.IndexOf("LinerSize") >= 0 ? true : false);
            //cbxLiningThruCo.Checked = (columnsToDisplay2.IndexOf("LiningThruCo") >= 0 ? true : false);
            cbxNoticeDelivered.Checked = (columnsToDisplay2.IndexOf("NoticeD_elivered") >= 0 ? true : false);
            cbxInProcess.Checked = (columnsToDisplay2.IndexOf("InProcess") >= 0 ? true : false);
            cbxInStock.Checked = (columnsToDisplay2.IndexOf("InStock") >= 0 ? true : false);
            cbxDelivered.Checked = (columnsToDisplay2.IndexOf("Delivered") >= 0 ? true : false);
            cbxLinerInstalled.Checked = (columnsToDisplay2.IndexOf("LinerInstalled") >= 0 ? true : false);
            cbxFinalVideo.Checked = (columnsToDisplay2.IndexOf("FinalVideo") >= 0 ? true : false);
            cbxDistanceFromUSMH.Checked = (columnsToDisplay2.IndexOf("DistanceFromUSMH") >= 0 ? true : false);
            cbxDistanceFromDSMH.Checked = (columnsToDisplay2.IndexOf("DistanceFromDSMH") >= 0 ? true : false);
            //cbxPostContractDigRequired.Checked = (columnsToDisplay2.IndexOf("PostContractDigRequired") >= 0 ? true : false);
            cbxCoCutDown.Checked = (columnsToDisplay2.IndexOf("CoCutDown") >= 0 ? true : false);
            cbxFinalRestoration.Checked = (columnsToDisplay2.IndexOf("FinalRestoration") >= 0 ? true : false);
            cbxCost.Checked = (columnsToDisplay2.IndexOf("Cost") >= 0 ? true : false);
            cbxBuidRebuid.Checked = (columnsToDisplay2.IndexOf("BuildRebuild") >= 0 ? true : false);
            cbxComments.Checked = (columnsToDisplay2.IndexOf("Comments") >= 0 ? true : false);
            cbxHistory.Checked = (columnsToDisplay2.IndexOf("History") >= 0 ? true : false);
            cbxDigRequiredPriorToLining.Checked = (columnsToDisplay2.IndexOf("DigRequiredPriorToLining") >= 0 ? true : false);
            cbxDigRequiredPriorToLiningCompleted.Checked = (columnsToDisplay2.IndexOf("DigRequiredPriorToLiningCompleted") >= 0 ? true : false);
            cbxDigRequiredAfterLining.Checked = (columnsToDisplay2.IndexOf("DigRequiredAfterLining") >= 0 ? true : false);
            cbxDigRequiredAfterLiningCompleted.Checked = (columnsToDisplay2.IndexOf("DigRequiredAfterLiningCompleted") >= 0 ? true : false);
            cbxOutOfScope.Checked = (columnsToDisplay2.IndexOf("OutOfScope") >= 0 ? true : false);
            cbxHoldClientIssue.Checked = (columnsToDisplay2.IndexOf("HoldClientIssue") >= 0 ? true : false);
            cbxHoldClientIssueResolved.Checked = (columnsToDisplay2.IndexOf("HoldClientIssueResolved") >= 0 ? true : false);
            cbxHoldLFSIssue.Checked = (columnsToDisplay2.IndexOf("HoldLFSIssue") >= 0 ? true : false);
            cbxHoldLFSIssueResolved.Checked = (columnsToDisplay2.IndexOf("HoldLFSIssueResolved") >= 0 ? true : false);
            cbxRequiresRoboticPrep.Checked = (columnsToDisplay2.IndexOf("LateralRequiresRoboticPrep") >= 0 ? true : false);
            cbxRequiresRoboticPrepCompleted.Checked = (columnsToDisplay2.IndexOf("LateralRequiresRoboticPrepCompleted") >= 0 ? true : false);
            cbxDyeTestReq.Checked = (columnsToDisplay2.IndexOf("DyeTestReq") >= 0 ? true : false);
            cbxDyeTestComplete.Checked = (columnsToDisplay2.IndexOf("DyeTestComplete") >= 0 ? true : false);
            cbxContractYear.Checked = (columnsToDisplay2.IndexOf("ContractYear") >= 0 ? true : false);
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



        private JlNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";
            string conditionValue2 = "";
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());

            // ... Load data for condition 1
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);
            conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));

            // ... If condition 2 exists
            if (ddlCondition2.SelectedValue != "-1")
            {
                // ... Load data for condition 2
                WorkTypeViewConditionGateway workTypeViewConditionGateway2 = new WorkTypeViewConditionGateway();
                workTypeViewConditionGateway2.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition2.SelectedValue), companyId);
                conditionValue2 = workTypeViewConditionGateway2.GetColumn_(workType, companyId, int.Parse(ddlCondition2.SelectedValue));
            }

            JlNavigator jlNavigator = new JlNavigator();
            jlNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), conditionValue2, tbxCondition2.Text.Trim(), companyId, currentProjectId, workType);

            return (JlNavigatorTDS)jlNavigator.Data;
        }



        private JlNavigatorTDS SubmitSearchForViews()
        {
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

            JlNavigator jlNavigator = new JlNavigator();
            string workType = "Junction Lining Lateral";
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());

            // ... Load SqlCommand
            WorkViewGateway workViewGateway = new WorkViewGateway();
            workViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = workViewGateway.GetSqlCommand(viewId);

            // ... Load data
            jlNavigator.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, currentProjectId, companyId, workType);

            return (JlNavigatorTDS)jlNavigator.Data;
        }

        

        private string GetWhereClause()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // General conditions
            string whereClause = "(LW.Deleted = 0) AND (LW.COMPANY_ID = " + companyId + ") AND (LWJLS.Deleted = 0) AND (LWJLS.COMPANY_ID = " + companyId + ") AND (AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ")";
            whereClause = whereClause + "AND (LW.ProjectID = " + hdfCurrentProjectId.Value + ") AND (LW.WorkType='Junction Lining Lateral') ";

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

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, conditionId);
            string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, conditionId);

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "AM_ASSET_SEWER_LATERAL") tableName = "AASL";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK_JUNCTIONLINING_SECTION") tableName = "LWJLS";
            if (tableName == "LFS_WORK_JUNCTIONLINING_LATERAL") tableName = "LWJLL";
            if (tableName == "LFS_WORK") tableName = "LW";
            if (tableName == "LFS_ASSET_SEWER_LATERAL_CLIENT") tableName = "LASLC";
            if (tableName == "LFS_MIGRATED_SECTIONS") tableName = "LMS";
            if (conditionValue == "MN#") conditionValue = "Address";

            // ... FOR TEXT FIELDS
            if ((conditionValue == "SubArea") || (conditionValue == "Street") || (conditionValue == "FlowOrderID") || (conditionValue == "OriginalSectionID") || (conditionValue == "CoPitLocation") || (conditionValue == "LinerSize") || (conditionValue == "Address") || (conditionValue == "Comments") || (conditionValue == "History") || (conditionValue == "ClientLateralID") || (conditionValue == "HamiltonInspectionNumber") || (conditionValue == "LateralID") || (conditionValue == "ConnectionType") || (conditionValue == "Flange") || (conditionValue == "Gasket") || (conditionValue == "PrepType") || (conditionValue == "LinerType") || (conditionValue == "ContractYear"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    // Search
                    if (textForSearch == "%")
                    {
                        if (conditionValue != "LateralID")
                        {
                            whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                            whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                        }
                        else
                        {
                            whereClause = whereClause + " AND ((AASS.SectionID LIKE '%')";
                            whereClause = whereClause + " OR (AASS.SectionID IS NULL))";
                        }
                    }
                    else
                    {
                        if (textForSearch == "")
                        {
                            if (conditionValue != "LateralID")
                            {
                                whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                            }
                            else
                            {
                                whereClause = whereClause + " AND (AASS.SectionID IS NULL)";
                            }
                        }
                        else
                        {
                            if (textForSearch.Contains("\""))
                            {
                                if ((conditionValue == "Comments") || (conditionValue == "History"))
                                {
                                    textForSearch = textForSearch.Replace("'", "''");
                                    whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                                }
                                else
                                {
                                    if (conditionValue != "Gasket")
                                    {
                                        textForSearch = textForSearch.Replace("\"", "");
                                    }

                                    if (conditionValue != "LateralID")
                                    {
                                        whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " = '" + textForSearch + "')";
                                    }
                                    else
                                    {
                                        whereClause = whereClause + "AND (AASS.FlowOrderID + '-JL-' + AASL.LateralID = " + textForSearch + ")";
                                    }
                                }
                            }
                            else
                            {
                                textForSearch = textForSearch.Replace("'", "''");

                                if (conditionValue != "LateralID")
                                {
                                    whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                                }
                                else
                                {
                                    whereClause = whereClause + "AND (AASS.FlowOrderID + '-JL-' + AASL.LateralID LIKE '%" + textForSearch + "%')";
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
                        if (textForSearch == "")
                        {
                            if (conditionValue != "LateralID")
                            {
                                whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                                whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NOT NULL))";
                            }
                            else
                            {
                                whereClause = whereClause + " AND ((AASS.SectionID LIKE '%')";
                                whereClause = whereClause + " OR (AASS.SectionID IS NOT NULL))";
                            }
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                if (conditionValue != "LateralID")
                                {
                                    whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL)";
                                }
                                else
                                {
                                    whereClause = whereClause + " AND (AASS.SectionID IS NULL)";
                                }
                            }
                            else
                            {
                                if (textForSearch.Contains("\""))
                                {
                                    if ((conditionValue == "Comments") || (conditionValue == "History"))
                                    {
                                        textForSearch = textForSearch.Replace("'", "''");
                                        whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " NOT LIKE '%" + textForSearch + "%')";
                                        whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                                    }
                                    else
                                    {
                                        textForSearch = textForSearch.Replace("\"", "");

                                        if (conditionValue != "LateralID")
                                        {
                                            whereClause = whereClause + "AND ((" + tableName + "." + conditionValue + " <> '" + textForSearch + "')";
                                            whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                                        }
                                        else
                                        {
                                            whereClause = whereClause + "AND (( AASS.FlowOrderID + '-JL-' + AASL.LateralID <> " + textForSearch + ")";
                                            whereClause = whereClause + "OR (AASS.FlowOrderID + '-JL-' + AASL.LateralID IS NULL))";
                                        }
                                    }
                                }
                                else
                                {
                                    textForSearch = textForSearch.Replace("'", "''");

                                    if (conditionValue != "LateralID")
                                    {
                                        whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " NOT LIKE '%" + textForSearch + "%')";
                                        whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                                    }
                                    else
                                    {
                                        whereClause = whereClause + "AND ((AASS.FlowOrderID + '-JL-' + AASL.LateralID NOT LIKE '%" + textForSearch + "%')";
                                        whereClause = whereClause + "OR (AASS.FlowOrderID + '-JL-' + AASL.LateralID IS NULL))";
                                    }
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

            // FOR DATE FIELDS
            if ((conditionValue == "PipeLocated") || (conditionValue == "ServicesLocated") || (conditionValue == "CoInstalled") || (conditionValue == "BackfilledConcrete") || (conditionValue == "BackfilledSoil") || (conditionValue == "Grouted") || (conditionValue == "Cored") || (conditionValue == "Prepped") || (conditionValue == "Measured") || (conditionValue == "InProcess") || (conditionValue == "InStock") || (conditionValue == "Delivered") || (conditionValue == "PreVideo") || (conditionValue == "LinerInstalled") || (conditionValue == "FinalVideo") || (conditionValue == "CoCutDown") || (conditionValue == "VideoInspection") || (conditionValue == "FinalRestoration") || (conditionValue == "NoticeDelivered") || (conditionValue == "DigRequiredPriorToLiningCompleted") || (conditionValue == "DigRequiredAfterLiningCompleted") || (conditionValue == "HoldClientIssueResolved") || (conditionValue == "HoldLFSIssueResolved") || (conditionValue == "LateralRequiresRoboticPrepCompleted") || (conditionValue == "DyeTestComplete"))
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

            // ... FOR BOOLEAN FIELDS
            if ((conditionValue == "CoRequired") || (conditionValue == "PitRequired") || (conditionValue == "PostContractDigRequired") || (conditionValue == "LiningThruCo") || (conditionValue == "DigRequiredPriorToLining") || (conditionValue == "DigRequiredAfterLining") || (conditionValue == "OutOfScope") || (conditionValue == "HoldClientIssue") || (conditionValue == "HoldLFSIssue") || (conditionValue == "LateralRequiresRoboticPrep") || (conditionValue == "DyeTestReq"))
            {
                // ... For operator =
                if (operatorValue == "=")
                {
                    if (textForSearch != "")
                    {
                        if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                        {
                            whereClause = whereClause + " AND (" + conditionValue + " = 1)";
                        }
                        else
                        {
                            if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                            {
                                whereClause = whereClause + " AND (" + conditionValue + " = 0)";
                            }
                            else
                            {
                                if (textForSearch == "%")
                                {
                                    whereClause = whereClause + " AND ((" + conditionValue + " = 1) OR (" + conditionValue + " = 0))";
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
                                whereClause = whereClause + " AND (" + conditionValue + " = 0)";
                            }
                            else
                            {
                                if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                                {
                                    whereClause = whereClause + " AND(" + conditionValue + " = 1)";
                                }
                                else
                                {
                                    if (textForSearch == "%")
                                    {
                                        whereClause = whereClause + " AND ((" + conditionValue + " = 1) OR (" + conditionValue + " = 0))";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // ... FOR INTEGER AND DOUBLE FIELDS. (Build / Rebuild #, Cost)
            if ((conditionValue == "BuildRebuild") || (conditionValue == "Cost"))
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

            // ... FOR DISTANCE FIELDS (Video Length To PL, Depth Of Pipe, Main Size)
            if ((conditionValue == "VideoLengthToPropertyLine") || (conditionValue == "DepthOfLocated") || (conditionValue == "Size_"))
            {
                string textForSearch4 = textForSearch;
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
                            try
                            {
                                if (Convert.ToDouble(textForSearch) > 99)
                                {
                                    double newMainSize = Convert.ToDouble(textForSearch) * 0.03937;
                                    textForSearch = Convert.ToString(Math.Ceiling(newMainSize)) + "\"";
                                }
                            }
                            catch
                            {
                            }

                            string textForSearch2 = textForSearch;
                            string textForSearch3 = textForSearch;

                            if (textForSearch.Contains("\""))
                            {
                                textForSearch2 = textForSearch2.Replace("\"", "");
                                textForSearch3 = textForSearch3.Replace("\"", "in");
                            }
                            else
                            {
                                if (!textForSearch.Contains("in"))
                                {
                                    textForSearch2 = textForSearch2 + "\"";
                                    textForSearch3 = textForSearch3 + "in";
                                }
                                else
                                {
                                    textForSearch2 = textForSearch2.Replace("in", "\"");
                                    textForSearch3 = textForSearch3.Replace("in", "");
                                }
                            }

                            whereClause = whereClause + "AND ((" + tableName + "." + conditionValue + " = N'" + textForSearch + "') OR (" + tableName + "." + conditionValue + " = N'" + textForSearch2 + "') OR (" + tableName + "." + conditionValue + " = N'" + textForSearch3 + "') OR (" + tableName + "." + conditionValue + " = N'" + textForSearch4 + "') )";
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
                                whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + operatorValue + "'" + textForSearch + "'" + ")";
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
            // For tableName
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway();
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = workTypeViewSortGateway.GetColumn_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "AM_ASSET_SEWER_LATERAL") tableName = "AASL";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK_JUNCTIONLINING_SECTION") tableName = "LWJLS";
            if (tableName == "LFS_WORK_JUNCTIONLINING_LATERAL") tableName = "LWJLL";

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));
            
            string orderBy = "";
            if (columnName == "Date")
            {
                switch (conditionValue)
                {
                    case "VideoInspection":
                        orderBy = "LWJLL.VideoInspection DESC";
                        break;

                    case "PipeLocated":
                        orderBy = "LWJLL.PipeLocated DESC";
                        break;

                    case "ServicesLocated":
                        orderBy = "LWJLL.ServicesLocated DESC";
                        break;

                    case "CoInstalled":
                        orderBy = "LWJLL.CoInstalled DESC";
                        break;

                    case "BackfilledConcrete":
                        orderBy = "LWJLL.BackfilledConcrete DESC";
                        break;

                    case "BackfilledSoil":
                        orderBy = "LWJLL.BackfilledSoil DESC";
                        break;

                    case "Grouted":
                        orderBy = "LWJLL.Grouted DESC";
                        break;

                    case "Cored":
                        orderBy = "LWJLL.Cored DESC";
                        break;

                    case "Prepped":
                        orderBy = "LWJLL.Prepped DESC";
                        break;

                    case "Measured":
                        orderBy = "LWJLL.Measured DESC";
                        break;

                    case "InProcess":
                        orderBy = "LWJLL.InProcess DESC";
                        break;

                    case "InStock":
                        orderBy = "LWJLL.InStock DESC";
                        break;

                    case "Delivered":
                        orderBy = "LWJLL.Delivered DESC";
                        break;

                    case "PreVideo":
                        orderBy = "LWJLL.PreVideo DESC";
                        break;

                    case "LinerInstalled":
                        orderBy = "LWJLL.LinerInstalled DESC";
                        break;

                    case "FinalVideo":
                        orderBy = "LWJLL.FinalVideo DESC";
                        break;

                    case "CoCutDown":
                        orderBy = "LWJLL.CoCutDown DESC";
                        break;

                    case "FinalRestoration":
                        orderBy = "LWJLL.FinalRestoration DESC";
                        break;

                    case "NoticeDelivered":
                        orderBy = "LWJLL.NoticeDelivered DESC";
                        break;

                    default:
                        orderBy = "AASS.FlowOrderID ASC";
                        break;
                }
            }
            else
            {
                orderBy = tableName + "." + columnName;
            }

            return orderBy;
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



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                if (Validator.IsValidDouble(distance.ToString()))
                {
                    if (distance.ToString().Contains("-"))
                    {
                        string positiveValue = distance.ToString().Replace('-', ' ').Trim();
                        return "-" + string.Format("{0:0.0}", Convert.ToDouble(positiveValue));
                    }
                    else
                    {
                        return string.Format("{0:0.0}", Convert.ToDouble(distance));
                    }
                }
                else
                {
                    return distance.ToString();
                }
            }
            else
            {
                return "";
            }
        }



        private void PostPageChanges()
        {
            JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);

            // Update jlNavigator rows
            foreach (GridViewRow row in grdJLNavigator.Rows)
            {
                string assetIdLabel = ((Label)row.FindControl("lblAssetID")).Text.Trim();
                int assetId = Int32.Parse(assetIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                
                jlNavigator.Update(assetId, selected);
            }

            jlNavigator.Data.AcceptChanges();

            // Store datasets
            Session["jlNavigatorTDS"] = jlNavigatorTDS;
        }



        private ArrayList GetAssetIdArrayList()
        {
            ArrayList jlIdArrayList = new ArrayList();

            foreach (JlNavigatorTDS.JlNavigatorRow jlNavigatorRow in jlNavigatorTDS.JlNavigator)
            {
                if (jlNavigatorRow.Selected)
                {
                    jlIdArrayList.Add(new JlId(jlNavigatorRow.AssetID_, jlNavigatorRow.Section_));
                }
            }

            return jlIdArrayList;
        }



        private ArrayList GetSectionIdArrayList()
        {
            ArrayList jlIdArrayList = new ArrayList();

            foreach (JlNavigatorTDS.JlNavigatorRow jlNavigatorRow in jlNavigatorTDS.JlNavigator)
            {
                if (jlNavigatorRow.Selected)
                {
                    if (!jlIdArrayList.Contains(jlNavigatorRow.SectionID))
                    {
                        jlIdArrayList.Add(jlNavigatorRow.SectionID);
                    }
                }
            }

            return jlIdArrayList;
        }



        private int GetFirstSectionAssetId()
        {
            int assetId = 0;

            foreach (JlNavigatorTDS.JlNavigatorRow jlNavigatorRow in jlNavigatorTDS.JlNavigator)
            {
                if (jlNavigatorRow.Selected)
                {
                    assetId = jlNavigatorRow.AssetID;
                }
            }

            return assetId;
        }



        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
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
            string columnsToDisplay = "&columns_to_display=SectionID,";
            string columnsToDisplay2 = "&columns_to_display2=SectionID,";

            columnsToDisplay2 = columnsToDisplay2 + (cbxOldCwpId.Checked ? "OriginalSectionID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxClientLateralId.Checked ? "ClientLateralId," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHamiltonInspectionNumber.Checked ? "HamiltonInspectionNumber," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxStreet.Checked ? "Street," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxAddress.Checked ? "MN," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMH.Checked ? "U_SMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMH.Checked ? "D_SMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVideoInspection.Checked ? "VideoInspection," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVideoLengthToPropertyLine.Checked ? "VideoLengthToPropertyLine," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDepthOfLocated.Checked ? "DepthOfLocated," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPipeLocated.Checked ? "PipeLocated," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxServicesLocated.Checked ? "ServicesLocated," : "");
            //columnsToDisplay2 = columnsToDisplay2 + (cbxCoRequired.Checked ? "CoRequired," : "");
            //columnsToDisplay2 = columnsToDisplay2 + (cbxPitRequired.Checked ? "PitRequired," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPrepType.Checked ? "PrepType," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCoPitLocation.Checked ? "CoPitLocation," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCoInstalled.Checked ? "CoInstalled," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxBackfilledConcrete.Checked ? "BackfilledConcrete," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxBackfilledSoil.Checked ? "BackfilledSoil," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxGrouted.Checked ? "Grouted," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCored.Checked ? "Cored," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPrepped.Checked ? "Prepped," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPreVideo.Checked ? "PreVideo," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMeasured.Checked ? "Measured," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxConnectionType.Checked ? "ConnectionType," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLinerType.Checked ? "LinerType," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxFlange.Checked ? "Flange," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxGasket.Checked ? "Gasket," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMainSize.Checked ? "MainSize," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLinerSize.Checked ? "LinerSize," : "");
            //columnsToDisplay2 = columnsToDisplay2 + (cbxLiningThruCo.Checked ? "LiningThruCo," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxNoticeDelivered.Checked ? "NoticeD_elivered," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxInProcess.Checked ? "InProcess," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxInStock.Checked ? "InStock," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDelivered.Checked ? "Delivered," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLinerInstalled.Checked ? "LinerInstalled," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxFinalVideo.Checked ? "FinalVideo," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDistanceFromUSMH.Checked ? "DistanceFromUSMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDistanceFromDSMH.Checked ? "DistanceFromDSMH," : "");
            //columnsToDisplay2 = columnsToDisplay2 + (cbxPostContractDigRequired.Checked ? "PostContractDigRequired," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCoCutDown.Checked ? "CoCutDown," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxFinalRestoration.Checked ? "FinalRestoration," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCost.Checked ? "Cost," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxBuidRebuid.Checked ? "BuildRebuild," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxComments.Checked ? "Comments," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHistory.Checked ? "History," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDigRequiredPriorToLining.Checked ? "DigRequiredPriorToLining," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDigRequiredPriorToLiningCompleted.Checked ? "DigRequiredPriorToLiningCompleted," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDigRequiredAfterLining.Checked ? "DigRequiredAfterLining," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDigRequiredAfterLiningCompleted.Checked ? "DigRequiredAfterLiningCompleted," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxOutOfScope.Checked ? "OutOfScope," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHoldClientIssue.Checked ? "HoldClientIssue," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHoldClientIssueResolved.Checked ? "HoldClientIssueResolved," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHoldLFSIssue.Checked ? "HoldLFSIssue," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHoldLFSIssueResolved.Checked ? "HoldLFSIssueResolved," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRequiresRoboticPrep.Checked ? "LateralRequiresRoboticPrep," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxRequiresRoboticPrepCompleted.Checked ? "LateralRequiresRoboticPrepCompleted," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDyeTestReq.Checked ? "DyeTestReq," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDyeTestComplete.Checked ? "DyeTestComplete," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxContractYear.Checked ? "ContractYear," : "");
            columnsToDisplay2 = columnsToDisplay2.Substring(0, columnsToDisplay2.Length - 1);

            if (hdfBtnOrigin.Value == "Search")
            {
                columnsToDisplay = columnsToDisplay + (cbxOldCwpId.Checked ? "OriginalSectionID," : "");
                columnsToDisplay = columnsToDisplay + (cbxClientLateralId.Checked ? "ClientLateralId," : "");
                columnsToDisplay = columnsToDisplay + (cbxHamiltonInspectionNumber.Checked ? "HamiltonInspectionNumber," : "");                
                columnsToDisplay = columnsToDisplay + (cbxStreet.Checked ? "Street," : "");
                columnsToDisplay = columnsToDisplay + (cbxAddress.Checked ? "MN," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMH.Checked ? "U_SMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMH.Checked ? "D_SMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxVideoInspection.Checked ? "VideoInspection," : "");
                columnsToDisplay = columnsToDisplay + (cbxVideoLengthToPropertyLine.Checked ? "VideoLengthToPropertyLine," : "");
                columnsToDisplay = columnsToDisplay + (cbxDepthOfLocated.Checked ? "DepthOfLocated," : "");
                columnsToDisplay = columnsToDisplay + (cbxPipeLocated.Checked ? "PipeLocated," : "");
                columnsToDisplay = columnsToDisplay + (cbxServicesLocated.Checked ? "ServicesLocated," : "");
                //columnsToDisplay = columnsToDisplay + (cbxCoRequired.Checked ? "CoRequired," : "");
                //columnsToDisplay = columnsToDisplay + (cbxPitRequired.Checked ? "PitRequired," : "");
                columnsToDisplay = columnsToDisplay + (cbxPrepType.Checked ? "PrepType," : "");
                columnsToDisplay = columnsToDisplay + (cbxCoPitLocation.Checked ? "CoPitLocation," : "");
                columnsToDisplay = columnsToDisplay + (cbxCoInstalled.Checked ? "CoInstalled," : "");
                columnsToDisplay = columnsToDisplay + (cbxBackfilledConcrete.Checked ? "BackfilledConcrete," : "");
                columnsToDisplay = columnsToDisplay + (cbxBackfilledSoil.Checked ? "BackfilledSoil," : "");
                columnsToDisplay = columnsToDisplay + (cbxGrouted.Checked ? "Grouted," : "");
                columnsToDisplay = columnsToDisplay + (cbxCored.Checked ? "Cored," : "");
                columnsToDisplay = columnsToDisplay + (cbxPrepped.Checked ? "Prepped," : "");
                columnsToDisplay = columnsToDisplay + (cbxPreVideo.Checked ? "PreVideo," : "");
                columnsToDisplay = columnsToDisplay + (cbxMeasured.Checked ? "Measured," : "");
                columnsToDisplay = columnsToDisplay + (cbxConnectionType.Checked ? "ConnectionType," : "");
                columnsToDisplay = columnsToDisplay + (cbxLinerType.Checked ? "LinerType," : "");
                columnsToDisplay = columnsToDisplay + (cbxFlange.Checked ? "Flange," : "");
                columnsToDisplay = columnsToDisplay + (cbxGasket.Checked ? "Gasket," : "");
                columnsToDisplay = columnsToDisplay + (cbxMainSize.Checked ? "MainSize," : "");
                columnsToDisplay = columnsToDisplay + (cbxLinerSize.Checked ? "LinerSize," : "");
                //columnsToDisplay = columnsToDisplay + (cbxLiningThruCo.Checked ? "LiningThruCo," : "");
                columnsToDisplay = columnsToDisplay + (cbxNoticeDelivered.Checked ? "NoticeD_elivered," : "");
                columnsToDisplay = columnsToDisplay + (cbxInProcess.Checked ? "InProcess," : "");
                columnsToDisplay = columnsToDisplay + (cbxInStock.Checked ? "InStock," : "");
                columnsToDisplay = columnsToDisplay + (cbxDelivered.Checked ? "Delivered," : "");
                columnsToDisplay = columnsToDisplay + (cbxLinerInstalled.Checked ? "LinerInstalled," : "");
                columnsToDisplay = columnsToDisplay + (cbxFinalVideo.Checked ? "FinalVideo," : "");
                columnsToDisplay = columnsToDisplay + (cbxDistanceFromUSMH.Checked ? "DistanceFromUSMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxDistanceFromDSMH.Checked ? "DistanceFromDSMH," : "");
                //columnsToDisplay = columnsToDisplay + (cbxPostContractDigRequired.Checked ? "PostContractDigRequired," : "");
                columnsToDisplay = columnsToDisplay + (cbxCoCutDown.Checked ? "CoCutDown," : "");
                columnsToDisplay = columnsToDisplay + (cbxFinalRestoration.Checked ? "FinalRestoration," : "");
                columnsToDisplay = columnsToDisplay + (cbxCost.Checked ? "Cost," : "");
                columnsToDisplay = columnsToDisplay + (cbxBuidRebuid.Checked ? "BuildRebuild," : "");
                columnsToDisplay = columnsToDisplay + (cbxComments.Checked ? "Comments," : "");
                columnsToDisplay = columnsToDisplay + (cbxHistory.Checked ? "History," : "");
                columnsToDisplay = columnsToDisplay + (cbxDigRequiredPriorToLining.Checked ? "DigRequiredPriorToLining," : "");
                columnsToDisplay = columnsToDisplay + (cbxDigRequiredPriorToLiningCompleted.Checked ? "DigRequiredPriorToLiningCompleted," : "");
                columnsToDisplay = columnsToDisplay + (cbxDigRequiredAfterLining.Checked ? "DigRequiredAfterLining," : "");
                columnsToDisplay = columnsToDisplay + (cbxDigRequiredAfterLiningCompleted.Checked ? "DigRequiredAfterLiningCompleted," : "");
                columnsToDisplay = columnsToDisplay + (cbxOutOfScope.Checked ? "OutOfScope," : "");
                columnsToDisplay = columnsToDisplay + (cbxHoldClientIssue.Checked ? "HoldClientIssue," : "");
                columnsToDisplay = columnsToDisplay + (cbxHoldClientIssueResolved.Checked ? "HoldClientIssueResolved," : "");
                columnsToDisplay = columnsToDisplay + (cbxHoldLFSIssue.Checked ? "HoldLFSIssue," : "");
                columnsToDisplay = columnsToDisplay + (cbxHoldLFSIssueResolved.Checked ? "HoldLFSIssueResolved," : "");
                columnsToDisplay = columnsToDisplay + (cbxRequiresRoboticPrep.Checked ? "LateralRequiresRoboticPrep," : "");
                columnsToDisplay = columnsToDisplay + (cbxRequiresRoboticPrepCompleted.Checked ? "LateralRequiresRoboticPrepCompleted," : "");
                columnsToDisplay = columnsToDisplay + (cbxDyeTestReq.Checked ? "DyeTestReq," : "");
                columnsToDisplay = columnsToDisplay + (cbxDyeTestComplete.Checked ? "DyeTestComplete," : "");
                columnsToDisplay = columnsToDisplay + (cbxContractYear.Checked ? "ContractYear," : "");
                columnsToDisplay = columnsToDisplay.Substring(0, columnsToDisplay.Length - 1);
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

            return columnsToDisplay+columnsToDisplay2;
        }

        
        
    }
}