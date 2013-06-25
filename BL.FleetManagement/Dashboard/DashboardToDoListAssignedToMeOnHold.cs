using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardToDoListAssignedToMeOnHold
    /// </summary>
    public class DashboardToDoListAssignedToMeOnHold: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardToDoListAssignedToMeOnHold()
            : base("DashboardToDoListAssignedToMeOnHold")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardToDoListAssignedToMeOnHold(DataSet data)
            : base(data, "DashboardToDoListAssignedToMeOnHold")
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
        /// LoadToDoListAssignedToMeOnHoldByEmployeeId
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadToDoListAssignedToMeOnHoldByEmployeeId(int createdById, int companyId)
        {
            DashboardToDoListAssignedToMeOnHoldGateway dashboardToDoListAssignedToMeOnHoldGateway = new DashboardToDoListAssignedToMeOnHoldGateway(Data);
            dashboardToDoListAssignedToMeOnHoldGateway.Table.Clear();
            dashboardToDoListAssignedToMeOnHoldGateway.ClearBeforeFill = false;
            dashboardToDoListAssignedToMeOnHoldGateway.LoadToDoListAssignedToMeOnHoldByEmployeeId(createdById, companyId);
            dashboardToDoListAssignedToMeOnHoldGateway.ClearBeforeFill = true;
            UpdateForDashboard(companyId);
        }




        /// <summary>
        /// UpdateForDashboard
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardToDoListAssignedToMeOnHoldRow row in (DashboardTDS.DashboardToDoListAssignedToMeOnHoldDataTable)Table)
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