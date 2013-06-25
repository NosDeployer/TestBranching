using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOutstandingSalesIssuesReport
    /// </summary>
    public class FlOutstandingSalesIssuesReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlOutstandingSalesIssuesReport()
            : base("OutstandingSalesIssues")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlOutstandingSalesIssuesReport(DataSet data)
            : base(data, "OutstandingSalesIssues")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlOutstandingSalesIssuesReportTDS();
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
            FlOutstandingSalesIssuesReportGateway flOutstandingSalesIssuesReportGateway = new FlOutstandingSalesIssuesReportGateway(Data);
            flOutstandingSalesIssuesReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            FlOutstandingSalesIssuesReportGateway flOutstandingSalesIssuesReportGateway = new FlOutstandingSalesIssuesReportGateway(Data);
            flOutstandingSalesIssuesReportGateway.LoadByCompaniesId(companyId, companiesId);

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
            FlOutstandingSalesIssuesReportGateway flOutstandingSalesIssuesReportGateway = new FlOutstandingSalesIssuesReportGateway(Data);
            flOutstandingSalesIssuesReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            foreach (FlOutstandingSalesIssuesReportTDS.OutstandingSalesIssuesRow row in (FlOutstandingSalesIssuesReportTDS.OutstandingSalesIssuesDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}