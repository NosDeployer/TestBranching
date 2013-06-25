using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;

namespace LiquiForce.LFSLive.BL.LabourHours.Timesheet
{
    /// <summary>
    /// TimesheetWaiting
    /// </summary>
    public class TimesheetWaiting : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TimesheetWaiting()
            : base("TimesheetWaiting")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TimesheetWaiting(DataSet data)
            : base(data, "TimesheetWaiting")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TimesheetWaitingTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        /// <summary>
        /// Update project time
        /// </summary>
        /// <param name="timesheetId">timesheetId</param>
        /// <param name="selected">selected</param>
        public void Update(int timesheetId, bool selected)
        {
            TimesheetWaitingTDS.TimesheetWaitingRow row = GetRow(timesheetId);
            row.Selected = selected;
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="timesheetId">timesheetId</param>
        /// <returns>Row</returns>
        private TimesheetWaitingTDS.TimesheetWaitingRow GetRow(int timesheetId)
        {
            TimesheetWaitingTDS.TimesheetWaitingRow row = ((TimesheetWaitingTDS.TimesheetWaitingDataTable)Table).FindByTimesheetID(timesheetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Timesheet.TimesheetWaiting.GetRow");
            }

            return row;
        }
    }
}
