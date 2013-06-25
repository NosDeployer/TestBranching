using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.Dashboard
{
    /// <summary>
    /// DashboardMySupportTicket
    /// </summary>
    public class DashboardMySupportTicket : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardMySupportTicket()
            : base("DashboardMySupportTicket")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardMySupportTicket(DataSet data)
            : base(data, "DashboardMySupportTicket")
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
        /// LoadMyCurrentSupportTicketByCreatedById
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyCurrentSupportTicketByCreatedByIdState(int createdById, string state, int companyId)
        {
            DashboardMySupportTicketGateway dashboardMySupportTicketGateway = new DashboardMySupportTicketGateway(Data);

            if (state != "%")
            {
                dashboardMySupportTicketGateway.LoadMyCurrentSupportTicketByCreatedByIdState(createdById, state, companyId);
            }
            else
            {
                dashboardMySupportTicketGateway.Table.Clear();
                dashboardMySupportTicketGateway.ClearBeforeFill = false;
                dashboardMySupportTicketGateway.LoadMyCurrentSupportTicketByCreatedByIdState(createdById, "New", companyId);
                dashboardMySupportTicketGateway.LoadMyCurrentSupportTicketByCreatedByIdState(createdById, "In Progress", companyId);
                dashboardMySupportTicketGateway.LoadMyCurrentSupportTicketByCreatedByIdState(createdById, "Completed", companyId);                
                dashboardMySupportTicketGateway.ClearBeforeFill = true;
            }
        }



        /// <summary>
        /// LoadMyCurrentSupportTicketByCreatedById
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyNewAndInProgressSupportTicketByCreated(int createdById, int companyId)
        {
            DashboardMySupportTicketGateway dashboardMySupportTicketGateway = new DashboardMySupportTicketGateway(Data);
            dashboardMySupportTicketGateway.Table.Clear();
            dashboardMySupportTicketGateway.ClearBeforeFill = false;
            dashboardMySupportTicketGateway.LoadMyCurrentSupportTicketByCreatedByIdState(createdById, "New", companyId);
            dashboardMySupportTicketGateway.LoadMyCurrentSupportTicketByCreatedByIdState(createdById, "In Progress", companyId);
            dashboardMySupportTicketGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadCurrentSupportTicket
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadCurrentSupportTicketByState(string state, int companyId)
        {
            DashboardMySupportTicketGateway dashboardMySupportTicketGateway = new DashboardMySupportTicketGateway(Data);
            
            if (state != "%")
            {
                dashboardMySupportTicketGateway.LoadCurrentSupportTicketByState(state, companyId);
            }
            else
            {
                dashboardMySupportTicketGateway.Table.Clear();
                dashboardMySupportTicketGateway.ClearBeforeFill = false;
                dashboardMySupportTicketGateway.LoadCurrentSupportTicketByState("New", companyId);
                dashboardMySupportTicketGateway.LoadCurrentSupportTicketByState("In Progress", companyId);
                dashboardMySupportTicketGateway.LoadCurrentSupportTicketByState("Completed", companyId);                
                dashboardMySupportTicketGateway.ClearBeforeFill = true;
            }
        }



        // <summary>
        /// LoadCurrentSupportTicket
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadNewAndInProgressSupportTicket(int companyId)
        {
            DashboardMySupportTicketGateway dashboardMySupportTicketGateway = new DashboardMySupportTicketGateway(Data);
            dashboardMySupportTicketGateway.Table.Clear();
            dashboardMySupportTicketGateway.ClearBeforeFill = false;
            dashboardMySupportTicketGateway.LoadCurrentSupportTicketByState("New", companyId);
            dashboardMySupportTicketGateway.LoadCurrentSupportTicketByState("In Progress", companyId);
            dashboardMySupportTicketGateway.ClearBeforeFill = true;
        }



    }
}