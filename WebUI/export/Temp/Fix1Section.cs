using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// Fix1Section
    /// </summary>
    public class Fix1Section : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1Section()
            : base("LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1Section(DataSet data)
            : base(data, "LFS_MASTER_AREA")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new Fix1TDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// SectionUpdate
        /// </summary>
        public void SectionUpdate()
        {
            foreach (Fix1TDS.LFS_MASTER_AREARow masterAreaRow in (Fix1TDS.LFS_MASTER_AREADataTable)Table)
            {
                LinningPlanGateway liningPlanGateway = new LinningPlanGateway();
                Fix1JlinerGateway fix1JlinerGateway = new Fix1JlinerGateway();
                fix1JlinerGateway.LoadByIdCompanyId(masterAreaRow.ID, masterAreaRow.COMPANY_ID);

                Fix1Jliner fix1Jliner = new Fix1Jliner(fix1JlinerGateway.Data);

                // Update variables
                int numLats = fix1Jliner.GetNumLats(masterAreaRow.ID, masterAreaRow.COMPANY_ID);
                int notLinedYeet = fix1Jliner.GetNotLinedYet(masterAreaRow.ID, masterAreaRow.COMPANY_ID);
                bool allMeasured = fix1Jliner.GetAllMeasured(masterAreaRow.ID, masterAreaRow.COMPANY_ID);
                int notMeasuredYet = fix1Jliner.GetNotMeasuredYet(masterAreaRow.ID, masterAreaRow.COMPANY_ID);
                int notDeliveredYet = fix1Jliner.GetNotDeliveredYet(masterAreaRow.ID, masterAreaRow.COMPANY_ID);

                masterAreaRow.NumLats = numLats;
                masterAreaRow.NotLinedYet = notLinedYeet;
                masterAreaRow.AllMeasured = (numLats == 0) ? false : allMeasured;
                masterAreaRow.NotMeasuredYet = notMeasuredYet;
                masterAreaRow.NotDeliveredYet = notDeliveredYet;
                
                // Update IssueWithtLaterals
                Guid rowId = masterAreaRow.ID;
                if (liningPlanGateway.IsLateralsIssueNo(rowId))
                {
                    masterAreaRow.IssueWithLaterals = "No";
                }
                else
                {
                    if (liningPlanGateway.IsLateralsIssueOutOfScope(rowId))
                    {
                        masterAreaRow.IssueWithLaterals = "Out Of Scope";
                    }
                    else
                    {
                        if (liningPlanGateway.IsLateralsIssueYesOutOfScope(rowId))
                        {
                            masterAreaRow.IssueWithLaterals = "Yes, Out Of Scope";
                        }
                        else
                        {
                            if (liningPlanGateway.IsLateralsIssueYes(rowId))
                            {
                                masterAreaRow.IssueWithLaterals = "Yes";
                            }
                        }
                    }
                }
            }
        }


        



        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private Fix1TDS.LFS_MASTER_AREARow GetRow(Guid id, int companyId)
        {
            Fix1TDS.LFS_MASTER_AREARow row = ((Fix1TDS.LFS_MASTER_AREADataTable)Table).FindByIDCOMPANY_ID(id, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.WebUI.Fix1Section.GetRow");
            }

            return row;
        }





    }
}
