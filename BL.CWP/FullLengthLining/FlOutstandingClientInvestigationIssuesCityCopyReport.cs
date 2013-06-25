using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOutstandingClientIssuesReport
    /// </summary>
    public class FlOutstandingClientInvestigationIssuesCityCopyReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOutstandingClientInvestigationIssuesCityCopyReport()
            : base("OutstandingClientInvestigationIssuesCityCopy")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlOutstandingClientInvestigationIssuesCityCopyReport(DataSet data)
            : base(data, "OutstandingClientInvestigationIssuesCityCopy")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOutstandingClientInvestigationIssuesCityCopyReportTDS();
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
            FlOutstandingClientInvestigationIssuesCityCopyReportGateway flOutstandingClientInvestigationIssuesCityCopyReportGateway = new FlOutstandingClientInvestigationIssuesCityCopyReportGateway(Data);
            flOutstandingClientInvestigationIssuesCityCopyReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            FlOutstandingClientInvestigationIssuesCityCopyReportGateway flOutstandingClientInvestigationIssuesCityCopyReportGateway = new FlOutstandingClientInvestigationIssuesCityCopyReportGateway(Data);
            flOutstandingClientInvestigationIssuesCityCopyReportGateway.LoadByCompaniesId(companyId, companiesId);

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
            FlOutstandingClientInvestigationIssuesCityCopyReportGateway flOutstandingClientInvestigationIssuesCityCopyReportGateway = new FlOutstandingClientInvestigationIssuesCityCopyReportGateway(Data);
            flOutstandingClientInvestigationIssuesCityCopyReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            foreach (FlOutstandingClientInvestigationIssuesCityCopyReportTDS.OutstandingClientInvestigationIssuesCityCopyRow row in (FlOutstandingClientInvestigationIssuesCityCopyReportTDS.OutstandingClientInvestigationIssuesCityCopyDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}