using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_summary
    /// </summary>
    public partial class materials_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialsInformationTDS materialsInformationTDS;
        protected MaterialsInformationTDS.CostHistoryInformationDataTable materialsInformationCosts;
        protected MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable materialsInformationCostsExceptions;
        protected MaterialsInformationTDS.NoteInformationDataTable materialsInformationNote;
        protected MaterialsTDS materialsTDS;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["material_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_summary.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Materials";
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfCurrentMaterialId.Value = Request.QueryString["material_id"];

                // Prepare initial data
                Session.Remove("materialsCostsDummy");
                Session.Remove("materialsCostsExceptionsDummy");
                Session.Remove("materialsNotesDummy");
                Session.Remove("costIdSelected");

                // ... for material title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

                MaterialsGateway materialsGateway = new MaterialsGateway();
                materialsGateway.LoadByMaterialId(materialId, companyId);
                lblTitleMaterial.Text = "Material: " + materialsGateway.GetDescription(materialId);

                // If coming from 
                string resourceType = hdfResourceType.Value;

                // ... materials_navigator2.aspx or materials_add.aspx
                if ((Request.QueryString["source_page"] == "materials_navigator2.aspx") || (Request.QueryString["source_page"] == "materials_add.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "yes";

                    // ... ... Set initial tab
                    if ((string)Session["dialogOpenedMaterials"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        materialsInformationTDS = new MaterialsInformationTDS();
                        materialsTDS = new MaterialsTDS();

                        MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                        materialsInformationBasicInformation.LoadByMaterialId(materialId, companyId);

                        MaterialsInformationCostHistoryInformation materialsInformationCostHistoryInformation = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
                        materialsInformationCostHistoryInformation.LoadAllByMaterialId(materialId, companyId);

                        MaterialsInformationCostHistoryExceptionsInformation materialsInformationCostHistoryExceptionsInformation = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);
                        materialsInformationCostHistoryExceptionsInformation.LoadAllByMaterialId(materialId, companyId);

                        Session["costIdSelected"] = 0;                        

                        MaterialsInformationNoteInformation materialsInformationNoteInformationForEdit = new MaterialsInformationNoteInformation(materialsInformationTDS);
                        materialsInformationNoteInformationForEdit.LoadAllByMaterialId(materialId, companyId);
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabMaterials"];

                        // Restore datasets
                        materialsTDS = (MaterialsTDS)Session["materialsTDS"];
                        materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];
                    }

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["materialsInformationTDS"] = materialsInformationTDS;
                    Session["materialsTDS"] = materialsTDS;
                }

                // ... materials_delete.aspx, materials_edit.aspx or materials_state.aspx 
                if ((Request.QueryString["source_page"] == "materials_delete.aspx") || (Request.QueryString["source_page"] == "materials_edit.aspx") || (Request.QueryString["source_page"] == "materials_state.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    materialsTDS = (MaterialsTDS)Session["materialsTDS"];
                    materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedMaterials"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabMaterials"];
                    }

                    tcDetailedInformation.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
                }

                // Prepare initial data
                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", 0, 0);
                odsCostsExceptions.FilterExpression = filterOptions;

                // ... Data for current material              
                LoadData(companyId);

                // Databind
                Page.DataBind();
            }
            else
            {
                // Restore datasets
                materialsTDS = (MaterialsTDS)Session["materialsTDS"];
                materialsInformationTDS = (MaterialsInformationTDS)Session["materialsInformationTDS"];
                materialsInformationNote = (MaterialsInformationTDS.NoteInformationDataTable)Session["materialsInformationNote"];

                // Set initial tab
                int activeTabMaterials = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTabMaterials;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Resources";

            // validate fields
            if (hdfProcess.Value == "Junction Lining")
            {
                tbxThicknessLength.Visible = false;
                lblThicknessLength.Visible = false;
            }
            else
            {
                tbxThicknessLength.Visible = true;
                lblThicknessLength.Visible = true;            
            }
        }        

        




        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        // 
        
        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            AddNotesNewEmptyFix(grdNotes);
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
                            Session.Remove("materialsCostsExceptionsDummy");

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



        protected void cbxSelectedCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("materialsCostsExceptionsDummy");

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






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabMaterials"] = "0";
            Session["dialogOpenedMaterials"] = "0";
            
            string activeTabMaterials = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./materials_edit.aspx?source_page=materials_summary.aspx&material_id=" + hdfCurrentMaterialId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mChangeState":
                    url = "./materials_state.aspx?source_page=materials_summary.aspx&material_id=" + hdfCurrentMaterialId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value + "&material_state=" + tbxState.Text;
                    break;

                case "mDelete":
                    url = "./materials_delete.aspx?source_page=materials_summary.aspx&material_id=" + hdfCurrentMaterialId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mLastSearch":
                    url = "./materials_navigator2.aspx?source_page=materials_summary.aspx&material_id=" + hdfCurrentMaterialId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = MaterialsNavigator.GetPreviousId((MaterialsNavigatorTDS)Session["materialsNavigatorTDS"], Int32.Parse(hdfCurrentMaterialId.Value));
                    if (previousId != Int32.Parse(hdfCurrentMaterialId.Value))
                    {
                        // Redirect
                        url = "./materials_summary.aspx?source_page=materials_navigator2.aspx&material_id=" + previousId.ToString() + "&active_tab=" + activeTabMaterials + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = MaterialsNavigator.GetNextId((MaterialsNavigatorTDS)Session["materialsNavigatorTDS"], Int32.Parse(hdfCurrentMaterialId.Value));
                    if (nextId != Int32.Parse(hdfCurrentMaterialId.Value))
                    {
                        // Redirect
                        url = "./materials_summary.aspx?source_page=materials_navigator2.aspx&material_id=" + nextId.ToString() + "&active_tab=" + activeTabMaterials + GetNavigatorState();
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabMaterials"] = "0";

            string url = "";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./materials_navigator.aspx?source_page=lm&resource_type=" + hdfResourceType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //     

        public MaterialsInformationTDS.NoteInformationDataTable GetNotesNew()
        {
            materialsInformationNote = (MaterialsInformationTDS.NoteInformationDataTable)Session["materialsNotesDummy"];
            if (materialsInformationNote == null)
            {
                materialsInformationNote = ((MaterialsInformationTDS)Session["materialsInformationTDS"]).NoteInformation;
            }

            return materialsInformationNote;
        }



        public MaterialsInformationTDS.CostHistoryInformationDataTable GetCostsNew()
        {
            materialsInformationCosts = (MaterialsInformationTDS.CostHistoryInformationDataTable)Session["materialsCostsDummy"];
            if (materialsInformationCosts == null)
            {
                materialsInformationCosts = ((MaterialsInformationTDS)Session["materialsInformationTDS"]).CostHistoryInformation;
            }

            return materialsInformationCosts;
        }



        public MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable GetCostsExceptionsNew()
        {
            materialsInformationCostsExceptions = (MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Session["materialsCostsExceptionsDummy"];
            if (materialsInformationCostsExceptions == null)
            {
                materialsInformationCostsExceptions = ((MaterialsInformationTDS)Session["materialsInformationTDS"]).CostHistoryExceptionsInformation;
            }

            return materialsInformationCostsExceptions;
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentMaterialIdId = '" + hdfCurrentMaterialId.ClientID + "';";
            contentVariables += "var hdfResourceTypeId = '" + hdfResourceType.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_sort_by=" + Request.QueryString["search_sort_by"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



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



        #region Load Functions

        private void LoadData(int companyId)
        {
            // Get FmId
            string resourceType = hdfResourceType.Value.Trim();
            int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

            // Load Data
            LoadBasicData(materialId);
        }



        private void LoadBasicData(int materialId)
        {
            MaterialsInformationBasicInformationGateway materialsInformationBasicInformationGateway = new MaterialsInformationBasicInformationGateway(materialsInformationTDS);
            if (materialsInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                // Load material basic data
                tbxDescription.Text = materialsInformationBasicInformationGateway.GetDescription(materialId);
                tbxProcess.Text = materialsInformationBasicInformationGateway.GetType(materialId);
                hdfProcess.Value = tbxProcess.Text;
                tbxSize.Text = materialsInformationBasicInformationGateway.GetSize(materialId);
                tbxState.Text = materialsInformationBasicInformationGateway.GetState(materialId);

                if (tbxProcess.Text == "Point Repairs")
                {
                    tbxThicknessLength.Text = materialsInformationBasicInformationGateway.GetLength(materialId);
                    lblThicknessLength.Text = "Length";
                }
                else
                {
                    if (tbxProcess.Text == "Full Length Lining")
                    {
                        tbxThicknessLength.Text = materialsInformationBasicInformationGateway.GetThickness(materialId);
                        lblThicknessLength.Text = "Thickness";
                    }
                }
            }
        }

        #endregion



        protected void AddNotesNewEmptyFix(GridView grdView)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                MaterialsInformationTDS.NoteInformationDataTable dt = new MaterialsInformationTDS.NoteInformationDataTable();
                dt.AddNoteInformationRow(-1, -1, "", -1, DateTime.Now, "", false, companyId, false);
                Session["materialsNotesDummy"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                MaterialsInformationTDS.NoteInformationDataTable dt = (MaterialsInformationTDS.NoteInformationDataTable)Session["materialsNotesDummy"];
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
                MaterialsInformationTDS.CostHistoryInformationDataTable dt = new MaterialsInformationTDS.CostHistoryInformationDataTable();
                dt.AddCostHistoryInformationRow(-1, -1, DateTime.Now, "", 0, 0, false, companyId, false);
                Session["materialsCostsDummy"] = dt;

                grdCosts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCosts.Rows.Count == 1)
            {
                MaterialsInformationTDS.CostHistoryInformationDataTable dt = (MaterialsInformationTDS.CostHistoryInformationDataTable)Session["materialsCostsDummy"];
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
                MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable dt = new MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable();
                dt.AddCostHistoryExceptionsInformationRow(Convert.ToInt32(Session["costIdSelected"]), -1, -1, "", "", "", 0, 0, false, companyId, false, "");
                Session["materialsCostsExceptionsDummy"] = dt;

                grdCostsExceptions.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCostsExceptions.Rows.Count == 1)
            {
                MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable dt = (MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable)Session["materialsCostsExceptionsDummy"];
                if (dt != null)
                {
                    grdCostsExceptions.Rows[0].Visible = false;
                    grdCostsExceptions.Rows[0].Controls.Clear();
                }
            }
        }



    }
}