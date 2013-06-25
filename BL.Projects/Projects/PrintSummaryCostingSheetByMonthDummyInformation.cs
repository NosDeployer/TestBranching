using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Projects.Projects;
using System.Collections;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    public class PrintSummaryCostingSheetByMonthDummyInformation : TableModule
    {
// ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintSummaryCostingSheetByMonthDummyInformation()
            : base("DummyInformation")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintSummaryCostingSheetByMonthDummyInformation(DataSet data)
            : base(data, "DummyInformation")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectCostingSheetAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS 
        //

        public int LoadAll(DateTime startDate, DateTime endDate, int companyId, string month)
        {
            int rows = 0;

            PrintSummaryCostingSheetByMonthDummyInformationGateway printSummaryCostingSheetByMonthDummyInformationGateway = new PrintSummaryCostingSheetByMonthDummyInformationGateway(Data);
            printSummaryCostingSheetByMonthDummyInformationGateway.LoadProjectsWithTimesheets(startDate, endDate);

            // Load
            ProjectCostingSheetAddLabourHoursInformationGateway projectCostingSheetAddLabourHoursInformationGateway = new ProjectCostingSheetAddLabourHoursInformationGateway(Data);
            projectCostingSheetAddLabourHoursInformationGateway.ClearBeforeFill = false;
            ProjectCostingSheetAddLabourHoursInformation model = new ProjectCostingSheetAddLabourHoursInformation(Data);

            foreach (ProjectCostingSheetAddTDS.DummyInformationRow projectListRow in (ProjectCostingSheetAddTDS.DummyInformationDataTable)printSummaryCostingSheetByMonthDummyInformationGateway.Table)
            {
                int projectId = projectListRow.ProjectID;

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                ArrayList works = new ArrayList();
                works.Add("Rehab Assessment");
                works.Add("Full Length");
                works.Add("Point Lining"); works.Add("Grouting");
                works.Add("Junction Lining");
                works.Add("MH Rehab");
                works.Add("Mobilization");
                works.Add("Other");
                works.Add("Downtime");
                works.Add("Office");
                works.Add("Office / Shop");
                works.Add("R & D");
                works.Add("Special Projects");
                works.Add("Subcontractor");
                works.Add("Watermain Relining");
                works.Add("SOTA");

                if (!projectGateway.GetFairWageApplies(projectId))
                {
                    model.Load(works, projectId, startDate, endDate, companyId, month);
                }
                else
                {
                    ArrayList jobClassType = new ArrayList();
                    jobClassType.Add("Laborer Group 2");
                    jobClassType.Add("Laborer Group 6");
                    jobClassType.Add("Operator Group 1");
                    jobClassType.Add("Operator Group 2");
                    jobClassType.Add("Regular Rate");

                    model.LoadFairWageProject(works, jobClassType, projectId, startDate, endDate, companyId, month);
                }

                decimal totalCostLH = StepLabourHoursInformationProcessGrid();

                ProjectCostingSheetAddBasicInformation projectCostingSheetAddBasicInformation = new ProjectCostingSheetAddBasicInformation(Data);
                projectCostingSheetAddBasicInformation.Insert2(projectId, projectId, "", startDate, endDate, totalCostLH, totalCostLH, 0, 0, 0, 0, 0, 0, 0, 0, "", false, companyId, 0, 0, 0, 0, 0, 0, 0, 0, 0, month);

                rows = rows + projectCostingSheetAddLabourHoursInformationGateway.Table.Rows.Count;
            }

            projectCostingSheetAddLabourHoursInformationGateway.ClearBeforeFill = true;

            return rows;
        }



        private decimal StepLabourHoursInformationProcessGrid()
        {
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.LabourHoursInformationRow row in (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Data.Tables["LabourHoursInformation"])
            {
                if (!row.Deleted)
                {
                    if (row.TotalCostUsd > 0)
                    {
                        totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                    }
                    else
                    {
                        totalCostUsdLH = totalCostUsdLH + row.TotalCostCad;
                    }
                }
            }

            return totalCostUsdLH;
        }

        
        
    }
}