using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitChecklistsReportUnitDetails
    /// </summary>
    public class UnitChecklistsReportUnitDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitChecklistsReportUnitDetails()
            : base("UnitChecklistsReportUnitDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitChecklistsReportUnitDetails(DataSet data)
            : base(data, "UnitChecklistsReportUnitDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitChecklistsReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>       
        /// <param name="mtoDotRules">mtoDotRules</param>
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        public void LoadByUnitId(int unitId, string mtoDotRules, string frequency, string state, int companyId)
        {
            UnitChecklistsReportUnitDetailsGateway unitChecklistsReportUnitDetailsGateway = new UnitChecklistsReportUnitDetailsGateway(Data);
            unitChecklistsReportUnitDetailsGateway.LoadByUnitId(unitId, companyId);

            UpdateForReport(mtoDotRules, frequency, state, true);
        }



        /// <summary>
        /// Load
        /// </summary>             
        /// <param name="mtoDotRules">mtoDotRules</param>
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <param name="allUnits">allUnits</param>
        public void Load(string mtoDotRules, string frequency, string state, int companyId, bool allUnits)
        {
            UnitChecklistsReportUnitDetailsGateway unitChecklistsReportUnitDetailsGateway = new UnitChecklistsReportUnitDetailsGateway(Data);
            unitChecklistsReportUnitDetailsGateway.Load(companyId);

            UpdateForReport(mtoDotRules, frequency, state, allUnits);
        }



        /// <summary>
        /// LoadByWorkingLocation
        /// </summary>
        /// <param name="workingLocation">workingLocation</param>        
        /// <param name="mtoDotRules">mtoDotRules</param>
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <param name="allUnits">allUnits</param>
        public void LoadByWorkingLocation(string workingLocation, string mtoDotRules, string frequency, string state, int companyId, bool allUnits)
        {
            UnitChecklistsReportUnitDetailsGateway unitChecklistsReportUnitDetailsGateway = new UnitChecklistsReportUnitDetailsGateway(Data);
            unitChecklistsReportUnitDetailsGateway.LoadByWorkingLocation(workingLocation, companyId);

            UpdateForReport(mtoDotRules, frequency, state, allUnits);
        }



        /// <summary>
        /// LoadByUnitType
        /// </summary>
        /// <param name="unitType">unitType</param>        
        /// <param name="state">state</param>
        /// <param name="mtoDotRules">mtoDotRules</param>   
        /// <param name="frequency">frequency</param>
        /// <param name="companyId">companyId</param>
        /// <param name="allUnits">allUnits</param>
        public void LoadByUnitType(string unitType, string mtoDotRules, string frequency, string state, int companyId, bool allUnits)
        {
            UnitChecklistsReportUnitDetailsGateway unitChecklistsReportUnitDetailsGateway = new UnitChecklistsReportUnitDetailsGateway(Data);
            unitChecklistsReportUnitDetailsGateway.LoadByUnitType(unitType, companyId);

            UpdateForReport(mtoDotRules, frequency, state, allUnits);
        }



        /// <summary>
        /// LoadByUnitTypeWorkingLocation
        /// </summary>
        /// <param name="unitType">unitType</param>        
        /// <param name="workingLocation">workingLocation</param>
        /// <param name="mtoDotRules">mtoDotRules</param>   
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>
        /// <param name="companyId">companyId</param>
        /// <param name="allUnits">allUnits</param>
        public void LoadByUnitTypeWorkingLocation(string unitType, string workingLocation, string mtoDotRules, string frequency, string state, int companyId, bool allUnits)
        {
            UnitChecklistsReportUnitDetailsGateway unitChecklistsReportUnitDetailsGateway = new UnitChecklistsReportUnitDetailsGateway(Data);
            unitChecklistsReportUnitDetailsGateway.LoadByUnitTypeWorkingLocation(unitType, workingLocation, companyId);

            UpdateForReport(mtoDotRules, frequency, state, allUnits);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="mtoDotRules">mtoDotRules</param>
        /// <param name="frequency">frequency</param>
        /// <param name="state">state</param>
        /// <param name="allUnits">allUnits</param>
        private void UpdateForReport(string mtoDotRules, string frequency, string state, bool allUnits)
        {
            UnitChecklistsReportChecklistDetailsGateway unitChecklistsReportChecklistDetailsGateway = new UnitChecklistsReportChecklistDetailsGateway(Data);
            unitChecklistsReportChecklistDetailsGateway.ClearBeforeFill = false;
            UnitChecklistsReportChecklistDetails unitChecklistsReportChecklistDetails = new UnitChecklistsReportChecklistDetails(Data);

            foreach (UnitChecklistsReportTDS.UnitChecklistsReportUnitDetailsRow row in (UnitChecklistsReportTDS.UnitChecklistsReportUnitDetailsDataTable)Table)
            {
                ChecklistGateway  checklistGateway = new ChecklistGateway();

                // Not show units witho no rules
                if ((!allUnits) && (!checklistGateway.IsUnitUsedInChecklist(row.UnitID)))
                {
                    row.Delete();
                }
                else
                {
                    // Load data for all units
                    if (mtoDotRules == "All")
                    {
                        if (frequency == "(All)")
                        {
                            if (state == "All")
                            {
                                // ... Load All
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitId(row.UnitID, row.COMPANY_ID);
                            }
                            else
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdState(row.UnitID, state, row.COMPANY_ID);
                            }
                        }
                        else
                        {
                            if (state == "All")
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdFrequency(row.UnitID, frequency, row.COMPANY_ID);
                            }
                            else
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdFrequencyState(row.UnitID, frequency, state, row.COMPANY_ID);
                            }
                        }
                    }
                    else
                    {
                        if (frequency == "(All)")
                        {
                            if (state == "All")
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdMtoDotRules(row.UnitID, mtoDotRules, row.COMPANY_ID);
                            }
                            else
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdMtoDotRulesState(row.UnitID, mtoDotRules, state, row.COMPANY_ID);
                            }
                        }
                        else
                        {
                            if (state == "All")
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdMtoDotRulesFrequency(row.UnitID, mtoDotRules, frequency, row.COMPANY_ID);
                            }
                            else
                            {
                                unitChecklistsReportChecklistDetailsGateway.LoadByUnitIdMtoDotRulesFrequencyState(row.UnitID, mtoDotRules, frequency, state, row.COMPANY_ID);
                            }
                        }
                    }
                }

            }
        }

    }
}