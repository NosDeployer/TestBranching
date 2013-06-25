using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesCostGateway
    /// </summary>
    public class ServicesCostGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesCostGateway()
            : base("LFS_FM_SERVICE_COST")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesCostGateway(DataSet data)
            : base(data, "LFS_FM_SERVICE_COST")
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
            tableMapping.DataSetTable = "LFS_FM_SERVICE_COST";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("PartNumber", "PartNumber");
            tableMapping.ColumnMappings.Add("PartName", "PartName");
            tableMapping.ColumnMappings.Add("Vendor", "Vendor");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("NoteID", "NoteID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_SERVICE_COST] WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND ((@IsNull_PartNumber = 1 AND [PartNumber] IS NULL) OR ([PartNumber] = @Original_PartNumber)) AND ([PartName] = @Original_PartName) AND ((@IsNull_Vendor = 1 AND [Vendor] IS NULL) OR ([Vendor] = @Original_Vendor)) AND ([Cost] = @Original_Cost) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_NoteID = 1 AND [NoteID] IS NULL) OR ([NoteID] = @Original_NoteID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PartNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PartNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PartName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Vendor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Vendor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Vendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Vendor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NoteID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoteID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NoteID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoteID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_SERVICE_COST] ([ServiceID], [RefID], [PartNumber], [PartName], [Vendor], [Cost], [Deleted], [COMPANY_ID], [NoteID]) VALUES (@ServiceID, @RefID, @PartNumber, @PartName, @Vendor, @Cost, @Deleted, @COMPANY_ID, @NoteID);
SELECT ServiceID, RefID, PartNumber, PartName, Vendor, Cost, Deleted, COMPANY_ID, NoteID FROM LFS_FM_SERVICE_COST WHERE (RefID = @RefID) AND (ServiceID = @ServiceID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PartNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PartName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Vendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Vendor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NoteID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoteID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_SERVICE_COST] SET [ServiceID] = @ServiceID, [RefID] = @RefID, [PartNumber] = @PartNumber, [PartName] = @PartName, [Vendor] = @Vendor, [Cost] = @Cost, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [NoteID] = @NoteID WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND ((@IsNull_PartNumber = 1 AND [PartNumber] IS NULL) OR ([PartNumber] = @Original_PartNumber)) AND ([PartName] = @Original_PartName) AND ((@IsNull_Vendor = 1 AND [Vendor] IS NULL) OR ([Vendor] = @Original_Vendor)) AND ([Cost] = @Original_Cost) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_NoteID = 1 AND [NoteID] IS NULL) OR ([NoteID] = @Original_NoteID)));
SELECT ServiceID, RefID, PartNumber, PartName, Vendor, Cost, Deleted, COMPANY_ID, NoteID FROM LFS_FM_SERVICE_COST WHERE (RefID = @RefID) AND (ServiceID = @ServiceID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PartNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PartName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Vendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Vendor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NoteID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoteID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ServiceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ServiceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PartNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PartNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PartName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PartName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Vendor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Vendor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Vendor", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Vendor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NoteID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoteID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NoteID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NoteID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a service cost (direct to DB)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="partNumber">partNumber</param>
        /// <param name="partName">partName</param>
        /// <param name="vendor">vendor</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="noteId">noteId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int serviceId, int refId, string partNumber, string partName, string vendor, decimal cost, bool deleted, int companyId, int? noteId)
        {
            SqlParameter serviceIdParameter = new SqlParameter("ServiceID", serviceId);
            SqlParameter originalRefIdParameter = new SqlParameter("RefID", refId);
            SqlParameter partNumberParameter = (partNumber.Trim() != "") ? new SqlParameter("PartNumber", partNumber.Trim()) : new SqlParameter("PartNumber", DBNull.Value);
            SqlParameter partNameParameter = (partName.Trim() != "") ? new SqlParameter("PartName", partName.Trim()) : new SqlParameter("PartName", DBNull.Value);
            SqlParameter vendorParameter = (vendor.Trim() != "") ? new SqlParameter("Vendor", vendor.Trim()) : new SqlParameter("Vendor", DBNull.Value);
            SqlParameter costParameter = new SqlParameter("Cost", cost); costParameter.SqlDbType = SqlDbType.Money;          
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter noteIdParameter = (noteId.HasValue) ? new SqlParameter("NoteID", noteId.Value) : new SqlParameter("NoteID", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_FM_SERVICE_COST] ([ServiceID], [RefID], [PartNumber], [PartName], [Vendor], [Cost], [Deleted], [COMPANY_ID], [NoteID]) VALUES (@ServiceID, @RefID, @PartNumber, @PartName, @Vendor, @Cost, @Deleted, @COMPANY_ID, @NoteID)";
            int rowsAffected = (int)ExecuteNonQuery(command, serviceIdParameter, originalRefIdParameter, partNumberParameter, partNameParameter, vendorParameter, costParameter, deletedParameter, companyIdParameter, noteIdParameter);
            return rowsAffected;
        }



        /// <summary>
        /// Update service cost (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalPartNumber">originalPartNumber</param>
        /// <param name="originalPartName">originalPartName</param>
        /// <param name="originalVendor">originalVendor</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalDeleted">originalDeleted</param> 
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalNoteId">originalNoteId</param>
        ///
        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newPartNumber">newPartNumber</param>
        /// <param name="newPartName">newPartName</param>
        /// <param name="newVendor">newVendor</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newNoteId">newNoteId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalServiceId, int originalRefId, string originalPartNumber, string originalPartName, string originalVendor, decimal originalCost, bool originalDeleted, int originalCompanyId, int? originalNoteId, int newServiceId, int newRefId, string newPartNumber, string newPartName, string newVendor, decimal newCost, bool newDeleted, int newCompanyId, int? newNoteId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("Original_ServiceID", originalServiceId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalPartNumberParameter = (originalPartNumber != "") ? new SqlParameter("Original_PartNumber", originalPartNumber) : new SqlParameter("Original_PartNumber", DBNull.Value);
            SqlParameter originalPartNameParameter = (originalPartName != "") ? new SqlParameter("Original_PartName", originalPartName) : new SqlParameter("Original_PartName", DBNull.Value);
            SqlParameter originalVendorParameter = (originalVendor != "") ? new SqlParameter("Original_Vendor", originalVendor) : new SqlParameter("Original_Vendor", DBNull.Value);
            SqlParameter originalCostParameter = new SqlParameter("Original_Cost", originalCost); originalCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalNoteIdParameter = (originalNoteId.HasValue) ? new SqlParameter("Original_NoteID", originalNoteId.Value) : new SqlParameter("Original_NoteID", DBNull.Value);

            SqlParameter newServiceIdParameter = new SqlParameter("ServiceID", originalServiceId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newPartNumberParameter = (newPartNumber.Trim() != "") ? new SqlParameter("PartNumber", newPartNumber.Trim()) : new SqlParameter("PartNumber", DBNull.Value);
            SqlParameter newPartNameParameter = (newPartName.Trim() != "") ? new SqlParameter("PartName", newPartName.Trim()) : new SqlParameter("PartName", DBNull.Value);
            SqlParameter newVendorParameter = (newVendor.Trim() != "") ? new SqlParameter("Vendor", newVendor.Trim()) : new SqlParameter("Vendor", DBNull.Value);
            SqlParameter newCostParameter = new SqlParameter("Cost", newCost); newCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newNoteIdParameter = (newNoteId.HasValue) ? new SqlParameter("NoteID", newNoteId.Value) : new SqlParameter("NoteID", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_COST] SET [ServiceID] = @ServiceID, [RefID] = @RefID, "+
                " [PartNumber] = @PartNumber, [PartName] = @PartName, [Vendor] = @Vendor, [Cost] = @Cost, "+
                " [Deleted] = @Deleted, [NoteID] = @NoteID "+
                " WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND [COMPANY_ID] = @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalServiceIdParameter, originalRefIdParameter, originalPartNumberParameter, originalPartNameParameter, originalVendorParameter, originalCostParameter, originalDeletedParameter, originalCompanyIdParameter, originalNoteIdParameter, newServiceIdParameter, newRefIdParameter, newPartNumberParameter, newPartNameParameter, newVendorParameter, newCostParameter, newDeletedParameter, newCompanyIdParameter, newNoteIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a service cost (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalServiceId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("@Original_ServiceID", originalServiceId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_COST] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ServiceID] = @Original_ServiceID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery( command, originalServiceIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all service costs (direct to DB)
        /// </summary>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalServiceId, int originalCompanyId)
        {
            SqlParameter originalServiceIdParameter = new SqlParameter("@Original_ServiceID", originalServiceId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_SERVICE_COST] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ServiceID] = @Original_ServiceID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalServiceIdParameter,  originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}