using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.CWP.PointRepairs
{
    /// <summary>
    /// PointRepairsRepairDetails
    /// </summary>
    public class PointRepairsRepairDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PointRepairsRepairDetails()
            : base("RepairDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PointRepairsRepairDetails(DataSet data)
            : base(data, "RepairDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PointRepairsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByWorkId(int workId, int companyId)
        {
            PointRepairsRepairDetailsGateway pointRepairsRepairDetailsGateway = new PointRepairsRepairDetailsGateway(Data);
            pointRepairsRepairDetailsGateway.LoadAllByWorkId(workId, companyId);

            UpdateForProcess();
        }



        /// <summary>
        /// LoadAllByWorkIdRepairPointId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByWorkIdRepairPointId(int workId, string repairPointId, int companyId)
        {
            PointRepairsRepairDetailsGateway pointRepairsRepairDetailsGateway = new PointRepairsRepairDetailsGateway(Data);
            pointRepairsRepairDetailsGateway.LoadAllByWorkIdRepairPointId(workId, repairPointId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="type">type</param>
        /// <param name="reamDistance">reamDistance</param>
        /// <param name="reamDate">reamDate</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="ltmh">ltmh</param>
        /// <param name="vtmh">vtmh</param>
        /// <param name="distance">distance</param>
        /// <param name="size_">size_</param>
        /// <param name="installDate">installDate</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="groutDistance">groutDistance</param>
        /// <param name="groutDate">groutDate</param>
        /// <param name="approval">approval</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="defectQualifier">defectQualifier</param>
        /// <param name="defectDetails">defectDetails</param>
        /// <param name="length">length</param>
        public void Insert(int workId, string repairPointId, string type, string reamDistance, DateTime? reamDate, string linerDistance, string direction, int? reinstates, string ltmh, string vtmh, string distance, string size_, DateTime? installDate, string mhShot, string groutDistance, DateTime? groutDate, string approval, bool extraRepair, bool cancelled, string comments, bool deleted, int companyId, bool inDatabase, string defectQualifier, string defectDetails, string length, DateTime? reinstateDate)
        {
            PointRepairsTDS.RepairDetailsRow row = ((PointRepairsTDS.RepairDetailsDataTable)Table).NewRepairDetailsRow();

            row.WorkID = workId;
            row.RepairPointID = repairPointId;
            row.Type = type;
            if (reamDistance != "") row.ReamDistance = reamDistance; else row.SetReamDistanceNull();
            if (reamDate.HasValue) row.ReamDate = (DateTime)reamDate; else row.SetReamDateNull();
            if (linerDistance != "") row.LinerDistance = linerDistance; else row.SetLinerDistanceNull();
            if (direction != "") row.Direction = direction; else row.SetDirectionNull();
            if (reinstates.HasValue) row.Reinstates = (int)reinstates; else row.SetReinstatesNull();
            if (ltmh != "") row.LTMH = ltmh; else row.SetLTMHNull();
            if (vtmh != "") row.VTMH = vtmh; else row.SetVTMHNull();
            if (distance != "") row.Distance = distance; else row.SetDistanceNull();
            if (size_ != "") row.Size_ = size_; else row.SetSize_Null();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (mhShot != "") row.MHShot = mhShot; else row.SetMHShotNull();
            if (groutDistance != "") row.GroutDistance = groutDistance; else row.SetGroutDistanceNull();
            if (groutDate.HasValue) row.GroutDate = (DateTime)groutDate; else row.SetGroutDateNull();
            if (approval != "") row.Approval = approval; else row.SetApprovalNull();
            row.ExtraRepair = extraRepair;
            row.Cancelled = cancelled;
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            if (defectQualifier != "") row.DefectQualifier = defectQualifier; else row.SetDefectQualifierNull();
            if (defectDetails != "") row.DefectDetails = defectDetails; else row.SetDefectDetailsNull();
            if (length != "") row.Length = length; else row.SetLengthNull();
            if (reinstateDate.HasValue) row.ReinstateDate = (DateTime)reinstateDate; else row.SetReinstateDateNull();

            ((PointRepairsTDS.RepairDetailsDataTable)Table).AddRepairDetailsRow(row);
        }



        /// <summary>
        /// UpdateRoboticReaming
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="reamDistance">reamDistance</param>
        /// <param name="reamDate">reamDate</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="approval">approval</param>
        /// <param name="comments">comments</param>
        /// <param name="defectQualifier">defectQualifier</param>
        /// <param name="defectDetails">defectDetails</param>
        public void UpdateRoboticReaming(int workId, string repairPointId, string reamDistance, DateTime? reamDate, bool extraRepair, bool cancelled, string approval, string comments, string defectQualifier, string defectDetails, DateTime? reinstateDate)
        {
            PointRepairsTDS.RepairDetailsRow row = GetRow(workId, repairPointId);

            if (reamDistance != "") row.ReamDistance = reamDistance; else row.SetReamDistanceNull();
            if (reamDate.HasValue) row.ReamDate = (DateTime)reamDate; else row.SetReamDateNull();
            row.ExtraRepair = extraRepair;
            row.Cancelled = cancelled;
            if (approval != "") row.Approval = approval; else row.SetApprovalNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (defectQualifier != "") row.DefectQualifier = defectQualifier; else row.SetDefectQualifierNull();
            if (defectDetails != "") row.DefectDetails = defectDetails; else row.SetDefectDetailsNull();
            if (reinstateDate.HasValue) row.ReinstateDate = (DateTime)reinstateDate; else row.SetReinstateDateNull();
        }



        /// <summary>
        /// UpdatePointLining
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="ltmh">ltmh</param>
        /// <param name="vtmh">vtmh</param>
        /// <param name="distance">distance</param>
        /// <param name="size_">size_</param>
        /// <param name="installDate">installDate</param>
        /// <param name="mhsshot">mhsshot</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="approval">approval</param>
        /// <param name="comments">comments</param>
        /// <param name="defectQualifier">defectQualifier</param>
        /// <param name="defectDetails">defectDetails</param>
        /// <param name="length">length</param>
        public void UpdatePointLining(int workId, string repairPointId, string linerDistance, string direction, int? reinstates, string ltmh, string vtmh, string distance, string size_, DateTime? installDate, string mhsshot, bool extraRepair, bool cancelled, string approval, string comments, string defectQualifier, string defectDetails, string length, DateTime? reinstateDate)
        {
            PointRepairsTDS.RepairDetailsRow row = GetRow(workId, repairPointId);

            if (linerDistance != "") row.LinerDistance = linerDistance; else row.SetLinerDistanceNull();
            if (direction != "") row.Direction = direction; else row.SetDirectionNull();
            if (reinstates.HasValue) row.Reinstates = (Int32)reinstates; else row.SetReinstatesNull();
            if (ltmh != "") row.LTMH = ltmh; else row.SetLTMHNull();
            if (vtmh != "") row.VTMH = vtmh; else row.SetVTMHNull();
            if (distance != "") row.Distance = distance; else row.SetDistanceNull();
            if (size_ != "") row.Size_ = size_; else row.SetSize_Null();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (mhsshot != "") row.MHShot = mhsshot; else row.SetMHShotNull();
            row.ExtraRepair = extraRepair;
            row.Cancelled = cancelled;
            if (approval != "") row.Approval = approval; else row.SetApprovalNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (defectQualifier != "") row.DefectQualifier = defectQualifier; else row.SetDefectQualifierNull();
            if (defectDetails != "") row.DefectDetails = defectDetails; else row.SetDefectDetailsNull();
            if (length != "") row.Length = length; else row.SetLengthNull();
            if (reinstateDate.HasValue) row.ReinstateDate = (DateTime)reinstateDate; else row.SetReinstateDateNull();
        }



        /// <summary>
        /// UpdateSizePointLining
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="size_">size_</param>
        public void UpdateSizePointLining(int workId, string repairPointId, string size_)
        {
            PointRepairsTDS.RepairDetailsRow row = GetRow(workId, repairPointId);

            if (size_ != "") row.Size_ = size_; else row.SetSize_Null();
        }



        /// <summary>
        /// UpdateGrouting
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="groutDistance">groutDistance</param>
        /// <param name="installDate">installDate</param>
        /// <param name="groutDate">groutDate</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="approval">approval</param>
        /// <param name="comments">comments</param>
        /// <param name="defectQualifier">defectQualifier</param>
        /// <param name="defectDetails">defectDetails</param>
        public void UpdateGrouting(int workId, string repairPointId, string groutDistance, DateTime? installDate, DateTime? groutDate, bool extraRepair, bool cancelled, string approval, string comments, string defectQualifier, string defectDetails, DateTime? reinstateDate)
        {
            PointRepairsTDS.RepairDetailsRow row = GetRow(workId, repairPointId);

            if (groutDistance != "") row.GroutDistance = groutDistance; else row.SetGroutDistanceNull();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (groutDate.HasValue) row.GroutDate = (DateTime)groutDate; else row.SetGroutDateNull();
            row.ExtraRepair = extraRepair;
            row.Cancelled = cancelled;
            if (approval != "") row.Approval = approval; else row.SetApprovalNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (defectQualifier != "") row.DefectQualifier = defectQualifier; else row.SetDefectQualifierNull();
            if (defectDetails != "") row.DefectDetails = defectDetails; else row.SetDefectDetailsNull();
            if (reinstateDate.HasValue) row.ReinstateDate = (DateTime)reinstateDate; else row.SetReinstateDateNull();
        }

        

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        public void Delete(int workId, string repairPointId)
        {
            PointRepairsTDS.RepairDetailsRow row = GetRow(workId, repairPointId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        public void DeleteAll()
        {
            foreach (PointRepairsTDS.RepairDetailsRow row in (PointRepairsTDS.RepairDetailsDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all repairs to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            PointRepairsTDS pointRepairsChanges = (PointRepairsTDS)Data.GetChanges();

            if (pointRepairsChanges.RepairDetails.Rows.Count > 0)
            {
                PointRepairsRepairDetailsGateway pointRepairsRepairDetailsGateway = new PointRepairsRepairDetailsGateway(pointRepairsChanges);

                foreach (PointRepairsTDS.RepairDetailsRow row in (PointRepairsTDS.RepairDetailsDataTable)pointRepairsChanges.RepairDetails)
                {
                    // Insert new repair 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int workId = row.WorkID;
                        string repairPointId = row.RepairPointID;
                        string reamDistance = ""; if (!row.IsReamDistanceNull()) reamDistance = row.ReamDistance;
                        DateTime? reamDate = null; if (!row.IsReamDateNull()) reamDate = row.ReamDate;
                        string linerDistance = ""; if (!row.IsLinerDistanceNull()) linerDistance = row.LinerDistance;
                        string direction = ""; if (!row.IsDirectionNull()) direction = row.Direction;
                        int? reinstates = null; if (!row.IsReinstatesNull()) reinstates = row.Reinstates;
                        string ltmh = ""; if (!row.IsLTMHNull()) ltmh = row.LTMH;
                        string vtmh = ""; if (!row.IsVTMHNull()) vtmh = row.VTMH;
                        string distance = ""; if (!row.IsDistanceNull()) distance = row.Distance;
                        string size_ = ""; if (!row.IsSize_Null()) size_ = row.Size_;
                        DateTime? installDate = null; if (!row.IsInstallDateNull()) installDate = row.InstallDate;
                        string mhshot = ""; if (!row.IsMHShotNull()) mhshot = row.MHShot;
                        string groutDistance = ""; if (!row.IsGroutDistanceNull()) groutDistance = row.GroutDistance;
                        DateTime? groutDate = null; if (!row.IsGroutDateNull()) groutDate = row.GroutDate;
                        string approval = ""; if (!row.IsApprovalNull()) approval = row.Approval;
                        bool extraRepair = row.ExtraRepair;
                        bool cancelled = row.Cancelled;
                        string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                        string defectQualifier = ""; if (!row.IsDefectQualifierNull()) defectQualifier = row.DefectQualifier;
                        string defectDetails = ""; if (!row.IsDefectDetailsNull()) defectDetails = row.DefectDetails;
                        string length = ""; if (!row.IsLengthNull()) length = row.Length;
                        DateTime? reinstateDate = null; if (!row.IsReinstateDateNull()) reinstateDate = row.ReinstateDate;

                        WorkPointRepairsRepair workPointRepairsRepair = new WorkPointRepairsRepair(null);
                        workPointRepairsRepair.InsertDirect(workId, repairPointId, row.Type, reamDistance, reamDate, linerDistance, direction, reinstates, ltmh, vtmh, distance, size_, installDate, mhshot, groutDistance, groutDate, approval, extraRepair, cancelled, comments, row.Deleted, row.COMPANY_ID, defectQualifier, defectDetails, length, reinstateDate);
                    }

                    // Update repair
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        string repairPointId = row.RepairPointID;
                        string type = row.Type;
                       
                        // Original values
                        string originalReamDistance = pointRepairsRepairDetailsGateway.GetReamDistanceOriginal(workId, repairPointId);
                        DateTime? originalReamDate = null; if (pointRepairsRepairDetailsGateway.GetReamDateOriginal(workId, repairPointId).HasValue) originalReamDate = pointRepairsRepairDetailsGateway.GetReamDateOriginal(workId, repairPointId);
                        string originalLinerDistance = pointRepairsRepairDetailsGateway.GetLinerDistanceOriginal(workId, repairPointId);
                        string originalDirection = pointRepairsRepairDetailsGateway.GetDirectionOriginal(workId, repairPointId);
                        int? originalReinstates = null; if (pointRepairsRepairDetailsGateway.GetReinstatesOriginal(workId, repairPointId).HasValue) originalReinstates = pointRepairsRepairDetailsGateway.GetReinstatesOriginal(workId, repairPointId);
                        string originalLtmh = pointRepairsRepairDetailsGateway.GetLTMHOriginal(workId, repairPointId);
                        string originalVtmh = pointRepairsRepairDetailsGateway.GetVTMHOriginal(workId, repairPointId);
                        string originalDistance = pointRepairsRepairDetailsGateway.GetDistanceOriginal(workId, repairPointId);
                        string originalSize_ = pointRepairsRepairDetailsGateway.GetSize_Original(workId, repairPointId);
                        DateTime? originalInstallDate = null; if (pointRepairsRepairDetailsGateway.GetInstallDateOriginal(workId, repairPointId).HasValue) originalInstallDate = pointRepairsRepairDetailsGateway.GetInstallDateOriginal(workId, repairPointId);
                        string originalMhShot = pointRepairsRepairDetailsGateway.GetMHShotOriginal(workId, repairPointId);
                        string originalGroutDistance = pointRepairsRepairDetailsGateway.GetGroutDistanceOriginal(workId, repairPointId);
                        DateTime? originalGroutDate = null; if (pointRepairsRepairDetailsGateway.GetGroutDateOriginal(workId, repairPointId).HasValue) originalGroutDate = pointRepairsRepairDetailsGateway.GetGroutDateOriginal(workId, repairPointId);
                        string originalApproval = pointRepairsRepairDetailsGateway.GetApprovalOriginal(workId, repairPointId);
                        bool originalExtraRepair = pointRepairsRepairDetailsGateway.GetExtraRepairOriginal(workId, repairPointId);
                        bool originalCancelled = pointRepairsRepairDetailsGateway.GetCancelledOriginal(workId, repairPointId);
                        string originalComments = pointRepairsRepairDetailsGateway.GetCommentsOriginal(workId, repairPointId);
                        string originalDefectQualifier = pointRepairsRepairDetailsGateway.GetDefectQualifierOriginal(workId, repairPointId);
                        string originalDefectDetails = pointRepairsRepairDetailsGateway.GetDefectDetailsOriginal(workId, repairPointId);
                        string originalLength = pointRepairsRepairDetailsGateway.GetLengthOriginal(workId, repairPointId);
                        DateTime? originalReinstateDate = null; if (pointRepairsRepairDetailsGateway.GetReinstateDateOriginal(workId, repairPointId).HasValue) originalReinstateDate = pointRepairsRepairDetailsGateway.GetReinstateDateOriginal(workId, repairPointId);

                        // New values
                        string newReamDistance = pointRepairsRepairDetailsGateway.GetReamDistance(workId, repairPointId);
                        DateTime? newReamDate = null; if (pointRepairsRepairDetailsGateway.GetReamDate(workId, repairPointId).HasValue) newReamDate = pointRepairsRepairDetailsGateway.GetReamDate(workId, repairPointId);
                        string newLinerDistance = pointRepairsRepairDetailsGateway.GetLinerDistance(workId, repairPointId);
                        string newDirection = pointRepairsRepairDetailsGateway.GetDirection(workId, repairPointId);
                        int? newReinstates = null; if (pointRepairsRepairDetailsGateway.GetReinstates(workId, repairPointId).HasValue) newReinstates = pointRepairsRepairDetailsGateway.GetReinstates(workId, repairPointId);
                        string newLtmh = pointRepairsRepairDetailsGateway.GetLTMH(workId, repairPointId);
                        string newVtmh = pointRepairsRepairDetailsGateway.GetVTMH(workId, repairPointId);
                        string newDistance = pointRepairsRepairDetailsGateway.GetDistance(workId, repairPointId);
                        string newSize_ = pointRepairsRepairDetailsGateway.GetSize_(workId, repairPointId);
                        DateTime? newInstallDate = null; if (pointRepairsRepairDetailsGateway.GetInstallDate(workId, repairPointId).HasValue) newInstallDate = pointRepairsRepairDetailsGateway.GetInstallDate(workId, repairPointId);
                        string newMhShot = pointRepairsRepairDetailsGateway.GetMHShot(workId, repairPointId);
                        string newGroutDistance = pointRepairsRepairDetailsGateway.GetGroutDistance(workId, repairPointId);
                        DateTime? newGroutDate = null; if (pointRepairsRepairDetailsGateway.GetGroutDate(workId, repairPointId).HasValue) newGroutDate = pointRepairsRepairDetailsGateway.GetGroutDate(workId, repairPointId);
                        string newApproval = pointRepairsRepairDetailsGateway.GetApproval(workId, repairPointId);
                        bool newExtraRepair = pointRepairsRepairDetailsGateway.GetExtraRepair(workId, repairPointId);
                        bool newCancelled = pointRepairsRepairDetailsGateway.GetCancelled(workId, repairPointId);
                        string newComments = pointRepairsRepairDetailsGateway.GetComments(workId, repairPointId);
                        string newDefectQualifier = pointRepairsRepairDetailsGateway.GetDefectQualifier(workId, repairPointId);
                        string newDefectDetails = pointRepairsRepairDetailsGateway.GetDefectDetails(workId, repairPointId);
                        string newLength = pointRepairsRepairDetailsGateway.GetLength(workId, repairPointId);
                        DateTime? newReinstateDate = null; if (pointRepairsRepairDetailsGateway.GetReinstateDate(workId, repairPointId).HasValue) newReinstateDate = pointRepairsRepairDetailsGateway.GetReinstateDate(workId, repairPointId);

                        WorkPointRepairsRepair workPointRepairsRepair = new WorkPointRepairsRepair(null);
                        workPointRepairsRepair.Updatedirect(workId, repairPointId, type, originalReamDistance, originalReamDate, originalLinerDistance, originalDirection, originalReinstates, originalLtmh, originalVtmh, originalDistance, originalSize_, originalInstallDate, originalMhShot, originalGroutDistance, originalGroutDate, originalApproval, originalExtraRepair, originalCancelled, originalComments, false, companyId, originalDefectQualifier, originalDefectDetails, originalLength, workId, repairPointId, type, newReamDistance, newReamDate, newLinerDistance, newDirection, newReinstates, newLtmh, newVtmh, newDistance, newSize_, newInstallDate, newMhShot, newGroutDistance, newGroutDate, newApproval, newExtraRepair, newCancelled, newComments, false, companyId, newDefectQualifier, newDefectDetails, newLength, originalReinstateDate, newReinstateDate);
                       
                    }

                    // Delete repair
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        string repairPointId = row.RepairPointID;

                        WorkPointRepairsRepair workPointRepairsRepair = new WorkPointRepairsRepair(null);
                        workPointRepairsRepair.DeleteDirect(workId, repairPointId, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// GetMaxRepairPointId
        /// </summary>
        /// <param name="repairType">repairType</param>
        /// <returns>available repair point id</returns>
        public int GetMaxRepairPointId(string repairType)
        {
            int maxRepairPointId = 64;

            foreach (PointRepairsTDS.RepairDetailsRow row in (PointRepairsTDS.RepairDetailsDataTable)Table)
            {
                if (row.Type == repairType)
                {
                    string repairPointId = row.RepairPointID.Substring(row.RepairPointID.Length - 1, 1);
                    int repairPointIdAsci = (int)repairPointId[0];

                    if (repairPointIdAsci >= maxRepairPointId)
                    {
                        maxRepairPointId = repairPointIdAsci;
                    }
                }
            }

            return maxRepairPointId;
        }




        

        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
       
        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Row obtained</returns>
        private PointRepairsTDS.RepairDetailsRow GetRow(int workId, string repairPointId)
        {
            PointRepairsTDS.RepairDetailsRow row = ((PointRepairsTDS.RepairDetailsDataTable)Table).FindByWorkIDRepairPointID(workId, repairPointId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.PointRepairs.PointRepairsRepairDetails.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateForProcess
        /// </summary>
        private void UpdateForProcess()
        {
            // Load comments
            foreach (PointRepairsTDS.RepairDetailsRow row in (PointRepairsTDS.RepairDetailsDataTable)Table)
            {
                PointRepairsRepairDetailsGateway pointRepairsRepairDetailsGateway = new PointRepairsRepairDetailsGateway();
                pointRepairsRepairDetailsGateway.LoadAllByWorkIdRepairPointId(row.WorkID, row.RepairPointID, row.COMPANY_ID);
                row.Comments = pointRepairsRepairDetailsGateway.GetComments(row.WorkID, row.RepairPointID);
            }

            // Format comments
            foreach (PointRepairsTDS.RepairDetailsRow row in (PointRepairsTDS.RepairDetailsDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



    }
}