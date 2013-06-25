using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime 
{
    /// <summary>
    /// PrintManhoursPerPhase
    /// </summary>
    public class PrintManhoursPerPhase : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManhoursPerPhase()
            : base("PrintManhoursPerPhase")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManhoursPerPhase(DataSet data)
            : base(data, "PrintManhoursPerPhase")
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
        /// <param name="function">function</param>
        public void LoadByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function)
        {
            PrintManhoursPerPhaseGateway printManhoursPerPhaseGateway = new PrintManhoursPerPhaseGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function);

            ProcessData(function);
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
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function)
        {
            PrintManhoursPerPhaseGateway printManhoursPerPhaseGateway = new PrintManhoursPerPhaseGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function);

            ProcessData(function);
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
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function)
        {
            PrintManhoursPerPhaseGateway printManhoursPerPhaseGateway = new PrintManhoursPerPhaseGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, function);

            ProcessData(function);
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
        public void LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function)
        {
            PrintManhoursPerPhaseGateway printManhoursPerPhaseGateway = new PrintManhoursPerPhaseGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Install");
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Prep from Main");
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessData(projectId, "Install");
            ProcessData(projectId, "Prep from Main");
        }



        /// <summary>
        /// ProcessData
        /// </summary>
        /// <para>Process de data from the original table for the Man Hours Per Phase report </para>  
        private void ProcessData(string function)
        {
            foreach (PrintManhoursPerPhaseTDS.PrintManhoursPerPhaseRow row in (PrintManhoursPerPhaseTDS.PrintManhoursPerPhaseDataTable)Table)
            {
                switch (row.Day)
                {
                    case "Monday": 
                        row.Day = "M";
                        break;

                    case "Tuesday":
                        row.Day = "T";
                        break;

                    case "Wednesday":
                        row.Day = "W";
                        break;

                    case "Thursday":
                        row.Day = "R";
                        break;

                    case "Friday":
                        row.Day = "F";
                        break;

                    default:
                        break;                                
                }

                if (function == "Scoping")
                {
                    if (!row.IsVideoDistanceNull())
                    {
                        row.VideoDistance = Convert.ToDecimal( Convert.ToDouble(row.VideoDistance) * 0.3048);
                    }
                    else
                    {
                        row.VideoDistance = 0;
                    }
                }
            }
        }



        /// <summary>
        /// ProcessData
        /// </summary>
        /// <para>Process de data from the original table for the Man Hours Per Phase report </para>  
        private void ProcessData(int currentProjectId, string currentPhase)
        {
            string projectName = "";
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            projectName = projectGateway.GetName(currentProjectId);

            foreach (PrintManhoursPerPhaseTDS.PrintManhoursPerPhaseRow row in (PrintManhoursPerPhaseTDS.PrintManhoursPerPhaseDataTable)Table)
            {
                if (row.ProjectName.Contains(projectName) && row.Phase.Contains(currentPhase))
                {
                    switch (row.Day)
                    {
                        case "Monday":
                            row.Day = "M";
                            break;

                        case "Tuesday":
                            row.Day = "T";
                            break;

                        case "Wednesday":
                            row.Day = "W";
                            break;

                        case "Thursday":
                            row.Day = "R";
                            break;

                        case "Friday":
                            row.Day = "F";
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        
               
    }
}