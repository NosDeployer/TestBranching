using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationReport
    /// </summary>
    public class UnitInformationReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitInformationReport()
            : base("UnitInformationReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitInformationReport(DataSet data)
            : base(data, "UnitInformationReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationReportTDS();
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
            UnitInformationReportGateway unitInformationReportGateway = new UnitInformationReportGateway(Data);
            unitInformationReportGateway.Load(companyId);            
        }



        /// <summary>
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByUnitId(int unitId, int companyId)
        {
            UnitInformationReportGateway unitInformationReportGateway = new UnitInformationReportGateway(Data);
            unitInformationReportGateway.LoadByUnitId(unitId, companyId);            
        }



        /// <summary>
        /// LoadByUnitType
        /// </summary>
        /// <param name="unitType">unitType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByUnitType(string unitType, int companyId)
        {
            UnitInformationReportGateway unitInformationReportGateway = new UnitInformationReportGateway(Data);
            unitInformationReportGateway.LoadByUnitType(unitType, companyId);
        }

        
                
    }
}