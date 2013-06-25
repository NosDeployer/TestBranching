using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewSortTemp
    /// </summary>
    public class FmViewSortTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewSortTemp()
            : base("FmViewSortTemp")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewSortTemp(DataSet data)
            : base(data, "FmViewSortTemp")
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
        /// <param name="companyId">COMPAN_ID</param>
        /// <param name="sortId">sortId</param>
        /// <param name="order">order</param>
        /// <param name="selected">selected</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int viewId, string fmType, int companyId, int sortId, int order, bool selected, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewSortTempRow row = ((FmViewTDS.FmViewSortTempDataTable)Table).NewFmViewSortTempRow();

            row.ViewID = viewId;
            row.FmType = fmType;
            row.COMPANY_ID = companyId;
            row.SortID = sortId;
            row.Order_ = order;
            row.Selected = selected;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;
 
            ((FmViewTDS.FmViewSortTempDataTable)Table).AddFmViewSortTempRow(row);
        }



        /// <summary>
        /// Process
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void Process(int viewId, string fmType, int companyId)
        {
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow rowViewSort in (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Data.Tables["LFS_FM_TYPE_VIEW_SORT"])
            {
                if (rowViewSort.Selected)
                {
                    int sortId = rowViewSort.SortID;
                    int order_ = rowViewSort.Order_;

                    Insert(viewId, fmType, companyId, sortId, order_, true, false, false);
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
            foreach (FmViewTDS.LFS_FM_TYPE_VIEW_SORTRow rowViewSort in (FmViewTDS.LFS_FM_TYPE_VIEW_SORTDataTable)Data.Tables["LFS_FM_TYPE_VIEW_SORT"])
            {
                FmViewSort fmViewSort = new FmViewSort();
                fmViewSort.LoadAllByViewIdFmTypeSortId(viewId, fmType, companyId, rowViewSort.SortID);
                FmViewSortGateway fmViewSortGateway = new FmViewSortGateway(fmViewSort.Data);

                if (fmViewSort.ExistsByViewIDFmTypeCompanyIdSortId(viewId, fmType, companyId, rowViewSort.SortID))
                {
                    if (rowViewSort.Selected)
                    {
                        Insert(viewId, fmType, companyId, rowViewSort.SortID, rowViewSort.Order_, true, true, false);
                    }
                    else
                    {
                        // delete
                        Insert(viewId, fmType, companyId, rowViewSort.SortID, 0, false, true, true);
                    }
                }
                else
                {
                    if (rowViewSort.Selected)
                    {
                        Insert(viewId, fmType, companyId, rowViewSort.SortID, rowViewSort.Order_, true, false, false);
                    }
                }
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        public void Save(int viewId, string fmType, int companyId)
        {
            foreach (FmViewTDS.FmViewSortTempRow rowViewSort in (FmViewTDS.FmViewSortTempDataTable)Data.Tables["FmViewSortTemp"])
            {
                FmViewSort fmViewSort = new FmViewSort(null);
                fmViewSort.InsertDirect(viewId, fmType, companyId, rowViewSort.SortID, rowViewSort.Order_, rowViewSort.Deleted);
            }
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        public void SaveForEdit()
        {
            foreach (FmViewTDS.FmViewSortTempRow rowViewSort in (FmViewTDS.FmViewSortTempDataTable)Data.Tables["FmViewSortTemp"])
            {
                FmViewSort fmViewSort = new FmViewSort(null);

                if (!rowViewSort.Deleted && !rowViewSort.InDatabase && rowViewSort.Selected)
                {
                    fmViewSort.InsertDirect(rowViewSort.ViewID, rowViewSort.FmType, rowViewSort.COMPANY_ID, rowViewSort.SortID, rowViewSort.Order_, rowViewSort.Deleted);
                }

                if (!rowViewSort.Deleted && rowViewSort.InDatabase && rowViewSort.Selected)
                {
                    FmViewSortGateway fmViewSortGateway = new FmViewSortGateway();
                    fmViewSortGateway.LoadAllByViewIdFmTypeSortId(rowViewSort.ViewID, rowViewSort.FmType, rowViewSort.COMPANY_ID, rowViewSort.SortID);

                    int originalViewId = rowViewSort.ViewID;
                    string originalFmType = rowViewSort.FmType;
                    int originalCompanyId = rowViewSort.COMPANY_ID;
                    int originalSortId = rowViewSort.SortID;
                    int originalOrder = fmViewSortGateway.GetOrder(rowViewSort.ViewID, rowViewSort.FmType, rowViewSort.COMPANY_ID, rowViewSort.SortID);
                    bool originalDeleted = fmViewSortGateway.GetDeleted(rowViewSort.ViewID, rowViewSort.FmType, rowViewSort.COMPANY_ID, rowViewSort.SortID);

                    fmViewSort.UpdateDirect(originalViewId, originalFmType, originalCompanyId, originalSortId, originalOrder, originalDeleted, rowViewSort.ViewID, rowViewSort.FmType, rowViewSort.COMPANY_ID, rowViewSort.SortID, rowViewSort.Order_, rowViewSort.Deleted);
                }

                if (rowViewSort.Deleted && rowViewSort.InDatabase && !rowViewSort.Selected)
                {
                    fmViewSort.DeleteDirectForEditView(rowViewSort.ViewID, rowViewSort.FmType, rowViewSort.COMPANY_ID, rowViewSort.SortID);
                }
            }
        }



        /// <summary>
        /// GetSortForSummary
        /// </summary>
        /// <returns>Sort clause</returns>
        public string GetSortForSummary()
        {
            string sort = "";

            DataRow[] dataRowOrder = Data.Tables["FmViewSortTemp"].Select("Deleted = 0", "Order_ ASC");
            foreach (DataRow row in dataRowOrder)
            {
                if (!(((FmViewTDS.FmViewSortTempRow)row).Deleted))
                {
                    string fmType = ((FmViewTDS.FmViewSortTempRow)row).FmType;
                    int companyId = ((FmViewTDS.FmViewSortTempRow)row).COMPANY_ID;
                    int sortId = ((FmViewTDS.FmViewSortTempRow)row).SortID;

                    FmTypeViewSort fmTypeViewSort = new FmTypeViewSort();
                    fmTypeViewSort.LoadByFmTypeSortId(fmType, companyId, sortId);
                    FmTypeViewSortGateway fmTypeViewSortGateway = new FmTypeViewSortGateway(fmTypeViewSort.Data);

                    sort = sort + fmTypeViewSortGateway.GetName(fmType, companyId, sortId) + ", ";
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
        /// <returns>Sort for sql</returns>
        public string GetSortForSql()
        {
            string sort = "";

            // process temp table
            DataRow[] dataRowOrder = Data.Tables["FmViewSortTemp"].Select("Deleted = 0", "Order_ ASC");
            foreach (DataRow row in dataRowOrder)
            {
                if (!(((FmViewTDS.FmViewSortTempRow)row).Deleted))
                {
                    int order_ = ((FmViewTDS.FmViewSortTempRow)row).Order_;
                    string fmType = ((FmViewTDS.FmViewSortTempRow)row).FmType;
                    int companyId = ((FmViewTDS.FmViewSortTempRow)row).COMPANY_ID;
                    int sortId = ((FmViewTDS.FmViewSortTempRow)row).SortID;

                    FmTypeViewSort fmTypeViewSort = new FmTypeViewSort();
                    fmTypeViewSort.LoadByFmTypeSortId(fmType, companyId, sortId);

                    FmTypeViewSortGateway fmTypeViewSortGateway = new FmTypeViewSortGateway(fmTypeViewSort.Data);

                    string tableName = fmTypeViewSortGateway.GetTable_(fmType, companyId, sortId);
                    string columnName = fmTypeViewSortGateway.GetColumn_(fmType, companyId, sortId);
                    string conditionName = fmTypeViewSortGateway.GetName(fmType, companyId, sortId);

                    if (fmType == "Services")
                    {
                        if (tableName == "LFS_FM_SERVICE") tableName = "LFS";
                        if (tableName == "LFS_FM_RULE") tableName = "LFR";
                        if (tableName == "LFS_FM_UNIT") tableName = "LFU";
                        if (conditionName == "Created By") tableName = "LEOwner";
                        if (conditionName == "Assigned To") tableName = "LEAssignedTo";
                    }                    

                    if (fmType == "Units")
                    {
                        if (tableName == "LFS_FM_UNIT")
                        {
                            tableName = "FMU";
                        }
                        else
                        {
                            if ((tableName == "LFS_FM_COMPANYLEVEL") && (columnName == "CompanyLevel"))
                            {
                                columnName = "Name";
                                tableName = "FMC";
                            }
                        }
                    }

                    if (fmType == "Services")
                    {
                        if (columnName == "Number")
                        {
                            sort = sort + String.Format(" CASE WHEN 1 = IsNumeric({0}.{1}) THEN Cast({0}.{1} AS INT) END, ", tableName, columnName);
                        }
                        else
                        {
                            if (conditionName == "Problem Description")
                            {
                                sort = sort + string.Format(" CAST({0}.{1} AS nvarchar), ", tableName, columnName);
                            }
                            else
                            {
                                if (columnName == "Date")
                                {
                                    sort = sort + " LFS.StartWorkDateTime DESC, ";                                           
                                }
                                else
                                {
                                    sort = sort + tableName + "." + columnName + ", ";
                                }
                            }
                        }
                    }

                    if (fmType == "Units")
                    {
                        if (columnName == "Notes" || columnName == "Categories")
                        {
                            sort = sort + string.Format(" CAST({0}.{1} AS nvarchar), ", tableName, columnName);
                        }
                        else
                        {
                            sort = sort + tableName + "." + columnName + ", ";
                        }
                    }
                }
            }
                        
            sort = sort.Substring(0, sort.Length - 2);
            
            return sort;
        }



    }
}