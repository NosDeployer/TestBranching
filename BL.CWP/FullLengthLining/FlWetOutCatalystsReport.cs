using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.Works;
using System.Collections;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlWetOutCatalystsReport
    /// </summary>
    public class FlWetOutCatalystsReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlWetOutCatalystsReport()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlWetOutCatalystsReport(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlWetOutReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="workId">workId</param>
        public void LoadByWorkId(int companyId, int workId)
        {
            FlWetOutCatalystsReportGateway flWetOutCatalystsReportGateway = new FlWetOutCatalystsReportGateway(Data);
            flWetOutCatalystsReportGateway.LoadByWorkId(companyId, workId);            
        }
    }
}
