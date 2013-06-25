using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.LabourHours.ActualCosts
{
    /// <summary>
    /// ActualCostsReportSubcontractorCosts
    /// </summary>
    public class ActualCostsReportSubcontractorCosts: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ActualCostsReportSubcontractorCosts()
            : base("SubcontractorCosts")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ActualCostsReportSubcontractorCosts(DataSet data)
            : base(data, "SubcontractorCosts")
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
            ActualCostsReportSubcontractorCostsGateway subcontractorHoursReportGateway = new ActualCostsReportSubcontractorCostsGateway(Data);
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
            ActualCostsReportSubcontractorCostsGateway subcontractorHoursReportGateway = new ActualCostsReportSubcontractorCostsGateway(Data);
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
            ActualCostsReportSubcontractorCostsGateway subcontractorHoursReportGateway = new ActualCostsReportSubcontractorCostsGateway(Data);
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
            ActualCostsReportSubcontractorCostsGateway subcontractorHoursReportGateway = new ActualCostsReportSubcontractorCostsGateway(Data);
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
            ActualCostsReportSubcontractorCostsGateway subcontractorHoursReportGateway = new ActualCostsReportSubcontractorCostsGateway(Data);
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
            ActualCostsReportSubcontractorCostsGateway subcontractorHoursReportGateway = new ActualCostsReportSubcontractorCostsGateway(Data);
            subcontractorHoursReportGateway.ClearBeforeFill = false;
            subcontractorHoursReportGateway.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
            subcontractorHoursReportGateway.ClearBeforeFill = true;
        }
    }
}
