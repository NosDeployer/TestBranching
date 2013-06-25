using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using System.Collections;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManHoursPerPhaseMH
    /// </summary>
    public class PrintManHoursPerPhaseMH : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhaseMH()
            : base("PrintManhoursPerPhaseMH")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhaseMH(DataSet data)
            : base(data, "PrintManhoursPerPhaseMH")
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
        public void LoadByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function, shape, conditionRating, location, material, crew);

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
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function, shape, conditionRating, location, material, crew);

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
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, function, shape, conditionRating, location, material, crew);

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
        public void LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Prep", shape, conditionRating, location, material, crew);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Spray", shape, conditionRating, location, material, crew);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessDataForProject(projectId, "Prep", companyId);
            ProcessDataForProject(projectId, "Spray", companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int companyId)
        {
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHRow row in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHDataTable)Table)
            {
                if (!row.IsTotalFtNull())
                {
                    Distance dist = new Distance(row.TotalFt);
                    row.RealFt = dist.ToDoubleInEng3();
                    row.TotalFtDouble = dist.ToDoubleInEng3();
                }
                else
                {
                    row.RealFt = 0;
                    row.TotalFtDouble = 0;
                }

                if (!alDays.Contains(row.Date))
                {
                    alDays.Add(row.Date);
                }

                rateAcum = rateAcum + row.RealFt / row.Hrs;
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHDataTable)Table)
            {
                row2.NumPeriods = alDays.Count;
                row2.AverageRate = rateAcum / alDays.Count;
            }
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int currentProjectId, string currentPhase, int companyId)
        {
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;

            string projectName = "";
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            projectName = projectGateway.GetName(currentProjectId);

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHRow row in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHDataTable)Table)
            {
                if (row.ProjectName.Contains(projectName) && row.Phase.Contains(currentPhase))
                {
                    if (!row.IsTotalFtNull())
                    {
                        Distance dist = new Distance(row.TotalFt);
                        row.RealFt = dist.ToDoubleInEng3();
                        row.TotalFtDouble = dist.ToDoubleInEng3();
                    }
                    else
                    {
                        row.RealFt = 0;
                        row.TotalFtDouble = 0;
                    }

                    if (!alDays.Contains(row.Date))
                    {
                        alDays.Add(row.Date);
                    }

                    rateAcum = rateAcum + row.RealFt / row.Hrs;
                }
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHDataTable)Table)
            {
                if (row2.ProjectName.Contains(projectName) && row2.Phase.Contains(currentPhase))
                {
                    row2.NumPeriods = alDays.Count;
                    row2.AverageRate = rateAcum / alDays.Count;
                }
            }
        }

        
               
    }
}