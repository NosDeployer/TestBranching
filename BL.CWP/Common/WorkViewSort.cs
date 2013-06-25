using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewSort
    /// </summary>
    public class WorkViewSort : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewSort()
            : base("LFS_WORK_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewSort(DataSet data)
            : base(data, "LFS_WORK_VIEW_SORT")
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
        /// LoadByViewIdWorkType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByViewIdWorkType(int viewId,string workType, int companyId)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(Data);
            workViewSortGateway.LoadByViewIdWorkType(viewId, workType, companyId);
        }



        /// <summary>
        /// LoadByViewIdWorkTypeSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void LoadByViewIdWorkTypeSortId(int viewId,string workType, int companyId, int sortId)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(Data);
            workViewSortGateway.LoadByViewIdWorkTypeSortId(viewId, workType, companyId, sortId);
        }



        /// <summary>
        /// LoadAllByViewIdWorkTypeSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void LoadAllByViewIdWorkTypeSortId(int viewId, string workType, int companyId, int sortId)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(Data);
            workViewSortGateway.LoadAllByViewIdWorkTypeSortId(viewId, workType, companyId, sortId);
        }



        /// <summary>
        /// ExistsByViewIDWorkTypeCompanyIdSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        public bool ExistsByViewIDWorkTypeCompanyIdSortId(int viewId, string workType, int companyId, int sortId)
        {
            string filter = string.Format("(ViewID = '{0}') AND (WorkType = '{1}') AND (COMPANY_ID = '{2}') AND (SortID = '{3}') ", viewId, workType, companyId, sortId);

            if (Table.Select(filter).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int viewId, int companyId)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(null);
            workViewSortGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// DeleteDirectForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void DeleteDirectForEditView(int viewId, string workType, int companyId, int sortId)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(null);
            workViewSortGateway.DeleteForEditView(viewId, workType, companyId, sortId);
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <param name="order">order</param>
        /// <param name="deleted">deleted</param>
        public void InsertDirect(int viewId, string workType, int companyId, int sortId, int order, bool deleted)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(null);
            workViewSortGateway.Insert(viewId, workType, companyId, sortId, order, deleted);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalSortId">originalSortId</param>
        /// <param name="originalOrder">originalOrder</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newSortId">newSortId</param>
        /// <param name="newOrder">newOrder</param>
        /// <param name="newDeleted">newDeleted</param>
        public void UpdateDirect(int originalViewId, string originalWorkType, int originalCompanyId, int originalSortId, int originalOrder, bool originalDeleted, int newViewId, string newWorkType, int newCompanyId, int newSortId, int newOrder, bool newDeleted)
        {
            WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(null);
            workViewSortGateway.Update(originalViewId, originalWorkType, originalCompanyId, originalSortId, originalOrder, originalDeleted, newViewId, newWorkType, newCompanyId, newSortId, newOrder, newDeleted);
        }

        
        
    }
}

