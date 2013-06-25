using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.FleetManagement.Categories
{
    /// <summary>
    /// CategoryGateway
    /// </summary>
    public class CategoryGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CategoryGateway()
            : base("LFS_FM_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CategoryGateway(DataSet data)
            : base(data, "LFS_FM_CATEGORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CategoriesTDS();
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
            tableMapping.DataSetTable = "LFS_FM_CATEGORY";
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ParentID", "ParentID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_CATEGORY] WHERE (([CategoryID] = @Original_CategoryID) AND ([Type] = @Original_Type) AND ([Name] = @Original_Name) AND ((@IsNull_ParentID = 1 AND [ParentID] IS NULL) OR ([ParentID] = @Original_ParentID)) AND ([Deleted] = @Original_Deleted) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_CATEGORY] ([Type], [Name], [ParentID], [Deleted], [COMPANY_ID]) VALUES (@Type, @Name, @ParentID, @Deleted, @COMPANY_ID);
SELECT CategoryID, Type, Name, ParentID, Deleted, COMPANY_ID FROM LFS_FM_CATEGORY WHERE (CategoryID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_CATEGORY] SET [Type] = @Type, [Name] = @Name, [ParentID] = @ParentID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([CategoryID] = @Original_CategoryID) AND ([Type] = @Original_Type) AND ([Name] = @Original_Name) AND ((@IsNull_ParentID = 1 AND [ParentID] IS NULL) OR ([ParentID] = @Original_ParentID)) AND ([Deleted] = @Original_Deleted) AND ((@IsNull_COMPANY_ID = 1 AND [COMPANY_ID] IS NULL) OR ([COMPANY_ID] = @Original_COMPANY_ID)));
SELECT CategoryID, Type, Name, ParentID, Deleted, COMPANY_ID FROM LFS_FM_CATEGORY WHERE (CategoryID = @CategoryID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ParentID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ParentID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

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
            FillDataWithStoredProcedure("LFS_FM_CATEGORYGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }
        

        
        /// <summary>
        /// LoadByCategoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByCategoryId(int categoryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_CATEGORYGATEWAY_LOADBYCATEGORYID", new SqlParameter("@categoryId", categoryId), new SqlParameter("@companyId", companyId));
            return Data;
        }


                
        /// <summary>
        /// LoadByUnitType
        /// </summary>
        /// <param name="unitType">unitType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByUnitType(string unitType, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_CATEGORYGATEWAY_LOADBYUNITTYPE", new SqlParameter("@unitType", unitType), new SqlParameter("@companyId", companyId));
            return Data;
        }


        
        /// <summary>
        /// LoadByParentId
        /// </summary>
        /// <param name="parentId">parentId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByParentId(int parentId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_CATEGORYGATEWAY_LOADBYPARENTID", new SqlParameter("@parentId", parentId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int categoryId)
        {
            string filter = string.Format("CategoryID = {0}", categoryId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Categories.CategoryGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>Name</returns>
        public string GetName(int categoryId)
        {
            return (string)GetRow(categoryId)["Name"];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>Type</returns>
        public string GetType(int categoryId)
        {
            return (string)GetRow(categoryId)["Type"];
        }



        /// <summary>
        /// GetParentId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>ParendId</returns>
        public int? GetParentId(int categoryId)
        {
            if (GetRow(categoryId).IsNull("ParentID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(categoryId)["ParentID"];
            }            
        }



        /// <summary>
        /// GetDeleted
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>Deleted</returns>
        public bool GetDeleted(int categoryId)
        {
            return (bool)GetRow(categoryId)["Deleted"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="name">name</param>
        /// <param name="parentId">parentId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(string type, string name, int? parentId, bool deleted, int companyId)
        {
            SqlParameter typeParameter = new SqlParameter("Type", type);
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter parentIdParamater = (parentId.HasValue) ? new SqlParameter("ParentID", (int)parentId) : new SqlParameter("ParentID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
                        
            string command = "INSERT INTO [dbo].[LFS_FM_CATEGORY] ([Type], [Name], [ParentID], [Deleted], [COMPANY_ID]) VALUES (@Type, @Name, @ParentID, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, typeParameter, nameParameter, parentIdParamater, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalCategoryId">originalCategoryId</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalParentId">originalParentId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newCategoryId">newCategoryId</param>
        /// <param name="newType">newType</param>
        /// <param name="newName">newName</param>
        /// <param name="newParentId">newParentId</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalCategoryId, string originalType, string originalName, int? originalParentId, bool originalDeleted, int originalCompanyId, int newCategoryId, string newType, string newName, int? newParentId, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalCategoryIdParameter = new SqlParameter("Original_CategoryID", originalCategoryId);
            SqlParameter originalTypeParameter = new SqlParameter("Original_Type", originalType);
            SqlParameter originalNameParameter = new SqlParameter("Original_Name", originalName);
            SqlParameter originalParentIdParameter = (originalParentId.HasValue) ? new SqlParameter("Original_ParentID", (int)originalParentId) : new SqlParameter("Original_ParentID", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newCategoryIdParameter = new SqlParameter("CategoryID", newCategoryId);
            SqlParameter newTypeParameter = new SqlParameter("Type", newType);
            SqlParameter newNameParameter = new SqlParameter("Name", newName);
            SqlParameter newParentIdParameter = (newParentId.HasValue) ? new SqlParameter("ParentID", (int)newParentId) : new SqlParameter("ParentID", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_CATEGORY] SET [Type] = @Type, [Name] = @Name, [ParentID] = @ParentID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID "+
                "WHERE (" +
                "([CategoryID] = @Original_CategoryID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCategoryIdParameter, originalTypeParameter, originalNameParameter, originalParentIdParameter, originalDeletedParameter, originalCompanyIdParameter, newCategoryIdParameter, newTypeParameter, newNameParameter, newParentIdParameter, newDeletedParameter, newCompanyIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int categoryId, int companyId)
        {
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_CATEGORY] SET [Deleted] = @Deleted WHERE (([CategoryID] = @CategoryID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, categoryIdParameter, companyIdParameter, deletedParameter);

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
        /// <returns>amount of rows</returns>
        public int CountByParentId(int parentId, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_CATEGORY C WHERE (C.ParentID = @parentId) AND (C.COMPANY_ID = @companyId) AND (C.Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@parentId", parentId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command));
        }



        /// <summary>
        /// GetParentId
        /// </summary>
        /// <returns>ParentId</returns>
        /// <param name="category">category</param>
        /// <param name="companyId">companyId</param>
        public int GetCategoryId(string category)
        {
            string commandText = "SELECT CategoryID FROM LFS_FM_CATEGORY WHERE (Name = @name) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@name",  category));

            if (ExecuteScalar(command) == DBNull.Value)
            {
                return 1;
            }
            else
            {
                return ((int)ExecuteScalar(command));
            }
        }
        


    }
}