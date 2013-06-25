using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOutstandingLFSIssuesReport
    /// </summary>
    public class FlOutstandingLFSIssuesReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOutstandingLFSIssuesReport()
            : base("OutstandingLFSIssues")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlOutstandingLFSIssuesReport(DataSet data)
            : base(data, "OutstandingLFSIssues")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOutstandingLFSIssuesReportTDS();
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
            FlOutstandingLFSIssuesReportGateway flOutstandingLFSIssuesReportGateway = new FlOutstandingLFSIssuesReportGateway(Data);
            flOutstandingLFSIssuesReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            FlOutstandingLFSIssuesReportGateway flOutstandingLFSIssuesReportGateway = new FlOutstandingLFSIssuesReportGateway(Data);
            flOutstandingLFSIssuesReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FlOutstandingLFSIssuesReportGateway flOutstandingLFSIssuesReportGateway = new FlOutstandingLFSIssuesReportGateway(Data);
            flOutstandingLFSIssuesReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            foreach (FlOutstandingLFSIssuesReportTDS.OutstandingLFSIssuesRow row in (FlOutstandingLFSIssuesReportTDS.OutstandingLFSIssuesDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}