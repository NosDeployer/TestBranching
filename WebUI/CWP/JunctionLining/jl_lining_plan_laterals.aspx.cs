using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jl_lining_plan_laterals
    /// </summary>
    public partial class jl_lining_plan_laterals : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected JlLiningPlanTDS jlLiningPlanTDS;
        protected JlLiningPlanTDS jlLiningPlanTDSForReport;
        protected JlLiningPlanTDS.JlLiningPlanJlinerDataTable jlLiners;   






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null)|| ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jl_lining_plan_laterals.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

                // Prepare initial data
                Session.Remove("jlLinersDummy");

                // If coming from 
                if (Request.QueryString["source_page"] == "jl_lining_plan.aspx")
                {
                    // ... for the grid
                    jlLiningPlanTDS = (JlLiningPlanTDS)Session["jlLiningPlanTDS"];
                    jlLiners = jlLiningPlanTDS.JlLiningPlanJliner;

                    // Load data
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    JlLiningPlanJliner jlLiningPlanJliner  =  new JlLiningPlanJliner();
                    jlLiningPlanJliner.LoadLiners(jlLiningPlanTDS, companyId);

                    jlLiningPlanTDS.JlLiningPlanJliner.DefaultView.Sort = " ParentInstallOrder DESC";

                    // Store dataset
                    Session["jlLiningPlanTDS"] = jlLiningPlanTDS;
                    jlLiners = jlLiningPlanTDS.JlLiningPlanJliner;
                    Session["jlLiners"] = jlLiners;
                    grdLiningPlanLiners.DataBind();

                    // Check results
                    JlLiningPlanJlinerGateway jlLiningPlanJlinerGateway = new JlLiningPlanJlinerGateway(jlLiningPlanTDS);
                    if (jlLiningPlanJlinerGateway.Table.Rows.Count > 0)
                    {
                        tdNoResults.Visible = false;
                        btnPreview.Visible = true;
                        btnOrder.Visible = true;
                        ddlOrder.Visible = true;
                        lblOrder.Visible = true;
                    }
                    else
                    {
                        tdNoResults.Visible = true;
                        btnPreview.Visible = false;
                        btnOrder.Visible = false;
                        ddlOrder.Visible = false;
                        lblOrder.Visible = false;
                    }
                }                                
            }
            else
            {
                // Restore datasets
                jlLiningPlanTDS = (JlLiningPlanTDS)Session["jlLiningPlanTDS"];
                jlLiners = jlLiningPlanTDS.JlLiningPlanJliner;

                // Store
                Session["jlLiners"] = jlLiningPlanTDS.JlLiningPlanJliner;
            }
        }       



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Laterals For Lining Plan";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdLiningPlanLiners_DataBound(object sender, EventArgs e)
        {
            AddJlinersNewEmptyFix(grdLiningPlanLiners);
        }



        protected void grdLiningPlanLiners_Sorting(object sender, GridViewSortEventArgs e)
        {
            //string direction = (e.SortDirection == SortDirection.Ascending) ? "ASC" : "DESC";

            //DataView dataView = new DataView(jlLiningPlanTDS.JlLiningPlanJliner);
            //dataView.Sort = e.SortExpression + " " + direction;
            //grdLiningPlanLiners.DataSource = dataView;
            grdLiningPlanLiners.DataBind();
        }



        protected void btnOrder_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            if (ddlOrder.SelectedIndex == 0)
            {
                grdLiningPlanLiners.Sort("ParentInstallOrder, SectionID, FlowOrderIDLateralID", SortDirection.Descending);
            }
            else
            {
                grdLiningPlanLiners.Sort("Selected", SortDirection.Ascending);
            }
        }



        protected void btnPreview_Click(object sender, System.EventArgs e)
        {
            Preview();
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        //  PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jl_lining_plan_laterals.js");
        }



        public JlLiningPlanTDS.JlLiningPlanJlinerDataTable GetJlinersNew()
        {
            jlLiners = (JlLiningPlanTDS.JlLiningPlanJlinerDataTable)Session["jlLinersDummy"];
            if (jlLiners == null)
            {
                jlLiners = ((JlLiningPlanTDS.JlLiningPlanJlinerDataTable)Session["jlLiners"]);
            }

            return jlLiners;
        }



        protected void AddJlinersNewEmptyFix(GridView grdLiningPlanLiners)
        {
            if (grdLiningPlanLiners.Rows.Count == 0)
            {                
                JlLiningPlanTDS.JlLiningPlanJlinerDataTable dt = new JlLiningPlanTDS.JlLiningPlanJlinerDataTable();
                dt.AddJlLiningPlanJlinerRow(-1, -1, -1, "", "", "",  "", "",  "", "", "", "", "", "", 30, "", "", 0, "");
                Session["jlLinersDummy"] = dt;

                grdLiningPlanLiners.DataBind();
            }

            // Normally executes at all postbacks
            if (grdLiningPlanLiners.Rows.Count == 1)
            {
                JlLiningPlanTDS.JlLiningPlanJlinerDataTable dt = (JlLiningPlanTDS.JlLiningPlanJlinerDataTable)Session["jlLinersDummy"];
                if (dt != null)
                {
                    grdLiningPlanLiners.Rows[0].Visible = false;
                    grdLiningPlanLiners.Rows[0].Controls.Clear();
                }
            }
        }



        private void Preview()
        {
            // Verify selecction
            cvSelection.IsValid = true;
            if (GetSelected() == 0)
            {                
                cvSelection.IsValid = false;
            }

            // Go to report
            if (jlLiningPlanTDS.JlLiningPlan.Rows.Count > 0)
            {
                Page.Validate();
                if (Page.IsValid)
                {
                    PostPageChanges();
                    Response.Redirect("./jl_lining_plan_report.aspx?source_page=jl_lining_plan_laterals.aspx&project_id=" + hdfCurrentProjectId.Value + "&client_id=" + hdfCurrentClientId.Value);
                }
            }            
        }



        private void PostPageChanges()
        {
            JlLiningPlanJliner jlLiningPlanJliner = new JlLiningPlanJliner(jlLiningPlanTDS);

            foreach (GridViewRow row in grdLiningPlanLiners.Rows)
            {
                int assetId = int.Parse(((HiddenField)row.FindControl("hdfAssetId")).Value);
                int companyId = int.Parse(((HiddenField)row.FindControl("hdfCompanyId")).Value);
                int section_ = int.Parse(((HiddenField)row.FindControl("hdfSectionId")).Value);
                int selected = Int32.Parse(((DropDownList)row.FindControl("ddlSelected")).SelectedValue);

                jlLiningPlanJliner.Update(assetId, section_, companyId, selected);
            }

            // Store datasets
            Session["jlLiningPlanTDS"] = jlLiningPlanTDS;
        }



        private int GetSelected()
        {
            int selected = 0;

            foreach (JlLiningPlanTDS.JlLiningPlanJlinerRow jlinerRow in jlLiningPlanTDS.JlLiningPlanJliner)
            {
                if (jlinerRow.Selected != 30)
                {
                    selected = selected++;
                }
            }

            return selected;
        }



    }
}