using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsInsuranceCompaniesCostsGateway
    /// </summary>
    public class ActualCostsInsuranceCompaniesCostsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsInsuranceCompaniesCostsGateway()
            : base("LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsInsuranceCompaniesCostsGateway(DataSet data)
            : base(data, "LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsTDS();
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
            tableMapping.DataSetTable = "LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("InsuranceCompanyID", "InsuranceCompanyID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID"); 
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS] WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([InsuranceCompanyID] = @Original_InsuranceCompanyID) AND ([Date] = @Original_Date) AND ([RateCad] = @Original_RateCad) AND ([RateUsd] = @Original_RateUsd) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InsuranceCompanyID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceCompanyID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS] ([ProjectID], [RefID], [InsuranceCompanyID], [Date], [RateCad], [RateUsd], [Comment], [Deleted], [COMPANY_ID]) VALUES (@ProjectID, @RefID, @InsuranceCompanyID, @Date, @RateCad, @RateUsd, @Comment, @Deleted, @COMPANY_ID);
SELECT ProjectID, RefID, InsuranceCompanyID, Date, RateCad, RateUsd, Comment, Deleted, COMPANY_ID FROM LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS WHERE (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InsuranceCompanyID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceCompanyID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS] SET [ProjectID] = @ProjectID, [RefID] = @RefID, [InsuranceCompanyID] = @InsuranceCompanyID, [Date] = @Date, [RateCad] = @RateCad, [RateUsd] = @RateUsd, [Comment] = @Comment, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID) AND ([InsuranceCompanyID] = @Original_InsuranceCompanyID) AND ([Date] = @Original_Date) AND ([RateCad] = @Original_RateCad) AND ([RateUsd] = @Original_RateUsd) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectID, RefID, InsuranceCompanyID, Date, RateCad, RateUsd, Comment, Deleted, COMPANY_ID FROM LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS WHERE (ProjectID = @ProjectID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InsuranceCompanyID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceCompanyID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Comment", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Comment", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RefID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RefID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InsuranceCompanyID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceCompanyID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RateCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RateUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RateUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a  insurance Companies cost (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>        
        /// <param name="date">date</param>        
        /// <param name="rateCad">rateCad</param>        
        /// <param name="rateUsd">rateUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>rowsAffected</returns>
        public int Insert(int projectId, int refId, int insuranceCompanyId, DateTime date, decimal rateCad, decimal rateUsd, string comment, bool deleted, int companyId)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter insuranceCompanyIdParameter = new SqlParameter("InsuranceCompanyID", insuranceCompanyId);
            SqlParameter dateParameter = new SqlParameter("Date", date);            
            SqlParameter rateCadParameter = new SqlParameter("RateCad", rateCad); rateCadParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter rateUsdParameter = new SqlParameter("RateUsd", rateUsd); rateUsdParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter commentParameter = (comment.Trim() != "") ? new SqlParameter("Comment", comment.Trim()) : new SqlParameter("Comment", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS] ([ProjectID], [RefID], [InsuranceCompanyID], [Date], [RateCad], [RateUsd], [Comment], [Deleted], [COMPANY_ID]) VALUES (@ProjectID, @RefID, @InsuranceCompanyID, @Date, @RateCad, @RateUsd, @Comment, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, projectIdParameter, refIdParameter, insuranceCompanyIdParameter, dateParameter, rateCadParameter, rateUsdParameter, commentParameter, deletedParameter, companyIdParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update service insuranceCompanies cost (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalInsuranceCompanyId">originalInsuranceCompanyId</param>
        /// <param name="originalDate">originalDate</param>        
        /// <param name="originalRate">originalRate</param>        
        /// <param name="originalComment">originalComment</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>        

        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newRefId">newRefId</param>        
        /// <param name="newInsuranceCompanyId">newInsuranceCompanyId</param>
        /// <param name="newDate">newDate</param>        
        /// <param name="newRate">newRate</param>        
        /// <param name="newComment">newComment</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalProjectId, int originalRefId, int originalInsuranceCompanyId, DateTime originalDate, decimal originalRateCad, decimal originalRateUsd, string originalComment, bool originalDeleted, int originalCompanyId, int newProjectId, int newRefId, int newInsuranceCompanyId, DateTime newDate,  decimal newRateCad, decimal newRateUsd,  string newComment, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalProjectIdParameter = new SqlParameter("Original_ProjectID", originalProjectId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalInsuranceCompanyIdParameter = new SqlParameter("Original_InsuranceCompanyID", originalInsuranceCompanyId);
            SqlParameter originalDateParameter = new SqlParameter("Original_Date", originalDate);            
            SqlParameter originalRateCadParameter = new SqlParameter("Original_RateCad", originalRateCad); originalRateCadParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter originalRateUsdParameter = new SqlParameter("Original_RateUsd", originalRateUsd); originalRateUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalCommentParameter = (originalComment.Trim() != "") ? new SqlParameter("Original_Comment", originalComment.Trim()) : new SqlParameter("Original_Comment", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);


            SqlParameter newProjectIdParameter = new SqlParameter("ProjectID", newProjectId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", originalRefId);
            SqlParameter newInsuranceCompanyIdParameter = new SqlParameter("InsuranceCompanyID", newInsuranceCompanyId);
            SqlParameter newDateParameter = new SqlParameter("Date", newDate);            
            SqlParameter newRateCadParameter = new SqlParameter("RateCad", newRateCad); newRateCadParameter.SqlDbType = SqlDbType.Money;            
            SqlParameter newRateUsdParameter = new SqlParameter("RateUsd", newRateUsd); newRateUsdParameter.SqlDbType = SqlDbType.Money;           
            SqlParameter newCommentParameter = (newComment.Trim() != "") ? new SqlParameter("Comment", newComment.Trim()) : new SqlParameter("Comment", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS] SET [InsuranceCompanyID] = @InsuranceCompanyID, [Date] = @Date, [RateCad] = @RateCad,  [RateUsd] = @RateUsd, [Comment] = @Comment " +
                " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalRefIdParameter, originalInsuranceCompanyIdParameter, originalDateParameter, originalRateCadParameter, originalRateUsdParameter, originalCommentParameter, originalDeletedParameter, originalCompanyIdParameter, newProjectIdParameter, newRefIdParameter, newInsuranceCompanyIdParameter, newDateParameter, newRateCadParameter, newRateUsdParameter, newCommentParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a subcontractor cost (direct to DB)
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

            string command = "UPDATE [dbo].[LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([ProjectID] = @Original_ProjectID) AND ([RefID] = @Original_RefID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalProjectIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }


    }
}