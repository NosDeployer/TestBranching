using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsCostHistoryExceptionsGateway
    /// </summary>
    public class MaterialsCostHistoryExceptionsGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsCostHistoryExceptionsGateway()
            : base("LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsCostHistoryExceptionsGateway(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS";
            tableMapping.ColumnMappings.Add("CostID", "CostID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND ([MaterialID] = @Original_MaterialID) AND ([Work_] = @Original_Work_) AND ([Function_] = @Original_Function_) AND ([UnitOfMeasurement] = @Original_UnitOfMeasurement) AND ([CostCad] = @Original_CostCad) AND ([CostUsd] = @Original_CostUsd) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] ([CostID], [RefID], [MaterialID], [Work_], [Function_], [UnitOfMeasurement], [CostCad], [CostUsd], [Deleted], [COMPANY_ID]) VALUES (@CostID, @RefID, @MaterialID, @Work_, @Function_, @UnitOfMeasurement, @CostCad, @CostUsd, @Deleted, @COMPANY_ID);
SELECT CostID, RefID, MaterialID, Work_, Function_, UnitOfMeasurement, CostCad, CostUsd, Deleted, COMPANY_ID FROM LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS WHERE (CostID = @CostID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));


            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] SET [CostID] = @CostID, [RefID] = @RefID, [MaterialID] = @MaterialID, [Work_] = @Work_, [Function_] = @Function_, [UnitOfMeasurement] = @UnitOfMeasurement, [CostCad] = @CostCad, [CostUsd] = @CostUsd, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND ([MaterialID] = @Original_MaterialID) AND ([Work_] = @Original_Work_) AND ([Function_] = @Original_Function_) AND ([UnitOfMeasurement] = @Original_UnitOfMeasurement) AND ([CostCad] = @Original_CostCad) AND ([CostUsd] = @Original_CostUsd) AND ((@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT CostID, RefID, MaterialID, Work_, Function_, UnitOfMeasurement, CostCad, CostUsd, Deleted, COMPANY_ID FROM LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS WHERE (CostID = @CostID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Work_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Work_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Function_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Function_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitOfMeasurement", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitOfMeasurement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CostUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CostUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Deleted", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }

        



        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a material cost exceptions (direct to DB)
        /// </summary>
        /// <param name="costId">costId</param>
        /// <param name="refId">refId</param>
        /// <param name="materialId">materialId</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="costCad">costCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int costId, int refId, int materialId, string work_, string function_,  string unitOfMeasurement, decimal costCad, decimal costUsd,  bool deleted, int companyId)
        {
            SqlParameter costIdParameter = new SqlParameter("CostID", costId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter materialIdParameter = new SqlParameter("MaterialID", materialId);
            SqlParameter workIdParameter = new SqlParameter("Work_", work_);
            SqlParameter functionIdParameter = new SqlParameter("Function_", function_);                        
            SqlParameter unitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", unitOfMeasurement);
            SqlParameter costCadParameter = new SqlParameter("CostCad", costCad);
            costCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter costUsdParameter = new SqlParameter("CostUsd", costUsd);
            costUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] "+
                "([CostID], [RefID], [MaterialID], [Work_], [Function_], [UnitOfMeasurement], [CostCad], [CostUsd], [Deleted], [COMPANY_ID]) VALUES (@CostID, @RefID, @MaterialID, @Work_, @Function_, @UnitOfMeasurement, @CostCad, @CostUsd, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, costIdParameter, refIdParameter, materialIdParameter, workIdParameter, functionIdParameter, unitOfMeasurementParameter, costCadParameter, costUsdParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update material cost exceptions (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalWork">originalWork</param>
        /// <param name="originalFunction">originalFunction</param>
        /// <param name="originalUnitOfMeasurement">originalUnitOfMeasurement</param>
        /// <param name="originalCostCad">originalCostCad</param>
        /// <param name="originalCostUsd">originalCostUsd</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newCostId">newCostId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newMaterialId">newMaterialId</param>
        /// <param name="newWork">newWork</param>
        /// <param name="newFunction">newFunction</param>
        /// <param name="newUnitOfMeasurement">newUnitOfMeasurement</param>
        /// <param name="newCostCad">newCostCad</param>
        /// <param name="newCostUsd">newCostUsd</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalCostId, int originalRefId, int originalMaterialId, string originalWork, string originalFunction, string originalUnitOfMeasurement, decimal originalCostCad, decimal originalCostUsd,  bool originalDeleted, int originalCompanyId, int newCostId, int newRefId, int newMaterialId, string newWork, string newFunction, string newUnitOfMeasurement, decimal newCostCad, decimal newCostUsd, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalCostIdParameter = new SqlParameter("Original_CostID", originalCostId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalMaterialIdParameter = new SqlParameter("Original_MaterialID", originalMaterialId);
            SqlParameter originalWorkParameter = new SqlParameter("Original_Work_", originalWork);
            SqlParameter originalFunctionIdParameter = new SqlParameter("Original_Function_", originalFunction);
            SqlParameter originalUnitOfMeasurementParameter = new SqlParameter("Original_UnitOfMeasurement", originalUnitOfMeasurement);
            SqlParameter originalCostCadParameter = new SqlParameter("Original_CostCad", originalCostCad);
            originalCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalCostUsdParameter = new SqlParameter("Original_CostUsd", originalCostUsd);
            originalCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);            
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newCostIdParameter = new SqlParameter("CostID", newCostId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newMaterialIdParameter = new SqlParameter("MaterialID", newMaterialId);
            SqlParameter newWorkParameter = new SqlParameter("Work_", newWork);
            SqlParameter newFunctionParameter = new SqlParameter("Function_", newFunction);
            SqlParameter newUnitOfMeasurementParameter = new SqlParameter("UnitOfMeasurement", newUnitOfMeasurement);
            SqlParameter newCostCadParameter = new SqlParameter("CostCad", newCostCad);
            newCostCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newCostUsdParameter = new SqlParameter("CostUsd", newCostUsd);
            newCostUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] "+
                " SET  [UnitOfMeasurement] = @UnitOfMeasurement, [CostCad] = @CostCad, "+
                " [CostUsd] = @CostUsd "+
                " WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND "+
                " ([Work_] = @Original_Work_) AND ([Function_] = @Original_Function_) " +
                " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostIdParameter, originalRefIdParameter, originalMaterialIdParameter, originalWorkParameter, originalFunctionIdParameter, originalUnitOfMeasurementParameter, originalCostCadParameter, originalCostUsdParameter, originalDeletedParameter, originalCompanyIdParameter, newCostIdParameter, newRefIdParameter, newMaterialIdParameter, newWorkParameter, newFunctionParameter, newUnitOfMeasurementParameter, newCostCadParameter, newCostUsdParameter, newDeletedParameter, newCompanyIdParameter); 

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


        
        /// <summary>
        /// Delete a material cost exceptions (direct to DB)
        /// </summary>
        /// <param name="originalCostId">originalCostId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalCostId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalCostIdParameter = new SqlParameter("@Original_CostID", originalCostId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([CostID] = @Original_CostID) AND ([RefID] = @Original_RefID) AND " +                             
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCostIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all materials costs exceptions (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int DeleteAll(int originalMaterialId, int originalCompanyId)
        {
            SqlParameter originalMaterialIdParameter = new SqlParameter("@Original_MaterialID", originalMaterialId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL_COST_HISTORY_EXCEPTIONS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([MaterialID] = @Original_MaterialID) " +                
                             " AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalMaterialIdParameter, originalCompanyIdParameter, deletedParameter);

            return rowsAffected;
        }



    }
}

