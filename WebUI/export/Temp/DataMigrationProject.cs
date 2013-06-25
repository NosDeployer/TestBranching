using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.BL.CWP.Assets;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI
{
    public class DataMigrationProject : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public DataMigrationProject() : base("DataMigrationProject")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public DataMigrationProject(DataSet data)
            : base(data, "DataMigrationProject")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataMigrationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="companiesId"></param>
        /// <param name="countryId"></param>
        /// <param name="provinceId"></param>
        /// <param name="countyId"></param>
        /// <param name="cityId"></param>
        /// <param name="officeId"></param>
        /// <param name="projectLeadId"></param>
        /// <param name="salesmanId"></param>
        /// <param name="name"></param>
        public void Insert(int companiesId, Int64 countryId, Int64? provinceId, Int64? countyId, Int64? cityId, int officeId, int? projectLeadId, int salesmanId, string project)
        {
            DataMigrationTDS.DataMigrationProjectRow row = ((DataMigrationTDS.DataMigrationProjectDataTable)Table).NewDataMigrationProjectRow();

            row.COMPANIES_ID = companiesId;
            row.CountryID = countryId;
            if (provinceId.HasValue) row.ProvinceID = provinceId.Value; else row.SetProvinceIDNull();
            if (countyId.HasValue) row.CountyID = countyId.Value; else row.SetCountyIDNull();
            if (cityId.HasValue) row.CityID = cityId.Value; else row.SetCityIDNull();
            row.OfficeID = officeId;
            if (projectLeadId.HasValue) row.ProjectLeadID = projectLeadId.Value; else row.SetProjectLeadIDNull();
            row.SalesmanID = salesmanId;
            row.Name = project;          
            
            ((DataMigrationTDS.DataMigrationProjectDataTable)Table).AddDataMigrationProjectRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="countryId">countryId</param>
        /// <param name="provinceId">provinceId</param>
        /// <param name="countyId">countyId</param>
        /// <param name="cityId">cityId</param>
        /// <param name="companyId">companyId</param>
        /// <param name="loginId">loginId</param>
        public void Save(int companyId, int loginId)
        {       
            foreach (DataMigrationTDS.DataMigrationProjectRow row in (DataMigrationTDS.DataMigrationProjectDataTable)Table)
            {
                // get parameters
                DateTime date = DateTime.Now;
                Int64 countryId = row.CountryID;
                Int64? provinceId = null; if (!row.IsProvinceIDNull()) provinceId = row.ProvinceID;
                Int64? countyId = null; if (!row.IsCountyIDNull()) countyId = row.CountyID;
                Int64? cityId = null; if (!row.IsCityIDNull()) cityId = row.CityID;
                int officeId = row.OfficeID;
                int? projectLeadId = null; if (!row.IsProjectLeadIDNull()) projectLeadId = row.ProjectLeadID;
                int salesmanId = row.SalesmanID;
                string projectState = "Active";
                string projectType = "Project";
                string name = row.Name;
                int clientId = row.COMPANIES_ID;
                               
                string projectNumber = GetProjectNumber(row, companyId);
                
                DataMigrationProjectGateway dataMigrationProjectGateway = new DataMigrationProjectGateway(null);
                if (dataMigrationProjectGateway.GetProjectIdByName(row.Name) == 0)
                {
                    int projectId = dataMigrationProjectGateway.InsertProject(countryId, officeId, projectLeadId, salesmanId, projectNumber, projectType, projectState, name, "", null, null, null, clientId, null, null, "", false, null, null, null, provinceId, cityId, companyId, countyId);

                    dataMigrationProjectGateway.InsertHistory(projectId, 1, projectState, DateTime.Now, loginId, companyId);

                    ProjectNumberGateway projectNumberGateway = new ProjectNumberGateway();
                    projectNumberGateway.Load();
                    ProjectNumber projectNumberForLoad = new ProjectNumber(projectNumberGateway.Data);
                    string pnProjectIncrement = projectNumberForLoad.GetProjectIncrement(date.Year, companyId);
                    int projectIncrement = int.Parse(pnProjectIncrement);
                    dataMigrationProjectGateway.UpdateProjectNumber(date.Year, projectIncrement, companyId);                
                }                
            }
        }



        /// <summary>
        /// GetProjectNumber
        /// </summary>
        /// <param name="row">row</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        private string GetProjectNumber(DataMigrationTDS.DataMigrationProjectRow row, int companyId)
        {
            DateTime date = DateTime.Now;

            CountryGateway countryGateway = new CountryGateway(new DataSet());
            countryGateway.LoadByCountryId(row.CountryID);
            string pnCountryId = countryGateway.GetIdForProjects(row.CountryID);

            OfficeGateway officeGateway = new OfficeGateway(new DataSet());
            officeGateway.LoadByOfficeId(row.OfficeID);
            string pnOfficeId = officeGateway.GetIdForProjects(row.OfficeID);

            SalesmanGateway salesmanGateway = new SalesmanGateway(new DataSet());
            salesmanGateway.LoadBySalesmanId(row.SalesmanID);
            string pnSalesmanId = salesmanGateway.GetIdForProjects(row.SalesmanID);

            ProjectNumberGateway projectNumberGateway = new ProjectNumberGateway();
            projectNumberGateway.Load();
            ProjectNumber projectNumber = new ProjectNumber(projectNumberGateway.Data);
            string pnYearCode = projectNumber.GetYearCode(date.Year);
            string pnProjectIncrement = projectNumber.GetProjectIncrement(date.Year, companyId);

            string newProjectNumber = pnCountryId + pnOfficeId + pnSalesmanId + pnYearCode + pnProjectIncrement;

            return newProjectNumber;
        }       




    }
}

