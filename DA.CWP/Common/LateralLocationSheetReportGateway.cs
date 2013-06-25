using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.Common
{
    /// <summary>
    /// LateralLocationSheetReportGateway
    /// </summary>
    public class LateralLocationSheetReportGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LateralLocationSheetReportGateway()
            : base("LateralLocationSheet")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">DataSet</param>
        public LateralLocationSheetReportGateway(DataSet data)
            : base(data, "LateralLocationSheet")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new LateralLocationSheetReportTDS();
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
            tableMapping.DataSetTable = "LateralLocationSheet";
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("MainDiameter", "MainDiameter");
            tableMapping.ColumnMappings.Add("Date", "Date");
            tableMapping.ColumnMappings.Add("TotalSectionLength", "TotalSectionLength");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("ID1", "ID1");
            tableMapping.ColumnMappings.Add("A1", "A1");
            tableMapping.ColumnMappings.Add("D1", "D1");
            tableMapping.ColumnMappings.Add("ID2", "ID2");
            tableMapping.ColumnMappings.Add("A2", "A2");
            tableMapping.ColumnMappings.Add("D2", "D2");
            tableMapping.ColumnMappings.Add("ID3", "ID3");
            tableMapping.ColumnMappings.Add("A3", "A3");
            tableMapping.ColumnMappings.Add("D3", "D3");
            tableMapping.ColumnMappings.Add("ID4", "ID4");
            tableMapping.ColumnMappings.Add("A4", "A4");
            tableMapping.ColumnMappings.Add("D4", "D4");
            tableMapping.ColumnMappings.Add("ID5", "ID5");
            tableMapping.ColumnMappings.Add("A5", "A5");
            tableMapping.ColumnMappings.Add("D5", "D5");
            tableMapping.ColumnMappings.Add("ID6", "ID6");
            tableMapping.ColumnMappings.Add("A6", "A6");
            tableMapping.ColumnMappings.Add("D6", "D6");
            tableMapping.ColumnMappings.Add("ID7", "ID7");
            tableMapping.ColumnMappings.Add("A7", "A7");
            tableMapping.ColumnMappings.Add("D7", "D7");
            tableMapping.ColumnMappings.Add("ID8", "ID8");
            tableMapping.ColumnMappings.Add("A8", "A8");
            tableMapping.ColumnMappings.Add("D8", "D8");
            tableMapping.ColumnMappings.Add("ID9", "ID9");
            tableMapping.ColumnMappings.Add("A9", "A9");
            tableMapping.ColumnMappings.Add("D9", "D9");
            tableMapping.ColumnMappings.Add("ID10", "ID10");
            tableMapping.ColumnMappings.Add("A10", "A10");
            tableMapping.ColumnMappings.Add("D10", "D10");
            tableMapping.ColumnMappings.Add("ID11", "ID11");
            tableMapping.ColumnMappings.Add("A11", "A11");
            tableMapping.ColumnMappings.Add("D11", "D11");
            tableMapping.ColumnMappings.Add("ID12", "ID12");
            tableMapping.ColumnMappings.Add("A12", "A12");
            tableMapping.ColumnMappings.Add("D12", "D12");
            tableMapping.ColumnMappings.Add("ID13", "ID13");
            tableMapping.ColumnMappings.Add("A13", "A13");
            tableMapping.ColumnMappings.Add("D13", "D13");
            tableMapping.ColumnMappings.Add("ID14", "ID14");
            tableMapping.ColumnMappings.Add("A14", "A14");
            tableMapping.ColumnMappings.Add("D14", "D14");
            tableMapping.ColumnMappings.Add("ID15", "ID15");
            tableMapping.ColumnMappings.Add("A15", "A15");
            tableMapping.ColumnMappings.Add("D15", "D15");
            tableMapping.ColumnMappings.Add("ID16", "ID16");
            tableMapping.ColumnMappings.Add("A16", "A16");
            tableMapping.ColumnMappings.Add("D16", "D16");
            tableMapping.ColumnMappings.Add("ID17", "ID17");
            tableMapping.ColumnMappings.Add("A17", "A17");
            tableMapping.ColumnMappings.Add("D17", "D17");
            tableMapping.ColumnMappings.Add("ID18", "ID18");
            tableMapping.ColumnMappings.Add("A18", "A18");
            tableMapping.ColumnMappings.Add("D18", "D18");
            tableMapping.ColumnMappings.Add("ID19", "ID19");
            tableMapping.ColumnMappings.Add("A19", "A19");
            tableMapping.ColumnMappings.Add("D19", "D19");
            tableMapping.ColumnMappings.Add("ID20", "ID20");
            tableMapping.ColumnMappings.Add("A20", "A20");
            tableMapping.ColumnMappings.Add("D20", "D20");
            tableMapping.ColumnMappings.Add("CP1", "CP1");
            tableMapping.ColumnMappings.Add("CP2", "CP2");
            tableMapping.ColumnMappings.Add("CP3", "CP3");
            tableMapping.ColumnMappings.Add("CP4", "CP4");
            tableMapping.ColumnMappings.Add("CP5", "CP5");
            tableMapping.ColumnMappings.Add("CP6", "CP6");
            tableMapping.ColumnMappings.Add("CP7", "CP7");
            tableMapping.ColumnMappings.Add("CP8", "CP8");
            tableMapping.ColumnMappings.Add("CP9", "CP9");
            tableMapping.ColumnMappings.Add("CP10", "CP10");
            tableMapping.ColumnMappings.Add("CP11", "CP11");
            tableMapping.ColumnMappings.Add("CP12", "CP12");
            tableMapping.ColumnMappings.Add("CP13", "CP13");
            tableMapping.ColumnMappings.Add("CP14", "CP14");
            tableMapping.ColumnMappings.Add("CP15", "CP15");
            tableMapping.ColumnMappings.Add("CP16", "CP16");
            tableMapping.ColumnMappings.Add("CP17", "CP17");
            tableMapping.ColumnMappings.Add("CP18", "CP18");
            tableMapping.ColumnMappings.Add("CP19", "CP19");
            tableMapping.ColumnMappings.Add("CP20", "CP20");
            tableMapping.ColumnMappings.Add("CP21", "CP21");
            tableMapping.ColumnMappings.Add("CP22", "CP22");
            tableMapping.ColumnMappings.Add("CP23", "CP23");
            tableMapping.ColumnMappings.Add("CP24", "CP24");
            tableMapping.ColumnMappings.Add("CP25", "CP25");
            tableMapping.ColumnMappings.Add("CP26", "CP26");
            tableMapping.ColumnMappings.Add("CP27", "CP27");
            tableMapping.ColumnMappings.Add("CP28", "CP28");
            tableMapping.ColumnMappings.Add("ID21", "ID21");
            tableMapping.ColumnMappings.Add("ID22", "ID22");
            tableMapping.ColumnMappings.Add("ID23", "ID23");
            tableMapping.ColumnMappings.Add("ID24", "ID24");
            tableMapping.ColumnMappings.Add("ID25", "ID25");
            tableMapping.ColumnMappings.Add("ID26", "ID26");
            tableMapping.ColumnMappings.Add("ID27", "ID27");
            tableMapping.ColumnMappings.Add("ID28", "ID28");
            tableMapping.ColumnMappings.Add("D21", "D21");
            tableMapping.ColumnMappings.Add("D22", "D22");
            tableMapping.ColumnMappings.Add("D23", "D23");
            tableMapping.ColumnMappings.Add("D24", "D24");
            tableMapping.ColumnMappings.Add("D25", "D25");
            tableMapping.ColumnMappings.Add("D26", "D26");
            tableMapping.ColumnMappings.Add("D27", "D27");
            tableMapping.ColumnMappings.Add("D28", "D28");
            tableMapping.ColumnMappings.Add("D29", "D29");
            tableMapping.ColumnMappings.Add("D30", "D30");
            tableMapping.ColumnMappings.Add("ID29", "ID29");
            tableMapping.ColumnMappings.Add("ID30", "ID30");
            tableMapping.ColumnMappings.Add("CP29", "CP29");
            tableMapping.ColumnMappings.Add("CP30", "CP30");
            tableMapping.ColumnMappings.Add("D31", "D31");
            tableMapping.ColumnMappings.Add("CP31", "CP31");
            tableMapping.ColumnMappings.Add("ID31", "ID31");
            tableMapping.ColumnMappings.Add("D32", "D32");
            tableMapping.ColumnMappings.Add("CP32", "CP32");
            tableMapping.ColumnMappings.Add("ID32", "ID32");
            tableMapping.ColumnMappings.Add("D33", "D33");
            tableMapping.ColumnMappings.Add("CP33", "CP33");
            tableMapping.ColumnMappings.Add("ID33", "ID33");
            tableMapping.ColumnMappings.Add("D34", "D34");
            tableMapping.ColumnMappings.Add("CP34", "CP34");
            tableMapping.ColumnMappings.Add("ID34", "ID34");
            tableMapping.ColumnMappings.Add("D35", "D35");
            tableMapping.ColumnMappings.Add("CP35", "CP35");
            tableMapping.ColumnMappings.Add("ID35", "ID35");
            tableMapping.ColumnMappings.Add("D36", "D36");
            tableMapping.ColumnMappings.Add("CP36", "CP36");
            tableMapping.ColumnMappings.Add("ID36", "ID36");
            tableMapping.ColumnMappings.Add("D37", "D37");
            tableMapping.ColumnMappings.Add("CP37", "CP37");
            tableMapping.ColumnMappings.Add("ID37", "ID37");
            tableMapping.ColumnMappings.Add("D38", "D38");
            tableMapping.ColumnMappings.Add("CP38", "CP38");
            tableMapping.ColumnMappings.Add("ID38", "ID38");
            tableMapping.ColumnMappings.Add("D39", "D39");
            tableMapping.ColumnMappings.Add("CP39", "CP39");
            tableMapping.ColumnMappings.Add("ID39", "ID39");
            tableMapping.ColumnMappings.Add("D40", "D40");
            tableMapping.ColumnMappings.Add("CP40", "CP40");
            tableMapping.ColumnMappings.Add("ID40", "ID40");
            tableMapping.ColumnMappings.Add("D41", "D41");
            tableMapping.ColumnMappings.Add("CP41", "CP41");
            tableMapping.ColumnMappings.Add("ID41", "ID41");
            tableMapping.ColumnMappings.Add("D42", "D42");
            tableMapping.ColumnMappings.Add("CP42", "CP42");
            tableMapping.ColumnMappings.Add("ID42", "ID42");
            tableMapping.ColumnMappings.Add("D43", "D43");
            tableMapping.ColumnMappings.Add("CP43", "CP43");
            tableMapping.ColumnMappings.Add("ID43", "ID43");
            tableMapping.ColumnMappings.Add("D44", "D44");
            tableMapping.ColumnMappings.Add("CP44", "CP44");
            tableMapping.ColumnMappings.Add("ID44", "ID44");
            tableMapping.ColumnMappings.Add("D45", "D45");
            tableMapping.ColumnMappings.Add("CP45", "CP45");
            tableMapping.ColumnMappings.Add("ID45", "ID45");
            tableMapping.ColumnMappings.Add("D46", "D46");
            tableMapping.ColumnMappings.Add("CP46", "CP46");
            tableMapping.ColumnMappings.Add("ID46", "ID46");
            tableMapping.ColumnMappings.Add("D47", "D47");
            tableMapping.ColumnMappings.Add("CP47", "CP47");
            tableMapping.ColumnMappings.Add("ID47", "ID47");
            tableMapping.ColumnMappings.Add("D48", "D48");
            tableMapping.ColumnMappings.Add("CP48", "CP48");
            tableMapping.ColumnMappings.Add("ID48", "ID48");
            tableMapping.ColumnMappings.Add("D49", "D49");
            tableMapping.ColumnMappings.Add("CP49", "CP49");
            tableMapping.ColumnMappings.Add("ID49", "ID49");
            tableMapping.ColumnMappings.Add("D50", "D50");
            tableMapping.ColumnMappings.Add("CP50", "CP50");
            tableMapping.ColumnMappings.Add("ID50", "ID50");
            tableMapping.ColumnMappings.Add("D51", "D51");
            tableMapping.ColumnMappings.Add("CP51", "CP51");
            tableMapping.ColumnMappings.Add("ID51", "ID51");
            tableMapping.ColumnMappings.Add("D52", "D52");
            tableMapping.ColumnMappings.Add("CP52", "CP52");
            tableMapping.ColumnMappings.Add("ID52", "ID52");
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
        /// LoadByAssetId
        /// </summary>
        /// <param name="assetId">assetId</param>
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadByAssetId(int assetId, int companyId)
        {
            string command = string.Format("SELECT AMASS.FlowOrderID AS SectionID, AMASS.AssetID, AMASS.Street, AMASS.Size_ as MainDiameter, getdate() AS Date, AMASS.Length as TotalSectionLength, " +
                                           " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AMASS.USMH) AS USMHDescription, " +
                                           " (SELECT MHID FROM AM_ASSET_SEWER_MH AASMH WHERE AASMH.AssetID = AMASS.DSMH) AS DSMHDescription " +                            
                                           " FROM dbo.AM_ASSET_SEWER_SECTION AMASS INNER JOIN dbo.AM_ASSET AMA ON AMASS.AssetID = AMA.AssetID " +
                                           " WHERE (AMASS.AssetID = {0}) AND (AMASS.Deleted = 0) AND (AMASS.COMPANY_ID = {1})", assetId, companyId);
            FillData(command);

            return Data;
        }



    }
}