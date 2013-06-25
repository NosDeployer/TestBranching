using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardUnassignedServiceRequests
    /// </summary>
    public class DashboardUnassignedServiceRequests : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardUnassignedServiceRequests()
            : base("DashboardUnassignedServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardUnassignedServiceRequests(DataSet data)
            : base(data, "DashboardUnassignedServiceRequests")
        {
        }
                           


        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllUnassignedServices
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAllUnassignedServices(int companyId)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServices(companyId);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllUnassignedServicesByUnitType(int companyId, string unitType)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByUnitType(companyId, unitType);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllUnassignedServicesByCompanyLevelId(int companyId,int companyLevelId)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByCompanyLevelId(companyId, companyLevelId);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllUnassignedServicesByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByCompanyLevelIdUnitType(companyId, companyLevelId, unitType);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllUnassignedServicesByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByAssignTeamMemberID(companyId, assignTeamMemberId);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllUnassignedServicesByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByAssignTeamMemberIDUnitType(companyId, assignTeamMemberId, unitType);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelId(companyId, assignTeamMemberId, companyLevelId);
        }



        /// <summary>
        /// LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            DashboardUnassignedServiceRequestsGateway dashboardUnassignedServiceRequestsGateway = new DashboardUnassignedServiceRequestsGateway(Data);
            dashboardUnassignedServiceRequestsGateway.LoadAllUnassignedServicesByAssignTeamMemberIDCompanyLevelIdUnitType(companyId, assignTeamMemberId, companyLevelId, unitType);
        }
        


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, int companyId, bool selected)
        {
            DashboardTDS.DashboardUnassignedServiceRequestsRow row = GetRow(serviceId);
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateForDashboard
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardUnassignedServiceRequestsRow row in (DashboardTDS.DashboardUnassignedServiceRequestsDataTable)Table)
            {
                // Get ruleId for the each service
                ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway();
                serviceInformationBasicInformationGateway.LoadByServiceId(row.ServiceID, companyId);
                int? ruleId = serviceInformationBasicInformationGateway.GetRuleId(row.ServiceID);

                if (ruleId.HasValue)
                {
                    RuleGateway ruleGateway = new RuleGateway();
                    ruleGateway.LoadAllByRuleId((int)ruleId, companyId);

                    if (ruleGateway.Table.Rows.Count > 0)
                    {
                        // Get ruleName for each service if exists
                        string ruleName = ruleGateway.GetName((int)ruleId);
                        row.UnassignedServicesCompleteName = row.UnassignedServicesCompleteName + " - " + ruleName;
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <returns>DashboardTDS.DashboardUnassignedServiceRequestsRow</returns>
        private DashboardTDS.DashboardUnassignedServiceRequestsRow GetRow(int serviceId)
        {
            DashboardTDS.DashboardUnassignedServiceRequestsRow row = ((DashboardTDS.DashboardUnassignedServiceRequestsDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardUnassignedServiceRequests.GetRow");
            }

            return row;
        }              



    }
}