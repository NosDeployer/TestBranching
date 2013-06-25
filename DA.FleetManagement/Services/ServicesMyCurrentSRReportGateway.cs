using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServicesMyCurrentSRReportGateway
    /// </summary>
    public class ServicesMyCurrentSRReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServicesMyCurrentSRReportGateway()
            : base("MyCurrrentServiceRequest")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ServicesMyCurrentSRReportGateway(DataSet data)
            : base(data, "MyCurrrentServiceRequest")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServicesMyCurrentSRReportTDS();
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
            tableMapping.DataSetTable = "MyCurrrentServiceRequest";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Number", "Number");
            tableMapping.ColumnMappings.Add("ServiceDescription", "ServiceDescription");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("UnitDescription", "UnitDescription");
            tableMapping.ColumnMappings.Add("CreatedBy", "CreatedBy");
            tableMapping.ColumnMappings.Add("AssignedTo", "AssignedTo");
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
        /// LoadMyCurrentSRByAssignTeamMemberID
        /// </summary>
        /// <param name="state">state</param>
        /// <param name="assignTeamMemberId">assignTeamMemberId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyServicesByStateAssignTeamMemberID(string state, int assignTeamMemberId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICESMYCURRENTSRREPORTGATEWAY_LOADMYCURRENTSRBYASSIGNTEAMMEMBERID", new SqlParameter("@state", state), new SqlParameter("@assignTeamMemberId", assignTeamMemberId), new SqlParameter("@companyId", companyId));
            return Data;
        }



    }
}
