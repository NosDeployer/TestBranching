using System;
using System.Data;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectSectionsNavigator
    /// </summary>
    public class ProjectSectionsNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectSectionsNavigator()
            : base("LFS_PROJECT_SECTIONS_NAVIGATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectSectionsNavigator(DataSet data)
            : base(data, "LFS_PROJECT_SECTIONS_NAVIGATOR")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectSectionsNavigatorTDS();
        }



        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="dsmh">dsmh</param>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionID">sectionID</param>
        /// <param name="street">street</param>
        /// <param name="usmh">usmh</param>
        public void LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId(string sectionID, string street, string usmh, string dsmh, int companyId, int projectId)
        {
            ProjectSectionsNavigatorGateway projectSectionsNavigatorGateway = new ProjectSectionsNavigatorGateway(Data);
            projectSectionsNavigatorGateway.LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId(sectionID, street, usmh, dsmh, companyId, projectId);

            //  Load comments
            UpdateFieldsForSections(companyId, projectId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="selected">selected</param>
        public void Update(int assetId, bool selected)
        {
            ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORRow row = GetRow(assetId);
            row.Selected = selected;
        }




        /// <summary>
        /// UpdateFieldsForSections
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <param name="currentProjectId">currentProjectId</param>
        private void UpdateFieldsForSections(int companyId, int currentProjectId)
        {
            AssetSewerSectionGateway assetSewerFindSectionGateway = new AssetSewerSectionGateway();

            AssetSewerMHGateway assetSewerFindMHGateway = new AssetSewerMHGateway();
            WorkGateway workGateway = new WorkGateway();
            foreach (ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORRow row in (ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable)Table)
            {
                //General data for asset
                assetSewerFindSectionGateway.LoadByAssetId(row.AssetID, companyId); //COMPANY_ID

                // ... For usmh
                row.USMHDescription = "";
                if (!row.IsUSMHNull())
                {
                    assetSewerFindMHGateway.LoadByAssetId(row.USMH, companyId);
                    row.USMHDescription = assetSewerFindMHGateway.GetMHID(row.USMH);
                }

                // ... For dsmh
                row.DSMHDescription = "";
                if (!row.IsDSMHNull())
                {
                    assetSewerFindMHGateway.LoadByAssetId(row.DSMH, companyId);
                    row.DSMHDescription = assetSewerFindMHGateway.GetMHID(row.DSMH);
                }

                // ... For Works
                row.RehabAssessment = workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(row.AssetID, currentProjectId, "Rehab Assessment", companyId);
                row.FullLengthLining = workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(row.AssetID, currentProjectId, "Full Length Lining", companyId);
                row.JunctionLining = workGateway.ExistsProjectIdAssetIdWorkTypeCompanyId(row.AssetID, currentProjectId, "Junction Lining Section", companyId);

                row.WorksDescription = "";
                if (row.RehabAssessment) row.WorksDescription = row.WorksDescription + "Rehab Assessment";

                if (row.FullLengthLining)
                {
                    if (row.WorksDescription.Trim().Length > 0)
                    {
                        row.WorksDescription = row.WorksDescription + ", Full Length Lining";
                    }
                    else
                    {
                        row.WorksDescription = row.WorksDescription + "Full Length Lining";
                    }
                }
                if (row.JunctionLining)
                {
                    if (row.WorksDescription.Trim().Length > 0)
                    {
                        row.WorksDescription = row.WorksDescription + ", Junction Lining";
                    }
                    else
                    {
                        row.WorksDescription = row.WorksDescription + "Junction Lining";
                    }
                }

                // ... For Laterals
                AssetSewerLateralGateway assetSewerLateralGateway = new AssetSewerLateralGateway();

                assetSewerLateralGateway.LoadBySectionId(row.AssetID, companyId);

                AssetSewerLateral assetSewerLateral = new AssetSewerLateral(assetSewerLateralGateway.Data);
                row.LateralsDescription = assetSewerLateral.GetAllLaterals(row.AssetID, companyId);
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="sectionId">sectionId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int projectId, int assetId, int companyId) //COMPANY_ID
        {
            WorkRehabAssessmentGateway workRehabAssessmentGateway = new WorkRehabAssessmentGateway();
            WorkRehabAssessment workRehabAssessment = new WorkRehabAssessment(workRehabAssessmentGateway.Data);

            WorkFullLengthLiningGateway workFullLengthLiningGateway = new WorkFullLengthLiningGateway();
            WorkFullLengthLining workFullLengthLining = new WorkFullLengthLining(workFullLengthLiningGateway.Data);

            WorkJunctionLiningSectionGateway workJunctionLiningSectionGateway = new WorkJunctionLiningSectionGateway();
            WorkJunctionLiningSection workJunctionLiningSection = new WorkJunctionLiningSection(workJunctionLiningSectionGateway.Data);

            int workIdRA = GetWorkId(projectId, assetId, "Rehab Assessment", companyId);
            if (workIdRA != 0) workRehabAssessment.DeleteDirect(workIdRA, companyId);

            int workIdFL = GetWorkId(projectId, assetId, "Full Length Lining", companyId);
            if (workIdFL != 0) workFullLengthLining.DeleteDirect(workIdFL, companyId);

            int workIdJL = GetWorkId(projectId, assetId, "Junction Lining Section", companyId);
            if (workIdJL != 0) workJunctionLiningSection.DeleteDirect(workIdJL, companyId);

            LfsAssetSewerSectionGateway lfsAssetSewerSectionGateway = new LfsAssetSewerSectionGateway();
            lfsAssetSewerSectionGateway.LoadByAssetId(assetId, companyId);
            LfsAssetSewerSection lfsAssetSewerSection = new LfsAssetSewerSection(lfsAssetSewerSectionGateway.Data);

            // Update lfs asset
            lfsAssetSewerSection.DeleteDirect(assetId, companyId);
        }



        /// <summary>
        /// GetWorkId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="assetId">assetId</param>
        /// <param name="workType">workType</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
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



        /// <summary>
        /// Get a single row. If not exists, raise an exception
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <returns>ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORRow</returns>
        private ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORRow GetRow(int assetId)
        {
            ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORRow row = ((ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable)Table).FindByAssetID(assetId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectSectionsNavigator.GetRow");
            }

            return row;
        }



    }
}