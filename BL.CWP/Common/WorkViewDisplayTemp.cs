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

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewDisplayTemp
    /// </summary>
    public class WorkViewDisplayTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewDisplayTemp()
            : base("WorkViewDisplayTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewDisplayTemp(DataSet data)
            : base(data, "WorkViewDisplayTemp")
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
        /// <param name="viewId"></param>
        /// <param name="workType"></param>
        /// <param name="companyId"></param>
        /// <param name="displayId"></param>
        /// <param name="selected"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void Insert(int viewId, string workType, int companyId, int displayId, bool selected, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewDisplayTempRow row = ((WorkViewTDS.WorkViewDisplayTempDataTable)Table).NewWorkViewDisplayTempRow();

            row.ViewID = viewId;
            row.WorkType = workType;
            row.COMPANY_ID = companyId;
            row.DisplayID = displayId;
            row.Selected = selected;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;
 
            ((WorkViewTDS.WorkViewDisplayTempDataTable)Table).AddWorkViewDisplayTempRow(row);
        }



        /// <summary>
        /// Process
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="workType"></param>
        /// <param name="companyId"></param>
        public void Process(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow rowViewDisplay in (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Data.Tables["LFS_WORK_TYPE_VIEW_DISPLAY"])
            {
                if (rowViewDisplay.Selected)
                {
                    int displayId = rowViewDisplay.DisplayID;
                    
                    Insert(viewId, workType, companyId, displayId, true, false, false);
                }
            }
        }



        /// <summary>
        /// ProcessForEdit
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="workType"></param>
        /// <param name="companyId"></param>
        public void ProcessForEdit(int viewId, string workType, int companyId)
        {
            foreach (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYRow rowViewDisplay in (WorkViewTDS.LFS_WORK_TYPE_VIEW_DISPLAYDataTable)Data.Tables["LFS_WORK_TYPE_VIEW_DISPLAY"])
            {
                WorkViewDisplay workViewDisplay = new WorkViewDisplay();
                workViewDisplay.LoadAllByViewIdWorkTypeDisplayId(viewId, workType, companyId, rowViewDisplay.DisplayID);
                WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(workViewDisplay.Data);

                if (workViewDisplay.ExistsByViewIDWorkTypeDisplayId(viewId, workType, companyId, rowViewDisplay.DisplayID))
                {
                    if (rowViewDisplay.Selected)
                    {
                        // Set Deleted in 0
                        Insert(viewId, workType, companyId, rowViewDisplay.DisplayID, true, true, false);
                    }
                    else
                    {                        
                        // Set Deleted in 1 
                        Insert(viewId, workType, companyId, rowViewDisplay.DisplayID, false, true, true);
                    }
                }
                else
                {
                    if (rowViewDisplay.Selected)
                    {
                        // Insert
                        Insert(viewId, workType, companyId, rowViewDisplay.DisplayID, true, false, false);
                    }                    
                }
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            foreach (WorkViewTDS.WorkViewDisplayTempRow rowViewDisplay in (WorkViewTDS.WorkViewDisplayTempDataTable)Data.Tables["WorkViewDisplayTemp"])
            {
                if (!rowViewDisplay.Deleted)
                {
                    int displayId = rowViewDisplay.DisplayID;

                    WorkViewDisplay workViewDisplay = new WorkViewDisplay(null);
                    workViewDisplay.InsertDirect(rowViewDisplay.ViewID, rowViewDisplay.WorkType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID, rowViewDisplay.Deleted);                    
                }
            }
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        public void SaveForEdit()
        {
            foreach (WorkViewTDS.WorkViewDisplayTempRow rowViewDisplay in (WorkViewTDS.WorkViewDisplayTempDataTable)Data.Tables["WorkViewDisplayTemp"])
            {
                WorkViewDisplay workViewDisplay = new WorkViewDisplay(null);
                
                if (!rowViewDisplay.Deleted && !rowViewDisplay.InDatabase && rowViewDisplay.Selected)
                {                    
                    workViewDisplay.InsertDirect(rowViewDisplay.ViewID, rowViewDisplay.WorkType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID, rowViewDisplay.Deleted);
                }

                if (!rowViewDisplay.Deleted && rowViewDisplay.InDatabase && rowViewDisplay.Selected)
                {
                    WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway();
                    workViewDisplayGateway.LoadAllByViewIdWorkTypeDisplayId(rowViewDisplay.ViewID, rowViewDisplay.WorkType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID);
                    
                    int originalViewId = rowViewDisplay.ViewID;
                    string originalWorkType = rowViewDisplay.WorkType;
                    int originalCompanyId = rowViewDisplay.COMPANY_ID;
                    int originalDisplayId = rowViewDisplay.DisplayID;
                    bool originalDeleted = workViewDisplayGateway.GetDeleted(rowViewDisplay.ViewID, rowViewDisplay.WorkType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID);

                    workViewDisplay.UpdateDirect(originalViewId, originalWorkType, originalCompanyId, originalDisplayId, originalDeleted, rowViewDisplay.ViewID, rowViewDisplay.WorkType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID, rowViewDisplay.Deleted);

                }

                if (rowViewDisplay.Deleted && rowViewDisplay.InDatabase && !rowViewDisplay.Selected)
                {
                    workViewDisplay.DeleteDirectForEditView(rowViewDisplay.ViewID, rowViewDisplay.WorkType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID);
                }

            }
        }



        /// <summary>
        /// GetColumnsToDisplay
        /// </summary>
        /// <returns></returns>
        public string GetColumnsToDisplay()
        {
            string columnsToDisplay = "";

            foreach (WorkViewTDS.WorkViewDisplayTempRow row in (WorkViewTDS.WorkViewDisplayTempDataTable)Table)
            {
                if (row.Selected)
                {
                    WorkTypeViewDisplay workTypeViewDisplay = new WorkTypeViewDisplay();
                    workTypeViewDisplay.LoadByWorkTypeDisplayId(row.WorkType, row.COMPANY_ID, row.DisplayID);

                    WorkTypeViewDisplayGateway workTypeViewDisplayGateway = new WorkTypeViewDisplayGateway(workTypeViewDisplay.Data);
                    columnsToDisplay = columnsToDisplay + workTypeViewDisplayGateway.GetName(row.WorkType, row.COMPANY_ID, row.DisplayID) + ", ";                    
                }
            }

            if (columnsToDisplay.Length > 2)
            {
                columnsToDisplay = columnsToDisplay.Substring(0, columnsToDisplay.Length - 2);
            }
            
            return columnsToDisplay;
        }
                      

        
    }
}
