using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FlResinsAddGateway
    /// </summary>
    public class FlResinsAddGateway: DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlResinsAddGateway()
            : base("FlResinsAdd")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlResinsAddGateway(DataSet data)
            : base(data, "FlResinsAdd")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlResinsAddTDS();
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
            tableMapping.DataSetTable = "FlResinsAdd";
            tableMapping.ColumnMappings.Add("ResinID", "ResinID");
            tableMapping.ColumnMappings.Add("ResinMake", "ResinMake");
            tableMapping.ColumnMappings.Add("ResinType", "ResinType");
            tableMapping.ColumnMappings.Add("ResinNumber", "ResinNumber");
            tableMapping.ColumnMappings.Add("LbUsg", "LbUsg");
            tableMapping.ColumnMappings.Add("LbDrums", "LbDrums");
            tableMapping.ColumnMappings.Add("ActiveResin", "ActiveResin");
            tableMapping.ColumnMappings.Add("ApplyCatalystTo", "ApplyCatalystTo");
            tableMapping.ColumnMappings.Add("Filter", "Filter");
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
            FillDataWithStoredProcedure("LFS_CWP_FLRESINSADDGATEWAY_LOADALL", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByResinId
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>data set</returns>
        public DataSet LoadByResinId(int resinId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLRESINSADDGATEWAY_LOADBYRESINID", new SqlParameter("@resinId", resinId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int resinId)
        {
            string filter = string.Format("ResinID = {0}", resinId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLenthLining.FlResinsAddGateway.GetRow");
            }
        }



        /// <summary>
        /// GetResinMake
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ResinMake or EMPTY</returns>
        public string GetResinMake(int resinId)
        {
            if (GetRow(resinId).IsNull("ResinMake"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinMake"];
            }
        }



        /// <summary>
        /// GetResinMake Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original ResinMake or EMPTY</returns>
        public string GetResinMakeOriginal(int resinId)
        {
            if (GetRow(resinId).IsNull(Table.Columns["ResinMake"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinMake", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetResinType
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ResinType or EMPTY</returns>
        public string GetResinType(int resinId)
        {
            if (GetRow(resinId).IsNull("ResinType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinType"];
            }
        }



        /// <summary>
        /// GetResinType Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original ResinType or EMPTY</returns>
        public string GetResinTypeOriginal(int resinId)
        {
            if (GetRow(resinId).IsNull(Table.Columns["ResinType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetResinNumber
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ResinNumber or EMPTY</returns>
        public string GetResinNumber(int resinId)
        {
            if (GetRow(resinId).IsNull("ResinNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinNumber"];
            }
        }



        /// <summary>
        /// GetResinNumber Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original ResinNumber or EMPTY</returns>
        public string GetResinNumberOriginal(int resinId)
        {
            if (GetRow(resinId).IsNull(Table.Columns["ResinNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ResinNumber", DataRowVersion.Original];
            }
        }
               
        
        
        /// <summary>
        /// GetLbUsg
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>LbUsg or EMPTY</returns>
        public decimal GetLbUsg(int resinId)
        {
            return (decimal)GetRow(resinId)["LbUsg"];         
        }



        /// <summary>
        /// GetLbUsg Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original LbUsg or EMPTY</returns>
        public decimal GetLbUsgOriginal(int resinId)
        {
            return (decimal)GetRow(resinId)["LbUsg", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLbDrums
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>LbDrums or EMPTY</returns>
        public int GetLbDrums(int resinId)
        {
            return (int)GetRow(resinId)["LbDrums"];
        }



        /// <summary>
        /// GetLbDrums Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original LbDrums or EMPTY</returns>
        public int GetLbDrumsOriginal(int resinId)
        {
            return (int)GetRow(resinId)["LbDrums", DataRowVersion.Original];
        }



        /// <summary>
        /// GetActiveResin
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ActiveResin or EMPTY</returns>
        public decimal GetActiveResin(int resinId)
        {
            return (decimal)GetRow(resinId)["ActiveResin"];
        }



        /// <summary>
        /// GetActiveResin Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original ActiveResin or EMPTY</returns>
        public decimal GetActiveResinOriginal(int resinId)
        {
            return (decimal)GetRow(resinId)["ActiveResin", DataRowVersion.Original];
        }



        /// <summary>
        /// GetApplyCatalystTo
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>ApplyCatalystTo or EMPTY</returns>
        public string GetApplyCatalystTo(int resinId)
        {
            if (GetRow(resinId).IsNull("ApplyCatalystTo"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ApplyCatalystTo"];
            }
        }



        /// <summary>
        /// GetApplyCatalystTo Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original ResinNumber or EMPTY</returns>
        public string GetApplyCatalystToOriginal(int resinId)
        {
            if (GetRow(resinId).IsNull(Table.Columns["ApplyCatalystTo"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(resinId)["ApplyCatalystTo", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFilter
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Filter or EMPTY</returns>
        public decimal GetFilter(int resinId)
        {
            return (decimal)GetRow(resinId)["Filter"];
        }



        /// <summary>
        /// GetFilter Original
        /// </summary>
        /// <param name="resinId">resinId</param>
        /// <returns>Original Filter or EMPTY</returns>
        public decimal GetFilterOriginal(int resinId)
        {
            return (decimal)GetRow(resinId)["Filter", DataRowVersion.Original];
        }




    }
}
