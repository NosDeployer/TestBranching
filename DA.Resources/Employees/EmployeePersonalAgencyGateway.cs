using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeePersonalAgencyGateway
    /// </summary>
    public class EmployeePersonalAgencyGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeePersonalAgencyGateway()
            : base("LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeePersonalAgencyGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES";
            tableMapping.ColumnMappings.Add("PersonalAgencyName", "PersonalAgencyName");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] WHERE (([PersonalAge" +
                "ncyName] = @Original_PersonalAgencyName) AND ([Deleted] = @Original_Deleted) AND" +
                " ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] ([PersonalAgencyName], [Deleted], [COMPANY_ID]) VALUES (@PersonalAgencyName, @Deleted, @COMPANY_ID);
SELECT PersonalAgencyName, Deleted, COMPANY_ID FROM LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES WHERE (PersonalAgencyName = @PersonalAgencyName)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] SET [PersonalAgencyName] = @PersonalAgencyName, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([PersonalAgencyName] = @Original_PersonalAgencyName) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT PersonalAgencyName, Deleted, COMPANY_ID FROM LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES WHERE (PersonalAgencyName = @PersonalAgencyName)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert Personnel Agency
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <param name="deleted">deleted</param>
        public void Insert(string personalAgencyName, int companyId, bool deleted)
        {
            SqlParameter personalAgencyNameParameter = (personalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", personalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] ([PersonalAgencyName], [Deleted], [COMPANY_ID]) VALUES (@PersonalAgencyName, " +
                 " @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, personalAgencyNameParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Update Personnel Agency
        /// </summary>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// 
        /// <param name="newPersonalAgencyName">newPersonalAgencyName</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <returns>rowsAffected</returns>
        public int Update(string originalPersonalAgencyName, int originalCompanyId, bool originalDeleted, string newPersonalAgencyName, int newCompanyId, bool newDeleted)
        {
            SqlParameter originalPersonalAgencyNameParameter = (originalPersonalAgencyName.Trim() != "") ? new SqlParameter("Original_PersonalAgencyName", originalPersonalAgencyName.Trim()) : new SqlParameter("Original_PersonalAgencyName", DBNull.Value);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);

            SqlParameter newPersonalAgencyNameParameter = (newPersonalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", newPersonalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] " +
                " SET [PersonalAgencyName] = @PersonalAgencyName, [COMPANY_ID] = @COMPANY_ID, [Deleted] = @Deleted " +
                " WHERE (([PersonalAgencyName] = @Original_PersonalAgencyName) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalPersonalAgencyNameParameter, originalCompanyIdParameter, originalDeletedParameter, newPersonalAgencyNameParameter, newCompanyIdParameter, newDeletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="companyId">companyId</param>
        public void Delete(string personalAgencyName, int companyId)
        {
            SqlParameter personalAgencyNameParameter = (personalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", personalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] SET  [Deleted] = @Deleted " +
                " WHERE (([PersonalAgencyName] = @PersonalAgencyName) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, personalAgencyNameParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// UnDelete
        /// </summary>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(string personalAgencyName, int companyId)
        {
            SqlParameter personalAgencyNameParameter = (personalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", personalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES] SET  [Deleted] = @Deleted " +
                " WHERE (([PersonalAgencyName] = @PersonalAgencyName) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, personalAgencyNameParameter, companyIdParameter, deletedParameter);
        }



        /// <summary>
        /// IsUsedInPointRepair
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInEmployee(string personalAgencyName, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_RESOURCES_EMPLOYEE WHERE (PersonalAgencyName = @personalAgencyName) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@personalAgencyName", personalAgencyName));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// ExistPersonalAgency
        /// </summary>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="companyId">companyId</param>
        /// <returns>TRUE if is used</returns>
        public bool ExistPersonalAgency(string personalAgencyName, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_RESOURCES_EMPLOYEE_PERSONAL_AGENCIES WHERE (PersonalAgencyName = @personalAgencyName) AND (COMPANY_ID = @companyId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@personalAgencyName", personalAgencyName));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

                      

    }
}