using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJl
    /// </summary>
    public class FlatSectionJl : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJl() : base("FlatSectionJl")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlatSectionJl(DataSet data) : base(data, "FlatSectionJl")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByAssetIdArrayList
        /// </summary>
        /// <param name="assetIdArrayList">ArrayList of assetsIds</param>
        /// <param name="selected">1 = Selected by default, 0 = Not selected by default</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="workType">workType</param>        
        /// <param name="companyId">companyId</param>
        public void LoadByAssetIdArrayList(ArrayList assetIdArrayList, int selected, int currentProjectId, string workType, int companyId)
        {
            // Loading data
            FlatSectionJlGateway flatSectionJlGateway = new FlatSectionJlGateway(Data);

            flatSectionJlGateway.Table.Clear();
            flatSectionJlGateway.ClearBeforeFill = false;

            foreach (JlId jlId in assetIdArrayList)
            {
                flatSectionJlGateway.LoadByAssetIdArrayList(currentProjectId, jlId.assetId, jlId.sectionId, companyId, selected);
            }

            flatSectionJlGateway.ClearBeforeFill = true;

            // Update some fields before to show
            UpdateFieldsForSections(currentProjectId, companyId);
        }



        /// <summary>
        /// UpdateSelected
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="selected">selected</param>
        public void UpdateSelected(int workId, bool selected)
        {
            FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow = GetRow(workId);
            flatSectionJlRow.Selected = selected;
        }



        /// <summary>
        /// UpdateCommentsHistoryForSummaryEdit
        /// </summary>
        /// <param name="jlWorkId">jlWorkId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>comments</returns>
        public void UpdateCommentsHistoryForSummaryEdit(int jlWorkId, string workType, int companyId)
        {            
            foreach (FlatSectionJlTDS.FlatSectionJlRow row in (FlatSectionJlTDS.FlatSectionJlDataTable)Table)
            {               
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByWorkId(jlWorkId, companyId);
                int assetId = workGateway.GetAssetId(jlWorkId);
                int projectId = workGateway.GetProjectId(jlWorkId);
                
                if (row.AssetID == assetId)
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
                    FlatSectionJLAllComments flatSectionJLAllComments = new FlatSectionJLAllComments();
                    flatSectionJLAllComments.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                    row.Comments = flatSectionJLAllComments.GetJLOrFLOrRAComments(companyId, flatSectionJLAllComments.Table.Rows.Count, "\n");

                    // Add M1 comments
                    WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
                    workFullLengthLiningM1LateralGateway.LoadByWorkIdLateral(flWorkId, row.AssetID, companyId);
                    if (workFullLengthLiningM1LateralGateway.Table.Rows.Count > 0)
                    {
                        string m1LateralComments = workFullLengthLiningM1LateralGateway.GetComments(flWorkId, row.AssetID);
                        if (m1LateralComments != "")
                        {
                            row.Comments = row.Comments + "\n\nType: M1 Lateral Comments\nComment: " + m1LateralComments;
                        }
                    }

                    WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway();
                    workFullLengthLiningM1Gateway.LoadByWorkId(flWorkId, companyId);
                    if (workFullLengthLiningM1Gateway.Table.Rows.Count > 0)
                    {
                        string trafficControlDetails = workFullLengthLiningM1Gateway.GetTrafficControlDetails(flWorkId);
                        if (trafficControlDetails != "")
                        {
                            row.Comments = row.Comments + "\n\nType: Traffic Control Details\nComment: " + trafficControlDetails ;
                        }

                        string standardByPassComments = workFullLengthLiningM1Gateway.GetStandardBypassComments(flWorkId);
                        if (standardByPassComments != "")
                        {
                            row.Comments = row.Comments + "\n\nType: Standard Bypass Comments\nComment: " + standardByPassComments ;
                        }
                    }         
                           
                    if (!row.IsCommentsNull())
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
                }
            }            
        }
        
             
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="section_">section_</param>
        /// <param name="companyId">companyId</param>
        /// <param name="address">address</param>
        /// <param name="pipeLocated">pipeLocated</param>
        /// <param name="servicesLocated">servicesLocated</param>
        /// <param name="coInstalled">coInstalled</param>
        /// <param name="backfilledConcrete">backfilledConcrete</param>
        /// <param name="backfilledSoil">backfilledSoil</param>
        /// <param name="grouted">grouted</param>
        /// <param name="cored">cored</param>
        /// <param name="prepped">prepped</param>
        /// <param name="measured">measured</param>
        /// <param name="linerSize">linerSize</param>
        /// <param name="inProcess">inProcess</param>
        /// <param name="inStock">inStock</param>
        /// <param name="delivered">delivered</param>
        /// <param name="preVideo">preVideo</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="selected">selected</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="flange">flange</param>
        /// <param name="gasket">gasket</param>
        /// <param name="connectionType">connectionType</param>
        /// <param name="depthOfLocated">depthOfLocated</param>
        /// <param name="digRequiredPriorToLining">digRequiredPriorToLining</param>
        /// <param name="digRequiredPriorToLiningCompleted">digRequiredPriorToLiningCompleted</param>
        /// <param name="digRequiredAfterLining">digRequiredAfterLining</param>
        /// <param name="digRequiredAfterLiningCompleted">digRequiredAfterLiningCompleted</param>
        /// <param name="outOfScope">outOfScope</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdClientIssueResolved">holdClientIssueResolved</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="holdLFSIssueResolved">holdLFSIssueResolved</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepCompleted">requiresRoboticPrepCompleted</param>
        /// <param name="linerType">linerType</param>
        /// <param name="prepType">prepType</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        public void Update(int workId, int assetId, int section_, int companyId, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, string distanceFromUSMH, string distanceFromDSMH, decimal? cost, bool deleted, bool selected, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, string clientLateralId, string videoLengthToPropertyLine, bool liningThruCo, DateTime? noticeDelivered, string hamiltonInspectionNumber, string flange, string gasket, string connectionType, string depthOfLocated,   bool digRequiredPriorToLining, DateTime? digRequiredPriorToLiningCompleted, bool digRequiredAfterLining, DateTime? digRequiredAfterLiningCompleted, bool outOfScope, bool holdClientIssue, DateTime? holdClientIssueResolved, bool holdLFSIssue, DateTime? holdLFSIssueResolved, bool requiresRoboticPrep, DateTime? requiresRoboticPrepCompleted, string linerType, string prepType, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow = GetRow(workId);

            flatSectionJlRow.WorkID = workId;
            flatSectionJlRow.AssetID = assetId;
            flatSectionJlRow.Section_ = section_;
            flatSectionJlRow.COMPANY_ID = companyId;

            if ((flatSectionJlRow.IsInProcessNull()) && (inProcess.HasValue))
            {
                if (!flatSectionJlRow.IsBuildRebuildNull())
                {
                    flatSectionJlRow.BuildRebuild = flatSectionJlRow.BuildRebuild + 1;
                }
                else
                {
                    flatSectionJlRow.BuildRebuild = 1;
                }
            }

            if (address.Trim() != "") flatSectionJlRow.Address = address.Trim(); else flatSectionJlRow.SetAddressNull();
            if (pipeLocated.HasValue) flatSectionJlRow.PipeLocated = (DateTime)pipeLocated; else flatSectionJlRow.SetPipeLocatedNull();
            if (servicesLocated.HasValue) flatSectionJlRow.ServicesLocated = (DateTime)servicesLocated; else flatSectionJlRow.SetServicesLocatedNull();
            if (coInstalled.HasValue) flatSectionJlRow.CoInstalled = (DateTime)coInstalled; else flatSectionJlRow.SetCoInstalledNull();
            if (backfilledConcrete.HasValue) flatSectionJlRow.BackfilledConcrete = (DateTime)backfilledConcrete; else flatSectionJlRow.SetBackfilledConcreteNull();
            if (backfilledSoil.HasValue) flatSectionJlRow.BackfilledSoil = (DateTime)backfilledSoil; else flatSectionJlRow.SetBackfilledSoilNull();
            if (grouted.HasValue) flatSectionJlRow.Grouted = (DateTime)grouted; else flatSectionJlRow.SetGroutedNull();
            if (cored.HasValue) flatSectionJlRow.Cored = (DateTime)cored; else flatSectionJlRow.SetCoredNull();
            if (prepped.HasValue) flatSectionJlRow.Prepped = (DateTime)prepped; else flatSectionJlRow.SetPreppedNull();
            if (measured.HasValue) flatSectionJlRow.Measured = (DateTime)measured; else flatSectionJlRow.SetMeasuredNull();
            if (linerSize.Trim() != "") flatSectionJlRow.LinerSize = linerSize.Trim(); else flatSectionJlRow.SetLinerSizeNull();
            if (inProcess.HasValue) flatSectionJlRow.InProcess = (DateTime)inProcess; else flatSectionJlRow.SetInProcessNull();
            if (inStock.HasValue) flatSectionJlRow.InStock = (DateTime)inStock; else flatSectionJlRow.SetInStockNull();
            if (delivered.HasValue) flatSectionJlRow.Delivered = (DateTime)delivered; else flatSectionJlRow.SetDeliveredNull();
            if (preVideo.HasValue) flatSectionJlRow.PreVideo = (DateTime)preVideo; else flatSectionJlRow.SetPreVideoNull();
            if (linerInstalled.HasValue) flatSectionJlRow.LinerInstalled = (DateTime)linerInstalled; else flatSectionJlRow.SetLinerInstalledNull();
            if (finalVideo.HasValue) flatSectionJlRow.FinalVideo = (DateTime)finalVideo; else flatSectionJlRow.SetFinalVideoNull();
            if (distanceFromUSMH.Trim() != "") flatSectionJlRow.DistanceFromUSMH = distanceFromUSMH.Trim(); else flatSectionJlRow.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.Trim() != "") flatSectionJlRow.DistanceFromDSMH = distanceFromDSMH.Trim(); else flatSectionJlRow.SetDistanceFromDSMHNull();
            if (cost.HasValue) flatSectionJlRow.Cost = (decimal)cost; else flatSectionJlRow.SetCostNull();
            flatSectionJlRow.Deleted = deleted;
            flatSectionJlRow.Selected = selected;
            if (videoInspection.HasValue) flatSectionJlRow.VideoInspection = (DateTime)videoInspection; else flatSectionJlRow.SetVideoInspectionNull();
            flatSectionJlRow.CoRequired = coRequired;
            flatSectionJlRow.PitRequired = pitRequired;
            if (coPitLocation.Trim() != "") flatSectionJlRow.CoPitLocation = coPitLocation; else flatSectionJlRow.SetCoPitLocationNull();
            flatSectionJlRow.PostContractDigRequired = postContractDigRequired;
            if (coCutDown.HasValue) flatSectionJlRow.CoCutDown = (DateTime)coCutDown; else flatSectionJlRow.SetCoCutDownNull();
            if (finalRestoration.HasValue) flatSectionJlRow.FinalRestoration = (DateTime)finalRestoration; else flatSectionJlRow.SetFinalRestorationNull();
            if (clientLateralId.Trim() != "") flatSectionJlRow.CLientLateralID = clientLateralId; else flatSectionJlRow.SetCLientLateralIDNull();
            if (videoLengthToPropertyLine.Trim() != "") flatSectionJlRow.VideoLengthToPropertyLine = videoLengthToPropertyLine; else flatSectionJlRow.SetVideoLengthToPropertyLineNull();
            flatSectionJlRow.LiningThruCo = liningThruCo;
            if (noticeDelivered.HasValue) flatSectionJlRow.NoticeDelivered = (DateTime)noticeDelivered; else flatSectionJlRow.SetNoticeDeliveredNull();
            if (hamiltonInspectionNumber.Trim() != "") flatSectionJlRow.HamiltonInspectionNumber = hamiltonInspectionNumber.Trim(); else flatSectionJlRow.SetHamiltonInspectionNumberNull();
            if (flange.Trim() != "") flatSectionJlRow.Flange = flange.Trim(); else flatSectionJlRow.SetFlangeNull();
            if (gasket.Trim() != "") flatSectionJlRow.Gasket = gasket.Trim(); else flatSectionJlRow.SetGasketNull();
            if (connectionType.Trim() != "") flatSectionJlRow.ConnectionType = connectionType.Trim(); else flatSectionJlRow.SetConnectionTypeNull();
            if (depthOfLocated.Trim() != "") flatSectionJlRow.DepthOfLocated = depthOfLocated.Trim(); else flatSectionJlRow.SetDepthOfLocatedNull();
            flatSectionJlRow.DigRequiredPriorToLining = digRequiredPriorToLining;
            if (digRequiredPriorToLiningCompleted.HasValue) flatSectionJlRow.DigRequiredPriorToLiningCompleted = (DateTime)digRequiredPriorToLiningCompleted; else flatSectionJlRow.SetDigRequiredPriorToLiningCompletedNull();
            flatSectionJlRow.DigRequiredAfterLining = digRequiredAfterLining;
            if (digRequiredAfterLiningCompleted.HasValue) flatSectionJlRow.DigRequiredAfterLiningCompleted = (DateTime)digRequiredAfterLiningCompleted; else flatSectionJlRow.SetDigRequiredAfterLiningCompletedNull();
            flatSectionJlRow.OutOfScope = outOfScope;
            flatSectionJlRow.HoldClientIssue = holdClientIssue;
            if (holdClientIssueResolved.HasValue) flatSectionJlRow.HoldClientIssueResolved = (DateTime)holdClientIssueResolved; else flatSectionJlRow.SetHoldClientIssueResolvedNull();
            flatSectionJlRow.HoldLFSIssue = holdLFSIssue;
            if (holdLFSIssueResolved.HasValue) flatSectionJlRow.HoldLFSIssueResolved = (DateTime)holdLFSIssueResolved; else flatSectionJlRow.SetHoldLFSIssueResolvedNull(); 
            flatSectionJlRow.LateralRequiresRoboticPrep = requiresRoboticPrep;
            if (requiresRoboticPrepCompleted.HasValue) flatSectionJlRow.LateralRequiresRoboticPrepCompleted = (DateTime)requiresRoboticPrepCompleted; else flatSectionJlRow.SetLateralRequiresRoboticPrepCompletedNull();
            if (linerType != "") flatSectionJlRow.LinerType = linerType.Trim(); else flatSectionJlRow.SetLinerTypeNull();
            if (prepType != "") flatSectionJlRow.PrepType = prepType.Trim(); else flatSectionJlRow.SetPrepTypeNull();
            flatSectionJlRow.DyeTestReq = dyeTestReq;
            if (dyeTestComplete.HasValue) flatSectionJlRow.DyeTestComplete = (DateTime)dyeTestComplete; else flatSectionJlRow.SetDyeTestCompleteNull();
            if (contractYear != "") flatSectionJlRow.ContractYear = contractYear.Trim(); else flatSectionJlRow.SetContractYearNull();
        }



        /// <summary>
        /// UpdateDateField
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="field">field</param>
        /// <param name="value">value</param>
        public void UpdateDateField(int workId, string field, DateTime? value)
        {
            FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow = GetRow(workId);

            switch (field)
            {
                case "VideoInspection":
                    if (value.HasValue) flatSectionJlRow.VideoInspection = (DateTime)value; else flatSectionJlRow.SetVideoInspectionNull();
                    break;

                case "PipeLocated":
                    if (value.HasValue) flatSectionJlRow.PipeLocated = (DateTime)value; else flatSectionJlRow.SetPipeLocatedNull();
                    break;

                case "ServicesLocated":
                    if (value.HasValue) flatSectionJlRow.ServicesLocated = (DateTime)value; else flatSectionJlRow.SetServicesLocatedNull();
                    break;

                case "CoInstalled":
                    if (value.HasValue) flatSectionJlRow.CoInstalled = (DateTime)value; else flatSectionJlRow.SetCoInstalledNull();
                    break;

                case "BackfilledConcrete":
                    if (value.HasValue) flatSectionJlRow.BackfilledConcrete = (DateTime)value; else flatSectionJlRow.SetBackfilledConcreteNull();
                    break;

                case "BackfilledSoil":
                    if (value.HasValue) flatSectionJlRow.BackfilledSoil = (DateTime)value; else flatSectionJlRow.SetBackfilledSoilNull();
                    break;

                case "Grouted":
                    if (value.HasValue) flatSectionJlRow.Grouted = (DateTime)value; else flatSectionJlRow.SetGroutedNull();
                    break;

                case "Cored":
                    if (value.HasValue) flatSectionJlRow.Cored = (DateTime)value; else flatSectionJlRow.SetCoredNull();
                    break;

                case "Prepped":
                    if (value.HasValue) flatSectionJlRow.Prepped = (DateTime)value; else flatSectionJlRow.SetPreppedNull();
                    break;

                case "PreVideo":
                    if (value.HasValue) flatSectionJlRow.PreVideo = (DateTime)value; else flatSectionJlRow.SetPreVideoNull();
                    break;

                case "Measured":
                    if (value.HasValue) flatSectionJlRow.Measured = (DateTime)value; else flatSectionJlRow.SetMeasuredNull();
                    break;

                case "NoticeDelivered":
                    if (value.HasValue) flatSectionJlRow.NoticeDelivered = (DateTime)value; else flatSectionJlRow.SetNoticeDeliveredNull();
                    break;

                case "InProcess":
                    if ((flatSectionJlRow.IsInProcessNull()) && (value.HasValue))
                    {
                        if (!flatSectionJlRow.IsBuildRebuildNull())
                        {
                            flatSectionJlRow.BuildRebuild = flatSectionJlRow.BuildRebuild + 1;
                        }
                        else
                        {
                            flatSectionJlRow.BuildRebuild = 1;
                        }
                    }

                    if (value.HasValue) flatSectionJlRow.InProcess = (DateTime)value; else flatSectionJlRow.SetInProcessNull();

                    break;

                case "InStock":
                    if (value.HasValue) flatSectionJlRow.InStock = (DateTime)value; else flatSectionJlRow.SetInStockNull();
                    break;

                case "Delivered":
                    if (value.HasValue) flatSectionJlRow.Delivered = (DateTime)value; else flatSectionJlRow.SetDeliveredNull();
                    break;

                case "LinerInstalled":
                    if (value.HasValue) flatSectionJlRow.LinerInstalled = (DateTime)value; else flatSectionJlRow.SetLinerInstalledNull();
                    break;

                case "FinalVideo":
                    if (value.HasValue) flatSectionJlRow.FinalVideo = (DateTime)value; else flatSectionJlRow.SetFinalVideoNull();
                    break;

                case "CoCutDown":
                    if (value.HasValue) flatSectionJlRow.CoCutDown = (DateTime)value; else flatSectionJlRow.SetCoCutDownNull();
                    break;

                case "FinalRestoration":
                    if (value.HasValue) flatSectionJlRow.FinalRestoration = (DateTime)value; else flatSectionJlRow.SetFinalRestorationNull();
                    break;

                case "DigRequiredPriorToLiningCompleted":
                    if (value.HasValue) flatSectionJlRow.DigRequiredPriorToLiningCompleted = (DateTime)value; else flatSectionJlRow.SetDigRequiredPriorToLiningCompletedNull();
                    break;

                case "DigRequiredAfterLiningCompleted":
                    if (value.HasValue) flatSectionJlRow.DigRequiredAfterLiningCompleted = (DateTime)value; else flatSectionJlRow.SetDigRequiredAfterLiningCompletedNull();
                    break;

                case "HoldClientIssueResolved":
                    if (value.HasValue) flatSectionJlRow.HoldClientIssueResolved = (DateTime)value; else flatSectionJlRow.SetHoldClientIssueResolvedNull();
                    break;

                case "HoldLFSIssueResolved":
                    if (value.HasValue) flatSectionJlRow.HoldLFSIssueResolved = (DateTime)value; else flatSectionJlRow.SetHoldLFSIssueResolvedNull();
                    break;

                case "LateralRequiresRoboticPrepCompleted":
                    if (value.HasValue) flatSectionJlRow.LateralRequiresRoboticPrepCompleted = (DateTime)value; else flatSectionJlRow.SetLateralRequiresRoboticPrepCompletedNull();
                    break;
            }
        }



        /// <summary>
        /// UpdateBooleanField
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="field">field</param>
        /// <param name="value">value</param>
        public void UpdateBooleanField(int workId, string field, bool value)
        {
            FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow = GetRow(workId);

            switch (field)
            {
                case "CoRequired":
                    flatSectionJlRow.CoRequired = value;
                    break;

                case "OutOfScope":
                    flatSectionJlRow.OutOfScope = value;
                    break;

                case "DigRequiredPriorToLining":
                    flatSectionJlRow.DigRequiredPriorToLining = value;
                    break;

                case "DigRequiredAfterLining":
                    flatSectionJlRow.DigRequiredAfterLining = value;
                    break;

                case "HoldClientIssue":
                    flatSectionJlRow.HoldClientIssue = value;
                    break;

                case "HoldLFSIssue":
                    flatSectionJlRow.HoldLFSIssue = value;
                    break;

                case "LateralRequiresRoboticPrep":
                    flatSectionJlRow.LateralRequiresRoboticPrep = value;
                    break;
            }
        }



        /// <summary>
        /// UpdateStringField
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="field">field</param>
        /// <param name="value">value</param>
        public void UpdateStringField(int workId, string field, string value)
        {
            FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow = GetRow(workId);

            switch (field)
            {
                case "CoPitLocation":
                    if (value.Trim() != "") flatSectionJlRow.CoPitLocation = value; else flatSectionJlRow.SetCoPitLocationNull();
                    break;

                case "Comment":
                    if (value.Trim() != "") flatSectionJlRow.Comments = value; else flatSectionJlRow.SetCommentsNull();
                    break;

                case "PrepType":
                    if (value.Trim() != "") flatSectionJlRow.PrepType = value; else flatSectionJlRow.SetPrepTypeNull();
                    break;

                case "LinerType":
                    if (value.Trim() != "") flatSectionJlRow.LinerType = value; else flatSectionJlRow.SetLinerTypeNull();
                    break;

                case "ContractYear":
                    if (value.Trim() != "") flatSectionJlRow.ContractYear = value; else flatSectionJlRow.SetContractYearNull();
                    break;
            }
        }



        /// <summary>
        /// UpdateAllLaterals
        /// </summary>
        /// <param name="lateralId">lateralId</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="equiresRoboticPrepIssueCompleted">equiresRoboticPrepIssueCompleted</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        public void UpdateAllLaterals(string lateralId, bool requiresRoboticPrep, DateTime? equiresRoboticPrepIssueCompleted, bool holdClientIssue, bool holdLFSIssue, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            foreach (FlatSectionJlTDS.FlatSectionJlRow row in (FlatSectionJlTDS.FlatSectionJlDataTable)Table)
            {
                if (lateralId == row.LateralID)
                {
                    row.LateralRequiresRoboticPrep = requiresRoboticPrep;
                    if (equiresRoboticPrepIssueCompleted.HasValue) row.LateralRequiresRoboticPrepCompleted = (DateTime)equiresRoboticPrepIssueCompleted; else row.SetLateralRequiresRoboticPrepCompletedNull();
                    row.HoldClientIssue = holdClientIssue;
                    row.HoldLFSIssue = holdLFSIssue;
                    row.DyeTestReq = dyeTestReq;
                    if (dyeTestComplete.HasValue) row.DyeTestComplete = (DateTime)dyeTestComplete; else row.SetDyeTestCompleteNull();
                    if (contractYear.Trim() != "") row.ContractYear = contractYear.Trim(); else row.SetContractYearNull();
                }
            }
        }



        /// <summary>
        /// UpdateAllLateralsFromFLL
        /// </summary>
        /// <param name="lateralId">lateralId</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="equiresRoboticPrepIssueCompleted">equiresRoboticPrepIssueCompleted</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        public void UpdateAllLateralsFromFLL(string lateralId, bool requiresRoboticPrep, DateTime? equiresRoboticPrepIssueCompleted, bool holdClientIssue, bool holdLFSIssue, bool dyeTestReq, DateTime? dyeTestComplete)
        {
            foreach (FlatSectionJlTDS.FlatSectionJlRow row in (FlatSectionJlTDS.FlatSectionJlDataTable)Table)
            {
                if (lateralId == row.LateralID)
                {
                    row.LateralRequiresRoboticPrep = requiresRoboticPrep;
                    if (equiresRoboticPrepIssueCompleted.HasValue) row.LateralRequiresRoboticPrepCompleted = (DateTime)equiresRoboticPrepIssueCompleted; else row.SetLateralRequiresRoboticPrepCompletedNull();
                    row.HoldClientIssue = holdClientIssue;
                    row.HoldLFSIssue = holdLFSIssue;
                    row.DyeTestReq = dyeTestReq;
                    if (dyeTestComplete.HasValue) row.DyeTestComplete = (DateTime)dyeTestComplete; else row.SetDyeTestCompleteNull();
                }
            }
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateDirect(Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int currentProjectId, int companyId)
        {
            FlatSectionJlTDS flatSectionJlChanges = (FlatSectionJlTDS)Data.GetChanges();
            
            if (flatSectionJlChanges.FlatSectionJl.Rows.Count > 0)
            {                
                // Update sections
                foreach (FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow in (FlatSectionJlTDS.FlatSectionJlDataTable)flatSectionJlChanges.FlatSectionJl)
                {
                    // New variables
                    string address = ""; if (!flatSectionJlRow.IsNull("Address")) address = flatSectionJlRow.Address;
                    DateTime? pipeLocated = null; if (!flatSectionJlRow.IsNull("PipeLocated")) pipeLocated = flatSectionJlRow.PipeLocated;
                    DateTime? servicesLocated = null; if (!flatSectionJlRow.IsNull("ServicesLocated")) servicesLocated = flatSectionJlRow.ServicesLocated;
                    DateTime? coInstalled = null; if (!flatSectionJlRow.IsNull("CoInstalled")) coInstalled = flatSectionJlRow.CoInstalled;
                    DateTime? backfilledConcrete = null; if (!flatSectionJlRow.IsNull("BackfilledConcrete")) backfilledConcrete = flatSectionJlRow.BackfilledConcrete;
                    DateTime? backfilledSoil = null; if (!flatSectionJlRow.IsNull("BackfilledSoil")) backfilledSoil = flatSectionJlRow.BackfilledSoil;
                    DateTime? grouted = null; if (!flatSectionJlRow.IsNull("Grouted")) grouted = flatSectionJlRow.Grouted;
                    DateTime? cored = null; if (!flatSectionJlRow.IsNull("Cored")) cored = flatSectionJlRow.Cored;
                    DateTime? prepped = null; if (!flatSectionJlRow.IsNull("Prepped")) prepped = flatSectionJlRow.Prepped;
                    DateTime? measured = null; if (!flatSectionJlRow.IsNull("Measured")) measured = flatSectionJlRow.Measured;
                    string linerSize = ""; if (!flatSectionJlRow.IsNull("LinerSize")) linerSize = flatSectionJlRow.LinerSize;
                    DateTime? inProcess = null; if (!flatSectionJlRow.IsNull("Inprocess")) inProcess = flatSectionJlRow.InProcess;
                    DateTime? inStock = null; if (!flatSectionJlRow.IsNull("InStock")) inStock = flatSectionJlRow.InStock;
                    DateTime? delivered = null; if (!flatSectionJlRow.IsNull("Delivered")) delivered = flatSectionJlRow.Delivered;
                    DateTime? preVideo = null; if (!flatSectionJlRow.IsNull("PreVideo")) preVideo = flatSectionJlRow.PreVideo;
                    DateTime? linerInstalled = null; if (!flatSectionJlRow.IsNull("LinerInstalled")) linerInstalled = flatSectionJlRow.LinerInstalled;
                    DateTime? finalVideo = null; if (!flatSectionJlRow.IsNull("FinalVideo")) finalVideo = flatSectionJlRow.FinalVideo;
                    string distanceFromUSMH = ""; if (!flatSectionJlRow.IsNull("DistanceFromUSMH")) distanceFromUSMH = flatSectionJlRow.DistanceFromUSMH;
                    string clientLateralId = ""; if (!flatSectionJlRow.IsNull("ClientLateralID")) clientLateralId = flatSectionJlRow.CLientLateralID;
                    string videoLengthToPropertyLine = ""; if (!flatSectionJlRow.IsNull("VideoLengthToPropertyLine")) videoLengthToPropertyLine = flatSectionJlRow.VideoLengthToPropertyLine;
                    bool liningThruCo = flatSectionJlRow.LiningThruCo;
                    DateTime? noticeDelivered = null; if (!flatSectionJlRow.IsNull("NoticeDelivered")) noticeDelivered = flatSectionJlRow.NoticeDelivered;
                    string hamiltonInspectionNumber = ""; if (!flatSectionJlRow.IsNull("HamiltonInspectionNumber")) hamiltonInspectionNumber = flatSectionJlRow.HamiltonInspectionNumber;
                    string flange = ""; if (!flatSectionJlRow.IsNull("Flange")) flange = flatSectionJlRow.Flange;
                    string gasket = ""; if (!flatSectionJlRow.IsNull("Gasket")) gasket = flatSectionJlRow.Gasket;
                    string connectionType = ""; if (!flatSectionJlRow.IsNull("ConnectionType")) connectionType = flatSectionJlRow.ConnectionType;
                    string distanceFromDSMH = ""; if (!flatSectionJlRow.IsNull("DistanceFromDSMH")) distanceFromDSMH = flatSectionJlRow.DistanceFromDSMH;
                    string map = "";
                    decimal? cost = null; if (!flatSectionJlRow.IsNull("Cost")) cost = flatSectionJlRow.Cost;
                    bool deleted = flatSectionJlRow.Deleted;
                    DateTime? videoInspection = null; if (!flatSectionJlRow.IsNull("VideoInspection")) videoInspection = flatSectionJlRow.VideoInspection;
                    bool coRequired = flatSectionJlRow.CoRequired;
                    bool pitRequired = flatSectionJlRow.PitRequired;
                    string coPitLocation = ""; if (!flatSectionJlRow.IsNull("CoPitLocation")) coPitLocation = flatSectionJlRow.CoPitLocation;
                    bool postContractDigRequired = flatSectionJlRow.PostContractDigRequired;
                    DateTime? coCutDown = null; if (!flatSectionJlRow.IsNull("CoCutDown")) coCutDown = flatSectionJlRow.CoCutDown;
                    DateTime? finalRestoration = null; if (!flatSectionJlRow.IsNull("FinalRestoration")) finalRestoration = flatSectionJlRow.FinalRestoration;
                    int? buildRebuild = null; if (!flatSectionJlRow.IsNull("BuildRebuild")) buildRebuild = flatSectionJlRow.BuildRebuild;
                    string depthOfLocated = ""; if (!flatSectionJlRow.IsNull("DepthOfLocated")) depthOfLocated = flatSectionJlRow.DepthOfLocated;
                    bool digRequiredPriorToLining = flatSectionJlRow.DigRequiredPriorToLining;
                    DateTime? digRequiredPriorToLiningCompleted = null; if (!flatSectionJlRow.IsNull("DigRequiredPriorToLiningCompleted")) digRequiredPriorToLiningCompleted = flatSectionJlRow.DigRequiredPriorToLiningCompleted;
                    bool digRequiredAfterLining = flatSectionJlRow.DigRequiredAfterLining;
                    DateTime? digRequiredAfterLiningCompleted = null; if (!flatSectionJlRow.IsNull("DigRequiredAfterLiningCompleted")) digRequiredAfterLiningCompleted = flatSectionJlRow.DigRequiredAfterLiningCompleted;
                    bool outOfScope = flatSectionJlRow.OutOfScope;
                    bool holdClientIssue = flatSectionJlRow.HoldClientIssue;
                    DateTime? holdClientIssueResolved = null; if (!flatSectionJlRow.IsNull("HoldClientIssueResolved")) holdClientIssueResolved = flatSectionJlRow.HoldClientIssueResolved;
                    bool holdLFSIssue = flatSectionJlRow.HoldLFSIssue;
                    DateTime? holdLFSIssueResolved = null; if (!flatSectionJlRow.IsNull("HoldLFSIssueResolved")) holdLFSIssueResolved = flatSectionJlRow.HoldLFSIssueResolved;
                    bool requiresRoboticPrep = flatSectionJlRow.LateralRequiresRoboticPrep;
                    DateTime? requiresRoboticPrepCompleted = null; if (!flatSectionJlRow.IsNull("LateralRequiresRoboticPrepCompleted")) requiresRoboticPrepCompleted = flatSectionJlRow.LateralRequiresRoboticPrepCompleted;
                    string linerType = ""; if (!flatSectionJlRow.IsNull("LinerType")) linerType = flatSectionJlRow.LinerType;
                    string prepType = ""; if (!flatSectionJlRow.IsNull("PrepType")) prepType = flatSectionJlRow.PrepType;
                    bool dyeTestReq = flatSectionJlRow.DyeTestReq;
                    DateTime? dyeTestComplete = null; if (!flatSectionJlRow.IsNull("DyeTestComplete")) dyeTestComplete = flatSectionJlRow.DyeTestComplete;
                    string contractYear = ""; if (!flatSectionJlRow.IsNull("ContractYear")) contractYear = flatSectionJlRow.ContractYear;
                    
                    // Update
                    Update(countryId, provinceId, countyId, cityId, currentProjectId, flatSectionJlRow.AssetID, flatSectionJlRow.SectionWorkID, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, buildRebuild, preVideo, linerInstalled, finalVideo, cost, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, deleted, companyId, distanceFromUSMH, distanceFromDSMH, map, clientLateralId, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, address, connectionType, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, flatSectionJlRow.Section_, linerType, prepType, dyeTestReq, dyeTestComplete, contractYear);
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        public void Delete(int workId)
        {
            FlatSectionJlTDS.FlatSectionJlRow row = GetRow(workId);
            row.Deleted = true;
        }  



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int companyId)
        {
            FlatSectionJlTDS flatSectionJlChanges = (FlatSectionJlTDS)Data.GetChanges();
            if (flatSectionJlChanges.FlatSectionJl.Rows.Count > 0)
            {
                FlatSectionJlGateway flatSectionJlGateway = new FlatSectionJlGateway(flatSectionJlChanges);

                foreach (FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow in (FlatSectionJlTDS.FlatSectionJlDataTable)flatSectionJlChanges.FlatSectionJl)
                {
                    if ((flatSectionJlRow.Selected) && (flatSectionJlRow.Deleted))
                    {
                        // Get values
                        int workId = flatSectionJlRow.WorkID;
                        int assetId = flatSectionJlRow.AssetID;
                        int sectionWorkId = flatSectionJlRow.SectionWorkID;
                        
                        // Delete
                        Delete(workId, assetId, sectionWorkId, companyId);
                    }
                }
            }
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// PRIVATE METHODS
        ///

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="workType">workType</param>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="pipeLocated">pipeLocated</param>
        /// <param name="servicesLocated">servicesLocated</param>
        /// <param name="coInstalled">coInstalled</param>
        /// <param name="backfilledConcrete">backfilledConcrete</param>
        /// <param name="backfilledSoil">backfilledSoil</param>
        /// <param name="grouted">grouted</param>
        /// <param name="cored">cored</param>
        /// <param name="prepped">prepped</param>
        /// <param name="measured">measured</param>
        /// <param name="linerSize">linerSize</param>
        /// <param name="inProcess">inProcess</param>
        /// <param name="inStock">inStock</param>
        /// <param name="delivered">delivered</param>
        /// <param name="buildRebuild">buildRebuild</param>
        /// <param name="preVideo">preVideo</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="cost">cost</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="distanceFromUsmh">distanceFromUsmh</param>
        /// <param name="distanceFromDsmh">distanceFromDsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="flange">flange</param>
        /// <param name="gasket">gasket</param>
        /// <param name="address">address</param>
        /// <param name="connectionType">connectionType</param>
        /// <param name="depthOfLocated">depthOfLocated</param>
        /// <param name="digRequiredPriorToLining">digRequiredPriorToLining</param>
        /// <param name="digRequiredPriorToLiningCompleted">digRequiredPriorToLiningCompleted</param>
        /// <param name="digRequiredAfterLining">digRequiredAfterLining</param>
        /// <param name="digRequiredAfterLiningCompleted">digRequiredAfterLiningCompleted</param>
        /// <param name="outOfScope">outOfScope</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdClientIssueResolved">holdClientIssueResolved</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="holdLFSIssueResolved">holdLFSIssueResolved</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepCompleted">requiresRoboticPrepCompleted</param> 
        /// <param name="section_">section_</param>
        /// <param name="linerType">linerType</param>
        /// <param name="prepType">prepType</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        private void Update(Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int currentProjectId, int assetId, int sectionWorkId, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? buildRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, decimal? cost, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, bool deleted, int companyId, string distanceFromUsmh, string distanceFromDsmh, string mapSize, string clientLateralId, string videoLengthToPropertyLine, bool liningThruCo, DateTime? noticeDelivered, string hamiltonInspectionNumber, string flange, string gasket, string address, string connectionType, string depthOfLocated, bool digRequiredPriorToLining, DateTime? digRequiredPriorToLiningCompleted, bool digRequiredAfterLining, DateTime? digRequiredAfterLiningCompleted, bool outOfScope, bool holdClientIssue, DateTime? holdClientIssueResolved, bool holdLFSIssue, DateTime? holdLFSIssueResolved, bool requiresRoboticPrep, DateTime? requiresRoboticPrepCompleted, int section_, string linerType, string prepType, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            // Update JL laterals
            WorkUpdate(currentProjectId, assetId, sectionWorkId, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, buildRebuild, preVideo, linerInstalled, finalVideo, cost, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, deleted, companyId, videoLengthToPropertyLine, liningThruCo, noticeDelivered, hamiltonInspectionNumber, flange, gasket, depthOfLocated, digRequiredPriorToLining, digRequiredPriorToLiningCompleted, digRequiredAfterLining, digRequiredAfterLiningCompleted, outOfScope, holdClientIssue, holdClientIssueResolved, holdLFSIssue, holdLFSIssueResolved, requiresRoboticPrep, requiresRoboticPrepCompleted, linerType, prepType, dyeTestReq, dyeTestComplete, contractYear);
            LateralUpdate(currentProjectId, assetId, distanceFromDsmh, distanceFromUsmh, mapSize, companyId, clientLateralId, address, connectionType);
            UpdateFLLaterals(currentProjectId, assetId, companyId, videoInspection, hamiltonInspectionNumber, section_, requiresRoboticPrep, requiresRoboticPrepCompleted, holdClientIssue, holdLFSIssue, dyeTestReq, dyeTestComplete, contractYear); 
        }



        /// <summary>
        /// LateralUpdate
        /// </summary>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="distanceFromDsmh">distanceFromDsmh</param>
        /// <param name="distanceFromUsmh">distanceFromUsmh</param>
        /// <param name="mapSize">mapSize</param>
        /// <param name="companyId">companyId</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="address">address</param>
        /// <param name="connectionType">connectionType</param>
        private void LateralUpdate(int currentProjectId, int assetId, string distanceFromDsmh, string distanceFromUsmh, string mapSize, int companyId, string clientLateralId, string address, string connectionType)
        {
            AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();
            assetSewerLateralGateway.LoadByAssetId(assetId, companyId);
                        
            // original values
            int originalSection_ = assetSewerLateralGateway.GetSection(assetId);
            string originalAddress = assetSewerLateralGateway.GetAddress(assetId);
            string originalLateralId = assetSewerLateralGateway.GetLateralId(assetId);
            string originalLatitudeAtSection = assetSewerLateralGateway.GetLatitudeAtSection(assetId);
            string originalLongitudeAtSection = assetSewerLateralGateway.GetLongitudeAtSection(assetId);
            string originalLatitudeAtPropertyLine = assetSewerLateralGateway.GetLatitudeAtPropertyLine(assetId);
            string originalLongitudeAtPropertyLine = assetSewerLateralGateway.GetLongitudeAtPropertyLine(assetId);
            string originalState = assetSewerLateralGateway.GetState(assetId);
            string originalSize_ = assetSewerLateralGateway.GetSize(assetId);
            string originalDistanceFromUsmh = assetSewerLateralGateway.GetDistanceFromUSMH(assetId);
            string originalDistanceFromDsmh = assetSewerLateralGateway.GetDistanceFromDSMH(assetId);
            string originalMapSize = assetSewerLateralGateway.GetMapSize(assetId);
            bool originalDelete = assetSewerLateralGateway.GetDeleted(assetId);
            int originalCompanyId = assetSewerLateralGateway.GetCompanyId(assetId);
            string originalConnectionType = assetSewerLateralGateway.GetConnectionType(assetId);
            
            // new values
            string newAddress = address;
            string newDistanceFromUsmh = originalDistanceFromUsmh;
            string newDistanceFromDsmh = originalDistanceFromDsmh;
            string newMapSize = mapSize;
            string newConnectionType = connectionType;
            
            // Update Sewer lateral
            AssetSewerLateral assetSewerLateral = new AssetSewerLateral(null);
            assetSewerLateral.UpdateDirect(assetId, originalSection_, originalAddress, originalLateralId, originalLatitudeAtSection, originalLongitudeAtSection, originalLatitudeAtPropertyLine, originalLongitudeAtPropertyLine, originalState, originalSize_, originalDistanceFromUsmh, originalDistanceFromDsmh, originalMapSize, originalDelete, originalCompanyId, originalConnectionType, assetId, originalSection_, newAddress, originalLateralId, originalLatitudeAtSection, originalLongitudeAtSection, originalLatitudeAtPropertyLine, originalLongitudeAtPropertyLine, originalState, originalSize_, newDistanceFromUsmh, newDistanceFromDsmh, newMapSize, originalDelete, originalCompanyId, newConnectionType);

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            int clientId = projectGateway.GetClientID(currentProjectId);

            LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway();
            lfsAssetSewerLateralClientGateway.LoadAllByAssetIdClientId(assetId, clientId, companyId);
            
            if (lfsAssetSewerLateralClientGateway.Table.Rows.Count == 0)
            {
                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                lfsAssetSewerLateralClient.InsertDirect(assetId, clientId, clientLateralId, false, companyId);
            }
            else
            {
                LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                string originalClientLateralId = lfsAssetSewerLateralClientGateway.GetClientLateralId(assetId, clientId);
                string newClientLateralId = clientLateralId;

                lfsAssetSewerLateralClient.UpdateDirect(assetId, clientId, originalClientLateralId, false, companyId, assetId, clientId, newClientLateralId, false, companyId);
            }            
        }



        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        private void UpdateFieldsForSections(int projectId, int companyId)
        {
            foreach (FlatSectionJlTDS.FlatSectionJlRow row in (FlatSectionJlTDS.FlatSectionJlDataTable)Table)
            {
                int jlWorkId = row.WorkID;               

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
                FlatSectionJLAllComments flatSectionJLAllComments = new FlatSectionJLAllComments();
                flatSectionJLAllComments.LoadAllByJlWorkIdFlWorkIdRaWorkId(jlWorkId, flWorkId, raWorkId, companyId);

                row.Comments = flatSectionJLAllComments.GetJLOrFLOrRAComments(companyId, flatSectionJLAllComments.Table.Rows.Count, "\n");

                // Add M1 comments
                WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
                workFullLengthLiningM1LateralGateway.LoadByWorkIdLateral(flWorkId, row.AssetID, companyId);
                if (workFullLengthLiningM1LateralGateway.Table.Rows.Count > 0)
                {
                    string m1LateralComments = workFullLengthLiningM1LateralGateway.GetComments(flWorkId, row.AssetID);
                    if (m1LateralComments != "")
                    {
                        row.Comments = row.Comments + "\n\nType: M1 Lateral Comments\nComment: " + m1LateralComments ;
                    }
                }

                WorkFullLengthLiningM1Gateway workFullLengthLiningM1Gateway = new WorkFullLengthLiningM1Gateway();
                workFullLengthLiningM1Gateway.LoadByWorkId(flWorkId, companyId);
                if (workFullLengthLiningM1Gateway.Table.Rows.Count > 0)
                {
                    string trafficControlDetails = workFullLengthLiningM1Gateway.GetTrafficControlDetails(flWorkId);
                    if (trafficControlDetails != "")
                    {
                        row.Comments = row.Comments + "\n\nType: Traffic Control Details\nComment: " + trafficControlDetails;
                    }

                    string standardByPassComments = workFullLengthLiningM1Gateway.GetStandardBypassComments(flWorkId);
                    if (standardByPassComments != "")
                    {
                        row.Comments = row.Comments + "\n\nType: Standard Bypass Comments\nComment: " + standardByPassComments ;
                    }

                    string measurementFromMH = "USMH"; if (workFullLengthLiningM1Gateway.GetMeasurementFromMh(flWorkId) != "") measurementFromMH = workFullLengthLiningM1Gateway.GetMeasurementFromMh(flWorkId);

                    if (measurementFromMH == "DSMH")
                    {
                        string auxDistanceFromUSMH = row.DistanceFromUSMH;
                        row.DistanceFromUSMH = row.DistanceFromDSMH;
                        row.DistanceFromDSMH = auxDistanceFromUSMH;
                    }
                }

                if (!row.IsCommentsNull())
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

                // Update FlowOrderID
                if (!row.IsFlowOrderIDNull())
                {
                    row.LateralID = row.FlowOrderID + "-JL-" + row.LateralID;
                }
                else
                {
                    row.LateralID = "JL-" + row.LateralID;
                }

                // Update MainSize
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
            }
        }       



        /// <summary>
        /// UpdateFLLaterals
        /// </summary>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="lateral_assetId">lateral_assetId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="v1Inspection">v1Inspection</param>
        /// <param name="clientInspectionNo">clientInspectionNo</param>
        /// <param name="section_">section_</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepCompleted">requiresRoboticPrepCompleted</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        private void UpdateFLLaterals(int currentProjectId, int lateral_assetId, int companyId, DateTime? v1Inspection, string clientInspectionNo, int section_, bool requiresRoboticPrep, DateTime? requiresRoboticPrepCompleted, bool holdClientIssue, bool holdLFSIssue, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            // Load work id
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(currentProjectId, section_, "Full Length Lining", companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // ... ... Get WorkId for Full Length Lining
                int workIdFll = workGateway.GetWorkId(section_, "Full Length Lining", currentProjectId);

                // ... ... Modifications at M1
                WorkFullLengthLiningM1LateralGateway workFullLengthLiningM1LateralGateway = new WorkFullLengthLiningM1LateralGateway();
                workFullLengthLiningM1LateralGateway.LoadByWorkIdLateral(workIdFll, lateral_assetId, companyId);
                if (workFullLengthLiningM1LateralGateway.Table.Rows.Count > 0)
                {
                    // ... .... ... Load original data                
                    string originalVideoDistance = workFullLengthLiningM1LateralGateway.GetVideoDistance(workIdFll, lateral_assetId);
                    string originalClockPosition = workFullLengthLiningM1LateralGateway.GetClockPosition(workIdFll, lateral_assetId);
                    string originalDistanceToCentre = workFullLengthLiningM1LateralGateway.GetDistanceToCentre(workIdFll, lateral_assetId);
                    string originalTimeOpened = workFullLengthLiningM1LateralGateway.GetTimeOpened(workIdFll, lateral_assetId);
                    string originalReverseSetup = workFullLengthLiningM1LateralGateway.GetReverseSetup(workIdFll, lateral_assetId);
                    DateTime? originalReinstate = workFullLengthLiningM1LateralGateway.GetReinstate(workIdFll, lateral_assetId);
                    string originalComments = workFullLengthLiningM1LateralGateway.GetComments(workIdFll, lateral_assetId);
                    bool originalDeleted = workFullLengthLiningM1LateralGateway.GetDeleted(workIdFll, lateral_assetId);
                    int originalCompanyId = workFullLengthLiningM1LateralGateway.GetCompanyId(workIdFll, lateral_assetId);
                    string originalClientInspectionNo = workFullLengthLiningM1LateralGateway.GetClientInspectionNo(workIdFll, lateral_assetId);
                    DateTime? originalV1Inspection = workFullLengthLiningM1LateralGateway.GetV1Inspection(workIdFll, lateral_assetId);
                    bool originalRequiresRoboticPrep = workFullLengthLiningM1LateralGateway.GetRequiresRoboticPrep(workIdFll, lateral_assetId);
                    DateTime? originalRequiresRoboticPrepDate = workFullLengthLiningM1LateralGateway.GetRequiresRoboticPrepDate(workIdFll, lateral_assetId);
                    bool originalHoldClientIssue = workFullLengthLiningM1LateralGateway.GetHoldClientIssue(workIdFll, lateral_assetId);
                    bool originalHoldLFSIssue = workFullLengthLiningM1LateralGateway.GetHoldLFSIssue(workIdFll, lateral_assetId);
                    bool originalLinelateral = workFullLengthLiningM1LateralGateway.GetLineLateral(workIdFll, lateral_assetId);
                    bool originalDyeTestReq = workFullLengthLiningM1LateralGateway.GetDyeTestReq(workIdFll, lateral_assetId);
                    DateTime? originalDyeTestComplete = null; if (workFullLengthLiningM1LateralGateway.GetDyeTestComplete(workIdFll, lateral_assetId).HasValue) originalDyeTestComplete = workFullLengthLiningM1LateralGateway.GetDyeTestComplete(workIdFll, lateral_assetId);
                    string originalContractYear = workFullLengthLiningM1LateralGateway.GetContractYear(workIdFll, lateral_assetId);
                    
                    // New data           
                    DateTime? newV1Inspection = v1Inspection;
                    string newClientInspectionNo = clientInspectionNo;
                    bool newRequiresRoboticPrep = requiresRoboticPrep;
                    bool newHoldClientIssue = holdClientIssue;
                    bool newHoldLFSIssue = holdLFSIssue;
                    DateTime? newRequiresRoboticPrepCompleted = null; if (requiresRoboticPrepCompleted.HasValue) newRequiresRoboticPrepCompleted = requiresRoboticPrepCompleted;
                    bool newDyeTestReq = dyeTestReq;
                    DateTime? newDyeTestComplete = null; if (dyeTestComplete.HasValue) newDyeTestComplete = dyeTestComplete;
                    string newContractYear = contractYear;
                    
                    // Update work
                    WorkFullLengthLiningM1Lateral workFullLengthLiningM1Lateral = new WorkFullLengthLiningM1Lateral(null);
                    workFullLengthLiningM1Lateral.UpdateDirect(workIdFll, lateral_assetId, originalVideoDistance, originalClockPosition, originalDistanceToCentre, originalTimeOpened, originalReverseSetup, originalReinstate, originalComments, originalDeleted, originalCompanyId, originalClientInspectionNo, originalV1Inspection, originalRequiresRoboticPrep, originalRequiresRoboticPrepDate, originalHoldClientIssue, originalHoldLFSIssue, originalLinelateral, originalDyeTestReq, originalDyeTestComplete, originalContractYear, workIdFll, lateral_assetId, originalVideoDistance, originalClockPosition, originalDistanceToCentre, originalTimeOpened, originalReverseSetup, originalReinstate, originalComments, originalDeleted, originalCompanyId, newClientInspectionNo, newV1Inspection, newRequiresRoboticPrep, newRequiresRoboticPrepCompleted, newHoldClientIssue, newHoldLFSIssue, originalLinelateral, newDyeTestReq, newDyeTestComplete, newContractYear);
                }
            }
        }



        /// <summary>
        /// WorkUpdate
        /// </summary>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <param name="workType">workType</param>
        /// <param name="assetId">assetId</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="pipeLocated">pipeLocated</param>
        /// <param name="servicesLocated">servicesLocated</param>
        /// <param name="coInstalled">coInstalled</param>
        /// <param name="backfilledConcrete">backfilledConcrete</param>
        /// <param name="backfilledSoil">backfilledSoil</param>
        /// <param name="grouted">grouted</param>
        /// <param name="cored">cored</param>
        /// <param name="prepped">prepped</param>
        /// <param name="measured">measured</param>
        /// <param name="linerSize">linerSize</param>
        /// <param name="inProcess">inProcess</param>
        /// <param name="inStock">inStock</param>
        /// <param name="delivered">delivered</param>
        /// <param name="buildRebuild">buildRebuild</param>
        /// <param name="preVideo">preVideo</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="cost">cost</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="flange">flange</param>
        /// <param name="gasket">gasket</param>
        /// <param name="depthOfLocated">depthOfLocated</param>
        /// <param name="digRequiredPriorToLining">digRequiredPriorToLining</param>
        /// <param name="digRequiredPriorToLiningCompleted">digRequiredPriorToLiningCompleted</param>
        /// <param name="digRequiredAfterLining">digRequiredAfterLining</param>
        /// <param name="digRequiredAfterLiningCompleted">digRequiredAfterLiningCompleted</param>
        /// <param name="outOfScope">outOfScope</param>
        /// <param name="holdClientIssue">holdClientIssue</param>
        /// <param name="holdClientIssueResolved">holdClientIssueResolved</param>
        /// <param name="holdLFSIssue">holdLFSIssue</param>
        /// <param name="holdLFSIssueResolved">holdLFSIssueResolved</param>
        /// <param name="requiresRoboticPrep">requiresRoboticPrep</param>
        /// <param name="requiresRoboticPrepCompleted">requiresRoboticPrepCompleted</param>
        /// <param name="linerType">linerType</param>
        /// <param name="prepType">prepType</param>
        /// <param name="dyeTestReq">dyeTestReq</param>
        /// <param name="dyeTestComplete">dyeTestComplete</param>
        private void WorkUpdate(int currentProjectId, int assetId, int sectionWorkId, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? buildRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, decimal? cost, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, bool deleted, int companyId, string videoLengthToPropertyLine, bool liningThruCo, DateTime? noticeDelivered, string hamiltonInspectionNumber, string flange, string gasket, string depthOfLocated, bool digRequiredPriorToLining, DateTime? digRequiredPriorToLiningCompleted, bool digRequiredAfterLining, DateTime? digRequiredAfterLiningCompleted, bool outOfScope, bool holdClientIssue, DateTime? holdClientIssueResolved, bool holdLFSIssue, DateTime? holdLFSIssueResolved, bool requiresRoboticPrep, DateTime? requiresRoboticPrepCompleted, string linerType, string prepType, bool dyeTestReq, DateTime? dyeTestComplete, string contractYear)
        {
            // Load work id
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(currentProjectId, assetId, "Junction Lining Lateral", companyId);
            int workId = workGateway.GetWorkId(assetId, "Junction Lining Lateral", currentProjectId);

            WorkJunctionLiningLateralGateway workJunctionLiningLateralGateway = new WorkJunctionLiningLateralGateway();
            workJunctionLiningLateralGateway.LoadByWorkId(workId, companyId);

            // Load original data
            DateTime? originalPipeLocated = workJunctionLiningLateralGateway.GetPipeLocated(workId);
            DateTime? originalServicesLocated = workJunctionLiningLateralGateway.GetServicesLocated(workId);
            DateTime? originalCoInstalled = workJunctionLiningLateralGateway.GetCoInstalled(workId);
            DateTime? originalBackfilledConcrete = workJunctionLiningLateralGateway.GetBackfilledConcrete(workId);
            DateTime? originalBackfilledSoil = workJunctionLiningLateralGateway.GetBackfilledSoil(workId);
            DateTime? originalGrouted = workJunctionLiningLateralGateway.GetGrouted(workId);
            DateTime? originalCored = workJunctionLiningLateralGateway.GetCored(workId);
            DateTime? originalPrepped = workJunctionLiningLateralGateway.GetPrepped(workId);
            DateTime? originalMeasured = workJunctionLiningLateralGateway.GetMeasured(workId);
            string originalLinerSize = workJunctionLiningLateralGateway.GetLinerSize(workId);
            DateTime? originalInProcess = workJunctionLiningLateralGateway.GetInProcess(workId);
            DateTime? originalInStock = workJunctionLiningLateralGateway.GetInStock(workId);
            DateTime? originalDelivered = workJunctionLiningLateralGateway.GetDelivered(workId);
            int? originalBuildRebuild = workJunctionLiningLateralGateway.GetBuildRebuild(workId);
            DateTime? originalPreVideo = workJunctionLiningLateralGateway.GetPreVideo(workId);
            DateTime? originalLinerInstalled = workJunctionLiningLateralGateway.GetLinerInstalled(workId);
            DateTime? originalFinalVideo = workJunctionLiningLateralGateway.GetFinalVideo(workId);
            decimal? originalCost = workJunctionLiningLateralGateway.GetCost(workId);
            DateTime? originalVideoInspection = workJunctionLiningLateralGateway.GetVideoInspection(workId);
            bool originalCoRequired = workJunctionLiningLateralGateway.GetCoRequired(workId);
            bool originalPitRequired = workJunctionLiningLateralGateway.GetPitRequired(workId);
            string originalCoPitLocation = workJunctionLiningLateralGateway.GetCoPitLocation(workId);
            bool originalPostContractDigRequired = workJunctionLiningLateralGateway.GetPostContractDigRequired(workId);
            DateTime? originalCoCutDown = workJunctionLiningLateralGateway.GetCoCutDown(workId);
            DateTime? originalFinalRestoration = workJunctionLiningLateralGateway.GetFinalRestoration(workId);
            string originalVideoLengthToPropertyLine = workJunctionLiningLateralGateway.GetVideoLengthToPropertyLine(workId);
            bool originalLiningThruCo = workJunctionLiningLateralGateway.GetLiningThruCo(workId);
            DateTime? originalNoticeDelivered = workJunctionLiningLateralGateway.GetNoticeDelivered(workId);
            string originalHamiltonInspectionNumber = workJunctionLiningLateralGateway.GetHamiltonInspectionNumber(workId);
            string originalFlange = workJunctionLiningLateralGateway.GetFlange(workId);
            string originalGasket = workJunctionLiningLateralGateway.GetGasket(workId);
            string originalDepthOfLocated = workJunctionLiningLateralGateway.GetDepthOfLocated(workId);            
            bool originalDigRequiredPriorToLining = workJunctionLiningLateralGateway.GetDigRequiredPriorToLining(workId);
            DateTime? originalDigRequiredPriorToLiningCompleted = workJunctionLiningLateralGateway.GetDigRequiredPriorToLiningCompleted(workId);
            bool originalDigRequiredAfterLining = workJunctionLiningLateralGateway.GetDigRequiredAfterLining(workId);
            DateTime? originalDigRequiredAfterLiningCompleted = workJunctionLiningLateralGateway.GetDigRequiredAfterLiningCompleted(workId);
            bool originalOutOfScope = workJunctionLiningLateralGateway.GetOutOfScope(workId);
            bool originalHoldClientIssue = workJunctionLiningLateralGateway.GetHoldClientIssue(workId);
            DateTime? originalHoldClientIssueResolved = workJunctionLiningLateralGateway.GetHoldClientIssueResolved(workId);
            bool originalHoldLFSIssue = workJunctionLiningLateralGateway.GetHoldLFSIssue(workId);
            DateTime? originalHoldLFSIssueResolved = workJunctionLiningLateralGateway.GetHoldLFSIssueResolved(workId);
            bool originalRequiresRoboticPrep = workJunctionLiningLateralGateway.GetLateralRequiresRoboticPrep(workId);
            DateTime? originalRequiresRoboticPrepCompleted = workJunctionLiningLateralGateway.GetLateralRequiresRoboticPrepCompleted(workId);
            string originalLinerType = workJunctionLiningLateralGateway.GetLinerType(workId);
            string originalPrepType = workJunctionLiningLateralGateway.GetPrepType(workId);
            bool originalDyeTestReq = workJunctionLiningLateralGateway.GetDyeTestReq(workId);
            DateTime? originalDyeTestComplete = null; if (workJunctionLiningLateralGateway.GetDyeTestComplete(workId).HasValue) originalDyeTestComplete = workJunctionLiningLateralGateway.GetDyeTestComplete(workId);
            string originalContractYear = workJunctionLiningLateralGateway.GetContractYear(workId);

            // New data
            DateTime? newPipeLocated = pipeLocated;
            DateTime? newServicesLocated = servicesLocated;
            DateTime? newCoInstalled = coInstalled;
            DateTime? newBackfilledConcrete = backfilledConcrete;
            DateTime? newBackfilledSoil = backfilledSoil;
            DateTime? newGrouted = grouted;
            DateTime? newCored = cored;
            DateTime? newPrepped = prepped;
            DateTime? newMeasured = measured;
            string newLinerSize = linerSize;
            DateTime? newInProcess = inProcess;
            DateTime? newInStock = inStock;
            DateTime? newDelivered = delivered;
            int? newBuildRebuild = buildRebuild;
            DateTime? newPreVideo = preVideo;
            DateTime? newLinerInstalled = linerInstalled;
            DateTime? newFinalVideo = finalVideo;
            decimal? newCost = cost;
            DateTime? newVideoInspection = videoInspection;
            bool newCoRequired = coRequired;
            bool newPitRequired = pitRequired;
            string newCoPitLocation = coPitLocation;
            bool newPostContractDigRequired = postContractDigRequired;
            DateTime? newCoCutDown = coCutDown;
            DateTime? newFinalRestoration = finalRestoration;
            string newVideoLengthToPropertyLine = videoLengthToPropertyLine;
            bool newLiningThruCo = liningThruCo;
            DateTime? newNoticeDelivered = noticeDelivered;
            string newHamiltonInspectionNumber = hamiltonInspectionNumber;
            string newFlange = flange;
            string newGasket = gasket;
            string newDepthOfLocated = depthOfLocated;            
            bool newDigRequiredPriorToLining = digRequiredPriorToLining;
            DateTime? newDigRequiredPriorToLiningCompleted = digRequiredPriorToLiningCompleted;
            bool newDigRequiredAfterLining = digRequiredAfterLining;
            DateTime? newDigRequiredAfterLiningCompleted = digRequiredAfterLiningCompleted;
            bool newOutOfScope = outOfScope;
            bool newHoldClientIssue = holdClientIssue;
            DateTime? newHoldClientIssueResolved = holdClientIssueResolved;
            bool newHoldLFSIssue = holdLFSIssue;
            DateTime? newHoldLFSIssueResolved = holdLFSIssueResolved;
            bool newRequiresRoboticPrep = requiresRoboticPrep;
            DateTime? newRequiresRoboticPrepCompleted = requiresRoboticPrepCompleted;
            string newLinerType = linerType;
            string newPrepType = prepType;
            bool newDyeTestReq = dyeTestReq;
            DateTime? newDyeTestComplete = null; if (dyeTestComplete.HasValue) newDyeTestComplete = dyeTestComplete;
            string newContractYear = contractYear;

            // Update work
            WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);
            workJunctionLiningLateral.UpdateDirect(workId, sectionWorkId, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalCost, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalCoCutDown, originalFinalRestoration, false, companyId, originalVideoLengthToPropertyLine, originalLiningThruCo, originalNoticeDelivered, originalHamiltonInspectionNumber, originalFlange, originalGasket, originalDepthOfLocated, originalDigRequiredPriorToLining, originalDigRequiredPriorToLiningCompleted, originalDigRequiredAfterLining, originalDigRequiredAfterLiningCompleted, originalOutOfScope, originalHoldClientIssue, originalHoldClientIssueResolved, originalHoldLFSIssue, originalHoldLFSIssueResolved, originalRequiresRoboticPrep, originalRequiresRoboticPrepCompleted, originalLinerType, originalPrepType, originalDyeTestReq, originalDyeTestComplete, newPipeLocated, newServicesLocated, newCoInstalled, newBackfilledConcrete, newBackfilledSoil, newGrouted, newCored, newPrepped, newMeasured, newLinerSize, newInProcess, newInStock, newDelivered, newBuildRebuild, newPreVideo, newLinerInstalled, newFinalVideo, newCost, newVideoInspection, newCoRequired, newPitRequired, newCoPitLocation, newPostContractDigRequired, newCoCutDown, newFinalRestoration, companyId, newVideoLengthToPropertyLine, newLiningThruCo, newNoticeDelivered, newHamiltonInspectionNumber, newFlange, newGasket, newDepthOfLocated, newDigRequiredPriorToLining, newDigRequiredPriorToLiningCompleted, newDigRequiredAfterLining, newDigRequiredAfterLiningCompleted, newOutOfScope, newHoldClientIssue, newHoldClientIssueResolved, newHoldLFSIssue, newHoldLFSIssueResolved, newRequiresRoboticPrep, newRequiresRoboticPrepCompleted, newLinerType, newPrepType, newDyeTestReq, newDyeTestComplete, originalContractYear, newContractYear);
        }    


               
        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="assetIdLateral">assetIdLateral</param>
        /// <param name="sectionWorkId">sectionWorkId</param>
        /// <param name="companyId">companyId</param>
        private void Delete(int workId, int assetIdLateral, int sectionWorkId, int companyId)
        {
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);
            int currentProjectId = workGateway.GetProjectId(workId);

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            int clientId = projectGateway.GetClientID(currentProjectId);
    
            // delete lateral work
            WorkJunctionLiningLateral workJunctionLiningLateral = new WorkJunctionLiningLateral(null);            
            workJunctionLiningLateral.DeleteDirect(workId, sectionWorkId, companyId);

            // delete lfs lateral
            LfsAssetSewerLateral lfsAssetSewerLateral = new LfsAssetSewerLateral(null);
            bool isDeleted = lfsAssetSewerLateral.DeleteDirect(assetIdLateral, companyId);

            if (isDeleted)
            {
                // delete lfs lateral client
                LfsAssetSewerLateralClientGateway lfsAssetSewerLateralClientGateway = new LfsAssetSewerLateralClientGateway();
                lfsAssetSewerLateralClientGateway.LoadByAssetIdClientId(assetIdLateral, clientId, companyId);

                if (lfsAssetSewerLateralClientGateway.Table.Rows.Count > 0)
                {
                    LfsAssetSewerLateralClient lfsAssetSewerLateralClient = new LfsAssetSewerLateralClient(null);
                    lfsAssetSewerLateralClient.DeleteDirect(assetIdLateral, clientId, companyId);
                }
            }
        }



        /// <summary>
        /// Get a single FlatSectionJlRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="assetId_">assetId_</param>
        /// <returns>Row obtained</returns>
        private FlatSectionJlTDS.FlatSectionJlRow GetRow(int workId)
        {
            FlatSectionJlTDS.FlatSectionJlRow flatSectionJlRow = ((FlatSectionJlTDS.FlatSectionJlDataTable)Table).FindByWorkID(workId);

            if (flatSectionJlRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.JunctionLining.FlatSectionJl.GetRow");
            }

            return flatSectionJlRow;
        }



    }
}