using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    public class PrintHoursForProjectOriginalGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintHoursForProjectOriginalGateway()
            : base("Original")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintHoursForProjectOriginalGateway(DataSet data)
            : base(data, "Original")
        {
        }


        /// <summary>
        /// InitData. Create a PrintHoursForPayrollPeriodTDS dataset
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintHoursForProjectTDS();
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
            tableMapping.DataSetTable = "Original";
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("EmployeeName", "EmployeeName");            
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("WorkingDetails", "WorkingDetails");
            tableMapping.ColumnMappings.Add("MealsCountry", "MealsCountry");
            tableMapping.ColumnMappings.Add("MealsAllowance", "MealsAllowance");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("TowedUnitID", "TowedUnitID");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");            
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS - DATASET
        //

        /// <summary>
        /// Load project times for Print Hours For Project report without filters
        /// </summary>
        public PrintHoursForProjectTDS Load()
        {
            string commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName");
            FillData(commandText);

            return (PrintHoursForProjectTDS) Data;
        }


        
        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        public PrintHoursForProjectTDS LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", startDate, endDate);
            }

            FillData(commandText);

            return (PrintHoursForProjectTDS)Data;
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        public PrintHoursForProjectTDS LoadByStartDateEndDateProjectTimeStateTeamMemberType(DateTime startDate, DateTime endDate, string projectTimeState, string teamMemberType)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (E.Type LIKE '{3}') AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", startDate, endDate, projectTimeState, teamMemberType);
            }
            else
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (E.Type LIKE '{2}') AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", startDate, endDate, teamMemberType);
            }

            FillData(commandText);

            return (PrintHoursForProjectTDS)Data;
        }

        
        
        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Companies filter (client) for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        public PrintHoursForProjectTDS LoadByCompaniesIdStartDateEndDateProjectTimeState(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (PT.Date_ BETWEEN '{1}' AND '{2}') AND (PT.ProjectTimeState LIKE '{3}') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (PT.Date_ BETWEEN '{1}' AND '{2}') AND (PT.ProjectTimeState <> 'Approved') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, startDate, endDate);
            }

            FillData(commandText);

            return (PrintHoursForProjectTDS) Data;
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Companies filter (client) for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <param name="teamMemberType">Team Member type</param>
        /// <returns>Dataset with original data table loaded</returns>
        public PrintHoursForProjectTDS LoadByCompaniesIdStartDateEndDateProjectTimeStateTeamMemberType(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string teamMemberType)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (E.Type = '{4}') AND (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (PT.Date_ BETWEEN '{1}' AND '{2}') AND (PT.ProjectTimeState LIKE '{3}') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, startDate, endDate, projectTimeState, teamMemberType);
            }
            else
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (E.Type = '{3}') AND (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (PT.Date_ BETWEEN '{1}' AND '{2}') AND (PT.ProjectTimeState <> 'Approved') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, startDate, endDate, teamMemberType);
            }

            FillData(commandText);

            return (PrintHoursForProjectTDS)Data;
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Company filter (client) for project times</param>
        /// <param name="projectId">Project filter for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        public PrintHoursForProjectTDS LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeState(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (P.ProjectId = {1}) AND (PT.Date_ BETWEEN '{2}' AND '{3}') AND (PT.ProjectTimeState LIKE '{4}') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, projectId, startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (P.ProjectId = {1}) AND (PT.Date_ BETWEEN '{2}' AND '{3}') AND (PT.ProjectTimeState <> 'Approved') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, projectId, startDate, endDate);
            }

            FillData(commandText);

            return (PrintHoursForProjectTDS)Data;
        }



        /// <summary>
        /// Load project times for Print Hours For Project report with filters
        /// </summary>
        /// <param name="companiesId">Company filter (client) for project times</param>
        /// <param name="projectId">Project filter for project times</param>
        /// <param name="startDate">Start date filter for project times</param>
        /// <param name="endDate">End date filter for project times</param>
        /// <param name="projectTimeState">State filter for project times</param>
        /// <returns>Dataset with original data table loaded</returns>
        public PrintHoursForProjectTDS LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateTeamMemberType(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string teamMemberType)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (E.Type = '{5}') AND (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (P.ProjectId = {1}) AND (PT.Date_ BETWEEN '{2}' AND '{3}') AND (PT.ProjectTimeState LIKE '{4}') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, projectId, startDate, endDate, projectTimeState, teamMemberType);
            }
            else
            {
                commandText = String.Format("SELECT CO.COMPANIES_ID AS ClientID, CO.NAME AS ClientName, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName, C.CountryID, C.Name AS CountryName, E.EmployeeID, E.LastName + ' ' + E.FirstName AS EmployeeName, PT.Date_, PT.ProjectTime, PT.WorkingDetails, PT.MealsCountry, PT.MealsAllowance, PT.Comments, E.Type, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_PROJECT_TIME AS PT INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID INNER JOIN LFS_RESOURCES_EMPLOYEE AS E ON PT.EmployeeID = E.EmployeeID INNER JOIN LFS_RESOURCES_COMPANIES AS CO ON PT.CompaniesID = CO.COMPANIES_ID WHERE (E.Type = '{4}') AND (PT.Deleted = 0) AND (CO.COMPANIES_ID = {0}) AND (P.ProjectId = {1}) AND (PT.Date_ BETWEEN '{2}' AND '{3}') AND (PT.ProjectTimeState <> 'Approved') AND (E.Salaried = 0) ORDER BY CO.NAME, P.Name + N' (' + P.ProjectNumber + N')', C.Name, PT.Date_, E.LastName + ' ' + E.FirstName", companiesId, projectId, startDate, endDate, teamMemberType);
            }

            FillData(commandText);

            return (PrintHoursForProjectTDS)Data;
        }



    }
}
