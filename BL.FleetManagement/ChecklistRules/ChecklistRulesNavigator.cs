using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.ChecklistRules;

namespace LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules
{
    /// <summary>
    /// ChecklistRulesNavigator
    /// </summary>
    public class ChecklistRulesNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ChecklistRulesNavigator()
            : base("ChecklistRulesNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ChecklistRulesNavigator(DataSet data)
            : base(data, "ChecklistRulesNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ChecklistRulesNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Load(int companyId)
        {
            ChecklistRulesNavigatorGateway checklistRulesNavigatorGateway = new ChecklistRulesNavigatorGateway(Data);
            checklistRulesNavigatorGateway.Load(companyId);            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <param name="selected">selected</param>
        public void Update(int ruleId, bool selected)
        {
            ChecklistRulesNavigatorTDS.ChecklistRulesNavigatorRow checklistRulesNavigatorRow = GetRow(ruleId);
            checklistRulesNavigatorRow.Selected = selected;            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="ruleId">ruleId</param>
        /// <returns>ChecklistRulesNavigatorRow</returns>
        private ChecklistRulesNavigatorTDS.ChecklistRulesNavigatorRow GetRow(int ruleId)
        {
            ChecklistRulesNavigatorTDS.ChecklistRulesNavigatorRow row = ((ChecklistRulesNavigatorTDS.ChecklistRulesNavigatorDataTable)Table).FindByRuleID(ruleId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.ChecklistRules.ChecklistRulesNavigator.GetRow");
            }

            return row;
        }



    }
}

