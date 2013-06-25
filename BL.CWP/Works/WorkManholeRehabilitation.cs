using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkManholeRehabilitation
    /// </summary>
    public class WorkManholeRehabilitation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkManholeRehabilitation()
            : base("LFS_WORK_MANHOLE_REHABILITATION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkManholeRehabilitation(DataSet data)
            : base(data, "LFS_WORK_MANHOLE_REHABILITATION")
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
        /// InsertDirect a rehabilitation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="preppredDate">preppredDate</param>
        /// <param name="sprayedDate">sprayedDate</param>
        /// <param name="batchId">batchId</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int workId, DateTime? preppredDate, DateTime? sprayedDate, int? batchId, bool deleted, int companyId)
        {
            WorkManholeRehabilitationGateway workManholeRehabilitationGateway = new WorkManholeRehabilitationGateway(null);
            workManholeRehabilitationGateway.Insert(workId, preppredDate, sprayedDate, batchId, deleted, companyId);
        }



        /// <summary>
        /// InsertDirect a rehabilitation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="preppredDate">preppredDate</param>
        /// <param name="sprayedDate">sprayedDate</param>
        /// <param name="batchId">batchId</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        public int InsertDirectEmptyWorks(int projectId, int assetId, DateTime? preppredDate, DateTime? sprayedDate, int? batchId, bool deleted, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Manhole Rehabilitation", companyId);

            if (workGateway.Table.Rows.Count == 0)
            {
                workId = new Work(null).InsertDirect(projectId, assetId, "Manhole Rehabilitation", null, deleted, companyId, "", "");
                new WorkManholeRehabilitationGateway(null).Insert(workId, preppredDate, sprayedDate, batchId, deleted, companyId);
            }
            else
            {
                workId = workGateway.GetWorkId(assetId, "Manhole Rehabilitation", projectId);
            }

            return workId;
        }


        /// <summary>
        /// UpdateDirect a rehabilitation
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalPreppredDate">originalPreppredDate</param>
        /// <param name="originalSprayedDate">originalSprayedDate</param>
        /// <param name="originalBatchId">originalBatchId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newPreppredDate">newPreppredDate</param>
        /// <param name="newSprayedDate">newSprayedDate</param>
        /// <param name="newBatchId">newBatchId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalWorkId, DateTime? originalPreppredDate, DateTime? originalSprayedDate, int? originalBatchId, bool originalDeleted, int originalCompanyId, int newWorkId, DateTime? newPreppredDate, DateTime? newSprayedDate, int? newBatchId, bool newDeleted, int newCompanyId)                                     
        {
            WorkManholeRehabilitationGateway workManholeRehabilitationGateway = new WorkManholeRehabilitationGateway(null);
            workManholeRehabilitationGateway.Update(originalWorkId, originalPreppredDate, originalSprayedDate, originalBatchId, originalDeleted, originalCompanyId, newWorkId,  newPreppredDate, newSprayedDate, newBatchId, newDeleted, newCompanyId);
        }
                      
  

        /// <summary>
        /// DeleteDirect a rehabilitation
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int workId, int companyId)
        {
            WorkManholeRehabilitationGateway workManholeRehabilitationGateway = new WorkManholeRehabilitationGateway(null);
            workManholeRehabilitationGateway.Delete(workId, companyId);
        }



    }
}    