using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewSort
    /// </summary>
    public class FmTypeViewSort : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewSort()
            : base("LFS_FM_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewSort(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_SORT")
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
        /// LoadByFmTypeInView
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inView">inView</param>
        public void LoadByFmTypeInView(string fmType, int companyId, bool inView)
        {
            FmTypeViewSortGateway fmTypeViewSortGateway = new FmTypeViewSortGateway(Data);
            fmTypeViewSortGateway.LoadByFmTypeInView(fmType, companyId, inView);

            UpdateOrder();
        }



        /// <summary>
        /// LoadByFmTypeSortId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void LoadByFmTypeSortId(string fmType, int companyId, int sortId)
        {
            FmTypeViewSortGateway fmTypeViewSortGateway = new FmTypeViewSortGateway(Data);
            fmTypeViewSortGateway.LoadByFmTypeSortId(fmType, companyId, sortId);         
        }

        

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <param name="order">order</param>
        /// <param name="selected">selected</param>
        public void Update(string fmType, int companyId, int sortId, int order, bool selected)
        {
            FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow row = GetRow(fmType, companyId, sortId);
            if (order == 0)
            {
                row.SetOrder_Null();
            }
            else
            {
                row.Order_ = order;
            }
            row.Selected = selected;
        }



        /// <summary>
        /// UpdateForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void UpdateForEdit(int viewId, string fmType, int companyId)
        {
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow row in (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Table)
            {
                if ((row.FmType == fmType) && (row.COMPANY_ID == companyId))
                {
                    FmViewSort fmViewSort = new FmViewSort();
                    fmViewSort.LoadByViewIdFmTypeSortId(viewId, fmType, companyId, row.SortID);
                    FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(fmViewSort.Data);

                    if (fmViewSort.ExistsByViewIDFmTypeCompanyIdSortId(viewId, fmType, companyId, row.SortID))
                    {
                        row.Selected = true;
                        row.Order_ = fmViewSortGateway.GetOrder(viewId, fmType, companyId, row.SortID);
                    }
                    else
                    {
                        row.Selected = false;
                        row.SetOrder_Null();
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns>FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow</returns>
        private FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow GetRow(string fmType, int companyId, int sortId)
        {
            FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow row = ((FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Table).FindByFmTypeCOMPANY_IDSortID(fmType, companyId, sortId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewSort.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateOrder
        /// </summary>
        private void UpdateOrder()
        {
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow row in (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Table)
            {
                row.SetOrder_Null();
            }
        }
        


    }
}