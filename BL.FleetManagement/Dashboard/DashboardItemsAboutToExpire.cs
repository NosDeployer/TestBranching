using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardItemsAboutToExpire
    /// </summary>
    public class DashboardItemsAboutToExpire : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardItemsAboutToExpire()
            : base("DashboardItemsAboutToExpire")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardItemsAboutToExpire(DataSet data)
            : base(data, "DashboardItemsAboutToExpire")
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
        /// LoadAllItemsAboutToExpire
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllItemsAboutToExpire(string period, int companyId)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpire(period, companyId);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllItemsAboutToExpireByUnitType(string period, int companyId, string unitType)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByUnitType(period, companyId, unitType);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByCompanyLevelId
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllItemsAboutToExpireByCompanyLevelId(string period, int companyId, int companyLevelId)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByCompanyLevelId(period, companyId, companyLevelId);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllItemsAboutToExpireByCompanyLevelIdUnitType(string period, int companyId, int companyLevelId, string unitType)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByCompanyLevelIdUnitType(period, companyId, companyLevelId, unitType);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberID
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllItemsAboutToExpireByAssignTeamMemberID(string period, int assignTeamMemberId, int companyId)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByAssignTeamMemberID(period, assignTeamMemberId, companyId);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType(string period, int assignTeamMemberId, int companyId, string unitType)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByAssignTeamMemberIDUnitType(period, assignTeamMemberId, companyId, unitType);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId(string period, int assignTeamMemberId, int companyId, int companyLevelId)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelId(period, assignTeamMemberId, companyId, companyLevelId);
        }



        /// <summary>
        /// LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType
        /// </summary>
        /// <param name="period">period</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType(string period, int assignTeamMemberId, int companyId, int companyLevelId, string unitType)
        {
            DashboardItemsAboutToExpireGateway dashboardItemsAboutToExpireGateway = new DashboardItemsAboutToExpireGateway(Data);
            dashboardItemsAboutToExpireGateway.LoadAllItemsAboutToExpireByAssignTeamMemberIDCompanyLevelIdUnitType(period, assignTeamMemberId, companyId, companyLevelId, unitType);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, int companyId, bool selected)
        {
            DashboardTDS.DashboardItemsAboutToExpireRow row = GetRow(serviceId);
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateForDashboard
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardItemsAboutToExpireRow row in (DashboardTDS.DashboardItemsAboutToExpireDataTable)Table)
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
                        row.ItemsAboutToExpireCompleteName = row.ItemsAboutToExpireCompleteName + " - " + ruleName;
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
        /// <returns>DashboardTDS.DashboardItemsAboutToExpireRow</returns>
        private DashboardTDS.DashboardItemsAboutToExpireRow GetRow(int serviceId)
        {
            DashboardTDS.DashboardItemsAboutToExpireRow row = ((DashboardTDS.DashboardItemsAboutToExpireDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardItemsAboutToExpire.GetRow");
            }

            return row;
        }              



    }
}