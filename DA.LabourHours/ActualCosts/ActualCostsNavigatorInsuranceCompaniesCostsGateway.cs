using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts    
{
    /// <summary>
    /// ActualCostsNavigatorInsuranceCompaniesCostsGateway
    /// </summary>
    public class ActualCostsNavigatorInsuranceCompaniesCostsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsNavigatorInsuranceCompaniesCostsGateway()
            : base("InsuranceCompaniesCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsNavigatorInsuranceCompaniesCostsGateway(DataSet data)
            : base(data, "InsuranceCompaniesCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsNavigatorTDS();
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

            tableMapping.DataSetTable = "InsuranceCompaniesCosts";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("InsuranceCompanyID", "InsuranceCompanyID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("InsuranceCompany", "InsuranceCompany");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            this._adapter.TableMappings.Add(tableMapping);

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
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        public void LoadWhereOrderBy(string whereClause, string orderBy)
        {
            string commandText = "";
            commandText = String.Format("SELECT ICC.ProjectID, ICC.RefID,ICC.InsuranceCompanyID, ICC.Date, IC.Name AS InsuranceCompany, C.Name AS Client, P.Name AS Project, ICC.RateCad, ICC.RateUsd, ICC.Comment, 0 AS Deleted, ICC.COMPANY_ID, 0 AS Selected " +
                                        " FROM LFS_LABOUR_HOURS_ACTUAL_COSTS_INSURANCE_COSTS ICC INNER JOIN " +
                                        " LFS_RESOURCES_INSURANCE_COMPANIES IC ON ICC.InsuranceCompanyID = IC.COMPANIES_ID INNER JOIN " +
                                        " LFS_PROJECT P ON ICC.ProjectID = P.ProjectID INNER JOIN " +
                                        " LFS_RESOURCES_COMPANIES C ON P.ClientID = C.COMPANIES_ID  " +
                                        " WHERE {0} ORDER BY {1}", whereClause, orderBy);
            FillData(commandText);
        }



    }
}