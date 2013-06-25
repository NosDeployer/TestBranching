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
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.BL.CWP.PointRepairs;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;

namespace LiquiForce.LFSLive.WebUI.CWP.PointRepairs
{
    /// <summary>
    /// pr_size
    /// </summary>
    public partial class pr_size : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected PointRepairsTDS pointRepairsTDS;
        protected SizeInformationTDS sizeInformationTDS;
        protected SizeInformationTDS.SizeInformationDataTable sizeInformation;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["repair_point_id"] == null) || ((string)Request.QueryString["work_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in pr_size.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfRepairPointId.Value = Convert.ToString(Request.QueryString["repair_point_id"]);
                hdfWorkId.Value = Convert.ToString(Request.QueryString["work_id"]);
                hdfUpdate.Value = "yes";
                Session.Remove("sizeInformationNewDummy");
                Session.Remove("sizeInformation");

                // If comming from 
                // ... pr_edit.aspx
                if (Request.QueryString["source_page"] == "pr_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // ... Load size to edit
                    pointRepairsTDS = (PointRepairsTDS)Session["pointRepairsTDS"];
                    sizeInformationTDS = new SizeInformationTDS();                    

                    SizeInformationGateway sizeInformationGateway = new SizeInformationGateway(sizeInformationTDS);
                    sizeInformationGateway.Load(Int32.Parse(hdfCompanyId.Value.Trim()));

                    // ... Store datasets
                    Session["sizeInformationTDS"] = sizeInformationTDS;
                    Session["sizeInformation"] = sizeInformationTDS.SizeInformation;
                }
            }
            else
            {
                // Restore datasets
                pointRepairsTDS = (PointRepairsTDS)Session["pointRepairsTDS"];
                sizeInformationTDS = (SizeInformationTDS)Session["sizeInformationTDS"];
                sizeInformation = sizeInformationTDS.SizeInformation;
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
            dialog2.DialogTitle = "Size For Point Lining";
        }



        protected void grdSize_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Page.Validate("sizeData");
            if (Page.IsValid)
            {
                string size_ = e.Keys["Size_"].ToString();
                int companyId = (int)e.Keys["COMPANY_ID"];

                SizeInformation model = new SizeInformation(sizeInformationTDS);

                // Delete size
                model.Delete(size_, companyId);

                // Store dataset
                Session.Remove("sizeInformationNewDummy");
                Session["sizeInformationTDS"] = sizeInformationTDS;
                Session["sizeInformation"] = sizeInformationTDS.SizeInformation;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdSize_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    GrdSizeAdd();
                    break;
            }
        }



        protected void grdSize_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("sizeDataEdit");
            if (Page.IsValid)
            {
                string originalSize_ = e.Keys["Size_"].ToString();
                int companyId = (int)e.Keys["COMPANY_ID"];

                string newSize_ = ((TextBox)grdSize.Rows[e.RowIndex].Cells[2].FindControl("tbxSizeEdit")).Text.Trim();

                if (originalSize_ != newSize_)
                {
                    // Update data
                    SizeInformation model = new SizeInformation(sizeInformationTDS);
                    model.Update(originalSize_, newSize_, companyId);                    
                }

                // Store dataset
                Session.Remove("sizeInformationNewDummy");
                Session["sizeInformationTDS"] = sizeInformationTDS;
                Session["sizeInformation"] = sizeInformationTDS.SizeInformation;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void cvSizeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            string originalSize = ((HiddenField)grdSize.Rows[grdSize.EditIndex].Cells[2].FindControl("hdfSizeEdit")).Value;

            if (originalSize != args.Value.Trim())
            {
                SizeInformationGateway sizeInformationGateway = new SizeInformationGateway(sizeInformationTDS);

                if (sizeInformationGateway.Table.Rows.Count > 0)
                {
                    foreach (SizeInformationTDS.SizeInformationRow row in (SizeInformationTDS.SizeInformationDataTable)sizeInformationGateway.Table)
                    {
                        if (row.Size_ == args.Value.Trim())
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }



        protected void cvSizeNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            
            SizeInformationGateway sizeInformationGateway = new SizeInformationGateway(sizeInformationTDS);

            if (sizeInformationGateway.Table.Rows.Count > 0)
            {
                foreach (SizeInformationTDS.SizeInformationRow row in (SizeInformationTDS.SizeInformationDataTable)sizeInformationGateway.Table)
                {
                    if (row.Size_ == args.Value.Trim())
                    {
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway();
            
            if (workPointRepairsRepairPointSizeGateway.IsUsedInPointRepair(args.Value.Trim(), Int32.Parse(hdfCompanyId.Value)))
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdSize_DataBound(object sender, EventArgs e)
        {
            AddSizeNewEmptyFix(grdSize);
        }



        protected void grdSize_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public SizeInformationTDS.SizeInformationDataTable GetSize()
        {
            sizeInformation = (SizeInformationTDS.SizeInformationDataTable)Session["sizeInformationNewDummy"];

            if (sizeInformation == null)
            {
                sizeInformation = ((SizeInformationTDS.SizeInformationDataTable)Session["sizeInformation"]);
            }

            return sizeInformation;
        }



        public void DummySizeNew(string Size_, int COMPANY_ID, bool deleted)
        {
        }



        public void DummySizeNew(string Size_, int COMPANY_ID)
        {
        }



        public void DummySizeNew(string Size_)
        {
        }



        public void DummySizeNew(bool Selected, string original_Size_, int original_COMPANY_ID)
        {
        }



        public void DummySizeNew(string Size_, string original_Size_, int original_COMPANY_ID)
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./pr_size.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private string GetSize_()
        {
            string size_ = "";
            
            // Update size navigator rows
            foreach (GridViewRow row in grdSize.Rows)
            {
                if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                {
                    size_ = ((TextBox)row.FindControl("tbxSize")).Text.Trim();
                }
            }

            return size_;
        }



        private void Save()
        {
            try
            {
                // Validate page
                // Add data if exist at grid's foot
                GrdSizeAdd();

                string sizeSelected = GetSize_();

                int workId = Int32.Parse(hdfWorkId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                string repairPointId = hdfRepairPointId.Value;

                if (sizeSelected != "")
                {
                    PointRepairsRepairDetails model = new PointRepairsRepairDetails(pointRepairsTDS);
                    model.UpdateSizePointLining(workId, repairPointId, sizeSelected);
                }

                // Update data
                UpdateDatabase();

                Session["pointRepairsTDS"] = pointRepairsTDS;

                // If coming from 
                // ... pr_edit.aspx
                if (Request.QueryString["source_page"] == "pr_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
            catch
            {
                if (Request.QueryString["source_page"] == "pr_edit.aspx")
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
                SizeInformation sizeInformation = new SizeInformation(sizeInformationTDS);
                sizeInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                sizeInformationTDS.AcceptChanges();
                Session["sizeInformationTDS"] = sizeInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddSizeNewEmptyFix(GridView grdSize)
        {
            if (grdSize.Rows.Count == 0)
            {
                SizeInformationTDS.SizeInformationDataTable dt = new SizeInformationTDS.SizeInformationDataTable();
                dt.AddSizeInformationRow("", 3, false, false, "", false);
                Session["sizeInformationNewDummy"] = dt;

                grdSize.DataBind();
            }

            // normally executes at all postbacks
            if (grdSize.Rows.Count == 1)
            {
                SizeInformationTDS.SizeInformationDataTable dt = (SizeInformationTDS.SizeInformationDataTable)Session["sizeInformationNewDummy"];
                if (dt != null)
                {
                    grdSize.Rows[0].Visible = false;
                    grdSize.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdSizeAdd()
        {
            if (ValidateSizeFooter())
            {
                Page.Validate("sizeDataNew");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string size_ = ((TextBox)grdSize.FooterRow.FindControl("tbxSizeNew")).Text.Trim();
                    bool newInDatabase = false;

                    SizeInformation model = new SizeInformation(sizeInformationTDS);
                    model.Insert(size_, companyId, false, newInDatabase);

                    Session.Remove("sizeInformationNewDummy");
                    Session["sizeInformationTDS"] = sizeInformationTDS;
                    Session["sizeInformation"] = sizeInformationTDS.SizeInformation;

                    grdSize.DataBind();
                    grdSize.PageIndex = grdSize.PageCount - 1;
                }
            }
        }



        private bool ValidateSizeFooter()
        {
            string size_ = ((TextBox)grdSize.FooterRow.FindControl("tbxSizeNew")).Text.Trim();

            if (size_ != "")
            {
                return true;
            }

            return false;
        }



    }
}