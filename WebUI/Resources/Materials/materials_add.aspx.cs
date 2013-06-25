using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Common;

namespace LiquiForce.LFSLive.WebUI.Resources.Materials
{
    /// <summary>
    /// materials_add
    /// </summary>
    public partial class materials_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected MaterialsAddTDS materialsAddTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_MATERIALS_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in materials_add_request.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

                // If coming from 
                // ... employee_navigator.aspx
                if (Request.QueryString["source_page"] == "lm")
                {
                    // ... Initialize tables
                    materialsAddTDS = new MaterialsAddTDS();

                    MaterialsAddGateway materialsAddGateway = new MaterialsAddGateway(materialsAddTDS);
                    materialsAddGateway.LoadAll(Int32.Parse(hdfCompanyId.Value));

                    // ... Store tables
                    Session["materialsAddTDS"] = materialsAddTDS;
                }

                // StepSection1In
                wzMaterials.ActiveStepIndex = 0;                
                StepBeginIn();
            }
            else
            {
                // Restore tables
                materialsAddTDS = (MaterialsAddTDS)Session["materialsAddTDS"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzMaterials.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "General Data":
                        StepGeneralDataIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzMaterials.ActiveStepIndex = wzMaterials.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzMaterials.ActiveStep.Name + " step in employees_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzMaterials.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                    }
                    break;

                case "General Data":
                    e.Cancel = !StepGeneralDataNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzMaterials.ActiveStep.Name + " step in materials_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzMaterials.ActiveStep.Name)
            {
                case "General Data":
                    e.Cancel = !StepGeneralDataPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzMaterials.ActiveStep.Name + " step in materials_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzMaterials.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //      

        protected void cvProcess_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if (ddlProcess.SelectedValue == "(Select a process)")
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a work process";
        }



        private bool StepBeginNext()
        {
            Page.Validate("beginInformation");
            if (Page.IsValid) 
            {
                Session["selectedProcess"] = ddlProcess.SelectedValue;
                return true;
            }

            return false;
        }



        #endregion






        #region STEP2 - GENERAL DATA

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - GENERAL DATA
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL DATA - AUXILIAR EVENTS
        // 

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






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL DATA - METHODS
        //

        private void StepGeneralDataIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide the following information for the new material";

            // Format Description
            if (Session["selectedProcess"].ToString() == "Full Length Lining")
            {
                pnlJunctionLiner.Visible = false;
                pnlPointRepairs.Visible = false;
                pnlFullLengthLining.Visible = true;                
            }

            if (Session["selectedProcess"].ToString() == "Point Repairs")
            {
                pnlJunctionLiner.Visible = false;
                pnlPointRepairs.Visible = true;
                pnlFullLengthLining.Visible = false;
            }

            if (Session["selectedProcess"].ToString() == "Junction Lining")
            {
                pnlJunctionLiner.Visible = true;
                pnlPointRepairs.Visible = false;
                pnlFullLengthLining.Visible = false;
            }
        }



        private bool StepGeneralDataPrevious()
        {
            return true;
        }



        private bool StepGeneralDataNext()
        {
            Page.Validate("detailInformation");
            if (Page.IsValid)
            {
                hdfThickness.Value = "";         
                hdfType.Value = Session["selectedProcess"].ToString();
                hdfState.Value = "Available";

                if (Session["selectedProcess"].ToString() == "Full Length Lining")
                {
                    hdfThickness.Value = ddlThickness.SelectedValue;
                    hdfSize.Value = tbxSize.Text.Trim();
                    hdfDescription.Value = "Full Length Liner " + hdfSize.Value;
                    if (ddlThickness.SelectedValue != "")
                    {
                        hdfDescription.Value = hdfDescription.Value + " / T." + hdfThickness.Value;
                    }
                }

                if (Session["selectedProcess"].ToString() == "Point Repairs")
                {                    
                    hdfSize.Value = ddlPrSize.SelectedValue;
                    string size = hdfSize.Value.Remove(hdfSize.Value.Length - 1, 1);
                    hdfLength.Value = ddlPrLength.SelectedValue;
                    string length = ddlPrLength.SelectedValue.Remove(ddlPrLength.SelectedValue.Length - 1, 1);
                    size = size.PadLeft(3, '0');
                    length = length.PadLeft(3, '0');
                    hdfDescription.Value = "PR-" + size + "-" + length + "-000";
                }

                if (Session["selectedProcess"].ToString() == "Junction Lining")
                {
                    hdfSize.Value = ""; 
                    if (rbtnMiscSupplies.Checked) hdfDescription.Value = "Lateral / Misc Supplies";
                    if (rbtnCleanoutMaterial.Checked) hdfDescription.Value = "Lateral / Cleanout Material";
                    if (rbtnBackfillCleanout.Checked) hdfDescription.Value= "Lateral / Backfill - Cleanout";
                    if (rbtnRestorationCrowleCap.Checked) hdfDescription.Value = "Lateral / Restoration & Crowle Cap ";
                    if (rbtnOther.Checked)
                    {
                        hdfSize.Value = tbxJLSize.Text.Trim();
                        hdfDescription.Value = "Junction Liner " + hdfSize.Value;
                    }
                }                

                return true;
            }

            return false;
        }


        #endregion






        #region STEP3 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Initialize summary
            tbxSummary.Text = GetSummary();
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        protected bool StepSummaryFinish()
        {
            Page.Validate("StepSummary");
            if (Page.IsValid)
            {
                PostPageChanges();
                UpdateDatabase();

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion






        #region STEP4 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            // Store active tab for postback
            Session["activeTabMaterials"] = "0";
            Session["dialogOpenedMaterials"] = "0";

            string url = "";

            url = "./materials_summary.aspx?source_page=materials_add.aspx&material_id=" + hdfMaterialId.Value + "&active_tab=0" + GetNavigatorState();
            lkbtnOpen.Attributes.Add("onclick", string.Format("return lkbtnOpenClick('{0}');", url));

            url = "./materials_edit.aspx?source_page=materials_add.aspx&material_id=" + hdfMaterialId.Value + "&active_tab=0" + GetNavigatorState();
            lkbtnEdit.Attributes.Add("onclick", string.Format("return lkbtnEditClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Materials";
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./materials_add.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                MaterialsAdd materialsAdd = new MaterialsAdd(materialsAddTDS);
                materialsAdd.Save();

                DB.CommitTransaction();

                // Store datasets
                materialsAddTDS.AcceptChanges();
                Session["materialsAddTDS"] = materialsAddTDS;

            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void PostPageChanges()
        {
            // Load user data
            string description = hdfDescription.Value;
            string size = hdfSize.Value;
            string length = hdfLength.Value;
            string thickness = hdfThickness.Value;
            string type = hdfType.Value;
            string state = hdfState.Value;
            bool deleted = false;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            bool inDataBase = false;

            LiquiForce.LFSLive.BL.Resources.Materials.MaterialsAdd model = new LiquiForce.LFSLive.BL.Resources.Materials.MaterialsAdd(materialsAddTDS);
            hdfMaterialId.Value =  model.Insert( description, size, length, thickness, type, state, deleted, companyId, inDataBase).ToString();

            // Store session
            Session["materialsAddTDS"] = materialsAddTDS;
        }



        private string GetSummary()
        {
            string summary = "NEW MATERIAL \n\n";
            summary = summary + "Process: " + hdfType.Value + "\n";
            summary = summary + "Description: " + hdfDescription.Value + "\n";           

            if (Session["selectedProcess"].ToString() == "Full Length Lining")
            {
                summary = summary + "Size: " + hdfSize.Value + "\n";
                summary = summary + "Thickness: " + hdfThickness.Value + "\n";
            }

            if (Session["selectedProcess"].ToString() == "Point Repairs")
                {
                    summary = summary + "Size: " + hdfSize.Value + "\n";
                    summary = summary + "Length: " + hdfLength.Value + "\n";
                }

            if (Session["selectedProcess"].ToString() == "Junction Lining")
            {
                if (rbtnOther.Checked)
                {
                    summary = summary + "Size: " + hdfSize.Value + "\n";
                }               
            }

            summary = summary + "\nState: " + hdfState.Value + "\n";
            
            return summary;
        }

        

        private string GetNavigatorState()
        {
            // Columns to display
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = "Materials";
            string columnsToDisplay = "&columns_to_display=";

            ResourceTypeViewDisplay resourceTypeViewDisplay = new ResourceTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + resourceTypeViewDisplay.GetColumnsByDefault(resourceType, companyId, true);

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";

            // Other values
            searchOptions = searchOptions + "&search_state=1";
            searchOptions = searchOptions + "&btn_origin=Search";

            // Return
            return columnsToDisplay + searchOptions;
        }



    }
}
