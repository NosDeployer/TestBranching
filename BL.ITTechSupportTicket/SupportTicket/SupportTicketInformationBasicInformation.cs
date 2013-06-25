using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketInformationBasicInformation
    /// </summary>
    public class SupportTicketInformationBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllBySupportTicketId
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllBySupportTicketId(int supportTicketId, int companyId)
        {
            SupportTicketInformationBasicInformationGateway toDoListInformationBasicInformationGateway = new SupportTicketInformationBasicInformationGateway(Data);
            toDoListInformationBasicInformationGateway.LoadAllBySupportTicketId(supportTicketId, companyId);
        }

        

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="dueDate">dueDate</param>
        public void Update(int supportTicketId, DateTime? dueDate)
        {
            SupportTicketInformationTDS.BasicInformationRow row = GetRow(supportTicketId);
            if (dueDate.HasValue) row.DueDate = (DateTime)dueDate; else row.SetDueDateNull();
        }



        /// <summary>
        /// UpdateState
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="state">state</param>
        public void UpdateState(int supportTicketId, string state)
        {
            SupportTicketInformationTDS.BasicInformationRow row = GetRow(supportTicketId);
            row.State = state;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            SupportTicketInformationTDS toDoListInformationChanges = (SupportTicketInformationTDS)Data.GetChanges();

            if (toDoListInformationChanges != null)
            {
                if (toDoListInformationChanges.BasicInformation.Rows.Count > 0)
                {
                    SupportTicketInformationBasicInformationGateway toDoListInformationBasicInformationGateway = new SupportTicketInformationBasicInformationGateway(toDoListInformationChanges);

                    // Update to do
                    foreach (SupportTicketInformationTDS.BasicInformationRow row in (SupportTicketInformationTDS.BasicInformationDataTable)toDoListInformationChanges.BasicInformation)
                    {
                        // Unchanged values
                        int supportTicketId = row.SupportTicketID;
                        int categoryId = row.CategoryID;
                        string subject = toDoListInformationBasicInformationGateway.GetSubject(supportTicketId);
                        DateTime creationDate = toDoListInformationBasicInformationGateway.GetCreationDate(supportTicketId);
                        int createdById = toDoListInformationBasicInformationGateway.GetCreatedByID(supportTicketId);

                        // Original values
                        DateTime? originalDueDate = null; if (toDoListInformationBasicInformationGateway.GetDueDateOriginal(supportTicketId).HasValue) originalDueDate = (DateTime)toDoListInformationBasicInformationGateway.GetDueDateOriginal(supportTicketId);
                        string originalState = toDoListInformationBasicInformationGateway.GetStateOriginal(supportTicketId);

                        // New variables
                        DateTime? newDueDate = null; if (toDoListInformationBasicInformationGateway.GetDueDate(supportTicketId).HasValue) newDueDate = (DateTime)toDoListInformationBasicInformationGateway.GetDueDate(supportTicketId);
                        string newState = toDoListInformationBasicInformationGateway.GetState(supportTicketId);

                        SupportTicketSupportTicket toDoListSupportTicket = new SupportTicketSupportTicket(null);
                        toDoListSupportTicket.UpdateDirect(supportTicketId, categoryId, subject, creationDate, createdById, originalState, originalDueDate, row.Deleted, row.COMPANY_ID, supportTicketId, categoryId, subject, creationDate, createdById, newState, newDueDate, row.Deleted, row.COMPANY_ID);
                    }
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        public void Delete(int supportTicketId)
        {
            SupportTicketInformationTDS.BasicInformationRow row = GetRow(supportTicketId);
            row.Deleted = true;
        }

               



                        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>Obtained row</returns>
        private SupportTicketInformationTDS.BasicInformationRow GetRow(int supportTicketId)
        {
            SupportTicketInformationTDS.BasicInformationRow row = ((SupportTicketInformationTDS.BasicInformationDataTable)Table).FindBySupportTicketID(supportTicketId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket.SupportTicketInformationBasicInformation.GetRow");
            }

            return row;
        }



    }
}