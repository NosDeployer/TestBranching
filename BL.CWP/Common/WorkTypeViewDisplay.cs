using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkTypeViewDisplay
    /// </summary>
    public class WorkTypeViewDisplay : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkTypeViewDisplay()
            : base("LFS_WORK_TYPE_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkTypeViewDisplay(DataSet data)
            : base(data, "LFS_WORK_TYPE_VIEW_DISPLAY")
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
        /// LoadByWorkType
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByWorkType(string workType, int companyId)
        {
            WorkTypeViewDisplayGateway columnsToDisplayGateway = new WorkTypeViewDisplayGateway(Data);
            columnsToDisplayGateway.LoadByWorkType(workType, companyId);           
        }



        /// <summary>
        /// LoadByWorkTypeDisplayId
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void LoadByWorkTypeDisplayId(string workType, int companyId, int displayId)
        {
            WorkTypeViewDisplayGateway columnsToDisplayGateway = new WorkTypeViewDisplayGateway(Data);
            columnsToDisplayGateway.LoadByWorkTypeDisplayId(workType, companyId, displayId);           
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="selected">selected</param>
        public void Update(string workType, int companyId, int displayId, bool selected)
        {
            WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow row = GetRow(workType, companyId, displayId);
            row.Selected = selected;
        }



        /// <summary>
        /// GetColumnsByDefault
        /// </summary>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsByDefault">inColumnsByDefault</param>
        /// <returns></returns>
        public string GetColumnsByDefault(string workType, int companyId, bool inColumnsByDefault)
        {
            WorkTypeViewDisplayGateway workTypeViewDisplayGateway = new WorkTypeViewDisplayGateway(Data);
            workTypeViewDisplayGateway.LoadByWorkTypeInColumnsByDefault(workType, companyId, inColumnsByDefault);
            
            string columnsByDefault = "";

            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow row in (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.WorkType == workType) && (row.COMPANY_ID == companyId) && (row.Always))
                {
                    columnsByDefault = columnsByDefault + row.Column_ + ", ";
                }
            }

            columnsByDefault = columnsByDefault.Substring(0, columnsByDefault.Length - 2);

            return columnsByDefault;
        }
        


        /// <summary>
        /// UpdateForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void UpdateForEdit(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow row in (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.WorkType == workType) && (row.COMPANY_ID == companyId))
                {
                    WorkViewDisplay workViewDisplay = new WorkViewDisplay();
                    workViewDisplay.LoadByViewIdWorkTypeDisplayId(viewId, workType, companyId, row.DisplayID);

                    if (workViewDisplay.ExistsByViewIDWorkTypeDisplayId(viewId, workType, companyId, row.DisplayID))
                    {
                        row.Selected = true;
                    }
                    else
                    {
                        row.Selected = false;
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
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        private WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow GetRow(string workType, int companyId, int displayId)
        {
            WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow row = ((WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Table).FindByWorkTypeCOMPANY_IDDisplayID(workType, companyId, displayId );

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.WorkTypeViewDisplay.GetRow");
            }

            return row;
        }              



    }
}
