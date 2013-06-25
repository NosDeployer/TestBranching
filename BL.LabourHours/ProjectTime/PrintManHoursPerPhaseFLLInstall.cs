using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using System.Collections;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManhoursPerPhaseFLL
    /// </summary>
    public class PrintManHoursPerPhaseFLLInstall : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhaseFLLInstall()
            : base("PrintManHoursPerPhaseFLLInstall")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhaseFLLInstall(DataSet data)
            : base(data, "PrintManHoursPerPhaseFLLInstall")
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
            PrintManHoursPerPhaseFLLInstallGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLInstallGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadAllByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        public void LoadAllByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseFLLInstallGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLInstallGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, "Install", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

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
            PrintManHoursPerPhaseFLLInstallGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLInstallGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);

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
        public void LoadAllByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseFLLInstallGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLInstallGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, "Install", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

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
            PrintManHoursPerPhaseFLLInstallGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLInstallGateway(Data);
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
            PrintManHoursPerPhaseFLLInstallGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseFLLInstallGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Install", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        public void ProcessDataForProject(int companyId)
        {
            ArrayList al = new ArrayList();
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int lateralsAcum = 0;
            double totalHrsAcum = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLInstallRow row1 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLInstallDataTable)Table)
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

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLInstallRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLInstallDataTable)Table)
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

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLInstallRow row3 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseFLLInstallDataTable)Table)
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