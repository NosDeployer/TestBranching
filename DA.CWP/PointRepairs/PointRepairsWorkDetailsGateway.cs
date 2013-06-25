using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.PointRepairs
{
    /// <summary>
    /// PointRepairsWorkDetailsGateway
    /// </summary>
    public class PointRepairsWorkDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PointRepairsWorkDetailsGateway()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PointRepairsWorkDetailsGateway(DataSet data)
            : base(data, "WorkDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PointRepairsTDS();
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
            tableMapping.DataSetTable = "WorkDetails";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("WorkIDFLL", "WorkIDFLL");
            tableMapping.ColumnMappings.Add("WorkIDRA", "WorkIDRA");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("RepairConfirmationDate", "RepairConfirmationDate");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("Material", "Material");
            tableMapping.ColumnMappings.Add("BypassRequired", "BypassRequired");
            tableMapping.ColumnMappings.Add("RoboticPrepRequired", "RoboticPrepRequired");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("RoboticDistances", "RoboticDistances");
            tableMapping.ColumnMappings.Add("ProposedLiningDate", "ProposedLiningDate");
            tableMapping.ColumnMappings.Add("DeadlineLiningDate", "DeadlineLiningDate");
            tableMapping.ColumnMappings.Add("FinalVideoDate", "FinalVideoDate");
            tableMapping.ColumnMappings.Add("EstimatedJoints", "EstimatedJoints");
            tableMapping.ColumnMappings.Add("JointsTestSealed", "JointsTestSealed");
            tableMapping.ColumnMappings.Add("IssueIdentified", "IssueIdentified");
            tableMapping.ColumnMappings.Add("IssueLFS", "IssueLFS");
            tableMapping.ColumnMappings.Add("IssueClient", "IssueClient");
            tableMapping.ColumnMappings.Add("IssueSales", "IssueSales");
            tableMapping.ColumnMappings.Add("IssueGivenToClient", "IssueGivenToClient");
            tableMapping.ColumnMappings.Add("IssueResolved", "IssueResolved");
            tableMapping.ColumnMappings.Add("IssueInvestigation", "IssueInvestigation");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("VideoLength", "VideoLength");
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
        /// LoadByWorkIdAssetId
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByWorkIdAssetId(int workId, int assetId,int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_POINTREPAIRSWORKDETAILSGATEWAY_LOADBYWORKIDASSETID", new SqlParameter("@workId", workId), new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("WorkID = {0}", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.PointRepairs.PointRepairsWorkDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetWorkIdFll. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WorkIDFLL or 0</returns>
        public int GetWorkIdFll(int workId)
        {
            if (GetRow(workId).IsNull("WorkIDFLL"))
            {
                return 0;
            }
            else
            {
                return (int)GetRow(workId)["WorkIDFLL"];
            }
        }



        /// <summary>
        /// GetWorkIdFll Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WorkIDFLL or 0</returns>
        public int GetWorkIdFllOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["WorkIDFLL"], DataRowVersion.Original))
            {
                return 0;
            }
            else
            {

                return (int)GetRow(workId)["WorkIDFLL", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetWorkIdRa. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>WorkIDRA or 0</returns>
        public int GetWorkIdRa(int workId)
        {
            if (GetRow(workId).IsNull("WorkIDRA"))
            {
                return 0;
            }
            else
            {
                return (int)GetRow(workId)["WorkIDRA"];
            }
        }



        /// <summary>
        /// GetWorkIdRa Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original WorkIDRA or 0</returns>
        public int GetWorkIdRaOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["WorkIDRA"], DataRowVersion.Original))
            {
                return 0;
            }
            else
            {

                return (int)GetRow(workId)["WorkIDRA", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ClientId or EMPTY</returns>
        public string GetClientId(int workId)
        {
            if (GetRow(workId).IsNull("ClientID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID"];
            }
        }



        /// <summary>
        /// GetClientId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ClientID or EMPTY</returns>
        public string GetClientIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ClientID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenBy(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementTakenBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy"];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenByOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementTakenBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreFlushDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreFlushDate or null</returns>
        public DateTime? GetPreFlushDate(int workId)
        {
            if (GetRow(workId).IsNull("PreFlushDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreFlushDate"];
            }
        }



        /// <summary>
        /// GetPreFlushDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreFlushDate or null</returns>
        public DateTime? GetPreFlushDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreFlushDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreFlushDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreVideoDate or null</returns>
        public DateTime? GetPreVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("PreVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideoDate"];
            }
        }



        /// <summary>
        /// GetPreVideoDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreVideoDate or null</returns>
        public DateTime? GetPreVideoDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideoDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetP1Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>P1 Date or null</returns>
        public DateTime? GetP1Date(int workId)
        {
            if (GetRow(workId).IsNull("P1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date"];
            }
        }



        /// <summary>
        /// GetP1Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original P1Date or null</returns>
        public DateTime? GetP1DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["P1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRepairConfirmationDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RepairConfirmationDate or null</returns>
        public DateTime? GetRepairConfirmationDate(int workId)
        {
            if (GetRow(workId).IsNull("RepairConfirmationDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RepairConfirmationDate"];
            }
        }



        /// <summary>
        /// GeRepairConfirmationDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RepairConfirmationDate or null</returns>
        public DateTime? GetRepairConfirmationDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RepairConfirmationDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RepairConfirmationDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTrafficControl. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControl or EMPTY</returns>
        public string GetTrafficControl(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControl"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl"];
            }
        }



        /// <summary>
        /// GetTrafficControl Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TrafficControl or EMPTY</returns>
        public string GetTrafficControlOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["TrafficControl"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMaterial. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Material or EMPTY</returns>
        public string GetMaterial(int workId)
        {
            if (GetRow(workId).IsNull("Material"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Material"];
            }
        }



        /// <summary>
        /// GetMaterial Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Material or EMPTY</returns>
        public string GetMaterialOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Material"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Material", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBypassRequired. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BypassRequired</returns>
        public bool GetBypassRequired(int workId)
        {
            return (bool)GetRow(workId)["BypassRequired"];
        }



        /// <summary>
        /// GetBypassRequired Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original BypassRequired</returns>
        public bool GetBypassRequiredOriginal(int workId)
        {
            return (bool)GetRow(workId)["BypassRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRoboticPrepRequired. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticPrepRequired</returns>
        public bool GetRoboticPrepRequired(int workId)
        {
            if (GetRow(workId).IsNull("RoboticPrepRequired"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["RoboticPrepRequired"];
            }
        }



        /// <summary>
        /// GetRoboticPrepRequired Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RoboticPrepRequired</returns>
        public bool GetRoboticPrepRequiredOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RoboticPrepRequired"], DataRowVersion.Original))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["RoboticPrepRequired", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCxisRemoved. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CXIsRemoved or null</returns>
        public int? GetCxisRemoved(int workId)
        {
            if (GetRow(workId).IsNull("CXIsRemoved"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CXIsRemoved"];
            }
        }



        /// <summary>
        /// GetCxisRemoved Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CXIsRemoved or null</returns>
        public int? GetCxisRemovedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CXIsRemoved"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CXIsRemoved", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRoboticDistances. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticDistances or EMPTY</returns>
        public string GetRoboticDistances(int workId)
        {
            if (GetRow(workId).IsNull("RoboticDistances"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RoboticDistances"];
            }
        }



        /// <summary>
        /// GetRoboticDistances Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RoboticDistances or EMPTY</returns>
        public string GetRoboticDistancesOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RoboticDistances"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["RoboticDistances", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProposedLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate or null</returns>
        public DateTime? GetProposedLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("ProposedLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate"];
            }
        }



        /// <summary>
        /// GetProposedLiningDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ProposedLiningDate or null</returns>
        public DateTime? GetProposedLiningDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ProposedLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DeadlineLiningDate or null</returns>
        public DateTime? GetDeadlineLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("DeadlineLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate"];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DeadlineLiningDate or null</returns>
        public DateTime? GetDeadlineLiningDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DeadlineLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalVideoDate or null</returns>
        public DateTime? GetFinalVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("FinalVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate"];
            }
        }



        /// <summary>
        /// GetFinalVideoDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original FinalVideoDate or null</returns>
        public DateTime? GetFinalVideoDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["FinalVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate", DataRowVersion.Original];
            }
        }



        // <summary>
        /// GetEstimatedJoints. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>EstimatedJoints or null</returns>
        public int? GetEstimatedJoints(int workId)
        {
            if (GetRow(workId).IsNull("EstimatedJoints"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["EstimatedJoints"];
            }
        }



        /// <summary>
        /// GetEstimatedJoints Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original EstimatedJoints or null</returns>
        public int? GetEstimatedJointsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["EstimatedJoints"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["EstimatedJoints", DataRowVersion.Original];
            }
        }



        // <summary>
        /// GetJointsTestSealed. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>JointsTestSealed or null</returns>
        public int? GetJointsTestSealed(int workId)
        {
            if (GetRow(workId).IsNull("JointsTestSealed"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["JointsTestSealed"];
            }
        }



        /// <summary>
        /// GetJointsTestSealed Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original JointsTestSealed or null</returns>
        public int? GetJointsTestSealedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["JointsTestSealed"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["JointsTestSealed", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIssueIdentified. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueIdentified</returns>
        public bool GetIssueIdentified(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified"];
        }



        /// <summary>
        /// GetIssueIdentified Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueIdentified</returns>
        public bool GetIssueIdentifiedOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueLFS. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueLFS</returns>
        public bool GetIssueLFS(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS"];
        }



        /// <summary>
        /// GetIssueLFS Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueLFS</returns>
        public bool GetIssueLFSOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueClient</returns>
        public bool GetIssueClient(int workId)
        {
            return (bool)GetRow(workId)["IssueClient"];
        }



        /// <summary>
        /// GetIssueClient Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueClient</returns>
        public bool GetIssueClientOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueClient", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueSales. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueSales</returns>
        public bool GetIssueSales(int workId)
        {
            return (bool)GetRow(workId)["IssueSales"];
        }



        /// <summary>
        /// GetIssueSales Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueSales</returns>
        public bool GetIssueSalesOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueSales", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueGivenToClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueGivenToClient</returns>
        public bool GetIssueGivenToClient(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient"];
        }



        /// <summary>
        /// GetIssueGivenToClient Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueGivenToClient</returns>
        public bool GetIssueGivenToClientOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueResolved. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueResolved</returns>
        public bool GetIssueResolved(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved"];
        }



        /// <summary>
        /// GetIssueResolved Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueResolved</returns>
        public bool GetIssueResolvedOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueInvestigation. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueInvestigation</returns>
        public bool GetIssueInvestigation(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation"];
        }



        /// <summary>
        /// GetIssueInvestigation Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueInvestigation</returns>
        public bool GetIssueInvestigationOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId)
        {
            if (GetRow(workId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoLength. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoLength or EMPTY</returns>
        public string GetVideoLength(int workId)
        {
            if (GetRow(workId).IsNull("VideoLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLength"];
            }
        }



        /// <summary>
        /// GetVideoLength Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoLength or EMPTY</returns>
        public string GetVideoLengthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoLength"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoLength", DataRowVersion.Original];
            }
        }



    }
}