using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Services.Services;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    public class ProjectService : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectService() : base("LFS_PROJECT_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectService(DataSet data) : base(data, "LFS_PROJECT_SERVICE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
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
            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(Data);
            projectServiceGateway.LoadAllByProjectId(projectId);

            foreach (ProjectTDS.LFS_PROJECT_SERVICERow lfsProjectServiceRow in (ProjectTDS.LFS_PROJECT_SERVICEDataTable)Table)
            {
                if (lfsProjectServiceRow.IsNull("AveragePrice"))
                {
                    lfsProjectServiceRow.Total = 0;
                }
                else
                {
                    lfsProjectServiceRow.Total = lfsProjectServiceRow.AveragePrice * lfsProjectServiceRow.Quantity;
                }
            }

            Table.AcceptChanges();
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="serviceId">serviceId</param>
        /// <param name="description">description</param>
        /// <param name="averageSize">averageSize</param>
        /// <param name="averagePrice">averagePrice</param>
        /// <param name="quantity">quantity</param>
        /// <param name="deleted">deleted</param>
        /// <param name="total">total</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int projectId, int refId, int? serviceId, string description, string averageSize, decimal? averagePrice, int quantity, bool deleted, decimal total, int companyId)
        {
            ProjectTDS.LFS_PROJECT_SERVICERow lfsProjectServiceRow = ((ProjectTDS.LFS_PROJECT_SERVICEDataTable)Table).NewLFS_PROJECT_SERVICERow();

            lfsProjectServiceRow.ProjectID = projectId;
            lfsProjectServiceRow.RefID = refId;
            if (serviceId.HasValue) lfsProjectServiceRow.ServiceID = (int)serviceId;
            if (description.Trim() != "") lfsProjectServiceRow.Description = description;
            if (averageSize.Trim() != "") lfsProjectServiceRow.AverageSize = averageSize;
            if (averagePrice.HasValue) lfsProjectServiceRow.AveragePrice = (decimal)averagePrice;
            lfsProjectServiceRow.Quantity = quantity;
            lfsProjectServiceRow.Deleted = deleted;
            lfsProjectServiceRow.Total = total;
            lfsProjectServiceRow.COMPANY_ID = companyId;

            ((ProjectTDS.LFS_PROJECT_SERVICEDataTable)Table).AddLFS_PROJECT_SERVICERow(lfsProjectServiceRow);
        }



        /// <summary>
        /// Insert a new note (direct to DB)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="serviceId">serviceId</param>
        /// <param name="description">description</param>
        /// <param name="averageSize">averageSize</param>
        /// <param name="averagePrice">averagePrice</param>
        /// <param name="quantity">quantity</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void InsertDirect(int projectId, int refId, int? serviceId, string description, string averageSize, decimal? averagePrice, int quantity, bool deleted, int companyId)
        {
            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(null);
            projectServiceGateway.Insert(projectId, refId, serviceId, description, averageSize, averagePrice, quantity, deleted, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="serviceId">serviceId</param>
        /// <param name="description">description</param>
        /// <param name="averageSize">averageSize</param>
        /// <param name="averagePrice">averagePrice</param>
        /// <param name="quantity">quantity</param>
        /// <param name="deleted">deleted</param>
        /// <param name="total">total</param>
        /// <param name="companyId">companyId</param>
        public void Update(int projectId, int refId, int? serviceId, string description, string averageSize, decimal? averagePrice, int quantity, bool deleted, decimal total, int companyId)
        {
            ProjectTDS.LFS_PROJECT_SERVICERow lfsProjectServiceRow = GetRow(projectId, refId);

            if (serviceId.HasValue) lfsProjectServiceRow.ServiceID = (int)serviceId; else lfsProjectServiceRow.SetServiceIDNull();
            if (description.Trim() != "") lfsProjectServiceRow.Description = description; else lfsProjectServiceRow.SetDescriptionNull();
            if (averageSize.Trim() != "") lfsProjectServiceRow.AverageSize = averageSize; else lfsProjectServiceRow.SetAverageSizeNull();
            if (averagePrice.HasValue) lfsProjectServiceRow.AveragePrice = (decimal)averagePrice; else lfsProjectServiceRow.SetAveragePriceNull();
            lfsProjectServiceRow.Quantity = quantity;
            lfsProjectServiceRow.Deleted = deleted;
            lfsProjectServiceRow.Total = total;
            lfsProjectServiceRow.COMPANY_ID = companyId;
        }



        /// <summary>
        /// Update cost (direct to DB)
        /// </summary>
        /// <param name="originalProjectId">originalProjectId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalServiceId">originalServiceId</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalAverageSize">originalAverageSize</param>
        /// <param name="originalAveragePrice">originalAveragePrice</param>
        /// <param name="originalQuantity">originalQuantity</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>  
        /// 
        /// <param name="newProjectId">newProjectId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newServiceId">newServiceId</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newAverageSize">newAverageSize</param>
        /// <param name="newAveragePrice">newAveragePrice</param>
        /// <param name="newQuantity">newQuantity</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>  
        public void UpdateDirect(int originalProjectId, int originalRefId, int? originalServiceId, string originalDescription, string originalAverageSize, decimal? originalAveragePrice, int originalQuantity, bool originalDeleted, int originalCompanyId, int newProjectId, int newRefId, int? newServiceId, string newDescription, string newAverageSize, decimal? newAveragePrice, int newQuantity, bool newDeleted, int newCompanyId)
        {
            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(null);
            projectServiceGateway.Update(originalProjectId, originalRefId, originalServiceId, originalDescription, originalAverageSize, originalAveragePrice, originalQuantity, originalDeleted, originalCompanyId, newProjectId, newRefId, newServiceId, newDescription, newAverageSize, newAveragePrice, newQuantity, newDeleted, newCompanyId);
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        public void Delete(int projectId, int refId)
        {
            ProjectTDS.LFS_PROJECT_SERVICERow lfsProjectServiceRow = GetRow(projectId, refId);
            lfsProjectServiceRow.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int projectId, int refId, int companyId)
        {
            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(null);
            projectServiceGateway.Delete(projectId, refId, companyId);
        }
       


        /// <summary>
        /// GetNewRefID
        /// </summary>
        /// <returns></returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (ProjectTDS.LFS_PROJECT_SERVICERow row in (ProjectTDS.LFS_PROJECT_SERVICEDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ProjectTDS.LFS_PROJECT_SERVICERow</returns>
        private ProjectTDS.LFS_PROJECT_SERVICERow GetRow(int projectId, int refId)
        {
            ProjectTDS.LFS_PROJECT_SERVICERow row = ((ProjectTDS.LFS_PROJECT_SERVICEDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectService.GetRow");
            }

            return row;

        }



    }
}
