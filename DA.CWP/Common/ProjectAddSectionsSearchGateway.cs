using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsSearchGateway
    /// </summary>
    public class ProjectAddSectionsSearchGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public ProjectAddSectionsSearchGateway() : base("ProjectAddSectionsSearch")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProjectAddSectionsSearchGateway(DataSet data) : base(data, "ProjectAddSectionsSearch")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectAddSectionsTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "ProjectAddSectionsSearch";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("RehabAssessmentWork", "RehabAssessmentWork");
            tableMapping.ColumnMappings.Add("FulllengthLiningWork", "FulllengthLiningWork");
            tableMapping.ColumnMappings.Add("JunctionLiningWork", "JunctionLiningWork");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("RehabAssessmentPrevWork", "RehabAssessmentPrevWork");
            tableMapping.ColumnMappings.Add("FullLengthLiningPrevWork", "FullLengthLiningPrevWork");
            tableMapping.ColumnMappings.Add("JunctionLiningPrevWork", "JunctionLiningPrevWork");

            tableMapping.ColumnMappings.Add("PointRepairsWork", "PointRepairsWork");
            tableMapping.ColumnMappings.Add("PointRepairsPrevWork", "PointRepairsPrevWork");

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
        public void LoadWhereOrderBy(string where, string orderBy)
        {
            string commandText = String.Format("SELECT DISTINCT AssetID, SectionID, Street, USMH, DSMH, "+
                " 0 AS RehabAssessMentWork, 0 AS FullLengthLiningWork, 0 AS JunctionLiningWork, 0 AS Selected, "+
                " 0 AS Deleted, FlowOrderID, MapSize, MapLength, 0 AS RehabAssessmentPrevWork, 0 AS  FullLengthLiningPrevWork, 0 AS JunctionLiningPrevWork, "+
                " 0 AS PointRepairsWork, 0 AS PointRepairsPrevWork " +
                " FROM LFS_CWP_COMMON_PROJECTADDSECTIONSSEARCH_VIEW "+
                " WHERE {0} ORDER BY {1}", where, orderBy);
            FillData(commandText);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //
        
        /// <summary>
        /// ExistsRehabAssessmentWork
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsRehabAssessmentWork(int projectId, int assetId, int companyId)
        {
            string workType = "Rehab Assessment";

            // Verify previous work
            string commandText = String.Format("SELECT COUNT(*) AS NO "+
                                               " FROM  LFS_WORK LW "+
                                               " WHERE (AssetID = {1}) AND (WorkType LIKE '{2}') "+
                                               " AND (ProjectID <> {0} AND (COMPANY_ID = {3}))", projectId, assetId, workType, companyId);

            int  count = (int)ExecuteScalar(commandText);                       

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsFullLengthLiningWork
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsFullLengthLiningWork(int projectId, int assetId,  int companyId)
        {
            string workType = "Full Length Lining";

            // Verify previous work
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                                               " FROM  LFS_WORK LW " +
                                               " WHERE (AssetID = {1}) AND (WorkType LIKE '{2}') " +
                                               " AND (ProjectID <> {0} AND (COMPANY_ID = {3}))", projectId, assetId, workType, companyId);

            int count = (int)ExecuteScalar(commandText);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsPointRepairsWork
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsPointRepairsWork(int projectId, int assetId, int companyId)
        {
            string workType = "Point Repairs";

            // Verify previous work
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                                               " FROM  LFS_WORK LW " +
                                               " WHERE (AssetID = {1}) AND (WorkType LIKE '{2}') " +
                                               " AND (ProjectID <> {0} AND (COMPANY_ID = {3}))", projectId, assetId, workType, companyId);

            int count = (int)ExecuteScalar(commandText);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsJunctionLiningWork
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsJunctionLiningWork(int projectId, int assetId,  int companyId)
        {
            string workType = "Junction Lining Section";

            // Verify previous work
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                                               " FROM  LFS_WORK LW " +
                                               " WHERE (AssetID = {1}) AND (WorkType LIKE '{2}') " +
                                               " AND (ProjectID <> {0} AND (COMPANY_ID = {3}))", projectId, assetId, workType, companyId);

            int count = (int)ExecuteScalar(commandText);
            
            return (count > 0) ? true : false;
        }



    }
}