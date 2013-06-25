using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardChecklistAlarms
    /// </summary>
    public class DashboardChecklistAlarms : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardChecklistAlarms()
            : base("DashboardChecklistAlarms")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardChecklistAlarms(DataSet data)
            : base(data, "DashboardChecklistAlarms")
        {
        }
                           


        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByAlarmPeriod
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAllByAlarmPeriod(int companyId)
        {
            DashboardChecklistAlarmsGateway dashboardChecklistAlarmsGateway = new DashboardChecklistAlarmsGateway(Data);
            dashboardChecklistAlarmsGateway.LoadAllByAlarmPeriod(companyId);
        }



        /// <summary>
        /// LoadAllByAlarmPeriodUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllByAlarmPeriodUnitType(int companyId, string unitType)
        {
            DashboardChecklistAlarmsGateway dashboardChecklistAlarmsGateway = new DashboardChecklistAlarmsGateway(Data);
            dashboardChecklistAlarmsGateway.LoadAllByAlarmPeriodUnitType(companyId, unitType);
        }



        /// <summary>
        /// LoadAllByAlarmPeriodCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllByAlarmPeriodCompanyLevelId(int companyId, int companyLevelId)
        {
            DashboardChecklistAlarmsGateway dashboardChecklistAlarmsGateway = new DashboardChecklistAlarmsGateway(Data);
            dashboardChecklistAlarmsGateway.LoadAllByAlarmPeriodCompanyLevelId(companyId, companyLevelId);
        }



        /// <summary>
        /// LoadAllByAlarmPeriodCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllByAlarmPeriodCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            DashboardChecklistAlarmsGateway dashboardChecklistAlarmsGateway = new DashboardChecklistAlarmsGateway(Data);
            dashboardChecklistAlarmsGateway.LoadAllByAlarmPeriodCompanyLevelIdUnitType(companyId, companyLevelId, unitType);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(int unitId, int ruleId, int companyId, bool selected)
        {
            DashboardTDS.DashboardChecklistAlarmsRow row = GetRow(unitId, ruleId);
            row.Selected = selected;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <returns>DashboardTDS.DashboardChecklistAlarmsRow</returns>
        private DashboardTDS.DashboardChecklistAlarmsRow GetRow(int unitId, int ruleId)
        {
            DashboardTDS.DashboardChecklistAlarmsRow row = ((DashboardTDS.DashboardChecklistAlarmsDataTable)Table).FindByUnitIDRuleID(unitId, ruleId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardChecklistAlarms.GetRow");
            }

            return row;
        }



    }
}