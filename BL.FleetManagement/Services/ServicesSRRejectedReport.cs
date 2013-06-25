using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRRejectedReport
    /// </summary>
    public class ServicesSRRejectedReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRRejectedReport()
            : base("RejectedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesSRRejectedReport(DataSet data)
            : base(data, "RejectedServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRRejectedReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadRejectedServices
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadRejectedServices(int companyId)
        {
            ServicesSRRejectedReportGateway servicesSRRejectedReportGateway = new ServicesSRRejectedReportGateway(Data);
            servicesSRRejectedReportGateway.LoadRejectedServices(companyId);
        }



    }
}

