using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// GerencialWeeklyProductionReport
    /// </summary>
    public class GerencialWeeklyProductionReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public GerencialWeeklyProductionReport()
            : base("WeeklyProductionReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public GerencialWeeklyProductionReport(DataSet data)
            : base(data, "WeeklyProductionReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new GerencialWeeklyProductionReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByDate
        /// </summary>
        /// <param name="startDate">startDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadByDate(DateTime startDate, int companyId)
        {
            // ... Find first day of the week
            GerencialWeeklyProductionReportGateway gerencialWeeklyProductionReportGateway = new GerencialWeeklyProductionReportGateway(Data);
            gerencialWeeklyProductionReportGateway.ClearBeforeFill = false;

            // ... Load data for next 7 days
            for (int i = 0; i < 6; i++)
            {                
                gerencialWeeklyProductionReportGateway.LoadByDate(startDate.AddDays(i), companyId);                
            }

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
            foreach (GerencialWeeklyProductionReportTDS.WeeklyProductionReportRow row in (GerencialWeeklyProductionReportTDS.WeeklyProductionReportDataTable)Table)
            {
                // ... update for length
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

