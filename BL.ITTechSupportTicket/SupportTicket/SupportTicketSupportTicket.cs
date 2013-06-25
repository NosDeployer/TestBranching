using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketSupportTicket
    /// </summary>
    public class SupportTicketSupportTicket: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketSupportTicket()
            : base("LFS_ITTST_SUPPORTICKET")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketSupportTicket(DataSet data)
            : base(data, "LFS_ITTST_SUPPORTICKET")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert direct (direct to DB)
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="subject">subject</param>
        /// <param name="creationDate">creationDate</param>
        /// <param name="createdById">createdById</param>
        /// <param name="state">state</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>todoId</returns>
        public int InsertDirect(int categoryId, string subject, DateTime creationDate, int createdById, string state, DateTime? dueDate, bool deleted, int companyId)
        {
            SupportTicketSupportTicketGateway supportTicketSupportTicketGateway = new SupportTicketSupportTicketGateway(null);
            return supportTicketSupportTicketGateway.Insert(categoryId, subject, creationDate, createdById, state, dueDate, deleted, companyId);
        }



        /// <summary>
        /// Update direct (direct to DB)
        /// </summary>        
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <param name="originalCategoryId">originalCategoryId</param>
        /// <param name="originalSubject">originalSubject</param>
        /// <param name="originalCreationDate">originalCreationDate</param>
        /// <param name="originalCreatedById">originalCreatedById</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDueDate">originalDueDate</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newSupportTicketId">newSupportTicketId</param>
        /// <param name="newCategoryId">newCategoryId</param>
        /// <param name="newSubject">newSubject</param>
        /// <param name="newCreationDate">newCreationDate</param>
        /// <param name="newCreatedById">newCreatedById</param>
        /// <param name="newState">newState</param>
        /// <param name="newDueDate">newDueDate</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect( int originalSupportTicketId, int originalCategoryId, string originalSubject, DateTime originalCreationDate, int originalCreatedById, string originalState, DateTime? originalDueDate, bool originalDeleted, int originalCompanyId, int newSupportTicketId, int newCategoryId, string newSubject, DateTime newCreationDate, int newCreatedById, string newState, DateTime? newDueDate, bool newDeleted, int newCompanyId)
        {
            SupportTicketSupportTicketGateway supportTicketSupportTicketGateway = new SupportTicketSupportTicketGateway(null);
            supportTicketSupportTicketGateway.Update( originalSupportTicketId, originalCategoryId, originalSubject, originalCreationDate, originalCreatedById, originalState, originalDueDate, originalDeleted, originalCompanyId,  newSupportTicketId, newCategoryId, newSubject, newCreationDate, newCreatedById, newState, newDueDate, newDeleted, newCompanyId);
        }
        


        /// <summary>
        /// DeleteDirect (direct to DB)
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>        
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int supportTicketId, int companyId)
        {
            SupportTicketSupportTicketGateway supportTicketSupportTicketGateway = new SupportTicketSupportTicketGateway(null);
            supportTicketSupportTicketGateway.Delete(supportTicketId, companyId);
        }


    }
}
