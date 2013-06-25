using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewCondition
    /// </summary>
    public class FmViewCondition : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewCondition()
            : base("LFS_FM_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewCondition(DataSet data)
            : base(data, "LFS_FM_VIEW_CONDITION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FmViewTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalConditionId">originalConditionId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalOperator">originalOperator</param>
        /// <param name="originalConditionNumber">originalConditionNumber</param>
        /// <param name="originalValue">originalValue</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newFmType">newFmType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newConditionId">newConditionId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newOperator">newOperator</param>
        /// <param name="newConditionNumber">newConditionNumber</param>
        /// <param name="newValue_">newValue_</param>
        /// <param name="newDeleted">newDeleted</param>
        public void UpdateDirect(int originalViewId, string originalFmType, int originalCompanyId, int originalConditionId, int originalRefId, string originalOperator, int originalConditionNumber, string originalValue, bool originalDeleted, int newViewId, string newFmType, int newCompanyId, int newConditionId, int newRefId, string newOperator, int newConditionNumber, string newValue_, bool newDeleted)
        {
            FmViewConditionGateway fmViewConditionGateway = new FmViewConditionGateway(null);
            fmViewConditionGateway.Update(originalViewId, originalCompanyId, originalFmType, originalConditionId, originalRefId, originalOperator, originalConditionNumber, originalValue, originalDeleted, newViewId, newCompanyId, newFmType, newConditionId, newRefId, newOperator, newConditionNumber, newValue_, newDeleted);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int viewId, int companyId)
        {
            FmViewConditionGateway fmViewConditionGateway = new FmViewConditionGateway(null);
            fmViewConditionGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// DeleteDirectForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        public void DeleteDirectForEditView(int viewId, int companyId, string fmType, int conditionId, int refId)
        {
            FmViewConditionGateway fmViewConditionGateway = new FmViewConditionGateway(null);
            fmViewConditionGateway.DeleteForEditView(viewId, companyId, fmType, conditionId, refId);
        }
        


        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="value">value</param>
        /// <param name="deleted">deleted</param>
        public void InsertDirect(int viewId, int companyId, string fmType, int conditionId, int refId, string operator_, int conditionNumber, string value, bool deleted)
        {
            FmViewConditionGateway fmViewConditionGateway = new FmViewConditionGateway(null);
            fmViewConditionGateway.Insert(viewId, companyId, fmType, conditionId, refId, operator_, conditionNumber, value, deleted);
        }          
            
        
 
    }
}