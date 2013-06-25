using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Revenue
{
    /// <summary>
    /// RevenueInformationBasicInformationGateway
    /// </summary>
    public class RevenueInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RevenueInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RevenueInformationBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RevenueInformationTDS();
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
            tableMapping.DataSetTable = "BasicInformation";            
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");            
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Revenue", "Revenue");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");                                        
            
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
        /// LoadByProjectIdRefId
        /// </summary>
        /// <param name="projectId">projectId</param>        
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectIdRefId(int projectId, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_REVENUEINFORMATIONBASICINFORMATIONGATEWAY_LOADBYPROJECTIDREFID", new SqlParameter("@projectId", projectId), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(int projectId, int refId)
        {
            string filter = string.Format("ProjectID = {0} AND RefID = '{1}'", projectId, refId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Revenue.RevenueInformationBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Reinstate or EMPTY</returns>
        public DateTime GetDate(int projectId, int refId)
        {
            return (DateTime)GetRow(projectId, refId)["Date"];
        }



        /// <summary>
        /// GetDate Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Date or EMPTY</returns>
        public DateTime GetDateOriginal(int projectId, int refId)
        {
            return (DateTime)GetRow(projectId, refId)["Date", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRevenue
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Revenue or EMPTY</returns>
        public decimal GetRevenue(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["Revenue"];
        }



        /// <summary>
        /// GetRevenue Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Revenue or EMPTY</returns>
        public decimal GetRevenueOriginal(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["Revenue", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComment
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Comment or EMPTY</returns>
        public string GetComment(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Comment"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Comment"];
            }
        }



        /// <summary>
        /// GetComment Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Comment or EMPTY</returns>
        public string GetCommentOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Comment"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Comment", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClient
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Client or EMPTY</returns>
        public string GetClient(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Client"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Client"];
            }
        }



        /// <summary>
        /// GetClient Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Client or EMPTY</returns>
        public string GetClientOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Client"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Client", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProject
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Project or EMPTY</returns>
        public string GetProject(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Project"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Project"];
            }
        }



        /// <summary>
        /// GetProject Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Project or EMPTY</returns>
        public string GetProjectOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Project"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Project", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientID
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>ClientID or EMPTY</returns>
        public int GetClientId(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["ClientID"];
        }



        /// <summary>
        /// GetClientID Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original ClientID or EMPTY</returns>
        public int GetClientIdOriginal(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["ClientID", DataRowVersion.Original];
        }


        
        /// <summary>
        /// GetCountryId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>CountryId or EMPTY</returns>
        public int GetCountryId(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["CountryID"];
        }

        
    }
}