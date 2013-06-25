﻿using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using System.Collections;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManhoursPerPhaseFLL
    /// </summary>
    public class PrintManhoursPerPhaseFLL : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManhoursPerPhaseFLL()
            : base("PrintManHoursPerPhaseFLL")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManhoursPerPhaseFLL(DataSet data)
            : base(data, "PrintManHoursPerPhaseFLL")
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
            PrintManHoursPerPhaseFLLGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para>
        /// <param name="companiesId">Company filter (client) for project Costing report</param>/// 
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseFLLGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLGateway(Data);
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
            PrintManHoursPerPhaseFLLGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);

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
        public void LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseFLLGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Install", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Prep & Measure", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Reinstate & Post Video", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessDataForProject(projectId, "Install", companyId);
            ProcessDataForProject(projectId, "Prep & Measure", companyId);
            ProcessDataForProject(projectId, "Reinstate & Post Video", companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int companyId)
        {
            ArrayList al = new ArrayList();
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int lateralsAcum = 0;
            double totalHrsAcum = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLRow row1 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLDataTable)Table)
            {
                if (row1.Phase.Contains("Prep") || row1.Phase.Contains("Reinstate"))
                {
                    if (!row1.Completed)
                    {
                        if (!al.Contains(row1.SectionID))
                        {
                            al.Add(row1.SectionID);
                        }
                    }
                }

                if (!row1.IsTotalFtNull())
                {                    
                    Distance distOriginal = new Distance(row1.TotalFt);
                    row1.TotalFtDouble = distOriginal.ToDoubleInEng3();
                }
                else
                {
                    row1.TotalFtDouble = 0;
                }

                if (!alDays.Contains(row1.Date))
                {
                    alDays.Add(row1.Date);
                    totalHrsAcum = totalHrsAcum + row1.Hrs;
                }
            }            

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLDataTable)Table)
            {               
                if (row2.Phase.Contains("Prep"))
                {
                    if (!row2.IsTotalFtNull())
                    {
                        Distance dist = new Distance(row2.TotalFt);
                        double distD = dist.ToDoubleInEng3();

                        if (!row2.Completed)
                        {
                            row2.RealFt = distD / 2;
                        }
                        else
                        {
                            if (al.Contains(row2.SectionID))
                            {
                                row2.RealFt = distD / 2;
                            }
                            else
                            {
                                row2.RealFt = dist.ToDoubleInEng3();
                            }
                        }
                    }
                    else
                    {
                        row2.RealFt = 0;
                    }

                    rateAcum = rateAcum + row2.RealFt / row2.Hrs;
                }

                if (row2.Phase.Contains("Reinstate"))
                {
                    if (!row2.IsLiveLateralsNull())
                    {
                        if (!row2.Completed)
                        {
                            row2.RealLiveLaterals = row2.LiveLaterals / 2;
                        }
                        else
                        {
                            if (al.Contains(row2.SectionID))
                            {
                                row2.RealLiveLaterals = row2.LiveLaterals / 2;
                            }
                            else
                            {
                                row2.RealLiveLaterals = row2.LiveLaterals;
                            }
                        }
                    }
                    else
                    {
                        row2.RealLiveLaterals = 0;
                    }

                    lateralsAcum = lateralsAcum + row2.RealLiveLaterals;
                    rateAcum = rateAcum + (row2.Hrs / row2.RealLiveLaterals);
                    row2.TotalHrs = totalHrsAcum;
                }

                if (row2.Phase.Contains("Install"))
                {
                    if (!row2.IsTotalFtNull())
                    {
                        Distance dist = new Distance(row2.TotalFt);
                        row2.RealFt = dist.ToDoubleInEng3();
                    }
                    else
                    {
                        row2.RealFt = 0;
                    }

                    rateAcum = rateAcum + row2.RealFt / row2.Hrs;
                }

                row2.NumPeriods = alDays.Count;                
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLRow row3 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLDataTable)Table)
            {
                if (row3.Phase.Contains("Reinstate"))
                {
                    row3.AverageRate = totalHrsAcum / lateralsAcum;
                }
                else
                {
                    row3.AverageRate = rateAcum / alDays.Count;
                }
            }
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int currentProjectId, string currentPhase, int companyId)
        {
            ArrayList al = new ArrayList();
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int lateralsAcum = 0;
            double totalHrsAcum = 0;

            string projectName = "";
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            projectName = projectGateway.GetName(currentProjectId);

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLRow row1 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLDataTable)Table)
            {
                if (row1.ProjectName.Contains(projectName) && row1.Phase.Contains(currentPhase))
                {
                    if (row1.Phase.Contains("Prep") || row1.Phase.Contains("Reinstate"))
                    {
                        if (!row1.Completed)
                        {
                            if (!al.Contains(row1.SectionID))
                            {
                                al.Add(row1.SectionID);
                            }
                        }
                    }

                    if (!row1.IsTotalFtNull())
                    {
                        Distance distOriginal = new Distance(row1.TotalFt);
                        row1.TotalFtDouble = distOriginal.ToDoubleInEng3();
                    }
                    else
                    {
                        row1.TotalFtDouble = 0;
                    }

                    if (!alDays.Contains(row1.Date))
                    {
                        alDays.Add(row1.Date);
                        totalHrsAcum = totalHrsAcum + row1.Hrs;
                    }
                }
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLDataTable)Table)
            {
                if (row2.ProjectName.Contains(projectName) && row2.Phase.Contains(currentPhase))
                {
                    if (row2.Phase.Contains("Prep"))
                    {
                        if (!row2.IsTotalFtNull())
                        {
                            Distance dist = new Distance(row2.TotalFt);
                            double distD = dist.ToDoubleInEng3();

                            if (!row2.Completed)
                            {
                                row2.RealFt = distD / 2;
                            }
                            else
                            {
                                if (al.Contains(row2.SectionID))
                                {
                                    row2.RealFt = distD / 2;
                                }
                                else
                                {
                                    row2.RealFt = dist.ToDoubleInEng3();
                                }
                            }
                        }
                        else
                        {
                            row2.RealFt = 0;
                        }

                        rateAcum = rateAcum + row2.RealFt / row2.Hrs;
                    }

                    if (row2.Phase.Contains("Reinstate"))
                    {
                        if (!row2.IsLiveLateralsNull())
                        {
                            if (!row2.Completed)
                            {
                                row2.RealLiveLaterals = row2.LiveLaterals / 2;
                            }
                            else
                            {
                                if (al.Contains(row2.SectionID))
                                {
                                    row2.RealLiveLaterals = row2.LiveLaterals / 2;
                                }
                                else
                                {
                                    row2.RealLiveLaterals = row2.LiveLaterals;
                                }
                            }
                        }
                        else
                        {
                            row2.RealLiveLaterals = 0;
                        }

                        lateralsAcum = lateralsAcum + row2.RealLiveLaterals;
                        rateAcum = rateAcum + (row2.Hrs / row2.RealLiveLaterals);
                        row2.TotalHrs = totalHrsAcum;
                    }

                    if (row2.Phase.Contains("Install"))
                    {
                        if (!row2.IsTotalFtNull())
                        {
                            Distance dist = new Distance(row2.TotalFt);
                            row2.RealFt = dist.ToDoubleInEng3();
                        }
                        else
                        {
                            row2.RealFt = 0;
                        }

                        rateAcum = rateAcum + row2.RealFt / row2.Hrs;
                    }

                    row2.NumPeriods = alDays.Count;
                }
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLRow row3 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLDataTable)Table)
            {
                if (row3.ProjectName.Contains(projectName) && row3.Phase.Contains(currentPhase))
                {
                    if (row3.Phase.Contains("Reinstate"))
                    {
                        row3.AverageRate = totalHrsAcum / lateralsAcum;
                    }
                    else
                    {
                        row3.AverageRate = rateAcum / alDays.Count;
                    }
                }
            }
        }

        
               
    }
}