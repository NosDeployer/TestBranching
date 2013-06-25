using System;
using System.Web.UI;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_delete
    /// </summary>
    public partial class jliner_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlinerTDS flatSectionJlinerTDS;
        protected SectionTDS sectionTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jliner_delete.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];

                // If coming from 
                // ... jliner_navigator2.aspx
                if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";
                }

                // ... flat_section_jliner_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                }

                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                sectionTDS = new SectionTDS();
                Session["sectionTDS"] = sectionTDS;
            }
            else
            {
                // Restore datasets
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];
                sectionTDS = (SectionTDS)Session["sectionTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "CWP";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mDelete":
                    this.Delete();
                    break;

                case "mCancel":
                    string url = "";

                    if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                    {
                        url = "./jliner_navigator2.aspx?source_page=flat_section_jliner_edit.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx")
                    {
                        url = "./flat_section_jliner_summary.aspx?source_page=flat_section_jliner_edit.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
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
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentClientId = '" + hdfCurrentClient.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_issues=" + Request.QueryString["search_issues"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"]; 
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
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner(flatSectionJlinerTDS);

                // ... Delete in flatSectionJlinerTDS
                foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)flatSectionJliner.Table)
                {
                    if ((flatSectionJlinerRow.Selected) && (!flatSectionJlinerRow.Deleted))
                    {
                        flatSectionJliner.Delete(flatSectionJlinerRow.ID_);
                    }
                }

                // ... Update section and jliners from flatSectionJlinerTDS
                flatSectionJliner.Save(sectionTDS);
                
                // Update databse
                UpdateDatabase();

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "jliner_navigator2.aspx")
                {
                    url = "./jliner_navigator2.aspx?source_page=jliner_delete.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx")
                {
                    url = "./flat_section_jliner_summary.aspx?source_page=jliner_delete.aspx&client=" + hdfCurrentClient.Value + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            try
            {
                SectionGateway sectionGateway = new SectionGateway(sectionTDS);
                sectionGateway.Update();

                sectionTDS.AcceptChanges();
                flatSectionJlinerTDS.AcceptChanges();
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

                // Update IssueWithLaterals field
                Section section = new Section(sectionTDS);
                section.UpdateIssueWithLaterals();
                sectionGateway.Update2();
                sectionTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}