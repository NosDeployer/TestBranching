using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceRequestsManagerToolCostInformation
    /// </summary>
    public class ServiceRequestsManagerToolCostInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceRequestsManagerToolCostInformation()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceRequestsManagerToolCostInformation(DataSet data)
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






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByServiceId
        /// </summary>       
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByServiceId(int serviceId, int companyId)
        {
            ServiceRequestsManagerToolCostInformationGateway serviceRequestsManagerToolCostInformationGateway = new ServiceRequestsManagerToolCostInformationGateway(Data);
            serviceRequestsManagerToolCostInformationGateway.LoadByServiceId(serviceId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="partNumber">partNumber</param>
        /// <param name="partName">partName</param>
        /// <param name="vendor">vendor</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int serviceId, string partNumber, string partName, string vendor, decimal cost, bool deleted, int companyId)
        {
            ServiceRequestsManagerToolTDS.CostInformationRow row = ((ServiceRequestsManagerToolTDS.CostInformationDataTable)Table).NewCostInformationRow();

            row.ServiceID = serviceId;
            row.RefID = GetNewRefId();
            if (partNumber != "") row.PartNumber = partNumber; else row.SetPartNumberNull();
            row.PartName = partName;
            if (vendor != "") row.Vendor = vendor; else row.SetVendorNull();
            row.Cost = cost;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            
            ((ServiceRequestsManagerToolTDS.CostInformationDataTable)Table).AddCostInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="partNumber">partNumber</param>
        /// <param name="partName">partName</param>
        /// <param name="vendor">vendor</param>
        /// <param name="cost">cost</param>
        public void Update(int serviceId, int refId, string partNumber, string partName, string vendor, decimal cost)
        {
            ServiceRequestsManagerToolTDS.CostInformationRow row = GetRow(serviceId, refId);

            if (partNumber != "") row.PartNumber = partNumber; else row.SetPartNumberNull();
            row.PartName = partName;
            if (vendor != "") row.Vendor = vendor; else row.SetVendorNull();
            row.Cost = cost;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        public void Delete(int serviceId, int refId)
        {
            ServiceRequestsManagerToolTDS.CostInformationRow row = GetRow(serviceId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        public void DeleteAll(int serviceId)
        {
            foreach (ServiceRequestsManagerToolTDS.CostInformationRow row in (ServiceRequestsManagerToolTDS.CostInformationDataTable)Table)
            {
                row.Deleted = true;
            }
        }



        /// <summary>
        /// GetTotalCost
        /// </summary>
        /// <param name="serviceId">serviceId</param>              
        /// <param name="companyId">companyId</param>
        public decimal GetTotalCost(int serviceId, int companyId)
        {
            decimal totalCost = 0.00M;

            foreach (ServiceRequestsManagerToolTDS.CostInformationRow row in (ServiceRequestsManagerToolTDS.CostInformationDataTable)Table)
            {
                if (!row.Deleted)
                {
                    totalCost = totalCost + row.Cost;
                }
            }

            return totalCost;
        }


        
        /// <summary>
        /// Save all costs to database (direct)
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int serviceId, int companyId)
        {
            ServiceRequestsManagerToolTDS serviceRequestsManagerToolTDS = (ServiceRequestsManagerToolTDS)Data.GetChanges();

            if (serviceRequestsManagerToolTDS.CostInformation.Rows.Count > 0)
            {
                ServiceRequestsManagerToolCostInformationGateway serviceRequestsManagerToolCostInformationGateway = new ServiceRequestsManagerToolCostInformationGateway(serviceRequestsManagerToolTDS);

                foreach (ServiceRequestsManagerToolTDS.CostInformationRow row in (ServiceRequestsManagerToolTDS.CostInformationDataTable)serviceRequestsManagerToolTDS.CostInformation)
                {
                    // Insert new costs 
                    if (!row.Deleted)
                    {
                        // new values
                        int refId = row.RefID;
                        int tempServiceId = row.ServiceID;

                        string newPartNumber = serviceRequestsManagerToolCostInformationGateway.GetPartNumber(tempServiceId, refId);
                        string newPartName = serviceRequestsManagerToolCostInformationGateway.GetPartName(tempServiceId, refId);
                        string newVendor = serviceRequestsManagerToolCostInformationGateway.GetVendor(tempServiceId, refId);
                        decimal newCost = serviceRequestsManagerToolCostInformationGateway.GetCost(tempServiceId, refId);

                        ServicesCost servicesCost = new ServicesCost(null);
                        servicesCost.InsertDirect(serviceId, refId, newPartNumber, newPartName, newVendor, newCost, row.Deleted, row.COMPANY_ID, null);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private ServiceRequestsManagerToolTDS.CostInformationRow GetRow(int serviceId, int refId)
        {
            ServiceRequestsManagerToolTDS.CostInformationRow row = ((ServiceRequestsManagerToolTDS.CostInformationDataTable)Table).FindByServiceIDRefID(serviceId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceRequestsManagerToolCostInformation.GetRow");
            }

            return row;
        }


             
        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>RefID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ServiceRequestsManagerToolTDS.CostInformationRow row in (ServiceRequestsManagerToolTDS.CostInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



    }
}