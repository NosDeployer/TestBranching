using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorGateway
    /// </summary>
    public class ProjectNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorGateway() : base("LFS_PROJECT_NAVIGATOR")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorGateway(DataSet data) : base(data, "LFS_PROJECT_NAVIGATOR")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectNavigatorTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "LFS_PROJECT_NAVIGATOR";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ProjectNumber", "ProjectNumber");
            tableMapping.ColumnMappings.Add("ProjectType", "ProjectType");
            tableMapping.ColumnMappings.Add("ProjectState", "ProjectState");
            tableMapping.ColumnMappings.Add("Name", "Name");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("ClientName", "ClientName");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");            
            tableMapping.ColumnMappings.Add("InvoicedToDate", "InvoicedToDate");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("Description", "Description");
            
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByProjectNumberNameClientIdProjectType
        /// </summary>
        /// <param name="projectNumber">Project Number filter</param>
        /// <param name="name">Name filter</param>
        /// <param name="client">Client Name filter</param>
        /// <param name="projectType">Project Type filter</param>
        /// <param name="projectState">State filter</param>
        /// <param name="country">Country filter</param>
        public void LoadByProjectNumberNameClientProjectTypeProjectStateCountry(string projectNumber, string name, string client, string projectType, string projectState, string country)
        {
            string commandText = "SELECT P.ProjectID, P.ProjectNumber, P.ProjectType, P.ProjectState, P.Name, P.CLientID, C.Name ClientName, P.Deleted, CU.InvoicedToDate,  CAST (0  AS bit) AS Selected, P.Description FROM dbo.LFS_PROJECT P INNER JOIN dbo.COMPANIES C ON P.ClientID = C.COMPANIES_ID LEFT OUTER JOIN LFS_PROJECT_COSTING_UPDATES AS CU ON P.ProjectID = CU.ProjectID WHERE ";
            
            if (projectNumber.Trim() != "")
            {
                commandText += "(P.ProjectNumber LIKE '%" + projectNumber.Trim() + "%')";
            }

            if (name.Trim() != "")
            {
                if (projectNumber.Trim() != "") commandText += " AND ";

                commandText += "(P.Name LIKE '%" + name.Trim() + "%')";
            }

            if (client.Trim() != "")
            {
                if ((projectNumber.Trim() != "") || (name.Trim() != "")) commandText += " AND ";

                commandText += "(C.NAME LIKE '%" + client.Trim() + "%')";
            }

            if (country.Trim() != "")
            {
                if ((projectNumber.Trim() != "") || (name.Trim() != "") || (client.Trim() != "")) commandText += " AND ";

                commandText += "(P.CountryID = " + country.Trim() + ")";
            }

            if ((projectNumber.Trim() != "") || (name.Trim() != "") || (client.Trim() != "") || (country.Trim() != "")) commandText += " AND (P.Deleted = 0) AND"; else commandText += "(P.Deleted = 0) AND";

            // Show all except Internal type
            if (projectType.Trim() == "BallparkProposalProject")
            {
                commandText += "(P.ProjectType NOT LIKE 'Internal') AND ";
            }
            else
            {
                commandText += "(P.ProjectType LIKE '" + projectType + "') AND ";
            }

            commandText += "(P.ProjectState LIKE '" + projectState + "')";

            commandText += " ORDER BY SUBSTRING(ProjectNumber, LEN(ProjectNumber) - 4, 5) DESC";

            FillData(commandText);
        }



        /// <summary>
        /// LoadByProjectType
        /// </summary>
        /// <param name="projectType">ProjectType filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectType(string projectType)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNAVIGATORGATEWAY_LOADBYPROJECTTYPE", new SqlParameter("@projectType", projectType));
            return Data;
        }
        

               
    }
}