using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsByProcessReportGateway
    /// </summary>
    public class MaterialsByProcessReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsByProcessReportGateway()
            : base("MaterialsByProcessReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public MaterialsByProcessReportGateway(DataSet data)
            : base(data, "MaterialsByProcessReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsByProcessReportTDS();
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
            tableMapping.DataSetTable = "MaterialsByProcessReport";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
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
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSBYPROCESSREPORTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByProcess
        /// </summary>
        /// <param name="process">process</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProcess(string process, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSBYPROCESSREPORTGATEWAY_LOADBYPROCESS", new SqlParameter("@process", process), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}