using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using System.Collections;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    public class FlInversionReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlInversionReport()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlInversionReport(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlInversionReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //        
        
        /// <summary>
        /// LoadBySectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="sectionId">sectionId</param>        
        public void LoadBySectionId(int companyId, ArrayList sectionsId)
        {
            foreach (string sectionId in sectionsId)
            {
                FlInversionReportGateway flInversionReportGateway = new FlInversionReportGateway(Data);
                flInversionReportGateway.ClearBeforeFill = false;
                flInversionReportGateway.LoadBySectionId(companyId, sectionId);
                flInversionReportGateway.ClearBeforeFill = true;
            }

            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        public void LoadByCompaniesIdSectionId(int companyId, int companiesId, ArrayList sectionsId)
        {
            foreach (string sectionId in sectionsId)
            {
                FlInversionReportGateway flInversionReportGateway = new FlInversionReportGateway(Data);
                flInversionReportGateway.ClearBeforeFill = false;
                flInversionReportGateway.LoadByCompaniesIdSectionId(companyId, companiesId, sectionId);
                flInversionReportGateway.ClearBeforeFill = true;

                UpdateForReport();
            }
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdSectionId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>        
        /// <param name="sectionId">sectionId</param>
        public void LoadByCompaniesIdProjectIdSectionId(int companyId, int companiesId, int projectId, ArrayList sectionsId)
        {
            FlInversionReportGateway flInversionReportGateway = new FlInversionReportGateway(Data);
            flInversionReportGateway.ClearBeforeFill = false;
            foreach (string sectionId in sectionsId)
            {
                flInversionReportGateway.LoadByCompaniesIdProjectIdSectionId(companyId, companiesId, projectId, sectionId);
            }
            flInversionReportGateway.ClearBeforeFill = true;

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
            // Load field cure records
            FlInversionFieldCureRecordReportGateway flInversionFieldCureGateway = new FlInversionFieldCureRecordReportGateway();
            flInversionFieldCureGateway.ClearBeforeFill = false;

            foreach (FlInversionReportTDS.LFS_WORK_FULLLENGTHLINING_INVERSIONRow row in (FlInversionReportTDS.LFS_WORK_FULLLENGTHLINING_INVERSIONDataTable)Table)
            {
                // Load catalysts
                flInversionFieldCureGateway.LoadByWorkId(row.COMPANY_ID, row.WorkID);

                // Update comments
                if (!row.IsCommentNull())
                {
                    row.Comment = row.Comment.Replace("<br>", "\n");
                }

                if (!row.IsInstallationResultsNull())
                {
                    row.InstallationResults = row.InstallationResults.Replace("<br>", "\n");
                }

                // Update tube size for report
                string[] confirmedSizeString = row.TubeSize.ToString().Split('\"');
                row.TubeSize = confirmedSizeString[0];

                // Run Details
                string runDetails = row.RunDetails;
                int companyId = row.COMPANY_ID;
                string[] runDetailsList = runDetails.Split('>');
                string flowOrderIds = "";
                for (int i = 0; i < runDetailsList.Length; i++)
                {
                    AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                    string sectionId = runDetailsList[i].ToString();
                    assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                    string flowOrderId = assetSewerSectionGateway.GetFlowOrderID(sectionId);
                    flowOrderIds = flowOrderIds + flowOrderId + '>';
                }
                flowOrderIds = flowOrderIds.Substring(0, flowOrderIds.Length - 1);
                row.RunDetails = flowOrderIds;
            }

            flInversionFieldCureGateway.ClearBeforeFill = true;
        }    

    }
}
