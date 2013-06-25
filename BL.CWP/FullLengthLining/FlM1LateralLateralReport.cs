using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    public class FlM1LateralLateralReport : TableModule
    {
// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlM1LateralLateralReport()
            : base("M1_LATERAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlM1LateralLateralReport(DataSet data)
            : base(data, "M1_LATERAL")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlM1LateralReportTDS();
        }
        



        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="flowOrderId">flowOrderId</param>
        /// <param name="unitType">unitType</param>
        public void UpdateForReport(string flowOrderId, string unitType)
        {
            foreach (FlM1LateralReportTDS.M1_LATERALRow row in (FlM1LateralReportTDS.M1_LATERALDataTable)Table)
            {
                // Update flow order
                if (row.FlowOrderIDLateralID == "")
                {
                    row.FlowOrderIDLateralID = flowOrderId + "-FL-" + row.LateralID;
                }

                if (!row.IsTimeOpenedNull())
                {
                    if (Validator.IsValidDate(row.TimeOpened))
                    {
                        DateTime validDate = DateTime.Parse(row.TimeOpened);
                        row.TimeOpened = validDate.ToShortDateString();
                    }
                }
            }
        }



    }
}