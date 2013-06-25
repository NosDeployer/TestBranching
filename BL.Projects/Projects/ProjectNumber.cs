using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Projects.Projects;

namespace LiquiForce.LFSLive.BL.Projects.Projects
{
    /// <summary>
    /// ProjectNumber
    /// </summary>
    public class ProjectNumber : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNumber() : base("LFS_PROJECT_NUMBER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNumber(DataSet data) : base(data, "LFS_PROJECT_NUMBER")
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
        /// GetYearCode
        /// </summary>
        /// <param name="yearCode">yearCode</param>
        /// <returns>string</returns>
        public string GetYearCode(int yearCode)
        {
            yearCode = yearCode - 2000;

            if (yearCode < 10)
            {
                return "0" + yearCode.ToString();
            }
            else
            {
                return yearCode.ToString();
            }
        }



        /// <summary>
        /// GetProjectIncrement
        /// </summary>
        /// <param name="yearCode">Year for project increment</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Project Increment string</returns>
        public string GetProjectIncrement(int yearCode, int companyId)
        {
            int projectIncrement = 0;
            ProjectTDS.LFS_PROJECT_NUMBERRow projectNumberRow = null;

            // Find year row if exists
            try
            {
                projectNumberRow = GetRow(yearCode);
            }
            catch
            {
            }

            // Calculate Project Increment
            if (projectNumberRow == null)
            {
                ProjectTDS.LFS_PROJECT_NUMBERRow newProjectNumberRow = ((ProjectTDS.LFS_PROJECT_NUMBERDataTable)Table).NewLFS_PROJECT_NUMBERRow();
                newProjectNumberRow.YearCode = yearCode;
                newProjectNumberRow.ProjectIncrement = 1;
                newProjectNumberRow.COMPANY_ID = companyId;
                ((ProjectTDS.LFS_PROJECT_NUMBERDataTable)Table).AddLFS_PROJECT_NUMBERRow(newProjectNumberRow);

                projectIncrement = newProjectNumberRow.ProjectIncrement;
            }
            else
            {
                projectNumberRow.ProjectIncrement = projectNumberRow.ProjectIncrement + 1;

                projectIncrement = projectNumberRow.ProjectIncrement;
            }

            // Complete Project Increment string for Project Number
            if (projectIncrement < 10)
            {
                return "00" + projectIncrement.ToString();
            }
            else
            {
                if (projectIncrement < 100)
                {
                    return "0" + projectIncrement.ToString();
                }
                else
                {
                    return projectIncrement.ToString();
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="yearCode">yearCode</param>
        /// <returns>ProjectTDS.LFS_PROJECT_NUMBERRow</returns>
        private ProjectTDS.LFS_PROJECT_NUMBERRow GetRow(int yearCode)
        {
            ProjectTDS.LFS_PROJECT_NUMBERRow row = ((ProjectTDS.LFS_PROJECT_NUMBERDataTable)Table).FindByYearCode(yearCode);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Projects.Projects.ProjectNumber.GetRow");
            }

            return row;
        }



    }
}
