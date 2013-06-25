using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectTechnical
    /// </summary>
    public class ProjectTechnical : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTechnical() : base("LFS_PROJECT_TECHNICAL")
        {
        }

        

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTechnical(DataSet data)
            : base(data, "LFS_PROJECT_TECHNICAL")
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
        /// <param name="availableDrawings">availableDrawings</param>
        /// <param name="availableVideo">availableVideo</param>
        /// <param name="groundConditions">groundConditions</param>
        /// <param name="groundConditionNotes">groundConditionNotes</param>
        /// <param name="reviewVideoInspections">reviewVideoInspections</param>
        /// <param name="strangeConfigurations">strangeConfigurations</param>
        /// <param name="strangeConfigurationsNotes">strangeConfigurationsNotes</param>
        /// <param name="furtherObservations">furtherObservations</param>
        /// <param name="restrictiveFactors">restrictiveFactors</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int projectId, bool availableDrawings, bool availableVideo, bool groundConditions, string groundConditionNotes, bool reviewVideoInspections, bool strangeConfigurations, string strangeConfigurationsNotes, string furtherObservations, string restrictiveFactors, int companyId)
        {
            // Insert new project
            ProjectTDS.LFS_PROJECT_TECHNICALRow projectTechnicalRow = ((ProjectTDS.LFS_PROJECT_TECHNICALDataTable)Table).NewLFS_PROJECT_TECHNICALRow();

            projectTechnicalRow.ProjectID = projectId;
            projectTechnicalRow.Drawings = availableDrawings;
            projectTechnicalRow.Video = availableVideo;
            projectTechnicalRow.GroundConditions = groundConditions;

            if (groundConditionNotes != null)
            {
                projectTechnicalRow.GrounConditionsNotes = groundConditionNotes;
            }
            else
            {
                projectTechnicalRow.SetGrounConditionsNotesNull();
            }

            projectTechnicalRow.ReviewVideo = reviewVideoInspections;
            projectTechnicalRow.StrangeConfigurations = strangeConfigurations;

            if (strangeConfigurationsNotes != null)
            {
                projectTechnicalRow.StrangeConfigurationsNotes = strangeConfigurationsNotes;
            }
            else
            {
                projectTechnicalRow.SetStrangeConfigurationsNotesNull();
            }

            if (furtherObservations != null)
            {
                projectTechnicalRow.FurtherObservations = furtherObservations;
            }
            else
            {
                projectTechnicalRow.SetFurtherObservationsNull();
            }

            if (restrictiveFactors != null)
            {
                projectTechnicalRow.RestrictiveFactors = restrictiveFactors;
            }
            else
            {
                projectTechnicalRow.SetRestrictiveFactorsNull();
            }

            projectTechnicalRow.COMPANY_ID = companyId;

            ((ProjectTDS.LFS_PROJECT_TECHNICALDataTable)Table).AddLFS_PROJECT_TECHNICALRow(projectTechnicalRow);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">ProjectId</param>
        /// <param name="availableDrawings">availableDrawings</param>
        /// <param name="availableVideo">availableVideo</param>
        /// <param name="groundConditions">groundConditions</param>
        /// <param name="groundConditionNotes">groundConditionNotes</param>
        /// <param name="reviewVideoInspections">reviewVideoInspections</param>
        /// <param name="strangeConfigurations">strangeConfigurations</param>
        /// <param name="strangeConfigurationsNotes">strangeConfigurationsNotes</param>
        /// <param name="furtherObservations">furtherObservations</param>
        /// <param name="restrictiveFactors">restrictiveFactors</param>
        /// <param name="companyId">companyId</param>
        // public void Update(int projectId, bool availableDrawings, bool availableVideo, bool groundConditions, string groundConditionNotes, bool reviewVideoInspections, bool strangeConfigurations, string strangeConfigurationsNotes, string furtherObservations, string restrictiveFactors, int companyId)
        public void Update(int projectId, bool availableDrawings, bool availableVideo,  int companyId)
        {
            ProjectTDS.LFS_PROJECT_TECHNICALRow projectTechnicalRow = GetRow(projectId);

            projectTechnicalRow.ProjectID = projectId;
            projectTechnicalRow.Drawings = availableDrawings;
            projectTechnicalRow.Video = availableVideo;
            //projectTechnicalRow.GroundConditions = groundConditions;

            //if (groundConditionNotes != null)
            //{
            //    projectTechnicalRow.GrounConditionsNotes = groundConditionNotes;
            //}
            //else
            //{
            //    projectTechnicalRow.SetGrounConditionsNotesNull();
            //}

            //projectTechnicalRow.ReviewVideo = reviewVideoInspections;
            //projectTechnicalRow.StrangeConfigurations = strangeConfigurations;

            //if (strangeConfigurationsNotes != null)
            //{
            //    projectTechnicalRow.StrangeConfigurationsNotes = strangeConfigurationsNotes;
            //}
            //else
            //{
            //    projectTechnicalRow.SetStrangeConfigurationsNotesNull();
            //}

            //if (furtherObservations != null)
            //{
            //    projectTechnicalRow.FurtherObservations = furtherObservations;
            //}
            //else
            //{
            //    projectTechnicalRow.SetFurtherObservationsNull();
            //}

            //if (restrictiveFactors != null)
            //{
            //    projectTechnicalRow.RestrictiveFactors = restrictiveFactors;
            //}
            //else
            //{
            //    projectTechnicalRow.SetRestrictiveFactorsNull();
            //}

            projectTechnicalRow.COMPANY_ID = companyId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ProjectTDS.LFS_PROJECTRow</returns>
        private ProjectTDS.LFS_PROJECT_TECHNICALRow GetRow(int projectId)
        {
            ProjectTDS.LFS_PROJECT_TECHNICALRow row = ((ProjectTDS.LFS_PROJECT_TECHNICALDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.Project.GetRow");
            }
            return row;
        }



    }
}