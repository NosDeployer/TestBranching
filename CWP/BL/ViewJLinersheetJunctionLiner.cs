using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.CWP.DatabaseGateway;
namespace LiquiForce.LFSLive.CWP.BL
{
    /// <summary>
    /// ViewJLinersheetJunctionLiner
    /// </summary>
    public class ViewJLinersheetJunctionLiner : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewJLinersheetJunctionLiner()
            : base("JunctionLiner")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ViewJLinersheetJunctionLiner(DataSet data)
            : base(data, "JunctionLiner")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ViewJLinersheetTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detailID">detailID</param>
        /// <param name="mn">mn</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="confirmedLatSize">confirmedLatSize</param>
        /// <param name="lateralMaterial">lateralMaterial</param>
        /// <param name="sharedLateral">sharedLateral</param>
        /// <param name="cleanoutRequired">cleanoutRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="mHShot">mHShot</param>
        /// <param name="mainConnection">mainConnection</param>
        /// <param name="transition">transition</param>
        /// <param name="cleanoutInstalled">cleanoutInstalled</param>
        /// <param name="pitInstalled">pitInstalled</param>
        /// <param name="cleanoutGrouted">cleanoutGrouted</param>
        /// <param name="cleanoutCored">cleanoutCored</param>
        /// <param name="prepCompleted">prepCompleted</param>
        /// <param name="measuredLatLength">measuredLatLength</param>
        /// <param name="measurementsTakenBy">measurementsTakenBy</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="restorationComplete">restorationComplete</param>
        /// <param name="linerOrdered">linerOrdered</param>
        /// <param name="linerInStock">linerInStock</param>
        /// <param name="linerPrice">linerPrice</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="archived">archived</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(Guid id, int companyId, string detailID, string mn, double? distanceFromUSMH, string confirmedLatSize, string lateralMaterial, string sharedLateral,  bool cleanoutRequired,  bool pitRequired, bool mHShot, string mainConnection, string transition, bool cleanoutInstalled, bool pitInstalled, bool cleanoutGrouted, bool cleanoutCored, DateTime? prepCompleted, string measuredLatLength, string measurementsTakenBy, DateTime? linerInstalled, DateTime? finalVideo, bool restorationComplete, bool linerOrdered,  bool linerInStock,  decimal? linerPrice, string comments, bool deleted, bool archived, bool inDatabase)
        {
            ViewJLinersheetTDS.JunctionLinerRow row = ((ViewJLinersheetTDS.JunctionLinerDataTable)Table).NewJunctionLinerRow();
            row.ID = id;
            row.RefID = GetNewRefId();            
            row.COMPANY_ID = companyId;
            row.DetailID = detailID; 
            if (mn != "") row.MN = mn; else row.SetMNNull();
            if (distanceFromUSMH.HasValue) row.DistanceFromUSMH = (double)distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (confirmedLatSize != "") row.ConfirmedLatSize = confirmedLatSize; else row.SetConfirmedLatSizeNull();
            if (lateralMaterial != "") row.LateralMaterial = lateralMaterial; else row.SetLateralMaterialNull();
            if (sharedLateral != "") row.SharedLateral = sharedLateral; else row.SetSharedLateralNull();
            row.CleanoutRequired = cleanoutRequired;
            row.PitRequired = pitRequired;
            row.MHShot = mHShot;
            if (mainConnection != "") row.MainConnection = mainConnection; else row.SetMainConnectionNull();
            if (transition != "") row.Transition = transition; else row.SetTransitionNull();
            row.CleanoutInstalled = cleanoutInstalled;
            row.PitInstalled = pitInstalled;
            row.CleanoutGrouted = cleanoutGrouted;
            row.CleanoutCored = cleanoutCored;
            if (prepCompleted.HasValue) row.PrepCompleted = (DateTime)prepCompleted; else row.SetPrepCompletedNull();
            if (measuredLatLength != "") row.MeasuredLatLength = measuredLatLength; else row.SetMeasuredLatLengthNull();
            if (measurementsTakenBy != "") row.MeasurementsTakenBy = measurementsTakenBy; else row.SetMeasurementsTakenByNull();
            if (linerInstalled.HasValue) row.LinerInstalled = (DateTime)linerInstalled; else row.SetLinerInstalledNull();
            if (finalVideo.HasValue) row.FinalVideo = (DateTime)finalVideo; else row.SetFinalVideoNull();
            row.RestorationComplete = restorationComplete;
            row.LinerOrdered = linerOrdered;
            row.LinerInStock = linerInStock;
            if (linerPrice.HasValue) row.LinerPrice = (decimal)linerPrice; else row.SetLinerPriceNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            row.Deleted = deleted;
            row.Archived = archived;
            row.InDatabase = inDatabase;

            ((ViewJLinersheetTDS.JunctionLinerDataTable)Table).AddJunctionLinerRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>       
        /// <param name="mn">mn</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="confirmedLatSize">confirmedLatSize</param>
        /// <param name="lateralMaterial">lateralMaterial</param>
        /// <param name="sharedLateral">sharedLateral</param>
        /// <param name="cleanoutRequired">cleanoutRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="mHShot">mHShot</param>
        /// <param name="mainConnection">mainConnection</param>
        /// <param name="transition">transition</param>
        /// <param name="cleanoutInstalled">cleanoutInstalled</param>
        /// <param name="pitInstalled">pitInstalled</param>
        /// <param name="cleanoutGrouted">cleanoutGrouted</param>
        /// <param name="cleanoutCored">cleanoutCored</param>
        /// <param name="prepCompleted">prepCompleted</param>
        /// <param name="measuredLatLength">measuredLatLength</param>
        /// <param name="measurementsTakenBy">measurementsTakenBy</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="restorationComplete">restorationComplete</param>
        /// <param name="linerOrdered">linerOrdered</param>
        /// <param name="linerInStock">linerInStock</param>
        /// <param name="linerPrice">linerPrice</param>
        /// <param name="comments">comments</param>
        public void Update(Guid id, int refId, int companyId, string mn, double? distanceFromUSMH, string confirmedLatSize, string lateralMaterial, string sharedLateral, bool cleanoutRequired, bool pitRequired, bool mHShot, string mainConnection, string transition, bool cleanoutInstalled, bool pitInstalled, bool cleanoutGrouted, bool cleanoutCored, DateTime? prepCompleted, string measuredLatLength, string measurementsTakenBy, DateTime? linerInstalled, DateTime? finalVideo, bool restorationComplete, bool linerOrdered, bool linerInStock, decimal? linerPrice, string comments)
        {
            ViewJLinersheetTDS.JunctionLinerRow row = GetRow(id, refId, companyId);

            if (mn != "") row.MN = mn; else row.SetMNNull();
            if (distanceFromUSMH.HasValue) row.DistanceFromUSMH = (double)distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (confirmedLatSize != "") row.ConfirmedLatSize = confirmedLatSize; else row.SetConfirmedLatSizeNull();
            if (lateralMaterial != "") row.LateralMaterial = lateralMaterial; else row.SetLateralMaterialNull();
            if (sharedLateral != "") row.SharedLateral = sharedLateral; else row.SetSharedLateralNull();
            row.CleanoutRequired = cleanoutRequired;
            row.PitRequired = pitRequired;
            row.MHShot = mHShot;
            if (mainConnection != "") row.MainConnection = mainConnection; else row.SetMainConnectionNull();
            if (transition != "") row.Transition = transition; else row.SetTransitionNull();
            row.CleanoutInstalled = cleanoutInstalled;
            row.PitInstalled = pitInstalled;
            row.CleanoutGrouted = cleanoutGrouted;
            row.CleanoutCored = cleanoutCored;
            if (prepCompleted.HasValue) row.PrepCompleted = (DateTime)prepCompleted; else row.SetPrepCompletedNull();
            if (measuredLatLength != "") row.MeasuredLatLength = measuredLatLength; else row.SetMeasuredLatLengthNull();
            if (measurementsTakenBy != "") row.MeasurementsTakenBy = measurementsTakenBy; else row.SetMeasurementsTakenByNull();
            if (linerInstalled.HasValue) row.LinerInstalled = (DateTime)linerInstalled; else row.SetLinerInstalledNull();
            if (finalVideo.HasValue) row.FinalVideo = (DateTime)finalVideo; else row.SetFinalVideoNull();
            row.RestorationComplete = restorationComplete;
            row.LinerOrdered = linerOrdered;
            row.LinerInStock = linerInStock;
            if (linerPrice.HasValue) row.LinerPrice = (decimal)linerPrice; else row.SetLinerPriceNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
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
            ViewJLinersheetTDS.JunctionLinerRow row = GetRow(id, refId, companyId);
            row.Deleted = true;
        }



        /// <summary>
        /// GetNewDetailId
        /// </summary>
        /// <remarks> Gets a new DetailID to insert a new lfs juntion liner record</remarks>        
        public string GetNewDetailId(ViewJLinersheetTDS viewJLinersheetTDS)
        {
            string detailIDs = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string newDetailID;
            int lastDetailIDIndex = -1;

            foreach (ViewJLinersheetTDS.JunctionLinerRow row in viewJLinersheetTDS.JunctionLiner)
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




        /// <summary>
        /// Save all to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="newId">newId</param>
        public void Save(int companyId, Guid newId)
        {
            ViewJLinersheetTDS jlinerChanges = (ViewJLinersheetTDS)Data.GetChanges();

            if (jlinerChanges.JunctionLiner.Rows.Count > 0)
            {
                ViewJLinersheetJunctionLinerGateway viewJLinersheetJunctionLinerGateway = new ViewJLinersheetJunctionLinerGateway(jlinerChanges);

                foreach (ViewJLinersheetTDS.JunctionLinerRow row in (ViewJLinersheetTDS.JunctionLinerDataTable)jlinerChanges.JunctionLiner)
                {
                    // Insert new Notes 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string mn = ""; if (!row.IsMNNull()) mn = row.MN;
                        double? distanceFromUSMH = null; if (!row.IsDistanceFromUSMHNull()) distanceFromUSMH = (double)row.DistanceFromUSMH;
                        string confirmedLatSize = ""; if (!row.IsConfirmedLatSizeNull()) confirmedLatSize = row.ConfirmedLatSize;
                        string lateralMaterial = ""; if (!row.IsLateralMaterialNull()) lateralMaterial = row.LateralMaterial;
                        string sharedLateral = ""; if (!row.IsSharedLateralNull()) sharedLateral = row.SharedLateral;
                        bool cleanoutRequired = row.CleanoutRequired;
                        bool pitRequired = row.PitRequired;
                        bool mHShot = row.MHShot;
                        string mainConnection = ""; if (!row.IsMainConnectionNull()) mainConnection = row.MainConnection;
                        string transition = ""; if (!row.IsTransitionNull()) transition = row.Transition;
                        bool cleanoutInstalled = row.CleanoutInstalled;
                        bool pitInstalled = row.PitInstalled;
                        bool cleanoutGrouted = row.CleanoutGrouted;
                        bool cleanoutCored = row.CleanoutCored;
                        DateTime? prepCompleted = null; if (!row.IsPrepCompletedNull()) prepCompleted = (DateTime)row.PrepCompleted;
                        string measuredLatLength = ""; if (!row.IsMeasuredLatLengthNull()) measuredLatLength = row.MeasuredLatLength;
                        string measurementsTakenBy = ""; if (!row.IsMeasurementsTakenByNull()) measurementsTakenBy = row.MeasurementsTakenBy;
                        DateTime? linerInstalled = null; if (!row.IsLinerInstalledNull()) linerInstalled = (DateTime)row.LinerInstalled;
                        DateTime? finalVideo = null; if (!row.IsFinalVideoNull()) finalVideo = (DateTime)row.FinalVideo;
                        bool restorationComplete = row.RestorationComplete;
                        bool linerOrdered = row.LinerOrdered;
                        bool linerInStock = row.LinerInStock;
                        decimal? linerPrice = null; if (!row.IsLinerPriceNull()) linerPrice = (decimal)row.LinerPrice;                        
                        string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                        bool deleted = false;
                        bool archived = row.Archived;

                        LFSRecordJuntionLiner lfsRecordJuntionLiner = new LFSRecordJuntionLiner(null);
                        lfsRecordJuntionLiner.InsertDirect(newId, row.RefID, row.COMPANY_ID, row.DetailID, mn, distanceFromUSMH, confirmedLatSize, lateralMaterial, sharedLateral, cleanoutRequired, pitRequired, mHShot , mainConnection, transition, cleanoutInstalled, pitInstalled, cleanoutGrouted, cleanoutCored, prepCompleted, measuredLatLength, measurementsTakenBy, linerInstalled, finalVideo, restorationComplete, linerOrdered, linerInStock, linerPrice, comments, deleted, archived);
                    }

                    // Update Notes
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        Guid id = row.ID;
                        int refId = row.RefID;

                        // original values
                        string originalMn = viewJLinersheetJunctionLinerGateway.GetMNOriginal(id, refId, companyId);
                        double? originalDistanceFromUSMH = viewJLinersheetJunctionLinerGateway.GetDistanceFromUSMHOriginal(id, refId, companyId);
                        string originalConfirmedLatSize = viewJLinersheetJunctionLinerGateway.GetConfirmedLatSizeOriginal(id, refId, companyId);
                        string originalLateralMaterial = viewJLinersheetJunctionLinerGateway.GetLateralMaterialOriginal(id, refId, companyId);
                        string originalSharedLateral = viewJLinersheetJunctionLinerGateway.GetSharedLateralOriginal(id, refId, companyId);
                        bool originalCleanoutRequired = viewJLinersheetJunctionLinerGateway.GetCleanoutRequiredOriginal(id, refId, companyId);
                        bool originalPitRequired = viewJLinersheetJunctionLinerGateway.GetPitRequiredOriginal(id, refId, companyId);
                        bool originalMHShot = viewJLinersheetJunctionLinerGateway.GetMHShotOriginal(id, refId, companyId);
                        string originalMainConnection = viewJLinersheetJunctionLinerGateway.GetMainConnectionOriginal(id, refId, companyId);
                        string originalTransition = viewJLinersheetJunctionLinerGateway.GetTransitionOriginal(id, refId, companyId);
                        bool originalCleanoutInstalled = viewJLinersheetJunctionLinerGateway.GetCleanoutInstalledOriginal(id, refId, companyId);
                        bool originalPitInstalled = viewJLinersheetJunctionLinerGateway.GetPitInstalledOriginal(id, refId, companyId);
                        bool originalCleanoutGrouted = viewJLinersheetJunctionLinerGateway.GetCleanoutGroutedOriginal(id, refId, companyId);
                        bool originalCleanoutCored = viewJLinersheetJunctionLinerGateway.GetCleanoutCoredOriginal(id, refId, companyId);
                        DateTime? originalPrepCompleted = viewJLinersheetJunctionLinerGateway.GetPrepCompletedOriginal(id, refId, companyId);
                        string originalMeasuredLatLength = viewJLinersheetJunctionLinerGateway.GetMeasuredLatLengthOriginal(id, refId, companyId);
                        string originalMeasurementsTakenBy = viewJLinersheetJunctionLinerGateway.GetMeasurementsTakenByOriginal(id, refId, companyId);
                        DateTime? originalLinerInstalled = viewJLinersheetJunctionLinerGateway.GetLinerInstalledOriginal(id, refId, companyId);
                        DateTime? originalFinalVideo = viewJLinersheetJunctionLinerGateway.GetFinalVideoOriginal(id, refId, companyId);
                        bool originalRestorationComplete = viewJLinersheetJunctionLinerGateway.GetRestorationCompleteOriginal(id, refId, companyId);
                        bool originalLinerOrdered = viewJLinersheetJunctionLinerGateway.GetLinerOrderedOriginal(id, refId, companyId);
                        bool originalLinerInStock = viewJLinersheetJunctionLinerGateway.GetLinerInStockOriginal(id, refId, companyId);
                        decimal? originalLinerPrice = viewJLinersheetJunctionLinerGateway.GetLinerPriceOriginal(id, refId, companyId);
                        string originalComments = viewJLinersheetJunctionLinerGateway.GetCommentsOriginal(id, refId, companyId);
                        bool originalDeleted = false;
                        bool originalArchived = viewJLinersheetJunctionLinerGateway.GetArchivedOriginal(id, refId, companyId);

                        // new values
                        string newMn = viewJLinersheetJunctionLinerGateway.GetMN(id, refId, companyId);
                        double? newDistanceFromUSMH = viewJLinersheetJunctionLinerGateway.GetDistanceFromUSMH(id, refId, companyId);
                        string newConfirmedLatSize = viewJLinersheetJunctionLinerGateway.GetConfirmedLatSize(id, refId, companyId);
                        string newLateralMaterial = viewJLinersheetJunctionLinerGateway.GetLateralMaterial(id, refId, companyId);
                        string newSharedLateral = viewJLinersheetJunctionLinerGateway.GetSharedLateral(id, refId, companyId);
                        bool newCleanoutRequired = viewJLinersheetJunctionLinerGateway.GetCleanoutRequired(id, refId, companyId);
                        bool newPitRequired = viewJLinersheetJunctionLinerGateway.GetPitRequired(id, refId, companyId);
                        bool newMHShot = viewJLinersheetJunctionLinerGateway.GetMHShot(id, refId, companyId);
                        string newMainConnection = viewJLinersheetJunctionLinerGateway.GetMainConnection(id, refId, companyId);
                        string newTransition = viewJLinersheetJunctionLinerGateway.GetTransition(id, refId, companyId);
                        bool newCleanoutInstalled = viewJLinersheetJunctionLinerGateway.GetCleanoutInstalled(id, refId, companyId);
                        bool newPitInstalled = viewJLinersheetJunctionLinerGateway.GetPitInstalled(id, refId, companyId);
                        bool newCleanoutGrouted = viewJLinersheetJunctionLinerGateway.GetCleanoutGrouted(id, refId, companyId);
                        bool newCleanoutCored = viewJLinersheetJunctionLinerGateway.GetCleanoutCored(id, refId, companyId);
                        DateTime? newPrepCompleted = viewJLinersheetJunctionLinerGateway.GetPrepCompleted(id, refId, companyId);
                        string newMeasuredLatLength = viewJLinersheetJunctionLinerGateway.GetMeasuredLatLength(id, refId, companyId);
                        string newMeasurementsTakenBy = viewJLinersheetJunctionLinerGateway.GetMeasurementsTakenBy(id, refId, companyId);
                        DateTime? newLinerInstalled = viewJLinersheetJunctionLinerGateway.GetLinerInstalled(id, refId, companyId);
                        DateTime? newFinalVideo = viewJLinersheetJunctionLinerGateway.GetFinalVideo(id, refId, companyId);
                        bool newRestorationComplete = viewJLinersheetJunctionLinerGateway.GetRestorationComplete(id, refId, companyId);
                        bool newLinerOrdered = viewJLinersheetJunctionLinerGateway.GetLinerOrdered(id, refId, companyId);
                        bool newLinerInStock = viewJLinersheetJunctionLinerGateway.GetLinerInStock(id, refId, companyId);
                        decimal? newLinerPrice = viewJLinersheetJunctionLinerGateway.GetLinerPrice(id, refId, companyId);
                        string newComments = viewJLinersheetJunctionLinerGateway.GetComments(id, refId, companyId);
                        bool newDeleted = false;
                        bool newArchived = viewJLinersheetJunctionLinerGateway.GetArchived(id, refId, companyId);

                        LFSRecordJuntionLiner lfsRecordJuntionLiner = new LFSRecordJuntionLiner(null);
                        lfsRecordJuntionLiner.UpdateDirect(id, refId, row.COMPANY_ID, row.DetailID, originalMn, originalDistanceFromUSMH, originalConfirmedLatSize, originalLateralMaterial, originalSharedLateral, originalCleanoutRequired, originalPitRequired, originalMHShot, originalMainConnection, originalTransition, originalCleanoutInstalled, originalPitInstalled, originalCleanoutGrouted, originalCleanoutCored, originalPrepCompleted, originalMeasuredLatLength, originalMeasurementsTakenBy, originalLinerInstalled, originalFinalVideo, originalRestorationComplete, originalLinerOrdered, originalLinerInStock, originalLinerPrice, originalComments, originalDeleted, originalArchived, id, refId, row.COMPANY_ID, row.DetailID, newMn, newDistanceFromUSMH, newConfirmedLatSize, newLateralMaterial, newSharedLateral, newCleanoutRequired, newPitRequired, newMHShot, newMainConnection, newTransition, newCleanoutInstalled, newPitInstalled, newCleanoutGrouted, newCleanoutCored, newPrepCompleted, newMeasuredLatLength, newMeasurementsTakenBy, newLinerInstalled, newFinalVideo, newRestorationComplete, newLinerOrdered, newLinerInStock, newLinerPrice, newComments, newDeleted, newArchived);
                    }

                    // Deleted notes 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        LFSRecordJuntionLiner lfsRecordJuntionLiner = new LFSRecordJuntionLiner(null);
                        lfsRecordJuntionLiner.DeleteDirect(row.ID, row.RefID, row.COMPANY_ID);            
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
        /// <returns>ViewJLinersheetTDS.JunctionLinerRow</returns>
        private ViewJLinersheetTDS.JunctionLinerRow GetRow(Guid id, int refId, int companyId)
        {
            ViewJLinersheetTDS.JunctionLinerRow row = ((ViewJLinersheetTDS.JunctionLinerDataTable)Table).FindByIDRefIDCOMPANY_ID(id, refId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.DatabaseGateway.ViewJlinersheetJunctionLiner.GetRow");
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

            foreach (ViewJLinersheetTDS.JunctionLinerRow row in (ViewJLinersheetTDS.JunctionLinerDataTable)Table)
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
