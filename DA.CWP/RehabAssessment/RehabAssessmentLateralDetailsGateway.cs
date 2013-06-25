using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.RehabAssessment
{
    /// <summary>
    /// RehabAssessmentLateralDetailsGateway
    /// </summary>
    public class RehabAssessmentLateralDetailsGateway :  DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RehabAssessmentLateralDetailsGateway()
            : base("LateralDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RehabAssessmentLateralDetailsGateway(DataSet data)
            : base(data, "LateralDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RehabAssessmentTDS();
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
            tableMapping.DataSetTable = "LateralDetails";
            tableMapping.ColumnMappings.Add("Lateral", "Lateral");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("DistanceToCentre", "DistanceToCentre");
            tableMapping.ColumnMappings.Add("TimeOpened", "TimeOpened");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
            tableMapping.ColumnMappings.Add("Reinstate", "Reinstate");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("LateralID", "LateralID");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("MaterialType", "MaterialType");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InProject", "InProject");
            tableMapping.ColumnMappings.Add("InProjectDatabase", "InProjectDatabase"); 
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Live", "Live");
            tableMapping.ColumnMappings.Add("ToProcess", "ToProcess");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("InFll", "InFll");
            tableMapping.ColumnMappings.Add("InFllDatabase", "InFllDatabase");
            tableMapping.ColumnMappings.Add("InJl", "InJl");
            tableMapping.ColumnMappings.Add("InJlDatabase", "InJlDatabse");
            tableMapping.ColumnMappings.Add("ConnectionType", "ConnectionType");
            tableMapping.ColumnMappings.Add("Mn", "Mn");
            tableMapping.ColumnMappings.Add("ClientInspectionNo", "ClientInspectionNo");
            tableMapping.ColumnMappings.Add("V1Inspection", "V1Inspection");
            tableMapping.ColumnMappings.Add("RequiresRoboticPrep", "RequiresRoboticPrep");
            tableMapping.ColumnMappings.Add("RequiresRoboticPrepDate", "RequiresRoboticPrepDate");
            tableMapping.ColumnMappings.Add("HoldClientIssue", "HoldClientIssue");
            tableMapping.ColumnMappings.Add("HoldLFSIssue", "HoldLFSIssue");
            tableMapping.ColumnMappings.Add("LineLateral", "LineLateral");
            tableMapping.ColumnMappings.Add("Flange", "Flange");
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
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByWorkId(int workId, int companyId)
        {
            string command = string.Format(" SELECT LWFM1L.Lateral, LWFM1L.VideoDistance, LWFM1L.ClockPosition, LWFM1L.DistanceToCentre, " +
                    "  LWFM1L.TimeOpened, LWFM1L.ReverseSetup, LWFM1L.Reinstate, LWFM1L.Comments, 'RA-' + AASL.LateralID AS LateralID , AASL.Size_, AASL.DistanceFromUSMH,  " +
                    "   AASL.DistanceFromDSMH, " +
                    "       (SELECT     TOP 1 MaterialType " +
                    "         FROM          AM_ASSET_SEWER_MATERIAL AASM " +
                    "         WHERE      (AASM.AssetID = AA.AssetID) AND" +
                    "                    (AASM.Deleted = 0) AND (AASM.COMPANY_ID = {1}) " +
                    "         ORDER BY AASM.Date_ DESC) AS MaterialType, LWFM1L.Deleted, " +
                    "   LWFM1L.COMPANY_ID, 1 AS InProject,  1 AS InProjectDatabase, 1 AS InDatabase, AASL.State AS Live,  0 AS ToProcess, LASLC.ClientLateralID, CAST (1 as bit) AS InFll, CAST (1 as bit) AS InFllDatabase, CAST (1 as bit) AS InJl, "+
                    "    CAST (1 as bit) AS InJlDatabase, AASL.ConnectionType, AASL.Address AS Mn, LWFM1L.ClientInspectionNo, LWFM1L.V1Inspection, " +
                    "    LWFM1L.RequiresRoboticPrep, LWFM1L.RequiresRoboticPrepDate, LWFM1L.HoldClientIssue, LWFM1L.HoldLFSIssue, LWFM1L.LineLateral, '' AS Flange, LWFM1L.DyeTestReq, LWFM1L.DyeTestComplete, LWFM1L.ContractYear " +
                    " FROM LFS_WORK_FULLLENGTHLINING_M1_LATERAL LWFM1L INNER JOIN " +
                    "   AM_ASSET AA ON LWFM1L.Lateral = AA.AssetID INNER JOIN " +
                    "   AM_ASSET_SEWER_LATERAL AASL ON AA.AssetID = AASL.AssetID INNER JOIN" +
                    "   LFS_WORK LW ON LWFM1L.WorkID = LW.WorkID INNER JOIN " +
                    "   LFS_PROJECT P ON LW.ProjectID = P.ProjectID LEFT JOIN " +
                    "   LFS_ASSET_SEWER_LATERAL_CLIENT LASLC ON AASL.AssetID = LASLC.AssetID AND P.ClientID = LASLC.ClientID " +
                " WHERE (LWFM1L.WorkID = {0}) AND (LWFM1L.COMPANY_ID = {1})", workId, companyId);
            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadInWorkForEdit
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadInWorkForEdit(int workId, int sectionId, int companyId)
        {
            string command = string.Format("SELECT AASL.AssetID AS Lateral, LWFM1L.VideoDistance, LWFM1L.ClockPosition, LWFM1L.DistanceToCentre, "+
                   "    LWFM1L.TimeOpened, LWFM1L.ReverseSetup, LWFM1L.Reinstate, LWFM1L.Comments, 'RA-' + AASL.LateralID AS LateralID, " +
                   "    AASL.Size_, AASL.DistanceFromUSMH,  AASL.DistanceFromDSMH, "+
                   "         (SELECT TOP 1 MaterialType "+
                   "           FROM  AM_ASSET_SEWER_MATERIAL AASM "+
                   "           WHERE (AASM.AssetID = AASL.AssetID) AND (AASM.Deleted = 0) AND (AASM.COMPANY_ID = {2})  "+
                   "           ORDER BY AASM.Date_ DESC) AS MaterialType, AASL.Deleted,  " +
                   "    AASL.COMPANY_ID, CAST (1 as bit) AS InProject, CAST (1 as bit) AS InProjectDatabase, CAST (1 as bit) AS InDatabase, "+
                   "    AASL.State AS Live, LASLC.ClientLateralID, CAST (1 as bit) AS InFll, CAST (1 as bit) AS InFllDatabase, CAST (0 as bit) AS InJl, "+
                   "    CAST (0 as bit) AS InJlDatabase, AASL.ConnectionType, AASL.Address AS Mn, LWFM1L.ClientInspectionNo, LWFM1L.V1Inspection, " +
                   "    LWFM1L.RequiresRoboticPrep, LWFM1L.RequiresRoboticPrepDate, LWFM1L.HoldClientIssue, LWFM1L.HoldLFSIssue, LWFM1L.LineLateral, '' AS Flange, LWFM1L.DyeTestReq, LWFM1L.DyeTestComplete, LWFM1L.ContractYear" +
                   "  FROM AM_ASSET_SEWER_LATERAL AASL INNER JOIN " +
                   "    LFS_WORK_FULLLENGTHLINING_M1_LATERAL LWFM1L ON AASL.AssetID = LWFM1L.Lateral INNER JOIN "+
                   "    LFS_WORK LW ON LWFM1L.WorkID = LW.WorkID INNER JOIN " +
                   "    LFS_PROJECT P ON LW.ProjectID = P.ProjectID LEFT JOIN " +
                   "    LFS_ASSET_SEWER_LATERAL_CLIENT LASLC ON AASL.AssetID = LASLC.AssetID AND P.ClientID = LASLC.ClientID " +
                   " " +
                   "  WHERE (LWFM1L.WorkID ={0}) AND (AASL.Section_ = {1}) AND (LWFM1L.COMPANY_ID = {2}) AND (LWFM1L.Deleted = 0) AND " +
                   "        (AASL.AssetID NOT IN " +
                   "            ( " +
                   "                SELECT AASL.AssetID " +
                   "                FROM AM_ASSET_SEWER_LATERAL AASL " +
                   "                INNER JOIN LFS_WORK LW ON AASL.AssetID = LW.AssetID " +
                   "                INNER JOIN LFS_WORK_JUNCTIONLINING_LATERAL LWJLL ON LW.WorkID = LWJLL.WorkID " +
                   "                WHERE (AASL.Section_ = {1}) AND (LWJLL.COMPANY_ID = {2}) AND (LWJLL.Deleted = 0)" +
                   "            )" +
                   "        ) ", workId, sectionId, companyId);

            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadInWorkForEdit
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadInWorkInJlForEdit(int workId, int sectionId, int companyId)
        {
            string command = string.Format("SELECT AASL.AssetID AS Lateral, LWFM1L.VideoDistance, LWFM1L.ClockPosition, LWFM1L.DistanceToCentre, " +
                   "    LWFM1L.TimeOpened, LWFM1L.ReverseSetup, LWFM1L.Reinstate, LWFM1L.Comments, 'RA-' + AASL.LateralID AS LateralID, " +
                   "    AASL.Size_, AASL.DistanceFromUSMH,  AASL.DistanceFromDSMH, " +
                   "         (SELECT TOP 1 MaterialType " +
                   "           FROM  AM_ASSET_SEWER_MATERIAL AASM " +
                   "           WHERE (AASM.AssetID = AASL.AssetID) AND (AASM.Deleted = 0) AND (AASM.COMPANY_ID = {2})  " +
                   "           ORDER BY AASM.Date_ DESC) AS MaterialType, AASL.Deleted,  " +
                   "    AASL.COMPANY_ID, CAST (1 as bit) AS InProject, CAST (1 as bit) AS InProjectDatabase, CAST (1 as bit) AS InDatabase, " +
                   "    AASL.State AS Live, LASLC.ClientLateralID, CAST (1 as bit) AS InFll, CAST (1 as bit) AS InFllDatabase, CAST (1 as bit) AS InJl, "+
                   "    CAST (1 as bit) AS InJlDatabase, AASL.ConnectionType, AASL.Address AS Mn, LWFM1L.ClientInspectionNo, LWFM1L.V1Inspection, " +
                   "    LWFM1L.RequiresRoboticPrep, LWFM1L.RequiresRoboticPrepDate, LWFM1L.HoldClientIssue, LWFM1L.HoldLFSIssue, LWFM1L.LineLateral, LWJLL.Flange, LWFM1L.DyeTestReq, LWFM1L.DyeTestComplete, LWFM1L.ContractYear " + 
                   " "+
                   "  FROM AM_ASSET_SEWER_LATERAL AASL INNER JOIN " +
                   "    LFS_WORK_FULLLENGTHLINING_M1_LATERAL LWFM1L ON AASL.AssetID = LWFM1L.Lateral INNER JOIN " +
                   "    LFS_WORK LW ON LWFM1L.WorkID = LW.WorkID INNER JOIN " +
                   "    LFS_PROJECT P ON LW.ProjectID = P.ProjectID LEFT JOIN " +
                   "    LFS_ASSET_SEWER_LATERAL_CLIENT LASLC ON AASL.AssetID = LASLC.AssetID AND P.ClientID = LASLC.ClientID INNER JOIN" +
                   "    LFS_WORK LW2 ON AASL.AssetID = LW2.AssetID AND LW2.Deleted = 0 AND LW2.ProjectID = P.ProjectID INNER JOIN" +
                   "    LFS_WORK_JUNCTIONLINING_LATERAL LWJLL ON LW2.WorkID = LWJLL.WorkID " +
                   " "+
                   "  WHERE (LWFM1L.WorkID ={0}) AND (AASL.Section_ = {1}) AND (LWFM1L.COMPANY_ID = {2}) AND (LWFM1L.Deleted = 0) AND " +
                   "        (AASL.AssetID IN " +
                   "            ( " +
                   "                SELECT AASL.AssetID " +
                   "                FROM AM_ASSET_SEWER_LATERAL AASL " +
                   "                INNER JOIN LFS_WORK LW ON AASL.AssetID = LW.AssetID "+
                   "                INNER JOIN LFS_WORK_JUNCTIONLINING_LATERAL LWJLL2 ON LW.WorkID = LWJLL2.WorkID " +
                   "                WHERE AASL.Section_ = {1} AND LWJLL2.COMPANY_ID = {2} AND (LWJLL2.Deleted = 0)" +
                   "            )" +
                   "        ) ", workId, sectionId, companyId);

            FillData(command);

            return Data;
        }



        /// <summary>
        /// LoadNotInWorkForEdit
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="sectionId"></param>
        /// <param name="companyId">companyId</param>
        /// <param name="projectId">projectId</param>
        /// <returns>Data</returns>
        public DataSet LoadNotInWorkForEdit(int workId, int sectionId, int companyId, int projectId)
        {
            string command = string.Format(
                   "  SELECT distinct AASL.AssetID AS Lateral, '', LWFM1L.VideoDistance, LWFM1L.ClockPosition, LWFM1L.DistanceToCentre, " +
                   "    LWFM1L.TimeOpened, LWFM1L.ReverseSetup, LWFM1L.Reinstate, CAST(LWFM1L.Comments AS VARCHAR(4000)) AS Comments, 'RA-' + AASL.LateralID AS LateralID, AASL.Size_, AASL.DistanceFromUSMH,  " +
                   "     AASL.DistanceFromDSMH, " +
                  "         (SELECT TOP 1 MaterialType " +
                   "           FROM  AM_ASSET_SEWER_MATERIAL AASM " +
                   "           WHERE (AASM.AssetID = AASL.AssetID) AND (AASM.Deleted = 0) AND (AASM.COMPANY_ID = {2})  " +
                   "           ORDER BY AASM.Date_ DESC) AS MaterialType, AASL.Deleted, " +
                   "     AASL.COMPANY_ID, CAST (0 as bit) AS InProject, CAST (0 as bit) AS InProjectDatabase,  CAST (1 as bit) AS InDatabase, " +
                   "     AASL.State AS Live, LASLC.ClientLateralID, CAST (0 as bit) AS InFll, CAST (0 as bit) AS InFllDatabase, CAST (1 as bit) AS InJl, "+
                   "     CAST (1 as bit) AS InJlDatabase, AASL.ConnectionType, AASL.Address AS Mn, LWFM1L.ClientInspectionNo, LWFM1L.V1Inspection, " +
                   "     CAST (0 as bit) AS RequiresRoboticPrep, LWFM1L.RequiresRoboticPrepDate, CAST (0 as bit) AS HoldClientIssue, CAST (0 as bit) AS HoldLFSIssue, CAST (0 as bit) AS LineLateral, LWJLL.Flange, LWFM1L.DyeTestReq, LWFM1L.DyeTestComplete, LWFM1L.ContractYear " +
                   "  FROM AM_ASSET_SEWER_LATERAL AASL INNER JOIN " +
                   "       LFS_WORK LW ON AASL.AssetID = LW.AssetID INNER JOIN " +
                   "       LFS_PROJECT P ON LW.ProjectID = P.ProjectID LEFT JOIN " +
                   "       LFS_ASSET_SEWER_LATERAL_CLIENT LASLC ON AASL.AssetID = LASLC.AssetID AND P.ClientID = LASLC.ClientID LEFT JOIN " +
                   "       LFS_WORK_FULLLENGTHLINING_M1_LATERAL LWFM1L ON AASL.AssetID = LWFM1L.Lateral INNER JOIN "+
                   "       LFS_WORK LW2 ON AASL.AssetID = LW2.AssetID AND LW2.Deleted = 0 AND LW2.ProjectID = P.ProjectID INNER JOIN" +
                   "       LFS_WORK_JUNCTIONLINING_LATERAL LWJLL ON LW2.WorkID = LWJLL.WorkID " +
                   " " +
                   "  WHERE (AASL.Section_ = {1}) AND (AASL.COMPANY_ID = {2}) AND (AASL.Deleted = 0) AND (LW.Deleted = 0) AND " +
                   "        (AASL.AssetID NOT IN " +
                   "            ( " +
                   "                SELECT AASL.AssetID " +
                   "                FROM AM_ASSET_SEWER_LATERAL AASL " +
                   "                INNER JOIN LFS_WORK_FULLLENGTHLINING_M1_LATERAL LWFM1L ON AASL.AssetID = LWFM1L.Lateral " +
                   "                WHERE (AASL.Section_ = {1})  " +
                   "                AND (LWFM1L.WorkID = {0})  AND (LWFM1L.COMPANY_ID = {2}) AND (LWFM1L.Deleted = 0)" +
                   "            )" +
                   "        ) ", workId, sectionId, companyId, projectId);

            FillData(command);

            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int lateral)
        {
            string filter = string.Format("Lateral = {0}", lateral);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.RehabAssessment.RehabAssessmentLateralDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetVideoDistance
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>VideoDistance or EMPTY</returns>
        public string GetVideoDistance(int lateral)
        {
            if (GetRow(lateral).IsNull("VideoDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["VideoDistance"];
            }
        }



        /// <summary>
        /// GetVideoDistance Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original VideoDistance or EMPTY</returns>
        public string GetVideoDistanceOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["VideoDistance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["VideoDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClockPosition
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ClockPosition or EMPTY</returns>
        public string GetClockPosition(int lateral)
        {
            if (GetRow(lateral).IsNull("ClockPosition"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ClockPosition"];
            }
        }



        /// <summary>
        /// GetClockPosition Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original ClockPosition or EMPTY</returns>
        public string GetClockPositionOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["ClockPosition"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ClockPosition", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceToCentre
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>DistanceToCentre or EMPTY</returns>
        public string GetDistanceToCentre(int lateral)
        {
            if (GetRow(lateral).IsNull("DistanceToCentre"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["DistanceToCentre"];
            }
        }



        /// <summary>
        /// GetDistanceToCentre Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original DistanceToCentre or EMPTY</returns>
        public string GetDistanceToCentreOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["DistanceToCentre"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["DistanceToCentre", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTimeOpened
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>TimeOpened or EMPTY</returns>
        public string GetTimeOpened(int lateral)
        {
            if (GetRow(lateral).IsNull("TimeOpened"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["TimeOpened"];
            }
        }



        /// <summary>
        /// GetTimeOpened Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original TimeOpened or EMPTY</returns>
        public string GetTimeOpenedOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["TimeOpened"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["TimeOpened", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetReverseSetup
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ReverseSetup or EMPTY</returns>
        public string GetReverseSetup(int lateral)
        {
            if (GetRow(lateral).IsNull("ReverseSetup"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ReverseSetup"];
            }
        }



        /// <summary>
        /// GetReverseSetup Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original ReverseSetup or EMPTY</returns>
        public string GetReverseSetupOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["ReverseSetup"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ReverseSetup", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetReinstate
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Reinstate or EMPTY</returns>
        public DateTime? GetReinstate(int lateral)
        {
            if (GetRow(lateral).IsNull("Reinstate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["Reinstate"];
            }
        }



        /// <summary>
        /// GetReinstate Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original Reinstate or EMPTY</returns>
        public DateTime? GetReinstateOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["Reinstate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["Reinstate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int lateral)
        {
            if (GetRow(lateral).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLateralID
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>LateralID or EMPTY</returns>
        public string GetLateralID(int lateral)
        {
            if (GetRow(lateral).IsNull("LateralID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["LateralID"];
            }
        }



        /// <summary>
        /// GetLateralID Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original LateralID or EMPTY</returns>
        public string GetLateralIDOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["LateralID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["LateralID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSize
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Size_ or EMPTY</returns>
        public string GetSize(int lateral)
        {
            if (GetRow(lateral).IsNull("Size_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Size_"];
            }
        }



        /// <summary>
        /// GetSize Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original Size_ or EMPTY</returns>
        public string GetSizeOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["Size_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Size_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMH
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>DistanceFromUSMH or EMPTY</returns>
        public string GetDistanceFromUSMH(int lateral)
        {
            if (GetRow(lateral).IsNull("DistanceFromUSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["DistanceFromUSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMH Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original DistanceFromUSMH or EMPTY</returns>
        public string GetDistanceFromUSMHOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["DistanceFromUSMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["DistanceFromUSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMH
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>DistanceFromDSMH or EMPTY</returns>
        public string GetDistanceFromDSMH(int lateral)
        {
            if (GetRow(lateral).IsNull("DistanceFromDSMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["DistanceFromDSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMH Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original DistanceFromDSMH or EMPTY</returns>
        public string GetDistanceFromDSMHOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["DistanceFromDSMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["DistanceFromDSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMaterialType
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>MaterialType or EMPTY</returns>
        public string GetMaterialType(int lateral)
        {
            if (GetRow(lateral).IsNull("MaterialType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["MaterialType"];
            }
        }



        /// <summary>
        /// GetMaterialType Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original MaterialType or EMPTY</returns>
        public string GetMaterialTypeOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["MaterialType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["MaterialType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLive
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Live or EMPTY</returns>
        public string GetLive(int lateral)
        {
            if (GetRow(lateral).IsNull("Live"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Live"];
            }
        }



        /// <summary>
        /// GetLive Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original Live or EMPTY</returns>
        public string GetLiveOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["Live"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Live", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInProject. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>InProject</returns>
        public bool GetInProject(int lateral)
        {
            return (bool)GetRow(lateral)["InProject"];
        }



        /// <summary>
        /// GetInProjectDatabase. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>InProjectDatabase</returns>
        public bool GetInProjectDatabase(int lateral)
        {
            return (bool)GetRow(lateral)["InProjectDatabase"];
        }



        /// <summary>
        /// GetInDatabase. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>InDatabase</returns>
        public bool GetInDatabase(int lateral)
        {
            return (bool)GetRow(lateral)["InDatabase"];
        }



        /// <summary>
        /// GetClientLateralId
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ClientLateralID</returns>
        public string GetClientLateralId(int lateral)
        {
            if (GetRow(lateral).IsNull("ClientLateralID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ClientLateralID"];
            }
        }

        

        /// <summary>
        /// GetClientLateralIdOriginal
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ClientLateralID</returns>
        public string GetClientLateralIdOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["ClientLateralID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ClientLateralID", DataRowVersion.Original];
            }
        }

        

        /// <summary>
        /// GetInFllDatabase. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>InFllDatabase</returns>
        public bool GetInFllDatabase(int lateral)
        {
            return (bool)GetRow(lateral)["InFllDatabase"];
        }



        /// <summary>
        /// GetInJlDatabase. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>InJlDatabase</returns>
        public bool GetInJlDatabase(int lateral)
        {
            return (bool)GetRow(lateral)["InJlDatabase"];
        }



        /// <summary>
        /// GetInPrDatabase. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>InPrDatabase</returns>
        public bool GetInPrDatabase(int lateral)
        {
            return (bool)GetRow(lateral)["InPrDatabase"];
        }



        /// <summary>
        /// GetConnectionType
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ConnectionType or EMPTY</returns>
        public string GetConnectionType(int lateral)
        {
            if (GetRow(lateral).IsNull("ConnectionType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ConnectionType"];
            }
        }



        /// <summary>
        /// GetConnectionType Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original ConnectionType or EMPTY</returns>
        public string GetConnectionTypeOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["ConnectionType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ConnectionType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMn
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Mn or EMPTY</returns>
        public string GetMn(int lateral)
        {
            if (GetRow(lateral).IsNull("Mn"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Mn"];
            }
        }



        /// <summary>
        /// GetMn Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original Mn or EMPTY</returns>
        public string GetMnOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["Mn"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Mn", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientInspectionNo
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ClientInspectionNo or EMPTY</returns>
        public string GetClientInspectionNo(int lateral)
        {
            if (GetRow(lateral).IsNull("ClientInspectionNo"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ClientInspectionNo"];
            }
        }



        /// <summary>
        /// GetClientInspectionNo Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original ClientInspectionNo or EMPTY</returns>
        public string GetClientInspectionNoOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["ClientInspectionNo"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ClientInspectionNo", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetV1Inspection
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>V1Inspection or EMPTY</returns>
        public DateTime? GetV1Inspection(int lateral)
        {
            if (GetRow(lateral).IsNull("V1Inspection"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["V1Inspection"];
            }
        }



        /// <summary>
        /// GetV1Inspection Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original V1Inspection or EMPTY</returns>
        public DateTime? GetV1InspectionOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["V1Inspection"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["V1Inspection", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRequiresRoboticPrep. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>RequiresRoboticPrep</returns>
        public bool GetRequiresRoboticPrep(int lateral)
        {
            return (bool)GetRow(lateral)["RequiresRoboticPrep"];
        }



        /// <summary>
        /// GetRequiresRoboticPrep Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original RequiresRoboticPrep or EMPTY</returns>
        public bool GetRequiresRoboticPrepOriginal(int lateral)
        {
            return (bool)GetRow(lateral)["RequiresRoboticPrep", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRequiresRoboticPrepDate
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>RequiresRoboticPrepDate or EMPTY</returns>
        public DateTime? GetRequiresRoboticPrepDate(int lateral)
        {
            if (GetRow(lateral).IsNull("RequiresRoboticPrepDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["RequiresRoboticPrepDate"];
            }
        }



        /// <summary>
        /// GetRequiresRoboticPrepDate Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original RequiresRoboticPrepDate or EMPTY</returns>
        public DateTime? GetRequiresRoboticPrepDateOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["RequiresRoboticPrepDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["RequiresRoboticPrepDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHoldClientIssue. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>HoldClientIssue</returns>
        public bool GetHoldClientIssue(int lateral)
        {
            return (bool)GetRow(lateral)["HoldClientIssue"];
        }



        /// <summary>
        /// GetHoldClientIssue Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original HoldClientIssue or EMPTY</returns>
        public bool GetHoldClientIssueOriginal(int lateral)
        {
            return (bool)GetRow(lateral)["HoldClientIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHoldLFSIssue. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>HoldLFSIssue</returns>
        public bool GetHoldLFSIssue(int lateral)
        {
            return (bool)GetRow(lateral)["HoldLFSIssue"];
        }



        /// <summary>
        /// GetHoldLFSIssue Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original HoldLFSIssue or EMPTY</returns>
        public bool GetHoldLFSIssueOriginal(int lateral)
        {
            return (bool)GetRow(lateral)["HoldLFSIssue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLineLateral. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>LineLateral</returns>
        public bool GetLineLateral(int lateral)
        {
            return (bool)GetRow(lateral)["LineLateral"];
        }



        /// <summary>
        /// GetLineLateral Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original LineLateral or EMPTY</returns>
        public bool GetLineLateralOriginal(int lateral)
        {
            return (bool)GetRow(lateral)["LineLateral", DataRowVersion.Original];
        }



        /// <summary>
        /// GetFlange
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Flange or EMPTY</returns>
        public string GetFlange(int lateral)
        {
            if (GetRow(lateral).IsNull("Flange"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Flange"];
            }
        }



        /// <summary>
        /// GetFlange Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original Flange or EMPTY</returns>
        public string GetFlangeOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["Flange"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["Flange", DataRowVersion.Original];
            }
        }
        


        /// <summary>
        /// GetDyeTestReq. 
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>DyeTestReq</returns>
        public bool GetDyeTestReq(int lateral)
        {
            return (bool)GetRow(lateral)["DyeTestReq"];
        }



        /// <summary>
        /// GetDyeTestReq Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original DyeTestReq or EMPTY</returns>
        public bool GetDyeTestReqOriginal(int lateral)
        {
            return (bool)GetRow(lateral)["DyeTestReq", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDyeTestComplete
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>DyeTestComplete or EMPTY</returns>
        public DateTime? GetDyeTestComplete(int lateral)
        {
            if (GetRow(lateral).IsNull("DyeTestComplete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["DyeTestComplete"];
            }
        }



        /// <summary>
        /// GetDyeTestComplete Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original DyeTestComplete or EMPTY</returns>
        public DateTime? GetDyeTestCompleteOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["DyeTestComplete"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(lateral)["DyeTestComplete", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetContractYear
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>ContractYear or EMPTY</returns>
        public string GetContractYear(int lateral)
        {
            if (GetRow(lateral).IsNull("ContractYear"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ContractYear"];
            }
        }



        /// <summary>
        /// GetContractYear Original
        /// </summary>
        /// <param name="lateral">lateral</param>
        /// <returns>Original ContractYear or EMPTY</returns>
        public string GetContractYearOriginal(int lateral)
        {
            if (GetRow(lateral).IsNull(Table.Columns["ContractYear"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(lateral)["ContractYear", DataRowVersion.Original];
            }
        }

    }
}