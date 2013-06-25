using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectCostingSheetTemplateInformation
    /// </summary>
    public class ProjectCostingSheetTemplateInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingSheetTemplateInformation()
            : base("TemplateInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingSheetTemplateInformation(DataSet data)
            : base(data, "TemplateInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }



        


        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAll
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            ProjectCostingSheetTemplateInformationGateway projectCostingSheetAddTemplateGateway = new ProjectCostingSheetTemplateInformationGateway(Data);
            projectCostingSheetAddTemplateGateway.LoadAll(companyId);
            
            if (projectCostingSheetAddTemplateGateway.Table.Rows.Count > 0)
            {
                foreach (ProjectCostingSheetAddTDS.TemplateInformationRow row in (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Table)
                {
                    string typeOfWork = "";
                    if (row.RAData) typeOfWork = "RA";
                    if (row.FLLData) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- FLL"; else typeOfWork = "FLL"; }
                    if (row.PRData) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- PR"; else typeOfWork = "PR"; }
                    if (row.JLData) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- JL"; else typeOfWork = "JL"; }
                    if (row.MRData) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- MR"; else typeOfWork = "MR"; }
                    if (row.MOBData) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- MOB"; else typeOfWork = "MOB"; }
                    if (row.OtherData) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- Other"; else typeOfWork = "Other"; }
                    row.TypeOfWork = typeOfWork;

                    string costingArea = "";
                    if (row.LabourHourData) costingArea = "Labour Hour";
                    if (row.UnitData) { if (costingArea.Length > 0) costingArea = costingArea + "- Unit"; else costingArea = "Unit"; }
                    if (row.MaterialData) { if (costingArea.Length > 0) costingArea = costingArea + "- Material"; else costingArea = "Material"; }
                    if (row.SubcontractorData) { if (costingArea.Length > 0) costingArea = costingArea + "- Subcontractor"; else costingArea = "Subcontractor"; }
                    if (row.MiscData) { if (costingArea.Length > 0) costingArea = costingArea + "- Misc."; else costingArea = "Misc."; }
                    row.CostingArea = costingArea;
                }
            }
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="revenue">revenue</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="comment">comment</param>
        public void Insert(string name, bool raData, bool fllData, bool prData, bool jlData, bool mrData, bool mobData, bool otherData, bool labourHourData, bool unitData, bool materialData, bool subcontractorData, bool miscData, bool revenueIncluded, bool deleted, int companyId, int? month, int? day, int? year, int? month2, int? day2, int? year2)
        {
            ProjectCostingSheetAddTDS.TemplateInformationRow row = ((ProjectCostingSheetAddTDS.TemplateInformationDataTable)Table).NewTemplateInformationRow();

            row.CostingSheetTemplateID = GetNewCostingSheetTemplateId();
            row.Name = name;
            row.RAData = raData;
            row.FLLData = fllData;
            row.PRData = prData;
            row.JLData = jlData;
            row.MRData = mrData;
            row.MOBData = mobData;
            row.OtherData = otherData;
            row.LabourHourData = labourHourData;
            row.UnitData = unitData;
            row.MaterialData = materialData;
            row.SubcontractorData = subcontractorData;
            row.MiscData = miscData;
            row.RevenueIncluded = revenueIncluded;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = false;

            if (month.HasValue) row.Month = month.Value; else row.SetMonthNull();
            if (day.HasValue) row.Day = day.Value; else row.SetDayNull();
            if (year.HasValue) row.Year = year.Value; else row.SetYearNull();

            if (month2.HasValue) row.Month2 = month2.Value; else row.SetMonth2Null();
            if (day2.HasValue) row.Day2 = day2.Value; else row.SetDay2Null();
            if (year2.HasValue) row.Year2 = year2.Value; else row.SetYear2Null();

            ((ProjectCostingSheetAddTDS.TemplateInformationDataTable)Table).AddTemplateInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIdTemplate">refIdTemplate</param>
        /// <param name="revenue">revenue</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="startDate">startDate</param>
        /// <param name="endDate">endDate</param>
        /// <param name="comment">comment</param>
        public void Update(int costingSheetTemplateId, string name, bool raData, bool fllData, bool prData, bool jlData, bool mrData, bool mobData, bool otherData, bool labourHourData, bool unitData, bool materialData, bool subcontractorData, bool miscData, bool revenueIncluded, bool deleted, int companyId, int? month, int? day, int? year, int? month2, int? day2, int? year2)
        {
            ProjectCostingSheetAddTDS.TemplateInformationRow row = GetRow(costingSheetTemplateId);

            row.Name = name;
            row.RAData = raData;
            row.FLLData = fllData;
            row.PRData = prData;
            row.JLData = jlData;
            row.MRData = mrData;
            row.MOBData = mobData;
            row.OtherData = otherData;
            row.LabourHourData = labourHourData;
            row.UnitData = unitData;
            row.MaterialData = materialData;
            row.SubcontractorData = subcontractorData;
            row.MiscData = miscData;
            row.RevenueIncluded = revenueIncluded;

            if (month.HasValue) row.Month = month.Value; else row.SetMonthNull();
            if (day.HasValue) row.Day = day.Value; else row.SetDayNull();
            if (year.HasValue) row.Year = year.Value; else row.SetYearNull();

            if (month2.HasValue) row.Month2 = month2.Value; else row.SetMonth2Null();
            if (day2.HasValue) row.Day2 = day2.Value; else row.SetDay2Null();
            if (year2.HasValue) row.Year2 = year2.Value; else row.SetYear2Null();
        }



        /// <summary>
        /// Update 
        /// </summary>
        /// <param name="teamProjectTimeId">teamProjectTimeId</param>
        /// <param name="selected">selected</param>
        public void Update(int costingSheetTemplateId, bool selected)
        {
            ProjectCostingSheetAddTDS.TemplateInformationRow row = GetRow(costingSheetTemplateId);
            row.Selected = selected;
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refId">refIdTemplate</param>
        public void Delete(int costingSheetTemplateId)
        {
            ProjectCostingSheetAddTDS.TemplateInformationRow row = GetRow(costingSheetTemplateId);
            row.Deleted = true;
        }



        /// <summary>
        /// Save all Template Costing Sheet
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="costingSheetId">costingSheetId</param>
        public void Save(int companyId)
        {
            ProjectCostingSheetAddTDS informationChanges = (ProjectCostingSheetAddTDS)Data.GetChanges();

            if (informationChanges.TemplateInformation.Rows.Count > 0)
            {
                ProjectCostingSheetTemplateInformationGateway projectCostingSheetTemplateInformationGateway = new ProjectCostingSheetTemplateInformationGateway(informationChanges);

                foreach (ProjectCostingSheetAddTDS.TemplateInformationRow row in (ProjectCostingSheetAddTDS.TemplateInformationDataTable)informationChanges.TemplateInformation)
                {
                    // Insert new costing sheet Template 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        int? month = null; if (!row.IsMonthNull()) month = row.Month;
                        int? day = null; if (!row.IsDayNull()) day = row.Day;
                        int? year = null; if (!row.IsYearNull()) year = row.Year;

                        int? month2 = null; if (!row.IsMonthNull()) month2 = row.Month2;
                        int? day2 = null; if (!row.IsDayNull()) day2 = row.Day2;
                        int? year2 = null; if (!row.IsYearNull()) year2 = row.Year2;
                       
                        ProjectCostingSheetTemplate projectCostingSheetTemplate = new ProjectCostingSheetTemplate(null);
                        projectCostingSheetTemplate.InsertDirect(row.Name, row.RAData, row.FLLData, row.PRData, row.JLData, row.MRData, row.MOBData, row.OtherData, row.LabourHourData, row.UnitData, row.MaterialData, row.SubcontractorData, row.MiscData, row.RevenueIncluded, row.Deleted, row.COMPANY_ID, month, day, year, month2, day2, year2);
                    }

                    // Update
                    if ((!row.Deleted) && (row.InDatabase))
                    {
                        int costingSheetTemplateId = row.CostingSheetTemplateID;
                        bool deleted = row.Deleted;

                        string originalName = projectCostingSheetTemplateInformationGateway.GetNameOriginal(costingSheetTemplateId);
                        bool originalRaData = projectCostingSheetTemplateInformationGateway.GetRADataOriginal(costingSheetTemplateId);
                        bool originalFLLData = projectCostingSheetTemplateInformationGateway.GetRAData(costingSheetTemplateId);
                        bool originalPRData = projectCostingSheetTemplateInformationGateway.GetPRDataOriginal(costingSheetTemplateId);
                        bool originalJLData = projectCostingSheetTemplateInformationGateway.GetJLDataOriginal(costingSheetTemplateId);
                        bool originalMRData = projectCostingSheetTemplateInformationGateway.GetMRDataOriginal(costingSheetTemplateId);
                        bool originalMOBData = projectCostingSheetTemplateInformationGateway.GetMOBDataOriginal(costingSheetTemplateId);
                        bool originalOtherData = projectCostingSheetTemplateInformationGateway.GetOtherDataOriginal(costingSheetTemplateId);
                        bool originalLabourHourData = projectCostingSheetTemplateInformationGateway.GetLabourHourDataOriginal(costingSheetTemplateId);
                        bool originalUnitData = projectCostingSheetTemplateInformationGateway.GetUnitDataOriginal(costingSheetTemplateId);
                        bool originalMaterialData = projectCostingSheetTemplateInformationGateway.GetMaterialDataOriginal(costingSheetTemplateId);
                        bool originalSubcontractorData = projectCostingSheetTemplateInformationGateway.GetSubcontractorDataOriginal(costingSheetTemplateId);
                        bool originalMiscData = projectCostingSheetTemplateInformationGateway.GetMiscDataOriginal(costingSheetTemplateId);
                        bool originalRevenueIncluded = projectCostingSheetTemplateInformationGateway.GetRevenueIncludedOriginal(costingSheetTemplateId);
                        int? originalMonth = null; if (projectCostingSheetTemplateInformationGateway.GetMonthOriginal(costingSheetTemplateId).HasValue) originalMonth = projectCostingSheetTemplateInformationGateway.GetMonthOriginal(costingSheetTemplateId).Value;
                        int? originalDay = null; if (projectCostingSheetTemplateInformationGateway.GetDayOriginal(costingSheetTemplateId).HasValue) originalDay = projectCostingSheetTemplateInformationGateway.GetDayOriginal(costingSheetTemplateId).Value;
                        int? originalYear = null; if (projectCostingSheetTemplateInformationGateway.GetYearOriginal(costingSheetTemplateId).HasValue) originalYear = projectCostingSheetTemplateInformationGateway.GetYearOriginal(costingSheetTemplateId).Value;

                        int? originalMonth2 = null; if (projectCostingSheetTemplateInformationGateway.GetMonth2Original(costingSheetTemplateId).HasValue) originalMonth = projectCostingSheetTemplateInformationGateway.GetMonth2Original(costingSheetTemplateId).Value;
                        int? originalDay2 = null; if (projectCostingSheetTemplateInformationGateway.GetDay2Original(costingSheetTemplateId).HasValue) originalDay = projectCostingSheetTemplateInformationGateway.GetDay2Original(costingSheetTemplateId).Value;
                        int? originalYear2 = null; if (projectCostingSheetTemplateInformationGateway.GetYear2Original(costingSheetTemplateId).HasValue) originalYear = projectCostingSheetTemplateInformationGateway.GetYear2Original(costingSheetTemplateId).Value;

                        string newName = projectCostingSheetTemplateInformationGateway.GetName(costingSheetTemplateId);
                        bool newRaData = projectCostingSheetTemplateInformationGateway.GetRAData(costingSheetTemplateId);
                        bool newFLLData = projectCostingSheetTemplateInformationGateway.GetRAData(costingSheetTemplateId);
                        bool newPRData = projectCostingSheetTemplateInformationGateway.GetPRData(costingSheetTemplateId);
                        bool newJLData = projectCostingSheetTemplateInformationGateway.GetJLData(costingSheetTemplateId);
                        bool newMRData = projectCostingSheetTemplateInformationGateway.GetMRData(costingSheetTemplateId);
                        bool newMOBData = projectCostingSheetTemplateInformationGateway.GetMOBData(costingSheetTemplateId);
                        bool newOtherData = projectCostingSheetTemplateInformationGateway.GetOtherData(costingSheetTemplateId);
                        bool newLabourHourData = projectCostingSheetTemplateInformationGateway.GetLabourHourData(costingSheetTemplateId);
                        bool newUnitData = projectCostingSheetTemplateInformationGateway.GetUnitData(costingSheetTemplateId);
                        bool newMaterialData = projectCostingSheetTemplateInformationGateway.GetMaterialData(costingSheetTemplateId);
                        bool newSubcontractorData = projectCostingSheetTemplateInformationGateway.GetSubcontractorData(costingSheetTemplateId);
                        bool newMiscData = projectCostingSheetTemplateInformationGateway.GetMiscData(costingSheetTemplateId);
                        bool newRevenueIncluded = projectCostingSheetTemplateInformationGateway.GetRevenueIncluded(costingSheetTemplateId);
                        int? newMonth = null; if (projectCostingSheetTemplateInformationGateway.GetMonth(costingSheetTemplateId).HasValue) newMonth = projectCostingSheetTemplateInformationGateway.GetMonth(costingSheetTemplateId).Value;
                        int? newDay = null; if (projectCostingSheetTemplateInformationGateway.GetDay(costingSheetTemplateId).HasValue) newDay = projectCostingSheetTemplateInformationGateway.GetDay(costingSheetTemplateId).Value;
                        int? newYear = null; if (projectCostingSheetTemplateInformationGateway.GetYear(costingSheetTemplateId).HasValue) newYear = projectCostingSheetTemplateInformationGateway.GetYear(costingSheetTemplateId).Value;
                        int? newMonth2 = null; if (projectCostingSheetTemplateInformationGateway.GetMonth2(costingSheetTemplateId).HasValue) newMonth2 = projectCostingSheetTemplateInformationGateway.GetMonth2(costingSheetTemplateId).Value;
                        int? newDay2 = null; if (projectCostingSheetTemplateInformationGateway.GetDay2(costingSheetTemplateId).HasValue) newDay2 = projectCostingSheetTemplateInformationGateway.GetDay2(costingSheetTemplateId).Value;
                        int? newYear2 = null; if (projectCostingSheetTemplateInformationGateway.GetYear2(costingSheetTemplateId).HasValue) newYear2 = projectCostingSheetTemplateInformationGateway.GetYear2(costingSheetTemplateId).Value;
                                               
                        ProjectCostingSheetTemplate projectCostingSheetTemplate = new ProjectCostingSheetTemplate(null);
                        projectCostingSheetTemplate.UpdateDirect(costingSheetTemplateId, originalName, originalRaData, originalFLLData, originalPRData, originalJLData, originalMRData, originalMOBData, originalOtherData, originalLabourHourData, originalUnitData, originalMaterialData, originalSubcontractorData, originalMiscData, originalRevenueIncluded, deleted, companyId, originalMonth, originalDay, originalYear, originalMonth2, originalDay2, originalYear2, newName, newRaData, newFLLData, newPRData, newJLData, newMRData, newMOBData, newOtherData, newLabourHourData, newUnitData, newMaterialData, newSubcontractorData, newMiscData, newRevenueIncluded, deleted, companyId, newMonth, newDay, newYear, newMonth2, newDay2, newYear2);
                    }

                    // Delete
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        ProjectCostingSheetTemplate projectCostingSheetTemplate = new ProjectCostingSheetTemplate(null);
                        projectCostingSheetTemplate.DeleteDirect(0, 0);
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
        /// <param name="costingSheetId">costingSheetId</param>
        /// <param name="refIdTemplate">refIdTemplate</param>
        /// <returns>row</returns>
        private ProjectCostingSheetAddTDS.TemplateInformationRow GetRow(int costingSheetTemplateId)
        {
            ProjectCostingSheetAddTDS.TemplateInformationRow row = ((ProjectCostingSheetAddTDS.TemplateInformationDataTable)Table).FindByCostingSheetTemplateID(costingSheetTemplateId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetTemplateInformation.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetNewCostingSheetTemplateId
        /// </summary>
        /// <returns>newCostingSheetTemplateId</returns>
        private int GetNewCostingSheetTemplateId()
        {
            int newCostingSheetTemplateId = 0;

            foreach (ProjectCostingSheetAddTDS.TemplateInformationRow row in (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Table)
            {
                if (newCostingSheetTemplateId < row.CostingSheetTemplateID)
                {
                    newCostingSheetTemplateId = row.CostingSheetTemplateID;
                }
            }

            newCostingSheetTemplateId++;

            return newCostingSheetTemplateId;
        }


        
    }
}