using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ActualCosts
{
    /// <summary>
    ///  ActualCostsInformationInsuranceCostsBasicInformationGateway
    /// </summary>
    public class  ActualCostsInformationInsuranceCostsBasicInformationGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public  ActualCostsInformationInsuranceCostsBasicInformationGateway()
            : base("InsuranceCostsBasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public  ActualCostsInformationInsuranceCostsBasicInformationGateway(DataSet data)
            : base(data, "InsuranceCostsBasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ActualCostsInformationTDS();
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
            tableMapping.DataSetTable = "InsuranceCostsBasicInformation";
            tableMapping.DataSetTable = "InsuranceCostsBasicInformation";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("InsuranceCompanyID", "InsuranceCompanyID");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("RateCad", "RateCad");
            tableMapping.ColumnMappings.Add("RateUsd", "RateUsd");
            tableMapping.ColumnMappings.Add("Comment", "Comment");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Insurance", "Insurance");
            tableMapping.ColumnMappings.Add("Client", "Client");
            tableMapping.ColumnMappings.Add("Project", "Project");            
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
            FillDataWithStoredProcedure("LFS_LABOURHOURS_ACTUALCOSTSINFORMATIONINSURANCECOSTSBASICINFORMATIONGATEWAY_LOADBYPROJECTIDREFID", new SqlParameter("@projectId", projectId), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.ActualCosts.ActualCostsInformationInsuranceCostsBasicInformationGateway.GetRow");
            }
        }



        /// <summary>
        /// GetInsuranceID
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>InsuranceID or EMPTY</returns>
        public int GetInsuranceID(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["InsuranceCompanyID"];
        }



        /// <summary>
        /// GetInsuranceID Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original InsuranceID or EMPTY</returns>
        public int GetInsuranceIDOriginal(int projectId, int refId)
        {
            return (int)GetRow(projectId, refId)["InsuranceCompanyID", DataRowVersion.Original];
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
        /// GetInsurance
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Insurance or EMPTY</returns>
        public string GetInsurance(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull("Insurance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Insurance"];
            }
        }



        /// <summary>
        /// GetInsurance Original
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <param name="refId">refId</param>        
        /// <returns>Original Insurance or EMPTY</returns>
        public string GetInsuranceOriginal(int projectId, int refId)
        {
            if (GetRow(projectId, refId).IsNull(Table.Columns["Insurance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId, refId)["Insurance", DataRowVersion.Original];
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