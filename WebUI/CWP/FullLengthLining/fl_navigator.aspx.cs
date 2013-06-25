using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_navigator
    /// </summary>
    public partial class fl_navigator : System.Web.UI.Page
    {
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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_navigator.aspx");
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
                workTypeViewSubAreaList.LoadAndAddItem("Full Length Lining", Int32.Parse(hdfCompanyId.Value), int.Parse(hdfCurrentProjectId.Value), "(All)");
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
                // ... Left Menu or select_project
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "select_project.aspx"))
                {
                    tdNoResults.Visible = false;
                }

                // ... fl_navigator2.aspx
                if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                {
                    RestoreNavigatorState();
                    if ((string)Request.QueryString["no_results"] == "yes")
                    {
                        tdNoResults.Visible = true;
                    }
                    else
                    {
                        tdNoResults.Visible = false;
                    }
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Tag Page
            hdfBtnOrigin.Value = "Search";

            Page.Validate();

            // Get data from DA gateway
            if (Page.IsValid)
            {
                FlNavigatorTDS flNavigatorTDS = SubmitSearch();

                // Show results
                if (flNavigatorTDS.FlNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["flNavigatorTDS"] = flNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./fl_navigator2.aspx?source_page=fl_navigator.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState());
                }
                else
                {
                    tdNoResults.Visible = true;
                }
            }
        }



        protected void btnGo_Click(object sender, EventArgs e)
        {
            // Tag Page
            hdfBtnOrigin.Value = "Go";

            // Get data from DA gateway
            if (Page.IsValid)
            {
                FlNavigatorTDS flNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (flNavigatorTDS.FlNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["flNavigatorTDS"] = flNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./fl_navigator2.aspx?source_page=fl_navigator.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState());
                }
                else
                {
                    tdNoResults.Visible = true;
                }
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
            if (Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"]))
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = true; // Resins option
                tkrpbLeftMenuTools.Items[0].Items[2].Visible = true; // Catalyst option
            }
            else
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Resins option
                tkrpbLeftMenuTools.Items[0].Items[2].Visible = false; // Catalyst option
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void cvInvalidOperator_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Operator for Text and boolean fields
            if ((ddlCondition1.SelectedItem.Text == "ID (Section)") || (ddlCondition1.SelectedItem.Text == "Old CWP ID") || (ddlCondition1.SelectedItem.Text == "Sub Area") || (ddlCondition1.SelectedItem.Text == "Street") || (ddlCondition1.SelectedItem.Text == "USMH") || (ddlCondition1.SelectedItem.Text == "USMH Address") || (ddlCondition1.SelectedItem.Text == "DSMH") || (ddlCondition1.SelectedItem.Text == "DSMH Address") || (ddlCondition1.SelectedItem.Text == "Map Size") || (ddlCondition1.SelectedItem.Text == "Confirmed Size") || (ddlCondition1.SelectedItem.Text == "Map Length") || (ddlCondition1.SelectedItem.Text == "Steel Tape Length") || (ddlCondition1.SelectedItem.Text == "Video Length") || (ddlCondition1.SelectedItem.Text == "Client ID") || (ddlCondition1.SelectedItem.Text == "Measurements Taken By") || (ddlCondition1.SelectedItem.Text == "Traffic Control") || (ddlCondition1.SelectedItem.Text == "Material") || (ddlCondition1.SelectedItem.Text == "Bypass Required?") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Required?") || (ddlCondition1.SelectedItem.Text == "Robotic Distances") || (ddlCondition1.SelectedItem.Text == "Issue Identified?") || (ddlCondition1.SelectedItem.Text == "LFS Issue?") || (ddlCondition1.SelectedItem.Text == "Client Issue?") || (ddlCondition1.SelectedItem.Text == "Sales Issue?") || (ddlCondition1.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition1.SelectedItem.Text == "Issue Investigation?") || (ddlCondition1.SelectedItem.Text == "Issue Resolved?") || (ddlCondition1.SelectedItem.Text == "Comments") || (ddlCondition1.SelectedItem.Text == "Repair Type") || (ddlCondition1.SelectedItem.Text == "Defect Qualifier") || (ddlCondition1.SelectedItem.Text == "Defect Details") || (ddlCondition1.SelectedItem.Text == "Extra Repair") || (ddlCondition1.SelectedItem.Text == "Cancelled") || (ddlCondition1.SelectedItem.Text == "Approval") || (ddlCondition1.SelectedItem.Text == "Repair Comments") || (ddlCondition1.SelectedItem.Text == "Ream Distance") || (ddlCondition1.SelectedItem.Text == "Liner Distance") || (ddlCondition1.SelectedItem.Text == "Direction") || (ddlCondition1.SelectedItem.Text == "LT @ MH") || (ddlCondition1.SelectedItem.Text == "VT @ MH") || (ddlCondition1.SelectedItem.Text == "Distance") || (ddlCondition1.SelectedItem.Text == "Repair Size") || (ddlCondition1.SelectedItem.Text == "Repair Length") || (ddlCondition1.SelectedItem.Text == "MH Shot?") || (ddlCondition1.SelectedItem.Text == "Grout Distance"))
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
            if ((ddlCondition1.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition1.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "M1 Date") || (ddlCondition1.SelectedItem.Text == "M2 Date") || (ddlCondition1.SelectedItem.Text == "Install Date") || (ddlCondition1.SelectedItem.Text == "Final Video Date") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Date") || (ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "Brushed") || (ddlCondition1.SelectedItem.Text == "Opened"))
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
            if ((ddlCondition1.SelectedItem.Text == "Proposed Lining Date") || (ddlCondition1.SelectedItem.Text == "Deadline Lining Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "M1 Date") || (ddlCondition1.SelectedItem.Text == "M2 Date") || (ddlCondition1.SelectedItem.Text == "Install Date") || (ddlCondition1.SelectedItem.Text == "Final Video Date") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Date") || (ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "Brushed") || (ddlCondition1.SelectedItem.Text == "Opened"))
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
            if ((ddlCondition1.SelectedItem.Text == "Issue Identified?") || (ddlCondition1.SelectedItem.Text == "LFS Issue?") || (ddlCondition1.SelectedItem.Text == "Client Issue?") 
                || (ddlCondition1.SelectedItem.Text == "Sales Issue?") || (ddlCondition1.SelectedItem.Text == "Issue Given To Client?") || (ddlCondition1.SelectedItem.Text == "Issue Investigation?") 
                || (ddlCondition1.SelectedItem.Text == "Issue Resolved?") || (ddlCondition1.SelectedItem.Text == "Pipe Size Change?") || (ddlCondition1.SelectedItem.Text == "Standard Bypass?") 
                || (ddlCondition1.SelectedItem.Text == "Drop Pipe") || (ddlCondition1.SelectedItem.Text == "Hydro Pulley?") || (ddlCondition1.SelectedItem.Text == "Fridge Cart?")
                || (ddlCondition1.SelectedItem.Text == "2\" Pump?") || (ddlCondition1.SelectedItem.Text == "6\" Bypass?") || (ddlCondition1.SelectedItem.Text == "Scaffolding?")
                || (ddlCondition1.SelectedItem.Text == "Winch Extension?") || (ddlCondition1.SelectedItem.Text == "Extra Generator?") || (ddlCondition1.SelectedItem.Text == "Grey Cable Extension?")
                || (ddlCondition1.SelectedItem.Text == "Easement Mats?") || (ddlCondition1.SelectedItem.Text == "Ramps Required?") || (ddlCondition1.SelectedItem.Text == "Camera Skid?"))
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
            if ((ddlCondition1.SelectedItem.Text == "Laterals") || (ddlCondition1.SelectedItem.Text == "Live Laterals") || (ddlCondition1.SelectedItem.Text == "CXI's Removed") || (ddlCondition1.SelectedItem.Text == "Capped Laterals"))
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

            UpdateDatabase();

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
            Response.Redirect("./../Common/select_project.aspx?source_page=fl_navigator.aspx&work_type=" + hdfWorkType.Value.Trim());
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fl_navigator.js");
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

            cbxIdSection.Checked = (columnsToDisplay2.IndexOf(" SectionID,") >= 0 ? true : false);
            cbxOldCWPID.Checked = (columnsToDisplay2.IndexOf("OriginalSectionID") >= 0 ? true : false);
            cbxSubArea.Checked = (columnsToDisplay2.IndexOf("SubArea") >= 0 ? true : false);
            cbxStreet.Checked = (columnsToDisplay2.IndexOf("Street") >= 0 ? true : false);
            cbxUsmh.Checked = (columnsToDisplay2.IndexOf(" USMH,") >= 0 ? true : false);
            cbxDsmh.Checked = (columnsToDisplay2.IndexOf(" DSMH") >= 0 ? true : false);
            cbxProposedLiningDate.Checked = (columnsToDisplay2.IndexOf("ProposedLiningDate") >= 0 ? true : false);
            cbxDeadlineLiningDate.Checked = (columnsToDisplay2.IndexOf("DeadlineLiningDate") >= 0 ? true : false);
            cbxP1Date.Checked = (columnsToDisplay2.IndexOf("P1Date") >= 0 ? true : false);
            cbxM1Date.Checked = (columnsToDisplay2.IndexOf("M1Date") >= 0 ? true : false);
            cbxM2Date.Checked = (columnsToDisplay2.IndexOf("M2Date") >= 0 ? true : false);
            cbxInstallDate.Checked = (columnsToDisplay2.IndexOf("InstallDate") >= 0 ? true : false);
            cbxFinalVideoDate.Checked = (columnsToDisplay2.IndexOf("FinalVideoDate") >= 0 ? true : false);
            cbxConfirmedSize.Checked = (columnsToDisplay2.IndexOf("Size_") >= 0 ? true : false);
            cbxActualLength.Checked = (columnsToDisplay2.IndexOf("ActualLength") >= 0 ? true : false);
            cbxComments.Checked = (columnsToDisplay2.IndexOf(" Comments") >= 0 ? true : false);
            cbxMapSize.Checked = (columnsToDisplay2.IndexOf("MapSize") >= 0 ? true : false);
            cbxMapLength.Checked = (columnsToDisplay2.IndexOf("MapLength") >= 0 ? true : false);
            cbxVideoLength.Checked = (columnsToDisplay2.IndexOf("VideoLength") >= 0 ? true : false);
            cbxLaterals.Checked = (columnsToDisplay2.IndexOf(" Laterals") >= 0 ? true : false);
            cbxLiveLaterals.Checked = (columnsToDisplay2.IndexOf("LiveLaterals") >= 0 ? true : false);
            cbxClientID.Checked = (columnsToDisplay2.IndexOf("ClientID") >= 0 ? true : false);
            cbxPreFlushDate.Checked = (columnsToDisplay2.IndexOf("PreFlushDate") >= 0 ? true : false);
            cbxPreVideoDate.Checked = (columnsToDisplay2.IndexOf("PreVideoDate") >= 0 ? true : false);
            cbxIssueIdentified.Checked = (columnsToDisplay2.IndexOf("IssueIdentified") >= 0 ? true : false);
            cbxLFSIssue.Checked = (columnsToDisplay2.IndexOf("IssueLFS") >= 0 ? true : false);
            cbxClientIssue.Checked = (columnsToDisplay2.IndexOf("IssueClient") >= 0 ? true : false);
            cbxSalesIssue.Checked = (columnsToDisplay2.IndexOf("IssueSales") >= 0 ? true : false);
            cbxIssueGivenToClient.Checked = (columnsToDisplay2.IndexOf("IssueGivenToClient") >= 0 ? true : false);
            cbxIssueInvestigation.Checked = (columnsToDisplay2.IndexOf("IssueInvestigation") >= 0 ? true : false);
            cbxIssueResolved.Checked = (columnsToDisplay2.IndexOf("IssueResolved") >= 0 ? true : false);
            cbxCXIsRemoved.Checked = (columnsToDisplay2.IndexOf("CXIsRemoved") >= 0 ? true : false);
            cbxMaterial.Checked = (columnsToDisplay2.IndexOf("MaterialType") >= 0 ? true : false);
            cbxUSMHAddress.Checked = (columnsToDisplay2.IndexOf("USMHAddress") >= 0 ? true : false);
            cbxUSMHDepth.Checked = (columnsToDisplay2.IndexOf("USMHDepth") >= 0 ? true : false);
            cbxUSMHMouth12.Checked = (columnsToDisplay2.IndexOf("USMHMouth12") >= 0 ? true : false);
            cbxUSMHMouth1.Checked = (columnsToDisplay2.IndexOf("USMHMouth1,") >= 0 ? true : false);
            cbxUSMHMouth2.Checked = (columnsToDisplay2.IndexOf("USMHMouth2") >= 0 ? true : false);
            cbxUSMHMouth3.Checked = (columnsToDisplay2.IndexOf("USMHMouth3") >= 0 ? true : false);
            cbxUSMHMouth4.Checked = (columnsToDisplay2.IndexOf("USMHMouth4") >= 0 ? true : false);
            cbxUSMHMouth5.Checked = (columnsToDisplay2.IndexOf("USMHMouth5") >= 0 ? true : false);
            cbxDSMHAddress.Checked = (columnsToDisplay2.IndexOf("DSMHAddress") >= 0 ? true : false);
            cbxDSMHDepth.Checked = (columnsToDisplay2.IndexOf("DSMHDepth") >= 0 ? true : false);
            cbxDSMHMouth12.Checked = (columnsToDisplay2.IndexOf("DSMHMouth12") >= 0 ? true : false);
            cbxDSMHMouth1.Checked = (columnsToDisplay2.IndexOf("DSMHMouth1,") >= 0 ? true : false);
            cbxDSMHMouth2.Checked = (columnsToDisplay2.IndexOf("DSMHMouth2") >= 0 ? true : false);
            cbxDSMHMouth3.Checked = (columnsToDisplay2.IndexOf("DSMHMouth3") >= 0 ? true : false);
            cbxDSMHMouth4.Checked = (columnsToDisplay2.IndexOf("DSMHMouth4") >= 0 ? true : false);
            cbxDSMHMouth5.Checked = (columnsToDisplay2.IndexOf("DSMHMouth5") >= 0 ? true : false);
            cbxTrafficControl.Checked = (columnsToDisplay2.IndexOf("TrafficControl,") >= 0 ? true : false);
            cbxSiteDetails.Checked = (columnsToDisplay2.IndexOf("SiteDetails") >= 0 ? true : false);
            cbxPipeSizeChange.Checked = (columnsToDisplay2.IndexOf("PipeSizeChange") >= 0 ? true : false);
            cbxStandardBypass.Checked = (columnsToDisplay2.IndexOf("StandardBypass,") >= 0 ? true : false);
            cbxStandardBypassComments.Checked = (columnsToDisplay2.IndexOf("StandardBypassComments") >= 0 ? true : false);            
            cbxTrafficControlDetails.Checked = (columnsToDisplay2.IndexOf("TrafficControlDetails") >= 0 ? true : false);
            cbxMeasurementType.Checked = (columnsToDisplay2.IndexOf("MeasurementType") >= 0 ? true : false);
            cbxMeasuredFromMH.Checked = (columnsToDisplay2.IndexOf("MeasurementFromMH") >= 0 ? true : false);
            cbxVideoDoneFromMH.Checked = (columnsToDisplay2.IndexOf("VideoDoneFromMH") >= 0 ? true : false);
            cbxVideoDoneToMH.Checked = (columnsToDisplay2.IndexOf("VideoDoneToMH") >= 0 ? true : false);
            cbxM1MeasurementsTakenBy.Checked = (columnsToDisplay2.IndexOf("M1MeasurementTakenBy") >= 0 ? true : false);
            cbxM2MeasurementsTakenBy.Checked = (columnsToDisplay2.IndexOf("M2MeasurementTakenBy") >= 0 ? true : false);
            cbxDropPipe.Checked = (columnsToDisplay2.IndexOf("DropPipe,") >= 0 ? true : false);
            cbxDropPipeInvertDepth.Checked = (columnsToDisplay2.IndexOf("DropPipeInvertDepth") >= 0 ? true : false);
            cbxCappedLaterals.Checked = (columnsToDisplay2.IndexOf("CappedLaterals") >= 0 ? true : false);
            cbxLineWidthID.Checked = (columnsToDisplay2.IndexOf("LineWithID") >= 0 ? true : false);
            cbxHydrantAddress.Checked = (columnsToDisplay2.IndexOf("HydrantAddress") >= 0 ? true : false);
            cbxHydrantDistanceToInversionMH.Checked = (columnsToDisplay2.IndexOf("DistanceToInversionMH") >= 0 ? true : false);
            cbxHydroWireWithin10FtOfInversionMH.Checked = (columnsToDisplay2.IndexOf("HydroWireWithin10FtOfInversionMH") >= 0 ? true : false);
            cbxSurfaceGrade.Checked = (columnsToDisplay2.IndexOf("SurfaceGrade") >= 0 ? true : false);
            cbxHydroPulley.Checked = (columnsToDisplay2.IndexOf("HydroPulley") >= 0 ? true : false);
            cbxFridgeCart.Checked = (columnsToDisplay2.IndexOf("FridgeCart") >= 0 ? true : false);
            cbx2InchPump.Checked = (columnsToDisplay2.IndexOf("TwoPump") >= 0 ? true : false);
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



        private FlNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue1 = "";
            string conditionValue2 = "";
            string name = "";

            FlNavigator flNavigator = new FlNavigator();
            string workType = hdfWorkType.Value.Trim();
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
            flNavigator.Load(whereClause, orderByClause, conditionValue1, tbxCondition1.Text.Trim(), conditionValue2, tbxCondition2.Text.Trim(), companyId, currentProjectId, workType, name);

            return (FlNavigatorTDS)flNavigator.Data;
        }



        private FlNavigatorTDS SubmitSearchForViews()
        {
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim()); 
            
            FlNavigator flNavigator = new FlNavigator();
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());

            // ... Load SqlCommand
            WorkViewGateway workViewGateway = new WorkViewGateway();
            workViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = workViewGateway.GetSqlCommand(viewId);

            // ... Load data
            flNavigator.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, currentProjectId, companyId, workType);

            return (FlNavigatorTDS)flNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LW.Deleted = 0) AND (LW.COMPANY_ID = " + companyId + ") AND (LWF.Deleted = 0) AND (LWF.COMPANY_ID = " + companyId + ") AND (AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ")";
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

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, conditionId);
            string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, conditionId);

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_WORK_REHABASSESSMENT") tableName = "LWR";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK") tableName = "LW";
            if (tableName == "LFS_MIGRATED_SECTIONS") tableName = "LMS";
            if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWF";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M1") tableName = "LWFM1";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M1_LATERAL") tableName = "LWFLLM1L";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M2") tableName = "LWFLLM2";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_P1") tableName = "LWFLP1";
            if (conditionValue == "USMHAddress") { tableName = "AASUSMH"; conditionValue = "Address"; }
            if (conditionValue == "DSMHAddress") { tableName = "AASDSMH"; conditionValue = "Address"; }

            // FOR TEXT FIELDS. (SubArea, Street, Id(Section), OriginalSectionID, Comments, .....)
            if ((conditionValue == "SubArea") || (conditionValue == "Street") || (conditionValue == "FlowOrderID") || (conditionValue == "OriginalSectionID") || (conditionValue == "Comments")
                || (conditionValue == "MapSize") || (conditionValue == "Size_") || (conditionValue == "MapLength") || (conditionValue == "Length") || (conditionValue == "VideoLength") || (conditionValue == "ClientID") || (conditionValue == "MeasurementTakenBy")
                || (conditionValue == "Address") || (conditionValue == "USMHDepth") || (conditionValue == "USMHMouth12") || (conditionValue == "USMHMouth1") || (conditionValue == "USMHMouth2") || (conditionValue == "USMHMouth3") || (conditionValue == "USMHMouth4")
                || (conditionValue == "USMHMouth5") || (conditionValue == "DSMHDepth") || (conditionValue == "DSMHMouth12") || (conditionValue == "DSMHMouth1") || (conditionValue == "DSMHMouth2") || (conditionValue == "DSMHMouth3")
                || (conditionValue == "DSMHMouth4") || (conditionValue == "DSMHMouth5") || (conditionValue == "TrafficControl") || (conditionValue == "SiteDetails") || (conditionValue == "StandardBypassComments")
                || (conditionValue == "TrafficControlDetails") || (conditionValue == "MeasurementType") || (conditionValue == "MeasurementFromMH") || (conditionValue == "VideoDoneFromMH") || (conditionValue == "VideoDoneToMH") || (conditionValue == "Thickness"))
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

            // FOR DATE FIELDS. (ProposedLiningDate, DeadlineLiningDate, P1Date, M1Date, M2Date, InstallDate, FinalVideoDate,  PreFlushDate and PreVideoDate)
            if ((conditionValue == "ProposedLiningDate") || (conditionValue == "DeadlineLiningDate") || (conditionValue == "P1Date") || (conditionValue == "M1Date") || (conditionValue == "M2Date") 
                || (conditionValue == "InstallDate") || (conditionValue == "FinalVideoDate") ||  (conditionValue == "PreFlushDate") || (conditionValue == "Reinstate") || (conditionValue == "TimeOpened")
                || (conditionValue == "PreVideoDate") || (conditionValue == "RoboticPrepCompletedDate"))
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

            // FOR BOOLEAN FIELDS
            if ((conditionValue == "IssueIdentified") || (conditionValue == "IssueLFS") || (conditionValue == "IssueClient") || (conditionValue == "IssueSales") || (conditionValue == "IssueGivenToClient") || (conditionValue == "IssueInvestigation") || (conditionValue == "IssueResolved")
                || (conditionValue == "PipeSizeChange") || (conditionValue == "StandardBypass") || (conditionValue == "DropPipe") || (conditionValue == "HydroPulley") || (conditionValue == "FridgeCart") || (conditionValue == "TwoPump") || (conditionValue == "SixBypass")
                || (conditionValue == "Scaffolding") || (conditionValue == "WinchExtention") || (conditionValue == "ExtraGenerator") || (conditionValue == "GreyCableExtension") || (conditionValue == "EasementMats") || (conditionValue == "RampRequired") || (conditionValue == "CameraSkid")
                || (conditionValue == "RoboticPrepCompleted"))
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

            // FOR INTEGER AND DOUBLE FIELDS. (Laterals, LiveLaterals, CXIsRemoved and CappedLaterals)
            if ((conditionValue == "Laterals") || (conditionValue == "LiveLaterals") || (conditionValue == "CXIsRemoved") || (conditionValue == "CappedLaterals"))
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
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway();
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = workTypeViewSortGateway.GetColumn_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));
            
            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWF";           
            
            // Get order by clause
            string orderBy = "";

            if (columnName == "Date")
            {
                switch (conditionValue)
                {
                    case "ProposedLiningDate":
                        orderBy = "LWF.ProposedLiningDate DESC";
                        break;

                    case "DeadlineLiningDate":
                        orderBy = "LWF.DeadlineLiningDate DESC";
                        break;

                    case "P1Date":
                        orderBy = "LWF.P1Date DESC";
                        break;

                    case "M1Date":
                        orderBy = "LWF.M1Date DESC";
                        break;

                    case "M2Date":
                        orderBy = "LWF.M2Date DESC";
                        break;

                    case "InstallDate":
                        orderBy = "LWF.InstallDate DESC";
                        break;

                    case "FinalVideoDate":
                        orderBy = "LWF.FinalVideoDate DESC";
                        break;
                                           
                    case "PreFlushDate":
                        orderBy = "LWR.PreFlushDate DESC";
                        break;

                    case "PreVideoDate":
                        orderBy = "LWR.PreVideoDate DESC";
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



        private void UpdateDatabase()
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

            columnsToDisplay2 = columnsToDisplay2 + (cbxIdSection.Checked ? " SectionID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxOldCWPID.Checked ? "OriginalSectionID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSubArea.Checked ? "SubArea," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxStreet.Checked ? "Street," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUsmh.Checked ? " USMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDsmh.Checked ? " DSMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxProposedLiningDate.Checked ? "ProposedLiningDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDeadlineLiningDate.Checked ? "DeadlineLiningDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxP1Date.Checked ? "P1Date," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxM1Date.Checked ? "M1Date," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxM2Date.Checked ? "M2Date," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxInstallDate.Checked ? "InstallDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxFinalVideoDate.Checked ? "FinalVideoDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxConfirmedSize.Checked ? "Size_," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxActualLength.Checked ? "ActualLength," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxComments.Checked ? " Comments," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMapSize.Checked ? "MapSize," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMapLength.Checked ? "MapLength," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVideoLength.Checked ? "VideoLength," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLaterals.Checked ? " Laterals," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLiveLaterals.Checked ? "LiveLaterals," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxClientID.Checked ? "ClientID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPreFlushDate.Checked ? "PreFlushDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPreVideoDate.Checked ? "PreVideoDate," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueIdentified.Checked ? "IssueIdentified," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLFSIssue.Checked ? "IssueLFS," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxClientIssue.Checked ? "IssueClient," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSalesIssue.Checked ? "IssueSales," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueGivenToClient.Checked ? "IssueGivenToClient," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueInvestigation.Checked ? "IssueInvestigation," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxIssueResolved.Checked ? "IssueResolved," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCXIsRemoved.Checked ? "CXIsRemoved," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMaterial.Checked ? "MaterialType," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHAddress.Checked ? "USMHAddress," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHDepth.Checked ? "USMHDepth," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHMouth12.Checked ? "USMHMouth12," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHMouth1.Checked ? "USMHMouth1," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHMouth2.Checked ? "USMHMouth2," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHMouth3.Checked ? "USMHMouth3," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHMouth4.Checked ? "USMHMouth4," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxUSMHMouth5.Checked ? "USMHMouth5," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHAddress.Checked ? "DSMHAddress," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHDepth.Checked ? "DSMHDepth," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHMouth12.Checked ? "DSMHMouth12," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHMouth1.Checked ? "DSMHMouth1," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHMouth2.Checked ? "DSMHMouth2," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHMouth3.Checked ? "DSMHMouth3," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHMouth4.Checked ? "DSMHMouth4," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDSMHMouth5.Checked ? "DSMHMouth5," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxTrafficControl.Checked ? "TrafficControl," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSiteDetails.Checked ? "SiteDetails," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxPipeSizeChange.Checked ? "PipeSizeChange," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxStandardBypass.Checked ? "StandardBypass," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxStandardBypassComments.Checked ? "StandardBypassComments," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxTrafficControlDetails.Checked ? "TrafficControlDetails," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMeasurementType.Checked ? "MeasurementType," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxMeasuredFromMH.Checked ? "MeasurementFromMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVideoDoneFromMH.Checked ? "VideoDoneFromMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxVideoDoneToMH.Checked ? "VideoDoneToMH," : "");            
            columnsToDisplay2 = columnsToDisplay2 + (cbxM1MeasurementsTakenBy.Checked ? "M1MeasurementTakenBy," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxM2MeasurementsTakenBy.Checked ? "M2MeasurementTakenBy," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDropPipe.Checked ? "DropPipe," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxDropPipeInvertDepth.Checked ? "DropPipeInvertDepth," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxCappedLaterals.Checked ? "CappedLaterals," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxLineWidthID.Checked ? "LineWithID," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHydrantAddress.Checked ? "HydrantAddress," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHydrantDistanceToInversionMH.Checked ? "DistanceToInversionMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHydroWireWithin10FtOfInversionMH.Checked ? "HydroWireWithin10FtOfInversionMH," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxSurfaceGrade.Checked ? "SurfaceGrade," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxHydroPulley.Checked ? "HydroPulley," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbxFridgeCart.Checked ? "FridgeCart," : "");
            columnsToDisplay2 = columnsToDisplay2 + (cbx2InchPump.Checked ? "TwoPump," : "");

            if (hdfBtnOrigin.Value == "Search")
            {
                columnsToDisplay = columnsToDisplay + (cbxIdSection.Checked ? " SectionID," : "");
                columnsToDisplay = columnsToDisplay + (cbxOldCWPID.Checked ? "OriginalSectionID," : "");
                columnsToDisplay = columnsToDisplay + (cbxSubArea.Checked ? "SubArea," : "");
                columnsToDisplay = columnsToDisplay + (cbxStreet.Checked ? "Street," : "");
                columnsToDisplay = columnsToDisplay + (cbxUsmh.Checked ? " USMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxDsmh.Checked ? " DSMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxProposedLiningDate.Checked ? "ProposedLiningDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxDeadlineLiningDate.Checked ? "DeadlineLiningDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxP1Date.Checked ? "P1Date," : "");
                columnsToDisplay = columnsToDisplay + (cbxM1Date.Checked ? "M1Date," : "");
                columnsToDisplay = columnsToDisplay + (cbxM2Date.Checked ? "M2Date," : "");
                columnsToDisplay = columnsToDisplay + (cbxInstallDate.Checked ? "InstallDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxFinalVideoDate.Checked ? "FinalVideoDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxConfirmedSize.Checked ? "Size_," : "");
                columnsToDisplay = columnsToDisplay + (cbxActualLength.Checked ? "ActualLength," : "");
                columnsToDisplay = columnsToDisplay + (cbxComments.Checked ? " Comments," : "");
                columnsToDisplay = columnsToDisplay + (cbxMapSize.Checked ? "MapSize," : "");
                columnsToDisplay = columnsToDisplay + (cbxMapLength.Checked ? "MapLength," : "");
                columnsToDisplay = columnsToDisplay + (cbxVideoLength.Checked ? "VideoLength," : "");
                columnsToDisplay = columnsToDisplay + (cbxLaterals.Checked ? " Laterals," : "");
                columnsToDisplay = columnsToDisplay + (cbxLiveLaterals.Checked ? "LiveLaterals," : "");
                columnsToDisplay = columnsToDisplay + (cbxClientID.Checked ? "ClientID," : "");
                columnsToDisplay = columnsToDisplay + (cbxPreFlushDate.Checked ? "PreFlushDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxPreVideoDate.Checked ? "PreVideoDate," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueIdentified.Checked ? "IssueIdentified," : "");
                columnsToDisplay = columnsToDisplay + (cbxLFSIssue.Checked ? "IssueLFS," : "");
                columnsToDisplay = columnsToDisplay + (cbxClientIssue.Checked ? "IssueClient," : "");
                columnsToDisplay = columnsToDisplay + (cbxSalesIssue.Checked ? "IssueSales," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueGivenToClient.Checked ? "IssueGivenToClient," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueInvestigation.Checked ? "IssueInvestigation," : "");
                columnsToDisplay = columnsToDisplay + (cbxIssueResolved.Checked ? "IssueResolved," : "");
                columnsToDisplay = columnsToDisplay + (cbxCXIsRemoved.Checked ? "CXIsRemoved," : "");
                columnsToDisplay = columnsToDisplay + (cbxMaterial.Checked ? "MaterialType," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHAddress.Checked ? "USMHAddress," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHDepth.Checked ? "USMHDepth," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHMouth12.Checked ? "USMHMouth12," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHMouth1.Checked ? "USMHMouth1," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHMouth2.Checked ? "USMHMouth2," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHMouth3.Checked ? "USMHMouth3," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHMouth4.Checked ? "USMHMouth4," : "");
                columnsToDisplay = columnsToDisplay + (cbxUSMHMouth5.Checked ? "USMHMouth5," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHAddress.Checked ? "DSMHAddress," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHDepth.Checked ? "DSMHDepth," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHMouth12.Checked ? "DSMHMouth12," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHMouth1.Checked ? "DSMHMouth1," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHMouth2.Checked ? "DSMHMouth2," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHMouth3.Checked ? "DSMHMouth3," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHMouth4.Checked ? "DSMHMouth4," : "");
                columnsToDisplay = columnsToDisplay + (cbxDSMHMouth5.Checked ? "DSMHMouth5," : "");
                columnsToDisplay = columnsToDisplay + (cbxTrafficControl.Checked ? "TrafficControl," : "");
                columnsToDisplay = columnsToDisplay + (cbxSiteDetails.Checked ? "SiteDetails," : "");
                columnsToDisplay = columnsToDisplay + (cbxPipeSizeChange.Checked ? "PipeSizeChange," : "");
                columnsToDisplay = columnsToDisplay + (cbxStandardBypass.Checked ? "StandardBypass," : "");
                columnsToDisplay = columnsToDisplay + (cbxStandardBypassComments.Checked ? "StandardBypassComments," : "");
                columnsToDisplay = columnsToDisplay + (cbxTrafficControlDetails.Checked ? "TrafficControlDetails," : "");
                columnsToDisplay = columnsToDisplay + (cbxMeasurementType.Checked ? "MeasurementType," : "");
                columnsToDisplay = columnsToDisplay + (cbxMeasuredFromMH.Checked ? "MeasurementFromMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxVideoDoneFromMH.Checked ? "VideoDoneFromMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxVideoDoneToMH.Checked ? "VideoDoneToMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxM1MeasurementsTakenBy.Checked ? "M1MeasurementTakenBy," : "");
                columnsToDisplay = columnsToDisplay + (cbxM2MeasurementsTakenBy.Checked ? "M2MeasurementTakenBy," : "");
                columnsToDisplay = columnsToDisplay + (cbxDropPipe.Checked ? "DropPipe," : "");
                columnsToDisplay = columnsToDisplay + (cbxDropPipeInvertDepth.Checked ? "DropPipeInvertDepth," : "");
                columnsToDisplay = columnsToDisplay + (cbxCappedLaterals.Checked ? "CappedLaterals," : "");
                columnsToDisplay = columnsToDisplay + (cbxLineWidthID.Checked ? "LineWithID," : "");
                columnsToDisplay = columnsToDisplay + (cbxHydrantAddress.Checked ? "HydrantAddress," : "");
                columnsToDisplay = columnsToDisplay + (cbxHydrantDistanceToInversionMH.Checked ? "DistanceToInversionMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxHydroWireWithin10FtOfInversionMH.Checked ? "HydroWireWithin10FtOfInversionMH," : "");
                columnsToDisplay = columnsToDisplay + (cbxSurfaceGrade.Checked ? "SurfaceGrade," : "");
                columnsToDisplay = columnsToDisplay + (cbxHydroPulley.Checked ? "HydroPulley," : "");
                columnsToDisplay = columnsToDisplay + (cbxFridgeCart.Checked ? "FridgeCart," : "");
                columnsToDisplay = columnsToDisplay + (cbx2InchPump.Checked ? "TwoPump," : "");
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