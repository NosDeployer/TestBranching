using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.Works
{
    /// <summary>
    /// WorkPointRepairsRepairPointSize
    /// </summary>
    public class WorkPointRepairsRepairPointSize : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkPointRepairsRepairPointSize()
            : base("LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkPointRepairsRepairPointSize(DataSet data)
            : base(data, "LFS_WORK_POINT_REPAIRS_REPAIRPOINT_SIZE")
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
        /// Insert material
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>        
        public void InsertDirect(string size_, int companyId, bool deleted)
        {
            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway(null);
            workPointRepairsRepairPointSizeGateway.Insert(size_, companyId, deleted);
        }



        /// <summary>
        /// Update size (direct to DB)
        /// </summary>
        /// <param name="originalSize">originalsize</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// 
        /// <param name="newSize">newSize</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>        
        public void UpdateDirect(string originalSize, int originalCompanyId, bool originalDeleted, string newSize, int newCompanyId, bool newDeleted)
        {
            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway(null);
            workPointRepairsRepairPointSizeGateway.Update(originalSize, originalCompanyId, originalDeleted, newSize, newCompanyId, newDeleted);
        }



        /// <summary>
        /// Delete size
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(string size_, int companyId)
        {
            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway(null);
            workPointRepairsRepairPointSizeGateway.Delete(size_, companyId);
        }



        /// <summary>
        /// Undelete size
        /// </summary>
        /// <param name="size_">size_</param>
        /// <param name="companyId">companyId</param>
        public void UnDeleteDirect(string size_, int companyId)
        {
            WorkPointRepairsRepairPointSizeGateway workPointRepairsRepairPointSizeGateway = new WorkPointRepairsRepairPointSizeGateway(null);
            workPointRepairsRepairPointSizeGateway.UnDelete(size_, companyId);
        }       

        
        
    }
}