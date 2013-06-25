using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintLogsOver15HoursGateway
    /// </summary>
    public class PrintLogsOver15HoursGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public PrintLogsOver15HoursGateway()
            : base("LFS_PROJECT_TIME")
        {
        }

        public PrintLogsOver15HoursGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new PrintLogsOver15HoursTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_PROJECT_TIME";
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("Country", "Country");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
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



        // METHODS
        public void LoadByStartDateEndDateProjectTimeState(DateTime startDate, DateTime endDate, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, C.Name AS Country, PT.Date_, PT.ProjectTime, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_RESOURCES_EMPLOYEE AS E INNER JOIN LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (P.Deleted = 0) AND (((PT.ProjectTime > 14 ) AND (C.CountryID = 1)) OR ((PT.ProjectTime > 15 ) AND (C.CountryID = 2))) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState LIKE '{2}') ORDER BY E.LastName + ' ' + E.FirstName, PT.Date_", startDate, endDate, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT E.LastName + ' ' + E.FirstName AS FullName, C.Name AS Country, PT.Date_, PT.ProjectTime, PT.UnitID, PT.TowedUnitID, PT.ProjectTimeState FROM LFS_RESOURCES_EMPLOYEE AS E INNER JOIN LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID INNER JOIN LFS_COUNTRY AS C ON P.CountryID = C.CountryID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (P.Deleted = 0) AND (((PT.ProjectTime > 14 ) AND (C.CountryID = 1)) OR ((PT.ProjectTime > 15 ) AND (C.CountryID = 2))) AND (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.ProjectTimeState <> 'Approved') ORDER BY E.LastName + ' ' + E.FirstName, PT.Date_", startDate, endDate);
            }

            FillData(commandText);
        }



    }
}