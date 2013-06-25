using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using System.Collections;

namespace LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation
{
    public class MrSummaryReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MrSummaryReport()
            : base("ManholeRehabilitation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MrSummaryReport(DataSet data)
            : base(data, "ManholeRehabilitation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MrSummaryReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //        
        
        /// <summary>
        /// LoadByAssetId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="assetID">assetID</param>        
        public void LoadByAssetId(int companyId, ArrayList assetsId)
        {
            MrSummaryReportManholeRehabilitationGateway mrSummaryReportGateway = new MrSummaryReportManholeRehabilitationGateway(Data);
            mrSummaryReportGateway.ClearBeforeFill = false;

            foreach (string assetID in assetsId)
            {
                mrSummaryReportGateway.LoadByAssetId(companyId, Int32.Parse(assetID));                           
            }
            
            mrSummaryReportGateway.ClearBeforeFill = true;
            UpdateForReport();    
        }



        /// <summary>
        /// LoadByCompaniesIdAssetId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>        
        public void LoadByCompaniesIdAssetId(int companyId, int companiesId, ArrayList assetsId)
        {
            MrSummaryReportManholeRehabilitationGateway mrSummaryReportGateway = new MrSummaryReportManholeRehabilitationGateway(Data);
            mrSummaryReportGateway.ClearBeforeFill = false;

            foreach (string assetID in assetsId)
            {                
                mrSummaryReportGateway.LoadByCompaniesIdAssetId(companyId, companiesId, Int32.Parse(assetID));                               
            }

            mrSummaryReportGateway.ClearBeforeFill = true;
            UpdateForReport();
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdAssetId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="projectId">projectId</param>        
        /// <param name="assetID">assetID</param>
        public void LoadByCompaniesIdProjectIdAssetId(int companyId, int companiesId, int projectId, ArrayList assetsId)
        {
            MrSummaryReportManholeRehabilitationGateway mrSummaryReportGateway = new MrSummaryReportManholeRehabilitationGateway(Data);
            mrSummaryReportGateway.ClearBeforeFill = false;
            
            foreach (string assetID in assetsId)
            {
                mrSummaryReportGateway.LoadByCompaniesIdProjectIdAssetId(companyId, companiesId, projectId, Int32.Parse(assetID));
            }

            mrSummaryReportGateway.ClearBeforeFill = true;
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
            //WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
            //workCommentsGateway.ClearBeforeFill = false;

            //foreach (MrSummaryReportTDS.ManholeRehabilitationRow row in (MrSummaryReportTDS.ManholeRehabilitationDataTable)Table)
            //{
            //    // Load catalysts
            //    workCommentsGateway.lo.LoadByWorkId(row.COMPANY_ID, row.AssetID);

            //    // Update comments
            //    if (!row.IsCommentNull())
            //    {
            //        row.Comment = row.Comment.Replace("<br>", "\n");
            //    }
            //}

            //flInversionFieldCureGateway.ClearBeforeFill = true;
        }    

    }
}
