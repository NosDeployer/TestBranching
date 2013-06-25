using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.WebUI.Common.Tools;
using System.Collections.Generic;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_sections_summary
    /// </summary>
    public partial class project_sections_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected ProjectSectionsNavigatorTDS projectSectionsNavigatorTDS;
        protected ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable projectSectionsNavigatorLaterals;
        protected AssetsTDS assetsTDS;
        protected LfsAssetsTDS lfsAssetsTDS;
        protected WorkTDS workTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in projects2.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfAssetID.Value = Request.QueryString["asset_id"];
                Session.Remove("projectSectionsNavigatorLateralsNewDummy");
                Session.Remove("projectSectionsNavigatorLaterals");

                // Initialize data
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                assetsTDS = new AssetsTDS();
                lfsAssetsTDS = new LfsAssetsTDS();
                workTDS = new WorkTDS();
                projectSectionsNavigatorTDS = new ProjectSectionsNavigatorTDS();

                // Load data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetID.Value);
                int projectId = Int32.Parse(hdfProjectId.Value);

                AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                assetSewerSectionGateway.LoadByAssetId(assetId, companyId);

                if (assetSewerSectionGateway.Table.Rows.Count > 0)
                {
                    tbxSectionId.Text = assetSewerSectionGateway.GetFlowOrderID(assetId);
                    tbxStreet.Text = assetSewerSectionGateway.GetStreet(assetId);

                    // ... For usmh
                    if (assetSewerSectionGateway.GetUSMH(assetId).HasValue)
                    {
                        AssetSewerMHGateway assetSewerFindMHGateway = new AssetSewerMHGateway();
                        int USMH = (int)assetSewerSectionGateway.GetUSMH(assetId);

                        assetSewerFindMHGateway.LoadByAssetId(USMH, companyId);
                        tbxUSMH.Text = assetSewerFindMHGateway.GetMHID(USMH);
                    }

                    // ... For usmh
                    if (assetSewerSectionGateway.GetDSMH(assetId).HasValue)
                    {
                        AssetSewerMHGateway assetSewerFindMHGateway = new AssetSewerMHGateway();
                        int DSMH = (int)assetSewerSectionGateway.GetDSMH(assetId);

                        assetSewerFindMHGateway.LoadByAssetId(DSMH, companyId);
                        tbxDSMH.Text = assetSewerFindMHGateway.GetMHID(DSMH);
                    }

                    // ... For Works
                    WorkGateway workGateway = new WorkGateway();
                    if (workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(assetId, projectId, "Rehab Assessment", companyId))
                        ckbxRehabAssessment.Checked = true;
                    if (workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(assetId, projectId, "Full Length Lining", companyId))
                        ckbxFullLengthLining.Checked = true;
                    if (workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(assetId, projectId, "Junction Lining Section", companyId))
                        ckbxJunctionLining.Checked = true;

                    // ... For Laterals
                    if (assetSewerSectionGateway.GetLaterals(int.Parse(hdfAssetID.Value)).HasValue)
                    {
                        tbxTotalLaterals.Text = ((int)assetSewerSectionGateway.GetLaterals(assetId)).ToString();
                    }
                    else
                    {
                        tbxTotalLaterals.Text = "0";
                    }

                    ProjectSectionsNavigatorLateralsGateway projectSectionsNavigatorLateralsGateway = new ProjectSectionsNavigatorLateralsGateway(projectSectionsNavigatorTDS);
                    projectSectionsNavigatorLateralsGateway.LoadBySection_ProjectId(assetId, projectId, companyId);

                    AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway(assetsTDS);
                    assetSewerLateralGateway.LoadBySectionProjectId(assetId, projectId, companyId);

                    // ... store datasets
                    Session["projectSectionsNavigatorTDS"] = projectSectionsNavigatorTDS;
                    projectSectionsNavigatorLaterals = projectSectionsNavigatorTDS.ProjectSectionNavigatorLaterals;
                    Session["projectSectionsNavigatorLaterals"] = projectSectionsNavigatorLaterals;
                }
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectSectionsNavigatorTDS = (ProjectSectionsNavigatorTDS)Session["lfsProjectSectionsNavigatorTDS"];
                projectSectionsNavigatorLaterals = (ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable)Session["projectSectionsNavigatorLaterals"];
                assetsTDS = (AssetsTDS)Session["assetsTDS"];
                lfsAssetsTDS = (LfsAssetsTDS)Session["lfsAssetsTDS"];
                workTDS = (WorkTDS)Session["workTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Costing Sheet Summary";
        }






        // ////////////////////////////////////////////////////////////////////////
        //  AUXILIAR EVENTS
        //

        protected void grdLateralsNavigator_DataBound(object sender, EventArgs e)
        {
            AddLateralsNewEmptyFix(grdLateralsNavigator);
        }






        // ////////////////////////////////////////////////////////////////////////
        //  METHODS
        //

        public ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable GetLaterals()
        {
            projectSectionsNavigatorLaterals = (ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable)Session["projectSectionsNavigatorLateralsNewDummy"];
            if (projectSectionsNavigatorLaterals == null)
            {
                projectSectionsNavigatorLaterals = ((ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable)Session["projectSectionsNavigatorLaterals"]);
            }

            return projectSectionsNavigatorLaterals;
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./project_sections_summary.js");
        }



        protected void AddLateralsNewEmptyFix(GridView grdLateralsNavigator)
        {
            if (grdLateralsNavigator.Rows.Count == 0)
            {
                ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable dt = new ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable();
                dt.AddProjectSectionNavigatorLateralsRow(-1, "", "", "", false, -1);
                Session["projectSectionsNavigatorLateralsNewDummy"] = dt;

                grdLateralsNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdLateralsNavigator.Rows.Count == 1)
            {
                ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable dt = (ProjectSectionsNavigatorTDS.ProjectSectionNavigatorLateralsDataTable)Session["projectSectionsNavigatorLateralsNewDummy"];
                if (dt != null)
                {
                    grdLateralsNavigator.Rows[0].Visible = false;
                    grdLateralsNavigator.Rows[0].Controls.Clear();
                }
            }
        }



    }
}