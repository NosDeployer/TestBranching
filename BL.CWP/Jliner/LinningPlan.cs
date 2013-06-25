using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.CWP.Section;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// LinningPlan
    /// </summary>
    public class LinningPlan : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LinningPlan() : base("LinningPlan")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public LinningPlan(DataSet data) : base(data, "LinningPlan")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LinningPlanTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="companyId">companyId</param>
        /// <param name="date_">date_</param>
        /// <param name="flusher">flusher</param>
        /// <param name="flusherMN">flusherMN</param>
        /// <param name="liner">liner</param>
        /// <param name="linerMN">linerMN</param>
        /// <param name="rotator">rotator</param>
        /// <param name="rotatorMN">rotatorMN</param>
        /// <param name="compressor">compressor</param>
        /// <param name="compressorMN">compressorMN</param>
        /// <param name="selected">selected</param>
        public void UpdateForReport(Guid id, int companyId, DateTime? date_, string flusher, string flusherMN, string liner, string linerMN, string rotator, string rotatorMN, string compressor, string compressorMN, string selected, string linerMNType)
        {
            LinningPlanTDS.LinningPlanRow linningPlanRow = GetRow(id, companyId);

            if (date_.HasValue) linningPlanRow.Date_ = (DateTime)date_; else linningPlanRow.SetDate_Null();
            linningPlanRow.Flusher = flusher;
            linningPlanRow.FlusherMN = flusherMN.Trim();
            linningPlanRow.Liner = liner;
            linningPlanRow.LinerMN = linerMN.Trim();
            linningPlanRow.Rotator = rotator;
            linningPlanRow.RotatorMN = rotatorMN.Trim();
            linningPlanRow.Compressor = compressor;
            linningPlanRow.CompressorMN = compressorMN.Trim();
            linningPlanRow.Selected = selected;
            linningPlanRow.LinerMNType = linerMNType;
        }



        /// <summary>
        /// ProcessForReport
        /// </summary>
        /// <param name="linningPlanTDS">TDS for process</param>
        public void ProcessForReport(LinningPlanTDS linningPlanTDS)
        {
            LinningPlanJlinerGateway linningPlanJlinerGateway = new LinningPlanJlinerGateway(Data);
            linningPlanJlinerGateway.ClearBeforeFill = false;
            LinningPlanJliner linningPlanJliner = new LinningPlanJliner(Data);

            foreach (LinningPlanTDS.LinningPlanRow linningPlanRow in linningPlanTDS.LinningPlan.Rows)
            {
                if (linningPlanRow.Selected != "9")
                {
                    // Create row for report
                    LinningPlanTDS.LinningPlanRow newRow = ((LinningPlanTDS.LinningPlanDataTable)Table).NewLinningPlanRow();

                    newRow.ID = linningPlanRow.ID;
                    newRow.COMPANY_ID = linningPlanRow.COMPANY_ID;
                    newRow.RecordID = linningPlanRow.RecordID;
                    if (!linningPlanRow.IsStreetNull()) newRow.Street = linningPlanRow.Street;
                    if (!linningPlanRow.IsConfirmedSizeNull()) newRow.ConfirmedSize = linningPlanRow.ConfirmedSize;
                    if (!linningPlanRow.IsBypassRequiredNull()) newRow.BypassRequired = linningPlanRow.BypassRequired;
                    if (!linningPlanRow.IsDegreeOfTrafficControlNull()) newRow.DegreeOfTrafficControl = linningPlanRow.DegreeOfTrafficControl;
                    if (!linningPlanRow.IsNumLatsNull()) newRow.NumLats = linningPlanRow.NumLats;
                    if (!linningPlanRow.IsNotLinedYetNull()) newRow.NotLinedYet = linningPlanRow.NotLinedYet;
                    if (!linningPlanRow.IsActualLengthNull()) newRow.ActualLength = linningPlanRow.ActualLength;
                    if (!linningPlanRow.IsUSMHNull()) newRow.USMH = linningPlanRow.USMH;
                    if (!linningPlanRow.IsDSMHNull()) newRow.DSMH = linningPlanRow.DSMH;
                    if (!linningPlanRow.IsAllMeasuredNull()) newRow.AllMeasured = linningPlanRow.AllMeasured;
                    if (!linningPlanRow.IsDate_Null()) newRow.Date_ = linningPlanRow.Date_;
                    if (!linningPlanRow.IsFlusherNull()) newRow.Flusher = linningPlanRow.Flusher;
                    if (!linningPlanRow.IsFlusherMNNull()) newRow.FlusherMN = linningPlanRow.FlusherMN;
                    if (!linningPlanRow.IsLinerNull()) newRow.Liner = linningPlanRow.Liner;
                    if (!linningPlanRow.IsLinerMNNull()) newRow.LinerMN = linningPlanRow.LinerMN;
                    if (!linningPlanRow.IsRotatorNull()) newRow.Rotator = linningPlanRow.Rotator;
                    if (!linningPlanRow.IsRotatorMNNull()) newRow.RotatorMN = linningPlanRow.RotatorMN;
                    if (!linningPlanRow.IsCompressorNull()) newRow.Compressor = linningPlanRow.Compressor;
                    if (!linningPlanRow.IsCompressorMNNull()) newRow.CompressorMN = linningPlanRow.CompressorMN;
                    newRow.Selected = linningPlanRow.Selected;
                    if (!linningPlanRow.IsLinerMNTypeNull()) newRow.LinerMNType = linningPlanRow.LinerMNType; else newRow.LinerMNType = "";
                    
                    ((LinningPlanTDS.LinningPlanDataTable)Table).AddLinningPlanRow(newRow);

                    // Select jliners for report
                    linningPlanJlinerGateway.LoadByIdMn(linningPlanRow.ID, linningPlanRow.COMPANY_ID, newRow.LinerMNType);
                    linningPlanJliner.UpdateCommentsForReport();
                }
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single LinningPlanRow. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">GUID ID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Row obtained</returns>
        private LinningPlanTDS.LinningPlanRow GetRow(Guid id, int companyId)
        {
            LinningPlanTDS.LinningPlanRow linningPlanRow = ((LinningPlanTDS.LinningPlanDataTable)Table).FindByIDCOMPANY_ID(id, companyId);

            if (linningPlanRow == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Jliner.LinningPlan.GetRow");
            }

            return linningPlanRow;
        }



    }
}
