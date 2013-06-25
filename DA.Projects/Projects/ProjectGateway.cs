using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectGateway
    /// </summary>
    public class ProjectGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectGateway()
            : base("LFS_PROJECT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectGateway(DataSet data)
            : base(data, "LFS_PROJECT")
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
            tableMapping.DataSetTable = "LFS_PROJECT";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("OfficeID", "OfficeID");
            tableMapping.ColumnMappings.Add("ProjectLeadID", "ProjectLeadID");
            tableMapping.ColumnMappings.Add("SalesmanID", "SalesmanID");
            tableMapping.ColumnMappings.Add("ProjectNumber", "ProjectNumber");
            tableMapping.ColumnMappings.Add("ProjectType", "ProjectType");
            tableMapping.ColumnMappings.Add("ProjectState", "ProjectState");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("ProposalDate", "ProposalDate");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("EndDate", "EndDate");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientProjectNumber", "ClientProjectNumber");
            tableMapping.ColumnMappings.Add("ClientPrimaryContactID", "ClientPrimaryContactID");
            tableMapping.ColumnMappings.Add("ClientSecondaryContactID", "ClientSecondaryContactID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("OriginalProjectID", "OriginalProjectID");
            tableMapping.ColumnMappings.Add("ProjectNumberCopy", "ProjectNumberCopy");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
            tableMapping.ColumnMappings.Add("ProvinceID", "ProvinceID");
            tableMapping.ColumnMappings.Add("CityID", "CityID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CountyID", "CountyID");
            tableMapping.ColumnMappings.Add("FairWageApplies", "FairWageApplies");
            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PROJECT] WHERE (([ProjectID] = @Original_ProjectID) AND ([" +
                "CountryID] = @Original_CountryID) AND ([OfficeID] = @Original_OfficeID) AND ((@I" +
                "sNull_ProjectLeadID = 1 AND [ProjectLeadID] IS NULL) OR ([ProjectLeadID] = @Orig" +
                "inal_ProjectLeadID)) AND ([SalesmanID] = @Original_SalesmanID) AND ([ProjectNumb" +
                "er] = @Original_ProjectNumber) AND ([ProjectType] = @Original_ProjectType) AND (" +
                "[ProjectState] = @Original_ProjectState) AND ((@IsNull_Name = 1 AND [Name] IS NU" +
                "LL) OR ([Name] = @Original_Name)) AND ((@IsNull_ProposalDate = 1 AND [ProposalDa" +
                "te] IS NULL) OR ([ProposalDate] = @Original_ProposalDate)) AND ((@IsNull_StartDa" +
                "te = 1 AND [StartDate] IS NULL) OR ([StartDate] = @Original_StartDate)) AND ((@I" +
                "sNull_EndDate = 1 AND [EndDate] IS NULL) OR ([EndDate] = @Original_EndDate)) AND" +
                " ([ClientID] = @Original_ClientID) AND ((@IsNull_ClientProjectNumber = 1 AND [Cl" +
                "ientProjectNumber] IS NULL) OR ([ClientProjectNumber] = @Original_ClientProjectN" +
                "umber)) AND ((@IsNull_ClientPrimaryContactID = 1 AND [ClientPrimaryContactID] IS" +
                " NULL) OR ([ClientPrimaryContactID] = @Original_ClientPrimaryContactID)) AND ((@" +
                "IsNull_ClientSecondaryContactID = 1 AND [ClientSecondaryContactID] IS NULL) OR (" +
                "[ClientSecondaryContactID] = @Original_ClientSecondaryContactID)) AND ([Deleted]" +
                " = @Original_Deleted) AND ((@IsNull_OriginalProjectID = 1 AND [OriginalProjectID" +
                "] IS NULL) OR ([OriginalProjectID] = @Original_OriginalProjectID)) AND ((@IsNull" +
                "_ProjectNumberCopy = 1 AND [ProjectNumberCopy] IS NULL) OR ([ProjectNumberCopy] " +
                "= @Original_ProjectNumberCopy)) AND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND [LIB" +
                "RARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_ID] = @Original_LIBRARY_CAT" +
                "EGORIES_ID)) AND ((@IsNull_ProvinceID = 1 AND [ProvinceID] IS NULL) OR ([Provinc" +
                "eID] = @Original_ProvinceID)) AND ((@IsNull_CityID = 1 AND [CityID] IS NULL) OR " +
                "([CityID] = @Original_CityID)) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@" +
                "IsNull_CountyID = 1 AND [CountyID] IS NULL) OR ([CountyID] = @Original_CountyID)" +
                ") AND ([FairWageApplies] = @Original_FairWageApplies))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CountryID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OfficeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OfficeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProjectLeadID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectLeadID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectLeadID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectLeadID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SalesmanID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Name", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProposalDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposalDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProposalDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposalDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientProjectNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientProjectNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientProjectNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientPrimaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientPrimaryContactID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientPrimaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientPrimaryContactID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientSecondaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientSecondaryContactID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientSecondaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientSecondaryContactID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OriginalProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OriginalProjectID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OriginalProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OriginalProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProjectNumberCopy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumberCopy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectNumberCopy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumberCopy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProvinceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProvinceID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CityID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CityID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CityID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CityID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CountyID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountyID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CountyID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountyID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWageApplies", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWageApplies", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT] ([CountryID], [OfficeID], [ProjectLeadID], [SalesmanID], [ProjectNumber], [ProjectType], [ProjectState], [Name], [Description], [ProposalDate], [StartDate], [EndDate], [ClientID], [ClientProjectNumber], [ClientPrimaryContactID], [ClientSecondaryContactID], [Deleted], [OriginalProjectID], [ProjectNumberCopy], [LIBRARY_CATEGORIES_ID], [ProvinceID], [CityID], [COMPANY_ID], [CountyID], [FairWageApplies]) VALUES (@CountryID, @OfficeID, @ProjectLeadID, @SalesmanID, @ProjectNumber, @ProjectType, @ProjectState, @Name, @Description, @ProposalDate, @StartDate, @EndDate, @ClientID, @ClientProjectNumber, @ClientPrimaryContactID, @ClientSecondaryContactID, @Deleted, @OriginalProjectID, @ProjectNumberCopy, @LIBRARY_CATEGORIES_ID, @ProvinceID, @CityID, @COMPANY_ID, @CountyID, @FairWageApplies);
SELECT ProjectID, CountryID, OfficeID, ProjectLeadID, SalesmanID, ProjectNumber, ProjectType, ProjectState, Name, Description, ProposalDate, StartDate, EndDate, ClientID, ClientProjectNumber, ClientPrimaryContactID, ClientSecondaryContactID, Deleted, OriginalProjectID, ProjectNumberCopy, LIBRARY_CATEGORIES_ID, ProvinceID, CityID, COMPANY_ID, CountyID, FairWageApplies FROM LFS_PROJECT WHERE (ProjectID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CountryID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OfficeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OfficeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectLeadID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectLeadID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SalesmanID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProposalDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposalDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientProjectNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientPrimaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientPrimaryContactID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientSecondaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientSecondaryContactID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OriginalProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OriginalProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectNumberCopy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumberCopy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProvinceID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CityID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CityID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CountyID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountyID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWageApplies", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWageApplies", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT] SET [CountryID] = @CountryID, [OfficeID] = @OfficeID, " +
                "[ProjectLeadID] = @ProjectLeadID, [SalesmanID] = @SalesmanID, [ProjectNumber] = " +
                "@ProjectNumber, [ProjectType] = @ProjectType, [ProjectState] = @ProjectState, [N" +
                "ame] = @Name, [Description] = @Description, [ProposalDate] = @ProposalDate, [Sta" +
                "rtDate] = @StartDate, [EndDate] = @EndDate, [ClientID] = @ClientID, [ClientProje" +
                "ctNumber] = @ClientProjectNumber, [ClientPrimaryContactID] = @ClientPrimaryConta" +
                "ctID, [ClientSecondaryContactID] = @ClientSecondaryContactID, [Deleted] = @Delet" +
                "ed, [OriginalProjectID] = @OriginalProjectID, [ProjectNumberCopy] = @ProjectNumb" +
                "erCopy, [LIBRARY_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID, [ProvinceID] = @Provin" +
                "ceID, [CityID] = @CityID, [COMPANY_ID] = @COMPANY_ID, [CountyID] = @CountyID, [F" +
                "airWageApplies] = @FairWageApplies WHERE (([ProjectID] = @Original_ProjectID) AN" +
                "D ([CountryID] = @Original_CountryID) AND ([OfficeID] = @Original_OfficeID) AND " +
                "((@IsNull_ProjectLeadID = 1 AND [ProjectLeadID] IS NULL) OR ([ProjectLeadID] = @" +
                "Original_ProjectLeadID)) AND ([SalesmanID] = @Original_SalesmanID) AND ([Project" +
                "Number] = @Original_ProjectNumber) AND ([ProjectType] = @Original_ProjectType) A" +
                "ND ([ProjectState] = @Original_ProjectState) AND ((@IsNull_Name = 1 AND [Name] I" +
                "S NULL) OR ([Name] = @Original_Name)) AND ((@IsNull_ProposalDate = 1 AND [Propos" +
                "alDate] IS NULL) OR ([ProposalDate] = @Original_ProposalDate)) AND ((@IsNull_Sta" +
                "rtDate = 1 AND [StartDate] IS NULL) OR ([StartDate] = @Original_StartDate)) AND " +
                "((@IsNull_EndDate = 1 AND [EndDate] IS NULL) OR ([EndDate] = @Original_EndDate))" +
                " AND ([ClientID] = @Original_ClientID) AND ((@IsNull_ClientProjectNumber = 1 AND" +
                " [ClientProjectNumber] IS NULL) OR ([ClientProjectNumber] = @Original_ClientProj" +
                "ectNumber)) AND ((@IsNull_ClientPrimaryContactID = 1 AND [ClientPrimaryContactID" +
                "] IS NULL) OR ([ClientPrimaryContactID] = @Original_ClientPrimaryContactID)) AND" +
                " ((@IsNull_ClientSecondaryContactID = 1 AND [ClientSecondaryContactID] IS NULL) " +
                "OR ([ClientSecondaryContactID] = @Original_ClientSecondaryContactID)) AND ([Dele" +
                "ted] = @Original_Deleted) AND ((@IsNull_OriginalProjectID = 1 AND [OriginalProje" +
                "ctID] IS NULL) OR ([OriginalProjectID] = @Original_OriginalProjectID)) AND ((@Is" +
                "Null_ProjectNumberCopy = 1 AND [ProjectNumberCopy] IS NULL) OR ([ProjectNumberCo" +
                "py] = @Original_ProjectNumberCopy)) AND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND " +
                "[LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_CATEGORIES_ID] = @Original_LIBRARY" +
                "_CATEGORIES_ID)) AND ((@IsNull_ProvinceID = 1 AND [ProvinceID] IS NULL) OR ([Pro" +
                "vinceID] = @Original_ProvinceID)) AND ((@IsNull_CityID = 1 AND [CityID] IS NULL)" +
                " OR ([CityID] = @Original_CityID)) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND" +
                " ((@IsNull_CountyID = 1 AND [CountyID] IS NULL) OR ([CountyID] = @Original_Count" +
                "yID)) AND ([FairWageApplies] = @Original_FairWageApplies));\r\nSELECT ProjectID, C" +
                "ountryID, OfficeID, ProjectLeadID, SalesmanID, ProjectNumber, ProjectType, Proje" +
                "ctState, Name, Description, ProposalDate, StartDate, EndDate, ClientID, ClientPr" +
                "ojectNumber, ClientPrimaryContactID, ClientSecondaryContactID, Deleted, Original" +
                "ProjectID, ProjectNumberCopy, LIBRARY_CATEGORIES_ID, ProvinceID, CityID, COMPANY" +
                "_ID, CountyID, FairWageApplies FROM LFS_PROJECT WHERE (ProjectID = @ProjectID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CountryID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountryID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OfficeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OfficeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectLeadID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectLeadID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SalesmanID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProposalDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposalDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@StartDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EndDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientProjectNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientPrimaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientPrimaryContactID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ClientSecondaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientSecondaryContactID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OriginalProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OriginalProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectNumberCopy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumberCopy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProvinceID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CityID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CityID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CountyID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountyID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FairWageApplies", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWageApplies", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CountryID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountryID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OfficeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OfficeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProjectLeadID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectLeadID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectLeadID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectLeadID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SalesmanID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SalesmanID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectState", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Name", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Name", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Name", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProposalDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposalDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProposalDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProposalDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_StartDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_StartDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "StartDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_EndDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EndDate", global::System.Data.SqlDbType.SmallDateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EndDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientProjectNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientProjectNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientProjectNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientProjectNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientPrimaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientPrimaryContactID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientPrimaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientPrimaryContactID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ClientSecondaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientSecondaryContactID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ClientSecondaryContactID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ClientSecondaryContactID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OriginalProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OriginalProjectID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OriginalProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OriginalProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProjectNumberCopy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumberCopy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectNumberCopy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectNumberCopy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ProvinceID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProvinceID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProvinceID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CityID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CityID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CityID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CityID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_CountyID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountyID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CountyID", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CountyID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FairWageApplies", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FairWageApplies", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion        
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// LoadByClientId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByClientId(int clientId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTGATEWAY_LOADBYCLIENTID", new SqlParameter("@clientId", clientId));
            return Data;
        }



        /// <summary>
        /// Get a single project. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId)
        {
            string filter = string.Format("ProjectID = {0}", projectId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectGateway.GetRow");
            }
        }



        /// <summary>
        /// GetCountryID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Country Id</returns>
        public Int64 GetCountryID(int projectId)
        {
            return (Int64)GetRow(projectId)["CountryID"];
        }



        /// <summary>
        /// GetOfficeID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Office Id</returns>
        public int GetOfficeID(int projectId)
        {
            return (int)GetRow(projectId)["OfficeID"];
        }



        /// <summary>
        /// GetProjectLeadID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project Lead Id - Employee Id or EMPTY</returns>
        public int? GetProjectLeadID(int projectId)
        {
            if (GetRow(projectId).IsNull("ProjectLeadID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["ProjectLeadID"];
            }
        }



        /// <summary>
        /// GetSalesmanID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Salesman Id - Employee Id</returns>
        public int GetSalesmanID(int projectId)
        {
            return (int)GetRow(projectId)["SalesmanID"];
        }



        /// <summary>
        /// GetProjectNumber. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project Number</returns>
        public string GetProjectNumber(int projectId)
        {
            return (string)GetRow(projectId)["ProjectNumber"];
        }



        /// <summary>
        /// GetProjectType. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project Type</returns>
        public string GetProjectType(int projectId)
        {
            return (string)GetRow(projectId)["ProjectType"];
        }



        /// <summary>
        /// GetProjectState. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project State</returns>
        public string GetProjectState(int projectId)
        {
            return (string)GetRow(projectId)["ProjectState"];
        }



        /// <summary>
        /// GetName. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project Name or EMPTY</returns>
        public string GetName(int projectId)
        {
            if (GetRow(projectId).IsNull("Name"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["Name"];
            }
        }



        /// <summary>
        /// GetDescription. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project Description or EMPTY</returns>
        public string GetDescription(int projectId)
        {
            if (GetRow(projectId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["Description"];
            }
        }



        /// <summary>
        /// GetProposalDate. If proposal not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Proposal Date o EMPTY</returns>
        public DateTime? GetProposalDate(int projectId)
        {
            if (GetRow(projectId).IsNull("ProposalDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(projectId)["ProposalDate"];
            }
        }



        /// <summary>
        /// GetStartDate. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Start Date or EMPTY</returns>
        public DateTime? GetStartDate(int projectId)
        {
            if (GetRow(projectId).IsNull("StartDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(projectId)["StartDate"];
            }
        }



        /// <summary>
        /// GetEndDate. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>End Date or EMPTY</returns>
        public DateTime? GetEndDate(int projectId)
        {
            if (GetRow(projectId).IsNull("EndDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(projectId)["EndDate"];
            }
        }



        /// <summary>
        /// GetClientID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ClientId - CompaniesId</returns>
        public int GetClientID(int projectId)
        {
            return (int)GetRow(projectId)["ClientID"];
        }



        /// <summary>
        /// GetClientProjectNumber. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Client Project Number or EMPTY</returns>
        public string GetClientProjectNumber(int projectId)
        {
            if (GetRow(projectId).IsNull("ClientProjectNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["ClientProjectNumber"];
            }
        }



        /// <summary>
        /// GetClientPrimaryContactID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Client Primary Contact ID or EMPTY</returns>
        public int? GetClientPrimaryContactID(int projectId)
        {
            if (GetRow(projectId).IsNull("ClientPrimaryContactID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["ClientPrimaryContactID"];
            }
        }



        /// <summary>
        /// GetClientSecondaryContactID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Client Secondary Contact ID or EMPTY</returns>
        public int? GetClientSecondaryContactID(int projectId)
        {
            if (GetRow(projectId).IsNull("ClientSecondaryContactID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["ClientSecondaryContactID"];
            }
        }



        /// <summary>
        /// GetDeleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetDeleted(int projectId)
        {
            return (bool)GetRow(projectId)["Deleted"];
        }



        /// <summary>
        /// GetOriginalProjectID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Original Project Id</returns>
        public int? GetOriginalProjectID(int projectId)
        {
            if (GetRow(projectId).IsNull("OriginalProjectID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["OriginalProjectID"];
            }
        }



        /// <summary>
        /// GetProjectNumberCopy. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project Number Copy</returns>
        public int? GetProjectNumberCopy(int projectId)
        {
            if (GetRow(projectId).IsNull("ProjectNumberCopy"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["ProjectNumberCopy"];
            }
        }



        /// <summary>
        /// GetLibraryCategoriesId. If project not exists, raise an exception
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Library Categories Id</returns>
        public int? GetLibraryCategoriesId(int projectId)
        {
            if (GetRow(projectId).IsNull("LIBRARY_CATEGORIES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId)["LIBRARY_CATEGORIES_ID"];
            }
        }



        /// <summary>
        /// GetCityID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>City Id</returns>
        public Int64? GetCityID(int projectId)
        {
            if (GetRow(projectId).IsNull("CityID"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(projectId)["CityID"];
            }
        }



        /// <summary>
        /// GetProvinceID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Province Id</returns>
        public Int64? GetProvinceID(int projectId)
        {
            if (GetRow(projectId).IsNull("ProvinceID"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(projectId)["ProvinceID"];
            }
        }



        /// <summary>
        /// GetCountyID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>County ID</returns>
        public Int64? GetCountyID(int projectId)
        {
            if (GetRow(projectId).IsNull("CountyID"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(projectId)["CountyID"];
            }
        }



        /// <summary>
        /// GetFairWageApplies. If project not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>FairWageApplies</returns>
        public bool GetFairWageApplies(int projectId)
        {
            return (bool)GetRow(projectId)["FairWageApplies"];
        }



        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
            {
                try
                {
                    Adapter.Update(Data, this.TableName);
                }
                catch (DBConcurrencyException dBConcurrencyException)
                {
                    throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
                }
                catch (SqlException sqlException)
                {
                    byte severityLevel = sqlException.Class;
                    if (severityLevel <= 16)
                    {
                        throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if ((severityLevel >= 17) && (severityLevel <= 19))
                    {
                        throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if (severityLevel >= 20)
                    {
                        throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Unknow error. Your operation has been cancelled.", e);
                }
            }
        }



        /// <summary>
        /// Update2 - ProjectNumber and ProjectHistory
        /// </summary>
        public void Update2()
        {
            ProjectNumberGateway projectNumberGateway = new ProjectNumberGateway(Data);
            ProjectHistoryGateway projectHistoryGateway = new ProjectHistoryGateway(Data);

            DataTable projectChanges = Table.GetChanges();
            DataTable projectNumberChanges = projectNumberGateway.Table.GetChanges();
            DataTable projectHistoryChanges = projectHistoryGateway.Table.GetChanges();

            if ((projectChanges == null) && (projectNumberChanges == null) && (projectHistoryChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectNumberGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectNumberGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectNumberGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectHistoryGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectHistoryGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectHistoryGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((projectChanges != null) && (projectChanges.Rows.Count > 0))
                {
                    Adapter.Update(projectChanges);
                    int newProjectId = DB.GetIdentCurrent("LFS_PROJECT", DB.Transaction);

                    //Getting projectId for History table
                    ProjectTDS.LFS_PROJECT_HISTORYRow row = ((ProjectTDS.LFS_PROJECT_HISTORYDataTable)projectHistoryGateway.Table).FindByProjectIDRefID(0, 1);
                    row.ProjectID = newProjectId;
                    projectHistoryChanges = projectHistoryGateway.Table.GetChanges();
                }

                if ((projectNumberChanges != null) && (projectNumberChanges.Rows.Count > 0))
                {
                    projectNumberGateway.Adapter.Update(projectNumberChanges);
                }

                if ((projectHistoryChanges != null) && (projectHistoryChanges.Rows.Count > 0))
                {
                    projectHistoryGateway.Adapter.Update(projectHistoryChanges);
                }

                DB.CommitTransaction();
            }

            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }

            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }

            catch (Exception e)
            {
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }

            finally
            {
                DB.Close();
            }
        }



        /// <summary>
        /// Update3 - Update all project
        /// </summary>
        public void Update3()
        {
            ProjectCostingUpdatesGateway projectCostingUpdatesGateway = new ProjectCostingUpdatesGateway(Data);
            ProjectEngineerSubcontractorsGateway projectEngineerSubcontractorsGateway = new ProjectEngineerSubcontractorsGateway(Data);
            ProjectHistoryGateway projectHistoryGateway = new ProjectHistoryGateway(Data);            
            ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(Data);            
            ProjectSubcontractorGateway projectSubcontractorGateway = new ProjectSubcontractorGateway(Data);
            ProjectTechnicalGateway projectTechnicalGateway = new ProjectTechnicalGateway(Data);
            ProjectTermsPOGateway projectTermsPOGateway = new ProjectTermsPOGateway(Data);
            
            DataTable projectChanges = Table.GetChanges();
            DataTable projectCostingUpdatesChanges = projectCostingUpdatesGateway.Table.GetChanges();
            DataTable projectEngineerSubcontractorsChanges = projectEngineerSubcontractorsGateway.Table.GetChanges();
            DataTable projectHistoryChanges = projectHistoryGateway.Table.GetChanges();            
            DataTable projectSaleBillingPricingChanges = projectSaleBillingPricingGateway.Table.GetChanges();            
            DataTable projectSubcontractorChanges = projectSubcontractorGateway.Table.GetChanges();
            DataTable projectTechnicalChanges = projectTechnicalGateway.Table.GetChanges();
            DataTable projectTermsPOChanges = projectTermsPOGateway.Table.GetChanges();

            if ((projectChanges == null) && (projectCostingUpdatesChanges == null) && (projectEngineerSubcontractorsChanges == null) && (projectHistoryChanges == null)  && (projectSaleBillingPricingChanges == null) && (projectSubcontractorChanges == null) && (projectTechnicalChanges == null) && (projectTermsPOChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectCostingUpdatesGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectCostingUpdatesGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectCostingUpdatesGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectEngineerSubcontractorsGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectEngineerSubcontractorsGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectEngineerSubcontractorsGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectHistoryGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectHistoryGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectHistoryGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectSaleBillingPricingGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectSaleBillingPricingGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectSaleBillingPricingGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectSubcontractorGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectSubcontractorGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectSubcontractorGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTechnicalGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTechnicalGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTechnicalGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTermsPOGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTermsPOGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTermsPOGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((projectChanges != null) && (projectChanges.Rows.Count > 0))
                {
                    Adapter.Update(projectChanges);
                }

                if ((projectCostingUpdatesChanges != null) && (projectCostingUpdatesChanges.Rows.Count > 0))
                {
                    projectCostingUpdatesGateway.Adapter.Update(projectCostingUpdatesChanges);
                }

                if ((projectEngineerSubcontractorsChanges != null) && (projectEngineerSubcontractorsChanges.Rows.Count > 0))
                {
                    projectEngineerSubcontractorsGateway.Adapter.Update(projectEngineerSubcontractorsChanges);
                }

                if ((projectHistoryChanges != null) && (projectHistoryChanges.Rows.Count > 0))
                {
                    projectHistoryGateway.Adapter.Update(projectHistoryChanges);
                }              

                if ((projectSaleBillingPricingChanges != null) && (projectSaleBillingPricingChanges.Rows.Count > 0))
                {
                    projectSaleBillingPricingGateway.Adapter.Update(projectSaleBillingPricingChanges);
                }              

                if ((projectSubcontractorChanges != null) && (projectSubcontractorChanges.Rows.Count > 0))
                {
                    projectSubcontractorGateway.Adapter.Update(projectSubcontractorChanges);
                }

                if ((projectTechnicalChanges != null) && (projectTechnicalChanges.Rows.Count > 0))
                {
                    projectTechnicalGateway.Adapter.Update(projectTechnicalChanges);
                }

                if ((projectTermsPOChanges != null) && (projectTermsPOChanges.Rows.Count > 0))
                {
                    projectTermsPOGateway.Adapter.Update(projectTermsPOChanges);
                }

                DB.CommitTransaction();
            }

            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }

            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }

            catch (Exception e)
            {
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }

            finally
            {
                DB.Close();
            }
        }
        


        /// <summary>
        /// Update4 - Duplicate proposal
        /// </summary>
        public void Update4()
        {
            ProjectCostingUpdatesGateway projectCostingUpdatesGateway = new ProjectCostingUpdatesGateway(Data);
            ProjectEngineerSubcontractorsGateway projectEngineerSubcontractorsGateway = new ProjectEngineerSubcontractorsGateway(Data);
            ProjectHistoryGateway projectHistoryGateway = new ProjectHistoryGateway(Data);
            ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(Data);
            ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(Data);
            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(Data);
            ProjectSubcontractorGateway projectSubcontractorGateway = new ProjectSubcontractorGateway(Data);
            ProjectTechnicalGateway projectTechnicalGateway = new ProjectTechnicalGateway(Data);
            ProjectTermsPOGateway projectTermsPOGateway = new ProjectTermsPOGateway(Data);

            DataTable projectChanges = Table.GetChanges();
            DataTable projectCostingUpdatesChanges = projectCostingUpdatesGateway.Table.GetChanges();
            DataTable projectEngineerSubcontractorsChanges = projectEngineerSubcontractorsGateway.Table.GetChanges();
            DataTable projectHistoryChanges = projectHistoryGateway.Table.GetChanges();
            DataTable projectNotesChanges = projectNotesGateway.Table.GetChanges();
            DataTable projectSaleBillingPricingChanges = projectSaleBillingPricingGateway.Table.GetChanges();
            DataTable projectServiceChanges = projectServiceGateway.Table.GetChanges();
            DataTable projectSubcontractorChanges = projectSubcontractorGateway.Table.GetChanges();
            DataTable projectTechnicalChanges = projectTechnicalGateway.Table.GetChanges();
            DataTable projectTermsPOChanges = projectTermsPOGateway.Table.GetChanges();

            if ((projectChanges == null) && (projectCostingUpdatesChanges == null) && (projectEngineerSubcontractorsChanges == null) && (projectHistoryChanges == null) && (projectNotesChanges == null) && (projectSaleBillingPricingChanges == null) && (projectServiceChanges == null) && (projectSubcontractorChanges == null) && (projectTechnicalChanges == null) && (projectTermsPOChanges == null)) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectCostingUpdatesGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectCostingUpdatesGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectCostingUpdatesGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectEngineerSubcontractorsGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectEngineerSubcontractorsGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectEngineerSubcontractorsGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectHistoryGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectHistoryGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectHistoryGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectNotesGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectNotesGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectNotesGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectSaleBillingPricingGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectSaleBillingPricingGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectSaleBillingPricingGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectServiceGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectServiceGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectServiceGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectSubcontractorGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectSubcontractorGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectSubcontractorGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTechnicalGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTechnicalGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTechnicalGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                projectTermsPOGateway.Adapter.InsertCommand.Transaction = DB.Transaction;
                projectTermsPOGateway.Adapter.UpdateCommand.Transaction = DB.Transaction;
                projectTermsPOGateway.Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((projectChanges != null) && (projectChanges.Rows.Count > 0))
                {
                    Adapter.Update(projectChanges);

                    int newProjectId = DB.GetIdentCurrent("LFS_PROJECT", DB.Transaction);

                    //Getting projectId for History table
                    ProjectTDS.LFS_PROJECT_HISTORYRow rowHistory = ((ProjectTDS.LFS_PROJECT_HISTORYDataTable)projectHistoryGateway.Table).FindByProjectIDRefID(0, 1);
                    rowHistory.ProjectID = newProjectId;
                    projectHistoryChanges = projectHistoryGateway.Table.GetChanges();

                    //Getting projectId for Costing Updates table
                    if (projectCostingUpdatesGateway.Table.Rows.Count > 0)
                    {
                        ProjectTDS.LFS_PROJECT_COSTING_UPDATESRow rowProjectCosting = ((ProjectTDS.LFS_PROJECT_COSTING_UPDATESDataTable)projectCostingUpdatesGateway.Table).FindByProjectID(0);
                        rowProjectCosting.ProjectID = newProjectId;
                        projectCostingUpdatesChanges = projectCostingUpdatesGateway.Table.GetChanges();
                    }

                    //Getting projectId for Engineer Subcontractors table
                    if (projectEngineerSubcontractorsGateway.Table.Rows.Count > 0)
                    {
                        ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSRow rowEngineerSubcontractors = ((ProjectTDS.LFS_PROJECT_ENGINEER_SUBCONTRACTORSDataTable)projectEngineerSubcontractorsGateway.Table).FindByProjectID(0);
                        rowEngineerSubcontractors.ProjectID = newProjectId;
                        projectEngineerSubcontractorsChanges = projectEngineerSubcontractorsGateway.Table.GetChanges();
                    }

                    //Getting projectId for Notes table
                    foreach (ProjectTDS.LFS_PROJECT_NOTERow rowNotes in (ProjectTDS.LFS_PROJECT_NOTEDataTable)projectNotesGateway.Table)
                    {
                        if (rowNotes.ProjectID == 0)
                        {
                            rowNotes.ProjectID = newProjectId;
                        }
                    }
                    projectNotesChanges = projectNotesGateway.Table.GetChanges();

                    //Getting projectId for SaleBillingPricing
                    if (projectSaleBillingPricingGateway.Table.Rows.Count > 0)
                    {
                        ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGRow rowSaleBillingPricing = ((ProjectTDS.LFS_PROJECT_SALE_BILLING_PRICINGDataTable)projectSaleBillingPricingGateway.Table).FindByProjectID(0);
                        rowSaleBillingPricing.ProjectID = newProjectId;
                        projectSaleBillingPricingChanges = projectSaleBillingPricingGateway.Table.GetChanges();
                    }

                    //Getting projectId for Subcontractors
                    foreach (ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow rowSubcontractor in (ProjectTDS.LFS_PROJECT_SUBCONTRACTORDataTable)projectSubcontractorGateway.Table)
                    {
                        if (rowSubcontractor.ProjectID == 0)
                        {
                            rowSubcontractor.ProjectID = newProjectId;
                        }
                    }
                    projectSubcontractorChanges = projectSubcontractorGateway.Table.GetChanges();

                    //Getting projectId for Services
                    foreach (ProjectTDS.LFS_PROJECT_SERVICERow rowService in (ProjectTDS.LFS_PROJECT_SERVICEDataTable)projectServiceGateway.Table)
                    {
                        if (rowService.ProjectID == 0)
                        {
                            rowService.ProjectID = newProjectId;
                        }
                    }
                    projectServiceChanges = projectServiceGateway.Table.GetChanges();

                    //Getting projectId for Technical
                    if (projectTechnicalGateway.Table.Rows.Count > 0)
                    {
                        ProjectTDS.LFS_PROJECT_TECHNICALRow rowTechnical = ((ProjectTDS.LFS_PROJECT_TECHNICALDataTable)projectTechnicalGateway.Table).FindByProjectID(0);
                        rowTechnical.ProjectID = newProjectId;
                        projectTechnicalChanges = projectTechnicalGateway.Table.GetChanges();
                    }

                    //Getting projectId for Terms
                    if (projectTermsPOGateway.Table.Rows.Count > 0)
                    {
                        ProjectTDS.LFS_PROJECT_TERMSRow rowTerms = ((ProjectTDS.LFS_PROJECT_TERMSDataTable)projectTermsPOGateway.Table).FindByProjectID(0);
                        rowTerms.ProjectID = newProjectId;
                        projectTermsPOChanges = projectTermsPOGateway.Table.GetChanges();
                    }
                }

                if ((projectCostingUpdatesChanges != null) && (projectCostingUpdatesChanges.Rows.Count > 0))
                {
                    projectCostingUpdatesGateway.Adapter.Update(projectCostingUpdatesChanges);
                }

                if ((projectEngineerSubcontractorsChanges != null) && (projectEngineerSubcontractorsChanges.Rows.Count > 0))
                {
                    projectEngineerSubcontractorsGateway.Adapter.Update(projectEngineerSubcontractorsChanges);
                }

                if ((projectHistoryChanges != null) && (projectHistoryChanges.Rows.Count > 0))
                {
                    projectHistoryGateway.Adapter.Update(projectHistoryChanges);
                }

                if ((projectNotesChanges != null) && (projectNotesChanges.Rows.Count > 0))
                {
                    projectNotesGateway.Adapter.Update(projectNotesChanges);
                }

                if ((projectSaleBillingPricingChanges != null) && (projectSaleBillingPricingChanges.Rows.Count > 0))
                {
                    projectSaleBillingPricingGateway.Adapter.Update(projectSaleBillingPricingChanges);
                }

                if ((projectServiceChanges != null) && (projectServiceChanges.Rows.Count > 0))
                {
                    projectServiceGateway.Adapter.Update(projectServiceChanges);
                }

                if ((projectSubcontractorChanges != null) && (projectSubcontractorChanges.Rows.Count > 0))
                {
                    projectSubcontractorGateway.Adapter.Update(projectSubcontractorChanges);
                }

                if ((projectTechnicalChanges != null) && (projectTechnicalChanges.Rows.Count > 0))
                {
                    projectTechnicalGateway.Adapter.Update(projectTechnicalChanges);
                }

                if ((projectTermsPOChanges != null) && (projectTermsPOChanges.Rows.Count > 0))
                {
                    projectTermsPOGateway.Adapter.Update(projectTermsPOChanges);
                }

                DB.CommitTransaction();
            }

            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }

            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
                byte severityLevel = sqlException.Class;
                if (severityLevel <= 16)
                {
                    throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if ((severityLevel >= 17) && (severityLevel <= 19))
                {
                    throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
                if (severityLevel >= 20)
                {
                    throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                }
            }

            catch (Exception e)
            {
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }

            finally
            {
                DB.Close();
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsUsedInProjectTime
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInProjectTime(int projectId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_PROJECT_TIME WHERE (ProjectID = @projectId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInTeamProjectTime
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInTeamProjectTime(int projectId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_TEAM_PROJECT_TIME AS PT WHERE (PT.Deleted = 0) AND (PT.ProjectID = @projectId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// GetOperatorGroupRate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <returns>RATE</returns>
        public decimal GetOperatorGroupRate(int projectId, string jobClassType)
        {
            string commandText = "SELECT TOP 1 LFS_PROJECT_JOB_CLASS_TYPE_RATE.Rate FROM LFS_PROJECT_JOB_CLASS_TYPE_RATE INNER JOIN LFS_PROJECT ON LFS_PROJECT.ProjectID = LFS_PROJECT_JOB_CLASS_TYPE_RATE.ProjectID "+
                                    "  WHERE (LFS_PROJECT_JOB_CLASS_TYPE_RATE.ProjectID = @projectId) AND (LFS_PROJECT_JOB_CLASS_TYPE_RATE.Deleted = 0) AND (LFS_PROJECT_JOB_CLASS_TYPE_RATE.JobClassType = @jobClassType) ";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));
            command.Parameters.Add(new SqlParameter("@jobClassType", jobClassType));

            try
            {
                return (decimal)ExecuteScalar(command);
            }
            catch
            {
                return 0;
            }
        }



        /// <summary>
        /// GetOperatorGroupFringeRate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <returns>RATE</returns>
        public decimal GetOperatorGroupFringeRate(int projectId, string jobClassType)
        {
            string commandText = "SELECT TOP 1 LFS_PROJECT_JOB_CLASS_TYPE_RATE.FringeRate FROM LFS_PROJECT_JOB_CLASS_TYPE_RATE INNER JOIN LFS_PROJECT ON LFS_PROJECT.ProjectID = LFS_PROJECT_JOB_CLASS_TYPE_RATE.ProjectID " +
                                    "  WHERE (LFS_PROJECT_JOB_CLASS_TYPE_RATE.ProjectID = @projectId) AND (LFS_PROJECT_JOB_CLASS_TYPE_RATE.Deleted = 0) AND (LFS_PROJECT_JOB_CLASS_TYPE_RATE.JobClassType = @jobClassType) ";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));
            command.Parameters.Add(new SqlParameter("@jobClassType", jobClassType));

            try
            {
                return (decimal)ExecuteScalar(command);
            }
            catch
            {
                return 0;
            }
        }



        /// <summary>
        /// IsUsedInTeamProjectTimeDetail
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInTeamProjectTimeDetail(int projectId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_TEAM_PROJECT_TIME_DETAIL AS TPTD WHERE (TPTD.ProjectID = @projectId) AND (TPTD.Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }




        /// <summary>
        /// IsUsedInTeamProjectTimeDetail
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsFairWageProjectWorkFunction(int projectId, string work_, string function_)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE INNER JOIN LFS_PROJECT ON LFS_PROJECT.ProjectID = LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.ProjectID " +
                                    "  WHERE (LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.ProjectID = @projectId) AND (LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.Deleted = 0) AND (LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.Work_ = @work_) AND (LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.Function_ = @function_) AND (LFS_PROJECT_WORK_FUNCTION_FAIR_WAGE.IsFairWage = 1) ";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));
            command.Parameters.Add(new SqlParameter("@work_", work_));
            command.Parameters.Add(new SqlParameter("@function_", function_));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// GetLastProjectId
        /// </summary>
        /// <returns>Last ProjectID</returns>
        public int GetLastProjectId()
        {
            string commandText = "SELECT MAX(ProjectID) AS projectId FROM LFS_PROJECT";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            return ((int)ExecuteScalar(command));
        }



        /// <summary>
        /// GetLastProjectNumberCopy
        /// </summary>
        /// <returns>Last ProjectNumberCopy</returns>
        public int? GetLastProjectNumberCopy(int projectId)
        {
            string commandText = "SELECT MAX(ProjectNumberCopy) AS projectNumberCopy FROM LFS_PROJECT WHERE (OriginalProjectID = @projectId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@projectId", projectId));

            if (ExecuteScalar(command) == DBNull.Value)
            {
                return null;
            }
            else
            {
                return ((int)ExecuteScalar(command));
            }
        }



    }
}