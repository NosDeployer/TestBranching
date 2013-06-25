using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketSupportTicketActivity
    /// </summary>
    public class SupportTicketSupportTicketActivity: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketSupportTicketActivity()
            : base("LFS_ITTST_SUPPORTICKET_ACTIVITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketSupportTicketActivity(DataSet data)
            : base(data, "LFS_ITTST_SUPPORTICKET_ACTIVITY")
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
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>        
        /// <param name="type_">type_</param>
        /// <param name="dateTime_">dateTime_</param>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        public void InsertDirect(int supportTicketId, int refId, string type_, DateTime dateTime_, int employeeId, string comment, bool deleted, int companyId)
        {
            SupportTicketSupportTicketActivityGateway supportTicketSupportTicketActivityGateway = new SupportTicketSupportTicketActivityGateway(null);
            supportTicketSupportTicketActivityGateway.Insert(supportTicketId, refId, type_, dateTime_, employeeId, comment, deleted, companyId);
        }



        /// <summary>
        /// Update direct - activity (direct to DB)
        /// </summary>
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalType_">originalType_</param>
        /// <param name="originalDateTime_">originalDateTime_</param>        
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>        
        ///
        /// <param name="newSupportTicketId">newSupportTicketId</param>
        /// <param name="newRefId">newRefId</param>        
        /// <param name="newType_">newType_</param>
        /// <param name="newDateTime_">newDateTime_</param>        
        /// <param name="newEmployeeId">newEmployeeId</param>
        /// <param name="newComment">newComment</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>        
        public void UpdateDirect(int originalSupportTicketId, int originalRefId, string originalType_, DateTime originalDateTime_, int originalEmployeeId, string originalComment, bool originalDeleted, int originalCompanyId, int newSupportTicketId, int newRefId, string newType_, DateTime newDateTime_, int newEmployeeId, string newComment, bool newDeleted, int newCompanyId)
        {
            SupportTicketSupportTicketActivityGateway supportTicketSupportTicketActivityGateway = new SupportTicketSupportTicketActivityGateway(null);
            supportTicketSupportTicketActivityGateway.Update(originalSupportTicketId, originalRefId, originalType_, originalDateTime_, originalEmployeeId, originalComment, originalDeleted, originalCompanyId, newSupportTicketId, newRefId, newType_, newDateTime_, newEmployeeId, newComment, newDeleted, newCompanyId);
        }
        


        /// <summary>
        /// Delete one activity  (direct to DB)
        /// </summary>
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteDirect(int originalSupportTicketId, int originalRefId, int originalCompanyId)
        {
            SupportTicketSupportTicketActivityGateway supportTicketSupportTicketActivityGateway = new SupportTicketSupportTicketActivityGateway(null);
            supportTicketSupportTicketActivityGateway.Delete(originalSupportTicketId, originalRefId, originalCompanyId);
        }



        /// <summary>
        /// Delete all activities  (direct to DB)
        /// </summary>
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        public void DeleteAllDirect(int originalSupportTicketId, int originalCompanyId)
        {
            SupportTicketSupportTicketActivityGateway supportTicketSupportTicketActivityGateway = new SupportTicketSupportTicketActivityGateway(null);
            supportTicketSupportTicketActivityGateway.DeleteAll(originalSupportTicketId, originalCompanyId);
        }



    }
}