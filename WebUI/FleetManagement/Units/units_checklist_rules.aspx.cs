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
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_checklist_rules
    /// </summary>
    public partial class units_checklist_rules : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected UnitInformationTDS unitInformationTDS;
        protected UnitInformationTDS.ChecklistDetailsDataTable unitsChecklistRulesEdit;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["unit_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_checklist_rules.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUnitId.Value = Request.QueryString["unit_id"].ToString();
                hdfUpdate.Value = "no";

                // If coming from 
                // ... units_summary.aspx and units_edit.aspx
                if (Request.QueryString["source_page"] == "units_summary.aspx" || Request.QueryString["source_page"] == "units_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    unitInformationTDS = new UnitInformationTDS();
                    unitsChecklistRulesEdit = new UnitInformationTDS.ChecklistDetailsDataTable();

                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int unitId = Int32.Parse(hdfUnitId.Value.Trim());

                    // Load
                    UnitInformationTDS dataSet = new UnitInformationTDS();
                    dataSet.ChecklistDetails.Merge(unitsChecklistRulesEdit, true);
                    UnitInformationChecklistDetails model = new UnitInformationChecklistDetails(dataSet);

                    model.LoadByUnitIdWithoutInProgressRules(unitId, int.Parse(hdfCompanyId.Value));

                    // Store tables
                    unitsChecklistRulesEdit = (UnitInformationTDS.ChecklistDetailsDataTable)model.Table;
                    Session["unitsChecklistRulesEdit"] = unitsChecklistRulesEdit;

                    grdChecklistRulesInformation.DataBind();
                }
            }
            else
            {
                // Restore datasets
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                unitsChecklistRulesEdit = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesEdit"];
            }
        }



        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Unit Checklist";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void cvGrdChecklistRulesInformation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            CustomValidator cvChecklistRules = (CustomValidator)source;
            args.IsValid = true;
            string messageError = "";

            if (grdChecklistRulesInformation.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdChecklistRulesInformation.Rows)
                {
                    string ChecklistRuleName = ((Label)row.FindControl("lblColumn")).Text;

                    try
                    {
                        if (((DropDownList)row.FindControl("ddlState")).SelectedValue != "Inactive" && ((DropDownList)row.FindControl("ddlState")).SelectedValue != "Unknown")
                        {
                            if (((Label)row.FindControl("lblFrequency")).Text == "Only once")
                            {
                                if (((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue)
                                {
                                    if (!((CheckBox)row.FindControl("cbxDone")).Checked)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("Done should be checked since {0} has a Last Service<br>", ChecklistRuleName);
                                    }

                                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("The Next Due date in {0} must be empty<br>", ChecklistRuleName);
                                    }
                                }
                                else
                                {
                                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        if (((CheckBox)row.FindControl("cbxDone")).Checked)
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("Done should be un-checked since {0} has a Next Due<br>", ChecklistRuleName);
                                        }
                                    }
                                    else
                                    {
                                        if (!((CheckBox)row.FindControl("cbxDone")).Checked)
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("The Next Due date in {0} must be inserted<br>", ChecklistRuleName);
                                        }
                                        else
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("The Last Service date in {0} must be inserted<br>", ChecklistRuleName);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue)
                                {
                                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        DateTime newLastService = ((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.Value;
                                        DateTime newNextDue = ((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.Value;
                                        DateTime rightNextDue = DateTime.Now;
                                        DateTime timeToAdded = new DateTime(((DateTime)newLastService).Year, ((DateTime)newLastService).Month, ((DateTime)newLastService).Day);
                                        string frequency = ((Label)row.FindControl("lblFrequency")).Text;

                                        if (frequency == "Monthly") rightNextDue = timeToAdded.AddMonths(1);
                                        if (frequency == "Every 2 months") rightNextDue = timeToAdded.AddMonths(2);
                                        if (frequency == "Every 3 months") rightNextDue = timeToAdded.AddMonths(3);
                                        if (frequency == "Every 4 months") rightNextDue = timeToAdded.AddMonths(4);
                                        if (frequency == "Every 6 months") rightNextDue = timeToAdded.AddMonths(6);
                                        if (frequency == "Yearly") rightNextDue = timeToAdded.AddYears(1);

                                        if (newNextDue != rightNextDue)
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("The dates in {0} are not consistent with the frequency of the rule<br>", ChecklistRuleName);
                                        }
                                    }
                                }
                                else
                                {
                                    if (!((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("The Last Service date or Next Due date in {0} must be inserted<br>", ChecklistRuleName);
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (((DropDownList)row.FindControl("ddlState")).SelectedValue == "Inactive")
                            {
                                if ((((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue) || (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue) || (((CheckBox)row.FindControl("cbxDone")).Checked))
                                {
                                    args.IsValid = false;
                                    messageError += String.Format("The state in {0} is inactive, insert data not allowed<br>", ChecklistRuleName);
                                }
                            }
                        }
                    }                    
                    catch
                    {
                    }
                }
            }

            cvChecklistRules.Text = messageError;
        }



        protected void grdChecklistRulesInformation_DataBound(object sender, EventArgs e)
        {
            ChecklistRulesInformationEmptyFix(grdChecklistRulesInformation);
        }



        protected void grdChecklistRulesInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                if (((Label)e.Row.FindControl("lblFrequency")).Text != "Only once")
                {
                    CheckBox cbxDone = ((CheckBox)e.Row.FindControl("cbxDone"));
                    cbxDone.Visible = false;
                }
            }
        }



        protected void grdChecklistRulesInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ChecklistRulesInformationProcessGrid();
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
            
            contentVariables += "var hdfUnitIdId = '" + hdfUnitId.ClientID + "';";
            contentVariables += "var hdfCompanyIdId = '" + hdfCompanyId.ClientID + "';";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_checklist_rules.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Save()
        {
            // Validate page
            Page.Validate();

            if (Page.IsValid)
            {
                ChecklistRulesInformationProcessGrid();

                Session.Remove("unitsChecklistRulesEditDummy");
                Session["unitsChecklistRulesEdit"] = unitsChecklistRulesEdit;

                UpdateDatabase();

                hdfUpdate.Value = "yes";

                // If coming from 
                // ... units_summary.aspx or units_edit.aspx
                if (Request.QueryString["source_page"] == "units_summary.aspx" || Request.QueryString["source_page"] == "units_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // process view
                UnitInformationTDS dataset = new UnitInformationTDS();
                dataset.ChecklistDetails.Merge(unitsChecklistRulesEdit, true);

                UnitInformationChecklistDetails model = new UnitInformationChecklistDetails(dataset);
                model.Save(unitId, companyId);
                
                DB.CommitTransaction();

                // Store datasets
                unitInformationTDS.AcceptChanges();
                Session["unitInformationTDS"] = unitInformationTDS;
                Session["unitsChecklistRulesEdit"] = unitsChecklistRulesEdit;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }        



        public UnitInformationTDS.ChecklistDetailsDataTable GetChecklistRulesInformation()
        {
            unitsChecklistRulesEdit = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesEditDummy"];

            if (unitsChecklistRulesEdit == null)
            {
                unitsChecklistRulesEdit = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesEdit"];
            }

            return unitsChecklistRulesEdit;
        }



        protected void ChecklistRulesInformationEmptyFix(GridView grdChecklistRulesInformation)
        {
            if (grdChecklistRulesInformation.Rows.Count == 0)
            {
                DateTime lastService = new DateTime();
                DateTime nextDue = new DateTime();
                UnitInformationTDS.ChecklistDetailsDataTable dt = new UnitInformationTDS.ChecklistDetailsDataTable();
                dt.AddChecklistDetailsRow(0, "", "", lastService, nextDue, false, "Unknown", false);
                Session["unitsChecklistRulesEditDummy"] = dt;

                grdChecklistRulesInformation.DataBind();
            }

            // normally executes at all postbacks
            if (grdChecklistRulesInformation.Rows.Count == 1)
            {
                UnitInformationTDS.ChecklistDetailsDataTable dt = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesEditDummy"];
                if (dt != null)
                {
                    // hide row
                    grdChecklistRulesInformation.Rows[0].Visible = false;
                    grdChecklistRulesInformation.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyChecklistRulesNew(int RuleID)
        {
        }



        private void ChecklistRulesInformationProcessGrid()
        {
            UnitInformationTDS dataSet = new UnitInformationTDS();
            dataSet.ChecklistDetails.Merge(unitsChecklistRulesEdit, true);
            UnitInformationChecklistDetails model = new UnitInformationChecklistDetails(dataSet);

            // update rows
            if (Session["unitsChecklistRulesEditDummy"] == null)
            {
                foreach (GridViewRow row in grdChecklistRulesInformation.Rows)
                {
                    int ruleId = int.Parse(grdChecklistRulesInformation.DataKeys[row.RowIndex].Values["RuleID"].ToString());
                    DateTime? lastService = null;
                    DateTime? nextDue = null;
                    bool done = ((CheckBox)row.FindControl("cbxDone")).Checked;
                    string state = ((DropDownList)row.FindControl("ddlState")).SelectedValue;

                    if (((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue)
                    {
                        lastService = ((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.Value;
                    }

                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                    {
                        nextDue = ((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.Value;
                    }

                    model.Update(ruleId, lastService, nextDue, state, done);
                }

                model.Table.AcceptChanges();

                unitsChecklistRulesEdit = (UnitInformationTDS.ChecklistDetailsDataTable)model.Table;
                Session["unitsChecklistRulesEdit"] = unitsChecklistRulesEdit;
            }
        }



    }
}