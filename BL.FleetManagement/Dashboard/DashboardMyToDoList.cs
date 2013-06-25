using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardMyToDoList
    /// </summary>
    public class DashboardMyToDoList: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardMyToDoList()
            : base("DashboardMyToDoList")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardMyToDoList(DataSet data)
            : base(data, "DashboardMyToDoList")
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
        /// LoadMyCurrentToDoListByCreatedById
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyCurrentToDoListByCreatedByIdState(int createdById, string state, int companyId)
        {
            DashboardMyToDoListGateway dashboardMyToDoListGateway = new DashboardMyToDoListGateway(Data);

            if (state != "%")
            {
                dashboardMyToDoListGateway.LoadMyCurrentToDoListByCreatedByIdState(createdById, state, companyId);
            }
            else
            {
                dashboardMyToDoListGateway.Table.Clear();
                dashboardMyToDoListGateway.ClearBeforeFill = false;
                dashboardMyToDoListGateway.LoadMyCurrentToDoListByCreatedByIdState(createdById, "New", companyId);
                dashboardMyToDoListGateway.LoadMyCurrentToDoListByCreatedByIdState(createdById, "In Progress", companyId);
                dashboardMyToDoListGateway.LoadMyCurrentToDoListByCreatedByIdState(createdById, "Completed", companyId);                
                dashboardMyToDoListGateway.ClearBeforeFill = true;
            }
        }



        /// <summary>
        /// LoadMyCurrentToDoListByCreatedById
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyNewAndInProgressToDoListByCreated(int createdById, int companyId)
        {
            DashboardMyToDoListGateway dashboardMyToDoListGateway = new DashboardMyToDoListGateway(Data);
            dashboardMyToDoListGateway.Table.Clear();
            dashboardMyToDoListGateway.ClearBeforeFill = false;
            dashboardMyToDoListGateway.LoadMyCurrentToDoListByCreatedByIdState(createdById, "New", companyId);
            dashboardMyToDoListGateway.LoadMyCurrentToDoListByCreatedByIdState(createdById, "In Progress", companyId);
            dashboardMyToDoListGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadCurrentToDoList
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadCurrentToDoListByState(string state, int companyId)
        {
            DashboardMyToDoListGateway dashboardMyToDoListGateway = new DashboardMyToDoListGateway(Data);
            
            if (state != "%")
            {
                dashboardMyToDoListGateway.LoadCurrentToDoListByState(state, companyId);
            }
            else
            {
                dashboardMyToDoListGateway.Table.Clear();
                dashboardMyToDoListGateway.ClearBeforeFill = false;
                dashboardMyToDoListGateway.LoadCurrentToDoListByState("New", companyId);
                dashboardMyToDoListGateway.LoadCurrentToDoListByState("In Progress", companyId);
                dashboardMyToDoListGateway.LoadCurrentToDoListByState("Completed", companyId);                
                dashboardMyToDoListGateway.ClearBeforeFill = true;
            }
        }



        // <summary>
        /// LoadCurrentToDoList
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadNewAndInProgressToDoList(int companyId)
        {
            DashboardMyToDoListGateway dashboardMyToDoListGateway = new DashboardMyToDoListGateway(Data);
            dashboardMyToDoListGateway.Table.Clear();
            dashboardMyToDoListGateway.ClearBeforeFill = false;
            dashboardMyToDoListGateway.LoadCurrentToDoListByState("New", companyId);
            dashboardMyToDoListGateway.LoadCurrentToDoListByState("In Progress", companyId);
            dashboardMyToDoListGateway.ClearBeforeFill = true;
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>DashboardTDS.DashboardMyToDoListRow</returns>
        private DashboardTDS.DashboardMyToDoListRow GetRow(int toDoId)
        {
            DashboardTDS.DashboardMyToDoListRow row = ((DashboardTDS.DashboardMyToDoListDataTable)Table).FindByToDoID(toDoId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardMyToDoList.GetRow");
            }

            return row;
        }              



    }
}