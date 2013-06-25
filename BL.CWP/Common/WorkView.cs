using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkView
    /// </summary>
    public class WorkView : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkView()
            : base("LFS_WORK_VIEW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkView(DataSet data)
            : base(data, "LFS_WORK_VIEW")
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
        /// DeleteDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int viewId, int companyId)
        {
            WorkViewDisplay workViewDisplay = new WorkViewDisplay(null);
            workViewDisplay.DeleteDirect(viewId, companyId);

            WorkViewCondition workViewCondition = new WorkViewCondition(null);
            workViewCondition.DeleteDirect(viewId, companyId);

            WorkViewSort workViewSort = new WorkViewSort(null);
            workViewSort.DeleteDirect(viewId, companyId);

            WorkViewGateway workViewGateway = new WorkViewGateway(null);
            workViewGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalLoginId">originalLoginId</param>
        /// <param name="originalName">originalName</param>
        /// <param name="originalType">originalType</param>
        /// <param name="origianlLogic">origianlLogic</param>
        /// <param name="originalSqlCommand">originalSqlCommand</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newViewID">newViewID</param>
        /// <param name="newLoginId">newLoginId</param>
        /// <param name="newName">newName</param>
        /// <param name="newType">newType</param>
        /// <param name="newLogic">newLogic</param>
        /// <param name="newSqlCommand">newSqlCommand</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalViewId, int originalLoginId, string originalName, string originalType, string origianlLogic, string originalSqlCommand, string originalWorkType, bool originalDeleted, int originalCompanyId, int newViewID, int newLoginId, string newName, string newType, string newLogic, string newSqlCommand, string newWorkType, bool newDeleted, int newCompanyId)
        {
            WorkViewGateway workViewGateway = new WorkViewGateway(null);
            workViewGateway.Update(originalViewId, originalLoginId, originalName, originalType, origianlLogic, originalSqlCommand, originalWorkType, originalDeleted, originalCompanyId, newViewID, newLoginId, newName, newType, newLogic, newSqlCommand, newWorkType, newDeleted, newCompanyId);
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="name">name</param>
        /// <param name="type">type</param>
        /// <param name="logic">logic</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="workType">workType</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int viewId, int loginId, string name, string type, string logic, string sqlCommand, string workType, bool deleted, int companyId)
        {
            WorkViewGateway workViewGateway = new WorkViewGateway(null);
            workViewGateway.Insert(viewId, loginId, name, type, logic, sqlCommand, workType, deleted, companyId);
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="name">name</param>
        /// <param name="type">type</param>
        /// <param name="logic">logic</param>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void SaveForEdit(int viewId, int loginId, string name, string type, string logic, string sqlCommand, string workType, int companyId, string newName, string newType)
        {
            WorkViewGateway workViewGateway = new WorkViewGateway();
            workViewGateway.LoadByViewId(viewId, companyId);

            int originalViewId = viewId;
            int originalLoginId = workViewGateway.GetLoginId(viewId);
            string originalName = workViewGateway.GetName(viewId);
            string originalType = workViewGateway.GetType(viewId);
            string originalLogic = workViewGateway.GetLogic(viewId);
            string originalSqlCommand = workViewGateway.GetSqlCommand(viewId);
            string originalWorkType = workViewGateway.GetWorkType(viewId);
            bool originalDeleted = workViewGateway.GetDeleted(viewId);
            int originalCompanyId = workViewGateway.GetCompanyId(viewId);

            UpdateDirect(originalViewId, originalLoginId, originalName, originalType, originalLogic, originalSqlCommand, originalWorkType, originalDeleted, originalCompanyId, viewId, loginId, newName, newType, logic, sqlCommand, workType, false, companyId);          
        }
        
        
                       
    }
}
