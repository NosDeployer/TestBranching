using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectTechnicalGateway
    /// </summary>
    public class ProjectTechnicalGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTechnicalGateway()
            : base("LFS_PROJECT_TECHNICAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTechnicalGateway(DataSet data)
            : base(data, "LFS_PROJECT_TECHNICAL")
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
            tableMapping.DataSetTable = "LFS_PROJECT_TECHNICAL";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("Drawings", "Drawings");
            tableMapping.ColumnMappings.Add("Video", "Video");
            tableMapping.ColumnMappings.Add("GroundConditions", "GroundConditions");
            tableMapping.ColumnMappings.Add("GrounConditionsNotes", "GrounConditionsNotes");
            tableMapping.ColumnMappings.Add("ReviewVideo", "ReviewVideo");
            tableMapping.ColumnMappings.Add("StrangeConfigurations", "StrangeConfigurations");
            tableMapping.ColumnMappings.Add("StrangeConfigurationsNotes", "StrangeConfigurationsNotes");
            tableMapping.ColumnMappings.Add("FurtherObservations", "FurtherObservations");
            tableMapping.ColumnMappings.Add("RestrictiveFactors", "RestrictiveFactors");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_PROJECT_TECHNICAL] WHERE (([ProjectID] = @Original_ProjectID) AND ([Drawings] = @Original_Drawings) AND ([Video] = @Original_Video) AND ([GroundConditions] = @Original_GroundConditions) AND ([ReviewVideo] = @Original_ReviewVideo) AND ([StrangeConfigurations] = @Original_StrangeConfigurations) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Drawings", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Drawings", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Video", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Video", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GroundConditions", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GroundConditions", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReviewVideo", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ReviewVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StrangeConfigurations", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StrangeConfigurations", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_PROJECT_TECHNICAL] ([ProjectID], [Drawings], [Video], [GroundConditions], [GrounConditionsNotes], [ReviewVideo], [StrangeConfigurations], [StrangeConfigurationsNotes], [FurtherObservations], [RestrictiveFactors], [COMPANY_ID]) VALUES (@ProjectID, @Drawings, @Video, @GroundConditions, @GrounConditionsNotes, @ReviewVideo, @StrangeConfigurations, @StrangeConfigurationsNotes, @FurtherObservations, @RestrictiveFactors, @COMPANY_ID);
SELECT ProjectID, Drawings, Video, GroundConditions, GrounConditionsNotes, ReviewVideo, StrangeConfigurations, StrangeConfigurationsNotes, FurtherObservations, RestrictiveFactors, COMPANY_ID FROM LFS_PROJECT_TECHNICAL WHERE (ProjectID = @ProjectID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Drawings", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Drawings", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Video", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Video", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GroundConditions", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GroundConditions", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GrounConditionsNotes", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "GrounConditionsNotes", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewVideo", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ReviewVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StrangeConfigurations", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StrangeConfigurations", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StrangeConfigurationsNotes", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "StrangeConfigurationsNotes", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FurtherObservations", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "FurtherObservations", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestrictiveFactors", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "RestrictiveFactors", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_PROJECT_TECHNICAL] SET [ProjectID] = @ProjectID, [Drawings] = @Drawings, [Video] = @Video, [GroundConditions] = @GroundConditions, [GrounConditionsNotes] = @GrounConditionsNotes, [ReviewVideo] = @ReviewVideo, [StrangeConfigurations] = @StrangeConfigurations, [StrangeConfigurationsNotes] = @StrangeConfigurationsNotes, [FurtherObservations] = @FurtherObservations, [RestrictiveFactors] = @RestrictiveFactors, [COMPANY_ID] = @COMPANY_ID WHERE (([ProjectID] = @Original_ProjectID) AND ([Drawings] = @Original_Drawings) AND ([Video] = @Original_Video) AND ([GroundConditions] = @Original_GroundConditions) AND ([ReviewVideo] = @Original_ReviewVideo) AND ([StrangeConfigurations] = @Original_StrangeConfigurations) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT ProjectID, Drawings, Video, GroundConditions, GrounConditionsNotes, ReviewVideo, StrangeConfigurations, StrangeConfigurationsNotes, FurtherObservations, RestrictiveFactors, COMPANY_ID FROM LFS_PROJECT_TECHNICAL WHERE (ProjectID = @ProjectID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Drawings", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Drawings", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Video", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Video", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GroundConditions", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GroundConditions", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@GrounConditionsNotes", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "GrounConditionsNotes", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ReviewVideo", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ReviewVideo", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StrangeConfigurations", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StrangeConfigurations", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@StrangeConfigurationsNotes", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "StrangeConfigurationsNotes", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@FurtherObservations", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "FurtherObservations", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RestrictiveFactors", System.Data.SqlDbType.NText, 0, System.Data.ParameterDirection.Input, 0, 0, "RestrictiveFactors", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ProjectID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ProjectID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Drawings", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Drawings", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Video", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Video", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_GroundConditions", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "GroundConditions", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ReviewVideo", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ReviewVideo", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_StrangeConfigurations", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "StrangeConfigurations", System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTTECHNICALGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectTechnicalGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDrawings
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Drawings</returns>
        public bool GetDrawings(int projectId)
        {
            return (bool)GetRow(projectId)["Drawings"];
        }



        /// <summary>
        /// GetVideo
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>Video</returns>
        public bool GetVideo(int projectId)
        {
            return (bool)GetRow(projectId)["Video"];
        }



        /// <summary>
        /// GetGroundConditions
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>GroundConditions</returns>
        public bool GetGroundConditions(int projectId)
        {
            return (bool)GetRow(projectId)["GroundConditions"];
        }



        /// <summary>
        /// GetReviewVideo
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>ReviewVideo</returns>
        public bool GetReviewVideo(int projectId)
        {
            return (bool)GetRow(projectId)["ReviewVideo"];
        }



        /// <summary>
        /// GetStrangeConfigurations
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>StrangeConfigurations</returns>
        public bool GetStrangeConfigurations(int projectId)
        {
            return (bool)GetRow(projectId)["StrangeConfigurations"];
        }



        /// <summary>
        /// GetGrounConditionsNotes
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>GrounConditionsNotes or EMPTY</returns>
        public string GetGrounConditionsNotes(int projectId)
        {
            if (GetRow(projectId).IsNull("GrounConditionsNotes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["GrounConditionsNotes"];
            }
        }



        /// <summary>
        /// GetStrangeConfigurationsNotes
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>StrangeConfigurationsNotes  and EMPTY</returns>
        public string GetStrangeConfigurationsNotes(int projectId)
        {
            if (GetRow(projectId).IsNull("StrangeConfigurationsNotes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["StrangeConfigurationsNotes"];
            }
        }



        /// <summary>
        /// GetFurtherObservations
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>FurtherObservations or EMPTY</returns>
        public string GetFurtherObservations(int projectId)
        {
            if (GetRow(projectId).IsNull("FurtherObservations"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["FurtherObservations"];
            }
        }



        /// <summary>
        /// GetRestrictiveFactors
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RestrictiveFactor or EMPTY</returns>
        public string GetRestrictiveFactors(int projectId)
        {
            if (GetRow(projectId).IsNull("RestrictiveFactors"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RestrictiveFactors"];
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
