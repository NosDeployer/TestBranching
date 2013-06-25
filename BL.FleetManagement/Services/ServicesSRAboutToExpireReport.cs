using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;


namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesSRAboutToExpireReport
    /// </summary>
    public class ServicesSRAboutToExpireReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesSRAboutToExpireReport()
            : base("AboutToExpireServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesSRAboutToExpireReport(DataSet data)
            : base(data, "AboutToExpireServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesSRAboutToExpireReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadItemsAboutToExpire
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>
        public void LoadItemsAboutToExpire(string period, int companyId)
        {
            ServicesSRAboutToExpireReportGateway servicesSRAboutToExpireReportGateway = new ServicesSRAboutToExpireReportGateway(Data);
            servicesSRAboutToExpireReportGateway.LoadItemsAboutToExpire(period, companyId);
        }



        /// <summary>
        /// LoadItemsAboutToExpireByAssignTeamMemberID
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadItemsAboutToExpireByAssignTeamMemberID(string period, int assignTeamMemberId, int companyId)
        {
            ServicesSRAboutToExpireReportGateway servicesSRAboutToExpireReportGateway = new ServicesSRAboutToExpireReportGateway(Data);
            servicesSRAboutToExpireReportGateway.LoadItemsAboutToExpireByAssignTeamMemberID(period, assignTeamMemberId, companyId);
        }




    }
}

