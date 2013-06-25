using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;

namespace LiquiForce.LFSLive.BL.LabourHours.Timesheet
{
    /// <summary>
    /// Timesheet
    /// </summary>
    public class Timesheet : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Timesheet()
            : base("LFS_TIMESHEET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Timesheet(DataSet data)
            : base(data, "LFS_TIMESHEET")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TimesheetTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        public void SetForApproval(int employeeId, int payPeriodId)
        {
            // Insert or update a timesheet
            // ... Search timesheet
            TimesheetTDS.LFS_TIMESHEETRow timesheetRow = null;
            if (Table.Rows.Count > 0)
            {
                TimesheetGateway timesheetGateway = new TimesheetGateway(Data);
                timesheetRow = (TimesheetTDS.LFS_TIMESHEETRow)timesheetGateway.GetRowByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            }

            // ... If timesheet not exists
            bool newRow = false;
            if (timesheetRow == null)
            {
                newRow = true;
                timesheetRow = ((TimesheetTDS.LFS_TIMESHEETDataTable)Table).NewLFS_TIMESHEETRow();
            }

            // ... Update timesheet's data
            timesheetRow.EmployeeID = employeeId;
            timesheetRow.PayPeriodID = payPeriodId;
            timesheetRow.State = "For Approval";
            timesheetRow.Deleted = false;
            if (newRow)
            {
                ((TimesheetTDS.LFS_TIMESHEETDataTable)Table).AddLFS_TIMESHEETRow(timesheetRow);
            }
        }



        /// <summary>
        /// Submit
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        public void Submit(int employeeId, int payPeriodId)
        {
            // Insert or update a timesheet
            // ... Search timesheet
            TimesheetTDS.LFS_TIMESHEETRow timesheetRow = null;
            if (Table.Rows.Count > 0)
            {
                TimesheetGateway timesheetGateway = new TimesheetGateway(Data);
                timesheetRow = (TimesheetTDS.LFS_TIMESHEETRow)timesheetGateway.GetRowByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            }

            // ... If timesheet not exists
            bool newRow = false;
            if (timesheetRow == null)
            {
                newRow = true;
                timesheetRow = ((TimesheetTDS.LFS_TIMESHEETDataTable)Table).NewLFS_TIMESHEETRow();
            }

            // ... Update timesheet's data
            timesheetRow.EmployeeID = employeeId;
            timesheetRow.PayPeriodID = payPeriodId;
            timesheetRow.State = "Submitted";
            timesheetRow.Deleted = false;
            if (newRow)
            {
                ((TimesheetTDS.LFS_TIMESHEETDataTable)Table).AddLFS_TIMESHEETRow(timesheetRow);
            }

            // Update timesheet's project time
            ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(Data);
            projectTimeGateway.LoadByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            foreach (TimesheetTDS.LFS_PROJECT_TIMERow projectTimeRow in (TimesheetTDS.LFS_PROJECT_TIMEDataTable) projectTimeGateway.Table)
            {
                projectTimeRow.ProjectTimeState = "Submitted";
            }
        }



        /// <summary>
        /// Approve
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <param name="approvedById">approvedById</param>
        public void Approve(int employeeId, int payPeriodId, int approvedById)
        {
            // Update timesheet's data
            TimesheetGateway timesheetGateway = new TimesheetGateway(Data);
            TimesheetTDS.LFS_TIMESHEETRow timesheetRow = (TimesheetTDS.LFS_TIMESHEETRow)timesheetGateway.GetRowByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            timesheetRow.State = "Approved";
            
            // Update timesheet's project time
            ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(Data);
            projectTimeGateway.LoadByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            foreach (TimesheetTDS.LFS_PROJECT_TIMERow projectTimeRow in (TimesheetTDS.LFS_PROJECT_TIMEDataTable)projectTimeGateway.Table)
            {
                projectTimeRow.ProjectTimeState = "Approved";
                projectTimeRow.ApprovedByID = approvedById;
            }
        }



        /// <summary>
        /// Reject
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="payPeriodId">payPeriodId</param>
        public void Reject(int employeeId, int payPeriodId)
        {
            // Update timesheet's data
            TimesheetGateway timesheetGateway = new TimesheetGateway(Data);
            TimesheetTDS.LFS_TIMESHEETRow timesheetRow = (TimesheetTDS.LFS_TIMESHEETRow)timesheetGateway.GetRowByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            timesheetRow.State = "Rejected";

            // Update timesheet's project time
            ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway(Data);
            projectTimeGateway.LoadByEmployeeIdPayPeriodId(employeeId, payPeriodId);
            foreach (TimesheetTDS.LFS_PROJECT_TIMERow projectTimeRow in (TimesheetTDS.LFS_PROJECT_TIMEDataTable)projectTimeGateway.Table)
            {
                projectTimeRow.ProjectTimeState = "Rejected";
            }
        }



    }
}