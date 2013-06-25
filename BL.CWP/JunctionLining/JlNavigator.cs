using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// JlNavigator
    /// </summary>
    public class JlNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlNavigator()
            : base("JlNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlNavigator(DataSet data)
            : base(data, "JlNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        /// <param name="conditionValue">conditionValue</param>
        /// <param name="textForSearch">textForSearch</param>
        /// <param name="conditionValue2">conditionValue2</param>
        /// <param name="textForSearch2">textForSearch2</param>
        /// <param name="projectId">COMPANY_ID</param>
        /// <param name="currentProjectId">projectId</param>
        /// <param name="workType">workType</param>
        public void Load(string whereClause, string orderByClause, string conditionValue, string textForSearch, string conditionValue2, string textForSearch2, int companyId, int projectId, string workType)
        {
            JlNavigatorGateway jlNavigatorGateway = new JlNavigatorGateway(Data);
            jlNavigatorGateway.LoadWhereOrderBy(whereClause, orderByClause, conditionValue, textForSearch, conditionValue2, textForSearch2);

            UpdateFieldsForSections(projectId, companyId);
        }



        /// <summary>
        /// LoadForViewsProjectIdCompanyIdWorkType
        /// </summary>
        /// <param name="sqlCommand">sqlCommand</param>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="workType">workType</param>
        public void LoadForViewsProjectIdCompanyIdWorkType(string sqlCommand, int projectId, int companyId, string workType)
        {
            JlNavigatorGateway jlNavigatorGateway = new JlNavigatorGateway(Data);
            jlNavigatorGateway.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, projectId, companyId, workType);

            UpdateFieldsForSections(projectId, companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="selected">selected</param>
        public void Update(int assetId, bool selected)
        {
            JlNavigatorTDS.JlNavigatorRow jlNavigatorRow = GetRow(assetId);
            jlNavigatorRow.Selected = selected;
        }



        /// <summary>
        /// UpdateCommentsHistory
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="projectId">projectId</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newHistory">newHistory</param>
        /// <param name="companyId">companyId</param>
        public void UpdateCommentsHistory(int workId, int assetId, int projectId, string newComments, string newHistory, int companyId)
        {
            JlNavigatorTDS.JlNavigatorRow jlNavigatorRow = GetRow(assetId);
            jlNavigatorRow.Comments = newComments;
            jlNavigatorRow.History = newHistory;

            // Save work
            // ... Get original variables
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            string originalWorkType = workGateway.GetWorkTypeOriginal(workId);
            int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(workId);
            string originalComment = workGateway.GetCommentsOriginal(workId);
            string originalHistory = workGateway.GetHistoryOriginal(workId);

            Work work = new Work(null);
            work.UpdateDirect(workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, newComments, newHistory);
        }



        /// <summary>
        /// UpdateComments
        /// </summary>
        /// <param name="jlWorkId">workIdjlWorkIdparam>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        public void UpdateComments(int jlWorkId, string workType, int companyId)
        {
            foreach (JlNavigatorTDS.JlNavigatorRow row in (JlNavigatorTDS.JlNavigatorDataTable)Table)
            {
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(jlWorkId, companyId);
                int assetId = workGateway.GetAssetId(jlWorkId);
                int projectId = workGateway.GetProjectId(jlWorkId);

                if (row.AssetID_ == assetId)
                {
                    // Update Comments
                    // ... Get raWorkId
                    int raWorkId = 0;

                    // ... Get raWorkId
                    int flWorkId = 0;
                    
                    // ... Load All Comments
                    FlatSectionJLAllComments flatSectionJLAllComments = new FlatSectionJLAllComments();
                    flatSectionJLAllComments.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                    row.Comments = flatSectionJLAllComments.GetJLOrFLOrRAComments(companyId, flatSectionJLAllComments.Table.Rows.Count, "\n");

                    if (!row.IsHistoryNull())
                    {
                        row.Comments = row.Comments.Replace("<br>", "\n");
                    }                    
                    
                    // Update History
                    FlatSectionJLAllHistory flatSectionJLAllHistory = new FlatSectionJLAllHistory();
                    flatSectionJLAllHistory.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                    row.History = flatSectionJLAllHistory.GetJLOrFLOrRAHistory(companyId, flatSectionJLAllHistory.Table.Rows.Count, "\n");

                    if (!row.IsHistoryNull())
                    {
                        row.History = row.History.Replace("<br>", "\n");
                    }

                    // Save work
                    // ... Get original variables
                    workGateway.LoadByWorkId(jlWorkId, companyId);

                    string originalWorkType = workGateway.GetWorkTypeOriginal(jlWorkId);
                    int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(jlWorkId);
                    string originalComment = workGateway.GetCommentsOriginal(jlWorkId);
                    string originalHistory = workGateway.GetHistoryOriginal(jlWorkId);

                    Work work = new Work(null);
                    work.UpdateDirect(jlWorkId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, jlWorkId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, row.Comments, row.History);
                }
            }
        }



        /// <summary>
        /// UpdateEnterForReport
        /// </summary>     
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateEnterForReport(int projectId, int companyId)
        {
            foreach (JlNavigatorTDS.JlNavigatorRow row in (JlNavigatorTDS.JlNavigatorDataTable)Table)
            {
                // Update Comments
                // ... Get raWorkId
                int raWorkId = 0;
                WorkGateway raWorkGateway = new WorkGateway();
                raWorkGateway.LoadByProjectIdAssetIdWorkType(projectId, row.Section_, "Rehab Assessment", companyId);
                if (raWorkGateway.Table.Rows.Count > 0)
                {
                    raWorkId = raWorkGateway.GetWorkId(row.Section_, "Rehab Assessment", projectId);
                }

                // ... Get flWorkId
                int flWorkId = 0;
                WorkGateway flWorkGateway = new WorkGateway();
                flWorkGateway.LoadByProjectIdAssetIdWorkType(projectId, row.Section_, "Full Length Lining", companyId);
                if (flWorkGateway.Table.Rows.Count > 0)
                {
                    flWorkId = flWorkGateway.GetWorkId(row.Section_, "Full Length Lining", projectId);
                }

                // ... Load All Comments
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByProjectIdAssetIdWorkType(projectId, row.AssetID_, "Junction Lining Lateral", companyId);
                int jlWorkId = workGateway.GetWorkId(row.AssetID_, "Junction Lining Lateral", projectId);

                FlatSectionJLAllComments flatSectionJLAllComments = new FlatSectionJLAllComments();
                flatSectionJLAllComments.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                row.Comments = flatSectionJLAllComments.GetJLOrFLOrRAComments(companyId, flatSectionJLAllComments.Table.Rows.Count, "\n");
                
                // Add M1 comments
                WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
                workFullLengthLiningM1LateralGateway.LoadByWorkIdLateral(flWorkId, row.AssetID_, companyId);
                if (workFullLengthLiningM1LateralGateway.Table.Rows.Count > 0)
                {
                    string m1LateralComments = workFullLengthLiningM1LateralGateway.GetComments(flWorkId, row.AssetID_);
                    if (m1LateralComments != "")
                    {
                        if (row.Comments.Length > 0)
                        {
                            row.Comments = row.Comments + "\n\nType: M1 Lateral Comments\nComment: " + m1LateralComments;
                        }
                        else
                        {
                            row.Comments = row.Comments + "Type: M1 Lateral Comments\nComment: " + m1LateralComments;
                        }
                    }
                }

                WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway();
                workFullLengthLiningM1Gateway.LoadByWorkId(flWorkId, companyId);
                if (workFullLengthLiningM1Gateway.Table.Rows.Count > 0)
                {
                    string trafficControlDetails = workFullLengthLiningM1Gateway.GetTrafficControlDetails(flWorkId);
                    if (trafficControlDetails != "")
                    {
                        if (row.Comments.Length > 0)
                        {
                            row.Comments = row.Comments + "\n\nType: Traffic Control Details\nComment: " + trafficControlDetails;
                        }
                        else
                        {
                            row.Comments = row.Comments + "Type: Traffic Control Details\nComment: " + trafficControlDetails;
                        }
                    }

                    string standardByPassComments = workFullLengthLiningM1Gateway.GetStandardBypassComments(flWorkId);
                    if (standardByPassComments != "")
                    {
                        if (row.Comments.Length > 0)
                        {
                            row.Comments = row.Comments + "\n\nType: Standard Bypass Comments\nComment: " + standardByPassComments;
                        }
                        else
                        {
                            row.Comments = row.Comments + "Type: Standard Bypass Comments\nComment: " + standardByPassComments;
                        }
                    }
                } 

                // Update Comments
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");

                    if (row.Comments.Length <= 0)
                    {
                        row.SetCommentsNull();
                    } 
                }

                // Update History
                FlatSectionJLAllHistory flatSectionJLAllHistory = new FlatSectionJLAllHistory();
                flatSectionJLAllHistory.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                row.History = flatSectionJLAllHistory.GetJLOrFLOrRAHistory(companyId, flatSectionJLAllHistory.Table.Rows.Count, "\n");
                
                if (!row.IsHistoryNull())
                {
                    row.History = row.History.Replace("<br>", "\n");

                    if (row.History.Length <= 0)
                    {
                        row.SetHistoryNull();
                    } 
                }                
            }
        }



        /// <summary>
        /// UpdateEnterForComments
        /// </summary>        
        public void UpdateEnterForComments()
        {
            foreach (JlNavigatorTDS.JlNavigatorRow row in (JlNavigatorTDS.JlNavigatorDataTable)Table)
            {
                // Update Comments
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("\n", "<br>");
                }

                // Update History
                if (!row.IsHistoryNull())
                {
                    row.History = row.History.Replace("\n", "<br>");
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateFieldsForSections(int projectId, int companyId)
        {
            foreach (JlNavigatorTDS.JlNavigatorRow row in (JlNavigatorTDS.JlNavigatorDataTable)Table)
            {
                if (row.IsPitRequiredNull())
                    row.PitRequired = false;

                if (row.IsCoRequiredNull())
                    row.CoRequired = false;

                if (row.IsPostContractDigRequiredNull())
                    row.PostContractDigRequired = false;

                if (row.IsLiningThruCoNull())
                    row.LiningThruCo = false;

                if (!row.IsFlowOrderIDNull())
                {
                    row.LateralID = row.FlowOrderID + "-JL-" + row.LateralID;
                }
                else
                {
                    row.LateralID = "JL-" + row.LateralID;
                }

                if (!row.IsMainSizeNull())
                {
                    try
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
                    catch
                    {
                    }
                }

                row.Selected = false;

                int workIdFll = GetWorkId(projectId, row.AssetID, "Full Length Lining", companyId);
                
                FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, row.AssetID, companyId);

                if (fullLengthLiningWorkDetailsGateway.Table.Rows.Count > 0)
                {
                    string measurementFromMH = "USMH"; 
                    if (fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll) != "") measurementFromMH = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workIdFll);

                    if (measurementFromMH == "DSMH")
                    {
                        string auxDistanceFromUSMH = row.DistanceFromUSMH;
                        row.DistanceFromUSMH = row.DistanceFromDSMH;
                        row.DistanceFromDSMH = auxDistanceFromUSMH;
                    }
                }
            }
        }



        /// <summary>
        /// GetWorkId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>JlNavigatorTDS.JlNavigatorRow</returns>
        private JlNavigatorTDS.JlNavigatorRow GetRow(int assetId)
        {
            JlNavigatorTDS.JlNavigatorRow row = ((JlNavigatorTDS.JlNavigatorDataTable)Table).FindByAssetID_(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.JlNavigator.GetRow");
            }

            return row;
        }



    }
}