using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProductionReport
    /// </summary>
    public  class ProductionReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //



        /// <summary>
        /// Default constructor
        /// </summary>
        public ProductionReport()
            : base("Production")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public ProductionReport(DataSet data)
            : base(data, "Production")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new ProductionReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS 
        //
        
        /// <summary>
        /// LoadByStartDateEndDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByStartDateEndDate(DateTime startDate, DateTime endDate, int companyId)
        {
            ProductionReportGateway productionReportGateway = new ProductionReportGateway(Data);
            productionReportGateway.LoadByStartDateEndDate(startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByClientIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByClientIdStartDateEndDate(int clientId, DateTime startDate, DateTime endDate, int companyId)
        {
            ProductionReportGateway productionReportGateway = new ProductionReportGateway(Data);
            productionReportGateway.LoadByClientIdStartDateEndDate(clientId, startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByClientIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByClientIdProjectIdStartDateEndDate(int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            ProductionReportGateway productionReportGateway = new ProductionReportGateway(Data);
            productionReportGateway.LoadByClientIdProjectIdStartDateEndDate(clientId, projectId, startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByCountryIdStartDateEndDate
        /// </summary>
        /// <param name="country">country</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryIdStartDateEndDate(int country, DateTime startDate, DateTime endDate, int companyId)
        {
            ProductionReportGateway productionReportGateway = new ProductionReportGateway(Data);
            productionReportGateway.LoadByCountryIdStartDateEndDate(country, startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByCountryIdClientIdStartDateEndDate
        /// </summary>
        /// <param name="country">country</param>
        /// <param name="clientId">clientId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryIdClientIdStartDateEndDate(int country, int clientId, DateTime startDate, DateTime endDate, int companyId)
        {
            ProductionReportGateway productionReportGateway = new ProductionReportGateway(Data);
            productionReportGateway.LoadByCountryIdClientIdStartDateEndDate(country, clientId, startDate, endDate, companyId);
        }



        /// <summary>
        /// LoadByCountryIdClientIdProjectIdStartDateEndDate
        /// </summary>
        /// <param name="country">country</param>
        /// <param name="clientId">clientId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryIdClientIdProjectIdStartDateEndDate(int country, int clientId, int projectId, DateTime startDate, DateTime endDate, int companyId)
        {
            ProductionReportGateway productionReportGateway = new ProductionReportGateway(Data);
            productionReportGateway.LoadByCountryIdClientIdProjectIdStartDateEndDate(country, clientId, projectId, startDate, endDate, companyId);
        }


                
    }
}