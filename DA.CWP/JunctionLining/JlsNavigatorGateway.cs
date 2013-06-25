using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JlsNavigatorGateway
    /// </summary>
    public class JlsNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlsNavigatorGateway() : base("JlsNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlsNavigatorGateway(DataSet data) : base(data, "JlsNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlsNavigatorTDS();
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
            tableMapping.DataSetTable = "JlsNavigator";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("USMHID", "USMHID");
            tableMapping.ColumnMappings.Add("DSMHID", "DSMHID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("OriginalSectionID", "OriginalSectionID");
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
            where = where + " AND " +
                   "        (AASS.AssetID NOT IN " +
                   "            ( " +
                   "                SELECT AASS2.AssetID " +
                   "                FROM AM_ASSET_SEWER_SECTION AASS2 INNER JOIN" +
                   "                LFS_WORK LW2 ON LW2.AssetID = AASS2.AssetID AND LW2.Deleted = 0 AND LW2.WorkType = 'Full Length Lining' INNER JOIN" +
                   "                LFS_WORK_FULLLENGTHLINING LWFLL ON LW2.WorkID = LWFLL.WorkID INNER JOIN " +
                   "                LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LWFLP1.WorkID = LW2.WorkID " +
                   "                WHERE (AASS2.AssetID = AASS.AssetID)  " +
                   "                AND (LWFLP1.RoboticPrepCompleted = 1) AND (LWFLP1.RoboticPrepCompletedDate is null) AND (LW2.Deleted = 0)" +
                   "            )" +
                   "        )";

            string commandText = String.Format("SELECT LW.WorkID, LW.AssetID, AASS.SectionID, LASS.SubArea, AASS.Street, AASS.USMH, AASUSMH.MHID AS USMHID, AASS.DSMH, AASDSMH.MHID AS DSMHID, CAST(0 AS BIT) AS Selected, AASS.FlowOrderID, LMS.OriginalSectionID " +
                                               " FROM AM_ASSET_SEWER_SECTION AASS " +
                                               "        INNER JOIN LFS_ASSET_SEWER_SECTION LASS ON AASS.AssetID = LASS.AssetID " +
                                               "        INNER JOIN LFS_WORK LW ON AASS.AssetID = LW.AssetID " +
                                               "        INNER JOIN LFS_WORK_JUNCTIONLINING_SECTION LWJLS ON LW.WorkID = LWJLS.WorkID " +
                                               "        LEFT JOIN AM_ASSET_SEWER_MH AASUSMH ON AASS.USMH = AASUSMH.AssetID " +
                                               "        LEFT JOIN AM_ASSET_SEWER_MH AASDSMH ON AASS.DSMH = AASDSMH.AssetID " +
                                               "        LEFT JOIN LFS_MIGRATED_SECTIONS LMS ON AASS.AssetID = LMS.NewID " +
                                               " WHERE {0} ORDER BY {1}", where, orderBy);
            FillData(commandText);
        }



    }
}
