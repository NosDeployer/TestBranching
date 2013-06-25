using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewCondition
    /// </summary>
    public class WorkViewCondition : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewCondition()
            : base("LFS_WORK_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewCondition(DataSet data)
            : base(data, "LFS_WORK_VIEW_CONDITION")
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
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId"></param>
        /// <param name="originalWorkType"></param>
        /// <param name="originalCompanyId"></param>
        /// <param name="originalConditionId"></param>
        /// <param name="originalRefId"></param>
        /// <param name="originalOperator"></param>
        /// <param name="originalConditionNumber"></param>
        /// <param name="originalValue"></param>
        /// <param name="originalDeleted"></param>
        /// <param name="newViewId"></param>
        /// <param name="newWorkType"></param>
        /// <param name="newCompanyId"></param>
        /// <param name="newConditionId"></param>
        /// <param name="newRefId"></param>
        /// <param name="newOperator"></param>
        /// <param name="newConditionNumber"></param>
        /// <param name="newValue_"></param>
        /// <param name="newDeleted"></param>
        public void UpdateDirect(int originalViewId, string originalWorkType, int originalCompanyId, int originalConditionId, int originalRefId, string originalOperator, int originalConditionNumber, string originalValue, bool originalDeleted, int newViewId, string newWorkType, int newCompanyId, int newConditionId, int newRefId, string newOperator, int newConditionNumber, string newValue_, bool newDeleted)
        {
            WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway(null);
            workViewConditionGateway.Update(originalViewId, originalCompanyId, originalWorkType, originalConditionId, originalRefId, originalOperator, originalConditionNumber, originalValue, originalDeleted, newViewId, newCompanyId, newWorkType, newConditionId, newRefId, newOperator, newConditionNumber, newValue_, newDeleted);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int viewId, int companyId)
        {
            WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway(null);
            workViewConditionGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// DeleteDirectForEditView
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="companyId"></param>
        /// <param name="workType"></param>
        /// <param name="conditionId"></param>
        /// <param name="refId"></param>
        public void DeleteDirectForEditView(int viewId, int companyId, string workType, int conditionId, int refId)
        {
            WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway(null);
            workViewConditionGateway.DeleteForEditView(viewId, companyId, workType, conditionId, refId);
        }
        


        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="companyId"></param>
        /// <param name="workType"></param>
        /// <param name="conditionId"></param>
        /// <param name="refId"></param>
        /// <param name="operator_"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="value"></param>
        /// <param name="deleted"></param>
        public void InsertDirect(int viewId, int companyId, string workType, int conditionId, int refId, string operator_, int conditionNumber, string value, bool deleted)
        {
            WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway(null);
            workViewConditionGateway.Insert(viewId, companyId, workType, conditionId, refId, operator_, conditionNumber, value, deleted);
        }          
            
        
 
    }
}
