using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewDisplayTemp
    /// </summary>
    public class FmViewDisplayTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewDisplayTemp()
            : base("FmViewDisplayTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewDisplayTemp(DataSet data)
            : base(data, "FmViewDisplayTemp")
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
        /// Insert
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="selected">selected</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, string fmType, int companyId, int displayId, bool selected, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewDisplayTempRow row = ((FmViewTDS.FmViewDisplayTempDataTable)Table).NewFmViewDisplayTempRow();

            row.ViewID = viewId;
            row.FmType = fmType;
            row.COMPANY_ID = companyId;
            row.DisplayID = displayId;
            row.Selected = selected;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;
 
            ((FmViewTDS.FmViewDisplayTempDataTable)Table).AddFmViewDisplayTempRow(row);
        }



        /// <summary>
        /// Process
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void Process(int viewId, string fmType, int companyId)
        {
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow rowViewDisplay in (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Data.Tables["LFS_FM_TYPE_VIEW_DISPLAY"])
            {
                if (rowViewDisplay.Selected)
                {
                    int displayId = rowViewDisplay.DisplayID;
                    
                    Insert(viewId, fmType, companyId, displayId, true, false, false);
                }
            }
        }



        /// <summary>
        /// ProcessForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void ProcessForEdit(int viewId, string fmType, int companyId)
        {
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow rowViewDisplay in (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Data.Tables["LFS_FM_TYPE_VIEW_DISPLAY"])
            {
                FmViewDisplay fmViewDisplay = new FmViewDisplay();
                fmViewDisplay.LoadAllByViewIdFmTypeCompanyIdDisplayId(viewId, fmType, companyId, rowViewDisplay.DisplayID);
                FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(fmViewDisplay.Data);

                if (fmViewDisplay.ExistsByViewIDFmTypeCompanyIdDisplayId(viewId, fmType, companyId, rowViewDisplay.DisplayID))
                {
                    if (rowViewDisplay.Selected)
                    {
                        // Set Deleted in 0
                        Insert(viewId, fmType, companyId, rowViewDisplay.DisplayID, true, true, false);
                    }
                    else
                    {                        
                        // Set Deleted in 1 
                        Insert(viewId, fmType, companyId, rowViewDisplay.DisplayID, false, true, true);
                    }
                }
                else
                {
                    if (rowViewDisplay.Selected)
                    {
                        // Insert
                        Insert(viewId, fmType, companyId, rowViewDisplay.DisplayID, true, false, false);
                    }                    
                }
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            foreach (FmViewTDS.FmViewDisplayTempRow rowViewDisplay in (FmViewTDS.FmViewDisplayTempDataTable)Data.Tables["FmViewDisplayTemp"])
            {
                if (!rowViewDisplay.Deleted)
                {
                    int displayId = rowViewDisplay.DisplayID;

                    FmViewDisplay fmViewDisplay = new FmViewDisplay(null);
                    fmViewDisplay.InsertDirect(rowViewDisplay.ViewID, rowViewDisplay.FmType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID, rowViewDisplay.Deleted);                    
                }
            }
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        public void SaveForEdit()
        {
            foreach (FmViewTDS.FmViewDisplayTempRow rowViewDisplay in (FmViewTDS.FmViewDisplayTempDataTable)Data.Tables["FmViewDisplayTemp"])
            {
                FmViewDisplay fmViewDisplay = new FmViewDisplay(null);
                
                if (!rowViewDisplay.Deleted && !rowViewDisplay.InDatabase && rowViewDisplay.Selected)
                {                    
                    fmViewDisplay.InsertDirect(rowViewDisplay.ViewID, rowViewDisplay.FmType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID, rowViewDisplay.Deleted);
                }

                if (!rowViewDisplay.Deleted && rowViewDisplay.InDatabase && rowViewDisplay.Selected)
                {
                    FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway();
                    fmViewDisplayGateway.LoadAllByViewIdFmTypeDisplayId(rowViewDisplay.ViewID, rowViewDisplay.FmType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID);
                    
                    int originalViewId = rowViewDisplay.ViewID;
                    string originalFmType = rowViewDisplay.FmType;
                    int originalCompanyId = rowViewDisplay.COMPANY_ID;
                    int originalDisplayId = rowViewDisplay.DisplayID;
                    bool originalDeleted = fmViewDisplayGateway.GetDeleted(rowViewDisplay.ViewID, rowViewDisplay.FmType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID);

                    fmViewDisplay.UpdateDirect(originalViewId, originalFmType, originalCompanyId, originalDisplayId, originalDeleted, rowViewDisplay.ViewID, rowViewDisplay.FmType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID, rowViewDisplay.Deleted);

                }

                if (rowViewDisplay.Deleted && rowViewDisplay.InDatabase && !rowViewDisplay.Selected)
                {
                    fmViewDisplay.DeleteDirectForEditView(rowViewDisplay.ViewID, rowViewDisplay.FmType, rowViewDisplay.COMPANY_ID, rowViewDisplay.DisplayID);
                }

            }
        }



        /// <summary>
        /// GetColumnsToDisplay
        /// </summary>
        /// <returns>columns to display</returns>
        public string GetColumnsToDisplay()
        {
            string columnsToDisplay = "";

            foreach (FmViewTDS.FmViewDisplayTempRow row in (FmViewTDS.FmViewDisplayTempDataTable)Table)
            {
                if (row.Selected)
                {
                    FmTypeViewDisplay fmTypeViewDisplay = new FmTypeViewDisplay();
                    fmTypeViewDisplay.LoadByFmTypeDisplayId(row.FmType, row.COMPANY_ID, row.DisplayID);

                    FmTypeViewDisplayGateway fmTypeViewDisplayGateway = new FmTypeViewDisplayGateway(fmTypeViewDisplay.Data);
                    columnsToDisplay = columnsToDisplay + fmTypeViewDisplayGateway.GetName(row.FmType, row.COMPANY_ID, row.DisplayID) + ", ";                    
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