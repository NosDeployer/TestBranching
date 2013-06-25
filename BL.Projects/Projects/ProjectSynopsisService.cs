using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Services.Services;


namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSynopsisNote
    /// </summary>
    public class ProjectSynopsisService : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSynopsisService()
            : base("LFS_PROJECT_SERVICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ProjectSynopsisService(DataSet data)
            : base(data, "LFS_PROJECT_SERVICE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSynopsisReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Total Average Price</returns>
        public string UpdateForReport(int projectId, int companyId)
        {
            double totalAveragePrice = 0;
            
            // For LFS_PROJECT_SERVICE
            // ... for Service Name and Total Average Price
            foreach (ProjectSynopsisReportTDS.LFS_PROJECT_SERVICERow row in this.Table.Rows)
            {
                if (row.ProjectID == projectId)
                {
                    try
                    {
                        totalAveragePrice = totalAveragePrice + (Convert.ToDouble(row.AveragePrice) * Convert.ToDouble(row.Quantity));
                    }
                    catch
                    {
                       
                    }

                    try
                    {
                        ServiceGateway serviceGateway = new ServiceGateway();
                        serviceGateway.LoadByServiceId(Convert.ToInt32(row.ServiceID), companyId);
                        row.ServiceName = serviceGateway.GetName(Convert.ToInt32(row.ServiceID));
                    }
                    catch
                    {
                        row.ServiceName = "Other";
                    }
                }
            }
            
            return totalAveragePrice.ToString();
        }

        

    }
}
