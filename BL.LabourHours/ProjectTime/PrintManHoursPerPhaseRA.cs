using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    public class PrintManHoursPerPhaseRA : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhaseRA()
            : base("PrintManHoursPerPhaseRA")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhaseRA(DataSet data)
            : base(data, "PrintManHoursPerPhaseRA")
        {
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintManhoursPerPhaseTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS 
        //

        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        public void LoadByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseRAGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);
            
            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseRAGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);
            ProcessDataForProject(companyId);
        }        



        /// <summary>
        /// LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing reports</param>
        /// <param name="startDate">Start date filter Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseRAGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);
            
            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para> 
        /// <param name="companiesId">Company filter (client) for Project Costing report</param>
        /// <param name="projectId">Project filter for Project Costing reports</param>
        /// <param name="startDate">Start date filter Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        public void LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseRAGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Flush Video and Reaming", confirmedSize1, confirmedSize2, accessType);
            //printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Pre-Video", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessDataForProject(projectId, "Flush Video and Reaming", companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int companyId)
        {
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int numPeriods = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRARow rowOriginal in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRADataTable)Table)
            {
                if (!rowOriginal.IsTotalFtNull())
                {
                    Distance distOriginal = new Distance(rowOriginal.TotalFt);
                    rowOriginal.TotalFtDouble = distOriginal.ToDoubleInEng3();
                    rowOriginal.RealFt = distOriginal.ToDoubleInEng3();
                }
                else
                {
                    rowOriginal.TotalFtDouble = 0;
                    rowOriginal.RealFt = 0;
                }

                rateAcum = rateAcum + rowOriginal.RealFt / rowOriginal.Hrs;

                // For get number of periods
                if (!alDays.Contains(rowOriginal.Date))
                {
                    alDays.Add(rowOriginal.Date);
                    numPeriods = numPeriods + 1;
                }               
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRARow row3 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRADataTable)Table)
            {
                row3.AverageRate = rateAcum / numPeriods;
                row3.NumPeriods = numPeriods;
            }
        }




        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int currentProjectId, string currentPhase, int companyId)
        {
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int numPeriods = 0;

            string projectName = "";
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            projectName = projectGateway.GetName(currentProjectId);

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRARow rowOriginal in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRADataTable)Table)
            {
                if (rowOriginal.ProjectName.Contains(projectName) && rowOriginal.Phase.Contains(currentPhase))
                {
                    if (!rowOriginal.IsTotalFtNull())
                    {
                        Distance distOriginal = new Distance(rowOriginal.TotalFt);
                        rowOriginal.TotalFtDouble = distOriginal.ToDoubleInEng3();
                        rowOriginal.RealFt = distOriginal.ToDoubleInEng3();
                    }
                    else
                    {
                        rowOriginal.TotalFtDouble = 0;
                        rowOriginal.RealFt = 0;
                    }

                    rateAcum = rateAcum + rowOriginal.RealFt / rowOriginal.Hrs;

                    // For get number of periods
                    if (!alDays.Contains(rowOriginal.Date))
                    {
                        alDays.Add(rowOriginal.Date);
                        numPeriods = numPeriods + 1;
                    }
                }
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRARow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRADataTable)Table)
            {
                if (row2.ProjectName.Contains(projectName) && row2.Phase.Contains(currentPhase))
                {
                    row2.AverageRate = rateAcum / numPeriods;
                    row2.NumPeriods = numPeriods;
                }
            }
        }

        
               
    }
}