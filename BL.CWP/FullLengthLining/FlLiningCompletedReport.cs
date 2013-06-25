using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlLiningCompletedReport
    /// </summary>
    public class FlLiningCompletedReport : TableModule
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public FlLiningCompletedReport()
            : base("LiningCompleted")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlLiningCompletedReport(DataSet data)
            : base(data, "LiningCompleted")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlLiningCompletedReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDate(int companiesId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            FlLiningCompletedReportGateway flLiningCompletedReportGateway = new FlLiningCompletedReportGateway(Data);
            flLiningCompletedReportGateway.LoadByCompaniesIdProjectIdStartDateEndDate(companiesId, projectId, startDate, endDate, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">ProjectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>        
        public void LoadByCompaniesIdProjectIdStartDateEndDateCountryId(int companiesId, int projectId, DateTime startDate, DateTime endDate, int countryId, int companyId)
        {
            FlLiningCompletedReportGateway flLiningCompletedReportGateway = new FlLiningCompletedReportGateway(Data);
            flLiningCompletedReportGateway.LoadByCompaniesIdProjectIdStartDateEndDateCountryId(companiesId, projectId, startDate, endDate, countryId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDate
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdStartDateEndDate(int companiesId, DateTime startDate, DateTime endDate, int companyId)
        {
            FlLiningCompletedReportGateway flLiningCompletedReportGateway = new FlLiningCompletedReportGateway(Data);
            flLiningCompletedReportGateway.LoadByCompaniesIdStartDateEndDate(companiesId, startDate, endDate, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdStartDateEndDateCountryId(int companiesId, DateTime startDate, DateTime endDate, int countryId, int companyId)
        {
            FlLiningCompletedReportGateway flLiningCompletedReportGateway = new FlLiningCompletedReportGateway(Data);
            flLiningCompletedReportGateway.LoadByCompaniesIdStartDateEndDateCountryId(companiesId, startDate, endDate, countryId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByStartDateEndDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDate(DateTime startDate, DateTime endDate, int companyId)
        {
            FlLiningCompletedReportGateway flLiningCompletedReportGateway = new FlLiningCompletedReportGateway(Data);
            flLiningCompletedReportGateway.LoadByStartDateEndDate(startDate, endDate, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByStartDateEndDateCountryId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDateCountryId(DateTime startDate, DateTime endDate, int countryId, int companyId)
        {
            FlLiningCompletedReportGateway flLiningCompletedReportGateway = new FlLiningCompletedReportGateway(Data);
            flLiningCompletedReportGateway.LoadByStartDateEndDateCountryId(startDate, endDate, countryId, companyId);

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
            foreach (FlLiningCompletedReportTDS.LiningCompletedRow row in (FlLiningCompletedReportTDS.LiningCompletedDataTable)Table)
            {
                if (!row.IsLengthNull())
                {
                    Distance distance = new Distance(row.Length);
                    row.Length = distance.ToStringInEng3();
                }

                if (!row.IsSize_Null())
                {
                    if (Distance.IsValidDistance(row.Size_))                    {
                        
                        Distance distance = new Distance(row.Size_);

                        switch (distance.DistanceType)
                        {
                            case 2:
                                row.Size_ = distance.ToStringInEng1();
                                break;
                            case 3:
                                if (Convert.ToDouble(row.Size_) > 99)
                                {
                                    double newSize_ = 0;
                                    newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                                    row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                }
                                else
                                {
                                    row.Size_ = row.Size_ + "\"";
                                }
                                break;
                            case 4:
                                row.Size_ = distance.ToStringInEng1();
                                break;
                            case 5:
                                row.Size_ = distance.ToStringInEng1();
                                break;
                        }
                    }
                }
            }
        }



    }
}