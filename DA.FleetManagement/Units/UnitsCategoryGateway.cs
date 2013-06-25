using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsCategoryGateway
    /// </summary>
    public class UnitsCategoryGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsCategoryGateway()
            : base("LFS_FM_UNIT_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsCategoryGateway(DataSet data)
            : base(data, "LFS_FM_UNIT_CATEGORY")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsTDS();
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
            tableMapping.DataSetTable = "LFS_FM_UNIT_CATEGORY";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_UNIT_CATEGORY] WHERE (([UnitID] = @Original_UnitID) AND" +
                " ([CategoryID] = @Original_CategoryID) AND ([Deleted] = @Original_Deleted) AND (" +
                "[COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_UNIT_CATEGORY] ([UnitID], [CategoryID], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @CategoryID, @Deleted, @COMPANY_ID);
SELECT UnitID, CategoryID, Deleted, COMPANY_ID FROM LFS_FM_UNIT_CATEGORY WHERE (CategoryID = @CategoryID) AND (UnitID = @UnitID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_UNIT_CATEGORY] SET [UnitID] = @UnitID, [CategoryID] = @CategoryID, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([UnitID] = @Original_UnitID) AND ([CategoryID] = @Original_CategoryID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT UnitID, CategoryID, Deleted, COMPANY_ID FROM LFS_FM_UNIT_CATEGORY WHERE (CategoryID = @CategoryID) AND (UnitID = @UnitID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CategoryID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CategoryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByCategoryId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSCATEGORYGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCategoryId
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByCategoryId(int categoryId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSCATEGORYGATEWAY_LOADBYCATEGORYID", new SqlParameter("@categoryId", categoryId), new SqlParameter("@companyId", companyId));
            return Data;
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int unitId, int categoryId, bool deleted, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_FM_UNIT_CATEGORY] ([UnitID], [CategoryID], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @CategoryID, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, unitIdParameter, categoryIdParameter, deletedParameter, companyIdParameter);            
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int unitId, int categoryId, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_UNIT_CATEGORY] SET  [Deleted] = @Deleted WHERE (([UnitID] = @UnitID) AND ([CategoryID] = @CategoryID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, unitIdParameter, categoryIdParameter, companyIdParameter, deletedParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// UnDelete
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        public void UnDelete(int unitId, int categoryId, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter categoryIdParameter = new SqlParameter("CategoryID", categoryId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", SqlDbType.Bit);
            deletedParameter.Value = 0;

            string command = "UPDATE [dbo].[LFS_FM_UNIT_CATEGORY] SET  [Deleted] = @Deleted WHERE (([UnitID] = @UnitID) AND ([CategoryID] = @CategoryID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, unitIdParameter, categoryIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// IsUsedInUnitCategory
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInUnitCategory(int unitId, int categoryId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT_CATEGORY WHERE (UnitID = @unitId) AND (CategoryID = @categoryId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInUnitCategory
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInUnitCategory(int unitId, int categoryId, bool deleted)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT_CATEGORY WHERE (UnitID = @unitId) AND (CategoryID = @categoryId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInUnitCategory
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInUnitCategory(int categoryId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT_CATEGORY WHERE (CategoryID = @categoryId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@categoryId", categoryId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }
        

        
    }
}



