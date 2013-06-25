using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintEmployeeLocationGateway
    /// </summary>
    public class PrintEmployeeLocationGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public PrintEmployeeLocationGateway()
            : base("PrintEmployeeLocation")
        {
        }

        public PrintEmployeeLocationGateway(DataSet data)
            : base(data, "PrintEmployeeLocation")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new PrintEmployeeLocationTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "PrintEmployeeLocation";
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("ProjectNane", "ProjectName");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        // METHODS
        public void LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate);
            }

            FillData(commandText);
        }




        public void LoadByStartDateEndDateLocationProjectTimeState(DateTime startDate, DateTime endDate, string location, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Location LIKE '%{2}%') AND (PT.ProjectTimeState LIKE '{3}') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, location, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Location LIKE '%{2}%') AND (PT.ProjectTimeState <> 'Approved') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, location);
            }
            
            FillData(commandText);
        }



        public void LoadByStartDateEndDateEmployeeIdProjectTimeState(DateTime startDate, DateTime endDate, int employeeId, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (PT.ProjectTimeState LIKE '{3}') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, employeeId, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (PT.ProjectTimeState <> 'Approved') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, employeeId);
            }

            FillData(commandText);
        }




        public void LoadByStartDateEndDateEmployeeIdLocationProjectTimeState(DateTime startDate, DateTime endDate, int employeeId, string location, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (PT.Location like '%{3}%') AND (PT.ProjectTimeState LIKE '{4}') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, employeeId, location, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, PT.Date_, SUM(PT.ProjectTime) AS ProjectTime, C.NAME AS ClientName, LP.Name+' ('+LP.ProjectNumber+')' AS ProjectName FROM dbo.LFS_RESOURCES_EMPLOYEE E INNER JOIN dbo.LFS_PROJECT_TIME PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT LP ON LP.ProjectID = PT.ProjectID INNER JOIN LFS_RESOURCES_COMPANIES C ON C.COMPANIES_ID = LP.ClientID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (PT.Location like '%{3}%') AND (PT.ProjectTimeState <> 'Approved') GROUP BY E.LastName + ' ' + E.FirstName, PT.Date_, C.NAME, LP.Name, LP.ProjectNumber", startDate, endDate, employeeId, location);
            }

            FillData(commandText);
        }



    }
}