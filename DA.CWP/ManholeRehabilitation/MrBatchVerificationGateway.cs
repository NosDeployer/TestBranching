using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation
{
    /// <summary>
    /// MrBatchVerificationGateway
    /// </summary>
    public class MrBatchVerificationGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MrBatchVerificationGateway()
            : base("BatchValidation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MrBatchVerificationGateway(DataSet data)
            : base(data, "BatchValidation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MrBatchVerificationTDS();
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
            tableMapping.DataSetTable = "BatchValidation";
            tableMapping.ColumnMappings.Add("BatchID", "BatchID");
            tableMapping.ColumnMappings.Add("Number", "Number");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            
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
        /// LoadAll
        /// </summary>
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadAll(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MRBATCHVERIFICATIONGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByBatchId
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadByBatchId(int batchId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MRBATCHVERIFICATIONGATEWAY_LOADBYBATCHID", new SqlParameter("@batchId", batchId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadLastBatch
        /// </summary>        
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadLastBatch(int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MRBATCHVERIFICATIONGATEWAY_LOADLASTBATCH", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int batchId)
        {
            string filter = string.Format("BatchID = {0}", batchId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation.MrBatchVerificationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <returns>Description or EMPTY</returns>
        public string GetDescription(int batchId)
        {
            if (GetRow(batchId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(batchId)["Description"];
            }
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int batchId)
        {
            if (GetRow(batchId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(batchId)["Description", DataRowVersion.Original];
            }
        }
               
        
        
        /// <summary>
        /// GetDate
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <returns>Date or EMPTY</returns>
        public DateTime GetDate(int batchId)
        {
            return (DateTime)GetRow(batchId)["Date"];         
        }



        /// <summary>
        /// GetDate Original
        /// </summary>
        /// <param name="batchId">batchId</param>
        /// <returns>Original Date or EMPTY</returns>
        public DateTime GetDateOriginal(int batchId)
        {
            return (DateTime)GetRow(batchId)["Date", DataRowVersion.Original];
        }

    }
}
