using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jl_delete
    /// </summary>
    public partial class jl_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlTDS flatSectionJlTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jl_delete.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

                // Prepare initial data
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
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Laterals";

                // If coming from 
                // ... jl_navigator2.aspx
                if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... flat_section_jl_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];
            }
            else
            {
                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];
            }
        }


                
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=jl_edit.aspx&work_type=Junction Lining");
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    this.Delete();
                    break;

                case "mCancel":
                    flatSectionJlTDS.RejectChanges();

                    string url = "";
                    if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                    {
                        url = "./jl_navigator2.aspx?source_page=jl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx")
                    {
                        url = "./flat_section_jl_summary.aspx?source_page=jl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jl_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_issues=" + Request.QueryString["search_issues"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Delete jliners
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);

                // ... Delete in flatSectionJlinerTDS
                foreach (FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow in (FlatSectionJlTDS.FlatSectionJlDataTable)flatSectionJl.Table)
                {
                    if ((flatSectionJlRow.Selected) && (!flatSectionJlRow.Deleted))
                    {
                        flatSectionJl.Delete(flatSectionJlRow.WorkID);
                    }
                }

                // ... Update assets 
                string workType = hdfWorkType.Value.Trim();
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());

                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["flatSectionJlTDS"] = flatSectionJlTDS;

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "jl_navigator2.aspx")
                {
                    url = "./jl_navigator2.aspx?source_page=jl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx")
                {
                    url = "./flat_section_jl_summary.aspx?source_page=jl_delete.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
                flatSectionJl.DeleteDirect(companyId);

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