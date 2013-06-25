using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// wucSRUnassignedUnassignedReport
    /// </summary>
    public class WucSRUnassignedUnassignedReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WucSRUnassignedUnassignedReport()
            : base("UnassignedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WucSRUnassignedUnassignedReport(DataSet data)
            : base(data, "UnassignedServiceRequests")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WucSRUnassignedUnassignedReportTDS();
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
            WucSRUnassignedUnassignedReportGateway wucSRUnassignedReportGateway = new WucSRUnassignedUnassignedReportGateway(Data);
            wucSRUnassignedReportGateway.LoadUnassignedServices(companyId);
        }



    }
}