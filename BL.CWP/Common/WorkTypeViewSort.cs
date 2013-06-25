using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewSort
    /// </summary>
    public class WorkTypeViewSort : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewSort()
            : base("LFS_WORK_TYPE_VIEW_SORT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewSort(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_SORT")
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
        /// LoadByWorkTypeInView
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inView">inView</param>
        public void LoadByWorkTypeInView(string workType, int companyId, bool inView)
        {
            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway(Data);
            workTypeViewSortGateway.LoadByWorkTypeInView(workType, companyId, inView);

            UpdateOrder();
        }



        /// <summary>
        /// LoadByWorkTypeSortId
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        public void LoadByWorkTypeSortId(string workType, int companyId, int sortId)
        {
            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway(Data);
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, sortId);         
        }

        

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <param name="order">order</param>
        /// <param name="selected">selected</param>
        public void Update(string workType, int companyId, int sortId, int order, bool selected)
        {
            WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow row = GetRow(workType, companyId, sortId);
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
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void UpdateForEdit(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow row in (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Table)
            {
                if ((row.WorkType == workType) && (row.COMPANY_ID == companyId))
                {
                    WorkViewSort workViewSort = new WorkViewSort();
                    workViewSort.LoadByViewIdWorkTypeSortId(viewId, workType, companyId, row.SortID);
                    WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(workViewSort.Data);

                    if (workViewSort.ExistsByViewIDWorkTypeCompanyIdSortId(viewId, workType, companyId, row.SortID))
                    {
                        row.Selected = true;
                        row.Order_ = workViewSortGateway.GetOrder(viewId, workType, companyId, row.SortID);
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
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <returns></returns>
        private WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow GetRow(string workType, int companyId, int sortId)
        {
            WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow row = ((WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Table).FindByWorkTypeCOMPANY_IDSortID(workType, companyId, sortId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewSort.GetRow");
            }

            return row;
        }



        /// <summary>
        /// UpdateOrder
        /// </summary>
        private void UpdateOrder()
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow row in (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Table)
            {
                row.SetOrder_Null();
            }
        }
        


    }
}


