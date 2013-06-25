using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Services
{
    /// <summary>
    /// ServiceRequestsManagerToolCostInformationGateway
    /// </summary>
    public class ServiceRequestsManagerToolCostInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRequestsManagerToolCostInformationGateway()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceRequestsManagerToolCostInformationGateway(DataSet data)
            : base(data, "CostInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ServiceRequestsManagerToolTDS();
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
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByServiceId
        /// </summary>       
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByServiceId(int serviceId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_SERVICEREQUESTSMANAGERTOOLCOSTINFORMATIONGATEWAY_LOADBYSERVICEID", new SqlParameter("@serviceId", serviceId), new SqlParameter("@companyId", companyId));
            return Data;
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






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS 
        //


        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        private DataRow GetRow(int serviceId, int refId)
        {
            string filter = string.Format("ServiceID = {0} AND RefID = {1}", serviceId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Services.ServiceRequestsManagerToolCostInformationGateway.GetRow");
            }
        }


    }
}
