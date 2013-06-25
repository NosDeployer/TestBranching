using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// CommentsMigrationGateway
    /// </summary>
    public class CommentsMigrationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public CommentsMigrationGateway()
            : base("CommentsMigration")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public CommentsMigrationGateway(DataSet data)
            : base(data, "CommentsMigration")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new CommentsMigrationTDS();
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
            tableMapping.DataSetTable = "CommentsMigration";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("RehabAssessmentPrevWork", "RehabAssessmentPrevWork");
            tableMapping.ColumnMappings.Add("FullLengthLiningPrevWork", "FullLengthLiningPrevWork");
            tableMapping.ColumnMappings.Add("JunctionLiningPrevWork", "JunctionLiningPrevWork");
            tableMapping.ColumnMappings.Add("PointRepairsPrevWork", "PointRepairsPrevWork");
            tableMapping.ColumnMappings.Add("MigrateComments", "MigrateComments");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
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
        public void LoadByProjectId(int projectId, int companyId)
        {
            string where = "(AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND (AAS.AssetSewerType = 'Section') AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ")";

            string whereClauseProject = "AND (AA.AssetID IN (SELECT DISTINCT LW.AssetID " +
                                 "  FROM   LFS_WORK LW " +
                                 "  WHERE  (LW.ProjectID = " + projectId + ") AND (LW.COMPANY_ID = " + companyId + ") AND (LW.Deleted = 0)))";

            string commandText = String.Format("SELECT DISTINCT AA.AssetID, AASS.SectionID, " +
                                                " 0 AS RehabAssessmentPrevWork, 0 AS  FullLengthLiningPrevWork, 0 AS JunctionLiningPrevWork, " +
                                                " 0 AS PointRepairsWork, 0 AS PointRepairsPrevWork, " +
                                                "  CAST (0 AS bit) AS MigrateComments, AASS.FlowOrderID " +
                                                " FROM AM_ASSET_SEWER_SECTION AASS INNER JOIN " +
                                                "       AM_ASSET AA ON AA.AssetID = AASS.AssetID INNER JOIN " +
                                                "       AM_ASSET_SEWER AAS ON AASS.AssetID = AAS.AssetID " +
                                                " WHERE {0} {1} ORDER BY AASS.SectionID", where, whereClauseProject);
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
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                                               " FROM  LFS_WORK LW " +
                                               " WHERE (AssetID = {1}) AND (WorkType LIKE '{2}') " +
                                               " AND (ProjectID <> {0} AND (COMPANY_ID = {3}))", projectId, assetId, workType, companyId);

            int count = (int)ExecuteScalar(commandText);

            return (count > 0) ? true : false;
        }



        /// <summary>
        /// ExistsFullLengthLiningWork
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public bool ExistsFullLengthLiningWork(int projectId, int assetId, int companyId)
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
        public bool ExistsJunctionLiningWork(int projectId, int assetId, int companyId)
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



        /// <summary>
        /// ExistsProjectIdAssetIdWorkTypeCompanyId
        /// </summary>
        /// <param name="assetId">AssetId</param>
        /// <param name="currentProjectId">currentProjectId filter</param>
        /// <param name="workType">WorkType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>boolean</returns>
        public Boolean ExistsProjectIdAssetIdWorkTypeCompanyId(int currentProjectId, int assetId, int companyId, string workType)
        {
            FillDataWithStoredProcedure("LFS_CWP_WORKGATEWAY_LOADBYPROJECTIDASSETIDWORKTYPECOMPANYID", new SqlParameter("@assetId", assetId), new SqlParameter("@projectId", currentProjectId), new SqlParameter("@workType", workType), new SqlParameter("@companyId", companyId));//COMPANY_ID
            if ((int)Table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}