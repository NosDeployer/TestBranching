using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// Rule
    /// </summary>
    public class Rule : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Rule()
            : base("LFS_FM_RULE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Rule(DataSet data)
            : base(data, "LFS_FM_RULE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RuleTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByRuleId(int ruleId, int companyId)
        {
            RuleGateway ruleGateway = new RuleGateway(Data);
            ruleGateway.LoadByRuleId(ruleId, companyId);            
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="mto">mto</param>
        /// <param name="frequency">frequency</param>
        /// <param name="alarm">alarm</param>
        /// <param name="alarmDays">alarmDays</param>
        /// <param name="serviceRequest">serviceRequest</param>
        /// <param name="serviceRequestDays">serviceRequestDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>RuleID</returns>
        public int InsertDirect(string name, string description, bool mto, string frequency, bool alarm, int? alarmDays, bool serviceRequest, int? serviceRequestDays, bool deleted, int companyId)
        {
            RuleGateway ruleGateway = new RuleGateway(null);
            int ruleId = ruleGateway.Insert(name, description, mto, frequency, alarm, alarmDays, serviceRequest, serviceRequestDays, deleted, companyId);

            return ruleId;
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="name">name</param>
        /// <param name="description">description</param>
        /// <param name="mto">mto</param>
        /// <param name="frequency">frequency</param>
        /// <param name="alarm">alarm</param>
        /// <param name="alarmDays">alarmDays</param>
        /// <param name="serviceRequest">serviceRequest</param>
        /// <param name="serviceRequestDays">serviceRequestDays</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void UpdateDirect(int ruleId, string name, string description, bool mto, string frequency, bool alarm, int? alarmDays, bool serviceRequest, int? serviceRequestDays, bool deleted, int companyId)
        {
            RuleGateway ruleGateway = new RuleGateway(null);
            ruleGateway.Update(ruleId, name, description, mto, frequency, alarm, alarmDays, serviceRequest, serviceRequestDays, deleted, companyId);            
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool DeleteDirect(int ruleId, int companyId)
        {
            RuleGateway ruleGateway = new RuleGateway(Data);
            ruleGateway.Delete(ruleId, companyId);

            return true;
        }



    }
}