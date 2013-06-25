using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// JlNavigatorGateway
    /// </summary>
    public class JlNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlNavigatorGateway()
            : base("JlNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlNavigatorGateway(DataSet data)
            : base(data, "JlNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlNavigatorTDS();
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
            tableMapping.DataSetTable = "JlNavigator";
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("AssetID_", "AssetID_");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("City", "City");
            tableMapping.ColumnMappings.Add("CityDescription", "CityDescription");
            tableMapping.ColumnMappings.Add("PipeLocated", "PipeLocated");
            tableMapping.ColumnMappings.Add("ServicesLocated", "ServicesLocated");
            tableMapping.ColumnMappings.Add("CoInstalled", "CoInstalled");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("Grouted", "Grouted");
            tableMapping.ColumnMappings.Add("Cored", "Cored");
            tableMapping.ColumnMappings.Add("Prepped", "Prepped");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("InStock", "InStock");
            tableMapping.ColumnMappings.Add("Delivered", "Delivered");
            tableMapping.ColumnMappings.Add("PreVideo", "PreVideo");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("CoRequired", "CoRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("CoCutDown", "CoCutDown");
            tableMapping.ColumnMappings.Add("FinalRestoration", "FinalRestoration");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
            tableMapping.ColumnMappings.Add("OriginalSectionID", "OriginalSectionID");
            tableMapping.ColumnMappings.Add("NoticeDelivered", "NoticeDelivered");
            tableMapping.ColumnMappings.Add("BuildRebuild", "BuildRebuild");
            tableMapping.ColumnMappings.Add("HamiltonInspectionNumber", "HamiltonInspectionNumber");
            tableMapping.ColumnMappings.Add("ConnectionType", "ConnectionType");
            tableMapping.ColumnMappings.Add("MainSize", "MainSize");
            tableMapping.ColumnMappings.Add("Flange", "Flange");
            tableMapping.ColumnMappings.Add("Gasket", "Gasket");
            tableMapping.ColumnMappings.Add("DepthOflocated", "DepthOfLocated");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLining", "DigRequiredPriorToLining");
            tableMapping.ColumnMappings.Add("DigRequiredPriorToLiningCompleted", "DigRequiredPriorToLiningCompleted");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLining", "DigRequiredAfterLining");
            tableMapping.ColumnMappings.Add("DigRequiredAfterLiningCompleted", "DigRequiredAfterLiningCompleted");
            tableMapping.ColumnMappings.Add("OutOfScope", "OutOfScope");
            tableMapping.ColumnMappings.Add("HoldClientIssue", "HoldClientIssue");
            tableMapping.ColumnMappings.Add("HoldClientIssueResolved", "HoldClientIssueResolved");
            tableMapping.ColumnMappings.Add("HoldLFSIssue", "HoldLFSIssue");
            tableMapping.ColumnMappings.Add("HoldLFSIssueResolved", "HoldLFSIssueResolved");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrep", "LateralRequiresRoboticPrep");
            tableMapping.ColumnMappings.Add("LateralRequiresRoboticPrepCompleted", "LateralRequiresRoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("PrepType", "PrepType");
            tableMapping.ColumnMappings.Add("LinerType", "LinerType");
            tableMapping.ColumnMappings.Add("DyeTestReq", "DyeTestReq");
            tableMapping.ColumnMappings.Add("DyeTestComplete", "DyeTestComplete");
            tableMapping.ColumnMappings.Add("ContractYear", "ContractYear");
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
        /// <param name="conditionValue2">conditionValue2</param>
        /// <param name="textForSearch2">textForSearch2</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch, string conditionValue2, string textForSearch2)
        {
            // For USMH
            string whereClauseUsmh = "";

            if (conditionValue == "USMH")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereClauseUsmh = whereClauseUsmh + " AND  (AASS.AssetID IN " +
                             " (SELECT DISTINCT AASS2.AssetID " +
                             "   FROM  AM_ASSET AA2 INNER JOIN " +
                             "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                             "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                             "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                             "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                             "          WHERE AASM.MHID LIKE '%" + textForSearch.Trim() + "%'))))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseUsmh = whereClauseUsmh + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            if (conditionValue2 == "USMH")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereClauseUsmh = whereClauseUsmh + " AND  (AASS.AssetID IN " +
                             " (SELECT DISTINCT AASS2.AssetID " +
                             "   FROM  AM_ASSET AA2 INNER JOIN " +
                             "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                             "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                             "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                             "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                             "          WHERE AASM.MHID LIKE '%" + textForSearch2.Trim() + "%'))))";
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereClauseUsmh = whereClauseUsmh + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            // For DSMH
            string whereClauseDsmh = "";

            if (conditionValue == "DSMH")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {

                    whereClauseDsmh = whereClauseDsmh + " AND (AASS.AssetID IN " +
                             " (SELECT DISTINCT AASS2.AssetID " +
                             "   FROM  AM_ASSET AA2 INNER JOIN " +
                             "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                             "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                             "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID  " +
                             "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0) AND (AASS2.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                             "          WHERE AASM.MHID LIKE '%" + textForSearch.Trim() + "%'))))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseDsmh = whereClauseDsmh + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            if (conditionValue2 == "DSMH")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {

                    whereClauseDsmh = whereClauseDsmh + " AND (AASS.AssetID IN " +
                             " (SELECT DISTINCT AASS2.AssetID " +
                             "   FROM  AM_ASSET AA2 INNER JOIN " +
                             "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                             "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                             "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID  " +
                             "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0) AND (AASS2.AssetID IN " +
                             "         (SELECT AASS1.AssetID " +
                             "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                             "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                             "          WHERE AASM.MHID LIKE '%" + textForSearch2.Trim() + "%'))))";
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereClauseDsmh = whereClauseDsmh + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }

            where = where + " AND " +
                   "        (AASS.AssetID NOT IN " +
                   "            ( " +
                   "                SELECT AASS2.AssetID " +
                   "                FROM AM_ASSET_SEWER_SECTION AASS2 INNER JOIN" +
                   "                LFS_WORK LW2 ON LW2.AssetID = AASS2.AssetID AND LW2.Deleted = 0 AND LW2.WorkType = 'Full Length Lining' INNER JOIN" +
                   "                LFS_WORK_FULLLENGTHLINING LWFLL ON LW2.WorkID = LWFLL.WorkID INNER JOIN " +
                   "                LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LWFLP1.WorkID = LW2.WorkID "+
                   "                WHERE (AASS2.AssetID = AASS.AssetID) AND (LW2.ProjectID = LW.ProjectID) " +
                   "                AND (LWFLP1.RoboticPrepCompleted = 1) AND (LWFLP1.RoboticPrepCompletedDate is null) AND (LW2.Deleted = 0)" +
                   "            )" +
                   "        )";

            string commandText = String.Format("SELECT CAST(0 AS bit) AS Selected,AASL.AssetID AS AssetID_, AASS.AssetID, AASL.Section_, AASS.SectionID, AASL.LateralID, LASS.SubArea, AASS.Street, AASS.USMH, AASS.DSMH, LW.Comments, "+
                                                " (SELECT MHID "+
                                                "   FROM AM_ASSET_SEWER_MH AASMH "+
                                                " WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, "+
                                                " (SELECT MHID "+
                                                "   FROM AM_ASSET_SEWER_MH AASMH "+
                                                " WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, AASL.Address, "+
                                                " 0 AS City, '' AS CityDescription, LWJLL.PipeLocated, LWJLL.ServicesLocated, LWJLL.CoInstalled, LWJLL.BackfilledConcrete, LWJLL.BackfilledSoil, LWJLL.Grouted, LWJLL.Cored, LWJLL.Prepped, LWJLL.Measured, " +
                                                " LWJLL.InProcess, LWJLL.InStock, LWJLL.Delivered, LWJLL.PreVideo, LWJLL.LinerInstalled, LWJLL.FinalVideo, LW.History, LWJLL.VideoInspection, LWJLL.CoRequired, LWJLL.PitRequired, LWJLL.CoPitLocation, " +
                                                " AASL.DistanceFromUSMH, AASL.DistanceFromDSMH, LWJLL.Cost, LWJLL.PostContractDigRequired, LWJLL.LinerSize, LWJLL.CoCutDown, LWJLL.FinalRestoration, AASS.FlowOrderID, LASLC.ClientLateralID, " +
                                                " LWJLL.VideoLengthToPropertyLine, LWJLL.LiningThruCo, LMS.OriginalSectionID, LWJLL.NoticeDelivered, LWJLL.BuildRebuild, LWJLL.HamiltonInspectionNumber, AASL.ConnectionType, AASS.Size_ AS MainSize, LWJLL.Flange, LWJLL.Gasket, "+
                                                " LWJLL.DepthOfLocated, LWJLL.DigRequiredPriorToLining, LWJLL.DigRequiredPriorToLiningCompleted, LWJLL.DigRequiredAfterLining, LWJLL.DigRequiredAfterLiningCompleted, LWJLL.OutOfScope, LWJLL.HoldClientIssue, "+
                                                " LWJLL.HoldClientIssueResolved, LWJLL.HoldLFSIssue, LWJLL.HoldLFSIssueResolved, LWJLL.LateralRequiresRoboticPrep, LWJLL.LateralRequiresRoboticPrepCompleted, LWJLL.PrepType, LWJLL.LinerType, LWJLL.DyeTestReq, LWJLL.DyeTestComplete, LWJLL.ContractYear " +
                                                " FROM AM_ASSET_SEWER_LATERAL AASL INNER JOIN " +
                                                "       LFS_WORK LW ON AASL.AssetID = LW.AssetID INNER JOIN " +
                                                "       LFS_PROJECT P ON LW.ProjectID = P.ProjectID LEFT JOIN " +
                                                "       LFS_ASSET_SEWER_LATERAL_CLIENT LASLC ON AASL.AssetID = LASLC.AssetID AND P.ClientID = LASLC.ClientID INNER JOIN " +
                                                "       AM_ASSET AA ON AASL.AssetID = AA.AssetID INNER JOIN " +
                                                "       AM_ASSET_SEWER AAS ON AASL.AssetID = AAS.AssetID INNER JOIN " +
                                                "       AM_ASSET_SEWER_SECTION AASS ON AASL.Section_ = AASS.AssetID INNER JOIN " +
                                                "       LFS_ASSET_SEWER_SECTION LASS ON AASS.AssetID = LASS.AssetID INNER JOIN " +
                                                "       LFS_WORK_JUNCTIONLINING_LATERAL LWJLL ON LW.WorkID = LWJLL.WorkID INNER JOIN " +
                                                "       LFS_WORK_JUNCTIONLINING_SECTION LWJLS ON LWJLL.SectionWorkID = LWJLS.WorkID LEFT JOIN " +
                                                "       LFS_MIGRATED_SECTIONS LMS ON AASS.AssetID = LMS.NewID " +
                                                " WHERE {0} {1} {2} ORDER BY {3}", where, whereClauseUsmh, whereClauseDsmh, orderBy);
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