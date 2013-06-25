using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// FlatSectionJlinerJuntionLiner2HistoryGateway
    /// </summary>
    public class FlatSectionJlinerJuntionLiner2HistoryGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlinerJuntionLiner2HistoryGateway()
            : base("JuntionLiner2History")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlinerJuntionLiner2HistoryGateway(DataSet data)
            : base(data, "JuntionLiner2History")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlinerTDS();
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
            tableMapping.DataSetTable = "JuntionLiner2History";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("HistoryID", "HistoryID");
            tableMapping.ColumnMappings.Add("DateTime_", "DateTime_");
            tableMapping.ColumnMappings.Add("LoginID", "LoginID");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("toComments", "toComments");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("UserFullName", "UserFullName");

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
        /// LoadAllByIdRefId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLINERJUNCTIONLINER2HISTORYGATEWAY_LOADALLBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByIdRefId
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLINERJUNCTIONLINER2HISTORYGATEWAY_LOADBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>        
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="historyId">historyId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(Guid id, int refId, int companyId, int historyId)
        {
            string filter = string.Format("(ID = '{0}') AND (RefID = {1}) AND (COMPANY_ID = {2} AND (HistoryID = {3}))", id, refId, companyId, historyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.Jliner.FlatSectionJlinerJunctionLiner2HistoryGateway.GetRow");
            }
        }



        /// <summary>
        /// GetHistory. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>  
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <returns>Comment o EMPTY</returns>
        public string GetComment(Guid id, int refId, int companyId, int historyId)
        {
            if (GetRow(id, refId, companyId, historyId).IsNull("History"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId, historyId)["History"];
            }
        }



        /// <summary>
        /// GetHistory Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <returns>Original History or EMPTY</returns>
        public string GetHistoryOriginal(Guid id, int refId, int companyId, int historyId)
        {
            if (GetRow(id, refId, companyId, historyId).IsNull(Table.Columns["History"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId, historyId)["History", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLoginID Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <returns>Original LoginID or EMPTY</returns>
        public int GetLoginIDOriginal(Guid id, int refId, int companyId, int historyId)
        {
            return (int)GetRow(id, refId, companyId, historyId)["LoginID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDateTime_ Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="historyId">historyId</param>
        /// <returns>Original DateTime_ or EMPTY</returns>
        public DateTime? GetDateTime_Original(Guid id, int refId, int companyId, int historyId)
        {
            if (GetRow(id, refId, companyId, historyId).IsNull(Table.Columns["DateTime_"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId, historyId)["DateTime_", DataRowVersion.Original];
            }
        }



    }
}


      