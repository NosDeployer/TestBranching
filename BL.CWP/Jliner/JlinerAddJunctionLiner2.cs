using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerAddJunctionLiner2
    /// </summary>
    public class JlinerAddJunctionLiner2 : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerAddJunctionLiner2()
            : base("JunctionLiner2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerAddJunctionLiner2(DataSet data)
            : base(data, "JunctionLiner2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadForAdd
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void LoadForAdd(Guid id, int companyId)
        {
            JlinerAddJunctionLiner2Gateway jlinerAddJunctionLiner2Gateway = new JlinerAddJunctionLiner2Gateway(Data);
            jlinerAddJunctionLiner2Gateway.LoadAllById(id, companyId);

            foreach (JlinerAddTDS.JunctionLiner2Row lfsJunctionLiner2Row in (JlinerAddTDS.JunctionLiner2DataTable)Table)
            {
                lfsJunctionLiner2Row.History = "---Loaded---";
            }

            Table.AcceptChanges();
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detailID">detailID</param>
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
        /// <param name="buildRebuild">buildRebuild</param>
        /// <param name="preVideo">preVideo</param>
        /// <param name="linerInstalled">linerInstalled</param>
        /// <param name="finalVideo">finalVideo</param>
        /// <param name="distanceFromUSMH">distanceFromUSMH</param>
        /// <param name="distanceFromDSMH">distanceFromDSMH</param>
        /// <param name="map">map</param>
        /// <param name="issue">issue</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="pitRequired">pitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="clientLateralID">clientLateralID</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(Guid id, int companyId, string detailID, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int buildRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, double? distanceFromUSMH, double? distanceFromDSMH, string map, string issue, decimal? cost, bool deleted, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, string comments, string history, DateTime? coCutDown, DateTime? finalRestoration, string clientLateralID, string videoLengthToPropertyLine, bool liningThruCo, string hamiltonInspectionNumber, DateTime? noticeDelivered, bool inDatabase)
        {
            JlinerAddTDS.JunctionLiner2Row row = ((JlinerAddTDS.JunctionLiner2DataTable)Table).NewJunctionLiner2Row();

            row.ID = id;
            row.RefID = GetNewRefId();
            row.COMPANY_ID = companyId;
            if (detailID != "") row.DetailID = detailID; else row.SetDetailIDNull();
            if (address != "") row.Address = address; else row.SetAddressNull();
            if (pipeLocated.HasValue) row.PipeLocated = (DateTime)pipeLocated; else row.SetPipeLocatedNull();
            if (servicesLocated.HasValue) row.ServicesLocated = (DateTime)servicesLocated; else row.SetServicesLocatedNull();
            if (coInstalled.HasValue) row.CoInstalled = (DateTime)coInstalled; else row.SetCoInstalledNull();
            if (backfilledConcrete.HasValue) row.BackfilledConcrete = (DateTime)backfilledConcrete; else row.SetBackfilledConcreteNull();
            if (backfilledSoil.HasValue) row.BackfilledSoil = (DateTime)backfilledSoil; else row.SetBackfilledSoilNull();
            if (grouted.HasValue) row.Grouted = (DateTime)grouted; else row.SetGroutedNull();
            if (cored.HasValue) row.Cored = (DateTime)cored; else row.SetCoredNull();
            if (prepped.HasValue) row.Prepped = (DateTime)prepped; else row.SetPreppedNull();
            if (measured.HasValue) row.Measured = (DateTime)measured; else row.SetMeasuredNull();
            if (linerSize != "") row.LinerSize = linerSize; else row.SetLinerSizeNull();
            if (inProcess.HasValue) row.InProcess = (DateTime)inProcess; else row.SetInProcessNull();
            if (inStock.HasValue) row.InStock = (DateTime)inStock; else row.SetInStockNull();
            if (delivered.HasValue) row.Delivered = (DateTime)delivered; else row.SetDeliveredNull();
            row.BuildRebuild = buildRebuild;
            if (preVideo.HasValue) row.PreVideo = (DateTime)preVideo; else row.SetPreVideoNull();
            if (linerInstalled.HasValue) row.LinerInstalled = (DateTime)linerInstalled; else row.SetLinerInstalledNull();
            if (finalVideo.HasValue) row.FinalVideo = (DateTime)finalVideo; else row.SetFinalVideoNull();
            if (distanceFromUSMH.HasValue) row.DistanceFromUSMH = (double)distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.HasValue) row.DistanceFromDSMH = (double)distanceFromDSMH; else row.SetDistanceFromDSMHNull();
            if (map != "") row.Map = map; else row.SetMapNull();
            row.Issue = issue;
            if (cost.HasValue) row.Cost = (decimal)cost; else row.SetCostNull();
            row.Deleted = deleted;
            if (videoInspection.HasValue) row.VideoInspection = (DateTime)videoInspection; else row.SetVideoInspectionNull();
            row.CoRequired = coRequired;
            row.PitRequired = pitRequired;
            if (coPitLocation != "") row.CoPitLocation = coPitLocation; else row.SetCoPitLocationNull();
            row.PostContractDigRequired = postContractDigRequired;            
            if (comments != "") row.Comments = comments; else row.SetCommentsNull();
            if (history != "") row.History = history; else row.SetHistoryNull();
            if (coCutDown.HasValue) row.CoCutDown = (DateTime)coCutDown; else row.SetCoCutDownNull();
            if (finalRestoration.HasValue) row.FinalRestoration = (DateTime)finalRestoration; else row.SetFinalRestorationNull();
            if (clientLateralID != "") row.ClientLateralID = clientLateralID; else row.SetClientLateralIDNull();
            if (videoLengthToPropertyLine != "") row.VideoLengthToPropertyLine = videoLengthToPropertyLine; else row.SetVideoLengthToPropertyLineNull();
            row.LiningThruCo = liningThruCo;
            if (hamiltonInspectionNumber != "") row.HamiltonInspectionNumber = hamiltonInspectionNumber; else row.SetHamiltonInspectionNumberNull();
            if (noticeDelivered.HasValue) row.NoticeDelivered = (DateTime)noticeDelivered; else row.SetNoticeDeliveredNull();
            row.InDatabase = inDatabase;

            ((JlinerAddTDS.JunctionLiner2DataTable)Table).AddJunctionLiner2Row(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        public void Update(Guid id, int refId, int companyId, string detailID, string address, double? distanceFromUSMH, double? distanceFromDSMH)
        {
            JlinerAddTDS.JunctionLiner2Row row = GetRow(id, refId, companyId);

            if (detailID != "") row.DetailID = detailID; else row.SetDetailIDNull();
            if (address != "") row.Address = address; else row.SetAddressNull();
            if (distanceFromUSMH.HasValue) row.DistanceFromUSMH = (double)distanceFromUSMH; else row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.HasValue) row.DistanceFromDSMH = (double)distanceFromDSMH; else row.SetDistanceFromDSMHNull();
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public void Delete(Guid id, int refId, int companyId)
        {
            JlinerAddTDS.JunctionLiner2Row row = GetRow(id, refId, companyId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        public void Save(Guid id, int companyId)
        {
            JlinerAddTDS jlinerAddChanges = (JlinerAddTDS)Data.GetChanges();

            if (jlinerAddChanges.JunctionLiner2.Rows.Count > 0)
            {
                JlinerAddJunctionLiner2Gateway jlinerAddJunctionLiner2Gateway  = new JlinerAddJunctionLiner2Gateway(jlinerAddChanges);

                foreach (JlinerAddTDS.JunctionLiner2Row row in (JlinerAddTDS.JunctionLiner2DataTable)jlinerAddChanges.JunctionLiner2)
                {
                    // Insert new laterals 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        string detailId = ""; if (!row.IsDetailIDNull()) detailId = row.DetailID;
                        string address = ""; if (!row.IsAddressNull()) address = row.Address;
                        DateTime? pipeLocated = null; if (!row.IsPipeLocatedNull()) pipeLocated = row.PipeLocated;
                        DateTime? servicesLocated = null; if (!row.IsServicesLocatedNull()) servicesLocated = row.ServicesLocated;
                        DateTime? coInstalled = null; if (!row.IsCoInstalledNull()) coInstalled = row.CoInstalled;
                        DateTime? backfilledConcrete = null; if (!row.IsBackfilledConcreteNull()) backfilledConcrete = row.BackfilledConcrete;
                        DateTime? backfilledSoil = null; if (!row.IsBackfilledSoilNull()) backfilledSoil = row.BackfilledSoil;
                        DateTime? grouted = null; if (!row.IsGroutedNull()) grouted = row.Grouted;
                        DateTime? cored = null; if (!row.IsCoredNull()) cored = row.Cored;
                        DateTime? prepped = null; if (!row.IsPreppedNull()) prepped = row.Prepped;
                        DateTime? measured = null; if (!row.IsMeasuredNull()) measured = row.Measured;
                        string linerSize = ""; if (!row.IsLinerSizeNull()) linerSize = row.LinerSize;
                        DateTime? inProcess = null; if (!row.IsInProcessNull()) inProcess = row.InProcess;
                        DateTime? inStock = null; if (!row.IsInStockNull()) inStock = row.InStock;
                        DateTime? delivered = null; if (!row.IsDeliveredNull()) delivered = row.Delivered;
                        int? buildRebuild = null; if (!row.IsBuildRebuildNull()) buildRebuild = row.BuildRebuild;
                        DateTime? preVideo = null; if (!row.IsPreVideoNull()) preVideo = row.PreVideo;
                        DateTime? linerInstalled = null; if (!row.IsLinerInstalledNull()) linerInstalled = row.LinerInstalled;
                        DateTime? finalVideo = null; if (!row.IsFinalVideoNull()) finalVideo = row.FinalVideo;
                        double? distanceFromUSMH = null; if (!row.IsDistanceFromUSMHNull()) distanceFromUSMH = row.DistanceFromUSMH;
                        double? distanceFromDSMH = null; if (!row.IsDistanceFromDSMHNull()) distanceFromDSMH = row.DistanceFromDSMH;
                        string map = ""; if (!row.IsMapNull()) map = row.Map;
                        string issue = row.Issue;
                        decimal? cost = null; if (!row.IsCostNull()) cost = row.Cost;
                        bool deleted = row.Deleted;
                        DateTime? videoInspections = null; if (!row.IsVideoInspectionNull()) videoInspections = row.VideoInspection;
                        bool coRequired = row.CoRequired;
                        bool pitRequired = row.PitRequired;
                        string coPitLocation = ""; if (!row.IsCoPitLocationNull()) coPitLocation = row.CoPitLocation;
                        bool postContractDigRequired = row.PostContractDigRequired;
                        string comments = ""; if (!row.IsCommentsNull()) comments = row.Comments;
                        string history = ""; if (!row.IsHistoryNull()) history = row.History;
                        DateTime? coCutDown = null; if (!row.IsCoCutDownNull()) coCutDown = row.CoCutDown;
                        DateTime? finalRestoration = null; if (!row.IsFinalRestorationNull()) finalRestoration = row.FinalRestoration;
                        string clientLateralID = ""; if (!row.IsClientLateralIDNull()) clientLateralID = row.ClientLateralID;
                        string videoLengthToPropertyLine = ""; if  (!row.IsVideoLengthToPropertyLineNull()) videoLengthToPropertyLine = row.VideoLengthToPropertyLine;
                        bool liningThruCo = row.LiningThruCo;
                        string hamiltonInspectionNumber = ""; if (!row.IsHamiltonInspectionNumberNull()) hamiltonInspectionNumber = row.HamiltonInspectionNumber;
                        DateTime? noticeDelivered = null; if (!row.IsNoticeDeliveredNull()) noticeDelivered = row.NoticeDelivered;

                        Jliner jliner = new Jliner(null);
                        jliner.InsertDirect(row.ID, row.RefID, row.COMPANY_ID, detailId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, buildRebuild, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH, map, issue, cost, deleted, videoInspections, coRequired, pitRequired, coPitLocation, postContractDigRequired, comments, history, coCutDown, finalRestoration, clientLateralID, videoLengthToPropertyLine, liningThruCo, hamiltonInspectionNumber, noticeDelivered);
                    }

                    // Update laterals
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int refId = row.RefID;

                        // original values
                        string originalDetailId = jlinerAddJunctionLiner2Gateway.GetDetailIDOriginal(id, refId, companyId);
                        string originalAddress = jlinerAddJunctionLiner2Gateway.GetAddressOriginal(id, refId, companyId);
                        DateTime? originalPipeLocated = jlinerAddJunctionLiner2Gateway.GetPipeLocatedOriginal(id, refId, companyId);
                        DateTime? originalServicesLocated = jlinerAddJunctionLiner2Gateway.GetServicesLocatedOriginal(id, refId, companyId);
                        DateTime? originalCoInstalled = jlinerAddJunctionLiner2Gateway.GetCoInstalledOriginal(id, refId, companyId);
                        DateTime? originalBackfilledConcrete = jlinerAddJunctionLiner2Gateway.GetBackfilledConcreteOriginal(id, refId, companyId);
                        DateTime? originalBackfilledSoil = jlinerAddJunctionLiner2Gateway.GetBackfilledSoilOriginal (id, refId, companyId);
                        DateTime? originalGrouted = jlinerAddJunctionLiner2Gateway.GetGroutedOriginal(id, refId, companyId);
                        DateTime? originalCored = jlinerAddJunctionLiner2Gateway.GetCoredOriginal(id, refId, companyId);
                        DateTime? originalPrepped = jlinerAddJunctionLiner2Gateway.GetPreppedOriginal(id, refId, companyId);
                        DateTime? originalMeasured = jlinerAddJunctionLiner2Gateway.GetMeasuredOriginal (id, refId, companyId);
                        string originalLinerSize = jlinerAddJunctionLiner2Gateway.GetLinerSizeOriginal(id, refId, companyId);
                        DateTime? originalInProcess = jlinerAddJunctionLiner2Gateway.GetInProcessOriginal(id, refId, companyId);
                        DateTime? originalInStock = jlinerAddJunctionLiner2Gateway.GetInStockOriginal(id, refId, companyId);
                        DateTime? originalDelivered = jlinerAddJunctionLiner2Gateway.GetDeliveredOriginal(id, refId, companyId);
                        int? originalBuildRebuild = jlinerAddJunctionLiner2Gateway.GetBuildRebuildOriginal(id, refId, companyId);
                        DateTime? originalPreVideo = jlinerAddJunctionLiner2Gateway.GetPreVideoOriginal(id, refId, companyId);
                        DateTime? originalLinerInstalled = jlinerAddJunctionLiner2Gateway.GetLinerInstalledOriginal(id, refId, companyId);
                        DateTime? originalFinalVideo = jlinerAddJunctionLiner2Gateway.GetFinalVideoOriginal(id, refId, companyId);
                        double? originalDistanceFromUSMH = jlinerAddJunctionLiner2Gateway.GetDistanceFromUSMHOriginal(id, refId, companyId);
                        double? originalDistanceFromDSMH = jlinerAddJunctionLiner2Gateway.GetDistanceFromDSMHOriginal(id, refId, companyId);
                        string originalMap = jlinerAddJunctionLiner2Gateway.GetMapOriginal(id, refId, companyId);
                        string originalIssue = jlinerAddJunctionLiner2Gateway.GetIssueOriginal(id, refId, companyId);
                        decimal? originalCost = jlinerAddJunctionLiner2Gateway.GetCostOriginal(id, refId, companyId);
                        DateTime? originalVideoInspection = jlinerAddJunctionLiner2Gateway.GetVideoInspectionOriginal(id, refId, companyId);
                        bool originalCoRequired =jlinerAddJunctionLiner2Gateway.GetCoRequiredOriginal(id, refId, companyId);
                        bool originalPitRequired = jlinerAddJunctionLiner2Gateway.GetPitRequiredOriginal(id, refId, companyId);
                        string originalCoPitLocation = jlinerAddJunctionLiner2Gateway.GetCoPitLocationOriginal(id, refId, companyId);
                        bool originalPostContractDigRequired =jlinerAddJunctionLiner2Gateway.GetPostContractDigRequiredOriginal(id, refId, companyId);
                        string originalComments = jlinerAddJunctionLiner2Gateway.GetCommentsOriginal(id, refId, companyId);
                        string originalHistory = jlinerAddJunctionLiner2Gateway.GetHistoryOriginal(id, refId, companyId);
                        DateTime? originalCoCutDown = jlinerAddJunctionLiner2Gateway.GetCoCutDownOriginal(id, refId, companyId);
                        DateTime? originalFinalRestoration = jlinerAddJunctionLiner2Gateway.GetFinalRestorationOriginal(id, refId, companyId);
                        string originalClientLateralID = jlinerAddJunctionLiner2Gateway.GetClientLateralIDOriginal(id, refId, companyId);
                        string originalVideoLengthToPropertyLine = jlinerAddJunctionLiner2Gateway.GetVideoLengthToPropertyLineOriginal(id, refId, companyId);
                        bool originalLiningThruCo = jlinerAddJunctionLiner2Gateway.GetLiningThruCoOriginal(id, refId, companyId);
                        string originalHamiltonInspectionNumber = jlinerAddJunctionLiner2Gateway.GetHamiltonInspectionNumberOriginal(id, refId, companyId);
                        DateTime? originalNoticeDelivered = jlinerAddJunctionLiner2Gateway.GetNoticeDeliveredOriginal(id, refId, companyId);

                        // new values
                        string newDetailId = jlinerAddJunctionLiner2Gateway.GetDetailID(id, refId, companyId);
                        string newAddress = jlinerAddJunctionLiner2Gateway.GetAddress(id, refId, companyId);
                        DateTime? newPipeLocated = jlinerAddJunctionLiner2Gateway.GetPipeLocated(id, refId, companyId);
                        DateTime? newServicesLocated = jlinerAddJunctionLiner2Gateway.GetServicesLocated(id, refId, companyId);
                        DateTime? newCoInstalled = jlinerAddJunctionLiner2Gateway.GetCoInstalled(id, refId, companyId);
                        DateTime? newBackfilledConcrete = jlinerAddJunctionLiner2Gateway.GetBackfilledConcrete(id, refId, companyId);
                        DateTime? newBackfilledSoil = jlinerAddJunctionLiner2Gateway.GetBackfilledSoil(id, refId, companyId);
                        DateTime? newGrouted = jlinerAddJunctionLiner2Gateway.GetGrouted(id, refId, companyId);
                        DateTime? newCored = jlinerAddJunctionLiner2Gateway.GetCored(id, refId, companyId);
                        DateTime? newPrepped = jlinerAddJunctionLiner2Gateway.GetPrepped(id, refId, companyId);
                        DateTime? newMeasured = jlinerAddJunctionLiner2Gateway.GetMeasured(id, refId, companyId);
                        string newLinerSize = jlinerAddJunctionLiner2Gateway.GetLinerSize(id, refId, companyId);
                        DateTime? newInProcess = jlinerAddJunctionLiner2Gateway.GetInProcess(id, refId, companyId);
                        DateTime? newInStock = jlinerAddJunctionLiner2Gateway.GetInStock(id, refId, companyId);
                        DateTime? newDelivered = jlinerAddJunctionLiner2Gateway.GetDelivered(id, refId, companyId);
                        int? newBuildRebuild = jlinerAddJunctionLiner2Gateway.GetBuildRebuild(id, refId, companyId);
                        DateTime? newPreVideo = jlinerAddJunctionLiner2Gateway.GetPreVideo(id, refId, companyId);
                        DateTime? newLinerInstalled = jlinerAddJunctionLiner2Gateway.GetLinerInstalled(id, refId, companyId);
                        DateTime? newFinalVideo = jlinerAddJunctionLiner2Gateway.GetFinalVideo(id, refId, companyId);
                        double? newDistanceFromUSMH = jlinerAddJunctionLiner2Gateway.GetDistanceFromUSMH(id, refId, companyId);
                        double? newDistanceFromDSMH = jlinerAddJunctionLiner2Gateway.GetDistanceFromDSMH(id, refId, companyId);
                        string newMap = jlinerAddJunctionLiner2Gateway.GetMap(id, refId, companyId);
                        string newIssue = jlinerAddJunctionLiner2Gateway.GetIssue(id, refId, companyId);
                        decimal? newCost = jlinerAddJunctionLiner2Gateway.GetCost(id, refId, companyId);
                        DateTime? newVideoInspection = jlinerAddJunctionLiner2Gateway.GetVideoInspection(id, refId, companyId);
                        bool newCoRequired = jlinerAddJunctionLiner2Gateway.GetCoRequired(id, refId, companyId);
                        bool newPitRequired = jlinerAddJunctionLiner2Gateway.GetPitRequired(id, refId, companyId);
                        string newCoPitLocation = jlinerAddJunctionLiner2Gateway.GetCoPitLocation(id, refId, companyId);
                        bool newPostContractDigRequired = jlinerAddJunctionLiner2Gateway.GetPostContractDigRequired(id, refId, companyId);
                        string newComments = jlinerAddJunctionLiner2Gateway.GetComments(id, refId, companyId);
                        string newHistory = jlinerAddJunctionLiner2Gateway.GetHistory(id, refId, companyId);
                        DateTime? newCoCutDown = jlinerAddJunctionLiner2Gateway.GetCoCutDown(id, refId, companyId);
                        DateTime? newFinalRestoration = jlinerAddJunctionLiner2Gateway.GetFinalRestoration(id, refId, companyId);
                        string newClientLateralID = jlinerAddJunctionLiner2Gateway.GetClientLateralID(id, refId, companyId);
                        string newVideoLengthToPropertyLine = jlinerAddJunctionLiner2Gateway.GetVideoLengthToPropertyLine(id, refId, companyId);
                        bool newLiningThruCo = jlinerAddJunctionLiner2Gateway.GetLiningThruCo(id, refId, companyId);
                        string newHamiltonInspectionNumber = jlinerAddJunctionLiner2Gateway.GetHamiltonInspectionNumber(id, refId, companyId);
                        DateTime? newNoticeDelivered = jlinerAddJunctionLiner2Gateway.GetNoticeDelivered(id, refId, companyId);

                        Jliner jliner = new Jliner(null);
                        jliner.UpdateDirect(row.ID, row.RefID, row.COMPANY_ID, originalDetailId, originalAddress, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalDistanceFromUSMH, originalDistanceFromDSMH, originalMap, originalIssue, originalCost, false, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalComments, originalHistory, originalCoCutDown, originalFinalRestoration, originalClientLateralID, originalVideoLengthToPropertyLine, originalLiningThruCo, originalHamiltonInspectionNumber, originalNoticeDelivered, row.ID, row.RefID, row.COMPANY_ID, newDetailId, newAddress, newPipeLocated, newServicesLocated, newCoInstalled, newBackfilledConcrete, newBackfilledSoil, newGrouted, newCored, newPrepped, newMeasured, newLinerSize, newInProcess, newInStock, newDelivered, newBuildRebuild, newPreVideo, newLinerInstalled, newFinalVideo, newDistanceFromUSMH, newDistanceFromDSMH, newMap, newIssue, newCost, false, newVideoInspection, newCoRequired, newPitRequired, newCoPitLocation, newPostContractDigRequired, newComments, newHistory, newCoCutDown, newFinalRestoration, newClientLateralID, newVideoLengthToPropertyLine, newLiningThruCo, newHamiltonInspectionNumber, newNoticeDelivered); 
                    }
                }
            }            
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>JlinerAddTDS.JunctionLiner2Row</returns>
        private JlinerAddTDS.JunctionLiner2Row GetRow(Guid id, int refId, int companyId)
        {
            JlinerAddTDS.JunctionLiner2Row row = ((JlinerAddTDS.JunctionLiner2DataTable)Table).FindByIDRefIDCOMPANY_ID(id, refId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.Jliner.JlinerAddJunctionLiner2.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New ID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (JlinerAddTDS.JunctionLiner2Row row in (JlinerAddTDS.JunctionLiner2DataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }




    }
}