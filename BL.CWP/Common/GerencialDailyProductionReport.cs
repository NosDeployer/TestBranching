using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// GerencialDailyProductionReport
    /// </summary>
    public class GerencialDailyProductionReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public GerencialDailyProductionReport()
            : base("DailyProductionReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public GerencialDailyProductionReport(DataSet data)
            : base(data, "DailyProductionReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new GerencialDailyProductionReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="date">date</param>
        /// <param name="companyId">companyId</param>
        public void LoadByDate(DateTime date, int companyId)
        {            
            GerencialDailyProductionReportGateway gerencialDailyProductionReportGateway = new GerencialDailyProductionReportGateway(Data);
            gerencialDailyProductionReportGateway.LoadByDate(date, companyId);

            UpdateFieldsForSections();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            foreach (GerencialDailyProductionReportTDS.DailyProductionReportRow row in (GerencialDailyProductionReportTDS.DailyProductionReportDataTable)Table)
            {              
                // ... modify for length
                if (row.IsLengthNull())
                {
                    row.TotalFtInstalled = 0;
                }
                else
                {
                    Distance distance = new Distance(row.Length);
                    row.TotalFtInstalled = distance.ToDoubleInEng3();
                }
            }
        }



    }
}
