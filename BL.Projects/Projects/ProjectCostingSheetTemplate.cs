using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetTemplate
    /// </summary>
    public class ProjectCostingSheetTemplate : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetTemplate()
            : base("LFS_PROJECT_COSTING_SHEET_TEMPLATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetTemplate(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_SHEET_TEMPLATE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// InsertDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="refId">refId</param>
        /// <param name="unitOfMeasurement">unitOfMeasurement</param>
        /// <param name="quantity">quantity</param>
        /// <param name="costCad">costCad</param>
        /// <param name="totalCostCad">totalCostCad</param>
        /// <param name="costUsd">costUsd</param>
        /// <param name="totalCostUsd">totalCostUsd</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="function_">function_</param>
        /// <param name="comment">comment</param>
        public void InsertDirect(string name, bool raData, bool fllData, bool prData, bool jlData, bool mrData, bool mobData, bool otherData, bool labourHourData, bool unitData, bool materialData, bool subcontractorData, bool miscData, bool revenueIncluded, bool deleted, int companyId, int? month, int? day, int? year, int? month2, int? day2, int? year2)
        {
            // Insert costing sheet Revenues
            ProjectCostingSheetTemplateGateway projectCostingSheetTemplateGateway = new ProjectCostingSheetTemplateGateway(null);
            projectCostingSheetTemplateGateway.Insert(name, raData, fllData, prData, jlData, mrData, mobData, otherData, labourHourData, unitData, materialData, subcontractorData, miscData, revenueIncluded, deleted, companyId, month, day, year, month2, day2, year2);
        }



        /// <summary>
        /// UpdateDirect
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="work_">work_</param>
        /// <param name="refIDRevenue">refIDRevenue</param>
        /// <param name="originalRevenue">originalRevenue</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalStartDate">originalStartDate</param>
        /// <param name="originalEndDate">originalEndDate</param>
        /// <param name="originalComment">originalComment</param>
        ///  
        /// <param name="newUnitOfMeasurement">newRevenue</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newStartDate">newStartDate</param>
        /// <param name="newEndDate">newEndDate</param>
        /// <param name="newComment">newComment</param>
        public void UpdateDirect(int costingSheetTemplateId, string originalName, bool originalRaData, bool originalFllData, bool originalPrData, bool originalJlData, bool originalMrData, bool originalMobData, bool originalOtherData, bool originalLabourHourData, bool originalUnitData, bool originalMaterialData, bool originalSubcontractorData, bool originalMiscData, bool originalRevenueIncluded, bool originalDeleted, int originalCompanyId, int? originalMonth, int? originalDay, int? originalYear, int? originalMonth2, int? originalDay2, int? originalYear2, string newName, bool newRaData, bool newFllData, bool newPrData, bool newJlData, bool newMrData, bool newMobData, bool newOtherData, bool newLabourHourData, bool newUnitData, bool newMaterialData, bool newSubcontractorData, bool newMiscData, bool newRevenueIncluded, bool newDeleted, int newCompanyId, int? newMonth, int? newDay, int? newYear, int? newMonth2, int? newDay2, int? newYear2)
        {
            ProjectCostingSheetTemplateGateway projectCostingSheetTemplateGateway = new ProjectCostingSheetTemplateGateway(null);
            projectCostingSheetTemplateGateway.Update(costingSheetTemplateId, originalName, originalRaData, originalFllData, originalPrData, originalJlData, originalMrData, originalMobData, originalOtherData, originalLabourHourData, originalUnitData, originalMaterialData, originalSubcontractorData, originalMiscData, originalRevenueIncluded, originalDeleted, originalCompanyId, originalMonth, originalDay, originalYear, originalMonth2, originalDay2, originalYear2, newName, newRaData, newFllData, newPrData, newJlData, newMrData, newMobData, newOtherData, newLabourHourData, newUnitData, newMaterialData, newSubcontractorData, newMiscData, newRevenueIncluded, newDeleted, newCompanyId, newMonth, newDay, newYear, newMonth2, newDay2, newYear2);
        }



        /// <summary>
        /// DeleteDirect
        /// </summary>
        /// <param name="costingSheetTemplateId">costingSheetTemplateId</param>
        /// <param name="companyId">companyId</param>
        public void DeleteDirect(int costingSheetTemplateId, int companyId)
        {
            ProjectCostingSheetTemplateGateway projectCostingSheetTemplateGateway = new ProjectCostingSheetTemplateGateway(null);
            projectCostingSheetTemplateGateway.Delete(costingSheetTemplateId, companyId);
        }



    }
}