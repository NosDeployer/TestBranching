using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation
{
    /// <summary>
    /// MrNavigatorGateway
    /// </summary>
    public class MrNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MrNavigatorGateway()
            : base("MrNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MrNavigatorGateway(DataSet data)
            : base(data, "MrNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MrNavigatorTDS();
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
            tableMapping.DataSetTable = "MrNavigator";
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("MHID", "MHID");
            tableMapping.ColumnMappings.Add("Latitude", "Latitude");
            tableMapping.ColumnMappings.Add("Longitude", "Longitude");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("ManholeShape", "ManholeShape");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MaterialID", "MaterialID");
            tableMapping.ColumnMappings.Add("TotalDepth", "TotalDepth");
            tableMapping.ColumnMappings.Add("TotalSurfaceArea", "TotalSurfaceArea");
            tableMapping.ColumnMappings.Add("ConditionRating", "ConditionRating");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("PreppedDate", "PreppedDate");
            tableMapping.ColumnMappings.Add("SprayedDate", "SprayedDate");
            tableMapping.ColumnMappings.Add("BatchID", "BatchID");
            tableMapping.ColumnMappings.Add("BatchDate", "BatchDate");
            tableMapping.ColumnMappings.Add("BatchDescription", "BatchDescription");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
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
        /// <param name="conditionValue1">conditionValue1</param> 
        /// <param name="conditionValue2">conditionValue2</param>
        /// <param name="textForSearch1">textForSearch1</param>
        /// <param name="textForSearch2">textForSearch2</param>
        /// <param name="inProject">inProject</param>
        /// <param name="projectId">projectId</param>
        /// <param name="workType">workType</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue1, string conditionValue2, string textForSearch1, string textForSearch2, bool inProject, int projectId, string workType)
        {
            string whereClauseSpecial = "";
            
            // For manholes in projects
            string inProjectSQL = "";
            //if (inProject)
            //{
            //    inProjectSQL = " AND (AASMH.AssetID in (SELECT DISTINCT AASMH2.AssetID FROM AM_ASSET_SEWER_MH_PROJECT AASMHP INNER JOIN AM_ASSET_SEWER_MH AASMH2 ON AASMHP.AssetID = AASMH2.AssetID " +
            //    "                         WHERE AASMHP.ProjectID = " + projectId +
            //    "                          ) )";
                           
            //}         

            // Command
            string commandText = String.Format("SELECT AASMH.AssetID, AASMH.MHID, AASMH.Latitud AS Latitude, AASMH.Longitude, AASMH.Address, AASMH.Deleted, " +
                     "  AASMH.COMPANY_ID, AASMH.ManholeShape,  AASMH.Location, AASMH.MaterialID, AASMH.TotalDepth, " +
                     "  AASMH.TotalSurfaceArea, LASMH.ConditionRating, " +
                     "  LW.ProjectID, LW.WorkID,  LWMR.PreppedDate, LWMR.SprayedDate, LWMR.BatchID, " +
                     "  LWMRB.Date AS BatchDate, LWMRB.Description AS BatchDescription, LW.Comments, " +
                     "  CAST(0 AS bit) AS Selected  "+
                    

                     " FROM         AM_ASSET AA INNER JOIN " +
                     "      AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                     "      AM_ASSET_SEWER_MH  AASMH ON AAS.AssetID = AASMH.AssetID INNER JOIN " +
                     "      LFS_ASSET_SEWER_MH LASMH ON AA.AssetID = LASMH.AssetID LEFT OUTER  JOIN " +
                     "      LFS_WORK AS LW ON AA.AssetID = LW.AssetID AND LW.ProjectID = {4} AND LW.Deleted = 0 LEFT OUTER JOIN " +
                     "      LFS_WORK_MANHOLE_REHABILITATION AS LWMR ON LW.WorkID = LWMR.WorkID AND LWMR.Deleted = 0 LEFT OUTER JOIN "+
                     "      LFS_WORK_MANHOLE_REHABILITATION_BATCH AS LWMRB ON LWMR.BatchID = LWMRB.BatchID INNER JOIN "+
                     "     AM_ASSET_SEWER_MH_PROJECT AASMHP ON AASMH.AssetID = AASMHP.AssetID "+

                      " WHERE {0} {1} {2} ORDER BY {3}", where, inProjectSQL, whereClauseSpecial, orderBy, projectId);

            FillData(commandText);
        }



        /// <summary>
        /// LoadForViewsProjectIdCompanyIdWorkType
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        public void LoadForViewsProjectIdCompanyIdWorkType(string sqlCommand, int projectId, int companyId, string workType)
        {
            string commandText = String.Format(sqlCommand, companyId, projectId, workType);

            FillData(commandText);
        }



    }
}