using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using System.Collections;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManHoursPerPhaseMHSpray
    /// </summary>
    public class PrintManHoursPerPhaseMHSpray : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhaseMHSpray()
            : base("PrintManHoursPerPhaseMHSpray")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhaseMHSpray(DataSet data)
            : base(data, "PrintManHoursPerPhaseMHSpray")
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
            PrintManHoursPerPhaseMHSprayGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHSprayGateway(Data);
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, function, shape, conditionRating, location, material, crew);

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
        public void LoadAllByStartDateEndDateProjectTimeStateWorkFunction(int? countryId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHSprayGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHSprayGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByStartDateEndDateProjectTimeStateWorkFunction(countryId, startDate, endDate, projectTimeState, work, "Spray", shape, conditionRating, location, material, crew);
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
        public void LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHSprayGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHSprayGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, function, shape, conditionRating, location, material, crew);

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
        public void LoadAllByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHSprayGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHSprayGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, startDate, endDate, projectTimeState, work, "Spray", shape, conditionRating, location, material, crew);
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
        public void LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(int companiesId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string work, string function, int companyId, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseMHSprayGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHSprayGateway(Data);
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
            PrintManHoursPerPhaseMHSprayGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhaseMHSprayGateway(Data);
            printManhoursPerPhaseGateway.ClearBeforeFill = false;
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, "Spray", shape, conditionRating, location, material, crew);
            printManhoursPerPhaseGateway.ClearBeforeFill = true;

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        public void ProcessDataForProject(int companyId)
        {
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHSprayRow row in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHSprayDataTable)Table)
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

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHSprayRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseMHSprayDataTable)Table)
            {
                row2.NumPeriods = alDays.Count;
                row2.AverageRate = rateAcum / alDays.Count;
            }
        }



    }
}