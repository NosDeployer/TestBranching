using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitWithAlarmsReport
    /// </summary>
    public class UnitWithAlarmsReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitWithAlarmsReport()
            : base("UnitWithAlarmsReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitWithAlarmsReport(DataSet data)
            : base(data, "UnitWithAlarmsReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitWithAlarmsReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            UnitWithAlarmsReportGateway unitWithAlarmsReportGateway = new UnitWithAlarmsReportGateway(Data);
            unitWithAlarmsReportGateway.Load(companyId);
        }    



    }
}