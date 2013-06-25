using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsInspectionGateway
    /// </summary>
    public class UnitsInspectionGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsInspectionGateway()
            : base("LFS_FM_UNIT_INSPECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsInspectionGateway(DataSet data)
            : base(data, "LFS_FM_UNIT_INSPECTION")
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
            tableMapping.DataSetTable = "LFS_FM_UNIT_INSPECTION";
            tableMapping.ColumnMappings.Add("UnitID", "UnitID");
            tableMapping.ColumnMappings.Add("InspectionID", "InspectionID");
            tableMapping.ColumnMappings.Add("Date_", "Date_");
            tableMapping.ColumnMappings.Add("Country", "Country");
            tableMapping.ColumnMappings.Add("State", "State");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("Result", "Result");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Notes", "Notes");
            tableMapping.ColumnMappings.Add("InspectedBy", "InspectedBy");
            tableMapping.ColumnMappings.Add("Attach", "Attach");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            this._adapter.TableMappings.Add(tableMapping);

            this._adapter.DeleteCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.DeleteCommand.Connection = DB.Connection;
            this._adapter.DeleteCommand.CommandText = @"DELETE FROM [dbo].[LFS_FM_UNIT_INSPECTION] WHERE (([UnitID] = @Original_UnitID) AND ([InspectionID] = @Original_InspectionID) AND ([Date_] = @Original_Date_) AND ([Country] = @Original_Country) AND ([State] = @Original_State) AND ([Type] = @Original_Type) AND ((@IsNull_Result = 1 AND [Result] IS NULL) OR ([Result] = @Original_Result)) AND ((@IsNull_Cost = 1 AND [Cost] IS NULL) OR ([Cost] = @Original_Cost)) AND ((@IsNull_InspectedBy = 1 AND [InspectedBy] IS NULL) OR ([InspectedBy] = @Original_InspectedBy)) AND ((@IsNull_Attach = 1 AND [Attach] IS NULL) OR ([Attach] = @Original_Attach)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";
            this._adapter.DeleteCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InspectionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Country", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Country", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Result", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Result", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Result", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Result", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InspectedBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectedBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InspectedBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectedBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Attach", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Attach", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Attach", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Attach", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.DeleteCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            
            this._adapter.InsertCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.InsertCommand.Connection = DB.Connection;
            this._adapter.InsertCommand.CommandText = @"INSERT INTO [dbo].[LFS_FM_UNIT_INSPECTION] ([UnitID], [InspectionID], [Date_], [Country], [State], [Type], [Result], [Cost], [Notes], [InspectedBy], [Attach], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @InspectionID, @Date_, @Country, @State, @Type, @Result, @Cost, @Notes, @InspectedBy, @Attach, @Deleted, @COMPANY_ID);
SELECT UnitID, InspectionID, Date_, Country, State, Type, Result, Cost, Notes, InspectedBy, Attach, Deleted, COMPANY_ID FROM LFS_FM_UNIT_INSPECTION WHERE (InspectionID = @InspectionID) AND (UnitID = @UnitID)";
            this._adapter.InsertCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InspectionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Country", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Country", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Result", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Result", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Notes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Notes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InspectedBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectedBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Attach", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Attach", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.InsertCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            
            this._adapter.UpdateCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.UpdateCommand.Connection = DB.Connection;
            this._adapter.UpdateCommand.CommandText = @"UPDATE [dbo].[LFS_FM_UNIT_INSPECTION] SET [UnitID] = @UnitID, [InspectionID] = @InspectionID, [Date_] = @Date_, [Country] = @Country, [State] = @State, [Type] = @Type, [Result] = @Result, [Cost] = @Cost, [Notes] = @Notes, [InspectedBy] = @InspectedBy, [Attach] = @Attach, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID WHERE (([UnitID] = @Original_UnitID) AND ([InspectionID] = @Original_InspectionID) AND ([Date_] = @Original_Date_) AND ([Country] = @Original_Country) AND ([State] = @Original_State) AND ([Type] = @Original_Type) AND ((@IsNull_Result = 1 AND [Result] IS NULL) OR ([Result] = @Original_Result)) AND ((@IsNull_Cost = 1 AND [Cost] IS NULL) OR ([Cost] = @Original_Cost)) AND ((@IsNull_InspectedBy = 1 AND [InspectedBy] IS NULL) OR ([InspectedBy] = @Original_InspectedBy)) AND ((@IsNull_Attach = 1 AND [Attach] IS NULL) OR ([Attach] = @Original_Attach)) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID));
SELECT UnitID, InspectionID, Date_, Country, State, Type, Result, Cost, Notes, InspectedBy, Attach, Deleted, COMPANY_ID FROM LFS_FM_UNIT_INSPECTION WHERE (InspectionID = @InspectionID) AND (UnitID = @UnitID)";
            this._adapter.UpdateCommand.CommandType = global::System.Data.CommandType.Text;
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InspectionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectionID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Country", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Country", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@State", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Result", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Result", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Notes", global::System.Data.SqlDbType.NText, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Notes", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@InspectedBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectedBy", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Attach", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Attach", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Current, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_UnitID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "UnitID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InspectionID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectionID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Date_", global::System.Data.SqlDbType.DateTime, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Date_", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Country", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Country", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_State", global::System.Data.SqlDbType.BigInt, 0, global::System.Data.ParameterDirection.Input, 0, 0, "State", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Type", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Type", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Result", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Result", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Result", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Result", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Cost", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Cost", global::System.Data.SqlDbType.Money, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Cost", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_InspectedBy", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectedBy", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_InspectedBy", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "InspectedBy", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@IsNull_Attach", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Attach", global::System.Data.DataRowVersion.Original, true, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Attach", global::System.Data.SqlDbType.NVarChar, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Attach", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_Deleted", global::System.Data.SqlDbType.Bit, 0, global::System.Data.ParameterDirection.Input, 0, 0, "Deleted", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));
            this._adapter.UpdateCommand.Parameters.Add(new global::System.Data.SqlClient.SqlParameter("@Original_COMPANY_ID", global::System.Data.SqlDbType.Int, 0, global::System.Data.ParameterDirection.Input, 0, 0, "COMPANY_ID", global::System.Data.DataRowVersion.Original, false, null, "", "", ""));

            this._adapter.SelectCommand = new System.Data.SqlClient.SqlCommand();
            this._adapter.SelectCommand.Connection = DB.Connection;
            this._adapter.SelectCommand.CommandText = "";
            this._adapter.SelectCommand.CommandType = CommandType.Text;

            #endregion
        }





                       
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - SINGLE ROW
        //

        /// <summary>
        /// LoadByUnitIdInspectionId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitIdInspectionId(int unitId, int inspectionId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSINSPECTIONGATEWAY_LOADBYUNITIDINSPECTIONID", new SqlParameter("@unitId", unitId), new SqlParameter("@inspectionId", inspectionId), new SqlParameter("@companyId", companyId));
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
            FillDataWithStoredProcedure("LFS_FM_UNITSINSPECTIONGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single inspection
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId, int inspectionId)
        {
            string filter = string.Format("(UnitId = {0}) AND (InspectionID = {1})", unitId, inspectionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsInspectionGateway.GetRow");
            }
        }



        /// <summary>
        /// GetCountry
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Country</returns>
        public Int64 GetCountry(int unitId, int inspectionId)
        {
            return (Int64)GetRow(unitId, inspectionId)["Country"];
        }



        /// <summary>
        /// GetCountry
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Country</returns>
        public Int64 GetState(int unitId, int inspectionId)
        {
            return (Int64)GetRow(unitId, inspectionId)["State"];
        }



        /// <summary>
        /// GetDate_
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Date_</returns>
        public DateTime GetDate_(int unitId, int inspectionId)
        {
            return (DateTime)GetRow(unitId, inspectionId)["Date_"];
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="date_">date_</param>
        /// <param name="country">country</param>
        /// <param name="state">state</param>
        /// <param name="type">type</param>
        /// <param name="result">result</param>
        /// <param name="cost">cost</param>
        /// <param name="notes">notes</param>
        /// <param name="inspectedBy">inspectedBy</param>
        /// <param name="attach">attach</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        public void Insert(int unitId, int inspectionId, DateTime date_, Int64 country, Int64 state, string type, string result, decimal? cost, string notes, string inspectedBy, string attach, bool deleted, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter inspectionIdParameter = new SqlParameter("InspectionID", inspectionId);
            SqlParameter date_Parameter = new SqlParameter("Date_", date_);            
            SqlParameter countryParameter = new SqlParameter("Country", country);
            SqlParameter stateParameter = new SqlParameter("State", state);
            SqlParameter typeParameter = new SqlParameter("Type", type);
            SqlParameter resultParameter = (result != "") ? new SqlParameter("Result", result) : new SqlParameter("Result", DBNull.Value);
            SqlParameter costParameter = (cost.HasValue) ? new SqlParameter("Cost", (decimal)cost) : new SqlParameter("Cost", DBNull.Value);
            costParameter.SqlDbType = SqlDbType.Money;
            SqlParameter notesParameter = (notes != "") ? new SqlParameter("Notes", notes) : new SqlParameter("Notes", DBNull.Value);
            SqlParameter inspectedByParameter = (inspectedBy != "") ? new SqlParameter("InspectedBy", inspectedBy) : new SqlParameter("InspectedBy", DBNull.Value);
            SqlParameter attachParameter = (attach != "") ? new SqlParameter("Attach", attach) : new SqlParameter("Attach", DBNull.Value);
            SqlParameter deletedParameter = new SqlParameter("Deleted", deleted);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
                        
            string command = "INSERT INTO [dbo].[LFS_FM_UNIT_INSPECTION] ([UnitID], [InspectionID], [Date_], [Country], [State], [Type], [Result], [Cost], [Notes], [InspectedBy], [Attach], [Deleted], [COMPANY_ID]) VALUES (@UnitID, @InspectionID, @Date_, @Country, @State, @Type, @Result, @Cost, @Notes, @InspectedBy, @Attach, @Deleted, @COMPANY_ID)";

            ExecuteScalar(command, unitIdParameter, inspectionIdParameter, date_Parameter, countryParameter, stateParameter, typeParameter, resultParameter, costParameter, notesParameter, inspectedByParameter, attachParameter, deletedParameter, companyIdParameter);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="originalUnitId">originalUnitId</param>
        /// <param name="originalInspectionId">originalInspectionId</param>
        /// <param name="originalDate_">originalDate_</param>
        /// <param name="originalCountry">originalCountry</param>
        /// <param name="originalState">originalState</param>
        /// <param name="originalType">originalType</param>
        /// <param name="originalResult">originalResult</param>
        /// <param name="originalCost">originalCost</param>
        /// <param name="originalNotes">originalNotes</param>
        /// <param name="originalInspectedBy">originalInspectedBy</param>
        /// <param name="originalAttach">originalAttach</param>
        /// <param name="originalDeleted">originalDeleted</param>
        /// <param name="originalCompanyId">originalCompanyId</param>
        /// 
        /// <param name="newUnitId">newUnitId</param>
        /// <param name="newInspectionId">newInspectionId</param>
        /// <param name="newDate_">newDate_</param>
        /// <param name="newCountry">newCountry</param>
        /// <param name="newState">newState</param>
        /// <param name="newType">newType</param>
        /// <param name="newResult">newResult</param>
        /// <param name="newCost">newCost</param>
        /// <param name="newNotes">newNotes</param>
        /// <param name="newInspectedBy">newInspectedBy</param>
        /// <param name="newAttach">newAttach</param>
        /// <param name="newDeleted">newDeleted</param>
        /// <param name="newCompanyId">newCompanyId</param>
        public void Update(int originalUnitId, int originalInspectionId, DateTime originalDate_, Int64 originalCountry, Int64 originalState, string originalType, string originalResult, decimal? originalCost, string originalNotes, string originalInspectedBy, string originalAttach, bool originalDeleted, int originalCompanyId, int newUnitId, int newInspectionId, DateTime newDate_, Int64 newCountry, Int64 newState, string newType, string newResult, decimal? newCost, string newNotes, string newInspectedBy, string newAttach, bool newDeleted, int newCompanyId)
        {
            SqlParameter originalUnitIdParameter = new SqlParameter("Original_UnitID", originalUnitId);
            SqlParameter originalInspectionIdParameter = new SqlParameter("Original_InspectionID", originalInspectionId);
            SqlParameter originalDate_Parameter = new SqlParameter("Original_Date_", originalDate_);
            SqlParameter originalCountryParameter = new SqlParameter("Original_Country", originalCountry);
            SqlParameter originalStateParameter = new SqlParameter("Original_State", originalState);
            SqlParameter originalTypeParameter = new SqlParameter("Original_Type", originalType);
            SqlParameter originalResultParameter = (originalResult != "") ? new SqlParameter("Original_Result", originalResult) : new SqlParameter("Original_Result", DBNull.Value);
            SqlParameter originalCostParameter = (originalCost.HasValue) ? new SqlParameter("Original_Cost", (decimal)originalCost) : new SqlParameter("Original_Cost", DBNull.Value);
            originalCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter originalNotesParameter = (originalNotes != "") ? new SqlParameter("Original_Notes", originalNotes) : new SqlParameter("Original_Notes", DBNull.Value);
            SqlParameter originalInspectedByParameter = (originalInspectedBy != "") ? new SqlParameter("Original_InspectedBy", originalInspectedBy) : new SqlParameter("Original_InspectedBy", DBNull.Value);
            SqlParameter originalAttachParameter = (originalAttach != "") ? new SqlParameter("Original_Attach", originalAttach) : new SqlParameter("Original_Attach", DBNull.Value);
            SqlParameter originalDeletedParameter = new SqlParameter("Original_Deleted", originalDeleted);
            SqlParameter originalCompanyIdParameter = new SqlParameter("Original_COMPANY_ID", originalCompanyId);

            SqlParameter newUnitIdParameter = new SqlParameter("UnitID", newUnitId);
            SqlParameter newInspectionIdParameter = new SqlParameter("InspectionID", newInspectionId);
            SqlParameter newDate_Parameter = new SqlParameter("Date_", newDate_);
            SqlParameter newCountryParameter = new SqlParameter("Country", newCountry);
            SqlParameter newStateParameter = new SqlParameter("State", newState);
            SqlParameter newTypeParameter = new SqlParameter("Type", newType);
            SqlParameter newResultParameter = (newResult != "") ? new SqlParameter("Result", newResult) : new SqlParameter("Result", DBNull.Value);
            SqlParameter newCostParameter = (newCost.HasValue) ? new SqlParameter("Cost", (decimal)newCost) : new SqlParameter("Cost", DBNull.Value);
            newCostParameter.SqlDbType = SqlDbType.Money;
            SqlParameter newNotesParameter = (newNotes != "") ? new SqlParameter("Notes", newNotes) : new SqlParameter("Notes", DBNull.Value);
            SqlParameter newInspectedByParameter = (newInspectedBy != "") ? new SqlParameter("InspectedBy", newInspectedBy) : new SqlParameter("InspectedBy", DBNull.Value);
            SqlParameter newAttachParameter = (newAttach != "") ? new SqlParameter("Attach", newAttach) : new SqlParameter("Attach", DBNull.Value);
            SqlParameter newDeletedParameter = new SqlParameter("Deleted", newDeleted);
            SqlParameter newCompanyIdParameter = new SqlParameter("COMPANY_ID", newCompanyId);

            string command = "UPDATE [dbo].[LFS_FM_UNIT_INSPECTION] SET [UnitID] = @UnitID, [InspectionID] = @InspectionID, [Date_] = @Date_, [Country] = @Country, [State] = @State, [Type] = @Type, [Result] = @Result, [Cost] = @Cost, [Notes] = @Notes, [InspectedBy] = @InspectedBy, [Attach] = @Attach, [Deleted] = @Deleted, [COMPANY_ID] = @COMPANY_ID " +
                 "WHERE (([UnitID] = @Original_UnitID) AND ([InspectionID] = @Original_InspectionID) AND ([Deleted] = @Original_Deleted) AND ([COMPANY_ID] = @Original_COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, originalUnitIdParameter, originalInspectionIdParameter, originalDate_Parameter, originalCountryParameter, originalStateParameter, originalTypeParameter, originalResultParameter, originalCostParameter, originalNotesParameter, originalInspectedByParameter, originalAttachParameter, originalDeletedParameter, originalCompanyIdParameter, newUnitIdParameter, newInspectionIdParameter, newDate_Parameter, newCountryParameter, newStateParameter, newTypeParameter, newResultParameter, newCostParameter, newNotesParameter, newInspectedByParameter, newAttachParameter, newDeletedParameter, newCompanyIdParameter);
            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }



        /// <summary>
        /// delete
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="inspectionId">inspectionId</param>
        /// <param name="companyId">companyId</param>
        public void Delete(int unitId, int inspectionId, int companyId)
        {
            SqlParameter unitIdParameter = new SqlParameter("UnitID", unitId);
            SqlParameter inspectionIdParameter = new SqlParameter("InspectionID", inspectionId);
            SqlParameter companyIdParameter = new SqlParameter("COMPANY_ID", companyId);
            SqlParameter deletedParameter = new SqlParameter("Deleted", 1);

            string command = "UPDATE [dbo].[LFS_FM_UNIT_INSPECTION] SET [Deleted] = @Deleted WHERE (([UnitID] = @UnitID) AND ([InspectionID] = @InspectionID) AND ([COMPANY_ID] = @COMPANY_ID))";

            int rowsAffected = (int)ExecuteNonQuery(command, unitIdParameter, inspectionIdParameter, companyIdParameter, deletedParameter);

            if (rowsAffected == 0)
            {
                throw new Exception("Concurrency error");
            }
        }        

       
 
    }
}
