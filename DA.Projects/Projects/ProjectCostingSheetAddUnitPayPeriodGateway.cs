using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddUnitPayPeriodGateway
    /// </summary>
    public class ProjectCostingSheetAddUnitPayPeriodGateway : DataTableGateway
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddUnitPayPeriodGateway()
            : base("UnitPayPeriod")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddUnitPayPeriodGateway(DataSet data)
            : base(data, "UnitPayPeriod")
        {
        }



        /// <summary>
        /// InitData. Create a ProjectCostingSheetAddTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
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
            tableMapping.DataSetTable = "UnitPayPeriod";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
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
        /// LoadByStartDateEndDateUnitId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateUnitId(DateTime startDate, DateTime endDate, int unitId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITPAYPERIODGATEWAY_LOADBYSTARTDATEENDATEUNITID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@unitId", unitId));
            return Data;
        }



        /// <summary>
        /// Get a single row
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId)
        {
            string filter = string.Format("UnitID = {0}", unitId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddUnitPayPeriod.GetRow");
            }
        }



    }
}