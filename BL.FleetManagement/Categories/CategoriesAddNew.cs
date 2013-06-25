using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using System.Collections;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.Categories
{
    /// <summary>
    /// CategoriesAddNew
    /// </summary>
    public class CategoriesAddNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CategoriesAddNew()
            : base("CategoriesAddNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CategoriesAddNew(DataSet data)
            : base(data, "CategoriesAddNew")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CategoriesAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="newCategoryID">newCategoryID</param>
        /// <param name="type">type</param>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int? categoryId, int? newCategoryID, string type, string name, int? parentId, bool deleted, int companyId, bool inDatabase)
        {
            CategoriesAddTDS.CategoriesAddNewRow row = ((CategoriesAddTDS.CategoriesAddNewDataTable)Table).NewCategoriesAddNewRow();

            if (categoryId.HasValue) row.CategoryID = (int)categoryId; else row.CategoryID = GetNewCategoryId();
            if (newCategoryID.HasValue) row.NewCategoryID = (int)newCategoryID; else row.SetNewCategoryIDNull();
            row.Type = type;
            row.Name = name;
            if (parentId.HasValue) row.ParentID = (int)parentId; else row.SetParentIDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((CategoriesAddTDS.CategoriesAddNewDataTable)Table).AddCategoriesAddNewRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            foreach (CategoriesAddTDS.CategoriesAddNewRow row in (CategoriesAddTDS.CategoriesAddNewDataTable)Data.Tables["CategoriesAddNew"])
            {
                // Insert category
                if ((!row.Deleted) && (!row.InDatabase))
                {
                    int? parentId = null; if (!row.IsParentIDNull()) parentId = row.ParentID;
                    InsertCategory(row.Type, row.Name, parentId, row.Deleted, row.COMPANY_ID);
                }

                // Update category
                if ((!row.Deleted) && (row.InDatabase))
                {
                    int companyId = row.COMPANY_ID;
                    CategoryGateway categoryGateway = new CategoryGateway();
                    categoryGateway.LoadByCategoryId(row.CategoryID, companyId);

                    int categoryId = row.CategoryID;
                    string originalType = categoryGateway.GetType(categoryId);
                    string originalName = categoryGateway.GetName(categoryId);
                    int? originalParentId = null; if (categoryGateway.GetParentId(categoryId).HasValue) originalParentId = (int)categoryGateway.GetParentId(categoryId);
                    bool originalDeleted = categoryGateway.GetDeleted(categoryId);
                    
                    UpdateCategory(categoryId, originalType, originalName, originalParentId, originalDeleted, companyId, row.CategoryID, row.Type, row.Name, originalParentId, row.Deleted, companyId);
                }

                // Delete category
                if ((row.Deleted) && (row.InDatabase))
                {
                    int categoryId = row.CategoryID;
                    int? newCategoryId = null; if (!row.IsNewCategoryIDNull()) newCategoryId = row.NewCategoryID;
                    int companyId = row.COMPANY_ID;

                    UpdateUnitsAndRulesCategories(categoryId, newCategoryId, companyId);
                    DeleteCategory(categoryId, companyId);  
                }
            }
        }



        /// <summary>
        /// CategoryIsUsed
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True or False</returns>
        public bool CategoryIsUsed(int categoryId, int companyId)
        {
            bool inUse = false;
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.Load(companyId);
            
            foreach (UnitsTDS.LFS_FM_UNITRow row in (UnitsTDS.LFS_FM_UNITDataTable)unitsGateway.Table)
            {
                int unitId = row.UnitID;

                UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);
                if (unitsCategoryGateway.IsUsedInUnitCategory(unitId, categoryId))
                {
                    inUse = true;
                }                
            }

            LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.RuleGateway ruleGateway = new RuleGateway();
            ruleGateway.Load(companyId);

            foreach (RuleTDS.LFS_FM_RULERow row in (RuleTDS.LFS_FM_RULEDataTable)ruleGateway.Table)
            {
                int ruleId = row.RuleID;

                RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);
                if (ruleCategoryGateway.IsUsedInRuleCategory(ruleId, categoryId))
                {
                    inUse = true;
                }                
            }

            return inUse;
        }



        /// <summary>
        /// GetRulesAndUnitsByCategoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public string GetRulesAndUnitsByCategoryId(int categoryId, int companyId)
        {
            string rules = "";
            string units = "";

            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.Load(companyId);

            foreach (UnitsTDS.LFS_FM_UNITRow rowUnits in (UnitsTDS.LFS_FM_UNITDataTable)unitsGateway.Table)
            {
                int unitId = rowUnits.UnitID;

                UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);
                if (unitsCategoryGateway.IsUsedInUnitCategory(unitId, categoryId))
                {
                    if (units.Length > 0)
                    {
                        units += "\t" + rowUnits.UnitCode + " - " + rowUnits.Description + "\n";                        
                    }
                    else
                    {
                        units += "Units:\n\n";
                        units += "\t" + rowUnits.UnitCode + " - " + rowUnits.Description + "\n";                        
                    }
                }
            }

            if (units.Length > 0)
            {
                units += "\n\n";
            }

            LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.RuleGateway ruleGateway = new RuleGateway();
            ruleGateway.Load(companyId);

            foreach (RuleTDS.LFS_FM_RULERow rowChecklistRules in (RuleTDS.LFS_FM_RULEDataTable)ruleGateway.Table)
            {
                int ruleId = rowChecklistRules.RuleID;

                RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);
                if (ruleCategoryGateway.IsUsedInRuleCategory(ruleId, categoryId))
                {
                    if (rules.Length > 0)
                    {
                        rules += "\t" + rowChecklistRules.Name + " - " + rowChecklistRules.Description + "\n";
                    }
                    else
                    {
                        rules += "Checklist Rules:\n\n";
                        rules += "\t" + rowChecklistRules.Name + "\n";
                    }
                }
            }

            return units + rules;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single unit. If not exists, raise an exception
        /// </summary>
        /// <param name="categoryId">internal categoryId</param>
        /// <returns>Row</returns>
        private CategoriesAddTDS.CategoriesAddNewRow GetRow(int categoryId)
        {
            CategoriesAddTDS.CategoriesAddNewRow row = ((CategoriesAddTDS.CategoriesAddNewDataTable)Table).FindByCategoryID(categoryId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Categories.CategoriesAddNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>UnitID</returns>
        private int GetNewCategoryId()
        {
            int newId = 0;

            foreach (CategoriesAddTDS.CategoriesAddNewRow row in (CategoriesAddTDS.CategoriesAddNewDataTable)Table)
            {
                if (newId < row.CategoryID)
                {
                    newId = row.CategoryID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// InsertCategory
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        private void InsertCategory(string type, string name, int? parentId, bool deleted, int companyId)
        {
            Category categories = new Category(null);
            categories.InsertDirect(type, name, parentId, deleted, companyId);
        }



        /// <summary>
        /// UpdateCategory
        /// </summary>
        /// <param name="originalCategoryId">originalCategoryId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newCategoryId">newCategoryId</param>
        /// <param name="newType">newType</param>
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        private void UpdateCategory(int originalCategoryId, string originalType, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, int newCategoryId, string newType, string newName, int? newParentId, bool newDeleted, int newCompanyId)
        {           
            Category category = new Category(null);
            category.UpdateDirect(originalCategoryId, originalType, originalName, originalParentId, originalDeleted, originalCompanyId, newCategoryId, newType, newName, newParentId, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeleteCategory
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteCategory(int categoryId, int companyId)
        {
            Category category = new Category(null);
            category.DeletedDirect(categoryId, companyId);
        }



        /// <summary>
        /// UpdateUnitsAndRulesCategories
        /// </summary>
        /// <param name="originalCategoryId">originalCategoryId</param>
        /// <param name="newCategoryId">newCategoryId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateUnitsAndRulesCategories(int originalCategoryId, int? newCategoryId, int companyId)
        {
            // Update rules categories
            LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.RuleGateway ruleGateway = new RuleGateway();
            ruleGateway.Load(companyId);

            if (ruleGateway.Table.Rows.Count > 0)
            {
                foreach (RuleTDS.LFS_FM_RULERow row in (RuleTDS.LFS_FM_RULEDataTable)ruleGateway.Table)
                {
                    int ruleId = row.RuleID;

                    RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);

                    if ((ruleCategoryGateway.IsUsedInRuleCategory(ruleId, originalCategoryId)) && (newCategoryId.HasValue))
                    {
                        if (!ruleCategoryGateway.IsUsedInRuleCategory(ruleId, (int)newCategoryId, true))
                        {
                            RuleCategory ruleCategory = new RuleCategory(null);

                            // Insert new rule category
                            ruleCategory.InsertDirect(ruleId, (int)newCategoryId, false, companyId);

                            // Delete old rule category
                            ruleCategory.DeleteDirect(ruleId, originalCategoryId, companyId);
                        }
                        else
                        {
                            RuleCategory ruleCategory = new RuleCategory(null);

                            // Undelete nee rule category
                            ruleCategory.UnDeleteDirect(ruleId, (int)newCategoryId, companyId);

                            // Delete old rule category                            
                            ruleCategory.DeleteDirect(ruleId, originalCategoryId, companyId);
                        }
                    }
                }
            }

            // Update units categories
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.Load(companyId);
            
            if (unitsGateway.Table.Rows.Count > 0)
            {
                foreach (UnitsTDS.LFS_FM_UNITRow row in (UnitsTDS.LFS_FM_UNITDataTable)unitsGateway.Table)
                {
                    int unitId = row.UnitID;
                    int companyLevelId = row.CompanyLevelID;

                    UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);
                    if ((unitsCategoryGateway.IsUsedInUnitCategory(unitId, originalCategoryId)) && (newCategoryId.HasValue) )
                    {
                        if (!unitsCategoryGateway.IsUsedInUnitCategory(unitId, (int)newCategoryId, true))
                        {
                            UnitsCategory unitsCategory = new UnitsCategory(null);

                            // Insert new unit category
                            unitsCategory.InsertDirect(unitId, (int)newCategoryId, false, companyId);

                            // Delete old unit category
                            unitsCategory.DeleteDirect(unitId, originalCategoryId, companyId);

                            // Delete all checklist for unitId
                            DeleteChecklists(unitId, companyId);

                            // Update checklist
                            UpdateUnitChecklists(unitId, row.CompanyLevelID, companyId);
                        }
                        else
                        {                            
                            UnitsCategory unitsCategory = new UnitsCategory(null);

                            // Undelete new category
                            unitsCategory.UnDeleteDirect(unitId, (int)newCategoryId, companyId);

                            // Delete old category
                            unitsCategory.DeleteDirect(unitId, originalCategoryId, companyId);

                            // Delete all checklist for unitId
                            DeleteChecklists(unitId, companyId);

                            // Update checklist
                            UpdateUnitChecklists(unitId, row.CompanyLevelID, companyId);
                        }
                    }
                }
            }                                  
        }



        /// <summary>
        /// DeleteChecklists
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteChecklists(int unitId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);

            if (checklistGateway.IsUnitUsedInChecklist(unitId))
            {
                // Delete checklist
                Checklist checklist = new Checklist(null);
                checklist.DeleteDirectByUnitId(unitId, companyId);
            }
        }



        /// <summary>
        /// UpdateUnitChecklists
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateUnitChecklists(int unitId, int companyLevelId, int companyId)
        {
            UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway();
            unitsCategoryGateway.LoadByUnitId(unitId, companyId);

            foreach (UnitsTDS.LFS_FM_UNIT_CATEGORYRow row in (UnitsTDS.LFS_FM_UNIT_CATEGORYDataTable)unitsCategoryGateway.Table)
            {
                int categoryId = row.CategoryID;

                RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway();
                ruleCategoryGateway.LoadByCategoryId(categoryId, companyId);

                foreach (RuleTDS.LFS_FM_RULE_CATEGORYRow rowRuleCategory in (RuleTDS.LFS_FM_RULE_CATEGORYDataTable)ruleCategoryGateway.Table)
                {
                    int ruleId = rowRuleCategory.RuleID;

                    RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);

                    if (ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(ruleId, companyLevelId))
                    {
                        ChecklistGateway checklistGateway = new ChecklistGateway(null);

                        if (checklistGateway.IsUsedInChecklist(unitId, ruleId, true))
                        {
                            Checklist checklist = new Checklist(null);
                            checklist.UnDeleteDirect(ruleId, unitId, companyId);
                        }
                        else
                        {
                            Checklist checklist = new Checklist(null);
                            checklist.InsertDirect(unitId, ruleId, null, null, false, "Unknown", false, companyId);
                        }
                    }
                }
            }
        }
             



    }
}

