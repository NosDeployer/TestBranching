using System.Data;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketAddBasicInformationGateway
    /// </summary>
    public class SupportTicketAddBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public SupportTicketAddBasicInformationGateway() : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public SupportTicketAddBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketAddTDS();
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("UnitId", "UnitId");
            tableMapping.ColumnMappings.Add("TeamMemberID", "TeamMemberID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("CreatedByID", "CreatedByID");
            tableMapping.ColumnMappings.Add("Type_", "Type_");
            tableMapping.ColumnMappings.Add("CategoryName", "CategoryName");
            
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }



    }
}