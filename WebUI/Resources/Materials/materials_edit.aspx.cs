using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_edit
    /// </summary>
    public partial class materials_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialsTDS materialsTDS;
        protected MaterialsInformationTDS materialsInformationTDS;
        protected MaterialsInformationTDS.NoteInformationDataTable materialsInformationNote;
        protected MaterialsInformationTDS.CostHistoryInformationDataTable materialsInformationCosts;
        protected MaterialsInformationTDS.CostHistoryExceptionsInformationDataTable materialsInformationCostsExceptions;        






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_edit.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Materials";
                hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfCurrentMaterialId.Value = Request.QueryString["material_id"];

                // Prepare initial data                
                Session.Remove("materialsNotesDummy");
                Session.Remove("materialsCostsDummy");
                Session.Remove("materialsCostsExceptionsDummy");
                Session.Remove("costIdSelected");
               
                // ... for team member title
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

                MaterialsGateway materialsGateway = new MaterialsGateway();
                materialsGateway.LoadByMaterialId(materialId, companyId);
                lblTitleMaterials.Text = "Material: " + materialsGateway.GetDescription(materialId);

                // If coming from 
                string resourceType = hdfResourceType.Value;

                // ... materials_navigator2.aspx or materials_add.aspx
                if ((Request.QueryString["source_page"] == "materials_navigator2.aspx")|| (Request.QueryString["source_page"] == "materials_add.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // ... Set initial tab
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

                    // ... Store dataset
                    Session["materialsInformationTDS"] = materialsInformationTDS;
                    Session["materialsTDS"] = materialsTDS;
                }

                // ... materials_summary.aspx or materials_edit
                if ((Request.QueryString["source_page"] == "materials_summary.aspx") || (Request.QueryString["source_page"] == "materials_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // ... Restore dataset
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

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                        materialsInformationBasicInformation.LoadByMaterialId(materialId, companyId);

                        MaterialsInformationCostHistoryInformation materialsInformationCostHistoryInformation = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
                        materialsInformationCostHistoryInformation.LoadAllByMaterialId(materialId, companyId);

                        MaterialsInformationCostHistoryExceptionsInformation materialsInformationCostHistoryExceptionsInformation = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);
                        materialsInformationCostHistoryExceptionsInformation.LoadAllByMaterialId(materialId, companyId);

                        MaterialsInformationNoteInformation materialsInformationNoteInformationForEdit = new MaterialsInformationNoteInformation(materialsInformationTDS);
                        materialsInformationNoteInformationForEdit.LoadAllByMaterialId(materialId, companyId);

                        // ... Store dataset
                        Session["materialsInformationTDS"] = materialsInformationTDS;
                        Session["materialsTDS"] = materialsTDS;
                    }
                }

                Session["costIdSelected"] = 0;
                grdCostsExceptions.ShowFooter = false;
                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", 0, 0);
                odsCostsExceptions.FilterExpression = filterOptions;

                // Prepare initial data
                // ... Set initial tab
                int activeTabMaterials = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTabMaterials;

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

                // Set initial tab
                int activeTabMaterials = Int32.Parse(hdfActiveTab.Value);
                tcDetailedInformation.ActiveTabIndex = activeTabMaterials;
            }
        }



        protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Notes Gridview, if the gridview is edition mode
                    if (grdNotes.EditIndex >= 0)
                    {
                        grdNotes.UpdateRow(grdNotes.EditIndex, true);
                    }

                    // Add New Note
                    GrdNotesAdd();
                    break;
            }
        }



        protected void grdCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Costs Gridview, if the gridview is edition mode
                    if (grdCosts.EditIndex >= 0)
                    {
                        grdCosts.UpdateRow(grdCosts.EditIndex, true);
                    }

                    // Add New Cost
                    Page.Validate("AddCost");
                    if (Page.IsValid)
                    {
                        GrdCostsAdd();
                    }
                    break;
            }
        }



        protected void grdCostsExceptions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Costs Exceptions Gridview, if the gridview is edition mode
                    if (grdCostsExceptions.EditIndex >= 0)
                    {
                        grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                    }

                    // Add New Cost Exceptions
                    Page.Validate("AddCostException");
                    if (Page.IsValid)
                    {
                        GrdCostsExceptionsAdd();
                    }
                    break;

                case "Edit":
                    string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", Convert.ToInt32(Session["costIdSelected"]), 0);
                    odsCostsExceptions.FilterExpression = filterOptions;
                    break;
            }
        }



        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }

            // Delete note
            int materialId = (int)e.Keys["MaterialID"];
            int refId = (int)e.Keys["RefID"];

            MaterialsInformationNoteInformation model = new MaterialsInformationNoteInformation(materialsInformationTDS);

            // Delete note
            model.Delete(materialId, refId);

            // Store dataset
            Session["materialsInformationTDS"] = materialsInformationTDS;
        }



        protected void grdCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }

            // Delete costs
            int costId = (int)e.Keys["CostID"];
            int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

            MaterialsInformationCostHistoryInformation model = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);

            // Delete cost
            model.Delete(costId, materialId);

            // Store dataset
            Session["materialsInformationTDS"] = materialsInformationTDS;
        }



        protected void grdCostsExceptions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Costs Exceptions Gridview, if the gridview is edition mode
            if (grdCostsExceptions.EditIndex >= 0)
            {
                grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
            }

            // Delete Cost Exceptions
            int costId = (int)e.Keys["CostID"];
            int refId = (int)e.Keys["RefID"];
            MaterialsInformationCostHistoryExceptionsInformation model = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);

            // Delete cost exception
            model.Delete(costId, refId);

            grdCostsExceptions.DataBind();
            grdCosts.DataBind();

            // Store dataset
            Session["materialsInformationTDS"] = materialsInformationTDS;
        }



        protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("notesDataEdit");
            if (Page.IsValid)
            {
                int materialId = (int)e.Keys["MaterialID"];
                int refId = (int)e.Keys["RefID"];

                string subject = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[2].FindControl("tbxNoteSubjectEdit")).Text.Trim();
                string Note = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[3].FindControl("tbxNoteNoteEdit")).Text.Trim();

                // Update data
                MaterialsInformationNoteInformation model = new MaterialsInformationNoteInformation(materialsInformationTDS);
                model.Update(materialId, refId, subject, Note);

                // Store dataset
                Session["materialsInformationTDS"] = materialsInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("EditCost");
            if (Page.IsValid)
            {
                int costId = (int)e.Keys["CostID"];
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

                string unitOfMeasurement = ((DropDownList)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue;
                decimal costCad = Decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCadEdit")).Text.Trim());
                decimal costUsd = Decimal.Parse(((TextBox)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUsdEdit")).Text.Trim());
                DateTime date = ((RadDatePicker)grdCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpDateEdit")).SelectedDate.Value;

                // Update data
                MaterialsInformationCostHistoryInformation model = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
                model.Update(costId, materialId, unitOfMeasurement, costCad, costUsd, date);

                // Store dataset
                Session["materialsInformationTDS"] = materialsInformationTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdCostsExceptions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("EditCostException");
            if (Page.IsValid)
            {
                int costId = Int32.Parse(((Label)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("lblExceptionCostIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("lblExceptionRefIDEdit")).Text.Trim());
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

                string unitOfMeasurement = ((DropDownList)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("ddlExceptionUnitOfMeasurementMaterialsEdit")).SelectedValue;
                decimal costCad = Decimal.Parse(((TextBox)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("tbxExceptionCostCadEdit")).Text.Trim());
                decimal costUsd = Decimal.Parse(((TextBox)grdCostsExceptions.Rows[e.RowIndex].Cells[3].FindControl("tbxExceptionCostUsdEdit")).Text.Trim());
                string workFunctionConcat = ((DropDownList)grdCostsExceptions.Rows[e.RowIndex].Cells[0].FindControl("ddlExceptionWorkFunctionEdit")).SelectedValue;

                string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                string work_ = workFunction[0].Trim();
                string function_ = workFunction[1].Trim();

                // Update data
                MaterialsInformationCostHistoryExceptionsInformation model = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);
                model.Update(costId, refId, work_, function_, unitOfMeasurement, costCad, costUsd, workFunctionConcat);

                // Store dataset
                Session["materialsInformationTDS"] = materialsInformationTDS;

                string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                odsCostsExceptions.FilterExpression = filterOptions;
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
            
            // Format Description
            if (hdfProcess.Value == "Full Length Lining")
            {
                pnlJunctionLiner.Visible = false;
                pnlPointRepairs.Visible = false;
                pnlFullLengthLining.Visible = true;

                // make extra rows not visible
                extraRow1.Visible = false;
                extraRow2.Visible = false;
                extraRow3.Visible = false;
                extraRow4.Visible = false;
                extraRow5.Visible = false;
                extraRow6.Visible = false;
                extraRow7.Visible = false;
                extraRow8.Visible = false;
                extraRow9.Visible = false;
                extraRow10.Visible = false;
                extraRow11.Visible = false;
                extraRow12.Visible = false;
            }

            if (hdfProcess.Value == "Point Repairs")
            {
                pnlJunctionLiner.Visible = false;
                pnlPointRepairs.Visible = true;
                pnlFullLengthLining.Visible = false;
                
                // make extra rows not visible
                extraRow1.Visible = false;
                extraRow2.Visible = false;
                extraRow3.Visible = false;
                extraRow4.Visible = false;
                extraRow5.Visible = false;
                extraRow6.Visible = false;
                extraRow7.Visible = false;
                extraRow8.Visible = false;
                extraRow9.Visible = false;
                extraRow10.Visible = false;
                extraRow11.Visible = false;
                extraRow12.Visible = false;
            }

            if (hdfProcess.Value == "Junction Lining")
            {
                pnlJunctionLiner.Visible = true;
                pnlPointRepairs.Visible = false;
                pnlFullLengthLining.Visible = false;

                // make extra rows not visible
                extraRow1.Visible = true;
                extraRow2.Visible = true;
                extraRow3.Visible = true;
                extraRow4.Visible = true;
                extraRow5.Visible = true;
                extraRow6.Visible = true;
                extraRow7.Visible = true;
                extraRow8.Visible = true;
                extraRow9.Visible = true;
                extraRow10.Visible = true;
                extraRow11.Visible = true;
                extraRow12.Visible = true;
                
                // Load correct radiobutton for new options
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                MaterialsInformationBasicInformationGateway materialsInformationBasicInformationGatewayForLoad = new MaterialsInformationBasicInformationGateway(materialsInformationTDS);
                materialsInformationBasicInformationGatewayForLoad.LoadByMaterialId(materialId, companyId);
                string jlDescription = materialsInformationBasicInformationGatewayForLoad.GetDescription(materialId);
                if (jlDescription == "Lateral / Misc Supplies")
                {
                    rbtnMiscSupplies.Checked = true;
                    rbtnCleanoutMaterial.Checked = false;
                    rbtnBackfillCleanout.Checked = false;
                    rbtnRestorationCrowleCap.Checked = false;
                    rbtnOther.Checked = false;
                    tbxJLSize.Text = "";
                }
                else
                {
                    if (jlDescription == "Lateral / Cleanout Material")
                    {
                        rbtnMiscSupplies.Checked = false;
                        rbtnCleanoutMaterial.Checked = true;
                        rbtnBackfillCleanout.Checked = false;
                        rbtnRestorationCrowleCap.Checked = false;
                        rbtnOther.Checked = false;
                        tbxJLSize.Text = "";
                    }
                    else
                    {
                        if (jlDescription == "Lateral / Backfill - Cleanout")
                        {
                            rbtnMiscSupplies.Checked = false;
                            rbtnCleanoutMaterial.Checked = false;
                            rbtnBackfillCleanout.Checked = true;
                            rbtnRestorationCrowleCap.Checked = false;
                            rbtnOther.Checked = false;
                            tbxJLSize.Text = "";
                        }
                        else
                        {
                            if (jlDescription == "Lateral / Restoration & Crowle Cap")
                            {
                                rbtnMiscSupplies.Checked = false;
                                rbtnCleanoutMaterial.Checked = false;
                                rbtnBackfillCleanout.Checked = false;
                                rbtnRestorationCrowleCap.Checked = true;
                                rbtnOther.Checked = false;
                                tbxJLSize.Text = "";
                            }
                            else
                            {
                                rbtnMiscSupplies.Checked = false;
                                rbtnCleanoutMaterial.Checked = false;
                                rbtnBackfillCleanout.Checked = false;
                                rbtnRestorationCrowleCap.Checked = false;
                                rbtnOther.Checked = true;
                                tbxJLSize.Text = materialsInformationBasicInformationGatewayForLoad.GetSize(materialId);
                            }
                        }
                    }
                }                
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
                            grdCostsExceptions.ShowFooter = true;
                            if (checkbox.Checked)
                            {
                                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                                foreach (GridViewRow rowTemp in grdCosts.Rows)
                                {
                                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                                    {
                                        if (Validator.IsValidInt32(((Label)rowTemp.FindControl("lblCostID")).Text))
                                        {
                                            int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                                            if (costId != costTemp)
                                            {
                                                ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                                            }
                                        }
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



        protected void grdCostsExceptions_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblExceptionRefIDEdit")).Text.Trim());
                int costId = Int32.Parse(((Label)e.Row.FindControl("lblExceptionCostIDEdit")).Text.Trim());

                MaterialsInformationCostHistoryExceptionsInformationGateway materialsInformationCostHistoryExceptionsInformationGateway = new MaterialsInformationCostHistoryExceptionsInformationGateway(materialsInformationTDS);
                string workFunction = materialsInformationCostHistoryExceptionsInformationGateway.GetWorkFunction(costId, refId);
                ((DropDownList)e.Row.FindControl("ddlExceptionWorkFunctionEdit")).SelectedValue = workFunction;

                string unitOfMeasurement = materialsInformationCostHistoryExceptionsInformationGateway.GetUnitOfMeasurement(costId, refId);
                ((DropDownList)e.Row.FindControl("ddlExceptionUnitOfMeasurementMaterialsEdit")).SelectedValue = unitOfMeasurement;              
            }
        }


        protected void grdCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);
                int costId = Int32.Parse(((Label)e.Row.FindControl("lblCostIDEdit")).Text.Trim());

                MaterialsInformationCostHistoryInformationGateway materialsInformationCostHistoryInformationGateway = new MaterialsInformationCostHistoryInformationGateway(materialsInformationTDS);
                string unitOfMeasurement = materialsInformationCostHistoryInformationGateway.GetUnitOfMeasurement(costId, materialId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue = unitOfMeasurement;
            }
        }       



        protected void grdNotes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }
        }



        protected void grdCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Costs Gridview, if the gridview is edition mode
            if (grdCosts.EditIndex >= 0)
            {
                grdCosts.UpdateRow(grdCosts.EditIndex, true);
            }
        }



        protected void grdCostsExceptions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Costs exceptions Gridview, if the gridview is edition mode
            if (grdCostsExceptions.EditIndex >= 0)
            {
                grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
            }
        }

               

        protected void cvSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvConfirmerSize = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    if (!args.Value.Contains("\""))
                    {
                        cvConfirmerSize.Text = "Invalid format. (please use X'Y\", or X\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvJLSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvConfirmerSize = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    if (!args.Value.Contains("\""))
                    {
                        cvConfirmerSize.Text = "Invalid format. (please use X'Y\", or X\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                        args.IsValid = false;
                    }
                }
            }
        }



        protected void cvJLSizeEmpty_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if ((args.Value.Trim() == "") && (rbtnOther.Checked))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvSizeEmpty_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() == "")
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvJLSizeAutoGenerate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!rbtnOther.Checked)
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cbxSelectedCost_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            int costId = 0;
            Session["costIdSelected"] = 0;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            Session.Remove("materialsCostsExceptionsDummy");
            grdCostsExceptions.ShowFooter = true;
            if (checkbox.Checked)
            {
                GridViewRow row = (GridViewRow)checkbox.NamingContainer;
                costId = Int32.Parse(((Label)row.FindControl("lblCostID")).Text);

                foreach (GridViewRow rowTemp in grdCosts.Rows)
                {
                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                    {
                        if (Validator.IsValidInt32(((Label)rowTemp.FindControl("lblCostID")).Text))
                        {
                            int costTemp = Int32.Parse(((Label)rowTemp.FindControl("lblCostID")).Text);

                            if (costId != costTemp)
                            {
                                ((CheckBox)rowTemp.FindControl("cbxSelected")).Checked = false;
                            }
                        }
                    }
                }

                Session.Remove("costIdSelected");
                Session["costIdSelected"] = costId;
            }           
                        
            string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
            odsCostsExceptions.FilterExpression = filterOptions;
        }



        protected void cvEditDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (((RadDatePicker)grdCosts.Rows[grdCosts.EditIndex].FindControl("tkrdpDateEdit")).SelectedDate.HasValue)
            {
                DateTime newDate = Convert.ToDateTime(((RadDatePicker)grdCosts.Rows[grdCosts.EditIndex].FindControl("tkrdpDateEdit")).SelectedDate.Value);

                if (grdCosts.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCosts.Rows)
                    {
                        if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            if (Validator.IsValidDate(((Label)row.FindControl("lblDate")).Text))
                            {
                                DateTime date = Convert.ToDateTime(((Label)row.FindControl("lblDate")).Text);
                                if (date == newDate)
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvAddDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.HasValue)
            {
                DateTime newDate = Convert.ToDateTime(((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value);

                if (grdCosts.Rows.Count > 0)
                {
                    foreach (GridViewRow row in grdCosts.Rows)
                    {
                        if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                        {
                            if (Validator.IsValidDate(((Label)row.FindControl("lblDate")).Text))
                            {
                                DateTime date = Convert.ToDateTime(((Label)row.FindControl("lblDate")).Text);
                                if (date == newDate)
                                {
                                    args.IsValid = false;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                args.IsValid = false;
            }
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
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":                    
                    if (Request.QueryString["source_page"] == "materials_navigator2.aspx")
                    {
                        url = "./materials_navigator2.aspx?source_page=materials_edit.aspx" + GetNavigatorState() + "&update=yes";
                    }
                    else
                    {
                        if (Request.QueryString["source_page"] == "materials_summary.aspx")
                        {                            
                            url = "./materials_summary.aspx?source_page=materials_edit.aspx&material_id=" + hdfCurrentMaterialId.Value + GetNavigatorState() + "&update=yes" + "&active_tab=" + activeTabMaterials;
                        }
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = MaterialsNavigator.GetPreviousId((MaterialsNavigatorTDS)Session["materialsNavigatorTDS"], Int32.Parse(hdfCurrentMaterialId.Value));
                    if (previousId != Int32.Parse(hdfCurrentMaterialId.Value))
                    {
                        this.Apply();

                        // Redirect
                        url = "./materials_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&material_id=" + previousId.ToString() + "&active_tab=" + activeTabMaterials + GetNavigatorState() + "&update=yes";
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = MaterialsNavigator.GetNextId((MaterialsNavigatorTDS)Session["materialsNavigatorTDS"], Int32.Parse(hdfCurrentMaterialId.Value));
                    if (nextId != Int32.Parse(hdfCurrentMaterialId.Value))
                    {
                        this.Apply();

                        // Redirect
                        url = "./materials_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&material_id=" + nextId.ToString() + "&active_tab=" + activeTabMaterials + GetNavigatorState() + "&update=yes";
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
        // PUBLIC METHODS
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



        public void DummyNotesNew(int MaterialID, int RefID)
        {
        }



        public void DummyCostsNew(string UnitOfMeasurement, int CostID)
        {
        }



        public void DummyCostsNew(int CostID)
        {
        }



        public void DummyCostsNew(int CostID, int MaterialID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID)
        {
        }



        public void DummyCostsExceptionsNew()
        {
        }



        public void DummyCostsExceptionsNew(int CostID, int RefID)
        {
        }



        public void DummyCostsExceptionsNew(int CostID, int RefID, int MaterialID)
        {
        }



        public void DummyCostsExceptionsNew(string UnitOfMeasurement, int CostID, int RefID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfMaterialIdId = '" + hdfCurrentMaterialId.ClientID + "';";
            contentVariables += "var hdfResourceTypeId = '" + hdfResourceType.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';"; 

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_edit.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_state=" + Request.QueryString["search_state"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        #region Load Functions

        private void LoadData(int companyId)
        {
            // Get Material ID
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
                hdfProcess.Value = materialsInformationBasicInformationGateway.GetType(materialId);
                tbxProcess.Text = materialsInformationBasicInformationGateway.GetType(materialId);                
                tbxState.Text = materialsInformationBasicInformationGateway.GetState(materialId);
                tbxDescription.Text = materialsInformationBasicInformationGateway.GetDescription(materialId);

                if (hdfProcess.Value == "Full Length Lining")
                {
                    ddlThickness.SelectedValue = materialsInformationBasicInformationGateway.GetThickness(materialId);
                    tbxSize.Text = materialsInformationBasicInformationGateway.GetSize(materialId);                    
                }

                if (hdfProcess.Value == "Point Repairs")
                {
                    ddlPrSize.SelectedValue = materialsInformationBasicInformationGateway.GetSize(materialId);
                    ddlPrLength.SelectedValue = materialsInformationBasicInformationGateway.GetLength(materialId);                    
                }

                if (hdfProcess.Value == "Junction Lining")
                {
                    string jlDescription = materialsInformationBasicInformationGateway.GetDescription(materialId);
                    if (jlDescription ==  "Lateral / Misc Supplies")
                    {
                        rbtnMiscSupplies.Checked = true;
                    }
                    else
                    {
                        if (jlDescription ==  "Lateral / Cleanout Material")
                        {
                            rbtnCleanoutMaterial.Checked = true;
                        }
                        else
                        {
                            if (jlDescription ==  "Lateral / Backfill - Cleanout")
                            {
                                rbtnBackfillCleanout.Checked = true;
                            }
                            else
                            {
                                tbxJLSize.Text = materialsInformationBasicInformationGateway.GetSize(materialId);   
                            }
                        }
                    }
                }                                
            }
        }
        #endregion



        private void Save()
        {
            // Validate data
            bool validData = false;

            Page.Validate("generalInformation");
            if (Page.IsValid)
            {
                validData = true;

                // ... Validate notes tab
                if (ValidateNotesFooter())
                {
                    Page.Validate("notesDataAdd");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("notesDataEdit");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }

            // For valid data
            if (validData)
            {
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Save notes data                
                GrdNotesAdd();

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Save costs data                
                GrdCostsAdd();

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }

                // Save costs exceptions data                
                GrdCostsExceptionsAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

                // ... Get basic material data
                string thickness = "";
                string size = "";
                string length = "";
                string description = "";
                string state = tbxState.Text.Trim();

                if (hdfProcess.Value == "Full Length Lining")
                {
                    thickness =  ddlThickness.SelectedValue;
                    size = tbxSize.Text.Trim();
                    description = "Full Length Liner " + size;
                    if (thickness != "")
                    {
                        description = description + " / T." + thickness;
                    }
                }

                if (hdfProcess.Value == "Point Repairs")
                {
                    size = ddlPrSize.SelectedValue;
                    length = ddlPrLength.SelectedValue;
                    string formatedSize = size.Remove(size.Length - 1, 1);
                    formatedSize = formatedSize.PadLeft(3, '0');
                    string formatedLength = length.Remove(length.Length - 1, 1);
                    formatedLength = formatedLength.PadLeft(3, '0');
                    description = "PR-" + formatedSize + "-" + formatedLength + "-000";                    
                }

                if (hdfProcess.Value == "Junction Lining")
                {
                    size = "";
                    if (rbtnMiscSupplies.Checked) description = "Lateral / Misc Supplies";
                    if (rbtnCleanoutMaterial.Checked) description = "Lateral / Cleanout Material";
                    if (rbtnBackfillCleanout.Checked) description = "Lateral / Backfill - Cleanout";
                    if (rbtnRestorationCrowleCap.Checked) description = "Lateral / Restoration & Crowle Cap";
                    if (rbtnOther.Checked)
                    {
                        if (!tbxDescription.Text.Contains("Lateral"))
                        {
                            size = tbxJLSize.Text.Trim();
                            description = "Junction Liner " + size;
                        }
                        else
                        {
                            description = tbxDescription.Text;
                        }
                    }
                }                                

                // Update service data
                MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                materialsInformationBasicInformation.Update(materialId, description, size, length, thickness, hdfProcess.Value, state, false, companyId);

                // Store datasets
                Session["materialsInformationTDS"] = materialsInformationTDS;
                Session["materialsTDS"] = materialsTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "materials_navigator2.aspx")
                {
                    url = "./materials_navigator2.aspx?source_page=materials_edit.aspx&material_id=" + hdfCurrentMaterialId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "materials_summary.aspx")
                {
                    string activeTabMaterials = hdfActiveTab.Value;
                    url = "./materials_summary.aspx?source_page=materials_edit.aspx&material_id=" + hdfCurrentMaterialId.Value + "&active_tab=" + activeTabMaterials + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
        {
            // Validate data
            bool validData = false;

            Page.Validate("generalInformation");
            if (Page.IsValid)
            {
                validData = true;

                // ... Validate notes tab
                if (ValidateNotesFooter())
                {
                    Page.Validate("notesDataAdd");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                Page.Validate("notesDataEdit");
                if (!Page.IsValid)
                {
                    validData = false;
                }
            }

            // For valid data
            if (validData)
            {
                // Notes Gridview, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Costs Gridview, if the gridview is edition mode
                if (grdCosts.EditIndex >= 0)
                {
                    grdCosts.UpdateRow(grdCosts.EditIndex, true);
                }

                // Costs Exceptions Gridview, if the gridview is edition mode
                if (grdCostsExceptions.EditIndex >= 0)
                {
                    grdCostsExceptions.UpdateRow(grdCostsExceptions.EditIndex, true);
                }

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

                // ... Get basic material data
                string thickness = "";
                string size = "";
                string length = "";
                string description = "";
                string state = tbxState.Text.Trim();

                if (hdfProcess.Value == "Full Length Lining")
                {
                    thickness = ddlThickness.SelectedValue;
                    size = tbxSize.Text.Trim();
                    description = "Full Length Liner " + size;
                    if (thickness != "")
                    {
                        description = description + " / T." + thickness;
                    }
                }

                if (hdfProcess.Value == "Point Repairs")
                {
                    size = ddlPrSize.SelectedValue;
                    length = ddlPrLength.SelectedValue;
                    string formatedSize = size.Remove(size.Length - 1, 1);
                    formatedSize = formatedSize.PadLeft(3, '0');
                    string formatedLength = length.Remove(length.Length - 1, 1);
                    formatedLength = formatedLength.PadLeft(3, '0');
                    description = "PR-" + formatedSize + "-" + formatedLength + "-000";
                }

                if (hdfProcess.Value == "Junction Lining")
                {
                    size = "";
                    if (rbtnMiscSupplies.Checked) description = "Lateral / Misc Supplies";
                    if (rbtnCleanoutMaterial.Checked) description = "Lateral / Cleanout Material";
                    if (rbtnBackfillCleanout.Checked) description = "Lateral / Backfill - Cleanout";
                    if (rbtnOther.Checked)
                    {
                        size = tbxJLSize.Text.Trim();
                        description = "Junction Liner " + size;
                    }
                }

                // Update service data
                MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                materialsInformationBasicInformation.Update(materialId, description, size, length, thickness, hdfProcess.Value, state, false, companyId);

                // Store datasets
                Session["materialsInformationTDS"] = materialsInformationTDS;
                Session["materialsTDS"] = materialsTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private void GrdNotesAdd()
        {
            if (ValidateNotesFooter())
            {
                Page.Validate("notesDataAdd");
                if (Page.IsValid)
                {
                    int materialId = Int32.Parse(hdfCurrentMaterialId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    string newNote = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
                    bool inServiceNoteDatabase = false;

                    MaterialsInformationNoteInformation model = new MaterialsInformationNoteInformation(materialsInformationTDS);
                    model.Insert(materialId, newSubject, loginId, dateTime_, newNote, false, companyId, inServiceNoteDatabase);

                    Session.Remove("materialsNotesDummy");
                    Session["materialsInformationTDS"] = materialsInformationTDS;

                    grdNotes.DataBind();
                    grdNotes.PageIndex = grdNotes.PageCount - 1;
                }
            }
        }



        private void GrdCostsAdd()
        {
            if (ValidateCostsFooter())
            {
                Page.Validate("AddCost");
                if (Page.IsValid)
                {
                    int materialId = Int32.Parse(hdfCurrentMaterialId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    DateTime date_ = ((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value;
                    string unitOfMeasurement = ((DropDownList)grdCosts.FooterRow.FindControl("ddlUnitOfMeasurementMaterialsNew")).SelectedValue;
                    decimal costCad = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostCadNew")).Text.Trim());
                    decimal costUsd = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostUsdNew")).Text.Trim());

                    MaterialsInformationCostHistoryInformation model = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
                    model.Insert(materialId, date_, unitOfMeasurement, costCad, costUsd, false, companyId, false);

                    Session.Remove("materialsCostsDummy");
                    Session["materialsInformationTDS"] = materialsInformationTDS;

                    grdCosts.DataBind();
                }
            }
        }



        private void GrdCostsExceptionsAdd()
        {
            if (ValidateCostsExceptionsFooter())
            {
                Page.Validate("AddCostException");
                if (Page.IsValid)
                {
                    int costId = Convert.ToInt32(Session["costIdSelected"]);
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    string unitOfMeasurement = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionUnitOfMeasurementMaterialsNew")).SelectedValue;
                    decimal costCad = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostCadNew")).Text.Trim());
                    decimal costUsd = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostUsdNew")).Text.Trim());
                    string workFunctionConcat = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWorkFunctionNew")).SelectedValue;

                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    string work_ = workFunction[0].Trim();
                    string function_ = workFunction[1].Trim();

                    MaterialsInformationCostHistoryExceptionsInformation model = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);
                    model.Insert(costId, work_, function_, unitOfMeasurement, costCad, costUsd, false, companyId, false, workFunctionConcat);

                    Session.Remove("materialsCostsExceptionsDummy");
                    Session["materialsInformationTDS"] = materialsInformationTDS;

                    string filterOptions = string.Format("CostID = {0} AND Deleted = {1}", costId, 0);
                    odsCostsExceptions.FilterExpression = filterOptions;

                    grdCostsExceptions.DataBind();
                }
            }
        }



        private bool ValidateNotesFooter()
        {
            string subject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
            string note = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();

            if ((subject != "") || (note != ""))
            {
                return true;
            }

            return false;
        }



        private bool ValidateCostsFooter()
        {
            DateTime? date_ = null; if (((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.HasValue) date_ = ((RadDatePicker)grdCosts.FooterRow.FindControl("tkrdpDateNew")).SelectedDate.Value;
            string unitOfMeasurement = ((DropDownList)grdCosts.FooterRow.FindControl("ddlUnitOfMeasurementMaterialsNew")).SelectedValue;
            decimal? costCad = null; if(((TextBox)grdCosts.FooterRow.FindControl("tbxCostCadNew")).Text.Trim() != "") costCad = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostCadNew")).Text.Trim());
            decimal? costUsd = null; if (((TextBox)grdCosts.FooterRow.FindControl("tbxCostUsdNew")).Text.Trim() != "") costUsd = Decimal.Parse(((TextBox)grdCosts.FooterRow.FindControl("tbxCostUsdNew")).Text.Trim());

            if ((date_.HasValue) || (costCad.HasValue) || (costUsd.HasValue))
            {
                return true;
            }

            return false;
        }



        private bool ValidateCostsExceptionsFooter()
        {
            string typeOfWork = ""; if (((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWorkFunctionNew")).SelectedValue != "(Select)") typeOfWork = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionWorkFunctionNew")).SelectedValue;
            string unitOfMeasurement = ((DropDownList)grdCostsExceptions.FooterRow.FindControl("ddlExceptionUnitOfMeasurementMaterialsNew")).SelectedValue;
            decimal? costCad = null; if (((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostCadNew")).Text.Trim() != "") costCad = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostCadNew")).Text.Trim());
            decimal? costUsd = null; if (((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostUsdNew")).Text.Trim() != "") costUsd = Decimal.Parse(((TextBox)grdCostsExceptions.FooterRow.FindControl("tbxExceptionCostUsdNew")).Text.Trim());

            if ((typeOfWork != "") || (costCad.HasValue) || (costUsd.HasValue))
            {
                return true;
            }

            return false;
        }



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



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int materialId = Int32.Parse(hdfCurrentMaterialId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save notes information
                MaterialsInformationNoteInformation materialsInformationNoteInformation = new MaterialsInformationNoteInformation(materialsInformationTDS);
                materialsInformationNoteInformation.Save(companyId);

                // Save costs information
                MaterialsInformationCostHistoryInformation materialsInformationCostHistoryInformation = new MaterialsInformationCostHistoryInformation(materialsInformationTDS);
                materialsInformationCostHistoryInformation.Save(companyId);

                // Save costs exceptions information
                MaterialsInformationCostHistoryExceptionsInformation materialsInformationCostHistoryExceptionsInformation = new MaterialsInformationCostHistoryExceptionsInformation(materialsInformationTDS);
                materialsInformationCostHistoryExceptionsInformation.Save(companyId, materialId);

                // Save material information 
                MaterialsInformationBasicInformation materialsInformationBasicInformation = new MaterialsInformationBasicInformation(materialsInformationTDS);
                materialsInformationBasicInformation.Save(companyId);

                DB.CommitTransaction();

                // Store datasets
                materialsInformationTDS.AcceptChanges();
                Session["materialsInformationTDS"] = materialsInformationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
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