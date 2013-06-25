using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using System.Collections;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewSortTemp
    /// </summary>
    public class WorkViewSortTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewSortTemp()
            : base("WorkViewSortTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewSortTemp(DataSet data)
            : base(data, "WorkViewSortTemp")
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
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="sortId">sortId</param>
        /// <param name="order">order</param>
        /// <param name="selected">selected</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, string workType, int companyId, int sortId, int order, bool selected, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewSortTempRow row = ((WorkViewTDS.WorkViewSortTempDataTable)Table).NewWorkViewSortTempRow();

            row.ViewID = viewId;
            row.WorkType = workType;
            row.COMPANY_ID = companyId;
            row.SortID = sortId;
            row.Order_ = order;
            row.Selected = selected;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;
 
            ((WorkViewTDS.WorkViewSortTempDataTable)Table).AddWorkViewSortTempRow(row);
        }



        /// <summary>
        /// Process
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void Process(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow rowViewSort in (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Data.Tables["LFS_WORK_TYPE_VIEW_SORT"])
            {
                if (rowViewSort.Selected)
                {
                    int sortId = rowViewSort.SortID;
                    int order_ = rowViewSort.Order_;

                    Insert(viewId, workType, companyId, sortId, order_, true, false, false);
                }
            }
        }



        /// <summary>
        /// ProcessForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void ProcessForEdit(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTRow rowViewSort in (WorkViewTDS.LFS_WORK_TYPE_VIEW_SORTDataTable)Data.Tables["LFS_WORK_TYPE_VIEW_SORT"])
            {
                WorkViewSort workViewSort = new WorkViewSort();
                workViewSort.LoadAllByViewIdWorkTypeSortId(viewId, workType, companyId, rowViewSort.SortID);
                WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway(workViewSort.Data);

                if (workViewSort.ExistsByViewIDWorkTypeCompanyIdSortId(viewId, workType, companyId, rowViewSort.SortID))
                {
                    if (rowViewSort.Selected)
                    {
                        Insert(viewId, workType, companyId, rowViewSort.SortID, rowViewSort.Order_, true, true, false);
                    }
                    else
                    {
                        // delete
                        Insert(viewId, workType, companyId, rowViewSort.SortID, 0, false, true, true);
                    }
                }
                else
                {
                    if (rowViewSort.Selected)
                    {
                        Insert(viewId, workType, companyId, rowViewSort.SortID, rowViewSort.Order_, true, false, false);
                    }
                }
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void Save(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.WorkViewSortTempRow rowViewSort in (WorkViewTDS.WorkViewSortTempDataTable)Data.Tables["WorkViewSortTemp"])
            {
                WorkViewSort workViewSort = new WorkViewSort(null);
                workViewSort.InsertDirect(viewId, workType, companyId, rowViewSort.SortID, rowViewSort.Order_, rowViewSort.Deleted);
            }
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        public void SaveForEdit()
        {
            foreach (WorkViewTDS.WorkViewSortTempRow rowViewSort in (WorkViewTDS.WorkViewSortTempDataTable)Data.Tables["WorkViewSortTemp"])
            {
                WorkViewSort workViewSort = new WorkViewSort(null);

                if (!rowViewSort.Deleted && !rowViewSort.InDatabase && rowViewSort.Selected)
                {
                    workViewSort.InsertDirect(rowViewSort.ViewID, rowViewSort.WorkType, rowViewSort.COMPANY_ID, rowViewSort.SortID, rowViewSort.Order_, rowViewSort.Deleted);
                }

                if (!rowViewSort.Deleted && rowViewSort.InDatabase && rowViewSort.Selected)
                {
                    WorkViewSortGateway workViewSortGateway = new WorkViewSortGateway();
                    workViewSortGateway.LoadAllByViewIdWorkTypeSortId(rowViewSort.ViewID, rowViewSort.WorkType, rowViewSort.COMPANY_ID, rowViewSort.SortID);

                    int originalViewId = rowViewSort.ViewID;
                    string originalWorkType = rowViewSort.WorkType;
                    int originalCompanyId = rowViewSort.COMPANY_ID;
                    int originalSortId = rowViewSort.SortID;
                    int originalOrder = workViewSortGateway.GetOrder(rowViewSort.ViewID, rowViewSort.WorkType, rowViewSort.COMPANY_ID, rowViewSort.SortID);
                    bool originalDeleted = workViewSortGateway.GetDeleted(rowViewSort.ViewID, rowViewSort.WorkType, rowViewSort.COMPANY_ID, rowViewSort.SortID);

                    workViewSort.UpdateDirect(originalViewId, originalWorkType, originalCompanyId, originalSortId, originalOrder, originalDeleted, rowViewSort.ViewID, rowViewSort.WorkType, rowViewSort.COMPANY_ID, rowViewSort.SortID, rowViewSort.Order_, rowViewSort.Deleted);
                }

                if (rowViewSort.Deleted && rowViewSort.InDatabase && !rowViewSort.Selected)
                {
                    workViewSort.DeleteDirectForEditView(rowViewSort.ViewID, rowViewSort.WorkType, rowViewSort.COMPANY_ID, rowViewSort.SortID);
                }
            }
        }



        /// <summary>
        /// GetSortForSummary
        /// </summary>
        /// <returns></returns>
        public string GetSortForSummary()
        {
            string sort = "";

            DataRow[] dataRowOrder = Data.Tables["WorkViewSortTemp"].Select("Deleted = 0", "Order_ ASC");
            foreach (DataRow row in dataRowOrder)
            {
                if (!(((WorkViewTDS.WorkViewSortTempRow)row).Deleted))
                {
                    string workType = ((WorkViewTDS.WorkViewSortTempRow)row).WorkType;
                    int companyId = ((WorkViewTDS.WorkViewSortTempRow)row).COMPANY_ID;
                    int sortId = ((WorkViewTDS.WorkViewSortTempRow)row).SortID;

                    WorkTypeViewSort workTypeViewSort = new WorkTypeViewSort();
                    workTypeViewSort.LoadByWorkTypeSortId(workType, companyId, sortId);
                    WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway(workTypeViewSort.Data);

                    sort = sort + workTypeViewSortGateway.GetName(workType, companyId, sortId) + ", ";
                }
            }

            if (sort.Length > 2)
            {
                sort = sort.Substring(0, sort.Length - 2);
            }
            return sort;
        }



        /// <summary>
        /// GetSortForSql
        /// </summary>
        /// <returns></returns>
        public string GetSortForSql()
        {
            string sort = "";

            // process temp table
            DataRow[] dataRowOrder = Data.Tables["WorkViewSortTemp"].Select("Deleted = 0", "Order_ ASC");
            foreach (DataRow row in dataRowOrder)
            {
                if (!(((WorkViewTDS.WorkViewSortTempRow)row).Deleted))
                {
                    int order_ = ((WorkViewTDS.WorkViewSortTempRow)row).Order_;
                    string workType = ((WorkViewTDS.WorkViewSortTempRow)row).WorkType;
                    int companyId = ((WorkViewTDS.WorkViewSortTempRow)row).COMPANY_ID;
                    int sortId = ((WorkViewTDS.WorkViewSortTempRow)row).SortID;

                    WorkTypeViewSort workTypeViewSort = new WorkTypeViewSort();
                    workTypeViewSort.LoadByWorkTypeSortId(workType, companyId, sortId);

                    WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway(workTypeViewSort.Data);

                    string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, sortId);

                    if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
                    if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWF";
                    if (tableName == "LFS_WORK") tableName = "LW";
                    if (tableName == "AM_ASSET_SEWER_LATERAL") tableName = "AASL";
                    if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
                    if (tableName == "LFS_WORK_JUNCTIONLINING_SECTION") tableName = "LWJLS";
                    if (tableName == "LFS_WORK_JUNCTIONLINING_LATERAL") tableName = "LWJLL";
                    if (tableName == "LFS_WORK_REHABASSESSMENT") tableName = "LWR";
                    if (tableName == "LFS_WORK_MANHOLE_REHABILITATION") tableName = "LWMR";
                    if (tableName == "AM_ASSET_SEWER_MH") tableName = "AASMH";
                    
                    sort = sort + tableName  + "." + workTypeViewSortGateway.GetColumn_(workType, companyId, sortId) + ", ";                                        
                }
            }
                        
            sort = sort.Substring(0, sort.Length - 2);
            
            return sort;
        }
                      

        
    }
}