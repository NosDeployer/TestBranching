using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.Works;
using System.Collections;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    public class FlM1LateralSectionReport : TableModule
    {
// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM1LateralSectionReport()
            : base("M1ReportByClient")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlM1LateralSectionReport(DataSet data)
            : base(data, "M1ReportByClient")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM1LateralReportTDS();
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
            FlM1LateralSectionReportGateway flM1ReportGateway = new FlM1LateralSectionReportGateway(Data);
            flM1ReportGateway.Load(companyId);

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
            FlM1LateralSectionReportGateway flM1ReportGateway = new FlM1LateralSectionReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesId(companyId, companiesId);

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
            FlM1LateralSectionReportGateway flM1ReportGateway = new FlM1LateralSectionReportGateway(Data);
            flM1ReportGateway.LoadByCompaniesIdProjectId(companyId, companiesId, projectId);

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
            // Load comments
            foreach (FlM1LateralReportTDS.M1ReportByClientRow row in (FlM1LateralReportTDS.M1ReportByClientDataTable)Table)
            {
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(row.WorkID, row.COMPANY_ID);
                row.M1Comments = workGateway.GetComments(row.WorkID);
            }

            // Update for unit type
            FlM1LateralLateralReportGateway flM1LateralReportGateway = new FlM1LateralLateralReportGateway(Data);
            flM1LateralReportGateway.ClearBeforeFill = false;
            FlM1LateralLateralReport flM1LateralReport = new FlM1LateralLateralReport(Data);

            foreach (FlM1LateralReportTDS.M1ReportByClientRow row in (FlM1LateralReportTDS.M1ReportByClientDataTable)Table)
            {
                flM1LateralReportGateway.LoadByAssetId(row.AssetID, row.COMPANY_ID);
                flM1LateralReport.UpdateForReport(row.FlowOrderID, unitType); 
            }
        }



    }
}