using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.JunctionLining
{
    /// <summary>
    /// FlatSectionJlsGateway
    /// </summary>
    public class FlatSectionJlsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlsGateway() : base("FlatSectionJls")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlsGateway(DataSet data) : base(data, "FlatSectionJls")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlsTDS();
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
            tableMapping.DataSetTable = "FlatSectionJls";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("USMHID", "USMHID");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("DSMHID", "DSMHID");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("OriginalSectionID", "OriginalSectionID");
            tableMapping.ColumnMappings.Add("AvailableToLine", "AvailableToLine");
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
        /// LoadByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="selected">Selecte value</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataSet</returns>
        public DataSet LoadByWorkId(int workId, int selected, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLSGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@selected", selected), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get one row, if not exists throw an exception
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>row</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("WorkID = {0}", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.JunctionLining.FlatSectionJlsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetAssetId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AssetId</returns>
        public int GetAssetId(int workId)
        {
            return (int)GetRow(workId)["AssetID"];
        }


                
        /// <summary>
        /// GetSectionID
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SectionID</returns>
        public string GetSectionId(int workId)
        {
            return (string)GetRow(workId)["SectionID"];
        }



        /// <summary>
        /// GetStreet
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Street or EMPTY</returns>
        public string GetStreet(int workId)
        {
            if (GetRow(workId).IsNull("Street"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Street"];
            }
        }


        
        /// <summary>
        /// GetStreetOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Street original or EMPTY</returns>
        public string GetStreetOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Street"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Street", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetUsmh
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Usmh or EMPTY</returns>
        public int? GetUsmh(int workId)
        {
            if (GetRow(workId).IsNull("USMH"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["USMH"];
            }
        }



        /// <summary>
        /// GetUsmhOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Usmh original or EMPTY</returns>
        public int? GetUsmhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMH"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["USMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHID or EMPTY</returns>
        public string GetUsmhId(int workId)
        {
            if (GetRow(workId).IsNull("USMHID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHID"];
            }
        }



        /// <summary>
        /// GetUsmhIdOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHID original or EMPTY</returns>
        public string GetUsmhIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHID", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetDsmh
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMH or EMPTY</returns>
        public int? GetDsmh(int workId)
        {
            if (GetRow(workId).IsNull("DSMH"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["DSMH"];
            }
        }



        /// <summary>
        /// GetDsmhOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMH original or EMPTY</returns>
        public int? GetDsmhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMH"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["DSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHID or EMPTY</returns>
        public string GetDsmhId(int workId)
        {
            if (GetRow(workId).IsNull("DSMHID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHID"];
            }
        }



        /// <summary>
        /// GetDsmhIdOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHID original or EMPTY</returns>
        public string GetDsmhIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSize
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Size_ or EMPTY</returns>
        public string GetSize_(int workId)
        {
            if (GetRow(workId).IsNull("Size_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Size_"];
            }
        }



        /// <summary>
        /// GetSizeOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Size_ original or EMPTY</returns>
        public string GetSize_Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Size_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Size_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLength
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Length or EMPTY</returns>
        public string GetLength(int workId)
        {
            if (GetRow(workId).IsNull("Length"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Length"];
            }
        }



        /// <summary>
        /// GetLengthOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Length original or EMPTY</returns>
        public string GetLengthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Length"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Length", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSubArea
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SubArea or EMPTY</returns>
        public string GetSubArea(int workId)
        {
            if (GetRow(workId).IsNull("SubArea"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SubArea"];
            }
        }



        /// <summary>
        /// GetSubAreaOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SubArea original or EMPTY</returns>
        public string GetSubAreaOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["SubArea"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SubArea", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNumLats
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>GetNumLats</returns>
        public int GetNumLats(int workId)
        {
            return (int)GetRow(workId)["NumLats"];
        }



        /// <summary>
        /// GetNotLinedYet
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotLinedYet</returns>
        public int GetNotLinedYet(int workId)
        {
            return (int)GetRow(workId)["NotLinedYet"];
        }



        /// <summary>
        /// GetAllMeasured
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AllMeasured</returns>
        public bool GetAllMeasured(int workId)
        {
            return (bool)GetRow(workId)["AllMeasured"];
        }



        /// <summary>
        /// GetIssueWithLaterals
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueWithLaterals</returns>
        public string GetIssueWithLaterals(int workId)
        {
            return (string)GetRow(workId)["IssueWithLaterals"];
        }



        /// <summary>
        /// GetNotMeasuredYet
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotMeasuredYed</returns>
        public int GetNotMeasuredYet(int workId)
        {
            return (int)GetRow(workId)["NotMeasuredYet"];
        }



        /// <summary>
        /// GetNotDeliveredYet
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotDeliveredYet</returns>
        public int GetNotDeliveredYet(int workId)
        {
            return (int)GetRow(workId)["NotDeliveredYet"];
        }



        /// <summary>
        /// GetTrafficControl
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControl or EMPTY</returns>
        public string GetTrafficControl(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControl"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl"];
            }
        }



        /// <summary>
        /// GetTrafficControlOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControl original or EMPTY</returns>
        public string GetTrafficControlOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["TrafficControl"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControl", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTrafficControlDetails
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficcontrolDetails or EMPTY</returns>
        public string GetTrafficControlDetails(int workId)
        {
            if (GetRow(workId).IsNull("TrafficControlDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControlDetails"];
            }
        }



        /// <summary>
        /// GetTrafficControlDetailsOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Traffic Control Details original or EMPTY</returns>
        public string GetTrafficControlDetailsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["TrafficControlDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["TrafficControlDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetStandardBypass
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypass</returns>
        public bool GetStandardBypass(int workId)
        {
            return (bool)GetRow(workId)["StandardBypass"];
        }



        /// <summary>
        /// GetStandardBypassOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypass original</returns>
        public bool GetStandardBypassOriginal(int workId)
        {
            return (bool)GetRow(workId)["StandardBypass", DataRowVersion.Original];
        }



        /// <summary>
        /// GetStandardBypassComments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypassComments or EMPTY</returns>
        public string GetStandardBypassComments(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypassComments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["StandardBypassComments"];
            }
        }



        /// <summary>
        /// GetStandardBypassCommentsOriginal
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>standardBypasscomments original or EMPTY</returns>
        public string GetStandardBypassCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["StandardBypassComments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["StandardBypassComments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFlowOrderId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FlowOrderID or EMPTY</returns>
        public string GetFlowOrderId(int workId)
        {
            if (GetRow(workId).IsNull("FlowOrderID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["FlowOrderID"];
            }
        }



        /// <summary>
        /// GetOriginalSectionId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>OriginalSectionID or EMPTY</returns>
        public string GetOriginalSectionId(int workId)
        {
            if (GetRow(workId).IsNull("OriginalSectionID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["OriginalSectionID"];
            }
        }



        /// <summary>
        /// GetAvailableToLine
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AvailableToLine</returns>
        public int GetAvailableToLine(int workId)
        {
            return (int)GetRow(workId)["AvailableToLine"];
        }



        /// <summary>
        /// Get DataSet for ODS
        /// </summary>
        /// <param name="flatSectionRaTDS">DataSet to return</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(DataSet flatSectionJlsTDS)
        {
            return flatSectionJlsTDS;
        }
               

        
    }
}
