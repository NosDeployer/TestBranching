using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard
{
    /// <summary>
    /// DashboardMySupportTicketGateway
    /// </summary>
    public class DashboardMySupportTicketGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public DashboardMySupportTicketGateway()
            : base("DashboardMySupportTicket")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public DashboardMySupportTicketGateway(DataSet data)
            : base(data, "DashboardMySupportTicket")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new DashboardTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "DashboardMySupportTicket";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("LastComment", "LastComment");
            tableMapping.ColumnMappings.Add("CategoryName", "CategoryName");
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
        /// LoadCurrentSupportTicket
        /// </summary>                
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadCurrentSupportTicketByState(string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ITTST_DASHBOARDMYSUPPORTTICKETGATEWAY_LOADALLCURRENTSUPPORTTICKETBYSTATE", new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadMyCurrentSupportTicketByCreatedById
        /// </summary>        
        /// <param name="createdById">createdById</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadMyCurrentSupportTicketByCreatedByIdState(int createdById, string state, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ITTST_DASHBOARDMYSUPPORTTICKETGATEWAY_LOADALLMYCURRENTSUPPORTTICKETBYCREATEDBYIDSTATE", new SqlParameter("@createdById", createdById), new SqlParameter("@state", state), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int supportTicketId)
        {
            string filter = string.Format("(SupportTicketID = {0})", supportTicketId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.ITTechSupportTicket.Dashboard.DashboardMySupportTicketGateway.GetRow");
            }
        }



        /// <summary>
        /// GetMySubject
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>Subject</returns>
        public string GetMySubject(int supportTicketId)
        {
            return (string)GetRow(supportTicketId)["Subject"];
        }



    }
}