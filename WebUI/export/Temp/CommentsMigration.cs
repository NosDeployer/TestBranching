using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    /// <summary>
    /// CommentsMigration
    /// </summary>
    public class CommentsMigration : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CommentsMigration()
            : base("CommentsMigration")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CommentsMigration(DataSet data)
            : base(data, "CommentsMigration")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CommentsMigrationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        public void LoadByProjectId(int parentProjectId, int childProject, int companyId)
        {
            CommentsMigrationGateway commentsMigrationGateway = new CommentsMigrationGateway(Data);
            commentsMigrationGateway.LoadByProjectId(childProject, companyId);

            UpdatePreviousWorks(parentProjectId, childProject, companyId);
        }



        /// <summary>
        /// UpdatePreviousWorks 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void UpdatePreviousWorks(int parentProjectId, int childProjectId, int companyId)
        {
            WorkGateway commentsMigrationGateway = new WorkGateway();

            foreach (CommentsMigrationTDS.CommentsMigrationRow searchRow in (CommentsMigrationTDS.CommentsMigrationDataTable)Data.Tables["CommentsMigration"])
            {
                // If there is Previous RA works on section
                if (commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(parentProjectId, searchRow.AssetID, companyId, "Rehab Assessment") && commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(childProjectId, searchRow.AssetID, companyId, "Rehab Assessment"))
                {
                    searchRow.MigrateComments = true;
                    searchRow.RehabAssessmentPrevWork = true;
                }

                // If there is Previous FL works on section
                if (commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(parentProjectId, searchRow.AssetID, companyId, "Full Length Lining") && commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(childProjectId, searchRow.AssetID, companyId, "Full Length Lining"))
                {
                    searchRow.MigrateComments = true;
                    searchRow.FullLengthLiningPrevWork = true;
                }

                // If there is Previous PR works on section
                if (commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(parentProjectId, searchRow.AssetID, companyId, "Point Repairs") && commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(childProjectId, searchRow.AssetID, companyId, "Point Repairs"))
                {
                    searchRow.MigrateComments = true;
                    searchRow.PointRepairsPrevWork = true;
                }

                // If there is Previous JL works on section
                if (commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(parentProjectId, searchRow.AssetID, companyId, "Junction Lining Section") && commentsMigrationGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(childProjectId, searchRow.AssetID, companyId, "Junction Lining Section"))
                {
                    searchRow.MigrateComments = true;
                    searchRow.JunctionLiningPrevWork = true;
                }
            }
        }



        /// <summary>
        /// GetSummary
        /// </summary>
        /// <returns></returns>
        public string GetSummary()
        {
            string summary = " ";

            foreach (CommentsMigrationTDS.CommentsMigrationRow row in (CommentsMigrationTDS.CommentsMigrationDataTable)Table)
            {
                if (row.MigrateComments)
                {
                    summary += row.FlowOrderID + " ";

                    if (row.FullLengthLiningPrevWork) summary += "FLL ";
                    if (row.RehabAssessmentPrevWork) summary += "RA ";
                    if (row.JunctionLiningPrevWork) summary += "JL ";
                    if (row.PointRepairsPrevWork) summary += "PR ";

                    summary += "\n";
                }
            }

            return summary;
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void Save(int parentProjectId, int childProjectId, int companyId)
        {
            foreach (CommentsMigrationTDS.CommentsMigrationRow row in (CommentsMigrationTDS.CommentsMigrationDataTable)Table)
            {
                if (row.MigrateComments)
                {
                    int assetId = row.AssetID;

                    // Save work
                    if (row.RehabAssessmentPrevWork)
                    {
                        SavePreviousWork(parentProjectId, childProjectId, row.AssetID, "Rehab Assessment", companyId);
                    }

                    if (row.FullLengthLiningPrevWork)
                    {
                        SavePreviousWork(parentProjectId, childProjectId, row.AssetID, "Full Length Lining", companyId);
                    }

                    if (row.PointRepairsPrevWork)
                    {
                        SavePreviousWork(parentProjectId, childProjectId, row.AssetID, "Point Repairs", companyId);
                    }

                    if (row.JunctionLiningPrevWork)
                    {
                        SavePreviousWork(parentProjectId, childProjectId, row.AssetID, "Junction Lining Section", companyId);
                    }
                }
            }
        }



        /// <summary>
        /// Save a Previous RA work
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="section_assetId">section_assetId</param>
        /// <param name="companyId">companyId</param>
        private void SavePreviousWork(int parentProjectId, int childProjectId, int assetId, string workType, int companyId)
        {
            int parentWorkId = 0;
            int childWorkId = 0;
            int childJLLWorkId = 0;
            int parentJLLWorkID = 0;

            // Load Previous work  - Rehab assessment data (last sections work)            
            WorkGateway parentWorkGateway = new WorkGateway();
            WorkGateway childWorkGateway = new WorkGateway();
            WorkGateway childJLLWorkGateway = new WorkGateway();

            parentWorkGateway.LoadByProjectIdAssetIdWorkType(parentProjectId, assetId, workType, companyId);

            if (parentWorkGateway.Table.Rows.Count > 0)
            {
                parentWorkId = parentWorkGateway.GetWorkId(assetId, workType, parentProjectId);

                childWorkGateway.LoadByProjectIdAssetIdWorkType(childProjectId, assetId, workType, companyId);
                childWorkId = childWorkGateway.GetWorkId(assetId, workType, childProjectId);

                // Load Previous work  - Comments and History
                SavePreviousComments(parentWorkId, workType, companyId, childWorkId);
                SavePreviousHistory(parentWorkId, workType, companyId, childWorkId);

                if (workType == "Junction Lining Section")
                {
                    // Load Previous work  - Junction Lining Lateral data
                    WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
                    workJunctionLiningLateralGateway.LoadBySectionWorkId(parentWorkId, companyId);

                    foreach (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALRow lateralRow in (WorkTDS.LFS_WORK_JUNCTIONLINING_LATERALDataTable)workJunctionLiningLateralGateway.Table)
                    {
                        try
                        {
                            WorkGateway workGatewayForLateral = new WorkGateway();
                            workGatewayForLateral.LoadByWorkId(lateralRow.WorkID, companyId);

                            int lateral_assetId = workGatewayForLateral.GetAssetId(lateralRow.WorkID);
                            parentJLLWorkID = lateralRow.WorkID;

                            childJLLWorkGateway.LoadByProjectIdAssetIdWorkType(childProjectId, lateral_assetId, "Junction Lining Lateral", companyId);
                            childJLLWorkId = childJLLWorkGateway.GetWorkId(lateral_assetId, "Junction Lining Lateral", childProjectId);

                            // Load Previous work  - Comments and History
                            SavePreviousComments(parentJLLWorkID, "Junction Lining Lateral", companyId, childJLLWorkId);
                            SavePreviousHistory(parentJLLWorkID, "Junction Lining Lateral", companyId, childJLLWorkId);

                            workUpdate(childJLLWorkId, childProjectId, lateral_assetId, companyId, "Junction Lining Lateral");
                        }
                        catch
                        {
                        }
                    }
                }
                else
                {
                    workUpdate(childWorkId, childProjectId, assetId, companyId, workType);
                }
            }
        }



        private void workUpdate(int workId, int projectId, int assetId, int companyId, string workType)
        {
            // Get original variables
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            string originalWorkType = workGateway.GetWorkTypeOriginal(workId);
            int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(workId);
            string originalComment = workGateway.GetCommentsOriginal(workId);
            string originalHistory = workGateway.GetHistoryOriginal(workId);

            //Get new comment
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
            workCommentsGateway.LoadByAssetIdWorkTypeProjectId(assetId, companyId, workType, projectId);

            WorkComments workComments = new WorkComments(workCommentsGateway.Data);
            string newComment = workComments.GetCommentsSummary(companyId, workCommentsGateway.Table.Rows.Count, "\n");

            Work work = new Work(null);
            work.UpdateDirect(workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, newComment, originalHistory);
        }



        /// <summary>
        /// Save Previous Comments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="newSectionWorkId">newSectionWorkId</param>
        private void SavePreviousComments(int parentWorkId, string workType, int companyId, int childWorkId)
        {
            WorkCommentsGateway parentWorkCommentsGateway = new WorkCommentsGateway();
            parentWorkCommentsGateway.LoadAllByWorkIdWorkType(parentWorkId, companyId, workType);

            WorkCommentsGateway childWorkCommentsGateway = new WorkCommentsGateway();
            childWorkCommentsGateway.LoadAllByWorkIdWorkType(childWorkId, companyId, workType);
            WorkComments childWorkComments = new WorkComments(childWorkCommentsGateway.Data);

            int lastRefId = childWorkComments.GetNewRefId();

            foreach (WorkTDS.LFS_WORK_COMMENTRow commentRow in (WorkTDS.LFS_WORK_COMMENTDataTable)parentWorkCommentsGateway.Table)
            {
                WorkComments workComments = new WorkComments();                

                int refId = lastRefId;
                string type = ""; if (!commentRow.IsTypeNull()) type = commentRow.Type;
                string subject = commentRow.Subject;
                int userId = commentRow.UserID;
                DateTime? dateTime_ = null; if (!commentRow.IsDateTime_Null()) dateTime_ = commentRow.DateTime_;
                string comment = ""; if (!commentRow.IsCommentNull()) comment = commentRow.Comment;
                int? libraryFilesId = null; if (!commentRow.IsLIBRARY_FILES_IDNull()) libraryFilesId = commentRow.LIBRARY_FILES_ID;

                workComments.InsertDirect(childWorkId, refId, type, subject, userId, dateTime_, comment, libraryFilesId, false, companyId, workType);

                lastRefId++;
            }
        }



        /// <summary>
        /// Save Previous History
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <param name="newSectionWorkId">newSectionWorkId</param>
        private void SavePreviousHistory(int parentWorkId, string workType, int companyId, int childWorkId)
        {
            WorkHistoryGateway parentWorkHistoryGateway = new WorkHistoryGateway();
            parentWorkHistoryGateway.LoadAllByWorkIdWorkType(parentWorkId, companyId, workType);

            WorkHistoryGateway childWorkHistoryGateway = new WorkHistoryGateway();
            childWorkHistoryGateway.LoadAllByWorkIdWorkType(childWorkId, companyId, workType);
            WorkHistory childWorkHistory = new WorkHistory(childWorkHistoryGateway.Data);

            int lastRefId = childWorkHistory.GetNewRefId();

            foreach (WorkTDS.LFS_WORK_HISTORYRow commentRow in (WorkTDS.LFS_WORK_HISTORYDataTable)parentWorkHistoryGateway.Table)
            {
                WorkHistory workHistory = new WorkHistory();

                int refId = lastRefId;
                string type = ""; if (!commentRow.IsTypeNull()) type = commentRow.Type;
                string subject = commentRow.Subject;
                int userId = commentRow.UserID;
                DateTime? dateTime_ = null; if (!commentRow.IsDateTime_Null()) dateTime_ = commentRow.DateTime_;
                string comment = ""; if (!commentRow.IsHistoryNull()) comment = commentRow.History;
                int? libraryFilesId = null; if (!commentRow.IsLIBRARY_FILES_IDNull()) libraryFilesId = commentRow.LIBRARY_FILES_ID;

                workHistory.InsertDirect(childWorkId, refId, type, subject, userId, dateTime_, comment, libraryFilesId, false, companyId, workType);

                lastRefId++;
            }
        }



    }
}