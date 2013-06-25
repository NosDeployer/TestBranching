using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.BL.Resources.Employees;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintUnnapprovedProjectTimes
    /// </summary>
    public class PrintUnnapprovedProjectTimes : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintUnnapprovedProjectTimes()
            : base("UnapprovedProjectTimes")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintUnnapprovedProjectTimes(DataSet data)
            : base(data, "UnapprovedProjectTimes")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintUnnapprovedProjectTimesTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS 
        //

        /// <summary>
        /// LoadByStartDateEndDateCountryId
        /// </summary>
        /// <para>Load Original to process data for report with filters  </para>
        /// <param name="startDate">Start date filter for report</param>
        /// <param name="endDate">End date filter for report</param>
        /// <param name="countryId">countryId</param>
        public void LoadByStartDateEndDateCountryId(DateTime startDate, DateTime endDate, Int64 countryId)
        {
            PrintUnnapprovedProjectTimesGateway printUnnapprovedProjectTimesGateway = new PrintUnnapprovedProjectTimesGateway(Data);
            printUnnapprovedProjectTimesGateway.LoadByStartDateEndDateCountryId(startDate, endDate, countryId);

            UpdateForReport();
        }

        

        /// <summary>
        /// LoadByStartDateEndDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        public void LoadByStartDateEndDate(DateTime startDate, DateTime endDate)
        {
            PrintUnnapprovedProjectTimesGateway printUnnapprovedProjectTimesGateway = new PrintUnnapprovedProjectTimesGateway(Data);
            printUnnapprovedProjectTimesGateway.LoadByStartDateEndDate(startDate, endDate);

            UpdateForReport();
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        private void UpdateForReport()
        {
            foreach (PrintUnnapprovedProjectTimesTDS.UnapprovedProjectTimesRow row in (PrintUnnapprovedProjectTimesTDS.UnapprovedProjectTimesDataTable)Table)
            {
                Employee employee = new Employee();

                string allCategoryManagers = employee.GetAllCategoryManagers(row.Category, row.EmployeeID);

                if (!String.IsNullOrEmpty(allCategoryManagers))
                {
                    row.Manager = allCategoryManagers;
                }
                else
                {
                    row.Manager = "";
                }
            }
        }



    }
}