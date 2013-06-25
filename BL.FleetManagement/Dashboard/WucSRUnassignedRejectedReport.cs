using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// WucSRUnassignedRejectedReport
    /// </summary>
    public class WucSRUnassignedRejectedReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WucSRUnassignedRejectedReport()
            : base("RejectedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WucSRUnassignedRejectedReport(DataSet data)
            : base(data, "RejectedServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WucSRUnassignedRejectedReportTDS();
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
            WucSRUnassignedRejectedReportGateway wucSRUnassignedRejectedReportGateway = new WucSRUnassignedRejectedReportGateway(Data);
            wucSRUnassignedRejectedReportGateway.LoadRejectedServices(companyId);
        }



    }
}