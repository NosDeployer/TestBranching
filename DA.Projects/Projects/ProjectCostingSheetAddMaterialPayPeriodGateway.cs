using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddMaterialPayPeriodGateway
    /// </summary>
    public class ProjectCostingSheetAddMaterialPayPeriodGateway : DataTableGateway
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddMaterialPayPeriodGateway()
            : base("MaterialPayPeriod")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddMaterialPayPeriodGateway(DataSet data)
            : base(data, "MaterialPayPeriod")
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
            tableMapping.DataSetTable = "MaterialPayPeriod";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
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
        /// LoadByStartDateEndDateMaterialId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateMaterialId(DateTime startDate, DateTime endDate, int materialId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALPAYPERIODGATEWAY_LOADBYSTARTDATEENDATEMATERIALID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@materialId", materialId));
            return Data;
        }



        /// <summary>
        /// Get a single row
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int materialId)
        {
            string filter = string.Format("MaterialID = {0}", materialId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddMaterialPayPeriod.GetRow");
            }
        }



    }
}