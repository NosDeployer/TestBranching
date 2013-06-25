using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlM2LateralReport
    /// </summary>
    public class FlM2LateralReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM2LateralReport()
            : base("M2_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlM2LateralReport(DataSet data)
            : base(data, "M2_LATERAL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM2ReportTDS();
        }



    }
}