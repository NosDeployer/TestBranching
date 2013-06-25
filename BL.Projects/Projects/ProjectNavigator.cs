using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNavigator
    /// </summary>
    public class ProjectNavigator : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigator()
            : base("LFS_PROJECT_NAVIGATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigator(DataSet data)
            : base(data, "LFS_PROJECT_NAVIGATOR")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="selected">selected</param>
        public void Update(int projectId, bool selected)
        {
            ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORRow row = GetRow(projectId);
            row.Selected = selected;
        }



        /// <summary>
        /// GetProjectId
        /// </summary>     
        /// <returns>projectId</returns>
        public int GetProjectId()
        {
            int projectId = 0;
            foreach (ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORRow row in (ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Table)
            {
                projectId = row.ProjectID;
            }

            return projectId;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        ///<param name="projectId">projectId</param>
        ///<returns>ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORRow</returns>
        private ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORRow GetRow(int projectId)
        {
            ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORRow row = ((ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Table).FindByProjectID(projectId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNavigator.GetRow");
            }

            return row;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="projectNavigatorTDS">projectNavigatorTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <returns>prevProjectId</returns>
        public static int GetPreviousId(ProjectNavigatorTDS projectNavigatorTDS, int currentProjectId)
        {
            int prevProjectId = currentProjectId;

            for (int i = 0; i < projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count; i++)
            {
                if ((int)projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView[i]["ProjectID"] == currentProjectId)
                {
                    if (i == 0)
                    {
                        prevProjectId = currentProjectId;
                    }
                    else
                    {
                        prevProjectId = (int)projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView[i - 1]["ProjectID"];
                    }

                    break;
                }
            }

            return prevProjectId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="projectNavigatorTDS">projectNavigatorTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <returns>nextProjectId</returns>
        public static int GetNextId(ProjectNavigatorTDS projectNavigatorTDS, int currentProjectId)
        {
            int nextProjectId = currentProjectId;

            for (int i = 0; i < projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count; i++)
            {
                if ((int)projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView[i]["ProjectID"] == currentProjectId)
                {
                    if (i == projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView.Count - 1)
                    {
                        nextProjectId = currentProjectId;
                    }
                    else
                    {
                        nextProjectId = (int)projectNavigatorTDS.LFS_PROJECT_NAVIGATOR.DefaultView[i + 1]["ProjectID"];
                    }
                    break;
                }
            }

            return nextProjectId;
        }



        /// <summary>
        /// GetPreviousId
        /// </summary>
        /// <param name="projectSelectProjectTDS">projectSelectProjectTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <returns>prevProjectId</returns>
        public static int GetPreviousId2(ProjectSelectProjectTDS projectSelectProjectTDS, int currentProjectId)
        {
            int prevProjectId = currentProjectId;

            for (int i = 0; i < projectSelectProjectTDS.LastUsedProjects.DefaultView.Count; i++)
            {
                if ((int)projectSelectProjectTDS.LastUsedProjects.DefaultView[i]["ProjectID"] == currentProjectId)
                {
                    if (i == 0)
                    {
                        prevProjectId = currentProjectId;
                    }
                    else
                    {
                        prevProjectId = (int)projectSelectProjectTDS.LastUsedProjects.DefaultView[i - 1]["ProjectID"];
                    }

                    break;
                }
            }

            return prevProjectId;
        }



        /// <summary>
        /// GetNextId
        /// </summary>
        /// <param name="projectSelectProjectTDS">projectSelectProjectTDS</param>
        /// <param name="currentProjectId">currentProjectId</param>
        /// <returns>nextProjectId</returns>
        public static int GetNextId2(ProjectSelectProjectTDS projectSelectProjectTDS, int currentProjectId)
        {
            int nextProjectId = currentProjectId;

            for (int i = 0; i < projectSelectProjectTDS.LastUsedProjects.DefaultView.Count; i++)
            {
                if ((int)projectSelectProjectTDS.LastUsedProjects.DefaultView[i]["ProjectID"] == currentProjectId)
                {
                    if (i == projectSelectProjectTDS.LastUsedProjects.DefaultView.Count - 1)
                    {
                        nextProjectId = currentProjectId;
                    }
                    else
                    {
                        nextProjectId = (int)projectSelectProjectTDS.LastUsedProjects.DefaultView[i + 1]["ProjectID"];
                    }
                    break;
                }
            }

            return nextProjectId;
        }



    }
}