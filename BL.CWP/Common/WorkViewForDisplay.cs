using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewForDisplay
    /// </summary>
    public class WorkViewForDisplay : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewForDisplay()
            : base("LFS_WORK_VIEW_FOR_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewForDisplay(DataSet data)
            : base(data, "LFS_WORK_VIEW_FOR_DISPLAY")
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
        /// LoadByWorkTypeInColumnsToDisplay 
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsToDisplay">inColumnsToDisplay</param>
        public void LoadByWorkTypeInColumnsToDisplay(int viewId,string workType, int companyId, bool inColumnsToDisplay)
        {
            WorkViewForDisplayGateway columnsToDisplayGateway = new WorkViewForDisplayGateway(Data);
            columnsToDisplayGateway.LoadByWorkTypeInColumnsToDisplay(workType, companyId, inColumnsToDisplay);
            UpdateInColumnsToDisplay(viewId, companyId);
        }

       

        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="name">name</param>
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>
        public void Update(string workType, string name, int companyId, bool selected)
        {
            //WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYRow row = GetRow(workType, name, companyId);

            //row.Selected = selected;
        }



        /// <summary>
        /// GetColumnsByDefault 
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsByDefault">inColumnsByDefault</param>
        /// <returns>columns by default</returns>
        public string GetColumnsByDefault(string workType, int companyId, bool inColumnsByDefault)
        {
            string columnsByDefault = "";

            //foreach (WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYRow row in (WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYDataTable)Table)
            //{
            //    if ((row.WorkType == workType) && (row.COMPANY_ID == companyId) && (row.InColumnsToDisplayByDefault))
            //    {
            //        columnsByDefault = columnsByDefault + row.Name_ + ", ";
            //    }
            //}

            //columnsByDefault = columnsByDefault.Substring(0, columnsByDefault.Length - 2);

            return columnsByDefault;

        }




 
        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateInColumnsToDisplay
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateInColumnsToDisplay(int viewId, int companyId)
        {
            //WorkViewColumnGateway workViewColumnGatewayForSearch = new WorkViewColumnGateway();
            //workViewColumnGatewayForSearch.LoadByViewIdCompanyId(viewId, companyId);
            
            //foreach (WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYRow row in (WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYDataTable)Table)
            //{
            //    bool existsColumn = workViewColumnGatewayForSearch.ExistsColumnName(viewId,row.Name_,companyId);
            //    row.Selected = existsColumn;
            //    row.Existing = existsColumn;
            //}
        }



        ///// <summary>
        ///// Get a single row. If not exists, raise an exception
        ///// </summary>
        ///// <param name="workType">workType</param>
        ///// <param name="name">name</param>
        ///// <param name="companyId">companyId</param>
        ///// <returns>Row</returns>
        //private WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYRow GetRow(string workType, string name, int companyId)
        //{
        //    WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYRow row = ((WorkViewTDS.LFS_WORK_VIEW_FOR_DISPLAYDataTable)Table).FindByWorkTypeName_COMPANY_ID( workType, name, companyId);

        //    if (row == null)
        //    {
        //        throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.WorkViewForDisplay.GetRow");
        //    }

        //    return row;
        //}





    }
}
