using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitChecklistsReportChecklistDetails
    /// </summary>
    public class UnitChecklistsReportChecklistDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitChecklistsReportChecklistDetails()
            : base("UnitChecklistsReportChecklistDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitChecklistsReportChecklistDetails(DataSet data)
            : base(data, "UnitChecklistsReportChecklistDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitChecklistsReportTDS();
        }



    }
}