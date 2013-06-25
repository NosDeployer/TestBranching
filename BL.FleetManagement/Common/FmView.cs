using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmView
    /// </summary>
    public class FmView : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmView()
            : base("LFS_FM_VIEW")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmView(DataSet data)
            : base(data, "LFS_FM_VIEW")
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
        /// DeleteDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int viewId, int companyId)
        {
            FmViewDisplay fmViewDisplay = new FmViewDisplay(null);
            fmViewDisplay.DeleteDirect(viewId, companyId);

            FmViewCondition fmViewCondition = new FmViewCondition(null);
            fmViewCondition.DeleteDirect(viewId, companyId);

            FmViewSort fmViewSort = new FmViewSort(null);
            fmViewSort.DeleteDirect(viewId, companyId);

            FmViewGateway fmViewGateway = new FmViewGateway(null);
            fmViewGateway.Delete(viewId, companyId);
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
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newViewID">newViewID</param>
        /// <param name="newLoginId">newLoginId</param>
        /// <param name="newName">newName</param>
        /// <param name="newType">newType</param>
        /// <param name="newLogic">newLogic</param>
        /// <param name="newSqlCommand">newSqlCommand</param>
        /// <param name="newFmType">newFmType</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void UpdateDirect(int originalViewId, int originalLoginId, string originalName, string originalType, string origianlLogic, string originalSqlCommand, string originalFmType, bool originalDeleted, int originalCompanyId, int newViewID, int newLoginId, string newName, string newType, string newLogic, string newSqlCommand, string newFmType, bool newDeleted, int newCompanyId)
        {
            FmViewGateway fmViewGateway = new FmViewGateway(null);
            fmViewGateway.Update(originalViewId, originalLoginId, originalName, originalType, origianlLogic, originalSqlCommand, originalFmType, originalDeleted, originalCompanyId, newViewID, newLoginId, newName, newType, newLogic, newSqlCommand, newFmType, newDeleted, newCompanyId);
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
        /// <param name="fmType">fmType</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int viewId, int loginId, string name, string type, string logic, string sqlCommand, string fmType, bool deleted, int companyId)
        {
            FmViewGateway fmViewGateway = new FmViewGateway(null);
            fmViewGateway.Insert(viewId, loginId, name, type, logic, sqlCommand, fmType, deleted, companyId);
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
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void SaveForEdit(int viewId, int loginId, string name, string type, string logic, string sqlCommand, string fmType, int companyId, string newName, string newType)
        {
            FmViewGateway fmViewGateway = new FmViewGateway();
            fmViewGateway.LoadByViewId(viewId, companyId);

            int originalViewId = viewId;
            int originalLoginId = fmViewGateway.GetLoginId(viewId);
            string originalName = fmViewGateway.GetName(viewId);
            string originalType = fmViewGateway.GetType(viewId);
            string originalLogic = fmViewGateway.GetLogic(viewId);
            string originalSqlCommand = fmViewGateway.GetSqlCommand(viewId);
            string originalFmType = fmViewGateway.GetFmType(viewId);
            bool originalDeleted = fmViewGateway.GetDeleted(viewId);
            int originalCompanyId = fmViewGateway.GetCompanyId(viewId);

            UpdateDirect(originalViewId, originalLoginId, originalName, originalType, originalLogic, originalSqlCommand, originalFmType, originalDeleted, originalCompanyId, viewId, loginId, newName, newType, logic, sqlCommand, fmType, false, companyId);          
        }
        
        
                       
    }
}