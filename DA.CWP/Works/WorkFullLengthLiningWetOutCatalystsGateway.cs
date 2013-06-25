using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Works
{
    /// <summary>
    /// WorkFullLengthLiningWetOutCatalystsGateway
    /// </summary>
    public class WorkFullLengthLiningWetOutCatalystsGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkFullLengthLiningWetOutCatalystsGateway()
            : base("LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkFullLengthLiningWetOutCatalystsGateway(DataSet data)
            : base(data, "LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS")
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
            tableMapping.DataSetTable = "LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("PercentageByWeight", "PercentageByWeight");
            tableMapping.ColumnMappings.Add("LbsForMixQuantity", "LbsForMixQuantity");
            tableMapping.ColumnMappings.Add("LbsForDrum", "LbsForDrum");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ([CatalystID] = @Original_CatalystID) AND ([PercentageByWeight] = @Original_PercentageByWeight) AND ([LbsForMixQuantity] = @Original_LbsForMixQuantity) AND ([LbsForDrum] = @Original_LbsForDrum) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageByWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbsForMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForMixQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbsForDrum", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForDrum", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] ([WorkID], [RefID], [CatalystID], [PercentageByWeight], [LbsForMixQuantity], [LbsForDrum], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @RefID, @CatalystID, @PercentageByWeight, @LbsForMixQuantity, @LbsForDrum, @Deleted, @COMPANY_ID);
SELECT WorkID, RefID, CatalystID, PercentageByWeight, LbsForMixQuantity, LbsForDrum, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS WHERE (RefID = @RefID) AND (WorkID = @WorkID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageByWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbsForMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForMixQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbsForDrum", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForDrum", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] SET [WorkID] = @WorkID, [RefID] = @RefID, [CatalystID] = @CatalystID, [PercentageByWeight] = @PercentageByWeight, [LbsForMixQuantity] = @LbsForMixQuantity, [LbsForDrum] = @LbsForDrum, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ([CatalystID] = @Original_CatalystID) AND ([PercentageByWeight] = @Original_PercentageByWeight) AND ([LbsForMixQuantity] = @Original_LbsForMixQuantity) AND ([LbsForDrum] = @Original_LbsForDrum) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT WorkID, RefID, CatalystID, PercentageByWeight, LbsForMixQuantity, LbsForDrum, Deleted, COMPANY_ID FROM LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS WHERE (RefID = @RefID) AND (WorkID = @WorkID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageByWeight", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbsForMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForMixQuantity", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LbsForDrum", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForDrum", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_WorkID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "WorkID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CatalystID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CatalystID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PercentageByWeight", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageByWeight", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbsForMixQuantity", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForMixQuantity", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LbsForDrum", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LbsForDrum", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a wet out catalyst (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="catalystId">catalystId</param>        
        /// <param name="percentageByWeight">percentageByWeight</param>
        /// <param name="lbsForMixQuantity">lbsForMixQuantity</param>
        /// <param name="lbsForDrum">lbsForDrum</param>
        /// <param name="deleted">deleted</param>       
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int workId, int refId, int catalystId, decimal percentageByWeight, decimal lbsForMixQuantity, string lbsForDrum, bool deleted, int companyId)
        {
            SqlParameter workIdParameter = new SqlParameter("WorkID", workId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter catalystIdParameter = new SqlParameter("CatalystID", catalystId);            
            SqlParameter percentageByWeightParameter = new SqlParameter("PercentageByWeight", percentageByWeight);
            SqlParameter lbsForMixQuantityParameter = new SqlParameter("LbsForMixQuantity", lbsForMixQuantity);
            SqlParameter lbsForDrumParameter = new SqlParameter("LbsForDrum", lbsForDrum);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] ([WorkID], [RefID], [CatalystID], [PercentageByWeight], [LbsForMixQuantity], [LbsForDrum], [Deleted], [COMPANY_ID]) VALUES (@WorkID, @RefID, @CatalystID, @PercentageByWeight, @LbsForMixQuantity, @LbsForDrum, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, refIdParameter, catalystIdParameter, percentageByWeightParameter, lbsForMixQuantityParameter, lbsForDrumParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update wet out catalyst (direct to DB)
        /// </summary>
        /// <param name="originalWorkId">originalWorkId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCatalystId">originalCatalystId</param>        
        /// <param name="originalPercentageByWeight">originalPercentageByWeight</param>
        /// <param name="originalLbsForMixQuantity">originalLbsForMixQuantity</param>
        /// <param name="originalLbsForDrum">originalLbsForDrum</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newWorkId">newWorkId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCatalystId">newCatalystId</param>        
        /// <param name="newPercentageByWeight">newPercentageByWeight</param>
        /// <param name="newLbsForMixQuantity">newLbsForMixQuantity</param>
        /// <param name="newLbsForDrum">newLbsForDrum</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalWorkId, int originalRefId, int originalCatalystId, decimal originalPercentageByWeight, decimal originalLbsForMixQuantity, string originalLbsForDrum, bool originalDeleted, int originalCompanyId, int newWorkId, int newRefId, int newCatalystId, decimal newPercentageByWeight, decimal newLbsForMixQuantity, string newLbsForDrum, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalWorkIdParameter = new SqlParameter("Original_WorkID", originalWorkId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCatalystIdParameter = new SqlParameter("Original_CatalystID", originalCatalystId);            
            SqlParameter originalPercentageByWeightParameter = new SqlParameter("Original_PercentageByWeight", originalPercentageByWeight);
            SqlParameter originalLbsForMixQuantityParameter = new SqlParameter("Original_LbsForMixQuantity", originalLbsForMixQuantity);
            SqlParameter originalLbsForDrumParameter = new SqlParameter("Original_LbsForDrum", originalLbsForDrum);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newWorkIdParameter = new SqlParameter("WorkID", newWorkId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCatalystIdParameter = new SqlParameter("CatalystID", newCatalystId);
            SqlParameter newPercentageByWeightParameter = new SqlParameter("PercentageByWeight", newPercentageByWeight);
            SqlParameter newLbsForMixQuantityParameter = new SqlParameter("LbsForMixQuantity", newLbsForMixQuantity);
            SqlParameter newLbsForDrumParameter = new SqlParameter("LbsForDrum", newLbsForDrum);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] "+
                " SET [CatalystID] = @CatalystID, [PercentageByWeight] = @PercentageByWeight, [LbsForMixQuantity] = @LbsForMixQuantity, [LbsForDrum] = @LbsForDrum " +
                " WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalWorkIdParameter, originalRefIdParameter, originalCatalystIdParameter, originalPercentageByWeightParameter, originalLbsForMixQuantityParameter, originalLbsForDrumParameter, originalDeletedParameter, originalCompanyIdParameter, newWorkIdParameter, newRefIdParameter, newCatalystIdParameter, newPercentageByWeightParameter, newLbsForMixQuantityParameter, newLbsForDrumParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a wet out catalyst (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Delete(int workId, int refId, int originalCompanyId)
        {
            SqlParameter workIdParameter = new SqlParameter("@Original_WorkID", workId);
            SqlParameter refIdParameter = new SqlParameter("@Original_RefID", refId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, refIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete all wet out catalyst (direct to DB)
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int DeleteAll(int workId, int originalCompanyId)
        {
            SqlParameter workIdParameter = new SqlParameter("@Original_WorkID", workId);            
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_WORK_FULLLENGTHLINING_WETOUT_CATALYSTS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([WorkID] = @Original_WorkID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, workIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }
    }
}
