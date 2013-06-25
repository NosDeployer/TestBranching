using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;

namespace LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels
{
    /// <summary>
    /// CompanyLevel
    /// </summary>
    public class CompanyLevel : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyLevel()
            : base("LFS_FM_COMPANYLEVEL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompanyLevel(DataSet data)
            : base(data, "LFS_FM_COMPANYLEVEL")
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
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway(Data);
            companyLevelGateway.Load(companyId);
            UpdateData();
        }



        /// <summary>
        /// LoadNodes
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadNodes(int companyId)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway(Data);
            companyLevelGateway.LoadNodes(companyId);
            UpdateData();
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitsUnitOfMeasurement">unitsUnitOfMeasurement</param>
        /// <returns>companyLevelId</returns>
        public int InsertDirect(string name, int? parentId, bool deleted, int companyId, string unitsUnitOfMeasurement)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway(null);
            companyLevelGateway.Insert(name, parentId, deleted, companyId, unitsUnitOfMeasurement);

            int companyLevelId = companyLevelGateway.GetLastCompanyLevelId();

            return companyLevelId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalUnitsUnitOfMeasurement">originalUnitsUnitOfMeasurement</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>        
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newUnitsUnitOfMeasurement">newUnitsUnitOfMeasurement</param>
        public void UpdateDirect(int originalCompanyLevelId, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, string originalUnitsUnitOfMeasurement, int newCompanyLevelId, string newName, int? newParentId, bool newDeleted, int newCompanyId, string newUnitsUnitOfMeasurement)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway(null);
            companyLevelGateway.Update(originalCompanyLevelId, originalName, originalParentId, originalDeleted, originalCompanyId, originalUnitsUnitOfMeasurement, newCompanyLevelId, newName, newParentId, newDeleted, newCompanyId, newUnitsUnitOfMeasurement);
        }



        /// <summary>
        /// DeletedDirect
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        public void DeletedDirect(int companyLevelId, int companyId)
        {
            CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway(null);
            companyLevelGateway.Delete(companyLevelId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            foreach (CompanyLevelsTDS.LFS_FM_COMPANYLEVELRow row in (CompanyLevelsTDS.LFS_FM_COMPANYLEVELDataTable)Table)
            {
                if (row.IsParentIDNull())
                {
                    row.ParentID = 0;
                }
            }           
        }



    }
}
