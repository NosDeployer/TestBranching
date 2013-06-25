using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// LFSRecordPointRepairsGateway
    /// </summary>
    public class LFSRecordPointRepairsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LFSRecordPointRepairsGateway()
            : base("LFS_POINT_REPAIRS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LFSRecordPointRepairsGateway(DataSet data)
            : base(data, "LFS_POINT_REPAIRS")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new TDSLFSRecord();
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
            tableMapping.DataSetTable = "LFS_POINT_REPAIRS";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("RepairSize", "RepairSize");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("Distance", "Distance");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Reinstates", "Reinstates");
            tableMapping.ColumnMappings.Add("LTAtMH", "LTAtMH");
            tableMapping.ColumnMappings.Add("VTAtMH", "VTAtMH");
            tableMapping.ColumnMappings.Add("LinerDistance", "LinerDistance");
            tableMapping.ColumnMappings.Add("Direction", "Direction");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("ExtraRepair", "ExtraRepair");
            tableMapping.ColumnMappings.Add("Cancelled", "Cancelled");
            tableMapping.ColumnMappings.Add("Approved", "Approved");
            tableMapping.ColumnMappings.Add("NotApproved", "NotApproved");
            tableMapping.ColumnMappings.Add("Archived", "Archived");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_POINT_REPAIRS] WHERE (([ID] = @Original_ID) AND ([RefID] =" +
                " @Original_RefID) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([DetailID] = @O" +
                "riginal_DetailID) AND ((@IsNull_RepairSize = 1 AND [RepairSize] IS NULL) OR ([Re" +
                "pairSize] = @Original_RepairSize)) AND ((@IsNull_InstallDate = 1 AND [InstallDat" +
                "e] IS NULL) OR ([InstallDate] = @Original_InstallDate)) AND ((@IsNull_Distance =" +
                " 1 AND [Distance] IS NULL) OR ([Distance] = @Original_Distance)) AND ((@IsNull_C" +
                "ost = 1 AND [Cost] IS NULL) OR ([Cost] = @Original_Cost)) AND ((@IsNull_Reinstat" +
                "es = 1 AND [Reinstates] IS NULL) OR ([Reinstates] = @Original_Reinstates)) AND (" +
                "(@IsNull_LTAtMH = 1 AND [LTAtMH] IS NULL) OR ([LTAtMH] = @Original_LTAtMH)) AND " +
                "((@IsNull_VTAtMH = 1 AND [VTAtMH] IS NULL) OR ([VTAtMH] = @Original_VTAtMH)) AND" +
                " ((@IsNull_LinerDistance = 1 AND [LinerDistance] IS NULL) OR ([LinerDistance] = " +
                "@Original_LinerDistance)) AND ((@IsNull_Direction = 1 AND [Direction] IS NULL) O" +
                "R ([Direction] = @Original_Direction)) AND ((@IsNull_MHShot = 1 AND [MHShot] IS " +
                "NULL) OR ([MHShot] = @Original_MHShot)) AND ((@IsNull_Comments = 1 AND [Comments" +
                "] IS NULL) OR ([Comments] = @Original_Comments)) AND ((@IsNull_Deleted = 1 AND [" +
                "Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) AND ((@IsNull_ExtraRepair " +
                "= 1 AND [ExtraRepair] IS NULL) OR ([ExtraRepair] = @Original_ExtraRepair)) AND (" +
                "(@IsNull_Cancelled = 1 AND [Cancelled] IS NULL) OR ([Cancelled] = @Original_Canc" +
                "elled)) AND ((@IsNull_Approved = 1 AND [Approved] IS NULL) OR ([Approved] = @Ori" +
                "ginal_Approved)) AND ((@IsNull_NotApproved = 1 AND [NotApproved] IS NULL) OR ([N" +
                "otApproved] = @Original_NotApproved)) AND ((@IsNull_Archived = 1 AND [Archived] " +
                "IS NULL) OR ([Archived] = @Original_Archived)))";
            this._adapter.DeleteCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RepairSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RepairSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RepairSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RepairSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Distance", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Distance", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Distance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Distance", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cost", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Reinstates", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Reinstates", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reinstates", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Reinstates", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LTAtMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LTAtMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LTAtMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VTAtMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VTAtMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VTAtMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerDistance", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerDistance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Direction", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Direction", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Direction", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MHShot", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Comments", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Comments", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtraRepair", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraRepair", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cancelled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cancelled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cancelled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Cancelled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Approved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotApproved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotApproved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NotApproved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_POINT_REPAIRS] ([ID], [RefID], [COMPANY_ID], [DetailID], [RepairSize], [InstallDate], [Distance], [Cost], [Reinstates], [LTAtMH], [VTAtMH], [LinerDistance], [Direction], [MHShot], [Comments], [Deleted], [ExtraRepair], [Cancelled], [Approved], [NotApproved], [Archived]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @RepairSize, @InstallDate, @Distance, @Cost, @Reinstates, @LTAtMH, @VTAtMH, @LinerDistance, @Direction, @MHShot, @Comments, @Deleted, @ExtraRepair, @Cancelled, @Approved, @NotApproved, @Archived);
SELECT ID, RefID, COMPANY_ID, DetailID, RepairSize, InstallDate, Distance, Cost, Reinstates, LTAtMH, VTAtMH, LinerDistance, Direction, MHShot, Comments, Deleted, ExtraRepair, Cancelled, Approved, NotApproved, Archived FROM LFS_POINT_REPAIRS WHERE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.InsertCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RepairSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RepairSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Distance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Distance", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reinstates", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Reinstates", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LTAtMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VTAtMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerDistance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Direction", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraRepair", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cancelled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Cancelled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NotApproved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_POINT_REPAIRS] SET [ID] = @ID, [RefID] = @RefID, [COMPANY_ID] =" +
                " @COMPANY_ID, [DetailID] = @DetailID, [RepairSize] = @RepairSize, [InstallDate] " +
                "= @InstallDate, [Distance] = @Distance, [Cost] = @Cost, [Reinstates] = @Reinstat" +
                "es, [LTAtMH] = @LTAtMH, [VTAtMH] = @VTAtMH, [LinerDistance] = @LinerDistance, [D" +
                "irection] = @Direction, [MHShot] = @MHShot, [Comments] = @Comments, [Deleted] = " +
                "@Deleted, [ExtraRepair] = @ExtraRepair, [Cancelled] = @Cancelled, [Approved] = @" +
                "Approved, [NotApproved] = @NotApproved, [Archived] = @Archived WHERE (([ID] = @O" +
                "riginal_ID) AND ([RefID] = @Original_RefID) AND ([COMPANY_ID] = @Original_COMPAN" +
                "Y_ID) AND ([DetailID] = @Original_DetailID) AND ((@IsNull_RepairSize = 1 AND [Re" +
                "pairSize] IS NULL) OR ([RepairSize] = @Original_RepairSize)) AND ((@IsNull_Insta" +
                "llDate = 1 AND [InstallDate] IS NULL) OR ([InstallDate] = @Original_InstallDate)" +
                ") AND ((@IsNull_Distance = 1 AND [Distance] IS NULL) OR ([Distance] = @Original_" +
                "Distance)) AND ((@IsNull_Cost = 1 AND [Cost] IS NULL) OR ([Cost] = @Original_Cos" +
                "t)) AND ((@IsNull_Reinstates = 1 AND [Reinstates] IS NULL) OR ([Reinstates] = @O" +
                "riginal_Reinstates)) AND ((@IsNull_LTAtMH = 1 AND [LTAtMH] IS NULL) OR ([LTAtMH]" +
                " = @Original_LTAtMH)) AND ((@IsNull_VTAtMH = 1 AND [VTAtMH] IS NULL) OR ([VTAtMH" +
                "] = @Original_VTAtMH)) AND ((@IsNull_LinerDistance = 1 AND [LinerDistance] IS NU" +
                "LL) OR ([LinerDistance] = @Original_LinerDistance)) AND ((@IsNull_Direction = 1 " +
                "AND [Direction] IS NULL) OR ([Direction] = @Original_Direction)) AND ((@IsNull_M" +
                "HShot = 1 AND [MHShot] IS NULL) OR ([MHShot] = @Original_MHShot)) AND ((@IsNull_" +
                "Comments = 1 AND [Comments] IS NULL) OR ([Comments] = @Original_Comments)) AND (" +
                "(@IsNull_Deleted = 1 AND [Deleted] IS NULL) OR ([Deleted] = @Original_Deleted)) " +
                "AND ((@IsNull_ExtraRepair = 1 AND [ExtraRepair] IS NULL) OR ([ExtraRepair] = @Or" +
                "iginal_ExtraRepair)) AND ((@IsNull_Cancelled = 1 AND [Cancelled] IS NULL) OR ([C" +
                "ancelled] = @Original_Cancelled)) AND ((@IsNull_Approved = 1 AND [Approved] IS N" +
                "ULL) OR ([Approved] = @Original_Approved)) AND ((@IsNull_NotApproved = 1 AND [No" +
                "tApproved] IS NULL) OR ([NotApproved] = @Original_NotApproved)) AND ((@IsNull_Ar" +
                "chived = 1 AND [Archived] IS NULL) OR ([Archived] = @Original_Archived)));\r\nSELE" +
                "CT ID, RefID, COMPANY_ID, DetailID, RepairSize, InstallDate, Distance, Cost, Rei" +
                "nstates, LTAtMH, VTAtMH, LinerDistance, Direction, MHShot, Comments, Deleted, Ex" +
                "traRepair, Cancelled, Approved, NotApproved, Archived FROM LFS_POINT_REPAIRS WHE" +
                "RE (COMPANY_ID = @COMPANY_ID) AND (ID = @ID) AND (RefID = @RefID)";
            this._adapter.UpdateCommand.CommandType = System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@RepairSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RepairSize", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Distance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Distance", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Reinstates", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Reinstates", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LTAtMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@VTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VTAtMH", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@LinerDistance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Direction", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Direction", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@MHShot", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Comments", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ExtraRepair", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Cancelled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Cancelled", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@NotApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NotApproved", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ID", System.Data.SqlDbType.UniqueIdentifier, 0, System.Data.ParameterDirection.Input, 0, 0, "ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RefID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RefID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_DetailID", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "DetailID", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_RepairSize", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "RepairSize", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_RepairSize", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "RepairSize", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_InstallDate", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_InstallDate", System.Data.SqlDbType.DateTime, 0, System.Data.ParameterDirection.Input, 0, 0, "InstallDate", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Distance", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Distance", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Distance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Distance", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cost", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cost", System.Data.SqlDbType.Money, 0, System.Data.ParameterDirection.Input, 0, 0, "Cost", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Reinstates", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Reinstates", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Reinstates", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Reinstates", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LTAtMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LTAtMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LTAtMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_VTAtMH", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "VTAtMH", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_VTAtMH", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "VTAtMH", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_LinerDistance", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_LinerDistance", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "LinerDistance", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Direction", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Direction", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Direction", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Direction", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_MHShot", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_MHShot", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "MHShot", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Comments", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Comments", System.Data.SqlDbType.NVarChar, 0, System.Data.ParameterDirection.Input, 0, 0, "Comments", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Deleted", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Deleted", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Deleted", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_ExtraRepair", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_ExtraRepair", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "ExtraRepair", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Cancelled", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Cancelled", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Cancelled", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Cancelled", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Approved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Approved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Approved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_NotApproved", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "NotApproved", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_NotApproved", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "NotApproved", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@IsNull_Archived", System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new System.Data.SqlClient.SqlParameter("@Original_Archived", System.Data.SqlDbType.Bit, 0, System.Data.ParameterDirection.Input, 0, 0, "Archived", System.Data.DataRowVersion.Original, false, null, "", "", ""));
            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a point repair (direct to DB)
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <param name="detailId">detailId</param>
        /// <param name="repairSize">repairSize</param>
        /// <param name="installDate">installDate</param>
        /// <param name="distance">distance</param>
        /// <param name="cost">cost</param>
        /// <param name="reinstates">reinstates</param>
        /// <param name="LTAtMH">LTAtMH</param>
        /// <param name="VTAtMH">VTAtMH</param>
        /// <param name="linerDistance">linerDistance</param>
        /// <param name="direction">direction</param>
        /// <param name="mhShot">mhShot</param>
        /// <param name="comments">comments</param>
        /// <param name="deleted">deleted</param>
        /// <param name="extraRepair">extraRepair</param>
        /// <param name="cancelled">cancelled</param>
        /// <param name="approved">approved</param>
        /// <param name="notApproved">notApproved</param>
        /// <param name="archived">archived</param>
        /// <returns>rowsAffected</returns>
        public int Insert(Guid id, int refId, int companyId, string detailId, string repairSize, DateTime? installDate, string distance, decimal? cost, int? reinstates, string LTAtMH, string VTAtMH, string linerDistance, string direction, string mhShot, string comments, bool deleted, bool extraRepair, bool cancelled, bool approved, bool notApproved, bool archived)
        {
            SqlParameter idParameter = new SqlParameter("ID", id);
            SqlParameter refIdParameter = new SqlParameter("RefID", refId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter detailIdParameter = new SqlParameter("DetailID", detailId);
            SqlParameter repairSizeParameter = (repairSize.Trim() != "") ? new SqlParameter("RepairSize", repairSize.Trim()) : new SqlParameter("RepairSize", DBNull.Value);
            SqlParameter installDateParameter = (installDate.HasValue) ? new SqlParameter("InstallDate", installDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter distanceParameter = (distance.Trim() != "") ? new SqlParameter("Distance", distance.Trim()) : new SqlParameter("Distance", DBNull.Value);
            SqlParameter costParameter = (cost.HasValue) ? new SqlParameter("Cost", cost) : new SqlParameter("Cost", DBNull.Value);
            costParameter.SqlDbType = SqlDbType.Money;
            SqlParameter reinstatesParameter = (reinstates.HasValue) ? new SqlParameter("Reinstates", reinstates) : new SqlParameter("Reinstates", DBNull.Value);
            SqlParameter LTAtMHParameter = (LTAtMH.Trim() != "") ? new SqlParameter("LTAtMH", LTAtMH) : new SqlParameter("LTAtMH", DBNull.Value);
            SqlParameter VTAtMHParameter = (VTAtMH.Trim() != "") ? new SqlParameter("VTAtMH", VTAtMH) : new SqlParameter("VTAtMH", DBNull.Value);
            SqlParameter linerDistanceParameter = (linerDistance.Trim() != "") ? new SqlParameter("LinerDistance", linerDistance) : new SqlParameter("LinerDistance", DBNull.Value);
            SqlParameter directionParameter = (direction.Trim() != "") ? new SqlParameter("Direction", direction) : new SqlParameter("Direction", DBNull.Value);
            SqlParameter mhShotParameter = (mhShot.Trim() != "") ? new SqlParameter("MHShot", mhShot) : new SqlParameter("MHShot", DBNull.Value);
            SqlParameter commentsParameter = (comments.Trim() != "") ? new SqlParameter("Comments", comments) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter extraRepairParameter = new SqlParameter("ExtraRepair", extraRepair);
            SqlParameter cancelledParameter = new SqlParameter("Cancelled", cancelled);
            SqlParameter approvedParameter = new SqlParameter("Approved", approved);
            SqlParameter notApprovedParameter = new SqlParameter("NotApproved", notApproved);
            SqlParameter archivedParameter = new SqlParameter("Archived", archived);

            string command = "INSERT INTO [dbo].[LFS_POINT_REPAIRS] ([ID], [RefID], [COMPANY_ID], [DetailID], [RepairSize], [InstallDate], [Distance], [Cost], [Reinstates], [LTAtMH], [VTAtMH], [LinerDistance], [Direction], [MHShot], [Comments], [Deleted], [ExtraRepair], [Cancelled], [Approved], [NotApproved], [Archived]) VALUES (@ID, @RefID, @COMPANY_ID, @DetailID, @RepairSize, @InstallDate, @Distance, @Cost, @Reinstates, @LTAtMH, @VTAtMH, @LinerDistance, @Direction, @MHShot, @Comments, @Deleted, @ExtraRepair, @Cancelled, @Approved, @NotApproved, @Archived)";

            int rowsAffected = (int)ExecuteNonQuery(command, idParameter, refIdParameter, companyIdParameter, detailIdParameter, repairSizeParameter, installDateParameter, distanceParameter, costParameter, reinstatesParameter, LTAtMHParameter, VTAtMHParameter, linerDistanceParameter, directionParameter, mhShotParameter, commentsParameter, deletedParameter, extraRepairParameter, cancelledParameter, approvedParameter, notApprovedParameter, archivedParameter);

            return rowsAffected;
        }



        /// <summary>
        /// Update work (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>
        /// <param name="originalcompanyId">originalcompanyId</param>        
        /// <param name="originalDetailId">originalDetailId</param>
        /// <param name="originalRepairSize">originalRepairSize</param>
        /// <param name="originalInstallDate">originalInstallDate</param>
        /// <param name="originalDistance">originalDistance</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalReinstates">originalReinstates</param>
        /// <param name="originalLTAtMH">originalLTAtMH</param>
        /// <param name="originalVTAtMH">originalVTAtMH</param>
        /// <param name="originalLinerDistance">originalLinerDistance</param>
        /// <param name="originalDirection">originalDirection</param>
        /// <param name="originalMhShot">originalMhShot</param>
        /// <param name="originalComments">originalComments</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalExtraRepair">originalExtraRepair</param>
        /// <param name="originalCancelled">originalCancelled</param>
        /// <param name="originalApproved">originalApproved</param>
        /// <param name="originalNotApproved">originalNotApproved</param>
        /// <param name="originalArchived">originalArchived</param>
        /// 
        /// <param name="newDetailId">newDetailId</param>
        /// <param name="newRepairSize">newRepairSize</param>
        /// <param name="newInstallDate">newInstallDate</param>
        /// <param name="newDistance">newDistance</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newReinstates">newReinstates</param>
        /// <param name="newLTAtMH">newLTAtMH</param>
        /// <param name="newVTAtMH">newVTAtMH</param>
        /// <param name="newLinerDistance">newLinerDistance</param>
        /// <param name="newDirection">newDirection</param>
        /// <param name="newMhShot">newMhShot</param>
        /// <param name="newComments">newComments</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newExtraRepair">newExtraRepair</param>
        /// <param name="newCancelled">newCancelled</param>
        /// <param name="newApproved">newApproved</param>
        /// <param name="newNotApproved">newNotApproved</param>
        /// <param name="newArchived">newArchived</param>
        public int Update(Guid originalId, int originalRefId, int originalCompanyId, string originalDetailId, string originalRepairSize, DateTime? originalInstallDate, string originalDistance, decimal? originalCost, int? originalReinstates, string originalLTAtMH, string originalVTAtMH, string originalLinerDistance, string originalDirection, string originalMhShot, string originalComments, bool originalDeleted, bool originalExtraRepair, bool originalCancelled, bool originalApproved, bool originalNotApproved, bool originalArchived, Guid newId, int newRefId, int newCompanyId,  string newDetailId, string newRepairSize, DateTime? newInstallDate, string newDistance, decimal? newCost, int? newReinstates, string newLTAtMH, string newVTAtMH, string newLinerDistance, string newDirection, string newMhShot, string newComments, bool newDeleted, bool newExtraRepair, bool newCancelled, bool newApproved, bool newNotApproved, bool newArchived)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalDetailIdParameter = new SqlParameter("Original_DetailID", originalDetailId);
            SqlParameter originalRepairSizeParameter = (originalRepairSize.Trim() != "") ? new SqlParameter("Original_RepairSize", originalRepairSize.Trim()) : new SqlParameter("Original_RepairSize", DBNull.Value);
            SqlParameter originalInstallDateParameter = (originalInstallDate.HasValue) ? new SqlParameter("Original_InstallDate", originalInstallDate) : new SqlParameter("Original_InstallDate", DBNull.Value);
            SqlParameter originalDistanceParameter = (originalDistance.Trim() != "") ? new SqlParameter("Original_Distance", originalDistance.Trim()) : new SqlParameter("Original_Distance", DBNull.Value);
            SqlParameter originalCostParameter = (originalCost.HasValue) ? new SqlParameter("Original_Cost", originalCost) : new SqlParameter("Original_Cost", DBNull.Value);
            originalCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalReinstatesParameter = (originalReinstates.HasValue) ? new SqlParameter("Original_Reinstates", originalReinstates) : new SqlParameter("Original_Reinstates", DBNull.Value);
            SqlParameter originalLTAtMHParameter = (originalLTAtMH.Trim() != "") ? new SqlParameter("Original_LTAtMH", originalLTAtMH) : new SqlParameter("Original_LTAtMH", DBNull.Value);
            SqlParameter originalVTAtMHParameter = (originalVTAtMH.Trim() != "") ? new SqlParameter("Original_VTAtMH", originalVTAtMH) : new SqlParameter("Original_VTAtMH", DBNull.Value);
            SqlParameter originalLinerDistanceParameter = (originalLinerDistance.Trim() != "") ? new SqlParameter("Original_LinerDistance", originalLinerDistance) : new SqlParameter("Original_LinerDistance", DBNull.Value);
            SqlParameter originalDirectionParameter = (originalDirection.Trim() != "") ? new SqlParameter("Original_Direction", originalDirection) : new SqlParameter("Original_Direction", DBNull.Value);
            SqlParameter originalMhShotParameter = (originalMhShot.Trim() != "") ? new SqlParameter("Original_MHShot", originalMhShot) : new SqlParameter("Original_MHShot", DBNull.Value);
            SqlParameter originalCommentsParameter = (originalComments.Trim() != "") ? new SqlParameter("Original_Comments", originalComments) : new SqlParameter("Original_Comments", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalExtraRepairParameter = new SqlParameter("Original_ExtraRepair", originalExtraRepair);
            SqlParameter originalCancelledParameter = new SqlParameter("Original_Cancelled", originalCancelled);
            SqlParameter originalApprovedParameter = new SqlParameter("Original_Approved", originalApproved);
            SqlParameter originalNotApprovedParameter = new SqlParameter("Original_NotApproved", originalNotApproved);
            SqlParameter originalArchivedParameter = new SqlParameter("Original_Archived", originalArchived);

            SqlParameter newIdParameter = new SqlParameter("ID", newId);
            SqlParameter newRefIdParameter = new SqlParameter("RefID", newRefId);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newDetailIdParameter = new SqlParameter("DetailID", newDetailId);
            SqlParameter newRepairSizeParameter = (newRepairSize.Trim() != "") ? new SqlParameter("RepairSize", newRepairSize.Trim()) : new SqlParameter("RepairSize", DBNull.Value);
            SqlParameter newInstallDateParameter = (newInstallDate.HasValue) ? new SqlParameter("InstallDate", newInstallDate) : new SqlParameter("InstallDate", DBNull.Value);
            SqlParameter newDistanceParameter = (newDistance.Trim() != "") ? new SqlParameter("Distance", newDistance.Trim()) : new SqlParameter("Distance", DBNull.Value);
            SqlParameter newCostParameter = (newCost.HasValue) ? new SqlParameter("Cost", newCost) : new SqlParameter("Cost", DBNull.Value);
            newCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newReinstatesParameter = (newReinstates.HasValue) ? new SqlParameter("Reinstates", newReinstates) : new SqlParameter("Reinstates", DBNull.Value);
            SqlParameter newLTAtMHParameter = (newLTAtMH.Trim() != "") ? new SqlParameter("LTAtMH", newLTAtMH) : new SqlParameter("LTAtMH", DBNull.Value);
            SqlParameter newVTAtMHParameter = (newVTAtMH.Trim() != "") ? new SqlParameter("VTAtMH", newVTAtMH) : new SqlParameter("VTAtMH", DBNull.Value);
            SqlParameter newLinerDistanceParameter = (newLinerDistance.Trim() != "") ? new SqlParameter("LinerDistance", newLinerDistance) : new SqlParameter("LinerDistance", DBNull.Value);
            SqlParameter newDirectionParameter = (newDirection.Trim() != "") ? new SqlParameter("Direction", newDirection) : new SqlParameter("Direction", DBNull.Value);
            SqlParameter newMhShotParameter = (newMhShot.Trim() != "") ? new SqlParameter("MHShot", newMhShot) : new SqlParameter("MHShot", DBNull.Value);
            SqlParameter newCommentsParameter = (newComments.Trim() != "") ? new SqlParameter("Comments", newComments) : new SqlParameter("Comments", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newExtraRepairParameter = new SqlParameter("ExtraRepair", newExtraRepair);
            SqlParameter newCancelledParameter = new SqlParameter("Cancelled", newCancelled);
            SqlParameter newApprovedParameter = new SqlParameter("Approved", newApproved);
            SqlParameter newNotApprovedParameter = new SqlParameter("NotApproved", newNotApproved);
            SqlParameter newArchivedParameter = new SqlParameter("Archived", newArchived);


            string command = "UPDATE [dbo].[LFS_POINT_REPAIRS] SET " +
                "[DetailID] = @DetailID, [RepairSize] = @RepairSize, [InstallDate] " +
                "= @InstallDate, [Distance] = @Distance, [Cost] = @Cost, [Reinstates] = @Reinstat" +
                "es, [LTAtMH] = @LTAtMH, [VTAtMH] = @VTAtMH, [LinerDistance] = @LinerDistance, [D" +
                "irection] = @Direction, [MHShot] = @MHShot, [Comments] = @Comments, [Deleted] = " +
                "@Deleted, [ExtraRepair] = @ExtraRepair, [Cancelled] = @Cancelled, [Approved] = @" +
                "Approved, [NotApproved] = @NotApproved, [Archived] = @Archived "+
                "WHERE (" +
                "([RefID] = @Original_RefID) AND ([ID] = @Original_ID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, originalDetailIdParameter, originalRepairSizeParameter, originalInstallDateParameter, originalDistanceParameter, originalCostParameter, originalReinstatesParameter, originalLTAtMHParameter, originalVTAtMHParameter, originalLinerDistanceParameter, originalDirectionParameter, originalMhShotParameter, originalCommentsParameter, originalDeletedParameter, originalExtraRepairParameter, originalCancelledParameter, originalApprovedParameter, originalNotApprovedParameter, originalArchivedParameter, newIdParameter, newRefIdParameter, newCompanyIdParameter, newDetailIdParameter, newRepairSizeParameter, newInstallDateParameter, newDistanceParameter, newCostParameter, newReinstatesParameter, newLTAtMHParameter, newVTAtMHParameter, newLinerDistanceParameter, newDirectionParameter, newMhShotParameter, newCommentsParameter, newDeletedParameter, newExtraRepairParameter, newCancelledParameter, newApprovedParameter, newNotApprovedParameter, newArchivedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// Delete service request (direct to DB)
        /// </summary>
        /// <param name="originalId">originalId</param>
        /// <param name="originalRefId">originalRefId</param>        
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(Guid originalId, int originalRefId, int originalCompanyId)
        {
            SqlParameter originalIdParameter = new SqlParameter("Original_ID", originalId);
            SqlParameter originalRefIdParameter = new SqlParameter("Original_RefID", originalRefId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_POINT_REPAIRS] SET  [Deleted] = @Deleted  " +
                             " WHERE ( ([ID] = @Original_ID) AND ([RefID] = @Original_RefID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalIdParameter, originalRefIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }
    }
}
