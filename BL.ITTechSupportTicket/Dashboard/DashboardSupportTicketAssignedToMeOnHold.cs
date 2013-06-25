using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.Dashboard
{
    /// <summary>
    /// DashboardSupportTicketAssignedToMeOnHold
    /// </summary>
    public class DashboardSupportTicketAssignedToMeOnHold : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardSupportTicketAssignedToMeOnHold()
            : base("DashboardSupportTicketAssignedToMeOnHold")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardSupportTicketAssignedToMeOnHold(DataSet data)
            : base(data, "DashboardSupportTicketAssignedToMeOnHold")
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
        /// LoadSupportTicketAssignedToMeOnHoldByEmployeeId
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadSupportTicketAssignedToMeOnHoldByEmployeeId(int createdById, int companyId)
        {
            DashboardSupportTicketAssignedToMeOnHoldGateway dashboardSupportTicketAssignedToMeOnHoldGateway = new DashboardSupportTicketAssignedToMeOnHoldGateway(Data);
            dashboardSupportTicketAssignedToMeOnHoldGateway.Table.Clear();
            dashboardSupportTicketAssignedToMeOnHoldGateway.ClearBeforeFill = false;
            dashboardSupportTicketAssignedToMeOnHoldGateway.LoadSupportTicketAssignedToMeOnHoldByEmployeeId(createdById, companyId);
            dashboardSupportTicketAssignedToMeOnHoldGateway.ClearBeforeFill = true;

            UpdateForDashboard(companyId);
        }




        /// <summary>
        /// UpdateForDashboard
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldRow row in (DashboardTDS.DashboardSupportTicketAssignedToMeOnHoldDataTable)Table)
            {
                int supportTicketId = row.SupportTicketID;

                SupportTicketInformationActivityInformation supportTicketInformationActivityInformation = new SupportTicketInformationActivityInformation();
                supportTicketInformationActivityInformation.LoadAllBySupportTicketId(supportTicketId, companyId);

                int lastRefId = supportTicketInformationActivityInformation.GetLastAssignedUserRefId();

                if (row.RefID != lastRefId)
                {
                    row.Delete();
                }
            }
        }
        


    }
}