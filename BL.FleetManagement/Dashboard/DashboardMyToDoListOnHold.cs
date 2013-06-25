using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardMyToDoListOnHold
    /// </summary>
    public class DashboardMyToDoListOnHold: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardMyToDoListOnHold()
            : base("DashboardMyToDoListOnHold")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardMyToDoListOnHold(DataSet data)
            : base(data, "DashboardMyToDoListOnHold")
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
        /// LoadMyCurrentToDoListOnHoldByCreatedById
        /// </summary>
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyCurrentToDoListOnHoldByCreatedById(int createdById, int companyId)
        {
            DashboardMyToDoListOnHoldGateway dashboardMyToDoListOnHoldGateway = new DashboardMyToDoListOnHoldGateway(Data);
            dashboardMyToDoListOnHoldGateway.Table.Clear();
            dashboardMyToDoListOnHoldGateway.ClearBeforeFill = false;
            dashboardMyToDoListOnHoldGateway.LoadMyCurrentToDoListOnHoldByCreatedById(createdById, companyId);
            dashboardMyToDoListOnHoldGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadCurrentToDoListOnHold
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadCurrentToDoListOnHold(int companyId)
        {
            DashboardMyToDoListOnHoldGateway dashboardMyToDoListOnHoldGateway = new DashboardMyToDoListOnHoldGateway(Data);
            dashboardMyToDoListOnHoldGateway.Table.Clear();
            dashboardMyToDoListOnHoldGateway.ClearBeforeFill = false;
            dashboardMyToDoListOnHoldGateway.LoadCurrentToDoListOnHold(companyId);
            dashboardMyToDoListOnHoldGateway.ClearBeforeFill = true;
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <returns>DashboardTDS.DashboardMyToDoListRow</returns>
        private DashboardTDS.DashboardMyToDoListOnHoldRow GetRow(int toDoId)
        {
            DashboardTDS.DashboardMyToDoListOnHoldRow row = ((DashboardTDS.DashboardMyToDoListOnHoldDataTable)Table).FindByToDoID(toDoId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardMyToDoListOnHold.GetRow");
            }

            return row;
        }              



    }
}