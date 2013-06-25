using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// UnassignedServiceRequest
    /// </summary>
    public class DashboardExpiredServiceRequests : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardExpiredServiceRequests()
            : base("DashboardExpiredServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardExpiredServiceRequests(DataSet data)
            : base(data, "DashboardExpiredServiceRequests")
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
        /// LoadAllExpiredItems
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadAllExpiredItems(int companyId)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItems(companyId);
        }



        /// <summary>
        /// LoadAllExpiredItemsByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllExpiredItemsByUnitType(int companyId, string unitType)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByUnitType(companyId, unitType);
        }



        /// <summary>
        /// LoadAllExpiredItemsByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllExpiredItemsByCompanyLevelId(int companyId, int companyLevelId)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByCompanyLevelId(companyId, companyLevelId);
        }



        /// <summary>
        /// LoadAllExpiredItemsByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllExpiredItemsByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByCompanyLevelIdUnitType(companyId, companyLevelId, unitType);
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllExpiredItemsByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByAssignTeamMemberID(assignTeamMemberId, companyId);
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllExpiredItemsByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByAssignTeamMemberIDUnitType(assignTeamMemberId, companyId, unitType);
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelId(assignTeamMemberId, companyId, companyLevelId);
        }



        /// <summary>
        /// LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            DashboardExpiredServiceRequestsGateway dashboardExpiredServiceRequestsGateway = new DashboardExpiredServiceRequestsGateway(Data);
            dashboardExpiredServiceRequestsGateway.LoadAllExpiredItemsByAssignTeamMemberIDCompanyLevelIdUnitType(assignTeamMemberId, companyId, companyLevelId, unitType);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, int companyId, bool selected)
        {
            DashboardTDS.DashboardExpiredServiceRequestsRow row = GetRow(serviceId);
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateForDashboard
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardExpiredServiceRequestsRow row in (DashboardTDS.DashboardExpiredServiceRequestsDataTable)Table)
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
                        row.ExpiredServicesCompleteName = row.ExpiredServicesCompleteName + " - " + ruleName;
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
        /// <returns>DashboardTDS.DashboardExpiredServiceRequestsRow</returns>
        private DashboardTDS.DashboardExpiredServiceRequestsRow GetRow(int serviceId)
        {
            DashboardTDS.DashboardExpiredServiceRequestsRow row = ((DashboardTDS.DashboardExpiredServiceRequestsDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardExpiredServiceRequests.GetRow");
            }

            return row;
        }              



    }
}