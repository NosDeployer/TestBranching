using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using System.Collections;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// ChecklistRulesAddNew
    /// </summary>
    public class ChecklistRulesAddNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ChecklistRulesAddNew()
            : base("ChecklistRulesAddNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ChecklistRulesAddNew(DataSet data)
            : base(data, "ChecklistRulesAddNew")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ChecklistRulesAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
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
        public void Insert(string name, string description, bool mto, string frequency, bool alarm, int? alarmDays, bool serviceRequest, int? serviceRequestDays, bool deleted, int companyId)
        {
            ChecklistRulesAddTDS.ChecklistRulesAddNewRow row = ((ChecklistRulesAddTDS.ChecklistRulesAddNewDataTable)Table).NewChecklistRulesAddNewRow();

            row.RuleID = GetNewId();
            row.Name = name;
            if (description.Trim() != "") row.Description = description; else row.SetDescriptionNull();
            row.MTO = mto;
            row.Frequency = frequency;
            row.Alarm = alarm;
            if (alarmDays.HasValue) row.AlarmDays = (int)alarmDays; else row.SetAlarmDaysNull();
            row.ServiceRequest = serviceRequest;
            if (serviceRequestDays.HasValue) row.ServiceRequestDays = (int)serviceRequestDays; else row.SetServiceRequestDaysNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;

            ((ChecklistRulesAddTDS.ChecklistRulesAddNewDataTable)Table).AddChecklistRulesAddNewRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="companyLevelsSelected">companyLevelsSelected</param>
        /// <param name="unitsSelected">unitsSelected</param>
        public void Save(ArrayList categoriesSelected, ArrayList companyLevelsSelected, ArrayList unitsSelected)
        {
            ChecklistRulesAddTDS checklistRulesAddChanges = (ChecklistRulesAddTDS)Data.GetChanges();

            if (checklistRulesAddChanges.ChecklistRulesAddNew.Rows.Count > 0)
            {
                foreach (ChecklistRulesAddTDS.ChecklistRulesAddNewRow row in (ChecklistRulesAddTDS.ChecklistRulesAddNewDataTable)checklistRulesAddChanges.ChecklistRulesAddNew)
                {
                    string name = row.Name;
                    string description = ""; if (!row.IsDescriptionNull()) description = row.Description;
                    bool mto = row.MTO;
                    string frequency = row.Frequency;
                    bool alarm = row.Alarm;
                    int? alarmDays = null; if (!row.IsAlarmDaysNull()) alarmDays = row.AlarmDays;
                    bool serviceRequest = row.ServiceRequest;
                    int? serviceRequestDays = null; if (!row.IsServiceRequestDaysNull()) serviceRequestDays = row.ServiceRequestDays;
                    bool deleted = row.Deleted;
                    int companyId = row.COMPANY_ID;                   

                    Rule rule = new Rule(null);
                    int ruleId = rule.InsertDirect(name, description, mto, frequency, alarm, alarmDays, serviceRequest, serviceRequestDays, deleted, companyId);

                    UpdateRuleCategory(ruleId, companyId, companyLevelsSelected, categoriesSelected, unitsSelected);
                    UpdateRuleCompanyLevel(ruleId, companyId, companyLevelsSelected);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single rule. If not exists, raise an exception
        /// </summary>
        /// <param name="unitId">internal ruleID</param>
        /// <returns>Row</returns>
        private ChecklistRulesAddTDS.ChecklistRulesAddNewRow GetRow(int ruleId)
        {
            ChecklistRulesAddTDS.ChecklistRulesAddNewRow row = ((ChecklistRulesAddTDS.ChecklistRulesAddNewDataTable)Table).FindByRuleID(ruleId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.ChecklistRulesAddNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>UnitID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (ChecklistRulesAddTDS.ChecklistRulesAddNewRow row in (ChecklistRulesAddTDS.ChecklistRulesAddNewDataTable)Table)
            {
                if (newId < row.RuleID)
                {
                    newId = row.RuleID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// UpdateRuleCategory
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelsSelected">companyLevelsSelected</param>
        /// <param name="categoriesSelected">categoriesSelected</param>
        /// <param name="unitsSelected">unitsSelected</param>
        private void UpdateRuleCategory(int ruleId, int companyId, ArrayList companyLevelsSelected, ArrayList categoriesSelected, ArrayList unitsSelected)
        {
            // Insert into checklist only selected units
            foreach (int categoryId in categoriesSelected)
            {
                RuleCategory ruleCategory = new RuleCategory(null);
                ruleCategory.InsertDirect(ruleId, categoryId, false, companyId);

                foreach (int unitId in unitsSelected)
                {
                    //int unitId = row.UnitID;

                    // Save categories and selected units
                    UnitsCategoryGateway unitsCategoryGatewayExist = new UnitsCategoryGateway(null);
                    if (unitsCategoryGatewayExist.IsUsedInUnitCategory(unitId, categoryId, false))
                    {                  
                        RuleCategoryUnits ruleCategoryUnits = new RuleCategoryUnits(null);
                        ruleCategoryUnits.InsertDirect(ruleId, categoryId, unitId, false, companyId);     
                    }

                    // Save Chechklists for selected units
                    foreach (int companyLevelId in companyLevelsSelected)
                    {
                        UnitsGateway unitsGateway = new UnitsGateway(null);

                        if (unitsGateway.IsUsedInUnitsAndNotIsDisposed(unitId, companyLevelId))
                        {
                            ChecklistGateway checklistGateway = new ChecklistGateway(null);
                            if (!checklistGateway.IsUsedInChecklist(unitId, ruleId))
                            {
                                Checklist checklist = new Checklist(null);
                                checklist.InsertDirect(unitId, ruleId, null, null, false, "Unknown", false, companyId);
                            }
                        }
                    }
                }                
            }
        }



        /// <summary>
        /// UpdateRuleCompanyLevel
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelsSelected">companyLevelsSelected</param>
        private void UpdateRuleCompanyLevel(int ruleId, int companyId, ArrayList companyLevelsSelected)
        {
            // Insert CompanyLevels selected
            foreach (int companyLevelId in companyLevelsSelected)
            {
                RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                ruleCompanyLevel.InsertDirect(ruleId, companyLevelId, false, companyId);                
            }
        }



    }
}