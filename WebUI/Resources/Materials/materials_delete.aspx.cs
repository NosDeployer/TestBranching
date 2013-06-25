using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_delete
    /// </summary>
    public partial class materials_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialsTDS materialsTDS;
        protected MaterialsInformationBasicInformation materialsInformationBasicInformation;
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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"]) && Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["material_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_delete.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfMaterialId.Value = Request.QueryString["material_id"];
                hdfActiveTab.Value = Request.QueryString["active_tab"];

                // Prepare initial data
                // ... for material title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int materialId = Int32.Parse(hdfMaterialId.Value);

                MaterialsGateway materialsGateway = new MaterialsGateway();
                materialsGateway.LoadByMaterialId(materialId, companyId);
                lblTitleMaterial.Text = "Material: " + materialsGateway.GetDescription(materialId);

                // If coming from 
                // ... materials_navigator2.aspx
                if (Request.QueryString["source_page"] == "materials_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    materialsInformationTDS = new MaterialsInformationTDS();
                    materialsTDS = new MaterialsTDS();

                    MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                    materialsInformationBasicInformation.LoadByMaterialId(materialId, companyId);

                    MaterialsInformationCostHistoryInformation materialsInformationCostHistoryInformation = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
                    materialsInformationCostHistoryInformation.LoadAllByMaterialId(materialId, companyId);

                    MaterialsInformationCostHistoryExceptionsInformation materialsInformationCostHistoryExceptionsInformation = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);
                    materialsInformationCostHistoryExceptionsInformation.LoadAllByMaterialId(materialId, companyId);

                    MaterialsInformationNoteInformation materialsInformationNoteInformation = new MaterialsInformationNoteInformation(materialsInformationTDS);
                    materialsInformationNoteInformation.LoadAllByMaterialId(materialId, companyId);

                    // Store dataset
                    Session["materialsInformationTDS"] = materialsInformationTDS;
                    Session["materialsTDS"] = materialsTDS;
                }

                // ... materials_summary.aspx
                if (Request.QueryString["source_page"] == "materials_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    materialsTDS = (MaterialsTDS)Session["materialsTDS"];
                    materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];
                }
            }
            else
            {
                // Restore datasets
                materialsTDS = (MaterialsTDS)Session["materialsTDS"];
                materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Resources";
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = null;

            switch (e.Item.Value)
            {
                case "mDelete":
                    Page.Validate();

                    if (Page.IsValid)
                    {
                        Delete();
                        UpdateDatabase();

                        // Redirect
                        if (Request.QueryString["source_page"] == "materials_navigator2.aspx")
                        {
                            url = "./materials_navigator2.aspx?source_page=materials_delete.aspx&material_id=" + hdfMaterialId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=yes";
                        }

                        if (Request.QueryString["source_page"] == "materials_summary.aspx")
                        {
                            url = "./materials_navigator2.aspx?source_page=materials_delete.aspx&material_id=" + hdfMaterialId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=yes";
                        }


                        Response.Redirect(url);
                    }
                    break;

                case "mCancel":
                    if (Request.QueryString["source_page"] == "materials_navigator2.aspx")
                    {
                        url = "./materials_navigator2.aspx?source_page=materials_delete.aspx&material_id=" + hdfMaterialId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "materials_summary.aspx")
                    {
                        url = "./materials_summary.aspx?source_page=materials_delete.aspx&material_id=" + hdfMaterialId.Value + "&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    }

                    if (url != "") Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Delete()
        {
            int materialId = int.Parse(hdfMaterialId.Value);

            MaterialsInformationNoteInformation materialsInformationNoteInformation = new MaterialsInformationNoteInformation(materialsInformationTDS);
            materialsInformationNoteInformation.DeleteAll(materialId);

            MaterialsInformationCostHistoryInformation materialsInformationCostHistoryInformation = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
            materialsInformationCostHistoryInformation.DeleteAll(materialId);

            MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
            materialsInformationBasicInformation.Delete(materialId);            

            // Store datasets
            Session["materialsInformationTDS"] = materialsInformationTDS;
        }



        private void UpdateDatabase()
        {
            // Get ids
            int materialId = Int32.Parse(hdfMaterialId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                materialsInformationBasicInformation.DeleteDirect(materialId, companyId);                

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
