using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// PrOverviewReport
    /// </summary>
    public class PrOverviewReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrOverviewReport()
            : base("PrOverview")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public PrOverviewReport(DataSet data)
            : base(data, "PrOverview")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrOverviewReportTDS();
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
            PrOverviewReportGateway prOverviewReportGateway = new PrOverviewReportGateway(Data);
            prOverviewReportGateway.Load(companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByPrType
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        public void LoadByPrType(string type, int companyId)
        {
            PrOverviewReportGateway prOverviewReportGateway = new PrOverviewReportGateway(Data);
            prOverviewReportGateway.LoadByPrType(type, companyId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        public void LoadByCompaniesId(int companyId, int companiesId)
        {
            PrOverviewReportGateway prOverviewReportGateway = new PrOverviewReportGateway(Data);
            prOverviewReportGateway.LoadByCompaniesId(companyId, companiesId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdPrType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="type">type</param>
        public void LoadByCompaniesIdPrType(int companyId, int companiesId, string type)
        {
            PrOverviewReportGateway prOverviewReportGateway = new PrOverviewReportGateway(Data);
            prOverviewReportGateway.LoadByCompaniesIdPrType(companyId, companiesId, type);

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
            PrOverviewReportGateway prOverviewReportGateway = new PrOverviewReportGateway(Data);
            prOverviewReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdPrType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>
        /// <param name="type">type</param>
        public void LoadByCompaniesIdProjectIdPrType(int companyId, int companiesId, int projectId, string type)
        {
            PrOverviewReportGateway prOverviewReportGateway = new PrOverviewReportGateway(Data);
            prOverviewReportGateway.LoadByCompaniesIdProjectIdPrType(companyId, companiesId, projectId, type);

            UpdateForReport();
        }  





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForProcess
        /// </summary>
        private void UpdateForReport()
        {           
            // Load comments
            foreach (PrOverviewReportTDS.PrOverviewRow row in (PrOverviewReportTDS.PrOverviewDataTable)Table)
            {
                PointRepairsRepairDetailsGateway pointRepairsRepairDetailsGateway = new PointRepairsRepairDetailsGateway();
                pointRepairsRepairDetailsGateway.LoadAllByWorkIdRepairPointId(row.WorkID, row.RepairPointID, row.COMPANY_ID);
                row.Comments = pointRepairsRepairDetailsGateway.GetComments(row.WorkID, row.RepairPointID);
            }

            // Format comments
            foreach (PrOverviewReportTDS.PrOverviewRow row in (PrOverviewReportTDS.PrOverviewDataTable)Table)
            {              
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}