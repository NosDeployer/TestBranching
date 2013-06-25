using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListMyToDoActivityReport
    /// </summary>
    public class ToDoListMyToDoActivityReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListMyToDoActivityReport()
            : base("ToDoListActivityMyToDo")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ToDoListMyToDoActivityReport(DataSet data)
            : base(data, "ToDoListActivityMyToDo")
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
        /// LoadMyToDoActivityByToDoId
        /// </summary>
        /// <param name="toDoId">toDoId</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyToDoActivityByToDoId(int toDoId, int companyId)
        {
            ToDoListMyToDoActivityReportGateway toDoListMyToDoActivityReportGateway = new ToDoListMyToDoActivityReportGateway(Data);
            toDoListMyToDoActivityReportGateway.ClearBeforeFill = false;
            toDoListMyToDoActivityReportGateway.LoadMyToDoActivityByToDoId(toDoId, companyId);
        }     



        /// <summary>
        /// UpdateForReport
        /// </summary>
        public void UpdateForReport()
        {
            foreach (ToDoListMyToDoReportTDS.ToDoListActivityMyToDoRow row in (ToDoListMyToDoReportTDS.ToDoListActivityMyToDoDataTable)Table)
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