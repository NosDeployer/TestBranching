using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeSectionGateway
    /// </summary>
    public class ProjectTimeSectionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeSectionGateway()
            : base("LFS_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeSectionGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME_SECTION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ProjectTimeTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization
            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "LFS_PROJECT_TIME_SECTION";
            tableMapping.ColumnMappings.Add("ProjectTimeID", "ProjectTimeID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("Completed", "Completed");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("PercentageOpened", "PercentageOpened");
            tableMapping.ColumnMappings.Add("PercentageBrushed", "PercentageBrushed");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_TIME_SECTION] WHERE (([ProjectTimeID] = @Original_ProjectTimeID) AND ([SectionID] = @Original_SectionID) AND ([FlowOrderID] = @Original_FlowOrderID) AND ([Completed] = @Original_Completed) AND ([Date_] = @Original_Date_) AND ([PercentageOpened] = @Original_PercentageOpened) AND ([PercentageBrushed] = @Original_PercentageBrushed) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Completed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PercentageOpened", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageOpened", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PercentageBrushed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageBrushed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_TIME_SECTION] ([ProjectTimeID], [SectionID], [FlowOrderID], [Completed], [Date_], [PercentageOpened], [PercentageBrushed], [Deleted], [COMPANY_ID]) VALUES (@ProjectTimeID, @SectionID, @FlowOrderID, @Completed, @Date_, @PercentageOpened, @PercentageBrushed, @Deleted, @COMPANY_ID);
SELECT ProjectTimeID, SectionID, FlowOrderID, Completed, Date_, PercentageOpened, PercentageBrushed, Deleted, COMPANY_ID FROM LFS_PROJECT_TIME_SECTION WHERE (ProjectTimeID = @ProjectTimeID) AND (SectionID = @SectionID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Completed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PercentageOpened", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageOpened", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PercentageBrushed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageBrushed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_TIME_SECTION] SET [ProjectTimeID] = @ProjectTimeID, [SectionID] = @SectionID, [FlowOrderID] = @FlowOrderID, [Completed] = @Completed, [Date_] = @Date_, [PercentageOpened] = @PercentageOpened, [PercentageBrushed] = @PercentageBrushed, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectTimeID] = @Original_ProjectTimeID) AND ([SectionID] = @Original_SectionID) AND ([FlowOrderID] = @Original_FlowOrderID) AND ([Completed] = @Original_Completed) AND ([Date_] = @Original_Date_) AND ([PercentageOpened] = @Original_PercentageOpened) AND ([PercentageBrushed] = @Original_PercentageBrushed) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectTimeID, SectionID, FlowOrderID, Completed, Date_, PercentageOpened, PercentageBrushed, Deleted, COMPANY_ID FROM LFS_PROJECT_TIME_SECTION WHERE (ProjectTimeID = @ProjectTimeID) AND (SectionID = @SectionID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Completed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PercentageOpened", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageOpened", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PercentageBrushed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageBrushed", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectTimeID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectTimeID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SectionID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SectionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_FlowOrderID", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "FlowOrderID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Completed", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Completed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PercentageOpened", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageOpened", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PercentageBrushed", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PercentageBrushed", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Update
        /// </summary>
        public void Update()
        {
            DataTable tableChanges = Table.GetChanges();

            if (tableChanges == null) return;

            try
            {
                DB.Open();
                DB.BeginTransaction();

                Adapter.InsertCommand.Transaction = DB.Transaction;
                Adapter.UpdateCommand.Transaction = DB.Transaction;
                Adapter.DeleteCommand.Transaction = DB.Transaction;

                if ((tableChanges != null) && (tableChanges.Rows.Count > 0))
                {
                    Adapter.Update(tableChanges);
                }

                DB.CommitTransaction();
            }
            catch (DBConcurrencyException dBConcurrencyException)
            {
                DB.RollbackTransaction();
                throw new Exception("Concurrency error: Another user already updated the data you are working on.  Your operation has been cancelled.", dBConcurrencyException);
            }
            catch (SqlException sqlException)
            {
                DB.RollbackTransaction();
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
                DB.RollbackTransaction();
                throw new Exception("Unknow error. Your operation has been cancelled.", e);
            }
            finally
            {
                DB.Close();
            }
        }



    }
}