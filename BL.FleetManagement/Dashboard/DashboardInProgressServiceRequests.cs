using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Dashboard;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Dashboard
{
    /// <summary>
    /// DashboardInProgressServiceRequests
    /// </summary>
    public class DashboardInProgressServiceRequests : TableModule
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DashboardInProgressServiceRequests()
            : base("DashboardInProgressServiceRequests")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DashboardInProgressServiceRequests(DataSet data)
            : base(data, "DashboardInProgressServiceRequests")
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
        /// LoadInProgressServices
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void LoadInProgressServices(int companyId)
        {
            DashboardInProgressServiceRequestsGateway dashboardInProgressServiceRequestsGateway = new DashboardInProgressServiceRequestsGateway(Data);
            dashboardInProgressServiceRequestsGateway.Table.Clear();
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = false;            
            dashboardInProgressServiceRequestsGateway.LoadServicesByState("Assigned", companyId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByState("Accepted", companyId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByState("Rejected", companyId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByState("In Progress", companyId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByState("Completed", companyId);
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadInProgressServicesByUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="unitType">unitType</param>
        public void LoadInProgressServicesByUnitType(int companyId, string unitType)
        {
            DashboardInProgressServiceRequestsGateway dashboardInProgressServiceRequestsGateway = new DashboardInProgressServiceRequestsGateway(Data);
            dashboardInProgressServiceRequestsGateway.Table.Clear();
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = false;
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateUnitType("Assigned", companyId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateUnitType("Accepted", companyId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateUnitType("Rejected", companyId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateUnitType("In Progress", companyId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateUnitType("Completed", companyId, unitType);
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadInProgressServicesByCompanyLevelId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        public void LoadInProgressServicesByCompanyLevelId(int companyId, int companyLevelId)
        {
            DashboardInProgressServiceRequestsGateway dashboardInProgressServiceRequestsGateway = new DashboardInProgressServiceRequestsGateway(Data);
            dashboardInProgressServiceRequestsGateway.Table.Clear();
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = false;            
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelId("Assigned", companyId, companyLevelId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelId("Accepted", companyId, companyLevelId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelId("Rejected", companyId, companyLevelId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelId("In Progress", companyId, companyLevelId);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelId("Completed", companyId, companyLevelId);
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadInProgressServicesByCompanyLevelIdUnitType
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="unitType">unitType</param>
        public void LoadInProgressServicesByCompanyLevelIdUnitType(int companyId, int companyLevelId, string unitType)
        {
            DashboardInProgressServiceRequestsGateway dashboardInProgressServiceRequestsGateway = new DashboardInProgressServiceRequestsGateway(Data);
            dashboardInProgressServiceRequestsGateway.Table.Clear();
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = false;
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelIdUnitType("Assigned", companyId, companyLevelId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelIdUnitType("Accepted", companyId, companyLevelId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelIdUnitType("Rejected", companyId, companyLevelId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelIdUnitType("In Progress", companyId, companyLevelId, unitType);
            dashboardInProgressServiceRequestsGateway.LoadServicesByStateCompanyLevelIdUnitType("Completed", companyId, companyLevelId, unitType);
            dashboardInProgressServiceRequestsGateway.ClearBeforeFill = true;
        }


        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(int serviceId, int companyId, bool selected)
        {
            DashboardTDS.DashboardInProgressServiceRequestsRow row = GetRow(serviceId);
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateForDashboard
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void UpdateForDashboard(int companyId)
        {
            foreach (DashboardTDS.DashboardInProgressServiceRequestsRow row in (DashboardTDS.DashboardInProgressServiceRequestsDataTable)Table)
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
                        row.InProgressServicesCompleteName = row.InProgressServicesCompleteName + " - " + ruleName;
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
        /// <returns>DashboardTDS.DashboardInProgressServiceRequestsRow</returns>
        private DashboardTDS.DashboardInProgressServiceRequestsRow GetRow(int serviceId)
        {
            DashboardTDS.DashboardInProgressServiceRequestsRow row = ((DashboardTDS.DashboardInProgressServiceRequestsDataTable)Table).FindByServiceID(serviceId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Dashboard.DashboardInProgressServiceRequests.GetRow");
            }

            return row;
        }              



    }
}