using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;

namespace LiquiForce.LFSLive.BL.FleetManagement.ToDoList
{
    /// <summary>
    /// ToDoListToDoAssignedToMeReport
    /// </summary>
    public class ToDoListToDoAssignedToMeReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ToDoListToDoAssignedToMeReport()
            : base("ToDoListToDoAssignedToMe")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ToDoListToDoAssignedToMeReport(DataSet data)
            : base(data, "ToDoListToDoAssignedToMe")
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
        /// LoadToDoAssignedToMeByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadToDoAssignedToMeByEmployeeId(int employeeId, int companyId)
        {
            ToDoListToDoAssignedToMeReportGateway toDoListToDoAssignedToMeReportGateway = new ToDoListToDoAssignedToMeReportGateway(Data);
            toDoListToDoAssignedToMeReportGateway.LoadToDoAssignedToMeByEmployeeId(employeeId, companyId);

            UpdateForReport(companyId);
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // ToDoListIVATE METHODS
        //

        /// <summary>
        /// UpdateForToDoListocess
        /// </summary>
        /// <param name="companyId">companyId</param>
        private void UpdateForReport(int companyId)
        {
            // Delete extra rows
            foreach (ToDoListToDoAssignedToMeReportTDS.ToDoListToDoAssignedToMeRow row in (ToDoListToDoAssignedToMeReportTDS.ToDoListToDoAssignedToMeDataTable)Table)
            {
                int toDoId = row.ToDoID;
                ToDoListInformationActivityInformation toDoListInformationActivityInformation = new ToDoListInformationActivityInformation();
                toDoListInformationActivityInformation.LoadAllByToDoId(toDoId, companyId);
                int lastRefId = toDoListInformationActivityInformation.GetLastAssignedUserRefId();

                if (row.RefID != lastRefId)
                {
                    row.Deleted = true;
                }
            }

            // Update text for report
            ToDoListToDoAssignedToMeActivityReport toDoListToDoAssignedToMeActivityReport = new ToDoListToDoAssignedToMeActivityReport(Data);

            foreach (ToDoListToDoAssignedToMeReportTDS.ToDoListToDoAssignedToMeRow row in (ToDoListToDoAssignedToMeReportTDS.ToDoListToDoAssignedToMeDataTable)Table)
            {
                if (!row.Deleted)
                {
                    toDoListToDoAssignedToMeActivityReport.LoadToDoAssignedToMeActivityByToDoId(row.ToDoID, row.COMPANY_ID);
                }
            }

            toDoListToDoAssignedToMeActivityReport.UpdateForReport();
            
            // Delete extra rows
            foreach (ToDoListToDoAssignedToMeReportTDS.ToDoListToDoAssignedToMeRow row in (ToDoListToDoAssignedToMeReportTDS.ToDoListToDoAssignedToMeDataTable)Table)
            {
                if (row.Deleted)
                {
                    row.Delete();
                }
            }
         }

    }
}