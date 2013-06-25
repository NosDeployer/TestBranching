using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// JlinerNavigatorGateway
    /// </summary>
    public class JlinerNavigatorGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public JlinerNavigatorGateway()
            : base("JlinerNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public JlinerNavigatorGateway(DataSet data)
            : base(data, "JlinerNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new JlinerNavigatorTDS();
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
            tableMapping.DataSetTable = "JlinerNavigator";
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("ID_", "ID_");
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("City", "City");
            tableMapping.ColumnMappings.Add("PipeLocated", "PipeLocated");
            tableMapping.ColumnMappings.Add("ServicesLocated", "ServicesLocated");
            tableMapping.ColumnMappings.Add("CoInstalled", "CoInstalled");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("Grouted", "Grouted");
            tableMapping.ColumnMappings.Add("Cored", "Cored");
            tableMapping.ColumnMappings.Add("Prepped", "Prepped");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("InStock", "InStock");
            tableMapping.ColumnMappings.Add("Delivered", "Delivered");
            tableMapping.ColumnMappings.Add("PreVideo", "PreVideo");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("CoRequired", "CoRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("MADeleted", "MADeleted");
            tableMapping.ColumnMappings.Add("JLDeleted", "JLDeleted");
            tableMapping.ColumnMappings.Add("COMPANIES_ID", "COMPANIES_ID");
            tableMapping.ColumnMappings.Add("Issue", "Issue");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("CoCutDown", "CoCutDown");
            tableMapping.ColumnMappings.Add("FinalRestoration", "FinalRestoration");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
            tableMapping.ColumnMappings.Add("HamiltonInspectionNumber", "HamiltonInspectionNumber");
            tableMapping.ColumnMappings.Add("NoticeDelivered", "NoticeDelivered");
            tableMapping.ColumnMappings.Add("BuildRebuild", "BuildRebuild");
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
        /// LoadWhereOrderBy
        /// </summary>
        /// <param name="where">clause WHERE</param>
        /// <param name="orderBy">clause ORDER BY</param>
        public void LoadWhereOrderBy(string where, string orderBy)
        {
            string commandText = String.Format("SELECT CAST(0 AS bit) AS Selected, MA.RecordID + '-' + JL.DetailID AS ID_, JL.ID, JL.RefID, JL.COMPANY_ID, JL.Address, " +
            " MA.Street, MA.City, JL.PipeLocated, JL.ServicesLocated, JL.CoInstalled, JL.BackfilledConcrete, JL.BackfilledSoil, JL.Grouted, JL.Cored, JL.Prepped, JL.Measured, " +
            " JL.InProcess, JL.InStock, JL.Delivered, JL.PreVideo, JL.LinerInstalled, JL.FinalVideo, JL.VideoInspection, JL.CoRequired, JL.PitRequired, MA.USMH, MA.DSMH, JL.CoPitLocation, " +
            " JL.DistanceFromUSMH, JL.DistanceFromDSMH, JL.Cost, MA.RecordID, MA.Deleted AS MADeleted, JL.DetailID, JL.Deleted AS JLDeleted, MA.COMPANIES_ID,JL.Issue, " +
            " MA.SubArea, JL.Comments, JL.History, JL.PostContractDigRequired, JL.LinerSize, JL.CoCutDown, JL.FinalRestoration, JL.ClientLateralID, JL.VideoLengthToPropertyLine, JL.LiningThruCo, " +
            " JL.HamiltonInspectionNumber, JL.NoticeDelivered, JL.BuildRebuild " +
            " FROM LFS_JUNCTION_LINER2 JL INNER JOIN LFS_MASTER_AREA MA ON JL.ID = MA.ID AND JL.COMPANY_ID = MA.COMPANY_ID " +
            " WHERE {0} ORDER BY {1}", where, orderBy);
            FillData(commandText);
        }



    } 
}