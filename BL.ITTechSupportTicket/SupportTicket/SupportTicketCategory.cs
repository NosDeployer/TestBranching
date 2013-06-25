using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketCategory
    /// </summary>
    public class SupportTicketCategory : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketCategory()
            : base("LFS_ITTST_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketCategory(DataSet data)
            : base(data, "LFS_ITTST_CATEGORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketCategoriesTDS();
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
            SupportTicketCategoryGateway supportTicketCategoryGateway = new SupportTicketCategoryGateway(Data);
            supportTicketCategoryGateway.Load(companyId);
            UpdateData();
        }



        /// <summary>
        /// InsertDirect
        /// </summary>        
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(string name, int? parentId, bool deleted, int companyId)
        {
            SupportTicketCategoryGateway categoryGateway = new SupportTicketCategoryGateway(null);
            categoryGateway.Insert(name, parentId, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalSupportTicketCategoryId">originalSupportTicketCategoryId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newSupportTicketCategoryId">newSupportTicketCategoryId</param>
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalSupportTicketCategoryId, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, int newSupportTicketCategoryId, string newName, int? newParentId, bool newDeleted, int newCompanyId)
        {
            SupportTicketCategoryGateway categoryGateway = new SupportTicketCategoryGateway(null);
            categoryGateway.Update(originalSupportTicketCategoryId,  originalName, originalParentId, originalDeleted, originalCompanyId, newSupportTicketCategoryId, newName, newParentId, newDeleted, newCompanyId);
        }



        /// <summary>
        /// DeletedDirect
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void DeletedDirect(int categoryId, int companyId)
        {
            SupportTicketCategoryGateway categoryGateway = new SupportTicketCategoryGateway(null);
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
            foreach (SupportTicketCategoriesTDS.LFS_ITTST_CATEGORYRow row in (SupportTicketCategoriesTDS.LFS_ITTST_CATEGORYDataTable)Table)
            {
                if (row.IsParentIDNull())
                {
                    row.ParentID = 0;
                }
            }           
        }
    }
}