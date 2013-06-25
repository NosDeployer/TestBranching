using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Subcontractors
{
    /// <summary>
    /// SubcontractorsResoucesSubcontractorsGateway
    /// </summary>
    public class SubcontractorsResoucesSubcontractorsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsResoucesSubcontractorsGateway()
            : base("LFS_RESOURCES_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsResoucesSubcontractorsGateway(DataSet data)
            : base(data, "LFS_RESOURCES_SUBCONTRACTORS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorsTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_SUBCONTRACTORS";
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Active", "Active");
            tableMapping.ColumnMappings.Add("Udf", "Udf");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_RESOURCES_SUBCONTRACTORS] WHERE (([COMPANIES_ID] = @Original_COMPANIES_ID) AND ([Date] = @Original_Date) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ([Active] = @Original_Active) AND ([Udf] = @Original_Udf) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Name", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Active", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Active", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Udf", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Udf", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_SUBCONTRACTORS] ([COMPANIES_ID], [Date], [Name], [Active], [Udf], [Deleted], [COMPANY_ID]) VALUES (@COMPANIES_ID, @Date, @Name, @Active, @Udf, @Deleted, @COMPANY_ID);
SELECT COMPANIES_ID, Date, Name, Active, Udf, Deleted, COMPANY_ID FROM LFS_RESOURCES_SUBCONTRACTORS WHERE (COMPANIES_ID = @COMPANIES_ID) AND (Date = @Date)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Active", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Active", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Udf", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Udf", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_RESOURCES_SUBCONTRACTORS] SET [COMPANIES_ID] = @COMPANIES_ID, [Date] = @Date, [Name] = @Name, [Active] = @Active, [Udf] = @Udf, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([COMPANIES_ID] = @Original_COMPANIES_ID) AND ([Date] = @Original_Date) AND ((@IsNull_Name = 1 AND [Name] IS NULL) OR ([Name] = @Original_Name)) AND ([Active] = @Original_Active) AND ([Udf] = @Original_Udf) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT COMPANIES_ID, Date, Name, Active, Udf, Deleted, COMPANY_ID FROM LFS_RESOURCES_SUBCONTRACTORS WHERE (COMPANIES_ID = @COMPANIES_ID) AND (Date = @Date)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Active", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Active", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Udf", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Udf", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Name", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Active", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Active", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Udf", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Udf", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
        /// Insert subcontractor (direct to DB)
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>
        /// <param name="name">name</param>
        /// <param name="active">active</param>
        /// <param name="udf">udf</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public int Insert(int companiesId, DateTime date, string name, bool active, bool udf, bool deleted, int companyId)
        {
            SqlParameter companiesIdParameter = new SqlParameter("COMPANIES_ID", companiesId);
            SqlParameter dateParameter = new SqlParameter("Date", date);
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter activeParameter = new SqlParameter("Active", active);
            SqlParameter udfParameter = new SqlParameter("Udf", udf);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);            

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_SUBCONTRACTORS] ([COMPANIES_ID], [Date], [Name], [Active], [Udf], [Deleted], [COMPANY_ID]) VALUES (@COMPANIES_ID, @Date, @Name, @Active, @Udf, @Deleted, @COMPANY_ID)";

            int rowsAffected = (int)ExecuteNonQuery(command, companiesIdParameter, dateParameter,nameParameter, activeParameter, udfParameter, deletedParameter, companyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Update subcontractor (direct to DB)
        /// </summary>
        /// <param name="originalCompaniesId">originalCompaniesId</param>
        /// <param name="originalDate">originalDate</param>
        /// <param name="originalActive">originalActive</param>
        /// <param name="originalUdf">originalUdf</param>        
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>

        /// <param name="newCompaniesId">newCompaniesId</param>
        /// <param name="newDate">newDate</param>
        /// <param name="newActive">newActive</param>
        /// <param name="newUdf">newUdf</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalCompaniesId, DateTime originalDate, bool originalActive, bool originalUdf, bool originalDeleted, int originalCompanyId, int newCompaniesId, DateTime newDate , bool newActive, bool newUdf, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalCompaniesIdParameter = new SqlParameter("Original_COMPANIES_ID", originalCompaniesId);
            SqlParameter originalDateParameter = new SqlParameter("Original_Date", originalDate);
            SqlParameter originalActiveParameter = new SqlParameter("Original_Active", originalActive);
            SqlParameter originalUdfParameter = new SqlParameter("Original_Udf", originalUdf);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newCompaniesIdParameter = new SqlParameter("COMPANIES_ID", newCompaniesId);
            SqlParameter newDateParameter = new SqlParameter("Date", newDate);
            SqlParameter newActiveParameter = new SqlParameter("Active", newActive);
            SqlParameter newUdfParameter = new SqlParameter("Udf", newUdf);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_RESOURCES_SUBCONTRACTORS] SET [Active] = @Active" +
                " WHERE (([COMPANIES_ID] = @Original_COMPANIES_ID) AND ([Date] = @Original_Date)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCompaniesIdParameter, originalDateParameter, originalActiveParameter, originalUdfParameter, originalDeletedParameter, originalCompanyIdParameter, newCompaniesIdParameter, newDateParameter, newActiveParameter, newUdfParameter, newDeletedParameter, newCompanyIdParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a subcontractor (direct to DB)
        /// </summary>
        /// <param name="originalCompaniesId">originalCompaniesId</param>
        /// <param name="originalDate">originalDate</param>
        public void Delete(int originalCompaniesId, DateTime originalDate)
        {
            SqlParameter originalCompaniesIdParameter = new SqlParameter("Original_COMPANIES_ID", originalCompaniesId);
            SqlParameter originalDateParameter = new SqlParameter("Original_Date", originalDate);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_SUBCONTRACTORS] SET  [Deleted] = @Deleted  " +
                             " WHERE (([COMPANIES_ID] = @Original_COMPANIES_ID) AND ([Date] = @Original_Date)) ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalCompaniesIdParameter, originalDateParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }

    }
}


