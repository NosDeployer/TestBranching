using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation
{
    /// <summary>
    /// ManholeRehabilitationWorkDetailsGateway
    /// </summary>
    public class ManholeRehabilitationWorkDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ManholeRehabilitationWorkDetailsGateway()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ManholeRehabilitationWorkDetailsGateway(DataSet data)
            : base(data, "WorkDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ManholeRehabilitationTDS();
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
            tableMapping.DataSetTable = "WorkDetails";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("PreppedDate", "PreppedDate");
            tableMapping.ColumnMappings.Add("SprayedDate", "SprayedDate");
            tableMapping.ColumnMappings.Add("BatchID", "BatchID");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("Comments", "Comments");

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
        /// LoadByWorkIdAssetId
        /// </summary>
        /// <param name="workId">workID</param>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByWorkIdAssetId(int workId, int assetId,int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_MANHOLEREHABILITATIONWORKDETAILSGATEWAY_LOADBYWORKIDASSETID", new SqlParameter("@workId", workId), new SqlParameter("@assetId", assetId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("WorkID = {0}", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation.ManholeRehabilitationWorkDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetPreppedDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreppedDate o EMPTY</returns>
        public DateTime? GetPreppedDate(int workId)
        {
            if (GetRow(workId).IsNull("PreppedDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreppedDate"];
            }
        }



        /// <summary>
        /// GetPreppedDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreppedDate or EMPTY</returns>
        public DateTime? GetPreppedDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreppedDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreppedDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSprayedDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SprayedDate o EMPTY</returns>
        public DateTime? GetSprayedDate(int workId)
        {
            if (GetRow(workId).IsNull("SprayedDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["SprayedDate"];
            }
        }



        /// <summary>
        /// GetSprayedDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SprayedDate or EMPTY</returns>
        public DateTime? GetSprayedDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["SprayedDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["SprayedDate", DataRowVersion.Original];
            }
        }
                       
        

        /// <summary>
        /// GetBatchID. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>BatchID</returns>
        public int GetBatchID(int workId)
        {
            return (int)GetRow(workId)["BatchID"];
        }



        /// <summary>
        /// GetBatchID Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original BatchID or EMPTY</returns>
        public int GetBatchIDOriginal(int workId)
        {
            return (int)GetRow(workId)["BatchID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Date o EMPTY</returns>
        public DateTime? GetDate(int workId)
        {
            if (GetRow(workId).IsNull("Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Date"];
            }
        }



        /// <summary>
        /// GetDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Date or EMPTY</returns>
        public DateTime? GetDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDescription. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Description o EMPTY</returns>
        public string GetDescription(int workId)
        {
            if (GetRow(workId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Description"];
            }
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Description", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Comments o EMPTY</returns>
        public string GetComments(int workId)
        {
            if (GetRow(workId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments", DataRowVersion.Original];
            }
        }
    }
}