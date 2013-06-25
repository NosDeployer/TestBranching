using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewCondition
    /// </summary>
    public class WorkTypeViewCondition : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewCondition()
            : base("LFS_WORK_TYPE_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewCondition(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_CONDITION")
        {
        }
                           


        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new WorkViewTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByWorkTypeConditionId
        /// </summary>
        /// <param name="workType">workType</param>        
        /// <param name="conditionId">conditionId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkTypeConditionId(string workType, int conditionId, int companyId)
        {
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway(Data);
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, conditionId, companyId);           
        }
        


    }
}

