using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Resources.Subcontractors
{
    /// <summary>
    /// SubcontractorsSetupSubcontractorsSetupGateway 
    /// </summary>
    public class SubcontractorsSetupSubcontractorsSetupGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorsSetupSubcontractorsSetupGateway()
            : base("SubcontractorsSetup")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorsSetupSubcontractorsSetupGateway(DataSet data)
            : base(data, "SubcontractorsSetup")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorsSetupTDS();
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
            tableMapping.DataSetTable = "SubcontractorsSetup";
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Date", "Date");            
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Active", "Active");
            tableMapping.ColumnMappings.Add("Udf", "Udf");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DateString", "DateString");
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
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_SUBCONTRACTORSMANAGERSUBCONTRACTORSMANAGERGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// IsUsedInSubcontractorCosts
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInSubcontractorCosts(int companiesId, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_LABOUR_HOURS_ACTUAL_COSTS_SUBCONTRACTOR_COSTS WHERE (SubcontractorID = @companiesId) AND (COMPANY_ID = @companyId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@companiesId", companiesId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(int companiesId, DateTime date)
        {
            string filter = string.Format("COMPANIES_ID = {0} AND DateString = '{1}'", companiesId, date.ToString());

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }

            throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Subcontractors.SubcontractorsSetupSubcontractorsSetupGateway.GetRow");
        }
        


        /// <summary>
        /// GetUdf
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>      
        /// <returns>Udf</returns>
        public bool GetUdf(int companiesId, DateTime date)
        {
            return (bool)GetRow(companiesId, date)["Udf"];
        }



        /// <summary>
        /// GetUdf Original
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>      
        /// <returns>Original Udf</returns>
        public bool GetUdfOriginal(int companiesId, DateTime date)
        {
            return (bool)GetRow(companiesId, date)["Udf", DataRowVersion.Original];            
        }



        /// <summary>
        /// GetActive
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>      
        /// <returns>Active</returns>
        public bool GetActive(int companiesId, DateTime date)
        {
            return (bool)GetRow(companiesId, date)["Active"];
        }



        /// <summary>
        /// GetActive Original
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>      
        /// <returns>Original Active</returns>
        public bool GetActiveOriginal(int companiesId, DateTime date)
        {
            return (bool)GetRow(companiesId, date)["Active", DataRowVersion.Original];
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="companiesId">companiesId</param>
        /// <param name="date">date</param>      
        /// <returns>Name or EMPTY</returns>
        public string GetName(int companiesId, DateTime date)
        {
            if (GetRow(companiesId, date).IsNull("Name"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(companiesId, date)["Name"];
            }
        }



    }
}