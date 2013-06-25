using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;

namespace LiquiForce.LFSLive.BL.FleetManagement.Common
{
    /// <summary>
    /// FmViewConditionNew
    /// </summary>
    public class FmViewConditionNew : TableModule
    {
        private int currentMaxDeep = 0;

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FmViewConditionNew()
            : base("FmViewConditionNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FmViewConditionNew(DataSet data)
            : base(data, "FmViewConditionNew")
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
        /// <param name="conditionId">conditionId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="sign">sign</param>
        /// <param name="value_">value_</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Insert(int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewConditionNewRow row = ((FmViewTDS.FmViewConditionNewDataTable)Table).NewFmViewConditionNewRow();

            row.ID = GetNewId();
            row.ConditionID = conditionId;
            row.Name = name;
            row.RefID = GetNewRefId(conditionId);
            row.Operator = operator_;
            row.Sign = sign;
            row.ConditionNumber = conditionNumber;
            row.Value_ = value_;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;

            ((FmViewTDS.FmViewConditionNewDataTable)Table).AddFmViewConditionNewRow(row);
        }



        /// <summary>
        /// InsertForEdit
        /// </summary>
        /// <param name="conditionId">conditionId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="sign">sign</param>
        /// <param name="value_">value_</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void InsertForEdit(int refId, int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewConditionNewRow row = ((FmViewTDS.FmViewConditionNewDataTable)Table).NewFmViewConditionNewRow();

            row.ID = GetNewId();
            row.ConditionID = conditionId;
            row.Name = name;
            row.RefID = refId;
            row.Operator = operator_;
            row.Sign = sign;
            row.ConditionNumber = conditionNumber;
            row.Value_ = value_;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;

            ((FmViewTDS.FmViewConditionNewDataTable)Table).AddFmViewConditionNewRow(row);
        }



        /// <summary>
        /// InsertTemp
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="conditionId">conditionid</param>
        /// <param name="name">name</param>
        /// <param name="refId">refId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="sign">sign</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="value_">value_</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void InsertTemp(int id, int conditionId, string name, int refId, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewConditionNewRow row = ((FmViewTDS.FmViewConditionNewDataTable)Table).NewFmViewConditionNewRow();

            row.ID = id;
            row.ConditionID = conditionId;
            row.Name = name;
            row.RefID = refId;
            row.Operator = operator_;
            row.Sign = sign;
            row.ConditionNumber = conditionNumber;
            row.Value_ = value_;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;

            ((FmViewTDS.FmViewConditionNewDataTable)Table).AddFmViewConditionNewRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="refId">refId</param>
        /// <param name="operator_">operator_</param>
        /// <param name="sign">sign</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="value_">value_</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void Update(int id, int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewConditionNewRow row = GetRow(id);

            row.RefID = GetNewRefId(conditionId);           
            row.ConditionID = conditionId;
            row.Name = name;            
            row.Operator = operator_;
            row.Sign = sign;
            row.ConditionNumber = conditionNumber;
            row.Value_ = value_;
            row.InDatabase = inDatabase;
            row.Deleted = deleted;
        }



        /// <summary>
        /// UpdateForEdit
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="conditionId">conditionId</param>
        /// <param name="name">name</param>
        /// <param name="operator_">operator_</param>
        /// <param name="sign">sign</param>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <param name="value_">value_</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="deleted">deleted</param>
        public void UpdateForEdit(int refId, int id, int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            FmViewTDS.FmViewConditionNewRow row = GetRow(id);

            if (row.ConditionID != conditionId)
            {
                InsertForEdit(refId, conditionId, name, operator_, sign, conditionNumber, value_, false, false);
                Delete(id);
            }
            else
            {
                row.RefID = row.RefID;
                row.ConditionID = conditionId;
                row.Name = name;
                row.Operator = operator_;
                row.Sign = sign;
                row.ConditionNumber = conditionNumber;
                row.Value_ = value_;
                row.Deleted = deleted;
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">id</param>
        public void Delete(int id)
        {
            FmViewTDS.FmViewConditionNewRow row = GetRow(id);
            row.Deleted = true;            
        }



        /// <summary>
        /// Process a new section's table 
        /// </summary>
        public void ProcessNew()
        {
            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                if (!rowNew.Deleted)
                {
                    int conditionId = rowNew.ConditionID;
                    string name = rowNew.Name;
                    int refId = rowNew.RefID;
                    string operator_ = rowNew.Operator;
                    string sign = rowNew.Sign;
                    int conditionNumber = rowNew.ConditionNumber;
                    string value = rowNew.Value_;
                    bool inDatabase = rowNew.InDatabase;
                    bool deleted = rowNew.Deleted;

                    Insert(conditionId, name, operator_, sign, conditionNumber, value, false, false);
                }
            }
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void Save(int viewId, int companyId, string fmType)
        {
            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                if (!rowNew.Deleted)
                {
                    FmViewCondition fmViewCondition = new FmViewCondition(null);
                    fmViewCondition.InsertDirect(viewId, companyId, fmType, rowNew.ConditionID, rowNew.RefID, rowNew.Operator, rowNew.ConditionNumber, rowNew.Value_, rowNew.Deleted);
                }
            }
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void SaveForEdit(int viewId, int companyId, string fmType)
        {
            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                FmViewCondition fmViewCondition = new FmViewCondition(null);

                if (!rowNew.Deleted && !rowNew.InDatabase)
                {
                    FmViewConditionGateway fmViewConditionGateway = new FmViewConditionGateway(null);

                    int refId = fmViewConditionGateway.GetLastRefIdByViewIdCompanyIdFmTypeConditionId(viewId, companyId, fmType, rowNew.ConditionID);
                    refId = refId + 1;
                    
                    fmViewCondition.InsertDirect(viewId, companyId, fmType, rowNew.ConditionID, refId, rowNew.Operator, rowNew.ConditionNumber, rowNew.Value_, rowNew.Deleted);
                }

                if (!rowNew.Deleted && rowNew.InDatabase)
                {
                    FmViewConditionGateway fmViewConditionGateway = new FmViewConditionGateway();
                    fmViewConditionGateway.LoadAllByViewIdFmTypeConditionIdRefId(viewId, companyId, fmType, rowNew.ConditionID, rowNew.RefID);

                    int originalViewId = viewId;
                    int originalCompanyId = companyId;
                    string originalFmType = fmType;
                    int originalConditionId = rowNew.ConditionID;
                    int originalRefId = rowNew.RefID; //fmViewConditionGateway.GetRefId(viewId, fmType, companyId, rowNew.ConditionID, rowNew.RefID);
                    string originalOperator_ = fmViewConditionGateway.GetOperator(viewId, fmType, companyId, rowNew.ConditionID, rowNew.RefID);
                    int originalConditionNumber = fmViewConditionGateway.GetConditionNumber(viewId, fmType, companyId, rowNew.ConditionID, rowNew.RefID);
                    string originalValue_ = fmViewConditionGateway.GetValue_(viewId, fmType, companyId, rowNew.ConditionID, rowNew.RefID);
                    bool originalDeleted = fmViewConditionGateway.GetDeleted(viewId, fmType, companyId, rowNew.ConditionID, rowNew.RefID);

                    fmViewCondition.UpdateDirect(originalViewId, originalFmType, originalCompanyId, originalConditionId, originalRefId, originalOperator_, originalConditionNumber, originalValue_, originalDeleted, viewId, fmType, companyId, rowNew.ConditionID, rowNew.RefID, rowNew.Operator, rowNew.ConditionNumber, rowNew.Value_, rowNew.Deleted);
                }

                if (rowNew.Deleted && rowNew.InDatabase)
                {
                    fmViewCondition.DeleteDirectForEditView(viewId, companyId, fmType, rowNew.ConditionID, rowNew.RefID);
                }
            }
        }



        /// <summary>
        /// GetConditions
        /// </summary>
        /// <returns>Conditions array</returns>
        public ArrayList GetConditions()
        {
            ArrayList conditions = new ArrayList();

            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["fmViewConditionNew"])
            {
                if (!rowNew.Deleted)
                {
                    string condition = "Condition" + rowNew.ConditionNumber.ToString();
                    conditions.Add(condition);                    
                }
            }

            return conditions;
        }



        /// <summary>
        /// GetConditionsByDefault
        /// </summary>
        /// <returns>Conditions by default</returns>
        public string GetConditionsByDefault()
        {
            string conditionsByDefault = "";
            string condition = "";
            ArrayList conditions = new ArrayList();

            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                if (!rowNew.Deleted && !conditions.Contains(rowNew.Name))
                {
                    conditions.Add(rowNew.Name);
                                   
                    condition = "";
                    condition = "(Condition" + rowNew.ConditionNumber; 
                    
                    string name = rowNew.Name;
                    int conditionNumber = rowNew.ConditionNumber;
                    
                    foreach (FmViewTDS.FmViewConditionNewRow rowNew2 in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
                    {
                        if (rowNew2.Name == name && rowNew2.ConditionNumber != conditionNumber && !rowNew2.Deleted)
                        {
                            condition = condition + " OR Condition" + rowNew2.ConditionNumber;
                        }
                    }

                    condition = condition + ") AND ";

                    conditionsByDefault = conditionsByDefault + condition;
                }                
            }

            if (conditionsByDefault.Length > 4)
            {
                return conditionsByDefault.Remove(conditionsByDefault.Length - 5);
            }
            else
            {
                return conditionsByDefault;
            }
        }



        /// <summary>
        /// ParserLogic
        /// </summary>
        /// <param name="originalLogic">originalLogic</param>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>parser logic string</returns>
        public string ParserLogic(string originalLogic, string fmType, int companyId)
        {
            string newLogic = "";

            if (fmType == "Services")
            {
                if (originalLogic.Length > 0)
                {
                    newLogic = "(LFS.Deleted = 0) AND (LFU.Deleted = 0) AND (LFS.COMPANY_ID = {0}) AND (LFU.COMPANY_ID = {0}) AND ";
                }
                else
                {
                    newLogic = "(LFS.Deleted = 0) AND (LFU.Deleted = 0) AND (LFS.COMPANY_ID = {0}) AND (LFU.COMPANY_ID = {0})";
                }
            }

            if (fmType == "Units")
            {
                if (originalLogic.Length > 0)
                {
                    newLogic = "(FMU.Deleted = 0) AND (FMU.State <> 'Archived') AND (FMC.Deleted = 0) AND (FMU.COMPANY_ID = {0}) AND (FMC.COMPANY_ID = {0}) AND ";
                }
                else
                {
                    newLogic = "(FMU.Deleted = 0) AND (FMU.State <> 'Archived') AND (FMC.Deleted = 0) AND (FMU.COMPANY_ID = {0}) AND (FMU.COMPANY_ID = {0})";
                }
            }
                               
            foreach (FmViewTDS.FmViewConditionNewRow rowNew in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                if (!rowNew.Deleted)
                {
                    string originalCondition = "Condition" + rowNew.ConditionNumber;
                    
                    FmTypeViewCondition fmTypeViewCondition = new FmTypeViewCondition();
                    fmTypeViewCondition.LoadByFmTypeConditionId(fmType, companyId, rowNew.ConditionID);

                    FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway(fmTypeViewCondition.Data);
                    string tableName = fmTypeViewConditionGateway.GetTable_(fmType, companyId, rowNew.ConditionID);
                    string conditionName = fmTypeViewConditionGateway.GetName(fmType, companyId, rowNew.ConditionID);
                    string column = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, rowNew.ConditionID);

                    if (fmType == "Services")
                    {
                        switch (tableName)
                        {
                            case "LFS_FM_SERVICE":
                                tableName = "LFS";
                                break;

                            case "LFS_FM_SERVICE_VEHICLE":
                                tableName = "LFSV";
                                break;

                            case "LFS_FM_UNIT":
                                tableName = "LFU";
                                break;

                            case "LFS_FM_RULE":
                                tableName = "LFR";
                                break;

                            case "LFS_FM_CHECKLIST":
                                tableName = "LFC";
                                break;

                            case "LFS_FM_COMPANYLEVEL":
                                tableName = "LFCL";
                                break;
                        }

                        if (conditionName == "Created By") tableName = "LEOwner";
                        if (conditionName == "Assigned To") tableName = "LEAssignedTo";
                    }                    

                    if (fmType == "Units")
                    {
                        switch (tableName)
                        {
                            case "LFS_FM_UNIT":
                                tableName = "FMU";
                                break;

                            case "LFS_FM_COMPANYLEVEL":
                                if (column == "CompanyLevel")
                                {
                                    column = "Name";
                                    tableName = "FMC";
                                }
                                break;

                            case "LFS_FM_UNIT_VEHICLE":
                                tableName = "FMUV";
                                break;

                            case "LFS_COUNTRY":
                                if (column == "LicenseCountry")
                                {
                                    tableName = "LCL";
                                }
                                if (column == "OwnerCountry")
                                {

                                    tableName = "LCO";
                                }
                                column = "Name";
                                break;

                            case "LFS_PROVINCE":
                                if (column == "LicenseState")
                                {
                                    tableName = "LPL";
                                }
                                if (column == "OwnerState")
                                {

                                    tableName = "LPO";
                                }
                                column = "Name";
                                break;
                        }                        
                    }
                    
                    string type = fmTypeViewConditionGateway.GetType(fmType, companyId, rowNew.ConditionID);
                    string sign = rowNew.Sign;
                    string conditionValue = rowNew.Value_;
                    string newCondition = "";
                    
                    // Search
                    if (conditionValue == "%")
                    {                        
                        if (type == "Date")
                        {
                            if (sign == "=")
                            {
                                newCondition = newCondition + " ((CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NOT NULL)";
                                newCondition = newCondition + " OR (CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NULL))";
                            }
                            else
                            {
                                if (sign == "<>")
                                {
                                    newCondition = newCondition + " (CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NULL)";
                                }
                                else
                                {
                                    newCondition = newCondition + " ((CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NOT NULL)";
                                    newCondition = newCondition + " OR (CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NULL))";
                                }
                            }
                        }
                        else
                        {
                            newCondition = newCondition + " ((" + tableName + "." + column + " LIKE '%')";
                            newCondition = newCondition + " OR (" + tableName + "." + column + " IS NULL))";
                        }                        
                    }
                    else
                    {
                        if (conditionValue == "")
                        {
                            if (sign == "<>")
                            {
                                newCondition = newCondition + tableName + "." + column + " IS NOT NULL ";
                            }
                            else
                            {
                                newCondition = newCondition + tableName + "." + column + " IS NULL ";
                            }
                        }
                        else
                        {
                            conditionValue = conditionValue.Replace("'", "''");

                            if ((type == "Int") || (type == "Decimal") || (type == "Boolean"))
                            {
                                if (type == "Boolean")
                                {
                                    if (conditionValue == "Yes") conditionValue = "1";
                                    if (conditionValue == "No") conditionValue = "0";

                                    if (fmType == "Units")
                                    {
                                        if (column != "WithAlarms" && column != "WithServicesLate" && column != "WithChecklistInUnknownState")
                                        {
                                            newCondition = newCondition + tableName + "." + column + sign + conditionValue;
                                        }
                                        else
                                        {
                                            if (column == "WithAlarms")
                                            {
                                                if (conditionValue == "1")
                                                {
                                                    newCondition = newCondition + " (FMU.UnitID IN " +
                                                     " (SELECT DISTINCT FMU1.UnitID " +
                                                     " FROM  LFS_FM_UNIT FMU1 INNER JOIN " +
                                                     " LFS_FM_CHECKLIST FMCL1 ON FMCL1.UnitID = FMU1.UnitID INNER JOIN " +
                                                     " LFS_FM_RULE FMR1 ON FMCL1.RuleID = FMR1.RuleID " +
                                                     " WHERE   (FMR1.Alarm = 1) AND (FMCL1.State = 'Warning' OR FMCL1.State = 'Expired') AND (FMCL1.Deleted = 0) AND (FMU1.Deleted = 0) AND (FMR1.Deleted = 0)" +
                                                     " ) )";
                                                }

                                                if (conditionValue == "0")
                                                {
                                                    newCondition = newCondition + " (FMU.UnitID NOT IN " +
                                                     " (SELECT DISTINCT FMU1.UnitID " +
                                                     " FROM  LFS_FM_UNIT FMU1 INNER JOIN " +
                                                     " LFS_FM_CHECKLIST FMCL1 ON FMCL1.UnitID = FMU1.UnitID INNER JOIN " +
                                                     " LFS_FM_RULE FMR1 ON FMCL1.RuleID = FMR1.RuleID " +
                                                     " WHERE   (FMCL1.State = 'Warning' OR FMCL1.State = 'Expired') AND (FMCL1.Deleted = 0) AND (FMU1.Deleted = 0) AND (FMR1.Deleted = 0)" +
                                                     " ) )";
                                                }
                                            }

                                            if (column == "WithServicesLate")
                                            {
                                                if (conditionValue == "1")
                                                {
                                                    newCondition = newCondition + " (FMU.UnitID IN " +
                                                     " (SELECT DISTINCT FMU1.UnitID " +
                                                     "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                                     "         LFS_FM_SERVICE FMS1 ON FMU1.UnitID = FMS1.UnitID " +
                                                     "   WHERE CONVERT(VARCHAR(10), FMS1.AssignDeadlineDate, 101) < CONVERT(VARCHAR(10), getdate(), 101) AND (FMS1.CompleteWorkDateTime IS NULL)" +
                                                     "            AND (FMS1.State <> 'Unassigned') AND (FMS1.State <> 'Completed') AND (FMS1.State <> 'Rejected') OR (FMS1.State = 'Assigned/Expired') OR (FMS1.State = 'In Progress/Expired') " +
                                                     "            OR (FMS1.CompleteWorkDateTime IS NOT NULL) AND (FMS1.CompleteWorkDateTime > FMS1.AssignDeadlineDate) " +
                                                     "  ) )";
                                                }

                                                if (conditionValue == "0")
                                                {
                                                    newCondition = newCondition + " (FMU.UnitID NOT IN " +
                                                     " (SELECT DISTINCT FMU1.UnitID " +
                                                     "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                                     "         LFS_FM_SERVICE FMS1 ON FMU1.UnitID = FMS1.UnitID " +
                                                     "   WHERE CONVERT(VARCHAR(10), FMS1.AssignDeadlineDate, 101) < CONVERT(VARCHAR(10), getdate(), 101) AND (FMS1.CompleteWorkDateTime IS NULL)" +
                                                     "            AND (FMS1.State <> 'Unassigned') AND (FMS1.State <> 'Completed') AND (FMS1.State <> 'Rejected') OR (FMS1.State = 'Assigned/Expired') OR (FMS1.State = 'In Progress/Expired') " +
                                                     "            OR (FMS1.CompleteWorkDateTime IS NOT NULL) AND (FMS1.CompleteWorkDateTime > FMS1.AssignDeadlineDate) " +
                                                     "  ) )";
                                                }
                                            }

                                            if (column == "WithChecklistInUnknownState")
                                            {
                                                if (conditionValue == "1")
                                                {
                                                    newCondition = newCondition + " (FMU.UnitID IN " +
                                                     " (SELECT DISTINCT FMU1.UnitID " +
                                                     "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                                     "         LFS_FM_CHECKLIST FMCL1 ON FMU1.UnitID = FMCL1.UnitID " +
                                                     "   WHERE (FMU1.Deleted = 0) AND (FMCL1.Deleted = 0) AND (FMCL1.State = 'Unknown') " +
                                                     "  ) )";
                                                }

                                                if (conditionValue == "0")
                                                {
                                                    newCondition = newCondition + " (FMU.UnitID NOT IN " +
                                                     " (SELECT DISTINCT FMU1.UnitID " +
                                                     "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                                     "         LFS_FM_CHECKLIST FMCL1 ON FMU1.UnitID = FMCL1.UnitID " +
                                                     "   WHERE (FMU1.Deleted = 0) AND (FMCL1.Deleted = 0) AND (FMCL1.State = 'Unknown') " +
                                                     "  ) )";
                                                }
                                            }
                                        }                                        
                                    }
                                    else
                                    {
                                        newCondition = newCondition + tableName + "." + column + sign + conditionValue;
                                    }
                                }
                                else
                                {
                                    newCondition = newCondition + tableName + "." + column + sign + conditionValue;
                                }
                            }
                            else
                            {
                                if (sign == "=")
                                {
                                    if (type != "Date")
                                    {
                                        if (conditionValue.Contains("\""))
                                        {
                                            conditionValue = conditionValue.Replace("\"", "");
                                            newCondition = newCondition + " (" + tableName + "." + column + " = '" + conditionValue + "')";
                                        }
                                        else
                                        {
                                            if (column == "Categories")
                                            {
                                                ArrayList categoriesId = new ArrayList();

                                                categoriesId = GetConditionForCategory(conditionValue, companyId);

                                                newCondition = newCondition + " (FMU.UnitID IN " +
                                                         " (SELECT DISTINCT FMU1.UnitID " +
                                                         "   FROM LFS_FM_UNIT FMU1 INNER JOIN " +
                                                         "         LFS_FM_UNIT_CATEGORY FMUC ON FMU1.UnitID = FMUC.UnitID " +
                                                         "   WHERE (FMU1.Deleted = 0) AND (FMUC.Deleted = 0) AND ";

                                                int cantOfCategory = categoriesId.Count;
                                                int auxOfCantOfCategory = 0;

                                                foreach (int categoryId in categoriesId)
	                                            {
                                                    auxOfCantOfCategory++;

                                                    if (auxOfCantOfCategory != cantOfCategory)
                                                    {
                                                        newCondition = newCondition + " (FMUC.CategoryID = " + categoryId + " ) OR ";
                                                    }
                                                    else
                                                    {
                                                        newCondition = newCondition + " (FMUC.CategoryID = " + categoryId + " ) ";
                                                    }
                                                }

                                                newCondition = newCondition + " )  )";
                                            }
                                            else
                                            {
                                                newCondition = newCondition + " (" + tableName + "." + column + " LIKE '%" + conditionValue + "%')";
                                            }
                                        }                                        
                                    }
                                    else
                                    {
                                        // Date
                                        if (conditionValue.Length > 7)
                                        {
                                            newCondition = newCondition + " CAST(CONVERT(varchar,"+ tableName + "." + column +", 101) AS smalldatetime) "+ sign + "'" + conditionValue + "'";
                                        }
                                        else
                                        {
                                            newCondition = newCondition + " CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) LIKE '%" + conditionValue + "%'";
                                        }
                                    }
                                }
                                else
                                {
                                    if (column == "Notes")
                                    {
                                        newCondition = newCondition + tableName + "." + column + " NOT LIKE '%" + conditionValue + "%'";
                                    }
                                    else
                                    {
                                        if (type != "Date")
                                        {
                                            newCondition = newCondition + tableName + "." + column + sign + "'" + conditionValue + "'";
                                        }
                                        else
                                        {
                                            // Date
                                            if (conditionValue.Length > 7)
                                            {
                                                if (sign == "<>")
                                                {
                                                    newCondition = newCondition + " ((CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) " + sign + "'" + conditionValue + "')";
                                                    newCondition = newCondition + " OR (CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NULL))";
                                                }
                                                else
                                                {
                                                    newCondition = newCondition + " CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) " + sign + "'" + conditionValue + "'";
                                                }
                                            }
                                            else
                                            {
                                                if (sign == "<>")
                                                {
                                                    newCondition = newCondition + " ((CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) NOT LIKE '%" + conditionValue + "%')";
                                                    newCondition = newCondition + " OR (CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) IS NULL))";
                                                }
                                                else
                                                {
                                                    if (sign == ">" || sign == "<=")
                                                    {
                                                        newCondition = newCondition + " CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime)" + sign + " '12/31/" + conditionValue + "'";
                                                    }
                                                    else
                                                    {
                                                        newCondition = newCondition + " CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime)" + sign + " '" + conditionValue + "'";
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    originalLogic = originalLogic.Replace(originalCondition, newCondition);
                }
            }

            if (originalLogic.Length > 0)
            {
                newLogic = newLogic + originalLogic;
            }

            return newLogic;
        }



        /// <summary>
        /// GetConditionForCategory
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="companyId">companyId</param>
        /// <returns>categoriesId</returns>
        private ArrayList GetConditionForCategory(string category, int companyId)
        {
            CategoryGateway categoryGateway2 = new CategoryGateway();            
            int categoryId = categoryGateway2.GetCategoryId(category);

            ArrayList categoriesId = new ArrayList();
            categoriesId.Add(categoryId);

            categoriesId = GetChilds(categoryId, categoriesId, companyId);

            return categoriesId;
        }



        /// <summary>
        /// GetChilds
        /// </summary>
        /// <param name="categoryId">categoryId</param>
        /// <param name="currentCategoriesId">currentCategoriesId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private ArrayList GetChilds(int categoryId, ArrayList currentCategoriesId, int companyId)
        {
            ArrayList categoriesId = currentCategoriesId;

            CategoryGateway categoryGateway = new CategoryGateway();
            categoryGateway.LoadByParentId(categoryId, companyId);

            foreach (CategoriesTDS.LFS_FM_CATEGORYRow row in ((CategoriesTDS.LFS_FM_CATEGORYDataTable)categoryGateway.Table))
            {
                categoriesId.Add(row.CategoryID);

                categoriesId = GetChilds(row.CategoryID, categoriesId, companyId);
            }

            return categoriesId;
        }



        /// <summary>
        /// GetConditionsForSummary
        /// </summary>
        /// <param name="fmType">fmType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Conditins for Summary</returns>
        public string GetConditionsForSummary(string fmType, int companyId)
        {
            string conditions = "";

            foreach (FmViewTDS.FmViewConditionNewRow row in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                if (!row.Deleted)
                {
                    FmTypeViewCondition fmTypeViewCondition = new FmTypeViewCondition();
                    fmTypeViewCondition.LoadByFmTypeConditionId(fmType, companyId, row.ConditionID);

                    FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway(fmTypeViewCondition.Data);
                    if (row.Value_ == "")
                    {
                        conditions = conditions + "Condition" + row.ConditionNumber + ": " + fmTypeViewConditionGateway.GetName(fmType, companyId, row.ConditionID) + " " + row.Sign + " (empty), ";
                    }
                    else
                    {
                        conditions = conditions + "Condition" + row.ConditionNumber + ": " + fmTypeViewConditionGateway.GetName(fmType, companyId, row.ConditionID) + " " + row.Sign + " " + row.Value_ + ", ";
                    }
                }
            }

            if (conditions.Length > 2)
            {
                conditions = conditions.Substring(0, conditions.Length - 2);
            }

            return conditions;
        }



        /// <summary>
        /// GetNewConditionNumber
        /// </summary>
        /// <returns>conditinNumber</returns>
        public int GetNewConditionNumber()
        {
            int newConditionNumber = 0;

            foreach (FmViewTDS.FmViewConditionNewRow row in (FmViewTDS.FmViewConditionNewDataTable)Data.Tables["FmViewConditionNew"])
            {
                if (newConditionNumber < row.ConditionNumber)
                {
                    newConditionNumber = row.ConditionNumber;
                }
            }

            newConditionNumber++;

            return newConditionNumber;
        }



        /// <summary>
        /// LoadByViewIdCompanyIdFmType
        /// </summary>
        /// <param name="viewId">viewId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void LoadByViewIdCompanyIdFmType(int viewId, int companyId, string fmType)
        {
            // process temp table
            DataRow[] toCopy = Data.Tables["FmViewConditionTemp"].Select();

            foreach (DataRow rowTemp in toCopy)
            {
                int id = ((FmViewTDS.FmViewConditionTempRow)rowTemp).ID;
                int conditionId = ((FmViewTDS.FmViewConditionTempRow)rowTemp).ConditionID;
                string name = ((FmViewTDS.FmViewConditionTempRow)rowTemp).Name;
                int refId = ((FmViewTDS.FmViewConditionTempRow)rowTemp).RefID;
                string operator_ = ((FmViewTDS.FmViewConditionTempRow)rowTemp).Operator;
                string sign = ((FmViewTDS.FmViewConditionTempRow)rowTemp).Sign;
                int conditionNumber = ((FmViewTDS.FmViewConditionTempRow)rowTemp).ConditionNumber;
                string value = ((FmViewTDS.FmViewConditionTempRow)rowTemp).Value_;
                bool inDatabase = ((FmViewTDS.FmViewConditionTempRow)rowTemp).InDatabase;
                bool deleted = ((FmViewTDS.FmViewConditionTempRow)rowTemp).Deleted;
                
                Insert(conditionId, name, operator_, sign, conditionNumber, value, inDatabase, deleted);
            }

            // load from database
            if (Table.Rows.Count == 0)
            {
                FmViewConditionNewGateway fmViewConditionNewGateway = new FmViewConditionNewGateway(Data);
                fmViewConditionNewGateway.LoadByViewIdFmType(viewId, companyId, fmType);
            }
        }



        /// <summary>
        /// ExistsConditionNumber
        /// </summary>
        /// <param name="conditionNumber">conditionNumber</param>
        /// <returns>True if row exists, else False</returns>
        public bool ExistsConditionNumber(int conditionNumber)
        {
            string filter = string.Format("(ConditionNumber = '{0}') AND (Deleted = 0)", conditionNumber);

            if (Table.Select(filter).Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>FmViewTDS.FmViewConditionNewRow</returns>
        private FmViewTDS.FmViewConditionNewRow GetRow(int id)
        {
            FmViewTDS.FmViewConditionNewRow row = ((FmViewTDS.FmViewConditionNewDataTable)Table).FindByID(id);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Common.FmViewConditionNew.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewId
        /// </summary>
        /// <returns>ID</returns>
        private int GetNewId()
        {
            int newId = 0;

            foreach (FmViewTDS.FmViewConditionNewRow row in (FmViewTDS.FmViewConditionNewDataTable)Table)
            {
                if (newId < row.ID)
                {
                    newId = row.ID;
                }
            }

            newId++;

            return newId;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <param name="conditionId">conditionId</param>
        /// <returns>RefId</returns>
        private int GetNewRefId(int conditionId)
        {
            int newRefId = 0;

            foreach (FmViewTDS.FmViewConditionNewRow row in (FmViewTDS.FmViewConditionNewDataTable)Table)
            {
                if (conditionId == row.ConditionID)
                {
                    if (newRefId < row.RefID)
                    {
                        newRefId = row.RefID;
                    }
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}