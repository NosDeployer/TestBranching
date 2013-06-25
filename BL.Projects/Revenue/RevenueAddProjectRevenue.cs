using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Revenue;

namespace LiquiForce.LFSLive.BL.Projects.Revenue
{
    /// <summary>
    /// RevenueAddProjectRevenue
    /// </summary>
    public class RevenueAddProjectRevenue: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RevenueAddProjectRevenue()
            : base("ProjectRevenue")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RevenueAddProjectRevenue(DataSet data)
            : base(data, "ProjectRevenue")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RevenueAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByProjectId(int projectId, int companyId)
        {
            RevenueAddProjectRevenueGateway revenueAddProjectRevenueGateway = new RevenueAddProjectRevenueGateway(Data);
            revenueAddProjectRevenueGateway.LoadAllByProjectId(projectId, companyId);
        }



        ///// <summary>
        ///// NotExistsByProjectIdRefIdDate
        ///// </summary>
        ///// <param name="projectId">projectId</param>        
        ///// <param name="dateFooter">dateFooter</param>        
        //public bool NotExistsByProjectIdRefIdDate(int projectId, DateTime date)
        //{
        //    bool noExists = true;
        //    if (Table.Rows.Count > 0)
        //    {
        //        foreach (RevenueAddTDS.ProjectRevenueRow row in (RevenueAddTDS.ProjectRevenueDataTable)Table)
        //        {
        //            if ((row.ProjectID == projectId) && (row.Date == date) && (row.Deleted == false))
        //            {
        //                noExists = false;
        //            }                    
        //        }
        //    }

        //    return noExists;
        //}






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Insert revenues
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="date">date</param>
        /// <param name="revenue">revenue</param>
        /// <param name="comment">comment</param>        
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="client">client</param>
        /// <param name="project">project</param>
        /// <param name="clientId">clientId</param>
        public void Insert(int projectId, DateTime date, decimal revenue, string comment, bool deleted, int companyId, bool inDatabase, string client, string project, int clientId)
        {
            RevenueAddTDS.ProjectRevenueRow row = ((RevenueAddTDS.ProjectRevenueDataTable)Table).NewProjectRevenueRow();
            row.ProjectID = projectId;    
            row.RefID = GetNewRefId(projectId, companyId);                    
            row.Date = date;
            row.Revenue = revenue;
            row.Comment = comment;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;
            row.Client = client;
            row.Project = project;
            row.ClientID = clientId;

            ((RevenueAddTDS.ProjectRevenueDataTable)Table).AddProjectRevenueRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>      
        /// <param name="projectId">projectId</param>  
        /// <param name="refId">refId</param>        
        /// <param name="date">date</param>
        /// <param name="revenue">revenue</param>       
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">CompanyId</param>
        public void Update(int projectId, int refId, DateTime date, decimal revenue, string comment, bool deleted, int companyId)
        {
            RevenueAddTDS.ProjectRevenueRow row = GetRow(projectId, refId);
                       
            row.Date = date;
            row.Revenue = revenue;                 
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;          
        }



        /// <summary>
        /// Delete revenue
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            RevenueAddTDS.ProjectRevenueRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
               
        /// <summary>
        /// Save all revenues to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            RevenueAddTDS revenueChanges = (RevenueAddTDS)Data.GetChanges();

            if (revenueChanges.ProjectRevenue.Rows.Count > 0)
            {
                RevenueAddProjectRevenueGateway revenuesAddProjectRevenueGateway = new RevenueAddProjectRevenueGateway(revenueChanges);

                foreach (RevenueAddTDS.ProjectRevenueRow row in (RevenueAddTDS.ProjectRevenueDataTable)revenueChanges.ProjectRevenue)
                {
                    //Insert revenues                   
                    ProjectRevenue projectRevenue = new ProjectRevenue(null);
                    projectRevenue.InsertDirect(row.ProjectID, row.RefID, row.Date, row.Revenue, row.Comment, row.Deleted, row.COMPANY_ID);                    
                }
            }
        }



        /// <summary>
        /// Get a single revenue. If not exists, raise an exception
        /// </summary>        
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>RevenueAddTDS.ProjectRevenueRow</returns>
        private RevenueAddTDS.ProjectRevenueRow GetRow(int projectId, int refId)
        {
            RevenueAddTDS.ProjectRevenueRow row = ((RevenueAddTDS.ProjectRevenueDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Revenue.RevenueAddProjectRevenue.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>RefID</returns>
        public int GetNewRefId(int projectId, int companyId)
        {
            int newRefId = 0;

            if (Table.Rows.Count == 0)
            {
                RevenueAddProjectRevenueGateway rr = new RevenueAddProjectRevenueGateway();
                rr.LoadAllByProjectId(projectId, companyId);

                foreach (RevenueAddTDS.ProjectRevenueRow row1 in (RevenueAddTDS.ProjectRevenueDataTable)rr.Table)
                {
                    if (newRefId < row1.RefID)
                    {
                        newRefId = row1.RefID;
                    }
                }
            }
            else
            {
                foreach (RevenueAddTDS.ProjectRevenueRow row2 in (RevenueAddTDS.ProjectRevenueDataTable)Table)
                {
                    if (newRefId < row2.RefID)
                    {
                        newRefId = row2.RefID;
                    }
                }

            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// GetSummary. 
        /// </summary>
        /// <param name="companyId">companyId</param>        
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetSummary(int companyId, string enterString)
        {
            string summary = "NEW REVENUES" + enterString;

            foreach (RevenueAddTDS.ProjectRevenueRow row in (RevenueAddTDS.ProjectRevenueDataTable)Table)
            {
                summary = summary + "Client: " + row.Client + enterString;
                summary = summary + "Project: " + row.Project + enterString;
                summary = summary + "Date: " + row.Date.Month.ToString() + "/" + row.Date.Day.ToString() + "/" + row.Date.Year.ToString() + enterString;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(row.ProjectID);

                if (projectGateway.GetCountryID(row.ProjectID) == 1) //Canada
                {
                    summary = summary + "Revenue: " + row.Revenue + " CAD" + enterString;                 
                }
                else
                {
                    summary = summary + "Revenue: " + row.Revenue + " USD" + enterString;                    
                }               
                
                summary = summary + "Comment: " + row.Comment + enterString + enterString;             
            }
            return (summary);
        }



    }
}