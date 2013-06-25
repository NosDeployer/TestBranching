using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.Dashboard
{
    /// <summary>
    /// DashboardMySupportTicketOnHold
    /// </summary>
    public class DashboardMySupportTicketOnHold : TableModule
    {
// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardMySupportTicketOnHold()
            : base("DashboardMySupportTicketOnHold")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardMySupportTicketOnHold(DataSet data)
            : base(data, "DashboardMySupportTicketOnHold")
        {
        }
                           


        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadMyCurrentSupportTicketOnHoldByCreatedById
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyCurrentSupportTicketOnHoldByCreatedById(int createdById, int companyId)
        {
            DashboardMySupportTicketOnHoldGateway dashboardMySupportTicketOnHoldGateway = new DashboardMySupportTicketOnHoldGateway(Data);
            dashboardMySupportTicketOnHoldGateway.Table.Clear();
            dashboardMySupportTicketOnHoldGateway.ClearBeforeFill = false;
            dashboardMySupportTicketOnHoldGateway.LoadMyCurrentSupportTicketOnHoldByCreatedById(createdById, companyId);
            dashboardMySupportTicketOnHoldGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadCurrentSupportTicketOnHold
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadCurrentSupportTicketOnHold(int companyId)
        {
            DashboardMySupportTicketOnHoldGateway dashboardMySupportTicketOnHoldGateway = new DashboardMySupportTicketOnHoldGateway(Data);
            dashboardMySupportTicketOnHoldGateway.Table.Clear();
            dashboardMySupportTicketOnHoldGateway.ClearBeforeFill = false;
            dashboardMySupportTicketOnHoldGateway.LoadCurrentSupportTicketOnHold(companyId);
            dashboardMySupportTicketOnHoldGateway.ClearBeforeFill = true;
        }



    }
}