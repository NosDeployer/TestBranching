using System;
using System.Collections;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Works;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManHoursPerPhasePLPrep
    /// </summary>
    public class PrintManHoursPerPhasePLPrep : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManHoursPerPhasePLPrep()
            : base("PrintManHoursPerPhasePLPrep")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManHoursPerPhasePLPrep(DataSet data)
            : base(data, "PrintManHoursPerPhasePLPrep")
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
            PrintManHoursPerPhasePLPrepGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhasePLPrepGateway(Data);
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
            PrintManHoursPerPhasePLPrepGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhasePLPrepGateway(Data);
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
            PrintManHoursPerPhasePLPrepGateway printManhoursPerPhaseGateway = new PrintManHoursPerPhasePLPrepGateway(Data);
            printManhoursPerPhaseGateway.LoadByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(companiesId, projectId, startDate, endDate, projectTimeState, work, function, confirmedSize1, confirmedSize2, accessType);

            ProcessDataForProject(companyId);
        }



        /// <summary>
        /// ProcessDataForProject
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <para>Process de data from the original table for the Project Costing report </para>  
        private void ProcessDataForProject(int companyId)
        {
            ArrayList al = new ArrayList();
            ArrayList alDays = new ArrayList();
            double rateAcum = 0;
            int linersAcum = 0;
            double totalHrsAcum = 0;

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhasePLPrepRow row1 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhasePLPrepDataTable)Table)
            {
                if (row1.Phase.Contains("Prep"))
                {
                    int workIdFll = GetWorkId(row1.ProjectID, row1.AssetID, "Full Length Lining", companyId);

                    FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
                    fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workIdFll, row1.AssetID, companyId);

                    if (fullLengthLiningWorkDetailsGateway.Table.Rows.Count > 0)
                    {
                        string totalFt = fullLengthLiningWorkDetailsGateway.GetVideoLength(workIdFll);
                        if (totalFt != "")
                        {
                            Distance distOriginal = new Distance(totalFt);
                            row1.TotalFtDouble = distOriginal.ToDoubleInEng3();
                            row1.RealFt = distOriginal.ToDoubleInEng3();
                        }
                        else
                        {
                            row1.TotalFtDouble = 0;
                            row1.RealFt = 0;
                        }
                    }
                    else
                    {
                        row1.TotalFtDouble = 0;
                        row1.RealFt = 0;
                    }
                }

                if (!alDays.Contains(row1.Date))
                {
                    alDays.Add(row1.Date);
                    totalHrsAcum = totalHrsAcum + row1.Hrs;
                }
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhasePLPrepRow row2 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhasePLPrepDataTable)Table)
            {
                if (row2.Phase.Contains("Prep"))
                {
                    rateAcum = rateAcum + row2.RealFt / row2.Hrs;
                }
                else
                {
                    if (row2.Phase.Contains("Install"))
                    {
                        linersAcum = linersAcum + row2.LinersInstalled;
                        rateAcum = rateAcum + (row2.Hrs / row2.LinersInstalled);
                        //row2.TotalHrs = totalHrsAcum;
                    }
                    else
                    {
                        linersAcum = linersAcum + row2.LinersReinstated;
                        rateAcum = rateAcum + (row2.Hrs / row2.LinersReinstated);
                        //row2.TotalHrs = totalHrsAcum;
                    }
                }

                row2.NumPeriods = alDays.Count;
            }

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhasePLPrepRow row3 in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhasePLPrepDataTable)Table)
            {
                if (row3.Phase.Contains("Prep"))
                {
                    row3.AverageRate = rateAcum / alDays.Count;
                }
                else
                {
                    row3.AverageRate = totalHrsAcum / linersAcum;
                }
            }
        }



        /// <summary>
        /// GetWorkId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns>workId</returns>
        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



    }
}