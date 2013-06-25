using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// TotalValueWorkAheadReport
    /// </summary>
    public class TotalValueWorkAheadReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Constructor
        /// </summary>
        public TotalValueWorkAheadReport() : base("TotalValueWorkAheadReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public TotalValueWorkAheadReport(DataSet data) : base(data, "TotalValueWorkAheadReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TotalValueWorkAheadReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadWhere
        /// </summary>
        /// <param name="where">where</param>
        /// <param name="money">money</param>
        /// <param name="exchangeRate">exchangeRate</param>
        public void LoadWhere(string where, string money, decimal exchangeRate)
        {
            TotalValueWorkAheadReportGateway totalValueWorkAheadReportGateway = new TotalValueWorkAheadReportGateway(Data);
            totalValueWorkAheadReportGateway.LoadWhere(where);

            UpdateForReport(money, exchangeRate);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForProcess
        /// </summary>
        private void UpdateForReport(string money, decimal exchangeRate)
        {
            foreach (TotalValueWorkAheadReportTDS.TotalValueWorkAheadReportRow row in (TotalValueWorkAheadReportTDS.TotalValueWorkAheadReportDataTable)Table)
            {
                if (row.ProjectState == "Awarded")
                {
                    row.SaleGettingJob = 100;
                }

                if (!row.IsBillPriceNull())
                {
                    if (row.BillMoney != money)
                    {
                        if (row.BillMoney == "CAD")
                        {
                            row.BillPrice = row.BillPrice / exchangeRate;
                        }
                        else
                        {
                            row.BillPrice = row.BillPrice * exchangeRate;
                        }
                    }
                }

                if ((!row.IsBillPriceNull()) && (!row.IsSaleGettingJobNull()))
                {
                    if (row.SaleGettingJob >= 95)
                    {
                        row.Total = row.BillPrice;
                    }
                    else
                    {
                        row.Total = 0;
                    }
                    //row.Total = (row.BillPrice * row.SaleGettingJob) / 100;
                }
                else
                {
                    row.Total = 0;
                }
            }
        }



    }
}
