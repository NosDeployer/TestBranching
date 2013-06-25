using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Materials;
using LiquiForce.LFSLive.BL.Resources.Materials;

namespace LiquiForce.LFSLive.BL.Resources.Materials
{
    /// <summary>
    /// MaterialsByProcessReport
    /// </summary>
    public class MaterialsByProcessReport : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsByProcessReport()
            : base("MaterialsByProcessReport")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsByProcessReport(DataSet data)
            : base(data, "MaterialsByProcessReport")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new MaterialsByProcessReportTDS();
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
            MaterialsByProcessReportGateway materialsByProcessReportGateway = new MaterialsByProcessReportGateway(Data);
            materialsByProcessReportGateway.Load(companyId);

            UpdateFieldsForSections();
        }



        /// <summary>
        /// LoadByProcess
        /// </summary>
        /// <param name="process">process</param>
        /// <param name="companyId">companyId</param>
        public void LoadByProcess(string process, int companyId)
        {
            MaterialsByProcessReportGateway materialsByProcessReportGateway = new MaterialsByProcessReportGateway(Data);
            materialsByProcessReportGateway.LoadByProcess(process, companyId);

            UpdateFieldsForSections();
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// PRIVATE METHODS
        ///

        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        private void UpdateFieldsForSections()
        {
            foreach (MaterialsByProcessReportTDS.MaterialsByProcessReportRow row in (MaterialsByProcessReportTDS.MaterialsByProcessReportDataTable)Table)
            {
                MaterialsInformationNoteInformationGateway materialsInformationNoteInformationGateway = new MaterialsInformationNoteInformationGateway();
                materialsInformationNoteInformationGateway.LoadAllByMaterialId(row.MaterialID, row.COMPANY_ID);

                MaterialsInformationNoteInformation materialsInformationNoteInformation = new MaterialsInformationNoteInformation(materialsInformationNoteInformationGateway.Data);
                string comments = materialsInformationNoteInformation.GetAllNotes(row.MaterialID, row.COMPANY_ID, materialsInformationNoteInformationGateway.Table.Rows.Count, "\n");

                if (comments.Length > 0)
                {
                    row.Notes = comments;
                }
                else
                {
                    row.SetNotesNull();
                }
            }
        }

        
                
    }
}