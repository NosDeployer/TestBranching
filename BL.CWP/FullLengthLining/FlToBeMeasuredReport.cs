using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlToBeMeasuredReport
    /// </summary>
    public class FlToBeMeasuredReport : TableModule
    {   
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlToBeMeasuredReport()
            : base("ToBeMeasured")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlToBeMeasuredReport(DataSet data)
            : base(data, "ToBeMeasured")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlToBeMeasuredReportTDS();
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
            FlToBeMeasuredReportGateway flToBeMeasuredReportGateway = new FlToBeMeasuredReportGateway(Data);
            flToBeMeasuredReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryId(int countryId, int companyId)
        {
            FlToBeMeasuredReportGateway flToBeMeasuredReportGateway = new FlToBeMeasuredReportGateway(Data);
            flToBeMeasuredReportGateway.LoadByCountryId(countryId, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesId(int companiesId, int companyId)
        {
            FlToBeMeasuredReportGateway flToBeMeasuredReportGateway = new FlToBeMeasuredReportGateway(Data);
            flToBeMeasuredReportGateway.LoadByCompaniesId(companiesId, companyId);

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
            FlToBeMeasuredReportGateway flToBeMeasuredReportGateway = new FlToBeMeasuredReportGateway(Data);
            flToBeMeasuredReportGateway.LoadByCompaniesIdCountryId(companiesId, countryId, companyId);

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
            FlToBeMeasuredReportGateway flToBeMeasuredReportGateway = new FlToBeMeasuredReportGateway(Data);
            flToBeMeasuredReportGateway.LoadByCompaniesIdProjectId(companiesId, projectId, companyId);

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
            FlToBeMeasuredReportGateway flToBeMeasuredReportGateway = new FlToBeMeasuredReportGateway(Data);
            flToBeMeasuredReportGateway.LoadByCompaniesIdProjectIdCountryId(companiesId, projectId, countryId, companyId);

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
            foreach (FlToBeMeasuredReportTDS.ToBeMeasuredRow row in (FlToBeMeasuredReportTDS.ToBeMeasuredDataTable)Table)
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