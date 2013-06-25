using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketCategoryAddNew
    /// </summary>
    public class SupportTicketCategoryAddNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketCategoryAddNew()
            : base("CategoriesAddNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketCategoryAddNew(DataSet data)
            : base(data, "CategoriesAddNew")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketCategoriesAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="newCategoryID">newCategoryID</param>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int? categoryId, int? newCategoryID, string name, int? parentId, bool deleted, int companyId, bool inDatabase)
        {
            SupportTicketCategoriesAddTDS.CategoriesAddNewRow row = ((SupportTicketCategoriesAddTDS.CategoriesAddNewDataTable)Table).NewCategoriesAddNewRow();

            if (categoryId.HasValue) row.CategoryID = (int)categoryId; else row.CategoryID = GetNewCategoryId();
            if (newCategoryID.HasValue) row.NewCategoryID = (int)newCategoryID; else row.SetNewCategoryIDNull();
            row.Name = name;
            if (parentId.HasValue) row.ParentID = (int)parentId; else row.SetParentIDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((SupportTicketCategoriesAddTDS.CategoriesAddNewDataTable)Table).AddCategoriesAddNewRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            foreach (SupportTicketCategoriesAddTDS.CategoriesAddNewRow row in (SupportTicketCategoriesAddTDS.CategoriesAddNewDataTable)Data.Tables["CategoriesAddNew"])
            {
                // Insert category
                if ((!row.Deleted) && (!row.InDatabase))
                {
                    int? parentId = null; if (!row.IsParentIDNull()) parentId = row.ParentID;
                    SupportTicketCategory categories = new SupportTicketCategory(null);
                    categories.InsertDirect(row.Name, parentId, row.Deleted, row.COMPANY_ID);
                }

                // Update category
                if ((!row.Deleted) && (row.InDatabase))
                {
                    int companyId = row.COMPANY_ID;
                    SupportTicketCategoryGateway supportTicketcategoryGateway = new SupportTicketCategoryGateway();
                    supportTicketcategoryGateway.LoadByCategoryId(row.CategoryID, companyId);

                    int categoryId = row.CategoryID;
                    string originalName = supportTicketcategoryGateway.GetName(categoryId);
                    int? originalParentId = null; if (supportTicketcategoryGateway.GetParentId(categoryId).HasValue) originalParentId = (int)supportTicketcategoryGateway.GetParentId(categoryId);

                    SupportTicketCategory category = new SupportTicketCategory(null);
                    category.UpdateDirect(categoryId, originalName, originalParentId, row.Deleted, companyId, row.CategoryID, row.Name, originalParentId, row.Deleted, companyId);
                }

                // Delete category
                if ((row.Deleted) && (row.InDatabase))
                {
                    int categoryId = row.CategoryID;
                    int? newCategoryId = null; if (!row.IsNewCategoryIDNull()) newCategoryId = row.NewCategoryID;
                    int companyId = row.COMPANY_ID;

                    SupportTicketCategory category = new SupportTicketCategory(null);
                    category.DeletedDirect(categoryId, companyId);
                }
            }
        }                  






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single unit. If not exists, raise an exception
        /// </summary>
        /// <param name="categoryId">internal categoryId</param>
        /// <returns>Row</returns>
        private SupportTicketCategoriesAddTDS.CategoriesAddNewRow GetRow(int categoryId)
        {
            SupportTicketCategoriesAddTDS.CategoriesAddNewRow row = ((SupportTicketCategoriesAddTDS.CategoriesAddNewDataTable)Table).FindByCategoryID(categoryId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket.SupportTicketCategoryAddNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>UnitID</returns>
        private int GetNewCategoryId()
        {
            int newId = 0;

            foreach (SupportTicketCategoriesAddTDS.CategoriesAddNewRow row in (SupportTicketCategoriesAddTDS.CategoriesAddNewDataTable)Table)
            {
                if (newId < row.CategoryID)
                {
                    newId = row.CategoryID;
                }
            }

            newId++;

            return newId;
        }        


        


    }
}

