using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursNavigatorGateway
    /// </summary>
    public class SubcontractorHoursNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursNavigatorGateway()
            : base("SubcontractorHoursNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursNavigatorGateway(DataSet data)
            : base(data, "SubcontractorHoursNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursNavigatorTDS();
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
            tableMapping.DataSetTable = "SubcontractorHoursNavigator";
            tableMapping.ColumnMappings.Add("SubcontractorID", "SubcontractorID");
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Subcontractor", "Subcontractor");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("TotalCad", "TotalCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("TotalUsd", "TotalUsd");
            tableMapping.ColumnMappings.Add("Select", "Selected");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
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
        public void LoadWhereOrderBy(string whereClause, string orderBy)
        {
            string commandText = "";
            commandText = String.Format("SELECT SC.SubcontractorID, SC.ProjectID, SC.RefID, SC.Date, S.Name AS Subcontractor, C.NAME AS Client, P.Name AS Project, SC.Quantity, SC.RateCad, SC.TotalCad, SC.RateUsd, SC.TotalUsd, 0 AS Selected, 0 AS Deleted " +
                                                      " FROM LFS_SUBCONTRACTOR_HOURS SC INNER JOIN LFS_RESOURCES_SUBCONTRACTORS S ON SC.SubcontractorID = S.COMPANIES_ID INNER JOIN LFS_PROJECT P ON SC.ProjectID = P.ProjectID INNER JOIN COMPANIES C ON P.ClientID = C.COMPANIES_ID " +
                                                      " WHERE {0} ORDER BY {1}", whereClause, orderBy);
            
            FillData(commandText);
        }



    }
}