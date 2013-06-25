using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2DetailsTemp
    /// </summary>
    public class TeamProjectTime2DetailTemp : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2DetailTemp()
            : base("LFS_TEAM_PROJECT_TIME_DETAIL_TEMP")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public TeamProjectTime2DetailTemp(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_DETAIL_TEMP")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TeamProjectTime2TDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load all TeamProjectTimeDetails by TeamProjectTimeId
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        public void LoadAllByTeamProjectTimeId(int teamProjectTimeId)
        {
            Table.Rows.Clear();

            TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(Data);
            teamProjectTime2DetailGateway.LoadAllByTeamProjectTimeId(teamProjectTimeId);

            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow row in ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)teamProjectTime2DetailGateway.Table))
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow newRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table).NewLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow();

                newRow.TeamProjectTimeID = row.TeamProjectTimeID;
                newRow.DetailID = row.DetailID;
                newRow.EmployeeID = row.EmployeeID;
                newRow.CompaniesID = row.CompaniesID;
                newRow.ProjectID = row.ProjectID;
                newRow.Date_ = row.Date_;
                if (row.IsStartTimeNull()) newRow.SetStartTimeNull(); else newRow.StartTime = row.StartTime;
                if (row.IsEndTimeNull()) newRow.SetEndTimeNull(); else newRow.EndTime = row.EndTime;
                if (row.IsOffsetNull()) newRow.SetOffsetNull(); else newRow.Offset = row.Offset;
                newRow.ProjectTime = row.ProjectTime;
                if (row.IsWorkingDetailsNull()) newRow.SetWorkingDetailsNull(); else newRow.WorkingDetails = row.WorkingDetails;
                if (row.IsLocationNull()) newRow.SetLocationNull(); else newRow.Location = row.Location;
                if (row.IsMealsCountryNull()) newRow.SetMealsCountryNull(); else newRow.MealsCountry = row.MealsCountry;
                newRow.MealsAllowance = false; if (row.MealsAllowance > 0) newRow.MealsAllowance = true;
                if (row.IsUnitIDNull()) newRow.SetUnitIDNull(); else newRow.UnitID = row.UnitID;
                if (row.IsTowedUnitIDNull()) newRow.SetTowedUnitIDNull(); else newRow.TowedUnitID = row.TowedUnitID;
                newRow.ProjectTimeState = row.ProjectTimeState;
                if (row.IsCommentsNull()) newRow.SetCommentsNull(); else newRow.Comments = row.Comments;
                newRow.Deleted = row.Deleted;

                newRow.SetWork_Null(); if (!row.IsNull("Work_")) newRow.Work_ = row.Work_;
                newRow.SetFunction_Null(); if (!row.IsNull("Function_")) newRow.Function_ = row.Function_;
                newRow.SetWorkFunctionConcatNull();

                if ((!row.IsNull("Work_")) && (!row.IsNull("Function_")))
                {
                    newRow.WorkFunctionConcat = row.Work_ + " . " + row.Function_;
                }

                newRow.FairWage = row.FairWage;
                if(row.IsJobClassTypeNull()) newRow.SetJobClassTypeNull(); else newRow.JobClassType = row.JobClassType;

                ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table).AddLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow(newRow);
            }
        }



        /// <summary>
        /// Insert TeamProjectTimeDetailTemp
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
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
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="fairWage">fairWage</param>
        public void Insert(int teamProjectTimeId, int employeeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, bool mealsAllowance, string projectTimeState, string comments, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow teamProjectTimeDetailRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table).NewLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow();

            teamProjectTimeDetailRow.TeamProjectTimeID = teamProjectTimeId;
            teamProjectTimeDetailRow.DetailID = GetNewDetailId();
            teamProjectTimeDetailRow.EmployeeID = employeeId;
            teamProjectTimeDetailRow.CompaniesID = companiesId;
            teamProjectTimeDetailRow.ProjectID = projectId;
            teamProjectTimeDetailRow.Date_ = date_;
            if (startTime != "") teamProjectTimeDetailRow.StartTime = startTime; else teamProjectTimeDetailRow.SetStartTimeNull();
            if (endTime != "") teamProjectTimeDetailRow.EndTime = endTime; else teamProjectTimeDetailRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeDetailRow.Offset = (double)offset; else teamProjectTimeDetailRow.SetOffsetNull();
            teamProjectTimeDetailRow.ProjectTime = 0;
            if (workingDetails != "") teamProjectTimeDetailRow.WorkingDetails = workingDetails; else teamProjectTimeDetailRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeDetailRow.Location = location; else teamProjectTimeDetailRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeDetailRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeDetailRow.SetMealsCountryNull();
            teamProjectTimeDetailRow.MealsAllowance = mealsAllowance;
            teamProjectTimeDetailRow.SetUnitIDNull();
            teamProjectTimeDetailRow.SetTowedUnitIDNull();
            teamProjectTimeDetailRow.ProjectTimeState = projectTimeState;
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.Deleted = false;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();

            ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table).AddLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow(teamProjectTimeDetailRow);

            // Insert real detail
            string mealsAllowanceType2 = ""; if (mealsAllowance) mealsAllowanceType2 = "Full Day";
            decimal mealsAllowance2 = MealsAllowance.GetMealsAllowance(mealsCountry, mealsAllowance, mealsAllowanceType2);

            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.Insert(teamProjectTimeId, employeeId, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType2, mealsAllowance2, projectTimeState, comments, fairWage, jobClassType);
        }



        /// <summary>
        /// Insert TeamProjectTimeDetailTemp
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">date_</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        /// <param name="towedUnits">towedUnits</param>
        /// <param name="units">units</param>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="location">location</param>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="workFunctionConcat">workFunctionConcat</param>
        /// <param name="fairWage">fairWage</param>
        public void Insert(int teamProjectTimeId, int employeeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, bool mealsAllowance, int? units, int? towedUnits, string projectTimeState, string comments, string work_, string function_, string workFunctionConcat, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow teamProjectTimeDetailRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table).NewLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow();

            teamProjectTimeDetailRow.TeamProjectTimeID = teamProjectTimeId;
            teamProjectTimeDetailRow.DetailID = GetNewDetailId();
            teamProjectTimeDetailRow.EmployeeID = employeeId;
            teamProjectTimeDetailRow.CompaniesID = companiesId;
            teamProjectTimeDetailRow.ProjectID = projectId;
            teamProjectTimeDetailRow.Date_ = date_;
            if (startTime != "") teamProjectTimeDetailRow.StartTime = startTime; else teamProjectTimeDetailRow.SetStartTimeNull();
            if (endTime != "") teamProjectTimeDetailRow.EndTime = endTime; else teamProjectTimeDetailRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeDetailRow.Offset = (double)offset; else teamProjectTimeDetailRow.SetOffsetNull();
            teamProjectTimeDetailRow.ProjectTime = 0;
            if (workingDetails != "") teamProjectTimeDetailRow.WorkingDetails = workingDetails; else teamProjectTimeDetailRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeDetailRow.Location = location; else teamProjectTimeDetailRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeDetailRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeDetailRow.SetMealsCountryNull();
            teamProjectTimeDetailRow.MealsAllowance = mealsAllowance;
            if (units != null) teamProjectTimeDetailRow.UnitID = (int)units; else teamProjectTimeDetailRow.SetUnitIDNull();
            if (towedUnits != null) teamProjectTimeDetailRow.TowedUnitID = (int)towedUnits; else teamProjectTimeDetailRow.SetTowedUnitIDNull();
            teamProjectTimeDetailRow.ProjectTimeState = projectTimeState;
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.Deleted = false;
            teamProjectTimeDetailRow.Work_ = work_;
            teamProjectTimeDetailRow.Function_ = function_;
            teamProjectTimeDetailRow.WorkFunctionConcat = workFunctionConcat;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();

            ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table).AddLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow(teamProjectTimeDetailRow);

            // Insert real detail
            string mealsAllowanceType2 = ""; if (mealsAllowance) mealsAllowanceType2 = "Full Day";
            decimal mealsAllowance2 = MealsAllowance.GetMealsAllowance(mealsCountry, mealsAllowance, mealsAllowanceType2);

            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.Insert(teamProjectTimeId, employeeId, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType2, mealsAllowance2, projectTimeState, comments, units, towedUnits, work_, function_, fairWage, jobClassType);
        }



        /// <summary>
        /// Update TeamProjectTimeDetailTemp
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="location">location</param>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="unitId">unitId</param>
        /// <param name="towedUnitId">towedUnitId</param>
        /// <param name="comments">comments</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="workFunctionConcat">workFunctionConcat</param>
        /// <param name="fairWage">fairWage</param>
        public void Update(int teamProjectTimeId, int detailId, int employeeId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, bool mealsAllowance, int? unitId, int? towedUnitId, string comments, string work_, string function_, string workFunctionConcat, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow teamProjectTimeDetailRow = GetRow(teamProjectTimeId, detailId);
            
            teamProjectTimeDetailRow.Date_ = date_;
            teamProjectTimeDetailRow.EmployeeID = employeeId;
            if (startTime != "") teamProjectTimeDetailRow.StartTime = startTime; else teamProjectTimeDetailRow.SetStartTimeNull();
            if (endTime != "") teamProjectTimeDetailRow.EndTime = endTime; else teamProjectTimeDetailRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeDetailRow.Offset = (double)offset; else teamProjectTimeDetailRow.SetOffsetNull();
            if (workingDetails != "") teamProjectTimeDetailRow.WorkingDetails = workingDetails; else teamProjectTimeDetailRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeDetailRow.Location = location; else teamProjectTimeDetailRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeDetailRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeDetailRow.SetMealsCountryNull();
            teamProjectTimeDetailRow.MealsAllowance = mealsAllowance;
            if (unitId.HasValue) teamProjectTimeDetailRow.UnitID = (int)unitId; else teamProjectTimeDetailRow.SetUnitIDNull();
            if (towedUnitId.HasValue) teamProjectTimeDetailRow.TowedUnitID = (int)towedUnitId; else teamProjectTimeDetailRow.SetTowedUnitIDNull();
            teamProjectTimeDetailRow.ProjectTime = 0;
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.Work_ = work_;
            teamProjectTimeDetailRow.Function_ = function_;
            teamProjectTimeDetailRow.WorkFunctionConcat = workFunctionConcat;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();

            // Update real detail
            string mealsAllowanceType2 = ""; if (mealsAllowance) mealsAllowanceType2 = "Full Day";
            decimal mealsAllowance2 = MealsAllowance.GetMealsAllowance(mealsCountry, mealsAllowance, mealsAllowanceType2);

            TeamProjectTime2Detail teamProjectTimeDetail = new TeamProjectTime2Detail(Data);
            teamProjectTimeDetail.Update(teamProjectTimeId, detailId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType2, mealsAllowance2, unitId, towedUnitId, teamProjectTimeDetailRow.ProjectTimeState, comments, work_, function_, fairWage, jobClassType);
        }



        /// <summary>
        /// Update all TeamProjectTimeDetailTemps
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        public void UpdateAll(int teamProjectTimeId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow lfsTeamProjectTimeRow = ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME.FindByTeamProjectTimeID(teamProjectTimeId);

            // Update all detail
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow lfsTeamProjectTimeDetailTempRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL_TEMP)
            {
                lfsTeamProjectTimeDetailTempRow.CompaniesID = lfsTeamProjectTimeRow.CompaniesID;
                lfsTeamProjectTimeDetailTempRow.ProjectID = lfsTeamProjectTimeRow.ProjectID;
                lfsTeamProjectTimeDetailTempRow.Date_ = lfsTeamProjectTimeRow.Date_;
                lfsTeamProjectTimeDetailTempRow.StartTime = (lfsTeamProjectTimeRow.IsStartTimeNull()) ? null : lfsTeamProjectTimeRow.StartTime.ToShortTimeString();
                lfsTeamProjectTimeDetailTempRow.EndTime = (lfsTeamProjectTimeRow.IsEndTimeNull()) ? null : lfsTeamProjectTimeRow.EndTime.ToShortTimeString();
                if (lfsTeamProjectTimeRow.IsOffsetNull()) lfsTeamProjectTimeDetailTempRow.SetOffsetNull(); else lfsTeamProjectTimeDetailTempRow.Offset = lfsTeamProjectTimeRow.Offset;
                lfsTeamProjectTimeDetailTempRow.WorkingDetails = lfsTeamProjectTimeRow.WorkingDetails;
                lfsTeamProjectTimeDetailTempRow.Location = (lfsTeamProjectTimeRow.IsLocationNull()) ? null : lfsTeamProjectTimeRow.Location;
                if (lfsTeamProjectTimeRow.IsMealsCountryNull()) lfsTeamProjectTimeDetailTempRow.SetMealsCountryNull(); else lfsTeamProjectTimeDetailTempRow.MealsCountry = lfsTeamProjectTimeRow.MealsCountry;
                lfsTeamProjectTimeDetailTempRow.MealsAllowance = (lfsTeamProjectTimeRow.MealsAllowance > 0) ? true : false;
                lfsTeamProjectTimeDetailTempRow.SetUnitIDNull();
                lfsTeamProjectTimeDetailTempRow.SetTowedUnitIDNull();
                lfsTeamProjectTimeDetailTempRow.SetCommentsNull();
                lfsTeamProjectTimeDetailTempRow.Work_ = lfsTeamProjectTimeRow.Work_;
                lfsTeamProjectTimeDetailTempRow.Function_ = lfsTeamProjectTimeRow.Function_;                
                lfsTeamProjectTimeDetailTempRow.WorkFunctionConcat = lfsTeamProjectTimeRow.Work_ + " . " + lfsTeamProjectTimeRow.Function_;
                lfsTeamProjectTimeDetailTempRow.FairWage = lfsTeamProjectTimeRow.FairWage;
            }

            // Update all real detail
            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.UpdateAll(teamProjectTimeId);
        }



        /// <summary>
        /// Update all TeamProjectTimeDetailTemps
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="clearUnitAssigment">clearUnitAssigment</param>
        public void UpdateAll(int teamProjectTimeId, bool clearUnitAssigment)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow lfsTeamProjectTimeRow = ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME.FindByTeamProjectTimeID(teamProjectTimeId);

            // Update all detail
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow lfsTeamProjectTimeDetailTempRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL_TEMP)
            {
                lfsTeamProjectTimeDetailTempRow.CompaniesID = lfsTeamProjectTimeRow.CompaniesID;
                lfsTeamProjectTimeDetailTempRow.ProjectID = lfsTeamProjectTimeRow.ProjectID;
                lfsTeamProjectTimeDetailTempRow.Date_ = lfsTeamProjectTimeRow.Date_;
                lfsTeamProjectTimeDetailTempRow.StartTime = (lfsTeamProjectTimeRow.IsStartTimeNull()) ? null : lfsTeamProjectTimeRow.StartTime.ToShortTimeString();
                lfsTeamProjectTimeDetailTempRow.EndTime = (lfsTeamProjectTimeRow.IsEndTimeNull()) ? null : lfsTeamProjectTimeRow.EndTime.ToShortTimeString();
                if (lfsTeamProjectTimeRow.IsOffsetNull()) lfsTeamProjectTimeDetailTempRow.SetOffsetNull(); else lfsTeamProjectTimeDetailTempRow.Offset = lfsTeamProjectTimeRow.Offset;
                lfsTeamProjectTimeDetailTempRow.WorkingDetails = lfsTeamProjectTimeRow.WorkingDetails;
                lfsTeamProjectTimeDetailTempRow.Location = (lfsTeamProjectTimeRow.IsLocationNull()) ? null : lfsTeamProjectTimeRow.Location;
                if (lfsTeamProjectTimeRow.IsMealsCountryNull()) lfsTeamProjectTimeDetailTempRow.SetMealsCountryNull(); else lfsTeamProjectTimeDetailTempRow.MealsCountry = lfsTeamProjectTimeRow.MealsCountry;
                lfsTeamProjectTimeDetailTempRow.MealsAllowance = (lfsTeamProjectTimeRow.MealsAllowance > 0) ? true : false;
                lfsTeamProjectTimeDetailTempRow.SetCommentsNull();
                lfsTeamProjectTimeDetailTempRow.Work_ = lfsTeamProjectTimeRow.Work_;
                lfsTeamProjectTimeDetailTempRow.Function_ = lfsTeamProjectTimeRow.Function_;
                lfsTeamProjectTimeDetailTempRow.WorkFunctionConcat = lfsTeamProjectTimeRow.Work_ + " . " + lfsTeamProjectTimeRow.Function_;
                lfsTeamProjectTimeDetailTempRow.FairWage = lfsTeamProjectTimeRow.FairWage;

                if (clearUnitAssigment)
                {
                    lfsTeamProjectTimeDetailTempRow.SetUnitIDNull();
                    lfsTeamProjectTimeDetailTempRow.SetTowedUnitIDNull();
                }
            }

            // Update all real detail
            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.UpdateAll(teamProjectTimeId, clearUnitAssigment);
        }



        /// <summary>
        /// Delete TeamProjectTimeDetailTemp
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        public void Delete(int teamProjectTimeId, int detailId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow teamProjectTimeDetailRow = GetRow(teamProjectTimeId, detailId);

            teamProjectTimeDetailRow.Deleted = true;

            // Delete real detail
            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.Delete(teamProjectTimeId, detailId);
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
                    foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow row in (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table)
                    {
                        if ((row.MealsAllowance) && (row.EmployeeID == employeeId) && (!row.Deleted))
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
        /// ValidateMealsAllowance
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// /// <param name="projectTimeId">projectTimeId</param>
        /// <returns>True or false</returns>
        public bool ValidateMealsAllowanceEdit(int employeeId, bool mealsAllowance, int projectTimeId)
        {
            if (mealsAllowance)
            {
                int mealsAllowances = 1;

                if (Table.Rows.Count > 0)
                {
                    foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow row in (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Table)
                    {
                        if (row.DetailID != projectTimeId)
                        {
                            if ((row.MealsAllowance) && (row.EmployeeID == employeeId) && (!row.Deleted))
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



        public bool NotExistsByEmployeIdDate_StartTime(int employeeId, DateTime date_, string startTime, string endTime)
        {
            bool noExists = true;
            if (Table.Rows.Count > 0)
            {
                foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow row in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL_TEMP)
                {
                    if ((row.EmployeeID == employeeId) && (row.Date_ == date_) && (row.Deleted == false))
                    {
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
                                if (((spanGridStartTime >= spanStartTime) && (midNight <= spanStartTime)) || ((spanGridStartTime >= spanEndTime) && (midNight <= spanEndTime)))
                                {
                                    noExists = false;
                                    return noExists;
                                }
                            }
                            else
                            {
                                if (((spanGridEndTime < spanGridStartTime) && (spanEndTime < spanStartTime)))
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
        /// GetNewDetailId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewDetailId()
        {
            int newDetailId = 0;

            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow row in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL_TEMP)
            {
                if (newDetailId < row.DetailID)
                {
                    newDetailId = row.DetailID;
                }
            }

            newDetailId++;

            return newDetailId;
        }



        /// <summary>
        /// Get a single TemaProjectTimeDetailTemp. If not exists, raise an excption.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns>Obtained TeamProjectTimeDetailTemp</returns>
        private TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow GetRow(int teamProjectTimeId, int detailId)
        {
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow row in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL_TEMP)
            {
                if ((row.TeamProjectTimeID == teamProjectTimeId) && (row.DetailID == detailId))
                {
                    return row;
                }
            }

            throw new Exception("Unavailable row in TeamProjectTime2DetailTemp.GetRow");
        }



    }
}