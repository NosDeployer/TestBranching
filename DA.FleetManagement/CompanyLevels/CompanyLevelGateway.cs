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
    public class CompanyLevelGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyLevelGateway()
            : base("LFS_FM_COMPANYLEVEL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompanyLevelGateway(DataSet data)
            : base(data, "LFS_FM_COMPANYLEVEL")
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
            tableMapping.DataSetTable = "LFS_FM_COMPANYLEVEL";
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ParentID", "ParentID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("UnitsUnitOfMeasurement", "UnitsUnitOfMeasurement");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_COMPANYLEVEL] WHERE (([CompanyLevelID] = @Original_CompanyLevelID) AND ([Name] = @Original_Name) AND ((@IsNull_ParentID = 1 AND [ParentID] IS NULL) OR ([ParentID] = @Original_ParentID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_UnitsUnitOfMeasurement = 1 AND [UnitsUnitOfMeasurement] IS NULL) OR ([UnitsUnitOfMeasurement] = @Original_UnitsUnitOfMeasurement)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitsUnitOfMeasurement", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_COMPANYLEVEL] ([Name], [ParentID], [Deleted], [COMPANY_ID], [UnitsUnitOfMeasurement]) VALUES (@Name, @ParentID, @Deleted, @COMPANY_ID, @UnitsUnitOfMeasurement);
SELECT CompanyLevelID, Name, ParentID, Deleted, COMPANY_ID, UnitsUnitOfMeasurement FROM LFS_FM_COMPANYLEVEL WHERE (CompanyLevelID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitsUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_COMPANYLEVEL] SET [Name] = @Name, [ParentID] = @ParentID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [UnitsUnitOfMeasurement] = @UnitsUnitOfMeasurement WHERE (([CompanyLevelID] = @Original_CompanyLevelID) AND ([Name] = @Original_Name) AND ((@IsNull_ParentID = 1 AND [ParentID] IS NULL) OR ([ParentID] = @Original_ParentID)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_UnitsUnitOfMeasurement = 1 AND [UnitsUnitOfMeasurement] IS NULL) OR ([UnitsUnitOfMeasurement] = @Original_UnitsUnitOfMeasurement)));
SELECT CompanyLevelID, Name, ParentID, Deleted, COMPANY_ID, UnitsUnitOfMeasurement FROM LFS_FM_COMPANYLEVEL WHERE (CompanyLevelID = @CompanyLevelID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitsUnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_UnitsUnitOfMeasurement", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitsUnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitsUnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompanyLevelID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_COMPANYLEVELGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadNodes
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadNodes(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_COMPANYLEVELGATEWAY_LOADNODES", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByCompanyLevelId(int companyLevelId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_COMPANYLEVELGATEWAY_LOADBYCOMPANYLEVELID", new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@companyId", companyId));
            return Data;
        }


        
        /// <summary>
        /// LoadByParentId
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByParentId(int parentId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_COMPANYLEVELGATEWAY_LOADBYPARENTID", new SqlParameter("@parentId", parentId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int companyLevelId)
        {
            string filter = string.Format("CompanyLevelID = {0}", companyLevelId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels.CompanyLevelGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>CategoryName</returns>
        public string GetName(int companyLevelId)
        {
            return (string)GetRow(companyLevelId)["Name"];
        }


        /// <summary>
        /// GetParentId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>ParendId</returns>
        public int? GetParentId(int companyLevelId)
        {
            if (GetRow(companyLevelId).IsNull("ParentID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(companyLevelId)["ParentID"];
            } 
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int companyLevelId)
        {
            return (bool)GetRow(companyLevelId)["Deleted"];
        }



        /// <summary>
        /// GetUnitsUnitOfMeasurement
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>UnitsUnitOfMeasurement</returns>
        public string GetUnitsUnitOfMeasurement(int companyLevelId)
        {
            if (GetRow(companyLevelId).IsNull("UnitsUnitOfMeasurement"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(companyLevelId)["UnitsUnitOfMeasurement"];
            }
        }



        /// <summary>
        /// GetUnitsUnitOfMeasurement Original
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>        
        /// <returns>Original UnitsUnitOfMeasurement or EMPTY</returns>
        public string GetUnitsUnitOfMeasurementOriginal(int companyLevelId)
        {
            if (GetRow(companyLevelId).IsNull(Table.Columns["UnitsUnitOfMeasurement"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(companyLevelId)["UnitsUnitOfMeasurement", DataRowVersion.Original];
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitsUnitOfMeasurement">unitsUnitOfMeasurement</param>
        public int Insert(string name, int? parentId, bool deleted, int companyId, string unitsUnitOfMeasurement)
        {
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter parentIdParamater = (parentId.HasValue) ? new SqlParameter("ParentID", (int)parentId) : new SqlParameter("ParentID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter unitsUnitOfMeasurementParamater = (unitsUnitOfMeasurement.Trim() != "") ? new SqlParameter("UnitsUnitOfMeasurement", unitsUnitOfMeasurement.Trim()) : new SqlParameter("UnitsUnitOfMeasurement", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_FM_COMPANYLEVEL] ([Name], [ParentID], [Deleted], [COMPANY_ID], [UnitsUnitOfMeasurement]) "+
                " VALUES (@Name, @ParentID, @Deleted, @COMPANY_ID, @UnitsUnitOfMeasurement)";

            //int companyLevelId = (int)ExecuteScalar(command, nameParameter, parentIdParamater, deletedParameter, companyIdParameter, unitsUnitOfMeasurementParamater);
            //return companyLevelId;
            ExecuteScalar(command, nameParameter, parentIdParamater, deletedParameter, companyIdParameter, unitsUnitOfMeasurementParamater);
            return 1;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>        
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalUnitsUnitOfMeasurement">originalUnitsUnitOfMeasurement</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newUnitsUnitOfMeasurement">newUnitsUnitOfMeasurement</param>
        public void Update(int originalCompanyLevelId, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, string originalUnitsUnitOfMeasurement, int newCompanyLevelId, string newName, int? newParentId, bool newDeleted, int newCompanyId, string newUnitsUnitOfMeasurement)
        {
            SqlParameter originalCompanyLevelIdParameter = new SqlParameter("Original_CompanyLevelID", originalCompanyLevelId);
            SqlParameter originalNameParameter = new SqlParameter("Original_Name", originalName);
            SqlParameter originalParentIdParameter = (originalParentId.HasValue) ? new SqlParameter("Original_ParentID", (int)originalParentId) : new SqlParameter("Original_ParentID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalUnitsUnitOfMeasurementParamater = (originalUnitsUnitOfMeasurement.Trim() != "") ? new SqlParameter("Original_UnitsUnitOfMeasurement", originalUnitsUnitOfMeasurement.Trim()) : new SqlParameter("Original_UnitsUnitOfMeasurement", DBNull.Value);
            
            SqlParameter newCompanyLevelIdParameter = new SqlParameter("CompanyLevelID", newCompanyLevelId);
            SqlParameter newNameParameter = new SqlParameter("Name", newName);
            SqlParameter newParentIdParameter = (newParentId.HasValue) ? new SqlParameter("ParentID", (int)newParentId) : new SqlParameter("ParentID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newUnitsUnitOfMeasurementParamater = (newUnitsUnitOfMeasurement.Trim() != "") ? new SqlParameter("UnitsUnitOfMeasurement", newUnitsUnitOfMeasurement.Trim()) : new SqlParameter("UnitsUnitOfMeasurement", DBNull.Value);
            
            string command = "UPDATE [dbo].[LFS_FM_COMPANYLEVEL] "+
                " SET [Name] = @Name, [ParentID] = @ParentID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [UnitsUnitOfMeasurement] = @UnitsUnitOfMeasurement " +
                " WHERE (" +
                " ([CompanyLevelID] = @Original_CompanyLevelID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCompanyLevelIdParameter, originalNameParameter, originalParentIdParameter, originalDeletedParameter, originalCompanyIdParameter, originalUnitsUnitOfMeasurementParamater, newCompanyLevelIdParameter, newNameParameter, newParentIdParameter, newDeletedParameter, newCompanyIdParameter, newUnitsUnitOfMeasurementParamater);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int companyLevelId, int companyId)
        {
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_COMPANYLEVEL] SET [Deleted] = @Deleted WHERE (([CompanyLevelID] = @CompanyLevelID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, companyLevelIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// CountByParentId
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public int CountByParentId(int parentId, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_COMPANYLEVEL C WHERE (C.ParentID = @parentId) AND (C.COMPANY_ID = @companyId) AND (C.Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@parentId", parentId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command));
        }



        /// <summary>
        /// GetLastCompanyLevelId
        /// </summary>
        /// <returns>Last CompanyLevelID</returns>
        public int GetLastCompanyLevelId()
        {
            string commandText = "SELECT MAX(CompanyLevelID) AS companyLevelId FROM LFS_FM_COMPANYLEVEL";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            return ((int)ExecuteScalar(command));
        }
        


    }
}


