using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlM1LateralReport
    /// </summary>
    public class FlM1LateralReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM1LateralReport()
            : base("M1_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlM1LateralReport(DataSet data)
            : base(data, "M1_LATERAL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM1ReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="unitType">unitType</param>
        public void UpdateForReport(string flowOrderId, string unitType)
        {
            foreach (FlM1ReportTDS.M1_LATERALRow row in (FlM1ReportTDS.M1_LATERALDataTable)Table)
            {
                Distance d;

                if (!row.IsVideoDistanceNull())
                {
                    if (Distance.IsValidDistance(row.VideoDistance))
                    {
                        d = new Distance(row.VideoDistance);

                        try
                        {
                            row.VideoDistanceDouble = d.ToDoubleInEng3();
                        }
                        catch
                        {
                            row.VideoDistanceDouble = Convert.ToDouble(row.VideoDistance);
                        }
                    }
                }

                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }                

                if (unitType == "Metric")
                {
                    if (!row.IsDistanceFromUSMHNull())
                    {
                        d = new Distance(row.DistanceFromUSMH);
                        row.DistanceFromUSMH = d.ToStringInMet2();
                    }

                    if (!row.IsDistanceFromDSMHNull())
                    {
                        d = new Distance(row.DistanceFromDSMH);
                        row.DistanceFromDSMH = d.ToStringInMet2();
                    }

                    if (!row.IsVideoDistanceNull())
                    {
                        d = new Distance(row.VideoDistance);
                        row.VideoDistance = d.ToStringInMet2();
                    }

                    if (!row.IsDistanceToCentreNull())
                    {
                        d = new Distance(row.DistanceToCentre);
                        row.DistanceToCentre = d.ToStringInMet2();
                    }

                    if (!row.IsReverseSetupNull())
                    {
                        d = new Distance(row.ReverseSetup);
                        row.ReverseSetup = d.ToStringInMet2();
                    }

                    if (!row.IsSize_Null())
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {
                            d = new Distance(row.Size_);
                            row.Size_ = d.ToStringInMet2();
                        }
                    }
                }

                if (unitType == "Imperial")
                {                   
                    if (!row.IsDistanceFromUSMHNull())
                    {
                        d = new Distance(row.DistanceFromUSMH);
                        row.DistanceFromUSMH = d.ToStringInEng1();
                    }

                    if (!row.IsDistanceFromDSMHNull())
                    {
                        d = new Distance(row.DistanceFromDSMH);
                        row.DistanceFromDSMH = d.ToStringInEng1();
                    }

                    if (!row.IsVideoDistanceNull())
                    {
                        d = new Distance(row.VideoDistance);
                        row.VideoDistance = d.ToStringInEng1();
                    }

                    if (!row.IsDistanceToCentreNull())
                    {
                        d = new Distance(row.DistanceToCentre);
                        row.DistanceToCentre = d.ToStringInEng1();
                    }

                    if (!row.IsReverseSetupNull())
                    {
                        d = new Distance(row.ReverseSetup);
                        row.ReverseSetup = d.ToStringInEng1();
                    }

                    if (!row.IsSize_Null())
                    {
                        try
                        {
                            if (Distance.IsValidDistance(row.Size_))                            {
                                
                                Distance distance = new Distance(row.Size_);

                                switch (distance.DistanceType)
                                {
                                    case 2:
                                        row.Size_ = distance.ToStringInEng1();
                                        break;
                                    case 3:
                                        if (Convert.ToDouble(row.Size_) > 99)
                                        {
                                            double newSize_ = 0;
                                            newSize_ = Convert.ToDouble(row.Size_) * 0.03937;
                                            row.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                        }
                                        else
                                        {
                                            row.Size_ = row.Size_ + "\"";
                                        }
                                        break;
                                    case 4:
                                        row.Size_ = distance.ToStringInEng1();
                                        break;
                                    case 5:
                                        row.Size_ = distance.ToStringInEng1();
                                        break;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                }

                // Update flow order
                if (row.FlowOrderIDLateralID == "")
                {
                    row.FlowOrderIDLateralID = flowOrderId + "-FL-" + row.LateralID;
                }
            }            
        }



    }
}
