using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime
{
    /// <summary>
    /// TeamProjectTime2
    /// </summary>
    public class TeamProjectTime2 : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public TeamProjectTime2()
            : base("LFS_TEAM_PROJECT_TIME")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data"></param>
        public TeamProjectTime2(DataSet data)
            : base(data, "LFS_TEAM_PROJECT_TIME")
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
        /// CreateTableStructureForDropDownList
        /// </summary>
        public void CreateTableStructureForDropDownList()
        {
            // Create table
            System.Data.DataTable table = new DataTable("LFS_TEAM_PROJECT_TIME");
            Data.Tables.Add(table);

            // Declare DataColumn variables
            DataColumn column;

            // Create columns
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "TeamProjectTimeID";
            Table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "TemplateName";
            Table.Columns.Add(column);
        }



        /// <summary>
        /// DestroyTableStructure
        /// </summary>
        public void DestroyTableStructure()
        {
            Data.Relations.Clear();
            ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL_TEMP.Constraints.Clear();
            ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME_DETAIL.Constraints.Clear();
            ((TeamProjectTime2TDS)Data).LFS_TEAM_PROJECT_TIME.Constraints.Clear();
            Data.Tables.Clear();
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="templateName">templateName</param>
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
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="loginId">loginId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="fairWage">fairWage</param>
        public void Insert(int teamProjectTimeId, string templateName, int companiesId, int projectId, DateTime date_, DateTime? startTime, DateTime? endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, int? unitId, int? towedUnitId, string comments, string type, string state, int loginId, bool deleted, string work_, string function_, bool fairWage)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow teamProjectTimeRow = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMEDataTable)Table).NewLFS_TEAM_PROJECT_TIMERow();

            teamProjectTimeRow.TeamProjectTimeID = teamProjectTimeId;
            if (templateName != "") teamProjectTimeRow.TemplateName = templateName; else teamProjectTimeRow.SetTemplateNameNull();
            teamProjectTimeRow.CompaniesID = companiesId;
            teamProjectTimeRow.ProjectID = projectId;
            teamProjectTimeRow.Date_ = date_;
            if (startTime.HasValue) teamProjectTimeRow.StartTime = (DateTime)startTime; else teamProjectTimeRow.SetStartTimeNull();
            if (endTime.HasValue) teamProjectTimeRow.EndTime = (DateTime)endTime; else teamProjectTimeRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeRow.Offset = (double)offset; else teamProjectTimeRow.SetOffsetNull();
            if (workingDetails != "") teamProjectTimeRow.WorkingDetails = workingDetails; else teamProjectTimeRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeRow.Location = location; else teamProjectTimeRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") teamProjectTimeRow.MealsAllowanceType = mealsAllowanceType; else teamProjectTimeRow.SetMealsAllowanceTypeNull();
            teamProjectTimeRow.MealsAllowance = (decimal)mealsAllowance;
            if (unitId.HasValue) teamProjectTimeRow.UnitID = (int)unitId; else teamProjectTimeRow.SetUnitIDNull();
            if (towedUnitId.HasValue) teamProjectTimeRow.TowedUnitID = (int)towedUnitId; else teamProjectTimeRow.SetTowedUnitIDNull();
            if (comments != "") teamProjectTimeRow.Comments = comments; else teamProjectTimeRow.SetCommentsNull();
            teamProjectTimeRow.Type = type;
            teamProjectTimeRow.State = state;
            teamProjectTimeRow.LoginID = loginId;
            teamProjectTimeRow.Deleted = deleted;
            teamProjectTimeRow.Work_ = work_;
            teamProjectTimeRow.Function_ = function_;
            teamProjectTimeRow.FairWage = fairWage;

            ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMEDataTable)Table).AddLFS_TEAM_PROJECT_TIMERow(teamProjectTimeRow);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="newTemplateName">newTemplateName</param>
        /// <param name="teamProjectTime2TDSToSave">teamProjectTime2TDSToSave</param>
        public void Insert(int teamProjectTimeId, string newTemplateName, TeamProjectTime2TDS teamProjectTime2TDSToSave)
        {
            // Insert master row
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow masterRow = GetRow(teamProjectTimeId);

            int companiesId = masterRow.CompaniesID;
            int projectId = masterRow.ProjectID;
            DateTime date_ = masterRow.Date_;
            DateTime? startTime = null; if (!masterRow.IsNull("StartTime")) startTime = masterRow.StartTime;
            DateTime? endTime = null; if (!masterRow.IsNull("EndTime")) endTime = masterRow.EndTime;
            double? offset = null; if (!masterRow.IsNull("Offset")) offset = masterRow.Offset;
            string workingDetails = ""; if (!masterRow.IsNull("WorkingDetails")) workingDetails = masterRow.WorkingDetails;
            string location = ""; if (!masterRow.IsNull("Location")) location = masterRow.Location;
            Int64? mealsCountry = null; if (!masterRow.IsNull("MealsCountry")) mealsCountry = masterRow.MealsCountry;
            String mealsAllowanceType = ""; if (!masterRow.IsNull("MealsAllowanceType")) mealsAllowanceType = masterRow.MealsAllowanceType;
            decimal mealsAllowance = masterRow.MealsAllowance;
            int? unitId = null; if (!masterRow.IsNull("UnitID")) unitId = masterRow.UnitID;
            int? towedUnitId = null; if (!masterRow.IsNull("TowedUnitID")) towedUnitId = masterRow.TowedUnitID;
            string comments = ""; if (!masterRow.IsNull("Comments")) comments = masterRow.Comments;
            string type = "Template";
            string state = "Done";
            int loginId = masterRow.LoginID;
            bool deleted = false;
            string work_ = masterRow.Work_;
            string function_ = masterRow.Function_;
            bool fairWage = masterRow.FairWage;

            TeamProjectTime2 teamProjectTime2ToSave = new TeamProjectTime2(teamProjectTime2TDSToSave);
            teamProjectTime2ToSave.Insert(0, newTemplateName, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, comments, type, state, loginId, deleted, work_, function_, fairWage);

            // Insert detail rows
            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.Insert(teamProjectTimeId, teamProjectTime2TDSToSave);
        }



        /// <summary>
        /// InsertForDropDownList
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="templateName">templateName</param>
        public void InsertForDropDownList(int teamProjectTimeId, string templateName)
        {
            // Verify structure
            if (Table == null)
            {
                CreateTableStructureForDropDownList();
            }

            // Insert row
            DataRow newRow = Table.NewRow();
            newRow["TeamProjectTimeID"] = teamProjectTimeId;
            newRow["TemplateName"] = templateName;
            Table.Rows.Add(newRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="templateName">templateName</param>
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
        /// <param name="type">type</param>
        /// <param name="state">state</param>
        /// <param name="loginId">loginId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <param name="fairWage">fairWage</param>
        public void Update(int teamProjectTimeId, string templateName, int companiesId, int projectId, DateTime date_, DateTime? startTime, DateTime? endTime, double? offset, string workingDetails, string location, Int64? mealsCountry, string mealsAllowanceType, decimal mealsAllowance, int? unitId, int? towedUnitId, string comments, string type, string state, int loginId, bool deleted, string work_, string function_, bool fairWage)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow teamProjectTimeRow = GetRow(teamProjectTimeId);

            if (templateName != "") teamProjectTimeRow.TemplateName = templateName; else teamProjectTimeRow.SetTemplateNameNull();
            teamProjectTimeRow.CompaniesID = companiesId;
            teamProjectTimeRow.ProjectID = projectId;
            teamProjectTimeRow.Date_ = date_;
            if (startTime.HasValue) teamProjectTimeRow.StartTime = (DateTime)startTime; else teamProjectTimeRow.SetStartTimeNull();
            if (endTime.HasValue) teamProjectTimeRow.EndTime = (DateTime)endTime; else teamProjectTimeRow.SetEndTimeNull();
            if (offset.HasValue) teamProjectTimeRow.Offset = (double)offset; else teamProjectTimeRow.SetOffsetNull();
            if (workingDetails != "") teamProjectTimeRow.WorkingDetails = workingDetails; else teamProjectTimeRow.SetWorkingDetailsNull();
            if (location != "") teamProjectTimeRow.Location = location; else teamProjectTimeRow.SetLocationNull();
            if (mealsCountry.HasValue) teamProjectTimeRow.MealsCountry = (Int64)mealsCountry; else teamProjectTimeRow.SetMealsCountryNull();
            if (mealsAllowanceType != "") teamProjectTimeRow.MealsAllowanceType = mealsAllowanceType; else teamProjectTimeRow.SetMealsAllowanceTypeNull();
            teamProjectTimeRow.MealsAllowance = (decimal)mealsAllowance;
            if (unitId.HasValue) teamProjectTimeRow.UnitID = (int)unitId; else teamProjectTimeRow.SetUnitIDNull();
            if (towedUnitId.HasValue) teamProjectTimeRow.TowedUnitID = (int)towedUnitId; else teamProjectTimeRow.SetTowedUnitIDNull();
            if (comments != "") teamProjectTimeRow.Comments = comments; else teamProjectTimeRow.SetCommentsNull();
            teamProjectTimeRow.Type = type;
            teamProjectTimeRow.State = state;
            teamProjectTimeRow.LoginID = loginId;
            teamProjectTimeRow.Deleted = deleted;
            teamProjectTimeRow.Work_ = work_;
            teamProjectTimeRow.Function_ = function_;
            teamProjectTimeRow.FairWage = fairWage;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="teamProjectTimeIdForReplace">teamProjectTimeIdForReplace</param>
        /// <param name="teamProjectTime2TDSToSave">teamProjectTime2TDSToSave</param>
        public void Update(int teamProjectTimeId, int teamProjectTimeIdForReplace, TeamProjectTime2TDS teamProjectTime2TDSToSave)
        {
            // Update existing row
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow masterRow = GetRow(teamProjectTimeId);

            int companiesId = masterRow.CompaniesID;
            int projectId = masterRow.ProjectID;
            DateTime date_ = masterRow.Date_;
            DateTime? startTime = null; if (!masterRow.IsNull("StartTime")) startTime = masterRow.StartTime;
            DateTime? endTime = null; if (!masterRow.IsNull("EndTime")) endTime = masterRow.EndTime;
            double? offset = null; if (!masterRow.IsNull("Offset")) offset = masterRow.Offset;
            string workingDetails = ""; if (!masterRow.IsNull("WorkingDetails")) workingDetails = masterRow.WorkingDetails;
            string location = ""; if (!masterRow.IsNull("Location")) location = masterRow.Location;
            Int64? mealsCountry = null; if (!masterRow.IsNull("MealsCountry")) mealsCountry = masterRow.MealsCountry;
            String mealsAllowanceType = ""; if (!masterRow.IsNull("MealsAllowanceType")) mealsAllowanceType = masterRow.MealsAllowanceType;
            decimal mealsAllowance = masterRow.MealsAllowance;
            int? unitId = null; if (!masterRow.IsNull("UnitID")) unitId = masterRow.UnitID;
            int? towedUnitId = null; if (!masterRow.IsNull("TowedUnitID")) towedUnitId = masterRow.TowedUnitID;
            string comments = ""; if (!masterRow.IsNull("Comments")) comments = masterRow.Comments;
            string type = "Template";
            string state = "Done";
            int loginId = masterRow.LoginID;
            bool deleted = false;
            string work_ = masterRow.Work_;
            string function_ = masterRow.Function_;
            bool fairWage = masterRow.FairWage;

            // ... Load existing row
            TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(teamProjectTime2TDSToSave);
            teamProjectTime2Gateway.LoadByTeamProjectTimeId(teamProjectTimeIdForReplace);

            // ... Replace existing row
            TeamProjectTime2 teamProjectTime2ToSave = new TeamProjectTime2(teamProjectTime2TDSToSave);
            teamProjectTime2ToSave.Update(teamProjectTimeIdForReplace, teamProjectTime2Gateway.GetTemplateName(teamProjectTimeIdForReplace), companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, comments, type, state, loginId, deleted, work_, function_, fairWage);

            // Update or delete detail rows
            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(Data);
            teamProjectTime2Detail.Update(teamProjectTimeId, teamProjectTimeIdForReplace, teamProjectTime2TDSToSave);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="teamProjectTimeId"></param>
        public void Delete(int teamProjectTimeId)
        {
            // Delete TeamProjectTime row
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow row = GetRow(teamProjectTimeId);
            row.Deleted = true;
        }



        /// <summary>
        /// LoadForDropDownListByLoginIdAndAddItem
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="teamProjectTimeId"></param>
        /// <param name="templateName"></param>
        /// <returns></returns>
        public DataSet LoadForDropDownListByLoginIdAndAddItem(int loginId, int teamProjectTimeId, string templateName)
        {
            // Create structure
            DestroyTableStructure();
            CreateTableStructureForDropDownList();

            // Insert extra template
            InsertForDropDownList(teamProjectTimeId, templateName);

            // Load templates
            TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(Data);
            teamProjectTime2Gateway.ClearBeforeFill = false;
            teamProjectTime2Gateway.LoadForDropDownListByLoginId(loginId);
            teamProjectTime2Gateway.ClearBeforeFill = true;

            // Return DataSet
            return Data;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single TeamProjectTime. If not exists, raise an exception.
        /// </summary>
        /// <param name="teamProjectTimeId"></param>
        /// <returns></returns>
        private TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow GetRow(int teamProjectTimeId)
        {
            TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMERow row = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIMEDataTable)Table).FindByTeamProjectTimeID(teamProjectTimeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTime2.GetRow");
            }

            return row;
        }



    }
}