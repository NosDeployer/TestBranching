using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTime
    /// </summary>
    public class ProjectTime : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTime()
            : base("LFS_PROJECT_TIME")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTime(DataSet data)
            : base(data, "LFS_PROJECT_TIME")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="location">location</param>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="unitId">unitId</param>
        /// <param name="towedUnitId">towedUnitId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="fairWage">fairWage</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="createdById">createdById</param>
        public int Insert(int employeeId, int companiesId, int projectId, DateTime date_, DateTime? startTime, DateTime? endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, int? unitId, int? towedUnitId, string projectTimeState, string comments, string work_, string function_, bool fairWage, string jobClassType, int createdById)
        {
            // Insert new project time
            ProjectTimeTDS.LFS_PROJECT_TIMERow projectTimeRow = ((ProjectTimeTDS.LFS_PROJECT_TIMEDataTable)Table).NewLFS_PROJECT_TIMERow();

            projectTimeRow.ProjectTimeID = GetNewProjectTimeId();
            projectTimeRow.EmployeeID = employeeId;
            projectTimeRow.CompaniesID = companiesId;
            projectTimeRow.ProjectID = projectId;
            projectTimeRow.Date_ = date_;
            if (startTime.HasValue) projectTimeRow.StartTime = (DateTime)startTime; else projectTimeRow.SetStartTimeNull();
            if (endTime.HasValue) projectTimeRow.EndTime = (DateTime)endTime; else projectTimeRow.SetEndTimeNull();
            if (offset.HasValue) projectTimeRow.Offset = (double)offset; else projectTimeRow.SetOffsetNull();
            projectTimeRow.ProjectTime = CalculateProjectTime(startTime, endTime, offset);
            if (workingDetails != "") projectTimeRow.WorkingDetails = workingDetails; else projectTimeRow.SetWorkingDetailsNull();
            if (location != "") projectTimeRow.Location = location; else projectTimeRow.SetLocationNull();
            if (mealsCountry.HasValue) projectTimeRow.MealsCountry = (Int64)mealsCountry; else projectTimeRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") projectTimeRow.MealsAllowanceType = mealsAllowanceType; else projectTimeRow.SetMealsAllowanceTypeNull();
            projectTimeRow.MealsAllowance = (decimal)mealsAllowance;
            if (unitId.HasValue) projectTimeRow.UnitID = (int)unitId; else projectTimeRow.SetUnitIDNull();
            if (towedUnitId.HasValue) projectTimeRow.TowedUnitID = (int)towedUnitId; else projectTimeRow.SetTowedUnitIDNull();
            if (comments != "") projectTimeRow.Comments = comments; else projectTimeRow.SetCommentsNull();
            projectTimeRow.ProjectTimeState = projectTimeState;
            projectTimeRow.Deleted = false;
            if (work_ != "") projectTimeRow.Work_ = work_; else projectTimeRow.SetWork_Null();
            if (function_ != "") projectTimeRow.Function_ = function_; else projectTimeRow.SetFunction_Null();
            projectTimeRow.COMPANY_ID = 3;
            projectTimeRow.SetApprovedByIDNull();
            projectTimeRow.FairWage = fairWage;
            if (jobClassType != "") projectTimeRow.JobClassType = jobClassType; else projectTimeRow.SetJobClassTypeNull();

            projectTimeRow.CreatedByID = createdById;
            projectTimeRow.CreateDate = DateTime.Now;

            ((ProjectTimeTDS.LFS_PROJECT_TIMEDataTable)Table).AddLFS_PROJECT_TIMERow(projectTimeRow);

            return projectTimeRow.ProjectTimeID;
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectTimeTDSToSave">projectTimeTDSToSave</param>
        public void Insert(ProjectTimeTDS projectTimeTDSToSave, int createdById)
        {
            foreach (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow projectTimeRow in ((ProjectTimeTDS)Data).LFS_PROJECT_TIME_TEMP)
            {
                if (!projectTimeRow.Deleted)
                {
                    int employeeId = projectTimeRow.EmployeeID;
                    int companiesId = projectTimeRow.CompaniesID;
                    int projectId = projectTimeRow.ProjectID;
                    DateTime date_ = projectTimeRow.Date_;
                    DateTime? startTime = null;
                    if (!projectTimeRow.IsStartTimeNull())
                    {
                        string[] startTimeSplit = projectTimeRow.StartTime.Split(':');
                        int startTimeHour = Int32.Parse(startTimeSplit[0].ToString());
                        int startTimeMinute = Int32.Parse(startTimeSplit[1].ToString());
                        startTime = new DateTime(date_.Year, date_.Month, date_.Day, startTimeHour, startTimeMinute, 0);
                    }
                    DateTime? endTime = null;
                    if (!projectTimeRow.IsEndTimeNull())
                    {
                        string[] endTimeSplit = projectTimeRow.EndTime.Split(':');
                        int endTimeHour = Int32.Parse(endTimeSplit[0].ToString());
                        int endTimeMinute = Int32.Parse(endTimeSplit[1].ToString());
                        endTime = new DateTime(date_.Year, date_.Month, date_.Day, endTimeHour, endTimeMinute, 0);

                        if (endTime < startTime)
                        {
                            endTime.Value.AddDays(1);
                        }
                    }
                    double? offset = null; if (!projectTimeRow.IsOffsetNull()) offset = projectTimeRow.Offset;
                    string workingDetails = ""; if (!projectTimeRow.IsWorkingDetailsNull()) workingDetails = projectTimeRow.WorkingDetails;
                    string location = ""; if (!projectTimeRow.IsLocationNull()) location = projectTimeRow.Location;
                    Int64? mealsCountry = null; if (!projectTimeRow.IsMealsCountryNull()) mealsCountry = projectTimeRow.MealsCountry;
                    string mealsAllowanceType = ""; if (!projectTimeRow.IsMealsAllowanceTypeNull()) mealsAllowanceType = projectTimeRow.MealsAllowanceType;
                    decimal mealsAllowance = projectTimeRow.MealsAllowance;
                    string comments = ""; if (!projectTimeRow.IsCommentsNull()) comments = projectTimeRow.Comments;
                    int? unitId = null; if (!projectTimeRow.IsUnitIDNull()) unitId = projectTimeRow.UnitID;
                    int? towedUnitId = null; if (!projectTimeRow.IsTowedUnitIDNull()) towedUnitId = projectTimeRow.TowedUnitID;
                    string projectTimeState = projectTimeRow.ProjectTimeState;
                    bool deleted = projectTimeRow.Deleted;
                    string work_ = ""; if (!projectTimeRow.IsWork_Null()) work_ = projectTimeRow.Work_;
                    string function_ = ""; if (!projectTimeRow.IsFunction_Null()) function_ = projectTimeRow.Function_;
                    bool fairWage = projectTimeRow.FairWage;
                    string jobClassType = ""; if (!projectTimeRow.IsJobClassTypeNull()) jobClassType = projectTimeRow.JobClassType;

                    ProjectTime projectTimeToSave = new ProjectTime(Data);
                    projectTimeToSave.Insert(employeeId, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, projectTimeState, comments, work_, function_, fairWage, jobClassType, createdById);
                }
            }            
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="location">location</param>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="unitId">unitId</param>
        /// <param name="towedUnitId">towedUnitId</param>
        /// <param name="comments">comments</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="fairWage">fairWage</param>
        /// <param name="jobClassType">jobClassType</param>
        /// <param name="updatedById">updatedById</param>
        public void Update(int projectTimeId, int companiesId, int projectId, DateTime date_, DateTime? startTime, DateTime? endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, int? unitId, int? towedUnitId, string comments, string work_, string function_, bool fairWage, string jobClassType, int updatedById)
        {
            ProjectTimeTDS.LFS_PROJECT_TIMERow projectTimeRow = GetRow(projectTimeId);

            projectTimeRow.CompaniesID = companiesId;
            projectTimeRow.ProjectID = projectId;
            projectTimeRow.Date_ = date_;
            if (startTime.HasValue) projectTimeRow.StartTime = (DateTime)startTime; else projectTimeRow.SetStartTimeNull();
            if (endTime.HasValue) projectTimeRow.EndTime = (DateTime)endTime; else projectTimeRow.SetEndTimeNull();
            if (offset.HasValue) projectTimeRow.Offset = (double)offset; else projectTimeRow.SetOffsetNull();
            projectTimeRow.ProjectTime = CalculateProjectTime(startTime, endTime, offset);
            if (workingDetails != "") projectTimeRow.WorkingDetails = workingDetails; else projectTimeRow.SetWorkingDetailsNull();
            if (location != "") projectTimeRow.Location = location; else projectTimeRow.SetLocationNull();
            if (mealsCountry.HasValue) projectTimeRow.MealsCountry = (Int64)mealsCountry; else projectTimeRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") projectTimeRow.MealsAllowanceType = mealsAllowanceType; else projectTimeRow.SetMealsAllowanceTypeNull();
            projectTimeRow.MealsAllowance = (decimal)mealsAllowance;
            if (unitId.HasValue) projectTimeRow.UnitID = (int)unitId; else projectTimeRow.SetUnitIDNull();
            if (towedUnitId.HasValue) projectTimeRow.TowedUnitID = (int)towedUnitId; else projectTimeRow.SetTowedUnitIDNull();
            if (comments != "") projectTimeRow.Comments = comments; else projectTimeRow.SetCommentsNull();
            if (work_ != "") projectTimeRow.Work_ = work_; else projectTimeRow.SetWork_Null();
            if (function_ != "") projectTimeRow.Function_ = function_; else projectTimeRow.SetFunction_Null();
            projectTimeRow.FairWage = fairWage;
            if (jobClassType != "") projectTimeRow.JobClassType = jobClassType; else projectTimeRow.SetJobClassTypeNull();
            projectTimeRow.UpdateByID = updatedById;
            projectTimeRow.UpdateDate = DateTime.Now;
        }



        /// <summary>
        /// GetNewProjectTimeId
        /// </summary>
        /// <returns>int</returns>
        public int GetNewProjectTimeId()
        {
            int newProjectTimeId = 0;

            if (Data.Tables["LFS_PROJECT_TIME"].Rows.Count == 0)
            {
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                newProjectTimeId = projectTimeGateway.GetLastProjectTimeId();
            }

            foreach (ProjectTimeTDS.LFS_PROJECT_TIMERow row in ((ProjectTimeTDS)Data).LFS_PROJECT_TIME)
            {
                if (newProjectTimeId < row.ProjectTimeID)
                {
                    newProjectTimeId = row.ProjectTimeID;
                }
            }

            newProjectTimeId++;

            return newProjectTimeId;
        }



        /// <summary>
        /// Approve
        /// </summary>
        /// <param name="approvedById">approvedById</param>
        public void Approve(int approvedById)
        {
            foreach (ProjectTimeTDS.LFS_PROJECT_TIMERow projectTimeRow in (ProjectTimeTDS.LFS_PROJECT_TIMEDataTable)Table)
            {
                projectTimeRow.ProjectTimeState = "Approved";
                projectTimeRow.ApprovedByID = approvedById;
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        public void Delete(int projectTimeId, int deletedById)
        {
            ProjectTimeTDS.LFS_PROJECT_TIMERow projectTimeRow = GetRow(projectTimeId);
            projectTimeRow.Deleted = true;
            projectTimeRow.DeletedByID = deletedById;
            projectTimeRow.DeleteDate = DateTime.Now;
        }



        /// <summary>
        /// ValidateExistPayPeriod
        /// </summary>
        /// <param name="date">date</param>
        public static bool ValidateExistPayPeriod(DateTime date)
        {
            PayPeriodGateway payPeriodGateway = new PayPeriodGateway();
            payPeriodGateway.LoadByDate(date.Year, date.Month, date.Day);
            if (payPeriodGateway.Table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        /// <summary>
        /// ValidateLimitedPayPeriodToManagementEdit
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="projectId">projectId</param>
        public static bool ValidateLimitedPayPeriodToManagementEdit(DateTime date, int projectId)
        {
            bool isValid = true;

            if (projectId != 35 && projectId != 39)
            {
                if (!(date > DateTime.Now))
                {
                    TimeSpan diference;
                    int daysBeforeNow = 0;
                    diference = DateTime.Now - date;
                    daysBeforeNow = diference.Days;

                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            if (daysBeforeNow > 7 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Tuesday:
                            if (daysBeforeNow > 8 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Wednesday:
                            if (daysBeforeNow > 2 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Thursday:
                            if (daysBeforeNow > 3 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Friday:
                            if (daysBeforeNow > 4 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Saturday:
                            if (daysBeforeNow > 5 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Sunday:
                            if (daysBeforeNow > 6 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;
                    }
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }



        /// <summary>
        /// ValidateLimitedPayPeriodToWednesdayManagementEdit
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="projectId">projectId</param>
        public static bool ValidateLimitedPayPeriodToWednesdayManagementEdit(DateTime date, int projectId)
        {
            bool isValid = true;

            if (projectId != 35 && projectId != 39)
            {
                if (!(date > DateTime.Now))
                {
                    TimeSpan diference;
                    int daysBeforeNow = 0;
                    diference = DateTime.Now - date;
                    daysBeforeNow = diference.Days;

                    switch (DateTime.Now.DayOfWeek)
                    {
                        case DayOfWeek.Monday:
                            if (daysBeforeNow > 7 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Tuesday:
                            if (daysBeforeNow > 8 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Wednesday:
                            if (daysBeforeNow > 9 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Thursday:
                            if (daysBeforeNow > 3 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Friday:
                            if (daysBeforeNow > 4 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Saturday:
                            if (daysBeforeNow > 5 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;

                        case DayOfWeek.Sunday:
                            if (daysBeforeNow > 6 || daysBeforeNow < 0)
                            {
                                isValid = false;
                            }
                            break;
                    }
                }
                else
                {
                    isValid = false;
                }
            }

            return isValid;
        }


        

        /// <summary>
        /// ValidateExistFieldForWorkingDetails
        /// </summary>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="fieldValue">fieldValue</param>
        public static bool ValidateExistFieldForWorkingDetails(string workingDetails, string fieldValue)
        {
            if ((workingDetails == "USA") || (workingDetails == "Canada"))
            {
                if (fieldValue.Trim() != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// ValidateNotExistFieldForWorkingDetails
        /// </summary>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="fieldValue">fieldValue</param>
        public static bool ValidateNotExistFieldForWorkingDetails(string workingDetails, string fieldValue)
        {
            if ((workingDetails != "USA") && (workingDetails != "Canada"))
            {
                if (fieldValue.Trim() != "")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }



        /// <summary>
        /// ValidateMealsCountry
        /// </summary>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        public static bool ValidateMealsCountry(string mealsCountry, bool mealsAllowance)
        {
            if (mealsAllowance)
            {
                if (mealsCountry != "-1")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }



        /// <summary>
        /// ValidateMealsAllowance
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public static bool ValidateMealsAllowance(int projectTimeId, int employeeId, DateTime date_, string mealsCountry, bool mealsAllowance, int companyId)
        {
            if ((mealsCountry != "-1") && (mealsAllowance))
            {
                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                if (projectTimeId == -1)
                {
                    if (projectTimeGateway.ExistsMealsAllowanceByEmployeIdDate(employeeId, date_, companyId))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (projectTimeGateway.ExistsMealsAllowanceByProjectTimeIdEmployeIdDate(projectTimeId,employeeId, date_, companyId))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }



        /// <summary>
        /// ValidateExistPayPeriod
        /// </summary>
        /// <param name="date">date</param>
        public static bool ValidateIfNonWorkingDay(DateTime date, int employeeId, int companyId)
        {
            int companyLevelId = 2;//Default for Canada

            EmployeeGateway employeeGateway = new EmployeeGateway();
            employeeGateway.LoadByEmployeeId(employeeId);

            if (employeeGateway.GetType(employeeId).Contains("US"))
            {
                companyLevelId = 3;
            }

            VacationsNonWorkingDaysInformationGateway vacationsNonWorkingDaysInformationGateway = new VacationsNonWorkingDaysInformationGateway();
            if (vacationsNonWorkingDaysInformationGateway.IsNonWorkingDay(date, companyLevelId, companyId))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        /// <summary>
        /// ValidateIfExistsAVacation
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public static bool ValidateIfExistsAVacation(DateTime date, int employeeId, int companyId)
        {
            bool valid = true;

            VacationsInformationGateway vacationsInformationGateway = new VacationsInformationGateway();
            if (vacationsInformationGateway.IsFullVacationDay(date, employeeId, companyId))
            {
                valid = false;
            }
            else
            {
                int amountHalfDays = vacationsInformationGateway.IsHalfVacationDay(date, employeeId, companyId);
                if (amountHalfDays == 2)
                {
                    valid = false;
                }
                else
                {
                    if ((amountHalfDays == 0) || (amountHalfDays == 1))
                    {
                        valid = true;
                    }
                }
            }

            return valid;
        }



        /// <summary>
        /// ValidateProjectTime
        /// </summary>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        public static bool ValidateProjectTime(string startTime, string endTime, string offset)
        {
            DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
            DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
            double? offsetToCalculate = null; if (offset != "") offsetToCalculate = double.Parse(offset);

            if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
            {
                return (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 0) ? true : false;
            }
            return true;
        }



        /// <summary>
        /// CalculateProjectTime
        /// </summary>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        private static double CalculateProjectTime(DateTime? startTime, DateTime? endTime, double? offset)
        {
            double hours = 0;
            TimeSpan diference;

            if ((startTime.HasValue) && (endTime.HasValue))
            {
                if (!offset.HasValue)
                {
                    offset = 0;
                }

                if ((DateTime)endTime >= (DateTime)startTime)
                {
                    diference = (DateTime)endTime - (DateTime)startTime;
                    hours = (double)(((diference.Hours * 60 + diference.Minutes) - (offset * 60)) / 60);
                }
                else
                {
                    diference = (DateTime)startTime - (DateTime)endTime;
                    hours = (double)((1440 - (diference.Hours * 60 + diference.Minutes) - (offset * 60)) / 60);
                }
            }

            string hoursString = hours.ToString("f2");

            return double.Parse(hoursString);
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>ProjectTimeTDS.LFS_PROJECT_TIMERow</returns>
        private ProjectTimeTDS.LFS_PROJECT_TIMERow GetRow(int projectTimeId)
        {
            ProjectTimeTDS.LFS_PROJECT_TIMERow row = ((ProjectTimeTDS.LFS_PROJECT_TIMEDataTable)Table).FindByProjectTimeID(projectTimeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.GetRow");
            }

            return row;
        }



    }
}