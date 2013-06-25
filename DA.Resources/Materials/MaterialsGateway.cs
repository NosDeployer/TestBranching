using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsGateway
    /// </summary>
    public class MaterialsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsGateway()
            : base("LFS_RESOURCES_MATERIAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsGateway(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL")
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
            tableMapping.DataSetTable = "LFS_RESOURCES_MATERIAL";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_MATERIAL] WHERE (([MaterialID] = @Original_MaterialID) AND ([Description] = @Original_Description) AND ((@IsNull_Size = 1 AND [Size] IS NULL) OR ([Size] = @Original_Size)) AND ((@IsNull_Length = 1 AND [Length] IS NULL) OR ([Length] = @Original_Length)) AND ((@IsNull_Thickness = 1 AND [Thickness] IS NULL) OR ([Thickness] = @Original_Thickness)) AND ([Type] = @Original_Type) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Length", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Thickness", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_MATERIAL] ([MaterialID], [Description], [Size], [Length], [Thickness], [Type], [State], [Deleted], [COMPANY_ID]) VALUES (@MaterialID, @Description, @Size, @Length, @Thickness, @Type, @State, @Deleted, @COMPANY_ID);
SELECT MaterialID, Description, Size, Length, Thickness, Type, State, Deleted, COMPANY_ID FROM LFS_RESOURCES_MATERIAL WHERE (MaterialID = @MaterialID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_MATERIAL] SET [MaterialID] = @MaterialID, [Description] = @Description, [Size] = @Size, [Length] = @Length, [Thickness] = @Thickness, [Type] = @Type, [State] = @State, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([MaterialID] = @Original_MaterialID) AND ([Description] = @Original_Description) AND ((@IsNull_Size = 1 AND [Size] IS NULL) OR ([Size] = @Original_Size)) AND ((@IsNull_Length = 1 AND [Length] IS NULL) OR ([Length] = @Original_Length)) AND ((@IsNull_Thickness = 1 AND [Thickness] IS NULL) OR ([Thickness] = @Original_Thickness)) AND ([Type] = @Original_Type) AND ([State] = @Original_State) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT MaterialID, Description, Size, Length, Thickness, Type, State, Deleted, COMPANY_ID FROM LFS_RESOURCES_MATERIAL WHERE (MaterialID = @MaterialID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Size", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MaterialID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MaterialID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Size", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Size", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Size", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Length", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Length", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Length", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Thickness", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Thickness", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Thickness", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByMaterialId(int materialId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSGATEWAY_LOADBYEMATERIALID", new SqlParameter("@materialId", materialId), new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSGATEWAY_LOADBYDESCRIPTION", new SqlParameter("@description", description), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="materialId">employeeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int materialId)
        {
            string filter = string.Format("MaterialID = {0}", materialId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Material.MaterialsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="description">description</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow2(string description)
        {
            string filter = string.Format("Description = '{0}'", description);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Material.MaterialsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Description</returns>
        public string GetDescription(int materialId)
        {
            return (string)GetRow(materialId)["Description"];
        }



        /// <summary>
        /// GetMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Description</returns>
        public int GetMaterialId(string description)
        {
            return (int)GetRow2(description)["MaterialID"];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Type</returns>
        public string GetType(int materialId)
        {
            return (string)GetRow(materialId)["Type"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a material (direct to DB)
        /// </summary>
        /// <param name="materialId">materialId</param>       
        /// <param name="description">description</param>
        /// <param name="size">size</param>
        /// <param name="length">length</param>
        /// <param name="thickness">thickness</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>        
        /// <param name="companyId">companyId</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int materialId, string description, string size, string length, string thickness, string type, string state, bool deleted, int companyId)
        {
            SqlParameter materialIdParameter = new SqlParameter("MaterialID", materialId);
            SqlParameter descriptionParameter = (description.Trim() != "") ? new SqlParameter("Description", description.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter sizeParameter = (size.Trim() != "") ? new SqlParameter("Size", size.Trim()) : new SqlParameter("Size", DBNull.Value);
            SqlParameter lengthParameter = (length.Trim() != "") ? new SqlParameter("Length", length.Trim()) : new SqlParameter("Length", DBNull.Value);
            SqlParameter thicknessParameter = (thickness.Trim() != "") ? new SqlParameter("Thickness", thickness.Trim()) : new SqlParameter("Thickness", DBNull.Value);
            SqlParameter typeParameter = (type.Trim() != "") ? new SqlParameter("Type", type.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter stateParameter = (state.Trim() != "") ? new SqlParameter("State", state.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_MATERIAL] ([MaterialID], [Description], [Size], [Length], [Thickness], [Type], [State], [Deleted], [COMPANY_ID]) VALUES (@MaterialID, @Description, @Size, @Length, @Thickness, @Type, @State, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, materialIdParameter, descriptionParameter, sizeParameter, lengthParameter, thicknessParameter, typeParameter, stateParameter, deletedParameter,companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update material (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>       
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalSize">originalSize</param>
        /// <param name="originalLength">originalLength</param>
        /// <param name="originalThickness">originalThickness</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDeleted">originalDeleted</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        ///
        /// <param name="newDescription">newDescription</param>
        /// <param name="newSize">newSize</param>
        /// <param name="newLength">newLength</param>
        /// <param name="newThickness">newThickness</param>
        /// <param name="newType">newType</param>
        /// <param name="newState">newState</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalMaterialId, string originalDescription, string originalSize, string originalLength, string originalThickness, string originalType, string originalState, bool originalDeleted, int originalCompanyId, int newMaterialId, string newDescription, string newSize, string newLength, string newThickness, string newType, string newState, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalMaterialIdParameter = new SqlParameter("Original_MaterialID", originalMaterialId);
            SqlParameter originalDescriptionParameter = (originalDescription.Trim() != "") ? new SqlParameter("Original_Description", originalDescription.Trim()) : new SqlParameter("Original_Description", DBNull.Value);
            SqlParameter originalSizeParameter = (originalSize.Trim() != "") ? new SqlParameter("Original_Size", originalSize.Trim()) : new SqlParameter("Original_Size", DBNull.Value);
            SqlParameter originalLengthParameter = (originalLength.Trim() != "") ? new SqlParameter("Original_Length", originalLength.Trim()) : new SqlParameter("Original_Length", DBNull.Value);
            SqlParameter originalThicknessParameter = (originalThickness.Trim() != "") ? new SqlParameter("Original_Thickness", originalThickness.Trim()) : new SqlParameter("Original_Thickness", DBNull.Value);
            SqlParameter originalTypeParameter = (originalType.Trim() != "") ? new SqlParameter("Original_Type", originalType.Trim()) : new SqlParameter("Original_Type", DBNull.Value);
            SqlParameter originalStateParameter = (originalState.Trim() != "") ? new SqlParameter("Original_State", originalState.Trim()) : new SqlParameter("Original_State", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);           

            SqlParameter newMaterialIdParameter = new SqlParameter("MaterialID", newMaterialId);
            SqlParameter newDescriptionParameter = (newDescription.Trim() != "") ? new SqlParameter("Description", newDescription.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter newSizeParameter = (newSize.Trim() != "") ? new SqlParameter("Size", newSize.Trim()) : new SqlParameter("Size", DBNull.Value);
            SqlParameter newLengthParameter = (newLength.Trim() != "") ? new SqlParameter("Length", newLength.Trim()) : new SqlParameter("Length", DBNull.Value);
            SqlParameter newThicknessParameter = (newThickness.Trim() != "") ? new SqlParameter("Thickness", newThickness.Trim()) : new SqlParameter("Thickness", DBNull.Value);
            SqlParameter newTypeParameter = (newType.Trim() != "") ? new SqlParameter("Type", newType.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter newStateParameter = (newState.Trim() != "") ? new SqlParameter("State", newState.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL] SET [Description] = @Description, [Size] = @Size, [Length] = @Length, " +
            " [Thickness] = @Thickness, [Type] = @Type, [State] = @State "+
            " WHERE ([MaterialID] = @Original_MaterialID) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalMaterialIdParameter, originalDescriptionParameter, originalSizeParameter, originalLengthParameter, originalThicknessParameter, originalTypeParameter, originalStateParameter, originalDeletedParameter, originalCompanyIdParameter, newMaterialIdParameter, newDescriptionParameter, newSizeParameter, newLengthParameter, newThicknessParameter, newTypeParameter, newStateParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a material (direct to DB)
        /// </summary>
        /// <param name="originalMaterialId">originalMaterialId</param>
        /// <returns>int</returns>
        public int Delete(int originalMaterialId)
        {
            SqlParameter originalMaterialIdParameter = new SqlParameter("@Original_MaterialID", originalMaterialId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_MATERIAL] SET  [Deleted] = @Deleted  " +
                             " WHERE ([MaterialID] = @Original_MaterialID)  ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalMaterialIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}

