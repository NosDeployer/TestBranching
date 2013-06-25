using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FlCXIRemovedReport
    /// </summary>
    public class FlCXIRemovedReport: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlCXIRemovedReport()
            : base("CXIRemovedReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlCXIRemovedReport(DataSet data)
            : base(data, "CXIRemovedReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlCXIRemovedReportTDS();
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
            FlCXIRemovedReportGateway flCXIRemovedReportGateway = new FlCXIRemovedReportGateway(Data);
            flCXIRemovedReportGateway.Load(companyId);

            UpdateFieldsForSections();
        }


        
        /// <summary>
        /// LoadByCountryId
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="companyId">companyId</param>
        public void LoadByCountryId(int countryId, int companyId)
        {
            FlCXIRemovedReportGateway flCXIRemovedReportGateway = new FlCXIRemovedReportGateway(Data);
            flCXIRemovedReportGateway.LoadByCountryId(countryId, companyId);

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
            foreach (FlCXIRemovedReportTDS.CXIRemovedReportRow row in (FlCXIRemovedReportTDS.CXIRemovedReportDataTable)Table)
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
            }
        }


        
    }
}