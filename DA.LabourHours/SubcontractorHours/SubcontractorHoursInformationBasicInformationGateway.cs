using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours
{
    /// <summary>
    /// SubcontractorHoursInformationBasicInformationGateway
    /// </summary>
    public class SubcontractorHoursInformationBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SubcontractorHoursInformationBasicInformationGateway()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SubcontractorHoursInformationBasicInformationGateway(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new SubcontractorHoursInformationTDS();
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
            tableMapping.ColumnMappings.Add("SubcontractorID", "SubcontractorID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("Quantity", "Quantity");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("TotalCad", "TotalCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("TotalUsd", "TotalUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Subcontractor", "Subcontractor");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");
            tableMapping.ColumnMappings.Add("Active", "Active");
            tableMapping.ColumnMappings.Add("CountryID", "CountryID");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");    
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");                
            
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_SUBCONTRACTORHOURSINFORMATIONBASICINFORMATIONGATEWAY_LOADBYPROJECTIDREFID", new SqlParameter("@projectId", projectId), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.Common.SubcontractorAddProjectSubcontractorsCostGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSubcontractorID
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>SubcontractorID or EMPTY</returns>
        public int GetSubcontractorID(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["SubcontractorID"];
        }



        /// <summary>
        /// GetSubcontractorID Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original SubcontractorID or EMPTY</returns>
        public int GetSubcontractorIDOriginal(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["SubcontractorID", DataRowVersion.Original];
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
        /// GetQuantity
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Quantity or EMPTY</returns>
        public double GetQuantity(int projectId, int refId)
        {
            return (double)GetRow(projectId, refId)["Quantity"];
        }



        /// <summary>
        /// GetQuantity Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Quantity or EMPTY</returns>
        public double GetQuantityOriginal(int projectId, int refId)
        {
            return (double)GetRow(projectId, refId)["Quantity", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRateUsd
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>RateUsd or EMPTY</returns>
        public decimal GetRateUsd(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["RateUsd"];
        }



        /// <summary>
        /// GetRateUsd Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original RateUsd or EMPTY</returns>
        public decimal GetRateUsdOriginal(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["RateUsd", DataRowVersion.Original];
        }



        /// <summary>
        /// GetRateCad
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>RateCad or EMPTY</returns>
        public decimal GetRateCad(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["RateCad"];
        }



        /// <summary>
        /// GetRateCad Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original RateCad or EMPTY</returns>
        public decimal GetRateCadOriginal(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["RateCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalCad
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>TotalCad or EMPTY</returns>
        public decimal GetTotalCad(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["TotalCad"];
        }



        /// <summary>
        /// GetTotalCad Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original TotalCad or EMPTY</returns>
        public decimal GetTotalCadOriginal(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["TotalCad", DataRowVersion.Original];
        }



        /// <summary>
        /// GetTotalUsd
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>TotalUsd or EMPTY</returns>
        public decimal GetTotalUsd(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["TotalUsd"];
        }



        /// <summary>
        /// GetTotalUsd Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original TotalUsd or EMPTY</returns>
        public decimal GetTotalUsdOriginal(int projectId, int refId)
        {
            return (decimal)GetRow(projectId, refId)["TotalUsd", DataRowVersion.Original];
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
        /// GetSubcontractor
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Subcontractor or EMPTY</returns>
        public string GetSubcontractor(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Subcontractor"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Subcontractor"];
            }
        }



        /// <summary>
        /// GetSubcontractor Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Subcontractor or EMPTY</returns>
        public string GetSubcontractorOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Subcontractor"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Subcontractor", DataRowVersion.Original];
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
        /// GetActive
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Active or EMPTY</returns>
        public bool GetActive(int projectId, int refId)
        {
            return (bool)GetRow(projectId, refId)["Active"];
        }



        /// <summary>
        /// GetActive Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Active or EMPTY</returns>
        public bool GetActiveOriginal(int projectId, int refId)
        {
            return (bool)GetRow(projectId, refId)["Active", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCountryId
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>CountryId or EMPTY</returns>
        public Int64 GetCountryId(int projectId, int refId)
        {
            return (Int64)GetRow(projectId, refId)["CountryID"];
        }



        /// <summary>
        /// GetCountryId Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original CountryId or EMPTY</returns>
        public Int64 GetCountryIdOriginal(int projectId, int refId)
        {
            return (Int64)GetRow(projectId, refId)["CountryID", DataRowVersion.Original];
        }



        /// <summary>
        /// GetClientID
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>ClientID or EMPTY</returns>
        public int GetClientID(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["ClientID"];
        }



        /// <summary>
        /// GetClientID Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original ClientID or EMPTY</returns>
        public int GetClientIDOriginal(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["ClientID", DataRowVersion.Original];
        }


        
    }
}