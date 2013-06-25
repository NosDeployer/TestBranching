using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRUnassignedReport
    /// </summary>
    public class ServicesSRUnassignedReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRUnassignedReport()
            : base("UnassignedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesSRUnassignedReport(DataSet data)
            : base(data, "UnassignedServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRUnassignedReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByUnassignedServices
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadUnassignedServices(int companyId)
        {
            ServicesSRUnassignedReportGateway servicesSRUnassignedReportGateway = new ServicesSRUnassignedReportGateway(Data);
            servicesSRUnassignedReportGateway.LoadUnassignedServices(companyId);
        }



    }
}

