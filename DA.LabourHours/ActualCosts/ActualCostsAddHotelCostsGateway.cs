using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsAddHotelCostsGateway
    /// </summary>
    public class ActualCostsAddHotelCostsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsAddHotelCostsGateway()
            : base("HotelCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsAddHotelCostsGateway(DataSet data)
            : base(data, "HotelCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsAddTDS();
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
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");            
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("Rate", "Rate");            
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
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
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Dataset</returns>
        public DataSet LoadAllByProjectId(int projectId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSADDHOTELCOSTSGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, int refId)
        {
            string filter = string.Format("ProjectID = {0} AND RefID = {1}", projectId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.ActualCosts.ActualCostsAddHotelCostsGateway.GetRow");
            }
        }




        /// <summary>
        /// GetClockPosition
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ClockPosition or EMPTY</returns>
        public int? GetClientID(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("ClientID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId, refId)["ClientID"];
            }
        }



    }
}