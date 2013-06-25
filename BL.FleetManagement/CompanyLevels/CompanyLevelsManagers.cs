using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;

namespace LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels
{
    /// <summary>
    /// CompanyLevelsManagers
    /// </summary>
    public class CompanyLevelsManagers : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyLevelsManagers()
            : base("LFS_FM_COMPANYLEVEL_MANAGERS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompanyLevelsManagers(DataSet data)
            : base(data, "LFS_FM_COMPANYLEVEL_MANAGERS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CompanyLevelsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //


        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int companyLevelId, int employeeId, bool deleted, int companyId)
        {
            CompanyLevelsManagersGateway companyLevelsManagersGateway = new CompanyLevelsManagersGateway(null);
            companyLevelsManagersGateway.Insert(companyLevelId, employeeId, deleted, companyId);
        }


        
        /// <summary>
        /// DeletedDirect
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void DeletedDirect(int companyLevelId, int employeeId, int companyId)
        {
            CompanyLevelsManagersGateway companyLevelsManagersGateway = new CompanyLevelsManagersGateway(null);
            companyLevelsManagersGateway.Delete(companyLevelId, employeeId, companyId);
        }
    }
}
