using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningCatalystsGateway
    /// </summary>
    public class WorkFullLengthLiningCatalystsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningCatalystsGateway()
            : base("LFS_WORK_FULLLENGTHLINING_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningCatalystsGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_CATALYSTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkTDS();
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_CATALYSTS";
            tableMapping.ColumnMappings.Add("CatalystID", "CatalystID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("DefaultPercentageByWeight", "DefaultPercentageByWeight");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_CATALYSTS] WHERE (([CatalystID] = @Original_CatalystID) AND ([Name] = @Original_Name) AND ([DefaultPercentageByWeight] = @Original_DefaultPercentageByWeight) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DefaultPercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefaultPercentageByWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_CATALYSTS] ([CatalystID], [Name], [DefaultPercentageByWeight], [Deleted], [COMPANY_ID]) VALUES (@CatalystID, @Name, @DefaultPercentageByWeight, @Deleted, @COMPANY_ID);
SELECT CatalystID, Name, DefaultPercentageByWeight, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_CATALYSTS WHERE (CatalystID = @CatalystID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DefaultPercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefaultPercentageByWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_CATALYSTS] SET [CatalystID] = @CatalystID, [Name] = @Name, [DefaultPercentageByWeight] = @DefaultPercentageByWeight, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([CatalystID] = @Original_CatalystID) AND ([Name] = @Original_Name) AND ([DefaultPercentageByWeight] = @Original_DefaultPercentageByWeight) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT CatalystID, Name, DefaultPercentageByWeight, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_CATALYSTS WHERE (CatalystID = @CatalystID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DefaultPercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefaultPercentageByWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DefaultPercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DefaultPercentageByWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByCatalystId
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>data set</returns>
        public DataSet LoadByCatalystId(int catalystId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGCATALYSTSGATEWAY_LOADCATALYSTID", new SqlParameter("@catalystId", catalystId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int catalystId)
        {
            string filter = string.Format("CatalystID = {0}", catalystId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLenthLining.FullLengthLiningCatalystsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>Name or EMPTY</returns>
        public string GetName(int catalystId)
        {
            if (GetRow(catalystId).IsNull("Name"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(catalystId)["Name"];
            }
        }



        /// <summary>
        /// GetDefaultPercentageByWeight
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <returns>DefaultPercentageByWeight or EMPTY</returns>
        public double GetDefaultPercentageByWeight(int catalystId)
        {
            return (double)GetRow(catalystId)["DefaultPercentageByWeight"];            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a catalyst (direct to DB)
        /// </summary>
        /// <param name="catalystId">catalystId</param>
        /// <param name="name">name</param>
        /// <param name="defaultPercentageByWeight">defaultPercentageByWeight</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int catalystId, string name, decimal defaultPercentageByWeight, bool deleted, int companyId)
        {
            SqlParameter catalystIdParameter = new SqlParameter("CatalystID", catalystId);
            SqlParameter nameParameter = new SqlParameter("Name", name.Trim());
            SqlParameter defaultPercentageByWeightParameter = new SqlParameter("DefaultPercentageByWeight", defaultPercentageByWeight);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_CATALYSTS] ([CatalystID], [Name], [DefaultPercentageByWeight], [Deleted], [COMPANY_ID]) VALUES (@CatalystID, @Name, @DefaultPercentageByWeight, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, catalystIdParameter, nameParameter, defaultPercentageByWeightParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update a catalyst (direct to DB)
        /// </summary>
        /// <param name="originalResinId">originalResinId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalDefaultPercentageByWeight">originalDefaultPercentageByWeight</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newResinId">newResinId</param>
        /// <param name="newName">newName</param>
        /// <param name="newDefaultPercentageByWeight">newDefaultPercentageByWeight</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalResinId, string originalName, decimal originalDefaultPercentageByWeight, bool originalDeleted, int originalCompanyId, int newResinId, string newName, decimal newDefaultPercentageByWeight,  bool newDeleted, int newCompanyId)
        {
            SqlParameter originalResinIdParameter = new SqlParameter("Original_CatalystID", originalResinId);
            SqlParameter originalNameParameter = new SqlParameter("Original_Name", originalName);
            SqlParameter originalDefaultPercentageByWeightParameter = new SqlParameter("Original_DefaultPercentageByWeight", originalDefaultPercentageByWeight);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newResinIdParameter = new SqlParameter("CatalystID", newResinId);
            SqlParameter newNameParameter = new SqlParameter("Name", newName);
            SqlParameter newDefaultPercentageByWeightParameter = new SqlParameter("DefaultPercentageByWeight", newDefaultPercentageByWeight);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_CATALYSTS] SET [CatalystID] = @CatalystID, [Name] = @Name, [DefaultPercentageByWeight] = @DefaultPercentageByWeight, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID  "+
                " WHERE (([CatalystID] = @Original_CatalystID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalResinIdParameter, originalNameParameter, originalDefaultPercentageByWeightParameter, originalDeletedParameter, originalCompanyIdParameter, newResinIdParameter, newNameParameter, newDefaultPercentageByWeightParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a catalyst (direct to DB)
        /// </summary>
        /// <param name="originalCatalystId">originalCatalystId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int originalCatalystId, int originalCompanyId)
        {
            SqlParameter originalCatalystIdParameter = new SqlParameter("@Original_CatalystID", originalCatalystId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_CATALYSTS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([CatalystID] = @Original_CatalystID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCatalystIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



    }
}
