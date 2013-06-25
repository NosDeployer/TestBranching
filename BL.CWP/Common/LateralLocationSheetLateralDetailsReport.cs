using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// LateralLocationSheetLateralDetailsReport
    /// </summary>
    public class LateralLocationSheetLateralDetailsReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LateralLocationSheetLateralDetailsReport()
            : base("LateralLocationSheetLateralDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LateralLocationSheetLateralDetailsReport(DataSet data)
            : base(data, "LateralLocationSheetLateralDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LateralLocationSheetReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadBySectionIdWorkIdProjectId
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="workId">workId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadBySectionIdWorkIdProjectId(int sectionId, int workId, int projectId, int companyId)
        {
            LateralLocationSheetLateralDetailsReportGateway lateralLocationSheetLateralDetailsReportGateway = new LateralLocationSheetLateralDetailsReportGateway(Data);
            lateralLocationSheetLateralDetailsReportGateway.LoadBySectionIdWorkIdProjectId(sectionId, workId, projectId, companyId);

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
            foreach (LateralLocationSheetReportTDS.LateralLocationSheetLateralDetailsRow lateralRow in (LateralLocationSheetReportTDS.LateralLocationSheetLateralDetailsDataTable)Table)
            {
                Distance d; if (!lateralRow.IsVideoDistanceNull()) d = new Distance(lateralRow.VideoDistance); else d = new Distance();
                lateralRow.VideoDistanceDouble = (!lateralRow.IsVideoDistanceNull()) ? d.ToDoubleInEng3() : 0.0;

                Distance d2; if (!lateralRow.IsReverseSetupNull()) d2 = new Distance(lateralRow.ReverseSetup); else d2 = new Distance();
                lateralRow.ReverseSetupDouble = (!lateralRow.IsReverseSetupNull()) ? d2.ToDoubleInEng3() : 0.0;
            }
        }



    }
}