using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using System.Collections;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels
{
    /// <summary>
    /// CompanyLevelsAddNew
    /// </summary>
    public class CompanyLevelsAddNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyLevelsAddNew()
            : base("CompanyLevelsAddNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompanyLevelsAddNew(DataSet data)
            : base(data, "CompanyLevelsAddNew")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CompanyLevelsAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="newCompanyLevelID">newCompanyLevelID</param>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="unitsUnitOfMeasurement">unitsUnitOfMeasurement</param>
        public void Insert(int? companyLevelId, int? newCompanyLevelID, string name, int? parentId, bool deleted, int companyId, bool inDatabase, string unitsUnitOfMeasurement)
        {
            CompanyLevelsAddTDS.CompanyLevelsAddNewRow row = ((CompanyLevelsAddTDS.CompanyLevelsAddNewDataTable)Table).NewCompanyLevelsAddNewRow();

            if (companyLevelId.HasValue) row.CompanyLevelID = (int)companyLevelId; else row.CompanyLevelID = GetNewCompanyLevelId();
            if (newCompanyLevelID.HasValue) row.NewCompanyLevelID = (int)newCompanyLevelID; else row.SetNewCompanyLevelIDNull();
            row.Name = name;
            if (parentId.HasValue) row.ParentID = (int)parentId; else row.SetParentIDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.UnitsUnitOfMeasurement = unitsUnitOfMeasurement;

            ((CompanyLevelsAddTDS.CompanyLevelsAddNewDataTable)Table).AddCompanyLevelsAddNewRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <returns>newCompanyLevelIdForInsert</returns>
        public int Save()
        {
            int companyLevelIdForManagers = 0 ;

            foreach (CompanyLevelsAddTDS.CompanyLevelsAddNewRow row in (CompanyLevelsAddTDS.CompanyLevelsAddNewDataTable)Data.Tables["CompanyLevelsAddNew"])
            {
                // Insert CompanyLevel
                if ((!row.Deleted) && (!row.InDatabase))
                {
                    int? parentId = null; if (!row.IsParentIDNull()) parentId = row.ParentID;
                    string unitsUnitOfMeasurement = ""; if (!row.IsUnitsUnitOfMeasurementNull()) unitsUnitOfMeasurement = row.UnitsUnitOfMeasurement;
                    companyLevelIdForManagers = InsertCompanyLevel(row.Name, parentId, row.Deleted, row.COMPANY_ID, unitsUnitOfMeasurement);
                }

                // Update CompanyLevel
                if ((!row.Deleted) && (row.InDatabase))
                {
                    int companyId = row.COMPANY_ID;
                    CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
                    companyLevelGateway.LoadByCompanyLevelId(row.CompanyLevelID, companyId);

                    int companyLevelId = row.CompanyLevelID;
                    companyLevelIdForManagers = row.CompanyLevelID;
                    string originalName = companyLevelGateway.GetName(companyLevelId);
                    int? originalParentId = null; if (companyLevelGateway.GetParentId(companyLevelId).HasValue) originalParentId = (int)companyLevelGateway.GetParentId(companyLevelId);
                    bool originalDeleted = companyLevelGateway.GetDeleted(companyLevelId);

                    UpdateCompanyLevel(companyLevelId, originalName, originalParentId, originalDeleted, companyId, row.UnitsUnitOfMeasurement, companyLevelId, row.Name, originalParentId, row.Deleted, companyId, row.UnitsUnitOfMeasurement);
                }

                // Delete CompanyLevel
                if ((row.Deleted) && (row.InDatabase))
                {
                    int companyLevelId = row.CompanyLevelID;
                    companyLevelIdForManagers = row.CompanyLevelID;
                    int? newCompanyLevelId = null; if (!row.IsNewCompanyLevelIDNull()) newCompanyLevelId = row.NewCompanyLevelID;
                    int companyId = row.COMPANY_ID;

                    UpdateUnitsAndRulesCompanyLevels(companyLevelId, newCompanyLevelId, companyId);
                    DeleteCompanyLevel(companyLevelId, companyId);
                }
            }

            return companyLevelIdForManagers;
        }



        /// <summary>
        /// CompanyLevelIsUsed
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True or False</returns>
        public bool CompanyLevelIsUsed(int companyLevelId, int companyId)
        {
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.Load(companyId);
            
            LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.RuleGateway ruleGateway = new RuleGateway();
            ruleGateway.Load(companyId);

            bool inUse = false;

            foreach (UnitsTDS.LFS_FM_UNITRow row in (UnitsTDS.LFS_FM_UNITDataTable)unitsGateway.Table)
            {
                int unitId = row.UnitID;

                if (companyLevelId == row.CompanyLevelID)
                {
                    inUse = true;
                }
            }                      

            foreach (RuleTDS.LFS_FM_RULERow row in (RuleTDS.LFS_FM_RULEDataTable)ruleGateway.Table)
            {
                int ruleId = row.RuleID;

                RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);
                if (ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(ruleId, companyLevelId))
                {
                    inUse = true;
                }                
            }

            return inUse;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single company level. If not exists, raise an exception
        /// </summary>
        /// <param name="companyLevelId">internal companyLevelId</param>
        /// <returns>Row</returns>
        private CompanyLevelsAddTDS.CompanyLevelsAddNewRow GetRow(int companyLevelId)
        {
            CompanyLevelsAddTDS.CompanyLevelsAddNewRow row = ((CompanyLevelsAddTDS.CompanyLevelsAddNewDataTable)Table).FindByCompanyLevelID(companyLevelId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels.CompanyLevelsAddNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>CompanyLevelID</returns>
        private int GetNewCompanyLevelId()
        {
            int newId = 0;

            foreach (CompanyLevelsAddTDS.CompanyLevelsAddNewRow row in (CompanyLevelsAddTDS.CompanyLevelsAddNewDataTable)Table)
            {
                if (newId < row.CompanyLevelID)
                {
                    newId = row.CompanyLevelID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// InsertCompanyLevel
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitsUnitOfMeasurement">unitUnitOfMeasurement</param>
        /// <returns>companyLevelId</returns>
        private int InsertCompanyLevel(string name, int? parentId, bool deleted, int companyId, string unitsUnitOfMeasurement)
        {
            CompanyLevel companyLevel = new CompanyLevel(null);
            int companyLevelId = companyLevel.InsertDirect(name, parentId, deleted, companyId, unitsUnitOfMeasurement);

            return companyLevelId;
        }



        /// <summary>
        /// UpdateCompanyLevel
        /// </summary>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalUnitsUnitOfMeasurement">originalUnitsUnitOfMeasurement</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newUnitsUnitOfMeasurement">newUnitsUnitOfMeasurement</param>
        private void UpdateCompanyLevel(int originalCompanyLevelId, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, string originalUnitsUnitOfMeasurement, int newCompanyLevelId, string newName, int? newParentId, bool newDeleted, int newCompanyId, string newUnitsUnitOfMeasurement)
        {
            CompanyLevel companyLevel = new CompanyLevel(null);
            companyLevel.UpdateDirect(originalCompanyLevelId, originalName, originalParentId, originalDeleted, originalCompanyId, originalUnitsUnitOfMeasurement, newCompanyLevelId, newName, newParentId, newDeleted, newCompanyId, newUnitsUnitOfMeasurement);
        }



        /// <summary>
        /// DeleteCompanyLevel
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        private void DeleteCompanyLevel(int companyLevelId, int companyId)
        {
            CompanyLevel companyLevel = new CompanyLevel(null);
            companyLevel.DeletedDirect(companyLevelId, companyId);
        }



        /// <summary>
        /// UpdateUnitsAndRulesCompanyLevels
        /// </summary>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateUnitsAndRulesCompanyLevels(int originalCompanyLevelId, int? newCompanyLevelId, int companyId)
        {
            // Update units
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.Load(companyId);

            if (unitsGateway.Table.Rows.Count > 0)
            {
                foreach (UnitsTDS.LFS_FM_UNITRow row in (UnitsTDS.LFS_FM_UNITDataTable)unitsGateway.Table)
                {
                    int unitId = row.UnitID;

                    if (originalCompanyLevelId == row.CompanyLevelID)
                    {
                        if (newCompanyLevelId.HasValue)
                        {
                            UnitsGateway unitsGatewayToUpdate = new UnitsGateway(null);
                            unitsGatewayToUpdate.UpdateCompanyLevel(row.UnitID, row.Deleted, row.COMPANY_ID, (int)newCompanyLevelId);
                        }
                    }
                }
            }

            // Update rules company levels
            LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules.RuleGateway ruleGateway = new RuleGateway();
            ruleGateway.Load(companyId);

            if (ruleGateway.Table.Rows.Count > 0)
            {
                foreach (RuleTDS.LFS_FM_RULERow row in (RuleTDS.LFS_FM_RULEDataTable)ruleGateway.Table)
                {
                    int ruleId = row.RuleID;

                    RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);
                    if ((ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(ruleId, originalCompanyLevelId)) && (newCompanyLevelId.HasValue))
                    {
                        if (!ruleCompanyLevelGateway.IsUsedInRuleCompanyLevel(ruleId, (int)newCompanyLevelId))
                        {
                            RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                            ruleCompanyLevel.InsertDirect(ruleId, (int)newCompanyLevelId, false, companyId);
                            ruleCompanyLevel.DeleteDirect(ruleId, originalCompanyLevelId, companyId);
                        }
                        else
                        {
                            RuleCompanyLevel ruleCompanyLevel = new RuleCompanyLevel(null);
                            ruleCompanyLevel.DeleteDirect(ruleId, originalCompanyLevelId, companyId);
                        }
                    }
                }
            }                        
        }



    }
}


