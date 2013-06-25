using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// AddRecordPointRepairsGateway
    /// </summary>
    public class AddRecordPointRepairsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public AddRecordPointRepairsGateway()
            : base("PointRepairs")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public AddRecordPointRepairsGateway(DataSet data)
            : base(data, "PointRepairs")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new AddRecordTDS();
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
            tableMapping.DataSetTable = "PointRepairs";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("RepairSize", "RepairSize");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("Distance", "Distance");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Reinstates", "Reinstates");
            tableMapping.ColumnMappings.Add("LTAtMH", "LTAtMH");
            tableMapping.ColumnMappings.Add("VTAtMH", "VTAtMH");
            tableMapping.ColumnMappings.Add("LinerDistance", "LinerDistance");
            tableMapping.ColumnMappings.Add("Direction", "Direction");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("ExtraRepair", "ExtraRepair");
            tableMapping.ColumnMappings.Add("Cancelled", "Cancelled");
            tableMapping.ColumnMappings.Add("Approved", "Approved");
            tableMapping.ColumnMappings.Add("NotApproved", "NotApproved");
            tableMapping.ColumnMappings.Add("Archived", "Archived");
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
        /// LoadById
        /// </summary>        
        /// <param name="id">id</param>           
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadById(Guid id, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLM1LATERALREPORTGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
            return Data;
        }  



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(Guid id, int refId, int companyId)
        {
            string filter = string.Format("(ID = '{0}') AND (RefID = {1}) AND (COMPANY_ID = {2})", id, refId, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.DatabaseGateway.AddRecordPointRepairsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDetailID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DetailID o EMPTY</returns>
        public string GetDetailID(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("DetailID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DetailID"];
            }
        }



        /// <summary>
        /// GetDetailID Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original DetailID or EMPTY</returns>
        public string GetDetailIDOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["DetailID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DetailID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRepairSize. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>RepairSize o EMPTY</returns>
        public string GetRepairSize(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("RepairSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["RepairSize"];
            }
        }



        /// <summary>
        /// GetRepairSize Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original RepairSize or EMPTY</returns>
        public string GetRepairSizeOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["RepairSize"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["RepairSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInstallDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>InstallDate o EMPTY</returns>
        public DateTime? GetInstallDate(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("InstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["InstallDate"];
            }
        }



        /// <summary>
        /// GetInstallDate Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original InstallDate or EMPTY</returns>
        public DateTime? GetInstallDateOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["InstallDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["InstallDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistance. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Distance o EMPTY</returns>
        public string GetDistance(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Distance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Distance"];
            }
        }



        /// <summary>
        /// GetDistance Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Distance or EMPTY</returns>
        public string GetDistanceOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Distance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Distance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCost. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Cost o EMPTY</returns>
        public decimal? GetCost(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Cost"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, refId, companyId)["Cost"];
            }
        }



        /// <summary>
        /// GetCost Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Cost or EMPTY</returns>
        public decimal? GetCostOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Cost"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, refId, companyId)["Cost", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetReinstates. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Reinstates o EMPTY</returns>
        public int? GetReinstates(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Reinstates"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, refId, companyId)["Reinstates"];
            }
        }



        /// <summary>
        /// GetReinstates Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Reinstates or EMPTY</returns>
        public int? GetReinstatesOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Reinstates"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, refId, companyId)["Reinstates", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLTAtMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LTAtMH o EMPTY</returns>
        public string GetLTAtMH(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LTAtMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LTAtMH"];
            }
        }



        /// <summary>
        /// GetLTAtMH Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LTAtMH or EMPTY</returns>
        public string GetLTAtMHOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LTAtMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LTAtMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVTAtMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>VTAtMH o EMPTY</returns>
        public string GetVTAtMH(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("VTAtMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["VTAtMH"];
            }
        }



        /// <summary>
        /// GetVTAtMH Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original VTAtMH or EMPTY</returns>
        public string GetVTAtMHOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["VTAtMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["VTAtMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerDistance. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LinerDistance o EMPTY</returns>
        public string GetLinerDistance(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LinerDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LinerDistance"];
            }
        }



        /// <summary>
        /// GetLinerDistance Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerDistance or EMPTY</returns>
        public string GetLinerDistanceOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LinerDistance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LinerDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDirection. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Direction o EMPTY</returns>
        public string GetDirection(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Direction"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Direction"];
            }
        }



        /// <summary>
        /// GetDirection Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Direction or EMPTY</returns>
        public string GetDirectionOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Direction"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Direction", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMHShot. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>MHShot o EMPTY</returns>
        public string GetMHShot(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("MHShot"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MHShot"];
            }
        }



        /// <summary>
        /// GetMHShot Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original MHShot or EMPTY</returns>
        public string GetMHShotOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["MHShot"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MHShot", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Comments o EMPTY</returns>
        public string GetComments(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetExtraRepair. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>ExtraRepair o EMPTY</returns>
        public bool GetExtraRepair(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["ExtraRepair"];            
        }



        /// <summary>
        /// GetExtraRepair Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original ExtraRepair or EMPTY</returns>
        public bool GetExtraRepairOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["ExtraRepair", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCancelled. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Cancelled o EMPTY</returns>
        public bool GetCancelled(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Cancelled"];
        }



        /// <summary>
        /// GetCancelled Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Cancelled or EMPTY</returns>
        public bool GetCancelledOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Cancelled", DataRowVersion.Original];
        }



        /// <summary>
        /// GetApproved. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Approved o EMPTY</returns>
        public bool GetApproved(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Approved"];
        }



        /// <summary>
        /// GetApproved Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Approved or EMPTY</returns>
        public bool GetApprovedOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Approved", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNotApproved. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>NotApproved o EMPTY</returns>
        public bool GetNotApproved(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["NotApproved"];
        }



        /// <summary>
        /// GetNotApproved Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original NotApproved or EMPTY</returns>
        public bool GetNotApprovedOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["NotApproved", DataRowVersion.Original];
        }



        /// <summary>
        /// GetArchived. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>NotApproved o EMPTY</returns>
        public bool GetArchived(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Archived"];
        }



        /// <summary>
        /// GetArchived Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Archived or EMPTY</returns>
        public bool GetArchivedOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Archived", DataRowVersion.Original];
        }

        


        
        
    }
}
