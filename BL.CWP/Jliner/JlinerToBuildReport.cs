using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Section;

namespace LiquiForce.LFSLive.BL.CWP.Jliner
{
    /// <summary>
    /// JlinerToBuildReport
    /// </summary>
    public class JlinerToBuildReport : TableModule
    {

        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //



        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerToBuildReport()
            : base("JLinersToBuild")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public JlinerToBuildReport(DataSet data)
            : base(data, "JLinersToBuild")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinertoBuildReportTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>        
        public void Load(int companyId)
        {
            JlinertoBuildReportGateway jlinertoBuildReportGateway = new JlinertoBuildReportGateway(Data);
            jlinertoBuildReportGateway.Load(companyId);
        }



        /// <summary>
        /// LoadByCompaniesID
        /// </summary>
        /// <param name="companiesId">COMPANIES_ID</param>
        /// <param name="companyId">companyId</param>         
        public void LoadByCompaniesID(int companyId, int companiesId)
        {
            JlinertoBuildReportGateway jlinertoBuildReportGateway = new JlinertoBuildReportGateway(Data);
            jlinertoBuildReportGateway.LoadByCompaniesID(companyId, companiesId);
        }



        /// <summary>
        /// UpdateForProcess
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void UpdateForReport(int companyId)
        {
            SectionGateway sectionGateway = new SectionGateway();
            JlinerGateway jlinerGateway = new JlinerGateway(sectionGateway.Data);
            Jliner jliner = new Jliner(sectionGateway.Data);

            sectionGateway.ClearBeforeFill = false;
            jlinerGateway.ClearBeforeFill = false;

            SectionTDS.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row;

            foreach (JlinertoBuildReportTDS.JLinersToBuildRow jLinersToBuildRow in ((JlinertoBuildReportTDS.JLinersToBuildDataTable)Table))
            {
                // Load sections
                try
                {
                    sectionGateway.GetRow(jLinersToBuildRow.ID);
                }
                catch 
                {                    
                    sectionGateway.LoadById(jLinersToBuildRow.ID, companyId); 
                }

                // Load laterals
                try
                {
                    lfsJunctionLiner2Row = (SectionTDS.LFS_JUNCTION_LINER2Row) jlinerGateway.GetRow(jLinersToBuildRow.ID, jLinersToBuildRow.RefID);
                }
                catch 
                {
                    jlinerGateway.LoadByIdCompanyId(jLinersToBuildRow.ID, companyId);
                    lfsJunctionLiner2Row = (SectionTDS.LFS_JUNCTION_LINER2Row) jlinerGateway.GetRow(jLinersToBuildRow.ID, jLinersToBuildRow.RefID);
                }

                // Update InProcess
                lfsJunctionLiner2Row.InProcess = DateTime.Now;
                lfsJunctionLiner2Row.BuildRebuild++;
            }

            //Update
            try
            {
                sectionGateway.Update();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
