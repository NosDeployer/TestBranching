using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.Projects.Revenue
{
    /// <summary>
    /// RevenueNavigatorGateway
    /// </summary>
    public class RevenueNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RevenueNavigatorGateway()
            : base("RevenueNavigator")
        {
        }


        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>

        public RevenueNavigatorGateway(DataSet data)
            : base(data, "RevenueNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RevenueNavigatorTDS();
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
            tableMapping.DataSetTable = "RevenueNavigator";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Revenue", "Revenue");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Selected", "Selected");       
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("CrountryID", "CrountryID");                   
            
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
        public void LoadWhereOrderBy(string where, string orderBy)
        {            
            string commandText = "";

            commandText = String.Format("SELECT     LPR.ProjectID, LPR.RefID, LPR.Date, LPR.Revenue, LPR.Comment, LPR.Deleted, LPR.COMPANY_ID, CAST(0 AS bit) AS Selected, C.Name AS Client,  " +
                     "  LP.Name + ' ( '+ LP.ProjectNumber  + ' )' AS Project, LP.CountryID  " +
                     "  FROM         LFS_PROJECT_REVENUE AS LPR INNER JOIN  " +
                     "  LFS_PROJECT AS LP ON LPR.ProjectID = LP.ProjectID INNER JOIN  " +
                     "  LFS_RESOURCES_COMPANIES AS C ON LP.ClientID = C.COMPANIES_ID  " +
                     " WHERE {0} ORDER BY {1}", where, orderBy);           

            FillData(commandText);
        }



    }
}