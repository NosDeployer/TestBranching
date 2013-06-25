using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketInformationActivityInformationGateway
    /// </summary>
    public class SupportTicketInformationActivityInformationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketInformationActivityInformationGateway()
            : base("ActivityInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketInformationActivityInformationGateway(DataSet data)
            : base(data, "ActivityInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SupportTicketInformationTDS();
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
            tableMapping.DataSetTable = "ActivityInformation";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("EmployeeID", "EmployeeID");
            tableMapping.ColumnMappings.Add("Type_", "Type_");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("EmployeeFullName", "EmployeeFullName");
            tableMapping.ColumnMappings.Add("SendMail", "SendMail");
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
        /// LoadAllBySupportTicketId
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllBySupportTicketId(int supportTicketId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ITTST_SUPPORTTICKETINFORMATIONACTIVITYINFORMATIONGATEWAY_LOADALLBYSUPPORTTICKETID", new SqlParameter("@supportTicketId", supportTicketId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int supportTicketId, int refId)
        {
            string filter = string.Format("SupportTicketID = {0} AND RefID = {1}", supportTicketId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket.SupportTicketInformationActivityInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetEmployeeID
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>EmployeeID or EMPTY</returns>
        public int GetEmployeeID(int supportTicketId, int refId)
        {           
            return (int)GetRow(supportTicketId, refId)["EmployeeID"];           
        }



        /// <summary>
        /// GetEmployeeID Original
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original EmployeeID or EMPTY</returns>
        public int GetEmployeeIDOriginal(int supportTicketId, int refId)
        {          
            return (int)GetRow(supportTicketId, refId)["EmployeeID", DataRowVersion.Original];           
        }



        /// <summary>
        /// GetType_
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>Type_ or EMPTY</returns>
        public string GetType_(int supportTicketId, int refId)
        {
            if (GetRow(supportTicketId, refId).IsNull("Type_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId, refId)["Type_"];
            }
        }



        /// <summary>
        /// GetDateTime_
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>DateTime_ or EMPTY</returns>
        public DateTime GetDateTime_(int supportTicketId, int refId)
        {
            return (DateTime)GetRow(supportTicketId, refId)["DateTime_"];         
        }



        /// <summary>
        /// GetComment
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>Comment or EMPTY</returns>
        public string GetComment(int supportTicketId, int refId)
        {
            if (GetRow(supportTicketId, refId).IsNull("Comment"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId, refId)["Comment"];
            }
        }


        
        /// <summary>
        /// GetComment Original
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Comment or EMPTY</returns>
        public string GetCommentOriginal(int supportTicketId, int refId)
        {
            if (GetRow(supportTicketId, refId).IsNull(Table.Columns["Comment"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId, refId)["Comment", DataRowVersion.Original];
            }
        }

        

        /// <summary>
        /// GetEmployeeFullName
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>EmployeeFullName or EMPTY</returns>
        public string GetEmployeeFullName(int supportTicketId, int refId)
        {
            if (GetRow(supportTicketId, refId).IsNull("EmployeeFullName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId, refId)["EmployeeFullName"];
            }
        }



        /// <summary>
        /// GetSendMail Original
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original SendMail or EMPTY</returns>
        public bool GetSendMailOriginal(int supportTicketId, int refId)
        {
            return (bool)GetRow(supportTicketId, refId)["SendMail", DataRowVersion.Original];
        }



    }
}