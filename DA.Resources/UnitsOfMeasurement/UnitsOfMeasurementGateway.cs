using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.UnitsOfMeasurement
{
    /// <summary>
    /// UnitsOfMeasurementGateway
    /// </summary>
    public class UnitsOfMeasurementGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsOfMeasurementGateway()
            : base("LFS_RESOURCES_UNITS_OF_MEASUREMENT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsOfMeasurementGateway(DataSet data)
            : base(data, "LFS_RESOURCES_UNITS_OF_MEASUREMENT")
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
            tableMapping.DataSetTable = "LFS_RESOURCES_UNITS_OF_MEASUREMENT";
            tableMapping.ColumnMappings.Add("UnitOfMeasurementID", "UnitOfMeasurementID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Abbreviation", "Abbreviation");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT] WHERE (([UnitOfMeasurementID] = @Original_UnitOfMeasurementID) AND ([Description] = @Original_Description) AND ([Abbreviation] = @Original_Abbreviation) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Abbreviation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Abbreviation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;

            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT] ([UnitOfMeasurementID], [Description], [Abbreviation], [Deleted], [COMPANY_ID]) VALUES (@UnitOfMeasurementID, @Description, @Abbreviation, @Deleted, @COMPANY_ID);
SELECT UnitOfMeasurementID, Description, Abbreviation, Deleted, COMPANY_ID FROM LFS_RESOURCES_UNITS_OF_MEASUREMENT WHERE (UnitOfMeasurementID = @UnitOfMeasurementID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Abbreviation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Abbreviation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;

            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT] SET [UnitOfMeasurementID] = @UnitOfMeasurementID, [Description] = @Description, [Abbreviation] = @Abbreviation, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([UnitOfMeasurementID] = @Original_UnitOfMeasurementID) AND ([Description] = @Original_Description) AND ([Abbreviation] = @Original_Abbreviation) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT UnitOfMeasurementID, Description, Abbreviation, Deleted, COMPANY_ID FROM LFS_RESOURCES_UNITS_OF_MEASUREMENT WHERE (UnitOfMeasurementID = @UnitOfMeasurementID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Abbreviation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Abbreviation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurementID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurementID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Abbreviation", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Abbreviation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByUnitOfMeasurementId
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByUnitOfMeasurementId(int unitOfMeasurementId, int companyId)
        {
            //FillDataWithStoredProcedure("LFS_RESOURCES_UNITSOFMEASUREMENTGATEWAY_LOADBYEUNITOFMEASUREMENTID", new SqlParameter("@unitOfMeasurementId", unitOfMeasurementId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByDescription
        /// </summary>
        /// <param name="description">description</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByDescription(string description, int companyId)
        {
            //FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSGATEWAY_LOADBYDESCRIPTION", new SqlParameter("@description", description), new SqlParameter("@companyId", companyId));
            return Data;
        }



        

        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a unit of measurement (direct to DB)
        /// </summary>
        /// <param name="unitOfMeasurementId">unitOfMeasurementId</param>       
        /// <param name="description">description</param>
        /// <param name="abreviation">abreviation</param>
        /// <param name="deleted">deleted</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int unitOfMeasurementId, string description, string abreviation, bool deleted, int companyId)
        {
            SqlParameter unitOfMeasurementIdParameter = new SqlParameter("UnitOfMeasurementID", unitOfMeasurementId);
            SqlParameter descriptionParameter = (description.Trim() != "") ? new SqlParameter("Description", description.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter abreviationParameter = (abreviation.Trim() != "") ? new SqlParameter("Abbreviation", abreviation.Trim()) : new SqlParameter("Abbreviation", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT] "+
                " ([UnitOfMeasurementID], [Description], [Abbreviation], [Deleted], [COMPANY_ID]) "+
                " VALUES (@UnitOfMeasurementID, @Description, @Abbreviation, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, unitOfMeasurementIdParameter, descriptionParameter, abreviationParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update a unit of measurement (direct to DB)
        /// </summary>
        /// <param name="originalUnitOfMeasurementId">originalUnitOfMeasurementId</param>       
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalAbbreviation">originalAbbreviation</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newDescription">newDescription</param>
        /// <param name="newAbbreviation">newAbbreviation</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalMaterialId, string originalDescription, string originalAbbreviation, bool originalDeleted, int originalCompanyId, int newMaterialId, string newDescription, string newAbbreviation, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalUnitOfMeasurementIdParameter = new SqlParameter("Original_UnitOfMeasurementID", originalMaterialId);
            SqlParameter originalDescriptionParameter = (originalDescription.Trim() != "") ? new SqlParameter("Original_Description", originalDescription.Trim()) : new SqlParameter("Original_Description", DBNull.Value);
            SqlParameter originalAbbreviationParameter = (originalAbbreviation.Trim() != "") ? new SqlParameter("Original_Abbreviation", originalAbbreviation.Trim()) : new SqlParameter("Original_Abbreviation", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newUnitOfMeasurementIdParameter = new SqlParameter("UnitOfMeasurementID", newMaterialId);
            SqlParameter newDescriptionParameter = (newDescription.Trim() != "") ? new SqlParameter("Description", newDescription.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter newAbbreviationParameter = (newAbbreviation.Trim() != "") ? new SqlParameter("Abbreviation", newAbbreviation.Trim()) : new SqlParameter("Abbreviation", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT] SET [UnitOfMeasurementID] = @UnitOfMeasurementID, [Description] = @Description, [Abbreviation] = @Abbreviation " +
            " WHERE ([UnitOfMeasurementID] = @Original_UnitOfMeasurementID) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitOfMeasurementIdParameter, originalDescriptionParameter, originalAbbreviationParameter, originalDeletedParameter, originalCompanyIdParameter, newUnitOfMeasurementIdParameter, newDescriptionParameter, newAbbreviationParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a unit of measurement (direct to DB)
        /// </summary>
        /// <param name="originalUnitOfMeasurementId">originalUnitOfMeasurementId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>int</returns>
        public int Delete(int originalUnitOfMeasurementId, int companyId)
        {
            SqlParameter originalUnitOfMeasurementIdParameter = new SqlParameter("@Original_UnitOfMeasurementID", originalUnitOfMeasurementId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_UNITS_OF_MEASUREMENT] SET  [Deleted] = @Deleted  " +
                             " WHERE ([UnitOfMeasurementID] = @Original_UnitOfMeasurementID)  ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitOfMeasurementIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }

    }
}