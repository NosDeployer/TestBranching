using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    public class DataMigrationProjectGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DataMigrationProjectGateway()
            : base("DataMigrationProject")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DataMigrationProjectGateway(DataSet data)
            : base(data, "DataMigrationProject")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DataMigrationTDS();
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
            tableMapping.DataSetTable = "DataMigrationProject";
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("OfficeID", "OfficeID");
            tableMapping.ColumnMappings.Add("ProjectLeadID", "ProjectLeadID");
            tableMapping.ColumnMappings.Add("SalesmanID", "SalesmanID");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ProvinceID", "ProvinceID");
            tableMapping.ColumnMappings.Add("CityID", "CityID");
            tableMapping.ColumnMappings.Add("CountyID", "CountyID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }

        
        
        /// <summary>
        /// InsertProject
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="officeId">officeId</param>
        /// <param name="projectLeadId">projectLeadId</param>
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="projectNumber">projectNumber</param>
        /// <param name="projectType">projectType</param>
        /// <param name="projectState">projectState</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="proposalDate">proposalDate</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="clientId">clientId</param>
        /// <param name="clientPrimaryContactID">clientPrimaryContactID</param>
        /// <param name="clientSecondaryContactID">clientSecondaryContactID</param>
        /// <param name="clientProjectNumber">clientProjectNumber</param>
        /// <param name="deleted">deleted</param>
        /// <param name="originalProjectID">originalProjectID</param>
        /// <param name="projectNumberCopy">projectNumberCopy</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="countyId">countyId</param>
        /// <returns></returns>
        public int InsertProject(Int64 countryId, int officeId, int? projectLeadId, int salesmanId, string projectNumber, string projectType, string projectState, string name, string description, DateTime? proposalDate, DateTime? startDate, DateTime? endDate, int clientId, int? clientPrimaryContactID, int? clientSecondaryContactID, string clientProjectNumber, bool deleted, int? originalProjectID, int? projectNumberCopy, int? libraryCategoriesId, Int64? provinceId, Int64? cityId, int companyId, Int64? countyId)
        {
            SqlParameter countryIdParameter = new SqlParameter("CountryID", (Int64)countryId);
            SqlParameter officeIdParameter = new SqlParameter("OfficeID", officeId);
            SqlParameter projectLeadIdParameter = (projectLeadId.HasValue) ? new SqlParameter("ProjectLeadID", (int)projectLeadId) : new SqlParameter("ProjectLeadID", DBNull.Value);
            SqlParameter salesmanIdParameter = new SqlParameter("SalesmanID", salesmanId);
            SqlParameter projectNumberParameter = new SqlParameter("ProjectNumber", projectNumber);
            SqlParameter projectTypeParameter = new SqlParameter("ProjectType", projectType);
            SqlParameter projectStateParameter = new SqlParameter("ProjectState", projectState);
            SqlParameter nameParameter = new SqlParameter("Name", name);
            SqlParameter descriptionParameter = (description != "") ? new SqlParameter("Description", description) : new SqlParameter("Description", DBNull.Value);
            SqlParameter proposalDateParameter = (proposalDate.HasValue) ? new SqlParameter("ProposalDate", (DateTime)proposalDate) : new SqlParameter("ProposalDate", DBNull.Value);
            SqlParameter startDateParameter = (startDate.HasValue) ? new SqlParameter("StartDate", (DateTime)startDate) : new SqlParameter("StartDate", DBNull.Value);
            SqlParameter endDateParameter = (endDate.HasValue) ? new SqlParameter("EndDate", (DateTime)endDate) : new SqlParameter("EndDate", DBNull.Value);
            SqlParameter cliendIdParameter = new SqlParameter("ClientID", clientId);
            SqlParameter clientProjectNumberParameter = (clientProjectNumber != "") ? new SqlParameter("ClientProjectNumber", clientProjectNumber) : new SqlParameter("ClientProjectNumber", DBNull.Value);
            SqlParameter clientPrimaryContactIdParameter = (clientPrimaryContactID.HasValue) ? new SqlParameter("ClientPrimaryContactID", (int)clientPrimaryContactID) : new SqlParameter("ClientPrimaryContactID", DBNull.Value);
            SqlParameter clientSecondaryContactIdParameter = (clientSecondaryContactID.HasValue) ? new SqlParameter("ClientSecondaryContactID", (int)clientSecondaryContactID) : new SqlParameter("ClientSecondaryContactID", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter originalProjectIdParameter = (originalProjectID.HasValue) ? new SqlParameter("OriginalProjectID", (int)originalProjectID) : new SqlParameter("OriginalProjectID", DBNull.Value);
            SqlParameter projectNumberCopyParameter = (projectNumberCopy.HasValue) ? new SqlParameter("ProjectNumberCopy", (int)projectNumberCopy) : new SqlParameter("ProjectNumberCopy", DBNull.Value);
            SqlParameter libraryCategoriesIdParameter = (libraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", (int)libraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);
            SqlParameter provinceIdParameter = (provinceId.HasValue) ? new SqlParameter("ProvinceID", (Int64)provinceId) : new SqlParameter("ProvinceID", DBNull.Value);
            SqlParameter cityIdParameter = (cityId.HasValue) ? new SqlParameter("CityID", (Int64)cityId) : new SqlParameter("CityID", DBNull.Value);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter countyIdParameter = (countyId.HasValue) ? new SqlParameter("CountyID", (Int64)countyId) : new SqlParameter("CountyID", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_PROJECT] ([CountryID], [OfficeID], [ProjectLeadID], [SalesmanID], [ProjectNumber], [ProjectType], [ProjectState], [Name], [Description], [ProposalDate], [StartDate], [EndDate], [ClientID], [ClientProjectNumber], [ClientPrimaryContactID], [ClientSecondaryContactID], [Deleted], [OriginalProjectID], [ProjectNumberCopy], [LIBRARY_CATEGORIES_ID], [ProvinceID], [CityID], [COMPANY_ID], [CountyID]) VALUES (@CountryID, @OfficeID, @ProjectLeadID, @SalesmanID, @ProjectNumber, @ProjectType, @ProjectState, @Name, @Description, @ProposalDate, @StartDate, @EndDate, @ClientID, @ClientProjectNumber, @ClientPrimaryContactID, @ClientSecondaryContactID, @Deleted, @OriginalProjectID, @ProjectNumberCopy, @LIBRARY_CATEGORIES_ID, @ProvinceID, @CityID, @COMPANY_ID, @CountyID); SELECT ProjectID FROM LFS_PROJECT WHERE (ProjectID = SCOPE_IDENTITY())";

            int projectId = (int)ExecuteScalar(command, countryIdParameter, officeIdParameter, projectLeadIdParameter, salesmanIdParameter, projectNumberParameter, projectTypeParameter, projectStateParameter, nameParameter, descriptionParameter, proposalDateParameter, startDateParameter, endDateParameter, cliendIdParameter, clientProjectNumberParameter, clientPrimaryContactIdParameter, clientSecondaryContactIdParameter, deletedParameter, originalProjectIdParameter, projectNumberCopyParameter, libraryCategoriesIdParameter, provinceIdParameter, cityIdParameter, companyIdParameter, countyIdParameter);

            return projectId;
        }



        /// <summary>
        /// InsertHistory
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="projectState">projectState</param>
        /// <param name="date_">date_</param>
        /// <param name="loginId">logonId</param>
        /// <param name="companyId">companyId</param>
        public void InsertHistory(int projectId, int refId, string projectState, DateTime date_, int loginId, int companyId)
        {
            SqlParameter projectIdParameter = new SqlParameter("ProjectID", projectId);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter projectStateParameter = new SqlParameter("ProjectState", projectState);
            SqlParameter date_Parameter = new SqlParameter("Date_", date_);
            SqlParameter loginIdParameter = new SqlParameter("LoginID", loginId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

            string command = "INSERT INTO [dbo].[LFS_PROJECT_HISTORY] ([ProjectID], [RefID], [ProjectState], [Date_], [LoginID], [COMPANY_ID]) VALUES (@ProjectID, @RefID, @ProjectState, @Date_, @LoginID, @COMPANY_ID);";

            ExecuteNonQuery(command, projectIdParameter, refIdParameter, projectStateParameter, date_Parameter, loginIdParameter, companyIdParameter);            
        }



        /// <summary>
        /// UpdateProjectNumber
        /// </summary>
        /// <param name="originalYearCode">originalYearCode</param>
        /// <param name="newProjectIncrement">newProjectIncrement</param>
        /// <param name="companyId">companyId</param>
        public void UpdateProjectNumber(int originalYearCode, int newProjectIncrement, int companyId)
        {
            SqlParameter originalYearCodeParameter = new SqlParameter("Original_YearCode", originalYearCode);
         
            SqlParameter newProjectIncrementParameter = new SqlParameter("ProjectIncrement", newProjectIncrement);
            
            string command = "UPDATE [dbo].[LFS_PROJECT_NUMBER] " +
                             "SET [ProjectIncrement] = @ProjectIncrement " +
                             "WHERE ([YearCode] = @Original_YearCode)";

            int rowsAffected = (int)ExecuteNonQuery(command, newProjectIncrementParameter, originalYearCodeParameter );
            if (rowsAffected == 0)
            {
                try
                {
                    SqlParameter yearCodeParameter = new SqlParameter("YearCode", originalYearCode);
                    SqlParameter projectIncrementParameter = new SqlParameter("ProjectIncrement", newProjectIncrement);
                    SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);

                    string commandInsert = "INSERT INTO [dbo].[LFS_PROJECT_NUMBER] ([YearCode], [ProjectIncrement], [COMPANY_ID]) VALUES (@YearCode, @ProjectIncrement, @COMPANY_ID);";

                    ExecuteNonQuery(commandInsert, yearCodeParameter, projectIncrementParameter, companyIdParameter);            
                }
                catch
                {
                    throw new Exception("Concurrency error");
                }
            }
        }


        
        /// <summary>
        /// GetProjectIdByName
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetProjectIdByName(string name)
        {
            string commandText = "SELECT ProjectID FROM LFS_PROJECT WHERE (Name = @name)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@name", name));
            int projectId = Convert.ToInt32(ExecuteScalar(command));
                        
            return projectId;            
        }



    }
}

