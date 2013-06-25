using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Projects.Projects
{
    /// <summary>
    /// ProjectTermsPOGateway
    /// </summary>
    public class ProjectTermsPOGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTermsPOGateway()
            : base("LFS_PROJECT_TERMS")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTermsPOGateway(DataSet data)
            : base(data, "LFS_PROJECT_TERMS")
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
            tableMapping.DataSetTable = "LFS_PROJECT_TERMS";
            tableMapping.ColumnMappings.Add("ProjectID", "ProjectID");
            tableMapping.ColumnMappings.Add("LiquidatedDamage", "LiquidatedDamage");
            tableMapping.ColumnMappings.Add("LiquidatedRate", "LiquidatedRate");
            tableMapping.ColumnMappings.Add("LiquidatedUnit", "LiquidatedUnit");
            tableMapping.ColumnMappings.Add("RelationshipClientWorkedBefore", "RelationshipClientWorkedBefore");
            tableMapping.ColumnMappings.Add("RelationshipClientQuirks", "RelationshipClientQuirks");
            tableMapping.ColumnMappings.Add("RelationshipClientPromises", "RelationshipClientPromises");
            tableMapping.ColumnMappings.Add("RelationshipClientPromisesNotes", "RelationshipClientPromisesNotes");
            tableMapping.ColumnMappings.Add("RelationshipWaterObtain", "RelationshipWaterObtain");
            tableMapping.ColumnMappings.Add("RelationshipMaterialDispose", "RelationshipMaterialDispose");
            tableMapping.ColumnMappings.Add("RelationshipRequireRPZ", "RelationshipRequireRPZ");
            tableMapping.ColumnMappings.Add("RelationshipStandardHydrantFitting", "RelationshipStandardHydrantFitting");
            tableMapping.ColumnMappings.Add("RelationshipPreConstructionMeeting", "RelationshipPreConstructionMeeting");
            tableMapping.ColumnMappings.Add("RelationshipSpecificMeetingLocation", "RelationshipSpecificMeetingLocation");
            tableMapping.ColumnMappings.Add("RelationshipSpecificMeetingLocationNotes", "RelationshipSpecificMeetingLocationNotes");
            tableMapping.ColumnMappings.Add("RelationshipVehicleAccess", "RelationshipVehicleAccess");
            tableMapping.ColumnMappings.Add("RelationshipVehicleAccessNotes", "RelationshipVehicleAccessNotes");
            tableMapping.ColumnMappings.Add("RelationshipProjectOutcome", "RelationshipProjectOutcome");
            tableMapping.ColumnMappings.Add("RelationshipSpecificReportingNeeds", "RelationshipSpecificReportingNeeds");
            tableMapping.ColumnMappings.Add("PurchaseOrderNumber", "PurchaseOrderNumber");
            tableMapping.ColumnMappings.Add("PurchaseOrderAttached", "PurchaseOrderAttached");
            tableMapping.ColumnMappings.Add("PurchaseOrderNotes", "PurchaseOrderNotes");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("VehicleAccessRoad", "VehicleAccessRoad");
            tableMapping.ColumnMappings.Add("VehicleAccessEasement", "VehicleAccessEasement");
            tableMapping.ColumnMappings.Add("VehicleAccessOther", "VehicleAccessOther");

            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_PROJECT_TERMS] WHERE (([ProjectID] = @Original_ProjectID) " +
                "AND ([LiquidatedDamage] = @Original_LiquidatedDamage) AND ((@IsNull_LiquidatedRa" +
                "te = 1 AND [LiquidatedRate] IS NULL) OR ([LiquidatedRate] = @Original_Liquidated" +
                "Rate)) AND ((@IsNull_LiquidatedUnit = 1 AND [LiquidatedUnit] IS NULL) OR ([Liqui" +
                "datedUnit] = @Original_LiquidatedUnit)) AND ([RelationshipClientWorkedBefore] = " +
                "@Original_RelationshipClientWorkedBefore) AND ([RelationshipClientPromises] = @O" +
                "riginal_RelationshipClientPromises) AND ((@IsNull_RelationshipWaterObtain = 1 AN" +
                "D [RelationshipWaterObtain] IS NULL) OR ([RelationshipWaterObtain] = @Original_R" +
                "elationshipWaterObtain)) AND ((@IsNull_RelationshipMaterialDispose = 1 AND [Rela" +
                "tionshipMaterialDispose] IS NULL) OR ([RelationshipMaterialDispose] = @Original_" +
                "RelationshipMaterialDispose)) AND ([RelationshipRequireRPZ] = @Original_Relation" +
                "shipRequireRPZ) AND ((@IsNull_RelationshipStandardHydrantFitting = 1 AND [Relati" +
                "onshipStandardHydrantFitting] IS NULL) OR ([RelationshipStandardHydrantFitting] " +
                "= @Original_RelationshipStandardHydrantFitting)) AND ([RelationshipPreConstructi" +
                "onMeeting] = @Original_RelationshipPreConstructionMeeting) AND ([RelationshipSpe" +
                "cificMeetingLocation] = @Original_RelationshipSpecificMeetingLocation) AND ((@Is" +
                "Null_RelationshipVehicleAccess = 1 AND [RelationshipVehicleAccess] IS NULL) OR (" +
                "[RelationshipVehicleAccess] = @Original_RelationshipVehicleAccess)) AND ((@IsNul" +
                "l_PurchaseOrderNumber = 1 AND [PurchaseOrderNumber] IS NULL) OR ([PurchaseOrderN" +
                "umber] = @Original_PurchaseOrderNumber)) AND ([PurchaseOrderAttached] = @Origina" +
                "l_PurchaseOrderAttached) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Vehicle" +
                "AccessRoad] = @Original_VehicleAccessRoad) AND ([VehicleAccessEasement] = @Origi" +
                "nal_VehicleAccessEasement) AND ([VehicleAccessOther] = @Original_VehicleAccessOt" +
                "her))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiquidatedDamage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedDamage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LiquidatedRate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedRate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiquidatedRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedRate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LiquidatedUnit", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedUnit", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiquidatedUnit", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedUnit", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipClientWorkedBefore", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientWorkedBefore", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipClientPromises", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientPromises", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipWaterObtain", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipWaterObtain", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipWaterObtain", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipWaterObtain", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipMaterialDispose", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipMaterialDispose", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipMaterialDispose", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipMaterialDispose", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipRequireRPZ", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipRequireRPZ", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipStandardHydrantFitting", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipStandardHydrantFitting", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipStandardHydrantFitting", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipStandardHydrantFitting", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipPreConstructionMeeting", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipPreConstructionMeeting", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipSpecificMeetingLocation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificMeetingLocation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipVehicleAccess", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccess", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipVehicleAccess", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccess", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PurchaseOrderNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PurchaseOrderNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PurchaseOrderAttached", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderAttached", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VehicleAccessRoad", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessRoad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VehicleAccessEasement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessEasement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VehicleAccessOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessOther", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = "INSERT INTO [dbo].[LFS_PROJECT_TERMS] ([ProjectID], [LiquidatedDamage], [Liquidat" +
                "edRate], [LiquidatedUnit], [RelationshipClientWorkedBefore], [RelationshipClient" +
                "Quirks], [RelationshipClientPromises], [RelationshipClientPromisesNotes], [Relat" +
                "ionshipWaterObtain], [RelationshipMaterialDispose], [RelationshipRequireRPZ], [R" +
                "elationshipStandardHydrantFitting], [RelationshipPreConstructionMeeting], [Relat" +
                "ionshipSpecificMeetingLocation], [RelationshipSpecificMeetingLocationNotes], [Re" +
                "lationshipVehicleAccess], [RelationshipVehicleAccessNotes], [RelationshipProject" +
                "Outcome], [RelationshipSpecificReportingNeeds], [PurchaseOrderNumber], [Purchase" +
                "OrderAttached], [PurchaseOrderNotes], [COMPANY_ID], [VehicleAccessRoad], [Vehicl" +
                "eAccessEasement], [VehicleAccessOther]) VALUES (@ProjectID, @LiquidatedDamage, @" +
                "LiquidatedRate, @LiquidatedUnit, @RelationshipClientWorkedBefore, @RelationshipC" +
                "lientQuirks, @RelationshipClientPromises, @RelationshipClientPromisesNotes, @Rel" +
                "ationshipWaterObtain, @RelationshipMaterialDispose, @RelationshipRequireRPZ, @Re" +
                "lationshipStandardHydrantFitting, @RelationshipPreConstructionMeeting, @Relation" +
                "shipSpecificMeetingLocation, @RelationshipSpecificMeetingLocationNotes, @Relatio" +
                "nshipVehicleAccess, @RelationshipVehicleAccessNotes, @RelationshipProjectOutcome" +
                ", @RelationshipSpecificReportingNeeds, @PurchaseOrderNumber, @PurchaseOrderAttac" +
                "hed, @PurchaseOrderNotes, @COMPANY_ID, @VehicleAccessRoad, @VehicleAccessEasemen" +
                "t, @VehicleAccessOther);\r\nSELECT ProjectID, LiquidatedDamage, LiquidatedRate, Li" +
                "quidatedUnit, RelationshipClientWorkedBefore, RelationshipClientQuirks, Relation" +
                "shipClientPromises, RelationshipClientPromisesNotes, RelationshipWaterObtain, Re" +
                "lationshipMaterialDispose, RelationshipRequireRPZ, RelationshipStandardHydrantFi" +
                "tting, RelationshipPreConstructionMeeting, RelationshipSpecificMeetingLocation, " +
                "RelationshipSpecificMeetingLocationNotes, RelationshipVehicleAccess, Relationshi" +
                "pVehicleAccessNotes, RelationshipProjectOutcome, RelationshipSpecificReportingNe" +
                "eds, PurchaseOrderNumber, PurchaseOrderAttached, PurchaseOrderNotes, COMPANY_ID," +
                " VehicleAccessRoad, VehicleAccessEasement, VehicleAccessOther FROM LFS_PROJECT_T" +
                "ERMS WHERE (ProjectID = @ProjectID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiquidatedDamage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedDamage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiquidatedRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedRate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiquidatedUnit", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedUnit", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientWorkedBefore", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientWorkedBefore", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientQuirks", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientQuirks", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientPromises", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientPromises", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientPromisesNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientPromisesNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipWaterObtain", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipWaterObtain", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipMaterialDispose", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipMaterialDispose", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipRequireRPZ", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipRequireRPZ", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipStandardHydrantFitting", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipStandardHydrantFitting", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipPreConstructionMeeting", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipPreConstructionMeeting", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipSpecificMeetingLocation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificMeetingLocation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipSpecificMeetingLocationNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificMeetingLocationNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipVehicleAccess", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccess", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipVehicleAccessNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccessNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipProjectOutcome", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipProjectOutcome", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipSpecificReportingNeeds", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificReportingNeeds", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchaseOrderNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchaseOrderAttached", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderAttached", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchaseOrderNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VehicleAccessRoad", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessRoad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VehicleAccessEasement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessEasement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VehicleAccessOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessOther", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_PROJECT_TERMS] SET [ProjectID] = @ProjectID, [LiquidatedDamage]" +
                " = @LiquidatedDamage, [LiquidatedRate] = @LiquidatedRate, [LiquidatedUnit] = @Li" +
                "quidatedUnit, [RelationshipClientWorkedBefore] = @RelationshipClientWorkedBefore" +
                ", [RelationshipClientQuirks] = @RelationshipClientQuirks, [RelationshipClientPro" +
                "mises] = @RelationshipClientPromises, [RelationshipClientPromisesNotes] = @Relat" +
                "ionshipClientPromisesNotes, [RelationshipWaterObtain] = @RelationshipWaterObtain" +
                ", [RelationshipMaterialDispose] = @RelationshipMaterialDispose, [RelationshipReq" +
                "uireRPZ] = @RelationshipRequireRPZ, [RelationshipStandardHydrantFitting] = @Rela" +
                "tionshipStandardHydrantFitting, [RelationshipPreConstructionMeeting] = @Relation" +
                "shipPreConstructionMeeting, [RelationshipSpecificMeetingLocation] = @Relationshi" +
                "pSpecificMeetingLocation, [RelationshipSpecificMeetingLocationNotes] = @Relation" +
                "shipSpecificMeetingLocationNotes, [RelationshipVehicleAccess] = @RelationshipVeh" +
                "icleAccess, [RelationshipVehicleAccessNotes] = @RelationshipVehicleAccessNotes, " +
                "[RelationshipProjectOutcome] = @RelationshipProjectOutcome, [RelationshipSpecifi" +
                "cReportingNeeds] = @RelationshipSpecificReportingNeeds, [PurchaseOrderNumber] = " +
                "@PurchaseOrderNumber, [PurchaseOrderAttached] = @PurchaseOrderAttached, [Purchas" +
                "eOrderNotes] = @PurchaseOrderNotes, [COMPANY_ID] = @COMPANY_ID, [VehicleAccessRo" +
                "ad] = @VehicleAccessRoad, [VehicleAccessEasement] = @VehicleAccessEasement, [Veh" +
                "icleAccessOther] = @VehicleAccessOther WHERE (([ProjectID] = @Original_ProjectID" +
                ") AND ([LiquidatedDamage] = @Original_LiquidatedDamage) AND ((@IsNull_Liquidated" +
                "Rate = 1 AND [LiquidatedRate] IS NULL) OR ([LiquidatedRate] = @Original_Liquidat" +
                "edRate)) AND ((@IsNull_LiquidatedUnit = 1 AND [LiquidatedUnit] IS NULL) OR ([Liq" +
                "uidatedUnit] = @Original_LiquidatedUnit)) AND ([RelationshipClientWorkedBefore] " +
                "= @Original_RelationshipClientWorkedBefore) AND ([RelationshipClientPromises] = " +
                "@Original_RelationshipClientPromises) AND ((@IsNull_RelationshipWaterObtain = 1 " +
                "AND [RelationshipWaterObtain] IS NULL) OR ([RelationshipWaterObtain] = @Original" +
                "_RelationshipWaterObtain)) AND ((@IsNull_RelationshipMaterialDispose = 1 AND [Re" +
                "lationshipMaterialDispose] IS NULL) OR ([RelationshipMaterialDispose] = @Origina" +
                "l_RelationshipMaterialDispose)) AND ([RelationshipRequireRPZ] = @Original_Relati" +
                "onshipRequireRPZ) AND ((@IsNull_RelationshipStandardHydrantFitting = 1 AND [Rela" +
                "tionshipStandardHydrantFitting] IS NULL) OR ([RelationshipStandardHydrantFitting" +
                "] = @Original_RelationshipStandardHydrantFitting)) AND ([RelationshipPreConstruc" +
                "tionMeeting] = @Original_RelationshipPreConstructionMeeting) AND ([RelationshipS" +
                "pecificMeetingLocation] = @Original_RelationshipSpecificMeetingLocation) AND ((@" +
                "IsNull_RelationshipVehicleAccess = 1 AND [RelationshipVehicleAccess] IS NULL) OR" +
                " ([RelationshipVehicleAccess] = @Original_RelationshipVehicleAccess)) AND ((@IsN" +
                "ull_PurchaseOrderNumber = 1 AND [PurchaseOrderNumber] IS NULL) OR ([PurchaseOrde" +
                "rNumber] = @Original_PurchaseOrderNumber)) AND ([PurchaseOrderAttached] = @Origi" +
                "nal_PurchaseOrderAttached) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ([Vehic" +
                "leAccessRoad] = @Original_VehicleAccessRoad) AND ([VehicleAccessEasement] = @Ori" +
                "ginal_VehicleAccessEasement) AND ([VehicleAccessOther] = @Original_VehicleAccess" +
                "Other));\r\nSELECT ProjectID, LiquidatedDamage, LiquidatedRate, LiquidatedUnit, Re" +
                "lationshipClientWorkedBefore, RelationshipClientQuirks, RelationshipClientPromis" +
                "es, RelationshipClientPromisesNotes, RelationshipWaterObtain, RelationshipMateri" +
                "alDispose, RelationshipRequireRPZ, RelationshipStandardHydrantFitting, Relations" +
                "hipPreConstructionMeeting, RelationshipSpecificMeetingLocation, RelationshipSpec" +
                "ificMeetingLocationNotes, RelationshipVehicleAccess, RelationshipVehicleAccessNo" +
                "tes, RelationshipProjectOutcome, RelationshipSpecificReportingNeeds, PurchaseOrd" +
                "erNumber, PurchaseOrderAttached, PurchaseOrderNotes, COMPANY_ID, VehicleAccessRo" +
                "ad, VehicleAccessEasement, VehicleAccessOther FROM LFS_PROJECT_TERMS WHERE (Proj" +
                "ectID = @ProjectID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiquidatedDamage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedDamage", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiquidatedRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedRate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LiquidatedUnit", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedUnit", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientWorkedBefore", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientWorkedBefore", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientQuirks", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientQuirks", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientPromises", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientPromises", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipClientPromisesNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientPromisesNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipWaterObtain", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipWaterObtain", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipMaterialDispose", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipMaterialDispose", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipRequireRPZ", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipRequireRPZ", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipStandardHydrantFitting", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipStandardHydrantFitting", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipPreConstructionMeeting", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipPreConstructionMeeting", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipSpecificMeetingLocation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificMeetingLocation", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipSpecificMeetingLocationNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificMeetingLocationNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipVehicleAccess", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccess", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipVehicleAccessNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccessNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipProjectOutcome", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipProjectOutcome", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@RelationshipSpecificReportingNeeds", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificReportingNeeds", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchaseOrderNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNumber", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchaseOrderAttached", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderAttached", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchaseOrderNotes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNotes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VehicleAccessRoad", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessRoad", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VehicleAccessEasement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessEasement", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VehicleAccessOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessOther", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ProjectID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ProjectID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiquidatedDamage", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedDamage", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LiquidatedRate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedRate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiquidatedRate", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedRate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LiquidatedUnit", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedUnit", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LiquidatedUnit", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LiquidatedUnit", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipClientWorkedBefore", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientWorkedBefore", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipClientPromises", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipClientPromises", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipWaterObtain", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipWaterObtain", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipWaterObtain", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipWaterObtain", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipMaterialDispose", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipMaterialDispose", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipMaterialDispose", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipMaterialDispose", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipRequireRPZ", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipRequireRPZ", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipStandardHydrantFitting", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipStandardHydrantFitting", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipStandardHydrantFitting", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipStandardHydrantFitting", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipPreConstructionMeeting", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipPreConstructionMeeting", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipSpecificMeetingLocation", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipSpecificMeetingLocation", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_RelationshipVehicleAccess", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccess", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_RelationshipVehicleAccess", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "RelationshipVehicleAccess", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PurchaseOrderNumber", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNumber", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PurchaseOrderNumber", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderNumber", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PurchaseOrderAttached", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchaseOrderAttached", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VehicleAccessRoad", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessRoad", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VehicleAccessEasement", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessEasement", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VehicleAccessOther", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VehicleAccessOther", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
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
            FillDataWithStoredProcedure("LFS_PROJECTS_PROJECTTERMSPOGATEWAY_LOADBYPROJECTID", new SqlParameter("@projectId", projectId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Projects.Projects.ProjectTermsPOGateway.GetRow");
            }
        }



        /// <summary>
        /// GetLiquidatedDamage
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>LiquidatedDamage</returns>
        public bool GetLiquidatedDamage(int projectId)
        {
            return (bool)GetRow(projectId)["LiquidatedDamage"];
        }



        /// <summary>
        /// GetRelationshipClientWorkedBefore
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipClientWorkedBefore</returns>
        public bool GetRelationshipClientWorkedBefore(int projectId)
        {
            return (bool)GetRow(projectId)["RelationshipClientWorkedBefore"];
        }



        /// <summary>
        /// GetRelationshipClientPromises
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipClientPromises</returns>
        public bool GetRelationshipClientPromises(int projectId)
        {
            return (bool)GetRow(projectId)["RelationshipClientPromises"];
        }



        /// <summary>
        /// GetRelationshipRequireRPZ
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipRequireRPZ</returns>
        public bool GetRelationshipRequireRPZ(int projectId)
        {
            return (bool)GetRow(projectId)["RelationshipRequireRPZ"];
        }



        /// <summary>
        /// GetRelationshipPreConstructionMeeting
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipPreConstructionMeeting</returns>
        public bool GetRelationshipPreConstructionMeeting(int projectId)
        {
            return (bool)GetRow(projectId)["RelationshipPreConstructionMeeting"];
        }



        /// <summary>
        /// GetRelationshipSpecificMeetingLocation 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipSpecificMeetingLocation</returns>
        public bool GetRelationshipSpecificMeetingLocation(int projectId)
        {
            return (bool)GetRow(projectId)["RelationshipSpecificMeetingLocation"];
        }



        /// <summary>
        /// GetPurchaseOrderAttached 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>PurchaseOrderAttached</returns>
        public bool GetPurchaseOrderAttached(int projectId)
        {
            return (bool)GetRow(projectId)["PurchaseOrderAttached"];
        }



        /// <summary>
        /// GetLiquidatedRate 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>LiquidatedRate or EMPTY</returns>
        public decimal? GetLiquidatedRate(int projectId)
        {
            if (GetRow(projectId).IsNull("LiquidatedRate"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(projectId)["LiquidatedRate"];
            }
        }



        /// <summary>
        /// GetLiquidatedUnit
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>LiquidatedUnit or EMPTY</returns>
        public string GetLiquidatedUnit(int projectId)
        {
            if (GetRow(projectId).IsNull("LiquidatedUnit"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["LiquidatedUnit"];
            }
        }



        /// <summary>
        /// GetRelationshipClientQuirks
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipClientQuirks or EMPTY</returns>
        public string GetRelationshipClientQuirks(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipClientQuirks"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipClientQuirks"];
            }
        }



        /// <summary>
        /// GetRelationshipClientPromisesNotes
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipClientPromisesNotes or EMPTY</returns>
        public string GetRelationshipClientPromisesNotes(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipClientPromisesNotes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipClientPromisesNotes"];
            }
        }



        /// <summary>
        /// GetRelationshipWaterObtain
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipWaterObtain or EMPTY</returns>
        public string GetRelationshipWaterObtain(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipWaterObtain"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipWaterObtain"];
            }
        }



        /// <summary>
        /// GetRelationshipMaterialDispose
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipMaterialDispose or EMPTY</returns>
        public string GetRelationshipMaterialDispose(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipMaterialDispose"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipMaterialDispose"];
            }
        }



        /// <summary>
        /// GetRelationshipStandardHydrantFitting
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipStandardHydrantFitting or EMPTY</returns>
        public string GetRelationshipStandardHydrantFitting(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipStandardHydrantFitting"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipStandardHydrantFitting"];
            }
        }



        /// <summary>
        /// GetRelationshipSpecificMeetingLocationNotes
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipSpecificMeetingLocationNotes or EMPTY</returns>
        public string GetRelationshipSpecificMeetingLocationNotes(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipSpecificMeetingLocationNotes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipSpecificMeetingLocationNotes"];
            }
        }



        /// <summary>
        /// GetRelationshipVehicleAccess 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipVehicleAccess or EMPTY</returns>
        public string GetRelationshipVehicleAccess(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipVehicleAccess"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipVehicleAccess"];
            }
        }



        /// <summary>
        /// GetRelationshipVehicleAccessNotes 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipVehicleAccessNotes or EMPTY</returns>
        public string GetRelationshipVehicleAccessNotes(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipVehicleAccessNotes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipVehicleAccessNotes"];
            }
        }



        /// <summary>
        /// GetRelationshipProjectOutcome 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipProjectOutcome or EMPTY</returns>
        public string GetRelationshipProjectOutcome(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipProjectOutcome"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipProjectOutcome"];
            }
        }



        /// <summary>
        /// GetRelationshipSpecificReportingNeeds 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>RelationshipSpecificReportingNeeds or EMPTY</returns>
        public string GetRelationshipSpecificReportingNeeds(int projectId)
        {
            if (GetRow(projectId).IsNull("RelationshipSpecificReportingNeeds"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["RelationshipSpecificReportingNeeds"];
            }
        }



        /// <summary>
        /// GetPurchaseOrderNumber
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>PurchaseOrderNumber or EMPTY</returns>
        public string GetPurchaseOrderNumber(int projectId)
        {
            if (GetRow(projectId).IsNull("PurchaseOrderNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["PurchaseOrderNumber"];
            }
        }



        /// <summary> 
        /// GetPurchaseOrderNotes
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>PurchaseOrderNotes or EMPTY</returns>
        public string GetPurchaseOrderNotes(int projectId)
        {
            if (GetRow(projectId).IsNull("PurchaseOrderNotes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(projectId)["PurchaseOrderNotes"];
            }
        }



        /// <summary>
        /// GetVehicleAccessRoad 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>VehicleAccessRoad</returns>
        public bool GetVehicleAccessRoad(int projectId)
        {
            return (bool)GetRow(projectId)["VehicleAccessRoad"];
        }



        /// <summary>
        /// GetVehicleAccessEasement 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>VehicleAccessEasement</returns>
        public bool GetVehicleAccessEasement(int projectId)
        {
            return (bool)GetRow(projectId)["VehicleAccessEasement"];
        }



        /// <summary>
        /// GetVehicleAccessOther 
        /// </summary>
        /// <param name="projectId">projectId</param>
        /// <returns>VehicleAccessOther</returns>
        public bool GetVehicleAccessOther(int projectId)
        {
            return (bool)GetRow(projectId)["VehicleAccessOther"];
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
