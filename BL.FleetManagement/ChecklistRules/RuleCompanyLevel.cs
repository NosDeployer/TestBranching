using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleCompanyLevel
    /// </summary>
    public class RuleCompanyLevel : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleCompanyLevel()
            : base("LFS_FM_RULE_COMPANYLEVEL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleCompanyLevel(DataSet data)
            : base(data, "LFS_FM_RULE_COMPANYLEVEL")
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
        /// InsertDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int ruleId, int companyLevelId, bool deleted, int companyId)
        {
            RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(null);
            ruleCompanyLevelGateway.Insert(ruleId, companyLevelId, deleted, companyId);           
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true</returns>
        public bool DeleteDirect(int ruleId, int companyLevelId, int companyId)
        {
            RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(Data);
            ruleCompanyLevelGateway.Delete(ruleId, companyLevelId, companyId);

            return true;
        }



        /// <summary>
        /// UnDeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>true</returns>
        public bool UnDeleteDirect(int ruleId, int companyLevelId, int companyId)
        {
            RuleCompanyLevelGateway ruleCompanyLevelGateway = new RuleCompanyLevelGateway(Data);
            ruleCompanyLevelGateway.UnDelete(ruleId, companyLevelId, companyId);

            return true;
        }



    }
}


