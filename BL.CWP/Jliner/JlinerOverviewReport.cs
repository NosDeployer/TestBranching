using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Section;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerOverviewReport
    /// </summary>
    public class JlinerOverviewReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerOverviewReport() : base("JlinerOverview")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlinerOverviewReport(DataSet data)
            : base(data, "JlinerOverview")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerOverviewReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Load(int companyId)
        {
            JlinerOverviewReportGateway jlinerOverviewReportGateway = new JlinerOverviewReportGateway(Data);
            jlinerOverviewReportGateway.Load(companyId);
            UpdateForProcess();           
        }



        /// <summary>
        /// LoadByCompaniesID
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>         
        public void LoadByCompaniesID(int companiesId, int companyId)
        {
            JlinerOverviewReportGateway jlinerOverviewReportGateway = new JlinerOverviewReportGateway(Data);
            jlinerOverviewReportGateway.LoadByCompaniesID(companiesId, companyId);
            UpdateForProcess();
        }
        


        /// <summary>
        /// UpdateCommentsForProcess
        /// </summary>
        public void UpdateCommentsForReport()
        {
            foreach (JlinerOverviewReportTDS.JlinerOverviewRow row in (JlinerOverviewReportTDS.JlinerOverviewDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }
            }
        }



        /// <summary>
        /// UpdateForProcess
        /// </summary>
        public void UpdateForProcess()
        {
            JlinerCoPitLocationListGateway jlinerCoPitLocationListGateway = new JlinerCoPitLocationListGateway();
            
            foreach (JlinerOverviewReportTDS.JlinerOverviewRow row in (JlinerOverviewReportTDS.JlinerOverviewDataTable)Table)
            {
                if (!row.IsCoPitLocationNull())
                {
                    row.Abbreviation = jlinerCoPitLocationListGateway.GetAbbreviation(row.CoPitLocation, row.COMPANY_ID);
                }
            }
        }
    }
}
