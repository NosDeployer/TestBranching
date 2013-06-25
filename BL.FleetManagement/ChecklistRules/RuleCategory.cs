using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// RuleCategory
    /// </summary>
    public class RuleCategory : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleCategory()
            : base("LFS_FM_RULE_CATEGORY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleCategory(DataSet data)
            : base(data, "LFS_FM_RULE_CATEGORY")
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
        /// <param name="categoryId">categoryId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int ruleId, int categoryId, bool deleted, int companyId)
        {
            RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(null);
            ruleCategoryGateway.Insert(ruleId, categoryId, deleted, companyId);           
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool DeleteDirect(int ruleId, int categoryId, int companyId)
        {
            RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(Data);
            ruleCategoryGateway.Delete(ruleId, categoryId, companyId);

            return true;
        }



        /// <summary>
        /// UnDeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool UnDeleteDirect(int ruleId, int categoryId, int companyId)
        {
            RuleCategoryGateway ruleCategoryGateway = new RuleCategoryGateway(Data);
            ruleCategoryGateway.UnDelete(ruleId, categoryId, companyId);

            return true;
        }



    }
}