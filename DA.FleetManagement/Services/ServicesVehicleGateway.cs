using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesVehicleGateway
    /// </summary>
    public class ServicesVehicleGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesVehicleGateway()
            : base("LFS_FM_SERVICE_VEHICLE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesVehicleGateway(DataSet data)
            : base(data, "LFS_FM_SERVICE_VEHICLE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesTDS();
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
            tableMapping.DataSetTable = "LFS_FM_SERVICE_VEHICLE";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Mileage", "Mileage");
            tableMapping.ColumnMappings.Add("StartWorkMileage", "StartWorkMileage");
            tableMapping.ColumnMappings.Add("CompleteWorkMileage", "CompleteWorkMileage");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_SERVICE_VEHICLE] WHERE (([ServiceID] = @Original_ServiceID) AND ((@IsNull_Mileage = 1 AND [Mileage] IS NULL) OR ([Mileage] = @Original_Mileage)) AND ((@IsNull_StartWorkMileage = 1 AND [StartWorkMileage] IS NULL) OR ([StartWorkMileage] = @Original_StartWorkMileage)) AND ((@IsNull_CompleteWorkMileage = 1 AND [CompleteWorkMileage] IS NULL) OR ([CompleteWorkMileage] = @Original_CompleteWorkMileage)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Mileage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Mileage", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Mileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Mileage", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_StartWorkMileage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "StartWorkMileage", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StartWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "StartWorkMileage", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkMileage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkMileage", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompleteWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkMileage", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_SERVICE_VEHICLE] ([ServiceID], [Mileage], [StartWorkMileage], [CompleteWorkMileage], [Deleted], [COMPANY_ID]) VALUES (@ServiceID, @Mileage, @StartWorkMileage, @CompleteWorkMileage, @Deleted, @COMPANY_ID);
SELECT ServiceID, Mileage, StartWorkMileage, CompleteWorkMileage, Deleted, COMPANY_ID FROM LFS_FM_SERVICE_VEHICLE WHERE (ServiceID = @ServiceID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Mileage", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "StartWorkMileage", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompleteWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkMileage", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));


            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_SERVICE_VEHICLE] SET [ServiceID] = @ServiceID, [Mileage] = @Mileage, [StartWorkMileage] = @StartWorkMileage, [CompleteWorkMileage] = @CompleteWorkMileage, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ServiceID] = @Original_ServiceID) AND ((@IsNull_Mileage = 1 AND [Mileage] IS NULL) OR ([Mileage] = @Original_Mileage)) AND ((@IsNull_StartWorkMileage = 1 AND [StartWorkMileage] IS NULL) OR ([StartWorkMileage] = @Original_StartWorkMileage)) AND ((@IsNull_CompleteWorkMileage = 1 AND [CompleteWorkMileage] IS NULL) OR ([CompleteWorkMileage] = @Original_CompleteWorkMileage)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ServiceID, Mileage, StartWorkMileage, CompleteWorkMileage, Deleted, COMPANY_ID FROM LFS_FM_SERVICE_VEHICLE WHERE (ServiceID = @ServiceID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Mileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Mileage", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StartWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "StartWorkMileage", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CompleteWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkMileage", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Mileage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Mileage", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Mileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Mileage", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_StartWorkMileage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "StartWorkMileage", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StartWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "StartWorkMileage", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CompleteWorkMileage", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkMileage", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CompleteWorkMileage", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "CompleteWorkMileage", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a service vehicle (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="mileage">mileage</param>
        /// <param name="startWorkMileage">startWorkMileage</param>
        /// <param name="completeWorkMileage">completeWorkMileage</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int serviceId, string mileage, string startWorkMileage, string completeWorkMileage,  bool deleted, int companyId)
        {
            SqlParameter serviceIdParameter = new SqlParameter("ServiceID", serviceId);
            SqlParameter mileageParameter = (mileage.Trim() != "") ? new SqlParameter("Mileage", mileage.Trim()) : new SqlParameter("Mileage", DBNull.Value);
            SqlParameter startWorkMileageParameter = (startWorkMileage.Trim() != "") ? new SqlParameter("StartWorkMileage", startWorkMileage.Trim()) : new SqlParameter("StartWorkMileage", DBNull.Value);
            SqlParameter completeWorkMileageParameter = (completeWorkMileage.Trim() != "") ? new SqlParameter("CompleteWorkMileage", completeWorkMileage.Trim()) : new SqlParameter("CompleteWorkMileage", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_SERVICE_VEHICLE] ([ServiceID], [Mileage], [StartWorkMileage], [CompleteWorkMileage], [Deleted], [COMPANY_ID]) VALUES (@ServiceID, @Mileage, @StartWorkMileage, @CompleteWorkMileage, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery( command, serviceIdParameter, mileageParameter, startWorkMileageParameter, completeWorkMileageParameter , deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update service vehicle (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalMileage">originalMileage</param>
        /// <param name="originalStartWorkMileage">originalStartWorkMileage</param>
        /// <param name="originalCompleteWorkMileage">originalCompleteWorkMileage</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>

        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newMileage">newMileage</param>
        /// <param name="newStartWorkMileage">newStartWorkMileage</param>
        /// <param name="newCompleteWorkMileage">newCompleteWorkMileage</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalServiceId, string originalMileage, string originalStartWorkMileage, string originalCompleteWorkMileage, bool originalDeleted, int originalCompanyId, int newServiceId, string newMileage, string newStartWorkMileage, string newCompleteWorkMileage, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("Original_ServiceID", originalServiceId);
            SqlParameter originalMileageParameter = (originalMileage != "") ? new SqlParameter("Original_Mileage", originalMileage) : new SqlParameter("Original_Mileage", DBNull.Value);
            SqlParameter originalStartWorkMileageParameter = (originalStartWorkMileage != "") ? new SqlParameter("Original_StartWorkMileage", originalStartWorkMileage) : new SqlParameter("Original_StartWorkMileage", DBNull.Value);
            SqlParameter originalCompleteWorkMileageParameter = (originalCompleteWorkMileage != "") ? new SqlParameter("Original_CompleteWorkMileage", originalCompleteWorkMileage) : new SqlParameter("Original_CompleteWorkMileage", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newServiceIdParameter = new SqlParameter("ServiceID", newServiceId);
            SqlParameter newMileageParameter = (newMileage != "") ? new SqlParameter("Mileage", newMileage) : new SqlParameter("Mileage", DBNull.Value);
            SqlParameter newStartWorkMileageParameter = (newStartWorkMileage != "") ? new SqlParameter("StartWorkMileage", newStartWorkMileage) : new SqlParameter("StartWorkMileage", DBNull.Value);
            SqlParameter newCompleteWorkMileageParameter = (newCompleteWorkMileage != "") ? new SqlParameter("CompleteWorkMileage", newCompleteWorkMileage) : new SqlParameter("CompleteWorkMileage", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_VEHICLE] SET [Mileage] = @Mileage, "+
                " [StartWorkMileage] = @StartWorkMileage, [CompleteWorkMileage] = @CompleteWorkMileage "+
                " WHERE ([ServiceID] = @Original_ServiceID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalServiceIdParameter, originalMileageParameter, originalStartWorkMileageParameter, originalCompleteWorkMileageParameter, originalDeletedParameter, originalCompanyIdParameter, newServiceIdParameter, newMileageParameter, newStartWorkMileageParameter, newCompleteWorkMileageParameter, newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a service vehicle (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalServiceId, int originalCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("@Original_ServiceID", originalServiceId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_VEHICLE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ServiceID] = @Original_ServiceID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalServiceIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}

