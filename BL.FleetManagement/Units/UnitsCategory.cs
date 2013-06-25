using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;

namespace LiquiForce.LFSLive.BL.FleetManagement.Units
{
    /// <summary>
    /// UnitsCategory
    /// </summary>
    public class UnitsCategory : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsCategory()
            : base("LFS_FM_UNIT_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsCategory(DataSet data)
            : base(data, "LFS_FM_UNIT_CATEGORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int unitId, int categoryId, bool deleted, int companyId)
        {
            UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);
            unitsCategoryGateway.Insert(unitId, categoryId, deleted, companyId);           
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool DeleteDirect(int unitId, int categoryId, int companyId)
        {
            UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);
            unitsCategoryGateway.Delete(unitId, categoryId, companyId);

            return true;
        }



        /// <summary>
        /// UnDeleteDirect
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool UnDeleteDirect(int unitId, int categoryId, int companyId)
        {
            UnitsCategoryGateway unitsCategoryGateway = new UnitsCategoryGateway(null);
            unitsCategoryGateway.UnDelete(unitId, categoryId, companyId);

            return true;
        }



    }
}