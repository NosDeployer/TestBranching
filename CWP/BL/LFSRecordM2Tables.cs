using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.CWP.BL
{
    /// <summary>
    /// LFSRecordM2Tables
    /// </summary>
    public class LFSRecordM2Tables : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LFSRecordM2Tables()
            : base("LFS_M2_TABLES")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LFSRecordM2Tables(DataSet data)
            : base(data, "LFS_M2_TABLES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TDSLFSRecord();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Insert a new row (direct to DB)
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
        /// <param name="deleted">deleted</param>
        /// <param name="archived">archived</param>
        public void InsertDirect(Guid id, int refId, int companyId, float? videoDistance, string clockPosition, string liveOrAbandoned, string distanceToCentreOfLateral, string lateralDiameter, string lateralType, string dateTimeOpened, string comments, string reverseSetup, bool deleted, bool archived)
        {
            LFSRecordM2TablesGateway lfsRecordM2TablesGateway = new LFSRecordM2TablesGateway();
            lfsRecordM2TablesGateway.Insert(id, refId, companyId, videoDistance, clockPosition, liveOrAbandoned, distanceToCentreOfLateral, lateralDiameter, lateralType, dateTimeOpened, comments, reverseSetup, deleted, archived);
        }



        /// <summary>
        /// Update a new repair (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>     
        /// <param name="originalVideoDistance">originalVideoDistance</param>
        /// <param name="originalClockPosition">originalClockPosition</param>
        /// <param name="originalLiveOrAbandoned">originalLiveOrAbandoned</param>
        /// <param name="originalDistanceToCentreOfLateral">originalDistanceToCentreOfLateral</param>
        /// <param name="originalLateralDiameter">originalLateralDiameter</param>
        /// <param name="originalLateralType">originalLateralType</param>
        /// <param name="originalDateTimeOpened">originalDateTimeOpened</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalReverseSetup">originalReverseSetup</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalArchived">originalArchived</param>
        /// 
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param> 
        /// <param name="newVideoDistance">newVideoDistance</param>
        /// <param name="newClockPosition">newClockPosition</param>
        /// <param name="newLiveOrAbandoned">newLiveOrAbandoned</param>
        /// <param name="newDistanceToCentreOfLateral">newDistanceToCentreOfLateral</param>
        /// <param name="newLateralDiameter">newLateralDiameter</param>
        /// <param name="newLateralType">newLateralType</param>
        /// <param name="newDateTimeOpened">newDateTimeOpened</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newReverseSetup">newReverseSetup</param>  
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newArchived">newArchived</param>
        public void UpdateDirect(Guid originalId, int originalRefId, int originalCompanyId,  float? originalVideoDistance, string originalClockPosition, string originalLiveOrAbandoned, string originalDistanceToCentreOfLateral, string originalLateralDiameter, string originalLateralType, string originalDateTimeOpened, string originalComments, string originalReverseSetup,   bool originalDeleted, bool originalArchived,  Guid newId, int newRefId, int newCompanyId, float? newVideoDistance, string newClockPosition, string newLiveOrAbandoned, string newDistanceToCentreOfLateral, string newLateralDiameter, string newLateralType, string newDateTimeOpened, string newComments, string newReverseSetup,   bool newDeleted, bool newArchived)
        {
            LFSRecordM2TablesGateway lfsRecordM2TablesGateway = new LFSRecordM2TablesGateway();
            lfsRecordM2TablesGateway.Update(originalId, originalRefId, originalCompanyId, originalVideoDistance, originalClockPosition, originalLiveOrAbandoned, originalDistanceToCentreOfLateral, originalLateralDiameter, originalLateralType, originalDateTimeOpened, originalComments, originalReverseSetup, originalDeleted, originalArchived, newId, newRefId, newCompanyId, newVideoDistance, newClockPosition, newLiveOrAbandoned, newDistanceToCentreOfLateral, newLateralDiameter, newLateralType, newDateTimeOpened, newComments, newReverseSetup, newDeleted, newArchived);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(Guid id, int refId, int companyId)
        {
            LFSRecordM2TablesGateway lfsRecordM2TablesGateway = new LFSRecordM2TablesGateway();
            lfsRecordM2TablesGateway.Delete(id, refId, companyId);
        }

    }
}
