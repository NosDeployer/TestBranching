﻿using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsAddInsuranceCompaniesCosts
    /// </summary>
    public class ActualCostsAddInsuranceCompaniesCosts : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsAddInsuranceCompaniesCosts()
            : base("InsuranceCompaniesCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsAddInsuranceCompaniesCosts(DataSet data)
            : base(data, "InsuranceCompaniesCosts")
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
            ActualCostsAddInsuranceCompaniesCostsGateway actualCostsAddInsuranceCompaniesCostsGateway = new ActualCostsAddInsuranceCompaniesCostsGateway(Data);
            actualCostsAddInsuranceCompaniesCostsGateway.LoadAllByProjectId(projectId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
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
        public void Insert(int projectId, int insuranceCompanyId, DateTime date, decimal rateCad, decimal rateUsd, string comment, bool deleted, int companyId, bool inDatabase, string name, string client, string project, int clientId)
        {
            ActualCostsAddTDS.InsuranceCompaniesCostsRow row = ((ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Table).NewInsuranceCompaniesCostsRow();
            row.RefID = GetNewRefId(projectId, companyId);
            row.ProjectID = projectId;
            row.InsuranceCompanyID = insuranceCompanyId;
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
            ((ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Table).AddInsuranceCompaniesCostsRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <param name="insuranceCompanyId">insuranceCompanyId</param>
        /// <param name="date">date</param>        
        /// <param name="rateCad">rateCad</param>        
        /// <param name="rateUsd">rateUsd</param>        
        /// <param name="comment">comment</param>
        /// <param name="deleted">Deleted</param>        
        /// <param name="companyId">CompanyId</param>
        /// <param name="name">name</param>        
        public void Update(int projectId, int refId, int insuranceCompanyId, DateTime date, decimal rateCad, decimal rateUsd, string comment, bool deleted, int companyId, string name)
        {
            ActualCostsAddTDS.InsuranceCompaniesCostsRow row = GetRow(projectId, refId);
            
            row.InsuranceCompanyID = insuranceCompanyId;
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
            ActualCostsAddTDS.InsuranceCompaniesCostsRow row = GetRow(projectId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Save(int companyId)
        {
            ActualCostsAddTDS insuranceCompaniesChanges = (ActualCostsAddTDS)Data.GetChanges();

            if (insuranceCompaniesChanges != null)
            {
                if (insuranceCompaniesChanges.InsuranceCompaniesCosts.Rows.Count > 0)
                {
                    ActualCostsAddInsuranceCompaniesCostsGateway actualCostsAddInsuranceCompaniesCostsGateway = new ActualCostsAddInsuranceCompaniesCostsGateway(insuranceCompaniesChanges);

                    foreach (ActualCostsAddTDS.InsuranceCompaniesCostsRow row in (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)insuranceCompaniesChanges.InsuranceCompaniesCosts)
                    {
                        // Insert new insurance cost 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {
                            int projectId = row.ProjectID;
                            int refId = row.RefID;
                            int insuranceCompanyId = row.InsuranceCompanyID;

                            decimal rateUsd = 0; if (!row.IsRateUsdNull()) rateUsd = row.RateUsd;                            
                            string comment = ""; if (!row.IsCommentNull()) comment = row.Comment;

                            ActualCostsInsuranceCompaniesCosts actualCostsInsuranceCompaniesCosts = new ActualCostsInsuranceCompaniesCosts(null);
                            actualCostsInsuranceCompaniesCosts.InsertDirect(projectId, refId, insuranceCompanyId, row.Date, row.RateCad, rateUsd, comment, row.Deleted, row.COMPANY_ID);
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
                ActualCostsAddInsuranceCompaniesCostsGateway rr = new ActualCostsAddInsuranceCompaniesCostsGateway();
                rr.LoadAllByProjectId(projectId, companyId);

                foreach (ActualCostsAddTDS.InsuranceCompaniesCostsRow row1 in (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)rr.Table)
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
                foreach (ActualCostsAddTDS.InsuranceCompaniesCostsRow row2 in (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Table)
                {
                    if (projectId == row2.ProjectID)
                    {
                        existProject = true;
                    }
                }

                // ... ... If there are rows at the grid get new Id
                if (existProject)
                {
                    foreach (ActualCostsAddTDS.InsuranceCompaniesCostsRow row3 in (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Table)
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
                    ActualCostsAddInsuranceCompaniesCostsGateway rrsc = new ActualCostsAddInsuranceCompaniesCostsGateway();
                    rrsc.LoadAllByProjectId(projectId, companyId);

                    foreach (ActualCostsAddTDS.InsuranceCompaniesCostsRow row3 in (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)rrsc.Table)
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
        /// <returns>ActualCostsAddTDS.InsuranceCompaniesCostsRow</returns>
        private ActualCostsAddTDS.InsuranceCompaniesCostsRow GetRow(int projectId, int refId)
        {
            ActualCostsAddTDS.InsuranceCompaniesCostsRow row = ((ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Table).FindByProjectIDRefID(projectId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsAddInsuranceCompaniesCosts.GetRow");
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
           
            foreach (ActualCostsAddTDS.InsuranceCompaniesCostsRow row in (ActualCostsAddTDS.InsuranceCompaniesCostsDataTable)Table)
            {
                if (!row.Deleted)
                {
                    summary = summary + "Date: " + row.Date.Month.ToString() + "/" + row.Date.Day.ToString() + "/" + row.Date.Year.ToString() + enterString;
                    summary = summary + "Client: " + row.Client + enterString;
                    summary = summary + "Project: " + row.Project + enterString;
                    summary = summary + "Insurance Company: " + row.Name + enterString;    

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