using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Resources.Materials;
using LiquiForce.LFSLive.DA.Resources.Materials;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_state
    /// </summary>
    public partial class materials_state : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialsInformationTDS materialsInformationTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["material_state"] == null) || ((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["material_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_state.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfMaterialId.Value = Request.QueryString["material_id"];
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();

                // Prepare initial data
                // ... for material title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int materialId = Int32.Parse(hdfMaterialId.Value);

                MaterialsGateway materialsGateway = new MaterialsGateway();
                materialsGateway.LoadByMaterialId(materialId, companyId);
                lblTitleMaterial.Text = "Material: " + materialsGateway.GetDescription(materialId);

                // If coming from materials_summary.aspx
                if ((string)Request.QueryString["source_page"] == "materials_summary.aspx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Get project record
                    materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];
                    MaterialsInformationBasicInformationGateway materialsInformationBasicInformationGateway = new MaterialsInformationBasicInformationGateway(materialsInformationTDS);
                    materialsInformationBasicInformationGateway.LoadByMaterialId(materialId, companyId);

                    // Store datasets
                    Session["materialsInformationTDS"] = materialsInformationTDS;
                }                
            }
            else
            {
                // Restore dataset 
                materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];
            }
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Resources";

            // Operation check
            switch ((string)Request.QueryString["material_state"])
            {
                case "Not Available":
                    tkrmTop.Items[0].Visible = true; //Enable
                    tkrmTop.Items[1].Visible = false;//Disable                    

                    // ... Cancel
                    tkrmTop.Items[2].Visible = true;
                    break;

                case "Available":
                    tkrmTop.Items[0].Visible = false; //Enable
                    tkrmTop.Items[1].Visible = true;//Disable                    

                    // ...Cancel
                    tkrmTop.Items[2].Visible = true;
                    break;                                 
            }

            // Set instruction
            switch ((string)Request.QueryString["material_state"])
            {
                case "Not Available":
                    lblState.Text = "Are you sure you want to enable this material?";                    
                    break;

                case "Available":
                    lblState.Text = "Are you sure you want to disable this material?";
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            if (e.Item.Value == "mCancel")
            {
                url = "./materials_summary.aspx?source_page=materials_edit.aspx&material_id=" + hdfMaterialId.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + hdfActiveTab.Value;
                Response.Redirect(url);
            }
            else
            {
                UpdateState();
                UpdateDatabase();

                url = string.Format("./materials_summary.aspx?source_page=materials_state.aspx&material_id=" + hdfMaterialId.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=yes");

                Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_state.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void UpdateState()
        {
            int materialId = Int32.Parse(hdfMaterialId.Value);
            MaterialsInformationBasicInformationGateway materialsInformationBasicInformationGateway = new MaterialsInformationBasicInformationGateway(materialsInformationTDS);

            // General Data            
            string description = materialsInformationBasicInformationGateway.GetDescription(materialId);
            string size = materialsInformationBasicInformationGateway.GetSize(materialId);
            string length = materialsInformationBasicInformationGateway.GetLength(materialId);
            string thickness = materialsInformationBasicInformationGateway.GetThickness(materialId);
            string type = materialsInformationBasicInformationGateway.GetType(materialId);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            
            // ... Get new values
            string newState = null;
            switch ((string)Request.QueryString["material_state"])
            {
                case "Available":
                    newState = "Not Available";                    
                    break;

                case "Not Available":
                    newState = "Available";                    
                    break;               
            }

            // Update service data
            MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
            materialsInformationBasicInformation.Update(materialId, description, size, length, thickness, type, newState, false, companyId);
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                materialsInformationBasicInformation.Save(companyId);
                DB.CommitTransaction();

                // Store datasets
                materialsInformationTDS.AcceptChanges();
                Session["materialsInformationTDS"] = materialsInformationTDS;
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