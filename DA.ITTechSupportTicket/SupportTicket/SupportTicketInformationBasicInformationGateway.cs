using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// SupportTicketInformationBasicInformationGateway
    /// </summary>
    public class SupportTicketInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SupportTicketInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SupportTicketInformationBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
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
            tableMapping.DataSetTable = "BasicInformation";
            tableMapping.ColumnMappings.Add("SupportTicketID", "SupportTicketID");
            tableMapping.ColumnMappings.Add("Subject", "Subject");
            tableMapping.ColumnMappings.Add("CreationDate", "CreationDate");
            tableMapping.ColumnMappings.Add("CreatedByID", "CreatedByID");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("DueDate", "DueDate");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("CategoryID", "CategoryID");
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
        /// LoadAllBySupportTicketId
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllBySupportTicketId(int supportTicketId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_ITTST_SUPPORTTICKETINFORMATIONBASICINFORMATIONGATEWAY_LOADALLBYSUPPORTTICKETID", new SqlParameter("@supportTicketId", supportTicketId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int supportTicketId)
        {
            string filter = string.Format("SupportTicketID = {0}", supportTicketId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket.SupportTicketInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int supportTicketId)
        {
            if (GetRow(supportTicketId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId)["State"];
            }
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>Original State or EMPTY</returns>
        public string GetStateOriginal(int supportTicketId)
        {
            if (GetRow(supportTicketId).IsNull(Table.Columns["State"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId)["State", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSubject
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>Subject or EMPTY</returns>
        public string GetSubject(int supportTicketId)
        {
            if (GetRow(supportTicketId).IsNull("Subject"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId)["Subject"];
            }
        }



        /// <summary>
        /// GetSubject Original
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>Original Subject or EMPTY</returns>
        public string GetSubjectOriginal(int supportTicketId)
        {
            if (GetRow(supportTicketId).IsNull(Table.Columns["Subject"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(supportTicketId)["Subject", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDueDate
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>DueDate or EMPTY</returns>
        public DateTime? GetDueDate(int supportTicketId)
        {
            if (GetRow(supportTicketId).IsNull("DueDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(supportTicketId)["DueDate"];
            }
        }



        /// <summary>
        /// GetDueDate Original If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>DueDate</returns>
        public DateTime? GetDueDateOriginal(int supportTicketId)
        {
            if (GetRow(supportTicketId).IsNull(Table.Columns["DueDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(supportTicketId)["DueDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCreationDate If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>CreationDate</returns>
        public DateTime GetCreationDate(int supportTicketId)
        {
            return (DateTime)GetRow(supportTicketId)["CreationDate"];
        }



        /// <summary>
        /// GetCreatedByID. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>CreatedByID</returns>
        public int GetCreatedByID(int supportTicketId)
        {
            return (int)GetRow(supportTicketId)["CreatedByID"];
        }


        
        /// <summary>
        /// GetCategoryId. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>CategoryID</returns>
        public int GetCategoryId(int supportTicketId)
        {
            return (int)GetRow(supportTicketId)["CategoryID"];
        }



        /// <summary>
        /// GetCategoryName. If not exists, raise an exception.
        /// </summary>
        /// <param name="supportTicketId">supportTicketId</param>
        /// <returns>CategoryID</returns>
        public string GetCategoryName(int supportTicketId)
        {
            return (string)GetRow(supportTicketId)["CategoryName"];
        }


                        
    }
}