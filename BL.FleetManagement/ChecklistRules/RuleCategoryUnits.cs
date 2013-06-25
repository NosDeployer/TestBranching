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
    public class RuleCategoryUnits : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RuleCategoryUnits()
            : base("LFS_FM_RULE_CATEGORY_UNITS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RuleCategoryUnits(DataSet data)
            : base(data, "LFS_FM_RULE_CATEGORY_UNITS")
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
        /// <param name="unitId">unitId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int ruleId, int categoryId, int unitId, bool deleted, int companyId)
        {
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(null);
            ruleCategoryUnitsGateway.Insert(ruleId, categoryId, unitId, deleted, companyId);           
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool DeleteDirect(int ruleId, int categoryId, int unitId, int companyId)
        {
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(Data);
            ruleCategoryUnitsGateway.Delete(ruleId, categoryId, unitId,companyId);

            return true;
        }



        /// <summary>
        /// DeleteDirectByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool DeleteDirectByRuleId(int ruleId, int companyId)
        {
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(Data);
            ruleCategoryUnitsGateway.DeleteByRuleId(ruleId, companyId);

            return true;
        }


        /// <summary>
        /// DeleteDirectByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool DeleteDirectByRuleIdCategoryId(int ruleId, int categoryId, int companyId)
        {
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(Data);
            ruleCategoryUnitsGateway.DeleteByRuleIdCategoryId(ruleId, categoryId, companyId);

            return true;
        }



        /// <summary>
        /// UnDeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="categoryId">categoryId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>True</returns>
        public bool UnDeleteDirect(int ruleId, int categoryId, int unitId, int companyId)
        {
            RuleCategoryUnitsGateway ruleCategoryUnitsGateway = new RuleCategoryUnitsGateway(Data);
            ruleCategoryUnitsGateway.UnDelete(ruleId, categoryId, unitId, companyId);

            return true;
        }

    }
}
