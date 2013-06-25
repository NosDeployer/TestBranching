﻿using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsReportInsuranceCosts
    /// </summary>
    public class ActualCostsReportInsuranceCosts: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsReportInsuranceCosts()
            : base("InsuranceCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsReportInsuranceCosts(DataSet data)
            : base(data, "InsuranceCosts")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadForClientProject
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void LoadForClientProject(int companyId)
        {
            ActualCostsReportInsuranceCostsGateway subcontractorHoursReportGateway = new ActualCostsReportInsuranceCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadForClientProject(companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesId(int clientId, int companyId)
        {
            ActualCostsReportInsuranceCostsGateway subcontractorHoursReportGateway = new ActualCostsReportInsuranceCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadByCompaniesId(clientId, companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectId(int clientId, int projectId, int companyId)
        {
            ActualCostsReportInsuranceCostsGateway subcontractorHoursReportGateway = new ActualCostsReportInsuranceCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }




        /// <summary>
        /// LoadStartDateEndDateForClientProject
        /// </summary>        
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadStartDateEndDateForClientProject(DateTime startDate, DateTime endDate, int companyId)
        {
            ActualCostsReportInsuranceCostsGateway subcontractorHoursReportGateway = new ActualCostsReportInsuranceCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdStartDateEndDate(int clientId, DateTime startDate, DateTime endDate, int companyId)
        {
            ActualCostsReportInsuranceCostsGateway subcontractorHoursReportGateway = new ActualCostsReportInsuranceCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDate(int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            ActualCostsReportInsuranceCostsGateway subcontractorHoursReportGateway = new ActualCostsReportInsuranceCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }
    }
}
