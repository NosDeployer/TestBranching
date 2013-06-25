using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintVehicleLocationGateway
    /// </summary>
    public class PrintVehicleLocationGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public PrintVehicleLocationGateway()
            : base("PrintVehicleLocation")
        {
        }

        public PrintVehicleLocationGateway(DataSet data)
            : base(data, "PrintVehicleLocation")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new PrintVehicleLocationTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PrintVehicleLocation";
            tableMapping.ColumnMappings.Add("ProjectTimeID", "ProjectTimeID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("UnitTowedCode", "UnitTowedCode");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("CountryName", "CountryName");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("ProjectTimeState", "ProjectTimeState");
            tableMapping.ColumnMappings.Add("ProjectName", "ProjectName");
            
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        // METHODS
        /// <summary>
        /// LoadByStartDateEndDateProjectTimeState
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="projectTimeState">projectTimeState</param>
        public void LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName "+
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') " +
                    " UNION ALL SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName "+
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName "+
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') " +
                    " UNION ALL SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName "+
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate);
            }

            FillData(commandText);

            PrintVehicleLocationDaysGateway printVehicleLocationDaysGateway = new PrintVehicleLocationDaysGateway(Data);
            printVehicleLocationDaysGateway.FillData();
        }



        /// <summary>
        /// LoadByStartDateEndDateUnitIdProjectTimeState
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        public void LoadByStartDateEndDateUnitIdProjectTimeState(DateTime startDate, DateTime endDate, int unitId, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID " +
                " WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState LIKE '{3}') "+
                " UNION ALL SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID " +
                " WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState LIKE '{3}') ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, unitId, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName" +
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID " +
                    " WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState <> 'Approved') "+
                    " UNION ALL SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID " +
                    " WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState <> 'Approved') ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, unitId);
            }

            FillData(commandText);

            PrintVehicleLocationDaysGateway printVehicleLocationDaysGateway = new PrintVehicleLocationDaysGateway(Data);
            printVehicleLocationDaysGateway.FillData();
        }



        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateCountryId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="countryId">countryId</param>
        public void LoadByStartDateEndDateProjectTimeStateCountryId(DateTime startDate, DateTime endDate, string projectTimeState, int countryId)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {3}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') " +
                    " UNION ALL "+
                    " SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE  (P.CountryID = {3}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') " +
                    " ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, projectTimeState, countryId);
            }
            else
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {2}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') " +
                    " UNION ALL "+
                    " SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState, P.Name + ' (' + P.ProjectNumber + ')' AS ProjectName " +
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {2}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') " +
                    " ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, countryId);
            }

            FillData(commandText);

            PrintVehicleLocationDaysGateway printVehicleLocationDaysGateway = new PrintVehicleLocationDaysGateway(Data);
            printVehicleLocationDaysGateway.FillData();
        }



        /// <summary>
        /// LoadByStartDateEndDateUnitIdProjectTimeStateCountryId
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="unitId">unitId</param>
        /// <param name="projectTimeState">projectTimeState</param>
        /// <param name="countryId">countryId</param>
        public void LoadByStartDateEndDateUnitIdProjectTimeStateCountryId(DateTime startDate, DateTime endDate, int unitId, string projectTimeState, int countryId)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState "+
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {4}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState LIKE '{3}') " + 
                    " UNION ALL "+
                    " SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {4}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState LIKE '{3}') " +
                    " ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, unitId, projectTimeState, countryId);
            }
            else
            {
                commandText = string.Format("SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, UT.UnitCode AS UnitTowedCode, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState "+
                    " FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_FM_UNIT UT ON PT.TowedUnitID = UT.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {3}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (UT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState <> 'Approved') " +
                    " UNION ALL "+
                    " SELECT PT.ProjectTimeID, E.EmployeeID, E.LastName + ', ' + E.FirstName AS FullName, PT.Date_, U.UnitCode, NULL, P.CountryID, CO.Name AS CountryName, CL.Name AS Client, PT.ProjectTimeState FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN dbo.LFS_FM_UNIT U ON PT.UnitID = U.UnitID INNER JOIN dbo.LFS_PROJECT P ON PT.ProjectID = P.ProjectID INNER JOIN dbo.LFS_Country CO ON P.CountryID = CO.CountryID INNER JOIN dbo.LFS_RESOURCES_COMPANIES CL ON PT.CompaniesID = CL.COMPANIES_ID "+
                    " WHERE (P.CountryID = {3}) AND (E.Deleted = 0) AND (PT.Deleted = 0) AND (U.Deleted = 0) AND (PT.TowedUnitID IS NULL) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (U.UnitID = {2}) AND (PT.ProjectTimeState <> 'Approved') " +
                    " ORDER BY U.UnitCode, P.CountryID, PT.Date_, E.LastName + ', ' + E.FirstName", startDate, endDate, unitId, countryId);
            }

            FillData(commandText);

            PrintVehicleLocationDaysGateway printVehicleLocationDaysGateway = new PrintVehicleLocationDaysGateway(Data);
            printVehicleLocationDaysGateway.FillData();
        }



    }
}