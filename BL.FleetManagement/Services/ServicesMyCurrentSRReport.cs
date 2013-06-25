using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServicesMyCurrentSRReport
    /// </summary>
    public class ServicesMyCurrentSRReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesMyCurrentSRReport()
            : base("MyCurrrentServiceRequest")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesMyCurrentSRReport(DataSet data)
            : base(data, "MyCurrrentServiceRequest")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesMyCurrentSRReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadMyCurrentSRByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyCurrentSRByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            ServicesMyCurrentSRReportGateway servicesMyCurrentSRReportGateway = new ServicesMyCurrentSRReportGateway(Data);

            servicesMyCurrentSRReportGateway.ClearBeforeFill = false;
            servicesMyCurrentSRReportGateway.LoadMyServicesByStateAssignTeamMemberID("Assigned", assignTeamMemberId, companyId);
            servicesMyCurrentSRReportGateway.LoadMyServicesByStateAssignTeamMemberID("Accepted", assignTeamMemberId, companyId);
            servicesMyCurrentSRReportGateway.LoadMyServicesByStateAssignTeamMemberID("In Progress", assignTeamMemberId, companyId);
            servicesMyCurrentSRReportGateway.ClearBeforeFill = true;
        }


        
    }
}

