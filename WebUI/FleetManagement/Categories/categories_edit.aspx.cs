using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Categories
{
    /// <summary>
    /// categories_edit
    /// </summary>
    public partial class categories_edit : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected CategoriesAddTDS categoriesAddTDS;
        protected CategoriesTDS categoriesTDS;
        protected ArrayList arrayCategoriesSelected;
        protected ArrayList arrayCategoriesSelected2;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // Prepare initial data 

                // ... Remove sessions
                Session.Remove("arrayCategoriesSelected");
                Session.Remove("arrayCategoriesSelected2");
                
                categoriesAddTDS = new CategoriesAddTDS();
                Session["categoriesAddTDS"] = categoriesAddTDS;

                // ... for Categories
                categoriesTDS = new CategoriesTDS();
                Session["categoriesTDSForEdit"] = categoriesTDS;

                arrayCategoriesSelected = new ArrayList();
                arrayCategoriesSelected2 = new ArrayList();
                Session["arrayCategoriesSelected"] = arrayCategoriesSelected;
                Session["arrayCategoriesSelected2"] = arrayCategoriesSelected2;
                
                wzCategoriesAdd.ActiveStepIndex = 0;
                StepOperationIn();
            }
            else
            {
                // Restore tables
                categoriesTDS = (CategoriesTDS)Session["categoriesTDSForEdit"];
                categoriesAddTDS = (CategoriesAddTDS)Session["categoriesAddTDS"];
                arrayCategoriesSelected = (ArrayList)Session["arrayCategoriesSelected"];
                arrayCategoriesSelected2 = (ArrayList)Session["arrayCategoriesSelected2"];
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
                switch (wzCategoriesAdd.ActiveStep.Name)
                {
                    case "Type":
                        StepTypeIn();
                        break;

                    case "Operation":
                        StepOperationIn();
                        break;

                    case "Categories":
                        StepCategoriesIn();
                        break;

                    case "Warning":
                        StepWarningIn();
                        break;

                    case "Category to replace":
                        StepCategories2In();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("Not exist the option for " + wzCategoriesAdd.ActiveStep.Name + " step in categories_edit.Wizard_ActiveStepChanged function");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCategoriesAdd.ActiveStep.Name)
            {
                case "Type":
                    e.Cancel = !StepTypeNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Type";
                    }
                    break;

                case "Operation":
                    e.Cancel = !StepOperationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Operation";
                    }
                    break;

                case "Categories":
                    e.Cancel = !StepCategoriesNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Categories";

                        if (rbtnDeleteCategory.Checked)
                        {
                            bool inUse = false;
                            foreach (int categoryId in arrayCategoriesSelected)
                            {
                                CategoriesAddNew categoriesAddNew = new CategoriesAddNew(null);
                                inUse = categoriesAddNew.CategoryIsUsed(categoryId, Int32.Parse(hdfCompanyId.Value));
                            }

                            if (inUse)
                            {
                                wzCategoriesAdd.ActiveStepIndex = wzCategoriesAdd.WizardSteps.IndexOf(StepWarning);
                            }
                            else
                            {
                                wzCategoriesAdd.ActiveStepIndex = wzCategoriesAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }
                        else
                        {
                            wzCategoriesAdd.ActiveStepIndex = wzCategoriesAdd.WizardSteps.IndexOf(StepSummary);
                        }
                    }
                    break;

                case "Warning":
                    e.Cancel = !StepWarningNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Warning";
                    }
                    break;

                case "Category to replace":
                    e.Cancel = !StepCategories2Next();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Categories2";
                    }
                    break;                

                default:
                    throw new Exception("Not exists the option for " + wzCategoriesAdd.ActiveStep.Name + " step in categories_edit.Wizard_NextButtonClick function");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCategoriesAdd.ActiveStep.Name)
            {
                case "Operation":
                    e.Cancel = !StepOperationPrevious();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Operation";
                    }
                    break;

                case "Categories":
                    e.Cancel = !StepCategoriesPrevious();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Categories";
                    }
                    break;

                case "Warning":
                    e.Cancel = !StepWarningPrevious();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Warning";
                    }
                    break;

                case "Category to replace":
                    e.Cancel = !StepCategories2Previous();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Categories2";
                    }
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Summary";
                    }
                    break;

                default:
                    throw new Exception("Not exists the option for " + wzCategoriesAdd.ActiveStep.Name + " step in categories_edit.Wizard_PreviousButtonClick function");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzCategoriesAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();

            if (!e.Cancel)
            {
                string url = "";
                hdfUpdate.Value = "yes";

                url = "window.opener.location";
                Response.Write("<script language='javascript'> { window.opener.location.href = " + url + "; window.close();}</script>");                                
            }
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - TYPE

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - TYPE
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - TYPE - METHODS
        //

        private void StepTypeIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a unit type";
        }



        private bool StepTypeNext()
        {
            Category category = new Category(categoriesTDS);

            if (rbtnVehicle.Checked)
            {
                category.LoadByUnitType("Vehicle", int.Parse(hdfCompanyId.Value));
            }
            else
            {
                category.LoadByUnitType("Equipment", int.Parse(hdfCompanyId.Value));
            }

            Session["categoriesTDSForEdit"] = categoriesTDS;

            tvCategoriesRoot.Nodes.Clear();
            GetNodeForCategory(tvCategoriesRoot.Nodes, 0);
            GetNodeForCategory(tvCategoriesRoot2.Nodes, 0);

            return true;
        }



        #endregion






        #region STEP2 - OPERATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP2 - OPERATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - OPERATION - METHODS
        //

        private void StepOperationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select an operation";
        }



        private bool StepOperationNext()
        {
            return true;
        }



        private bool StepOperationPrevious()
        {
            return true;
        }

        #endregion
        





        #region STEP3 - CATEGORIES

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - CATEGORIES
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - CATEGORIES - AUXILIAR EVENTS
        //

        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCategoriesSelected = (ArrayList)Session["arrayCategoriesSelected"];
            arrayCategoriesSelected.Clear();

            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesSelected(nodes);
            }

            if (tvCategoriesRoot.Nodes.Count > 0)
            {
                if (arrayCategoriesSelected.Count > 0)
                {
                    if (arrayCategoriesSelected.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCategories.ErrorMessage = "You can select only one category";
                    }
                }
                else
                {
                    if (!rbtnAddCategory.Checked)
                    {
                        cvCategories.ErrorMessage = "You must select at least one category";
                    }
                    else
                    {
                        args.IsValid = true;
                    }
                }
            }
            else
            {
                cvCategories.ErrorMessage = "There are no categories available. Contact your system administrator";
            }

            Session["arrayCategoriesSelected"] = arrayCategoriesSelected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - CATEGORIES - METHODS
        //

        private void StepCategoriesIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");

            if (rbtnAddCategory.Checked)
            {
                instruction.Text = "Please select the parent category (option), then define the name";
                lblName.Visible = true;
                tbxName.Visible = true;               
            }

            if (rbtnEditCategory.Checked)
            {
                instruction.Text = "Please select the category to edit, then define it's new name";
                lblName.Visible = true;
                tbxName.Visible = true; 
            }

            if (rbtnDeleteCategory.Checked)
            {
                instruction.Text = "Please select the category to delete";
                lblName.Visible = false;
                tbxName.Visible = false;
            }
        }



        private bool StepCategoriesNext()
        {
            bool isValid = true;

            Page.Validate("StepCategories");

            if (Page.IsValid)
            {
                if (!rbtnDeleteCategory.Checked)
                {
                    Page.Validate("StepCategoriesName");
                }

                isValid = Page.IsValid;
            }
            else
            {
                isValid = false;
            }

            return isValid;
        }



        private bool StepCategoriesPrevious()
        {
            return true;
        }



        private void GetCategoriesSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected(node2);
                }
            }
        }

        #endregion






        #region STEP4 - WARNING

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - WARNING
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - WARNING - METHODS
        //

        private void StepWarningIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Warning: The category you are about to delete contains the following units and checklist rules associated";

            foreach (int categoryId in arrayCategoriesSelected)
            {
                CategoriesAddNew categoriesAddNew = new CategoriesAddNew(null);
                tbxWarning.Text = categoriesAddNew.GetRulesAndUnitsByCategoryId(categoryId, Int32.Parse(hdfCompanyId.Value));
            }            
        }



        private bool StepWarningNext()
        {
            return true;
        }



        private bool StepWarningPrevious()
        {
            return true;
        }

        #endregion






        #region STEP5 - CATEGORIES 2

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - CATEGORIES 2
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - CATEGORIES 2 - AUXILIAR EVENTS
        //

        protected void cvCategories2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCategoriesSelected2 = (ArrayList)Session["arrayCategoriesSelected2"];
            arrayCategoriesSelected2.Clear();

            foreach (TreeNode nodes in tvCategoriesRoot2.Nodes)
            {
                GetCategoriesSelected2(nodes);
            }

            if (tvCategoriesRoot2.Nodes.Count > 0)
            {
                if (arrayCategoriesSelected2.Count > 0)
                {
                    if (arrayCategoriesSelected2.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCategories2.ErrorMessage = "You can select only one category";
                    }
                }
                else
                {
                    cvCategories2.ErrorMessage = "You must select at least one category";
                }
            }
            else
            {
                cvCategories2.ErrorMessage = "There are no categories available. Contact your system administrator";
            }

            Session["arrayCategoriesSelected2"] = arrayCategoriesSelected2;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - CATEGORIES 2 - METHODS
        //

        private void StepCategories2In()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define the category to replace";
        }



        private bool StepCategories2Next()
        {
            bool isValid = true;

            Page.Validate("StepCategories2");

            if (!Page.IsValid)
            {
                isValid = false;
            }

            return isValid;
        }



        private bool StepCategories2Previous()
        {
            return true;
        }



        private void GetCategoriesSelected2(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected2.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected2.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected2(node2);
                }
            }
        }


        #endregion






        #region STEP6 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";
            hdfUpdate.Value = "yes";

            if (rbtnAddCategory.Checked) tbxSummary.Text = "Operation: Add category";
            if (rbtnDeleteCategory.Checked) tbxSummary.Text = "Operation: Delete category";
            if (rbtnEditCategory.Checked) tbxSummary.Text = "Operation: Edit category";

            if (!rbtnDeleteCategory.Checked)
            {
                if (arrayCategoriesSelected.Count > 0)
                {
                    foreach (int categoryIdInArray in arrayCategoriesSelected)
                    {
                        CategoryGateway categoryGateway = new CategoryGateway();
                        categoryGateway.LoadByCategoryId(categoryIdInArray, int.Parse(hdfCompanyId.Value));

                        tbxSummary.Text += "\nParent category: " + categoryGateway.GetName(categoryIdInArray);
                    }
                }
                else
                {
                    tbxSummary.Text += "\nParent category: (Empty)";
                }
            }

            if (!rbtnDeleteCategory.Checked)
            {
                tbxSummary.Text += "\nName: " + tbxName.Text;
            }
            else
            {
                foreach (int categoryIdInArray in arrayCategoriesSelected)
                {
                    CategoryGateway categoryGateway = new CategoryGateway();
                    categoryGateway.LoadByCategoryId(categoryIdInArray, int.Parse(hdfCompanyId.Value));

                    tbxSummary.Text += "\nName: " + categoryGateway.GetName(categoryIdInArray);
                }
            }
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        private bool StepSummaryFinish()
        {
            if (Page.IsValid)
            {
                int companyId = Convert.ToInt32(Session["companyID"]);
                string unitType = ""; if (rbtnEquipment.Checked) unitType = "Equipment"; else unitType = "Vehicle";
                int? categoryId = null;

                foreach (int categoryIdInArray in arrayCategoriesSelected)
                {
                    categoryId = categoryIdInArray;
                }
                                
                if (rbtnAddCategory.Checked)
                {                          
                    CategoriesAddNew categoriesAddnew = new CategoriesAddNew(categoriesAddTDS);
                    categoriesAddnew.Insert(null, null, unitType, tbxName.Text.Trim(), categoryId, false, companyId, false);
                }

                if (rbtnEditCategory.Checked)
                {
                    CategoriesAddNew categoriesAddnew = new CategoriesAddNew(categoriesAddTDS);
                    categoriesAddnew.Insert(categoryId, null, unitType, tbxName.Text.Trim(), null, false, companyId, true);
                }

                if (rbtnDeleteCategory.Checked)
                {
                    int? newCategoryId = null;

                    if (arrayCategoriesSelected2.Count > 0)
                    {
                        foreach (int categoryId2 in arrayCategoriesSelected2)
                        {
                            newCategoryId = categoryId2;
                        }
                    }
                    
                    CategoriesAddNew categoriesAddnew = new CategoriesAddNew(categoriesAddTDS);
                    categoriesAddnew.Insert(categoryId, newCategoryId, unitType, tbxName.Text.Trim(), null, true, companyId, true);
                }
                           
                
                // Store database
                Session["categoriesAddTDS"] = categoriesAddTDS;

                Save();

                hdfUpdate.Value = "yes";

                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Categories";
        }



        private void GetNodeForCategory(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;

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

                // step 4
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 5
                GetNodeForCategory(newNode.ChildNodes, thisId);
            }
        }



        private void Save()
        {
            // save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                CategoriesAddNew categoriesAddNew = new CategoriesAddNew(categoriesAddTDS);
                categoriesAddNew.Save();

                // Store datasets
                categoriesAddTDS.AcceptChanges();
                Session["categoriesAddTDS"] = categoriesAddTDS;

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



    }
}
