using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.Assets
{
    /// <summary>
    /// asset_sewer_material
    /// </summar
    public partial class asset_sewer_material : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialInformationTDS materialInformationTDS;
        protected MaterialInformationTDS.MaterialInformationDataTable materialInformation;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_EDIT"])) || !(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["work_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in asset_sewer_material.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfAssetId.Value = Convert.ToString(Request.QueryString["asset_id"]);
                hdfWorkId.Value = Convert.ToString(Request.QueryString["work_id"]);
                hdfUpdate.Value = "yes";

                Session.Remove("materialInformationNewDummy");
                Session.Remove("materialInformation");

                // If coming from 
                // ... fl_edit.aspx or ra_edit.aspx
                if ((Request.QueryString["source_page"] == "fl_edit.aspx") || (Request.QueryString["source_page"] == "ra_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // ... Load materials to edit
                    materialInformationTDS = new MaterialInformationTDS();

                    // Get workId
                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

                    MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway(materialInformationTDS);
                    materialInformationGateway.LoadAllByAssetId(assetId, companyId);

                    // ... Store datasets
                    Session["materialInformationTDS"] = materialInformationTDS;
                    Session["materialInformation"] = materialInformationTDS.MaterialInformation;
                }
            }
            else
            {
                // Restore datasets
                materialInformationTDS = (MaterialInformationTDS)Session["materialInformationTDS"];
                materialInformation = materialInformationTDS.MaterialInformation;
            }
        }



        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }        



        protected void grdMaterials_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int assetId = (int)e.Keys["AssetID"];
            int refId = (int)e.Keys["RefID"];

            MaterialInformation model = new MaterialInformation(materialInformationTDS);

            // Delete lateral
            model.Delete(assetId, refId);

            // Store dataset
            Session.Remove("materialInformationNewDummy");
            Session["materialInformationTDS"] = materialInformationTDS;
            Session["materialInformation"] = materialInformationTDS.MaterialInformation;
        }



        protected void grdMaterials_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    GrdMaterialsAdd();
                    break;
            }
        }



        protected void grdMaterials_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("materialDataEdit");
            if (Page.IsValid)
            {
                int assetId = (int)e.Keys["AssetID"];
                int refId = (int)e.Keys["RefID"];

                string materialType = ((DropDownList)grdMaterials.Rows[e.RowIndex].Cells[2].FindControl("ddlMaterialTypeEdit")).Text.Trim();

                // Update data
                MaterialInformation model = new MaterialInformation(materialInformationTDS);
                model.Update(assetId, refId, materialType);

                // Store dataset
                Session.Remove("materialInformationNewDummy");
                Session["materialInformationTDS"] = materialInformationTDS;
                Session["materialInformation"] = materialInformationTDS.MaterialInformation;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Materials For Section";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdMaterials_DataBound(object sender, EventArgs e)
        {
            AddMaterialsNewEmptyFix(grdMaterials);
        }



        protected void grdMaterials_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int assetId = Int32.Parse(hdfAssetId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());

                MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway(materialInformationTDS);
                string materialType = materialInformationGateway.GetMaterialType(assetId, refId);

                ((DropDownList)e.Row.FindControl("ddlMaterialTypeEdit")).SelectedValue = materialType;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public MaterialInformationTDS.MaterialInformationDataTable GetMaterials()
        {
            materialInformation = (MaterialInformationTDS.MaterialInformationDataTable)Session["materialInformationNewDummy"];
            if (materialInformation == null)
            {
                materialInformation = ((MaterialInformationTDS.MaterialInformationDataTable)Session["materialInformation"]);
            }

            return materialInformation;
        }



        public void DummyMaterialsNew(int Lateral, int original_AssetID, int original_RefID)
        {
        }



        public void DummyMaterialsNew(int Lateral, DateTime Date_, int original_AssetID, int original_RefID)
        {
        }



        public void DummyMaterialsNew(int original_Lateral)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";

            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./asset_sewer_material.js");
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
            Page.Validate("materialDataEdit");

            if (Page.IsValid)
            {
                // Material Gridview
                // ... If the gridview is edition mode
                if (grdMaterials.EditIndex >= 0)
                {
                    grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
                }

                // ... Add data if exist at grid's foot
                GrdMaterialsAdd();

                // Update data
                UpdateDatabase();

                // If coming from 
                // ... fl_edit.aspx or ra_edit.aspx
                if ((Request.QueryString["source_page"] == "fl_edit.aspx") || (Request.QueryString["source_page"] == "ra_edit.aspx"))
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                MaterialInformation materialInformation = new MaterialInformation(materialInformationTDS);
                materialInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                materialInformationTDS.AcceptChanges();
                Session["materialInformationTDS"] = materialInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddMaterialsNewEmptyFix(GridView grdMaterials)
        {
            if (grdMaterials.Rows.Count == 0)
            {
                MaterialInformationTDS.MaterialInformationDataTable dt = new MaterialInformationTDS.MaterialInformationDataTable();
                dt.AddMaterialInformationRow(-1, -1, "", new DateTime(), -1, false, false);
                Session["materialInformationNewDummy"] = dt;

                grdMaterials.DataBind();
            }

            // normally executes at all postbacks
            if (grdMaterials.Rows.Count == 1)
            {
                MaterialInformationTDS.MaterialInformationDataTable dt = (MaterialInformationTDS.MaterialInformationDataTable)Session["materialInformationNewDummy"];
                if (dt != null)
                {
                    grdMaterials.Rows[0].Visible = false;
                    grdMaterials.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdMaterialsAdd()
        {
            if (ValidateMaterialsFooter())
            {
                Page.Validate("materialDataFooter");
                if (Page.IsValid)
                {
                    int assetId = Int32.Parse(hdfAssetId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newMaterialType = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlMaterialTypeFooter")).Text.Trim();
                    DateTime newDateTime = DateTime.Now;
                    bool newInDatabase = false;

                    MaterialInformation model = new MaterialInformation(materialInformationTDS);
                    model.Insert(assetId, newMaterialType, newDateTime, false, companyId, newInDatabase);

                    Session.Remove("materialInformationNewDummy");
                    Session["materialInformationTDS"] = materialInformationTDS;
                    Session["materialInformation"] = materialInformationTDS.MaterialInformation;

                    grdMaterials.DataBind();
                    grdMaterials.PageIndex = grdMaterials.PageCount - 1;
                }
            }
        }



        private bool ValidateMaterialsFooter()
        {
            string materialTypeFooter = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlMaterialTypeFooter")).SelectedValue.Trim();

            if (materialTypeFooter != "(Select a material type)")
            {
                return true;
            }

            return false;
        }





    }
}