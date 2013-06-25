using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsAddSubcontractorCosts
    /// </summary>
    public class ActualCostsAddSubcontractorCosts : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsAddSubcontractorCosts()
            : base("SubcontractorCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsAddSubcontractorCosts(DataSet data)
            : base(data, "SubcontractorCosts")
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
            ActualCostsAddSubcontractorCostsGateway actualCostsAddSubcontractorCostsGateway = new ActualCostsAddSubcontractorCostsGateway(Data);
            actualCostsAddSubcontractorCostsGateway.LoadAllByProjectId(projectId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="date">date</param>
        /// <param name="quantity">quantity</param>
        /// <param name="rateCad">rateCad</param>
        /// <param name="totalCad">totalCad</param>
        /// <param name="rateUsd">rateUsd</param>
        /// <param name="totalUsd">totalUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">Deleted</param>
        /// <param name="libraryFilesId">LibraryFilesId</param>
        /// <param name="companyId">CompanyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="name">name</param>
        /// <param name="client">client</param>
        /// <param name="project">project</param>
        /// <param name="clientId">clientId</param>
        public void Insert(int projectId, int subcontractorId, DateTime date, double quantity, decimal rateCad, decimal totalCad, decimal rateUsd, decimal totalUsd, string comment, bool deleted, int companyId, bool inDatabase, string name, string client, string project, int clientId)
        {
            ActualCostsAddTDS.SubcontractorCostsRow row = ((ActualCostsAddTDS.SubcontractorCostsDataTable)Table).NewSubcontractorCostsRow();
            row.RefID = GetNewRefId(projectId, companyId);
            row.ProjectID = projectId;
            row.SubcontractorID = subcontractorId;
            row.Date = date;
            row.Quantity = quantity;
            row.RateCad = rateCad;
            row.TotalCad = totalCad;
            row.RateUsd = rateUsd;
            row.TotalUsd = totalUsd;
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();
            row.Deleted = deleted;            
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.Name = name;
            row.Rate = rateCad;
            row.Total = totalCad;
            row.Client = client;
            row.Project = project;
            row.ClientID = clientId;
            ((ActualCostsAddTDS.SubcontractorCostsDataTable)Table).AddSubcontractorCostsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="date">date</param>
        /// <param name="quantity">quantity</param>
        /// <param name="rateCad">rateCad</param>
        /// <param name="totalCad">totalCad</param>
        /// <param name="rateUsd">rateUsd</param>
        /// <param name="totalUsd">totalUsd</param>
        /// <param name="comment">comment</param>
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">CompanyId</param>
        /// <param name="name">name</param>        
        public void Update(int projectId, int refId, int subcontractorId, DateTime date, double quantity, decimal rateCad, decimal totalCad, decimal rateUsd, decimal totalUsd, string comment, bool deleted, int companyId, string name)
        {
            ActualCostsAddTDS.SubcontractorCostsRow row = GetRow(projectId, refId);
            
            row.SubcontractorID = subcontractorId;
            row.Date = date;
            row.Quantity = quantity;
            row.RateCad = rateCad;
            row.TotalCad = totalCad;
            row.RateUsd = rateUsd;
            row.TotalUsd = totalUsd;
            if ((comment != "") && (comment != null)) row.Comment = comment.Trim(); else row.SetCommentNull();            
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.Name = name;
            row.Rate = rateCad;
            row.Total = totalCad;            
        }



        /// <summary>
        /// Delete project
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="refId">RefId</param>
        /// <returns></returns>
        public void Delete(int projectId, int refId)
        {
            ActualCostsAddTDS.SubcontractorCostsRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all udfs to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            ActualCostsAddTDS subcontractorsChanges = (ActualCostsAddTDS)Data.GetChanges();

            if (subcontractorsChanges != null)
            {
                if (subcontractorsChanges.SubcontractorCosts.Rows.Count > 0)
                {
                    ActualCostsAddSubcontractorCostsGateway actualCostsAddSubcontractorCostsGateway = new ActualCostsAddSubcontractorCostsGateway(subcontractorsChanges);

                    foreach (ActualCostsAddTDS.SubcontractorCostsRow row in (ActualCostsAddTDS.SubcontractorCostsDataTable)subcontractorsChanges.SubcontractorCosts)
                    {
                        // Insert new subcontractor hours 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            int subcontractorId = row.SubcontractorID;

                            decimal rateUsd = 0; if (!row.IsRateUsdNull()) rateUsd = row.RateUsd;
                            decimal totalUsd = 0; if (!row.IsTotalUsdNull()) totalUsd = row.TotalUsd;
                            string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;

                            ActualCostsSubcontractorCosts actualCostsSubcontractorCosts = new ActualCostsSubcontractorCosts(null);
                            actualCostsSubcontractorCosts.InsertDirect(projectId, refId, subcontractorId, row.Date, row.Quantity, row.RateCad, row.TotalCad, rateUsd, totalUsd, comment, row.Deleted, row.COMPANY_ID);
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
                ActualCostsAddSubcontractorCostsGateway rr = new ActualCostsAddSubcontractorCostsGateway();
                rr.LoadAllByProjectId(projectId, companyId);

                foreach (ActualCostsAddTDS.SubcontractorCostsRow row1 in (ActualCostsAddTDS.SubcontractorCostsDataTable)rr.Table)
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
                foreach (ActualCostsAddTDS.SubcontractorCostsRow row2 in (ActualCostsAddTDS.SubcontractorCostsDataTable)Table)
                {
                    if (projectId == row2.ProjectID)
                    {
                        existProject = true;
                    }
                }

                // ... ... If there are rows at the grid get new Id
                if (existProject)
                {
                    foreach (ActualCostsAddTDS.SubcontractorCostsRow row3 in (ActualCostsAddTDS.SubcontractorCostsDataTable)Table)
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
                    ActualCostsAddSubcontractorCostsGateway rrsc = new ActualCostsAddSubcontractorCostsGateway();
                    rrsc.LoadAllByProjectId(projectId, companyId);

                    foreach (ActualCostsAddTDS.SubcontractorCostsRow row3 in (ActualCostsAddTDS.SubcontractorCostsDataTable)rrsc.Table)
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
        /// <returns>ActualCostsAddTDS.SubcontractorCostsRow</returns>
        private ActualCostsAddTDS.SubcontractorCostsRow GetRow(int projectId, int refId)
        {
            ActualCostsAddTDS.SubcontractorCostsRow row = ((ActualCostsAddTDS.SubcontractorCostsDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsAddSubcontractorCosts.GetRow");
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
        public string GetSummary(int companyId, string enterString, string option)
        {
            string summary = "" + enterString;

            if (option == "BySubcontractor")
            {
                foreach (ActualCostsAddTDS.SubcontractorCostsRow row in (ActualCostsAddTDS.SubcontractorCostsDataTable)Table)
                {
                    if (!row.Deleted)
                    {
                        summary = summary + "Date: " + row.Date.Month.ToString() + "/" + row.Date.Day.ToString() + "/" + row.Date.Year.ToString() + enterString;
                        summary = summary + "Client: " + row.Client + enterString;
                        summary = summary + "Project: " + row.Project + enterString;
                        summary = summary + "Quantity: " + row.Quantity + enterString;

                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(row.ProjectID);

                        if (projectGateway.GetCountryID(row.ProjectID) == 1) //Canada
                        {
                            summary = summary + "Rate: " + row.Rate + " CAD" + enterString;
                            summary = summary + "Total: " + row.TotalCad + " CAD" + enterString;
                        }
                        else
                        {
                            summary = summary + "Rate: " + row.Rate + " USD" + enterString;
                            summary = summary + "Total: " + row.TotalUsd + " CAD" + enterString;
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
            }
            else
            {
                if (option == "ByClientProject")
                {
                    foreach (ActualCostsAddTDS.SubcontractorCostsRow row in (ActualCostsAddTDS.SubcontractorCostsDataTable)Table)
                    {   
                        if (!row.Deleted)
                        {
                            summary = summary + "Date: " + row.Date.Month.ToString() + "/" + row.Date.Day.ToString() + "/" + row.Date.Year.ToString() + enterString;
                            summary = summary + "Subcontractor: " + row.Name + enterString;                            
                            summary = summary + "Quantity: " + row.Quantity + enterString;

                            ProjectGateway projectGateway = new ProjectGateway();
                            projectGateway.LoadByProjectId(row.ProjectID);

                            if (projectGateway.GetCountryID(row.ProjectID) == 1) //Canada
                            {
                                summary = summary + "Rate: " + row.Rate + " CAD" + enterString;
                                summary = summary + "Total: " + row.TotalCad + " CAD" + enterString;
                            }
                            else
                            {
                                summary = summary + "Rate: " + row.Rate + " USD" + enterString;
                                summary = summary + "Total: " + row.TotalUsd + " CAD" + enterString;
                            }

                            if (!row.IsCommentNull())
                            {
                                summary = summary + "Comment: " + row.Comment + enterString + enterString;
                            }
                            else
                            {
                                summary = summary + "Comment: " + enterString + enterString; 
                            }
                        }
                    }
                }
            }
            return (summary);
        }






    }
}