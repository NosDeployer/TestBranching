using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// BallparkSummaryReport
    /// </summary>
    public class BallparkSummaryReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BallparkSummaryReport()
            : base("BallparkSummaryReportTDS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public BallparkSummaryReport(DataSet data)
            : base(data, "BallparkSummaryReportTDS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new BallparkSummaryReportTDS();
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">where</param>
        /// <param name="orderBy">orderBy</param>
        /// <param name="money">money</param>
        /// <param name="exchangeRate">exchangeRate</param>
        public void LoadWhereOrderBy(string where, string orderBy, string money, decimal exchangeRate)
        {
            BallparkSummaryReportGateway ballparkSummaryReportGateway = new BallparkSummaryReportGateway(Data);
            ballparkSummaryReportGateway.LoadWhereOrderBy(where, orderBy);

            UpdateForReport(money, exchangeRate);
        }
                





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="money">money</param>
        /// <param name="exchangeRate">exchangeRate</param>
        private void UpdateForReport(string money, decimal exchangeRate)
        {
            foreach (BallparkSummaryReportTDS.BallparkSummaryReportTDSRow row in (BallparkSummaryReportTDS.BallparkSummaryReportTDSDataTable)Table)
            {
                // Set value to BillMoney
                if (!row.IsBillMoneyNull())
                {
                    if (row.BillMoney != money)
                    {
                        if (row.BillMoney == "CAD")
                        {
                            if (!row.IsBillPriceNull())
                            {
                                row.BillPrice = row.BillPrice / exchangeRate;
                            }
                        }
                        else
                        {
                            if (!row.IsBillPriceNull())
                            {
                                row.BillPrice = row.BillPrice * exchangeRate;
                            }
                        }
                    }

                }

            }

        }



    }
}
