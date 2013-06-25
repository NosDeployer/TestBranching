using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    public class TimesheetMissingReportGateway : DataTableGateway
    {
        // CONSTRUCTORS
        public TimesheetMissingReportGateway()
            : base("TimesheetMissingReport")
        {
        }

        public TimesheetMissingReportGateway(DataSet data)
            : base(data, "TimesheetMissingReport")
        {
        }



        // INITIALIZERS
        protected override void InitData()
        {
            _data = new TimesheetMissingReportTDS();
        }

        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "DataTable1";
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("FullName", "FullName");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        /// PUBLIC METHODS
        
        /// <summary>
        /// LoadByFromTo
        /// </summary>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        /// <param name="employeeState">employeeState</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="includeSalaried">includeSalaried</param>
        public void LoadByFromTo(DateTime from, DateTime to, string employeeState, string employeeType, bool includeSalaried)
        {
            string commandText = "";
            if (includeSalaried)
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                   "  FROM (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted " +
                                                   "          FROM " +
                                                   "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                   "                  FROM dbo.LFS_RESOURCES_EMPLOYEE AS E INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID " +
                                                   "                  WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.RequestProjectTime = 1) AND (E.State = '{2}') AND (E.Type like '%{3}') AND (E.Deleted = 0) " +
                                                   "                  GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                   "                ) AS AA " +
                                                   "          RIGHT JOIN " +
                                                   "                ( SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                   "                    FROM dbo.LFS__RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                   "                    WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.RequestProjectTime = 1) AND (E.State = '{2}') AND (E.Type like '%{3}') AND (E.Deleted = 0) " +
                                                   "                ) AS BB " +
                                                   "          ON  (AA.Date_ = BB.Date_) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                   "       ) AS CC " +
                                                   "  WHERE (CC.Deleted IS NULL) " +
                                                   "  ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), employeeState, employeeType);
            }
            else
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                   "  FROM (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted " +
                                                   "          FROM " +
                                                   "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                   "                  FROM dbo.LFS_RESOURCES_EMPLOYEE AS E INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID " +
                                                   "                  WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.RequestProjectTime = 1) AND (E.State = '{2}') AND (E.Type like '%{3}') AND (E.Salaried = 0) AND (E.Deleted = 0) " +
                                                   "                  GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                   "                ) AS AA " +
                                                   "          RIGHT JOIN " +
                                                   "                ( SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                   "                    FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                   "                    WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.RequestProjectTime = 1) AND (E.State = '{2}') AND (E.Type like '%{3}') AND (E.Salaried = 0) AND (E.Deleted = 0) " +
                                                   "                ) AS BB " +
                                                   "          ON  (AA.Date_ = BB.Date_) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                   "       ) AS CC " +
                                                   "  WHERE (CC.Deleted IS NULL) " +
                                                   "  ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), employeeState, employeeType);
            }

            FillData(commandText);
        }



        /// <summary>
        /// LoadByFromTo
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        /// <param name="employeeState">employeeState</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="includeSalaried">includeSalaried</param>
        public void LoadByCountryIdFromTo(int countryId, DateTime from, DateTime to, string employeeState, string employeeType, bool includeSalaried)
        {
            string commandText = "";
            if (includeSalaried)
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                   "  FROM (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted " +
                                                   "            FROM " +
                                                   "                (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                   "                    FROM dbo.LFS_RESOURCES_EMPLOYEE AS E INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID " +
                                                   "                    WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Deleted = 0) AND (P.CountryID = {2}) AND (P.Deleted = 0) " +
                                                   "                    GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                   "                ) AS AA " +
                                                   "            RIGHT JOIN " +
                                                   "                (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                   "                    FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                   "                    WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Deleted = 0) " +
                                                   "                ) AS BB " +
                                                   "            ON  (AA.Date_ = BB.Date_) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                   "       ) AS CC " +
                                                   "  WHERE (CC.Deleted IS NULL) " +
                                                   "  ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), countryId, employeeState, employeeType);
            }
            else
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                   "  FROM (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted " +
                                                   "            FROM " +
                                                   "                (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                   "                    FROM dbo.LFS_RESOURCES_EMPLOYEE AS E INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID " +
                                                   "                    WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Salaried = 0) AND (E.Deleted = 0) AND (P.CountryID = {2}) AND (P.Deleted = 0) " +
                                                   "                    GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                   "                ) AS AA " +
                                                   "            RIGHT JOIN " +
                                                   "                (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                   "                    FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                   "                    WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Salaried = 0) AND (E.Deleted = 0) " +
                                                   "                ) AS BB " +
                                                   "            ON  (AA.Date_ = BB.Date_) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                   "       ) AS CC " +
                                                   "  WHERE (CC.Deleted IS NULL) " +
                                                   "  ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), countryId, employeeState, employeeType);
            }

            FillData(commandText);
        }



        /// <summary>
        /// LoadByEmployeeIDFromTo
        /// </summary>
        /// <param name="employeeID">employeeID</param>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        /// <param name="employeeState">employeeState</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="includeSalaried">includeSalaried</param>
        public void LoadByEmployeeIDFromTo(int employeeID, DateTime from, DateTime to, string employeeState, string employeeType, bool includeSalaried)
        {
            string commandText = "";
            if (includeSalaried)
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                    "   FROM  (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted	" +
                                                    "           FROM " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E	INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID " +
                                                    "                   WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Deleted = 0) " +
                                                    "                   GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                    "               ) AS AA " +
                                                    "           RIGHT JOIN " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                    "                   WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Deleted = 0) " +
                                                    "               ) AS BB " +
                                                    "           ON (AA.Date_ = BB.Date_ ) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                    "       ) AS CC " +
                                                    "   WHERE (CC.Deleted IS NULL) " +
                                                    "   ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), employeeID, employeeState, employeeType);
            }
            else
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                    "   FROM  (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted	" +
                                                    "           FROM " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E	INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID " +
                                                    "                   WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Salaried = 0) AND (E.Deleted = 0) " +
                                                    "                   GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                    "               ) AS AA " +
                                                    "           RIGHT JOIN " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                    "                   WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{3}') AND (E.Type like '%{4}') AND (E.Salaried = 0) AND (E.Deleted = 0) " +
                                                    "               ) AS BB " +
                                                    "           ON (AA.Date_ = BB.Date_ ) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                    "       ) AS CC " +
                                                    "   WHERE (CC.Deleted IS NULL) " +
                                                    "   ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), employeeID, employeeState, employeeType);
            }

            FillData(commandText);
        }



        /// <summary>
        /// LoadByCountryIdEmployeeIDFromTo
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="employeeID">employeeID</param>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        /// <param name="employeeState">employeeState</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="includeSalaried">includeSalaried</param>
        public void LoadByCountryIdEmployeeIDFromTo(int countryId, int employeeID, DateTime from, DateTime to, string employeeState, string employeeType, bool includeSalaried)
        {
            string commandText = "";
            if (includeSalaried)
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                    "   FROM  (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted	" +
                                                    "           FROM " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID " +
                                                    "                   WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{4}') AND (E.Type like '%{5}') AND (E.Deleted = 0) AND (P.CountryID = {3}) AND (P.Deleted = 0) " +
                                                    "                   GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                    "               ) AS AA " +
                                                    "           RIGHT JOIN " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                    "                   WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{4}') AND (E.Type like '%{5}') AND (E.Deleted = 0) " +
                                                    "               ) AS BB " +
                                                    "           ON (AA.Date_ = BB.Date_ ) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                    "       ) AS CC " +
                                                    "   WHERE (CC.Deleted IS NULL) " +
                                                    "   ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), employeeID, countryId, employeeState, employeeType);
            }
            else
            {
                commandText = string.Format("SELECT Date_, EmployeeID, FullName " +
                                                    "   FROM  (SELECT BB.Date_, BB.EmployeeID, BB.FullName, AA.EmployeeID AS Deleted	" +
                                                    "           FROM " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PT.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E INNER JOIN dbo.LFS_PROJECT_TIME AS PT ON E.EmployeeID = PT.EmployeeID INNER JOIN LFS_PROJECT AS P ON PT.ProjectID = P.ProjectID " +
                                                    "                   WHERE (PT.Date_ BETWEEN '{0}' AND '{1}') AND (PT.Deleted = 0) AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{4}') AND (E.Type like '%{5}') AND (E.Salaried = 0) AND (E.Deleted = 0) AND (P.CountryID = {3}) AND (P.Deleted = 0) " +
                                                    "                   GROUP BY PT.Date_, E.LastName + ' ' + E.FirstName, E.EmployeeID " +
                                                    "               ) AS AA " +
                                                    "           RIGHT JOIN " +
                                                    "               (SELECT E.EmployeeID, E.LastName + ' ' + E.FirstName AS FullName, PPD.Date_ " +
                                                    "                   FROM dbo.LFS_RESOURCES_EMPLOYEE AS E, dbo.LFS_PAY_PERIOD_DAY PPD " +
                                                    "                   WHERE (PPD.Date_ BETWEEN '{0}' AND '{1}') AND (E.EmployeeID = {2}) AND (E.RequestProjectTime = 1) AND (E.State = '{4}') AND (E.Type like '%{5}') AND (E.Salaried = 0) AND (E.Deleted = 0) " +
                                                    "               ) AS BB " +
                                                    "           ON (AA.Date_ = BB.Date_ ) AND (AA.EmployeeID = BB.EmployeeID) " +
                                                    "       ) AS CC " +
                                                    "   WHERE (CC.Deleted IS NULL) " +
                                                    "   ORDER BY FullName", string.Format("{0}/{1}/{2}", from.Month, from.Day, from.Year), string.Format("{0}/{1}/{2}", to.Month, to.Day, to.Year), employeeID, countryId, employeeState, employeeType);
            }

            FillData(commandText);
        }



    }
}
