using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.BL
{
    /// <summary>
    /// ViewFullLengthLiningLfsM2Tables
    /// </summary>
    public class ViewFullLengthLiningLfsM2Tables : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewFullLengthLiningLfsM2Tables()
            : base("LfsM2Tables")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ViewFullLengthLiningLfsM2Tables(DataSet data)
            : base(data, "LfsM2Tables")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ViewFullLengthLiningTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="liveOrAbandoned">liveOrAbandoned</param>
        /// <param name="distanceToCentreOfLateral">distanceToCentreOfLateral</param>
        /// <param name="lateralDiameter">lateralDiameter</param>
        /// <param name="lateralType">lateralType</param>
        /// <param name="dateTimeOpened">dateTimeOpened</param>
        /// <param name="comments">comments</param>
        /// <param name="reverseSetup">reverseSetup</param>
        /// <param name="deleted">deleted</param>
        /// <param name="archived">archived</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(Guid id, int companyId, float? videoDistance, string clockPosition, string liveOrAbandoned, string distanceToCentreOfLateral, string lateralDiameter, string lateralType, string dateTimeOpened, string comments, string reverseSetup, bool deleted, bool archived, bool inDatabase)
        {
            ViewFullLengthLiningTDS.LfsM2TablesRow row = ((ViewFullLengthLiningTDS.LfsM2TablesDataTable)Table).NewLfsM2TablesRow();
            row.ID = id;
            row.RefID = GetNewRefId();            
            row.COMPANY_ID = companyId;
            if (videoDistance.HasValue) row.VideoDistance = (float)videoDistance; else row.SetVideoDistanceNull();
            if (clockPosition != "") row.ClockPosition = clockPosition; else row.SetClockPositionNull();
            if (liveOrAbandoned != "") row.LiveOrAbandoned = liveOrAbandoned; else row.SetLiveOrAbandonedNull();
            if (distanceToCentreOfLateral != "") row.DistanceToCentreOfLateral = distanceToCentreOfLateral; else row.SetDistanceToCentreOfLateralNull();
            if (lateralDiameter != "") row.LateralDiameter = lateralDiameter; else row.SetLateralDiameterNull();
            if (lateralType != "") row.LateralType = lateralType; else row.SetLateralTypeNull();
            if (dateTimeOpened != "") row.DateTimeOpened = dateTimeOpened; else row.SetDateTimeOpenedNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (reverseSetup != "") row.ReverseSetup = reverseSetup; else row.SetReverseSetupNull();
            row.Archived = archived;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;

            ((ViewFullLengthLiningTDS.LfsM2TablesDataTable)Table).AddLfsM2TablesRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="videoDistance">videoDistance</param>
        /// <param name="clockPosition">clockPosition</param>
        /// <param name="liveOrAbandoned">liveOrAbandoned</param>
        /// <param name="distanceToCentreOfLateral">distanceToCentreOfLateral</param>
        /// <param name="lateralDiameter">lateralDiameter</param>
        /// <param name="lateralType">lateralType</param>
        /// <param name="dateTimeOpened">dateTimeOpened</param>
        /// <param name="comments">comments</param>
        /// <param name="reverseSetup">reverseSetup</param>
        public void Update(Guid id, int refId, int companyId, float? videoDistance, string clockPosition, string liveOrAbandoned, string distanceToCentreOfLateral, string lateralDiameter, string lateralType, string dateTimeOpened, string comments, string reverseSetup)
        {
            ViewFullLengthLiningTDS.LfsM2TablesRow row = GetRow(id, refId, companyId);

            if (videoDistance.ToString() != "") row.VideoDistance = (float)videoDistance; else row.SetVideoDistanceNull();
            if (clockPosition != "") row.ClockPosition = clockPosition; else row.SetClockPositionNull();
            if (liveOrAbandoned != "") row.LiveOrAbandoned = liveOrAbandoned; else row.SetLiveOrAbandonedNull();
            if (distanceToCentreOfLateral != "") row.DistanceToCentreOfLateral = distanceToCentreOfLateral; else row.SetDistanceToCentreOfLateralNull();
            if (lateralDiameter != "") row.LateralDiameter = lateralDiameter; else row.SetLateralDiameterNull();
            if (lateralType != "") row.LateralType = lateralType; else row.SetLateralTypeNull();
            if (dateTimeOpened != "") row.DateTimeOpened = dateTimeOpened; else row.SetDateTimeOpenedNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (reverseSetup != "") row.ReverseSetup = reverseSetup; else row.SetReverseSetupNull();
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
            ViewFullLengthLiningTDS.LfsM2TablesRow row = GetRow(id, refId, companyId);
            row.Deleted = true;
        }       



        /// <summary>
        /// Save all to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="newId">newId</param>
        public void Save(int companyId, Guid newId)
        {
            ViewFullLengthLiningTDS lfsM2TablesChanges = (ViewFullLengthLiningTDS)Data.GetChanges();

            if (lfsM2TablesChanges.LfsM2Tables.Rows.Count > 0)
            {
                ViewFullLengthLiningLfsM2TablesGateway viewFullLengthLiningLfsM2TablesGateway = new ViewFullLengthLiningLfsM2TablesGateway(lfsM2TablesChanges);

                foreach (ViewFullLengthLiningTDS.LfsM2TablesRow row in (ViewFullLengthLiningTDS.LfsM2TablesDataTable)lfsM2TablesChanges.LfsM2Tables)
                {
                    // Insert new Notes 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {                        
                        float? videoDistance = null; if (!row.IsVideoDistanceNull()) videoDistance = row.VideoDistance;
                        string clockPosition = ""; if (!row.IsClockPositionNull()) clockPosition = row.ClockPosition;
                        string liveOrAbandoned = ""; if (!row.IsLiveOrAbandonedNull()) liveOrAbandoned = row.LiveOrAbandoned;
                        string distanceToCentreOfLateral = ""; if (!row.IsDistanceToCentreOfLateralNull()) distanceToCentreOfLateral = row.DistanceToCentreOfLateral;
                        string lateralDiameter = ""; if (!row.IsLateralDiameterNull()) lateralDiameter = row.LateralDiameter;
                        string lateralType = ""; if (!row.IsLateralTypeNull()) lateralType = row.LateralType;
                        string dateTimeOpened = ""; if (!row.IsDateTimeOpenedNull()) dateTimeOpened = row.DateTimeOpened;
                        string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                        string reverseSetup = ""; if (!row.IsReverseSetupNull()) reverseSetup = row.ReverseSetup;
                        bool deleted = false;
                        bool archived = row.Archived;

                        LFSRecordM2Tables lfsRecordM2Tables = new LFSRecordM2Tables(null);
                        lfsRecordM2Tables.InsertDirect(newId, row.RefID, row.COMPANY_ID, videoDistance, clockPosition, liveOrAbandoned, distanceToCentreOfLateral, lateralDiameter, lateralType, dateTimeOpened, comments, reverseSetup, deleted, archived);
                    }

                    // Update Notes
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        Guid id = row.ID;
                        int refId = row.RefID;

                        // original values
                        float? originalVideoDistance = viewFullLengthLiningLfsM2TablesGateway.GetVideoDistanceOriginal(id, refId, companyId);
                        string originalClockPosition = viewFullLengthLiningLfsM2TablesGateway.GetClockPositionOriginal(id, refId, companyId);
                        string originalLiveOrAbandoned = viewFullLengthLiningLfsM2TablesGateway.GetLiveOrAbandonedOriginal(id, refId, companyId);
                        string originalDistanceToCentreOfLateral = viewFullLengthLiningLfsM2TablesGateway.GetDistanceToCentreOfLateralOriginal(id, refId, companyId);
                        string originalLateralDiameter = viewFullLengthLiningLfsM2TablesGateway.GetLateralDiameterOriginal(id, refId, companyId);
                        string originalLateralType = viewFullLengthLiningLfsM2TablesGateway.GetLateralTypeOriginal(id, refId, companyId);
                        string originalDateTimeOpened = viewFullLengthLiningLfsM2TablesGateway.GetDateTimeOpenedOriginal(id, refId, companyId);
                        string originalComments = viewFullLengthLiningLfsM2TablesGateway.GetCommentsOriginal(id, refId, companyId);
                        string originalReverseSetup = viewFullLengthLiningLfsM2TablesGateway.GetReverseSetupOriginal(id, refId, companyId);
                        bool originalDeleted = false;
                        bool originalArchived = viewFullLengthLiningLfsM2TablesGateway.GetArchivedOriginal(id, refId, companyId);

                        // new values
                        float? newVideoDistance = viewFullLengthLiningLfsM2TablesGateway.GetVideoDistance(id, refId, companyId);
                        string newClockPosition = viewFullLengthLiningLfsM2TablesGateway.GetClockPosition(id, refId, companyId);
                        string newLiveOrAbandoned = viewFullLengthLiningLfsM2TablesGateway.GetLiveOrAbandoned(id, refId, companyId);
                        string newDistanceToCentreOfLateral = viewFullLengthLiningLfsM2TablesGateway.GetDistanceToCentreOfLateral(id, refId, companyId);
                        string newLateralDiameter = viewFullLengthLiningLfsM2TablesGateway.GetLateralDiameter(id, refId, companyId);
                        string newLateralType = viewFullLengthLiningLfsM2TablesGateway.GetLateralType(id, refId, companyId);
                        string newDateTimeOpened = viewFullLengthLiningLfsM2TablesGateway.GetDateTimeOpened(id, refId, companyId);
                        string newComments = viewFullLengthLiningLfsM2TablesGateway.GetComments(id, refId, companyId);
                        string newReverseSetup = viewFullLengthLiningLfsM2TablesGateway.GetReverseSetup(id, refId, companyId);
                        bool newDeleted = false;
                        bool newArchived = viewFullLengthLiningLfsM2TablesGateway.GetArchived(id, refId, companyId);

                        LFSRecordM2Tables lfsRecordM2Tables = new LFSRecordM2Tables(null);
                        lfsRecordM2Tables.UpdateDirect(id, refId, row.COMPANY_ID, originalVideoDistance, originalClockPosition, originalLiveOrAbandoned, originalDistanceToCentreOfLateral, originalLateralDiameter, originalLateralType, originalDateTimeOpened, originalComments, originalReverseSetup, originalDeleted, originalArchived, id, refId, row.COMPANY_ID, newVideoDistance, newClockPosition, newLiveOrAbandoned, newDistanceToCentreOfLateral, newLateralDiameter, newLateralType, newDateTimeOpened, newComments, newReverseSetup, newDeleted, newArchived);
                    }

                    // Deleted notes 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        LFSRecordM2Tables lfsRecordM2Tables = new LFSRecordM2Tables(null);
                        lfsRecordM2Tables.DeleteDirect(row.ID, row.RefID, row.COMPANY_ID);            
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
        /// <returns>ViewFullLengthLiningTDS.LfsM2TablesRow</returns>
        private ViewFullLengthLiningTDS.LfsM2TablesRow GetRow(Guid id, int refId, int companyId)
        {
            ViewFullLengthLiningTDS.LfsM2TablesRow row = ((ViewFullLengthLiningTDS.LfsM2TablesDataTable)Table).FindByIDRefIDCOMPANY_ID(id, refId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.DatabaseGateway.ViewFullLengthLiningLfsM2Tables.GetRow");
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

            foreach (ViewFullLengthLiningTDS.LfsM2TablesRow row in (ViewFullLengthLiningTDS.LfsM2TablesDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }

    }
}
