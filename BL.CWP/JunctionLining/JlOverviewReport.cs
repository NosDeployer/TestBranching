using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlOverviewReport
    /// </summary>
    public class JlOverviewReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlOverviewReport()
            : base("JlOverview")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlOverviewReport(DataSet data)
            : base(data, "JlOverview")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlOverviewReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            JlOverviewReportGateway jlOverviewReportGateway = new JlOverviewReportGateway(Data);
            jlOverviewReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

            UpdateForReport(companyId);
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            JlOverviewReportGateway jlOverviewReportGateway = new JlOverviewReportGateway(Data);
            jlOverviewReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport(companyId);
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            JlOverviewReportGateway jlOverviewReportGateway = new JlOverviewReportGateway(Data);
            jlOverviewReportGateway.Load(companyId);

            UpdateForReport(companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForProcess
        /// </summary>
        /// <param name="companyId">companyId</param>
        private void UpdateForReport(int companyId)
        {
            WorkJunctionLiningCoPitLocationListGateway workJunctionLiningCoPitLocationListGateway = new WorkJunctionLiningCoPitLocationListGateway();
            
            foreach (JlOverviewReportTDS.JlOverviewRow row in (JlOverviewReportTDS.JlOverviewDataTable)Table)
            {
                if (!row.IsCoPitLocationNull())
                {
                    row.Abbreviation = workJunctionLiningCoPitLocationListGateway.GetAbbreviation(row.CoPitLocation, companyId);
                }

                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }

                int workIdFll = GetWorkId(row.ProjectID, row.AssetID, "Full Length Lining", companyId);

                FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, row.AssetID, companyId);

                if (fullLengthLiningWorkDetailsGateway.Table.Rows.Count > 0)
                {
                    string measurementFromMH = "USMH"; if (fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll) != "") measurementFromMH = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll);

                    if (measurementFromMH == "DSMH")
                    {
                        string auxDistanceFromUSMH = row.DistanceFromUSMH;
                        row.DistanceFromUSMH = row.DistanceFromDSMH;
                        row.DistanceFromDSMH = auxDistanceFromUSMH;
                    }
                }
            }
        }



        /// <summary>
        /// GetWorkId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



    }
}