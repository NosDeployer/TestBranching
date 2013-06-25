using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.DA.CWP.RehabAssessment
{
    /// <summary>
    /// RaNavigatorGateway
    /// </summary>
    public class RaNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RaNavigatorGateway()
            : base("RaNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RaNavigatorGateway(DataSet data)
            : base(data, "RaNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RaNavigatorTDS();
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
            tableMapping.DataSetTable = "RaNavigator";
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("AssetID_", "AssetID_");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("OriginalSectionID", "OriginalSectionID");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("VideoLength", "VideoLength");
            tableMapping.ColumnMappings.Add("Laterals", "Laterals");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("MaterialType", "MaterialType");
            tableMapping.ColumnMappings.Add("USMHAddress", "USMHAddress");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("USMHMouth12", "USMHMouth12");
            tableMapping.ColumnMappings.Add("USMHMouth1", "USMHMouth1");
            tableMapping.ColumnMappings.Add("USMHMouth2", "USMHMouth2");
            tableMapping.ColumnMappings.Add("USMHMouth3", "USMHMouth3");
            tableMapping.ColumnMappings.Add("USMHMouth4", "USMHMouth4");
            tableMapping.ColumnMappings.Add("USMHMouth5", "USMHMouth5");
            tableMapping.ColumnMappings.Add("DSMHAddress", "DSMHAddress");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("DSMHMouth12", "DSMHMouth12");
            tableMapping.ColumnMappings.Add("DSMHMouth1", "DSMHMouth1");
            tableMapping.ColumnMappings.Add("DSMHMouth2", "DSMHMouth2");
            tableMapping.ColumnMappings.Add("DSMHMouth3", "DSMHMouth3");
            tableMapping.ColumnMappings.Add("DSMHMouth4", "DSMHMouth4");
            tableMapping.ColumnMappings.Add("DSMHMouth5", "DSMHMouth5");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("SiteDetails", "SiteDetails");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("MeasurementFromMH", "MeasurementFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneFromMH", "VideoDoneFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneToMH", "VideoDoneToMH");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
            tableMapping.ColumnMappings.Add("RoboticPrepCompleted", "RoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("RoboticPrepCompletedDate", "RoboticPrepCompletedDate");
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
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch)
        {            
            string whereClauseSpecial = "";

            // For USMH
            if (conditionValue == "USMH")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND  (AASS.AssetID IN " +
                             " (SELECT DISTINCT AASS2.AssetID " +
                             "   FROM  AM_ASSET AA2 INNER JOIN " +
                             "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                             "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                             "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                             "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                             "          WHERE AASM.MHID LIKE '%" + textForSearch.Trim() + "%'))))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            // For DSMH
            if (conditionValue == "DSMH")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (AASS.AssetID IN " +

                             " (SELECT DISTINCT AASS2.AssetID " +
                             "   FROM  AM_ASSET AA2 INNER JOIN " +
                             "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                             "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                             "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID  " +
                             "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0) AND (AASS2.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                             "          WHERE AASM.MHID LIKE '%" + textForSearch.Trim() + "%'))))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            // For Material Type
            if (conditionValue == "MaterialType")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseSpecial = whereClauseSpecial + " AND (AASS.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MATERIAL AASM ON AASS1.AssetID = AASM.AssetID " +
                             "          WHERE (AASM.MaterialType LIKE '%" + textForSearch.Trim() + "%') AND (AASS1.Deleted = 0)))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseSpecial = whereClauseSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MATERIAL AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            string commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, AASS.AssetID AS AssetID_, " +
                          " AASS.AssetID, AASS.SectionID, LASS.SubArea, AASS.Street, AASS.USMH, AASS.DSMH, " +
                          " LW.Comments, " +
                          "  (SELECT MHID " +
                          "    FROM AM_ASSET_SEWER_MH AASMH " +
                          "    WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                          "  (SELECT MHID " +
                          "    FROM AM_ASSET_SEWER_MH AASMH " +
                          "    WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                          " AASS.FlowOrderID, LWR.PreFlushDate, LWR.PreVideoDate, AASS.MapSize, AASS.MapLength, LMS.OriginalSectionID, " +
                          " AASS.Size_, AASS.Length, LWFLLM2.VideoLength, AASS.Laterals, AASS.LiveLaterals, LWFLL.ClientID, LWFLL.P1Date, LWFLP1.CXIsRemoved, LWFLL.M1Date, LWFM1.MeasurementTakenBy, " +
                          " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, " +
                          " AASUSMH.Address AS USMHAddress, AASS.USMHDepth, LASS.USMHMouth12, LASS.USMHMouth1, LASS.USMHMouth2, LASS.USMHMouth3, LASS.USMHMouth4, LASS.USMHMouth5, " +
                          " AASDSMH.Address AS DSMHAddress, AASS.DSMHDepth, LASS.DSMHMouth12, LASS.DSMHMouth1, LASS.DSMHMouth2, LASS.DSMHMouth3, LASS.DSMHMouth4, LASS.DSMHMouth5, LWFM1.TrafficControl, LWFM1.SiteDetails, " +
                          " LWFM1.PipeSizeChange, LWFM1.StandardBypass, LWFM1.StandardBypassComments, LWFM1.TrafficControlDetails, LWFM1.MeasurementType, LWFM1.MeasurementFromMH, LWFM1.VideoDoneFromMH, " +
                          " LWFM1.VideoDoneToMH, LASS.Thickness, LWFLP1.RoboticPrepCompleted, LWFLP1.RoboticPrepCompletedDate " +
                          " FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN " +
                          "      LFS_WORK LW ON LWR.WorkID = LW.WorkID INNER JOIN " +
                          "      AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                          "      AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                          "      AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                          "      LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID LEFT JOIN " +
                          "      LFS_MIGRATED_SECTIONS LMS ON AA.AssetID = LMS.NewID LEFT JOIN " +
                          "     AM_ASSET_SEWER_MH AASUSMH ON AASS.USMH = AASUSMH.AssetID LEFT JOIN " +
                             "  AM_ASSET_SEWER_MH AASDSMH ON AASS.DSMH = AASDSMH.AssetID LEFT JOIN " +
                          "      LFS_WORK LW2 ON LW2.AssetID = AA.AssetID AND LW2.Deleted = 0 AND LW2.WorkType = 'Full Length Lining' AND LW2.ProjectID = LW.ProjectID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING LWFLL ON LW2.WorkID = LWFLL.WorkID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING_M1 LWFM1 ON LWFM1.WorkID = LW2.WorkID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING_M2 LWFLLM2 ON LWFLLM2.WorkID = LW2.WorkID LEFT JOIN " +
                          "      LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LWFLP1.WorkID = LW2.WorkID " +
                         " WHERE {0} {1} ORDER BY {2}", where, whereClauseSpecial, orderBy);

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