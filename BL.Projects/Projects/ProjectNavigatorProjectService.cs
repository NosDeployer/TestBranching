using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectService
    /// </summary>
    public class ProjectNavigatorProjectService : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectService()
            : base("ProjectService")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectService(DataSet data)
            : base(data, "ProjectService")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>              
        public void LoadAllByProjectId(int projectId)
        {
            ProjectNavigatorProjectServiceGateway projectNavigatorProjectServiceGateway = new ProjectNavigatorProjectServiceGateway(Data);
            projectNavigatorProjectServiceGateway.LoadAllByProjectId(projectId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="serviceId">serviceId</param>
        /// <param name="description">description</param>
        /// <param name="averageSize">averageSize</param>
        /// <param name="averagePrice">averagePrice</param>
        /// <param name="quantity">quantity</param>
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="total">total</param>
        public void Insert(int projectId, int? serviceId, string description, string averageSize, decimal? averagePrice, int quantity, bool deleted, int companyId, bool inDatabase, decimal total)
        {
            ProjectNavigatorTDS.ProjectServiceRow row = ((ProjectNavigatorTDS.ProjectServiceDataTable)Table).NewProjectServiceRow();
            row.ProjectID = projectId;
            row.RefID = GetNewRefId();
            if (serviceId.HasValue) row.ServiceID = (int)serviceId; else row.SetServiceIDNull();
            if (description != "") row.Description = description; else row.SetDescriptionNull();
            if (averageSize != "") row.AverageSize = averageSize; else row.SetAverageSizeNull();
            if (averagePrice.HasValue) row.AveragePrice = (decimal)averagePrice; else row.SetAveragePriceNull();
            row.Quantity = quantity;            
            row.Deleted = deleted;            
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Total = total;

            ((ProjectNavigatorTDS.ProjectServiceDataTable)Table).AddProjectServiceRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <param name="serviceId">serviceId</param>
        /// <param name="description">description</param>        
        /// <param name="averageSize">averageSize</param>        
        /// <param name="averagePrice">averagePrice</param>        
        /// <param name="quantity">quantity</param>
        /// <param name="total">total</param>
        public void Update(int projectId, int refId, int? serviceId, string description, string averageSize, decimal? averagePrice, int quantity, decimal total)
        {
            ProjectNavigatorTDS.ProjectServiceRow row = GetRow(projectId, refId);

            if (serviceId.HasValue) row.ServiceID = (int)serviceId; else row.SetServiceIDNull();
            if (description != "") row.Description = description; else row.SetDescriptionNull();
            if (averageSize != "") row.AverageSize = averageSize; else row.SetAverageSizeNull();
            if (averagePrice.HasValue) row.AveragePrice = (decimal)averagePrice; else row.SetAveragePriceNull();
            row.Quantity = quantity;
            row.Total = total;
        }



        /// <summary>
        /// UpdateForSave
        /// </summary>
        public void UpdateForSave()
        {
            foreach (ProjectNavigatorTDS.ProjectServiceRow row in (ProjectNavigatorTDS.ProjectServiceDataTable)Table)
            {                               
                // Fix null serviceId
                if (!row.IsServiceIDNull())
                {
                    if (row.ServiceID == -1)
                    {
                        row.SetServiceIDNull();
                    }
                }                

                // Fixed null averageprice
                if (!row.IsAveragePriceNull())
                {
                    if (row.AveragePrice == 0.00M)
                    {                        
                        row.SetAveragePriceNull();
                    }
                }                             
            }
        }



        /// <summary>
        /// UpdateForLoad
        /// </summary>
        public void UpdateForLoad()
        {
            foreach (ProjectNavigatorTDS.ProjectServiceRow row in (ProjectNavigatorTDS.ProjectServiceDataTable)Table)
            {             
                // Fix null serviceId
                if (row.IsServiceIDNull())
                {
                    row.ServiceID = -1;                   
                }

                // Fixed null averageprice
                if (row.IsAveragePriceNull())
                {
                    row.AveragePrice = 0.00M;                 
                }

                // Calc Total
                row.Total = decimal.Round((row.AveragePrice * row.Quantity), 2);
            }
        }



        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            ProjectNavigatorTDS.ProjectServiceRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// GetTotalCost
        /// </summary>
        public decimal GetTotalCost()
        {
            decimal total = 0.00M;

            foreach (ProjectNavigatorTDS.ProjectServiceRow row in (ProjectNavigatorTDS.ProjectServiceDataTable)Table)
            {
                if (!row.Deleted)
                {
                    total = total + decimal.Parse(row.Total.ToString());
                }
            }

            return total;
        }

      
        
        /// <summary>
        /// Save all Service to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            ProjectNavigatorTDS serviceChanges = (ProjectNavigatorTDS)Data.GetChanges();

            if (serviceChanges != null)
            {
                if (serviceChanges.ProjectService.Rows.Count > 0)
                {
                    ProjectNavigatorProjectServiceGateway projectNavigatorProjectServiceGateway = new ProjectNavigatorProjectServiceGateway(serviceChanges);

                    foreach (ProjectNavigatorTDS.ProjectServiceRow row in (ProjectNavigatorTDS.ProjectServiceDataTable)serviceChanges.ProjectService)
                    {
                        // Insert new Service 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            int? serviceId = null; if (!row.IsServiceIDNull()) serviceId = row.ServiceID;
                            string description = ""; if (!row.IsDescriptionNull()) description = row.Description;
                            string averageSize = ""; if (!row.IsAverageSizeNull()) averageSize = row.AverageSize;
                            decimal? averagePrice = null; if (!row.IsAveragePriceNull()) averagePrice = row.AveragePrice;                            

                            ProjectService projectService = new ProjectService(null);
                            projectService.InsertDirect(row.ProjectID, row.RefID, serviceId, description, averageSize, averagePrice, row.Quantity, row.Deleted, row.COMPANY_ID);
                        }

                        // Update Service
                        if ((!row.Deleted) && (row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            bool originalDeleted = false;
                            int originalCompanyId = companyId;

                            // original values
                            int? originalServiceId = projectNavigatorProjectServiceGateway.GetServiceIDOriginal(projectId, refId);
                            string originalDescription = projectNavigatorProjectServiceGateway.GetDescriptionOriginal(projectId, refId);
                            string originalAverageSize = projectNavigatorProjectServiceGateway.GetAverageSizeOriginal(projectId, refId);
                            decimal? originalAveragePrice = projectNavigatorProjectServiceGateway.GetAveragePriceOriginal(projectId, refId);
                            int originalQuantity = projectNavigatorProjectServiceGateway.GetQuantityOriginal(projectId, refId);

                            // new values
                            int? newServiceId = projectNavigatorProjectServiceGateway.GetServiceID(projectId, refId);
                            string newDescription = projectNavigatorProjectServiceGateway.GetDescription(projectId, refId);
                            string newAverageSize = projectNavigatorProjectServiceGateway.GetAverageSize(projectId, refId);
                            decimal? newAveragePrice = projectNavigatorProjectServiceGateway.GetAveragePrice(projectId, refId);
                            int newQuantity = projectNavigatorProjectServiceGateway.GetQuantity(projectId, refId);

                            ProjectService projectService = new ProjectService(null);
                            projectService.UpdateDirect(projectId, refId,  originalServiceId, originalDescription, originalAverageSize, originalAveragePrice, originalQuantity, originalDeleted, originalCompanyId, projectId, refId, newServiceId, newDescription, newAverageSize, newAveragePrice, newQuantity, originalDeleted, originalCompanyId);
                        }

                        // Deleted Service 
                        if ((row.Deleted) && (row.InDatabase))
                        {
                            ProjectService projectService = new ProjectService(null);
                            projectService.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }
      




        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectNavigatorTDS.ProjectServiceRow</returns>
        private ProjectNavigatorTDS.ProjectServiceRow GetRow(int projectId, int refId)
        {
            ProjectNavigatorTDS.ProjectServiceRow row = ((ProjectNavigatorTDS.ProjectServiceDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigatorProjectService.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectNavigatorTDS.ProjectServiceRow row in (ProjectNavigatorTDS.ProjectServiceDataTable)Table)
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
