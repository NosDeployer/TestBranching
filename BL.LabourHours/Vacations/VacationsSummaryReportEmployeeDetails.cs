using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsSummaryReportEmployeeDetails
    /// </summary>
    public class VacationsSummaryReportEmployeeDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsSummaryReportEmployeeDetails()
            : base("EmployeeDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsSummaryReportEmployeeDetails(DataSet data)
            : base(data, "EmployeeDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsSummaryReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByYear
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="companyId">companyId</param>
        public void LoadByYear(int year, int companyId)
        {
            VacationsSummaryReportEmployeeDetailsGateway vacationsSummaryReportEmployeeDetailsGateway = new VacationsSummaryReportEmployeeDetailsGateway(Data);
            vacationsSummaryReportEmployeeDetailsGateway.LoadByYear(year, companyId);

            UpdateForReport(companyId);
        }

        

        /// <summary>
        /// LoadByYearEmployeeId
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByYearEmployeeId(int year, int employeeId, int companyId)
        {
            VacationsSummaryReportEmployeeDetailsGateway vacationsSummaryReportEmployeeDetailsGateway = new VacationsSummaryReportEmployeeDetailsGateway(Data);
            vacationsSummaryReportEmployeeDetailsGateway.LoadByYearEmployeeId(year, employeeId, companyId);

            UpdateForReport(companyId);
        }



        /// <summary>
        /// LoadByYearEmployeeType
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="location">location</param>
        /// <param name="companyId">companyId</param>
        public void LoadByYearEmployeeType(int year, string location, int companyId)
        {
            VacationsSummaryReportEmployeeDetailsGateway vacationsSummaryReportEmployeeDetailsGateway = new VacationsSummaryReportEmployeeDetailsGateway(Data);
            vacationsSummaryReportEmployeeDetailsGateway.LoadByYearEmployeeType(year, location, companyId);

            UpdateForReport(companyId);
        }



        /// <summary>
        /// LoadByYearEmployeeTypeEmployeeId
        /// </summary>
        /// <param name="year">year</param>
        /// <param name="location">location</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByYearEmployeeTypeEmployeeId(int year, string location, int employeeId, int companyId)
        {
            VacationsSummaryReportEmployeeDetailsGateway vacationsSummaryReportEmployeeDetailsGateway = new VacationsSummaryReportEmployeeDetailsGateway(Data);
            vacationsSummaryReportEmployeeDetailsGateway.LoadByYearEmployeeTypeEmployeeId(year, location, employeeId, companyId);

            UpdateForReport(companyId);
        }
               




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="companyId"></param>
        private void UpdateForReport(int companyId)
        {
            VacationsSummaryReportVacationDetailsGateway vacationsSummaryReportVacationDetailsGateway = new VacationsSummaryReportVacationDetailsGateway(Data);
            vacationsSummaryReportVacationDetailsGateway.ClearBeforeFill = false;

            VacationsSummaryReportVacationDetails vacationsSummaryReportVacationDetails = new VacationsSummaryReportVacationDetails(Data);

            foreach (VacationsSummaryReportTDS.EmployeeDetailsRow row in (VacationsSummaryReportTDS.EmployeeDetailsDataTable)Table)
            {
                DateTime startDate = new DateTime(row.Year, 1, 1);
                DateTime endDate = new DateTime(row.Year, 12, 31);

                // Load vacation details
                vacationsSummaryReportVacationDetailsGateway.LoadByEmployeeIdStartDateEndDate(row.EmployeeID, startDate, endDate, companyId);

                foreach (VacationsSummaryReportTDS.VacationDetailsRow row2 in (VacationsSummaryReportTDS.VacationDetailsDataTable)vacationsSummaryReportVacationDetailsGateway.Table)
                {
                    int requestId = row2.RequestID;
                    string vacationDetail = "";

                    VacationsInformationDaysInformation vacationsInformationDaysInformation = new VacationsInformationDaysInformation();
                    vacationsInformationDaysInformation.LoadByRequestId(requestId, companyId);

                    foreach (VacationsInformationTDS.DaysInformationRow row3 in (VacationsInformationTDS.DaysInformationDataTable)vacationsInformationDaysInformation.Table)
                    {
                        if (row3.StartDate.Year == row.Year)
                        {
                            switch (row3.PaymentType)
                            {
                                case "Full Vacation Day":
                                    vacationDetail += row3.StartDate.ToString("MMM/dd") + " Full Vacation Day, ";
                                    break;

                                case "Half Vacation Day":
                                    vacationDetail += row3.StartDate.ToString("MMM/dd") + " Half Vacation Day, ";
                                    break;

                                case "Unpaid Leave Full Day":
                                    vacationDetail += row3.StartDate.ToString("MMM/dd") + " Unpaid Leave Full Day, ";
                                    break;

                                case "Unpaid Leave Half Day":
                                    vacationDetail += row3.StartDate.ToString("MMM/dd") + " Unpaid Leave Half Day, ";
                                    break;
                            }
                        }
                    }

                    vacationDetail = vacationDetail.Remove(vacationDetail.Length - 2, 2);

                    row2.Details = vacationDetail;
                }

                // Update for location
                if (row.EmployeeType.Contains("CA"))
                {
                    row.EmployeeType = "Canada";
                }
                else
                {
                    row.EmployeeType = "USA";
                }
            }
        }



    }
}