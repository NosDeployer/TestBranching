using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeGateway
    /// </summary>
    public class EmployeeGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeGateway()
            : base("LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
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
            tableMapping.DataSetTable = "LFS_RESOURCES_EMPLOYEE";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("ContactsID", "ContactsID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("FirstName", "FirstName");
            tableMapping.ColumnMappings.Add("MiddleInitial", "MiddleInitial");
            tableMapping.ColumnMappings.Add("LastName", "LastName");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("IsSalesman", "IsSalesman");
            tableMapping.ColumnMappings.Add("RequestProjectTime", "RequestProjectTime");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Salaried", "Salaried");
            tableMapping.ColumnMappings.Add("eMail", "eMail");
            tableMapping.ColumnMappings.Add("AssignableSRS", "AssignableSRS");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
            tableMapping.ColumnMappings.Add("Category", "Category");
            tableMapping.ColumnMappings.Add("PersonalAgencyName", "PersonalAgencyName");
            tableMapping.ColumnMappings.Add("IsVacationsManager", "IsVacationsManager");
            tableMapping.ColumnMappings.Add("ApproveTimesheets", "ApproveTimesheets");
            tableMapping.ColumnMappings.Add("BourdenFactor", "BourdenFactor");
            tableMapping.ColumnMappings.Add("USHealthBenefitFactor", "USHealthBenefitFactor");
            tableMapping.ColumnMappings.Add("BenefitFactorCad", "BenefitFactorCad");
            tableMapping.ColumnMappings.Add("BenefitFactorUsd", "BenefitFactorUsd");
            tableMapping.ColumnMappings.Add("Crew", "Crew");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_RESOURCES_EMPLOYEE] WHERE (([EmployeeID] = @Original_Emplo" +
                "yeeID) AND ((@IsNull_LoginID = 1 AND [LoginID] IS NULL) OR ([LoginID] = @Origina" +
                "l_LoginID)) AND ((@IsNull_ContactsID = 1 AND [ContactsID] IS NULL) OR ([Contacts" +
                "ID] = @Original_ContactsID)) AND ([FullName] = @Original_FullName) AND ([FirstNa" +
                "me] = @Original_FirstName) AND ((@IsNull_MiddleInitial = 1 AND [MiddleInitial] I" +
                "S NULL) OR ([MiddleInitial] = @Original_MiddleInitial)) AND ([LastName] = @Origi" +
                "nal_LastName) AND ([Type] = @Original_Type) AND ([State] = @Original_State) AND " +
                "([IsSalesman] = @Original_IsSalesman) AND ([RequestProjectTime] = @Original_Requ" +
                "estProjectTime) AND ([Deleted] = @Original_Deleted) AND ([Salaried] = @Original_" +
                "Salaried) AND ((@IsNull_eMail = 1 AND [eMail] IS NULL) OR ([eMail] = @Original_e" +
                "Mail)) AND ([AssignableSRS] = @Original_AssignableSRS) AND ((@IsNull_JobClassTyp" +
                "e = 1 AND [JobClassType] IS NULL) OR ([JobClassType] = @Original_JobClassType)) " +
                "AND ([Category] = @Original_Category) AND ((@IsNull_PersonalAgencyName = 1 AND [" +
                "PersonalAgencyName] IS NULL) OR ([PersonalAgencyName] = @Original_PersonalAgency" +
                "Name)) AND ([IsVacationsManager] = @Original_IsVacationsManager) AND ([ApproveTi" +
                "mesheets] = @Original_ApproveTimesheets) AND ((@IsNull_BourdenFactor = 1 AND [Bo" +
                "urdenFactor] IS NULL) OR ([BourdenFactor] = @Original_BourdenFactor)) AND ((@IsN" +
                "ull_USHealthBenefitFactor = 1 AND [USHealthBenefitFactor] IS NULL) OR ([USHealth" +
                "BenefitFactor] = @Original_USHealthBenefitFactor)) AND ((@IsNull_BenefitFactorCa" +
                "d = 1 AND [BenefitFactorCad] IS NULL) OR ([BenefitFactorCad] = @Original_Benefit" +
                "FactorCad)) AND ((@IsNull_BenefitFactorUsd = 1 AND [BenefitFactorUsd] IS NULL) O" +
                "R ([BenefitFactorUsd] = @Original_BenefitFactorUsd)) AND ((@IsNull_Crew = 1 AND " +
                "[Crew] IS NULL) OR ([Crew] = @Original_Crew)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ContactsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContactsID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ContactsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContactsID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FullName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FullName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FirstName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FirstName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MiddleInitial", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiddleInitial", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MiddleInitial", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiddleInitial", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsSalesman", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsSalesman", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequestProjectTime", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestProjectTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Salaried", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Salaried", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_eMail", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "eMail", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_eMail", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "eMail", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignableSRS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignableSRS", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JobClassType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PersonalAgencyName", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsVacationsManager", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsVacationsManager", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BourdenFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BourdenFactor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BourdenFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BourdenFactor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USHealthBenefitFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USHealthBenefitFactor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USHealthBenefitFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USHealthBenefitFactor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BenefitFactorCad", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BenefitFactorUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Crew", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Crew", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Crew", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Crew", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE] ([LoginID], [ContactsID], [FullName], [FirstName], [MiddleInitial], [LastName], [Type], [State], [IsSalesman], [RequestProjectTime], [Deleted], [Salaried], [eMail], [AssignableSRS], [JobClassType], [Category], [PersonalAgencyName], [IsVacationsManager], [ApproveTimesheets], [BourdenFactor], [USHealthBenefitFactor], [BenefitFactorCad], [BenefitFactorUsd], [Crew]) VALUES (@LoginID, @ContactsID, @FullName, @FirstName, @MiddleInitial, @LastName, @Type, @State, @IsSalesman, @RequestProjectTime, @Deleted, @Salaried, @eMail, @AssignableSRS, @JobClassType, @Category, @PersonalAgencyName, @IsVacationsManager, @ApproveTimesheets, @BourdenFactor, @USHealthBenefitFactor, @BenefitFactorCad, @BenefitFactorUsd, @Crew);
SELECT EmployeeID, LoginID, ContactsID, FullName, FirstName, MiddleInitial, LastName, Type, State, IsSalesman, RequestProjectTime, Deleted, Salaried, eMail, AssignableSRS, JobClassType, Category, PersonalAgencyName, IsVacationsManager, ApproveTimesheets, BourdenFactor, USHealthBenefitFactor, BenefitFactorCad, BenefitFactorUsd, Crew FROM LFS_RESOURCES_EMPLOYEE WHERE (EmployeeID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ContactsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContactsID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FullName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FullName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FirstName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FirstName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MiddleInitial", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiddleInitial", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsSalesman", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsSalesman", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequestProjectTime", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestProjectTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Salaried", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Salaried", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@eMail", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "eMail", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignableSRS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignableSRS", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsVacationsManager", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsVacationsManager", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BourdenFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BourdenFactor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USHealthBenefitFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USHealthBenefitFactor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Crew", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Crew", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE] SET [LoginID] = @LoginID, [ContactsID] = @C" +
                "ontactsID, [FullName] = @FullName, [FirstName] = @FirstName, [MiddleInitial] = @" +
                "MiddleInitial, [LastName] = @LastName, [Type] = @Type, [State] = @State, [IsSale" +
                "sman] = @IsSalesman, [RequestProjectTime] = @RequestProjectTime, [Deleted] = @De" +
                "leted, [Salaried] = @Salaried, [eMail] = @eMail, [AssignableSRS] = @AssignableSR" +
                "S, [JobClassType] = @JobClassType, [Category] = @Category, [PersonalAgencyName] " +
                "= @PersonalAgencyName, [IsVacationsManager] = @IsVacationsManager, [ApproveTimes" +
                "heets] = @ApproveTimesheets, [BourdenFactor] = @BourdenFactor, [USHealthBenefitF" +
                "actor] = @USHealthBenefitFactor, [BenefitFactorCad] = @BenefitFactorCad, [Benefi" +
                "tFactorUsd] = @BenefitFactorUsd, [Crew] = @Crew WHERE (([EmployeeID] = @Original" +
                "_EmployeeID) AND ((@IsNull_LoginID = 1 AND [LoginID] IS NULL) OR ([LoginID] = @O" +
                "riginal_LoginID)) AND ((@IsNull_ContactsID = 1 AND [ContactsID] IS NULL) OR ([Co" +
                "ntactsID] = @Original_ContactsID)) AND ([FullName] = @Original_FullName) AND ([F" +
                "irstName] = @Original_FirstName) AND ((@IsNull_MiddleInitial = 1 AND [MiddleInit" +
                "ial] IS NULL) OR ([MiddleInitial] = @Original_MiddleInitial)) AND ([LastName] = " +
                "@Original_LastName) AND ([Type] = @Original_Type) AND ([State] = @Original_State" +
                ") AND ([IsSalesman] = @Original_IsSalesman) AND ([RequestProjectTime] = @Origina" +
                "l_RequestProjectTime) AND ([Deleted] = @Original_Deleted) AND ([Salaried] = @Ori" +
                "ginal_Salaried) AND ((@IsNull_eMail = 1 AND [eMail] IS NULL) OR ([eMail] = @Orig" +
                "inal_eMail)) AND ([AssignableSRS] = @Original_AssignableSRS) AND ((@IsNull_JobCl" +
                "assType = 1 AND [JobClassType] IS NULL) OR ([JobClassType] = @Original_JobClassT" +
                "ype)) AND ([Category] = @Original_Category) AND ((@IsNull_PersonalAgencyName = 1" +
                " AND [PersonalAgencyName] IS NULL) OR ([PersonalAgencyName] = @Original_Personal" +
                "AgencyName)) AND ([IsVacationsManager] = @Original_IsVacationsManager) AND ([App" +
                "roveTimesheets] = @Original_ApproveTimesheets) AND ((@IsNull_BourdenFactor = 1 A" +
                "ND [BourdenFactor] IS NULL) OR ([BourdenFactor] = @Original_BourdenFactor)) AND " +
                "((@IsNull_USHealthBenefitFactor = 1 AND [USHealthBenefitFactor] IS NULL) OR ([US" +
                "HealthBenefitFactor] = @Original_USHealthBenefitFactor)) AND ((@IsNull_BenefitFa" +
                "ctorCad = 1 AND [BenefitFactorCad] IS NULL) OR ([BenefitFactorCad] = @Original_B" +
                "enefitFactorCad)) AND ((@IsNull_BenefitFactorUsd = 1 AND [BenefitFactorUsd] IS N" +
                "ULL) OR ([BenefitFactorUsd] = @Original_BenefitFactorUsd)) AND ((@IsNull_Crew = " +
                "1 AND [Crew] IS NULL) OR ([Crew] = @Original_Crew)));\r\nSELECT EmployeeID, LoginI" +
                "D, ContactsID, FullName, FirstName, MiddleInitial, LastName, Type, State, IsSale" +
                "sman, RequestProjectTime, Deleted, Salaried, eMail, AssignableSRS, JobClassType," +
                " Category, PersonalAgencyName, IsVacationsManager, ApproveTimesheets, BourdenFac" +
                "tor, USHealthBenefitFactor, BenefitFactorCad, BenefitFactorUsd, Crew FROM LFS_RE" +
                "SOURCES_EMPLOYEE WHERE (EmployeeID = @EmployeeID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ContactsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContactsID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FullName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FullName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FirstName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FirstName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@MiddleInitial", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiddleInitial", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LastName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsSalesman", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsSalesman", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RequestProjectTime", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestProjectTime", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Salaried", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Salaried", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@eMail", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "eMail", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AssignableSRS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignableSRS", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsVacationsManager", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsVacationsManager", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BourdenFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BourdenFactor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@USHealthBenefitFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USHealthBenefitFactor", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Crew", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Crew", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_EmployeeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LoginID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LoginID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ContactsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContactsID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ContactsID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ContactsID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FullName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FullName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FirstName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FirstName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_MiddleInitial", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiddleInitial", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_MiddleInitial", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "MiddleInitial", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LastName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LastName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsSalesman", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsSalesman", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RequestProjectTime", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RequestProjectTime", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Salaried", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Salaried", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_eMail", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "eMail", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_eMail", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "eMail", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AssignableSRS", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AssignableSRS", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_JobClassType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_JobClassType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "JobClassType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Category", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Category", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PersonalAgencyName", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PersonalAgencyName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PersonalAgencyName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsVacationsManager", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsVacationsManager", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ApproveTimesheets", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ApproveTimesheets", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BourdenFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BourdenFactor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BourdenFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BourdenFactor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_USHealthBenefitFactor", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USHealthBenefitFactor", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_USHealthBenefitFactor", global::System.Data.SqlDbType.Float, 0, global::System.Data.ParameterDirection.Input, 0, 0, "USHealthBenefitFactor", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BenefitFactorCad", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorCad", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorCad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_BenefitFactorUsd", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_BenefitFactorUsd", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "BenefitFactorUsd", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Crew", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Crew", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Crew", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Crew", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@EmployeeID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "EmployeeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByEmployeeId(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_LOADBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// LoadByLoginId
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>Data</returns>
        public DataSet LoadByLoginId(int loginId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_LOADBYLOGINID", new SqlParameter("@loginId", loginId));
            return Data;
        }



        /// <summary>
        /// LoadByFleetManager
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>Data</returns>
        public DataSet LoadByFleetManager(int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_LOADBYFLEETMANAGER", new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadApproveManagersByCategoryType
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="type">type</param>
        /// <returns>Data</returns>
        public DataSet LoadApproveManagersByCategoryType(string category, string type)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_LOADAPPROVEMANAGERSBYCATEGORYTYPE", new SqlParameter("@category", category), new SqlParameter("@type", type));
            return Data;
        }



        /// <summary>
        /// LoadForMailsByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Data</returns>
        public DataSet LoadForMailsByEmployeeId(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_LOADFORMAILSBYEMPLOYEEID", new SqlParameter("@employeeId", employeeId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int employeeId)
        {
            string filter = string.Format("EmployeeID = {0}", employeeId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeGateway.GetRow");
            }
        }



        /// <summary>
        /// GetFullName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>FullName</returns>
        public string GetFullName(int employeeId)
        {
            return (string)GetRow(employeeId)["FullName"];
        }



        /// <summary>
        /// GetLastName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>LastName</returns>
        public string GetLastName(int employeeId)
        {
            return (string)GetRow(employeeId)["LastName"];
        }



        /// <summary>
        /// GetFirstName
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>FirstName</returns>
        public string GetFirstName(int employeeId)
        {
            return (string)GetRow(employeeId)["FirstName"];
        }



        /// <summary>
        /// GetRequestProjectTime
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>RequestProjectTime</returns>
        public bool GetRequestProjectTime(int employeeId)
        {
            return (bool)GetRow(employeeId)["RequestProjectTime"];
        }



        /// <summary>
        /// GetEMail
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>eMail</returns>
        public string GetEMail(int employeeId)
        {
            if (GetRow(employeeId).IsNull("eMail"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["eMail"];
            }
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Type or Empty</returns>
        public string GetType(int employeeId)
        {
            if (GetRow(employeeId).IsNull("Type"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["Type"];
            }
        }



        /// <summary>
        /// GetCategory
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>Category</returns>
        public string GetCategory(int employeeId)
        {
            return (string)GetRow(employeeId)["Category"];
        }



        /// <summary>
        /// GetJobClassType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>JobClassType or Empty</returns>
        public string GetJobClassType(int employeeId)
        {
            if (GetRow(employeeId).IsNull("JobClassType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(employeeId)["JobClassType"];
            }
        }



        /// <summary>
        /// GetIsVacationsManager
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>IsVacationsManager</returns>
        public bool GetIsVacationsManager(int employeeId)
        {
            return (bool)GetRow(employeeId)["IsVacationsManager"];
        }



        /// <summary>
        /// GetApproveTimesheets
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>ApproveTimesheets</returns>
        public bool GetApproveTimesheets(int employeeId)
        {
            return (bool)GetRow(employeeId)["ApproveTimesheets"];
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// IsUsedInProjectsAsSalesman
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <returns>bool</returns>
        public bool IsUsedInProjectsAsSalesman(int employeeId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_ISUSEDINPROJECTSASSALESMAN", new SqlParameter("@employeeId", employeeId));

            if ((int)Table.Rows[0]["No"] > 0)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// IsEmployeeWithTimesheet
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>bool</returns>
        public bool IsEmployeeWithTimesheet(int loginId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_ISEMPLOYEEWITHTIMESHEET", new SqlParameter("@loginId", loginId));

            if (Table.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }



        /// <summary>
        /// GetEmployeIdByLoginId
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>int</returns>
        public int GetEmployeIdByLoginId(int loginId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEEGATEWAY_GETEMPLOYEEIDBYLOGINID", new SqlParameter("@loginId", loginId));

            if (Table.Rows.Count > 0)
            {
                return (int)Table.Rows[0]["EmployeeID"]; ;
            }
            else
            {
                return 0;
            }
        }



        /// <summary>
        /// IsWithApproveTimesheetInCategory
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        /// <returns>TRUE if is used</returns>
        public bool IsEmployeeWithApproveTimesheetInCategory(int employeeId, string category)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_RESOURCES_EMPLOYEE_CATEGORY_APPROVE_TIMESHEETS WHERE (EmployeeID = @employeeId) AND (Category = @category) AND (ApproveTimesheets = 1) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@employeeId", employeeId));
            command.Parameters.Add(new SqlParameter("@category", category));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a employee (direct to DB)
        /// </summary>
        /// <param name="loginId">loginId</param>       
        /// <param name="contactsId">contactsId</param>
        /// <param name="fullName">fullName</param>
        /// <param name="firstName">firstName</param>
        /// <param name="middleInitial">middleInitial</param>
        /// <param name="lastName">lastName</param>
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="isSalesman">isSalesman</param>
        /// <param name="requestProjectTime">requestProjectTime</param>
        /// <param name="deleted">deleted</param>
        /// <param name="salaried">salaried</param>        
        /// <param name="eMail">eMail</param>
        /// <param name="assignableSrs">assignableSrs</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="category">category</param>
        /// <param name="personalAgencyName">personalAgencyName</param>
        /// <param name="isVacationsManager">isVacationsManager</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        /// <param name="bourdenFactor">bourdenFactor</param>
        /// <param name="usHealthBenefitFactor">usHealthBenefitFactor</param>
        /// <param name="benefitFactorCad">benefitFactorCad</param>
        /// <param name="benefitFactorUsd">benefitFactorUsd</param>
        /// <param name="crew">crew</param>
        /// <returns>rowsAffected</returns>
        public int Insert(int? loginId, int? contactsId, string fullName, string firstName, string middleInitial, string lastName, string type, string state, bool isSalesman, bool requestProjectTime, bool deleted, bool salaried, string eMail, bool assignableSrs, string jobClassType, string category, string personalAgencyName, bool isVacationsManager, bool approveTimesheets, decimal? bourdenFactor, decimal? usHealthBenefitFactor, decimal? benefitFactorCad, decimal? benefitFactorUsd, string crew)
        {
            SqlParameter loginIdParameter = (loginId.HasValue) ? new SqlParameter("LoginID", loginId) : new SqlParameter("LoginID", DBNull.Value);
            SqlParameter contactsIdParameter = (contactsId.HasValue) ? new SqlParameter("ContactsID", contactsId) : new SqlParameter("ContactsID", DBNull.Value);
            SqlParameter fullNameParameter = (fullName.Trim() != "") ? new SqlParameter("FullName", fullName.Trim()) : new SqlParameter("FullName", DBNull.Value);
            SqlParameter firstNameParameter = (firstName.Trim() != "") ? new SqlParameter("FirstName", firstName.Trim()) : new SqlParameter("FirstName", DBNull.Value);
            SqlParameter middleInitialParameter = (middleInitial.Trim() != "") ? new SqlParameter("MiddleInitial", middleInitial.Trim()) : new SqlParameter("MiddleInitial", DBNull.Value);
            SqlParameter lastNameParameter = (lastName.Trim() != "") ? new SqlParameter("LastName", lastName.Trim()) : new SqlParameter("LastName", DBNull.Value);
            SqlParameter typeParameter = (type.Trim() != "") ? new SqlParameter("Type", type.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter stateParameter = (state.Trim() != "") ? new SqlParameter("State", state.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter isSalesmanParameter = new SqlParameter("IsSalesman", isSalesman);
            SqlParameter requestProjectTimeParameter = new SqlParameter("RequestProjectTime", requestProjectTime);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter salariedParameter = new SqlParameter("Salaried", salaried);
            SqlParameter eMailParameter = (eMail.Trim() != "") ? new SqlParameter("eMail", eMail.Trim()) : new SqlParameter("eMail", DBNull.Value);
            SqlParameter assignableSRSParameter = new SqlParameter("AssignableSRS", assignableSrs);
            SqlParameter jobClassTypeParameter = (jobClassType.Trim() != "") ? new SqlParameter("JobClassType", jobClassType.Trim()) : new SqlParameter("JobClassType", DBNull.Value);
            SqlParameter categoryParameter = new SqlParameter("Category", category);
            SqlParameter personalAgencyNameParameter = (personalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", personalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            SqlParameter isVacationsManagerParameter = new SqlParameter("IsVacationsManager", isVacationsManager);
            SqlParameter approveTimesheetsParameter = new SqlParameter("ApproveTimesheets", approveTimesheets);
            SqlParameter bourdenFactorParameter = (bourdenFactor.HasValue) ? new SqlParameter("BourdenFactor", (decimal)bourdenFactor) : new SqlParameter("BourdenFactor", DBNull.Value);
            SqlParameter usHealthBenefitFactorParameter = (usHealthBenefitFactor.HasValue) ? new SqlParameter("USHealthBenefitFactor", (decimal)usHealthBenefitFactor) : new SqlParameter("USHealthBenefitFactor", DBNull.Value);
            SqlParameter benefitFactorCadParameter = (benefitFactorCad.HasValue) ? new SqlParameter("BenefitFactorCad", (decimal)benefitFactorCad) : new SqlParameter("BenefitFactorCad", DBNull.Value);
            benefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter benefitFactorUsdParameter = (benefitFactorUsd.HasValue) ? new SqlParameter("BenefitFactorUsd", (decimal)benefitFactorUsd) : new SqlParameter("BenefitFactorUsd", DBNull.Value);
            benefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter crewParameter = (crew.Trim() != "") ? new SqlParameter("Crew", crew.Trim()) : new SqlParameter("Crew", DBNull.Value);

            string command = "INSERT INTO [dbo].[LFS_RESOURCES_EMPLOYEE] ([LoginID], [ContactsID], [FullName], [FirstName], [MiddleInitial], [LastName], [Type], [State], [IsSalesman], [RequestProjectTime], [Deleted], [Salaried], [eMail], "+
                            " [AssignableSRS], [JobClassType], [Category], [PersonalAgencyName], [IsVacationsManager], [ApproveTimesheets], [BourdenFactor], [USHealthBenefitFactor], [BenefitFactorCad], [BenefitFactorUsd], [Crew]) "+
                            " VALUES (@LoginID, @ContactsID, @FullName, @FirstName, @MiddleInitial, @LastName, @Type, @State, @IsSalesman, @RequestProjectTime, @Deleted, @Salaried, @eMail, @AssignableSRS, @JobClassType, @Category, @PersonalAgencyName, "+
                            " @IsVacationsManager, @ApproveTimesheets, @BourdenFactor, @USHealthBenefitFactor, @BenefitFactorCad, @BenefitFactorUsd, @Crew); " +
                " SELECT EmployeeID FROM LFS_RESOURCES_EMPLOYEE WHERE (EmployeeID = SCOPE_IDENTITY()) ";

            int employeeId = (int)ExecuteScalar(command, loginIdParameter, contactsIdParameter, fullNameParameter, firstNameParameter, middleInitialParameter, lastNameParameter, typeParameter, stateParameter, isSalesmanParameter, requestProjectTimeParameter, deletedParameter, salariedParameter, eMailParameter, assignableSRSParameter, jobClassTypeParameter, categoryParameter, personalAgencyNameParameter, isVacationsManagerParameter, approveTimesheetsParameter, bourdenFactorParameter, usHealthBenefitFactorParameter, benefitFactorCadParameter, benefitFactorUsdParameter, crewParameter);

            return employeeId;
        }



        /// <summary>
        /// Update employee (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <param name="originalLoginId">originalLoginId</param>       
        /// <param name="originalContactsId">originalContactsId</param>
        /// <param name="originalFullName">originalFullName</param>
        /// <param name="originalFirstName">originalFirstName</param>
        /// <param name="originalMiddleInitial">originalMiddleInitial</param>
        /// <param name="originalLastName">originalLastName</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalIsSalesman">originalIsSalesman</param>
        /// <param name="originalRequestProjectTime">originalRequestProjectTime</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalSalaried">originalSalaried</param>
        /// <param name="originalEMail">originalEMail</param>
        /// <param name="originalAssignableSrs">originalAssignableSrs</param>
        /// <param name="originalJobClassType">originalJobClassType</param>
        /// <param name="originalCategory">originalCategory</param>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// <param name="originalIsVacationsManager">originalIsVacationsManager</param>
        /// <param name="originalApproveTimesheets">originalApproveTimesheets</param>
        /// <param name="originalBourdenFactor">originalBourdenFactor</param>
        /// <param name="originalUsHealthBenefitFactor">originalUsHealthBenefitFactor</param>
        /// <param name="originalBenefitFactorCad">originalBenefitFactorCad</param>
        /// <param name="originalBenefitFactorUsd">originalBenefitFactorUsd</param>
        /// <param name="originalCrew">originalCrew</param>
        ///
        /// <param name="newFullName">newFullName</param>
        /// <param name="newFirstName">newFirstName</param>
        /// <param name="newMiddleInitial">newMiddleInitial</param>
        /// <param name="newLastName">newLastName</param>
        /// <param name="newType">newType</param>
        /// <param name="newState">newState</param>
        /// <param name="newIsSalesman">newIsSalesman</param>
        /// <param name="newRequestProjectTime">newRequestProjectTime</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newSalaried">newSalaried</param>
        /// <param name="newEMail">newEMail</param>
        /// <param name="newAssignableSrs">newAssignableSrs</param>
        /// <param name="newJobClassType">newJobClassType</param>
        /// <param name="newCategory">newCategory</param>
        /// <param name="newPersonalAgencyName">nerPersonalAgencyName</param>
        /// <param name="newIsVacationsManager">newIsVacationsManager</param>
        /// <param name="newApproveTimesheets">newApproveTimesheets</param>
        /// <param name="newBourdenFactor">newBourdenFactor</param>
        /// <param name="newUsHealthBenefitFactor">newUsHealthBenefitFactor</param>
        /// <param name="newBenefitFactorCad">newBenefitFactorCad</param>
        /// <param name="newBenefitFactorUsd">newBenefitFactorUsd</param>
        /// <param name="newCrew">newCrew</param>
        /// <returns>rowsAffected</returns>
        public int Update(int originalEmployeeId, int? originalLoginId, int? originalContactsId, string originalFullName, string originalFirstName, string originalMiddleInitial, string originalLastName, string originalType, string originalState, bool originalIsSalesman, bool originalRequestProjectTime, bool originalDeleted, bool originalSalaried, string originalEMail, bool originalAssignableSrs, string originalJobClassType, string originalCategory, string originalPersonalAgencyName, bool originalIsVacationsManager, bool originalApproveTimesheets, decimal? originalBourdenFactor, decimal? originalUsHealthBenefitFactor, decimal? originalBenefitFactorCad, decimal? originalBenefitFactorUsd, string originalCrew, string newFullName, string newFirstName, string newMiddleInitial, string newLastName, string newType, string newState, bool newIsSalesman, bool newRequestProjectTime, bool newDeleted, bool newSalaried, string newEMail, bool newAssignableSrs, string newJobClassType, string newCategory, string newPersonalAgencyName, bool newIsVacationsManager, bool newApproveTimesheets,  decimal? newBourdenFactor, decimal? newUsHealthBenefitFactor, decimal? newBenefitFactorCad, decimal? newBenefitFactorUsd, string newCrew)
        {
            SqlParameter originalEmployeeIdParameter = new SqlParameter("Original_EmployeeID", originalEmployeeId);
            SqlParameter originalLoginIdParameter = (originalLoginId.HasValue) ? new SqlParameter("Original_LoginID", originalLoginId) : new SqlParameter("Original_LoginID", DBNull.Value);
            SqlParameter originalContactsIdParameter = (originalContactsId.HasValue) ? new SqlParameter("Original_ContactsID", originalContactsId) : new SqlParameter("Original_ContactsID", DBNull.Value);
            SqlParameter originalFullNameParameter = (originalFullName.Trim() != "") ? new SqlParameter("Original_FullName", originalFullName.Trim()) : new SqlParameter("Original_FullName", DBNull.Value);
            SqlParameter originalFirstNameParameter = (originalFirstName.Trim() != "") ? new SqlParameter("Original_FirstName", originalFirstName.Trim()) : new SqlParameter("Original_FirstName", DBNull.Value);
            SqlParameter originalMiddleInitialParameter = (originalMiddleInitial.Trim() != "") ? new SqlParameter("MiddleInitial", originalMiddleInitial.Trim()) : new SqlParameter("Original_MiddleInitial", DBNull.Value);
            SqlParameter originalLastNameParameter = (originalLastName.Trim() != "") ? new SqlParameter("Original_LastName", originalLastName.Trim()) : new SqlParameter("Original_LastName", DBNull.Value);
            SqlParameter originalTypeParameter = (originalType.Trim() != "") ? new SqlParameter("Original_Type", originalType.Trim()) : new SqlParameter("Original_Type", DBNull.Value);
            SqlParameter originalStateParameter = (originalState.Trim() != "") ? new SqlParameter("Original_State", originalState.Trim()) : new SqlParameter("Original_State", DBNull.Value);
            SqlParameter originalIsSalesmanParameter = new SqlParameter("Original_IsSalesman", originalIsSalesman);
            SqlParameter originalRequestProjectTimeParameter = new SqlParameter("Original_RequestProjectTime", originalRequestProjectTime);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalSalariedParameter = new SqlParameter("Original_Salaried", originalSalaried);
            SqlParameter originalEMailParameter = (originalEMail.Trim() != "") ? new SqlParameter("Original_eMail", originalEMail.Trim()) : new SqlParameter("Original_eMail", DBNull.Value);
            SqlParameter originalAssignableSrsParameter = new SqlParameter("Original_AssignableSRS", originalAssignableSrs);
            SqlParameter originalJobClassTypeParameter = (originalJobClassType.Trim() != "") ? new SqlParameter("Original_JobClassType", originalJobClassType.Trim()) : new SqlParameter("Original_JobClassType", DBNull.Value);
            SqlParameter originalCategoryParameter = new SqlParameter("Original_Category", originalCategory);
            SqlParameter originalPersonalAgencyNameParameter = (originalPersonalAgencyName.Trim() != "") ? new SqlParameter("Original_PersonalAgencyName", originalPersonalAgencyName.Trim()) : new SqlParameter("Original_PersonalAgencyName", DBNull.Value);
            SqlParameter originalIsVacationsManagerParameter = new SqlParameter("Original_IsVacationsManager", originalIsVacationsManager);
            SqlParameter originalApproveTimesheetsParameter = new SqlParameter("Original_ApproveTimesheets", originalApproveTimesheets);
            SqlParameter originalBourdenFactorParameter = (originalBourdenFactor.HasValue) ? new SqlParameter("Original_BourdenFactor", (decimal)originalBourdenFactor) : new SqlParameter("Original_BourdenFactor", DBNull.Value);
            SqlParameter originalUsHealthBenefitFactorParameter = (originalUsHealthBenefitFactor.HasValue) ? new SqlParameter("Original_USHealthBenefitFactor", (decimal)originalUsHealthBenefitFactor) : new SqlParameter("Original_USHealthBenefitFactor", DBNull.Value);
            SqlParameter originalBenefitFactorCadParameter = (originalBenefitFactorCad.HasValue) ? new SqlParameter("Original_BenefitFactorCad", (decimal)originalBenefitFactorCad) : new SqlParameter("Original_BenefitFactorCad", DBNull.Value);
            originalBenefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalBenefitFactorUsdParameter = (originalBenefitFactorUsd.HasValue) ? new SqlParameter("Original_BenefitFactorUsd", (decimal)originalBenefitFactorUsd) : new SqlParameter("Original_BenefitFactorUsd", DBNull.Value);
            originalBenefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalCrewParameter = (originalCrew.Trim() != "") ? new SqlParameter("Original_Crew", originalCrew.Trim()) : new SqlParameter("Original_Crew", DBNull.Value);
            
            SqlParameter newLoginIdParameter = (originalLoginId.HasValue) ? new SqlParameter("LoginID", originalLoginId) : new SqlParameter("LoginID", DBNull.Value);
            SqlParameter newContactsIdParameter = (originalContactsId.HasValue) ? new SqlParameter("ContactsID", originalContactsId) : new SqlParameter("ContactsID", DBNull.Value);
            SqlParameter newFullNameParameter = (newFullName.Trim() != "") ? new SqlParameter("FullName", newFullName.Trim()) : new SqlParameter("FullName", DBNull.Value);
            SqlParameter newFirstNameParameter = (newFirstName.Trim() != "") ? new SqlParameter("FirstName", newFirstName.Trim()) : new SqlParameter("FirstName", DBNull.Value);
            SqlParameter newMiddleInitialParameter = (newMiddleInitial.Trim() != "") ? new SqlParameter("MiddleInitial", newMiddleInitial.Trim()) : new SqlParameter("MiddleInitial", DBNull.Value);
            SqlParameter newLastNameParameter = (newLastName.Trim() != "") ? new SqlParameter("LastName", newLastName.Trim()) : new SqlParameter("LastName", DBNull.Value);
            SqlParameter newTypeParameter = (newType.Trim() != "") ? new SqlParameter("Type", newType.Trim()) : new SqlParameter("Type", DBNull.Value);
            SqlParameter newStateParameter = (newState.Trim() != "") ? new SqlParameter("State", newState.Trim()) : new SqlParameter("State", DBNull.Value);
            SqlParameter newIsSalesmanParameter = new SqlParameter("IsSalesman", newIsSalesman);
            SqlParameter newRequestProjectTimeParameter = new SqlParameter("RequestProjectTime", newRequestProjectTime);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newSalariedParameter = new SqlParameter("Salaried", newSalaried);
            SqlParameter newEMailParameter = (newEMail.Trim() != "") ? new SqlParameter("eMail", newEMail.Trim()) : new SqlParameter("eMail", DBNull.Value);
            SqlParameter newAssignableSrsParameter = new SqlParameter("AssignableSRS", newAssignableSrs);
            SqlParameter newJobClassTypeParameter = (newJobClassType.Trim() != "") ? new SqlParameter("JobClassType", newJobClassType.Trim()) : new SqlParameter("JobClassType", DBNull.Value);
            SqlParameter newCategoryParameter = new SqlParameter("Category", newCategory);
            SqlParameter newPersonalAgencyNameParameter = (newPersonalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", newPersonalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            SqlParameter newIsVacationsManagerParameter = new SqlParameter("IsVacationsManager", newIsVacationsManager);
            SqlParameter newApproveTimesheetsParameter = new SqlParameter("ApproveTimesheets", newApproveTimesheets);
            SqlParameter newBourdenFactorParameter = (newBourdenFactor.HasValue) ? new SqlParameter("BourdenFactor", (decimal)newBourdenFactor) : new SqlParameter("BourdenFactor", DBNull.Value);
            SqlParameter newUsHealthBenefitFactorParameter = (newUsHealthBenefitFactor.HasValue) ? new SqlParameter("USHealthBenefitFactor", (decimal)newUsHealthBenefitFactor) : new SqlParameter("USHealthBenefitFactor", DBNull.Value);
            SqlParameter newBenefitFactorCadParameter = (newBenefitFactorCad.HasValue) ? new SqlParameter("BenefitFactorCad", (decimal)newBenefitFactorCad) : new SqlParameter("BenefitFactorCad", DBNull.Value);
            newBenefitFactorCadParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newBenefitFactorUsdParameter = (newBenefitFactorUsd.HasValue) ? new SqlParameter("BenefitFactorUsd", (decimal)newBenefitFactorUsd) : new SqlParameter("BenefitFactorUsd", DBNull.Value);
            newBenefitFactorUsdParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newCrewParameter = (newCrew.Trim() != "") ? new SqlParameter("Crew", newCrew.Trim()) : new SqlParameter("Crew", DBNull.Value);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE] SET [LoginID] = @LoginID, [ContactsID] = @C" +
                "ontactsID, [FullName] = @FullName, [FirstName] = @FirstName, [MiddleInitial] = @" +
                "MiddleInitial, [LastName] = @LastName, [Type] = @Type, [State] = @State, [IsSale" +
                "sman] = @IsSalesman, [RequestProjectTime] = @RequestProjectTime, [Deleted] = @De" +
                "leted, [Salaried] = @Salaried, [eMail] = @eMail, [AssignableSRS] = @AssignableSR" +
                "S, [JobClassType] = @JobClassType, [Category] = @Category, [PersonalAgencyName] " +
                "= @PersonalAgencyName, [IsVacationsManager] = @IsVacationsManager, [ApproveTimes" +
                "heets] = @ApproveTimesheets, [BourdenFactor] = @BourdenFactor, [USHealthBenefitF" +
                "actor] = @USHealthBenefitFactor, [BenefitFactorCad] = @BenefitFactorCad, [Benefi" +
                "tFactorUsd] = @BenefitFactorUsd , [Crew] = @Crew" +
                " WHERE ([EmployeeID] = @Original_EmployeeID)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalEmployeeIdParameter, originalLoginIdParameter, originalContactsIdParameter, originalFullNameParameter, originalFirstNameParameter, originalMiddleInitialParameter, originalLastNameParameter, originalTypeParameter, originalStateParameter, originalIsSalesmanParameter, originalRequestProjectTimeParameter, originalDeletedParameter, originalSalariedParameter, originalEMailParameter, originalAssignableSrsParameter, originalJobClassTypeParameter, originalCategoryParameter, originalPersonalAgencyNameParameter, originalIsVacationsManagerParameter, originalApproveTimesheetsParameter, originalBourdenFactorParameter, originalUsHealthBenefitFactorParameter, originalBenefitFactorCadParameter, originalBenefitFactorUsdParameter, originalCrewParameter, newLoginIdParameter, newContactsIdParameter, newFullNameParameter, newFirstNameParameter, newMiddleInitialParameter, newLastNameParameter, newTypeParameter, newStateParameter, newIsSalesmanParameter, newRequestProjectTimeParameter, newDeletedParameter, newSalariedParameter, newEMailParameter, newAssignableSrsParameter, newJobClassTypeParameter, newCategoryParameter, newPersonalAgencyNameParameter, newIsVacationsManagerParameter, newApproveTimesheetsParameter, newBourdenFactorParameter, newUsHealthBenefitFactorParameter, newBenefitFactorCadParameter, newBenefitFactorUsdParameter, newCrewParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete a employee (direct to DB)
        /// </summary>
        /// <param name="originalEmployeeId">originalEmployeeId</param>
        /// <returns>int</returns>
        public int Delete(int originalEmployeeId)
        {
            SqlParameter originalEmployeeIdParameter = new SqlParameter("@Original_EmployeeID", originalEmployeeId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE] SET  [Deleted] = @Deleted  " +
                             " WHERE ([EmployeeID] = @Original_EmployeeID)  ";

            int rowsAffected = (int)ExecuteNonQuery(command, originalEmployeeIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// UpdatePersonalAgencyName
        /// </summary>
        /// <param name="originalPersonalAgencyName">originalPersonalAgencyName</param>
        /// 
        /// <param name="newPersonalAgencyName">newPersonalAgencyName</param>
        /// <returns>rowsAffected</returns>
        public int UpdatePersonalAgencyName(string originalPersonalAgencyName, string newPersonalAgencyName)
        {
            SqlParameter originalPersonalAgencyNameParameter = (originalPersonalAgencyName.Trim() != "") ? new SqlParameter("Original_PersonalAgencyName", originalPersonalAgencyName.Trim()) : new SqlParameter("Original_PersonalAgencyName", DBNull.Value);
            
            SqlParameter newPersonalAgencyNameParameter = (newPersonalAgencyName.Trim() != "") ? new SqlParameter("PersonalAgencyName", newPersonalAgencyName.Trim()) : new SqlParameter("PersonalAgencyName", DBNull.Value);
            
            string command = "UPDATE [dbo].[LFS_RESOURCES_EMPLOYEE] SET [PersonalAgencyName] = @PersonalAgencyName " +
                " WHERE ([PersonalAgencyName] = @Original_PersonalAgencyName)";

            int rowsAffected = (int)ExecuteNonQuery(command, originalPersonalAgencyNameParameter, newPersonalAgencyNameParameter);

            return rowsAffected;
        }



    }
}