using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewColumn
    /// </summary>
    public class WorkViewColumn : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewColumn()
            : base("LFS_WORK_VIEW_COLUMN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewColumn(DataSet data)
            : base(data, "LFS_WORK_VIEW_COLUMN")
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
        /// Insert a columns to be displayed
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="name">name</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <returns>viewId</returns>
        public void Insert(int viewId, string name, bool deleted, int companyId)
        {
            //WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row = ((WorkViewTDS.LFS_WORK_VIEW_COLUMNDataTable)Table).NewLFS_WORK_VIEW_COLUMNRow();

            //row.ViewID = viewId;
            //row.RefID = GetNewRefId();
            //row.Name = name;
            //row.Deleted = deleted;
            //row.COMPANY_ID = companyId;

            //((WorkViewTDS.LFS_WORK_VIEW_COLUMNDataTable)Table).AddLFS_WORK_VIEW_COLUMNRow(row);
        }



        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="refId">refId</param>
        /// <param name="name">name</param>
        /// <param name="deleted">deleted</param>
        public void Update(int viewId, int refId, string name, bool deleted)
        {
            //WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row = GetRow(viewId, refId);

            //row.Name = name;
            //row.Deleted = deleted;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="viewId">viewId</param>
        public void Delete(int viewId)
        {
            //foreach (WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row in (WorkViewTDS.LFS_WORK_VIEW_COLUMNDataTable)Table)
            //{
            //    if (row.ViewID == viewId)
            //    {
            //        row.Deleted = true;
            //    }
            //}
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="refId">refId</param>
        public void Delete(int viewId, int refId)
        {
            //WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row = GetRow(viewId, refId);
            //row.Deleted = true;
        }



        /// <summary>
        /// GetColumnsToDisplay
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>columnsToDisplay</returns>
        public string GetColumnsToDisplay(int viewId, int companyId)
        {
            string columnsToDisplay = "";

            //foreach (WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row in (WorkViewTDS.LFS_WORK_VIEW_COLUMNDataTable)Table)
            //{
            //    if ((row.ViewID == viewId) && (row.COMPANY_ID == companyId))
            //    {
            //        columnsToDisplay = columnsToDisplay + row.Name + ", ";
            //    }
            //}

            //columnsToDisplay = columnsToDisplay.Substring(0, columnsToDisplay.Length - 2);

            return columnsToDisplay;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //


        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="refId">refId</param>
        /// <returns>Row</returns>
        //private WorkViewTDS.LFS_WORK_VIEW_COLUMNRow GetRow(int viewId, int refId)
        //{
        //    //WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row = ((WorkViewTDS.LFS_WORK_VIEW_COLUMNDataTable)Table).FindByViewIDRefID(viewId,refId);

        //    //if (row == null)
        //    //{
        //    //    throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.WorkViewColumn.GetRow");
        //    //}

        //    //return row;
        //}



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            //foreach (WorkViewTDS.LFS_WORK_VIEW_COLUMNRow row in (WorkViewTDS.LFS_WORK_VIEW_COLUMNDataTable)Table)
            //{
            //    if (newRefId < row.RefID)
            //    {
            //        newRefId = row.RefID;
            //    }
            //}

            //newRefId++;

            return newRefId;
        }

    }
}
