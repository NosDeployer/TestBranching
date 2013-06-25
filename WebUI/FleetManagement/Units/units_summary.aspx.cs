using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.RAF;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_summary
    /// </summary>
    public partial class units_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitInformationTDS unitInformationTDS;
        protected UnitInformationTDS.ChecklistDetailsDataTable unitsChecklistRulesTemp;
        protected UnitInformationTDS.ServiceDetailsDataTable unitsServicesTemp;
        protected UnitInformationTDS.InspectionDetailsDataTable unitsInspectionsTemp;
        protected UnitInformationTDS.NoteInformationDataTable unitsNotesTemp;
        protected UnitInformationTDS.CostInformationDataTable unitInformationCosts;
        protected UnitInformationTDS.CostExceptionsInformationDataTable unitInformationCostsExceptions;
        protected CategoriesTDS categoriesTDS;
        protected CompanyLevelsTDS companyLevelsTDS;





        
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"]) && (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_EDIT"]) || Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_COMMENTS"]))))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["unit_id"] == null) || ((string)Request.QueryString["unit_type"] == null) || ((string)Request.QueryString["unit_state"] == null)  || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_summary.aspx");
                }

                // Tag Page                
                hdfUnitId.Value = Request.QueryString["unit_id"].ToString();
                hdfUnitType.Value = Request.QueryString["unit_type"].ToString();
                hdfUnitState.Value = Request.QueryString["unit_state"].ToString();
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                                                
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int unitId = Int32.Parse(hdfUnitId.Value.Trim());

                Session.Remove("unitsChecklistRulesTempDummy");
                Session.Remove("unitsServicesTempDummy");
                Session.Remove("unitsInspectionsTempDummy");
                Session.Remove("unitsNotesTempDummy");
                Session.Remove("unitsCostsDummy");
                Session.Remove("unitsCostsExceptionsDummy");
                Session.Remove("costIdSelected");

                // If coming from 
                // ... units_navigator2.aspx or wucAlarms.ascx.cs
                if ((Request.QueryString["source_page"] == "units_navigator2.aspx") || (Request.QueryString["source_page"] == "wucAlarms.ascx"))
                {                    
                    StoreNavigatorState();
                    ViewState["update"] = "no";                    

                    // ... ... Set initial tab
                    if ((string)Session["dialogOpenedUnits"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        unitInformationTDS = new UnitInformationTDS();
                        unitsChecklistRulesTemp = new UnitInformationTDS.ChecklistDetailsDataTable();
                        unitsServicesTemp = new UnitInformationTDS.ServiceDetailsDataTable();
                        unitsInspectionsTemp = new UnitInformationTDS.InspectionDetailsDataTable();
                        unitsNotesTemp = new UnitInformationTDS.NoteInformationDataTable();
                        
                        UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                        unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                        UnitInformationInspectionDetails unitInformationInspectionDetailsForEdit = new UnitInformationInspectionDetails(unitInformationTDS);
                        unitInformationInspectionDetailsForEdit.LoadByUnitId(unitId, companyId);

                        UnitInformationNoteDetails unitInformationNoteDetails = new UnitInformationNoteDetails(unitInformationTDS);
                        unitInformationNoteDetails.LoadByUnitId(unitId, companyId);

                        UnitInformationCostInformation unitInformationCostInformation = new UnitInformationCostInformation(unitInformationTDS);
                        unitInformationCostInformation.LoadAllByUnitId(unitId, companyId);

                        UnitInformationCostExceptionsInformation unitInformationCostExceptionsInformation = new UnitInformationCostExceptionsInformation(unitInformationTDS);
                        unitInformationCostExceptionsInformation.LoadAllByUnitId(unitId, companyId);

                        Session["costIdSelected"] = 0;

                        // ... For Categories
                        categoriesTDS = new CategoriesTDS();
                        Category category = new Category(categoriesTDS);
                        category.LoadByUnitType(hdfUnitType.Value, int.Parse(hdfCompanyId.Value));

                        // .. For Company Levels
                        companyLevelsTDS = new CompanyLevelsTDS();
                        CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                        companyLevel.Load(int.Parse(hdfCompanyId.Value));
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabUnits"];

                        // Restore datasets
                        unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                        unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
                        unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
                        unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
                        unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTemp"];
                        categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnits"];
                        companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];
                    }

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["unitInformationTDS"] = unitInformationTDS;
                    Session["unitsChecklistRulesTemp"] = unitsChecklistRulesTemp;
                    Session["unitsServicesTemp"] = unitsServicesTemp;
                    Session["unitsInspectionsTemp"] = unitsInspectionsTemp;
                    Session["unitsNotesTemp"] = unitsNotesTemp;
                    Session["categoriesTDSForUnits"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;                    
                }

                // ... units_add.aspx
                if (Request.QueryString["source_page"] == "units_add.aspx")
                {
                    ViewState["update"] = "yes";

                    hdfActiveTab.Value = Request.QueryString["active_tab"];

                    unitInformationTDS = new UnitInformationTDS();
                    unitsChecklistRulesTemp = new UnitInformationTDS.ChecklistDetailsDataTable();
                    unitsServicesTemp = new UnitInformationTDS.ServiceDetailsDataTable();
                    unitsInspectionsTemp = new UnitInformationTDS.InspectionDetailsDataTable();
                    unitsNotesTemp = new UnitInformationTDS.NoteInformationDataTable();

                    UnitInformationUnitDetails unitInformationUnitDetails = new UnitInformationUnitDetails(unitInformationTDS);
                    unitInformationUnitDetails.LoadByUnitId(unitId, companyId);

                    UnitInformationNoteDetails unitInformationNoteDetails = new UnitInformationNoteDetails(unitInformationTDS);
                    unitInformationNoteDetails.LoadByUnitId(unitId, companyId);

                    // ... For Categories
                    categoriesTDS = new CategoriesTDS();
                    Category category = new Category(categoriesTDS);
                    category.LoadByUnitType(hdfUnitType.Value, int.Parse(hdfCompanyId.Value));

                    // .. For Company Levels
                    companyLevelsTDS = new CompanyLevelsTDS();
                    CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                    companyLevel.Load(int.Parse(hdfCompanyId.Value));

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["unitInformationTDS"] = unitInformationTDS;
                    Session["unitsChecklistRulesTemp"] = unitsChecklistRulesTemp;
                    Session["unitsServicesTemp"] = unitsServicesTemp;
                    Session["unitsInspectionsTemp"] = unitsInspectionsTemp;
                    Session["unitsNotesTemp"] = unitsNotesTemp;
                    Session["categoriesTDSForUnits"] = categoriesTDS;
                    Session["companyLevelsTDS"] = companyLevelsTDS;     
                }

                // ... units_delete.aspx, units_edit.aspx or units_state.aspx
                if ((Request.QueryString["source_page"] == "units_delete.aspx") || (Request.QueryString["source_page"] == "units_edit.aspx") || (Request.QueryString["source_page"] == "units_state.aspx") )
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                    unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
                    unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
                    unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
                    unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTemp"];
                    categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnits"];
                    companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];                    

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedUnits"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabUnits"];
                    }

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
                }

                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", 0, 0);
                odsCostsExceptions.FilterExpression = filterOptions;

                // ... Data for current unit               
                LoadUnitData(unitId, companyId);                                
            }
            else
            {
                // Restore datasets
                unitInformationTDS = (UnitInformationTDS)Session["unitInformationTDS"];
                unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
                unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
                unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
                unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTemp"];
                categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnits"];
                companyLevelsTDS = (CompanyLevelsTDS)Session["companyLevelsTDS"];                

                // Set initial tab
                int activeTabUnits = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTabUnits;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "FleetManagement";         
                        
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int unitId = Int32.Parse(hdfUnitId.Value);
            
            // Validate unit info
            string type = hdfUnitType.Value;
            string state = hdfUnitState.Value;
            
            if (type == "Vehicle")
            {
                lblTitle.Text = "Vehicle Information";
                tpPlateData.Enabled = true;
                tpTechnical.Enabled = true;
            }
            else
            {
                lblTitle.Text = "Equipment Information";
                tpPlateData.Enabled = false;
                tpTechnical.Enabled = false;               
            }

            //[3] = Dispose option
            //[4] = Activate option
            if (state == "Disposed")
            {
                lblDispositionDate.Visible = true;
                tbxDispositionDate.Visible = true;

                lblDispositionReason.Visible = true;
                tbxDispositionReason.Visible = true;

                tkrmTop.Items[3].Visible = false; // Dispose
                tkrmTop.Items[4].Visible = true; // Activate

                tkrmTop.Items[5].Visible = true; // Remove
            }
            else
            {
                lblDispositionDate.Visible = false;
                tbxDispositionDate.Visible = false;

                lblDispositionReason.Visible = false;
                tbxDispositionReason.Visible = false;

                tkrmTop.Items[4].Visible = false; // Activate

                if (!IsUnitWithServicesActives(unitId, companyId))
                {
                    tkrmTop.Items[3].Visible = true; // Dispose                    
                }
                else
                {
                    tkrmTop.Items[3].Visible = false; // Dispose
                }
            }

            if (state == "Disposed")
            {
                tkrmTop.Items[2].Visible = false; // Add SR
            }

            if (Delete(unitId, companyId))
            {
                tkrmTop.Items[1].Visible = true; // Delete
            }
            else
            {
                tkrmTop.Items[1].Visible = false; // Delete
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void cbxSelectedCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("unitCostsExceptionsDummy");

            if (checkbox.Checked)
            {
                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                foreach (GridViewRow rowTemp in grdCosts.Rows)
                {
                    int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                    if (costId != costTemp)
                    {
                        ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                    }
                }

                Session.Remove("costIdSelected");
                Session["costIdSelected"] = costId;
            }

            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
            odsCostsExceptions.FilterExpression = filterOptions;
        }



         protected void btnChecklistOnClick(object sender, EventArgs e)
         {
             // Store active tab for postback
             Session["activeTabUnits"] = "4";
             Session["dialogOpenedUnits"] = "1";

             // Open Dialog                       
             string script = "<script language='javascript'>";
             string url = "./units_checklist_rules.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value;
             script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=630, height=440')", url);
             script = script + "</script>";
             ScriptManager.RegisterStartupScript(this, this.GetType(), "Checklist", script, false);
         }



         protected void btnOpenServiceOnClick(object sender, EventArgs e)
         {
             foreach (GridViewRow row in grdServices.Rows)
             {
                 if (((CheckBox)row.FindControl("cbxSelectedService")).Checked)
                 {
                     int serviceId = Int32.Parse(((Label)row.FindControl("lblServiceId")).Text.Trim());

                     // Redirect
                     string url = "./../Services/services_summary.aspx?source_page=services_add_request.aspx&dashboard=False&service_id=" + serviceId + "&active_tab=0" + GetNavigatorStateForServices();
                     Response.Redirect(url);
                 }
             }
         }



         protected void btnDownload_Click(object sender, EventArgs e)
         {
             string fileName = "";
             string originalFileName = "";

             AppSettingsReader appSettingReader = new AppSettingsReader();
             string websitePath = appSettingReader.GetValue("WebsitePath", typeof(System.String)).ToString();

             string fullPath = string.Format("{0}\\Files\\LF_DGHOUGDH\\Library\\{1}", websitePath, fileName);
             FileInfo file = new FileInfo(fullPath);

             // Checking if file exists
             if (file.Exists)
             {
                 Response.ClearContent();
                 Response.AddHeader("Content-Disposition", "attachment; filename=" + originalFileName);
                 Response.AppendHeader("Content-Length", file.Length.ToString());

                 switch (file.Extension.ToLower())
                 {
                     case ".html":
                         Response.ContentType = "text/html";
                         break;

                     case ".htm":
                         Response.ContentType = "text/html";
                         break;

                     case ".txt":
                         Response.ContentType = "text/plain";
                         break;

                     case ".gif":
                         Response.ContentType = "image/gif";
                         break;

                     case ".png":
                         Response.ContentType = "image/x-png";
                         break;

                     case ".jpeg":
                         Response.ContentType = "image/jpeg";
                         break;

                     case ".jpg":
                         Response.ContentType = "image/jpeg";
                         break;

                     case "jpe":
                         Response.ContentType = "image/jpeg";
                         break;

                     case ".bmp":
                         Response.ContentType = "image/x-ms-bmp";
                         break;

                     case ".wav":
                         Response.ContentType = "audio/x-wav";
                         break;

                     case ".midi":
                         Response.ContentType = "audio/midi";
                         break;

                     case ".mp3":
                         Response.ContentType = "audio/mpeg";
                         break;

                     case ".mpeg":
                         Response.ContentType = "video/mpeg";
                         break;

                     case ".mpg":
                         Response.ContentType = "video/mpeg";
                         break;

                     case "mpe":
                         Response.ContentType = "video/mpeg";
                         break;

                     case ".mov":
                         Response.ContentType = "video/quicktime";
                         break;

                     case ".avi":
                         Response.ContentType = "video/x-msvideo";
                         break;

                     case ".pdf":
                         Response.ContentType = "application/pdf";
                         break;

                     case ".zip":
                         Response.ContentType = "application/zip";
                         break;

                     case ".ppt":
                         Response.ContentType = "application/vnd.ms-powerpoint";
                         break;

                     case ".doc":
                         Response.ContentType = "application/msword";
                         break;

                     case ".xls":
                         Response.ContentType = "application/vnd.ms-excel";
                         break;

                     case ".rtf":
                         Response.ContentType = "text/rtf";
                         break;

                     case ".exe":
                         Response.ContentType = "application/octet-stream";
                         break;

                     default:
                         Response.ContentType = "Application/X-unknown";
                         break;
                 }

                 Response.WriteFile(file.FullName);
                 Response.End();
             }
         }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

         protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
         {
            // Store active tab for postback
            Session["activeTabUnits"] = "0";
            Session["dialogOpenedUnits"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./units_edit.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mDelete":
                    url = "./units_delete.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mDispose":
                    url = "./units_state.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&new_unit_state=Disposed";
                    break;

                case "mActivate":
                    url = "./units_state.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&new_unit_state=Active";
                    break;

                case "mArchive":
                    url = "./units_state.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&new_unit_state=Archived";
                    break;

                case "mLastSearch":
                    url = "./units_navigator2.aspx?source_page=units_summary.aspx&unit_id=" + hdfUnitId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = UnitsNavigator.GetPreviousId((UnitsNavigatorTDS)Session["unitsNavigatorTDS"], Int32.Parse(hdfUnitId.Value));
                    if (previousId != Int32.Parse(hdfUnitId.Value))
                    {
                        // ... Redirect
                        url = "./units_summary.aspx?source_page=units_navigator2.aspx&unit_id=" + previousId.ToString() + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = UnitsNavigator.GetNextId((UnitsNavigatorTDS)Session["unitsNavigatorTDS"], Int32.Parse(hdfUnitId.Value));
                    if (nextId != Int32.Parse(hdfUnitId.Value))
                    {
                        // ... Redirect
                        url = "./units_summary.aspx?source_page=units_navigator2.aspx&unit_id=" + nextId.ToString() + "&unit_type=" + hdfUnitType.Value + "&unit_state=" + hdfUnitState.Value + "&active_tab=" + hdfActiveTab.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



         protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
         {
            // Store active tab for postback
            Session["activeTabUnits"] = "0";
            Session["dialogOpenedUnits"] = "0";
            Session.Remove("libraryTDSForUnits");

            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./units_navigator.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 2)
                {
                    return string.Format("{0:0.00}", Convert.ToDecimal(value));
                }
                else
                {
                    return string.Format("{0:0.0}", Convert.ToDecimal(value));
                }
            }
            else
            {
                return "";
            }
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUnitIdId = '" + hdfUnitId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }        



        private string GetNavigatorStateForServices()
        {
            // Columns to display
            int companyId = Int32.Parse(Session["companyID"].ToString());
            string fmType = "Services";
            string columnsToDisplay = "&columns_to_display=";

            FmTypeViewDisplay fmTypeViewDisplay = new FmTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + fmTypeViewDisplay.GetColumnsByDefault(fmType, companyId, true);

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";

            // For Views
            searchOptions = searchOptions + "&search_ddlView=-2";

            // Other values
            searchOptions = searchOptions + "&search_state=1";
            searchOptions = searchOptions + "&search_sort_by=1";
            searchOptions = searchOptions + "&btn_origin=Search";

            // Return
            return columnsToDisplay + searchOptions;
        }



        #region Load Functions

        private void LoadUnitData(int unitId, int companyId)
        {
            // Load Data
            LoadBasicData(unitId);
            LoadDetailedData(unitId);
            LoadChecklitData(unitId);
            LoadServiceData(unitId);
            LoadInspectionData(unitId);
            LoadNotes(unitId, companyId);
        }



        private void LoadBasicData(int unitId)
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
            if (unitInformationUnitDetailsGateway.Table.Rows.Count > 0)
            {                
                // Load unit basic data
                tbxUnitState.Text = unitInformationUnitDetailsGateway.GetState(unitId);
                tbxCode.Text = unitInformationUnitDetailsGateway.GetUnitCode(unitId);
                tbxDescription.Text = unitInformationUnitDetailsGateway.GetDescription(unitId);
                tbxVinSn.Text = unitInformationUnitDetailsGateway.GetVin(unitId);
                tbxManufacturer.Text = unitInformationUnitDetailsGateway.GetManufacturer(unitId);
                tbxModel.Text = unitInformationUnitDetailsGateway.GetModel(unitId);
                tbxYear.Text = unitInformationUnitDetailsGateway.GetYear_(unitId);
                if (unitInformationUnitDetailsGateway.GetIsTowable(unitId)) cbxIsTowable.Checked = true; else cbxIsTowable.Checked = false;
                tbxInsuranceClass.Text = unitInformationUnitDetailsGateway.GetInsuranceClass(unitId);
                if (unitInformationUnitDetailsGateway.GetInsuranceClass(unitId) == "Ryder Specified")
                {
                    lblRyderSpecified.Visible = true;
                    tbxRyderSpecified.Visible = true;
                    tbxRyderSpecified.Text = unitInformationUnitDetailsGateway.GetInsuranceClassRyderSpecified(unitId);
                }
                else
                {
                    lblRyderSpecified.Visible = false;
                    tbxRyderSpecified.Visible = false;
                }
                tbxPurchasePrice.Text = ""; if (unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).HasValue) tbxPurchasePrice.Text = Math.Round(unitInformationUnitDetailsGateway.GetPurchasePrice(unitId).Value, 2).ToString();
                tbxScrapDate.Text = ""; if (unitInformationUnitDetailsGateway.GetScrapDate(unitId).HasValue) tbxScrapDate.Text = unitInformationUnitDetailsGateway.GetScrapDate(unitId).Value.ToShortDateString();
                tbxSaleProceeds.Text = ""; if (unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).HasValue) tbxSaleProceeds.Text = Math.Round(unitInformationUnitDetailsGateway.GetSaleProceeds(unitId).Value, 2).ToString();
            }
        }



        private void LoadDetailedData(int unitId)
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);
            if (unitInformationUnitDetailsGateway.Table.Rows.Count > 0)
            {
                // Load for General Tab
                if (unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId).HasValue) tbxAcquisitionDate.Text = ((DateTime)unitInformationUnitDetailsGateway.GetAcquisitionDate(unitId)).ToShortDateString();
                if (unitInformationUnitDetailsGateway.GetDispositionDate(unitId).HasValue) tbxDispositionDate.Text = ((DateTime)unitInformationUnitDetailsGateway.GetDispositionDate(unitId)).ToShortDateString();
                tbxDispositionReason.Text = unitInformationUnitDetailsGateway.GetDispositionReason(unitId);                
                int companyLevelId = unitInformationUnitDetailsGateway.GetCompanyLevelId(unitId);

                GetNodeForCategory(tvCategoriesRoot.Nodes, 0);
                GetNodeForCompanyLevels(tvCompanyLevelsRoot.Nodes, 0, companyLevelId);

                foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
                {
                    GetCategoriesParent(nodes);
                }

                foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
                {
                    GetCompanyLevelsParent(nodes);
                }

                // Load for Plate and Technical Tabs
                if (unitInformationUnitDetailsGateway.GetType(unitId) == "Vehicle")
                {
                    if (unitInformationUnitDetailsGateway.GetLicenseCountry(unitId).HasValue)
                    {
                        Int64 countryId = (Int64)unitInformationUnitDetailsGateway.GetLicenseCountry(unitId);
                        CountryGateway countryGateway = new CountryGateway();
                        countryGateway.LoadByCountryId(countryId);
                        tbxLicenseCountry.Text = countryGateway.GetName(countryId);
                    }

                    if (unitInformationUnitDetailsGateway.GetLicenseState(unitId).HasValue)
                    {
                        Int64 stateId = (Int64)unitInformationUnitDetailsGateway.GetLicenseState(unitId);
                        ProvinceGateway provinceGateway = new ProvinceGateway();
                        provinceGateway.LoadByProvinceId(stateId);
                        tbxLicenseState.Text = provinceGateway.GetName(stateId);
                    }

                    tbxLicensePlateNumber.Text = unitInformationUnitDetailsGateway.GetLicensePlateNumbver(unitId);
                    tbxActualWeight.Text = unitInformationUnitDetailsGateway.GetActualWeight(unitId);
                    tbxRegisteredWeight.Text = unitInformationUnitDetailsGateway.GetRegisteredWeight(unitId);
                    tbxTireSizeFront.Text = unitInformationUnitDetailsGateway.GetTireSizeFront(unitId);
                    tbxTireSizeBack.Text = unitInformationUnitDetailsGateway.GetTireSizeBack(unitId);
                    tbxNumberOfAxes.Text = unitInformationUnitDetailsGateway.GetNumberOfAxes(unitId);
                    tbxFuelType.Text = unitInformationUnitDetailsGateway.GetFuelType(unitId);
                    tbxBeginningOdometer.Text = unitInformationUnitDetailsGateway.GetBeginningOdometer(unitId);
                    cbxIsReeferEquipped.Checked = unitInformationUnitDetailsGateway.GetIsReeferEquipped(unitId);
                    cbxIsPtoEquipped.Checked = unitInformationUnitDetailsGateway.GetIsPTOEquipped(unitId);
                  
                }

                // Load for Ownership tab
                tbxOwnerType.Text = unitInformationUnitDetailsGateway.GetOwnerType(unitId);
                tbxOwnerName.Text = unitInformationUnitDetailsGateway.GetOwnerName(unitId);
                tbxOwnerContact.Text = unitInformationUnitDetailsGateway.GetOwnerContact(unitId);
                
                if (unitInformationUnitDetailsGateway.GetOwnerCountry(unitId).HasValue)
                {
                    Int64 countryId = (Int64)unitInformationUnitDetailsGateway.GetOwnerCountry(unitId);
                    CountryGateway countryGateway = new CountryGateway();
                    countryGateway.LoadByCountryId(countryId);
                    tbxOwnerCountry.Text = countryGateway.GetName(countryId);
                    
                    if (unitInformationUnitDetailsGateway.GetOwnerState(unitId).HasValue)
                    {
                        Int64 stateId = (Int64)unitInformationUnitDetailsGateway.GetOwnerState(unitId);
                        ProvinceGateway provinceGateway = new ProvinceGateway();
                        provinceGateway.LoadByProvinceId(stateId);
                        tbxOwnerState.Text = provinceGateway.GetName(stateId);
                    }
                }

                // Load for Inspection Tab (Qualification data)
                if (unitInformationUnitDetailsGateway.GetQualifiedDate(unitId).HasValue) tbxQualifiedDate.Text = ((DateTime)unitInformationUnitDetailsGateway.GetQualifiedDate(unitId)).ToShortDateString();
                if (unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId).HasValue) tbxNotQualifiedDate.Text = ((DateTime)unitInformationUnitDetailsGateway.GetNotQualifiedDate(unitId)).ToShortDateString();
                tbxIfNotQualifiedExplain.Text = unitInformationUnitDetailsGateway.GetNotQualifiedExplain(unitId);
            }
        }



        private void LoadChecklitData(int unitId)
        {
            // Load
            UnitInformationTDS dataSet = new UnitInformationTDS();
            dataSet.ChecklistDetails.Merge(unitsChecklistRulesTemp, true);
            UnitInformationChecklistDetails model = new UnitInformationChecklistDetails(dataSet);
            
            model.Load(unitId, int.Parse(hdfCompanyId.Value));
           
            // Store tables
            unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)model.Table;
            Session["unitsChecklistRulesTemp"] = unitsChecklistRulesTemp;

            grdChecklistRulesInformation.DataBind();
        }



        private void LoadServiceData(int unitId)
        {
            UnitInformationTDS dataset = new UnitInformationTDS();
            dataset.ServiceDetails.Merge(unitsServicesTemp, true);
            UnitInformationServiceDetails model = new UnitInformationServiceDetails(dataset);

            model.Load(unitId, int.Parse(hdfCompanyId.Value));

            unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)model.Table;
            Session["unitsServicesTemp"] = unitsServicesTemp;

            grdServices.DataBind();
        }



        private void LoadInspectionData(int unitId)
        {
            UnitInformationTDS dataset = new UnitInformationTDS();
            dataset.InspectionDetails.Merge(unitsInspectionsTemp, true);
            UnitInformationInspectionDetails model = new UnitInformationInspectionDetails(dataset);

            model.LoadByUnitId(unitId, int.Parse(hdfCompanyId.Value));

            unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)model.Table;
            Session["unitsInspectionsTemp"] = unitsInspectionsTemp;

            grdInspections.DataBind();
        }



        private void LoadNotes(int unitId, int companyId)
        {
            UnitInformationUnitDetailsGateway unitInformationUnitDetailsGateway = new UnitInformationUnitDetailsGateway(unitInformationTDS);

            int? libraryCategoriesId = null; if (unitInformationUnitDetailsGateway.GetLibraryCategoriesId(unitId).HasValue) libraryCategoriesId = (int)unitInformationUnitDetailsGateway.GetLibraryCategoriesId(unitId);

            if (libraryCategoriesId.HasValue)
            {
                tbxCategoryAssocited.Text = GetFullCategoryName((int)libraryCategoriesId, companyId);
            }
            else
            {
                tbxCategoryAssocited.Text = "";
            }
        }



        private void GetNodeForCategory(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;
            UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);

            DataRow[] children = categoriesTDS.Tables["LFS_FM_CATEGORY"].Select("ParentID='" + parentId + "'");
           
            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[2]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                //step 4
                if (unitsCategoryGateway.IsUsedInUnitCategory(Int32.Parse(hdfUnitId.Value), thisId))
                {
                    newNode.Checked = true;
                }

                // step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 6
                GetNodeForCategory(newNode.ChildNodes, thisId);
            }
        }



        private void GetNodeForCompanyLevels(TreeNodeCollection nodes, int parentId, int companyLevelId)
        {
            Int32 thisId;
            string thisName;
            
            DataRow[] children = companyLevelsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[1]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                //step 4
                if (companyLevelId == thisId)
                {
                    newNode.Checked = true;
                }

                // step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 6
                GetNodeForCompanyLevels(newNode.ChildNodes, thisId, companyLevelId);
            }
        }



        private void GetCategoriesParent(TreeNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                node.ShowCheckBox = false;

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesParent(node2);
                }
            }
        }



        private void GetCompanyLevelsParent(TreeNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                node.ShowCheckBox = false;

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsParent(node2);
                }
            }
        }



        private string GetFullCategoryName(int libraryCategoryId, int companyId)
        {
            int[] libraryArray = new int[100];
            int maxDeep = 0;

            for (int index = 0; index < libraryArray.Length; index++)
            {
                libraryArray[index] = -1;
            }

            string fullCategoryName = "";
            libraryArray = GetDeepParent(libraryCategoryId, 0, maxDeep, libraryArray, companyId);            

            for (int index = 0; index < 100; index++)
            {
                if (libraryArray[index] > 0)
                {
                    if (index > 0)
                    {
                        fullCategoryName = fullCategoryName + "/";
                    }

                    LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
                    libraryCategoriesGateway.LoadAllByLibraryCategoriesId(libraryArray[index], companyId);
                    fullCategoryName = fullCategoryName + libraryCategoriesGateway.GetCategoryName(libraryArray[index]);
                }
            }

            return fullCategoryName;
        }



        private int[] GetDeepParent(int currentId, int deep, int maxDeep, int[] currentLibraryArray, int companyId)
        {
            int[] libraryArray = currentLibraryArray;
            ViewState["currentmaxDeep"] = maxDeep;

            LibraryCategoriesGateway libraryCategoriesGateway = new LibraryCategoriesGateway();
            libraryCategoriesGateway.LoadAllByLibraryCategoriesId(currentId, companyId);

            if (libraryCategoriesGateway.Table.Rows.Count > 0)
            {
                if (libraryCategoriesGateway.GetParentId(currentId) == 0)
                {
                    libraryArray[0] = currentId;
                    ViewState["currentmaxDeep"] = deep;
                    return libraryArray;
                }
                else
                {
                    libraryArray = GetDeepParent(libraryCategoriesGateway.GetParentId(currentId), deep + 1, (int)ViewState["currentmaxDeep"], libraryArray, companyId);
                    libraryArray[(int)ViewState["currentmaxDeep"] - deep] = currentId;
                    return libraryArray;
                }
            }
            else
            {
                return libraryArray;
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdChecklistRulesInformation_DataBound(object sender, EventArgs e)
        {
            ChecklistRulesInformationEmptyFix(grdChecklistRulesInformation);
        }



        protected void grdServices_DataBound(object sender, EventArgs e)
        {
            ServicesEmptyFix(grdServices);
        }



        protected void grdInspections_DataBound(object sender, EventArgs e)
        {
            InspectionsEmptyFix(grdInspections);
        }



        protected void grdCosts_DataBound(object sender, EventArgs e)
        {
            // New Empty Fix
            AddCostsNewEmptyFix(grdCosts);

            // Check last row
            int totalRows = grdCosts.Rows.Count;
            if (totalRows != 0)
            {
                foreach (GridViewRow rowTemp1 in grdCosts.Rows)
                {
                    if (rowTemp1.RowIndex == totalRows - 1)
                    {
                        // ... Mark last row as selected
                        if ((grdCosts.Rows[0].Visible) && (rowTemp1.RowType == DataControlRowType.DataRow) && ((rowTemp1.RowState == DataControlRowState.Normal) || (rowTemp1.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            // ... Mark first row as selected
                            ((CheckBox)rowTemp1.FindControl("cbxSelected")).Checked = true;

                            // ... Show exceptions for first selected row
                            CheckBox checkbox = ((CheckBox)rowTemp1.FindControl("cbxSelected"));
                            int costId = 0;
                            Session["costIdSelected"] = 0;
                            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                            Session.Remove("unitCostsExceptionsDummy");
                             
                            if (checkbox.Checked)
                            {
                                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                                foreach (GridViewRow rowTemp in grdCosts.Rows)
                                {
                                    int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                                    if (costId != costTemp)
                                    {
                                        ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                                    }
                                }

                                Session.Remove("costIdSelected");
                                Session["costIdSelected"] = costId;
                            }

                            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                            odsCostsExceptions.FilterExpression = filterOptions;
                        }
                    }
                }
            }
        }



        protected void grdCostsExceptions_DataBound(object sender, EventArgs e)
        {
            AddCostsExceptionsNewEmptyFix(grdCostsExceptions);
        }



        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdNotes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                string originalFileName = ((TextBox)e.Row.FindControl("tbxNoteAttachment")).Text;
                string fileName = ((Label)e.Row.FindControl("lblFileName")).Text;
                int libraryFileId = 0; if (((Label)e.Row.FindControl("lblLibraryFileId")).Text != "") libraryFileId = Int32.Parse(((Label)e.Row.FindControl("lblLibraryFileId")).Text);

                // Button visibility
                if (originalFileName == "")
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = false;
                }
                else
                {
                    ((Button)e.Row.FindControl("btnNoteDownload")).Visible = true;
                }
            }
        }



        protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "DownloadAttachment":
                    GridViewRow rowDonwload = (GridViewRow)(((Button)e.CommandSource).NamingContainer);
                    string originalFileName = ((TextBox)rowDonwload.FindControl("tbxNoteAttachment")).Text;
                    string fileName = ((Label)rowDonwload.FindControl("lblFileName")).Text;
                    GrdNotesOpenAttachment(originalFileName, fileName);
                    break;
            }
        }



        protected string GetNoteCreatedBy(object userId)
        {
            if (userId != DBNull.Value)
            {
                if (Convert.ToInt32(userId) != -1)
                {
                    try
                    {
                        // Created By
                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

                        return userName.ToString();
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        protected void grdChecklistRulesInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ChecklistRulesInformationProcessGrid();
        }



        protected void grdServices_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ServicesProcessGrid();
        }



        protected void grdInspections_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            InspectionsProcessGrid();
        }



        public UnitInformationTDS.ChecklistDetailsDataTable GetChecklistRulesInformation()
        {
            unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTempDummy"];

            if (unitsChecklistRulesTemp == null)
            {
                unitsChecklistRulesTemp = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTemp"];
            }

            return unitsChecklistRulesTemp;
        }



        public UnitInformationTDS.ServiceDetailsDataTable GetServicesInformation()
        {
            unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTempDummy"];

            if (unitsServicesTemp == null)
            {
                unitsServicesTemp = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTemp"];
            }

            return unitsServicesTemp;
        }



        public UnitInformationTDS.InspectionDetailsDataTable GetInspectionsInformation()
        {
            unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTempDummy"];

            if (unitsInspectionsTemp == null)
            {
                unitsInspectionsTemp = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTemp"];
            }

            return unitsInspectionsTemp;
        }



        public UnitInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            unitsNotesTemp = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTempDummy"];
            
            if (unitsNotesTemp == null)
            {
                unitsNotesTemp = ((UnitInformationTDS)Session["unitInformationTDS"]).NoteInformation;
            }

            return unitsNotesTemp;
        }



        public UnitInformationTDS.CostInformationDataTable GetCostsNew()
        {
            unitInformationCosts = (UnitInformationTDS.CostInformationDataTable)Session["unitCostsDummy"];
            if (unitInformationCosts == null)
            {
                unitInformationCosts = ((UnitInformationTDS)Session["unitInformationTDS"]).CostInformation;
            }

            return unitInformationCosts;
        }



        public UnitInformationTDS.CostExceptionsInformationDataTable GetCostsExceptionsNew()
        {
            unitInformationCostsExceptions = (UnitInformationTDS.CostExceptionsInformationDataTable)Session["unitCostsExceptionsDummy"];
            if (unitInformationCostsExceptions == null)
            {
                unitInformationCostsExceptions = ((UnitInformationTDS)Session["unitInformationTDS"]).CostExceptionsInformation;
            }

            return unitInformationCostsExceptions;
        }



        protected void ChecklistRulesInformationEmptyFix(GridView grdChecklistRulesInformation)
        {
            if (grdChecklistRulesInformation.Rows.Count == 0)
            {
                DateTime lastService = new DateTime();
                DateTime nextDue = new DateTime();
                UnitInformationTDS.ChecklistDetailsDataTable dt = new UnitInformationTDS.ChecklistDetailsDataTable();
                dt.AddChecklistDetailsRow(0, "", "", lastService, nextDue, false, "Unknown", false);
                Session["unitsChecklistRulesTempDummy"] = dt;
                btnChecklist.Visible = false;
                grdChecklistRulesInformation.DataBind();
            }

            // Normally executes at all postbacks
            if (grdChecklistRulesInformation.Rows.Count == 1)
            {
                UnitInformationTDS.ChecklistDetailsDataTable dt = (UnitInformationTDS.ChecklistDetailsDataTable)Session["unitsChecklistRulesTempDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdChecklistRulesInformation.Rows[0].Visible = false;
                    grdChecklistRulesInformation.Rows[0].Controls.Clear();
                    btnChecklist.Visible = false;
                }
            }
        }



        protected void ServicesEmptyFix(GridView grdServices)
        {
            if (grdServices.Rows.Count == 0)
            {
                DateTime date = new DateTime();
                UnitInformationTDS.ServiceDetailsDataTable dt = new UnitInformationTDS.ServiceDetailsDataTable();
                dt.AddServiceDetailsRow("", date, "", "", false);
                Session["unitsServicesTempDummy"] = dt;
                btnOpenService.Visible = false;
                grdServices.DataBind();
            }

            // normally executes at all postbacks
            if (grdServices.Rows.Count == 1)
            {
                UnitInformationTDS.ServiceDetailsDataTable dt = (UnitInformationTDS.ServiceDetailsDataTable)Session["unitsServicesTempDummy"];
                if (dt != null)
                {
                    // hide row
                    grdServices.Rows[0].Visible = false;
                    grdServices.Rows[0].Controls.Clear();
                    btnOpenService.Visible = false;
                }
            }
        }



        protected void InspectionsEmptyFix(GridView grdInspections)
        {
            if (grdInspections.Rows.Count == 0)
            {
                DateTime date = new DateTime();
                UnitInformationTDS.InspectionDetailsDataTable dt = new UnitInformationTDS.InspectionDetailsDataTable();
                dt.AddInspectionDetailsRow(0, date, 0, 0, "", "", 0, "", "", "", false, false);
                Session["unitsInspectionsTempDummy"] = dt;

                grdInspections.DataBind();
            }

            // normally executes at all postbacks
            if (grdInspections.Rows.Count == 1)
            {
                UnitInformationTDS.InspectionDetailsDataTable dt = (UnitInformationTDS.InspectionDetailsDataTable)Session["unitsInspectionsTempDummy"];
                if (dt != null)
                {
                    // hide row
                    grdInspections.Rows[0].Visible = false;
                    grdInspections.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddNotesNewEmptyFix(GridView grdView)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.NoteInformationDataTable dt = new UnitInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", false, companyId, false, 0, "", "");
                Session["unitsNotesTempDummy"] = dt;

                grdNotes.DataBind();
            }

            // normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                UnitInformationTDS.NoteInformationDataTable dt = (UnitInformationTDS.NoteInformationDataTable)Session["unitsNotesTempDummy"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsNewEmptyFix(GridView grdView)
        {
            if (grdCosts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.CostInformationDataTable dt = new UnitInformationTDS.CostInformationDataTable();
                dt.AddCostInformationRow(-1, -1, DateTime.Now, "", 0, 0, false, companyId, false);
                Session["unitCostsDummy"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                UnitInformationTDS.CostInformationDataTable dt = (UnitInformationTDS.CostInformationDataTable)Session["unitCostsDummy"];
                if (dt != null)
                {
                    grdCosts.Rows[0].Visible = false;
                    grdCosts.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCostsExceptionsNewEmptyFix(GridView grdView)
        {
            if (grdCostsExceptions.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                UnitInformationTDS.CostExceptionsInformationDataTable dt = new UnitInformationTDS.CostExceptionsInformationDataTable();
                dt.AddCostExceptionsInformationRow(Convert.ToInt32(Session["costIdSelected"]), -1, -1, "", "", 0, 0, false, companyId, false);
                Session["unitCostsExceptionsDummy"] = dt;

                grdCostsExceptions.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCostsExceptions.Rows.Count == 1)
            {
                UnitInformationTDS.CostExceptionsInformationDataTable dt = (UnitInformationTDS.CostExceptionsInformationDataTable)Session["unitCostsExceptionsDummy"];
                if (dt != null)
                {
                    grdCostsExceptions.Rows[0].Visible = false;
                    grdCostsExceptions.Rows[0].Controls.Clear();
                }
            }
        }



        private void ChecklistRulesInformationProcessGrid()
        {            
        }



        private void ServicesProcessGrid()
        {
        }



        private void InspectionsProcessGrid()
        {
        }



        private void GrdNotesOpenAttachment(string originalFileName, string fileName)
        {
            // Button download functionality
            if ((originalFileName != "") && (fileName != ""))
            {
                // Escape single quote
                originalFileName = originalFileName.Replace("'", "%27");
                fileName = fileName.Replace("'", "%27");

                string script = "<script language='javascript'>";
                string url = "./units_download_attachment.aspx?original_filename=" + Server.UrlEncode(originalFileName) + "&filename=" + Server.UrlEncode(fileName);
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=0, height=0')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "DownloadAttachment", script, false);
            }
        }


        
        private bool Delete(int unitId, int companyId)
        {
            LiquiForce.LFSLive.BL.FleetManagement.Units.Units units = new LiquiForce.LFSLive.BL.FleetManagement.Units.Units(null);

            int result = units.IsInUse(unitId, companyId);

            if (result != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        protected string GetCountry(object country)
        {
            if (country == DBNull.Value)
            {
                return "";
            }
            else
            {
                Int64 countryId = Int64.Parse(country.ToString());

                if (countryId > 0)
                {
                    CountryGateway countryGateway = new CountryGateway();
                    countryGateway.LoadByCountryId(countryId);
                    return countryGateway.GetName(countryId);
                }
                else
                {
                    return "";
                }
            }
        }



        protected string GetState(object state)
        {
            if (state == DBNull.Value)
            {
                return "";
            }
            else
            {
                Int64 stateId = Int64.Parse(state.ToString());

                if (stateId > 0)
                {
                    ProvinceGateway provinceGateway = new ProvinceGateway();
                    provinceGateway.LoadByProvinceId(stateId);
                    return provinceGateway.GetName(stateId);
                }
                else
                {
                    return "";
                }
            }
        }



        protected bool IsUnitWithServicesActives(int unitId, int companyId)
        {
            UnitsGateway unitsGateway = new UnitsGateway(null);

            if (unitsGateway.IsUnitWithServicesActives(unitId, companyId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion



    }
}