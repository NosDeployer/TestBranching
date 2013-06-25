using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlLiningPlan
    /// </summary>
    public class JlLiningPlan : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlLiningPlan() : base("JlLiningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlLiningPlan(DataSet data)
            : base(data, "JlLiningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlLiningPlanTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="date_">date_</param>
        /// <param name="flusher">flusher</param>
        /// <param name="flusherMN">flusherMN</param>
        /// <param name="liner">liner</param>
        /// <param name="linerMN">linerMN</param>
        /// <param name="rotator">rotator</param>
        /// <param name="rotatorMN">rotatorMN</param>
        /// <param name="compressor">compressor</param>
        /// <param name="compressorMN">compressorMN</param>
        /// <param name="selected">selected</param>
        /// <param name="flowOrderId">flowOderId</param>
        /// <param name="standardBypassComments">standardBypassComments</param>
        /// <param name="trafficControlDetails">trafficControlDetails</param>
        public void UpdateForReport(int assetId, int companyId, DateTime? date_, string flusher, string flusherMN, string liner, string linerMN, string rotator, string rotatorMN, string compressor, string compressorMN, string selected, string flowOrderId, string standardBypassComments, string trafficControlDetails)
        {
            JlLiningPlanTDS.JlLiningPlanRow jlLiningPlanRow = GetRow(assetId, companyId);

            if (date_.HasValue) jlLiningPlanRow.Date_ = (DateTime)date_; else jlLiningPlanRow.SetDate_Null();
            jlLiningPlanRow.Flusher = flusher;
            jlLiningPlanRow.FlusherMN = flusherMN.Trim();
            jlLiningPlanRow.Liner = liner;
            jlLiningPlanRow.LinerMN = linerMN.Trim();
            jlLiningPlanRow.Rotator = rotator;
            jlLiningPlanRow.RotatorMN = rotatorMN.Trim();
            jlLiningPlanRow.Compressor = compressor;
            jlLiningPlanRow.CompressorMN = compressorMN.Trim();
            jlLiningPlanRow.Selected = selected;
            jlLiningPlanRow.FlowOrderID = flowOrderId;
            jlLiningPlanRow.StandardBypassComments = standardBypassComments;
            jlLiningPlanRow.TrafficControlDetails = trafficControlDetails;
        }
        

        
        /// <summary>
        /// ProcessForReport
        /// </summary>
        /// <param name="jlLiningPlanTDS">TDS for process</param>
        public void ProcessForReport(JlLiningPlanTDS jlLiningPlanTDS)
        {
            JlLiningPlanJlinerGateway jlLiningPlanJlinerGateway = new JlLiningPlanJlinerGateway(Data);
            jlLiningPlanJlinerGateway.ClearBeforeFill = false;
            JlLiningPlanJliner jlLiningPlanJliner = new JlLiningPlanJliner(Data);

            foreach (JlLiningPlanTDS.JlLiningPlanRow jlLiningPlanRow in jlLiningPlanTDS.JlLiningPlan.Rows)
            {
                if (jlLiningPlanRow.Selected != "9")
                {
                    // Create row for report
                    JlLiningPlanTDS.JlLiningPlanRow newRow = ((JlLiningPlanTDS.JlLiningPlanDataTable)Table).NewJlLiningPlanRow();

                    newRow.AssetID = jlLiningPlanRow.AssetID;
                    newRow.COMPANY_ID = jlLiningPlanRow.COMPANY_ID;
                    newRow.SectionID = jlLiningPlanRow.SectionID;
                    if (!jlLiningPlanRow.IsStreetNull()) newRow.Street = jlLiningPlanRow.Street;
                    if (!jlLiningPlanRow.IsSize_Null())
                    {
                        if (Distance.IsValidDistance(jlLiningPlanRow.Size_))
                        {
                            Distance distance = new Distance(jlLiningPlanRow.Size_);

                            switch (distance.DistanceType)
                            {
                                case 2:
                                    jlLiningPlanRow.Size_ = distance.ToStringInEng1();
                                    break;
                                case 3:
                                    if (Convert.ToDouble(jlLiningPlanRow.Size_) > 99)
                                    {
                                        double newSize_ = 0;
                                        newSize_ = Convert.ToDouble(jlLiningPlanRow.Size_) * 0.03937;
                                        jlLiningPlanRow.Size_ = Convert.ToString(Math.Ceiling(newSize_)) + "\"";
                                    }
                                    else
                                    {
                                        jlLiningPlanRow.Size_ = jlLiningPlanRow.Size_ + "\"";
                                    }
                                    break;
                                case 4:
                                    jlLiningPlanRow.Size_ = distance.ToStringInEng1();
                                    break;
                                case 5:
                                    jlLiningPlanRow.Size_ = distance.ToStringInEng1();
                                    break;
                            }
                        }
                    }
                    if (!jlLiningPlanRow.IsStandardBypassNull()) newRow.StandardBypass = jlLiningPlanRow.StandardBypass;
                    if (!jlLiningPlanRow.IsTrafficControlNull()) newRow.TrafficControl = jlLiningPlanRow.TrafficControl;
                    if (!jlLiningPlanRow.IsNumLatsNull()) newRow.NumLats = jlLiningPlanRow.NumLats;
                    if (!jlLiningPlanRow.IsNotLinedYetNull()) newRow.NotLinedYet = jlLiningPlanRow.NotLinedYet;
                    if (!jlLiningPlanRow.IsLengthNull()) newRow.Length = jlLiningPlanRow.Length;
                    if (!jlLiningPlanRow.IsUSMHNull()) newRow.USMH = jlLiningPlanRow.USMH;
                    if (!jlLiningPlanRow.IsDSMHNull()) newRow.DSMH = jlLiningPlanRow.DSMH;
                    if (!jlLiningPlanRow.IsAllMeasuredNull()) newRow.AllMeasured = jlLiningPlanRow.AllMeasured;
                    if (!jlLiningPlanRow.IsDate_Null()) newRow.Date_ = jlLiningPlanRow.Date_;
                    if (!jlLiningPlanRow.IsFlusherNull()) newRow.Flusher = jlLiningPlanRow.Flusher;
                    if (!jlLiningPlanRow.IsFlusherMNNull()) newRow.FlusherMN = jlLiningPlanRow.FlusherMN;
                    if (!jlLiningPlanRow.IsLinerNull()) newRow.Liner = jlLiningPlanRow.Liner;
                    if (!jlLiningPlanRow.IsLinerMNNull()) newRow.LinerMN = jlLiningPlanRow.LinerMN;
                    if (!jlLiningPlanRow.IsRotatorNull()) newRow.Rotator = jlLiningPlanRow.Rotator;
                    if (!jlLiningPlanRow.IsRotatorMNNull()) newRow.RotatorMN = jlLiningPlanRow.RotatorMN;
                    if (!jlLiningPlanRow.IsCompressorNull()) newRow.Compressor = jlLiningPlanRow.Compressor;
                    if (!jlLiningPlanRow.IsCompressorMNNull()) newRow.CompressorMN = jlLiningPlanRow.CompressorMN;
                    if (!jlLiningPlanRow.IsUSMHDescriptionNull()) newRow.USMHDescription = jlLiningPlanRow.USMHDescription; else newRow.SetUSMHDescriptionNull();
                    if (!jlLiningPlanRow.IsDSMHDescriptionNull()) newRow.DSMHDescription = jlLiningPlanRow.DSMHDescription; else newRow.SetDSMHDescriptionNull();
                    if (!jlLiningPlanRow.IsUSMHAddressNull()) newRow.USMHAddress = jlLiningPlanRow.USMHAddress; else newRow.SetUSMHAddressNull();
                    if (!jlLiningPlanRow.IsDSMHAddressNull()) newRow.DSMHAddress = jlLiningPlanRow.DSMHAddress; else newRow.SetDSMHAddressNull();
                    newRow.Selected = jlLiningPlanRow.Selected;
                    newRow.FlowOrderID = jlLiningPlanRow.FlowOrderID;
                    newRow.StandardBypassComments = jlLiningPlanRow.StandardBypassComments;
                    newRow.TrafficControlDetails = jlLiningPlanRow.TrafficControlDetails;

                    ((JlLiningPlanTDS.JlLiningPlanDataTable)Table).AddJlLiningPlanRow(newRow);

                    // Select jliners for report
                    foreach (JlLiningPlanTDS.JlLiningPlanJlinerRow jlLiningPlanJlinerRow in jlLiningPlanTDS.JlLiningPlanJliner.Rows)
                    {
                        if (jlLiningPlanJlinerRow.Selected != 30)
                        {
                            jlLiningPlanJlinerGateway.LoadBySection_AssetIdAndLateralOrder(jlLiningPlanRow.AssetID, jlLiningPlanRow.COMPANY_ID, newRow.LinerMN, jlLiningPlanJlinerRow.Selected, jlLiningPlanRow.Selected, jlLiningPlanJlinerRow.AssetID);   
                        }
                    }

                    jlLiningPlanJliner.UpdateForReport(jlLiningPlanRow.COMPANY_ID);
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single LinningPlanRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Row obtained</returns>
        private JlLiningPlanTDS.JlLiningPlanRow GetRow(int assetId, int companyId)
        {
            JlLiningPlanTDS.JlLiningPlanRow jlLiningPlanRow = ((JlLiningPlanTDS.JlLiningPlanDataTable)Table).FindByAssetIDCOMPANY_ID(assetId, companyId);

            if (jlLiningPlanRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.JlLiningPlan.GetRow");
            }

            return jlLiningPlanRow;
        }



    }
}