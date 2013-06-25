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
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// Project Subcontractor Add
    /// </summary>
    public partial class project_subcontractor_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;





        
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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_engineer_subcontractors_edit.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];

                // If coming from 

                // ... project_engineer_subcontractors.aspx or project_engineer_subcontractors_edit.aspx
                if ((Request.QueryString["source_page"] == "project_engineer_subcontractors.aspx") || (Request.QueryString["source_page"] == "project_engineer_subcontractors_edit.aspx"))
                {
                    // Restore dataset
                    projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                }

                // Prepare initial data

                // ... for subcontractor
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(Select)", companyId);
                ddlSubcontractorId.DataSource = companiesList.Table;
                ddlSubcontractorId.DataTextField = "Name";
                ddlSubcontractorId.DataValueField = "COMPANIES_ID";
                ddlSubcontractorId.DataBind();
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
            }
        }



        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                UpdateDatabase();

                Response.Write("<script language='javascript'> { window.close();}</script>");
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Add Sub-Contractor";

            // Country check
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
            if (projectGateway.GetCountryID(int.Parse(hdfProjectId.Value)) == 1)
            {
                ddlSubcontractorMOLForm1000.Visible = true;
                tbxSubcontractorMOLForm1000.Visible = false;
            }
            else
            {
                ddlSubcontractorMOLForm1000.Visible = false;
                tbxSubcontractorMOLForm1000.Visible = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_subcontractor_add.js");
        }



        private void PostPageChanges()
        {
            // Insert subcontractors
            ProjectSubcontractor projectSubcontractor = new ProjectSubcontractor(projectTDS);

            int refId = projectSubcontractor.GetNewRefId();
            int subcontractorId = int.Parse(ddlSubcontractorId.SelectedValue);
            bool writtenQuote = cbxSubcontractorWrittenQuote.Checked;
            bool surveyedSite = cbxSubcontractorSurveyedSite.Checked;
            bool workedBefore = cbxSubcontractorWorkedBefore.Checked;
            string role = tbxSubcontractorRole.Text.Trim();
            bool agreement = cbxSubcontractorAgreement.Checked;
            string issues = tbxSubcontractorIssues.Text.Trim();
            bool purchaseOrder = cbxSubcontractorPurchaseOrder.Checked;
            bool insuranceCertificate = cbxSubcontractorInsuranceCertificate.Checked;
            bool wsib = cbxSubcontractorWSIB.Checked;
            string molForm1000 = ddlSubcontractorMOLForm1000.SelectedValue;
            int royalties = int.Parse(tbxRoyalties.Text.Trim());

            projectSubcontractor.Insert(int.Parse(hdfProjectId.Value), refId, subcontractorId, writtenQuote, surveyedSite, workedBefore, role, agreement, issues, purchaseOrder, insuranceCertificate, wsib, molForm1000, false, Int32.Parse(hdfCompanyId.Value.Trim()), royalties);
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectSubcontractorGateway projectSubcontractorGateway = new ProjectSubcontractorGateway(projectTDS);
                projectSubcontractorGateway.Update();

                projectTDS.AcceptChanges();

                Session["lfsProjectTDS"] = projectTDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}
