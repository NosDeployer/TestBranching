using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardToDoListAssignedToMe
    /// </summary>
    public class DashboardToDoListAssignedToMe: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardToDoListAssignedToMe()
            : base("DashboardToDoListAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardToDoListAssignedToMe(DataSet data)
            : base(data, "DashboardToDoListAssignedToMe")
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
        /// LoadCurrentToDoListAssignedToMeByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadCurrentToDoListAssignedToMeByEmployeeId(int employeeId, int companyId)
        {
            DashboardToDoListAssignedToMeGateway dashboardToDoListAssignedToMeGateway = new DashboardToDoListAssignedToMeGateway(Data);
            dashboardToDoListAssignedToMeGateway.Table.Clear();
            dashboardToDoListAssignedToMeGateway.ClearBeforeFill = false;
            dashboardToDoListAssignedToMeGateway.LoadCurrentToDoListAssignedToMeByEmployeeId(employeeId, companyId);            
            dashboardToDoListAssignedToMeGateway.ClearBeforeFill = true;
            UpdateForDashboard(companyId);
        }


        
        /// <summary>
        /// UpdateForDashboard
        /// </summary>        
        /// <param name="companyId">companyId</param>
        private void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardToDoListAssignedToMeRow row in (DashboardTDS.DashboardToDoListAssignedToMeDataTable)Table)
            {
                int toDoId = row.ToDoID;

                ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation();
                toDoListInformationActivityInformation.LoadAllByToDoId(toDoId, companyId);

                int lastRefId = toDoListInformationActivityInformation.GetLastAssignedUserRefId();

                if (row.RefID != lastRefId)
                {
                    row.Delete();
                }
            }
        }



    }
}