using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlOutstandingSalesIssuesReport
    /// </summary>
    public class FlAllOutstandingIssuesReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlAllOutstandingIssuesReport()
            : base("AllOutstandingIssues")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlAllOutstandingIssuesReport(DataSet data)
            : base(data, "AllOutstandingIssues")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlAllOutstandingIssuesReportTDS();
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
            FlAllOutstandingIssuesReportGateway flAllOutstandingIssuesReportGateway = new FlAllOutstandingIssuesReportGateway(Data);
            flAllOutstandingIssuesReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            FlAllOutstandingIssuesReportGateway flAllOutstandingIssuesReportGateway = new FlAllOutstandingIssuesReportGateway(Data);
            flAllOutstandingIssuesReportGateway.LoadByCompaniesId(companyId, companiesId);

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
            FlAllOutstandingIssuesReportGateway flAllOutstandingIssuesReportGateway = new FlAllOutstandingIssuesReportGateway(Data);
            flAllOutstandingIssuesReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            foreach (FlAllOutstandingIssuesReportTDS.AllOutstandingIssuesRow row in (FlAllOutstandingIssuesReportTDS.AllOutstandingIssuesDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}

