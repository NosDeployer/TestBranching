using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement;
using LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// unitsOfMeasurement_navigator
    /// </summary>
    public partial class unitsOfMeasurement_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitsOfMeasurementTDS unitsOfMeasurementTDS;
        protected UnitsOfMeasurementNavigatorTDS unitsOfMeasurementNavigatorTDS;
        protected UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable unitsOfMeasurementNavigator;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if ((!Convert.ToBoolean(Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_VIEW"])) && (!Convert.ToBoolean(Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_ADD"])) && (!Convert.ToBoolean(Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_EDIT"])) && (!Convert.ToBoolean(Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_DELETE"])) )
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in unitsOfMeasurement_navigator.aspx");
                }

                // Tag Page
                Session.Remove("unitOfMeasurementDummy");              
                hdfCompanyId.Value = Session["companyID"].ToString();
                
                // If coming from out
                if (((string)Request.QueryString["source_page"] == "out") || ((string)Request.QueryString["source_page"] == "unitsOfMeasurement_navigator.aspx"))
                {
                    unitsOfMeasurementNavigatorTDS = new UnitsOfMeasurementNavigatorTDS();

                    // Get unitsOfMeasurement records
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    UnitsOfMeasurementNavigatorGateway unitsOfMeasurementNavigatorGateway = new UnitsOfMeasurementNavigatorGateway(unitsOfMeasurementNavigatorTDS);
                    unitsOfMeasurementNavigatorGateway.LoadAll(companyId);

                    // Store dataset
                    Session["unitsOfMeasurementNavigatorTDS"] = unitsOfMeasurementNavigatorTDS;
                    Session["unitsOfMeasurementNavigator"] = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;
                    unitsOfMeasurementNavigator = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;
                }

                // Databind
                Page.DataBind();
            }
            else
            {
                // Restore dataset
                unitsOfMeasurementNavigatorTDS = (UnitsOfMeasurementNavigatorTDS)Session["unitsOfMeasurementNavigatorTDS"];
                unitsOfMeasurementNavigator = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;
            }
        }



        protected void grdUnitsOfMeasurement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Units Of Measurement Gridview, if the gridview is edition mode
            if (grdUnitsOfMeasurement.EditIndex >= 0)
            {
                grdUnitsOfMeasurement.UpdateRow(grdUnitsOfMeasurement.EditIndex, true);
            }

            // Delete unit of Measurement
            int unitOfMeasurementId = (int)e.Keys["UnitOfMeasurementID"];

            UnitsOfMeasurementNavigator model = new UnitsOfMeasurementNavigator(unitsOfMeasurementNavigatorTDS);
            model.Delete(unitOfMeasurementId);

            Session["unitsOfMeasurementNavigatorTDS"] = unitsOfMeasurementNavigatorTDS;
            Session["unitsOfMeasurementNavigator"] = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;
        }



        protected void grdUnitsOfMeasurement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":

                    // Units Of Measurement Gridview, if the gridview is edition mode
                    if (grdUnitsOfMeasurement.EditIndex >= 0)
                    {
                        grdUnitsOfMeasurement.UpdateRow(grdUnitsOfMeasurement.EditIndex, true);
                    }

                    // Add new unit of Measurement
                    GrdUnistOfMeasurementAdd();
                    break;
            }
        }



        protected void grdUnitsOfMeasurement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int unitOfMeasurementId = (int)e.Keys["UnitOfMeasurementID"];
                string description = ((TextBox)grdUnitsOfMeasurement.Rows[e.RowIndex].Cells[1].FindControl("tbxDescriptionEdit")).Text;
                string abbreviation = ((TextBox)grdUnitsOfMeasurement.Rows[e.RowIndex].Cells[1].FindControl("tbxAbbreviationEdit")).Text;

                UnitsOfMeasurementNavigator model = new UnitsOfMeasurementNavigator(unitsOfMeasurementNavigatorTDS);
                model.Update(unitOfMeasurementId, description, abbreviation, false, companyId);

                Session["unitsOfMeasurementNavigatorTDS"] = unitsOfMeasurementNavigatorTDS;
                Session["unitsOfMeasurementNavigator"] = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;
            }
            else
            {
                e.Cancel = true;
            }
        }
        


        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Resources";

            if ((Convert.ToBoolean(Session["sgLFS_RESOURCES_UNITSOFMEASUREMENT_ADMIN"])))
            {
                tkrpbLeftMenu.Visible = true;
            }
            else
            {
                tkrpbLeftMenu.Visible = false;
            }
        }





        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdUnitsOfMeasurement_DataBound(object sender, EventArgs e)
        {
            AddUnitsOfMeasurementNewEmptyFix(grdUnitsOfMeasurement);
        }



        protected void grdUnitsOfMeasurement_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Comments Gridview, if the gridview is edition mode
            if (grdUnitsOfMeasurement.EditIndex >= 0)
            {
                grdUnitsOfMeasurement.UpdateRow(grdUnitsOfMeasurement.EditIndex, true);
            }
        }
                
        



        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSave":
                    Save();

                    // Redirect
                    string url = "./unitsOfMeasurement_navigator.aspx?source_page=unitsOfMeasurement_navigator.aspx";

                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable GetUnitOfMeasurementNew()
        {
            unitsOfMeasurementNavigator = (UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)Session["unitOfMeasurementDummy"];

            if (unitsOfMeasurementNavigator == null)
            {
                unitsOfMeasurementNavigator = ((UnitsOfMeasurementNavigatorTDS)Session["unitsOfMeasurementNavigatorTDS"]).UnitsOfMeasurementNavigator;
            }

            return unitsOfMeasurementNavigator;
        }



        public void DummyUnitOfMeasurementNew(int UnitOfMeasurementID)
        {
        }








        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./unitsOfMeasurement_navigator.js");
        }



        private void Save()
        {
            // Validate data
            bool validData = true;

            if (FooterValidate())
            {
                Page.Validate("dataNew");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }

            // For valid data
            if (validData)
            {
                // If the gridview is edition mode
                if (grdUnitsOfMeasurement.EditIndex >= 0)
                {
                    grdUnitsOfMeasurement.UpdateRow(grdUnitsOfMeasurement.EditIndex, true);
                }

                // Save notes data                
                GrdUnistOfMeasurementAdd();                

                // Update database
                UpdateDatabase();               
            }
        }


        
        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                UnitsOfMeasurementNavigator unitsOfMeasurementNavigator = new UnitsOfMeasurementNavigator(unitsOfMeasurementNavigatorTDS);
                unitsOfMeasurementNavigator.Save();

                DB.CommitTransaction();

                // Store datasets
                unitsOfMeasurementNavigatorTDS.AcceptChanges();
                Session["unitsOfMeasurementNavigatorTDS"] = unitsOfMeasurementNavigatorTDS;
                Session["unitsOfMeasurementNavigator"] = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddUnitsOfMeasurementNewEmptyFix(GridView grdView)
        {
            if (grdUnitsOfMeasurement.Rows.Count == 0)
            {
                UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable dt = new UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable();
                dt.AddUnitsOfMeasurementNavigatorRow(-1, "", "", false, -1, false);
                Session["unitOfMeasurementDummy"] = dt;

                grdUnitsOfMeasurement.DataBind();
            }

            // Normally executes at all postbacks
            if (grdUnitsOfMeasurement.Rows.Count == 1)
            {
                UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable dt = (UnitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigatorDataTable)Session["unitOfMeasurementDummy"];
                if (dt != null)
                {
                    grdUnitsOfMeasurement.Rows[0].Visible = false;
                    grdUnitsOfMeasurement.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdUnistOfMeasurementAdd()
        {
            ViewState["pageIndex"] = grdUnitsOfMeasurement.PageIndex;

            if (FooterValidate())
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string description = ((TextBox)grdUnitsOfMeasurement.FooterRow.FindControl("tbxDescriptionNew")).Text.Trim();
                string abbreviation = ((TextBox)grdUnitsOfMeasurement.FooterRow.FindControl("tbxAbbreviationNew")).Text.Trim();

                UnitsOfMeasurementNavigator model = new UnitsOfMeasurementNavigator(unitsOfMeasurementNavigatorTDS);
                model.Insert(description, abbreviation, false, companyId, false);

                Session.Remove("unitOfMeasurementDummy");
                Session["unitsOfMeasurementNavigatorTDS"] = unitsOfMeasurementNavigatorTDS;
                Session["unitsOfMeasurementNavigator"] = unitsOfMeasurementNavigatorTDS.UnitsOfMeasurementNavigator;

                grdUnitsOfMeasurement.DataBind();
                grdUnitsOfMeasurement.PageIndex = grdUnitsOfMeasurement.PageCount - 1;
            }
        }



        protected bool FooterValidate()
        {
            Page.Validate("dataNew");
            if (Page.IsValid)
            {
                string description = ((TextBox)grdUnitsOfMeasurement.FooterRow.FindControl("tbxDescriptionNew")).Text.Trim();
                string abbreviation = ((TextBox)grdUnitsOfMeasurement.FooterRow.FindControl("tbxAbbreviationNew")).Text.Trim();

                if ((description != "") || (abbreviation != ""))
                {
                    return true;
                }
            }

            return false;            
        }



    }
}