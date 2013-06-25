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
    /// FlInversionFieldCureRecord
    /// </summary>
    public class FlInversionFieldCureRecord: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlInversionFieldCureRecord()
            : base("InversionFieldCureRecord")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlInversionFieldCureRecord(DataSet data)
            : base(data, "InversionFieldCureRecord")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlInversionFieldCureRecordTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int workId, int companyId)
        {
            FlInversionFieldCureRecordGateway flInversionFieldCureRecordGateway = new FlInversionFieldCureRecordGateway(Data);
            flInversionFieldCureRecordGateway.LoadAllByWorkId(workId, companyId);
        }



        /// <summary>
        /// Load
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        public void Load(int workId, int companyId)
        {
            FlInversionFieldCureRecordGateway flInversionFieldCureRecordGateway = new FlInversionFieldCureRecordGateway(Data);
            flInversionFieldCureRecordGateway.LoadByWorkId(workId, companyId);
        }







        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new field cure record
        /// </summary>
        /// <param name="workId">workId</param>        
        /// <param name="readingTime">readingTime</param>
        /// <param name="headFt">headFt</param>
        /// <param name="boilerInF">boilerInF</param>
        /// <param name="boilerOutF">boilerOutF</param>
        /// <param name="pumpFlow">pumpFlow</param>
        /// <param name="pumpPsi">pumpPsi</param>
        /// <param name="mh1Top">mh1Top</param>
        /// <param name="mh1Bot">mh1Bot</param>
        /// <param name="mh2Top">mh2Top</param>
        /// <param name="mh2Bot">mh2Bot</param>
        /// <param name="mh3Top">mh3Top</param>
        /// <param name="mh3Bot">mh3Bot</param>
        /// <param name="mh4Top">mh4Top</param>
        /// <param name="mh4Bot">mh4Bot</param>        
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int workId, DateTime readingTime, decimal? headFt, decimal? boilerInF, decimal? boilerOutF, decimal? pumpFlow, decimal? pumpPsi, decimal? mh1Top, decimal? mh1Bot, decimal? mh2Top, decimal? mh2Bot, decimal? mh3Top, decimal? mh3Bot, decimal? mh4Top, decimal? mh4Bot, string comments, bool deleted, int companyId, bool inDatabase)
        {
            FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row = ((FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Table).NewInversionFieldCureRecordRow();

            row.WorkID = workId;
            row.RefID = GetNewRefId();
            row.ReadingTime = readingTime;
            if (headFt.HasValue) row.HeadFt = (decimal)headFt; else row.SetHeadFtNull();
            if (boilerInF.HasValue) row.BoilerInF = (decimal)boilerInF; else row.SetBoilerInFNull();
            if (boilerOutF.HasValue) row.BoilerOutF = (decimal)boilerOutF; else row.SetBoilerOutFNull();
            if (pumpFlow.HasValue) row.PumpFlow = (decimal)pumpFlow; else row.SetPumpFlowNull();
            if (pumpPsi.HasValue) row.PumpPsi = (decimal)pumpPsi; else row.SetPumpPsiNull();
            if (pumpFlow.HasValue) row.PumpFlow = (decimal)pumpFlow; else row.SetPumpFlowNull();
            if (mh1Top.HasValue) row.MH1Top = (decimal)mh1Top; else row.SetMH1TopNull();
            if (mh1Bot.HasValue) row.MH1Bot = (decimal)mh1Bot; else row.SetMH1BotNull();
            if (mh2Top.HasValue) row.MH2Top = (decimal)mh2Top; else row.SetMH2TopNull();
            if (mh2Bot.HasValue) row.MH2Bot = (decimal)mh2Bot; else row.SetMH2BotNull();
            if (mh3Top.HasValue) row.MH3Top = (decimal)mh3Top; else row.SetMH3TopNull();
            if (mh3Bot.HasValue) row.MH3Bot = (decimal)mh3Bot; else row.SetMH3BotNull();
            if (mh4Top.HasValue) row.MH4Top = (decimal)mh4Top; else row.SetMH4TopNull();
            if (mh4Bot.HasValue) row.MH4Bot = (decimal)mh4Bot; else row.SetMH4BotNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Table).AddInversionFieldCureRecordRow(row);
        }



        /// <summary>
        /// Update a field cure record
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="readingTime">readingTime</param>
        /// <param name="headFt">headFt</param>
        /// <param name="boilerInF">boilerInF</param>
        /// <param name="boilerOutF">boilerOutF</param>
        /// <param name="pumpFlow">pumpFlow</param>
        /// <param name="pumpPsi">pumpPsi</param>
        /// <param name="mh1Top">mh1Top</param>
        /// <param name="mh1Bot">mh1Bot</param>
        /// <param name="mh2Top">mh2Top</param>
        /// <param name="mh2Bot">mh2Bot</param>
        /// <param name="mh3Top">mh3Top</param>
        /// <param name="mh3Bot">mh3Bot</param>
        /// <param name="mh4Top">mh4Top</param>
        /// <param name="mh4Bot">mh4Bot</param>        
        /// <param name="comments">comments</param>                
        public void Update(int workId, int refId, DateTime readingTime, decimal? headFt, decimal? boilerInF, decimal? boilerOutF, decimal? pumpFlow, decimal? pumpPsi, decimal? mh1Top, decimal? mh1Bot, decimal? mh2Top, decimal? mh2Bot, decimal? mh3Top, decimal? mh3Bot, decimal? mh4Top, decimal? mh4Bot, string comments)
        {
            FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row = GetRow(workId, refId);

            row.ReadingTime = readingTime;
            if (headFt.HasValue) row.HeadFt = (decimal)headFt; else row.SetHeadFtNull();
            if (boilerInF.HasValue) row.BoilerInF = (decimal)boilerInF; else row.SetBoilerInFNull();
            if (boilerOutF.HasValue) row.BoilerOutF = (decimal)boilerOutF; else row.SetBoilerOutFNull();
            if (pumpFlow.HasValue) row.PumpFlow = (decimal)pumpFlow; else row.SetPumpFlowNull();
            if (pumpPsi.HasValue) row.PumpPsi = (decimal)pumpPsi; else row.SetPumpPsiNull();
            if (pumpFlow.HasValue) row.PumpFlow = (decimal)pumpFlow; else row.SetPumpFlowNull();
            if (mh1Top.HasValue) row.MH1Top = (decimal)mh1Top; else row.SetMH1TopNull();
            if (mh1Bot.HasValue) row.MH1Bot = (decimal)mh1Bot; else row.SetMH1BotNull();
            if (mh2Top.HasValue) row.MH2Top = (decimal)mh2Top; else row.SetMH2TopNull();
            if (mh2Bot.HasValue) row.MH2Bot = (decimal)mh2Bot; else row.SetMH2BotNull();
            if (mh3Top.HasValue) row.MH3Top = (decimal)mh3Top; else row.SetMH3TopNull();
            if (mh3Bot.HasValue) row.MH3Bot = (decimal)mh3Bot; else row.SetMH3BotNull();
            if (mh4Top.HasValue) row.MH4Top = (decimal)mh4Top; else row.SetMH4TopNull();
            if (mh4Bot.HasValue) row.MH4Bot = (decimal)mh4Bot; else row.SetMH4BotNull();
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
        }
               

        
        /// <summary>
        /// Delete one field cure record
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int workId, int refId, int companyId)
        {
            FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row = GetRow(workId, refId);
            row.Deleted = true;            
        }



        /// <summary>
        /// Save all field cure record to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>        
        /// <param name="runDetails">runDetails</param>
        /// <param name="projectId">projectId</param>
        public void Save(int companyId, string runDetails, int projectId)
        {
            string[] runDetailsList = runDetails.Split('>');     

            FlInversionFieldCureRecordTDS flInversionFieldCureRecordChanges = (FlInversionFieldCureRecordTDS)Data.GetChanges();

            if (flInversionFieldCureRecordChanges.InversionFieldCureRecord.Rows.Count > 0)
            {
                FlInversionFieldCureRecordGateway flInversionFieldCureRecordGateway = new FlInversionFieldCureRecordGateway(flInversionFieldCureRecordChanges);

                foreach (FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row in (FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)flInversionFieldCureRecordChanges.InversionFieldCureRecord)
                {
                    // Insert new field cure records 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        DateTime readingTime = row.ReadingTime;
                        decimal? headFt = null; if (!row.IsHeadFtNull()) headFt = row.HeadFt;
                        decimal? boilerInF = null; if (!row.IsBoilerInFNull()) boilerInF = row.BoilerInF;
                        decimal? boilerOutF = null; if (!row.IsBoilerOutFNull()) boilerOutF = row.BoilerOutF;
                        decimal? pumpFlow = null; if (!row.IsPumpFlowNull()) pumpFlow = row.PumpFlow;
                        decimal? pumpPsi = null; if (!row.IsPumpPsiNull()) pumpPsi = row.PumpPsi;
                        decimal? mh1Top = null; if (!row.IsMH1TopNull()) mh1Top = row.MH1Top;
                        decimal? mh1Bot = null; if (!row.IsMH1BotNull()) mh1Bot = row.MH1Bot;
                        decimal? mh2Top = null; if (!row.IsMH2TopNull()) mh2Top = row.MH2Top;
                        decimal? mh2Bot = null; if (!row.IsMH2BotNull()) mh2Bot = row.MH2Bot;
                        decimal? mh3Top = null; if (!row.IsMH3TopNull()) mh3Top = row.MH3Top;
                        decimal? mh3Bot = null; if (!row.IsMH3BotNull()) mh3Bot = row.MH3Bot;
                        decimal? mh4Top = null; if (!row.IsMH4TopNull()) mh4Top = row.MH4Top;
                        decimal? mh4Bot = null; if (!row.IsMH4BotNull()) mh4Bot = row.MH4Bot;
                        string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;

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

                            WorkFullLengthLiningInversionFieldCureRecord workFullLengthLiningInversionFieldCureRecord = new WorkFullLengthLiningInversionFieldCureRecord(null);
                            workFullLengthLiningInversionFieldCureRecord.InsertDirect(newWorkId, row.RefID, readingTime, headFt, boilerInF, boilerOutF, pumpFlow, pumpPsi, mh1Top, mh1Bot, mh2Top, mh2Bot, mh3Top, mh3Bot, mh4Top, mh4Bot, comments, row.Deleted, row.COMPANY_ID);
                        }
                    }

                    // Update field cure records
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int workId = row.WorkID;
                        int refId = row.RefID;
                        bool originalDeleted = false;
                        int originalCompanyId = companyId;

                        // original values
                        DateTime originalReadingTime= flInversionFieldCureRecordGateway.GetReadingTimeOriginal(workId, refId);
                        decimal? originalHeadFt = flInversionFieldCureRecordGateway.GetHeadFtOriginal(workId, refId);
                        decimal? originalBoilerInF = flInversionFieldCureRecordGateway.GetBoilerInFOriginal(workId, refId);
                        decimal? originalBoilerOutF = flInversionFieldCureRecordGateway.GetBoilerOutFOriginal(workId, refId);
                        decimal? originalPumpFlow = flInversionFieldCureRecordGateway.GetPumpFlowOriginal(workId, refId);
                        decimal? originalPumpPsi = flInversionFieldCureRecordGateway.GetPumpPsiOriginal(workId, refId);
                        decimal? originalMH1Top = flInversionFieldCureRecordGateway.GetMH1TopOriginal(workId, refId);
                        decimal? originalMH1Bot = flInversionFieldCureRecordGateway.GetMH1BotOriginal(workId, refId);
                        decimal? originalMH2Top = flInversionFieldCureRecordGateway.GetMH2TopOriginal(workId, refId);
                        decimal? originalMH2Bot = flInversionFieldCureRecordGateway.GetMH2BotOriginal(workId, refId);
                        decimal? originalMH3Top = flInversionFieldCureRecordGateway.GetMH3TopOriginal(workId, refId);
                        decimal? originalMH3Bot = flInversionFieldCureRecordGateway.GetMH3BotOriginal(workId, refId);
                        decimal? originalMH4Top = flInversionFieldCureRecordGateway.GetMH4TopOriginal(workId, refId);
                        decimal? originalMH4Bot = flInversionFieldCureRecordGateway.GetMH4BotOriginal(workId, refId);
                        string originalComments = flInversionFieldCureRecordGateway .GetCommentsOriginal(workId, refId);

                        // new values
                        DateTime newReadingTime = flInversionFieldCureRecordGateway.GetReadingTime(workId, refId);
                        decimal? newHeadFt = flInversionFieldCureRecordGateway.GetHeadFt(workId, refId);
                        decimal? newBoilerInF = flInversionFieldCureRecordGateway.GetBoilerInF(workId, refId);
                        decimal? newBoilerOutF = flInversionFieldCureRecordGateway.GetBoilerOutF(workId, refId);
                        decimal? newPumpFlow = flInversionFieldCureRecordGateway.GetPumpFlow(workId, refId);
                        decimal? newPumpPsi = flInversionFieldCureRecordGateway.GetPumpPsi(workId, refId);
                        decimal? newMH1Top = flInversionFieldCureRecordGateway.GetMH1Top(workId, refId);
                        decimal? newMH1Bot = flInversionFieldCureRecordGateway.GetMH1Bot(workId, refId);
                        decimal? newMH2Top = flInversionFieldCureRecordGateway.GetMH2Top(workId, refId);
                        decimal? newMH2Bot = flInversionFieldCureRecordGateway.GetMH2Bot(workId, refId);
                        decimal? newMH3Top = flInversionFieldCureRecordGateway.GetMH3Top(workId, refId);
                        decimal? newMH3Bot = flInversionFieldCureRecordGateway.GetMH3Bot(workId, refId);
                        decimal? newMH4Top = flInversionFieldCureRecordGateway.GetMH4Top(workId, refId);
                        decimal? newMH4Bot = flInversionFieldCureRecordGateway.GetMH4Bot(workId, refId);
                        string newComments = flInversionFieldCureRecordGateway .GetComments(workId, refId);

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

                            FlInversionFieldCureRecordGateway flInversionFieldCureRecordGatewayForReview = new FlInversionFieldCureRecordGateway();
                            flInversionFieldCureRecordGatewayForReview.LoadByWorkId(newWorkId, companyId);
                            if (flInversionFieldCureRecordGatewayForReview.Table.Rows.Count > 0)
                            {
                                WorkFullLengthLiningInversionFieldCureRecord workFullLengthLiningInversionFieldCureRecord = new WorkFullLengthLiningInversionFieldCureRecord(null);
                                workFullLengthLiningInversionFieldCureRecord.UpdateDirect(newWorkId, refId, originalReadingTime, originalHeadFt, originalBoilerInF, originalBoilerOutF, originalPumpFlow, originalPumpPsi, originalMH1Top, originalMH1Bot, originalMH2Top, originalMH2Bot, originalMH3Top, originalMH3Bot, originalMH4Top, originalMH4Bot, originalComments, originalDeleted, originalCompanyId, workId, refId, newReadingTime, newHeadFt, newBoilerInF, newBoilerOutF, newPumpFlow, newPumpPsi, newMH1Top, newMH1Bot, newMH2Top, newMH2Bot, newMH3Top, newMH3Bot, newMH4Top, newMH4Bot, originalComments, originalDeleted, originalCompanyId);
                            }
                            else
                            {
                                DateTime readingTime = row.ReadingTime;
                                decimal? headFt = null; if (!row.IsHeadFtNull()) headFt = row.HeadFt;
                                decimal? boilerInF = null; if (!row.IsBoilerInFNull()) boilerInF = row.BoilerInF;
                                decimal? boilerOutF = null; if (!row.IsBoilerOutFNull()) boilerOutF = row.BoilerOutF;
                                decimal? pumpFlow = null; if (!row.IsPumpFlowNull()) pumpFlow = row.PumpFlow;
                                decimal? pumpPsi = null; if (!row.IsPumpPsiNull()) pumpPsi = row.PumpPsi;
                                decimal? mh1Top = null; if (!row.IsMH1TopNull()) mh1Top = row.MH1Top;
                                decimal? mh1Bot = null; if (!row.IsMH1BotNull()) mh1Bot = row.MH1Bot;
                                decimal? mh2Top = null; if (!row.IsMH2TopNull()) mh2Top = row.MH2Top;
                                decimal? mh2Bot = null; if (!row.IsMH2BotNull()) mh2Bot = row.MH2Bot;
                                decimal? mh3Top = null; if (!row.IsMH3TopNull()) mh3Top = row.MH3Top;
                                decimal? mh3Bot = null; if (!row.IsMH3BotNull()) mh3Bot = row.MH3Bot;
                                decimal? mh4Top = null; if (!row.IsMH4TopNull()) mh4Top = row.MH4Top;
                                decimal? mh4Bot = null; if (!row.IsMH4BotNull()) mh4Bot = row.MH4Bot;
                                string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                                
                                WorkFullLengthLiningInversionFieldCureRecord workFullLengthLiningInversionFieldCureRecord = new WorkFullLengthLiningInversionFieldCureRecord(null);
                                workFullLengthLiningInversionFieldCureRecord.InsertDirect(newWorkId, row.RefID, readingTime, headFt, boilerInF, boilerOutF, pumpFlow, pumpPsi, mh1Top, mh1Bot, mh2Top, mh2Bot, mh3Top, mh3Bot, mh4Top, mh4Bot, comments, row.Deleted, row.COMPANY_ID);
                            }
                        }
                    }

                    // Deleted field cure records 
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

                            WorkFullLengthLiningInversionFieldCureRecord workFullLengthLiningInversionFieldCureRecord = new WorkFullLengthLiningInversionFieldCureRecord(null);
                            workFullLengthLiningInversionFieldCureRecord.DeleteDirect(newWorkId, row.RefID, row.COMPANY_ID);
                        }
                    }
                }
            }
        }



        /// <summary>
        /// GetSummary
        /// </summary>
        /// <returns>Summary</returns>
        public string GetSummary()
        {
            string summary = "";
            foreach (FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row in (FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Table)
            {
                if (!row.Deleted)
                {
                    summary = summary + "Reading Time: " + row.ReadingTime.ToString("H:mm");
                    if (!row.IsHeadFtNull()) summary = summary + ", Head Ft: " + row.HeadFt.ToString();
                    if (!row.IsBoilerInFNull()) summary = summary + ", Boiler In F: " + row.BoilerInF.ToString();
                    if (!row.IsBoilerOutFNull()) summary = summary + ", Boiler Out F: " + row.BoilerOutF.ToString();
                    if (!row.IsPumpFlowNull()) summary = summary + ", Pump Flow: " + row.PumpFlow.ToString();
                    if (!row.IsPumpPsiNull()) summary = summary + ", Pump psi: " + row.PumpPsi.ToString();
                    if (!row.IsMH1TopNull()) summary = summary + ", MH Top: " + row.MH1Top.ToString();
                    if (!row.IsMH1BotNull()) summary = summary + ", MH Bot: " + row.MH1Bot.ToString();
                    if (!row.IsMH2TopNull()) summary = summary + ", MH Top: " + row.MH2Top.ToString();
                    if (!row.IsMH2BotNull()) summary = summary + ", MH Bot: " + row.MH2Bot.ToString();
                    if (!row.IsMH3TopNull()) summary = summary + ", MH Top: " + row.MH3Top.ToString();
                    if (!row.IsMH3BotNull()) summary = summary + ", MH Bot: " + row.MH3Bot.ToString();
                    if (!row.IsMH4TopNull()) summary = summary + ", MH Top: " + row.MH4Top.ToString();
                    if (!row.IsMH4BotNull()) summary = summary + ", MH Bot: " + row.MH4Bot.ToString();
                    if (!row.IsCommentsNull()) summary = summary + ", Comments: " + row.Comments.ToString();
                    summary = summary + "\n\n";
                }
            }

            return summary;
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

            foreach (FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row in (FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Table)
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
        /// Get a single field cure records. If not exists, raise an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="refId">RefID</param>
        /// <returns>FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow</returns>
        private FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow GetRow(int workId, int refId)
        {
            FlInversionFieldCureRecordTDS.InversionFieldCureRecordRow row = ((FlInversionFieldCureRecordTDS.InversionFieldCureRecordDataTable)Table).FindByWorkIDRefID(workId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.FullLengthLining.FlInversionFieldCureRecord.GetRow");
            }

            return row;
        }
    }
}
