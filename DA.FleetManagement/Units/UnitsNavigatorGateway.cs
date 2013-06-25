using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsNavigatorGateway
    /// </summary>
    public class UnitsNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsNavigatorGateway()
            : base("UnitsNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsNavigatorGateway(DataSet data)
            : base(data, "UnitsNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsNavigatorTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "UnitsNavigator";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("VIN", "VIN");
            tableMapping.ColumnMappings.Add("Manufacturer", "Manufacturer");
            tableMapping.ColumnMappings.Add("Model", "Model");
            tableMapping.ColumnMappings.Add("Year", "Year");
            tableMapping.ColumnMappings.Add("IsTowable", "IsTowable");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Categories", "Categories");
            tableMapping.ColumnMappings.Add("OwnerType", "OwnerType");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("CompanyLevel", "CompanyLevel");
            tableMapping.ColumnMappings.Add("AcquisitionDate", "AcquisitionDate");
            tableMapping.ColumnMappings.Add("CostCad", "CostCad");
            tableMapping.ColumnMappings.Add("CostUsd", "CostUsd");
            tableMapping.ColumnMappings.Add("LicenseCountry", "LicenseCountry");
            tableMapping.ColumnMappings.Add("LicenseState", "LicenseState");
            tableMapping.ColumnMappings.Add("LicensePlateNumbver", "LicensePlateNumbver");
            tableMapping.ColumnMappings.Add("AportionedTagNumber", "AportionedTagNumber");
            tableMapping.ColumnMappings.Add("ActualWeight", "ActualWeight");
            tableMapping.ColumnMappings.Add("RegisteredWeight", "RegisteredWeight");
            tableMapping.ColumnMappings.Add("TireSizeFront", "TireSizeFront");
            tableMapping.ColumnMappings.Add("TireSizeBack", "TireSizeBack");
            tableMapping.ColumnMappings.Add("NumberOfAxes", "NumberOfAxes");
            tableMapping.ColumnMappings.Add("FuelType", "FuelType");
            tableMapping.ColumnMappings.Add("BeginningOdometer", "BeginningOdometer");
            tableMapping.ColumnMappings.Add("IsReeferEquipped", "IsReeferEquipped");
            tableMapping.ColumnMappings.Add("IsPTOEquipped", "IsPTOEquipped");
            tableMapping.ColumnMappings.Add("OwnerCountry", "OwnerCountry");
            tableMapping.ColumnMappings.Add("OwnerState", "OwnerState");
            tableMapping.ColumnMappings.Add("OwnerName", "OwnerName");
            tableMapping.ColumnMappings.Add("OwnerContact", "OwnerContact");
            tableMapping.ColumnMappings.Add("QualifiedDate", "QualifiedDate");
            tableMapping.ColumnMappings.Add("NotQualifiedDate", "NotQualifiedDate");
            tableMapping.ColumnMappings.Add("NotQualifiedExplain", "NotQualifiedExplain");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("InsuranceClass", "InsuranceClass");
            tableMapping.ColumnMappings.Add("InsuranceClassRyderSpecied", "InsuranceClassRyderSpecified");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch)
        {
            // For units with alarms
            string whereClauseWithAlarms = "";

            if (conditionValue == "WithAlarms")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    if ((textForSearch.ToUpper() == "YES") || (textForSearch.ToUpper() == "Y"))
                    {
                        whereClauseWithAlarms = whereClauseWithAlarms + " AND (FMU.UnitID IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 " FROM  LFS_FM_UNIT FMU1 INNER JOIN " +
                                 " LFS_FM_CHECKLIST FMCL1 ON FMCL1.UnitID = FMU1.UnitID INNER JOIN " +
                                 " LFS_FM_RULE FMR1 ON FMCL1.RuleID = FMR1.RuleID " +
                                 " WHERE   (FMR1.Alarm = 1) AND (FMCL1.State = 'Warning' OR FMCL1.State = 'Expired') AND (FMCL1.Deleted = 0) AND (FMU1.Deleted = 0) AND (FMR1.Deleted = 0)" +
                                 " ) )";
                    }
                    else
                    {
                        if ((textForSearch.ToUpper() == "NO") || (textForSearch.ToUpper() == "N"))
                        {
                            whereClauseWithAlarms = whereClauseWithAlarms + " AND (FMU.UnitID NOT IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 " FROM  LFS_FM_UNIT FMU1 INNER JOIN " +
                                 " LFS_FM_CHECKLIST FMCL1 ON FMCL1.UnitID = FMU1.UnitID INNER JOIN " +
                                 " LFS_FM_RULE FMR1 ON FMCL1.RuleID = FMR1.RuleID " +
                                 " WHERE   (FMCL1.State = 'Warning' OR FMCL1.State = 'Expired') AND (FMCL1.Deleted = 0) AND (FMU1.Deleted = 0) AND (FMR1.Deleted = 0)" +
                                 " ) )";
                        }
                    }
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseWithAlarms = whereClauseWithAlarms + " AND (FMU.UnitID NOT IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 " FROM  LFS_FM_UNIT FMU1 INNER JOIN " +
                                 " LFS_FM_CHECKLIST FMCL1 ON FMCL1.UnitID = FMU1.UnitID INNER JOIN " +
                                 " LFS_FM_RULE FMR1 ON FMCL1.RuleID = FMR1.RuleID " +
                                 " WHERE   (FMCL1.State = 'Warning' OR FMCL1.State = 'Expired') AND (FMCL1.Deleted = 0) AND (FMU1.Deleted = 0) AND (FMR1.Deleted = 0)" +
                                 " ) )";
                    }
                }
            }

            // For Units with services late
            string whereClauseWithServicesLate = "";

            if (conditionValue == "WithServicesLate")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    if ((textForSearch.ToUpper() == "YES") || (textForSearch.ToUpper() == "Y"))
                    {
                        whereClauseWithServicesLate = whereClauseWithServicesLate + " AND  (FMU.UnitID IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                 "         LFS_FM_SERVICE FMS1 ON FMU1.UnitID = FMS1.UnitID " +                                 
                                 "   WHERE CONVERT(VARCHAR(10), FMS1.AssignDeadlineDate, 101) < CONVERT(VARCHAR(10), getdate(), 101) AND (FMS1.CompleteWorkDateTime IS NULL)" +
                                 "            AND (FMS1.State <> 'Unassigned') AND (FMS1.State <> 'Completed') AND (FMS1.State <> 'Rejected') OR (FMS1.State = 'Assigned/Expired') OR (FMS1.State = 'In Progress/Expired') "+
                                 "            OR (FMS1.CompleteWorkDateTime IS NOT NULL) AND (FMS1.CompleteWorkDateTime > FMS1.AssignDeadlineDate) "+
                                 "  ) )";
                    }
                    else
                    {
                        if ((textForSearch.ToUpper() == "NO") || (textForSearch.ToUpper() == "N"))
                        {
                            whereClauseWithServicesLate = whereClauseWithServicesLate + " AND  (FMU.UnitID NOT IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                 "         LFS_FM_SERVICE FMS1 ON FMU1.UnitID = FMS1.UnitID " +
                                 "   WHERE CONVERT(VARCHAR(10), FMS1.AssignDeadlineDate, 101) < CONVERT(VARCHAR(10), getdate(), 101) AND (FMS1.CompleteWorkDateTime IS NULL)" +
                                 "            AND (FMS1.State <> 'Unassigned') AND (FMS1.State <> 'Completed') AND (FMS1.State <> 'Rejected') OR (FMS1.State = 'Assigned/Expired') OR (FMS1.State = 'In Progress/Expired') " +
                                 "            OR (FMS1.CompleteWorkDateTime IS NOT NULL) AND (FMS1.CompleteWorkDateTime > FMS1.AssignDeadlineDate) " +
                                 "  ) )";
                        }
                    }
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseWithServicesLate = whereClauseWithServicesLate + " AND  (FMU.UnitID NOT IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                 "         LFS_FM_SERVICE FMS1 ON FMU1.UnitID = FMS1.UnitID " +
                                 "   WHERE CONVERT(VARCHAR(10), FMS1.AssignDeadlineDate, 101) < CONVERT(VARCHAR(10), getdate(), 101) AND (FMS1.CompleteWorkDateTime IS NULL)" +
                                 "            AND (FMS1.State <> 'Unassigned') AND (FMS1.State <> 'Completed') AND (FMS1.State <> 'Rejected') OR (FMS1.State = 'Assigned/Expired') OR (FMS1.State = 'In Progress/Expired') " +
                                 "            OR (FMS1.CompleteWorkDateTime IS NOT NULL) AND (FMS1.CompleteWorkDateTime > FMS1.AssignDeadlineDate) " +
                                 "  ) )";
                    }
                }
            }

            // For Units with checklist in unknown state
            string whereClauseWithChecklistUnknownState = "";

            if (conditionValue == "WithChecklistInUnknownState")
            {
                if ((textForSearch != "") && (textForSearch != "%"))
                {
                    if ((textForSearch.ToUpper() == "YES") || (textForSearch.ToUpper() == "Y"))
                    {
                        whereClauseWithChecklistUnknownState = whereClauseWithChecklistUnknownState + " AND  (FMU.UnitID IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                 "         LFS_FM_CHECKLIST FMCL1 ON FMU1.UnitID = FMCL1.UnitID " +
                                 "   WHERE (FMU1.Deleted = 0) AND (FMCL1.Deleted = 0) AND (FMCL1.State = 'Unknown') " +
                                 "  ) )";
                    }
                    else
                    {
                        if ((textForSearch.ToUpper() == "NO") || (textForSearch.ToUpper() == "N"))
                        {
                            whereClauseWithChecklistUnknownState = whereClauseWithChecklistUnknownState + " AND  (FMU.UnitID NOT IN " +
                                     " (SELECT DISTINCT FMU1.UnitID " +
                                     "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                     "         LFS_FM_CHECKLIST FMCL1 ON FMU1.UnitID = FMCL1.UnitID " +
                                     "   WHERE (FMU1.Deleted = 0) AND (FMCL1.Deleted = 0) AND (FMCL1.State = 'Unknown') "+
                                     "  ) )";
                        }
                    }
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClauseWithChecklistUnknownState = whereClauseWithChecklistUnknownState + " AND  (FMU.UnitID NOT IN " +
                                 " (SELECT DISTINCT FMU1.UnitID " +
                                 "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                 "         LFS_FM_CHECKLIST FMCL1 ON FMU1.UnitID = FMCL1.UnitID " +
                                 "   WHERE (FMU1.Deleted = 0) AND (FMCL1.Deleted = 0) AND (FMCL1.State = 'Unknown') " +
                                 "  ) )";
                    }
                }
            }

            // For costs
            string whereClauseCostCad = "";

            if ((conditionValue == "CostCad") || (conditionValue == "CostUsd"))
            {
                if (textForSearch == "")
                {
                    whereClauseCostCad = whereClauseCostCad + " AND  (FMU.UnitID NOT IN " +
                        " (SELECT DISTINCT   FMUCH.UnitID "+
                        "  FROM         LFS_FM_UNIT_COST_HISTORY FMUCH " +
                        "   WHERE (FMUCH.Deleted = 0)  " +
                                 "  ) )";
                }
                else
                {
                    if (textForSearch == "%")
                    {
                        whereClauseCostCad = whereClauseCostCad + " AND  (FMU.UnitID IN " +
                        " (SELECT DISTINCT   FMUCH.UnitID " +
                        "  FROM         LFS_FM_UNIT_COST_HISTORY FMUCH " +
                        "   WHERE (FMUCH.Deleted = 0)  " +
                                 "  ) ) OR  (FMU.UnitID NOT IN " +
                        " (SELECT DISTINCT   FMUCH.UnitID " +
                        "  FROM         LFS_FM_UNIT_COST_HISTORY FMUCH " +
                        "   WHERE (FMUCH.Deleted = 0)  " +
                                 "  ) )";
                    }
                    else
                    {
                        whereClauseCostCad = whereClauseCostCad + " AND  (FMU.UnitID IN " +
                       " (SELECT DISTINCT   FMUCH.UnitID " +
                       "  FROM         LFS_FM_UNIT_COST_HISTORY FMUCH " +
                       "   WHERE (FMUCH.Deleted = 0) AND (FMUCH." + conditionValue + " = " + textForSearch + ")" +
                                "  ) )";
                    }
                }
            }

            // General sql command
            string commandText = String.Format("SELECT FMU.UnitID, FMU.UnitCode, FMU.Description, FMU.VIN, FMU.Manufacturer, FMU.Model, FMU.Year_ as Year, "+
                    " FMU.IsTowable, CAST(0 AS bit) AS Selected, FMU.COMPANY_ID, FMU.Deleted, FMU.Categories, FMU.OwnerType, FMU.Notes, FMC.Name as CompanyLevel, " +
                    " FMU.AcquisitionDate,  "+
                    " (SELECT  top 1 FMUCH1.CostCad FROM LFS_FM_UNIT_COST_HISTORY FMUCH1 WHERE FMUCH1.UnitID = FMU.UnitID ORDER BY FMUCH1.Date Desc) AS CostCad, " +
                    " (SELECT  top 1 FMUCH2.CostUsd FROM LFS_FM_UNIT_COST_HISTORY FMUCH2 WHERE FMUCH2.UnitID = FMU.UnitID ORDER BY FMUCH2.Date Desc) AS CostUsd, " +
                    " (SELECT Name FROM LFS_COUNTRY C WHERE C.CountryID = FMUV.LicenseCountry) AS LicenseCountry, "+
                    " (SELECT Name FROM LFS_PROVINCE P WHERE P.ProvinceID = FMUV.LicenseState) AS LicenseState, FMUV.LicensePlateNumbver, FMUV.AportionedTagNumber, "+
                    " FMUV.ActualWeight, FMUV.RegisteredWeight, FMUV.TireSizeFront, FMUV.TireSizeBack, FMUV.NumberOfAxes, FMUV.FuelType, FMUV.BeginningOdometer, " +
                    " FMUV.IsReeferEquipped, FMUV.IsPTOEquipped, (SELECT Name FROM LFS_COUNTRY C WHERE C.CountryID = FMU.OwnerCountry) AS OwnerCountry, " +
                    " (SELECT Name FROM LFS_PROVINCE P WHERE P.ProvinceID = FMU.OwnerState) AS OwnerState, FMU.OwnerName, FMU.OwnerContact, FMU.QualifiedDate, " +
                    " FMU.NotQualifiedDate, FMU.NotQualifiedExplain, FMU.State, FMU.InsuranceClass, FMU.InsuranceClassRyderSpecified " +
                    " FROM  LFS_FM_UNIT FMU INNER JOIN "+                                 
                    "       LFS_FM_COMPANYLEVEL FMC ON FMU.CompanyLevelID = FMC.CompanyLevelID LEFT JOIN "+
                    "       LFS_FM_UNIT_VEHICLE FMUV ON FMU.UnitID = FMUV.UnitID LEFT JOIN "+
                    "       LFS_COUNTRY LCL ON LCL.CountryID = FMUV.LicenseCountry LEFT JOIN "+
                    "       LFS_PROVINCE LPL ON LPL.ProvinceID = FMUV.LicenseState LEFT JOIN "+
                    "       LFS_COUNTRY LCO ON LCO.CountryID = FMU.OwnerCountry LEFT JOIN " +
                    "       LFS_PROVINCE LPO ON LPO.ProvinceID = FMU.OwnerState "+
                    " WHERE {0} {1} {2} {3} {5}  ORDER BY {4}", where, whereClauseWithAlarms, whereClauseWithServicesLate, whereClauseWithChecklistUnknownState, orderBy, whereClauseCostCad);

            FillData(commandText);
        }



        /// <summary>
        /// LoadForViewsFmTypeCompanyId
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void LoadForViewsFmTypeCompanyId(string sqlCommand, int companyId, string fmType)
        {
            string commandText = String.Format(sqlCommand, companyId);
            FillData(commandText);
        }



    }
}