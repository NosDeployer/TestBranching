using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetAddUnitListGateway
    /// </summary>
    public class ProjectCostingSheetAddUnitListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectCostingSheetAddUnitListGateway()
            : base("UnitList")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectCostingSheetAddUnitListGateway(DataSet data)
            : base(data, "UnitList")
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
            tableMapping.DataSetTable = "UnitList";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("UnitOfMeasurement", "UnitOfMeasurement");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("Description", "Description");
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
        /// GetCostCad. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>CostCad</returns>
        public decimal? GetCostCad(int unitId)
        {
            if (GetRow(unitId).IsNull("CostCad"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(unitId)["CostCad"];
            }
        }



        /// <summary>
        /// GetCostUsd. If not exists, raise an exception.
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>CostUsd</returns>
        public decimal? GetCostUsd(int unitId)
        {
            if (GetRow(unitId).IsNull("CostUsd"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(unitId)["CostUsd"];
            }
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByProjectIdStartDateEndDateWork
        /// </summary>
        /// <returns>Data</returns>
        /// <param name="projectId"></param>
        /// <param name="startDate"></param>
        /// <param name="work"></param>
        /// <param name="endDate"></param>
        /// <param name="companyId"></param>
        public DataSet LoadByProjectIdStartDateEndDateWork(int projectId, DateTime startDate, DateTime endDate, string work, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYPROJECTIDSTARTDATEENDDATEWORK", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@work", work), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByProjectIdStartDateEndDateWorkFunction
        /// </summary>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdStartDateEndDateWorkFunction(int projectId, DateTime startDate, DateTime endDate, string work, string function, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYPROJECTIDSTARTDATEENDDATEWORKFUNCTION", new SqlParameter("@projectId", projectId), new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@work", work), new SqlParameter("@function", function), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Data</returns>
        public DataSet LoadByUnitId(int unitId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateUnitId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateUnitId(DateTime startDate, DateTime endDate, int unitId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYSTARTDATEENDATEUNITID", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@unitId", unitId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateUnitId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateUnitId(DateTime startDate, int unitId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYSTARTDATEUNITID", new SqlParameter("@startDate", startDate), new SqlParameter("@unitId", unitId));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateEndDateUnitIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateEndDateUnitIdWork_(DateTime startDate, DateTime endDate, int unitId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYSTARTDATEENDATEUNITIDWORK_", new SqlParameter("@startDate", startDate), new SqlParameter("@endDate", endDate), new SqlParameter("@unitId", unitId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByStartDateUnitIdWork_
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="work_">work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByStartDateUnitIdWork_(DateTime startDate, int unitId, string work_)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGSHEETADDUNITLISTGATEWAY_LOADBYSTARTDATEUNITIDWORK_", new SqlParameter("@startDate", startDate), new SqlParameter("@unitId", unitId), new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// Get a single unit
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingSheetAddUnitListGateway.GetRow");
            }
        }



    }
}