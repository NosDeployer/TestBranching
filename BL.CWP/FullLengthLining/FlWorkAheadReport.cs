using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlWorkAheadReport
    /// </summary>
    public class FlWorkAheadReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlWorkAheadReport()
            : base("WorkAhead")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlWorkAheadReport(DataSet data)
            : base(data, "WorkAhead")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FLWorkAheadReportTDS();
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
            FlWorkAheadReportGateway flWorkAheadReportGateway = new FlWorkAheadReportGateway(Data);
            flWorkAheadReportGateway.Load(companyId);

            UpdateForReport();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        private void UpdateForReport()
        {
            double total = 0.0F;
            double totalConfirmed = 0;
            Distance d;

            foreach (FLWorkAheadReportTDS.WorkAheadRow rowTemp in (FLWorkAheadReportTDS.WorkAheadDataTable)Table)
            {
                if (!rowTemp.IsMapLengthNull())
                {
                    if (Distance.IsValidDistance(rowTemp.MapLength))
                    {
                        d = new Distance(rowTemp.MapLength);
                        total = total + d.ToDoubleInEng3();
                    }
                }

                if (!rowTemp.IsSize_Null())
                {
                    if (Distance.IsValidDistance(rowTemp.Size_))
                    {
                        d = new Distance(rowTemp.Size_);
                        totalConfirmed = totalConfirmed + d.ToDoubleInEng3();
                    }
                }                
            }

            foreach (FLWorkAheadReportTDS.WorkAheadRow row in (FLWorkAheadReportTDS.WorkAheadDataTable)Table)
            {
                if (!row.IsMapLengthNull())
                {
                    if (Distance.IsValidDistance(row.MapLength))
                    {
                        d = new Distance(row.MapLength);
                        row.SumScaled = Math.Round(d.ToDoubleInEng3(), 2);
                    }
                }

                if (!row.IsSize_Null())
                {
                    if (Distance.IsValidDistance(row.Size_))
                    {
                        try
                        {
                            d = new Distance(row.Size_);
                            row.SumConfirmed = Convert.ToInt32(d.ToStringInEng3());
                        }
                        catch
                        {
                            row.SumConfirmed = 0;
                        }
                    }
                } 

                row.TotalAhead = Math.Round(total, 2);
                row.TotalAhead2 = totalConfirmed;
            }
        }
        
      
        
    }
}