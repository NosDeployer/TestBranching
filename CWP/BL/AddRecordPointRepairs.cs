using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.BL
{
    /// <summary>
    /// AddRecordPointRepairs
    /// </summary>
    public class AddRecordPointRepairs : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AddRecordPointRepairs()
            : base("PointRepairs")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AddRecordPointRepairs(DataSet data)
            : base(data, "PointRepairs")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new AddRecordTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="repairSize">repairSize</param>
        /// <param name="installDate">installDate</param>
        /// <param name="distance">distance</param>
        /// <param name="cost">cost</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="ltAtMh">ltAtMh</param>
        /// <param name="vtAtMh">vtAtMh</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="approved">approved</param>
        /// <param name="notApproved">notApproved</param>
        /// <param name="archived">archived</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="addRecordTDS">addRecordTDS</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(Guid id, string repairSize, DateTime? installDate, string distance, decimal? cost, int? reinstates, string ltAtMh, string vtAtMh, string linerDistance, string direction, string mhShot, string comments, bool deleted, bool extraRepair, bool cancelled, bool approved, bool notApproved, bool archived, int companyId, AddRecordTDS addRecordTDS, bool inDatabase)
        {
            AddRecordTDS.PointRepairsRow row = ((AddRecordTDS.PointRepairsDataTable)Table).NewPointRepairsRow();
            row.ID = id;
            row.RefID = GetNewRefId();            
            row.COMPANY_ID = companyId;
            row.DetailID = GetNewPointRepairsDetailId(addRecordTDS);
            row.RepairSize = repairSize;
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.IsInstallDateNull();
            row.Distance = distance;
            if (cost.HasValue) row.Cost = (decimal)cost; else row.IsCostNull();
            if (reinstates.HasValue) row.Reinstates = (int)reinstates; else row.IsReinstatesNull();
            row.LTAtMH = ltAtMh;
            row.VTAtMH = vtAtMh;
            row.LinerDistance = linerDistance;
            row.Direction = direction;
            row.MHShot = mhShot;
            row.Comments = comments;
            row.Deleted = deleted;
            row.ExtraRepair = extraRepair;
            row.Cancelled = cancelled;
            row.Approved = approved;
            row.NotApproved = notApproved;
            row.Archived = archived;
            row.InDatabase = inDatabase;

            ((AddRecordTDS.PointRepairsDataTable)Table).AddPointRepairsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="repairSize">repairSize</param>
        /// <param name="installDate">installDate</param>
        /// <param name="distance">distance</param>
        /// <param name="cost">cost</param>
        /// <param name="reinstates">reinstates</param>
        public void Update(Guid id, int refId, int companyId,  string repairSize, DateTime? installDate, string distance, decimal? cost, int? reinstates)
        {
            AddRecordTDS.PointRepairsRow row = GetRow(id, refId, companyId);

            if (distance != "") row.Distance = distance; else row.SetDistanceNull();
            if (repairSize != "") row.RepairSize = repairSize; else row.SetRepairSizeNull();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();                        
            if (reinstates.HasValue) row.Reinstates = (int)reinstates; else row.SetReinstatesNull();
            if (cost.HasValue) row.Cost = (decimal)cost; else row.SetCostNull();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="ltMh">ltMh</param>
        /// <param name="vtMh">vtMh</param>                
        /// <param name="installDate">installDate</param>
        /// <param name="distance">distance</param>
        /// <param name="size">size</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cacelled">cacelled</param>        
        /// <param name="approved">approved</param>
        /// <param name="notApproved">notApproved</param>
        public void Update(Guid id, int refId, int companyId, string linerDistance, string direction, int? reinstates, string ltMh, string vtMh, DateTime? installDate, string distance, string size, string mhShot, bool extraRepair, bool cancelled, bool approved, bool notApproved)
        {
            AddRecordTDS.PointRepairsRow row = GetRow(id, refId, companyId);

            if (linerDistance != "") row.LinerDistance = linerDistance; else row.SetLinerDistanceNull();
            if (direction != "") row.Direction = direction; else row.SetDirectionNull();
            if (reinstates.HasValue) row.Reinstates = (int)reinstates; else row.SetReinstatesNull();
            if (ltMh != "") row.LTAtMH = ltMh; else row.SetLTAtMHNull();
            if (vtMh != "") row.VTAtMH = vtMh; else row.SetVTAtMHNull();
            if (installDate.HasValue) row.InstallDate = (DateTime)installDate; else row.SetInstallDateNull();
            if (distance != "") row.Distance = distance; else row.SetDistanceNull();
            if (size != "") row.RepairSize = size; else row.SetRepairSizeNull();
            if (mhShot != "") row.MHShot = mhShot; else row.SetMHShotNull();
            row.ExtraRepair = extraRepair;
            row.Cancelled = cancelled;
            row.Approved = approved;
            row.NotApproved = notApproved;
        }



        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public void Delete(Guid id, int refId, int companyId)
        {
            AddRecordTDS.PointRepairsRow row = GetRow(id, refId, companyId);
            row.Deleted = true;
        }       



        /// <summary>
        /// Save all PR to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="newId">newId</param>
        public void Save(int companyId, Guid newId)
        {
            AddRecordTDS pointRepairsChanges = (AddRecordTDS)Data.GetChanges();

            if (pointRepairsChanges != null)
            {
                if (pointRepairsChanges.PointRepairs.Rows.Count > 0)
                {
                    AddRecordPointRepairsGateway addRecordPointRepairsGateway = new AddRecordPointRepairsGateway(pointRepairsChanges);

                    foreach (AddRecordTDS.PointRepairsRow row in (AddRecordTDS.PointRepairsDataTable)pointRepairsChanges.PointRepairs)
                    {
                        // Insert new Notes 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            string repairSize = ""; if (!row.IsRepairSizeNull()) repairSize = row.RepairSize;
                            DateTime? installDate = null; if (!row.IsInstallDateNull()) installDate = row.InstallDate;
                            string distance = ""; if (!row.IsDistanceNull()) distance = row.Distance;
                            decimal? cost = null; if (!row.IsCostNull()) cost = row.Cost;
                            int? reinstates = null; if (!row.IsReinstatesNull()) reinstates = row.Reinstates;
                            string ltatMh = ""; if (!row.IsLTAtMHNull()) ltatMh = row.LTAtMH;
                            string vtatMh = ""; if (!row.IsVTAtMHNull()) vtatMh = row.VTAtMH;
                            string linerDistance = ""; if (!row.IsLinerDistanceNull()) linerDistance = row.LinerDistance;
                            string direction = ""; if (!row.IsDirectionNull()) direction = row.Direction;
                            string mhShot = ""; if (!row.IsMHShotNull()) mhShot = row.MHShot;
                            string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;

                            LFSRecordPointRepairs lfsRecordPointRepairs = new LFSRecordPointRepairs(null);
                            lfsRecordPointRepairs.InsertDirect(newId, row.RefID, row.COMPANY_ID, row.DetailID, repairSize, installDate, distance, cost, reinstates, ltatMh, vtatMh, linerDistance, direction, mhShot, comments, row.Deleted, row.ExtraRepair, row.Cancelled, row.Approved, row.NotApproved, row.Archived);
                        }

                        // Update Notes
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            Guid id = row.ID;
                            int refId = row.RefID;

                            // original values
                            string originalDetailId = addRecordPointRepairsGateway.GetDetailIDOriginal(id, refId, companyId);
                            string originalRepairSize = addRecordPointRepairsGateway.GetRepairSizeOriginal(id, refId, companyId);
                            DateTime? originalInstallDate = addRecordPointRepairsGateway.GetInstallDateOriginal(id, refId, companyId);
                            string originalDistance = addRecordPointRepairsGateway.GetDistanceOriginal(id, refId, companyId);
                            decimal? originalCost = addRecordPointRepairsGateway.GetCostOriginal(id, refId, companyId);
                            int? originalReinstates = addRecordPointRepairsGateway.GetReinstatesOriginal(id, refId, companyId);
                            string originalLTAtMH = addRecordPointRepairsGateway.GetLTAtMHOriginal(id, refId, companyId);
                            string originalVTAtMH = addRecordPointRepairsGateway.GetVTAtMHOriginal(id, refId, companyId);
                            string originalLinerDistance = addRecordPointRepairsGateway.GetLinerDistanceOriginal(id, refId, companyId);
                            string originalDirection = addRecordPointRepairsGateway.GetDirectionOriginal(id, refId, companyId);
                            string originalMhShot = addRecordPointRepairsGateway.GetMHShotOriginal(id, refId, companyId);
                            string originalComments = addRecordPointRepairsGateway.GetCommentsOriginal(id, refId, companyId);
                            bool originalDeleted = false;
                            bool originalExtraRepair = addRecordPointRepairsGateway.GetExtraRepairOriginal(id, refId, companyId);
                            bool originalCancelled = addRecordPointRepairsGateway.GetCancelledOriginal(id, refId, companyId);
                            bool originalApproved = addRecordPointRepairsGateway.GetApprovedOriginal(id, refId, companyId);
                            bool originalNotApproved = addRecordPointRepairsGateway.GetNotApprovedOriginal(id, refId, companyId);
                            bool originalArchived = addRecordPointRepairsGateway.GetArchivedOriginal(id, refId, companyId);

                            // new values
                            string newDetailId = addRecordPointRepairsGateway.GetDetailID(id, refId, companyId);
                            string newRepairSize = addRecordPointRepairsGateway.GetRepairSize(id, refId, companyId);
                            DateTime? newInstallDate = addRecordPointRepairsGateway.GetInstallDate(id, refId, companyId);
                            string newDistance = addRecordPointRepairsGateway.GetDistance(id, refId, companyId);
                            decimal? newCost = addRecordPointRepairsGateway.GetCost(id, refId, companyId);
                            int? newReinstates = addRecordPointRepairsGateway.GetReinstates(id, refId, companyId);
                            string newLTAtMH = addRecordPointRepairsGateway.GetLTAtMH(id, refId, companyId);
                            string newVTAtMH = addRecordPointRepairsGateway.GetVTAtMH(id, refId, companyId);
                            string newLinerDistance = addRecordPointRepairsGateway.GetLinerDistance(id, refId, companyId);
                            string newDirection = addRecordPointRepairsGateway.GetDirection(id, refId, companyId);
                            string newMhShot = addRecordPointRepairsGateway.GetMHShot(id, refId, companyId);
                            string newComments = addRecordPointRepairsGateway.GetComments(id, refId, companyId);
                            bool newDeleted = false;
                            bool newExtraRepair = addRecordPointRepairsGateway.GetExtraRepair(id, refId, companyId);
                            bool newCancelled = addRecordPointRepairsGateway.GetCancelled(id, refId, companyId);
                            bool newApproved = addRecordPointRepairsGateway.GetApproved(id, refId, companyId);
                            bool newNotApproved = addRecordPointRepairsGateway.GetNotApproved(id, refId, companyId);
                            bool newArchived = addRecordPointRepairsGateway.GetArchived(id, refId, companyId);

                            LFSRecordPointRepairs lfsRecordPointRepairs = new LFSRecordPointRepairs(null);
                            lfsRecordPointRepairs.UpdateDirect(id, refId, companyId, originalDetailId, originalRepairSize, originalInstallDate, originalDistance, originalCost, originalReinstates, originalLTAtMH, originalVTAtMH, originalLinerDistance, originalDirection, originalMhShot, originalComments, originalDeleted, originalExtraRepair, originalCancelled, originalApproved, originalNotApproved, originalArchived, id, refId, companyId, newDetailId, newRepairSize, newInstallDate, newDistance, newCost, newReinstates, newLTAtMH, newVTAtMH, newLinerDistance, newDirection, newMhShot, newComments, newDeleted, newExtraRepair, newCancelled, newApproved, newNotApproved, newArchived);
                        }

                        // Deleted notes 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            LFSRecordPointRepairs lfsRecordPointRepairs = new LFSRecordPointRepairs(null);
                            lfsRecordPointRepairs.DeleteDirect(row.ID, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>AddRecordTDS.PointRepairsRow</returns>
        private AddRecordTDS.PointRepairsRow GetRow(Guid id, int refId, int companyId)
        {
            AddRecordTDS.PointRepairsRow row = ((AddRecordTDS.PointRepairsDataTable)Table).FindByIDRefIDCOMPANY_ID(id, refId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.BL.AddRecordPointRepairs.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (AddRecordTDS.PointRepairsRow row in (AddRecordTDS.PointRepairsDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        public string GetNewPointRepairsDetailId(AddRecordTDS addRecordTDS)
        {
            string detailIDs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string newDetailID;
            int lastDetailIDIndex = -1;

            foreach (AddRecordTDS.PointRepairsRow row in addRecordTDS.PointRepairs)
            {
                if (row.Deleted == false)
                {
                    int rowIndex = detailIDs.IndexOf(row.DetailID);
                    if (lastDetailIDIndex < rowIndex)
                    {
                        lastDetailIDIndex = rowIndex;
                    }
                }
            }

            if (lastDetailIDIndex < 25)
            {
                lastDetailIDIndex++;
                newDetailID = detailIDs[lastDetailIDIndex].ToString();
            }
            else
            {
                newDetailID = "-1";
            }

            return newDetailID;
        }

        

    }
}
