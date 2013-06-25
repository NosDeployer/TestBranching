using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlLiningPlanJliner
    /// </summary>
    public class JlLiningPlanJliner : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlLiningPlanJliner() : base("JlLiningPlanJliner")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlLiningPlanJliner(DataSet data)
            : base(data, "JlLiningPlanJliner")
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
        /// Load liners
        /// </summary>
        /// <param name="jlLiningPlanTDS">jlLiningPlanTDS</param>       
        /// <param name="companyId">companyId</param>
        public void LoadLiners(JlLiningPlanTDS jlLiningPlanTDS, int companyId)
        {
            JlLiningPlanJlinerGateway jlLiningPlanJlinerGateway = new JlLiningPlanJlinerGateway(jlLiningPlanTDS.JlLiningPlanJliner.DataSet);
            jlLiningPlanJlinerGateway.ClearBeforeFill = false;
            JlLiningPlanJliner jlLiningPlanJliner = new JlLiningPlanJliner(jlLiningPlanTDS.JlLiningPlanJliner.DataSet);

            foreach (JlLiningPlanTDS.JlLiningPlanRow jlLiningPlanRow in jlLiningPlanTDS.JlLiningPlan.Rows)
            {
                if (jlLiningPlanRow.Selected != "9")
                {
                    string linerMN = jlLiningPlanRow.LinerMN;

                    jlLiningPlanJlinerGateway.LoadByAssetIdMnSelected(jlLiningPlanRow.AssetID, jlLiningPlanRow.COMPANY_ID, linerMN, jlLiningPlanRow.Selected);
                    jlLiningPlanJliner.UpdateForReport(companyId);
                }
            }
        }



        /// <summary>
        /// Update a liner
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="section_">section_</param>        
        /// <param name="companyId">companyId</param>
        /// <param name="selected">selected</param>        
        public void Update(int assetId, int section_, int companyId, int selected)
        {
            JlLiningPlanTDS.JlLiningPlanJlinerRow row = GetRow(assetId, section_, companyId);
            row.Selected = selected;
        }

        

        /// <summary>
        /// UpdateForReport
        /// </summary>        
        /// <param name="companyId">companyId</param>
        public void UpdateForReport(int companyId)
        {
            foreach (JlLiningPlanTDS.JlLiningPlanJlinerRow row in (JlLiningPlanTDS.JlLiningPlanJlinerDataTable)Table)
            {
                // Update comments
                int jlWorkId = row.SectionWorkID;
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(jlWorkId, companyId);
                int assetId = workGateway.GetAssetId(jlWorkId);
                int projectId = workGateway.GetProjectId(jlWorkId);

                // ... Get raWorkId
                int raWorkId = 0;
                WorkGateway raWorkGateway = new WorkGateway();
                raWorkGateway.LoadByProjectIdAssetIdWorkType(projectId, row.Section_, "Rehab Assessment", companyId);
                if (raWorkGateway.Table.Rows.Count > 0)
                {
                    raWorkId = raWorkGateway.GetWorkId(row.Section_, "Rehab Assessment", projectId);
                }

                // ... Get raWorkId
                int flWorkId = 0;
                WorkGateway flWorkGateway = new WorkGateway();
                flWorkGateway.LoadByProjectIdAssetIdWorkType(projectId, row.Section_, "Full Length Lining", companyId);
                if (flWorkGateway.Table.Rows.Count > 0)
                {
                    flWorkId = flWorkGateway.GetWorkId(row.Section_, "Full Length Lining", projectId);
                }

                // ... Load All Comments
                FlatSectionJLAllComments flatSectionJLAllComments = new FlatSectionJLAllComments();
                flatSectionJLAllComments.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                row.Comments = flatSectionJLAllComments.GetJLOrFLOrRAComments(companyId, flatSectionJLAllComments.Table.Rows.Count, "\n");

                // Add M1 comments
                WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
                workFullLengthLiningM1LateralGateway.LoadByWorkIdLateral(flWorkId, row.AssetID, companyId);
                if (workFullLengthLiningM1LateralGateway.Table.Rows.Count > 0)
                {
                    string m1LateralComment = workFullLengthLiningM1LateralGateway.GetComments(flWorkId, row.AssetID);
                    if (m1LateralComment != "")
                    {
                        row.Comments = row.Comments + "\n\nType: M1 Lateral Comments\nComment: " + m1LateralComment;
                    }
                }

                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }

                // Round PullInDistance                
                if (Validator.IsValidDecimal(row.PullInDistance))
                {
                    row.PullInDistance = decimal.Round(decimal.Parse(row.PullInDistance), 1).ToString();
                }
                else
                {
                    row.PullInDistance = "0";
                }

                // Update Main size
                if (!row.IsMainSizeNull())
                {
                    if (Distance.IsValidDistance(row.MainSize))
                    {
                        Distance distance = new Distance(row.MainSize);

                        switch (distance.DistanceType)
                        {
                            case 2:
                                row.MainSize = distance.ToStringInEng1();
                                break;
                            case 3:
                                if (Convert.ToDouble(row.MainSize) > 99)
                                {
                                    double newMainSize = 0;
                                    newMainSize = Convert.ToDouble(row.MainSize) * 0.03937;
                                    row.MainSize = Convert.ToString(Math.Ceiling(newMainSize)) + "\"";
                                }
                                else
                                {
                                    row.MainSize = row.MainSize + "\"";
                                }
                                break;
                            case 4:
                                row.MainSize = distance.ToStringInEng1();
                                break;
                            case 5:
                                row.MainSize = distance.ToStringInEng1();
                                break;
                        }
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single comment. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="section_">section_</param>
        /// <param name="companyId">companyId</param>
        /// <returns>JlLiningPlanTDS.JlLiningPlanJlinerRow</returns>
        private JlLiningPlanTDS.JlLiningPlanJlinerRow GetRow(int assetId, int section_, int companyId)
        {
            JlLiningPlanTDS.JlLiningPlanJlinerRow row = ((JlLiningPlanTDS.JlLiningPlanJlinerDataTable)Table).FindByAssetIDSection_COMPANY_ID(assetId, section_, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.JLiningPlanJliner.GetRow");
            }

            return row;
        }



    }
}