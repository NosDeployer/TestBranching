using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmTypeViewDisplay
    /// </summary>
    public class FmTypeViewDisplay : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmTypeViewDisplay()
            : base("LFS_FM_TYPE_VIEW_DISPLAY")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmTypeViewDisplay(DataSet data)
            : base(data, "LFS_FM_TYPE_VIEW_DISPLAY")
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
        /// LoadByFmType
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByFmType(string fmType, int companyId)
        {
            FmTypeViewDisplayGateway columnsToDisplayGateway = new FmTypeViewDisplayGateway(Data);
            columnsToDisplayGateway.LoadByFmType(fmType, companyId);           
        }



        /// <summary>
        /// LoadByFmTypeDisplayId
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        public void LoadByFmTypeDisplayId(string fmType, int companyId, int displayId)
        {
            FmTypeViewDisplayGateway columnsToDisplayGateway = new FmTypeViewDisplayGateway(Data);
            columnsToDisplayGateway.LoadByFmTypeDisplayId(fmType, companyId, displayId);           
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <param name="selected">selected</param>
        public void Update(string fmType, int companyId, int displayId, bool selected)
        {
            FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow row = GetRow(fmType, companyId, displayId);
            row.Selected = selected;
        }



        /// <summary>
        /// GetColumnsByDefault
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inColumnsByDefault">inColumnsByDefault</param>
        /// <returns>columns by default</returns>
        public string GetColumnsByDefault(string fmType, int companyId, bool inColumnsByDefault)
        {
            FmTypeViewDisplayGateway fmTypeViewDisplayGateway = new FmTypeViewDisplayGateway(Data);
            fmTypeViewDisplayGateway.LoadByFmTypeInColumnsByDefault(fmType, companyId, inColumnsByDefault);
            
            string columnsByDefault = "";

            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow row in (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.FmType == fmType) && (row.COMPANY_ID == companyId) && (row.Always))
                {
                    columnsByDefault = columnsByDefault + row.Name + ", ";
                }
            }

            columnsByDefault = columnsByDefault.Substring(0, columnsByDefault.Length - 2);

            return columnsByDefault;
        }
        


        /// <summary>
        /// UpdateForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void UpdateForEdit(int viewId, string fmType, int companyId)
        {
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow row in (FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Table)
            {
                if ((row.FmType == fmType) && (row.COMPANY_ID == companyId))
                {
                    FmViewDisplay fmViewDisplay = new FmViewDisplay();
                    fmViewDisplay.LoadByViewIdFmTypeCompanyIdDisplayId(viewId, fmType, companyId, row.DisplayID);

                    if (fmViewDisplay.ExistsByViewIDFmTypeCompanyIdDisplayId(viewId, fmType, companyId, row.DisplayID))
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
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="displayId">displayId</param>
        /// <returns>FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow</returns>
        private FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow GetRow(string fmType, int companyId, int displayId)
        {
            FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYRow row = ((FmViewTDS.LFS_FM_TYPE_VIEW_DISPLAYDataTable)Table).FindByFmTypeCOMPANY_IDDisplayID(fmType, companyId, displayId );

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Common.FmTypeViewDisplay.GetRow");
            }

            return row;
        }              



    }
}