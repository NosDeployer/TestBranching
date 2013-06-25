using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Dashboard
{
    /// <summary>
    /// UnassignedServiceRequestsGateway
    /// </summary>
    public class DashboardUnassignedServiceRequestsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardUnassignedServiceRequestsGateway()
            : base("DashboardUnassignedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardUnassignedServiceRequestsGateway(DataSet data)
            : base(data, "DashboardUnassignedServiceRequests")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
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
            tableMapping.DataSetTable = "DashboardUnassignedServiceRequests";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("UnassignedServicesCompleteName", "UnassignedServicesCompleteName");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
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
        /// LoadAllUnassignedServices
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServices(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICES", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByUnitType(int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByCompanyLevelId(int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberID
        /// </summary>        
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYASSIGNTEAMMEMBERID", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberIDUnitType
        /// </summary>        
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYASSIGNTEAMMEMBERIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId
        /// </summary>        
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYASSIGNTEAMMEMBERIDCOMPANYLEVELID", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyLevelId", companyLevelId));
            return Data;
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>        
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>DataSet</returns>
        public DataSet LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            FillDataWithStoredProcedure("LFS_FM_DASHBOARDUNASSIGNEDSERVICEREQUESTSGATEWAY_LOADALLUNASSIGNEDSERVICESBYASSIGNTEAMMEMBERIDCOMPANYLEVELIDUNITTYPE", new SqlParameter("@companyId", companyId), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@unitType", unitType));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId)
        {
            string filter = string.Format("(ServiceID = {0})", serviceId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Dashboard.DashboardUnassignedServiceRequestsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetUnassignedServicesCompleteName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>UnassignedServicesCompleteName</returns>
        public string GetUnassignedServicesCompleteName(int serviceId)
        {
            return (string)GetRow(serviceId)["UnassignedServicesCompleteName"];
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //
        
        /// <summary>
        /// CountUnassignedServiceRequests
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequests(int companyId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN "+
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN "+
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID "+
                    " WHERE     (LFS.State = 'Unassigned') AND "+
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) ", companyId);

            int  count = (int)ExecuteScalar(commandText);                     
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByUnitType(int companyId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                        " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                        " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                        " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                        " WHERE     (LFS.State = 'Unassigned') AND " +
                        " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.Type = '{1}') ", companyId, unitType);
            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                        " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                        " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                        " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                        " WHERE     (LFS.State = 'Unassigned') AND " +
                        " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFS.MTO = 1) ", companyId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByCompanyLevelId(int companyId, int companyLevelId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {1}) ", companyId, companyLevelId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {1}) AND (LFU.Type = '{2}') ", companyId, companyLevelId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {1}) AND (LFS.MTO = 1)  ", companyId, companyLevelId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequests
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequests(int companyId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND "+
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) ", companyId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByUnitType(int companyId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.Type = '{1}')  ", companyId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFS.MTO = 1)  ", companyId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByCompanyLevelId(int companyId, int companyLevelId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {1}) ", companyId, companyLevelId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {1}) AND (LFU.Type = '{2}') ", companyId, companyLevelId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {1}) AND (LFS.MTO = 1)  ", companyId, companyLevelId);

            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND "+
                    " (LFS.COMPANY_ID = {0})  AND (LFS.AssignTeamMemberID = {1}) AND  "+
                    " (LFS.Deleted = 0) ", companyId, assignTeamMemberId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0})  AND (LFS.AssignTeamMemberID = {1}) AND  " +
                    " (LFS.Deleted = 0) AND (LFU.Type = '{2}')  ", companyId, assignTeamMemberId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0})  AND (LFS.AssignTeamMemberID = {1}) AND  " +
                    " (LFS.Deleted = 0) AND (LFS.MTO = 1) ", companyId, assignTeamMemberId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0})  AND (LFS.AssignTeamMemberID = {1}) AND  " +
                    " (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {2}) ", companyId, assignTeamMemberId, companyLevelId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountUnassignedServiceRequestsByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of unassigned service requests</returns>
        public int CountUnassignedServiceRequestsByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0})  AND (LFS.AssignTeamMemberID = {1}) AND  " +
                    " (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {2}) AND (LFU.Type = '{3}') ", companyId, assignTeamMemberId, companyLevelId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Unassigned') AND " +
                    " (LFS.COMPANY_ID = {0})  AND (LFS.AssignTeamMemberID = {1}) AND  " +
                    " (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {2}) AND (LFS.MTO = 1) ", companyId, assignTeamMemberId, companyLevelId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND  "+
                    " (LFS.COMPANY_ID = {0}) AND (LFS.AssignTeamMemberID = {1}) AND" +
                    " (LFS.Deleted = 0) ", companyId, assignTeamMemberId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND  " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.AssignTeamMemberID = {1}) AND" +
                    " (LFS.Deleted = 0) AND (LFU.Type = '{2}') ", companyId, assignTeamMemberId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND  " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.AssignTeamMemberID = {1}) AND" +
                    " (LFS.Deleted = 0) AND (LFS.MTO = 1) ", companyId, assignTeamMemberId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            string commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND  " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.AssignTeamMemberID = {1}) AND" +
                    " (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {2}) ", companyId, assignTeamMemberId, companyLevelId);

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



        /// <summary>
        /// CountRejectedServiceRequestsByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        /// <returns>amount of rejected service requests</returns>
        public int CountRejectedServiceRequestsByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            string commandText = "";

            if (unitType != "MTO / DOT")
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND  " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.AssignTeamMemberID = {1}) AND" +
                    " (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {2}) AND (LFU.Type = '{3}') ", companyId, assignTeamMemberId, companyLevelId, unitType);

            }
            else
            {
                commandText = String.Format("SELECT COUNT(*) AS NO " +
                    " FROM         LFS_FM_SERVICE LFS INNER JOIN " +
                    " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID LEFT OUTER JOIN " +
                    " LFS_FM_RULE LFRL ON LFS.RuleID = LFRL.RuleID " +
                    " WHERE     (LFS.State = 'Rejected') AND  " +
                    " (LFS.COMPANY_ID = {0}) AND (LFS.AssignTeamMemberID = {1}) AND" +
                    " (LFS.Deleted = 0) AND (LFU.CompanyLevelID = {2}) AND (LFS.MTO = 1) ", companyId, assignTeamMemberId, companyLevelId);
            }

            int count = (int)ExecuteScalar(commandText);
            return count;
        }



    }
}