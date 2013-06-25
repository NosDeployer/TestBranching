using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    public class Print3ChartReportTempGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public Print3ChartReportTempGateway()
            : base("Print3ChartReportTemp")
        {
        }

        public Print3ChartReportTempGateway(DataSet data)
            : base(data, "Print3ChartReportTemp")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new Print3ChartReportTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "Print3ChartReportTemp";
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            tableMapping.ColumnMappings.Add("ProjectTime", "ProjectTime");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



        // METHODS
        public void LoadByDateProjectTimeState(DateTime date, string projectTimeState)
        {
            string commandText = "";

            if (projectTimeState != "Unapproved")
            {
                commandText = string.Format("SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, SUM(ROUND(PT.ProjectTime,2)) AS ProjectTime FROM LFS_RESOURCES_EMPLOYEE AS E INNER JOIN LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ > '{0}') AND (PT.ProjectTimeState LIKE '{1}') GROUP BY E.EmployeeID, E.LastName + ' ' + E.FirstName", date, projectTimeState);
            }
            else
            {
                commandText = string.Format("SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, SUM(ROUND(PT.ProjectTime,2)) AS ProjectTime FROM LFS_RESOURCES_EMPLOYEE AS E INNER JOIN LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID WHERE (E.Deleted = 0) AND (PT.Deleted = 0) AND (PT.Date_ > '{0}') AND (PT.ProjectTimeState <> 'Approved') GROUP BY E.EmployeeID, E.LastName + ' ' + E.FirstName", date);
            }

            FillData(commandText);
       }
    }
}
