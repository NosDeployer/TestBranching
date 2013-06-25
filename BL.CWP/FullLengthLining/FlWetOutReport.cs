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
    /// <summary>
    /// FlWetOutReport
    /// </summary>
    public class FlWetOutReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlWetOutReport()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlWetOutReport(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlWetOutReportTDS();
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
                FlWetOutReportGateway flWetOutReportGateway = new FlWetOutReportGateway(Data);
                flWetOutReportGateway.ClearBeforeFill = false;
                flWetOutReportGateway.LoadBySectionId(companyId, sectionId);
                flWetOutReportGateway.ClearBeforeFill = true;
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
                FlWetOutReportGateway flWetOutReportGateway = new FlWetOutReportGateway(Data);
                flWetOutReportGateway.ClearBeforeFill = false;
                flWetOutReportGateway.LoadByCompaniesIdSectionId(companyId, companiesId, sectionId);
                flWetOutReportGateway.ClearBeforeFill = true;

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
            FlWetOutReportGateway flWetOutReportGateway = new FlWetOutReportGateway(Data);
            flWetOutReportGateway.ClearBeforeFill = false;
            foreach (string sectionId in sectionsId)
            {
                flWetOutReportGateway.LoadByCompaniesIdProjectIdSectionId(companyId, companiesId, projectId, sectionId);
            }
            flWetOutReportGateway.ClearBeforeFill = true;

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
            // Load catalysts
            FlWetOutCatalystsReportGateway flWetOutCatalystsReportGateway = new FlWetOutCatalystsReportGateway();
            flWetOutCatalystsReportGateway.ClearBeforeFill = false;

            foreach (FlWetOutReportTDS.LFS_WORK_FULLLENGTHLINING_WETOUTRow row in (FlWetOutReportTDS.LFS_WORK_FULLLENGTHLINING_WETOUTDataTable)Table)
            {
                // Load catalysts
                flWetOutCatalystsReportGateway.LoadByWorkId(row.COMPANY_ID, row.WorkID);

                // Update comments
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
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
            flWetOutCatalystsReportGateway.ClearBeforeFill = true;
        }
    }
}
