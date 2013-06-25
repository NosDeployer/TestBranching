using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;

namespace LiquiForce.LFSLive.BL.CWP.RehabAssessment
{
    /// <summary>
    /// RaLiningPlan
    /// </summary>
    public class RaLiningPlan : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RaLiningPlan() : base("RaLiningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public RaLiningPlan(DataSet data)
            : base(data, "RaLiningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RaLiningPlanTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="date_">date_</param>
        /// <param name="flusher">flusher</param>
        /// <param name="flusherMN">flusherMN</param>
        /// <param name="video">video</param>
        /// <param name="videoMN">videoMN</param>
        /// <param name="selected">selected</param>
        public void UpdateForReport(int workId, int companyId, DateTime? date_, string flusher, string flusherMN, string video, string videoMN, string selected)
        {
            RaLiningPlanTDS.RaLiningPlanRow raLiningPlanRow = GetRow(workId);

            if (date_.HasValue) raLiningPlanRow.Date_ = (DateTime)date_; else raLiningPlanRow.SetDate_Null();
            raLiningPlanRow.Flusher = flusher;
            raLiningPlanRow.FlusherMN = flusherMN.Trim();
            raLiningPlanRow.Video = video;
            raLiningPlanRow.VideoMN = videoMN.Trim();
            raLiningPlanRow.Selected = selected;
        }



        /// <summary>
        /// ProcessForReport
        /// </summary>
        /// <param name="linningPlanTDS">TDS for process</param>
        public void ProcessForReport(RaLiningPlanTDS raLiningPlanTDS)
        {
            foreach (RaLiningPlanTDS.RaLiningPlanRow raLiningPlanRow in raLiningPlanTDS.RaLiningPlan.Rows)
            {
                if (raLiningPlanRow.Selected != "9")
                {
                    // Create row for report
                    RaLiningPlanTDS.RaLiningPlanRow newRow = ((RaLiningPlanTDS.RaLiningPlanDataTable)Table).NewRaLiningPlanRow();

                    newRow.WorkID = raLiningPlanRow.WorkID;
                    newRow.AssetID = raLiningPlanRow.AssetID;
                    newRow.COMPANY_ID = raLiningPlanRow.COMPANY_ID;
                    newRow.SectionID = raLiningPlanRow.SectionID;
                    if (!raLiningPlanRow.IsStreetNull()) newRow.Street = raLiningPlanRow.Street;
                    if (!raLiningPlanRow.IsSubAreaNull()) newRow.SubArea = raLiningPlanRow.SubArea;
                    if (!raLiningPlanRow.IsUSMHNull()) newRow.USMH = raLiningPlanRow.USMH;
                    if (!raLiningPlanRow.IsDSMHNull()) newRow.DSMH = raLiningPlanRow.DSMH;
                    if (!raLiningPlanRow.IsDate_Null()) newRow.Date_ = raLiningPlanRow.Date_;
                    if (!raLiningPlanRow.IsFlusherNull()) newRow.Flusher = raLiningPlanRow.Flusher;
                    if (!raLiningPlanRow.IsFlusherMNNull()) newRow.FlusherMN = raLiningPlanRow.FlusherMN;
                    if (!raLiningPlanRow.IsVideoNull()) newRow.Video = raLiningPlanRow.Video;
                    if (!raLiningPlanRow.IsVideoMNNull()) newRow.VideoMN = raLiningPlanRow.VideoMN;
                    if (!raLiningPlanRow.IsUSMHDescriptionNull()) newRow.USMHDescription = raLiningPlanRow.USMHDescription;
                    if (!raLiningPlanRow.IsDSMHDescriptionNull()) newRow.DSMHDescription = raLiningPlanRow.DSMHDescription;
                    newRow.Selected = raLiningPlanRow.Selected;
                    newRow.FlowOrderID = raLiningPlanRow.FlowOrderID;

                    ((RaLiningPlanTDS.RaLiningPlanDataTable)Table).AddRaLiningPlanRow(newRow);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single LinningPlanRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Row obtained</returns>
        private RaLiningPlanTDS.RaLiningPlanRow GetRow(int workId)
        {
            RaLiningPlanTDS.RaLiningPlanRow raLiningPlanRow = ((RaLiningPlanTDS.RaLiningPlanDataTable)Table).FindByWorkID(workId);

            if (raLiningPlanRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.RaLiningPlan.GetRow");
            }

            return raLiningPlanRow;
        }



    }
}