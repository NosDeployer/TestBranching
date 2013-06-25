using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;
using LiquiForce.LFSLive.DA.Resources.Common;
using LiquiForce.LFSLive.BL.Resources.Common;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_navigator
    /// </summary>
    public partial class materials_navigator : System.Web.UI.Page
    {
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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_navigator.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Materials";

                // Prepare initial data
                // ... For 
                odsViewForDisplayList.DataBind();
                ddlCondition1.DataSourceID = "odsViewForDisplayList";
                ddlCondition1.DataValueField = "ConditionID";
                ddlCondition1.DataTextField = "Name";
                ddlCondition1.DataBind();

                // If comming from 

                // ... Left Menu or jliner_main
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... materials_navigator2.aspx
                if (Request.QueryString["source_page"] == "materials_navigator2.aspx")
                {
                    RestoreNavigatorState();
                    if ((string)Request.QueryString["no_results"] == "yes")
                    {
                        tdNoResults.Visible = true;
                    }
                    else
                    {
                        tdNoResults.Visible = false;
                    }
                }
            }
        }
        


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Page.Validate();
            // Get data from DA gateway
            if (Page.IsValid)
            {
                MaterialsNavigatorTDS materialsNavigatorTDS = SubmitSearch();

                // Show results
                if (materialsNavigatorTDS.MaterialNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["materialsNavigatorTDS"] = materialsNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./materials_navigator2.aspx?source_page=materials_navigator.aspx&" + GetNavigatorState());
                }
                else
                {
                    tdNoResults.Visible = true;
                }
            }
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "Resources";
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// AUXILIAR EVENTS
        ///    

        protected void cvForDecimalNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Decimal number fields validate
            if ((ddlCondition1.SelectedItem.Text == "Cost (CAD)") || (ddlCondition1.SelectedItem.Text == "Cost (USD)") )
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
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition 1
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
            string conditionValue = "";
            
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

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

              
        
        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();
            string columnsToDisplay = "&columns_to_display=";

            ResourceTypeViewDisplay resourceTypeViewDisplay = new ResourceTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + resourceTypeViewDisplay.GetColumnsByDefault(resourceType, companyId, true);

            return columnsToDisplay;
        }


    }
}