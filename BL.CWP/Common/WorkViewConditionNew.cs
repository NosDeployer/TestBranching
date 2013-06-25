using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// WorkViewConditionNew
    /// </summary>
    public class WorkViewConditionNew : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public WorkViewConditionNew()
            : base("WorkViewConditionNew")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public WorkViewConditionNew(DataSet data)
            : base(data, "WorkViewConditionNew")
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
        /// <param name="conditionId"></param>
        /// <param name="operator_"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="sign"></param>
        /// <param name="value_"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void Insert(int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewConditionNewRow row = ((WorkViewTDS.WorkViewConditionNewDataTable)Table).NewWorkViewConditionNewRow();

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

            ((WorkViewTDS.WorkViewConditionNewDataTable)Table).AddWorkViewConditionNewRow(row);
        }



        /// <summary>
        /// InsertForEdit
        /// </summary>
        /// <param name="conditionId"></param>
        /// <param name="operator_"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="sign"></param>
        /// <param name="value_"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void InsertForEdit(int refId, int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewConditionNewRow row = ((WorkViewTDS.WorkViewConditionNewDataTable)Table).NewWorkViewConditionNewRow();

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

            ((WorkViewTDS.WorkViewConditionNewDataTable)Table).AddWorkViewConditionNewRow(row);
        }



        /// <summary>
        /// InsertTemp
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conditionId"></param>
        /// <param name="name"></param>
        /// <param name="refId"></param>
        /// <param name="operator_"></param>
        /// <param name="sign"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="value_"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void InsertTemp(int id, int conditionId, string name, int refId, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewConditionNewRow row = ((WorkViewTDS.WorkViewConditionNewDataTable)Table).NewWorkViewConditionNewRow();

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

            ((WorkViewTDS.WorkViewConditionNewDataTable)Table).AddWorkViewConditionNewRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id"></param>
        /// <param name="conditionId"></param>
        /// <param name="refId"></param>
        /// <param name="operator_"></param>
        /// <param name="sign"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="value_"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void Update(int id, int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewConditionNewRow row = GetRow(id);

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
        /// <param name="id"></param>
        /// <param name="conditionId"></param>
        /// <param name="name"></param>
        /// <param name="operator_"></param>
        /// <param name="sign"></param>
        /// <param name="conditionNumber"></param>
        /// <param name="value_"></param>
        /// <param name="inDatabase"></param>
        /// <param name="deleted"></param>
        public void UpdateForEdit(int refId, int id, int conditionId, string name, string operator_, string sign, int conditionNumber, string value_, bool inDatabase, bool deleted)
        {
            WorkViewTDS.WorkViewConditionNewRow row = GetRow(id);

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
        /// <param name="id"></param>
        public void Delete(int id)
        {
            WorkViewTDS.WorkViewConditionNewRow row = GetRow(id);
            row.Deleted = true;            
        }



        /// <summary>
        /// Process a new section's table 
        /// </summary>
        public void ProcessNew()
        {
            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
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
        /// <param name="viewId"></param>
        /// <param name="companyId"></param>
        /// <param name="workType"></param>
        public void Save(int viewId, int companyId, string workType)
        {
            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
            {
                if (!rowNew.Deleted)
                {
                    WorkViewCondition workViewCondition = new WorkViewCondition(null);
                    workViewCondition.InsertDirect(viewId, companyId, workType, rowNew.ConditionID, rowNew.RefID, rowNew.Operator, rowNew.ConditionNumber, rowNew.Value_, rowNew.Deleted);
                }
            }
        }



        /// <summary>
        /// SaveForEdit
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="companyId"></param>
        /// <param name="workType"></param>
        public void SaveForEdit(int viewId, int companyId, string workType)
        {
            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
            {
                WorkViewCondition workViewCondition = new WorkViewCondition(null);

                if (!rowNew.Deleted && !rowNew.InDatabase)
                {
                    WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway(null);

                    int refId = workViewConditionGateway.GetLastRefIdByViewIdWorkTypeConditionId(viewId, companyId, workType, rowNew.ConditionID);
                    refId = refId + 1;
                    
                    workViewCondition.InsertDirect(viewId, companyId, workType, rowNew.ConditionID, refId, rowNew.Operator, rowNew.ConditionNumber, rowNew.Value_, rowNew.Deleted);
                }

                if (!rowNew.Deleted && rowNew.InDatabase)
                {
                    WorkViewConditionGateway workViewConditionGateway = new WorkViewConditionGateway();
                    workViewConditionGateway.LoadAllByViewIdWorkTypeConditionIdRefId(viewId, companyId, workType, rowNew.ConditionID, rowNew.RefID);

                    int originalViewId = viewId;
                    int originalCompanyId = companyId;
                    string originalWorkType = workType;
                    int originalConditionId = rowNew.ConditionID;
                    int originalRefId = rowNew.RefID; //workViewConditionGateway.GetRefId(viewId, workType, companyId, rowNew.ConditionID, rowNew.RefID);
                    string originalOperator_ = workViewConditionGateway.GetOperator(viewId, workType, companyId, rowNew.ConditionID, rowNew.RefID);
                    int originalConditionNumber = workViewConditionGateway.GetConditionNumber(viewId, workType, companyId, rowNew.ConditionID, rowNew.RefID);
                    string originalValue_ = workViewConditionGateway.GetValue_(viewId, workType, companyId, rowNew.ConditionID, rowNew.RefID);
                    bool originalDeleted = workViewConditionGateway.GetDeleted(viewId, workType, companyId, rowNew.ConditionID, rowNew.RefID);

                    workViewCondition.UpdateDirect(originalViewId, originalWorkType, originalCompanyId, originalConditionId, originalRefId, originalOperator_, originalConditionNumber, originalValue_, originalDeleted, viewId, workType, companyId, rowNew.ConditionID, rowNew.RefID, rowNew.Operator, rowNew.ConditionNumber, rowNew.Value_, rowNew.Deleted);

                }

                if (rowNew.Deleted && rowNew.InDatabase)
                {
                    workViewCondition.DeleteDirectForEditView(viewId, companyId, workType, rowNew.ConditionID, rowNew.RefID);
                }
            }
        }



        /// <summary>
        /// GetConditions
        /// </summary>
        /// <returns></returns>
        public ArrayList GetConditions()
        {
            ArrayList conditions = new ArrayList();

            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
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
        /// <returns></returns>
        public string GetConditionsByDefault()
        {
            string conditionsByDefault = "";
            string condition = "";
            ArrayList conditions = new ArrayList();

            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
            {
                if (!rowNew.Deleted && !conditions.Contains(rowNew.Name))
                {
                    conditions.Add(rowNew.Name);
                                   
                    condition = "";
                    condition = "(Condition" + rowNew.ConditionNumber; 
                    
                    string name = rowNew.Name;
                    int conditionNumber = rowNew.ConditionNumber;
                    
                    foreach (WorkViewTDS.WorkViewConditionNewRow rowNew2 in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
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
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public string ParserLogic(string originalLogic, string workType, int companyId)
        {
            string newLogic = "";

            if (workType == "Junction Lining")
            {
                if (originalLogic.Length > 0)
                {
                    newLogic = "(AASS.Deleted = 0) AND (LW.Deleted = 0) AND (AASL.Deleted = 0) AND (AASS.COMPANY_ID = {0}) AND (LW.ProjectID = {1}) AND (LW.WorkType = '{2}') AND ";
                }
                else
                {
                    newLogic = "(AASS.Deleted = 0) AND (LW.Deleted = 0) AND (AASL.Deleted = 0) AND (AASS.COMPANY_ID = {0}) AND (LW.ProjectID = {1}) AND (LW.WorkType = '{2}')";
                }
            }
            else
            {
                if (workType == "Manhole Rehabilitation")
                {
                    if (originalLogic.Length > 0)
                    {
                        newLogic = "(AASMHP.ProjectID = {1}) AND ";
                    }
                    else
                    {
                        newLogic = "(AASMHP.ProjectID = {1}) ";
                    }
                }
                else
                {
                    if (originalLogic.Length > 0)
                    {
                        newLogic = "(AASS.Deleted = 0) AND (LW.Deleted = 0) AND (AASS.COMPANY_ID = {0}) AND (LW.ProjectID = {1}) AND (LW.WorkType = '{2}') AND ";
                    }
                    else
                    {
                        newLogic = "(AASS.Deleted = 0) AND (LW.Deleted = 0) AND (AASS.COMPANY_ID = {0}) AND (LW.ProjectID = {1}) AND (LW.WorkType = '{2}')";
                    }
                }
            }

            WorkViewTDS.WorkViewConditionNewDataTable tableSorted = (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"];

            foreach (WorkViewTDS.WorkViewConditionNewRow rowNew in tableSorted.Select("", "ConditionNumber DESC"))
            {
                if (!rowNew.Deleted)
                {
                    string originalCondition = "Condition" + rowNew.ConditionNumber;

                    WorkTypeViewCondition workTypeViewCondition = new WorkTypeViewCondition();
                    workTypeViewCondition.LoadByWorkTypeConditionId(workType, rowNew.ConditionID, companyId);

                    WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway(workTypeViewCondition.Data);
                    string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, rowNew.ConditionID);

                    if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
                    if (tableName == "AM_ASSET_SEWER_LATERAL") tableName = "AASL";
                    if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
                    if (tableName == "LFS_ASSET_SEWER_LATERAL_CLIENT") tableName = "LASLC";
                    if (tableName == "LFS_WORK") tableName = "LW";
                    if (workType == "Rehab Assessment")
                    {
                        if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWFLL";
                    }
                    else
                    {
                        if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWF";
                    }
                    if (tableName == "LFS_WORK_FULLLENGTHLINING_M1") tableName = "LWFM1";
                    if (tableName == "LFS_WORK_FULLLENGTHLINING_M2") tableName = "LWFLLM2";
                    if (tableName == "LFS_WORK_FULLLENGTHLINING_P1") tableName = "LWFLP1";
                    if (tableName == "LFS_WORK_JUNCTIONLINING_SECTION") tableName = "LWJLS";
                    if (tableName == "LFS_WORK_JUNCTIONLINING_LATERAL") tableName = "LWJLL";
                    if (tableName == "LFS_WORK_REHABASSESSMENT") tableName = "LWR";
                    if (tableName == "LFS_WORK_POINT_REPAIRS") tableName = "LWPR";
                    if (tableName == "LFS_WORK_POINT_REPAIRS_REPAIR") tableName = "LWPRR";
                    if (tableName == "LFS_MIGRATED_SECTIONS") tableName = "LMS";
                    if (tableName == "LFS_WORK_MANHOLE_REHABILITATION") tableName = "LWMR";
                    if (tableName == "AM_ASSET_SEWER_MH") tableName = "AASMH";

                    string column = workTypeViewConditionGateway.GetColumn_(workType, companyId, rowNew.ConditionID);
                    string type = workTypeViewConditionGateway.GetType(workType, companyId, rowNew.ConditionID);
                    string sign = rowNew.Sign;
                    string conditionValue = rowNew.Value_;
                    string newCondition = "";

                    if (column == "USMH")
                    {
                        column = "MHID";
                        tableName = "AASUSMH";
                    }

                    if (column == "DSMH")
                    {
                        column = "MHID";
                        tableName = "AASDSMH";
                    }

                    if (column == "MN#")
                    {
                        column = "Address";
                    }

                    if (column == "USMHAddress")
                    {
                        column = "Address";
                        tableName = "AASUSMH";
                    }

                    if (column == "DSMHAddress")
                    {
                        column = "Address";
                        tableName = "AASDSMH";
                    }

                    // Search
                    if (conditionValue == "%")
                    {
                        if (type == "Boolean")
                        {
                            newCondition = newCondition + " ((" + tableName + "." + column + " = 1) OR (" + tableName + "." + column + " = 0))";
                        }
                        else
                        {
                            if ((workType == "Junction Lining") && ((column == "FlowOrderID") || (column == "LateralID")))
                            {
                                if (column == "FlowOrderID")
                                {
                                    newCondition = newCondition + " (((" + tableName + "." + column + " LIKE '%')";
                                    newCondition = newCondition + " OR (" + tableName + "." + column + " IS NULL))";
                                    newCondition = newCondition + " OR ((AASL.LateralID LIKE '%')";
                                    newCondition = newCondition + " OR (AASL.LateralID IS NULL)))";
                                }
                                else
                                {
                                    if (column == "LateralID")
                                    {
                                        newCondition = newCondition + " ((AASS.SectionID LIKE '%')";
                                        newCondition = newCondition + " OR (AASS.SectionID IS NULL))";
                                    }
                                }
                            }
                            else
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
                                    if (column != "CXIsRemoved")
                                    {
                                        if (sign == "=")
                                        {
                                            newCondition = newCondition + " ((" + tableName + "." + column + " LIKE '%')";
                                            newCondition = newCondition + " OR (" + tableName + "." + column + " IS NULL))";
                                        }

                                        if (sign == "<>")
                                        {
                                            newCondition = newCondition + " (" + tableName + "." + column + " IS NULL)";
                                        }
                                        else
                                        {
                                            if (sign != "=")
                                            {
                                                newCondition = newCondition + " ((" + tableName + "." + column + " LIKE '%')";
                                                newCondition = newCondition + " OR (" + tableName + "." + column + " IS NULL))";
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (conditionValue == "")
                        {
                            if (sign == "<>")
                            {
                                if ((workType == "Junction Lining") && ((column == "FlowOrderID") || (column == "LateralID")))
                                {
                                    if (column == "FlowOrderID")
                                    {
                                        newCondition = newCondition + " ((" + tableName + "." + column + " IS NOT NULL)";
                                        newCondition = newCondition + " OR (AASL.LateralID IS NOT NULL))";
                                    }
                                    else
                                    {
                                        if (column == "LateralID")
                                        {
                                            newCondition = newCondition + " (AASS.SectionID IS NOT NULL)";
                                        }
                                    }
                                }
                                else
                                {
                                    if (column != "CXIsRemoved")
                                    {
                                        newCondition = newCondition + tableName + "." + column + " IS NOT NULL ";
                                    }
                                    else
                                    {
                                        newCondition = newCondition + " (AASS.AssetID IN " +
                                                    " (SELECT AASS1.AssetID" +
                                                   " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved IS NOT NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                                    " ) )";
                                    }
                                }
                            }
                            else
                            {
                                if ((workType == "Junction Lining") && ((column == "FlowOrderID") || (column == "LateralID")))
                                {
                                    if (column == "FlowOrderID")
                                    {
                                        newCondition = newCondition + " ((" + tableName + "." + column + " IS NULL)";
                                        newCondition = newCondition + " OR (AASL.LateralID IS NULL))";
                                    }

                                    if (column == "LateralID")
                                    {
                                        newCondition = newCondition + " (AASS.SectionID IS NULL)";
                                    }
                                }
                                else
                                {
                                    if (column != "CXIsRemoved")
                                    {
                                        newCondition = newCondition + tableName + "." + column + " IS NULL ";
                                    }
                                    else
                                    {
                                        newCondition = newCondition + " (AASS.AssetID IN " +
                                                    " (SELECT AASS1.AssetID" +
                                                   " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved IS NULL) AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                                    " ) )";
                                    }
                                }
                            }
                        }
                        else
                        {
                            conditionValue = conditionValue.Replace("'", "''");

                            if ((type == "Int") || (type == "Decimal") || (type == "Boolean"))
                            {
                                if (conditionValue == "Yes") conditionValue = "1";
                                if (conditionValue == "No") conditionValue = "0";

                                if (column != "CXIsRemoved")
                                {
                                    newCondition = newCondition + tableName + "." + column + sign + conditionValue;
                                }
                                else
                                {
                                    newCondition = newCondition + " (AASS.AssetID IN " +
                                                    " (SELECT AASS1.AssetID" +
                                                   " FROM  AM_ASSET_SEWER_SECTION AASS1 INNER JOIN " +
                                 " LFS_WORK LW1 ON (AASS1.AssetID = LW1.AssetID) AND (LW1.WorkType = 'Full Length Lining') AND (LW1.ProjectID = LW.ProjectID) INNER JOIN " +
                                 " LFS_WORK_FULLLENGTHLINING_P1 LWFLP1 ON LW1.WorkID = LWFLP1.WorkID INNER JOIN LFS_WORK LW2 ON (AASS1.AssetID = LW2.AssetID) AND (LW2.WorkType = 'Rehab Assessment') AND (LW2.ProjectID = LW1.ProjectID) " +
                                 " WHERE ( (LWFLP1.CXIsRemoved " + sign + conditionValue + ") AND (AASS1.Deleted = 0) AND (LW1.Deleted = 0) AND (LWFLP1.Deleted = 0)) " +
                                                    " ) )";
                                }
                            }
                            else
                            {
                                if (sign == "=")
                                {
                                    if ((workType == "Junction Lining") && ((column == "FlowOrderID") || (column == "LateralID")))
                                    {
                                        if (column == "FlowOrderID")
                                        {
                                            newCondition = newCondition + " ((" + tableName + "." + column + " LIKE '%" + conditionValue + "%')";
                                            newCondition = newCondition + " OR (AASL.LateralID LIKE '%" + conditionValue + "%'))";
                                        }
                                        else
                                        {
                                            if (column == "LateralID")
                                            {
                                                newCondition = newCondition + "(AASS.FlowOrderID + '-JL-' + AASL.LateralID LIKE '%" + conditionValue + "%')";
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (type != "Date")
                                        {
                                            if (conditionValue.Contains("\""))
                                            {
                                                if (column != "Gasket")
                                                {
                                                    if (column != "Size_" && column != "VideoLengthToPropertyLine" && column != "DepthOfLocated")
                                                    {
                                                        conditionValue = conditionValue.Replace("\"", "");
                                                    }
                                                }

                                                newCondition = newCondition + " (" + tableName + "." + column + " = '" + conditionValue + "')";
                                            }
                                            else
                                            {
                                                if (column == "Issue" && conditionValue == "(All)")
                                                {
                                                    newCondition = newCondition + " ((LWJLL.Issue LIKE '%')";
                                                    newCondition = newCondition + " OR (LWJLL.Issue IS NULL))";
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
                                                newCondition = newCondition + " CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) " + sign + "'" + conditionValue + "'";
                                            }
                                            else
                                            {
                                                newCondition = newCondition + " CAST(CONVERT(varchar," + tableName + "." + column + ", 101) AS smalldatetime) LIKE '%" + conditionValue + "%'";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if ((workType == "Junction Lining") && (column == "FlowOrderID"))
                                    {
                                        newCondition = newCondition + " ((" + tableName + "." + column + sign + "'" + conditionValue + "')";
                                        newCondition = newCondition + " OR (AASL.LateralID " + sign + "'" + conditionValue + "'))";
                                    }
                                    else
                                    {
                                        if ((workType == "Junction Lining") && (column == "LateralID"))
                                        {
                                            newCondition = newCondition + " ((AASS.FlowOrderID + '-JL-' + AASL.LateralID NOT LIKE '%" + conditionValue + "%')";
                                            newCondition = newCondition + "OR (AASS.FlowOrderID + '-JL-' + AASL.LateralID IS NULL))";
                                        }
                                        else
                                        {
                                            if (column == "Comments" || column == "History")
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
        /// GetConditionsForSummary
        /// </summary>
        /// <param name="workType"></param>
        /// <param name="companyId"></param>
        /// <returns></returns>
        public string GetConditionsForSummary(string workType, int companyId)
        {
            string conditions = "";

            foreach (WorkViewTDS.WorkViewConditionNewRow row in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
            {
                if (!row.Deleted)
                {
                    WorkTypeViewCondition workTypeViewCondition = new WorkTypeViewCondition();
                    workTypeViewCondition.LoadByWorkTypeConditionId(workType, row.ConditionID, companyId);

                    WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway(workTypeViewCondition.Data);
                    if (row.Value_ == "")
                    {
                        conditions = conditions + "Condition" + row.ConditionNumber + ": " + workTypeViewConditionGateway.GetName(workType, companyId, row.ConditionID) + " " + row.Sign + " (empty), ";
                    }
                    else
                    {
                        conditions = conditions + "Condition" + row.ConditionNumber + ": " + workTypeViewConditionGateway.GetName(workType, companyId, row.ConditionID) + " " + row.Sign + " " + row.Value_ + ", ";
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
        /// <returns></returns>
        public int GetNewConditionNumber()
        {
            int newConditionNumber = 0;

            foreach (WorkViewTDS.WorkViewConditionNewRow row in (WorkViewTDS.WorkViewConditionNewDataTable)Data.Tables["WorkViewConditionNew"])
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
        /// LoadByViewIdCompanyIdWorkType
        /// </summary>
        /// <param name="viewId"></param>
        /// <param name="companyId"></param>
        /// <param name="workType"></param>
        public void LoadByViewIdCompanyIdWorkType(int viewId, int companyId, string workType)
        {
            // process temp table
            DataRow[] toCopy = Data.Tables["WorkViewConditionTemp"].Select();

            foreach (DataRow rowTemp in toCopy)
            {
                int id = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).ID;
                int conditionId = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).ConditionID;
                string name = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).Name;
                int refId = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).RefID;
                string operator_ = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).Operator;
                string sign = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).Sign;
                int conditionNumber = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).ConditionNumber;
                string value = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).Value_;
                bool inDatabase = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).InDatabase;
                bool deleted = ((WorkViewTDS.WorkViewConditionTempRow)rowTemp).Deleted;
                
                Insert(conditionId, name, operator_, sign, conditionNumber, value, inDatabase, deleted);
            }

            // load from database
            if (Table.Rows.Count == 0)
            {
                WorkViewConditionNewGateway workViewConditionNewGateway = new WorkViewConditionNewGateway(Data);
                workViewConditionNewGateway.LoadByViewIdWorkType(viewId, companyId, workType);
            }
        }



        /// <summary>
        /// ExistsConditionNumber
        /// </summary>
        /// <param name="conditionNumber"></param>
        /// <returns></returns>
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
        /// <param name="id"></param>
        /// <returns>WorkViewTDS.WorkViewConditionNewRow</returns>
        private WorkViewTDS.WorkViewConditionNewRow GetRow(int id)
        {
            WorkViewTDS.WorkViewConditionNewRow row = ((WorkViewTDS.WorkViewConditionNewDataTable)Table).FindByID(id);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.WorkViewConditionNew.GetRow");
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

            foreach (WorkViewTDS.WorkViewConditionNewRow row in (WorkViewTDS.WorkViewConditionNewDataTable)Table)
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
        /// <param name="conditionId"></param>
        /// <returns>RefId</returns>
        private int GetNewRefId(int conditionId)
        {
            int newRefId = 0;

            foreach (WorkViewTDS.WorkViewConditionNewRow row in (WorkViewTDS.WorkViewConditionNewDataTable)Table)
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