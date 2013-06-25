using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    public class PrintManHoursPerPhaseRAPreFlush : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhaseRAPreFlush()
            : base("PrintManHoursPerPhaseRAPreFlush")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhaseRAPreFlush(DataSet data)
            : base(data, "PrintManHoursPerPhaseRAPreFlush")
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
            PrintManHoursPerPhaseRAPreFlushGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAPreFlushGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// LoadByStartDateEndDateProjectTimeStateWorkFunction
        /// </summary>
        /// <para>Load Original to process data for Project Costing report with filters  </para>
        /// <param name="startDate">Start date filter for Project Costing report</param>
        /// <param name="endDate">End date filter for Project Costing report</param>
        /// <param name="projectTimeState">State filter for Project Costing report</param>
        /// <param name="work">work</param>
        public void LoadAllByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseRAPreFlushGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAPreFlushGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, "Pre-Flush", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

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
            PrintManHoursPerPhaseRAPreFlushGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAPreFlushGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);
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
        public void LoadAllByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string confirmedSize1, string confirmedSize2, string accessType)
        {
            PrintManHoursPerPhaseRAPreFlushGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAPreFlushGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, "Pre-Flush", confirmedSize1, confirmedSize2, accessType);
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
            PrintManHoursPerPhaseRAPreFlushGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAPreFlushGateway(Data);
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
            PrintManHoursPerPhaseRAPreFlushGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseRAPreFlushGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Pre-Flush", confirmedSize1, confirmedSize2, accessType);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        public void ProcessDataForProject(int companyId)
        {
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int numPeriods = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRAPreFlushRow rowOriginal in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRAPreFlushDataTable)Table)
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

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRAPreFlushRow row3 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseRAPreFlushDataTable)Table)
            {
                row3.AverageRate = rateAcum / numPeriods;
                row3.NumPeriods = numPeriods;
            }
        }



    }
}