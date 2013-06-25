using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListOverviewReport
    /// </summary>
    public class ToDoListMyToDoReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListMyToDoReport()
            : base("ToDoListMyToDo")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ToDoListMyToDoReport(DataSet data)
            : base(data, "ToDoListMyToDo")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListMyToDoReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadMyToDoByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyToDoByEmployeeId(int employeeId, int companyId)
        {
            ToDoListMyToDoReportGateway toDoListMyToDoReportGateway = new ToDoListMyToDoReportGateway(Data);
            toDoListMyToDoReportGateway.LoadMyToDoByEmployeeId(employeeId, companyId);

            UpdateForReport();
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // ToDoListIVATE METHODS
        //

        /// <summary>
        /// UpdateForToDoListocess
        /// </summary>
        private void UpdateForReport()
        {
            ToDoListMyToDoActivityReport toDoListMyToDoActivityReport = new ToDoListMyToDoActivityReport(Data);

            foreach (ToDoListMyToDoReportTDS.ToDoListMyToDoRow row in (ToDoListMyToDoReportTDS.ToDoListMyToDoDataTable)Table)
            {
                toDoListMyToDoActivityReport.LoadMyToDoActivityByToDoId(row.ToDoID, row.COMPANY_ID);
            }

            toDoListMyToDoActivityReport.UpdateForReport();
        }



    }
}