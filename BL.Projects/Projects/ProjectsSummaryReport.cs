﻿using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectsSummaryReport
    /// </summary>
    public class ProjectsSummaryReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectsSummaryReport()
            : base("ProjectsSummaryReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public ProjectsSummaryReport(DataSet data)
            : base(data, "ProjectsSummaryReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectsSummaryReportTDS();
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
            ProjectsSummaryReportGateway projectsSummaryReportGateway = new ProjectsSummaryReportGateway(Data);
            projectsSummaryReportGateway.LoadWhere(where);

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
            foreach (ProjectsSummaryReportTDS.ProjectsSummaryReportRow row in (ProjectsSummaryReportTDS.ProjectsSummaryReportDataTable)Table)
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

                            if (!row.IsCostsIncurredNull())
                            {
                                row.CostsIncurred = row.CostsIncurred / exchangeRate;
                            }

                            if (!row.IsCostToCompleteNull())
                            {
                                row.CostToComplete = row.CostToComplete / exchangeRate;
                            }

                            if (!row.IsExtrasToDateNull())
                            {
                                row.ExtrasToDate = row.ExtrasToDate / exchangeRate;
                            }

                            if (!row.IsOriginalProfitEstimatedNull())
                            {
                                row.OriginalProfitEstimated = row.OriginalProfitEstimated / exchangeRate;
                            }

                            if (!row.IsInvoicedToDateNull())
                            {
                                row.InvoicedToDate = row.InvoicedToDate / exchangeRate;
                            }
                        }
                        else
                        {
                            if (!row.IsBillPriceNull())
                            {
                                row.BillPrice = row.BillPrice * exchangeRate;
                            }

                            if (!row.IsCostsIncurredNull())
                            {
                                row.CostsIncurred = row.CostsIncurred * exchangeRate;
                            }

                            if (!row.IsCostToCompleteNull())
                            {
                                row.CostToComplete = row.CostToComplete * exchangeRate;
                            }

                            if (!row.IsExtrasToDateNull())
                            {
                                row.ExtrasToDate = row.ExtrasToDate * exchangeRate;
                            }

                            if (!row.IsOriginalProfitEstimatedNull())
                            {
                                row.OriginalProfitEstimated = row.OriginalProfitEstimated * exchangeRate;
                            }

                            if (!row.IsInvoicedToDateNull())
                            {
                                row.InvoicedToDate = row.InvoicedToDate * exchangeRate;
                            }
                        }
                    }
                }

                // Set value to TotalAmountIncludingExtras
                if (!row.IsBillPriceNull())
                {
                    if (!row.IsExtrasToDateNull())
                    {
                        row.TotalAmountIncludingExtras = row.BillPrice + row.ExtrasToDate;
                    }
                    else
                    {
                        row.TotalAmountIncludingExtras = row.BillPrice;
                    }
                }
                else
                {
                    if (!row.IsExtrasToDateNull())
                    {
                        row.TotalAmountIncludingExtras = row.ExtrasToDate;
                    }
                }

                // Left to Invoice
                if (!row.IsTotalAmountIncludingExtrasNull())
                {
                    if (!row.IsInvoicedToDateNull())
                    {
                        row.LeftToInvoice = row.TotalAmountIncludingExtras - row.InvoicedToDate;
                    }
                    else
                    {
                        row.LeftToInvoice = row.TotalAmountIncludingExtras;
                    }
                }
                else
                {
                    row.SetLeftToInvoiceNull();
                }

                // Set value to % Completed
                if (!row.IsInvoicedToDateNull() && !row.IsTotalAmountIncludingExtrasNull())
                {
                    if (row.TotalAmountIncludingExtras > 0)
                    {
                        row.PercentageCompleted = Convert.ToInt32(Math.Round(((row.InvoicedToDate / row.TotalAmountIncludingExtras) * 100)));
                    }
                }
                else
                {
                    row.PercentageCompleted = 0;
                }
            }
        }



    }
}