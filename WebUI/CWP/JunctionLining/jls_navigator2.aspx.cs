using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jls_navigator2
    /// </summary>
    public partial class jls_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected JlsNavigatorTDS jlsNavigatorTDS;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jls_navigator2.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();

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

                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                int companyId = Int32.Parse(hdfCompanyId.Value);

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

                // ... jls_navigator.aspx or jls_navigator2.aspx
                if ((Request.QueryString["source_page"] == "jls_navigator.aspx") || (Request.QueryString["source_page"] == "jls_navigator2.aspx"))
                {
                    RestoreNavigatorState();

                    jlsNavigatorTDS = (JlsNavigatorTDS)Session["jlsNavigatorTDS"];
                }

                // ... flat_section_jls_edit.aspx, flat_section_jls_summary.aspx or jls_delete.aspx
                if ((Request.QueryString["source_page"] == "flat_section_jls_edit.aspx") || (Request.QueryString["source_page"] == "flat_section_jls_summary.aspx") || (Request.QueryString["source_page"] == "jls_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        jlsNavigatorTDS = (JlsNavigatorTDS)Session["jlsNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("jlsNavigatorTDS");

                        // ... Search data with updates
                        jlsNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["jlsNavigatorTDS"] = jlsNavigatorTDS;

                        // ... control of existing records
                        if (jlsNavigatorTDS.JlsNavigator.Rows.Count == 0)
                        {
                            string url = "./jls_navigator.aspx?source_page=jls_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&no_results=yes";
                            Response.Redirect(url);
                        }
                    }
                }

                // For the grid
                grdJLNavigator.DataSource = jlsNavigatorTDS.JlsNavigator;
                grdJLNavigator.DataBind();

                // ... for the total rows
                if (jlsNavigatorTDS.JlsNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + jlsNavigatorTDS.JlsNavigator.Rows.Count;
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
                jlsNavigatorTDS = (JlsNavigatorTDS)Session["jlsNavigatorTDS"];

                // ... for the total rows
                if (jlsNavigatorTDS.JlsNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + jlsNavigatorTDS.JlsNavigator.Rows.Count;
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
                string url = "";

                // Delete store data
                Session.Contents.Remove("jlsNavigatorTDS");

                // Get data from DA gateway
                jlsNavigatorTDS = SubmitSearch();

                // Show results
                if (jlsNavigatorTDS.JlsNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["jlsNavigatorTDS"] = jlsNavigatorTDS;

                    // ... Go to the results page
                    url = "./jls_navigator2.aspx?source_page=jls_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./jls_navigator.aspx?source_page=jls_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }

              
                
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "eSewers";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void odsViewForDisplayList_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters.Remove("workType");
            e.InputParameters.Add("workType", "Junction Lining Section");
        }

        
        
        
        
        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../common/select_project.aspx?source_page=jls_navigator2.aspx&work_type=Junction Lining Section");
        }



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            PostPageChanges();

            ArrayList workIdArrayList = GetWorkIdArrayList();
            if (workIdArrayList.Count > 0)
            {
                FlatSectionJls flatSectionJls = new FlatSectionJls();
                flatSectionJls.LoadByWorkIdArrayList(workIdArrayList, 1, companyId);

                if (flatSectionJls.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlsTDS");

                    // Store datasets
                    Session["jlsNavigatorTDS"] = jlsNavigatorTDS;
                    Session["flatSectionJlsTDS"] = flatSectionJls.Data;

                    // Redirect
                    string url = "./flat_section_jls_summary.aspx?source_page=jls_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
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

            PostPageChanges();

            ArrayList workIdArrayList = GetWorkIdArrayList();
            if (workIdArrayList.Count > 0)
            {
                FlatSectionJls flatSectionJls = new FlatSectionJls();
                flatSectionJls.LoadByWorkIdArrayList(workIdArrayList, 1, companyId);

                if (flatSectionJls.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlsTDS");

                    // Store datasets
                    Session["jlsNavigatorTDS"] = jlsNavigatorTDS;
                    Session["flatSectionJlsTDS"] = flatSectionJls.Data;

                    // Redirect
                    string url = "./flat_section_jls_edit.aspx?source_page=jls_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
                    Response.Redirect(url);
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }        



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            PostPageChanges();

            ArrayList workIdArrayList = GetWorkIdArrayList();

            if (workIdArrayList.Count > 0)
            {
                FlatSectionJls flatSectionJls = new FlatSectionJls();
                flatSectionJls.LoadByWorkIdArrayList(workIdArrayList, 1, companyId);

                if (flatSectionJls.Table.Rows.Count > 0)
                {
                    // Delete store dataset
                    Session.Remove("flatSectionJlsTDS");

                    // Store datasets
                    Session["jlsNavigatorTDS"] = jlsNavigatorTDS;
                    Session["flatSectionJlsTDS"] = flatSectionJls.Data;

                    // Redirect
                    string url = "./jls_delete.aspx?source_page=jls_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
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
            string url = "./jls_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./jl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
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
                    script2 = script2 + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=800, height=680')", url);
                    script2 = script2 + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "M1Report", script2, false);
                    url = "";
                    break;

                case "mLiningPlan":
                    url = "./jl_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
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
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jls_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            // Columns To Display
            string columnsToDisplay = Request.QueryString["columns_to_display"];

            // Search condition 1
            // ... For Condition 
            odsViewForDisplayList.DataBind();
            ddlCondition1.DataSourceID = "odsViewForDisplayList";
            ddlCondition1.DataValueField = "ConditionID";
            ddlCondition1.DataTextField = "Name";
            ddlCondition1.DataBind();
            ddlCondition1.SelectedValue = Request.QueryString["search_ddlCondition1"];   

            // ... For text for search
            tbxCondition1.Text = Request.QueryString["search_tbxCondition1"];

            //Other values
            //... For SortBy
            odsSortByList.DataBind();
            ddlSortBy.DataSourceID = "odsSortByList";
            ddlSortBy.DataValueField = "SortID";
            ddlSortBy.DataTextField = "Name";
            ddlSortBy.DataBind();
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

             // Grid's columns
            grdJLNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("SectionID") >= 0 ? true : false);
            grdJLNavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("OriginalSectionID") >= 0 ? true : false);
            grdJLNavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("SubArea") >= 0 ? true : false);
            grdJLNavigator.Columns[5].Visible = (columnsToDisplay.IndexOf("Street") >= 0 ? true : false);
            grdJLNavigator.Columns[6].Visible = (columnsToDisplay.IndexOf("USMH") >= 0 ? true : false);
            grdJLNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf("DSMH") >= 0 ? true : false);
        }



        private string GetNavigatorState()
        {
            // Columns to display
            string columnsToDisplay = "";
            columnsToDisplay = columnsToDisplay + GetColumnsToDisplay();

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=" + ddlCondition1.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition1=" + tbxCondition1.Text.Trim();

            // Other values
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private JlsNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();

            // ... Load data
            JlsNavigator jlsNavigator = new JlsNavigator();
            jlsNavigator.Load(whereClause, orderByClause);

            return (JlsNavigatorTDS)jlsNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LW.Deleted = 0) AND (LW.COMPANY_ID = " + companyId + ") AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ") ";
            whereClause = whereClause + "AND (LW.ProjectID = " + hdfCurrentProjectId.Value + ") ";

            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim());
            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch)
        {
            string conditionValue = "";
            string workType = "Junction Lining Section";
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, conditionId, companyId);

            conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, conditionId);
            string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, conditionId);

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if ((tableName == "AM_ASSET_SEWER_MH") && (conditionValue == "USMH"))
            {
                conditionValue = "MHID";
                tableName = "AASUSMH";
            }
            if ((tableName == "AM_ASSET_SEWER_MH") && (conditionValue == "DSMH"))
            {
                conditionValue = "MHID";
                tableName = "AASDSMH";
            }
            if (tableName == "LFS_WORK_JUNCTIONLINING_SECTION") tableName = "LWJLS";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_MIGRATED_SECTIONS") tableName = "LMS";

            // ... FOR TEXT FIELDS
            if ((conditionValue == "FlowOrderID") || (conditionValue == "SubArea") || (conditionValue == "Street") || (conditionValue == "OriginalSectionID") || (conditionValue == "MHID"))
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
                        textForSearch = textForSearch.Replace("'", "''");
                        whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                    }
                }
            }

            return whereClause;
        }

        
        
        private string GetOrderByClause()
        {
            // For tableName
            string workType = "Junction Lining Section";
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway();
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = workTypeViewSortGateway.GetColumn_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_WORK_JUNCTIONLINING_SECTION") tableName = "LWJLS";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";

            return tableName + "." + columnName;
        }



        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = "Junction Lining Section";
            string columnsToDisplay = "&columns_to_display=";

            WorkTypeViewDisplay workTypeViewDisplay = new WorkTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + workTypeViewDisplay.GetColumnsByDefault(workType, companyId, true);

            return columnsToDisplay;
        }



        private void PostPageChanges()
        {
            JlsNavigator jlsNavigator = new JlsNavigator(jlsNavigatorTDS);

            // Update jls rows
            foreach (GridViewRow row in grdJLNavigator.Rows)
            {
                int workId = int.Parse(((Label)row.FindControl("lblWorkID")).Text);
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                jlsNavigator.Update(workId, selected);
            }

            jlsNavigator.Data.AcceptChanges();

            // Store datasets
            Session["jlsNavigatorTDS"] = jlsNavigatorTDS;
        }
        
        
        
        private ArrayList GetWorkIdArrayList()
        {
            ArrayList jlsIdArrayList = new ArrayList();

            foreach (JlsNavigatorTDS.JlsNavigatorRow jlsNavigatorRow in jlsNavigatorTDS.JlsNavigator)
            {
                if (jlsNavigatorRow.Selected)
                {
                    jlsIdArrayList.Add(new JlsId(jlsNavigatorRow.WorkID));
                }
            }

            return jlsIdArrayList;
        }



        private ArrayList GetSectionIdArrayList()
        {
            ArrayList jlsIdArrayList = new ArrayList();

            foreach (JlsNavigatorTDS.JlsNavigatorRow jlsNavigatorRow in jlsNavigatorTDS.JlsNavigator)
            {
                if (jlsNavigatorRow.Selected)
                {
                    if (!jlsIdArrayList.Contains(jlsNavigatorRow.SectionID))
                    {
                        jlsIdArrayList.Add(jlsNavigatorRow.SectionID);
                    }
                }
            }

            return jlsIdArrayList;
        }
               
        
                
    }
}