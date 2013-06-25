using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts    
{
    /// <summary>
    /// ActualCostsNavigatorHotelCostsGateway
    /// </summary>
    public class ActualCostsNavigatorHotelCostsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsNavigatorHotelCostsGateway()
            : base("HotelCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsNavigatorHotelCostsGateway(DataSet data)
            : base(data, "HotelCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsNavigatorTDS();
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
            tableMapping.DataSetTable = "HotelCosts";           
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("HotelID", "HotelID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Hotel", "Hotel");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");            
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");            
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");             
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            
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
            commandText = String.Format("SELECT HC.ProjectID, HC.RefID,HC.HotelID, HC.Date, H.Name AS Hotel, C.Name AS Client, P.Name AS Project, HC.RateCad, HC.RateUsd, HC.Comment, 0 AS Deleted, HC.COMPANY_ID, 0 AS Selected " +
                                        " FROM LFS_LABOUR_HOURS_ACTUAL_COSTS_HOTEL_COSTS HC INNER JOIN "+
                                        " LFS_RESOURCES_HOTELS H ON HC.HotelID = H.COMPANIES_ID INNER JOIN "+
                                        " LFS_PROJECT P ON HC.ProjectID = P.ProjectID INNER JOIN "+
                                        " LFS_RESOURCES_COMPANIES C ON P.ClientID = C.COMPANIES_ID " +
                                        " WHERE {0} ORDER BY {1}", whereClause, orderBy);
            
            FillData(commandText);
        }



    }
}