using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkManholeRehabilitationBatch
    /// </summary>
    public class WorkManholeRehabilitationBatch: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkManholeRehabilitationBatch()
            : base("LFS_WORK_MANHOLE_REHABILITATION_BATCH")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkManholeRehabilitationBatch(DataSet data)
            : base(data, "LFS_WORK_MANHOLE_REHABILITATION_BATCH")
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
        /// InsertDirect a batch
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="description">description</param>
        /// <param name="defaultDate">defaultDate</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int batchId, string description, DateTime date, bool deleted, int companyId)
        {
            WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway(null);
            workManholeRehabilitationBatchGateway.Insert(batchId, description, date, deleted, companyId);
        }


        /// <summary>
        /// UpdateDirect a batch
        /// </summary>
        /// <param name="originalCatalystId">originalCatalystId</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalDefaultDate">originalDefaultDate</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newCatalystId">newCatalystId</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newDefaultDate">newDefaultDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCatalystId, string originalDescription, DateTime originalDate, bool originalDeleted, int originalCompanyId, int newCatalystId, string newDescription, DateTime newDate, bool newDeleted, int newCompanyId)
        {
            WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway(null);
            workManholeRehabilitationBatchGateway.Update(originalCatalystId, originalDescription, originalDate, originalDeleted, originalCompanyId, newCatalystId, newDescription, newDate, newDeleted, newCompanyId);
        }
                      
  

        /// <summary>
        /// DeleteDirect a batch
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int batchId, int companyId)
        {
            WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway(null);
            workManholeRehabilitationBatchGateway.Delete(batchId, companyId);
        }


    }
}
    