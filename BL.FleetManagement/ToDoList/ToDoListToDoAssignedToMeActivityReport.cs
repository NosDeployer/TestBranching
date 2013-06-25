using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoAssignedToMeActivityReport
    /// </summary>
    public class ToDoListToDoAssignedToMeActivityReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoAssignedToMeActivityReport()
            : base("ToDoListActivityToDoAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ToDoListToDoAssignedToMeActivityReport(DataSet data)
            : base(data, "ToDoListActivityToDoAssignedToMe")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ToDoListToDoAssignedToMeReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadToDoAssignedToMeActivityByToDoId
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="companyId">companyId</param>
        public void LoadToDoAssignedToMeActivityByToDoId(int toDoId, int companyId)
        {
            ToDoListToDoAssignedToMeActivityReportGateway toDoListToDoAssignedToMeActivityReportGateway = new ToDoListToDoAssignedToMeActivityReportGateway(Data);
            toDoListToDoAssignedToMeActivityReportGateway.ClearBeforeFill = false;
            toDoListToDoAssignedToMeActivityReportGateway.LoadToDoAssignedToMeActivityByToDoId(toDoId, companyId);
        }     



        /// <summary>
        /// UpdateForReport
        /// </summary>
        public void UpdateForReport()
        {
            foreach (ToDoListToDoAssignedToMeReportTDS.ToDoListActivityToDoAssignedToMeRow row in (ToDoListToDoAssignedToMeReportTDS.ToDoListActivityToDoAssignedToMeDataTable)Table)
            {
                string employee = "";
                if (row.Type_ == "AssignUser")
                {
                    employee = "Assigned User: " + row.EmployeeFullName;
                }
                else
                {
                    if (row.Type_ == "CloseToDo")
                    {
                        employee = "Closed by: " + row.EmployeeFullName;
                    }
                    else
                    {
                        if (row.Type_ == "AddComment")
                        {
                            employee = "Comment added by: " + row.EmployeeFullName;
                        }
                        else
                        {
                            employee = "On hold by: " + row.EmployeeFullName;
                        }
                    }
                }

                row.EmployeeFullName = employee;
            }
        }



    }
}