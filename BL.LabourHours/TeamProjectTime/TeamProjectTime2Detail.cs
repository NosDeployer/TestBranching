using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.LabourHours.PayPeriod;
using LiquiForce.LFSLive.DA.LabourHours.Timesheet;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2Detail 
    /// </summary>
    public class TeamProjectTime2Detail : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTOR
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2Detail()
            : base("LFS_TEAM_PROJECT_TIME_DETAIL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public TeamProjectTime2Detail(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME_DETAIL")
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
        /// Insert
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
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="fairWage">fairWage</param>
        public void Insert(int teamProjectTimeId, int employeeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, string projectTimeState, string comments, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow teamProjectTimeDetailRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).NewLFS_TEAM_PROJECT_TIME_DETAILRow();

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
            if (mealsAllowanceType != "") teamProjectTimeDetailRow.MealsAllowanceType = mealsAllowanceType; else teamProjectTimeDetailRow.SetMealsAllowanceTypeNull();
            teamProjectTimeDetailRow.MealsAllowance = (decimal)mealsAllowance;
            teamProjectTimeDetailRow.SetUnitIDNull();
            teamProjectTimeDetailRow.SetTowedUnitIDNull();
            teamProjectTimeDetailRow.ProjectTimeState = projectTimeState;
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.Deleted = false;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();

            ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).AddLFS_TEAM_PROJECT_TIME_DETAILRow(teamProjectTimeDetailRow);
        }



        /// <summary>
        /// Insert
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
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="units">units</param>
        /// <param name="towedUnits">towedUnits</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="fairWage">fairWage</param>
        public void Insert(int teamProjectTimeId, int employeeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, string projectTimeState, string comments, int? units, int? towedUnits, string work_, string function_, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow teamProjectTimeDetailRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).NewLFS_TEAM_PROJECT_TIME_DETAILRow();

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
            if (mealsAllowanceType != "") teamProjectTimeDetailRow.MealsAllowanceType = mealsAllowanceType; else teamProjectTimeDetailRow.SetMealsAllowanceTypeNull();
            teamProjectTimeDetailRow.MealsAllowance = (decimal)mealsAllowance;
            if (units != null) teamProjectTimeDetailRow.UnitID = (int)units; else teamProjectTimeDetailRow.SetUnitIDNull();
            if (towedUnits != null) teamProjectTimeDetailRow.TowedUnitID = (int)towedUnits; else teamProjectTimeDetailRow.SetTowedUnitIDNull();
            teamProjectTimeDetailRow.ProjectTimeState = projectTimeState;
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.Deleted = false;
            teamProjectTimeDetailRow.Work_ = work_;
            teamProjectTimeDetailRow.Function_ = function_;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();

            ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).AddLFS_TEAM_PROJECT_TIME_DETAILRow(teamProjectTimeDetailRow);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="teamProjectTime2TDSToSave">teamProjectTime2TDSToSave</param>
        public void Insert(int teamProjectTimeId, TeamProjectTime2TDS teamProjectTime2TDSToSave)
        {
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow detailRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL)
            {
                if (!detailRow.Deleted)
                {
                    int detailId = detailRow.DetailID;
                    int employeeId = detailRow.EmployeeID;
                    int companiesId = detailRow.CompaniesID;
                    int projectId = detailRow.ProjectID;

                    DateTime date_ = detailRow.Date_;
                    string startTimeDetail = ""; if (!detailRow.IsNull("StartTime")) startTimeDetail = detailRow.StartTime;
                    string endTimeDetail = null; if (!detailRow.IsNull("EndTime")) endTimeDetail = detailRow.EndTime;
                    double? offset = null; if (!detailRow.IsNull("Offset")) offset = detailRow.Offset;
                    double projectTime = detailRow.ProjectTime;
                    string workingDetails = ""; if (!detailRow.IsNull("WorkingDetails")) workingDetails = detailRow.WorkingDetails;
                    string location = ""; if (!detailRow.IsNull("Location")) location = detailRow.Location;
                    Int64? mealsCountry = null; if (!detailRow.IsNull("MealsCountry")) mealsCountry = detailRow.MealsCountry;
                    string mealsAllowanceType = ""; if (!detailRow.IsNull("MealsAllowanceType")) mealsAllowanceType = detailRow.MealsAllowanceType;
                    decimal mealsAllowance = detailRow.MealsAllowance;
                    string ProjectTimeState = detailRow.ProjectTimeState;
                    string comments = ""; if (!detailRow.IsNull("Comments")) comments = detailRow.Comments;
                    bool fairWage = detailRow.FairWage;
                    string jobClassType = ""; if (!detailRow.IsNull("JobClassType")) jobClassType = detailRow.JobClassType;

                    TeamProjectTime2Detail teamProjectTime2DetailToSave = new TeamProjectTime2Detail(teamProjectTime2TDSToSave);
                    teamProjectTime2DetailToSave.Insert(0, employeeId, companiesId, projectId, date_, startTimeDetail, endTimeDetail, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, ProjectTimeState, comments, fairWage, jobClassType);
                }
            }
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
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
        public void Update(int teamProjectTimeId, int detailId, DateTime date_, string startTime, string endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, int? unitId, int? towedUnitId, string projectTimeState, string comments, string work_, string function_, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow teamProjectTimeDetailRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).FindByTeamProjectTimeIDDetailID(teamProjectTimeId, detailId);

            teamProjectTimeDetailRow.Date_ = date_;

            if (startTime != "") teamProjectTimeDetailRow.StartTime = startTime; else teamProjectTimeDetailRow.SetStartTimeNull();
            if (endTime != "") teamProjectTimeDetailRow.EndTime = endTime; else teamProjectTimeDetailRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeDetailRow.Offset = (double)offset; else teamProjectTimeDetailRow.SetOffsetNull();
            if (workingDetails != "") teamProjectTimeDetailRow.WorkingDetails = workingDetails; else teamProjectTimeDetailRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeDetailRow.Location = location; else teamProjectTimeDetailRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeDetailRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeDetailRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") teamProjectTimeDetailRow.MealsAllowanceType = mealsAllowanceType; else teamProjectTimeDetailRow.SetMealsAllowanceTypeNull();
            teamProjectTimeDetailRow.MealsAllowance = mealsAllowance;
            if (unitId.HasValue) teamProjectTimeDetailRow.UnitID = (int)unitId; else teamProjectTimeDetailRow.SetUnitIDNull();
            if (towedUnitId.HasValue) teamProjectTimeDetailRow.TowedUnitID = (int)towedUnitId; else teamProjectTimeDetailRow.SetTowedUnitIDNull();
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.ProjectTime = 0;
            teamProjectTimeDetailRow.Work_ = work_;
            teamProjectTimeDetailRow.Function_ = function_;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companiesId">companiesId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="date_">date_</param>
        /// <param name="startTime">startTime</param>
        /// <param name="endTime">endTime</param>
        /// <param name="offset">offset</param>
        /// <param name="projectTime">projectTime</param>
        /// <param name="workingDetails">workingDetails</param>
        /// <param name="location">location</param>
        /// <param name="mealsCountry">mealsCountry</param>
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="unitId">unitId</param>
        /// <param name="towedUnitId">towedUnitId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="fairWage">fairWage</param>
        public void Update(int teamProjectTimeId, int detailId, int employeeId, int companiesId, int projectId, DateTime date_, string startTime, string endTime, double? offset, double projectTime, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, int? unitId, int? towedUnitId, string projectTimeState, string comments, bool deleted, bool fairWage, string jobClassType)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow teamProjectTimeDetailRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).FindByTeamProjectTimeIDDetailID(teamProjectTimeId, detailId);

            teamProjectTimeDetailRow.EmployeeID = employeeId;
            teamProjectTimeDetailRow.CompaniesID = companiesId;
            teamProjectTimeDetailRow.ProjectID = projectId;
            teamProjectTimeDetailRow.Date_ = date_;

            if (startTime != "") teamProjectTimeDetailRow.StartTime = startTime; else teamProjectTimeDetailRow.SetStartTimeNull();
            if (endTime != "") teamProjectTimeDetailRow.EndTime = endTime; else teamProjectTimeDetailRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeDetailRow.Offset = (double)offset; else teamProjectTimeDetailRow.SetOffsetNull();
            teamProjectTimeDetailRow.ProjectTime = projectTime;
            if (workingDetails != "") teamProjectTimeDetailRow.WorkingDetails = workingDetails; else teamProjectTimeDetailRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeDetailRow.Location = location; else teamProjectTimeDetailRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeDetailRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeDetailRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") teamProjectTimeDetailRow.MealsAllowanceType = mealsAllowanceType; else teamProjectTimeDetailRow.SetMealsAllowanceTypeNull();
            teamProjectTimeDetailRow.MealsAllowance = mealsAllowance;
            if (unitId.HasValue) teamProjectTimeDetailRow.UnitID = (int)unitId; else teamProjectTimeDetailRow.SetUnitIDNull();
            if (towedUnitId.HasValue) teamProjectTimeDetailRow.TowedUnitID = (int)towedUnitId; else teamProjectTimeDetailRow.SetTowedUnitIDNull();
            teamProjectTimeDetailRow.ProjectTimeState = projectTimeState;
            if (comments != "") teamProjectTimeDetailRow.Comments = comments; else teamProjectTimeDetailRow.SetCommentsNull();
            teamProjectTimeDetailRow.Deleted = deleted;
            teamProjectTimeDetailRow.FairWage = fairWage;
            if (jobClassType != "") teamProjectTimeDetailRow.JobClassType = jobClassType; else teamProjectTimeDetailRow.SetJobClassTypeNull();
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="teamProjectTimeIdForReplace">teamProjectTimeIdForReplace</param>
        /// <param name="teamProjectTime2TDSToSave">teamProjectTime2TDSToSave</param>
        public void Update(int teamProjectTimeId, int teamProjectTimeIdForReplace, TeamProjectTime2TDS teamProjectTime2TDSToSave)
        {
            // Load existing rows
            TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(teamProjectTime2TDSToSave);
            teamProjectTime2DetailGateway.LoadAllByTeamProjectTimeId(teamProjectTimeIdForReplace);

            // Delete existing rows
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow detailExistingRow in ((TeamProjectTime2TDS)teamProjectTime2DetailGateway.Data).LFS_TEAM_PROJECT_TIME_DETAIL)
            {
                detailExistingRow.Deleted = true;
            }

            // Insert or update detail rows
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow detailRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL)
            {
                int detailId = detailRow.DetailID;
                int employeeId = detailRow.EmployeeID;
                int companiesId = detailRow.CompaniesID;
                int projectId = detailRow.ProjectID;
                DateTime date_ = detailRow.Date_;
                string startTimeDetail = ""; if (!detailRow.IsNull("StartTime")) startTimeDetail = detailRow.StartTime;
                string endTimeDetail = null; if (!detailRow.IsNull("EndTime")) endTimeDetail = detailRow.EndTime;
                double? offset = null; if (!detailRow.IsNull("Offset")) offset = detailRow.Offset;
                double projectTime = detailRow.ProjectTime;
                string workingDetails = ""; if (!detailRow.IsNull("WorkingDetails")) workingDetails = detailRow.WorkingDetails;
                string location = ""; if (!detailRow.IsNull("Location")) location = detailRow.Location;
                Int64? mealsCountry = null; if (!detailRow.IsNull("MealsCountry")) mealsCountry = detailRow.MealsCountry;
                string mealsAllowanceType = ""; if (!detailRow.IsNull("MealsAllowanceType")) mealsAllowanceType = detailRow.MealsAllowanceType;
                decimal mealsAllowance = detailRow.MealsAllowance;
                int? unitId = null; if (!detailRow.IsNull("UnitID")) unitId = detailRow.UnitID;
                int? towedUnitId = null; if (!detailRow.IsNull("TowedUnitID")) towedUnitId = detailRow.TowedUnitID;
                string ProjectTimeState = detailRow.ProjectTimeState;
                string comments = ""; if (!detailRow.IsNull("Comments")) comments = detailRow.Comments;
                bool deleted = detailRow.Deleted;
                bool fairWage = detailRow.FairWage;
                string jobClassType = ""; if (!detailRow.IsNull("JobClassType")) jobClassType = detailRow.JobClassType;

                // ... Get row if exists
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow oldDetailRow = null;

                try
                {
                    oldDetailRow = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow)teamProjectTime2DetailGateway.GetRow(teamProjectTimeIdForReplace, detailId);
                }
                catch
                {
                    oldDetailRow = null;
                }

                // ... Row check
                TeamProjectTime2Detail teamProjectTime2DetailToSave = new TeamProjectTime2Detail(teamProjectTime2TDSToSave);
                if (oldDetailRow != null)
                {
                    teamProjectTime2DetailToSave.Update(teamProjectTimeIdForReplace, detailId, employeeId, companiesId, projectId, date_, startTimeDetail, endTimeDetail, offset, projectTime, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, ProjectTimeState, comments, deleted, fairWage, jobClassType);
                }
                else
                {
                    teamProjectTime2DetailToSave.Insert(teamProjectTimeIdForReplace, employeeId, companiesId, projectId, date_, startTimeDetail, endTimeDetail, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, ProjectTimeState, comments, fairWage, jobClassType);
                }
            }
        }



        /// <summary>
        /// UpdateAll
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        public void UpdateAll(int teamProjectTimeId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow lfsTeamProjectTimeRow = ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME.FindByTeamProjectTimeID(teamProjectTimeId);

            // Update all detail
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow lfsTeamProjectTimeDetailRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL)
            {
                lfsTeamProjectTimeDetailRow.CompaniesID = lfsTeamProjectTimeRow.CompaniesID;
                lfsTeamProjectTimeDetailRow.ProjectID = lfsTeamProjectTimeRow.ProjectID;
                lfsTeamProjectTimeDetailRow.Date_ = lfsTeamProjectTimeRow.Date_;
                lfsTeamProjectTimeDetailRow.StartTime = (lfsTeamProjectTimeRow.IsStartTimeNull()) ? null : lfsTeamProjectTimeRow.StartTime.ToShortTimeString();
                lfsTeamProjectTimeDetailRow.EndTime = (lfsTeamProjectTimeRow.IsEndTimeNull()) ? null : lfsTeamProjectTimeRow.EndTime.ToShortTimeString();
                if (lfsTeamProjectTimeRow.IsOffsetNull()) lfsTeamProjectTimeDetailRow.SetOffsetNull(); else lfsTeamProjectTimeDetailRow.Offset = lfsTeamProjectTimeRow.Offset;
                lfsTeamProjectTimeDetailRow.WorkingDetails = lfsTeamProjectTimeRow.WorkingDetails;
                lfsTeamProjectTimeDetailRow.Location = (lfsTeamProjectTimeRow.IsLocationNull()) ? null : lfsTeamProjectTimeRow.Location;
                if (lfsTeamProjectTimeRow.IsMealsCountryNull()) lfsTeamProjectTimeDetailRow.SetMealsCountryNull(); else lfsTeamProjectTimeDetailRow.MealsCountry = lfsTeamProjectTimeRow.MealsCountry;
                if (lfsTeamProjectTimeRow.IsMealsAllowanceTypeNull()) lfsTeamProjectTimeDetailRow.SetMealsAllowanceTypeNull(); else lfsTeamProjectTimeDetailRow.MealsAllowanceType = lfsTeamProjectTimeRow.MealsAllowanceType;
                lfsTeamProjectTimeDetailRow.MealsAllowance = lfsTeamProjectTimeRow.MealsAllowance;
                lfsTeamProjectTimeDetailRow.SetUnitIDNull();
                lfsTeamProjectTimeDetailRow.SetTowedUnitIDNull();
                lfsTeamProjectTimeDetailRow.SetCommentsNull();
                lfsTeamProjectTimeDetailRow.Work_ = lfsTeamProjectTimeRow.Work_;
                lfsTeamProjectTimeDetailRow.Function_ = lfsTeamProjectTimeRow.Function_;
                lfsTeamProjectTimeDetailRow.FairWage = lfsTeamProjectTimeRow.FairWage;
            }
        }



        /// <summary>
        /// UpdateAll
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="clearUnitAssigment">clearUnitAssigment</param>
        public void UpdateAll(int teamProjectTimeId, bool clearUnitAssigment)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow lfsTeamProjectTimeRow = ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME.FindByTeamProjectTimeID(teamProjectTimeId);

            // Update all detail
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow lfsTeamProjectTimeDetailRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL)
            {
                lfsTeamProjectTimeDetailRow.CompaniesID = lfsTeamProjectTimeRow.CompaniesID;
                lfsTeamProjectTimeDetailRow.ProjectID = lfsTeamProjectTimeRow.ProjectID;
                lfsTeamProjectTimeDetailRow.Date_ = lfsTeamProjectTimeRow.Date_;
                lfsTeamProjectTimeDetailRow.StartTime = (lfsTeamProjectTimeRow.IsStartTimeNull()) ? null : lfsTeamProjectTimeRow.StartTime.ToShortTimeString();
                lfsTeamProjectTimeDetailRow.EndTime = (lfsTeamProjectTimeRow.IsEndTimeNull()) ? null : lfsTeamProjectTimeRow.EndTime.ToShortTimeString();
                if (lfsTeamProjectTimeRow.IsOffsetNull()) lfsTeamProjectTimeDetailRow.SetOffsetNull(); else lfsTeamProjectTimeDetailRow.Offset = lfsTeamProjectTimeRow.Offset;
                lfsTeamProjectTimeDetailRow.WorkingDetails = lfsTeamProjectTimeRow.WorkingDetails;
                lfsTeamProjectTimeDetailRow.Location = (lfsTeamProjectTimeRow.IsLocationNull()) ? null : lfsTeamProjectTimeRow.Location;
                if (lfsTeamProjectTimeRow.IsMealsCountryNull()) lfsTeamProjectTimeDetailRow.SetMealsCountryNull(); else lfsTeamProjectTimeDetailRow.MealsCountry = lfsTeamProjectTimeRow.MealsCountry;
                if (lfsTeamProjectTimeRow.IsMealsAllowanceTypeNull()) lfsTeamProjectTimeDetailRow.SetMealsAllowanceTypeNull(); else lfsTeamProjectTimeDetailRow.MealsAllowanceType = lfsTeamProjectTimeRow.MealsAllowanceType;
                lfsTeamProjectTimeDetailRow.MealsAllowance = lfsTeamProjectTimeRow.MealsAllowance;
                if (clearUnitAssigment)
                {
                    lfsTeamProjectTimeDetailRow.SetUnitIDNull();
                    lfsTeamProjectTimeDetailRow.SetTowedUnitIDNull();
                }
                lfsTeamProjectTimeDetailRow.SetCommentsNull();
                lfsTeamProjectTimeDetailRow.Work_ = lfsTeamProjectTimeRow.Work_;
                lfsTeamProjectTimeDetailRow.Function_ = lfsTeamProjectTimeRow.Function_;
                lfsTeamProjectTimeDetailRow.FairWage = lfsTeamProjectTimeRow.FairWage;
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        public void Delete(int teamProjectTimeId, int detailId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow teamProjectTimeDetailRow = GetRow(teamProjectTimeId, detailId);

            teamProjectTimeDetailRow.Deleted = true;
        }



        /// <summary>
        /// Delete all TeamProjectTimeDetails associated to one TeamProjectTime
        /// </summary>
        /// <param name="teamProjectTimeId">TeamProjectTimeId</param>
        public void Delete(int teamProjectTimeId)
        {
            string filter = string.Format("TeamProjectTimeID = {0}", teamProjectTimeId);
            DataRow[] filterRows = Table.Select(filter);

            foreach (DataRow row in filterRows)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow teamProjectTimeDetailRow = GetRow(teamProjectTimeId, int.Parse(row["DetailID"].ToString()));
                teamProjectTimeDetailRow.Deleted = true;
            }
        }



        /// <summary>
        /// MoveToProjectTime
        /// </summary>
        /// <param name="projectTimeTDS">projectTimeTDS</param>
        /// <param name="LHMode">LHMode</param>
        /// <param name="fullEditing">fullEditing</param>
        /// <param name="typeOfWork">typeOfWork</param>
        /// <param name="function">function</param>
        /// <param name="companyId">companyId</param>
        /// <param name="createdById">createdById</param>
        /// <returns></returns>
        public string MoveToProjectTime(ProjectTimeTDS projectTimeTDS, string LHMode, bool fullEditing, string typeOfWork, string function, int companyId, int createdById)
        {
            PayPeriodGateway payPeriodGateway = new PayPeriodGateway(new DataSet());
            TimesheetGateway timesheetGateway = new TimesheetGateway(new DataSet());
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime projectTime = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime(projectTimeTDS);
            string errorMessage = "";

            // Clear before project times
            projectTime.Table.Rows.Clear();

            // Insert new project times
            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow row in ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table))
            {
                if (!row.Deleted)
                {
                    int employeeId = row.EmployeeID;
                    int companiesId = row.CompaniesID;
                    int projectId = row.ProjectID;
                    DateTime date_ = row.Date_;

                    DateTime? startTime = null;
                    if (!row.IsStartTimeNull())
                    {
                        string[] startTimeSplit = row.StartTime.Split(':');
                        int startTimeHour = Int32.Parse(startTimeSplit[0].ToString());
                        string[] startTimeMinuteSplit = startTimeSplit[1].Split(' ');
                        int startTimeMinute = Int32.Parse(startTimeMinuteSplit[0].ToString());
                        startTime = new DateTime(date_.Year, date_.Month, date_.Day, startTimeHour, startTimeMinute, 0);
                    }
                    DateTime? endTime = null;
                    if (!row.IsEndTimeNull())
                    {
                        string[] endTimeSplit = row.EndTime.Split(':');
                        int endTimeHour = Int32.Parse(endTimeSplit[0].ToString());
                        string[] endTimeMinuteSplit = endTimeSplit[1].Split(' ');
                        int endTimeMinute = Int32.Parse(endTimeMinuteSplit[0].ToString());
                        endTime = new DateTime(date_.Year, date_.Month, date_.Day, endTimeHour, endTimeMinute, 0);
                    }
                    double? offset = null; if (!row.IsOffsetNull()) offset = row.Offset;
                    double projectTimeValue = row.ProjectTime;
                    string workingDetails = ""; if (!row.IsWorkingDetailsNull()) workingDetails = row.WorkingDetails;
                    string location = ""; if (!row.IsLocationNull()) location = row.Location;
                    Int64? mealsCountry = null; if (!row.IsMealsCountryNull()) mealsCountry = row.MealsCountry;
                    string mealsAllowanceType = ""; if (!row.IsMealsAllowanceTypeNull()) mealsAllowanceType = row.MealsAllowanceType;
                    decimal mealsAllowance = row.MealsAllowance;
                    int? unitId = null; if (!row.IsUnitIDNull()) unitId = row.UnitID;
                    int? towedUnitId = null; if (!row.IsTowedUnitIDNull()) towedUnitId = row.TowedUnitID;
                    string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                    string work_ = row.Work_;
                    string function_ = row.Function_;
                    bool fairWage = row.FairWage;
                    string jobClass = ""; if (!row.IsJobClassTypeNull()) jobClass = row.JobClassType;                    

                    string projectTimeState = row.ProjectTimeState;

                   int projectTimeId = projectTime.Insert(employeeId, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, projectTimeState, comments, work_, function_, fairWage, jobClass, createdById);

                   if (typeOfWork == "Full Length")
                   {
                       LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeSection projectTimeSection = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeSection(projectTimeTDS);

                       switch (function)
                       {
                           case "Install":
                               foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow projectTimeRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_SECTION)
                               {
                                   if (projectTimeRow.Selected)
                                   {
                                       projectTimeSection.Insert(projectTimeId, projectTimeRow.SectionID, projectTimeRow.FlowOrderID, true, projectTimeRow._Date, 0, 0, false, companyId);
                                   }
                               }
                               break;

                           case "Prep & Measure":
                               foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow projectTimeRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_SECTION)
                               {
                                   if (projectTimeRow.Selected)
                                   {
                                       projectTimeSection.Insert(projectTimeId, projectTimeRow.SectionID, projectTimeRow.FlowOrderID, projectTimeRow.Completed, projectTimeRow._Date, 0, 0, false, companyId);
                                   }
                               }
                               break;

                           case "Reinstate & Post Video":
                               foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow projectTimeRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_SECTION)
                               {
                                   if (projectTimeRow.Selected)
                                   {
                                       projectTimeSection.Insert(projectTimeId, projectTimeRow.SectionID, projectTimeRow.FlowOrderID, projectTimeRow.Completed, projectTimeRow._Date, projectTimeRow.PercentageOpened, projectTimeRow.PercentageBrushed, false, companyId);
                                   }
                               }
                               break;
                       }
                   }

                   //if (typeOfWork == "MH Rehab")//TODO MH
                   //{
                   //    LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeSection projectTimeSection = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeSection(projectTimeTDS);

                   //    switch (function)
                   //    {
                   //        case "Prep":
                   //            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow projectTimeRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_SECTION)
                   //            {
                   //                if (projectTimeRow.Selected)
                   //                {
                   //                    projectTimeSection.Insert(projectTimeId, projectTimeRow.SectionID, projectTimeRow.FlowOrderID, true, projectTimeRow._Date, 0, 0, false, companyId);
                   //                }
                   //            }
                   //            break;

                   //        case "Spray":
                   //            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONRow projectTimeRow in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_SECTION)
                   //            {
                   //                if (projectTimeRow.Selected)
                   //                {
                   //                    projectTimeSection.Insert(projectTimeId, projectTimeRow.SectionID, projectTimeRow.FlowOrderID, true, projectTimeRow._Date, 0, 0, false, companyId);
                   //                }
                   //            }
                   //            break;
                   //    }
                   //}
                }
            }

            return errorMessage;
        }



        /// <summary>
        /// GetNewDetailId
        /// </summary>
        /// <returns></returns>
        public int GetNewDetailId()
        {
            int newDetailId = 0;

            foreach (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow row in ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL)
            {
                if (newDetailId < row.DetailID)
                {
                    newDetailId = row.DetailID;
                }
            }

            newDetailId++;

            return newDetailId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single TemaProjectTimeDetail, If not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="detailId">detailId</param>
        /// <returns></returns>
        private TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow GetRow(int teamProjectTimeId, int detailId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILRow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAILDataTable)Table).FindByTeamProjectTimeIDDetailID(teamProjectTimeId, detailId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTime2Detail.GetRow");
            }

            return row;
        }



    }
}