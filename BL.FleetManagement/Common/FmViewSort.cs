using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewSort
    /// </summary>
    public class FmViewSort : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewSort()
            : base("LFS_FM_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewSort(DataSet data)
            : base(data, "LFS_FM_VIEW_SORT")
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
        /// LoadByViewIdFmTypeSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void LoadByViewIdFmTypeSortId(int viewId,string fmType, int companyId, int sortId)
        {
            FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(Data);
            fmViewSortGateway.LoadByViewIdFmTypeSortId(viewId, fmType, companyId, sortId);
        }



        /// <summary>
        /// LoadAllByViewIdFmTypeSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void LoadAllByViewIdFmTypeSortId(int viewId, string fmType, int companyId, int sortId)
        {
            FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(Data);
            fmViewSortGateway.LoadAllByViewIdFmTypeSortId(viewId, fmType, companyId, sortId);
        }



        /// <summary>
        /// ExistsByViewIDFmTypeCompanyIdSortId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>True if row exists, else False<returns>Obtained row</returns></returns>
        public bool ExistsByViewIDFmTypeCompanyIdSortId(int viewId, string fmType, int companyId, int sortId)
        {
            string filter = string.Format("(ViewID = '{0}') AND (FmType = '{1}') AND (COMPANY_ID = '{2}') AND (SortID = '{3}') ", viewId, fmType, companyId, sortId);

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
            FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(null);
            fmViewSortGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// DeleteDirectForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void DeleteDirectForEditView(int viewId, string fmType, int companyId, int sortId)
        {
            FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(null);
            fmViewSortGateway.DeleteForEditView(viewId, fmType, companyId, sortId);
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <param name="order">order</param>
        /// <param name="deleted">deleted</param>
        public void InsertDirect(int viewId, string fmType, int companyId, int sortId, int order, bool deleted)
        {
            FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(null);
            fmViewSortGateway.Insert(viewId, fmType, sortId, order, deleted, companyId);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalSortId">originalSortId</param>
        /// <param name="originalOrder">originalOrder</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newFmType">newFmType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newSortId">newSortId</param>
        /// <param name="newOrder">newOrder</param>
        /// <param name="newDeleted">newDeleted</param>
        public void UpdateDirect(int originalViewId, string originalFmType, int originalCompanyId, int originalSortId, int originalOrder, bool originalDeleted, int newViewId, string newFmType, int newCompanyId, int newSortId, int newOrder, bool newDeleted)
        {
            FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(null);
            fmViewSortGateway.Update(originalViewId, originalFmType, originalCompanyId, originalSortId, originalOrder, originalDeleted, newViewId, newFmType, newCompanyId, newSortId, newOrder, newDeleted);
        }



    }
}