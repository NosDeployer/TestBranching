using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServiceInformationServiceCost
    /// </summary>
    public class ServiceInformationServiceCostGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInformationServiceCostGateway()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceInformationServiceCostGateway(DataSet data)
            : base(data, "CostInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceInformationTDS();
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
            tableMapping.DataSetTable = "CostInformation";
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("PartNumber", "PartNumber");
            tableMapping.ColumnMappings.Add("PartName", "PartName");
            tableMapping.ColumnMappings.Add("Vendor", "Vendor");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InServiceCostDatabase", "InServiceCostDatabase");
            tableMapping.ColumnMappings.Add("NoteID", "NoteID");
            tableMapping.ColumnMappings.Add("LIBRARY_FILES_ID", "LIBRARY_FILES_ID");
            tableMapping.ColumnMappings.Add("ORIGINAL_FILENAME", "ORIGINAL_FILENAME");
            tableMapping.ColumnMappings.Add("FILENAME", "FILENAME");
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
        /// LoadAllByServiceId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByServiceId(int serviceId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEINFORMATIONSERVICECOSTGATEWAY_LOADALLBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int serviceId, int refId)
        {
            string filter = string.Format("ServiceID = {0} AND RefID = {1}", serviceId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Services.ServiceInformationServiceCostGateway.GetRow");
            }
        }



        /// <summary>
        /// GetPartNumber
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>PartNumber or EMPTY</returns>
        public string GetPartNumber(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("PartNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["PartNumber"];
            }
        }



        /// <summary>
        /// GetPartNumber Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PartNumber or EMPTY</returns>
        public string GetPartNumberOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["PartNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["PartNumber", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPartName
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>PartName or EMPTY</returns>
        public string GetPartName(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("PartName"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["PartName"];
            }
        }



        /// <summary>
        /// GetPartName Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original PartName or EMPTY</returns>
        public string GetPartNameOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["PartName"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["PartName", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVendor
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Vendor or EMPTY</returns>
        public string GetVendor(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("Vendor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["Vendor"];
            }
        }



        /// <summary>
        /// GetVendor Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Vendor or EMPTY</returns>
        public string GetVendorOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["Vendor"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(serviceId, refId)["Vendor", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCost
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Cost or EMPTY</returns>
        public decimal GetCost(int serviceId, int refId)
        {
            return (decimal)GetRow(serviceId, refId)["Cost"];
        }



        /// <summary>
        /// GetCost Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Cost or EMPTY</returns>
        public decimal GetCostOriginal(int serviceId, int refId)
        {
            return (decimal)GetRow(serviceId, refId)["Cost", DataRowVersion.Original];
        }



        /// <summary>
        /// GetNoteID
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>NoteID or null</returns>
        public int? GetNoteID(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("NoteID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId, refId)["NoteID"];
            }
        }



        /// <summary>
        /// GetNoteID Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original NoteID or null</returns>
        public int? GetNoteIDOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["NoteID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId, refId)["NoteID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLibraryFilesId
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLibraryFilesId(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull("LIBRARY_FILES_ID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId, refId)["LIBRARY_FILES_ID"];
            }
        }



        /// <summary>
        /// GetLibraryFilesId Original
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original LIBRARY_FILES_ID or EMPTY</returns>
        public int? GetLibraryFilesIdOriginal(int serviceId, int refId)
        {
            if (GetRow(serviceId, refId).IsNull(Table.Columns["LIBRARY_FILES_ID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(serviceId, refId)["LIBRARY_FILES_ID", DataRowVersion.Original];
            }
        }



    }
}