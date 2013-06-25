using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddMaterialListGateway
    /// </summary>
    public class ProjectCostingSheetAddMaterialListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddMaterialListGateway()
            : base("MaterialList")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddMaterialListGateway(DataSet data)
            : base(data, "MaterialList")
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
            tableMapping.DataSetTable = "MaterialList";
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Size", "Size");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
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
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByWork_
        /// </summary>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByWork_(string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOADBYWORK_", new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByMaterialId
        /// </summary>
        /// <param name="materialId">materialId</param>
        /// <returns>Data</returns>
        public DataSet LoadByMaterialId(int materialId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOADBYMATERIALID", new SqlParameter("@materialId", materialId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateMaterialId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateMaterialId(DateTime startDate, int materialId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOADBYSTARTDATEMATERIALID", new SqlParameter("@startDate", startDate), new SqlParameter("@materialId", materialId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateMaterialId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="materialId">materialId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateMaterialId(DateTime startDate, DateTime endDate, int materialId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOADBYSTARTDATEENDATEMATERIALID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@materialId", materialId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateMaterialIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="materialId">materialId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateMaterialIdWork_(DateTime startDate, int materialId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOADBYSTARTDATEMATERIALIDWORK_", new SqlParameter("@startDate", startDate), new SqlParameter("@materialId", materialId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateMaterialIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="materialId">materialId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateMaterialIdWork_(DateTime startDate, DateTime endDate, int materialId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDMATERIALLISTGATEWAY_LOADBYSTARTDATEENDATEMATERIALIDWORK_", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@materialId", materialId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// Get a single material
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddMaterialListGateway.GetRow");
            }
        }



    }
}