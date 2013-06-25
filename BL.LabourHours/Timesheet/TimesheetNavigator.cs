using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;

namespace LiquiForce.LFSLive.BL.LabourHours.Timesheet
{
    /// <summary>
    /// TimesheetNavigator
    /// </summary>
    public class TimesheetNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TimesheetNavigator()
            : base("LFS_PROJECT_TIME")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TimesheetNavigator(DataSet data)
            : base(data, "LFS_PROJECT_TIME")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TimesheetNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Update project time
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="selected">selected</param>
        public void Update(int  projectTimeId, bool selected)
        {
            TimesheetNavigatorTDS.LFS_PROJECT_TIMERow row = GetRow(projectTimeId);
            row.Selected = selected;
        }



        /// <summary>
        /// GetTotalProjectTime
        /// </summary>
        public decimal GetTotalProjectTime()
        {
            decimal total = 0.00M;

            foreach (TimesheetNavigatorTDS.LFS_PROJECT_TIMERow row in (TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)Table)
            {
                if (!row.Deleted)
                {
                    total = total + decimal.Parse(row.ProjectTime.ToString());
                }
            }

            return total;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Row</returns>
        private TimesheetNavigatorTDS.LFS_PROJECT_TIMERow GetRow(int projectTimeId)
        {
            TimesheetNavigatorTDS.LFS_PROJECT_TIMERow row = ((TimesheetNavigatorTDS.LFS_PROJECT_TIMEDataTable)Table).FindByProjectTimeID(projectTimeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.Timesheet.TimesheetNavigator.GetRow");
            }

            return row;
        }



    }
}