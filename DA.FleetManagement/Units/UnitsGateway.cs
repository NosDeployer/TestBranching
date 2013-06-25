using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsGateway
    /// </summary>
    public class UnitsGateway : DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsGateway()
            : base("LFS_FM_UNIT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsGateway(DataSet data)
            : base(data, "LFS_FM_UNIT")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitsTDS();
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
            tableMapping.DataSetTable = "LFS_FM_UNIT";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("UnitCode", "UnitCode");
            tableMapping.ColumnMappings.Add("Description", "Description");
            tableMapping.ColumnMappings.Add("VIN", "VIN");
            tableMapping.ColumnMappings.Add("Manufacturer", "Manufacturer");
            tableMapping.ColumnMappings.Add("Model", "Model");
            tableMapping.ColumnMappings.Add("Year_", "Year_");
            tableMapping.ColumnMappings.Add("IsTowable", "IsTowable");
            tableMapping.ColumnMappings.Add("CompanyLevelID", "CompanyLevelID");
            tableMapping.ColumnMappings.Add("AcquisitionDate", "AcquisitionDate");
            tableMapping.ColumnMappings.Add("DispositionDate", "DispositionDate");
            tableMapping.ColumnMappings.Add("DispositionReason", "DispositionReason");
            tableMapping.ColumnMappings.Add("OwnerType", "OwnerType");
            tableMapping.ColumnMappings.Add("OwnerCountry", "OwnerCountry");
            tableMapping.ColumnMappings.Add("OwnerState", "OwnerState");
            tableMapping.ColumnMappings.Add("OwnerName", "OwnerName");
            tableMapping.ColumnMappings.Add("OwnerContact", "OwnerContact");
            tableMapping.ColumnMappings.Add("QualifiedDate", "QualifiedDate");
            tableMapping.ColumnMappings.Add("NotQualifiedDate", "NotQualifiedDate");
            tableMapping.ColumnMappings.Add("NotQualifiedExplain", "NotQualifiedExplain");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("Categories", "Categories");
            tableMapping.ColumnMappings.Add("InsuranceClass", "InsuranceClass");
            tableMapping.ColumnMappings.Add("InsuranceClassRyderSpecified", "InsuranceClassRyderSpecified");
            tableMapping.ColumnMappings.Add("PurchasePrice", "PurchasePrice");
            tableMapping.ColumnMappings.Add("ScrapDate", "ScrapDate");
            tableMapping.ColumnMappings.Add("SaleProceeds", "SaleProceeds");
            tableMapping.ColumnMappings.Add("LIBRARY_CATEGORIES_ID", "LIBRARY_CATEGORIES_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = "DELETE FROM [dbo].[LFS_FM_UNIT] WHERE (([UnitID] = @Original_UnitID) AND ([UnitCo" +
                "de] = @Original_UnitCode) AND ((@IsNull_Description = 1 AND [Description] IS NUL" +
                "L) OR ([Description] = @Original_Description)) AND ((@IsNull_VIN = 1 AND [VIN] I" +
                "S NULL) OR ([VIN] = @Original_VIN)) AND ((@IsNull_Manufacturer = 1 AND [Manufact" +
                "urer] IS NULL) OR ([Manufacturer] = @Original_Manufacturer)) AND ((@IsNull_Model" +
                " = 1 AND [Model] IS NULL) OR ([Model] = @Original_Model)) AND ((@IsNull_Year_ = " +
                "1 AND [Year_] IS NULL) OR ([Year_] = @Original_Year_)) AND ([IsTowable] = @Origi" +
                "nal_IsTowable) AND ([CompanyLevelID] = @Original_CompanyLevelID) AND ((@IsNull_A" +
                "cquisitionDate = 1 AND [AcquisitionDate] IS NULL) OR ([AcquisitionDate] = @Origi" +
                "nal_AcquisitionDate)) AND ((@IsNull_DispositionDate = 1 AND [DispositionDate] IS" +
                " NULL) OR ([DispositionDate] = @Original_DispositionDate)) AND ((@IsNull_Disposi" +
                "tionReason = 1 AND [DispositionReason] IS NULL) OR ([DispositionReason] = @Origi" +
                "nal_DispositionReason)) AND ((@IsNull_OwnerType = 1 AND [OwnerType] IS NULL) OR " +
                "([OwnerType] = @Original_OwnerType)) AND ((@IsNull_OwnerCountry = 1 AND [OwnerCo" +
                "untry] IS NULL) OR ([OwnerCountry] = @Original_OwnerCountry)) AND ((@IsNull_Owne" +
                "rState = 1 AND [OwnerState] IS NULL) OR ([OwnerState] = @Original_OwnerState)) A" +
                "ND ((@IsNull_OwnerName = 1 AND [OwnerName] IS NULL) OR ([OwnerName] = @Original_" +
                "OwnerName)) AND ((@IsNull_OwnerContact = 1 AND [OwnerContact] IS NULL) OR ([Owne" +
                "rContact] = @Original_OwnerContact)) AND ((@IsNull_QualifiedDate = 1 AND [Qualif" +
                "iedDate] IS NULL) OR ([QualifiedDate] = @Original_QualifiedDate)) AND ((@IsNull_" +
                "NotQualifiedDate = 1 AND [NotQualifiedDate] IS NULL) OR ([NotQualifiedDate] = @O" +
                "riginal_NotQualifiedDate)) AND ([State] = @Original_State) AND ((@IsNull_Type = " +
                "1 AND [Type] IS NULL) OR ([Type] = @Original_Type)) AND ([Deleted] = @Original_D" +
                "eleted) AND ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_InsuranceClass =" +
                " 1 AND [InsuranceClass] IS NULL) OR ([InsuranceClass] = @Original_InsuranceClass" +
                ")) AND ((@IsNull_InsuranceClassRyderSpecified = 1 AND [InsuranceClassRyderSpecif" +
                "ied] IS NULL) OR ([InsuranceClassRyderSpecified] = @Original_InsuranceClassRyder" +
                "Specified)) AND ((@IsNull_PurchasePrice = 1 AND [PurchasePrice] IS NULL) OR ([Pu" +
                "rchasePrice] = @Original_PurchasePrice)) AND ((@IsNull_ScrapDate = 1 AND [ScrapD" +
                "ate] IS NULL) OR ([ScrapDate] = @Original_ScrapDate)) AND ((@IsNull_SaleProceeds" +
                " = 1 AND [SaleProceeds] IS NULL) OR ([SaleProceeds] = @Original_SaleProceeds)) A" +
                "ND ((@IsNull_LIBRARY_CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR (" +
                "[LIBRARY_CATEGORIES_ID] = @Original_LIBRARY_CATEGORIES_ID)))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitCode", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitCode", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Description", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VIN", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VIN", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VIN", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VIN", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Manufacturer", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Manufacturer", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Manufacturer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Manufacturer", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Model", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Model", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Model", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Model", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Year_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Year_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsTowable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsTowable", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AcquisitionDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcquisitionDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AcquisitionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcquisitionDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DispositionDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DispositionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DispositionReason", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionReason", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DispositionReason", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionReason", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerCountry", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerCountry", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerCountry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerState", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerState", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerName", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerName", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerContact", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerContact", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerContact", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerContact", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_QualifiedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "QualifiedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_QualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "QualifiedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NotQualifiedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotQualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InsuranceClass", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClass", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InsuranceClass", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InsuranceClassRyderSpecified", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClassRyderSpecified", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InsuranceClassRyderSpecified", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClassRyderSpecified", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchasePrice", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchasePrice", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ScrapDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ScrapDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ScrapDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ScrapDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SaleProceeds", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SaleProceeds", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SaleProceeds", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SaleProceeds", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_UNIT] ([UnitCode], [Description], [VIN], [Manufacturer], [Model], [Year_], [IsTowable], [CompanyLevelID], [AcquisitionDate], [DispositionDate], [DispositionReason], [OwnerType], [OwnerCountry], [OwnerState], [OwnerName], [OwnerContact], [QualifiedDate], [NotQualifiedDate], [NotQualifiedExplain], [State], [Type], [Deleted], [COMPANY_ID], [Notes], [Categories], [InsuranceClass], [InsuranceClassRyderSpecified], [PurchasePrice], [ScrapDate], [SaleProceeds], [LIBRARY_CATEGORIES_ID]) VALUES (@UnitCode, @Description, @VIN, @Manufacturer, @Model, @Year_, @IsTowable, @CompanyLevelID, @AcquisitionDate, @DispositionDate, @DispositionReason, @OwnerType, @OwnerCountry, @OwnerState, @OwnerName, @OwnerContact, @QualifiedDate, @NotQualifiedDate, @NotQualifiedExplain, @State, @Type, @Deleted, @COMPANY_ID, @Notes, @Categories, @InsuranceClass, @InsuranceClassRyderSpecified, @PurchasePrice, @ScrapDate, @SaleProceeds, @LIBRARY_CATEGORIES_ID);
SELECT UnitID, UnitCode, Description, VIN, Manufacturer, Model, Year_, IsTowable, CompanyLevelID, AcquisitionDate, DispositionDate, DispositionReason, OwnerType, OwnerCountry, OwnerState, OwnerName, OwnerContact, QualifiedDate, NotQualifiedDate, NotQualifiedExplain, State, Type, Deleted, COMPANY_ID, Notes, Categories, InsuranceClass, InsuranceClassRyderSpecified, PurchasePrice, ScrapDate, SaleProceeds, LIBRARY_CATEGORIES_ID FROM LFS_FM_UNIT WHERE (UnitID = SCOPE_IDENTITY())";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitCode", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitCode", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VIN", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VIN", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Manufacturer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Manufacturer", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Model", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Model", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Year_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsTowable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsTowable", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AcquisitionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcquisitionDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DispositionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DispositionReason", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerContact", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerContact", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@QualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "QualifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotQualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotQualifiedExplain", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedExplain", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Notes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Notes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Categories", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Categories", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InsuranceClass", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InsuranceClassRyderSpecified", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClassRyderSpecified", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchasePrice", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchasePrice", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ScrapDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ScrapDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SaleProceeds", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SaleProceeds", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = "UPDATE [dbo].[LFS_FM_UNIT] SET [UnitCode] = @UnitCode, [Description] = @Descripti" +
                "on, [VIN] = @VIN, [Manufacturer] = @Manufacturer, [Model] = @Model, [Year_] = @Y" +
                "ear_, [IsTowable] = @IsTowable, [CompanyLevelID] = @CompanyLevelID, [Acquisition" +
                "Date] = @AcquisitionDate, [DispositionDate] = @DispositionDate, [DispositionReas" +
                "on] = @DispositionReason, [OwnerType] = @OwnerType, [OwnerCountry] = @OwnerCount" +
                "ry, [OwnerState] = @OwnerState, [OwnerName] = @OwnerName, [OwnerContact] = @Owne" +
                "rContact, [QualifiedDate] = @QualifiedDate, [NotQualifiedDate] = @NotQualifiedDa" +
                "te, [NotQualifiedExplain] = @NotQualifiedExplain, [State] = @State, [Type] = @Ty" +
                "pe, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Notes] = @Notes, [Categor" +
                "ies] = @Categories, [InsuranceClass] = @InsuranceClass, [InsuranceClassRyderSpec" +
                "ified] = @InsuranceClassRyderSpecified, [PurchasePrice] = @PurchasePrice, [Scrap" +
                "Date] = @ScrapDate, [SaleProceeds] = @SaleProceeds, [LIBRARY_CATEGORIES_ID] = @L" +
                "IBRARY_CATEGORIES_ID WHERE (([UnitID] = @Original_UnitID) AND ([UnitCode] = @Ori" +
                "ginal_UnitCode) AND ((@IsNull_Description = 1 AND [Description] IS NULL) OR ([De" +
                "scription] = @Original_Description)) AND ((@IsNull_VIN = 1 AND [VIN] IS NULL) OR" +
                " ([VIN] = @Original_VIN)) AND ((@IsNull_Manufacturer = 1 AND [Manufacturer] IS N" +
                "ULL) OR ([Manufacturer] = @Original_Manufacturer)) AND ((@IsNull_Model = 1 AND [" +
                "Model] IS NULL) OR ([Model] = @Original_Model)) AND ((@IsNull_Year_ = 1 AND [Yea" +
                "r_] IS NULL) OR ([Year_] = @Original_Year_)) AND ([IsTowable] = @Original_IsTowa" +
                "ble) AND ([CompanyLevelID] = @Original_CompanyLevelID) AND ((@IsNull_Acquisition" +
                "Date = 1 AND [AcquisitionDate] IS NULL) OR ([AcquisitionDate] = @Original_Acquis" +
                "itionDate)) AND ((@IsNull_DispositionDate = 1 AND [DispositionDate] IS NULL) OR " +
                "([DispositionDate] = @Original_DispositionDate)) AND ((@IsNull_DispositionReason" +
                " = 1 AND [DispositionReason] IS NULL) OR ([DispositionReason] = @Original_Dispos" +
                "itionReason)) AND ((@IsNull_OwnerType = 1 AND [OwnerType] IS NULL) OR ([OwnerTyp" +
                "e] = @Original_OwnerType)) AND ((@IsNull_OwnerCountry = 1 AND [OwnerCountry] IS " +
                "NULL) OR ([OwnerCountry] = @Original_OwnerCountry)) AND ((@IsNull_OwnerState = 1" +
                " AND [OwnerState] IS NULL) OR ([OwnerState] = @Original_OwnerState)) AND ((@IsNu" +
                "ll_OwnerName = 1 AND [OwnerName] IS NULL) OR ([OwnerName] = @Original_OwnerName)" +
                ") AND ((@IsNull_OwnerContact = 1 AND [OwnerContact] IS NULL) OR ([OwnerContact] " +
                "= @Original_OwnerContact)) AND ((@IsNull_QualifiedDate = 1 AND [QualifiedDate] I" +
                "S NULL) OR ([QualifiedDate] = @Original_QualifiedDate)) AND ((@IsNull_NotQualifi" +
                "edDate = 1 AND [NotQualifiedDate] IS NULL) OR ([NotQualifiedDate] = @Original_No" +
                "tQualifiedDate)) AND ([State] = @Original_State) AND ((@IsNull_Type = 1 AND [Typ" +
                "e] IS NULL) OR ([Type] = @Original_Type)) AND ([Deleted] = @Original_Deleted) AN" +
                "D ([COMPANY_ID] = @Original_COMPANY_ID) AND ((@IsNull_InsuranceClass = 1 AND [In" +
                "suranceClass] IS NULL) OR ([InsuranceClass] = @Original_InsuranceClass)) AND ((@" +
                "IsNull_InsuranceClassRyderSpecified = 1 AND [InsuranceClassRyderSpecified] IS NU" +
                "LL) OR ([InsuranceClassRyderSpecified] = @Original_InsuranceClassRyderSpecified)" +
                ") AND ((@IsNull_PurchasePrice = 1 AND [PurchasePrice] IS NULL) OR ([PurchasePric" +
                "e] = @Original_PurchasePrice)) AND ((@IsNull_ScrapDate = 1 AND [ScrapDate] IS NU" +
                "LL) OR ([ScrapDate] = @Original_ScrapDate)) AND ((@IsNull_SaleProceeds = 1 AND [" +
                "SaleProceeds] IS NULL) OR ([SaleProceeds] = @Original_SaleProceeds)) AND ((@IsNu" +
                "ll_LIBRARY_CATEGORIES_ID = 1 AND [LIBRARY_CATEGORIES_ID] IS NULL) OR ([LIBRARY_C" +
                "ATEGORIES_ID] = @Original_LIBRARY_CATEGORIES_ID)));\r\nSELECT UnitID, UnitCode, De" +
                "scription, VIN, Manufacturer, Model, Year_, IsTowable, CompanyLevelID, Acquisiti" +
                "onDate, DispositionDate, DispositionReason, OwnerType, OwnerCountry, OwnerState," +
                " OwnerName, OwnerContact, QualifiedDate, NotQualifiedDate, NotQualifiedExplain, " +
                "State, Type, Deleted, COMPANY_ID, Notes, Categories, InsuranceClass, InsuranceCl" +
                "assRyderSpecified, PurchasePrice, ScrapDate, SaleProceeds, LIBRARY_CATEGORIES_ID" +
                " FROM LFS_FM_UNIT WHERE (UnitID = @UnitID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitCode", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitCode", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@VIN", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VIN", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Manufacturer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Manufacturer", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Model", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Model", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Year_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsTowable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsTowable", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@AcquisitionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcquisitionDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DispositionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@DispositionReason", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionReason", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerType", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerCountry", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerState", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerName", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@OwnerContact", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerContact", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@QualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "QualifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotQualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@NotQualifiedExplain", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedExplain", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Notes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Notes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Categories", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Categories", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InsuranceClass", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClass", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InsuranceClassRyderSpecified", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClassRyderSpecified", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@PurchasePrice", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchasePrice", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@ScrapDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ScrapDate", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@SaleProceeds", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SaleProceeds", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitCode", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitCode", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Description", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Description", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Description", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_VIN", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VIN", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_VIN", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "VIN", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Manufacturer", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Manufacturer", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Manufacturer", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Manufacturer", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Model", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Model", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Model", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Model", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Year_", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year_", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Year_", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Year_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_IsTowable", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "IsTowable", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_CompanyLevelID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "CompanyLevelID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_AcquisitionDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcquisitionDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_AcquisitionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "AcquisitionDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DispositionDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DispositionDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_DispositionReason", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionReason", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_DispositionReason", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "DispositionReason", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerType", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerType", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerType", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerType", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerCountry", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerCountry", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerCountry", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerCountry", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerState", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerState", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerState", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerState", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerName", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerName", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerName", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerName", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_OwnerContact", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerContact", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_OwnerContact", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "OwnerContact", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_QualifiedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "QualifiedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_QualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "QualifiedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_NotQualifiedDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_NotQualifiedDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "NotQualifiedDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Type", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InsuranceClass", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClass", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InsuranceClass", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClass", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InsuranceClassRyderSpecified", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClassRyderSpecified", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InsuranceClassRyderSpecified", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InsuranceClassRyderSpecified", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_PurchasePrice", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchasePrice", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_PurchasePrice", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "PurchasePrice", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_ScrapDate", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ScrapDate", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_ScrapDate", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "ScrapDate", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_SaleProceeds", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SaleProceeds", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_SaleProceeds", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "SaleProceeds", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_LIBRARY_CATEGORIES_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "LIBRARY_CATEGORIES_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 4, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));

            #endregion
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }        



        /// <summary>
        /// LoadByCompanyLevelId
        /// </summary>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByCompanyLevelId(int companyLevelId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSGATEWAY_LOADBYCOMPANYLEVELID", new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadSimilarTop12
        /// </summary>
        /// <param name="manufacturer">manufacturer</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadSimilarTop12(string manufacturer, int companyId)
        {
            string manufacturerParameter = "U.Manufacturer LIKE '" + manufacturer + "%'";
            string companyIdParameter = "U.COMPANY_ID = " + companyId.ToString();

            string commandText = String.Format("SELECT TOP 12 U.UnitID, U.UnitCode, U.Description, U.VIN, U.Manufacturer, U.Model, U.Year_, U.IsTowable, U.CompanyLevelID, U.AcquisitionDate, U.DispositionDate, U.DispositionReason,  U.OwnerType, U.OwnerName, U.OwnerContact, U.QualifiedDate, U.NotQualifiedDate, U.State, U.Type, U.Deleted, U.COMPANY_ID, U.Notes, U.Categories, U.InsuranceClass, U.InsuranceClassRyderSpecified, U.PurchasePrice, U.ScrapDate, U.SaleProceeds, U.LIBRARY_CATEGORIES_ID FROM dbo.LFS_FM_UNIT U WHERE {0} AND {1} ORDER BY U.Manufacturer", manufacturerParameter, companyIdParameter);
            FillData(commandText);

            return Data;
        }



        /// <summary>
        /// IsUsedInUnits
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInUnits(int unitId, int companyLevelId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT WHERE (UnitID = @unitId) AND (CompanyLevelID = @companyLevelId) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@companyLevelId", companyLevelId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInUnitsAndNotIsDisposed
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInUnitsAndNotIsDisposed(int unitId, int companyLevelId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT WHERE (UnitID = @unitId) AND (CompanyLevelID = @companyLevelId) AND (Deleted = 0) AND (State <> 'Disposed')";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@companyLevelId", companyLevelId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUnitNotDisposed
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUnitNotDisposed(int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT WHERE (UnitID = @unitId) AND (Deleted = 0) AND (State <> 'Disposed')";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }
        
        

        /// <summary>
        /// IsUsedInUnits
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="deleted">deleted</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUsedInUnits(int unitId, int companyLevelId, bool deleted)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT WHERE (UnitID = @unitId) AND (CompanyLevelID = @companyLevelId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@companyLevelId", companyLevelId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUnitWithServicesActives
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>TRUE if is used</returns>
        public bool IsUnitWithServicesActives(int unitId, int companyId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT U INNER JOIN LFS_FM_SERVICE S ON U.UnitID = S.UnitID WHERE (S.State <> 'Completed') AND (U.UnitID = @unitId) AND (S.UnitID = @unitId) AND (U.Deleted = 0) AND (S.Deleted = 0) AND (U.COMPANY_ID = @companyId) AND (S.COMPANY_ID = @companyId)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@companyId", companyId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInProjectTime
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>True if is used, false if not</returns>
        public bool IsUsedInProjectTime(int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_PROJECT_TIME WHERE ((UnitID = @unitId) OR (TowedUnitID = @unitId)) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            
            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInTeamProjectTime
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>true is is used, false if not</returns>
        public bool IsUsedInTeamProjectTime(int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_TEAM_PROJECT_TIME WHERE ((UnitID = @unitId) OR (TowedUnitID = @unitId)) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            
            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUsedInTeamProjectTimeDetail
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>true if is used, false if not</returns>
        public bool IsUsedInTeamProjectTimeDetail(int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_TEAM_PROJECT_TIME_DETAIL WHERE ((UnitID = @unitId) OR (TowedUnitID = @unitId)) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// IsUnitCodeInUse
        /// </summary>
        /// <param name="unitCode">unitCode</param>
        /// <returns>true if is used, false if not</returns>
        public bool IsUnitCodeInUse(string unitCode)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT WHERE (UnitCode = @unitCode) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitCode", unitCode));

            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }

        

        /// <summary>
        /// IsUnitCodeInUse
        /// </summary>
        /// <param name="unitCode">unitCode</param>
        /// <param name="unitId">unitId</param>
        /// <returns>true if is used, false if not</returns>
        public bool IsUnitCodeInUse(string unitCode, int unitId)
        {
            string commandText = "SELECT COUNT(*) FROM LFS_FM_UNIT WHERE (UnitID != @unitId) AND (UnitCode = @unitCode) AND (Deleted = 0)";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);
            command.Parameters.Add(new SqlParameter("@unitId", unitId));
            command.Parameters.Add(new SqlParameter("@unitCode", unitCode));
            
            return ((int)ExecuteScalar(command) > 0) ? true : false;
        }



        /// <summary>
        /// Get a single unit
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId)
        {
            string filter = string.Format("UnitID = {0}", unitId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Type or EMPTY</returns>
        public string GetType(int unitId)
        {
            if (GetRow(unitId).IsNull("Type"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Type"];
            }
        }



        /// <summary>
        /// GetUnitCode
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>UnitCode or EMPTY</returns>
        public string GetUnitCode(int unitId)
        {
            if (GetRow(unitId).IsNull("UnitCode"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["UnitCode"];
            }
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>State or EMPTY</returns>
        public string GetState(int unitId)
        {
            if (GetRow(unitId).IsNull("State"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["State"];
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>Description or EMPTY</returns>
        public string GetDescription(int unitId)
        {
            if (GetRow(unitId).IsNull("Description"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(unitId)["Description"];
            }
        }


        
        /// <summary>
        /// GetCompanyLevelId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>CompanyLevelID or EMPTY</returns>
        public int GetCompanyLevelId(int unitId)
        {
            return (int)GetRow(unitId)["CompanyLevelID"];
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROWS
        //

        /// <summary>
        /// Insert a unit (direct to DB)
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="description">description</param>
        /// <param name="vin">vin</param>
        /// <param name="manufacturer">manufacturer</param>
        /// <param name="model">model</param>
        /// <param name="year_">year_</param>
        /// <param name="isTowable">isTowable</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="acquisitionDate">acquisitionDate</param>
        /// <param name="dispositionDate">dispositionDate</param>
        /// <param name="dispositionReason">dispositionReason</param>        
        /// <param name="ownerType">ownerType</param>
        /// <param name="ownerCountry">ownerCountry</param>
        /// <param name="ownerState">ownerState</param>
        /// <param name="ownerName">ownerName</param>
        /// <param name="ownerContact">ownerContact</param>
        /// <param name="qualifiedDate">qualifiedDate</param>
        /// <param name="notQualifiedDate">notQualifiedDate</param>
        /// <param name="notQualifiedExplain">notQualifiedExplain</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="notes">notes</param>
        /// <param name="categories">categories</param>
        /// <param name="insuranceClass">insuranceClass</param>
        /// <param name="insuranceClassRyderSpecified">insuranceClassRyderSpecified</param>
        /// <param name="purchasePrice">purchasePrice</param>
        /// <param name="saleProceeds">saleProceeds</param>
        /// <param name="scrapDate">scrapDate</param>
        /// <param name="libraryCategoriesId">libraryCategoriesId</param>
        /// <returns>UnitID</returns>
        public int Insert(string code, string description, string vin, string manufacturer, string model, string year_, bool isTowable, int companyLevelId, DateTime? acquisitionDate, DateTime? dispositionDate, string dispositionReason, string ownerType, Int64? ownerCountry, Int64? ownerState, string ownerName, string ownerContact, DateTime? qualifiedDate, DateTime? notQualifiedDate, string notQualifiedExplain, string state, string type, bool deleted, int companyId, string notes, string categories, string insuranceClass, string insuranceClassRyderSpecified, decimal? purchasePrice, DateTime? scrapDate, decimal? saleProceeds, int? libraryCategoriesId)
        {
            SqlParameter codeParameter = new SqlParameter("UnitCode", code);
            SqlParameter descriptionParameter = (description != "") ? new SqlParameter("Description", description) : new SqlParameter("Description", DBNull.Value);
            SqlParameter vinParameter = (vin != "") ? new SqlParameter("VIN", vin) : new SqlParameter("VIN", DBNull.Value);
            SqlParameter manufacturerParameter = (manufacturer != "") ? new SqlParameter("Manufacturer", manufacturer) : new SqlParameter("Manufacturer", DBNull.Value);
            SqlParameter modelParameter = (model != "") ? new SqlParameter("Model", model) : new SqlParameter("Model", DBNull.Value);
            SqlParameter yearParameter = (year_ != "") ? new SqlParameter("Year_", year_) : new SqlParameter("Year_", DBNull.Value);
            SqlParameter isTowableParameter = new SqlParameter("IsTowable", isTowable);
            SqlParameter companyLevelIdParameter = new SqlParameter("CompanyLevelID", companyLevelId);
            SqlParameter acquisitionDateParameter = (acquisitionDate.HasValue) ? new SqlParameter("AcquisitionDate", (DateTime)acquisitionDate) : new SqlParameter("AcquisitionDate", DBNull.Value);
            SqlParameter dispositionDateParameter = (dispositionDate.HasValue) ? new SqlParameter("DispositionDate", (DateTime)dispositionDate) : new SqlParameter("DispositionDate", DBNull.Value);
            SqlParameter dispositionReasonParameter = (dispositionReason != "") ? new SqlParameter("DispositionReason", dispositionReason) : new SqlParameter("DispositionReason", DBNull.Value);
            SqlParameter ownerTypeParameter = (ownerType != "") ? new SqlParameter("OwnerType", ownerType) : new SqlParameter("OwnerType", DBNull.Value);
            SqlParameter ownerCountryParameter = (ownerCountry.HasValue) ? new SqlParameter("OwnerCountry", (Int64)ownerCountry) : new SqlParameter("OwnerCountry", DBNull.Value);
            SqlParameter ownerStateParameter = (ownerState.HasValue) ? new SqlParameter("OwnerState", (Int64)ownerState) : new SqlParameter("OwnerState", DBNull.Value);
            SqlParameter ownerNameParameter = (ownerName != "") ? new SqlParameter("OwnerName", ownerName) : new SqlParameter("OwnerName", DBNull.Value);
            SqlParameter ownerContactParameter = (ownerContact != "") ? new SqlParameter("OwnerContact", ownerContact) : new SqlParameter("OwnerContact", DBNull.Value);
            SqlParameter qualifiedDateParameter = (qualifiedDate.HasValue) ? new SqlParameter("QualifiedDate", (DateTime)qualifiedDate) : new SqlParameter("QualifiedDate", DBNull.Value);
            SqlParameter notQualifiedDateParameter = (notQualifiedDate.HasValue) ? new SqlParameter("NotQualifiedDate", (DateTime)notQualifiedDate) : new SqlParameter("NotQualifiedDate", DBNull.Value);
            SqlParameter notQualifiedExplainParameter = (notQualifiedExplain != "") ? new SqlParameter("NotQualifiedExplain", notQualifiedExplain) : new SqlParameter("NotQualifiedExplain", DBNull.Value);
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter typeParameter = new SqlParameter("Type", type);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter notesParameter = (notes != "") ? new SqlParameter("Notes", notes) : new SqlParameter("Notes", DBNull.Value);
            SqlParameter categoriesParameter = (categories != "") ? new SqlParameter("Categories", categories) : new SqlParameter("Categories", DBNull.Value);
            SqlParameter insuranceClassParameter = (insuranceClass != "") ? new SqlParameter("InsuranceClass", insuranceClass) : new SqlParameter("insuranceClass", DBNull.Value);
            SqlParameter insuranceClassRyderSpecifiedParameter = (insuranceClassRyderSpecified != "") ? new SqlParameter("InsuranceClassRyderSpecified", insuranceClassRyderSpecified) : new SqlParameter("InsuranceClassRyderSpecified", DBNull.Value);
            SqlParameter purchasePriceParameter = (purchasePrice.HasValue) ? new SqlParameter("PurchasePrice", purchasePrice) : new SqlParameter("PurchasePrice", DBNull.Value);
            purchasePriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter scrapDateParameter = (scrapDate.HasValue) ? new SqlParameter("ScrapDate", (DateTime)scrapDate) : new SqlParameter("ScrapDate", DBNull.Value);
            SqlParameter saleProceedsParameter = (saleProceeds.HasValue) ? new SqlParameter("SaleProceeds", saleProceeds) : new SqlParameter("SaleProceeds", DBNull.Value);
            saleProceedsParameter.SqlDbType = SqlDbType.Money;
            SqlParameter libraryCategoriesIdParameter = (libraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", libraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);
            
            string command = "INSERT INTO [dbo].[LFS_FM_UNIT] ([UnitCode], [Description], [VIN], [Manufacturer], [Model], [Year_], [IsTowable], [CompanyLevelID], [AcquisitionDate], [DispositionDate], "+
                             " [DispositionReason], [OwnerType], [OwnerCountry], [OwnerState], [OwnerName], [OwnerContact], [QualifiedDate], [NotQualifiedDate], [NotQualifiedExplain], [State], [Type], "+
                             " [Deleted], [COMPANY_ID], [Notes], [Categories], [InsuranceClass], [InsuranceClassRyderSpecified], [PurchasePrice], [ScrapDate], [SaleProceeds], [LIBRARY_CATEGORIES_ID]) " +
                             " "+
                             " VALUES (@UnitCode, @Description, @VIN, @Manufacturer, @Model, @Year_, @IsTowable, @CompanyLevelID, @AcquisitionDate, @DispositionDate, @DispositionReason,  @OwnerType, "+
                             " @OwnerCountry, @OwnerState, @OwnerName, @OwnerContact, @QualifiedDate, @NotQualifiedDate, @NotQualifiedExplain, @State, @Type, @Deleted, @COMPANY_ID, @Notes, @Categories, "+
                             " @InsuranceClass, @InsuranceClassRyderSpecified, @PurchasePrice, @ScrapDate, @SaleProceeds, @LIBRARY_CATEGORIES_ID); " +
                             " SELECT UnitID FROM LFS_FM_UNIT WHERE (UnitID = SCOPE_IDENTITY())";

            int unitId = (int)ExecuteScalar(command, codeParameter, descriptionParameter, vinParameter, manufacturerParameter, modelParameter, yearParameter, isTowableParameter, companyLevelIdParameter, acquisitionDateParameter, dispositionDateParameter, dispositionReasonParameter, ownerTypeParameter, ownerCountryParameter, ownerStateParameter, ownerNameParameter, ownerContactParameter, qualifiedDateParameter, notQualifiedDateParameter, notQualifiedExplainParameter, stateParameter, typeParameter, deletedParameter, companyIdParameter, notesParameter, categoriesParameter, insuranceClassParameter, insuranceClassRyderSpecifiedParameter, purchasePriceParameter, scrapDateParameter, saleProceedsParameter, libraryCategoriesIdParameter);
            
            return unitId;
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCode">originalCode</param>
        /// <param name="originalDescription">originalDescription</param>
        /// <param name="originalVin">originalVin</param>
        /// <param name="originalManufacturer">originalManufacturer</param>
        /// <param name="originalModel">originalModel</param>
        /// <param name="originalYear_">originalYear_</param>
        /// <param name="originalIsTowable">originalIsTowable</param>
        /// <param name="originalCompanyLevelId">originalCompanyLevelId</param>
        /// <param name="originalAcquisitionDate">originalAcquisitionDate</param>
        /// <param name="originalDispositionDate">originalDispositionDate</param>
        /// <param name="originalDispositionReason">originalDispositionReason</param>       
        /// <param name="originalOwnerType">originalOwnerType</param>
        /// <param name="originalOwnerCountry">originalOwnerCountry</param>
        /// <param name="originalOwnerState">originalOwnerState</param>
        /// <param name="originalOwnerName">originalOwnerName</param>
        /// <param name="originalOwnerContact">originalOwnerContact</param>
        /// <param name="originalQualifiedDate">originalQualifiedDate</param>
        /// <param name="originalNotQualifiedDate">originalNotQualifiedDate</param>
        /// <param name="originalNotQualifiedExplain">originalNotQualifiedExplain</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalCategories">originalCategories</param>
        /// <param name="originalInsuranceClass">originalInsuranceClass</param>
        /// <param name="originalInsuranceClassRyderSpecified">originalInsuranceClassRyderSpecified</param>
        /// <param name="originalPurchasePrice">originalPurchasePrice</param>
        /// <param name="originalSaleProceeds">originalSaleProceeds</param>
        /// <param name="originalScrapDate">originalScrapDate</param>
        /// <param name="originalLibraryCategoriesId">originalLibraryCategoriesId</param>
        /// 
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newCode">newCode</param>
        /// <param name="newDescription">newDescription</param>
        /// <param name="newVin">newVin</param>
        /// <param name="newManufacturer">newManufacturer</param>
        /// <param name="newModel">newModel</param>
        /// <param name="newYear_">newYear_</param>
        /// <param name="newIsTowable">newIsTowable</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <param name="newAcquisitionDate">newAcquisitionDate</param>
        /// <param name="newDispositionDate"newDispositionDate></param>
        /// <param name="newDispositionReason">newDispositionReason</param>        
        /// <param name="newOwnerType">newOwnerType</param>
        /// <param name="newOwnerCountry">newOwnerCountry</param>
        /// <param name="newOwnerState">newOwnerState</param>
        /// <param name="newOwnerName">newOwnerName</param>
        /// <param name="newOwnerContact">newOwnerContact</param>
        /// <param name="newQualifiedDate">newQualifiedDate</param>
        /// <param name="newNotQualifiedDate">newNotQualifiedDate</param>
        /// <param name="newNotQualifiedExplain">newNotQualifiedExplain</param>
        /// <param name="newState">newState</param>
        /// <param name="newType">newType</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newCategories">newCategories</param>
        /// <param name="newInsuranceClass">newInsuranceClass</param>
        /// <param name="newInsuranceClassRyderSpecified">newInsuranceClassRyderSpecified</param>
        /// <param name="newPurchasePrice">newPurchasePrice</param>
        /// <param name="newSaleProceeds">newSaleProceeds</param>
        /// <param name="newScrapDate">newScrapDate</param>
        /// <param name="newLibraryCategoriesId">newLibraryCategoriesId</param>
        public void Update(int originalUnitId, string originalUnitCode, string originalDescription, string originalVin, string originalManufacturer, string originalModel, string originalYear_, bool originalIsTowable, int originalCompanyLevelId, DateTime? originalAcquisitionDate, DateTime? originalDispositionDate, string originalDispositionReason, string originalOwnerType, Int64? originalOwnerCountry, Int64? originalOwnerState, string originalOwnerName, string originalOwnerContact, DateTime? originalQualifiedDate, DateTime? originalNotQualifiedDate, string originalNotQualifiedExplain, string originalState, string originalType, bool originalDeleted, int originalCompanyId, string originalNotes, string originalCategories, string originalInsuranceClass, string originalInsuranceClassRyderSpecified, decimal? originalPurchasePrice, DateTime? originalScrapDate, decimal? originalSaleProceeds, int? originalLibraryCategoriesId, int newUnitId, string newUnitCode, string newDescription, string newVin, string newManufacturer, string newModel, string newYear_, bool newIsTowable, int newCompanyLevelId, DateTime? newAcquisitionDate, DateTime? newDispositionDate, string newDispositionReason, string newOwnerType, Int64? newOwnerCountry, Int64? newOwnerState, string newOwnerName, string newOwnerContact, DateTime? newQualifiedDate, DateTime? newNotQualifiedDate, string newNotQualifiedExplain, string newState, string newType, bool newDeleted, int newCompanyId, string newNotes, string newCategories, string newInsuranceClass, string newInsuranceClassRyderSpecified, decimal? newPurchasePrice, DateTime? newScrapDate, decimal? newSaleProceeds, int? newLibraryCategoriesId)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalUnitCodeParameter = new SqlParameter("Original_UnitCode", originalUnitCode);
            SqlParameter originalDescriptionParameter = (originalDescription.Trim() != "") ? new SqlParameter("Original_Description", originalDescription) : new SqlParameter("Original_Description", DBNull.Value);
            SqlParameter originalVinParameter = (originalVin != "") ? new SqlParameter("Original_VIN", originalVin) : new SqlParameter("Original_VIN", DBNull.Value);
            SqlParameter originalManufacturerParameter = (originalManufacturer != "") ? new SqlParameter("Original_Manufacturer", originalManufacturer) : new SqlParameter("Original_Manufacturer", DBNull.Value);
            SqlParameter originalModelParameter = (originalModel != "") ? new SqlParameter("Original_Model", originalModel) : new SqlParameter("Original_Model", DBNull.Value);
            SqlParameter originalYearParameter = (originalYear_ != "") ? new SqlParameter("Original_Year_", originalYear_) : new SqlParameter("Original_Year_", DBNull.Value);
            SqlParameter originalIsTowableParameter = new SqlParameter("Original_IsTowable", originalIsTowable);
            SqlParameter originalCompanyLevelIdParameter = new SqlParameter("Original_CompanyLevelID", originalCompanyLevelId);
            SqlParameter originalAcquisitionDateParameter = (originalAcquisitionDate.HasValue) ? new SqlParameter("Original_AcquisitionDate", (DateTime)originalAcquisitionDate) : new SqlParameter("Original_AcquisitionDate", DBNull.Value);
            SqlParameter originalDispositionDateParameter = (originalDispositionDate.HasValue) ? new SqlParameter("Original_DispositionDate", (DateTime)originalDispositionDate) : new SqlParameter("Original_DispositionDate", DBNull.Value);
            SqlParameter originalDispositionReasonParameter = (originalDispositionReason != "") ? new SqlParameter("Original_DispositionReason", originalDispositionReason) : new SqlParameter("Original_DispositionReason", DBNull.Value);            
            SqlParameter originalOwnerTypeParameter = (originalOwnerType != "") ? new SqlParameter("Original_OwnerType", originalOwnerType) : new SqlParameter("Original_OwnerType", DBNull.Value);
            SqlParameter originalOwnerCountryParameter = (originalOwnerCountry.HasValue) ? new SqlParameter("Original_OwnerCountry", (Int64)originalOwnerCountry) : new SqlParameter("Original_OwnerCountry", DBNull.Value);
            SqlParameter originalOwnerStateParameter = (originalOwnerState.HasValue) ? new SqlParameter("Original_OwnerState", (Int64)originalOwnerState) : new SqlParameter("Original_OwnerState", DBNull.Value);
            SqlParameter originalOwnerNameParameter = (originalOwnerName != "") ? new SqlParameter("Original_OwnerName", originalOwnerName) : new SqlParameter("Original_OwnerName", DBNull.Value);
            SqlParameter originalOwnerContactParameter = (originalOwnerContact != "") ? new SqlParameter("Original_OwnerContact", originalOwnerContact) : new SqlParameter("Original_OwnerContact", DBNull.Value);
            SqlParameter originalQualifiedDateParameter = (originalQualifiedDate.HasValue) ? new SqlParameter("Original_QualifiedDate", (DateTime)originalQualifiedDate) : new SqlParameter("Original_QualifiedDate", DBNull.Value);
            SqlParameter originalNotQualifiedDateParameter = (originalNotQualifiedDate.HasValue) ? new SqlParameter("Original_NotQualifiedDate", (DateTime)originalNotQualifiedDate) : new SqlParameter("Original_NotQualifiedDate", DBNull.Value);
            SqlParameter originalNotQualifiedExplainParameter = (originalNotQualifiedExplain != "") ? new SqlParameter("Original_NotQualifiedExplain", originalNotQualifiedExplain) : new SqlParameter("Original_NotQualifiedExplain", DBNull.Value);
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalTypeParameter = new SqlParameter("Original_Type", originalType);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter originalNotesParameter = (originalNotes != "") ? new SqlParameter("Original_Notes", originalNotes) : new SqlParameter("Original_Notes", DBNull.Value);
            SqlParameter originalCategoriesParameter = (originalCategories != "") ? new SqlParameter("Original_Categories", originalCategories) : new SqlParameter("Original_Categories", DBNull.Value);
            SqlParameter originalInsuranceClassParameter = (originalInsuranceClass != "") ? new SqlParameter("Original_InsuranceClass", originalInsuranceClass) : new SqlParameter("Original_InsuranceClass", DBNull.Value);
            SqlParameter originalInsuranceClassRyderSpecifiedParameter = (originalInsuranceClassRyderSpecified != "") ? new SqlParameter("Original_InsuranceClassRyderSpecified", originalInsuranceClassRyderSpecified) : new SqlParameter("Original_InsuranceClassRyderSpecified", DBNull.Value);
            SqlParameter originalPurchasePriceParameter = (originalPurchasePrice.HasValue) ? new SqlParameter("Original_PurchasePrice", originalPurchasePrice) : new SqlParameter("Original_PurchasePrice", DBNull.Value);
            originalPurchasePriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalScrapDateParameter = (originalScrapDate.HasValue) ? new SqlParameter("Original_ScrapDate", (DateTime)originalScrapDate) : new SqlParameter("Original_ScrapDate", DBNull.Value);
            SqlParameter originalSaleProceedsParameter = (originalSaleProceeds.HasValue) ? new SqlParameter("Original_SaleProceeds", originalSaleProceeds) : new SqlParameter("Original_SaleProceeds", DBNull.Value);
            originalSaleProceedsParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalLibraryCategoriesIdParameter = (originalLibraryCategoriesId.HasValue) ? new SqlParameter("Original_LIBRARY_CATEGORIES_ID", originalLibraryCategoriesId) : new SqlParameter("Original_LIBRARY_CATEGORIES_ID", DBNull.Value);

            SqlParameter newUnitIdParameter = new SqlParameter("UnitID", newUnitId);
            SqlParameter newUnitCodeParameter = new SqlParameter("UnitCode", newUnitCode);
            SqlParameter newDescriptionParameter = (newDescription.Trim() != "") ? new SqlParameter("Description", newDescription) : new SqlParameter("Description", DBNull.Value);
            SqlParameter newVinParameter = (newVin != "") ? new SqlParameter("VIN", newVin) : new SqlParameter("VIN", DBNull.Value);
            SqlParameter newManufacturerParameter = (newManufacturer != "") ? new SqlParameter("Manufacturer", newManufacturer) : new SqlParameter("Manufacturer", DBNull.Value);
            SqlParameter newModelParameter = (newModel != "") ? new SqlParameter("Model", newModel) : new SqlParameter("Model", DBNull.Value);
            SqlParameter newYearParameter = (newYear_ != "") ? new SqlParameter("Year_", newYear_) : new SqlParameter("Year_", DBNull.Value);
            SqlParameter newIsTowableParameter = new SqlParameter("IsTowable", newIsTowable);
            SqlParameter newCompanyLevelIdParameter = new SqlParameter("CompanyLevelID", newCompanyLevelId);
            SqlParameter newAcquisitionDateParameter = (newAcquisitionDate.HasValue) ? new SqlParameter("AcquisitionDate", (DateTime)newAcquisitionDate) : new SqlParameter("AcquisitionDate", DBNull.Value);
            SqlParameter newDispositionDateParameter = (newDispositionDate.HasValue) ? new SqlParameter("DispositionDate", (DateTime)newDispositionDate) : new SqlParameter("DispositionDate", DBNull.Value);
            SqlParameter newDispositionReasonParameter = (newDispositionReason != "") ? new SqlParameter("DispositionReason", newDispositionReason) : new SqlParameter("DispositionReason", DBNull.Value);            
            SqlParameter newOwnerTypeParameter = (newOwnerType != "") ? new SqlParameter("OwnerType", newOwnerType) : new SqlParameter("OwnerType", DBNull.Value);
            SqlParameter newOwnerCountryParameter = (newOwnerCountry.HasValue) ? new SqlParameter("OwnerCountry", (Int64)newOwnerCountry) : new SqlParameter("OwnerCountry", DBNull.Value);
            SqlParameter newOwnerStateParameter = (newOwnerState.HasValue) ? new SqlParameter("OwnerState", (Int64)newOwnerState) : new SqlParameter("OwnerState", DBNull.Value);
            SqlParameter newOwnerNameParameter = (newOwnerName != "") ? new SqlParameter("OwnerName", newOwnerName) : new SqlParameter("OwnerName", DBNull.Value);
            SqlParameter newOwnerContactParameter = (newOwnerContact != "") ? new SqlParameter("OwnerContact", newOwnerContact) : new SqlParameter("OwnerContact", DBNull.Value);
            SqlParameter newQualifiedDateParameter = (newQualifiedDate.HasValue) ? new SqlParameter("QualifiedDate", (DateTime)newQualifiedDate) : new SqlParameter("QualifiedDate", DBNull.Value);
            SqlParameter newNotQualifiedDateParameter = (newNotQualifiedDate.HasValue) ? new SqlParameter("NotQualifiedDate", (DateTime)newNotQualifiedDate) : new SqlParameter("NotQualifiedDate", DBNull.Value);
            SqlParameter newNotQualifiedExplainParameter = (newNotQualifiedExplain != "") ? new SqlParameter("NotQualifiedExplain", newNotQualifiedExplain) : new SqlParameter("NotQualifiedExplain", DBNull.Value);
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newTypeParameter = new SqlParameter("Type", newType);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);
            SqlParameter newNotesParameter = (newNotes != "") ? new SqlParameter("Notes", newNotes) : new SqlParameter("Notes", DBNull.Value);
            SqlParameter newCategoriesParameter = (newCategories != "") ? new SqlParameter("Categories", newCategories) : new SqlParameter("Categories", DBNull.Value);
            SqlParameter newInsuranceClassParameter = (newInsuranceClass != "") ? new SqlParameter("InsuranceClass", newInsuranceClass) : new SqlParameter("InsuranceClass", DBNull.Value);
            SqlParameter newInsuranceClassRyderSpecifiedParameter = (newInsuranceClassRyderSpecified != "") ? new SqlParameter("InsuranceClassRyderSpecified", newInsuranceClassRyderSpecified) : new SqlParameter("InsuranceClassRyderSpecified", DBNull.Value);
            SqlParameter newPurchasePriceParameter = (newPurchasePrice.HasValue) ? new SqlParameter("PurchasePrice", newPurchasePrice) : new SqlParameter("PurchasePrice", DBNull.Value);
            newPurchasePriceParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newScrapDateParameter = (newScrapDate.HasValue) ? new SqlParameter("ScrapDate", (DateTime)newScrapDate) : new SqlParameter("ScrapDate", DBNull.Value);
            SqlParameter newSaleProceedsParameter = (newSaleProceeds.HasValue) ? new SqlParameter("SaleProceeds", newSaleProceeds) : new SqlParameter("SaleProceeds", DBNull.Value);
            newSaleProceedsParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newLibraryCategoriesIdParameter = (newLibraryCategoriesId.HasValue) ? new SqlParameter("LIBRARY_CATEGORIES_ID", newLibraryCategoriesId) : new SqlParameter("LIBRARY_CATEGORIES_ID", DBNull.Value);
            
            string command = "UPDATE [dbo].[LFS_FM_UNIT] " +
                "SET [UnitCode] = @UnitCode, [Description] = @Description, [VIN] = @VIN, " +
                "[Manufacturer] = @Manufacturer, [Model] = @Model, [Year_] = @Year_, [IsTowable] = @IsTowable, " +
                "[CompanyLevelID] = @CompanyLevelID, [AcquisitionDate] = @AcquisitionDate, " +
                "[DispositionDate] = @DispositionDate, [DispositionReason] = @DispositionReason, " +
                "[OwnerType] = @OwnerType, [OwnerCountry] = @OwnerCountry, " +
                "[OwnerState] = @OwnerState, [OwnerName] = @OwnerName, [OwnerContact] = @OwnerContact, " +
                "[QualifiedDate] = @QualifiedDate, [NotQualifiedDate] = @NotQualifiedDate, " +
                "[NotQualifiedExplain] = @NotQualifiedExplain, [State] = @State, [Type] = @Type, " +
                "[Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID, [Notes] = @Notes, [Categories] = @Categories, " +
                "[InsuranceClass] = @InsuranceClass, [InsuranceClassRyderSpecified] = @InsuranceClassRyderSpecified, "+
                "[PurchasePrice] = @PurchasePrice, [ScrapDate] = @ScrapDate, [SaleProceeds] = @SaleProceeds, [LIBRARY_CATEGORIES_ID] = @LIBRARY_CATEGORIES_ID "+
                "WHERE (" +
                "([UnitID] = @Original_UnitID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalUnitCodeParameter, originalDescriptionParameter, originalVinParameter, originalManufacturerParameter, originalModelParameter, originalYearParameter, originalIsTowableParameter, originalCompanyLevelIdParameter, originalAcquisitionDateParameter, originalDispositionDateParameter, originalDispositionReasonParameter, originalOwnerTypeParameter, originalOwnerCountryParameter, originalOwnerStateParameter, originalOwnerNameParameter, originalOwnerContactParameter, originalQualifiedDateParameter, originalNotQualifiedDateParameter, originalNotQualifiedExplainParameter, originalStateParameter, originalTypeParameter, originalDeletedParameter, originalCompanyIdParameter, originalNotesParameter, originalCategoriesParameter, originalInsuranceClassParameter, originalInsuranceClassRyderSpecifiedParameter, originalPurchasePriceParameter, originalScrapDateParameter, originalLibraryCategoriesIdParameter, newUnitIdParameter, newUnitCodeParameter, newDescriptionParameter, newVinParameter, newManufacturerParameter, newModelParameter, newYearParameter, newIsTowableParameter, newCompanyLevelIdParameter, newAcquisitionDateParameter, newDispositionDateParameter, newDispositionReasonParameter, newOwnerTypeParameter, newOwnerCountryParameter, newOwnerStateParameter, newOwnerNameParameter, newOwnerContactParameter, newQualifiedDateParameter, newNotQualifiedDateParameter, newNotQualifiedExplainParameter, newStateParameter, newTypeParameter, newDeletedParameter, newCompanyIdParameter, newNotesParameter, newCategoriesParameter, newInsuranceClassParameter, newInsuranceClassRyderSpecifiedParameter, newPurchasePriceParameter, newScrapDateParameter, newSaleProceedsParameter, newLibraryCategoriesIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// Delete unit(direct to DB)
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <returns>int</returns>
        public int Delete(int originalUnitId, int originalCompanyId)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_UNIT] SET  [Deleted] = @Deleted  " +
                             " WHERE (([UnitID] = @Original_UnitID) AND " +
                             "  ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalCompanyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }

            return rowsAffected;
        }



        /// <summary>
        /// UpdateCompanyLevel(direct to DB)
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newCompanyLevelId">newCompanyLevelId</param>
        /// <returns>int</returns>
        public void UpdateCompanyLevel(int originalUnitId, bool originalDeleted, int originalCompanyId, int newCompanyLevelId)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);
            
            SqlParameter newCompanyLevelIdParameter = new SqlParameter("CompanyLevelID", newCompanyLevelId);
                        
            string command = "UPDATE [dbo].[LFS_FM_UNIT] " +
                "SET [CompanyLevelID] = @CompanyLevelID " +
                "WHERE (" +
                "([UnitID] = @Original_UnitID) AND ([Deleted] = @Original_Deleted) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalDeletedParameter, originalCompanyIdParameter, newCompanyLevelIdParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// UpdateState
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// <param name="newState">newState</param>
        public void UpdateState(int originalUnitId, int originalCompanyId, string newState)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newStateParameter = new SqlParameter("State", newState);

            string command = "UPDATE [dbo].[LFS_FM_UNIT] " +
                "SET [State] = @State " +
                "WHERE (" +
                "([UnitID] = @Original_UnitID) AND " +
                " ([COMPANY_ID] = @Original_COMPANY_ID)" +
                " )";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalCompanyIdParameter, newStateParameter);
            
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - QUERIES
        //

        /// <summary>
        /// GetLastUnitId
        /// </summary>
        /// <returns>Last UnitID</returns>
        public int GetLastUnitId()
        {
            string commandText = "SELECT MAX(UnitID) AS unitId FROM LFS_FM_UNIT";
            SqlCommand command = new SqlCommand(commandText, DB.Connection);

            return ((int)ExecuteScalar(command));
        }



    }
}