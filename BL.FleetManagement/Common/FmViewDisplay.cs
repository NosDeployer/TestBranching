using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewDisplay
    /// </summary>
    public class FmViewDisplay : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewDisplay()
            : base("LFS_FM_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewDisplay(DataSet data)
            : base(data, "LFS_FM_VIEW_DISPLAY")
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
        /// LoadByViewIdFmTypeCompanyId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByViewIdFmTypeCompanyId(int viewId,string fmType, int companyId)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(Data);
            fmViewDisplayGateway.LoadByViewIdFmType(viewId, fmType, companyId);
        }



        /// <summary>
        /// LoadByViewIdFmTypeCompanyIdDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void LoadAllByViewIdFmTypeCompanyIdDisplayId(int viewId, string fmType, int companyId, int displayId)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(Data);
            fmViewDisplayGateway.LoadAllByViewIdFmTypeDisplayId(viewId, fmType, companyId, displayId);
        }



        /// <summary>
        /// LoadByViewIdFmTypeCompanyIdDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void LoadByViewIdFmTypeCompanyIdDisplayId(int viewId, string fmType, int companyId, int displayId)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(Data);
            fmViewDisplayGateway.LoadByViewIdFmTypeDisplayId(viewId, fmType, companyId, displayId);
        }



        /// <summary>
        /// ExistsByViewIDFmTypeCompanyIdDisplayId
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>True if row exists, else False</returns>
        public bool ExistsByViewIDFmTypeCompanyIdDisplayId(int viewId, string fmType, int companyId, int displayId)
        {
            string filter = string.Format("(ViewID = '{0}') AND (FmType = '{1}') AND (COMPANY_ID = '{2}') AND (DisplayID = '{3}') ", viewId, fmType, companyId, displayId);

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
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>columnsToDisplay</returns>
        public string GetColumnsToDisplayForViews(int viewId, string fmType, int companyId)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(Data);
            fmViewDisplayGateway.LoadByViewIdFmType(viewId, fmType, companyId);

            string columnsToDisplay = "";

            foreach (FmViewTDS.LFS_FM_VIEW_DISPLAYRow row in (FmViewTDS.LFS_FM_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.FmType == fmType) && (row.COMPANY_ID == companyId) && (row.ViewID == viewId))
                {
                    FmTypeViewDisplayGateway fmTypeViewDisplayGateway = new FmTypeViewDisplayGateway();
                    fmTypeViewDisplayGateway.LoadByFmTypeDisplayId(fmType, companyId, row.DisplayID);

                    columnsToDisplay = columnsToDisplay + fmTypeViewDisplayGateway.GetName(fmType, companyId, row.DisplayID) + ", ";
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
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(null);
            fmViewDisplayGateway.Delete(viewId, companyId);
        }



        /// <summary>
        /// DeleteDirectForEditView
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayid</param>
        public void DeleteDirectForEditView(int viewId, string fmType, int companyId, int displayId)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(null);
            fmViewDisplayGateway.DeleteForEditView(viewId, fmType, companyId, displayId);
        }



        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="deleted">deleted</param>
        public void InsertDirect(int viewId, string fmType, int companyId, int displayId, bool deleted)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(null);
            fmViewDisplayGateway.Insert(viewId, fmType, companyId, displayId, deleted);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="originalViewId">originalViewId</param>
        /// <param name="originalFmType">originalFmType</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDisplayId">originalDisplayid</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="newViewId">newViewid</param>
        /// <param name="newFmType">newFmType</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDisplayId">newDisplayid</param>
        /// <param name="newDeleted">newDeleted</param>
        public void UpdateDirect(int originalViewId, string originalFmType, int originalCompanyId, int originalDisplayId, bool originalDeleted, int newViewId, string newFmType, int newCompanyId, int newDisplayId, bool newDeleted)
        {
            FmViewDisplayGateway fmViewDisplayGateway = new FmViewDisplayGateway(null);
            fmViewDisplayGateway.Update(originalViewId, originalFmType, originalCompanyId, originalDisplayId, originalDeleted, newViewId, newFmType, newCompanyId, newDisplayId, newDeleted);
        }



    }
}