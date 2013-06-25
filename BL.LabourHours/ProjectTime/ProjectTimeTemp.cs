using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeTemp
    /// </summary>
    public class ProjectTimeTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeTemp()
            : base("LFS_PROJECT_TIME_TEMP")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeTemp(DataSet data)
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
        /// <param name="isMealsAllowance">isMealsAllowance</param>
        /// <param name="unitId">unitId</param>
        /// <param name="towedUnitId">towedUnitId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="workFunctionConcat">workFunctionConcat</param>
        /// <param name="fairWage">fairWage</param>
        /// <param name="jobClassType">jobClassType</param>
        public void Insert(int employeeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, bool isMealsAllowance, decimal mealsAllowance, int? unitId, int? towedUnitId, string projectTimeState, string comments, string work_, string function_, string workFunctionConcat, bool fairWage, string jobClassType)
        {
            // Insert new project time
            ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow projectTimeRow = ((ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Table).NewLFS_PROJECT_TIME_TEMPRow();

            projectTimeRow.ProjectTimeID = GetNewProjectTimeId();
            projectTimeRow.EmployeeID = employeeId;
            projectTimeRow.CompaniesID = companiesId;
            projectTimeRow.ProjectID = projectId;
            projectTimeRow.Date_ = date_;
            if (startTime != "") projectTimeRow.StartTime = startTime; else projectTimeRow.SetStartTimeNull();
            DateTime? startTimeD = null; if (startTime != "") startTimeD = DateTime.Parse(startTime);
            if (endTime != "") projectTimeRow.EndTime = endTime; else projectTimeRow.SetEndTimeNull();
            DateTime? endTimeD = null; if (endTime != "") endTimeD = DateTime.Parse(endTime);
            if (offset.HasValue) projectTimeRow.Offset = (double)offset; else projectTimeRow.SetOffsetNull();
            projectTimeRow.ProjectTime = CalculateProjectTime(startTimeD, endTimeD, offset);
            if (workingDetails != "") projectTimeRow.WorkingDetails = workingDetails; else projectTimeRow.SetWorkingDetailsNull();
            if (location != "") projectTimeRow.Location = location; else projectTimeRow.SetLocationNull();
            if (mealsCountry.HasValue) projectTimeRow.MealsCountry = (Int64)mealsCountry; else projectTimeRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") projectTimeRow.MealsAllowanceType = mealsAllowanceType; else projectTimeRow.SetMealsAllowanceTypeNull();
            projectTimeRow.MealsAllowance = (decimal)mealsAllowance;
            projectTimeRow.IsMealsAllowance = isMealsAllowance;
            if (unitId.HasValue) projectTimeRow.UnitID = (int)unitId; else projectTimeRow.SetUnitIDNull();
            if (towedUnitId.HasValue) projectTimeRow.TowedUnitID = (int)towedUnitId; else projectTimeRow.SetTowedUnitIDNull();
            if (comments != "") projectTimeRow.Comments = comments; else projectTimeRow.SetCommentsNull();
            projectTimeRow.ProjectTimeState = projectTimeState;
            projectTimeRow.Deleted = false;
            projectTimeRow.Work_ = work_;
            projectTimeRow.Function_ = function_;
            projectTimeRow.WorkFunctionConcat = workFunctionConcat;
            projectTimeRow.FairWage = fairWage;
            if (jobClassType != "") projectTimeRow.JobClassType = jobClassType; else projectTimeRow.SetJobClassTypeNull();

            ((ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Table).AddLFS_PROJECT_TIME_TEMPRow(projectTimeRow);
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
        /// <param name="isMealsAllowance">isMealsAllowance</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="unitId">unitId</param>
        /// <param name="towedUnitId">towedUnitId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="workFunctionConcat">workFunctionConcat</param>
        /// <param name="fairWage">fairWage</param>
        /// <param name="jobClassType">jobClassType</param>
        public void Update(int projectTimeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, bool isMealsAllowance, decimal mealsAllowance, int? unitId, int? towedUnitId, string comments, string work_, string function_, string workFunctionConcat, bool fairWage, string jobClassType)
        {
            ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow projectTimeRow = GetRow(projectTimeId);

            projectTimeRow.CompaniesID = companiesId;
            projectTimeRow.ProjectID = projectId;
            projectTimeRow.Date_ = date_;
            if (startTime != "") projectTimeRow.StartTime = startTime; else projectTimeRow.SetStartTimeNull();
            DateTime? startTimeD = null; if (startTime != "") startTimeD = DateTime.Parse(startTime);
            if (endTime != "") projectTimeRow.EndTime = endTime; else projectTimeRow.SetEndTimeNull();
            DateTime? endTimeD = null; if (endTime != "") endTimeD = DateTime.Parse(endTime);
            if (offset.HasValue) projectTimeRow.Offset = (double)offset; else projectTimeRow.SetOffsetNull();
            projectTimeRow.ProjectTime = CalculateProjectTime(startTimeD, endTimeD, offset);
            if (workingDetails != "") projectTimeRow.WorkingDetails = workingDetails; else projectTimeRow.SetWorkingDetailsNull();
            if (location != "") projectTimeRow.Location = location; else projectTimeRow.SetLocationNull();
            if (mealsCountry.HasValue) projectTimeRow.MealsCountry = (Int64)mealsCountry; else projectTimeRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") projectTimeRow.MealsAllowanceType = mealsAllowanceType; else projectTimeRow.SetMealsAllowanceTypeNull();
            projectTimeRow.MealsAllowance = (decimal)mealsAllowance;
            projectTimeRow.IsMealsAllowance = isMealsAllowance;
            if (unitId.HasValue) projectTimeRow.UnitID = (int)unitId; else projectTimeRow.SetUnitIDNull();
            if (towedUnitId.HasValue) projectTimeRow.TowedUnitID = (int)towedUnitId; else projectTimeRow.SetTowedUnitIDNull();
            if (comments != "") projectTimeRow.Comments = comments; else projectTimeRow.SetCommentsNull();
            projectTimeRow.Work_ = work_;
            projectTimeRow.Function_ = function_;
            projectTimeRow.WorkFunctionConcat = workFunctionConcat;
            projectTimeRow.FairWage = fairWage;
            if (jobClassType != "") projectTimeRow.JobClassType = jobClassType; else projectTimeRow.SetJobClassTypeNull();
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectTimeId">projectTimeId</param>
        public void Delete(int projectTimeId)
        {
            ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow projectTimeRow = GetRow(projectTimeId);
            projectTimeRow.Deleted = true;
        }



        /// <summary>
        /// ValidateMealsAllowance
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <returns>True or false</returns>
        public bool ValidateMealsAllowance(int employeeId, bool mealsAllowance)
        {
            if (mealsAllowance)
            {
                int mealsAllowances = 1;

                if (Table.Rows.Count > 0)
                {
                    foreach (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow row in (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Table)
                    {
                        if ((row.IsMealsAllowance) && (row.EmployeeID == employeeId) && (!row.Deleted))
                        {
                            mealsAllowances++;
                        }
                    }
                }
                else
                {
                    return true;
                }

                if (mealsAllowances == 1)
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
        /// ValidateMealsAllowanceEdit
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>True or false</returns>
        public bool ValidateMealsAllowanceEdit(int employeeId, bool mealsAllowance, int projectTimeId)
        {
            if (mealsAllowance)
            {
                int mealsAllowances = 1;

                if (Table.Rows.Count > 0)
                {
                    foreach (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow row in (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Table)
                    {
                        if (row.ProjectTimeID != projectTimeId)
                        {
                            if ((row.IsMealsAllowance) && (row.EmployeeID == employeeId) && (!row.Deleted))
                            {
                                mealsAllowances++;
                            }
                        }
                    }
                }
                else
                {
                    return true;
                }

                if (mealsAllowances == 1)
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
        /// NotExistsByEmployeIdDate_StartTimeEndTime
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <returns>True or false</returns>
        public bool NotExistsByEmployeIdDate_StartTimeEndTime(int employeeId, DateTime date_, string startTime, string endTime)
        {
            bool noExists = true;
            if (Table.Rows.Count > 0)
            {
                foreach (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow row in (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Table)
                {
                    if ((row.EmployeeID == employeeId) && (row.Date_ == date_) && (row.Deleted == false))
                    {
                        // Get start, end times.
                        TimeSpan spanGridStartTime = TimeSpan.Parse(row.StartTime);
                        TimeSpan spanGridEndTime = TimeSpan.Parse(row.EndTime);
                        TimeSpan spanStartTime = TimeSpan.Parse(startTime);
                        TimeSpan spanEndTime = TimeSpan.Parse(endTime);

                        string twentyForHours = "23:59";                        
                        TimeSpan midNight = TimeSpan.Parse(twentyForHours);                        

                        // When End Time < StartTime   (when they finish work the next day)
                        if ((spanGridEndTime < spanGridStartTime) && (spanEndTime > spanStartTime))
                        {
                            if (((spanStartTime >= spanGridStartTime) && (spanStartTime <= midNight)) || ((spanEndTime >= spanGridStartTime) && (spanEndTime <= midNight)))
                            {
                                noExists = false;
                                return noExists;
                            }
                        }
                        else
                        {
                            if ((spanEndTime < spanStartTime) && (spanGridEndTime > spanGridStartTime))
                            {
                                if (((spanGridStartTime >= spanStartTime) && ( midNight <= spanStartTime)) || (( spanGridStartTime >= spanEndTime) && (midNight <= spanEndTime)))
                                {
                                    noExists = false;
                                    return noExists;
                                }
                            }
                            else
                            {
                                if ((spanGridEndTime < spanGridStartTime) && (spanEndTime < spanStartTime))
                                {
                                    noExists = false;
                                    return noExists;
                                }
                                else
                                {
                                    // When End Time > Start Time.  (times in the same day)
                                    if (((spanStartTime < spanGridStartTime) && (spanEndTime <= spanGridStartTime)) || ((spanStartTime >= spanGridEndTime) && (spanEndTime > spanGridEndTime)))
                                    {
                                        noExists = true;
                                    }
                                    else
                                    {
                                        noExists = false;
                                        return noExists;
                                    }
                                }
                            }
                        }                        
                    }
                }
            }

            return noExists;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

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
        /// <returns>ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow</returns>
        private ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow GetRow(int projectTimeId)
        {
            ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow row = ((ProjectTimeTDS.LFS_PROJECT_TIME_TEMPDataTable)Table).FindByProjectTimeID(projectTimeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeTemp.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewProjectTimeId
        /// </summary>
        /// <returns>int</returns>
        public int GetNewProjectTimeId()
        {
            int newProjectTimeId = 0;

            foreach (ProjectTimeTDS.LFS_PROJECT_TIME_TEMPRow row in ((ProjectTimeTDS)Data).LFS_PROJECT_TIME_TEMP)
            {
                if (newProjectTimeId < row.ProjectTimeID)
                {
                    newProjectTimeId = row.ProjectTimeID;
                }
            }

            newProjectTimeId++;

            return newProjectTimeId;
        }



    }
}