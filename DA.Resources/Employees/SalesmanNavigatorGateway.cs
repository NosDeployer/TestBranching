using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// SalesmanNavigatorGateway
    /// </summary>
    public class SalesmanNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SalesmanNavigatorGateway()
            : base("SalesmanNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SalesmanNavigatorGateway(DataSet data)
            : base(data, "SalesmanNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeNavigatorTDS();
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
            tableMapping.DataSetTable = "SalesmanNavigator";
            tableMapping.ColumnMappings.Add("SalesmanID", "SalesmanID");
            tableMapping.ColumnMappings.Add("IdForProjects", "IdForProjects");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
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
        /// LoadBySalesmanId
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>Data</returns>
        public DataSet LoadBySalesmanId(int salesmanId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_SALESMANNAVIGATORGATEWAY_LOADBYSALESMANID", new SqlParameter("@salesmanId", salesmanId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int salesmanId)
        {
            string filter = string.Format("SalesmanID = {0}", salesmanId);
            return Table.Select(filter)[0];
        }



        /// <summary>
        /// GetIdForProjects
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>IdForProjects</returns>
        public string GetIdForProjects(int salesmanId)
        {
            if (GetRow(salesmanId).IsNull("IdForProjects"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(salesmanId)["IdForProjects"];
            }
        }



        /// <summary>
        /// GetIdForProjects Original
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns>Original IdForProjects or EMPTY</returns>
        public string GetIdForProjectsOriginal(int salesmanId)
        {
            if (GetRow(salesmanId).IsNull(Table.Columns["IdForProjects"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(salesmanId)["IdForProjects", DataRowVersion.Original];
            }
        }

    }
}
