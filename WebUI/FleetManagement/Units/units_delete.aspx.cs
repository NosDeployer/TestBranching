using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_delete
    /// </summary>
    public partial class units_delete : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitInformationTDS unitInformationTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_DELETE"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["unit_id"] == null) || ((string)Request.QueryString["unit_type"] == null) || ((string)Request.QueryString["unit_state"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_delete.aspx");
                }

                // Tag Page
                hdfUnitId.Value = Request.QueryString["unit_id"].ToString();
                hdfUnitType.Value = Request.QueryString["unit_type"].ToString();
                hdfUnitState.Value = Request.QueryString["unit_state"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();

                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int unitId = Int32.Parse(hdfUnitId.Value.Trim());
                                
                // If comming from                 
                // ... units_navigator2.aspx
                if (Request.QueryString["source_page"] == "units_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    unitInformationTDS = new UnitInformationTDS();

                    UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                    unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                    UnitInformationChecklistDetails unitInformationChecklistDetails = new UnitInformationChecklistDetails(unitInformationTDS);
                    unitInformationChecklistDetails.Load(unitId, companyId);

                    UnitInformationServiceDetails unitInformationServiceDetails = new UnitInformationServiceDetails(unitInformationTDS);
                    unitInformationServiceDetails.Load(unitId, companyId);

                    UnitInformationInspectionDetails unitInformationInspectionDetails = new UnitInformationInspectionDetails(unitInformationTDS);
                    unitInformationInspectionDetails.LoadByUnitId(unitId, companyId);

                    UnitInformationCostExceptionsInformation unitInformationCostExceptionsInformation = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                    unitInformationCostExceptionsInformation.LoadAllByUnitId(unitId, companyId);

                    UnitInformationCostInformation unitInformationCostInformation = new UnitInformationCostInformation(unitInformationTDS);
                    unitInformationCostInformation.LoadAllByUnitId(unitId, companyId);

                    // Store dataset
                    Session["unitInformationTDS"] = unitInformationTDS;
                }

                // ... units_summary.aspx
                if (Request.QueryString["source_page"] == "units_summary.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore datasets
                    unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                }                
            }
            else
            {
                // Restore datasets
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";
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
                    if (Request.QueryString["source_page"] == "units_navigator2.aspx")
                    {
                        url = "./units_navigator2.aspx?source_page=units_delete.aspx&unit_id=" + hdfUnitId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "units_summary.aspx")
                    {
                        url = "./units_summary.aspx?source_page=units_delete.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=0" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_delete.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
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
                // Delete
                int unitId = Int32.Parse(hdfUnitId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                
                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.Delete(unitId);

                UnitInformationChecklistDetails unitInformationChecklistDetails = new UnitInformationChecklistDetails(unitInformationTDS);
                unitInformationChecklistDetails.DeleteAll();

                UnitInformationInspectionDetails unitInformationInspectionDetails = new UnitInformationInspectionDetails(unitInformationTDS);
                unitInformationInspectionDetails.DeleteAll();

                UnitInformationCostExceptionsInformation unitInformationCostExceptionsInformation = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                unitInformationCostExceptionsInformation.DeleteAll(unitId);

                UnitInformationCostInformation unitInformationCostInformation = new UnitInformationCostInformation(unitInformationTDS);
                unitInformationCostInformation.DeleteAll(unitId);

                // Update databse
                UpdateDatabase();

                // Store datasets
                Session["unitInformationTDS"] = unitInformationTDS;

                // Redirect
                string url = "";
                url = "./units_navigator2.aspx?source_page=units_delete.aspx" + GetNavigatorState() + "&update=yes";
                Response.Redirect(url);
            }
        }



        private void UpdateDatabase()
        {
            // Get ids
            int unitId = Int32.Parse(hdfUnitId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string unitType = hdfUnitType.Value;

            // Delete
            DB.Open();
            DB.BeginTransaction();
            try
            {
                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.DeleteDirect(unitId, unitType, companyId);

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
