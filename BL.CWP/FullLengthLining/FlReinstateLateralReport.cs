using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlReinstateLateralReport
    /// </summary>
    public class FlReinstateLateralReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlReinstateLateralReport()
            : base("ReinstateLateral")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlReinstateLateralReport(DataSet data)
            : base(data, "ReinstateLateral")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlReinstateReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="unitType">unitType</param>
        /// <param name="measurementFromMH">measurementFromMH</param>
        public void UpdateForReport(string flowOrderId, string unitType, string measurementFromMH)
        {
            foreach (FlReinstateReportTDS.ReinstateLateralRow row in (FlReinstateReportTDS.ReinstateLateralDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }

                Distance d;

                if (unitType == "Metric")
                {
                    if (!row.IsSize_Null())
                    {
                        d = new Distance(row.Size_);
                        row.Size_ = d.ToStringInMet1();
                    }

                    if (!row.IsDistanceFromUSMHNull())
                    {
                        d = new Distance(row.DistanceFromUSMH);
                        row.DistanceFromUSMH = d.ToStringInMet1();
                    }

                    if (!row.IsDistanceFromDSMHNull())
                    {
                        d = new Distance(row.DistanceFromDSMH);
                        row.DistanceFromDSMH = d.ToStringInMet1();
                    }
                }

                if (unitType == "Imperial")
                {
                    if (!row.IsSize_Null())
                    {
                        if (Distance.IsValidDistance(row.Size_))
                        {
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

                    if (!row.IsDistanceFromUSMHNull())
                    {
                        d = new Distance(row.DistanceFromUSMH);
                        row.DistanceFromUSMH = d.ToStringInEng2();
                    }

                    if (!row.IsDistanceFromDSMHNull())
                    {
                        d = new Distance(row.DistanceFromDSMH);
                        row.DistanceFromDSMH = d.ToStringInEng2();
                    }
                }

                // Update flow order
                if (row.FlowOrderIDLateralID == "")
                {
                    row.FlowOrderIDLateralID = flowOrderId + "-FL-" + row.LateralID;
                }

                // Update Reverse Clock Position
                TimeSpan timeToSubstract = TimeSpan.Parse("12:00");
                string clock = ""; if (!row.IsClockPositionNull()) clock = row.ClockPosition;
                
                if (clock != "")
                {
                    if (clock != "12" && clock != "12:00" && clock != "6" && clock != "6:00" && clock != "06:00")
                    {
                        try
                        {
                            DateTime time = DateTime.Parse(clock);
                            row.ReverseClockPosition = timeToSubstract.Subtract(new TimeSpan(time.Hour, time.Minute, 0)).ToString().Remove(5);
                        }
                        catch
                        {
                            if (Tools.Validator.IsValidInt32(clock))
                            {
                                int hour = int.Parse(clock);
                                row.ReverseClockPosition = timeToSubstract.Subtract(new TimeSpan(hour, 0, 0)).ToString().Remove(5);
                            }
                            else
                            {
                                row.ReverseClockPosition = clock;
                            }
                        }
                    }
                    else
                    {
                        if (clock == "12:00" || clock == "06:00" || clock == "6:00")
                        {
                            if (clock == "6:00")
                            {
                                row.ReverseClockPosition = "06:00";
                            }
                            else
                            {
                                row.ReverseClockPosition = clock;
                            }
                        }
                        else
                        {
                            try
                            {
                                row.ReverseClockPosition = DateTime.Parse(clock).ToString().Remove(5);
                            }
                            catch
                            {
                                if (Tools.Validator.IsValidInt32(clock))
                                {
                                    int hour = int.Parse(clock);
                                    row.ReverseClockPosition = new TimeSpan(hour, 0, 0).ToString().Remove(5);
                                }
                                else
                                {
                                    row.ReverseClockPosition = clock;
                                }
                            }
                        }
                    }
                }

                if (measurementFromMH == "DSMH")
                {
                    string auxDistanceFromUSMH = row.DistanceFromUSMH;
                    row.DistanceFromUSMH = row.DistanceFromDSMH;
                    row.DistanceFromDSMH = auxDistanceFromUSMH;
                }
            }            
        }



    }
}