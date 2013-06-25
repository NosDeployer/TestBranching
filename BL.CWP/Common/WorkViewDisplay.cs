using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewDisplay
    /// </summary>
    public class WorkViewDisplay : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewDisplay()
            : base("LFS_WORK_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewDisplay(DataSet data)
            : base(data, "LFS_WORK_VIEW_DISPLAY")
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
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(Data);
            workViewDisplayGateway.LoadByViewIdWorkType(viewId,workType, companyId);
        }



        /// <summary>
        /// LoadAllByViewIdWorkTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void LoadAllByViewIdWorkTypeDisplayId(int viewId, string workType, int companyId, int displayId)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(Data);
            workViewDisplayGateway.LoadAllByViewIdWorkTypeDisplayId(viewId,workType, companyId, displayId);
        }



        /// <summary>
        /// LoadByViewIdWorkTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void LoadByViewIdWorkTypeDisplayId(int viewId, string workType, int companyId, int displayId)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(Data);
            workViewDisplayGateway.LoadByViewIdWorkTypeDisplayId(viewId, workType, companyId, displayId);
        }



        /// <summary>
        /// ExistsByViewIDWorkTypeDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns></returns>
        public bool ExistsByViewIDWorkTypeDisplayId(int viewId, string workType, int companyId, int displayId)
        {
            string filter = string.Format("(ViewID = '{0}') AND (WorkType = '{1}') AND (COMPANY_ID = '{2}') AND (DisplayID = '{3}') ", viewId, workType, companyId, displayId);

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
        /// GetColumnsToDisplayForViews
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>columnsToDisplay</returns>
        public string GetColumnsToDisplayForViews(int viewId, string workType, int companyId)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(Data);
            workViewDisplayGateway.LoadByViewIdWorkType(viewId, workType, companyId);

            string columnsToDisplay = "";

            foreach (WorkViewTDS.LFS_WORK_VIEW_DISPLAYRow row in (WorkViewTDS.LFS_WORK_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.WorkType == workType) && (row.COMPANY_ID == companyId) && (row.ViewID == viewId))
                {
                    WorkTypeViewDisplayGateway workTypeViewDisplayGateway = new WorkTypeViewDisplayGateway();
                    workTypeViewDisplayGateway.LoadByWorkTypeDisplayId(workType, companyId, row.DisplayID);

                    if (row.WorkType == "Junction Lining")
                    {
                        string column = workTypeViewDisplayGateway.GetColumn_(workType, companyId, row.DisplayID);
                        switch (column)
                        {
                            case "USMH":
                                columnsToDisplay = columnsToDisplay + "U_SMH" + ", ";
                                break;

                            case "DSMH":
                                columnsToDisplay = columnsToDisplay + "D_SMH" + ", ";
                                break;

                            case "Address":
                                columnsToDisplay = columnsToDisplay + "MN" + ", ";
                                break;

                            case "NoticeDelivered":
                                columnsToDisplay = columnsToDisplay + "NoticeD_elivered" + ", ";
                                break;

                            default:
                                columnsToDisplay = columnsToDisplay + workTypeViewDisplayGateway.GetColumn_(workType, companyId, row.DisplayID) + ", ";
                                break;
                        }
                    }
                    else
                    {
                        columnsToDisplay = columnsToDisplay + workTypeViewDisplayGateway.GetColumn_(workType, companyId, row.DisplayID) + ", ";
                    }
                }
            }

            columnsToDisplay = columnsToDisplay.Substring(0, columnsToDisplay.Length - 2);

            return columnsToDisplay;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int viewId, int companyId)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(null);
            workViewDisplayGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// DeleteDirectForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void DeleteDirectForEditView(int viewId, string workType, int companyId, int displayId)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(null);
            workViewDisplayGateway.DeleteForEditView(viewId, workType, companyId, displayId);
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="deleted">deleted</param>        
        public void InsertDirect(int viewId, string workType, int companyId, int displayId, bool deleted)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(null);
            workViewDisplayGateway.Insert(viewId, workType, companyId, displayId, deleted);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalWorkType">originalWorkType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDisplayId">originalDisplayId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewId</param>
        /// <param name="newWorkType">newWorkType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDisplayId">newDisplayId</param>
        /// <param name="newDeleted">newDeleted</param>
        public void UpdateDirect(int originalViewId, string originalWorkType, int originalCompanyId, int originalDisplayId, bool originalDeleted, int newViewId, string newWorkType, int newCompanyId, int newDisplayId, bool newDeleted)
        {
            WorkViewDisplayGateway workViewDisplayGateway = new WorkViewDisplayGateway(null);
            workViewDisplayGateway.Update(originalViewId, originalWorkType, originalCompanyId, originalDisplayId, originalDeleted, newViewId, newWorkType, newCompanyId, newDisplayId, newDeleted);
        }



    }
}
