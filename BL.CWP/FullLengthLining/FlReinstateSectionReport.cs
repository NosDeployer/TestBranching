using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlReinstateSectionReport
    /// </summary>
    public class FlReinstateSectionReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlReinstateSectionReport()
            : base("ReinstateSection")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlReinstateSectionReport(DataSet data)
            : base(data, "ReinstateSection")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlReinstateReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void Load(int companyId, string unitType)
        {
            FlReinstateSectionReportGateway flReinstateSectionReportGateway = new FlReinstateSectionReportGateway(Data);
            flReinstateSectionReportGateway.Load(companyId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="unitType">unitType</param>
        public void LoadBySectionId(int companyId, string sectionId, string unitType)
        {
            FlReinstateSectionReportGateway flReinstateSectionReportGateway = new FlReinstateSectionReportGateway(Data);
            flReinstateSectionReportGateway.LoadBySectionId(companyId, sectionId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesId(int companyId, int companiesId, string unitType)
        {
            FlReinstateSectionReportGateway flReinstateSectionReportGateway = new FlReinstateSectionReportGateway(Data);
            flReinstateSectionReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport(unitType);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="unitType">unitType</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId, string unitType)
        {
            FlReinstateSectionReportGateway flReinstateSectionReportGateway = new FlReinstateSectionReportGateway(Data);
            flReinstateSectionReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

            UpdateForReport(unitType);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="unitType">unitType</param>
        private void UpdateForReport(string unitType)
        {
            FlReinstateLateralReportGateway flReinstateLateralReportGateway = new FlReinstateLateralReportGateway(Data);
            flReinstateLateralReportGateway.ClearBeforeFill = false;
            FlReinstateLateralReport flReinstateLateralReport = new FlReinstateLateralReport(Data);
            
            foreach (FlReinstateReportTDS.ReinstateSectionRow row in (FlReinstateReportTDS.ReinstateSectionDataTable)Table)
            {
                int workId = row.WorkID;
                FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workId, row.AssetID, row.COMPANY_ID);
                string measurementFromMH = "USMH"; if (fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId) != "") measurementFromMH = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);

                Distance d;

                if (unitType == "Metric")
                {
                    if (!row.IsSize_Null())
                    {
                        d = new Distance(row.Size_);
                        row.Size_ = d.ToStringInMet1();
                    }

                    if (!row.IsLengthNull())
                    {
                        d = new Distance(row.Length);
                        row.Length = d.ToStringInMet1();
                    }
                }

                if (unitType == "Imperial")
                {
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

                    if (!row.IsLengthNull())
                    {
                        d = new Distance(row.Length);
                        row.Length = d.ToStringInEng2();
                    }
                }

                flReinstateLateralReportGateway.LoadByAssetId(row.AssetID, row.COMPANY_ID);
                flReinstateLateralReport.UpdateForReport(row.FlowOrderID, unitType, measurementFromMH);                
            }
        }



    }
}