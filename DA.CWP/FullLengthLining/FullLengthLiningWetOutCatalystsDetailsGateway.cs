using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningWetOutCatalystsDetailsGateway
    /// </summary>
    public class FullLengthLiningWetOutCatalystsDetailsGateway  : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningWetOutCatalystsDetailsGateway()
            : base("WetOutCatalystsDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningWetOutCatalystsDetailsGateway(DataSet data)
            : base(data, "WetOutCatalystsDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
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
            tableMapping.DataSetTable = "FlCatalystsAdd";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");            
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("CatalystID", "CatalystID");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("PercentageByWeight", "PercentageByWeight");
            tableMapping.ColumnMappings.Add("LbsForMixQuantity", "LbsForMixQuantity");
            tableMapping.ColumnMappings.Add("LbsForDrum", "LbsForDrum");
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
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>data set</returns>
        public DataSet LoadAllByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGWETOUTCATALYSTSDETAILSGATEWAY_LOADALLBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>data set</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGWETOUTCATALYSTSDETAILSGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId, int refId)
        {
            string filter = string.Format("WorkID = {0} AND RefID = {1}", workId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLenthLining.FullLengthLiningWetOutCatalystsDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetName
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Name or EMPTY</returns>
        public string GetName(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("Name"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Name"];
            }
        }



        /// <summary>
        /// GetName Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Name or EMPTY</returns>
        public string GetNameOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["Name"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["Name", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCatalystID
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>CatalystID or EMPTY</returns>
        public int GetCatalystID(int workId, int refId)
        {
            return (int)GetRow(workId, refId)["CatalystID"];            
        }



        /// <summary>
        /// GetCatalystID Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original CatalystID or EMPTY</returns>
        public int GetCatalystIDOriginal(int workId, int refId)
        {            
            return (int)GetRow(workId, refId)["CatalystID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPercentageByWeight
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>PercentageByWeight or EMPTY</returns>
        public decimal GetPercentageByWeight(int workId, int refId)
        {
            return (decimal)GetRow(workId, refId)["PercentageByWeight"];
        }



        /// <summary>
        /// GetPercentageByWeight Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PercentageByWeight or EMPTY</returns>
        public decimal GetPercentageByWeightOriginal(int workId, int refId)
        {
            return (decimal)GetRow(workId, refId)["PercentageByWeight", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLbsForMixQuantity
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>LbsForMixQuantity or EMPTY</returns>
        public decimal GetLbsForMixQuantity(int workId, int refId)
        {
            return (decimal)GetRow(workId, refId)["LbsForMixQuantity"];
        }



        /// <summary>
        /// GetLbsForMixQuantity Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LbsForMixQuantity or EMPTY</returns>
        public decimal GetLbsForMixQuantityOriginal(int workId, int refId)
        {
            return (decimal)GetRow(workId, refId)["LbsForMixQuantity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLbsForDrum
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>LbsForDrum or EMPTY</returns>
        public string GetLbsForDrum(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull("LbsForDrum"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["LbsForDrum"];
            }
        }



        /// <summary>
        /// GetLbsForDrum Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LbsForDrum or EMPTY</returns>
        public string GetLbsForDrumOriginal(int workId, int refId)
        {
            if (GetRow(workId, refId).IsNull(Table.Columns["LbsForDrum"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, refId)["LbsForDrum", DataRowVersion.Original];
            }
        }



    }
}
