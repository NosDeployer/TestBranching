using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.CWP.Common;

namespace LiquiForce.LFSLive.BL.CWP.Common
{
    /// <summary>
    /// ProjectAddSectionsSearch
    /// </summary>
    public class ProjectAddSectionsSearch : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectAddSectionsSearch() : base("ProjectAddSectionsSearch")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectAddSectionsSearch(DataSet data) : base(data, "ProjectAddSectionsSearch")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectAddSectionsTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="whereClause">whereClause</param>
        /// <param name="orderByClause">orderByClause</param>
        public void Load(string whereClause, string orderByClause)
        {
            ProjectAddSectionsSearchGateway projectAddSectionsSearchGateway = new ProjectAddSectionsSearchGateway(Data);
            projectAddSectionsSearchGateway.Table.Clear();
            projectAddSectionsSearchGateway.ClearBeforeFill = true;
            projectAddSectionsSearchGateway.LoadWhereOrderBy(whereClause, orderByClause);
        }



        /// <summary>
        /// Update Row 
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <param name="rehabAssessmentWork">rehabAssessmentWork</param>
        /// <param name="fullLengthLiningWork">fullLengthLiningWork</param>
        /// <param name="pointRepairsWork">pointRepairsWork</param>
        /// <param name="JunctionLiningWork">JunctionLiningWork</param>
        /// <param name="Selected">Selected</param>
        /// <param name="rehabAssessmentPrevWork">rehabAssessmentPrevWork</param>
        /// <param name="fullLengthLiningPrevWork">fullLengthLiningPrevWork</param>
        /// <param name="pointRepairsPrevWork">pointRepairsPrevWork</param>
        /// <param name="junctionLiningPrevWork">junctionLiningPrevWork</param>
        public void UpdateBySectionId(string sectionId, bool rehabAssessmentWork, bool fullLengthLiningWork, bool pointRepairsWork, bool JunctionLiningWork, bool Selected, bool rehabAssessmentPrevWork, bool fullLengthLiningPrevWork, bool pointRepairsPrevWork, bool junctionLiningPrevWork)
        {
            ProjectAddSectionsTDS.ProjectAddSectionsSearchRow row = GetRow(sectionId);

            row.RehabAssessmentWork = rehabAssessmentWork;
            row.FulllengthLiningWork = fullLengthLiningWork;
            row.PointRepairsWork = pointRepairsWork;
            row.JunctionLiningWork = JunctionLiningWork;            
            row.Selected = Selected;
            row.RehabAssessmentPrevWork = rehabAssessmentPrevWork;
            row.FullLengthLiningPrevWork = fullLengthLiningPrevWork;
            row.PointRepairsPrevWork = pointRepairsPrevWork;
            row.JunctionLiningPrevWork = junctionLiningPrevWork;            
        }



        /// <summary>
        /// UpdatePreviousWorks 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="companyId">companyId</param>
        public void UpdatePreviousWorks(int projectId,  int companyId)
        {
            ProjectAddSectionsSearchGateway projectAddSectionsSearchGateway = new ProjectAddSectionsSearchGateway();

            foreach (ProjectAddSectionsTDS.ProjectAddSectionsSearchRow searchRow in (ProjectAddSectionsTDS.ProjectAddSectionsSearchDataTable)Data.Tables["ProjectAddSectionsSearch"])
            {
                // If there is Previous RA works on section
                if (projectAddSectionsSearchGateway.ExistsRehabAssessmentWork(projectId, searchRow.AssetID, companyId))
                {
                    searchRow.RehabAssessmentPrevWork = true;
                }

                // If there is Previous FL works on section
                if (projectAddSectionsSearchGateway.ExistsFullLengthLiningWork(projectId, searchRow.AssetID, companyId))
                {
                    searchRow.FullLengthLiningPrevWork = true;
                }

                // If there is Previous PR works on section
                if (projectAddSectionsSearchGateway.ExistsPointRepairsWork(projectId, searchRow.AssetID, companyId))
                {
                    searchRow.PointRepairsPrevWork = true;
                }

                // If there is Previous JL works on section
                if (projectAddSectionsSearchGateway.ExistsJunctionLiningWork(projectId, searchRow.AssetID, companyId))
                {
                    searchRow.JunctionLiningPrevWork = true;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single section. If not exists, raise an exception
        /// </summary>
        /// <param name="sectionId">sectionId</param>
        /// <returns>ProjectAddSectionsSearchRow</returns>
        private ProjectAddSectionsTDS.ProjectAddSectionsSearchRow GetRow(string sectionId)
        {
            string filter = string.Format("SectionID = '{0}'", sectionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return (ProjectAddSectionsTDS.ProjectAddSectionsSearchRow) row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.CWP.Common.ProjectAddSectionsSearch.GetRow");
            }
        }



    }
}