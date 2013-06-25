using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsAddOtherCosts
    /// </summary>
    public class ActualCostsAddOtherCosts : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsAddOtherCosts()
            : base("OtherCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsAddOtherCosts(DataSet data)
            : base(data, "OtherCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsAddTDS();
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
            ActualCostsAddOtherCostsGateway actualCostsAddOtherCostsGateway = new ActualCostsAddOtherCostsGateway(Data);
            actualCostsAddOtherCostsGateway.LoadAllByProjectId(projectId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="category">category</param>
        /// <param name="date">date</param>        
        /// <param name="rateCad">rateCad</param>        
        /// <param name="rateUsd">rateUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">CompanyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="name">name</param>
        /// <param name="client">client</param>
        /// <param name="project">project</param>
        /// <param name="clientId">clientId</param>
        public void Insert(int projectId, string category, DateTime date, decimal rateCad, decimal rateUsd, string comment, bool deleted, int companyId, bool inDatabase, string name, string client, string project, int clientId)
        {
            ActualCostsAddTDS.OtherCostsRow row = ((ActualCostsAddTDS.OtherCostsDataTable)Table).NewOtherCostsRow();
            row.RefID = GetNewRefId(projectId, companyId);
            row.ProjectID = projectId;
            row.Category = category;
            row.Date = date;            
            row.RateCad = rateCad;            
            row.RateUsd = rateUsd;            
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();
            row.Deleted = deleted;            
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Name = name;
            row.Rate = rateCad;            
            row.Client = client;
            row.Project = project;
            row.ClientID = clientId;
            ((ActualCostsAddTDS.OtherCostsDataTable)Table).AddOtherCostsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="category">category</param>
        /// <param name="date">date</param>        
        /// <param name="rateCad">rateCad</param>        
        /// <param name="rateUsd">rateUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">CompanyId</param>
        /// <param name="name">name</param>        
        public void Update(int projectId, int refId, string category, DateTime date, decimal rateCad, decimal rateUsd, string comment, bool deleted, int companyId, string name)
        {
            ActualCostsAddTDS.OtherCostsRow row = GetRow(projectId, refId);
            
            row.Category = category;
            row.Date = date;            
            row.RateCad = rateCad;            
            row.RateUsd = rateUsd;            
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Name = name;
            row.Rate = rateCad;                       
        }



        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            ActualCostsAddTDS.OtherCostsRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            ActualCostsAddTDS otherChanges = (ActualCostsAddTDS)Data.GetChanges();

            if (otherChanges != null)
            {
                if (otherChanges.OtherCosts.Rows.Count > 0)
                {
                    ActualCostsAddOtherCostsGateway actualCostsAddOtherCostsGateway = new ActualCostsAddOtherCostsGateway(otherChanges);

                    foreach (ActualCostsAddTDS.OtherCostsRow row in (ActualCostsAddTDS.OtherCostsDataTable)otherChanges.OtherCosts)
                    {
                        // Insert new other cost 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            string category = row.Category;

                            decimal rateUsd = 0; if (!row.IsRateUsdNull()) rateUsd = row.RateUsd;                            
                            string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;

                            ActualCostsOtherCosts actualCostsOtherCosts = new ActualCostsOtherCosts(null);
                            actualCostsOtherCosts.InsertDirect(projectId, refId, category, row.Date, row.RateCad, rateUsd, comment, row.Deleted, row.COMPANY_ID);
                        }                        
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>New ID</returns>
        public int GetNewRefId(int projectId, int companyId)
        {           
            int newRefId = 0;

            if (Table.Rows.Count == 0)
            {
                ActualCostsAddOtherCostsGateway rr = new ActualCostsAddOtherCostsGateway();
                rr.LoadAllByProjectId(projectId, companyId);

                foreach (ActualCostsAddTDS.OtherCostsRow row1 in (ActualCostsAddTDS.OtherCostsDataTable)rr.Table)
                {
                    if (newRefId < row1.RefID)
                    {
                        newRefId = row1.RefID;
                    }
                }
            }
            else
            {
                // ... If there are rows at the grid
                // ... ... Verify if there are rows for the same project at the grid
                bool existProject = false;
                foreach (ActualCostsAddTDS.OtherCostsRow row2 in (ActualCostsAddTDS.OtherCostsDataTable)Table)
                {
                    if (projectId == row2.ProjectID)
                    {
                        existProject = true;
                    }
                }

                // ... ... If there are rows at the grid get new Id
                if (existProject)
                {
                    foreach (ActualCostsAddTDS.OtherCostsRow row3 in (ActualCostsAddTDS.OtherCostsDataTable)Table)
                    {
                        if (projectId == row3.ProjectID)
                        {
                            if (newRefId < row3.RefID)
                            {
                                newRefId = row3.RefID;
                            }
                        }
                    }
                }
                else
                {
                    // ... ... There are no rows for the project at the grid, verify on de db.                    
                    ActualCostsAddOtherCostsGateway rrsc = new ActualCostsAddOtherCostsGateway();
                    rrsc.LoadAllByProjectId(projectId, companyId);

                    foreach (ActualCostsAddTDS.OtherCostsRow row3 in (ActualCostsAddTDS.OtherCostsDataTable)rrsc.Table)
                    {
                        if (newRefId < row3.RefID)
                        {
                            newRefId = row3.RefID;
                        }
                    }
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// Get a single sobcontractor hour. If not exists, raise an exception
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ActualCostsAddTDS.OtherCostsRow</returns>
        private ActualCostsAddTDS.OtherCostsRow GetRow(int projectId, int refId)
        {
            ActualCostsAddTDS.OtherCostsRow row = ((ActualCostsAddTDS.OtherCostsDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsAddOtherCosts.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetSummary. 
        /// </summary>
        /// <param name="companyId">companyId</param>        
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        /// <param name="option">option</param>
        public string GetSummary(int companyId, string enterString)
        {
            string summary = "" + enterString;
           
            foreach (ActualCostsAddTDS.OtherCostsRow row in (ActualCostsAddTDS.OtherCostsDataTable)Table)
            {
                if (!row.Deleted)
                {
                    summary = summary + "Date: " + row.Date.Month.ToString() + "/" + row.Date.Day.ToString() + "/" + row.Date.Year.ToString() + enterString;
                    summary = summary + "Client: " + row.Client + enterString;
                    summary = summary + "Project: " + row.Project + enterString;
                    summary = summary + "Category: " + row.Name + enterString;    

                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(row.ProjectID);

                    if (projectGateway.GetCountryID(row.ProjectID) == 1) //Canada
                    {
                        summary = summary + "Rate: " + row.Rate + " CAD" + enterString;                            
                    }
                    else
                    {
                        summary = summary + "Rate: " + row.Rate + " USD" + enterString;                            
                    }

                    if (!row.IsCommentNull())
                    {
                        summary = summary + "Comment: " + row.Comment + enterString + enterString;
                    }
                    else
                    {
                        summary = summary + "Comment: " + enterString + enterString; ;
                    }
                }
            }
            
            return (summary);
        }






    }
}