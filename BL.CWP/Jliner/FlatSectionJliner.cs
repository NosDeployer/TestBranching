using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Section;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// FlatSectionJliner
    /// </summary>
    public class FlatSectionJliner : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJliner() : base("FlatSectionJliner")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public FlatSectionJliner(DataSet data) : base(data, "FlatSectionJliner")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlinerTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByIdRefIdCompanyId
        /// </summary>
        /// <param name="id">LFS_MASTER_AREA ID</param>
        /// <param name="refId">LFS_JUNCTION_LINER2 ID</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>Data</returns>
        public void LoadByIdRefId(Guid id, int refId, int companyId)
        {
            FlatSectionJlinerGateway flatSectionJlinerGateway = new FlatSectionJlinerGateway(Data);
            flatSectionJlinerGateway.LoadByIdRefId(id, refId, companyId);
        }



        /// <summary>
        /// LoadBySaleDetailIdArrayList
        /// </summary>
        /// <param name="jlinerIdArrayList">ArrayList of JLinedIds</param>
        /// <param name="selected">1 = Selected by default, 0 = Not selected by default</param>
        public void LoadBySaleDetailIdArrayList(ArrayList jlinerIdArrayList, int selected)
        {
            // Loading data
            FlatSectionJlinerGateway flatSectionJlinerGateway = new FlatSectionJlinerGateway(Data);

            flatSectionJlinerGateway.Table.Clear();
            flatSectionJlinerGateway.ClearBeforeFill = false;

            foreach (JlinerId jlinerId in jlinerIdArrayList)
            {
                flatSectionJlinerGateway.LoadByIdRefIdSelected(jlinerId.id, jlinerId.refId, jlinerId.companyId, selected);
            }
            
            flatSectionJlinerGateway.ClearBeforeFill = true;
        }

    

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="id_">id_</param>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="recordId">recordId</param>
        /// <param name="detailId">detailId</param>
        /// <param name="address">address</param>
        /// <param name="pipeLocated">pipeLocated</param>
        /// <param name="servicesLocated">servicesLocated</param>
        /// <param name="coInstalled">coInstalled</param>
        /// <param name="backfilledConcrete">backfilledConcrete</param>
        /// <param name="backfilledSoil">backfilledSoil</param>
        /// <param name="cored">cored</param>
        /// <param name="grouted">grouted</param>
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
        /// <param name="comments">comments</param>
        /// <param name="history">history</param>
        /// <param name="issue">issue</param>
        /// <param name="cost">cost</param>
        /// <param name="deleted">deleted</param>
        /// <param name="selected">selected</param>
        /// <param name="videoInspection">videoInspection</param>
        /// <param name="coRequired">coRequired</param>
        /// <param name="PitRequired">PitRequired</param>
        /// <param name="coPitLocation">coPitLocation</param>
        /// <param name="postContractDigRequired">postContractDigRequired</param>
        /// <param name="coCutDown">coCutDown</param>
        /// <param name="finalRestoration">finalRestoration</param>
        /// <param name="clientLateralID">clientLateralID</param>
        /// <param name="videoLengthToPropertyLine">videoLengthToPropertyLine</param>
        /// <param name="liningThruCo">liningThruCo</param>
        /// <param name="hamiltonInspectionNumber">hamiltonInspectionNumber</param>
        /// <param name="noticeDelivered">noticeDelivered</param>
        public void Update(string id_, Guid id, int refId, int companyId, string recordId, string detailId, string address, DateTime? pipeLocated, DateTime? servicesLocated, DateTime? coInstalled, DateTime? backfilledConcrete, DateTime? backfilledSoil, DateTime? grouted, DateTime? cored, DateTime? prepped, DateTime? measured, string linerSize, DateTime? inProcess, DateTime? inStock, DateTime? delivered, DateTime? preVideo, DateTime? linerInstalled, DateTime? finalVideo, double? distanceFromUSMH, double? distanceFromDSMH, string comments, string history, string issue, decimal? cost, bool deleted, bool selected, DateTime? videoInspection, bool coRequired, bool PitRequired, string coPitLocation, bool postContractDigRequired, DateTime? coCutDown, DateTime? finalRestoration, string clientLateralID, string videoLengthToPropertyLine, bool liningThruCo, string hamiltonInspectionNumber, DateTime? noticeDelivered)
        {
            FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow = GetRow(id_);

            flatSectionJlinerRow.ID = id;
            flatSectionJlinerRow.RefID = refId;
            flatSectionJlinerRow.COMPANY_ID = companyId;
            flatSectionJlinerRow.RecordID = recordId;
            flatSectionJlinerRow.DetailID = detailId;

            if ((flatSectionJlinerRow.IsInProcessNull()) && (inProcess.HasValue))
            {
                if (!flatSectionJlinerRow.IsBuildRebuildNull())
                {
                    flatSectionJlinerRow.BuildRebuild = flatSectionJlinerRow.BuildRebuild + 1;
                }
                else
                {
                    flatSectionJlinerRow.BuildRebuild = 1;
                }
            }

            if (address.Trim() != "") flatSectionJlinerRow.Address = address.Trim(); else flatSectionJlinerRow.SetAddressNull();
            if (pipeLocated.HasValue) flatSectionJlinerRow.PipeLocated = (DateTime)pipeLocated; else flatSectionJlinerRow.SetPipeLocatedNull();
            if (servicesLocated.HasValue) flatSectionJlinerRow.ServicesLocated = (DateTime)servicesLocated; else flatSectionJlinerRow.SetServicesLocatedNull();
            if (coInstalled.HasValue) flatSectionJlinerRow.CoInstalled = (DateTime)coInstalled; else flatSectionJlinerRow.SetCoInstalledNull();
            if (backfilledConcrete.HasValue) flatSectionJlinerRow.BackfilledConcrete = (DateTime)backfilledConcrete; else flatSectionJlinerRow.SetBackfilledConcreteNull();
            if (backfilledSoil.HasValue) flatSectionJlinerRow.BackfilledSoil = (DateTime)backfilledSoil; else flatSectionJlinerRow.SetBackfilledSoilNull();
            if (grouted.HasValue) flatSectionJlinerRow.Grouted = (DateTime)grouted; else flatSectionJlinerRow.SetGroutedNull();
            if (cored.HasValue) flatSectionJlinerRow.Cored = (DateTime)cored; else flatSectionJlinerRow.SetCoredNull();
            if (prepped.HasValue) flatSectionJlinerRow.Prepped = (DateTime)prepped; else flatSectionJlinerRow.SetPreppedNull();
            if (measured.HasValue) flatSectionJlinerRow.Measured = (DateTime)measured; else flatSectionJlinerRow.SetMeasuredNull();
            if (linerSize.Trim() != "") flatSectionJlinerRow.LinerSize = linerSize.Trim(); else flatSectionJlinerRow.SetLinerSizeNull();
            if (inProcess.HasValue) flatSectionJlinerRow.InProcess = (DateTime)inProcess; else flatSectionJlinerRow.SetInProcessNull();
            if (inStock.HasValue) flatSectionJlinerRow.InStock = (DateTime)inStock; else flatSectionJlinerRow.SetInStockNull();
            if (delivered.HasValue) flatSectionJlinerRow.Delivered = (DateTime)delivered; else flatSectionJlinerRow.SetDeliveredNull();
            if (preVideo.HasValue) flatSectionJlinerRow.PreVideo = (DateTime)preVideo; else flatSectionJlinerRow.SetPreVideoNull();
            if (linerInstalled.HasValue) flatSectionJlinerRow.LinerInstalled = (DateTime)linerInstalled; else flatSectionJlinerRow.SetLinerInstalledNull();
            if (finalVideo.HasValue) flatSectionJlinerRow.FinalVideo = (DateTime)finalVideo; else flatSectionJlinerRow.SetFinalVideoNull();
            if (distanceFromUSMH.HasValue) flatSectionJlinerRow.DistanceFromUSMH = (double)distanceFromUSMH; else flatSectionJlinerRow.SetDistanceFromUSMHNull();
            if (distanceFromDSMH.HasValue) flatSectionJlinerRow.DistanceFromDSMH = (double)distanceFromDSMH; else flatSectionJlinerRow.SetDistanceFromDSMHNull();
            flatSectionJlinerRow.Issue = issue;
            if (cost.HasValue) flatSectionJlinerRow.Cost = (decimal)cost; else flatSectionJlinerRow.SetCostNull(); 
            flatSectionJlinerRow.Deleted = deleted;
            flatSectionJlinerRow.Selected = selected;
            if (videoInspection.HasValue) flatSectionJlinerRow.VideoInspection = (DateTime)videoInspection; else flatSectionJlinerRow.SetVideoInspectionNull();
            flatSectionJlinerRow.CoRequired = coRequired;
            flatSectionJlinerRow.PitRequired = PitRequired;
            if (coPitLocation.Trim() != "") flatSectionJlinerRow.CoPitLocation = coPitLocation; else flatSectionJlinerRow.SetCoPitLocationNull();
            flatSectionJlinerRow.PostContractDigRequired = postContractDigRequired;
            if (coCutDown.HasValue) flatSectionJlinerRow.CoCutDown = (DateTime)coCutDown; else flatSectionJlinerRow.SetCoCutDownNull();
            if (finalRestoration.HasValue) flatSectionJlinerRow.FinalRestoration = (DateTime)finalRestoration; else flatSectionJlinerRow.SetFinalRestorationNull();
            if (clientLateralID.Trim() != "") flatSectionJlinerRow.ClientLateralID = clientLateralID; else flatSectionJlinerRow.SetClientLateralIDNull();
            if (videoLengthToPropertyLine.Trim() != "") flatSectionJlinerRow.VideoLengthToPropertyLine = videoLengthToPropertyLine; else flatSectionJlinerRow.SetVideoLengthToPropertyLineNull();
            flatSectionJlinerRow.LiningThruCo = liningThruCo;
            if (hamiltonInspectionNumber.Trim() != "") flatSectionJlinerRow.HamiltonInspectionNumber = hamiltonInspectionNumber.Trim(); else flatSectionJlinerRow.SetHamiltonInspectionNumberNull();
            if (noticeDelivered.HasValue) flatSectionJlinerRow.NoticeDelivered = (DateTime)noticeDelivered; else flatSectionJlinerRow.SetNoticeDeliveredNull();
        }



        /// <summary>
        /// UpdateField
        /// </summary>
        /// <param name="id_">id_</param>
        /// <param name="field">field</param>
        /// <param name="value">value</param>
        public void UpdateField(string id_, string field, DateTime? value)
        {
            FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow = GetRow(id_);

            switch (field)
            {
                case "VideoInspection":
                    if (value.HasValue) flatSectionJlinerRow.VideoInspection = (DateTime)value; else flatSectionJlinerRow.SetVideoInspectionNull();
                    break;

                case "PipeLocated":
                    if (value.HasValue) flatSectionJlinerRow.PipeLocated = (DateTime)value; else flatSectionJlinerRow.SetPipeLocatedNull();
                    break;

                case "ServicesLocated":
                    if (value.HasValue) flatSectionJlinerRow.ServicesLocated = (DateTime)value; else flatSectionJlinerRow.SetServicesLocatedNull();
                    break;

                case "CoInstalled":
                    if (value.HasValue) flatSectionJlinerRow.CoInstalled = (DateTime)value; else flatSectionJlinerRow.SetCoInstalledNull();
                    break;

                case "BackfilledConcrete":
                    if (value.HasValue) flatSectionJlinerRow.BackfilledConcrete = (DateTime)value; else flatSectionJlinerRow.SetBackfilledConcreteNull();
                    break;

                case "BackfilledSoil":
                    if (value.HasValue) flatSectionJlinerRow.BackfilledSoil = (DateTime)value; else flatSectionJlinerRow.SetBackfilledSoilNull();
                    break;

                case "Grouted":
                    if (value.HasValue) flatSectionJlinerRow.Grouted = (DateTime)value; else flatSectionJlinerRow.SetGroutedNull();
                    break;

                case "Cored":
                    if (value.HasValue) flatSectionJlinerRow.Cored = (DateTime)value; else flatSectionJlinerRow.SetCoredNull();
                    break;

                case "Prepped":
                    if (value.HasValue) flatSectionJlinerRow.Prepped = (DateTime)value; else flatSectionJlinerRow.SetPreppedNull();
                    break;

                case "PreVideo":
                    if (value.HasValue) flatSectionJlinerRow.PreVideo = (DateTime)value; else flatSectionJlinerRow.SetPreVideoNull();
                    break;

                case "Measured":
                    if (value.HasValue) flatSectionJlinerRow.Measured = (DateTime)value; else flatSectionJlinerRow.SetMeasuredNull();
                    break;

                case "NoticeDelivered":
                    if (value.HasValue) flatSectionJlinerRow.NoticeDelivered = (DateTime)value; else flatSectionJlinerRow.SetNoticeDeliveredNull();
                    break;

                case "InProcess":
                    if ((flatSectionJlinerRow.IsInProcessNull()) && (value.HasValue))
                    {
                        if (!flatSectionJlinerRow.IsBuildRebuildNull())
                        {
                            flatSectionJlinerRow.BuildRebuild = flatSectionJlinerRow.BuildRebuild + 1;
                        }
                        else
                        {
                            flatSectionJlinerRow.BuildRebuild = 1;
                        }
                    }
                    if (value.HasValue) flatSectionJlinerRow.InProcess = (DateTime)value; else flatSectionJlinerRow.SetInProcessNull();
                    break;

                case "InStock":
                    if (value.HasValue) flatSectionJlinerRow.InStock = (DateTime)value; else flatSectionJlinerRow.SetInStockNull();
                    break;

                case "Delivered":
                    if (value.HasValue) flatSectionJlinerRow.Delivered = (DateTime)value; else flatSectionJlinerRow.SetDeliveredNull();
                    break;

                case "LinerInstalled":
                    if (value.HasValue) flatSectionJlinerRow.LinerInstalled = (DateTime)value; else flatSectionJlinerRow.SetLinerInstalledNull();
                    break;

                case "FinalVideo":
                    if (value.HasValue) flatSectionJlinerRow.FinalVideo = (DateTime)value; else flatSectionJlinerRow.SetFinalVideoNull();
                    break;

                case "CoCutDown":
                    if (value.HasValue) flatSectionJlinerRow.CoCutDown = (DateTime)value; else flatSectionJlinerRow.SetCoCutDownNull();
                    break;

                case "FinalRestoration":
                    if (value.HasValue) flatSectionJlinerRow.FinalRestoration = (DateTime)value; else flatSectionJlinerRow.SetFinalRestorationNull();
                    break;                 
            }
        }



        /// <summary>
        /// UpdateCommentsHistoryForProcess
        /// </summary>
        public void UpdateCommentsHistoryForProcess()
        {
            foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table)
            {
                if (!row.IsCommentsNull())
                {
                    row.Comments = row.Comments.Replace("<br>", "\n");
                }

                if (!row.IsHistoryNull())
                {
                    row.History = row.History.Replace("<br>", "\n");
                }
            }
        }



        /// <summary>
        /// UpdateCommentsHistoryForSummaryEdit
        /// </summary>
        public void UpdateCommentsHistoryForSummaryEdit()
        {
            FlatSectionJlinerJuntionLiner2CommentGateway flatSectionJlinerJuntionLiner2CommentGateway = new FlatSectionJlinerJuntionLiner2CommentGateway();
            FlatSectionJlinerJuntionLiner2Comment jlinerComments = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerJuntionLiner2CommentGateway.Data);

            FlatSectionJlinerJuntionLiner2HistoryGateway flatSectionJlinerJuntionLiner2HistoryGateway = new FlatSectionJlinerJuntionLiner2HistoryGateway();
            FlatSectionJlinerJuntionLiner2History jlinerHistory = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerJuntionLiner2HistoryGateway.Data);

            foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table)
            {
                flatSectionJlinerJuntionLiner2CommentGateway.LoadByIdRefId(row.ID, row.RefID, row.COMPANY_ID);
                row.Comments = jlinerComments.GetAllComments(row.ID, row.RefID, row.COMPANY_ID, flatSectionJlinerJuntionLiner2CommentGateway.Table.Rows.Count, "\n");

                flatSectionJlinerJuntionLiner2HistoryGateway.LoadByIdRefId(row.ID, row.RefID, row.COMPANY_ID);
                row.History = jlinerHistory.GetAllHistory(row.ID, row.RefID, row.COMPANY_ID, flatSectionJlinerJuntionLiner2HistoryGateway.Table.Rows.Count, "\n");
            }
        }


                
        /// <summary>
        /// Update selected for one row
        /// </summary>
        /// <param name="id_">id_</param>
        /// <param name="selected">selected</param>
        public void UpdateSelected(string id_, bool selected)
        {
            FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow = GetRow(id_);
            flatSectionJlinerRow.Selected = selected;
        }



        /// <summary>
        /// UpdateComments
        /// </summary>
        /// <param name="id_">id_</param>
        public void UpdateComments(string id_)
        {
            // Updating history fields            
            //FlatSectionJlinerTDS.FlatSectionJlinerRow lfsJunctionLiner2Row = GetRow(id_);

            //JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway();
            //jlinerCommentGateway.LoadByIdRefIdCompanyId(lfsJunctionLiner2Row.ID, lfsJunctionLiner2Row.RefID, lfsJunctionLiner2Row.COMPANY_ID);
            //JlinerComments jlinerComments = new JlinerComments(jlinerCommentGateway.Data);
            //string comments = jlinerComments.GetAllComments(lfsJunctionLiner2Row.ID, lfsJunctionLiner2Row.RefID, lfsJunctionLiner2Row.COMPANY_ID, jlinerCommentGateway.Table.Rows.Count, "<br>");
            //if (comments.Length > 0)
            //{
            //    lfsJunctionLiner2Row.Comments = comments;
            //}
            //else
            //{
            //    lfsJunctionLiner2Row.SetCommentsNull();
            //}

            foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table)
            {
                JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway();
                jlinerCommentGateway.LoadByIdRefId(row.ID, row.RefID, row.COMPANY_ID);
                JlinerComments jlinerComments = new JlinerComments(jlinerCommentGateway.Data);
                string comments = jlinerComments.GetAllComments(row.ID, row.RefID, row.COMPANY_ID, jlinerCommentGateway.Table.Rows.Count, "<br>");
                
                if (comments.Length > 0)
                {
                    row.Comments = comments;
                }
                else
                {
                    row.SetCommentsNull();
                }
            }


        }



        /// <summary>
        /// UpdateHistory
        /// </summary>
        /// <param name="id_">id_</param>
        public void UpdateHistory(string id_)
        {
            //// Updating history fields
            //JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway();

            //FlatSectionJlinerTDS.FlatSectionJlinerRow lfsJunctionLiner2Row = GetRow(id_);

            //jlinerHistoryGateway.LoadByIdRefIdCompanyId(lfsJunctionLiner2Row.ID, lfsJunctionLiner2Row.RefID, lfsJunctionLiner2Row.COMPANY_ID);
            //JlinerHistory jlinerHistory = new JlinerHistory(jlinerHistoryGateway.Data);
            //string history = jlinerHistory.GetAllHistory(lfsJunctionLiner2Row.ID, lfsJunctionLiner2Row.RefID, lfsJunctionLiner2Row.COMPANY_ID, jlinerHistoryGateway.Table.Rows.Count, "<br>");
            //if (history.Length > 0)
            //{
            //    lfsJunctionLiner2Row.History = history;
            //}
            //else
            //{
            //    lfsJunctionLiner2Row.SetHistoryNull();
            //}

            foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table)
            {
                JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway();
                jlinerHistoryGateway.LoadByIdRefId(row.ID, row.RefID, row.COMPANY_ID);
                JlinerHistory jlinerHistory = new JlinerHistory(jlinerHistoryGateway.Data);
                string history = jlinerHistory.GetAllHistory(row.ID, row.RefID, row.COMPANY_ID, jlinerHistoryGateway.Table.Rows.Count, "<br>");

                if (history.Length > 0)
                {
                    row.History = history;
                }
                else
                {
                    row.SetHistoryNull();
                }
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id_">MA.RecordID + '-' + JL.DetailId</param>
        public void Delete(string id_)
        {
            FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow = GetRow(id_);
            flatSectionJlinerRow.Deleted = true;
        }
        


        /// <summary>
        /// Save to Section and Jliner rows
        /// </summary>
        /// <param name="sectionTDS">sectionTDS</param>
        public void Save(SectionTDS sectionTDS)
        {
            FlatSectionJlinerTDS flatSectionJlinerChanges = (FlatSectionJlinerTDS)Data.GetChanges();
            if (flatSectionJlinerChanges.FlatSectionJliner.Rows.Count > 0)
            {
                SectionGateway sectionGateway = new SectionGateway(sectionTDS);
                LiquiForce.LFSLive.BL.CWP.Section.Section section = new LiquiForce.LFSLive.BL.CWP.Section.Section(sectionTDS);
                JlinerGateway jlinerGateway = new JlinerGateway(sectionTDS);
                Jliner jliner = new Jliner(sectionTDS);
                JlinerCommentGateway jlinerCommentGateway = new JlinerCommentGateway(sectionTDS);
                JlinerComments jlinerComments = new JlinerComments(jlinerCommentGateway.Data);
                JlinerHistoryGateway jlinerHistoryGateway = new JlinerHistoryGateway(sectionTDS);
                JlinerHistory jlinerHistory = new JlinerHistory(jlinerHistoryGateway.Data);

                sectionGateway.ClearBeforeFill = false;
                jlinerGateway.ClearBeforeFill = false;
                jlinerCommentGateway.ClearBeforeFill = false;
                jlinerHistoryGateway.ClearBeforeFill = false;

                foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)flatSectionJlinerChanges.FlatSectionJliner)
                {
                    // Load section and jliner
                    // ... Load section
                    try
                    {
                        //... Search section row
                        sectionGateway.GetRow(flatSectionJlinerRow.ID);
                    }
                    catch
                    {
                        //... Load section and section's jliners
                        sectionGateway.LoadById(flatSectionJlinerRow.ID, flatSectionJlinerRow.COMPANY_ID);
                        jlinerGateway.LoadByIdCompanyId(flatSectionJlinerRow.ID, flatSectionJlinerRow.COMPANY_ID);
                        jlinerCommentGateway.LoadById(flatSectionJlinerRow.ID, flatSectionJlinerRow.COMPANY_ID);
                        jlinerHistoryGateway.LoadById(flatSectionJlinerRow.ID, flatSectionJlinerRow.COMPANY_ID);
                    }

                    // Update
                    
                    // ... Update jliner
                    string address = ""; if (!flatSectionJlinerRow.IsNull("Address")) address = flatSectionJlinerRow.Address;
                    DateTime? pipeLocated = null; if (!flatSectionJlinerRow.IsNull("PipeLocated")) pipeLocated = flatSectionJlinerRow.PipeLocated;
                    DateTime? servicesLocated = null; if (!flatSectionJlinerRow.IsNull("ServicesLocated")) servicesLocated = flatSectionJlinerRow.ServicesLocated;
                    DateTime? coInstalled = null; if (!flatSectionJlinerRow.IsNull("CoInstalled")) coInstalled = flatSectionJlinerRow.CoInstalled;
                    DateTime? backfilledConcrete = null; if (!flatSectionJlinerRow.IsNull("BackfilledConcrete")) backfilledConcrete = flatSectionJlinerRow.BackfilledConcrete;
                    DateTime? backfilledSoil = null; if (!flatSectionJlinerRow.IsNull("BackfilledSoil")) backfilledSoil = flatSectionJlinerRow.BackfilledSoil;
                    DateTime? grouted = null; if (!flatSectionJlinerRow.IsNull("Grouted")) grouted = flatSectionJlinerRow.Grouted;
                    DateTime? cored = null; if (!flatSectionJlinerRow.IsNull("Cored")) cored = flatSectionJlinerRow.Cored;
                    DateTime? prepped = null; if (!flatSectionJlinerRow.IsNull("Prepped")) prepped = flatSectionJlinerRow.Prepped;
                    DateTime? measured = null; if (!flatSectionJlinerRow.IsNull("Measured")) measured = flatSectionJlinerRow.Measured;
                    string linerSize = ""; if (!flatSectionJlinerRow.IsNull("LinerSize")) linerSize = flatSectionJlinerRow.LinerSize;
                    DateTime? inProcess = null; if (!flatSectionJlinerRow.IsNull("Inprocess")) inProcess = flatSectionJlinerRow.InProcess;
                    DateTime? inStock = null; if (!flatSectionJlinerRow.IsNull("InStock")) inStock = flatSectionJlinerRow.InStock;
                    DateTime? delivered = null; if (!flatSectionJlinerRow.IsNull("Delivered")) delivered = flatSectionJlinerRow.Delivered;
                    DateTime? preVideo = null; if (!flatSectionJlinerRow.IsNull("PreVideo")) preVideo = flatSectionJlinerRow.PreVideo;
                    DateTime? linerInstalled = null; if (!flatSectionJlinerRow.IsNull("LinerInstalled")) linerInstalled = flatSectionJlinerRow.LinerInstalled;
                    DateTime? finalVideo = null; if (!flatSectionJlinerRow.IsNull("FinalVideo")) finalVideo = flatSectionJlinerRow.FinalVideo;
                    double? distanceFromUSMH = null; if (!flatSectionJlinerRow.IsNull("DistanceFromUSMH")) distanceFromUSMH = flatSectionJlinerRow.DistanceFromUSMH;
                    double? distanceFromDSMH = null; if (!flatSectionJlinerRow.IsNull("DistanceFromDSMH")) distanceFromDSMH = flatSectionJlinerRow.DistanceFromDSMH;
                    string history = ""; if (!flatSectionJlinerRow.IsNull("History")) history = flatSectionJlinerRow.History;
                    string map = "";
                    string issue = flatSectionJlinerRow.Issue;
                    decimal? cost = null; if (!flatSectionJlinerRow.IsNull("Cost")) cost = flatSectionJlinerRow.Cost;
                    bool deleted = flatSectionJlinerRow.Deleted;

                    // ... Delete all comments and history for a jliner
                    if (deleted)
                    {
                        jlinerComments.DeleteAllCommentsForAJliner(flatSectionJlinerRow.ID, flatSectionJlinerRow.RefID, flatSectionJlinerRow.COMPANY_ID);
                        jlinerHistory.DeleteAllHistoryForAJliner(flatSectionJlinerRow.ID, flatSectionJlinerRow.RefID, flatSectionJlinerRow.COMPANY_ID);
                    }

                    DateTime? videoInspection = null; if (!flatSectionJlinerRow.IsNull("VideoInspection")) videoInspection = flatSectionJlinerRow.VideoInspection;
                    bool coRequired = flatSectionJlinerRow.CoRequired;
                    bool pitRequired = flatSectionJlinerRow.PitRequired;
                    string coPitLocation = ""; if (!flatSectionJlinerRow.IsNull("CoPitLocation")) coPitLocation = flatSectionJlinerRow.CoPitLocation;
                    bool postContractDigRequired = flatSectionJlinerRow.PostContractDigRequired;
                    DateTime? coCutDown = null; if (!flatSectionJlinerRow.IsNull("CoCutDown")) coCutDown = flatSectionJlinerRow.CoCutDown;
                    DateTime? finalRestoration = null; if (!flatSectionJlinerRow.IsNull("FinalRestoration")) finalRestoration = flatSectionJlinerRow.FinalRestoration;
                    string clientLateralId = ""; if (!flatSectionJlinerRow.IsNull("ClientLateralID")) clientLateralId = flatSectionJlinerRow.ClientLateralID;
                    string videoLengthToPropertyLine = ""; if (!flatSectionJlinerRow.IsNull("VideoLengthToPropertyLine")) videoLengthToPropertyLine = flatSectionJlinerRow.VideoLengthToPropertyLine;
                    bool liningThruCo = flatSectionJlinerRow.LiningThruCo;
                    string hamiltonInspectionNumber = ""; if (!flatSectionJlinerRow.IsNull("HamiltonInspectionNumber")) hamiltonInspectionNumber = flatSectionJlinerRow.HamiltonInspectionNumber;
                    DateTime? noticeDelivered = null; if (!flatSectionJlinerRow.IsNull("NoticeDelivered")) noticeDelivered = flatSectionJlinerRow.NoticeDelivered;

                    jliner.Update(flatSectionJlinerRow.ID, flatSectionJlinerRow.RefID, flatSectionJlinerRow.COMPANY_ID, flatSectionJlinerRow.DetailID, address, pipeLocated, servicesLocated, coInstalled, backfilledConcrete, backfilledSoil, grouted, cored, prepped, measured, linerSize, inProcess, inStock, delivered, preVideo, linerInstalled, finalVideo, distanceFromUSMH, distanceFromDSMH,map, issue, cost, deleted, videoInspection, coRequired, pitRequired, coPitLocation, postContractDigRequired, coCutDown, finalRestoration, clientLateralId, videoLengthToPropertyLine, liningThruCo, hamiltonInspectionNumber, noticeDelivered);
                    
                    // ... Update section
                    section.UpdateJliners(flatSectionJlinerRow.ID, flatSectionJlinerRow.COMPANY_ID);
                }
            }
        }



        /// <summary>
        /// Save all sections & works to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int companyId)
        {
            FlatSectionJlinerTDS jlinerChanges = (FlatSectionJlinerTDS)Data.GetChanges();

            if (jlinerChanges.FlatSectionJliner.Rows.Count > 0)
            {
                FlatSectionJlinerGateway flatSectionJlinerGateway = new FlatSectionJlinerGateway(jlinerChanges);

                foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)jlinerChanges.FlatSectionJliner)
                {
                    // Update comments and history
                    if (!row.Deleted)
                    {
                        Guid id = row.ID;
                        int refId = row.RefID;

                        // original values
                        string originalDetailId = flatSectionJlinerGateway.GetDetailIDOriginal(id, refId, companyId);
                        string originalAddress = flatSectionJlinerGateway.GetAddressOriginal(id, refId, companyId);
                        DateTime? originalPipeLocated = flatSectionJlinerGateway.GetPipeLocatedOriginal(id, refId, companyId);
                        DateTime? originalServicesLocated = flatSectionJlinerGateway.GetServicesLocatedOriginal(id, refId, companyId);
                        DateTime? originalCoInstalled = flatSectionJlinerGateway.GetCoInstalledOriginal(id, refId, companyId);
                        DateTime? originalBackfilledConcrete = flatSectionJlinerGateway.GetBackfilledConcreteOriginal(id, refId, companyId);
                        DateTime? originalBackfilledSoil = flatSectionJlinerGateway.GetBackfilledSoilOriginal(id, refId, companyId);
                        DateTime? originalGrouted = flatSectionJlinerGateway.GetGroutedOriginal(id, refId, companyId);
                        DateTime? originalCored = flatSectionJlinerGateway.GetCoredOriginal(id, refId, companyId);
                        DateTime? originalPrepped = flatSectionJlinerGateway.GetPreppedOriginal(id, refId, companyId);
                        DateTime? originalMeasured = flatSectionJlinerGateway.GetMeasuredOriginal(id, refId, companyId);
                        string originalLinerSize = flatSectionJlinerGateway.GetLinerSizeOriginal(id, refId, companyId);
                        DateTime? originalInProcess = flatSectionJlinerGateway.GetInProcessOriginal(id, refId, companyId);
                        DateTime? originalInStock = flatSectionJlinerGateway.GetInStockOriginal(id, refId, companyId);
                        DateTime? originalDelivered = flatSectionJlinerGateway.GetDeliveredOriginal(id, refId, companyId);
                        int? originalBuildRebuild = flatSectionJlinerGateway.GetBuildRebuildOriginal(id, refId, companyId);
                        DateTime? originalPreVideo = flatSectionJlinerGateway.GetPreVideoOriginal(id, refId, companyId);
                        DateTime? originalLinerInstalled = flatSectionJlinerGateway.GetLinerInstalledOriginal(id, refId, companyId);
                        DateTime? originalFinalVideo = flatSectionJlinerGateway.GetFinalVideoOriginal(id, refId, companyId);
                        double? originalDistanceFromUSMH = flatSectionJlinerGateway.GetDistanceFromUSMHOriginal(id, refId, companyId);
                        double? originalDistanceFromDSMH = flatSectionJlinerGateway.GetDistanceFromDSMHOriginal(id, refId, companyId);
                        string originalMap = flatSectionJlinerGateway.GetMapOriginal(id, refId, companyId);
                        string originalIssue = flatSectionJlinerGateway.GetIssueOriginal(id, refId, companyId);
                        decimal? originalCost = flatSectionJlinerGateway.GetCostOriginal(id, refId, companyId);
                        DateTime? originalVideoInspection = flatSectionJlinerGateway.GetVideoInspectionOriginal(id, refId, companyId);
                        bool originalCoRequired = flatSectionJlinerGateway.GetCoRequiredOriginal(id, refId, companyId);
                        bool originalPitRequired = flatSectionJlinerGateway.GetPitRequiredOriginal(id, refId, companyId);
                        string originalCoPitLocation = flatSectionJlinerGateway.GetCoPitLocationOriginal(id, refId, companyId);
                        bool originalPostContractDigRequired = flatSectionJlinerGateway.GetPostContractDigRequiredOriginal(id, refId, companyId);
                        string originalComments = flatSectionJlinerGateway.GetCommentsOriginal(id, refId, companyId);
                        string originalHistory = flatSectionJlinerGateway.GetHistoryOriginal(id, refId, companyId);
                        DateTime? originalCoCutDown = flatSectionJlinerGateway.GetCoCutDownOriginal(id, refId, companyId);
                        DateTime? originalFinalRestoration = flatSectionJlinerGateway.GetFinalRestorationOriginal(id, refId, companyId);
                        string originalClientLateralID = flatSectionJlinerGateway.GetClientLateralIDOriginal(id, refId, companyId);
                        string originalVideoLengthToPropertyLine = flatSectionJlinerGateway.GetVideoLengthToPropertyLineOriginal(id, refId, companyId);
                        bool originalLiningThruCo = flatSectionJlinerGateway.GetLiningThruCoOriginal(id, refId, companyId);
                        string originalHamiltonInspectionNumber = flatSectionJlinerGateway.GetHamiltonInspectionNumberOriginal(id, refId, companyId);
                        DateTime? originalNoticeDelivered = flatSectionJlinerGateway.GetNoticeDeliveredOriginal(id, refId, companyId);

                        // new values                        
                        string newComments = flatSectionJlinerGateway.GetComments(id, refId, companyId);
                        string newHistory = flatSectionJlinerGateway.GetHistory(id, refId, companyId);                        

                        Jliner jliner = new Jliner(null);
                        jliner.UpdateDirect(row.ID, row.RefID, row.COMPANY_ID, originalDetailId, originalAddress, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalDistanceFromUSMH, originalDistanceFromDSMH, originalMap, originalIssue, originalCost, false, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, originalComments, originalHistory, originalCoCutDown, originalFinalRestoration, originalClientLateralID, originalVideoLengthToPropertyLine, originalLiningThruCo, originalHamiltonInspectionNumber, originalNoticeDelivered, row.ID, row.RefID, row.COMPANY_ID, originalDetailId, originalAddress, originalPipeLocated, originalServicesLocated, originalCoInstalled, originalBackfilledConcrete, originalBackfilledSoil, originalGrouted, originalCored, originalPrepped, originalMeasured, originalLinerSize, originalInProcess, originalInStock, originalDelivered, originalBuildRebuild, originalPreVideo, originalLinerInstalled, originalFinalVideo, originalDistanceFromUSMH, originalDistanceFromDSMH, originalMap, originalIssue, originalCost, false, originalVideoInspection, originalCoRequired, originalPitRequired, originalCoPitLocation, originalPostContractDigRequired, newComments, newHistory, originalCoCutDown, originalFinalRestoration, originalClientLateralID, originalVideoLengthToPropertyLine, originalLiningThruCo, originalHamiltonInspectionNumber, originalNoticeDelivered);
                    }
                }
            }
        }



        /// <summary>
        /// GetGeneralId. 
        /// </summary>
        /// <returns>id<returns>
        public Guid GetGeneralId()
        {
            Guid id = new Guid();

            foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table)
            {
               id = row.ID;
            }
            return (id);
        }



        /// <summary>
        /// GetGeneralCompanyId 
        /// </summary>
        /// <returns>companyId<returns>
        public int GetGeneralCompanyId()
        {
            int companyId = 0;

            foreach (FlatSectionJlinerTDS.FlatSectionJlinerRow row in (FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table)
            {
                companyId = row.COMPANY_ID;
            }
            return (companyId);
        }


        



        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single FlatSectionJlinerRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="id_">MA.RecordID + '-' + JL.DetailId</param>
        /// <returns>Row obtained</returns>
        private FlatSectionJlinerTDS.FlatSectionJlinerRow GetRow(string id_)
        {
            FlatSectionJlinerTDS.FlatSectionJlinerRow flatSectionJlinerRow = ((FlatSectionJlinerTDS.FlatSectionJlinerDataTable)Table).FindByID_(id_);

            if (flatSectionJlinerRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.FlatSectionJliner.GetRow");
            }

            return flatSectionJlinerRow;
        }



    }
}