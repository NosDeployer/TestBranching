using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels
{
    /// <summary>
    /// CompanyLevelGateway
    /// </summary>
    public class CompanyLevelsManagersGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyLevelsManagersGateway()
            : base("LFS_FM_COMPANYLEVEL_MANAGERS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompanyLevelsManagersGateway(DataSet data)
            : base(data, "LFS_FM_COMPANYLEVEL_MANAGERS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CompanyLevelsTDS();
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
            tableMapping.DataSetTable = "LFS_FM_COMPANYLEVEL_MANAGERS";
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_COMPANYLEVEL_MANAGERS] WHERE (([CompanyLevelID] = @Orig" +
                "inal_CompanyLevelID) AND ([EmployeeID] = @Original_EmployeeID) AND ([Deleted] = " +
                "@Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_COMPANYLEVEL_MANAGERS] ([CompanyLevelID], [EmployeeID], [Deleted], [COMPANY_ID]) VALUES (@CompanyLevelID, @EmployeeID, @Deleted, @COMPANY_ID);
SELECT CompanyLevelID, EmployeeID, Deleted, COMPANY_ID FROM LFS_FM_COMPANYLEVEL_MANAGERS WHERE (CompanyLevelID = @CompanyLevelID) AND (EmployeeID = @EmployeeID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyLevelID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_COMPANYLEVEL_MANAGERS] SET [CompanyLevelID] = @CompanyLevelID, [EmployeeID] = @EmployeeID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([CompanyLevelID] = @Original_CompanyLevelID) AND ([EmployeeID] = @Original_EmployeeID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT CompanyLevelID, EmployeeID, Deleted, COMPANY_ID FROM LFS_FM_COMPANYLEVEL_MANAGERS WHERE (CompanyLevelID = @CompanyLevelID) AND (EmployeeID = @EmployeeID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompanyLevelID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int companyLevelId, int employeeId, bool deleted, int companyId)
        {
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter employeeIdParameter = new SqlParameter("EmployeeID", employeeId);            
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_COMPANYLEVEL_MANAGERS] "+
                " ([CompanyLevelID], [EmployeeID], [Deleted], [COMPANY_ID]) "+
                " VALUES (@CompanyLevelID, @EmployeeID, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, companyLevelIdParameter, employeeIdParameter, deletedParameter, companyIdParameter);
        }


        
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int companyLevelId, int employeeId, int companyId)
        {
            SqlParameter companyLevelIdParameter = new SqlParameter("Original_CompanyLevelID", companyLevelId);
            SqlParameter employeeIdParameter = new SqlParameter("Original_EmployeeID", employeeId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_COMPANYLEVEL_MANAGERS] "+
                " SET [Deleted] = @Deleted "+
                " WHERE (([CompanyLevelID] = @Original_CompanyLevelID) AND ([EmployeeID] = @Original_EmployeeID))";

            int rowsAffected = (int)ExecuteNonQuery(command, companyLevelIdParameter, employeeIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// GetCompanyLevelId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Last CompanyLevelId</returns>
        public int GetCompanyLevelId(int employeeId, int companyId)
        {
            string commandText = "SELECT TOP 1 CompanyLevelID FROM LFS_FM_COMPANYLEVEL_MANAGERS WHERE (EmployeeID = @employeeId) AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            if (ExecuteScalar(command) == null)
            {
                return 0;
            }
            else
            {
                return ((int)ExecuteScalar(command));
            }
        }



    }
}