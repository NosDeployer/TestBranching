using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationChecklistDetails
    /// </summary>
    public class UnitInformationChecklistDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationChecklistDetails()
            : base("ChecklistDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationChecklistDetails(DataSet data)
            : base(data, "ChecklistDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByUnitIdWithoutInProgressRules
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByUnitIdWithoutInProgressRules(int unitId, int companyId)
        {
            UnitInformationChecklistDetailsGateway unitInformationChecklistDetailsGateway = new UnitInformationChecklistDetailsGateway(Data);
            unitInformationChecklistDetailsGateway.LoadByUnitIdWithoutInProgressRules(unitId, companyId);            
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Load(int unitId, int companyId)
        {
            UnitInformationChecklistDetailsGateway unitInformationChecklistDetailsGateway = new UnitInformationChecklistDetailsGateway(Data);
            unitInformationChecklistDetailsGateway.LoadByUnitId(unitId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="lastService">lastService</param>
        /// <param name="nextDue">nextDue</param>
        /// <param name="state">state</param>
        /// <param name="done">done</param>
        public void Update(int ruleId, DateTime? lastService, DateTime? nextDue, string state, bool done)
        {
            UnitInformationTDS.ChecklistDetailsRow row = GetRow(ruleId);

            if (lastService.HasValue) row.LastService = (DateTime)lastService; else row.SetLastServiceNull();
            if (nextDue.HasValue) row.NextDue = (DateTime)nextDue; else row.SetNextDueNull();
            if (state != "") row.State = state;
            row.Done = done;            
        }



        /// <summary>
        /// Delete
        /// </summary>
        public void Delete(int ruleId)
        {
            UnitInformationTDS.ChecklistDetailsRow row = GetRow(ruleId);
            row.Deleted = true;            
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        public void DeleteAll()
        {
            foreach (UnitInformationTDS.ChecklistDetailsRow row in (UnitInformationTDS.ChecklistDetailsDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int unitId, int companyId)
        {
            UnitInformationChecklistDetailsGateway unitInformationChecklistDetailsGateway = new UnitInformationChecklistDetailsGateway(Data);

            foreach (UnitInformationTDS.ChecklistDetailsRow row in (UnitInformationTDS.ChecklistDetailsDataTable)Data.Tables["ChecklistDetails"])
            {
                if (!row.Deleted)
                {
                    // Unchanged values
                    int ruleId = row.RuleID;
                    bool deleted = false;

                    // Original values
                    DateTime? originalLastService = null; if (unitInformationChecklistDetailsGateway.GetLastServiceOriginal(ruleId).HasValue) originalLastService = (DateTime)unitInformationChecklistDetailsGateway.GetLastServiceOriginal(ruleId);
                    DateTime? originalNextDue = null; if (unitInformationChecklistDetailsGateway.GetNextDueOriginal(ruleId).HasValue) originalNextDue = (DateTime)unitInformationChecklistDetailsGateway.GetNextDueOriginal(ruleId);
                    bool originalDone = unitInformationChecklistDetailsGateway.GetDoneOriginal(ruleId);
                    string originalState = unitInformationChecklistDetailsGateway.GetStateOriginal(ruleId);

                    // New values
                    DateTime? newLastService = null; if (unitInformationChecklistDetailsGateway.GetLastService(ruleId).HasValue) newLastService = (DateTime)unitInformationChecklistDetailsGateway.GetLastService(ruleId);
                    DateTime? newNextDue = null; if (unitInformationChecklistDetailsGateway.GetNextDue(ruleId).HasValue) newNextDue = (DateTime)unitInformationChecklistDetailsGateway.GetNextDue(ruleId);
                    bool newDone = unitInformationChecklistDetailsGateway.GetDone(ruleId);
                    string newState = unitInformationChecklistDetailsGateway.GetState(ruleId);

                    if (row.Frequency != "Only once")
                    {
                        if (newLastService.HasValue)
                        {
                            // Get next due
                            DateTime timeToAdded = new DateTime(((DateTime)newLastService).Year, ((DateTime)newLastService).Month, ((DateTime)newLastService).Day);

                            if (row.Frequency == "Monthly") newNextDue = timeToAdded.AddMonths(1);
                            if (row.Frequency == "Every 2 months") newNextDue = timeToAdded.AddMonths(2);
                            if (row.Frequency == "Every 3 months") newNextDue = timeToAdded.AddMonths(3);
                            if (row.Frequency == "Every 4 months") newNextDue = timeToAdded.AddMonths(4);
                            if (row.Frequency == "Every 6 months") newNextDue = timeToAdded.AddMonths(6);
                            if (row.Frequency == "Yearly") newNextDue = timeToAdded.AddYears(1);
                        }
                    }

                    // Update
                    Checklist checklist = new Checklist(null);
                    checklist.UpdateDirect(unitId, ruleId, originalLastService, originalNextDue, originalDone, originalState, deleted, companyId, unitId, ruleId, newLastService, newNextDue, newDone, newState, deleted, companyId);
                }
                else
                {
                    int ruleId = row.RuleID;
                    Checklist checklist = new Checklist(null);
                    checklist.DeleteDirect(ruleId, unitId, companyId);
                }
            }            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>Row</returns>
        private UnitInformationTDS.ChecklistDetailsRow GetRow(int ruleId)
        {
            UnitInformationTDS.ChecklistDetailsRow row = ((UnitInformationTDS.ChecklistDetailsDataTable)Table).FindByRuleID(ruleId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Units.UnitInformationChecklistDetails.GetRow");
            }

            return row;
        }      
               
        

    }
}

