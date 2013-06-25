using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursReport
    /// </summary>
    public class SubcontractorHoursReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursReport()
            : base("SubcontractorHours")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursReport(DataSet data)
            : base(data, "SubcontractorHours")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadForSubcontractors
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void LoadForSubcontractors(int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadForSubcontractors(companyId);
        }



        /// <summary>
        /// LoadStartDateEndDateForSubcontractors
        /// </summary>        
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadStartDateEndDateForSubcontractors(DateTime startDate, DateTime endDate, int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadStartDateEndDateForSubcontractors(startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadBySubcontractorId
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="companyId">companyId</param>
        public void LoadBySubcontractorId(int subcontractorId, int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadBySubcontractorId(subcontractorId, companyId);
        }



        /// <summary>
        /// LoadBySubcontractorIdStartDateEndDate
        /// </summary>
        /// <param name="subcontractorId">subcontractorId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadBySubcontractorIdStartDateEndDate(int subcontractorId, DateTime startDate, DateTime endDate, int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadBySubcontractorIdStartDateEndDate(subcontractorId, startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadForClientProject
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void LoadForClientProject(int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadForClientProject(companyId);
        }



        /// <summary>
        /// LoadStartDateEndDateForClientProject
        /// </summary>        
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadStartDateEndDateForClientProject(DateTime startDate, DateTime endDate, int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadStartDateEndDateForClientProject(startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByCompaniesId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesId(int clientId, int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadByCompaniesId(clientId, companyId);
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
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadByCompaniesIdStartDateEndDate(clientId, startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdProjectId
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCompaniesIdProjectId(int clientId, int projectId, int companyId)
        {
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadByCompaniesIdProjectId(clientId, projectId, companyId);
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
            SubcontractorHoursReportGateway subcontractorHoursReportGateway = new SubcontractorHoursReportGateway(Data);
            subcontractorHoursReportGateway.LoadByCompaniesIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
        }


      



        


    }
}
