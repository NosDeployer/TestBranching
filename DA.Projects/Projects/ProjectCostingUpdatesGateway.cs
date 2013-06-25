using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectCostingUpdatesGateway
    /// </summary>
    public class ProjectCostingUpdatesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectCostingUpdatesGateway()
            : base("LFS_PROJECT_COSTING_UPDATES")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectCostingUpdatesGateway(DataSet data)
            : base(data, "LFS_PROJECT_COSTING_UPDATES")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTDS();
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
            tableMapping.DataSetTable = "LFS_PROJECT_COSTING_UPDATES";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("ExtrasToDate", "ExtrasToDate");
            tableMapping.ColumnMappings.Add("CostsIncurred", "CostsIncurred");
            tableMapping.ColumnMappings.Add("CostToComplete", "CostToComplete");
            tableMapping.ColumnMappings.Add("OriginalProfitEstimated", "OriginalProfitEstimated");
            tableMapping.ColumnMappings.Add("InvoicedToDate", "InvoicedToDate");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_COSTING_UPDATES] WHERE (([ProjectID] = @Original_ProjectID) AND ((@IsNull_ExtrasToDate = 1 AND [ExtrasToDate] IS NULL) OR ([ExtrasToDate] = @Original_ExtrasToDate)) AND ((@IsNull_CostsIncurred = 1 AND [CostsIncurred] IS NULL) OR ([CostsIncurred] = @Original_CostsIncurred)) AND ((@IsNull_CostToComplete = 1 AND [CostToComplete] IS NULL) OR ([CostToComplete] = @Original_CostToComplete)) AND ((@IsNull_OriginalProfitEstimated = 1 AND [OriginalProfitEstimated] IS NULL) OR ([OriginalProfitEstimated] = @Original_OriginalProfitEstimated)) AND ((@IsNull_InvoicedToDate = 1 AND [InvoicedToDate] IS NULL) OR ([InvoicedToDate] = @Original_InvoicedToDate)) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtrasToDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtrasToDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtrasToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtrasToDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CostsIncurred", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CostsIncurred", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CostsIncurred", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostsIncurred", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CostToComplete", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CostToComplete", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CostToComplete", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostToComplete", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_OriginalProfitEstimated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "OriginalProfitEstimated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OriginalProfitEstimated", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "OriginalProfitEstimated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InvoicedToDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InvoicedToDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InvoicedToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InvoicedToDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_COSTING_UPDATES] ([ProjectID], [ExtrasToDate], [CostsIncurred], [CostToComplete], [OriginalProfitEstimated], [InvoicedToDate], [COMPANY_ID]) VALUES (@ProjectID, @ExtrasToDate, @CostsIncurred, @CostToComplete, @OriginalProfitEstimated, @InvoicedToDate, @COMPANY_ID);
SELECT ProjectID, ExtrasToDate, CostsIncurred, CostToComplete, OriginalProfitEstimated, InvoicedToDate, COMPANY_ID FROM LFS_PROJECT_COSTING_UPDATES WHERE (ProjectID = @ProjectID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtrasToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtrasToDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CostsIncurred", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostsIncurred", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CostToComplete", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostToComplete", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OriginalProfitEstimated", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "OriginalProfitEstimated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoicedToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InvoicedToDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_COSTING_UPDATES] SET [ProjectID] = @ProjectID, [ExtrasToDate] = @ExtrasToDate, [CostsIncurred] = @CostsIncurred, [CostToComplete] = @CostToComplete, [OriginalProfitEstimated] = @OriginalProfitEstimated, [InvoicedToDate] = @InvoicedToDate, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectID] = @Original_ProjectID) AND ((@IsNull_ExtrasToDate = 1 AND [ExtrasToDate] IS NULL) OR ([ExtrasToDate] = @Original_ExtrasToDate)) AND ((@IsNull_CostsIncurred = 1 AND [CostsIncurred] IS NULL) OR ([CostsIncurred] = @Original_CostsIncurred)) AND ((@IsNull_CostToComplete = 1 AND [CostToComplete] IS NULL) OR ([CostToComplete] = @Original_CostToComplete)) AND ((@IsNull_OriginalProfitEstimated = 1 AND [OriginalProfitEstimated] IS NULL) OR ([OriginalProfitEstimated] = @Original_OriginalProfitEstimated)) AND ((@IsNull_InvoicedToDate = 1 AND [InvoicedToDate] IS NULL) OR ([InvoicedToDate] = @Original_InvoicedToDate)) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectID, ExtrasToDate, CostsIncurred, CostToComplete, OriginalProfitEstimated, InvoicedToDate, COMPANY_ID FROM LFS_PROJECT_COSTING_UPDATES WHERE (ProjectID = @ProjectID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtrasToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtrasToDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CostsIncurred", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostsIncurred", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@CostToComplete", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostToComplete", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@OriginalProfitEstimated", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "OriginalProfitEstimated", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InvoicedToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InvoicedToDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtrasToDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtrasToDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtrasToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtrasToDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CostsIncurred", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CostsIncurred", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CostsIncurred", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostsIncurred", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_CostToComplete", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "CostToComplete", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_CostToComplete", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "CostToComplete", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_OriginalProfitEstimated", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "OriginalProfitEstimated", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_OriginalProfitEstimated", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "OriginalProfitEstimated", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InvoicedToDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InvoicedToDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InvoicedToDate", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "InvoicedToDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByProjectId
        /// </summary>
        /// <param name="projectId">ProjectId filter</param>
        /// <returns>Data</returns>
        public DataSet LoadByProjectId(int projectId)
        {
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTCOSTINGUPDATESGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId));
            return Data;
        }



        /// <summary>
        /// Get a single project. If not exists, raise an exception.
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Project row</returns>
        public DataRow GetRow(int projectId)
        {
            string filter = string.Format("ProjectID = {0}", projectId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectCostingUpdatesGateway.GetRow");
            }
        }



        /// <summary>
        /// GetExtrasToDate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ExtrasToDate</returns>
        public decimal? GetExtrasToDate(int projectId)
        {
            if (GetRow(projectId).IsNull("ExtrasToDate"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["ExtrasToDate"];
            }
        }



        /// <summary>
        /// GetCostsIncurred
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>CostsIncurred</returns>
        public decimal? GetCostsIncurred(int projectId)
        {
            if (GetRow(projectId).IsNull("CostsIncurred"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["CostsIncurred"];
            }
        }



        /// <summary>
        /// GetCostToComplete
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>CostToComplete</returns>
        public decimal? GetCostToComplete(int projectId)
        {
            if (GetRow(projectId).IsNull("CostToComplete"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["CostToComplete"];
            }
        }



        /// <summary>
        /// GetOriginalProfitEstimated
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>OriginalProfitEstimated</returns>
        public decimal? GetOriginalProfitEstimated(int projectId)
        {
            if (GetRow(projectId).IsNull("OriginalProfitEstimated"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["OriginalProfitEstimated"];
            }
        }



        /// <summary>
        /// GetInvoicedToDate
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>InvoicedToDate</returns>
        public decimal? GetInvoicedToDate(int projectId)
        {
            if (GetRow(projectId).IsNull("InvoicedToDate"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["InvoicedToDate"];
            }
        }

            
        
        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
            {
                try
                {
                    Adapter.Update(Data, this.TableName);
                }
                catch (DBConcurrencyException dBConcurrencyException)
                {
                    throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
                }
                catch (SqlException sqlException)
                {
                    byte severityLevel = sqlException.Class;
                    if (severityLevel <= 16)
                    {
                        throw new Exception("Low severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if ((severityLevel >= 17) && (severityLevel <= 19))
                    {
                        throw new Exception("Mid severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                    if (severityLevel >= 20)
                    {
                        throw new Exception("High severity error. Your operation has been cancelled.  SQL Error " + severityLevel + ".");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception("Unknow error. Your operation has been cancelled.", e);
                }
            }
        }



    }
}

