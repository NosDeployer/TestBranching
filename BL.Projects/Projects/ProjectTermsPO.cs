using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectTermsPO
    /// </summary>
    public class ProjectTermsPO  : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTermsPO() : base("LFS_PROJECT_TERMS")
        {
        }

       

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTermsPO(DataSet data)
            : base(data, "LFS_PROJECT_TERMS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert 
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="liquidateDamage">LiquidateDamage</param>
        /// <param name="liquidatedRate">LiquidatedRate</param>
        /// <param name="liquidatedUnit">LiquidatedUnit</param>
        /// <param name="clientWorkedBefore">ClientWorkedBefore</param>
        /// <param name="clientQuirks">ClientQuirks</param>
        /// <param name="clientPromises">ClientPromises</param>
        /// <param name="waterObtain">WaterObtain</param>
        /// <param name="materialDispose">MaterialDispose</param>
        /// <param name="requireRPZ">RequireRPZ</param>
        /// <param name="standardHydrantFitting">StandardHydrantFitting</param>
        /// <param name="preconstructionMeeting">PreconstructionMeeting</param>
        /// <param name="specificMeetingLocation">SpecificMeetingLocation</param>
        /// <param name="specificMeetingLocationNotes">SpecificMeetingLocationNotes</param>
        /// <param name="vehicleAccess">VehicleAccess</param>
        /// <param name="projectOutcome">ProjectOutcome</param>
        /// <param name="specificReportingNeeds">SpecificReportingNeeds</param>
        /// <param name="orderNumber">OrderNumber</param>
        /// <param name="orderAttached">OrderAttached</param>
        /// <param name="orderNotes">OrderNotes</param>
        /// <param name="clientPromisesNotes">clientPromisesNotes</param>
        /// <param name="vehicleAccessNotes">vehicleAccessNotes</param>
        /// <param name="companyId">companyId</param>
        /// <param name="vehicleAccessRoad">vehicleAccessRoad</param>
        /// <param name="vehicleAccessEasement">vehicleAccessEasement</param>
        /// <param name="vehicleAccessOther">vehicleAccessOther</param>
        public void Insert(int projectId, bool liquidateDamage, decimal? liquidatedRate, string liquidatedUnit, bool clientWorkedBefore, string clientQuirks, bool clientPromises, string clientPromisesNotes, string waterObtain, string materialDispose, bool requireRPZ, string standardHydrantFitting, bool preconstructionMeeting, bool specificMeetingLocation, string specificMeetingLocationNotes, string vehicleAccess, string vehicleAccessNotes, string projectOutcome, string specificReportingNeeds, string orderNumber, bool orderAttached, string orderNotes, int companyId, bool vehicleAccessRoad, bool vehicleAccessEasement, bool vehicleAccessOther)
        {
            // Insert new project
            ProjectTDS.LFS_PROJECT_TERMSRow projectTermsRow = ((ProjectTDS.LFS_PROJECT_TERMSDataTable)Table).NewLFS_PROJECT_TERMSRow();
            
            projectTermsRow.ProjectID = projectId;
            projectTermsRow.LiquidatedDamage = liquidateDamage;
            if (liquidatedRate.HasValue)projectTermsRow.LiquidatedRate = (decimal)liquidatedRate; else projectTermsRow.SetLiquidatedRateNull();
            if (liquidatedUnit != null) projectTermsRow.LiquidatedUnit = liquidatedUnit; else projectTermsRow.SetLiquidatedUnitNull();
            projectTermsRow.RelationshipClientWorkedBefore = clientWorkedBefore;
            if (clientQuirks != null) projectTermsRow.RelationshipClientQuirks = clientQuirks; else projectTermsRow.SetRelationshipClientQuirksNull();
            projectTermsRow.RelationshipClientPromises = clientPromises;
            if (clientPromisesNotes != null)projectTermsRow.RelationshipClientPromisesNotes = clientPromisesNotes; else projectTermsRow.SetRelationshipClientPromisesNotesNull();
            if (waterObtain != null)projectTermsRow.RelationshipWaterObtain = waterObtain; else projectTermsRow.SetRelationshipWaterObtainNull();
            if (materialDispose != null) projectTermsRow.RelationshipMaterialDispose = materialDispose; else projectTermsRow.SetRelationshipMaterialDisposeNull();
            projectTermsRow.RelationshipRequireRPZ = requireRPZ;
            if (standardHydrantFitting != null) projectTermsRow.RelationshipStandardHydrantFitting = standardHydrantFitting; else projectTermsRow.SetRelationshipStandardHydrantFittingNull(); 
            projectTermsRow.RelationshipPreConstructionMeeting = preconstructionMeeting;
            projectTermsRow.RelationshipSpecificMeetingLocation = specificMeetingLocation;
            if (specificMeetingLocationNotes != null) projectTermsRow.RelationshipSpecificMeetingLocationNotes = specificMeetingLocationNotes; else projectTermsRow.SetRelationshipSpecificMeetingLocationNotesNull();
            if (vehicleAccess != null) projectTermsRow.RelationshipVehicleAccess = vehicleAccess; else projectTermsRow.SetRelationshipVehicleAccessNull();
            if (vehicleAccessNotes != null)projectTermsRow.RelationshipVehicleAccessNotes = vehicleAccessNotes; else projectTermsRow.SetRelationshipVehicleAccessNotesNull();
            if (projectOutcome != null) projectTermsRow.RelationshipProjectOutcome = projectOutcome; else projectTermsRow.SetRelationshipProjectOutcomeNull();
            if (specificReportingNeeds != null) projectTermsRow.RelationshipSpecificReportingNeeds = specificReportingNeeds; else projectTermsRow.SetRelationshipSpecificReportingNeedsNull();
            if (orderNumber != null) projectTermsRow.PurchaseOrderNumber = orderNumber; else projectTermsRow.SetPurchaseOrderNumberNull();
            projectTermsRow.PurchaseOrderAttached = orderAttached;
            if (orderNotes != null)  projectTermsRow.PurchaseOrderNotes = orderNotes;  else projectTermsRow.SetPurchaseOrderNotesNull();
            projectTermsRow.COMPANY_ID = companyId;
            projectTermsRow.VehicleAccessRoad = vehicleAccessRoad;
            projectTermsRow.VehicleAccessEasement = vehicleAccessEasement;
            projectTermsRow.VehicleAccessOther = vehicleAccessOther;

            ((ProjectTDS.LFS_PROJECT_TERMSDataTable)Table).AddLFS_PROJECT_TERMSRow(projectTermsRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="liquidateDamage">LiquidateDamage</param>
        /// <param name="liquidatedRate">LiquidatedRate</param>
        /// <param name="liquidatedUnit">LiquidatedUnit</param>
        /// <param name="clientWorkedBefore">ClientWorkedBefore</param>
        /// <param name="clientQuirks">ClientQuirks</param>
        /// <param name="clientPromises">ClientPromises</param>
        /// <param name="waterObtain">WaterObtain</param>
        /// <param name="materialDispose">MaterialDispose</param>
        /// <param name="requireRPZ">RequireRPZ</param>
        /// <param name="standardHydrantFitting">StandardHydrantFitting</param>
        /// <param name="preconstructionMeeting">PreconstructionMeeting</param>
        /// <param name="specificMeetingLocation">SpecificMeetingLocation</param>
        /// <param name="specificMeetingLocationNotes">SpecificMeetingLocationNotes</param>
        /// <param name="vehicleAccess">VehicleAccess</param>
        /// <param name="projectOutcome">ProjectOutcome</param>
        /// <param name="specificReportingNeeds">SpecificReportingNeeds</param>
        /// <param name="orderNumber">OrderNumber</param>
        /// <param name="orderAttached">OrderAttached</param>
        /// <param name="orderNotes">OrderNotes</param>
        /// <param name="clientPromisesNotes">clientPromisesNotes</param>
        /// <param name="vehicleAccessNotes">vehicleAccessNotes</param>
        /// <param name="companyId">companyId</param>
        /// <param name="vehicleAccessRoad">vehicleAccessRoad</param>
        /// <param name="vehicleAccessEasement">vehicleAccessEasement</param>
        /// <param name="vehicleAccessOther">vehicleAccessOther</param>
        //public void Update(int projectId, bool liquidateDamage, decimal? liquidatedRate, string liquidatedUnit, bool clientWorkedBefore, string clientQuirks, bool clientPromises, string clientPromisesNotes, string waterObtain, string materialDispose, bool requireRPZ, string standardHydrantFitting, bool preconstructionMeeting, bool specificMeetingLocation, string specificMeetingLocationNotes, string vehicleAccess, string vehicleAccessNotes, string projectOutcome, string specificReportingNeeds, string orderNumber, bool orderAttached, string orderNotes, int companyId)
        public void Update(int projectId,  string projectOutcome, string specificReportingNeeds, string orderNumber, int companyId, bool vehicleAccessRoad, bool vehicleAccessEasement, bool vehicleAccessOther)
        {
            ProjectTDS.LFS_PROJECT_TERMSRow projectTermsRow = GetRow(projectId);

            //projectTermsRow.LiquidatedDamage = liquidateDamage;
            //if (liquidatedRate.HasValue)projectTermsRow.LiquidatedRate = (decimal)liquidatedRate; else projectTermsRow.SetLiquidatedRateNull();
            //if (liquidatedUnit != null) projectTermsRow.LiquidatedUnit = liquidatedUnit; else projectTermsRow.SetLiquidatedUnitNull();
            //projectTermsRow.RelationshipClientWorkedBefore = clientWorkedBefore;
            //if (clientQuirks != null) projectTermsRow.RelationshipClientQuirks = clientQuirks; else projectTermsRow.SetRelationshipClientQuirksNull();
            //projectTermsRow.RelationshipClientPromises = clientPromises;
            //if (clientPromisesNotes != null) projectTermsRow.RelationshipClientPromisesNotes = clientPromisesNotes; else  projectTermsRow.SetRelationshipClientPromisesNotesNull();
            //if (waterObtain != null) projectTermsRow.RelationshipWaterObtain = waterObtain; else projectTermsRow.SetRelationshipWaterObtainNull();
            //if (materialDispose != null) projectTermsRow.RelationshipMaterialDispose = materialDispose;  else  projectTermsRow.SetRelationshipMaterialDisposeNull();
            //projectTermsRow.RelationshipRequireRPZ = requireRPZ;
            //if (standardHydrantFitting != null)  projectTermsRow.RelationshipStandardHydrantFitting = standardHydrantFitting; else projectTermsRow.SetRelationshipStandardHydrantFittingNull();
            //projectTermsRow.RelationshipPreConstructionMeeting = preconstructionMeeting;
            //projectTermsRow.RelationshipSpecificMeetingLocation = specificMeetingLocation;
            //if (specificMeetingLocationNotes != null) projectTermsRow.RelationshipSpecificMeetingLocationNotes = specificMeetingLocationNotes; else projectTermsRow.SetRelationshipSpecificMeetingLocationNotesNull();
            //if (vehicleAccess != null) projectTermsRow.RelationshipVehicleAccess = vehicleAccess; else projectTermsRow.SetRelationshipVehicleAccessNull();
            //if (vehicleAccessNotes != null) projectTermsRow.RelationshipVehicleAccessNotes = vehicleAccessNotes; else projectTermsRow.SetRelationshipVehicleAccessNotesNull();
            if (projectOutcome != null) projectTermsRow.RelationshipProjectOutcome = projectOutcome; else projectTermsRow.SetRelationshipProjectOutcomeNull();
            if (specificReportingNeeds != null) projectTermsRow.RelationshipSpecificReportingNeeds = specificReportingNeeds; else projectTermsRow.SetRelationshipSpecificReportingNeedsNull();
            if (orderNumber != null) projectTermsRow.PurchaseOrderNumber = orderNumber; else projectTermsRow.SetPurchaseOrderNumberNull();
            //projectTermsRow.PurchaseOrderAttached = orderAttached;
            //if (orderNotes != null) projectTermsRow.PurchaseOrderNotes = orderNotes; else projectTermsRow.SetPurchaseOrderNotesNull();
            projectTermsRow.COMPANY_ID = companyId;
            projectTermsRow.VehicleAccessRoad = vehicleAccessRoad;
            projectTermsRow.VehicleAccessEasement = vehicleAccessEasement;
            projectTermsRow.VehicleAccessOther = vehicleAccessOther;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECTRow</returns>
        private ProjectTDS.LFS_PROJECT_TERMSRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECT_TERMSRow row = ((ProjectTDS.LFS_PROJECT_TERMSDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.Project.GetRow");
            }
            return row;
        }



    }
}