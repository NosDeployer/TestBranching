using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOverviewReport
    /// </summary>
    public class FlOverviewReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOverviewReport()
            : base("OverviewReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlOverviewReport(DataSet data)
            : base(data, "OverviewReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOverviewReportTDS();
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
            FlOverviewReportGateway flOverviewReportGateway = new FlOverviewReportGateway(Data);
            flOverviewReportGateway.Load(companyId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectId(int companiesId, int projectId, int companyId)
        {
            FlOverviewReportGateway flOverviewReportGateway = new FlOverviewReportGateway(Data);
            flOverviewReportGateway.LoadByCompaniesIdProjectId(companiesId, projectId, companyId);            
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
            FlOverviewReportGateway flOverviewReportGateway = new FlOverviewReportGateway(Data);
            flOverviewReportGateway.LoadByCompaniesIdProjectIdCountryId(companiesId, projectId, countryId, companyId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesId(int companiesId, int companyId)
        {
            FlOverviewReportGateway flOverviewReportGateway = new FlOverviewReportGateway(Data);
            flOverviewReportGateway.LoadByCompaniesId(companiesId, companyId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// LoadByCompaniesIdCountryId
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdCountryId(int companiesId, int countryId, int companyId)
        {
            FlOverviewReportGateway flOverviewReportGateway = new FlOverviewReportGateway(Data);
            flOverviewReportGateway.LoadByCompaniesIdCountryId(companiesId, countryId, companyId);

            UpdateFieldsForSections();
        }
        


        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryId(int countryId, int companyId)
        {
            FlOverviewReportGateway flOverviewReportGateway = new FlOverviewReportGateway(Data);
            flOverviewReportGateway.LoadByCountryId(countryId, companyId);

            UpdateFieldsForSections();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            foreach (FlOverviewReportTDS.OverviewReportRow row in (FlOverviewReportTDS.OverviewReportDataTable)Table)
            {
                if (!row.IsSizeNull())
                {
                    if (Distance.IsValidDistance(row.Size))
                    {
                        Distance distance = new Distance(row.Size);

                        switch (distance.DistanceType)
                        {
                            case 2:
                                row.Size = distance.ToStringInEng1();
                                break;
                            case 3:
                                if (Convert.ToDouble(row.Size) > 99)
                                {
                                    double newSize_ = 0;
                                    newSize_ = Convert.ToDouble(row.Size) * 0.03937;
                                    row.Size = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                }
                                else
                                {
                                    row.Size = row.Size + "\"";
                                }
                                break;
                            case 4:
                                row.Size = distance.ToStringInEng1();
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