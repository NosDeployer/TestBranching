using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.PointRepairs
{
    /// <summary>
    /// PrNavigatorGateway
    /// </summary>
    public class PrNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PrNavigatorGateway()
            : base("PrNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrNavigatorGateway(DataSet data)
            : base(data, "PrNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrNavigatorTDS();
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
            tableMapping.DataSetTable = "PrNavigator";
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("AssetID_", "AssetID_");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("DeadlineLiningDate", "DeadlineLiningDate");
            tableMapping.ColumnMappings.Add("FinalVideoDate", "FinalVideoDate");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("USMHAddress", "USMHAddress");
            tableMapping.ColumnMappings.Add("DSMHAddress", "DSMHAddress");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("VideoLength", "VideoLength");
            tableMapping.ColumnMappings.Add("Laterals", "Laterals");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("RepairConfirmationDate", "RepairConfirmationDate");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("MaterialType", "MaterialType");
            tableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            tableMapping.ColumnMappings.Add("RoboticPrepRequired", "RoboticPrepRequired");
            tableMapping.ColumnMappings.Add("RoboticDistances", "RoboticDistances");
            tableMapping.ColumnMappings.Add("EstimatedJoints", "EstimatedJoints");
            tableMapping.ColumnMappings.Add("JointsTestSealed", "JointsTestSealed");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueGivenToClient", "IssueGivenToClient");
            tableMapping.ColumnMappings.Add("IssueInvestigation", "IssueInvestigation");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("RepairPointID", "RepairPointID");
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
        /// <param name="name">name</param>
        /// <param name="conditionValue2">conditionValue2</param>
        /// <param name="textForSearch2">textForSearch2</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch, string name, string conditionValue2, string textForSearch2)
        {
            // For USMH
            string whereSpecial = "";

            if (conditionValue == "USMH")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereSpecial = whereSpecial + " AND  (AASS.AssetID IN " +
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
                        whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }
            else
            {
                if (conditionValue == "USMHAddress")
                {
                    if ((textForSearch != "") && (textForSearch != "%"))
                    {
                        whereSpecial = whereSpecial + " AND  (AASS.AssetID IN " +
                                 " (SELECT DISTINCT AASS2.AssetID " +
                                 "   FROM  AM_ASSET AA2 INNER JOIN " +
                                 "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                                 "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                                 "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                                 "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "          WHERE AASM.Address LIKE '%" + textForSearch.Trim() + "%'))))";
                    }
                    else
                    {
                        if (textForSearch == "")
                        {
                            whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                     "         (SELECT AASS1.AssetID " +
                                     "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                     "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                     "         ))";
                        }
                    }
                }
            }

            if (conditionValue2 == "USMH")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereSpecial = whereSpecial + " AND  (AASS.AssetID IN " +
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
                        whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }
            else
            {
                if (conditionValue2 == "USMHAddress")
                {
                    if ((textForSearch2 != "") && (textForSearch2 != "%"))
                    {
                        whereSpecial = whereSpecial + " AND  (AASS.AssetID IN " +
                                 " (SELECT DISTINCT AASS2.AssetID " +
                                 "   FROM  AM_ASSET AA2 INNER JOIN " +
                                 "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                                 "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                                 "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                                 "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                 "          WHERE AASM.Address LIKE '%" + textForSearch2.Trim() + "%'))))";
                    }
                    else
                    {
                        if (textForSearch2 == "")
                        {
                            whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                     "         (SELECT AASS1.AssetID " +
                                     "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                     "          AM_ASSET_SEWER_MH AASM ON AASS1.USMH = AASM.AssetID " +
                                     "         ))";
                        }
                    }
                }
            }

            // For DSMH
            if (conditionValue == "DSMH")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
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
                        whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }
            else
            {
                if (conditionValue == "DSMHAddress")
                {
                    if ((textForSearch != "") && (textForSearch != "%"))
                    {
                        whereSpecial = whereSpecial + " AND  (AASS.AssetID IN " +
                                 " (SELECT DISTINCT AASS2.AssetID " +
                                 "   FROM  AM_ASSET AA2 INNER JOIN " +
                                 "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                                 "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                                 "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                                 "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "          WHERE AASM.Address LIKE '%" + textForSearch.Trim() + "%'))))";
                    }
                    else
                    {
                        if (textForSearch == "")
                        {
                            whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                     "         (SELECT AASS1.AssetID " +
                                     "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                     "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                     "         ))";
                        }
                    }
                }
            }

            if (conditionValue2 == "DSMH")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
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
                        whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "         ))";
                    }
                }
            }
            else
            {
                if (conditionValue2 == "DSMHAddress")
                {
                    if ((textForSearch2 != "") && (textForSearch2 != "%"))
                    {
                        whereSpecial = whereSpecial + " AND  (AASS.AssetID IN " +
                                 " (SELECT DISTINCT AASS2.AssetID " +
                                 "   FROM  AM_ASSET AA2 INNER JOIN " +
                                 "         AM_ASSET_SEWER AAS2 ON AA2.AssetID = AAS2.AssetID INNER JOIN " +
                                 "         AM_ASSET_SEWER_SECTION AASS2 ON AAS2.AssetID = AASS2.AssetID INNER JOIN " +
                                 "         LFS_WORK LW2 ON AA2.AssetID = LW2.AssetID " +
                                 "   WHERE (LW2.Deleted = 0) AND (AA2.Deleted = 0) AND (AAS2.Deleted = 0)  AND (AASS2.AssetID IN " +
                                 "         (SELECT AASS1.AssetID " +
                                 "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                 "          WHERE AASM.Address LIKE '%" + textForSearch2.Trim() + "%'))))";
                    }
                    else
                    {
                        if (textForSearch2 == "")
                        {
                            whereSpecial = whereSpecial + " AND (AASS.AssetID  NOT IN " +
                                     "         (SELECT AASS1.AssetID " +
                                     "          FROM   AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                     "          AM_ASSET_SEWER_MH AASM ON AASS1.DSMH = AASM.AssetID " +
                                     "         ))";
                        }
                    }
                }
            }

            // For CXIsRemoved
            if (conditionValue == "CXIsRemoved")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved = " + textForSearch.Trim() + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            if (conditionValue2 == "CXIsRemoved")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved = " + textForSearch2.Trim() + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            // Video Length
            if (conditionValue == "VideoLength")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M2 LWFLM2 ON LW1.WorkID = LWFLM2.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLM2.VideoLength = " + textForSearch.Trim() + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLM2.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M2 LWFLM2 ON LW1.WorkID = LWFLM2.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLM2.VideoLength IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLM2.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            if (conditionValue2 == "VideoLength")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M2 LWFLM2 ON LW1.WorkID = LWFLM2.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLM2.VideoLength = " + textForSearch2.Trim() + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLM2.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M2 LWFLM2 ON LW1.WorkID = LWFLM2.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLM2.VideoLength IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLM2.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            // For PreFlushDate
            if (conditionValue == "PreFlushDate")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    if (textForSearch.Length > 7)
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreFlushDate, 101) AS smalldatetime) = '" + textForSearch + "'))" +
                                " ) )";
                    }
                    else
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID" +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreFlushDate, 101) AS smalldatetime) LIKE '%" + textForSearch + "%'))" +
                                " ) )";
                    }
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                " (SELECT AASS1.AssetID " +
                                " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID "+
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreFlushDate, 101) AS smalldatetime) IS NULL))" +
                                " ) )";
                    }
                }
            }

            if (conditionValue2 == "PreFlushDate")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    if (textForSearch2.Length > 7)
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreFlushDate, 101) AS smalldatetime) = '" + textForSearch2 + "'))" +
                                " ) )";
                    }
                    else
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID" +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreFlushDate, 101) AS smalldatetime) LIKE '%" + textForSearch2 + "%'))" +
                                " ) )";
                    }
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                " (SELECT AASS1.AssetID " +
                                " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreFlushDate, 101) AS smalldatetime) IS NULL))" +
                                " ) )";
                    }
                }
            }  

            // For PreVideoDate
            if (conditionValue == "PreVideoDate")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    if (textForSearch.Length > 7)
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreVideoDate, 101) AS smalldatetime) = '" + textForSearch + "'))" +
                                " ) )";
                    }
                    else
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreVideoDate, 101) AS smalldatetime) LIKE '%" + textForSearch + "%'))" +
                                " ) )";
                    }
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                " (SELECT AASS1.AssetID " +
                                " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreVideoDate, 101) AS smalldatetime) IS NULL))" +
                                " ) )";
                    }
                }
            }

            if (conditionValue2 == "PreVideoDate")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    if (textForSearch2.Length > 7)
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreVideoDate, 101) AS smalldatetime) = '" + textForSearch2 + "'))" +
                                " ) )";
                    }
                    else
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                               " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreVideoDate, 101) AS smalldatetime) LIKE '%" + textForSearch2 + "%'))" +
                                " ) )";
                    }
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                " (SELECT AASS1.AssetID " +
                                " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Rehab Assessment') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_REHABASSESSMENT LWR1 ON LW1.WorkID = LWR1.WorkID " +
                                " WHERE ( (LWR1.Deleted = 0) AND (CAST(CONVERT(varchar, LWR1.PreVideoDate, 101) AS smalldatetime) IS NULL))" +
                                " ) )";
                    }
                }
            }

            // For P1Date
            if (conditionValue == "P1Date")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    if (textForSearch.Length > 7)
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING LWFLL1 ON LW1.WorkID = LWFLL1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                " WHERE ( (LWFLL1.Deleted = 0) AND (CAST(CONVERT(varchar, LWFLL1.P1Date, 101) AS smalldatetime) = '" + textForSearch + "'))" +
                                " ) )";
                    }
                    else
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING LWFLL1 ON LW1.WorkID = LWFLL1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                " WHERE ( (LWFLL1.Deleted = 0) AND (CAST(CONVERT(varchar, LWFLL1.P1Date, 101) AS smalldatetime) LIKE '%" + textForSearch + "%'))" +
                                " ) )";
                    }
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING LWFLL1 ON LW1.WorkID = LWFLL1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                " WHERE ( (LWFLL1.Deleted = 0) AND (CAST(CONVERT(varchar, LWFLL1.P1Date, 101) AS smalldatetime) IS NULL))" +
                                " ) )";
                    }
                }
            }

            if (conditionValue2 == "P1Date")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    if (textForSearch2.Length > 7)
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING LWFLL1 ON LW1.WorkID = LWFLL1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                " WHERE ( (LWFLL1.Deleted = 0) AND (CAST(CONVERT(varchar, LWFLL1.P1Date, 101) AS smalldatetime) = '" + textForSearch2 + "'))" +
                                " ) )";
                    }
                    else
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                               " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING LWFLL1 ON LW1.WorkID = LWFLL1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                " WHERE ( (LWFLL1.Deleted = 0) AND (CAST(CONVERT(varchar, LWFLL1.P1Date, 101) AS smalldatetime) LIKE '%" + textForSearch2 + "%'))" +
                                " ) )";
                    }
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING LWFLL1 ON LW1.WorkID = LWFLL1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                " WHERE ( (LWFLL1.Deleted = 0) AND (CAST(CONVERT(varchar, LWFLL1.P1Date, 101) AS smalldatetime) IS NULL))" +
                                " ) )";
                    }
                }
            }

            // TrafficControl
            if (conditionValue == "TrafficControl")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M1 LWFLLM1 ON LW1.WorkID = LWFLLM1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLLM1.TrafficControl = " + textForSearch.Trim() + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLLM1.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M1 LWFLLM1 ON LW1.WorkID = LWFLLM1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLLM1.TrafficControl IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLLM1.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            if (conditionValue2 == "TrafficControl")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M1 LWFLLM1 ON LW1.WorkID = LWFLLM1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLLM1.TrafficControl = " + textForSearch2.Trim() + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLLM1.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_M1 LWFLLM1 ON LW1.WorkID = LWFLLM1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLLM1.TrafficControl IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLLM1.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            // MaterialType
            if (conditionValue == "MaterialType")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " AM_ASSET_SEWER_MATERIAL AASM ON (AASS1.AssetID = AASM.AssetID) " +
                                 " WHERE ( (AASM.MaterialType = " + textForSearch.Trim() + ") AND (AASS1.Deleted = 0) AND (AASM.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " AM_ASSET_SEWER_MATERIAL AASM ON (AASS1.AssetID = AASM.AssetID) " +
                                 " WHERE ( (AASM.MaterialType IS NULL) AND (AASS1.Deleted = 0) AND (AASM.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            if (conditionValue2 == "MaterialType")
            {
                if ((textForSearch2 != "") && (textForSearch2 != "%"))
                {
                    whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " AM_ASSET_SEWER_MATERIAL AASM ON (AASS1.AssetID = AASM.AssetID) " +
                                 " WHERE ( (AASM.MaterialType = " + textForSearch2.Trim() + ") AND (AASS1.Deleted = 0) AND (AASM.Deleted = 0)) " +
                                 " ) )";
                }
                else
                {
                    if (textForSearch2 == "")
                    {
                        whereSpecial = whereSpecial + " AND (AASS.AssetID IN " +
                                 " (SELECT AASS1.AssetID " +
                                 " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " AM_ASSET_SEWER_MATERIAL AASM ON (AASS1.AssetID = AASM.AssetID) " +
                                 " WHERE ( (AASM.MaterialType IS NULL) AND (AASS1.Deleted = 0) AND (AASM.Deleted = 0)) " +
                                 " ) )";
                    }
                }
            }

            // For Repairs (RepairPointID, Type, DefectQualifier, DefectDetails, Approval, ReamDistance, LinerDistance, Direction, LTMH, VTMH, Distance, MHShot, GroutDistance, ExtraRepair, Cancelled, Reinstates, , ReamDate, InstallDate, GroutDate)
            string commandText = "";
            string conditionRepair = " (LWPRR.RepairPointID";

            // ... for condition 1
            if (conditionValue == "RepairPointID") conditionRepair += ") ";
            if (conditionValue == "Type") conditionRepair += " +' / '+ LWPRR.Type) AS RepairPointID ";
            if (conditionValue == "DefectQualifier") conditionRepair += " +' / '+ LWPRR.DefectQualifier) AS RepairPointID ";
            if (conditionValue == "DefectDetails") conditionRepair += " +' / '+ LWPRR.DefectDetails) AS RepairPointID ";
            if (conditionValue == "Approval") conditionRepair += " +' / '+ LWPRR.Approval) AS RepairPointID ";
            if (conditionValue == "ReamDistance") conditionRepair += " +' / '+ LWPRR.ReamDistance) AS RepairPointID ";
            if (conditionValue == "LinerDistance") conditionRepair += " +' / '+ LWPRR.LinerDistance) AS RepairPointID ";
            if (conditionValue == "Direction") conditionRepair += " +' / '+ LWPRR.Direction) AS RepairPointID ";
            if (conditionValue == "LTMH") conditionRepair += "  +' / '+ LWPRR.LTMH) AS RepairPointID ";
            if (conditionValue == "VTMH") conditionRepair += " +' / '+ LWPRR.VTMH) AS RepairPointID ";
            if (conditionValue == "Distance") conditionRepair += " +' / '+ LWPRR.Distance) AS RepairPointID ";
            if (conditionValue == "MHShot") conditionRepair += " +' / '+ LWPRR.MHShot) AS RepairPointID ";
            if (conditionValue == "GroutDistance") conditionRepair += "  +' / '+ LWPRR.GroutDistance) AS RepairPointID ";
            if (conditionValue == "Reinstates") conditionRepair += "  +' / '+ CAST(LWPRR.Reinstates AS nvarchar)) AS RepairPointID ";
            if (conditionValue == "ReamDate") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.ReamDate,101)) AS RepairPointID ";
            if (conditionValue == "InstallDate") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.InstallDate,101)) AS RepairPointID ";
            if (conditionValue == "GroutDate") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.GroutDate,101)) AS RepairPointID ";
            if (conditionValue == "Comments" && name == "Repair Comments") conditionRepair += "  +' / '+ CAST(LWPRR.Comments AS nvarchar)) AS RepairPointID ";
            if (conditionValue == "Size_" && name == "Repair Size") conditionRepair += "  +' / '+ LWPRR.Size_) AS RepairPointID ";
            if (conditionValue == "Length" && name == "Repair Length") conditionRepair += "  +' / '+ LWPRR.Length) AS RepairPointID ";
            if (conditionValue == "ExtraRepair") conditionRepair += " +' / '+ (CASE WHEN LWPRR.ExtraRepair = 0 THEN 'No' ELSE 'Yes' END)) AS RepairPointID ";
            if (conditionValue == "Cancelled") conditionRepair += " +' / '+ (CASE WHEN LWPRR.Cancelled = 0 THEN 'No' ELSE 'Yes' END)) AS RepairPointID ";
                           
            if ((conditionValue == "RepairPointID") || (conditionValue == "Type") || (conditionValue == "DefectQualifier") || (conditionValue == "DefectDetails") || (conditionValue == "Approval") || (conditionValue == "ReamDistance") || (conditionValue == "LinerDistance") || (conditionValue == "Direction") || (conditionValue == "LTMH") || (conditionValue == "VTMH") || (conditionValue == "Distance") || (conditionValue == "MHShot") || (conditionValue == "GroutDistance") || (conditionValue == "ExtraRepair") || (conditionValue == "Cancelled") || (conditionValue == "Reinstates") || (conditionValue == "ReamDate") || (conditionValue == "InstallDate") || (conditionValue == "GroutDate") || (conditionValue == "Comments" && name == "Repair Comments") || (conditionValue == "Size_" && name == "Repair Size") || (conditionValue == "Length" && name == "Repair Length"))
            {
                commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, "+
                 "  ( CAST(AASS.AssetID AS nvarchar) + (CASE WHEN LWPRR.RepairPointID is null THEN '' ELSE '-'+LWPRR.RepairPointID END) ) AS AssetID_, AASS.AssetID, " +
                 " AASS.SectionID, AASS.Street, AASS.USMH, AASS.DSMH, " +
                 " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                 " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                 " AASS.FlowOrderID, LASS.SubArea, LWPR.ProposedLiningDate, LWPR.DeadlineLiningDate, LWPR.FinalVideoDate, " +
                 " (SELECT TOP 1 LWFP1.CXIsRemoved FROM LFS_WORK_FULLLENGTHLINING_P1 LWFP1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFP1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW1 ON LWFLL.WorkID = LW1.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW1.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS CXIsRemoved, " +
                 " LW.Comments, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHAddress, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHAddress, AASS.MapSize, AASS.Size_, AASS.MapLength, AASS.Length, " +
                 " (SELECT TOP 1 LWFM2.VideoLength FROM LFS_WORK_FULLLENGTHLINING_M2 LWFM2 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM2.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS VideoLength, " +
                 " AASS.Laterals, AASS.LiveLaterals, LWPR.ClientID, LWPR.MeasurementTakenBy, " +
                 " (SELECT TOP 1 LWR.PreFlushDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreFlushDate, " +
                 " (SELECT TOP 1 LWR.PreVideoDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreVideoDate, " +
                 "  (SELECT TOP 1 LWFLL.P1Date FROM LFS_WORK_FULLLENGTHLINING LWFLL INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS P1Date, " +
                 " LWPR.RepairConfirmationDate, (SELECT TOP 1 LWFM1.TrafficControl FROM LFS_WORK_FULLLENGTHLINING_M1 LWFM1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS TrafficControl," +
                 " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, LWPR.BypassRequired, " +
                 " CAST(0 AS bit) AS RoboticPrepRequired, " +
                 " LWPR.RoboticDistances, LWPR.EstimatedJoints, LWPR.JointsTestSealed, LWPR.IssueIdentified, LWPR.IssueLFS, LWPR.IssueClient, LWPR.IssueSales, LWPR.IssueGivenToClient, LWPR.IssueInvestigation, LWPR.IssueResolved, " +
                 " LWPR.WorkID, {3}"+               
                 " " +
                 " FROM LFS_WORK LW INNER JOIN " +
                 "  AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                 "  AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                 "  AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                 "  LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID INNER JOIN " +
                 "  LFS_WORK_POINT_REPAIRS LWPR ON LW.WorkID = LWPR.WorkID LEFT JOIN " +
                 "  LFS_WORK_POINT_REPAIRS_REPAIR LWPRR ON LWPR.WorkID = LWPRR.WorkID" +
                 "                                               " +
                 " WHERE {0} {1} ORDER BY {2}", where, whereSpecial, orderBy, conditionRepair);
            }
            else
            {
                // ... for condition 1
                if (conditionValue2 == "RepairPointID") conditionRepair += ") ";
                if (conditionValue2 == "Type") conditionRepair += " +' / '+ LWPRR.Type) AS RepairPointID ";
                if (conditionValue2 == "DefectQualifier") conditionRepair += " +' / '+ LWPRR.DefectQualifier) AS RepairPointID ";
                if (conditionValue2 == "DefectDetails") conditionRepair += " +' / '+ LWPRR.DefectDetails) AS RepairPointID ";
                if (conditionValue2 == "Approval") conditionRepair += " +' / '+ LWPRR.Approval) AS RepairPointID ";
                if (conditionValue2 == "ReamDistance") conditionRepair += " +' / '+ LWPRR.ReamDistance) AS RepairPointID ";
                if (conditionValue2 == "LinerDistance") conditionRepair += " +' / '+ LWPRR.LinerDistance) AS RepairPointID ";
                if (conditionValue2 == "Direction") conditionRepair += " +' / '+ LWPRR.Direction) AS RepairPointID ";
                if (conditionValue2 == "LTMH") conditionRepair += "  +' / '+ LWPRR.LTMH) AS RepairPointID ";
                if (conditionValue2 == "VTMH") conditionRepair += " +' / '+ LWPRR.VTMH) AS RepairPointID ";
                if (conditionValue2 == "Distance") conditionRepair += " +' / '+ LWPRR.Distance) AS RepairPointID ";
                if (conditionValue2 == "MHShot") conditionRepair += " +' / '+ LWPRR.MHShot) AS RepairPointID ";
                if (conditionValue2 == "GroutDistance") conditionRepair += "  +' / '+ LWPRR.GroutDistance) AS RepairPointID ";
                if (conditionValue2 == "Reinstates") conditionRepair += "  +' / '+ CAST(LWPRR.Reinstates AS nvarchar)) AS RepairPointID ";
                if (conditionValue2 == "ReamDate") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.ReamDate,101)) AS RepairPointID ";
                if (conditionValue2 == "InstallDate") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.InstallDate,101)) AS RepairPointID ";
                if (conditionValue2 == "GroutDate") conditionRepair += "  +' / '+ CONVERT(nvarchar,LWPRR.GroutDate,101)) AS RepairPointID ";
                if (conditionValue2 == "Comments" && name == "Repair Comments") conditionRepair += "  +' / '+ CAST(LWPRR.Comments AS nvarchar)) AS RepairPointID ";
                if (conditionValue2 == "Size_" && name == "Repair Size") conditionRepair += "  +' / '+ LWPRR.Size_) AS RepairPointID ";
                if (conditionValue2 == "Length" && name == "Repair Length") conditionRepair += "  +' / '+ LWPRR.Length) AS RepairPointID ";
                if (conditionValue2 == "ExtraRepair") conditionRepair += " +' / '+ (CASE WHEN LWPRR.ExtraRepair = 0 THEN 'No' ELSE 'Yes' END)) AS RepairPointID ";
                if (conditionValue2 == "Cancelled") conditionRepair += " +' / '+ (CASE WHEN LWPRR.Cancelled = 0 THEN 'No' ELSE 'Yes' END)) AS RepairPointID ";
                
                if ((conditionValue2 == "RepairPointID") || (conditionValue2 == "Type") || (conditionValue2 == "DefectQualifier") || (conditionValue2 == "DefectDetails") || (conditionValue2 == "Approval") || (conditionValue2 == "ReamDistance") || (conditionValue2 == "LinerDistance") || (conditionValue2 == "Direction") || (conditionValue2 == "LTMH") || (conditionValue2 == "VTMH") || (conditionValue2 == "Distance") || (conditionValue2 == "MHShot") || (conditionValue2 == "GroutDistance") || (conditionValue2 == "ExtraRepair") || (conditionValue2 == "Cancelled") || (conditionValue2 == "Reinstates") || (conditionValue2 == "ReamDate") || (conditionValue2 == "InstallDate") || (conditionValue2 == "GroutDate") || (conditionValue2 == "Comments" && name == "Repair Comments") || (conditionValue2 == "Size_" && name == "Repair Size") || (conditionValue2 == "Length" && name == "Repair Length"))
                {
                    commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, " +
                     "  ( CAST(AASS.AssetID AS nvarchar) + (CASE WHEN LWPRR.RepairPointID is null THEN '' ELSE '-'+LWPRR.RepairPointID END) ) AS AssetID_, AASS.AssetID, " +
                     " AASS.SectionID, AASS.Street, AASS.USMH, AASS.DSMH, " +
                     " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                     " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                     " AASS.FlowOrderID, LASS.SubArea, LWPR.ProposedLiningDate, LWPR.DeadlineLiningDate, LWPR.FinalVideoDate, " +
                     " (SELECT TOP 1 LWFP1.CXIsRemoved FROM LFS_WORK_FULLLENGTHLINING_P1 LWFP1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFP1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW1 ON LWFLL.WorkID = LW1.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW1.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS CXIsRemoved, " +
                     " LW.Comments, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHAddress, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHAddress, AASS.MapSize, AASS.Size_, AASS.MapLength, AASS.Length, " +
                     " (SELECT TOP 1 LWFM2.VideoLength FROM LFS_WORK_FULLLENGTHLINING_M2 LWFM2 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM2.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS VideoLength, " +
                     " AASS.Laterals, AASS.LiveLaterals, LWPR.ClientID, LWPR.MeasurementTakenBy, " +
                     " (SELECT TOP 1 LWR.PreFlushDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreFlushDate, " +
                     " (SELECT TOP 1 LWR.PreVideoDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreVideoDate, " +
                     "  (SELECT TOP 1 LWFLL.P1Date FROM LFS_WORK_FULLLENGTHLINING LWFLL INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS P1Date, " +
                     " LWPR.RepairConfirmationDate, (SELECT TOP 1 LWFM1.TrafficControl FROM LFS_WORK_FULLLENGTHLINING_M1 LWFM1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS TrafficControl," +
                     " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, LWPR.BypassRequired, " +
                     " CAST(0 AS bit) AS RoboticPrepRequired, " +
                     " LWPR.RoboticDistances, LWPR.EstimatedJoints, LWPR.JointsTestSealed, LWPR.IssueIdentified, LWPR.IssueLFS, LWPR.IssueClient, LWPR.IssueSales, LWPR.IssueGivenToClient, LWPR.IssueInvestigation, LWPR.IssueResolved, " +
                     " LWPR.WorkID, {3}" +
                     " " +
                     " FROM LFS_WORK LW INNER JOIN " +
                     "  AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                     "  AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                     "  AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                     "  LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID INNER JOIN " +
                     "  LFS_WORK_POINT_REPAIRS LWPR ON LW.WorkID = LWPR.WorkID LEFT JOIN " +
                     "  LFS_WORK_POINT_REPAIRS_REPAIR LWPRR ON LWPR.WorkID = LWPRR.WorkID" +
                     "                                               " +
                     " WHERE {0} {1} ORDER BY {2}", where, whereSpecial, orderBy, conditionRepair);
                }
                else
                {
                    // For normal searches
                    commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, CAST(AASS.AssetID AS nvarchar) AS AssetID_, AASS.AssetID, " +
                                 " AASS.SectionID, AASS.Street, AASS.USMH, AASS.DSMH, " +
                                 " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHDescription, " +
                                 " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHDescription, " +
                                 " AASS.FlowOrderID, LASS.SubArea, LWPR.ProposedLiningDate, LWPR.DeadlineLiningDate, LWPR.FinalVideoDate, " +
                                 " (SELECT TOP 1 LWFP1.CXIsRemoved FROM LFS_WORK_FULLLENGTHLINING_P1 LWFP1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFP1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW1 ON LWFLL.WorkID = LW1.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW1.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS CXIsRemoved, " +
                                 " LW.Comments, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.USMH) AS USMHAddress, (SELECT Address FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AASS.DSMH) AS DSMHAddress, AASS.MapSize, AASS.Size_, AASS.MapLength, AASS.Length, " +
                                 " (SELECT TOP 1 LWFM2.VideoLength FROM LFS_WORK_FULLLENGTHLINING_M2 LWFM2 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM2.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS VideoLength, " +
                                 " AASS.Laterals, AASS.LiveLaterals, LWPR.ClientID, LWPR.MeasurementTakenBy, " +
                                 " (SELECT TOP 1 LWR.PreFlushDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreFlushDate, " +
                                 " (SELECT TOP 1 LWR.PreVideoDate FROM LFS_WORK_REHABASSESSMENT LWR INNER JOIN LFS_WORK LW ON LWR.WorkID = LW.WorkID WHERE (LW.AssetID = AA.AssetID) AND (LWR.Deleted = 0) ORDER BY LWR.WorkID DESC) AS PreVideoDate, " +
                                 "  (SELECT TOP 1 LWFLL.P1Date FROM LFS_WORK_FULLLENGTHLINING LWFLL INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS P1Date, " +
                                 " LWPR.RepairConfirmationDate, (SELECT TOP 1 LWFM1.TrafficControl FROM LFS_WORK_FULLLENGTHLINING_M1 LWFM1 INNER JOIN LFS_WORK_FULLLENGTHLINING LWFLL ON LWFM1.WorkID = LWFLL.WorkID INNER JOIN LFS_WORK LW ON LWFLL.WorkID = LW.WorkID INNER JOIN LFS_WORK LW2 ON (LW2.AssetID = AA.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW.ProjectID) WHERE (LW.AssetID = AA.AssetID) AND (LWFLL.Deleted = 0) ORDER BY LWFLL.WorkID DESC) AS TrafficControl," +
                                 " (SELECT TOP 1 MaterialType FROM AM_ASSET_SEWER_MATERIAL AASM WHERE (AASM.AssetID = AASS.AssetID) AND (AASM.Deleted = 0) ORDER BY Date_ DESC) AS MaterialType, LWPR.BypassRequired, " +
                                 " CAST(0 AS bit) AS RoboticPrepRequired, " +
                                 " LWPR.RoboticDistances, LWPR.EstimatedJoints, LWPR.JointsTestSealed, LWPR.IssueIdentified, LWPR.IssueLFS, LWPR.IssueClient, LWPR.IssueSales, LWPR.IssueGivenToClient, LWPR.IssueInvestigation, LWPR.IssueResolved, " +
                                 " LWPR.WorkID, '' AS RepairPointID " +
                                 " " +
                                 " FROM LFS_WORK LW INNER JOIN " +
                                 "  AM_ASSET AA ON LW.AssetID = AA.AssetID INNER JOIN " +
                                 "  AM_ASSET_SEWER AAS ON AA.AssetID = AAS.AssetID INNER JOIN " +
                                 "  AM_ASSET_SEWER_SECTION AASS ON AAS.AssetID = AASS.AssetID INNER JOIN " +
                                 "  LFS_ASSET_SEWER_SECTION LASS ON AAS.AssetID = LASS.AssetID INNER JOIN " +
                                 "  LFS_WORK_POINT_REPAIRS LWPR ON LW.WorkID = LWPR.WorkID " +
                                 "                                               " +
                                 " WHERE {0} {1} ORDER BY {2}", where, whereSpecial, orderBy);
                }
            }
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