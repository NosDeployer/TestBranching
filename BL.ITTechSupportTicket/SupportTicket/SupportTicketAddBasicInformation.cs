using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketAddBasicInformation
    /// </summary>
    public class SupportTicketAddBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketAddBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketAddBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a support ticket
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="subject">subject</param>        
        /// <param name="comment">comment</param>
        /// <param name="dueDate">dueDate</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="state">state</param>        
        /// <param name="createdById">createdById</param>
        /// <param name="type_">type_</param>
        /// <param name="categoryName">categoryName</param>
        public void Insert(int categoryId, string subject, string comment, DateTime? dueDate, int assignTeamMemberId, bool deleted, int companyId, string state, int createdById, string type_, string categoryName)
        {
            SupportTicketAddTDS.BasicInformationRow row = ((SupportTicketAddTDS.BasicInformationDataTable)Table).NewBasicInformationRow();

            row.SupportTicketID = GetNewId();
            row.CategoryID = categoryId;
            row.Subject = subject;
            row.Comment = comment;
            if (dueDate.HasValue) row.DueDate = (DateTime)dueDate; else row.SetDueDateNull();
            row.TeamMemberID = assignTeamMemberId; 
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.State = state;
            row.CreatedByID = createdById;
            row.Type_ = type_;
            row.CategoryName = categoryName;

            ((SupportTicketAddTDS.BasicInformationDataTable)Table).AddBasicInformationRow(row);
        }



        /// <summary>
        /// Save support tickets
        /// </summary>
        /// <param name="creationDate">creationDate</param>        
        /// <param name="companyId">companyId</param>
        public int? Save(DateTime creationDate, int companyId)
        {
            int newSupportTicketId = 0;

            SupportTicketAddTDS supportTicketAddChanges = (SupportTicketAddTDS)Data.GetChanges();
            if (supportTicketAddChanges.BasicInformation.Rows.Count > 0)
            {
                foreach (SupportTicketAddTDS.BasicInformationRow row in (SupportTicketAddTDS.BasicInformationDataTable)supportTicketAddChanges.BasicInformation)
                {
                    int categoryId = row.CategoryID;
                    string subject = ""; if (!row.IsSubjectNull()) subject = row.Subject;
                    string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;
                    DateTime? dueDate = null; if (!row.IsDueDateNull()) dueDate = row.DueDate;                    
                    int employeeId = 0; if (!row.IsTeamMemberIDNull()) employeeId = row.TeamMemberID;
                    bool deleted = row.Deleted;
                    string state = row.State;
                    int createdById = row.CreatedByID;
                    int refId = 1;
                    string type_ = row.Type_;

                    // ... Insert the support ticket
                    SupportTicketSupportTicket supportTicketSupportTicket = new SupportTicketSupportTicket(null);
                    newSupportTicketId = supportTicketSupportTicket.InsertDirect(categoryId, subject, creationDate, createdById, state, dueDate, deleted, companyId);

                    // ... Insert first Activity (Default Assignation - first Activity)
                    SupportTicketSupportTicketActivity supportTicketSupportTicketActivity = new SupportTicketSupportTicketActivity(null);
                    supportTicketSupportTicketActivity.InsertDirect(newSupportTicketId, refId, type_, creationDate, employeeId, comment, row.Deleted, companyId);
                }
            }

            return newSupportTicketId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="supportTicketID">internal supportTicketID</param>
        /// <returns>Row</returns>
        private SupportTicketAddTDS.BasicInformationRow GetRow(int supportTicketId)
        {
            SupportTicketAddTDS.BasicInformationRow row = ((SupportTicketAddTDS.BasicInformationDataTable)Table).FindBySupportTicketID(supportTicketId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket.SupportTicketAddBasicInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>supportTicketID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (SupportTicketAddTDS.BasicInformationRow row in (SupportTicketAddTDS.BasicInformationDataTable)Table)
            {
                if (newId < row.SupportTicketID)
                {
                    newId = row.SupportTicketID;
                }
            }

            newId++;

            return newId;
        }



    }
}
