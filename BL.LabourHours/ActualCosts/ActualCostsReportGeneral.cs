using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using System.Collections;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsReportGeneral
    /// </summary>
    public class ActualCostsReportGeneral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public ActualCostsReportGeneral()
            : base("PrintActualCostsGeneral")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ActualCostsReportGeneral(DataSet data)
            : base(data, "PrintActualCostsGeneral")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS 
        //

        public int LoadAll(string category, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId, bool withDates)
        {
            int rows = 0;

            ActualCostsReportGeneralGateway actualCostsReportGeneralGateway = new ActualCostsReportGeneralGateway(Data);
            actualCostsReportGeneralGateway.ClearBeforeFill = false;
            actualCostsReportGeneralGateway.Load();

            // Load Subcontractors
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportSubcontractorCosts actualCostsReportSubcontractorCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportSubcontractorCosts(Data);

            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportSubcontractorCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportSubcontractorCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }

            // Load Hotels
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportHotelCosts actualCostsReportHotelCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportHotelCosts(Data);

            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportHotelCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportHotelCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }

            // Load bonding Companies
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportBondingCosts actualCostsReportBondingCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportBondingCosts(Data);
            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportBondingCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportBondingCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }  

            // Load Insurance Companies
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportInsuranceCosts actualCostsReportInsuranceCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportInsuranceCosts(Data);

            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportInsuranceCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportInsuranceCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }

            //Load Other costs
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportOtherCosts actualCostsReportOtherCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportOtherCosts(Data);

            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportOtherCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportOtherCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }

            actualCostsReportGeneralGateway.ClearBeforeFill = true;

            rows = actualCostsReportSubcontractorCosts.Table.Rows.Count + actualCostsReportHotelCosts.Table.Rows.Count + actualCostsReportBondingCosts.Table.Rows.Count + actualCostsReportInsuranceCosts.Table.Rows.Count + actualCostsReportOtherCosts.Table.Rows.Count;

            return rows;
        }

        /// <summary>
        /// LoadForSubcontractors
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="withDates">withDates</param>
        public void LoadForSubcontractors(string category, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId, bool withDates)
        {
            // Load Subcontractors
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportSubcontractorCosts actualCostsReportSubcontractorCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportSubcontractorCosts(Data);
            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportSubcontractorCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportSubcontractorCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportSubcontractorCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }
        }



        /// <summary>
        /// LoadForHotels
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="withDates">withDates</param>
        public void LoadForHotels(string category, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId, bool withDates)
        {
            // Load Hotels
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportHotelCosts actualCostsReportHotelCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportHotelCosts(Data);
            
            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportHotelCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportHotelCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportHotelCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }               
        }



        /// <summary>
        /// LoadForInsuranceCompanies
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="withDates">withDates</param>
        public void LoadForInsuranceCompanies(string category, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId, bool withDates)
        {
            // Load Insurance Companies
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportInsuranceCosts actualCostsReportInsuranceCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportInsuranceCosts(Data);
            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportInsuranceCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportInsuranceCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportInsuranceCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }
        }



        /// <summary>
        /// LoadForBondingCompanies
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="withDates">withDates</param>
        public void LoadForBondingCompanies(string category, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId, bool withDates)
        {
            // Load bonding Companies
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportBondingCosts actualCostsReportBondingCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportBondingCosts(Data);
            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportBondingCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportBondingCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportBondingCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }    
        }



        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        /// <param name="withDates">withDates</param>
        public void LoadForOtherCosts(string category, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId, bool withDates)
        {
            //Load Other costs
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportOtherCosts actualCostsReportOtherCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportOtherCosts(Data);
            if (!withDates)
            {
                if (clientId == -1)
                {
                    actualCostsReportOtherCosts.LoadForClientProject(companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesId(clientId, companyId);
                    }
                    else
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
                    }
                }
            }
            else
            {
                if (clientId == -1)
                {
                    actualCostsReportOtherCosts.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
                }
                else
                {
                    if (projectId == -1)
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
                    }
                    else
                    {
                        actualCostsReportOtherCosts.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
                    }
                }
            }
        }
        


    }
}