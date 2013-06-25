using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// PlLiningPlan
    /// </summary>
    public class PrLiningPlan : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrLiningPlan() : base("PlLiningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public PrLiningPlan(DataSet data)
            : base(data, "PlLiningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PlLiningPlanTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="date_">date_</param>
        /// <param name="selected">selected</param>
        /// <param name="liner">liner</param>
        /// <param name="linerMN">linerMN</param>
        /// <param name="video">video</param>
        /// <param name="videoMN">videoMN</param>
        public void UpdateForReport(int workId, string repairPointId, DateTime? date_, string selected, string liner, string linerMN, string video, string videoMN)
        {
            PlLiningPlanTDS.PlLiningPlanRow plLiningPlanRow = GetRow(workId, repairPointId);

            if (date_.HasValue) plLiningPlanRow.Date_ = (DateTime)date_; else plLiningPlanRow.SetDate_Null();
            plLiningPlanRow.Selected = selected;
            plLiningPlanRow.Liner = liner;
            plLiningPlanRow.LinerMN = linerMN;
            plLiningPlanRow.Video = video;
            plLiningPlanRow.VideoMN = videoMN;
        }



        /// <summary>
        /// ProcessForReport
        /// </summary>
        /// <param name="plLiningPlanTDS">TDS for process</param>
        public void ProcessForReport(PlLiningPlanTDS plLiningPlanTDS)
        {
            foreach (PlLiningPlanTDS.PlLiningPlanRow plLiningPlanRow in plLiningPlanTDS.PlLiningPlan.Rows)
            {
                if (plLiningPlanRow.Selected != "9")
                {
                    // Create row for report
                    PlLiningPlanTDS.PlLiningPlanRow newRow = ((PlLiningPlanTDS.PlLiningPlanDataTable)Table).NewPlLiningPlanRow();

                    newRow.WorkID = plLiningPlanRow.WorkID;
                    newRow.RepairPointID = plLiningPlanRow.RepairPointID;
                    newRow.FlowOrderID = plLiningPlanRow.FlowOrderID;
                    newRow.Selected = plLiningPlanRow.Selected;
                    if (!plLiningPlanRow.IsDate_Null()) newRow.Date_ = plLiningPlanRow.Date_;
                    if (!plLiningPlanRow.IsStreetNull()) newRow.Street = plLiningPlanRow.Street;
                    if (!plLiningPlanRow.IsUsmhDescriptionNull()) newRow.UsmhDescription = plLiningPlanRow.UsmhDescription;
                    if (!plLiningPlanRow.IsDsmhDescriptionNull()) newRow.DsmhDescription = plLiningPlanRow.DsmhDescription;
                    newRow.Type = plLiningPlanRow.Type;
                    if (!plLiningPlanRow.IsReamDistanceNull()) newRow.ReamDistance = plLiningPlanRow.ReamDistance;
                    if (!plLiningPlanRow.IsReamDateNull()) newRow.ReamDate = plLiningPlanRow.ReamDate;
                    if (!plLiningPlanRow.IsLinerDistanceNull()) newRow.LinerDistance = plLiningPlanRow.LinerDistance;
                    if (!plLiningPlanRow.IsDirectionNull()) newRow.Direction = plLiningPlanRow.Direction;
                    if (!plLiningPlanRow.IsReinstatesNull()) newRow.Reinstates = plLiningPlanRow.Reinstates;
                    if (!plLiningPlanRow.IsLTMHNull()) newRow.LTMH = plLiningPlanRow.LTMH;
                    if (!plLiningPlanRow.IsVTMHNull()) newRow.VTMH = plLiningPlanRow.VTMH;
                    if (!plLiningPlanRow.IsDistanceNull()) newRow.Distance = plLiningPlanRow.Distance;
                    if (!plLiningPlanRow.IsSize_Null()) newRow.Size_ = plLiningPlanRow.Size_;
                    if (!plLiningPlanRow.IsInstallDateNull()) newRow.InstallDate = plLiningPlanRow.InstallDate;
                    if (!plLiningPlanRow.IsMHShotNull()) newRow.MHShot = plLiningPlanRow.MHShot;
                    if (!plLiningPlanRow.IsGroutDistanceNull()) newRow.GroutDistance = plLiningPlanRow.GroutDistance;
                    if (!plLiningPlanRow.IsGroutDateNull()) newRow.GroutDate = plLiningPlanRow.GroutDate;
                    if (!plLiningPlanRow.IsApprovalNull()) newRow.Approval = plLiningPlanRow.Approval;
                    newRow.ExtraRepair = plLiningPlanRow.ExtraRepair;
                    newRow.Cancelled = plLiningPlanRow.Cancelled;
                    if (!plLiningPlanRow.IsLinerNull()) newRow.Liner = plLiningPlanRow.Liner;
                    if (!plLiningPlanRow.IsLinerMNNull()) newRow.LinerMN = plLiningPlanRow.LinerMN;
                    if (!plLiningPlanRow.IsVideoNull()) newRow.Video = plLiningPlanRow.Video;
                    if (!plLiningPlanRow.IsVideoMNNull()) newRow.VideoMN = plLiningPlanRow.VideoMN;
                    if (!plLiningPlanRow.IsDefectQualifierNull()) newRow.DefectQualifier = plLiningPlanRow.DefectQualifier;
                    if (!plLiningPlanRow.IsDefectDetailsNull()) newRow.DefectDetails = plLiningPlanRow.DefectDetails;

                    // Update comments
                    if (!plLiningPlanRow.IsCommentsNull())
                    {
                        newRow.Comments = plLiningPlanRow.Comments.Replace("<br>", "\n");
                    }

                    newRow.Deleted = plLiningPlanRow.Deleted;
                    newRow.COMPANY_ID = plLiningPlanRow.COMPANY_ID;

                    ((PlLiningPlanTDS.PlLiningPlanDataTable)Table).AddPlLiningPlanRow(newRow);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single LiningPlanRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Row obtained</returns>
        private PlLiningPlanTDS.PlLiningPlanRow GetRow(int workId, string repairPointId)
        {
            PlLiningPlanTDS.PlLiningPlanRow plLiningPlanRow = ((PlLiningPlanTDS.PlLiningPlanDataTable)Table).FindByWorkIDRepairPointID(workId, repairPointId);

            if (plLiningPlanRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.PointRepairs.PlLiningPlan.GetRow");
            }

            return plLiningPlanRow;
        }



    }
}