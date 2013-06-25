using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOutstandingClientIssuesReport
    /// </summary>
    public class FlOutstandingClientIssuesReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOutstandingClientIssuesReport()
            : base("OutstandingClientIssues")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlOutstandingClientIssuesReport(DataSet data)
            : base(data, "OutstandingClientIssues")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOutstandingClientIssuesReportTDS();
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
            FlOutstandingClientIssuesReportGateway flOutstandingClientIssuesReportGateway = new FlOutstandingClientIssuesReportGateway(Data);
            flOutstandingClientIssuesReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            FlOutstandingClientIssuesReportGateway flOutstandingClientIssuesReportGateway = new FlOutstandingClientIssuesReportGateway(Data);
            flOutstandingClientIssuesReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompanyIdCompaniesIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        public void LoadByCompaniesIdProjectId(int companyId, int companiesId, int projectId)
        {
            FlOutstandingClientIssuesReportGateway flOutstandingClientIssuesReportGateway = new FlOutstandingClientIssuesReportGateway(Data);
            flOutstandingClientIssuesReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            foreach (FlOutstandingClientIssuesReportTDS.OutstandingClientIssuesRow row in (FlOutstandingClientIssuesReportTDS.OutstandingClientIssuesDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }            
            }
        }



    }
}