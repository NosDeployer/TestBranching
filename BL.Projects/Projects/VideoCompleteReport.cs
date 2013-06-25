using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// VideoCompleteReport
    /// </summary>
    public class VideoCompleteReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public VideoCompleteReport()
            : base("Production")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public VideoCompleteReport(DataSet data)
            : base(data, "Production")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new VideoCompleteReportTDS();
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
            VideoCompleteReportGateway videoCompleteReportGateway = new VideoCompleteReportGateway(Data);
            videoCompleteReportGateway.ClearBeforeFill = false;
            videoCompleteReportGateway.LoadByStartDateEndDate(startDate, endDate, companyId);
            videoCompleteReportGateway.LoadByStartDateEndDate2(startDate, endDate, companyId);
            videoCompleteReportGateway.ClearBeforeFill = true;
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
            VideoCompleteReportGateway videoCompleteReportGateway = new VideoCompleteReportGateway(Data);
            videoCompleteReportGateway.ClearBeforeFill = false;
            videoCompleteReportGateway.LoadByCountryIdStartDateEndDate(country, startDate, endDate, companyId);
            videoCompleteReportGateway.LoadByCountryIdStartDateEndDate2(country, startDate, endDate, companyId);
            videoCompleteReportGateway.ClearBeforeFill = true;
        }


                
    }
}