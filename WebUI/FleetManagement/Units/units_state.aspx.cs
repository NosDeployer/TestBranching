using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_state
    /// </summary>
    public partial class units_state : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["unit_id"] == null) || ((string)Request.QueryString["unit_type"] == null) || ((string)Request.QueryString["unit_state"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_state.aspx");
                }

                // Tag Page
                hdfUnitId.Value = Request.QueryString["unit_id"].ToString();
                hdfUnitType.Value = Request.QueryString["unit_type"].ToString();
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfUnitState.Value = Request.QueryString["unit_state"].ToString();
                hdfNewUnitState.Value = Request.QueryString["new_unit_state"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();

                // If coming from units_summary.aspx
                if ((string)Request.QueryString["source_page"] == "units_summary.aspx")
                {
                    // Store Navigator State and Update control
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int unitId = Int32.Parse(hdfUnitId.Value.Trim());

                    unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                    UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                    unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                    // Store dataset
                    Session["unitInformationTDS"] = unitInformationTDS;
                }

                // Restore dataset
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
            }
            else
            {
                // Restore dataset 
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
            }
        }
              


        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";

            string newState = hdfNewUnitState.Value;

            // Operation check
            switch (newState)
            {
                case "Disposed":
                    tkrmTop.Items[0].Visible = false; //Activate
                    tkrmTop.Items[1].Visible = true;//Dispose
                    tkrmTop.Items[2].Visible = false;//Archive
                    
                    // ...Cancel
                    tkrmTop.Items[3].Visible = true;
                    break;

                case "Active":
                    tkrmTop.Items[0].Visible = true; //Activate
                    tkrmTop.Items[1].Visible = false;//Dispose
                    tkrmTop.Items[2].Visible = false;//Archive

                    // ...Cancel
                    tkrmTop.Items[3].Visible = true;
                    break;

                case "Archived":
                    tkrmTop.Items[0].Visible = false; //Activate
                    tkrmTop.Items[1].Visible = false;//Dispose
                    tkrmTop.Items[2].Visible = true;//Archive

                    // ...Cancel
                    tkrmTop.Items[3].Visible = true;
                    break; 
            }

            // Set instruction
            switch (newState)
            {
                case "Disposed":
                    lblState.Text = "Are you sure you want to dispose this unit?";                    
                    break;

                case "Active":
                    lblState.Text = "Are you sure you want to activate this unit?";                   
                    break;

                case "Archived":
                    lblState.Text = "Are you sure you want to archive this unit?";
                    break;   
            }
                        
            // Validate vehicle info
            string type = hdfUnitType.Value;
            string state = hdfUnitState.Value;

            if (type == "Vehicle")
            {
                lblTitle.Text = "Vehicle Information";                
            }
            else
            {
                lblTitle.Text = "Equipment Information";               
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
                url = "./units_summary.aspx?source_page=units_state.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=0" + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                Response.Redirect(url);
            }
            else
            {
                Page.Validate();

                if (Page.IsValid)
                {
                    UpdateState();
                    UpdateDatabase();

                    string state = hdfNewUnitState.Value;

                    // Operation check
                    switch (state)
                    {
                        case "Disposed":
                            url = "./units_summary.aspx?source_page=units_state.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=yes";
                            break;

                        case "Active":
                            url = "./units_summary.aspx?source_page=units_state.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=yes";
                            break;

                        case "Archived":
                            url = "./units_navigator2.aspx?source_page=units_delete.aspx&unit_id=" + hdfUnitId.Value + GetNavigatorState() + "&update=yes";
                            break;
                    }                    

                    Response.Redirect(url);
                }
            }
        }



        protected void lkbtnCancel_Click(object sender, EventArgs e)
        {
            string url = "./units_summary.aspx?source_page=units_state.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
            Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_state.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void UpdateState()
        {
            int unitId = Int32.Parse(hdfUnitId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
                        
            // ... Get new values
            string unitState = null;           
            string state = hdfNewUnitState.Value;

            // Operation check
            switch (state)
            {
                case "Disposed":
                    unitState = "Disposed";
                    hdfUnitState.Value = "Disposed";
                    break;

                case "Active":
                    unitState = "Active";
                    hdfUnitState.Value = "Active";
                    break;

                case "Archived":
                    unitState = "Archived";
                    hdfUnitState.Value = "Archived";
                    break; 
            }

            // Update data
            UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
            unitInformationUnitDetails.UpdateState(unitId, unitState);
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                unitInformationUnitDetails.SaveState(companyId, hdfNewUnitState.Value);

                DB.CommitTransaction();

                // Store datasets
                unitInformationTDS.AcceptChanges();
                Session["unitInformationTDS"] = unitInformationTDS;
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