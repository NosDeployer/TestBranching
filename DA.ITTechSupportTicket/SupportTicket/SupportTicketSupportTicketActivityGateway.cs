using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketSupportTicketActivityGateway
    /// </summary>
    public class SupportTicketSupportTicketActivityGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketSupportTicketActivityGateway()
            : base("LFS_ITTST_SUPPORTICKET_ACTIVITY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketSupportTicketActivityGateway(DataSet data)
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



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_ITTST_SUPPORTICKET_ACTIVITY";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Type_", "Type_");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] WHERE (([SupportTicketID] = @Original_SupportTicketID) AND ([RefID] = @Original_RefID) AND ([Type_] = @Original_Type_) AND ([DateTime_] = @Original_DateTime_) AND ([EmployeeID] = @Original_EmployeeID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] ([SupportTicketID], [RefID], [Type_], [DateTime_], [EmployeeID], [Comment], [Deleted], [COMPANY_ID]) VALUES (@SupportTicketID, @RefID, @Type_, @DateTime_, @EmployeeID, @Comment, @Deleted, @COMPANY_ID);
SELECT SupportTicketID, RefID, Type_, DateTime_, EmployeeID, Comment, Deleted, COMPANY_ID FROM LFS_ITTST_SUPPORTICKET_ACTIVITY WHERE (RefID = @RefID) AND (SupportTicketID = @SupportTicketID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
 
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] SET [SupportTicketID] = @SupportTicketID, [RefID] = @RefID, [Type_] = @Type_, [DateTime_] = @DateTime_, [EmployeeID] = @EmployeeID, [Comment] = @Comment, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([SupportTicketID] = @Original_SupportTicketID) AND ([RefID] = @Original_RefID) AND ([Type_] = @Original_Type_) AND ([DateTime_] = @Original_DateTime_) AND ([EmployeeID] = @Original_EmployeeID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT SupportTicketID, RefID, Type_, DateTime_, EmployeeID, Comment, Deleted, COMPANY_ID FROM LFS_ITTST_SUPPORTICKET_ACTIVITY WHERE (RefID = @RefID) AND (SupportTicketID = @SupportTicketID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SupportTicketID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SupportTicketID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DateTime_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DateTime_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a to do activity (direct to DB)
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>      
        /// <param name="type_">type_</param>
        /// <param name="dateTime_">dateTime_</param>  
        /// <param name="employeeId">employeeId</param>    
        /// <param name="comment">comment</param>  
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int supportTicketId, int refId, string type_, DateTime dateTime_, int employeeId, string comment, bool deleted, int companyId)
        {
            SqlParameter supportTicketIdParameter = new SqlParameter("SupportTicketId", supportTicketId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter type_Parameter = new SqlParameter("Type_", type_);
            SqlParameter dateTime_Parameter = new SqlParameter("DateTime_", dateTime_);            
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);
            SqlParameter commentParameter = (comment != "") ? new SqlParameter("Comment", comment) : new SqlParameter("Comment", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] ([SupportTicketID], [RefID], [Type_], [DateTime_], [EmployeeID], [Comment], [Deleted], [COMPANY_ID]) VALUES (@SupportTicketID, @RefID, @Type_, @DateTime_, @EmployeeID, @Comment, @Deleted, @COMPANY_ID)";
            int rowsAffected = (int)ExecuteNonQuery(command, supportTicketIdParameter, refIdParameter, type_Parameter, dateTime_Parameter, employeeIdParameter, commentParameter, deletedParameter, companyIdParameter);
            return rowsAffected;
        }



        /// <summary>
        /// Update to do activity (direct to DB)
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
        /// <returns>rowsAffected</returns>
        public int Update(int originalSupportTicketId, int originalRefId, string originalType_, DateTime originalDateTime_, int originalEmployeeId, string originalComment, bool originalDeleted, int originalCompanyId, int newSupportTicketId, int newRefId, string newType_, DateTime newDateTime_, int newEmployeeId, string newComment, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalSupportTicketIdParameter = new SqlParameter("Original_SupportTicketID", originalSupportTicketId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);            
            SqlParameter originalType_Parameter = new SqlParameter("Original_Type_", originalType_);
            SqlParameter originalDateTime_Parameter = new SqlParameter("Original_DateTime_", originalDateTime_);
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalCommentParameter = (originalComment != "") ? new SqlParameter("Original_Comment", originalComment) : new SqlParameter("Original_Comment", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);                        
                        
            SqlParameter newSupportTicketIdParameter = new SqlParameter("SupportTicketID", newSupportTicketId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);            
            SqlParameter newType_Parameter = new SqlParameter("Type_", newType_);
            SqlParameter newDateTime_Parameter = new SqlParameter("DateTime_", newDateTime_);
            SqlParameter newEmployeeIdParameter = new SqlParameter("EmployeeID", newEmployeeId);
            SqlParameter newCommentParameter = (newComment != "") ? new SqlParameter("Comment", newComment) : new SqlParameter("Comment", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = " UPDATE [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] SET  [Type_] = @Type_, [DateTime_] = @DateTime_, [EmployeeID] = @EmployeeID, [Comment] = @Comment "+
                                         " WHERE (([SupportTicketID] = @Original_SupportTicketID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSupportTicketIdParameter, originalRefIdParameter, originalType_Parameter,  originalDateTime_Parameter, originalEmployeeIdParameter, originalCommentParameter, originalDeletedParameter, originalCompanyIdParameter, newSupportTicketIdParameter, newRefIdParameter, newType_Parameter, newDateTime_Parameter, newEmployeeIdParameter, newCommentParameter, newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete support ticket activity (direct to DB)
        /// </summary>
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalSupportTicketId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalSupportTicketIdParameter = new SqlParameter("@Original_SupportTicketID", originalSupportTicketId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] SET  [Deleted] = @Deleted  " +
                             " WHERE (([SupportTicketID] = @Original_SupportTicketID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSupportTicketIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



                
        /// <summary>
        /// Delete all support ticket activity (direct to DB)
        /// </summary>
        /// <param name="originalSupportTicketId">originalSupportTicketId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalSupportTicketId, int originalCompanyId)
        {
            SqlParameter originalSupportTicketIdParameter = new SqlParameter("@Original_SupportTicketID", originalSupportTicketId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_ITTST_SUPPORTICKET_ACTIVITY] SET  [Deleted] = @Deleted  " +
                             " WHERE (([SupportTicketID] = @Original_SupportTicketID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalSupportTicketIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}