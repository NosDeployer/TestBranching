using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using System.Collections;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintManhoursPerPhaseGeneral
    /// </summary>
    public class PrintManhoursPerPhaseGeneral : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////     
        // CONSTRUCTORS
        //
        
        /// <summary>
        /// Default constructor
        /// </summary>
        public PrintManhoursPerPhaseGeneral()
            : base("PrintManhoursPerPhaseGeneral")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public PrintManhoursPerPhaseGeneral(DataSet data)
            : base(data, "PrintManhoursPerPhaseGeneral")
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
        /// Load
        /// </summary>
        public void Load(int companyId, DateTime startDate, DateTime endDate, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseGeneralGateway printManHoursPerPhaseGeneralGateway = new PrintManHoursPerPhaseGeneralGateway(Data);
            printManHoursPerPhaseGeneralGateway.Load(companyId, startDate, endDate);

            UpdateForReport(startDate, endDate, projectTimeState, companyId, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
        }



        /// <summary>
        /// LoadByCountryId
        /// </summary>
        public void LoadByCountryId(int companyId, int countryId, DateTime startDate, DateTime endDate, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseGeneralGateway printManHoursPerPhaseGeneralGateway = new PrintManHoursPerPhaseGeneralGateway(Data);
            printManHoursPerPhaseGeneralGateway.LoadByCountryId(companyId, countryId, startDate, endDate);

            UpdateForReport(startDate, endDate, projectTimeState, companyId, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
        }



        /// <summary>
        /// LoadByClientId
        /// </summary>
        public void LoadByClientId(int companyId, int clientId, DateTime startDate, DateTime endDate, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseGeneralGateway printManHoursPerPhaseGeneralGateway = new PrintManHoursPerPhaseGeneralGateway(Data);
            printManHoursPerPhaseGeneralGateway.LoadByClientId(companyId, clientId, startDate, endDate);

            UpdateForReport(startDate, endDate, projectTimeState, companyId, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
        }



        /// <summary>
        /// LoadByProjectId
        /// </summary>
        public void LoadByProjectId(int companyId, int projectId, DateTime startDate, DateTime endDate, string projectTimeState, string confirmedSize1, string confirmedSize2, string accessType, string shape, int conditionRating, string location, string material, string crew)
        {
            PrintManHoursPerPhaseGeneralGateway printManHoursPerPhaseGeneralGateway = new PrintManHoursPerPhaseGeneralGateway(Data);
            printManHoursPerPhaseGeneralGateway.LoadByProjectId(companyId, projectId, startDate, endDate);

            UpdateForReport(startDate, endDate, projectTimeState, companyId, confirmedSize1, confirmedSize2, accessType, shape, conditionRating, location, material, crew);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// UpdateForReport
        /// </summary>
        private void UpdateForReport(DateTime startDate, DateTime endDate, string projectTimeState, int companyId, string confirmedSize1, string confirmedSize2, string accessType, string shape, int conditionRating, string location, string material, string crew)
        {
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhase printManhoursPerPhaseJL = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhase(Data);
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseRA printManhoursPerPhaseRA = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseRA(Data);
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhaseFLL printManhoursPerPhaseFLL = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManhoursPerPhaseFLL(Data);
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseMH printManhoursPerPhaseMH = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhaseMH(Data);
            LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhasePL printManhoursPerPhasePL = new LiquiForce.LFSLive.BL.LabourHours.ProjectTime.PrintManHoursPerPhasePL(Data);

            foreach (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseGeneralRow row in (PrintManhoursPerPhaseTDS.PrintManHoursPerPhaseGeneralDataTable)Table)
            {
                int clientId = row.ClientID;
                int projectId = row.ProjectID;
                int countryId = row.CountryID;

                printManhoursPerPhaseJL.LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(clientId, projectId, startDate, endDate, projectTimeState, "Junction Lining", "");
                printManhoursPerPhaseRA.LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(clientId, projectId, startDate, endDate, projectTimeState, "Rehab Assessment", "", companyId, confirmedSize1, confirmedSize2, accessType);
                printManhoursPerPhaseFLL.LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(clientId, projectId, startDate, endDate, projectTimeState, "Full Length", "", companyId, confirmedSize1, confirmedSize2, accessType);
                printManhoursPerPhaseMH.LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(clientId, projectId, startDate, endDate, projectTimeState, "MH Rehab", "", companyId, shape, conditionRating, location, material, crew);
                printManhoursPerPhasePL.LoadAllByCompaniesIdProjectIdStartDateEndDateProjectTimeStateWorkFunction(clientId, projectId, startDate, endDate, projectTimeState, "Point Lining", "", companyId, confirmedSize1, confirmedSize2, accessType);
            }
        }



    }
}