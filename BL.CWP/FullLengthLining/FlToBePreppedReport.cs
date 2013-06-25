using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlToBePreppedReport
    /// </summary>
    public class FlToBePreppedReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlToBePreppedReport()
            : base("ToBePrepped")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlToBePreppedReport(DataSet data)
            : base(data, "ToBePrepped")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlToBePreppedReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //


        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            FlToBePreppedReportGateway flToBePreppedReportGateway = new FlToBePreppedReportGateway(Data);
            flToBePreppedReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryId(int countryId, int companyId)
        {
            FlToBePreppedReportGateway flToBePreppedReportGateway = new FlToBePreppedReportGateway(Data);
            flToBePreppedReportGateway.LoadByCountryId(countryId, companyId);

            UpdateForReport();
        }
        
        

        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesId(int companiesId, int companyId)
        {
            FlToBePreppedReportGateway flToBePreppedReportGateway = new FlToBePreppedReportGateway(Data);
            flToBePreppedReportGateway.LoadByCompaniesId(companiesId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdCountryId(int companiesId, int countryId, int companyId)
        {
            FlToBePreppedReportGateway flToBePreppedReportGateway = new FlToBePreppedReportGateway(Data);
            flToBePreppedReportGateway.LoadByCompaniesIdCountryId(companiesId, countryId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>        
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectId(int companiesId, int projectId, int companyId)
        {
            FlToBePreppedReportGateway flToBePreppedReportGateway = new FlToBePreppedReportGateway(Data);
            flToBePreppedReportGateway.LoadByCompaniesIdProjectId(companiesId, projectId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdCountryId(int companiesId, int projectId, int countryId, int companyId)
        {
            FlToBePreppedReportGateway flToBePreppedReportGateway = new FlToBePreppedReportGateway(Data);
            flToBePreppedReportGateway.LoadByCompaniesIdProjectIdCountryId(companiesId, projectId, countryId, companyId);

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
            foreach (FlToBePreppedReportTDS.ToBePreppedRow row in (FlToBePreppedReportTDS.ToBePreppedDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }

                if (!row.IsSize_Null())
                {
                    if (Distance.IsValidDistance(row.Size_))
                    {
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