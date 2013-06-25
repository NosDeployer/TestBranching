using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesNavigatorGateway
    /// </summary>
    public class ServicesNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesNavigatorGateway()
            : base("ServicesNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServicesNavigatorGateway(DataSet data)
            : base(data, "ServicesNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesNavigatorTDS();
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
            tableMapping.DataSetTable = "ServicesNavigator";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("ServiceNumber", "ServiceNumber");
            tableMapping.ColumnMappings.Add("MTO", "MTO");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("UnitDescription", "UnitDescription");
            tableMapping.ColumnMappings.Add("ProblemDescription", "ProblemDescription");
            tableMapping.ColumnMappings.Add("ChecklistRule", "ChecklistRule");
            tableMapping.ColumnMappings.Add("CreatedBy", "CreatedBy");
            tableMapping.ColumnMappings.Add("AssignedTo", "AssignedTo");
            tableMapping.ColumnMappings.Add("StartDate", "StartDate");
            tableMapping.ColumnMappings.Add("CompleteDate", "CompleteDate");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("DeadlineDate", "DeadlineDate");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("VIN", "VIN");
            tableMapping.ColumnMappings.Add("UnitState", "UnitState");
            tableMapping.ColumnMappings.Add("ChecklistState", "ChecklistState");
            tableMapping.ColumnMappings.Add("Mileage", "Mileage");
            tableMapping.ColumnMappings.Add("AssignDateTime", "AssignDateTime");
            tableMapping.ColumnMappings.Add("AcceptDateTime", "AcceptDateTime");
            tableMapping.ColumnMappings.Add("StartWorkOutOfServiceDate", "StartWorkOutOfServiceDate");
            tableMapping.ColumnMappings.Add("StartWorkOutOfServiceTime", "StartWorkOutOfServiceTime");
            tableMapping.ColumnMappings.Add("StartWorkMileage", "StartWorkMileage");
            tableMapping.ColumnMappings.Add("CompleteWorkBackToServiceDate", "CompleteWorkBackToServiceDate");
            tableMapping.ColumnMappings.Add("CompleteWorkBackToServiceTime", "CompleteWorkBackToServiceTime");
            tableMapping.ColumnMappings.Add("CompleteWorkMileage", "CompleteWorkMileage");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailDescription", "CompleteWorkDetailDescription");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailPreventable", "CompleteWorkDetailPreventable");
            tableMapping.ColumnMappings.Add("CompleteWorkDetailTMLabourHours", "CompleteWorkDetailTMLabourHours");
            tableMapping.ColumnMappings.Add("WorkingLocation", "WorkingLocation");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        public void LoadWhereOrderBy(string where, string orderBy, string conditionValue, string textForSearch)
        {
            string commandText = "";
            commandText = String.Format("SELECT LFS.ServiceID, LFS.Number AS ServiceNumber, LFS.MTO, LFU.UnitCode, LFU.Description AS UnitDescription, LFS.Description AS ProblemDescription, " +
                      " LFR.Name AS ChecklistRule, LEOwner.LastName + ' '+ LEOwner.FirstName AS CreatedBy, LEAssignedTo.LastName + ' '+ LEAssignedTo.FirstName AS AssignedTo, LFS.StartWorkDateTime AS StartDate, " +
                      " LFS.CompleteWorkDateTime AS CompleteDate, '' AS Notes, CAST(0 AS bit) AS Selected, LFS.COMPANY_ID, CAST(0 AS bit) AS Deleted, LFS.AssignDeadlineDate AS DeadlineDate, LFS.State, " +
                      " LFS.DateTime_, LFU.VIN, LFU.State as UnitState, LFC.State as ChecklistState, LFSV.Mileage, LFS.AssignDateTime, LFS.AcceptDateTime, LFS.StartWorkOutOfServiceDate, LFS.StartWorkOutOfServiceTime, "+
                      " LFSV.StartWorkMileage, LFS.CompleteWorkBackToServiceDate, LFS.CompleteWorkBackToServiceTime, LFSV.CompleteWorkMileage, LFS.CompleteWorkDetailDescription, LFS.CompleteWorkDetailPreventable, "+
                      " LFS.CompleteWorkDetailTMLabourHours, LFCL.Name AS WorkingLocation "+
                      " FROM LFS_FM_RULE LFR INNER JOIN "+
                      " LFS_FM_CHECKLIST LFC ON LFR.RuleID = LFC.RuleID RIGHT OUTER JOIN "+
                      " LFS_FM_SERVICE LFS LEFT JOIN LFS_FM_SERVICE_VEHICLE LFSV ON LFSV.ServiceID = LFS.ServiceID INNER JOIN "+
                      " LFS_FM_UNIT LFU ON LFS.UnitID = LFU.UnitID INNER JOIN "+
                      " LFS_FM_COMPANYLEVEL LFCL ON LFU.CompanyLevelID = LFCL.CompanyLevelID INNER JOIN "+
                      " LFS_RESOURCES_EMPLOYEE LEOwner ON LFS.OwnerID = LEOwner.EmployeeID LEFT OUTER JOIN "+
                      " LFS_RESOURCES_EMPLOYEE LEAssignedTo ON LFS.AssignTeamMemberID = LEAssignedTo.EmployeeID ON LFC.UnitID = LFS.UnitID AND "+
                      " LFC.RuleID = LFS.RuleID "+
          " WHERE {0} {1}", where, orderBy);
            FillData(commandText);
        }



        /// <summary>
        /// LoadForViewsProjectIdCompanyIdFmType
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="companyId">companyId</param>
        /// <param name="fmType">fmType</param>
        public void LoadForViewsProjectIdCompanyIdFmType(string sqlCommand, int companyId, string fmType)
        {
            string commandText = String.Format(sqlCommand, companyId);
            FillData(commandText);
        }



    }
}