using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// Jliner
    /// </summary>
    public class Jliner : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Jliner() : base("LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Jliner(DataSet data) : base(data, "LFS_JUNCTION_LINER2")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SectionTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detailId">detailId</param>
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
        /// <param name="comments">comments</param>        
        /// <param name="map">map</param>
        /// <param name="issue">issue</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="clientLateralId">clientLateralId</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        /// <param name="coCutDown">coCutDown</param>
        public void Insert(Guid id, int refId, int companyId, string detailId, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? buildRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, double? distanceFromUSMH, double? distanceFromDSMH, string map, string issue, decimal? cost, bool deleted, DateTime? videoInspection, DateTime? finalRestoration, string clientLateralId, string videoLengthToPropertyLine, bool liningThruCo, string hamiltonInspectionNumber, DateTime? noticeDelivered, DateTime? coCutDown)
        {
            SectionTDS.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row = ((SectionTDS.LFS_JUNCTION_LINER2DataTable)Table).NewLFS_JUNCTION_LINER2Row();
            
            lfsJunctionLiner2Row.ID = id;
            lfsJunctionLiner2Row.RefID = refId;
            lfsJunctionLiner2Row.COMPANY_ID = companyId;
            lfsJunctionLiner2Row.DetailID = detailId;
            if (address.Trim() != "") lfsJunctionLiner2Row.Address = address.Trim(); else lfsJunctionLiner2Row.SetAddressNull();
            if (pipeLocated.HasValue) lfsJunctionLiner2Row.PipeLocated = (DateTime)pipeLocated; else lfsJunctionLiner2Row.SetPipeLocatedNull();
            if (servicesLocated.HasValue) lfsJunctionLiner2Row.ServicesLocated = (DateTime)servicesLocated; else lfsJunctionLiner2Row.SetServicesLocatedNull();
            if (coInstalled.HasValue) lfsJunctionLiner2Row.CoInstalled = (DateTime)coInstalled; else lfsJunctionLiner2Row.SetCoInstalledNull();
            if (backfilledConcrete.HasValue) lfsJunctionLiner2Row.BackfilledConcrete = (DateTime)backfilledConcrete; else lfsJunctionLiner2Row.SetBackfilledConcreteNull();
            if (backfilledSoil.HasValue) lfsJunctionLiner2Row.BackfilledSoil = (DateTime)backfilledSoil; else lfsJunctionLiner2Row.SetBackfilledSoilNull();
            if (grouted.HasValue) lfsJunctionLiner2Row.Grouted = (DateTime)grouted; else lfsJunctionLiner2Row.SetGroutedNull();
            if (cored.HasValue) lfsJunctionLiner2Row.Cored = (DateTime)cored; else lfsJunctionLiner2Row.SetCoredNull();
            if (prepped.HasValue) lfsJunctionLiner2Row.Prepped = (DateTime)prepped; else lfsJunctionLiner2Row.SetPreppedNull();
            if (measured.HasValue) lfsJunctionLiner2Row.Measured = (DateTime)measured; else lfsJunctionLiner2Row.SetMeasuredNull();
            if (linerSize.Trim() != "") lfsJunctionLiner2Row.LinerSize = linerSize.Trim(); else lfsJunctionLiner2Row.SetLinerSizeNull();
            if (inProcess.HasValue) lfsJunctionLiner2Row.InProcess = (DateTime)inProcess; else lfsJunctionLiner2Row.SetInProcessNull();
            if (inStock.HasValue) lfsJunctionLiner2Row.InStock = (DateTime)inStock; else lfsJunctionLiner2Row.SetInStockNull();
            if (delivered.HasValue) lfsJunctionLiner2Row.Delivered = (DateTime)delivered; else lfsJunctionLiner2Row.SetDeliveredNull();
            if (buildRebuild.HasValue) lfsJunctionLiner2Row.BuildRebuild = (int)buildRebuild; else lfsJunctionLiner2Row.SetBuildRebuildNull();
            if (preVideo.HasValue) lfsJunctionLiner2Row.PreVideo = (DateTime)preVideo; else lfsJunctionLiner2Row.SetPreVideoNull();
            if (linerInstalled.HasValue) lfsJunctionLiner2Row.LinerInstalled = (DateTime)linerInstalled; else lfsJunctionLiner2Row.SetLinerInstalledNull();
            if (finalVideo.HasValue) lfsJunctionLiner2Row.FinalVideo = (DateTime)finalVideo; else lfsJunctionLiner2Row.SetFinalVideoNull();
            if (distanceFromUSMH.HasValue) lfsJunctionLiner2Row.DistanceFromUSMH = (double)distanceFromUSMH; else lfsJunctionLiner2Row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.HasValue) lfsJunctionLiner2Row.DistanceFromDSMH = (double)distanceFromDSMH; else lfsJunctionLiner2Row.SetDistanceFromDSMHNull();
            if (map.Trim() != "") lfsJunctionLiner2Row.Map = map; else lfsJunctionLiner2Row.SetMapNull();
            lfsJunctionLiner2Row.Issue = issue;
            if (cost.HasValue) lfsJunctionLiner2Row.Cost = (decimal)cost; else lfsJunctionLiner2Row.SetCostNull(); 
            lfsJunctionLiner2Row.Deleted = deleted;
            if (videoInspection.HasValue) lfsJunctionLiner2Row.VideoInspection = (DateTime)videoInspection; else lfsJunctionLiner2Row.SetVideoInspectionNull();
            lfsJunctionLiner2Row.CoRequired = false;
            lfsJunctionLiner2Row.PitRequired = false;
            lfsJunctionLiner2Row.PostContractDigRequired = false;
            if (coCutDown.HasValue) lfsJunctionLiner2Row.CoCutDown = (DateTime)coCutDown; else lfsJunctionLiner2Row.SetCoCutDownNull();
            if (finalRestoration.HasValue) lfsJunctionLiner2Row.FinalRestoration = (DateTime)finalRestoration; else lfsJunctionLiner2Row.SetFinalRestorationNull();
            if (clientLateralId.Trim() != "") lfsJunctionLiner2Row.ClientLateralID = clientLateralId; else lfsJunctionLiner2Row.SetClientLateralIDNull();
            if (videoLengthToPropertyLine.Trim() != "") lfsJunctionLiner2Row.VideoLengthToPropertyLine = videoLengthToPropertyLine; else lfsJunctionLiner2Row.SetVideoLengthToPropertyLineNull();
            lfsJunctionLiner2Row.LiningThruCo = false;
            if (hamiltonInspectionNumber.Trim() != "") lfsJunctionLiner2Row.HamiltonInspectionNumber = hamiltonInspectionNumber; else lfsJunctionLiner2Row.SetHamiltonInspectionNumberNull();
            if (noticeDelivered.HasValue) lfsJunctionLiner2Row.NoticeDelivered = (DateTime)noticeDelivered; else lfsJunctionLiner2Row.SetNoticeDeliveredNull();

            lfsJunctionLiner2Row.SetCommentsNull();
            lfsJunctionLiner2Row.SetHistoryNull();

            ((SectionTDS.LFS_JUNCTION_LINER2DataTable)Table).AddLFS_JUNCTION_LINER2Row(lfsJunctionLiner2Row);
        }



        /// <summary>
        /// Insert direct
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detailId">detailId</param>
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
        public void InsertDirect(Guid id, int refId, int companyId, string detailId, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, int? buildRebuild, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, double? distanceFromUSMH, double? distanceFromDSMH, string map, string issue, decimal? cost, bool deleted, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, string comments, string history, DateTime? coCutDown, DateTime? finalRestoration, string clientLateralID, string videoLengthToPropertyLine, bool liningThruCo, string hamiltonInspectionNumber, DateTime? noticeDelivered)
        {
            JlinerGateway jlinerGateway = new JlinerGateway(null);
            jlinerGateway.Insert(id, refId, companyId, detailId, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, buildRebuild, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH, map, issue, cost, deleted, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, comments, history, coCutDown, finalRestoration, clientLateralID, videoLengthToPropertyLine, liningThruCo, hamiltonInspectionNumber, noticeDelivered);
        }



        /// <summary>
        /// Update jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="detailId">detailId</param>
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
        /// <param name="map">map</param>
        /// <param name="issue">issue</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
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
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        public void Update(Guid id, int refId, int companyId, string detailId, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, double? distanceFromUSMH, double? distanceFromDSMH, string map, string issue, decimal? cost, bool deleted, DateTime? videoInspection, bool coRequired, bool pitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, string clientLateralId, string videoLengthToPropertyLine, bool liningThruCo, string hamiltonInspectionNumber, DateTime? noticeDelivered)
        {
            SectionTDS.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row = GetRow(id, refId, companyId);

            lfsJunctionLiner2Row.DetailID = detailId;
            if (address.Trim() != "") lfsJunctionLiner2Row.Address = address.Trim(); else lfsJunctionLiner2Row.SetAddressNull();
            if (pipeLocated.HasValue) lfsJunctionLiner2Row.PipeLocated = (DateTime)pipeLocated; else lfsJunctionLiner2Row.SetPipeLocatedNull();
            if (servicesLocated.HasValue) lfsJunctionLiner2Row.ServicesLocated = (DateTime)servicesLocated; else lfsJunctionLiner2Row.SetServicesLocatedNull();
            if (coInstalled.HasValue) lfsJunctionLiner2Row.CoInstalled = (DateTime)coInstalled; else lfsJunctionLiner2Row.SetCoInstalledNull();
            if (backfilledConcrete.HasValue) lfsJunctionLiner2Row.BackfilledConcrete = (DateTime)backfilledConcrete; else lfsJunctionLiner2Row.SetBackfilledConcreteNull();
            if (backfilledSoil.HasValue) lfsJunctionLiner2Row.BackfilledSoil = (DateTime)backfilledSoil; else lfsJunctionLiner2Row.SetBackfilledSoilNull();
            if (grouted.HasValue) lfsJunctionLiner2Row.Grouted = (DateTime)grouted; else lfsJunctionLiner2Row.SetGroutedNull();
            if (cored.HasValue) lfsJunctionLiner2Row.Cored = (DateTime)cored; else lfsJunctionLiner2Row.SetCoredNull();
            if (prepped.HasValue) lfsJunctionLiner2Row.Prepped = (DateTime)prepped; else lfsJunctionLiner2Row.SetPreppedNull();
            if (measured.HasValue) lfsJunctionLiner2Row.Measured = (DateTime)measured; else lfsJunctionLiner2Row.SetMeasuredNull();
            if (linerSize.Trim() != "") lfsJunctionLiner2Row.LinerSize = linerSize.Trim(); else lfsJunctionLiner2Row.SetLinerSizeNull();

            if ((lfsJunctionLiner2Row.IsInProcessNull()) && (inProcess.HasValue))
            {
                lfsJunctionLiner2Row.BuildRebuild++;
            }

            if (inProcess.HasValue) lfsJunctionLiner2Row.InProcess = (DateTime)inProcess; else lfsJunctionLiner2Row.SetInProcessNull();
            if (inStock.HasValue) lfsJunctionLiner2Row.InStock = (DateTime)inStock; else lfsJunctionLiner2Row.SetInStockNull();
            if (delivered.HasValue) lfsJunctionLiner2Row.Delivered = (DateTime)delivered; else lfsJunctionLiner2Row.SetDeliveredNull();
            if (preVideo.HasValue) lfsJunctionLiner2Row.PreVideo = (DateTime)preVideo; else lfsJunctionLiner2Row.SetPreVideoNull();
            if (linerInstalled.HasValue) lfsJunctionLiner2Row.LinerInstalled = (DateTime)linerInstalled; else lfsJunctionLiner2Row.SetLinerInstalledNull();
            if (finalVideo.HasValue) lfsJunctionLiner2Row.FinalVideo = (DateTime)finalVideo; else lfsJunctionLiner2Row.SetFinalVideoNull();
            if (distanceFromUSMH.HasValue) lfsJunctionLiner2Row.DistanceFromUSMH = (double)distanceFromUSMH; else lfsJunctionLiner2Row.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.HasValue) lfsJunctionLiner2Row.DistanceFromDSMH = (double)distanceFromDSMH; else lfsJunctionLiner2Row.SetDistanceFromDSMHNull();
            if (map.Trim() != "") lfsJunctionLiner2Row.Map = map; else lfsJunctionLiner2Row.SetMapNull();
            lfsJunctionLiner2Row.Issue = issue;
            if (cost.HasValue) lfsJunctionLiner2Row.Cost = (decimal)cost; else lfsJunctionLiner2Row.SetCostNull();
            lfsJunctionLiner2Row.Deleted = deleted;
            if (videoInspection.HasValue) lfsJunctionLiner2Row.VideoInspection = (DateTime)videoInspection; else lfsJunctionLiner2Row.SetVideoInspectionNull();
            lfsJunctionLiner2Row.CoRequired = coRequired;
            lfsJunctionLiner2Row.PitRequired = pitRequired;
            if (coPitLocation.Trim() != "") lfsJunctionLiner2Row.CoPitLocation = coPitLocation; else lfsJunctionLiner2Row.SetCoPitLocationNull();
            lfsJunctionLiner2Row.PostContractDigRequired = postContractDigRequired;
            if (coCutDown.HasValue) lfsJunctionLiner2Row.CoCutDown = (DateTime)coCutDown; else lfsJunctionLiner2Row.SetCoCutDownNull();
            if (finalRestoration.HasValue) lfsJunctionLiner2Row.FinalRestoration = (DateTime)finalRestoration; else lfsJunctionLiner2Row.SetFinalRestorationNull();
            if (clientLateralId.Trim() != "") lfsJunctionLiner2Row.ClientLateralID = clientLateralId; else lfsJunctionLiner2Row.SetClientLateralIDNull();
            if (videoLengthToPropertyLine != "") lfsJunctionLiner2Row.VideoLengthToPropertyLine = videoLengthToPropertyLine; else lfsJunctionLiner2Row.SetVideoLengthToPropertyLineNull();
            lfsJunctionLiner2Row.LiningThruCo = liningThruCo;
            if (hamiltonInspectionNumber.Trim() != "") lfsJunctionLiner2Row.HamiltonInspectionNumber = hamiltonInspectionNumber; else lfsJunctionLiner2Row.SetHamiltonInspectionNumberNull();
            if (noticeDelivered.HasValue) lfsJunctionLiner2Row.NoticeDelivered = (DateTime)noticeDelivered; else lfsJunctionLiner2Row.SetNoticeDeliveredNull();
        }



        /// <summary>
        /// Update direct
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalDetailId">originalDetailId</param>
        /// <param name="originalAddress">originalAddress</param>
        /// <param name="originalPipeLocated">originalPipeLocated</param>
        /// <param name="originalServicesLocated">originalServicesLocated</param>
        /// <param name="originalCoInstalled">originalCoInstalled</param>
        /// <param name="originalBackfilledConcrete">originalBackfilledConcrete</param>
        /// <param name="originalBackfilledSoil">originalBackfilledSoil</param>
        /// <param name="originalGrouted">originalGrouted</param>
        /// <param name="originalCored">originalCored</param>
        /// <param name="originalPrepped">originalPrepped</param>
        /// <param name="originalMeasured">originalMeasured</param>
        /// <param name="originalLinerSize">originalLinerSize</param>
        /// <param name="originalInProcess">originalInProcess</param>
        /// <param name="originalInStock">originalInStock</param>
        /// <param name="originalDelivered">originalDelivered</param>
        /// <param name="originalBuildRebuild">originalBuildRebuild</param>
        /// <param name="originalPreVideo">originalPreVideo</param>        
        /// <param name="originalLinerInstalled">originalLinerInstalled</param>
        /// <param name="originalFinalVideo">originalFinalVideo</param>
        /// <param name="originalDistanceFromUSMH">originalDistanceFromUSMH</param>
        /// <param name="originalDistanceFromDSMH">originalDistanceFromDSMH</param>
        /// <param name="originalMap">originalMap</param>
        /// <param name="originalIssue">originalIssue</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalVideoInspection">originalVideoInspection</param>
        /// <param name="originalCoRequired">originalCoRequired</param>
        /// <param name="originalPitRequired">originalPitRequired</param>
        /// <param name="originalCoPitLocation">originalCoPitLocation</param>
        /// <param name="originalPostContractDigRequired">originalPostContractDigRequired</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalHistory">originalHistory</param>
        /// <param name="originalCoCutDown">originalCoCutDown</param>
        /// <param name="originalFinalRestoration">originalFinalRestoration</param>
        /// <param name="originalClientLateralID">originalClientLateralID</param>
        /// <param name="originalVideoLengthToPropertyLine">originalVideoLengthToPropertyLine</param>
        /// <param name="originalLiningThruCo">originalLiningThruCo</param>
        /// <param name="originalHamiltonInspectionNumber">originalHamiltonInspectionNumber</param>
        /// <param name="originalNoticeDelivered">originalNoticeDelivered</param>
        ///
        /// <param name="newId">newId</param>
        /// <param name="newRefId">newRefId</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newDetailId">newDetailId</param>
        /// <param name="newAddress">newAddress</param>
        /// <param name="newPipeLocated">newPipeLocated</param>
        /// <param name="newServicesLocated">newServicesLocated</param>
        /// <param name="newCoInstalled">newCoInstalled</param>
        /// <param name="newBackfilledConcrete">newBackfilledConcrete</param>
        /// <param name="newBackfilledSoil">newBackfilledSoil</param>
        /// <param name="newGrouted">newGrouted</param>
        /// <param name="newCored">newCored</param>
        /// <param name="newPrepped">newPrepped</param>
        /// <param name="newMeasured">newMeasured</param>
        /// <param name="newLinerSize">newLinerSize</param>
        /// <param name="newInProcess">newInProcess</param>
        /// <param name="newInStock">newInStock</param>
        /// <param name="newDelivered">newDelivered</param>
        /// <param name="newBuildRebuild">newBuildRebuild</param>
        /// <param name="newPreVideo">newPreVideo</param>        
        /// <param name="newLinerInstalled">newLinerInstalled</param>
        /// <param name="newFinalVideo">newFinalVideo</param>
        /// <param name="newDistanceFromUSMH">newDistanceFromUSMH</param>
        /// <param name="newDistanceFromDSMH">newDistanceFromDSMH</param>
        /// <param name="newMap">newMap</param>
        /// <param name="newIssue">newIssue</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newDeleted">newDeleted</param>        
        /// <param name="newVideoInspection">newVideoInspection</param>
        /// <param name="newCoRequired">newCoRequired</param>
        /// <param name="newPitRequired">newPitRequired</param>
        /// <param name="newCoPitLocation">newCoPitLocation</param>
        /// <param name="newPostContractDigRequired">newPostContractDigRequired</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newHistory">newHistory</param>
        /// <param name="newCoCutDown">newCoCutDown</param>
        /// <param name="newFinalRestoration">newFinalRestoration</param>
        /// <param name="newClientLateralID">newClientLateralID</param>
        /// <param name="newVideoLengthToPropertyLine">newVideoLengthToPropertyLine</param>
        /// <param name="newLiningThruCo">newLiningThruCo</param>
        /// <param name="newHamiltonInspectionNumber">newHamiltonInspectionNumber</param>
        /// <param name="newNoticeDelivered">newNoticeDelivered</param>
        public void UpdateDirect(Guid originalId, int originalRefId, int originalCompanyId, string originalDetailId, string originalAddress, DateTime? originalPipeLocated, DateTime? originalServicesLocated, DateTime? originalCoInstalled, DateTime? originalBackfilledConcrete, DateTime? originalBackfilledSoil, DateTime? originalGrouted, DateTime? originalCored, DateTime? originalPrepped, DateTime? originalMeasured, string originalLinerSize, DateTime? originalInProcess, DateTime? originalInStock, DateTime? originalDelivered, int? originalBuildRebuild, DateTime? originalPreVideo, DateTime? originalLinerInstalled, DateTime? originalFinalVideo, double? originalDistanceFromUSMH, double? originalDistanceFromDSMH, string originalMap, string originalIssue, decimal? originalCost, bool originalDeleted, DateTime? originalVideoInspection, bool originalCoRequired, bool originalPitRequired, string originalCoPitLocation, bool originalPostContractDigRequired, string originalComments, string originalHistory, DateTime? originalCoCutDown, DateTime? originalFinalRestoration, string originalClientLateralID, string originalVideoLengthToPropertyLine, bool originalLiningThruCo, string originalHamiltonInspectionNumber, DateTime? originalNoticeDelivered, Guid newId, int newRefId, int newCompanyId, string newDetailId, string newAddress, DateTime? newPipeLocated, DateTime? newServicesLocated, DateTime? newCoInstalled, DateTime? newBackfilledConcrete, DateTime? newBackfilledSoil, DateTime? newGrouted, DateTime? newCored, DateTime? newPrepped, DateTime? newMeasured, string newLinerSize, DateTime? newInProcess, DateTime? newInStock, DateTime? newDelivered, int? newBuildRebuild, DateTime? newPreVideo, DateTime? newLinerInstalled, DateTime? newFinalVideo, double? newDistanceFromUSMH, double? newDistanceFromDSMH, string newMap, string newIssue, decimal? newCost, bool newDeleted, DateTime? newVideoInspection, bool newCoRequired, bool newPitRequired, string newCoPitLocation, bool newPostContractDigRequired, string newComments, string newHistory, DateTime? newCoCutDown, DateTime? newFinalRestoration, string newClientLateralID, string newVideoLengthToPropertyLine, bool newLiningThruCo, string newHamiltonInspectionNumber, DateTime? newNoticeDelivered)
        {
            JlinerGateway jlinerGateway = new JlinerGateway(null);
            jlinerGateway.Update(originalId, originalRefId, originalCompanyId, originalDetailId, originalAddress, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalDistanceFromUSMH, originalDistanceFromDSMH, originalMap, originalIssue,  originalCost, originalDeleted, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalComments, originalHistory, originalCoCutDown, originalFinalRestoration, originalClientLateralID, originalVideoLengthToPropertyLine, originalLiningThruCo, originalHamiltonInspectionNumber, originalNoticeDelivered, newId, newRefId, newCompanyId, newDetailId, newAddress, newPipeLocated, newServicesLocated, newCoInstalled, newBackfilledConcrete, newBackfilledSoil, newGrouted, newCored, newPrepped, newMeasured, newLinerSize, newInProcess, newInStock, newDelivered, newBuildRebuild, newPreVideo, newLinerInstalled, newFinalVideo, newDistanceFromUSMH, newDistanceFromDSMH, newMap, newIssue, newCost, newDeleted, newVideoInspection, newCoRequired, newPitRequired, newCoPitLocation, newPostContractDigRequired, newComments, newHistory, newCoCutDown, newFinalRestoration, newClientLateralID, newVideoLengthToPropertyLine, newLiningThruCo, newHamiltonInspectionNumber, newNoticeDelivered);
        }
            

        
        /// <summary>
        /// Delete one jliner
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(Guid id, int refId, int companyId)
        {
            SectionTDS.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row = GetRow(id, refId, companyId);
            lfsJunctionLiner2Row.Deleted = true;
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>                
        public void DeleteDirect(Guid id, int refId, int companyId)
        {
            JlinerGateway jlinerGateway = new JlinerGateway(null);
            jlinerGateway.Delete(id, refId, companyId);
        }


        
        /// <summary>
        /// GetNewRefId
        /// </summary>
        /// <returns>New RefID</returns>
        public int GetNewRefId()
        {
            int newRefId = 0;

            foreach (SectionTDS.LFS_JUNCTION_LINER2Row row in (SectionTDS.LFS_JUNCTION_LINER2DataTable)Table)
            {
                if (newRefId < row.RefID)
                {
                    newRefId = row.RefID;
                }
            }

            newRefId++;

            return newRefId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single jliner. If not exists, raise an exception
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="refId">RefID</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private SectionTDS.LFS_JUNCTION_LINER2Row GetRow(Guid id, int refId, int companyId)
        {
            SectionTDS.LFS_JUNCTION_LINER2Row row = ((SectionTDS.LFS_JUNCTION_LINER2DataTable)Table).FindByIDRefIDCOMPANY_ID(id, refId, companyId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.Jliner.GetRow");
            }

            return row;
        }



    }
}