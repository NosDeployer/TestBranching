using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardMyServiceRequests
    /// </summary>
    public class DashboardMyServiceRequests : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardMyServiceRequests()
            : base("DashboardMyServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardMyServiceRequests(DataSet data)
            : base(data, "DashboardMyServiceRequests")
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
        /// LoadMyServicesByAssignTeamMemberID
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadMyServicesByAssignTeamMemberID(int assignTeamMemberId, int companyId)
        {
            DashboardMyServiceRequestsGateway dashboardMyServiceRequestsGateway = new DashboardMyServiceRequestsGateway(Data);
            dashboardMyServiceRequestsGateway.Table.Clear();
            dashboardMyServiceRequestsGateway.ClearBeforeFill = false;            
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberID("Assigned",assignTeamMemberId, companyId);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberID("Accepted", assignTeamMemberId, companyId);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberID("In Progress", assignTeamMemberId, companyId);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberID("Completed", assignTeamMemberId, companyId);
            dashboardMyServiceRequestsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadMyServicesByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadMyServicesByAssignTeamMemberIDUnitType(int assignTeamMemberId, int companyId, string unitType)
        {
            DashboardMyServiceRequestsGateway dashboardMyServiceRequestsGateway = new DashboardMyServiceRequestsGateway(Data);
            dashboardMyServiceRequestsGateway.Table.Clear();
            dashboardMyServiceRequestsGateway.ClearBeforeFill = false;
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDUnitType("Assigned", assignTeamMemberId, companyId, unitType);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDUnitType("Accepted", assignTeamMemberId, companyId, unitType);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDUnitType("In Progress", assignTeamMemberId, companyId, unitType);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDUnitType("Completed", assignTeamMemberId, companyId, unitType);
            dashboardMyServiceRequestsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadMyServicesByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadMyServicesByAssignTeamMemberIDCompanyLevelId(int assignTeamMemberId, int companyId, int companyLevelId)
        {
            DashboardMyServiceRequestsGateway dashboardMyServiceRequestsGateway = new DashboardMyServiceRequestsGateway(Data);
            dashboardMyServiceRequestsGateway.Table.Clear();
            dashboardMyServiceRequestsGateway.ClearBeforeFill = false;
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId("Assigned", assignTeamMemberId, companyId, companyLevelId);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId("Accepted", assignTeamMemberId, companyId, companyLevelId);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId("In Progress", assignTeamMemberId, companyId, companyLevelId);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelId("Completed", assignTeamMemberId, companyId, companyLevelId);
            dashboardMyServiceRequestsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadMyServicesByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadMyServicesByAssignTeamMemberIDCompanyLevelIdUnitType(int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            DashboardMyServiceRequestsGateway dashboardMyServiceRequestsGateway = new DashboardMyServiceRequestsGateway(Data);
            dashboardMyServiceRequestsGateway.Table.Clear();
            dashboardMyServiceRequestsGateway.ClearBeforeFill = false;
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelIdUnitType("Assigned", assignTeamMemberId, companyId, companyLevelId, unitType);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelIdUnitType("Accepted", assignTeamMemberId, companyId, companyLevelId, unitType);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelIdUnitType("In Progress", assignTeamMemberId, companyId, companyLevelId, unitType);
            dashboardMyServiceRequestsGateway.LoadMyServicesByStateAssignTeamMemberIDCompanyLevelIdUnitType("Completed", assignTeamMemberId, companyId, companyLevelId, unitType);
            dashboardMyServiceRequestsGateway.ClearBeforeFill = true;
        }

        

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, int companyId, bool selected)
        {
            DashboardTDS.DashboardMyServiceRequestsRow row = GetRow(serviceId);
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateForDashboard
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardMyServiceRequestsRow row in (DashboardTDS.DashboardMyServiceRequestsDataTable)Table)
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
                        row.MyServicesCompleteName = row.MyServicesCompleteName + " - " + ruleName;
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
        /// <returns>DashboardTDS.DashboardMyServiceRequestsRow</returns>
        private DashboardTDS.DashboardMyServiceRequestsRow GetRow(int serviceId)
        {
            DashboardTDS.DashboardMyServiceRequestsRow row = ((DashboardTDS.DashboardMyServiceRequestsDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardMyServiceRequests.GetRow");
            }

            return row;
        }              



    }
}