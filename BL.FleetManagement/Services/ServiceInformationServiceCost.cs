using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Services;

namespace LiquiForce.LFSLive.BL.FleetManagement.Services
{
    /// <summary>
    /// ServiceInformationServiceCost
    /// </summary>
    public class ServiceInformationServiceCost : TableModule
    {
       // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ServiceInformationServiceCost()
            : base("CostInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ServiceInformationServiceCost(DataSet data)
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
            ServiceInformationServiceCostGateway serviceInformationServiceCostGateway = new ServiceInformationServiceCostGateway(Data);
            serviceInformationServiceCostGateway.LoadAllByServiceId(serviceId, companyId);
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
        /// <param name="inServiceCostDatabase">inServiceCostDatabase</param>
        /// <param name="noteId">noteId</param>
        public void Insert(int serviceId, string partNumber, string partName, string vendor, decimal cost, bool deleted, int companyId, bool inServiceCostDatabase, int? noteId)
        {
            ServiceInformationTDS.CostInformationRow row = ((ServiceInformationTDS.CostInformationDataTable)Table).NewCostInformationRow();

            row.ServiceID = serviceId;
            row.RefID = GetNewRefId();
            if (partNumber != "") row.PartNumber = partNumber; else row.SetPartNumberNull();
            row.PartName = partName;
            if (vendor != "") row.Vendor = vendor; else row.SetVendorNull();
            row.Cost = cost;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InServiceCostDatabase = inServiceCostDatabase;
            if (noteId.HasValue) row.NoteID = noteId.Value; else row.SetNoteIDNull();

            ((ServiceInformationTDS.CostInformationDataTable)Table).AddCostInformationRow(row);
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
        /// <param name="noteId">noteId</param>
        public void Update(int serviceId, int refId, string partNumber, string partName, string vendor, decimal cost, int? noteId)
        {
            ServiceInformationTDS.CostInformationRow row = GetRow(serviceId, refId);

            if (partNumber != "") row.PartNumber = partNumber; else row.SetPartNumberNull();
            row.PartName = partName;
            if (vendor != "") row.Vendor = vendor; else row.SetVendorNull();
            row.Cost = cost;
            if (noteId.HasValue) row.NoteID = noteId.Value; else row.SetNoteIDNull();
        }



        /// <summary>
        /// UpdateNoteId. Update the note Id
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="noteId">noteId</param>
        public void UpdateNoteId(int serviceId, int refId, int noteId)
        {
            ServiceInformationTDS.CostInformationRow row = GetRow(serviceId, refId);

            row.NoteID = noteId;
        }



        /// <summary>
        /// UpdateLibraryFilesId. Update the Library Files Id
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        /// <param name="originalFileName">originalFileName</param>
        /// <param name="fileName">filename</param>
        public void UpdateLibraryFilesId(int serviceId, int refId, string originalFileName, string fileName)
        {
            ServiceInformationTDS.CostInformationRow row = GetRow(serviceId, refId);

            row.ORIGINAL_FILENAME = originalFileName;
            row.FILENAME = fileName;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        /// <param name="refId">refId</param>
        public void Delete(int serviceId, int refId)
        {
            ServiceInformationTDS.CostInformationRow row = GetRow(serviceId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="serviceId">serviceId</param>
        public void DeleteAll(int serviceId)
        {
            foreach (ServiceInformationTDS.CostInformationRow row in (ServiceInformationTDS.CostInformationDataTable)Table)
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

            foreach (ServiceInformationTDS.CostInformationRow row in (ServiceInformationTDS.CostInformationDataTable)Table)
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
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ServiceInformationTDS serviceInformationChanges = (ServiceInformationTDS)Data.GetChanges();

            if (serviceInformationChanges.CostInformation.Rows.Count > 0)
            {
                ServiceInformationServiceCostGateway serviceInformationServiceCostGateway = new ServiceInformationServiceCostGateway(serviceInformationChanges);
                
                foreach (ServiceInformationTDS.CostInformationRow row in (ServiceInformationTDS.CostInformationDataTable)serviceInformationChanges.CostInformation)
                {
                    // Insert new costs 
                    if ((!row.Deleted) && (!row.InServiceCostDatabase))
                    {
                        // new values
                        int serviceId = row.ServiceID;
                        int refId = row.RefID;

                        string newPartNumber = serviceInformationServiceCostGateway.GetPartNumber(serviceId, refId);
                        string newPartName = serviceInformationServiceCostGateway.GetPartName(serviceId, refId);
                        string newVendor = serviceInformationServiceCostGateway.GetVendor(serviceId, refId);
                        decimal newCost = serviceInformationServiceCostGateway.GetCost(serviceId, refId);
                        int? noteId = serviceInformationServiceCostGateway.GetNoteID(serviceId, refId);

                        ServicesCost servicesCost = new ServicesCost(null);
                        servicesCost.InsertDirect(serviceId, refId, newPartNumber, newPartName, newVendor, newCost, row.Deleted, row.COMPANY_ID, noteId);
                    }
                    
                    // Update costs
                    if ((!row.Deleted) && (row.InServiceCostDatabase))
                    {
                        int serviceId = row.ServiceID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalPartNumber = serviceInformationServiceCostGateway.GetPartNumberOriginal(serviceId, refId);
                        string originalPartName = serviceInformationServiceCostGateway.GetPartNameOriginal(serviceId, refId);
                        string originalVendor = serviceInformationServiceCostGateway.GetVendorOriginal(serviceId, refId);
                        decimal originalCost = serviceInformationServiceCostGateway.GetCostOriginal(serviceId, refId);
                        int? originalNoteId = serviceInformationServiceCostGateway.GetNoteIDOriginal(serviceId, refId);

                        // new values
                        string newPartNumber = serviceInformationServiceCostGateway.GetPartNumber(serviceId, refId);
                        string newPartName = serviceInformationServiceCostGateway.GetPartName(serviceId, refId);
                        string newVendor = serviceInformationServiceCostGateway.GetVendor(serviceId, refId);
                        decimal newCost = serviceInformationServiceCostGateway.GetCost(serviceId, refId);
                        int? newNoteId = serviceInformationServiceCostGateway.GetNoteID(serviceId, refId);
                                       
                        ServicesCost servicesCost = new ServicesCost(null);
                        servicesCost.UpdateDirect(serviceId, refId, originalPartNumber, originalPartName, originalVendor, originalCost, originalDeleted, originalCompanyId, originalNoteId, serviceId, refId, newPartNumber, newPartName, newVendor, newCost, originalDeleted, originalCompanyId, newNoteId);
                    }

                    // Deleted costs
                    if ((row.Deleted)  && (row.InServiceCostDatabase))
                    {
                        ServicesCost servicesCost = new ServicesCost(null);
                        servicesCost.DeleteDirect(row.ServiceID, row.RefID, row.COMPANY_ID);
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
        private ServiceInformationTDS.CostInformationRow GetRow(int serviceId, int refId)
        {
            ServiceInformationTDS.CostInformationRow row = ((ServiceInformationTDS.CostInformationDataTable)Table).FindByServiceIDRefID(serviceId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Services.ServiceInformationServiceCost.GetRow");
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

            foreach (ServiceInformationTDS.CostInformationRow row in (ServiceInformationTDS.CostInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// GetLastRefId
        /// </summary>
        /// <returns>Last ID</returns>
        public int GetLastRefId()
        {
            int newRefId = 1;

            foreach (ServiceInformationTDS.CostInformationRow row in (ServiceInformationTDS.CostInformationDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            return newRefId;
        }



    }
}