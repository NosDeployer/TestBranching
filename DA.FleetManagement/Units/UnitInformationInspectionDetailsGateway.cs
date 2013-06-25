using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitInformationInspectionDetailsGateway
    /// </summary>
    public class UnitInformationInspectionDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Default constructor
        /// </summary>
        public UnitInformationInspectionDetailsGateway()
            : base("InspectionDetails")
        {
        }



        /// <summary>
        /// Constructor. Replace a default dataset
        /// </summary>
        /// <param name="data">Dataset</param>
        public UnitInformationInspectionDetailsGateway(DataSet data)
            : base(data, "InspectionDetails")
        {
        }



        /// <summary>
        /// InitData. 
        /// </summary>
        protected override void InitData()
        {
            _data = new UnitInformationTDS();
        }



        /// <summary>
        /// InitAdapter (empty)
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.SourceTable = "Table";
            tableMapping.DataSetTable = "InspectionDetails";
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
        /// LoadByUnitId
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadByUnitId(int unitId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITINFORMATIONINSPECTIONDETAILSGATEWAY_LOADBYUNITID", new SqlParameter("@unitId", unitId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Row</returns>
        public DataRow GetRow(int inspectionId)
        {
            string filter = string.Format("(InspectionID  = {0})", inspectionId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitInformationInspectionDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDate_
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Date_ or EMPTY</returns>
        public DateTime GetDate_(int inspectionId)
        {
            return (DateTime)GetRow(inspectionId)["Date_"];            
        }



        /// <summary>
        /// GetDate_ Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Date_ or EMPTY</returns>
        public DateTime GetDate_Original(int inspectionId)
        {
            return (DateTime)GetRow(inspectionId)["Date_", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCountry
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Country</returns>
        public Int64 GetCountry(int inspectionId)
        {
            return (Int64)GetRow(inspectionId)["Country"];
        }



        /// <summary>
        /// GetCountry Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Country or EMPTY</returns>
        public Int64 GetCountryOriginal(int inspectionId)
        {
            return (Int64)GetRow(inspectionId)["Country", DataRowVersion.Original];
        }



        /// <summary>
        /// GetState
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>State</returns>
        public Int64 GetState(int inspectionId)
        {
            return (Int64)GetRow(inspectionId)["State"];
        }



        /// <summary>
        /// GetState Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original State or EMPTY</returns>
        public Int64 GetStateOriginal(int inspectionId)
        {
            return (Int64)GetRow(inspectionId)["State", DataRowVersion.Original];
        }



        /// <summary>
        /// GetType
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Type or EMPTY</returns>
        public string GetType(int inspectionId)
        {
            return (string)GetRow(inspectionId)["Type"];
        }



        /// <summary>
        /// GetType Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Type or EMPTY</returns>
        public string GetTypeOriginal(int inspectionId)
        {
            return (string)GetRow(inspectionId)["Type", DataRowVersion.Original];
        }



        /// <summary>
        /// GetResult
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Result or EMPTY</returns>
        public string GetResult(int inspectionId)
        {
            return (string)GetRow(inspectionId)["Result"];
        }



        /// <summary>
        /// GetResult Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Result or EMPTY</returns>
        public string GetResultOriginal(int inspectionId)
        {
            return (string)GetRow(inspectionId)["Result", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCost
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Cost</returns>
        public decimal? GetCost(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull("Cost"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(inspectionId)["Cost"];
            }
        }



        /// <summary>
        /// GetCost Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Cost or EMPTY</returns>
        public decimal? GetCostOriginal(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull(Table.Columns["Cost"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(inspectionId)["Cost", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNotes
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Notes or EMPTY</returns>
        public string GetNotes(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull("Notes"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(inspectionId)["Notes"];
            }
        }



        /// <summary>
        /// GetNotes Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Notes or EMPTY</returns>
        public string GetNotesOriginal(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull(Table.Columns["Notes"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(inspectionId)["Notes", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInspectedBy
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>InspectedBy or EMPTY</returns>
        public string GetInspectedBy(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull("InspectedBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(inspectionId)["InspectedBy"];
            }
        }



        /// <summary>
        /// GetInspectedBy Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original InspectedBy or EMPTY</returns>
        public string GetInspectedByOriginal(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull(Table.Columns["InspectedBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(inspectionId)["InspectedBy", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAttach
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Attach or EMPTY</returns>
        public string GetAttach(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull("Attach"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(inspectionId)["Attach"];
            }
        }



        /// <summary>
        /// GetAttach Original
        /// </summary>
        /// <param name="inspectionId">inspectionId</param>
        /// <returns>Original Attach or EMPTY</returns>
        public string GetAttachOriginal(int inspectionId)
        {
            if (GetRow(inspectionId).IsNull(Table.Columns["Attach"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(inspectionId)["Attach", DataRowVersion.Original];
            }
        }



    }
}




