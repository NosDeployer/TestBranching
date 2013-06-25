using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// Checklist
    /// </summary>
    public class Checklist : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Checklist()
            : base("LFS_FM_CHECKLIST")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Checklist(DataSet data)
            : base(data, "LFS_FM_CHECKLIST")
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
        /// <param name="unitId">unitId</param>
        /// <param name="ruleId">ruleId</param>
        /// <param name="lastService">lastService</param>
        /// <param name="nextDue">nextDue</param>
        /// <param name="done">done</param>
        /// <param name="state">state</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int unitId, int ruleId, DateTime? lastService, DateTime? nextDue, bool done, string state, bool deleted, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.Insert(unitId, ruleId, lastService, nextDue, done, state, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalRuleId">originalRuleId</param>
        /// <param name="originalLastService">originalLastService</param>
        /// <param name="originalNextDue">originalNextDue</param>
        /// <param name="originalDone">originalDone</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newRuleId">newRuleId</param>
        /// <param name="newLastService">newLastService</param>
        /// <param name="newNextDue">newNextDue</param>
        /// <param name="newDone">newDone</param>
        /// <param name="newState">newState</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalUnitId, int originalRuleId, DateTime? originalLastService, DateTime? originalNextDue, bool originalDone, string originalState, bool originalDeleted, int originalCompanyId, int newUnitId, int newRuleId, DateTime? newLastService, DateTime? newNextDue, bool newDone, string newState, bool newDeleted, int newCompanyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.Update(originalUnitId, originalRuleId, originalLastService, originalNextDue, originalDone, originalState, originalDeleted, originalCompanyId, newUnitId, newRuleId, newLastService, newNextDue, newDone, newState, newDeleted, newCompanyId);
        }



        /// <summary>
        /// UpdateStateDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="newState">newState</param>
        public void UpdateStateDirect(int ruleId, int unitId, int companyId, string newState)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.UpdateState(ruleId, unitId, companyId, newState);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirect(int ruleId, int unitId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.Delete(ruleId, unitId, companyId);

            return true;
        }



        /// <summary>
        /// DeleteDirectByRuleId
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirectByRuleId(int ruleId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.DeleteByRuleId(ruleId, companyId);

            return true;
        }



        /// <summary>
        /// DeleteDirectByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public bool DeleteDirectByUnitId(int unitId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.DeleteByUnitId(unitId, companyId);

            return true;
        }



        /// <summary>
        /// UnDeleteDirect
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        public bool UnDeleteDirect(int ruleId, int unitId, int companyId)
        {
            ChecklistGateway checklistGateway = new ChecklistGateway(null);
            checklistGateway.UnDelete(ruleId, unitId, companyId);

            return true;
        }



    }
}