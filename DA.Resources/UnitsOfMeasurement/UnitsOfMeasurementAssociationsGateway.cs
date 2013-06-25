using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementAssociationsGateway
    /// </summary>
    public class UnitsOfMeasurementAssociationsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementAssociationsGateway()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementAssociationsGateway(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsOfMeasurementTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS";
            tableMapping.ColumnMappings.Add("AssociationsID", "AssociationsID");
            tableMapping.ColumnMappings.Add("UnitOfMeasurementID", "UnitOfMeasurementID");
            tableMapping.ColumnMappings.Add("Module", "Module");
            tableMapping.ColumnMappings.Add("ByDefault", "ByDefault");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS] WHERE (([AssociationsID] = @Original_AssociationsID) AND ([UnitOfMeasurementID] = @Original_UnitOfMeasurementID) AND ([Module] = @Original_Module) AND ([ByDefault] = @Original_ByDefault) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssociationsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssociationsID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Module", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Module", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ByDefault", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ByDefault", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;

            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS] ([AssociationsID], [UnitOfMeasurementID], [Module], [ByDefault], [Deleted], [COMPANY_ID]) VALUES (@AssociationsID, @UnitOfMeasurementID, @Module, @ByDefault, @Deleted, @COMPANY_ID);
SELECT AssociationsID, UnitOfMeasurementID, Module, ByDefault, Deleted, COMPANY_ID FROM LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS WHERE (AssociationsID = @AssociationsID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssociationsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssociationsID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Module", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Module", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ByDefault", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ByDefault", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;

            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS] SET [AssociationsID] = @AssociationsID, [UnitOfMeasurementID] = @UnitOfMeasurementID, [Module] = @Module, [ByDefault] = @ByDefault, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([AssociationsID] = @Original_AssociationsID) AND ([UnitOfMeasurementID] = @Original_UnitOfMeasurementID) AND ([Module] = @Original_Module) AND ([ByDefault] = @Original_ByDefault) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT AssociationsID, UnitOfMeasurementID, Module, ByDefault, Deleted, COMPANY_ID FROM LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS WHERE (AssociationsID = @AssociationsID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssociationsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssociationsID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Module", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Module", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ByDefault", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ByDefault", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssociationsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssociationsID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Module", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Module", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ByDefault", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ByDefault", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert an association (direct to DB)
        /// </summary>
        /// <param name="associationsId">associationsId</param>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>       
        /// <param name="module">module</param>
        /// <param name="byDefault">byDefault</param>
        /// <param name="deleted">deleted</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int associationsId, int unitOfMeasurementId, string module, bool byDefault, bool deleted, int companyId)
        {
            SqlParameter unitOfMeasurementIdParameter = new SqlParameter("UnitOfMeasurementID", unitOfMeasurementId);
            SqlParameter moduleParameter = new SqlParameter("Module", module.Trim());
            SqlParameter byDefaultParameter = new SqlParameter("ByDefault", byDefault);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS] ([UnitOfMeasurementID], [Module], [ByDefault], [Deleted], [COMPANY_ID]) VALUES (@UnitOfMeasurementID, @Module, @ByDefault, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, unitOfMeasurementIdParameter, moduleParameter, byDefaultParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update an association (direct to DB)
        /// </summary>
        /// <param name="originalAssociationsId">originalAssociationsId</param>
        /// <param name="originalUnitOfMeasurementId">originalUnitOfMeasurementId</param>       
        /// <param name="originalModule">originalModule</param>
        /// <param name="originalByDefault">originalByDefault</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newAssociationsId">newAssociationsId</param>
        /// <param name="newUnitOfMeasurementId">newUnitOfMeasurementId</param>
        /// <param name="newModule">newModule</param>
        /// <param name="newByDefault">newByDefault</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalAssociationsId, int originalUnitOfMeasurementId, string originalModule, bool originalByDefault, bool originalDeleted, int originalCompanyId, int newAssociationsId, int newUnitOfMeasurementId, string newModule, bool newByDefault, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalAssociationsIdParameter = new SqlParameter("Original_AssociationsID", originalAssociationsId);
            SqlParameter originalUnitOfMeasurementIdParameter = new SqlParameter("Original_UnitOfMeasurementID", originalUnitOfMeasurementId);
            SqlParameter originalModuleParameter = (originalModule.Trim() != "") ? new SqlParameter("Original_Module", originalModule.Trim()) : new SqlParameter("Original_Module", DBNull.Value);
            SqlParameter originalByDefaultParameter = new SqlParameter("Original_ByDefault", originalByDefault);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newAssociationsIdParameter = new SqlParameter("AssociationsID", newAssociationsId);
            SqlParameter newUnitOfMeasurementIdParameter = new SqlParameter("UnitOfMeasurementID", newUnitOfMeasurementId);
            SqlParameter newModuleParameter = (newModule.Trim() != "") ? new SqlParameter("Module", newModule.Trim()) : new SqlParameter("Module", DBNull.Value);
            SqlParameter newByDefaultParameter =  new SqlParameter("ByDefault", newByDefault);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS] " +
                " SET [ByDefault] = @ByDefault " +
                " WHERE ([AssociationsID] = @Original_AssociationsID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalAssociationsIdParameter, originalUnitOfMeasurementIdParameter, originalModuleParameter, originalByDefaultParameter, originalDeletedParameter, originalCompanyIdParameter, newAssociationsIdParameter, newUnitOfMeasurementIdParameter, newModuleParameter, newByDefaultParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete an association (direct to DB)
        /// </summary>
        /// <param name="originalAssociationsId">originalAssociationsId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>int</returns>
        public int Delete(int originalAssociationsId, int companyId)
        {
            SqlParameter originalAssociationsIdParameter = new SqlParameter("Original_AssociationsID", originalAssociationsId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT_ASSOCIATIONS] SET  [Deleted] = @Deleted  " +
                             " WHERE ([AssociationsID] = @Original_AssociationsID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalAssociationsIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }

    }
}