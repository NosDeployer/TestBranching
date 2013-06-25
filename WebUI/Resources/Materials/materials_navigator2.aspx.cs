using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.BL.Resources.Materials;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.DA.Resources.Common;
using LiquiForce.LFSLive.BL.Resources.Common;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_navigator2
    /// </summary>
    public partial class materials_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialsNavigatorTDS materialsNavigatorTDS;
        protected MaterialsNavigatorTDS.MaterialNavigatorDataTable materialsNavigator;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_navigator2.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Materials";
                Session.Remove("materialsNavigatorNewDummy");

                // Prepare initial data
                 // ... For 
                odsViewForDisplayList.DataBind();
                ddlCondition1.DataSourceID = "odsViewForDisplayList";
                ddlCondition1.DataValueField = "ConditionID";
                ddlCondition1.DataTextField = "Name";
                ddlCondition1.DataBind();

                // If coming from 
                // ... materials_navigator.aspx or materials_navigator2.aspx
                if ((Request.QueryString["source_page"] == "materials_navigator.aspx") || (Request.QueryString["source_page"] == "materials_navigator2.aspx"))
                {
                    RestoreNavigatorState();
                    materialsNavigatorTDS = (MaterialsNavigatorTDS)Session["materialsNavigatorTDS"];
                }

                // ... materials_edit.aspx, materials_summary.aspx or materials_delete.aspx
                if ((Request.QueryString["source_page"] == "materials_edit.aspx") || (Request.QueryString["source_page"] == "materials_summary.aspx") || (Request.QueryString["source_page"] == "materials_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        materialsNavigatorTDS = (MaterialsNavigatorTDS)Session["materialsNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("materialsNavigatorTDS");

                        // ... Search data with updates                        
                        materialsNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["materialsNavigatorTDS"] = materialsNavigatorTDS;
                    }
                }

                // ... materials_delete.aspx, materials_summary.aspx or materials_edit.aspx
                if ((Request.QueryString["source_page"] == "materials_delete.aspx") || (Request.QueryString["source_page"] == "materials_summary.aspx") || (Request.QueryString["source_page"] == "materials_edit.aspx"))
                {
                    if (materialsNavigatorTDS.MaterialNavigator.Rows.Count == 0)
                    {
                        string url = "./materials_navigator.aspx?source_page=materials_navigator2.aspx&re_type=" + hdfResourceType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                Session["materialsNavigatorTDS"] = materialsNavigatorTDS;
                Session["materialsNavigator"] = materialsNavigatorTDS.MaterialNavigator;

                // ... for the total rows
                if (materialsNavigatorTDS.MaterialNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + materialsNavigatorTDS.MaterialNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
            else
            {
                // Restore searched data (if any)
                materialsNavigatorTDS = (MaterialsNavigatorTDS)Session["materialsNavigatorTDS"];
                materialsNavigator = materialsNavigatorTDS.MaterialNavigator;

                // ... for the total rows
                if (materialsNavigatorTDS.MaterialNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + materialsNavigatorTDS.MaterialNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Tag Page
                string url = "";

                // Delete store data
                Session.Contents.Remove("materialsNavigatorTDS");

                // Get data from DA gateway
                materialsNavigatorTDS = SubmitSearch();

                // Show results
                if (materialsNavigatorTDS.MaterialNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["materialsNavigatorTDS"] = materialsNavigatorTDS;

                    // ... Go to the results page
                    url = "./materials_navigator2.aspx?source_page=materials_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./materials_navigator.aspx?source_page=materials_navigator2.aspx&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }        
               


        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "Resources";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //    

        protected void grdNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewEmptyFix(grdNavigator);
        }



        protected void grdNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = materialsNavigatorTDS.MaterialNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                materialsNavigatorTDS.MaterialNavigator.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    materialsNavigatorTDS.MaterialNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    materialsNavigatorTDS.MaterialNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["materialsNavigatorTDS"] = materialsNavigatorTDS;
            Session["materialsNavigator"] = materialsNavigatorTDS.MaterialNavigator;
        }



        protected void cvForDecimalNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Decimal number fields validate
            if ((ddlCondition1.SelectedItem.Text == "Cost (CAD)") || (ddlCondition1.SelectedItem.Text == "Cost (USD)"))
            {
                if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                {
                    if (Validator.IsValidDecimal(args.Value.Trim()))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            PostPageChanges();

            int materialId = GetMaterialId();
            hdfCurrentMaterialId.Value = materialId.ToString();

            if (materialId > 0)
            {
                // Store active tab for postback
                Session["activeTabMaterials"] = "0";
                Session["dialogOpenedMaterials"] = "0";

                // Redirect
                string url = "./materials_summary.aspx?source_page=materials_navigator2.aspx&material_id=" + hdfCurrentMaterialId.Value + "&active_tab=0" + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            PostPageChanges();

            int materialId = GetMaterialId();
            hdfCurrentMaterialId.Value = materialId.ToString();

            if (materialId > 0)
            {
                // Store active tab for postback
                Session["activeTabMaterials"] = "0";
                Session["dialogOpenedMaterials"] = "0";

                // Redirect
                string url = "./materials_edit.aspx?source_page=materials_navigator2.aspx&material_id=" + materialId + "&active_tab=0" + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnPreviewList_Click(object sender, EventArgs e)
        {
            string url = "";

            string headerValues = "";
            int totalColumnsExport = 6;
            int totalColumnsPreview = 6;
            string name = "";
            string title = "Material Search Results";

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdNavigator.Columns[2].Visible) headerValues += "Process";
            if (grdNavigator.Columns[3].Visible) headerValues += " * Description";
            if (grdNavigator.Columns[4].Visible) headerValues += " * Size";
            if (grdNavigator.Columns[5].Visible) headerValues += " * Length";
            if (grdNavigator.Columns[6].Visible) headerValues += " * Tickness";
            if (grdNavigator.Columns[7].Visible) headerValues += " * State";

            // Establishing columns to display
            string[] columns = headerValues.Split('*');
            string columnsForReport = "";
            int j;

            // ... for visible columns
            for (int i = 0; i < columns.Length; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=" + columns[i].Trim();
            }

            // ... For not visible columns
            for (int i = columns.Length; i < totalColumnsPreview; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=None";
            }

            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./materials_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&name=" + name + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                   

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";

            string headerValues = "";
            int totalColumnsExport = 6;
            int totalColumnsPreview = 6;
            string name = "";
            string title = "Material Search Results";
            string columnsForReport = "";
            int j;

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdNavigator.Columns[2].Visible) headerValues += "Process";
            if (grdNavigator.Columns[3].Visible) headerValues += " * Description";
            if (grdNavigator.Columns[4].Visible) headerValues += " * Size";
            if (grdNavigator.Columns[5].Visible) headerValues += " * Length";
            if (grdNavigator.Columns[6].Visible) headerValues += " * Tickness";
            if (grdNavigator.Columns[7].Visible) headerValues += " * State";

            // Establishing columns to display
            string[] columnsExcel = headerValues.Split('*');

            // ... for visible columns
            for (int i = 0; i < columnsExcel.Length; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=" + columnsExcel[i].Trim();
            }

            // ... For not visible columns
            for (int i = columnsExcel.Length; i < totalColumnsExport; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=None";
            }

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./materials_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + name + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }               
            
            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            PostPageChanges();

            int materialId = GetMaterialId();
            if (materialId > 0)
            {
                hdfCurrentMaterialId.Value = materialId.ToString();

                // Store active tab for postback
                Session["activeTabMaterials"] = "0";
                Session["dialogOpenedMaterials"] = "0";

                // Redirect
                string url = "./materials_delete.aspx?source_page=materials_navigator2.aspx&material_id=" + materialId + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./materials_navigator.aspx?source_page=lm&resource_type=" + hdfResourceType.Value;

            if (url != "") Response.Redirect(url);
        }  






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        public MaterialsNavigatorTDS.MaterialNavigatorDataTable GetNavigator()
        {
            materialsNavigator = (MaterialsNavigatorTDS.MaterialNavigatorDataTable)Session["materialsNavigatorNewDummy"];
            if (materialsNavigator == null)
            {
                materialsNavigator = ((MaterialsNavigatorTDS.MaterialNavigatorDataTable)Session["materialsNavigator"]);
            }

            return materialsNavigator;
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfResourceTypeId = '" + hdfResourceType.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            // Columns To Display
            string columnsToDisplay = Request.QueryString["columns_to_display"];

            // Search condition 1
            // ... For Condition 
            odsViewForDisplayList.DataBind();
            ddlCondition1.DataSourceID = "odsViewForDisplayList";
            ddlCondition1.DataValueField = "ConditionID";
            ddlCondition1.DataTextField = "Name";
            ddlCondition1.DataBind();
            ddlCondition1.SelectedValue = Request.QueryString["search_ddlCondition1"];

            // ... For text for search
            tbxCondition1.Text = Request.QueryString["search_tbxCondition1"];

            // ... For View 
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);

            //Other values
            // Grid's columns
            grdNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("Type") >= 0 ? true : false);
            grdNavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("Description") >= 0 ? true : false);
            grdNavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("Size") >= 0 ? true : false);
            grdNavigator.Columns[5].Visible = (columnsToDisplay.Contains("Length") ? true : false);
            grdNavigator.Columns[6].Visible = (columnsToDisplay.Contains("Thickness") ? true : false);
            grdNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf("State") >= 0 ? true : false);            
        }



        private string GetNavigatorState()
        {
            // Columns to display
            string columnsToDisplay = "";
            columnsToDisplay = columnsToDisplay + GetColumnsToDisplay();

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=" + ddlCondition1.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition1=" + tbxCondition1.Text.Trim();

            // Return
            return columnsToDisplay + searchOptions;
        }



        private MaterialsNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = "";
            string resourceType = hdfResourceType.Value.Trim();
            string conditionValue = "";
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());            

            // ... Load data
            ResourceTypeViewConditionGateway resourceTypeViewConditionGateway = new ResourceTypeViewConditionGateway();
            resourceTypeViewConditionGateway.LoadByResourceTypeConditionId(resourceType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = resourceTypeViewConditionGateway.GetColumn_(resourceType, companyId, int.Parse(ddlCondition1.SelectedValue));

            MaterialsNavigator materialsNavigator = new MaterialsNavigator();
            materialsNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId, resourceType);

            return (MaterialsNavigatorTDS)materialsNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            string whereClause = "(LRM.Deleted = 0) ";

            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim());
            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value;

            ResourceTypeViewConditionGateway resourceTypeViewConditionGateway = new ResourceTypeViewConditionGateway();
            resourceTypeViewConditionGateway.LoadByResourceTypeConditionId(resourceType, companyId, conditionId);

            string conditionValue = resourceTypeViewConditionGateway.GetColumn_(resourceType, companyId, conditionId);
            string tableName = resourceTypeViewConditionGateway.GetTable_(resourceType, companyId, conditionId);

            if (tableName == "LFS_RESOURCES_MATERIAL") tableName = "LRM";
            if (tableName == "LFS_RESOURCES_MATERIAL_COST_HISTORY") tableName = "LRMCH";

            // FOR TEXT FIELDS. (Type, Description, Size, Length, Thickness, State)
            if ((conditionValue == "Type") || (conditionValue == "Description") || (conditionValue == "Size") || (conditionValue == "Length") || (conditionValue == "Thickness") || (conditionValue == "State"))
            {
                // ... Search
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                    whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                    }
                    else
                    {
                        if (textForSearch.Contains("\""))
                        {
                            if (conditionValue == "Comments")
                            {
                                textForSearch = textForSearch.Replace("'", "''");
                                whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                            }
                            else
                            {
                                textForSearch = textForSearch.Replace("\"", "");
                                whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " = '" + textForSearch + "')";
                            }
                        }
                        else
                        {
                            textForSearch = textForSearch.Replace("'", "''");
                            whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                        }
                    }
                }
            }

            return whereClause;
        }        



        private void PostPageChanges()
        {
            MaterialsNavigator materialsNavigator = new MaterialsNavigator(materialsNavigatorTDS);

            // Update 
            foreach (GridViewRow row in grdNavigator.Rows)
            {
                int materialId = Int32.Parse(((Label)row.FindControl("lblMaterialId")).Text.Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                materialsNavigator.Update(materialId, selected);
            }

            materialsNavigator.Data.AcceptChanges();

            // Store datasets
            Session["materialsNavigatorTDS"] = materialsNavigatorTDS;
        }



        private int GetMaterialId()
        {
            int materialId = 0;

            foreach (MaterialsNavigatorTDS.MaterialNavigatorRow materialsNavigatorRow in materialsNavigatorTDS.MaterialNavigator)
            {
                if (materialsNavigatorRow.Selected)
                {
                    materialId = materialsNavigatorRow.MaterialID;
                }
            }

            return materialId;
        }



        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();
            string columnsToDisplay = "&columns_to_display=";

            ResourceTypeViewDisplay resourceTypeViewDisplay = new ResourceTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + resourceTypeViewDisplay.GetColumnsByDefault(resourceType, companyId, true);

            return columnsToDisplay;
        }



        protected void AddNewEmptyFix(GridView grdNavigator)
        {
            if (grdNavigator.Rows.Count == 0)
            {
                MaterialsNavigatorTDS.MaterialNavigatorDataTable dt = new MaterialsNavigatorTDS.MaterialNavigatorDataTable();
                dt.AddMaterialNavigatorRow(-1,"", "", "", "", "", "",  false, -1, false, 0,0);
                Session["materialsNavigatorNewDummy"] = dt;

                grdNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdNavigator.Rows.Count == 1)
            {
                MaterialsNavigatorTDS.MaterialNavigatorDataTable dt = (MaterialsNavigatorTDS.MaterialNavigatorDataTable)Session["materialsNavigatorNewDummy"];
                if (dt != null)
                {
                    grdNavigator.Rows[0].Visible = false;
                    grdNavigator.Rows[0].Controls.Clear();
                }
            }
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

                

    }
}