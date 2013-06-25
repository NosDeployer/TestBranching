using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningInversionFieldCureRecord
    /// </summary>
    class WorkFullLengthLiningInversionFieldCureRecord : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningInversionFieldCureRecord()
            : base("LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningInversionFieldCureRecord(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_INVERSION_FIEL_CURE_RECORD")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect a field cure record
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="readingTime">readingTime</param>
        /// <param name="headFt">headFt</param>
        /// <param name="boilerInF">boilerInF</param>
        /// <param name="boilerOutF">boilerOutF</param>
        /// <param name="pumpFlow">pumpFlow</param>
        /// <param name="pumpPsi">pumpPsi</param>
        /// <param name="mh1Top">mh1Top</param>
        /// <param name="mh1Bot">mh1Bot</param>
        /// <param name="mh2Top">mh2Top</param>
        /// <param name="mh2Bot">mh2Bot</param>
        /// <param name="mh3Top">mh3Top</param>
        /// <param name="mh3Bot">mh3Bot</param>
        /// <param name="mh4Top">mh4Top</param>
        /// <param name="mh4Bot">mh4Bot</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>   
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int workId, int refId, DateTime readingTime, decimal? headFt, decimal? boilerInF, decimal? boilerOutF, decimal? pumpFlow, decimal? pumpPsi, decimal? mh1Top, decimal? mh1Bot, decimal? mh2Top, decimal? mh2Bot, decimal? mh3Top, decimal? mh3Bot, decimal? mh4Top, decimal? mh4Bot, string comments, bool deleted, int companyId)
        {
            WorkFullLengthLiningInversionFieldCureRecordGateway workFullLengthLiningInversionFieldCureRecordGateway = new WorkFullLengthLiningInversionFieldCureRecordGateway(null);
            workFullLengthLiningInversionFieldCureRecordGateway.Insert(workId, refId, readingTime, headFt, boilerInF, boilerOutF, pumpFlow, pumpPsi, mh1Top, mh1Bot, mh2Top, mh2Bot, mh3Top, mh3Bot, mh4Top, mh4Bot, comments, deleted, companyId);
        }


        /// <summary>
        /// UpdateDirect a field cure record
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalReadingTime">originalReadingTime</param>
        /// <param name="originalHeadFt">originalHeadFt</param>
        /// <param name="originalBoilerInF">originalBboilerInF</param>
        /// <param name="originalBoilerOutF">originalBoilerOutF</param>
        /// <param name="originalPumpFlow">originalPumpFlow</param>
        /// <param name="originalPumpPsi">originalPumpPsi</param>
        /// <param name="originalMh1Top">originalMh1Top</param>
        /// <param name="originalMh1Bot">originalMh1Bot</param>
        /// <param name="originalMh2Top">originalMh2Top</param>
        /// <param name="originalMh2Bot">originalMh2Bot</param>
        /// <param name="originalMh3Top">originalMh3Top</param>
        /// <param name="originalMh3Bot">originalMh3Bot</param>
        /// <param name="originalMh4Top">originalMh4Top</param>
        /// <param name="originalMh4Bot">originalMh4Bot</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newReadingTime">newReadingTime</param>
        /// <param name="newHeadFt">newHeadFt</param>
        /// <param name="newBoilerInF">newBboilerInF</param>
        /// <param name="newBoilerOutF">newBoilerOutF</param>
        /// <param name="newPumpFlow">newPumpFlow</param>
        /// <param name="newPumpPsi">newPumpPsi</param>
        /// <param name="newMh1Top">newMh1Top</param>
        /// <param name="newMh1Bot">newMh1Bot</param>
        /// <param name="newMh2Top">newMh2Top</param>
        /// <param name="newMh2Bot">newMh2Bot</param>
        /// <param name="newMh3Top">newMh3Top</param>
        /// <param name="newMh3Bot">newMh3Bot</param>
        /// <param name="newMh4Top">newMh4Top</param>
        /// <param name="newMh4Bot">newMh4Bot</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalWorkId, int originalRefId, DateTime originalReadingTime, decimal? originalHeadFt, decimal? originalBoilerInF, decimal? originalBoilerOutF, decimal? originalPumpFlow, decimal? originalPumpPsi, decimal? originalMh1Top, decimal? originalMh1Bot, decimal? originalMh2Top, decimal? originalMh2Bot, decimal? originalMh3Top, decimal? originalMh3Bot, decimal? originalMh4Top, decimal? originalMh4Bot, string originalComments, bool originalDeleted, int originalCompanyId, int newWorkId, int newRefId, DateTime newReadingTime, decimal? newHeadFt, decimal? newBoilerInF, decimal? newBoilerOutF, decimal? newPumpFlow, decimal? newPumpPsi, decimal? newMh1Top, decimal? newMh1Bot, decimal? newMh2Top, decimal? newMh2Bot, decimal? newMh3Top, decimal? newMh3Bot, decimal? newMh4Top, decimal? newMh4Bot, string newComments, bool newDeleted, int newCompanyId)
        {
            WorkFullLengthLiningInversionFieldCureRecordGateway workFullLengthLiningInversionFieldCureRecordGateway = new WorkFullLengthLiningInversionFieldCureRecordGateway(null);
            workFullLengthLiningInversionFieldCureRecordGateway.Update( originalWorkId,  originalRefId, originalReadingTime,  originalHeadFt,  originalBoilerInF,  originalBoilerOutF,  originalPumpFlow,  originalPumpPsi,  originalMh1Top,  originalMh1Bot,  originalMh2Top,  originalMh2Bot,  originalMh3Top,  originalMh3Bot,  originalMh4Top,  originalMh4Bot,  originalComments,  originalDeleted,  originalCompanyId,  newWorkId,  newRefId, newReadingTime,  newHeadFt,  newBoilerInF,  newBoilerOutF,  newPumpFlow,  newPumpPsi,  newMh1Top,  newMh1Bot,  newMh2Top,  newMh2Bot,  newMh3Top,  newMh3Bot,  newMh4Top,  newMh4Bot,  newComments,  newDeleted,  newCompanyId);
        }
                      
  

        /// <summary>
        /// DeleteDirect a field cure record
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int refId, int companyId)
        {
            WorkFullLengthLiningInversionFieldCureRecordGateway workFullLengthLiningInversionFieldCureRecordGateway = new WorkFullLengthLiningInversionFieldCureRecordGateway(null);
            workFullLengthLiningInversionFieldCureRecordGateway.Delete(workId, refId, companyId);
        }



        /// <summary>
        /// DeleteAllDirect a field cure record
        /// </summary>
        /// <param name="workId">workId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteAllDirect(int workId, int companyId)
        {
            WorkFullLengthLiningInversionFieldCureRecordGateway workFullLengthLiningInversionFieldCureRecordGateway = new WorkFullLengthLiningInversionFieldCureRecordGateway(null);
            workFullLengthLiningInversionFieldCureRecordGateway.DeleteAll(workId, companyId);
        }
        
    }
}

