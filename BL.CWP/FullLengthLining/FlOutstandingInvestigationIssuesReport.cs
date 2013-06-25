using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOutstandingInvestigationIssuesReport
    /// </summary>
    public class FlOutstandingInvestigationIssuesReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOutstandingInvestigationIssuesReport()
            : base("OutstandingInvestigationIssues")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlOutstandingInvestigationIssuesReport(DataSet data)
            : base(data, "OutstandingInvestigationIssues")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOutstandingInvestigationIssuesReportTDS();
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
            FlOutstandingInvestigationIssuesReportGateway flOutstandingInvestigationIssuesReportGateway = new FlOutstandingInvestigationIssuesReportGateway(Data);
            flOutstandingInvestigationIssuesReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            FlOutstandingInvestigationIssuesReportGateway flOutstandingInvestigationIssuesReportGateway = new FlOutstandingInvestigationIssuesReportGateway(Data);
            flOutstandingInvestigationIssuesReportGateway.LoadByCompaniesId(companyId, companiesId);

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
            FlOutstandingInvestigationIssuesReportGateway flOutstandingInvestigationIssuesReportGateway = new FlOutstandingInvestigationIssuesReportGateway(Data);
            flOutstandingInvestigationIssuesReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            foreach (FlOutstandingInvestigationIssuesReportTDS.OutstandingInvestigationIssuesRow row in (FlOutstandingInvestigationIssuesReportTDS.OutstandingInvestigationIssuesDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}