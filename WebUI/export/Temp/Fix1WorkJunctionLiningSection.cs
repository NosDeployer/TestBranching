using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.WebUI.export.Temp;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;

namespace LiquiForce.LFSLive.WebUI.export.Temp
{
    /// <summary>
    /// Fix1WorkJunctionLiningSection
    /// </summary>
    public class Fix1WorkJunctionLiningSection : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1WorkJunctionLiningSection()
            : base("LFS_WORK_JUNCTIONLINING_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1WorkJunctionLiningSection(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_SECTION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new Fix1WorkJuntionLiningSectionTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
              


        /// <summary>
        /// UpdateSection        
        /// <param name="companyId">companyId</param>
        public void UpdateSection(int companyId)
        {
            foreach (Fix1WorkJuntionLiningSectionTDS.LFS_WORK_JUNCTIONLINING_SECTIONRow row in (Fix1WorkJuntionLiningSectionTDS.LFS_WORK_JUNCTIONLINING_SECTIONDataTable)Table)
            {
                WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway();
                workJunctionLiningSectionGateway.LoadByWorkId(row.WorkID, companyId);

                // get old values of section
                int numLats = workJunctionLiningSectionGateway.GetNumLats(row.WorkID);
                int notLinedYet = workJunctionLiningSectionGateway.GetNotLinedYet(row.WorkID);
                bool allMeasured = workJunctionLiningSectionGateway.GetAllMeasured(row.WorkID);
                bool deleted = workJunctionLiningSectionGateway.GetDeleted(row.WorkID);
                string issueWithLaterals = workJunctionLiningSectionGateway.GetIssueWithLaterals(row.WorkID);
                int notMeasuredYet = workJunctionLiningSectionGateway.GetNotMeasuredYet(row.WorkID);
                int notDeliveredYet = workJunctionLiningSectionGateway.GetNotDeliveredYet(row.WorkID);
                string trafficControl = workJunctionLiningSectionGateway.GetTrafficControl(row.WorkID);
                string trafficControlDetails = workJunctionLiningSectionGateway.GetTrafficControlDetails(row.WorkID);
                bool standardBypass = workJunctionLiningSectionGateway.GetStandardBypass(row.WorkID);
                string standardBypassComments = workJunctionLiningSectionGateway.GetStandardBypassComments(row.WorkID);
                int availableToLine = workJunctionLiningSectionGateway.GetAvailableToLine(row.WorkID);

                //  get new values of section
                int newAvailableToLine = 0;

                // load laterals
                WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                workJunctionLiningLateralGateway.LoadBySectionWorkId(row.WorkID, companyId);

                int delivered = 0;
                int installed = 0;
                foreach (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALRow row1 in (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALDataTable)workJunctionLiningLateralGateway.Table)
                {
                    if ((!row1.Deleted) && (!row1.OutOfScope))
                    {
                        if (!row1.IsDeliveredNull())  delivered++;
                        if (!row1.IsLinerInstalledNull()) installed++;
                    }
                }

                if (numLats > 0)
                {
                    newAvailableToLine = delivered - installed;
                }

                // Update Work Juntion Lining Section
                WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(null);
                workJunctionLiningSection.UpdateDirect(row.WorkID, numLats, notLinedYet, allMeasured, deleted, issueWithLaterals, notMeasuredYet, notDeliveredYet, companyId, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, availableToLine, numLats, notLinedYet, allMeasured, issueWithLaterals, notMeasuredYet, notDeliveredYet, trafficControl, trafficControlDetails, standardBypass, standardBypassComments, newAvailableToLine);
            }
        }
    }
}
