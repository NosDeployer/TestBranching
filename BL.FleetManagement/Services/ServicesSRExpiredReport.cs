using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRExpiredReport
    /// </summary>
    public class ServicesSRExpiredReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRExpiredReport()
            : base("ExpiredServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesSRExpiredReport(DataSet data)
            : base(data, "ExpiredServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRExpiredReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadExpiredItems
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadExpiredItems(int companyId)
        {
            ServicesSRExpiredReportGateway servicesSRExpiredReportGateway = new ServicesSRExpiredReportGateway(Data);
            servicesSRExpiredReportGateway.LoadExpiredItems(companyId);
        }



        /// <summary>
        /// LoadExpiredItemsByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadExpiredItemsByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            ServicesSRExpiredReportGateway servicesSRExpiredReportGateway = new ServicesSRExpiredReportGateway(Data);
            servicesSRExpiredReportGateway.LoadExpiredItemsByAssignTeamMemberID(assignTeamMemberId, companyId);
        }


        
    }
}
