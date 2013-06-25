using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;

namespace LiquiForce.LFSLive.BL.FleetManagement.Categories
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Category()
            : base("LFS_FM_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Category(DataSet data)
            : base(data, "LFS_FM_CATEGORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CategoriesTDS();
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
            CategoryGateway categoryGateway = new CategoryGateway(Data);
            categoryGateway.Load(companyId);
            UpdateData();
        }



        /// <summary>
        /// LoadAllUnitTypes
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAllUnitTypes(int companyId)
        {
            CategoryGateway categoryGateway = new CategoryGateway(Data);
            categoryGateway.ClearBeforeFill = false;
            categoryGateway.LoadByUnitType("Equipment", companyId);
            categoryGateway.LoadByUnitType("Vehicle", companyId);
            categoryGateway.ClearBeforeFill = true;
            UpdateDataForView();
        }
       
                
                
        /// <summary>
        /// LoadByUnitType
        /// </summary>
        /// <param name="unitType">unitType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByUnitType(string unitType, int companyId)
        {
            CategoryGateway categoryGateway = new CategoryGateway(Data);
            categoryGateway.LoadByUnitType(unitType, companyId);
            UpdateData();
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(string type, string name, int? parentId, bool deleted, int companyId)
        {
            CategoryGateway categoryGateway = new CategoryGateway(null);
            categoryGateway.Insert(type, name, parentId, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalCategoryId">originalCategoryId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newCategoryId">newCategoryId</param>
        /// <param name="newType">newType</param>
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalCategoryId, string originalType, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, int newCategoryId, string newType, string newName, int? newParentId, bool newDeleted, int newCompanyId)
        {
            CategoryGateway categoryGateway = new CategoryGateway(null);
            categoryGateway.Update(originalCategoryId, originalType, originalName, originalParentId, originalDeleted, originalCompanyId, newCategoryId, newType, newName, newParentId, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeletedDirect
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void DeletedDirect(int categoryId, int companyId)
        {
            CategoryGateway categoryGateway = new CategoryGateway(null);
            categoryGateway.Delete(categoryId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        {
            foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)Table)
            {
                if (row.IsParentIDNull())
                {
                    row.ParentID = 0;
                }
            }           
        }



        /// <summary>
        /// UpdateDataForView
        /// </summary>
        private void UpdateDataForView()
        {
            foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in (CategoriesTDS.LFS_FM_CATEGORYDataTable)Table)
            {
                if (row.IsParentIDNull())
                {
                    if (row.Type == "Equipment")
                    {
                        row.ParentID = 0;
                    }

                    if (row.Type == "Vehicle")
                    {
                        row.ParentID = -1;
                    }
                }
            }
        }



    }
}