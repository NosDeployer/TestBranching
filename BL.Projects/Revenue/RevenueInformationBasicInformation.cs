using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Revenue;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;


namespace LiquiForce.LFSLive.BL.Projects.Revenue
{
    /// <summary>
    /// RevenueInformationBasicInformation
    /// </summary>
    public class RevenueInformationBasicInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RevenueInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RevenueInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RevenueInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="projectId">projectId</param>    
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByProjectIdRefId(int projectId, int refId, int companyId)
        {
            RevenueInformationBasicInformationGateway revenueInformationBasicInformationGateway = new RevenueInformationBasicInformationGateway(Data);
            revenueInformationBasicInformationGateway.LoadByProjectIdRefId(projectId, refId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="date">date</param>
        /// <param name="revenue">revenue</param>
        /// <param name="comment">comment</param>
        public void Update(int projectId, int refId, DateTime date, decimal revenue, string comment)
        {
            RevenueInformationTDS.BasicInformationRow row = GetRow(projectId, refId);

            row.Date = date;
            row.Revenue = revenue;           
            if (comment.Trim() != "") row.Comment = comment; else row.SetCommentNull();           
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>       
        public void Delete(int projectId, int refId)
        {
            RevenueInformationTDS.BasicInformationRow row = GetRow(projectId, refId);                                
            row.Deleted = true;            
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            RevenueInformationTDS revenueInformationChanges = (RevenueInformationTDS)Data.GetChanges();

            if (revenueInformationChanges.BasicInformation.Rows.Count > 0)
            {
                RevenueInformationBasicInformationGateway revenueBasicInformationGateway = new RevenueInformationBasicInformationGateway(revenueInformationChanges);

                // Update revneue
                foreach (RevenueInformationTDS.BasicInformationRow row in (RevenueInformationTDS.BasicInformationDataTable)revenueInformationChanges.BasicInformation)
                {
                    // Insert new revenue 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;

                        ProjectRevenue projectRevenue = new ProjectRevenue(null);
                        projectRevenue.InsertDirect(row.ProjectID, row.RefID, row.Date, row.Revenue, comment, row.Deleted, row.COMPANY_ID);
                    }

                    // Update revenue
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int projectId = row.ProjectID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // Original values
                        DateTime originalDate = revenueBasicInformationGateway.GetDateOriginal(projectId, refId);
                        decimal originalRevenue = revenueBasicInformationGateway.GetRevenueOriginal(projectId, refId);
                        string originalComment = revenueBasicInformationGateway.GetCommentOriginal(projectId, refId);

                        // New values
                        DateTime newDate = revenueBasicInformationGateway.GetDate(projectId, refId);
                        decimal newRevenue = revenueBasicInformationGateway.GetRevenue(projectId, refId);
                        string newComment = revenueBasicInformationGateway.GetComment(projectId, refId);

                        ProjectRevenue projectRevenue = new ProjectRevenue(null);
                        projectRevenue.UpdateDirect(projectId, refId, originalDate, originalRevenue, originalComment, originalDeleted, originalCompanyId, projectId, refId, newDate, newRevenue, newComment, originalDeleted, originalCompanyId);
                    }

                    // Delete revenue 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectRevenue projectRevenue = new ProjectRevenue(null);
                        projectRevenue.DeleteDirect(row.ProjectID, row.RefID, row.COMPANY_ID);
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
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private RevenueInformationTDS.BasicInformationRow GetRow(int projectId, int refId)
        {
            RevenueInformationTDS.BasicInformationRow row = ((RevenueInformationTDS.BasicInformationDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Revenue.RevenueInformationBasicInformation.GetRow");
            }

            return row;
        }



    }
}
