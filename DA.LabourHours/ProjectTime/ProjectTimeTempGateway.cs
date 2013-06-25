using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeTempGateway
    /// </summary>
    public class ProjectTimeTempGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeTempGateway()
            : base("LFS_PROJECT_TIME_TEMP")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeTempGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME_TEMP")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "LFS_PROJECT_TIME_TEMP";
            tableMapping.ColumnMappings.Add("ProjectTimeID", "ProjectTimeID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("CompaniesID", "CompaniesID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("StartTime", "StartTime");
            tableMapping.ColumnMappings.Add("EndTime", "EndTime");
            tableMapping.ColumnMappings.Add("Offset", "Offset");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("Location", "Location");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowanceType", "MealsAllowanceType");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Work_", "Work_");
            tableMapping.ColumnMappings.Add("Function_", "Function_");
            tableMapping.ColumnMappings.Add("WorkFunctionConcat", "WorkFunctionConcat");
            tableMapping.ColumnMappings.Add("IsMealsAllowance", "IsMealsAllowance");
            tableMapping.ColumnMappings.Add("FairWage", "FairWage");
            tableMapping.ColumnMappings.Add("JobClassType", "JobClassType");
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
        /// GetRow
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectTimeId)
        {
            string filter = string.Format("ProjectTimeID = {0}", projectTimeId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.ProjectTime.ProjectTimeTempGateway.GetRow");
            }
        }



        /// <summary>
        /// GetEmployeeId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>EmployeeID</returns>
        public int GetEmployeeId(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["EmployeeID"];
        }



        /// <summary>
        /// GetEmployeeID Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original EmployeeID or EMPTY</returns>
        public int GetEmployeeIDOriginal(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["EmployeeID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCompaniesId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>CompaniesID</returns>
        public int GetCompaniesId(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["CompaniesID"];
        }



        /// <summary>
        /// GetCompaniesID Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original CompaniesID or EMPTY</returns>
        public int GetCompaniesIDOriginal(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["CompaniesID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetProjectId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectID</returns>
        public int GetProjectId(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["ProjectID"];
        }



        /// <summary>
        /// GetProjectID Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original ProjectID or EMPTY</returns>
        public int GetProjectIDOriginal(int projectTimeId)
        {
            return (int)GetRow(projectTimeId)["ProjectID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDate_
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Date_</returns>
        public DateTime GetDate_(int projectTimeId)
        {
            return (DateTime)GetRow(projectTimeId)["Date_"];
        }



        /// <summary>
        /// GetDate_ Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original Date_ or EMPTY</returns>
        public DateTime? GetDate_Original(int projectTimeId)
        {
            return (DateTime)GetRow(projectTimeId)["Date_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStartTime
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>StartTime or EMPTY</returns>
        public string GetStartTime(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("StartTime"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["StartTime"];
            }
        }



        /// <summary>
        /// GetStartTime Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original StartTime or EMPTY</returns>
        public string GetStartTimeOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["StartTime"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["StartTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetEndTime
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>EndTime or EMPTY </returns>
        public string GetEndTime(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("EndTime"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["EndTime"];
            }
        }



        /// <summary>
        /// GetEndTime Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original EndTime or EMPTY</returns>
        public string GetEndTimeOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["EndTime"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["EndTime", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetOffset
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Offset or null</returns>
        public double? GetOffset(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Offset"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["Offset"];
            }
        }



        /// <summary>
        /// GetOffset Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original Offset or null</returns>
        public int? GetOffsetOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["Offset"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["Offset", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetProjectTime
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectTime</returns>
        public double GetProjectTime(int projectTimeId)
        {
            return (double)GetRow(projectTimeId)["ProjectTime"];
        }



        /// <summary>
        /// GetProjectTime Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original ProjectTime or EMPTY</returns>
        public double GetProjectTimeOriginal(int projectTimeId)
        {
            return (double)GetRow(projectTimeId)["ProjectTime", DataRowVersion.Original];
        }



        /// <summary>
        /// GetWorkingDetails
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>WorkingDetails or EMPTY</returns>
        public string GetWorkingDetails(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("WorkingDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["WorkingDetails"];
            }
        }



        /// <summary>
        /// GetWorkingDetails Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original WorkingDetails or EMPTY</returns>
        public string GetWorkingDetailsOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["WorkingDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["WorkingDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLocation
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Location or EMPTY</returns>
        public string GetLocation(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Location"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Location"];
            }
        }



        /// <summary>
        /// GetLocation Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original Location or EMPTY</returns>
        public string GetLocationOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["Location"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Location", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMealsCountry
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>MealsCountry or null</returns>
        public Int64? GetMealsCountry(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("MealsCountry"))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(projectTimeId)["MealsCountry"];
            }
        }



        /// <summary>
        /// GetMealsCountry Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original MealsCountry or null</returns>
        public Int64? GetMealsCountryOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["MealsCountry"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (Int64)GetRow(projectTimeId)["MealsCountry", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMealsAllowanceType
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>MealsAllowanceType or EMPTY</returns>
        public string GetMealsAllowanceType(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("MealsAllowanceType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["MealsAllowanceType"];
            }
        }



        /// <summary>
        /// GetMealsAllowanceType Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original MealsAllowanceType or EMPTY</returns>
        public string GetMealsAllowanceTypeOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["MealsAllowanceType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["MealsAllowanceType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMealsAllowance
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>MealsAllowance</returns>
        public decimal GetMealsAllowance(int projectTimeId)
        {
            return (decimal)GetRow(projectTimeId)["MealsAllowance"];
        }



        /// <summary>
        /// GetMealsAllowance Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original MealsAllowance</returns>
        public decimal GetMealsAllowanceOriginal(int projectTimeId)
        {
            return (decimal)GetRow(projectTimeId)["MealsAllowance", DataRowVersion.Original];
        }



        /// <summary>
        /// GetUnitId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>UnitId or null</returns>
        public int? GetUnitId(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("UnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["UnitId"];
            }
        }



        /// <summary>
        /// GetUnitId Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original UnitId or null</returns>
        public int? GetUnitIdOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["UnitId"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["UnitId", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTowedUnitId
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>TowedUnitId or null</returns>
        public int? GetTowedUnitId(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("TowedUnitId"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["TowedUnitId"];
            }
        }



        /// <summary>
        /// GetTowedUnitId Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original TowedUnitId or null</returns>
        public int? GetTowedUnitIdOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["TowedUnitId"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectTimeId)["TowedUnitId", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProjectTimeState
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectTimeState</returns>
        public string GetProjectTimeState(int projectTimeId)
        {
            return (string)GetRow(projectTimeId)["ProjectTimeState"];
        }



        /// <summary>
        /// GetProjectTimeState Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original ProjectTimeState</returns>
        public string GetProjectTimeStateOriginal(int projectTimeId)
        {
            return (string)GetRow(projectTimeId)["ProjectTimeState", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetWork
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Work_ or EMPTY</returns>
        public string GetWork(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Work_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Work_"];
            }
        }



        /// <summary>
        /// GetWork_ Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original Work_ or EMPTY</returns>
        public string GetWork_Original(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["Work_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Work_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFunction
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Function_ or EMPTY</returns>
        public string GetFunction(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("Function_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Function_"];
            }
        }



        /// <summary>
        /// GetFunction_ Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original Function_ or EMPTY</returns>
        public string GetFunction_Original(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["Function_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["Function_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetWorkFunctionConcat
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>WorkFunctionConcat or EMPTY</returns>
        public string GetWorkFunctionConcat(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("WorkFunctionConcat"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["WorkFunctionConcat"];
            }
        }



        /// <summary>
        /// GetWorkFunctionConcat Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original WorkFunctionConcat or EMPTY</returns>
        public string GetWorkFunctionConcatOriginal(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull(Table.Columns["WorkFunctionConcat"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["WorkFunctionConcat", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIsMealsAllowance
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>IsMealsAllowance</returns>
        public bool GetIsMealsAllowance(int projectTimeId)
        {
            return (bool)GetRow(projectTimeId)["IsMealsAllowance"];
        }



        /// <summary>
        /// GetIsMealsAllowance Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original IsMealsAllowance</returns>
        public bool GetIsMealsAllowanceOriginal(int projectTimeId)
        {
            return (bool)GetRow(projectTimeId)["IsMealsAllowance", DataRowVersion.Original];
        }



        /// <summary>
        /// GetFairWage
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>FairWage</returns>
        public bool GetFairWage(int projectTimeId)
        {
            return (bool)GetRow(projectTimeId)["FairWage"];
        }



        /// <summary>
        /// GetFairWage Original
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>Original FairWage</returns>
        public bool GetFairWageOriginal(int projectTimeId)
        {
            return (bool)GetRow(projectTimeId)["FairWage", DataRowVersion.Original];
        }




        /// <summary>
        /// GetJobClassType
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>JobClassType or EMPTY </returns>
        public string GetJobClassType(int projectTimeId)
        {
            if (GetRow(projectTimeId).IsNull("JobClassType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectTimeId)["JobClassType"];
            }
        }

        

    }
}