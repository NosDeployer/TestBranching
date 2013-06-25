using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;

namespace LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketInformationActivityInformation
    /// </summary>
    public class SupportTicketInformationActivityInformation: TableModule
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketInformationActivityInformation()
            : base("ActivityInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketInformationActivityInformation(DataSet data)
            : base(data, "ActivityInformation")
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
            SupportTicketInformationActivityInformationGateway supportTicketInformationActivityInformationGateway = new SupportTicketInformationActivityInformationGateway(Data);
            supportTicketInformationActivityInformationGateway.LoadAllBySupportTicketId(supportTicketId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="type_">type_</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="employeeFullName">EmployeeFullName</param>
        /// <param name="sendMail">sendMail</param>
        public void Insert(int supportTicketId, int employeeId, string type_, DateTime dateTime_, string comment, bool deleted, int companyId, bool inDatabase, string employeeFullName, bool sendMail)
        {
            SupportTicketInformationTDS.ActivityInformationRow row = ((SupportTicketInformationTDS.ActivityInformationDataTable)Table).NewActivityInformationRow();

            row.SupportTicketID = supportTicketId;
            row.RefID = GetNewRefId();   
            row.EmployeeID = employeeId;          
            row.Type_ = type_;
            row.DateTime_ = dateTime_;                
            row.Comment = comment;    
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDataBase = inDatabase;
            row.EmployeeFullName = employeeFullName;
            row.SendMail = sendMail;
            
            ((SupportTicketInformationTDS.ActivityInformationDataTable)Table).AddActivityInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="employeeFullName">employeeFullName</param>
        /// <param name="comment">comment</param>        
        /// <param name="sendMail">sendMail</param>
        public void Update(int supportTicketId, int refId, int employeeId, string employeeFullName, string comment, bool sendMail)
        {
            SupportTicketInformationTDS.ActivityInformationRow row = GetRow(supportTicketId, refId);
            row.Comment = comment;
            row.EmployeeID = employeeId;
            row.EmployeeFullName = employeeFullName;
            row.SendMail = sendMail;
        }

                

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <param name="sendMail">sendMail</param>
        public void Delete(int supportTicketId, int refId, bool sendMail)
        {
            SupportTicketInformationTDS.ActivityInformationRow row = GetRow(supportTicketId, refId);
            row.Deleted = true;
            row.SendMail = sendMail;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        public void DeleteAll(int supportTicketId)
        {
            foreach (SupportTicketInformationTDS.ActivityInformationRow row in (SupportTicketInformationTDS.ActivityInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// Save all activities to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            SupportTicketInformationTDS supportTicketInformationChanges = (SupportTicketInformationTDS)Data.GetChanges();

            if (supportTicketInformationChanges != null)
            {
                if (supportTicketInformationChanges.ActivityInformation.Rows.Count > 0)
                {
                    SupportTicketInformationActivityInformationGateway supportTicketInformationActivityInformationGateway = new SupportTicketInformationActivityInformationGateway(supportTicketInformationChanges);

                    foreach (SupportTicketInformationTDS.ActivityInformationRow row in (SupportTicketInformationTDS.ActivityInformationDataTable)supportTicketInformationChanges.ActivityInformation)
                    {
                        // Insert new activity 
                        if ((!row.Deleted) && (!row.InDataBase))
                        {
                            // new values
                            int supportTicketId = row.SupportTicketID;
                            int refId = row.RefID;

                            int employeeId = supportTicketInformationActivityInformationGateway.GetEmployeeID(supportTicketId, refId);
                            string type_ = supportTicketInformationActivityInformationGateway.GetType_(supportTicketId, refId);
                            DateTime dateTime_ = supportTicketInformationActivityInformationGateway.GetDateTime_(supportTicketId, refId);
                            string comment = supportTicketInformationActivityInformationGateway.GetComment(supportTicketId, refId);

                            SupportTicketSupportTicketActivity supportTicketSupportTicketActivity = new SupportTicketSupportTicketActivity(null);
                            supportTicketSupportTicketActivity.InsertDirect(supportTicketId, refId, type_, dateTime_, employeeId, comment, row.Deleted, row.COMPANY_ID);
                        }

                        // Update activities
                        if ((!row.Deleted) && (row.InDataBase))
                        {
                            int supportTicketId = row.SupportTicketID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values
                            int originalEmployeeId = supportTicketInformationActivityInformationGateway.GetEmployeeID(supportTicketId, refId);
                            string originalType_ = supportTicketInformationActivityInformationGateway.GetType_(supportTicketId, refId);
                            DateTime originalDateTime_ = supportTicketInformationActivityInformationGateway.GetDateTime_(supportTicketId, refId);
                            string originalComment = supportTicketInformationActivityInformationGateway.GetComment(supportTicketId, refId);

                            // new values
                            int newEmployeeId = supportTicketInformationActivityInformationGateway.GetEmployeeIDOriginal(supportTicketId, refId);
                            string newComment = supportTicketInformationActivityInformationGateway.GetCommentOriginal(supportTicketId, refId);

                            SupportTicketSupportTicketActivity supportTicketSupportTicketActivity = new SupportTicketSupportTicketActivity(null);
                            supportTicketSupportTicketActivity.UpdateDirect(supportTicketId, refId, originalType_, originalDateTime_, originalEmployeeId, originalComment, originalDeleted, originalCompanyId, supportTicketId, refId, originalType_, originalDateTime_, newEmployeeId, newComment, originalDeleted, originalCompanyId);
                        }

                        // Deleted activity
                        if ((row.Deleted) && (row.InDataBase))
                        {
                            SupportTicketSupportTicketActivity supportTicketSupportTicketActivity = new SupportTicketSupportTicketActivity(null);
                            supportTicketSupportTicketActivity.DeleteDirect(row.SupportTicketID, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private SupportTicketInformationTDS.ActivityInformationRow GetRow(int supportTicketId, int refId)
        {
            SupportTicketInformationTDS.ActivityInformationRow row = ((SupportTicketInformationTDS.ActivityInformationDataTable)Table).FindBySupportTicketIDRefID(supportTicketId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket.supportTicketInformationActivityInformation.GetRow");
            }

            return row;
        }


             
        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (SupportTicketInformationTDS.ActivityInformationRow row in (SupportTicketInformationTDS.ActivityInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// GetLastAssignedUserRefId
        /// </summary>
        /// <returns>Last ID</returns>
        public int GetLastAssignedUserRefId()
        {
            int newRefId = 1;

            foreach (SupportTicketInformationTDS.ActivityInformationRow row in (SupportTicketInformationTDS.ActivityInformationDataTable)Table)
            {
                if ((row.Type_ == "AssignUser") && (!row.Deleted))
                {
                    if (newRefId < row.RefID)
                    {
                        newRefId = row.RefID;
                    }
                }
            }

            return newRefId;
        }



    }
}