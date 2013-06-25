using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.BL.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningWetOutCommentsDetails
    /// </summary>
    public class FullLengthLiningWetOutCommentsDetails : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningWetOutCommentsDetails()
            : base("WetOutCommentsDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningWetOutCommentsDetails(DataSet data)
                : base(data, "WetOutCommentsDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="loginId">loginId</param>
        /// <param name="dateTime_">dateTime_</param>
        /// <param name="comment">comment</param>
        /// <param name="libraryFilesId">libraryFilesId</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        /// <param name="userFullName">userFullName</param>        
        /// <param name="workType">workType</param>
        public void Insert(int workId, string type, string subject, int loginId, DateTime dateTime_, string comment, int? libraryFilesId, bool deleted, int companyId, bool inDatabase, string userFullName, string workType)
        {
            FullLengthLiningTDS.WetOutCommentsDetailsRow row = ((FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Table).NewWetOutCommentsDetailsRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId();
            row.Type = type.Trim(); 
            row.Subject = subject.Trim();
            row.UserID = loginId;
            row.DateTime_ = dateTime_;
            row.Comment = comment.Trim(); 
            if (libraryFilesId.HasValue) row.LIBRARY_FILES_ID = (int)libraryFilesId; else row.SetLIBRARY_FILES_IDNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;
            row.UserFullName = userFullName;            
            row.WorkType = workType; 

            ((FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Table).AddWetOutCommentsDetailsRow(row);
        }



        /// <summary>
        /// Update a comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="type">type</param>
        /// <param name="subject">subject</param>
        /// <param name="companyId">companyId</param>
        /// <param name="comment">comment</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">add Permission</param>
        public void Update(int workId, int refId, string type, string subject, int companyId, string comment, int loginId, bool adminPermission, bool toHistory)
        {
            FullLengthLiningTDS.WetOutCommentsDetailsRow row = GetRow(workId, refId);

            if (adminPermission)
            {
                row.Subject = subject.Trim();
                row.Comment = comment.Trim();                 
            }
            else
            {
                if (row.UserID == loginId)
                {
                    row.Subject = subject.Trim();
                    row.Comment = comment.Trim();                  
                }
            }
        }



        /// <summary>
        /// UpdateForProcess. Update the author of each comment
        /// </summary>
        public void UpdateForProcess()
        {
            LoginGateway loginGateway = new LoginGateway();

            foreach (FullLengthLiningTDS.WetOutCommentsDetailsRow row in (FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Table)
            {
                loginGateway.LoadByLoginId(row.UserID, row.COMPANY_ID);
                row.UserFullName = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);
            }
        }



        /// <summary>
        /// Delete one comment
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="loginId">loginId</param>
        /// <param name="adminPermission">admin Permission</param>
        public void Delete(int workId, int refId, int companyId, int loginId, bool adminPermission)
        {
            FullLengthLiningTDS.WetOutCommentsDetailsRow row = GetRow(workId, refId);

            if (adminPermission)
            {
                row.Deleted = true;
            }
            else
            {
                if (row.UserID == loginId)
                {
                    row.Deleted = true;
                }
            }
        }



        /// <summary>
        /// Save all comments to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>   
        /// <param name="runDetails">runDetails</param>
        /// <param name="projectId">projectId</param>
        public void Save(int companyId, string runDetails, int projectId)
        {
            string[] runDetailsList = runDetails.Split('>'); 

            FullLengthLiningTDS fullLengthLiningWetOutCommentsDetailsChanges = (FullLengthLiningTDS)Data.GetChanges();

            if (fullLengthLiningWetOutCommentsDetailsChanges.WetOutCommentsDetails.Rows.Count > 0)
            {
                FullLengthLiningWetOutCommentsDetailsGateway fullLengthLiningWetOutCommentsDetailsGateway = new FullLengthLiningWetOutCommentsDetailsGateway(fullLengthLiningWetOutCommentsDetailsChanges);

                foreach (FullLengthLiningTDS.WetOutCommentsDetailsRow row in (FullLengthLiningTDS.WetOutCommentsDetailsDataTable)fullLengthLiningWetOutCommentsDetailsChanges.WetOutCommentsDetails)
                {
                    // Insert new comments 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                            string sectionId = runDetailsList[i].ToString();
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            WorkGateway workGateway = new WorkGateway();
                            int newWorkId = 0;
                            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                            if (workGateway.Table.Rows.Count > 0)
                            {
                                newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                            }

                            WorkFullLengthLiningWetOutComments workFullLengthLiningWetOutComments = new WorkFullLengthLiningWetOutComments(null);
                            int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;

                            workFullLengthLiningWetOutComments.InsertDirect(newWorkId, row.RefID, row.Type, row.Subject, row.UserID, row.DateTime_, row.Comment, libraryFilesId, row.Deleted, row.COMPANY_ID, row.WorkType);
                        }
                    }

                    // Update comments
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        string originalType = fullLengthLiningWetOutCommentsDetailsGateway.GetTypeOriginal(workId, refId);
                        string originalSubject = fullLengthLiningWetOutCommentsDetailsGateway.GetSubjectOriginal(workId, refId);
                        int originalUserId = fullLengthLiningWetOutCommentsDetailsGateway.GetUserIdOriginal(workId, refId);
                        DateTime? originalDateTime = null; if (fullLengthLiningWetOutCommentsDetailsGateway.GetDateTime_Original(workId, refId) != null) originalDateTime = fullLengthLiningWetOutCommentsDetailsGateway.GetDateTime_Original(workId, refId);
                        string originalComment = fullLengthLiningWetOutCommentsDetailsGateway.GetCommentOriginal(workId, refId);
                        int? originalLibraryFilesId = null; if (fullLengthLiningWetOutCommentsDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = fullLengthLiningWetOutCommentsDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId);
                        string originalWorkType = fullLengthLiningWetOutCommentsDetailsGateway.GetWorkTypeOriginal(workId, refId);

                        // new values
                        string newType = fullLengthLiningWetOutCommentsDetailsGateway.GetType(workId, refId);
                        string newSubject = fullLengthLiningWetOutCommentsDetailsGateway.GetSubject(workId, refId);
                        string newComment = fullLengthLiningWetOutCommentsDetailsGateway.GetComment(workId, refId);
                        int? newLibraryFilesId = null; if (fullLengthLiningWetOutCommentsDetailsGateway.GetLIBRARY_FILES_IDOriginal(workId, refId) != null) originalLibraryFilesId = fullLengthLiningWetOutCommentsDetailsGateway.GetLIBRARY_FILES_ID(workId, refId);

                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                            string sectionId = runDetailsList[i].ToString();
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            WorkGateway workGateway = new WorkGateway();
                            int newWorkId = 0;
                            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                            if (workGateway.Table.Rows.Count > 0)
                            {
                                newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                            }

                            string workType = "Full Length Lining Wet Out";
                            FullLengthLiningWetOutCommentsDetailsGateway fullLengthLiningWetOutCommentsDetailsGatewayForReview = new FullLengthLiningWetOutCommentsDetailsGateway();
                            fullLengthLiningWetOutCommentsDetailsGatewayForReview.LoadAllByWorkIdWorkType(newWorkId, companyId, workType);
                            if (fullLengthLiningWetOutCommentsDetailsGatewayForReview.Table.Rows.Count > 0)
                            {
                                WorkFullLengthLiningWetOutComments workFullLengthLiningWetOutComments = new WorkFullLengthLiningWetOutComments(null);
                                workFullLengthLiningWetOutComments.UpdateDirect(newWorkId, refId, originalType, originalSubject, originalUserId, originalDateTime, originalComment, originalLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType, workId, refId, newType, newSubject, originalUserId, originalDateTime, newComment, newLibraryFilesId, originalDeleted, originalCompanyId, originalWorkType);
                            }
                            else
                            {
                                WorkFullLengthLiningWetOutComments workFullLengthLiningWetOutComments = new WorkFullLengthLiningWetOutComments(null);
                                int? libraryFilesId = null; if (!row.IsLIBRARY_FILES_IDNull()) libraryFilesId = row.LIBRARY_FILES_ID;

                                workFullLengthLiningWetOutComments.InsertDirect(newWorkId, row.RefID, row.Type, row.Subject, row.UserID, row.DateTime_, row.Comment, libraryFilesId, row.Deleted, row.COMPANY_ID, row.WorkType);
                            }
                        }
                    }

                    // Deleted comments 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        for (int i = 0; i < runDetailsList.Length; i++)
                        {
                            AssetSewerSectionGateway assetSewerSectionGateway = new AssetSewerSectionGateway();
                            string sectionId = runDetailsList[i].ToString();
                            assetSewerSectionGateway.LoadBySectionId(sectionId, companyId);
                            int assetId = assetSewerSectionGateway.GetAssetID(sectionId);

                            WorkGateway workGateway = new WorkGateway();
                            int newWorkId = 0;
                            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Full Length Lining", companyId);
                            if (workGateway.Table.Rows.Count > 0)
                            {
                                newWorkId = workGateway.GetWorkId(assetId, "Full Length Lining", projectId);
                            }
                            WorkFullLengthLiningWetOutComments workFullLengthLiningWetOutComments = new WorkFullLengthLiningWetOutComments(null);
                            workFullLengthLiningWetOutComments.DeleteDirect(newWorkId, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetAllFullLengthLiningComments. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="numberOfComments">numberOfComments</param>
        /// <param name="enterString">enterString</param>
        /// <returns>a string with all comments separeted with  the enterString</returns>
        public string GetAllFullLengthLiningComments(int workId, int companyId, int numberOfComments, string enterString)
        {
            string comment = "";

            foreach (FullLengthLiningTDS.WetOutCommentsDetailsRow row in (FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Table)
            {
                if ((row.WorkID == workId) && (row.COMPANY_ID == companyId) && (!row.Deleted))
                {
                    // ... Get user name
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadAllByLoginId(row.UserID, row.COMPANY_ID);
                    string user = loginGateway.GetLastName(row.UserID, row.COMPANY_ID) + " " + loginGateway.GetFirstName(row.UserID, row.COMPANY_ID);

                    // ... Form the comment string
                    string rowComment = row.Comment;
                    comment = comment + row.DateTime_ + " (" + user.Trim() + ")" ;
                    comment = comment + ", Created At: " + row.WorkType;
                    comment = comment + ", Type: " + row.Type;                    
                    comment = comment + ", Subject: " + row.Subject + enterString;
                    comment = comment + "Comment: " + rowComment;
                }

                // Insert enter when correspond
                if (numberOfComments > 1)
                {
                    comment = comment + enterString + enterString;
                    numberOfComments--;
                }
            }
            return (comment);
        }






        //// ////////////////////////////////////////////////////////////////////////
        //// PRIVATE METHODS
        ////

        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        private int GetNewRefId()
        {
            int newRefId = 0;

            foreach (FullLengthLiningTDS.WetOutCommentsDetailsRow row in (FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }



        /// <summary>
        /// Get a single comment. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">RefID</param>
        /// <returns>RehabAssessmentTDS.WetOutCommentsDetailsRow</returns>
        private FullLengthLiningTDS.WetOutCommentsDetailsRow GetRow(int workId, int refId)
        {
            FullLengthLiningTDS.WetOutCommentsDetailsRow row = ((FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FullLengthLiningWetOutCommentsDetails.GetRow");
            }

            return row;
        }
    }
}
