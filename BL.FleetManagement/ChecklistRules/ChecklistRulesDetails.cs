using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// ChecklistRulesDetails
    /// </summary>
    public class ChecklistRulesDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ChecklistRulesDetails()
            : base("ChecklistRulesDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ChecklistRulesDetails(DataSet data)
            : base(data, "ChecklistRulesDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RuleTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Save
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="mto">mto</param>
        /// <param name="frequency">frequency</param>
        /// <param name="alarm">alarm</param>
        /// <param name="alarmDays">alarmDays</param>
        /// <param name="serviceRequest">serviceRequest</param>
        /// <param name="serviceRequestDays">serviceRequestDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyLevelsSelected">companyLevelsSelected</param>
        /// <param name="unitsSelected">unitsSelected</param>
        public void Save(int ruleId, string name, string description, bool mto, string frequency, bool alarm, int? alarmDays, bool serviceRequest, int? serviceRequestDays, bool deleted, int companyId, ArrayList categoriesSelected, ArrayList companyLevelsSelected, ArrayList unitsSelected)
        {
            DeleteChecklists(ruleId, companyId);
            UpdateRule(ruleId, name, description, mto, frequency, alarm, alarmDays, serviceRequest, serviceRequestDays, deleted, companyId);
            UpdateRuleCategory(ruleId, companyId, categoriesSelected, companyLevelsSelected);
            UpdateRuleCategoryUnits(ruleId, companyId, categoriesSelected, companyLevelsSelected, unitsSelected);
            UpdateRuleCompanyLevel(ruleId, companyId, companyLevelsSelected);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int ruleId, int companyId)
        {
            DeleteRule(ruleId, companyId);
            DeleteRuleCategory(ruleId, companyId);
            DeleteRuleCompanyLevel(ruleId, companyId);
            DeleteChecklists(ruleId, companyId);
        }
        

        



        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //               
        
        /// <summary>
        /// DeleteRule
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteRule(int ruleId, int companyId)
        {
            LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(null);
            rule.DeleteDirect(ruleId, companyId);
        }



        /// <summary>
        /// DeleteRuleCategory
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteRuleCategory(int ruleId, int companyId)
        {
            // Delete RuleCategoryUnits
            RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(null);
            
            if (ruleCategoryUnitsGateway.IsRuleUsed(ruleId))
            {
                ruleCategoryUnits.DeleteDirectByRuleId(ruleId, companyId);
            }

            // Load all categories
            CategoryGateway categoryGateway = new CategoryGateway();
            categoryGateway.Load(companyId);

            // Delete rule categories
            if (categoryGateway.Table.Rows.Count > 0)
            {
                foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)categoryGateway.Table)
                {
                    int categoryId = row.CategoryID;
                    RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);                    
                    if (ruleCategoryGateway.IsUsedInRuleCategory(ruleId, categoryId))
                    {
                        RuleCategory ruleCategory = new RuleCategory(null);
                        ruleCategory.DeleteDirect(ruleId, categoryId, companyId);
                    }
                }
            }
        }



        /// <summary>
        /// DeleteRuleCompanyLevel
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteRuleCompanyLevel(int ruleId, int companyId)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
            companyLevelGateway.Load(companyId);

            if (companyLevelGateway.Table.Rows.Count > 0)
            {
                foreach (CompanyLevelsTDS.LFS_FM_COMPANYLEVELRow row in (CompanyLevelsTDS.LFS_FM_COMPANYLEVELDataTable)companyLevelGateway.Table)
                {
                    int companyLevelId = row.CompanyLevelID;

                    RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);

                    if (ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(ruleId, companyLevelId))
                    {
                        RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                        ruleCompanyLevel.DeleteDirect(ruleId, companyLevelId, companyId);                        
                    }
                }
            }
        }



        /// <summary>
        /// DeleteChecklists
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteChecklists(int ruleId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);

            if (checklistGateway.IsRuleUsedInChecklist(ruleId))
            {
                // Delete all checklists for ruleId
                Checklist checklist = new Checklist(null);
                checklist.DeleteDirectByRuleId(ruleId, companyId);
            }
        }



        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="mto">mto</param>
        /// <param name="frequency">frequency</param>
        /// <param name="alarm">alarm</param>
        /// <param name="alarmDays">alarmDays</param>
        /// <param name="serviceRequest">serviceRequest</param>
        /// <param name="serviceRequestDays">serviceRequestDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        private void UpdateRule(int ruleId, string name, string description, bool mto, string frequency, bool alarm, int? alarmDays, bool serviceRequest, int? serviceRequestDays, bool deleted, int companyId)
        {
            LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule rule = new LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.Rule(null);
            rule.UpdateDirect(ruleId, name, description, mto, frequency, alarm, alarmDays, serviceRequest, serviceRequestDays, false, companyId);
        }



        /// <summary>
        /// UpdateRuleCategoryUnits
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyLevelsSelected">companyLevelsSelected</param>
        /// <param name="unitsSelected">unitsSelected</param>
        private void UpdateRuleCategoryUnits(int ruleId, int companyId, ArrayList categoriesSelected, ArrayList companyLevelsSelected, ArrayList unitsSelected)
        {            
            // At each category
            CategoryGateway categoryGateway = new CategoryGateway();
            categoryGateway.Load(companyId);

            foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)categoryGateway.Table)
            {
                int categoryId = row.CategoryID;

                // At each unit
                UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway();
                unitsCategoryGateway.LoadByCategoryId(categoryId, companyId);

                foreach (UnitsTDS.LFS_FM_UNIT_CATEGORYRow rowUnitCategory in (UnitsTDS.LFS_FM_UNIT_CATEGORYDataTable)unitsCategoryGateway.Table)
                {
                    int unitId = rowUnitCategory.UnitID;

                    RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(null);

                    // If it already exists and it's not deleted
                    if (ruleCategoryUnitsGateway.IsUsedInRuleCategoryUnits(ruleId, categoryId, unitId))
                    {
                        // Verify if it's at the current selection
                        if ((!categoriesSelected.Contains(categoryId)) || (categoriesSelected.Contains(categoryId) && (!unitsSelected.Contains(unitId))))
                        {
                            // Delete
                            RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
                            ruleCategoryUnits.DeleteDirect(ruleId, categoryId, unitId, companyId);
                        }
                        else
                        {
                            RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
                            ruleCategoryUnits.UnDeleteDirect(ruleId, categoryId, unitId, companyId);

                            // Insert checklist
                            foreach (int companyLevelId in companyLevelsSelected)
                            {
                                UnitsGateway unitsGateway = new UnitsGateway(null);

                                if (unitsGateway.IsUsedInUnitsAndNotIsDisposed(unitId, companyLevelId))
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
                    else
                    {
                        // If it already exists and it's deleted
                        if (ruleCategoryUnitsGateway.IsUsedInRuleCategoryUnitsAsDeleted(ruleId, categoryId, unitId))
                        {
                            // Verify if it's at the current selection
                            if (categoriesSelected.Contains(categoryId) && (unitsSelected.Contains(unitId)))
                            {
                                // UnDelete
                                RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
                                ruleCategoryUnits.UnDeleteDirect(ruleId, categoryId, unitId, companyId);

                                // Insert checklist
                                foreach (int companyLevelId in companyLevelsSelected)
                                {
                                    UnitsGateway unitsGateway = new UnitsGateway(null);

                                    if (unitsGateway.IsUsedInUnitsAndNotIsDisposed(unitId, companyLevelId))
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
                        // If it's not at bd
                        else
                        { 
                            // Verify if it's at the current selection
                            if (categoriesSelected.Contains(categoryId) && (unitsSelected.Contains(unitId)))
                            {
                                // Insert rule category units
                                RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
                                ruleCategoryUnits.InsertDirect(ruleId, categoryId, unitId, false, companyId);                               

                                // Insert checklist
                                foreach (int companyLevelId in companyLevelsSelected)
                                {
                                    UnitsGateway unitsGateway = new UnitsGateway(null);

                                    if (unitsGateway.IsUsedInUnitsAndNotIsDisposed(unitId, companyLevelId))
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
            }
        }



        /// <summary>
        /// UpdateRuleCategory
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyLevelsSelected">companyLevelsSelected</param>
        private void UpdateRuleCategory(int ruleId, int companyId, ArrayList categoriesSelected, ArrayList companyLevelsSelected)
        {
            CategoryGateway categoryGateway = new CategoryGateway();
            categoryGateway.Load(companyId);

            foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)categoryGateway.Table)
            {
                int categoryId = row.CategoryID;

                RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);
                if (ruleCategoryGateway.IsUsedInRuleCategory(ruleId, categoryId, true))
                {
                    // Delete
                    if (!categoriesSelected.Contains(categoryId))
                    {
                        RuleCategory ruleCategory = new RuleCategory(null);
                        ruleCategory.DeleteDirect(ruleId, categoryId, companyId);                            
                    }
                    else // Undelete
                    {
                        RuleCategory ruleCategory = new RuleCategory(null);
                        ruleCategory.UnDeleteDirect(ruleId, categoryId, companyId);                        
                    }
                }
                else
                {
                    if (categoriesSelected.Contains(categoryId))
                    {
                        RuleCategory ruleCategory = new RuleCategory(null);
                        ruleCategory.InsertDirect(ruleId, categoryId, false, companyId);               
                    }
                }
            }            
        }


        
        /// <summary>
        /// UpdateRuleCompanyLevel
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelsSected">companyLevelsSected</param>
        private void UpdateRuleCompanyLevel(int ruleId, int companyId, ArrayList companyLevelsSelected)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
            companyLevelGateway.Load(companyId);

            if (companyLevelGateway.Table.Rows.Count > 0)
            {
                foreach (CompanyLevelsTDS.LFS_FM_COMPANYLEVELRow row in (CompanyLevelsTDS.LFS_FM_COMPANYLEVELDataTable)companyLevelGateway.Table)
                {
                    int companyLevelId = row.CompanyLevelID;

                    RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);

                    if (ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(ruleId, companyLevelId, true))
                    {
                        if (!companyLevelsSelected.Contains(companyLevelId))
                        {
                            RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                            ruleCompanyLevel.DeleteDirect(ruleId, companyLevelId, companyId);                            
                        }
                        else
                        {
                            RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                            ruleCompanyLevel.UnDeleteDirect(ruleId, companyLevelId, companyId);                            
                        }
                    }
                    else
                    {
                        if (companyLevelsSelected.Contains(companyLevelId))
                        {
                            RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                            ruleCompanyLevel.InsertDirect(ruleId, companyLevelId, false, companyId);                            
                        }
                    }
                }
            }
        }       



    }
}


