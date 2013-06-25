using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectServiceGateway
    /// </summary>
    public class ProjectServiceGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectServiceGateway() : base("LFS_PROJECT_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectServiceGateway(DataSet data) : base(data, "LFS_PROJECT_SERVICE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_SERVICE";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("AverageSize", "AverageSize");
            tableMapping.ColumnMappings.Add("AveragePrice", "AveragePrice");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);
            
            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_SERVICE] WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ((@IsNull_ServiceID = 1 AND [ServiceID] IS NULL) OR ([ServiceID] = @Original_ServiceID)) AND ((@IsNull_Description = 1 AND [Description] IS NULL) OR ([Description] = @Original_Description)) AND ((@IsNull_AverageSize = 1 AND [AverageSize] IS NULL) OR ([AverageSize] = @Original_AverageSize)) AND ((@IsNull_AveragePrice = 1 AND [AveragePrice] IS NULL) OR ([AveragePrice] = @Original_AveragePrice)) AND ([Quantity] = @Original_Quantity) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AverageSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AverageSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AverageSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AverageSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AveragePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AveragePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AveragePrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "AveragePrice", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Quantity", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_SERVICE] ([ProjectID], [RefID], [ServiceID], [Description], [AverageSize], [AveragePrice], [Quantity], [Deleted], [COMPANY_ID]) VALUES (@ProjectID, @RefID, @ServiceID, @Description, @AverageSize, @AveragePrice, @Quantity, @Deleted, @COMPANY_ID);
SELECT ProjectID, RefID, ServiceID, Description, AverageSize, AveragePrice, Quantity, Deleted, COMPANY_ID FROM LFS_PROJECT_SERVICE WHERE (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AverageSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AverageSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AveragePrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "AveragePrice", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Quantity", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_SERVICE] SET [ProjectID] = @ProjectID, [RefID] = @RefID, [ServiceID] = @ServiceID, [Description] = @Description, [AverageSize] = @AverageSize, [AveragePrice] = @AveragePrice, [Quantity] = @Quantity, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ((@IsNull_ServiceID = 1 AND [ServiceID] IS NULL) OR ([ServiceID] = @Original_ServiceID)) AND ((@IsNull_Description = 1 AND [Description] IS NULL) OR ([Description] = @Original_Description)) AND ((@IsNull_AverageSize = 1 AND [AverageSize] IS NULL) OR ([AverageSize] = @Original_AverageSize)) AND ((@IsNull_AveragePrice = 1 AND [AveragePrice] IS NULL) OR ([AveragePrice] = @Original_AveragePrice)) AND ([Quantity] = @Original_Quantity) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectID, RefID, ServiceID, Description, AverageSize, AveragePrice, Quantity, Deleted, COMPANY_ID FROM LFS_PROJECT_SERVICE WHERE (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AverageSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AverageSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@AveragePrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "AveragePrice", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Quantity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Quantity", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ServiceID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ServiceID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Description", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Description", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Description", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AverageSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AverageSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AverageSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "AverageSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_AveragePrice", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "AveragePrice", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_AveragePrice", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "AveragePrice", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Quantity", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Quantity", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
                        
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
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTSERVICEGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadAByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTSERVICEGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a  note (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="serviceId">serviceId</param>
        /// <param name="description">description</param>
        /// <param name="averageSize">averageSize</param>
        /// <param name="averagePrice">averagePrice</param>
        /// <param name="quantity">quantity</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int projectId, int refId, int? serviceId, string description, string averageSize, decimal? averagePrice, int quantity, bool deleted, int companyId)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter serviceIdParameter = (serviceId.HasValue) ? new SqlParameter("ServiceID", serviceId) : new SqlParameter("ServiceID", DBNull.Value);
            SqlParameter descriptionParameter = (description.Trim() != "") ? new SqlParameter("Description", description.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter averageSizeParameter = (averageSize.Trim() != "") ? new SqlParameter("AverageSize", averageSize.Trim()) : new SqlParameter("AverageSize", DBNull.Value);
            SqlParameter averagePriceParameter = (averagePrice.HasValue) ? new SqlParameter("AveragePrice", averagePrice) : new SqlParameter("AveragePrice", DBNull.Value);
            averagePriceParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter quantityParameter = new SqlParameter("Quantity", quantity);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_SERVICE] ([ProjectID], [RefID], [ServiceID], "+
                " [Description], [AverageSize], [AveragePrice], [Quantity], [Deleted], [COMPANY_ID]) "+
                " VALUES (@ProjectID, @RefID, @ServiceID, @Description, @AverageSize, @AveragePrice, @Quantity, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, refIdParameter, serviceIdParameter, descriptionParameter, averageSizeParameter, averagePriceParameter, quantityParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update service note (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalAverageSize">originalAverageSize</param>
        /// <param name="originalAveragePrice">originalAveragePrice</param>
        /// <param name="originalQuantity">originalQuantity</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>  
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newAverageSize">newAverageSize</param>
        /// <param name="newAveragePrice">newAveragePrice</param>
        /// <param name="newQuantity">newQuantity</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>        
        /// <returns>rowsAffected</returns>
        public int Update(int originalProjectId, int originalRefId, int? originalServiceId, string originalDescription, string originalAverageSize, decimal? originalAveragePrice, int originalQuantity, bool originalDeleted, int originalCompanyId, int newProjectId, int newRefId, int? newServiceId, string newDescription, string newAverageSize, decimal? newAveragePrice, int newQuantity,  bool newDeleted, int newCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalServiceIdParameter = (originalServiceId.HasValue) ? new SqlParameter("Original_ServiceID", originalServiceId) : new SqlParameter("Original_ServiceID", DBNull.Value);
            SqlParameter originalDescriptionParameter = (originalDescription.Trim() != "") ? new SqlParameter("Original_Description", originalDescription.Trim()) : new SqlParameter("Original_Description", DBNull.Value);
            SqlParameter originalAverageSizeParameter = (originalAverageSize.Trim() != "") ? new SqlParameter("Original_AverageSize", originalAverageSize.Trim()) : new SqlParameter("Original_AverageSize", DBNull.Value);
            SqlParameter originalAveragePriceParameter = (originalAveragePrice.HasValue) ? new SqlParameter("Original_AveragePrice", originalAveragePrice) : new SqlParameter("Original_AveragePrice", DBNull.Value);
            originalAveragePriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalQuantityParameter = new SqlParameter("Original_Quantity", originalQuantity);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newServiceIdParameter = (newServiceId.HasValue) ? new SqlParameter("ServiceID", newServiceId) : new SqlParameter("ServiceID", DBNull.Value);
            SqlParameter newDescriptionParameter = (newDescription.Trim() != "") ? new SqlParameter("Description", newDescription.Trim()) : new SqlParameter("Description", DBNull.Value);
            SqlParameter newAverageSizeParameter = (newAverageSize.Trim() != "") ? new SqlParameter("AverageSize", newAverageSize.Trim()) : new SqlParameter("AverageSize", DBNull.Value);
            SqlParameter newAveragePriceParameter = (newAveragePrice.HasValue) ? new SqlParameter("AveragePrice", newAveragePrice) : new SqlParameter("AveragePrice", DBNull.Value);
            newAveragePriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newQuantityParameter = new SqlParameter("Quantity", newQuantity);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_PROJECT_SERVICE] SET [ServiceID] = @ServiceID, [Description] = @Description, "+
                " [AverageSize] = @AverageSize, [AveragePrice] = @AveragePrice, [Quantity] = @Quantity "+            
                " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalRefIdParameter, originalServiceIdParameter, originalDescriptionParameter, originalAverageSizeParameter, originalAveragePriceParameter, originalQuantityParameter, originalDeletedParameter, originalCompanyIdParameter, newProjectIdParameter, newRefIdParameter, newServiceIdParameter, newDescriptionParameter, newAverageSizeParameter, newAveragePriceParameter, newQuantityParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a note (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalProjectId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("@Original_ProjectID", originalProjectId);
            SqlParameter originalRefIdParameter = new SqlParameter("@Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_PROJECT_SERVICE] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}
