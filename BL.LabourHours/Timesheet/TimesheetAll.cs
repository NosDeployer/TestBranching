using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;

namespace LiquiForce.LFSLive.BL.LabourHours.Timesheet
{
    /// <summary>
    /// TimesheetAll
    /// </summary>
    public class TimesheetAll : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TimesheetAll()
            : base("TIMESHEET_ALL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TimesheetAll(DataSet data)
            : base(data, "TIMESHEET_ALL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TimesheetAllTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <param name="selected">selected</param>
        public void Update(int payPeriodId, bool selected)
        {
            TimesheetAllTDS.TIMESHEET_ALLRow row = GetRow(payPeriodId);
            row.Selected = selected;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="payPeriodId">payPeriodId</param>
        /// <returns>Row</returns>
        private TimesheetAllTDS.TIMESHEET_ALLRow GetRow(int payPeriodId)
        {
            TimesheetAllTDS.TIMESHEET_ALLRow row = ((TimesheetAllTDS.TIMESHEET_ALLDataTable)Table).FindByPayPeriodID(payPeriodId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Timesheet.TimesheetAll.GetRow");
            }

            return row;
        }
    }
}
