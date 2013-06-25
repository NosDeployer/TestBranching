using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.Dashboard
{
    /// <summary>
    /// DashboardSupportTicketAssignedToMe
    /// </summary>
    public class DashboardSupportTicketAssignedToMe : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardSupportTicketAssignedToMe()
            : base("DashboardSupportTicketAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardSupportTicketAssignedToMe(DataSet data)
            : base(data, "DashboardSupportTicketAssignedToMe")
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
        /// LoadCurrentSupportTicketAssignedToMeByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadCurrentSupportTicketAssignedToMeByEmployeeId(int employeeId, int companyId)
        {
            DashboardSupportTicketAssignedToMeGateway dashboardSupportTicketAssignedToMeGateway = new DashboardSupportTicketAssignedToMeGateway(Data);
            dashboardSupportTicketAssignedToMeGateway.Table.Clear();
            dashboardSupportTicketAssignedToMeGateway.ClearBeforeFill = false;
            dashboardSupportTicketAssignedToMeGateway.LoadCurrentSupportTicketAssignedToMeByEmployeeId(employeeId, companyId);            
            dashboardSupportTicketAssignedToMeGateway.ClearBeforeFill = true;

            UpdateForDashboard(companyId);
        }


        
        /// <summary>
        /// UpdateForDashboard
        /// </summary>        
        /// <param name="companyId">companyId</param>
        private void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardSupportTicketAssignedToMeRow row in (DashboardTDS.DashboardSupportTicketAssignedToMeDataTable)Table)
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