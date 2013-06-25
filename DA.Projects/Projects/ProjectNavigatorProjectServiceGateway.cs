using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectNavigatorProjectNotesGateway
    /// </summary>
    public class ProjectNavigatorProjectServiceGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectNavigatorProjectServiceGateway()
            : base("ProjectService")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectNavigatorProjectServiceGateway(DataSet data)
            : base(data, "ProjectService")
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
            tableMapping.DataSetTable = "ProjectService";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("ServiceID", "ServiceID");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("AverageSize", "AverageSize");
            tableMapping.ColumnMappings.Add("AveragePrice", "AveragePrice");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");            
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Total", "Total");   
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
        /// LoadAllByProjectId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTNAVIGATORPROJECTSERVICEGATEWAY_LOADALLBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, int refId)
        {
            string filter = string.Format("ProjectID = {0} AND RefID = {1}", projectId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectNavigatorProjectServiceGateway.GetRow");
            }
        }



        /// <summary>
        /// GetServiceID
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>ServiceID or EMPTY</returns>
        public int? GetServiceID(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("ServiceID"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId, refId)["ServiceID"];
            }
        }



        /// <summary>
        /// GetServiceID Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original ServiceID or EMPTY</returns>
        public int? GetServiceIDOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["ServiceID"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(projectId, refId)["ServiceID", DataRowVersion.Original];
            }
        }     



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Description or EMPTY</returns>
        public string GetDescription(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Description"];
            }
        }



        /// <summary>
        /// GetDescription Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Description or EMPTY</returns>
        public string GetDescriptionOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Description"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Description", DataRowVersion.Original];
            }
        }

        

        /// <summary>
        /// GetAverageSize
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>AverageSize or EMPTY</returns>
        public string GetAverageSize(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("AverageSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["AverageSize"];
            }
        }



        /// <summary>
        /// GetAverageSize Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original AverageSize or EMPTY</returns>
        public string GetAverageSizeOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["AverageSize"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["AverageSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAveragePrice
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>AveragePrice or EMPTY</returns>
        public decimal? GetAveragePrice(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("AveragePrice"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId, refId)["AveragePrice"];
            }
        }



        /// <summary>
        /// GetAveragePrice Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original AveragePrice or EMPTY</returns>
        public decimal? GetAveragePriceOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["AveragePrice"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId, refId)["AveragePrice", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetQuantity
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Quantity</returns>
        public int GetQuantity(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["Quantity"];            
        }



        /// <summary>
        /// GetQuantity Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>
        /// <returns>Original Quantity</returns>
        public int GetQuantityOriginal(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["Quantity", DataRowVersion.Original];            
        }     



    }
}
