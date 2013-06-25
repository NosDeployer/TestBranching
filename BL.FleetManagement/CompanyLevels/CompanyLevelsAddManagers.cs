using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;

namespace LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels
{
    /// <summary>
    /// CompanyLevelManagers
    /// </summary>
    public class CompanyLevelsAddManagers : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public CompanyLevelsAddManagers()
            : base("CompanyLevelManagers")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public CompanyLevelsAddManagers(DataSet data)
            : base(data, "CompanyLevelManagers")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new CompanyLevelsAddTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>Data</returns>
        /// <param name="companyId">companyId</param>
        public void LoadAll(int companyId)
        {
            CompanyLevelsAddManagersGateway companyLevelManagersGateway = new CompanyLevelsAddManagersGateway(Data);
            companyLevelManagersGateway.LoadAll(companyId);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="employeeId">employeeId</param>
        /// <param name="selected">selected</param>
        public void Update(int companyLevelId, int employeeId, bool selected)
        {
            CompanyLevelsAddTDS.CompanyLevelManagersRow row = GetRow(employeeId);
            row.CompanyLevelID = companyLevelId;
            row.Selected = selected;
        }



        /// <summary>
        /// Update
        /// </summary>
        public void DeleteAll()
        {
            foreach (CompanyLevelsAddTDS.CompanyLevelManagersRow row in (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Table)
            {
                if (row.Selected)
                {
                    row.Deleted = true;
                }
            }
        }



        /// <summary>
        /// UpdateManagers
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        public void UpdateManagers(int companyLevelId, int companyId)
        {
            CompanyLevelsAddManagersGateway companyLevelManagersGateway = new CompanyLevelsAddManagersGateway();

            foreach (CompanyLevelsAddTDS.CompanyLevelManagersRow row in (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Table)
            {
                if (companyLevelManagersGateway.InUseHasManagers(companyLevelId, row.EmployeeID, companyId))
                {
                    row.Selected = true;
                    row.InDatabase = true;
                    row.CompanyLevelID = companyLevelId;
                }
                else
                {
                    row.Selected = false;
                    row.InDatabase = false;
                    row.CompanyLevelID = 0;
                }
            }
        }
        


        /// <summary>
        /// GetManagers
        /// </summary>
        /// <returns>managers list</returns>
        public string GetManagers()
        {
            string managersList= "";
            CompanyLevelsAddManagersGateway companyLevelManagersGateway = new CompanyLevelsAddManagersGateway();

            foreach (CompanyLevelsAddTDS.CompanyLevelManagersRow row in (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Table)
            {
                if (row.Selected) 
                {
                    managersList = managersList + row.FullName + ", ";
                }
            }

            managersList = managersList.Substring(0, managersList.Length - 2);
            return managersList;
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="newCompanyLevelIdForAdd">newCompanyLevelIdForAdd</param>
        /// <param name="companyId">companyId</param>
        public void Save(int newCompanyLevelId, int companyId)
        {
            foreach (CompanyLevelsAddTDS.CompanyLevelManagersRow row in (CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Data.Tables["CompanyLevelManagers"])
            {
                // Insert CompanyLevel manager
                if ((!row.Deleted) && (!row.InDatabase) && (row.Selected))
                {
                    CompanyLevelsManagers companyLevelsManagers = new CompanyLevelsManagers(null);
                    companyLevelsManagers.InsertDirect(newCompanyLevelId, row.EmployeeID, row.Deleted, companyId);
                }

                // Delete CompanyLevel for Update
                if ((!row.Deleted) && (row.InDatabase) && (!row.Selected))
                {
                    CompanyLevelsManagers companyLevelsManagers = new CompanyLevelsManagers(null);
                    companyLevelsManagers.DeletedDirect(newCompanyLevelId, row.EmployeeID, companyId);
                }

                // Delete CompanyLevel 
                if ((row.Deleted) && (row.InDatabase) && (row.Selected))
                {
                    CompanyLevelsManagers companyLevelsManagers = new CompanyLevelsManagers(null);
                    companyLevelsManagers.DeletedDirect(newCompanyLevelId, row.EmployeeID, companyId);
                }
            }
        }







        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        ///<summary>
        ///Get a single row. If not exists, raise an exception
        ///</summary>
        /// <param name="employeeId">employeeId</param>
        ///<returns>CompanyLevelsAddTDS.CompanyLevelManagersRow</returns>
        private CompanyLevelsAddTDS.CompanyLevelManagersRow GetRow(int employeeId)
        {
            CompanyLevelsAddTDS.CompanyLevelManagersRow row = ((CompanyLevelsAddTDS.CompanyLevelManagersDataTable)Table).FindByEmployeeID(employeeId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FM.companyLevels.CompanyLevelManagers.GetRow");
            }

            return row;
        }


    }
}
