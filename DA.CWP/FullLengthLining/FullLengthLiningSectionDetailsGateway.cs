using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.FullLengthLining
{
    /// <summary>
    /// FullLengthLiningSectionDetailsGateway
    /// </summary>
    public class FullLengthLiningSectionDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FullLengthLiningSectionDetailsGateway()
            : base("SectionDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FullLengthLiningSectionDetailsGateway(DataSet data)
            : base(data, "SectionDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FullLengthLiningTDS();
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
            tableMapping.DataSetTable = "SectionDetails";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("AssetID", "AssetID");
            tableMapping.ColumnMappings.Add("SectionID", "SectionID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("MapSize", "MapSize");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("MapLength", "MapLength");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("Laterals", "Laterals");
            tableMapping.ColumnMappings.Add("LiveLaterals", "LiveLaterals");
            tableMapping.ColumnMappings.Add("USMHDepth", "USMHDepth");
            tableMapping.ColumnMappings.Add("DSMHDepth", "DSMHDepth");
            tableMapping.ColumnMappings.Add("SteelTapeThroughSewer", "SteelTapeThroughSewer");
            tableMapping.ColumnMappings.Add("USMHMouth12", "USMHMouth12");
            tableMapping.ColumnMappings.Add("USMHMouth1", "USMHMouth1");
            tableMapping.ColumnMappings.Add("USMHMouth2", "USMHMouth2");
            tableMapping.ColumnMappings.Add("USMHMouth3", "USMHMouth3");
            tableMapping.ColumnMappings.Add("USMHMouth4", "USMHMouth4");
            tableMapping.ColumnMappings.Add("USMHMouth5", "USMHMouth5");
            tableMapping.ColumnMappings.Add("DSMHMouth12", "DSMHMouth12");
            tableMapping.ColumnMappings.Add("DSMHMouth1", "DSMHMouth1");
            tableMapping.ColumnMappings.Add("DSMHMouth2", "DSMHMouth2");
            tableMapping.ColumnMappings.Add("DSMHMouth3", "DSMHMouth3");
            tableMapping.ColumnMappings.Add("DSMHMouth4", "DSMHMouth4");
            tableMapping.ColumnMappings.Add("DSMHMouth5", "DSMHMouth5");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("USMHDescription", "USMHDescription");
            tableMapping.ColumnMappings.Add("DSMHDescription", "DSMHDescription");
            tableMapping.ColumnMappings.Add("USMHAddress", "USMHAddress");
            tableMapping.ColumnMappings.Add("DSMHAddress", "DSMHAddress");
            tableMapping.ColumnMappings.Add("SubArea", "SubArea");
            tableMapping.ColumnMappings.Add("FlowOrderID", "FlowOrderID");
            tableMapping.ColumnMappings.Add("OriginalSectionID", "OriginalSectionID");
            tableMapping.ColumnMappings.Add("Thickness", "Thickness");
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
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FULLLENGTHLININGSECTIONDETAILSGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;            
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.FullLengthLining.FullLengthLiningSectionDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetSectionId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SectionID or EMPTY</returns>
        public string GetSectionId(int workId)
        {
            if (GetRow(workId).IsNull("SectionID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SectionID"];
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
        /// GetStreet Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original street or EMPTY</returns>
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
        /// GetUsmh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMH or EMPTY</returns>
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
        /// GetUsmh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMH or EMPTY</returns>
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
        /// GetDsmh. If not exists, raise an exception.
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
        /// GetDsmh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMH or EMPTY</returns>
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
        /// GetMapSize
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MapSize or EMPTY</returns>
        public string GetMapSize(int workId)
        {
            if (GetRow(workId).IsNull("MapSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MapSize"];
            }
        }



        /// <summary>
        /// GetMapSize Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MapSize or EMPTY</returns>
        public string GetMapSizeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MapSize"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MapSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSize_
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
        /// GetSize Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Size or EMPTY</returns>
        public string GetSizeOriginal(int workId)
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
        /// GetMapLength
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MapLength or EMPTY</returns>
        public string GetMapLength(int workId)
        {
            if (GetRow(workId).IsNull("MapLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MapLength"];
            }
        }



        /// <summary>
        /// GetMapLength Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MapLength or EMPTY</returns>
        public string GetMapLengthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MapLength"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MapLength", DataRowVersion.Original];
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
        /// GetLength Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Length or EMPTY</returns>
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
        /// GetLaterals. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>GetLaterals or EMPTY</returns>
        public int? GetLaterals(int workId)
        {
            if (GetRow(workId).IsNull("Laterals"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["Laterals"];
            }
        }



        /// <summary>
        /// GetLateralsOriginal Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Laterals or EMPTY</returns>
        public int? GetLateralsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Laterals"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["Laterals", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLiveLaterals. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>GetLiveLaterals or EMPTY</returns>
        public int? GetLiveLaterals(int workId)
        {
            if (GetRow(workId).IsNull("LiveLaterals"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["LiveLaterals"];
            }
        }



        /// <summary>
        /// GetLiveLateralsOriginal Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original LiveLaterals or EMPTY</returns>
        public int? GetLiveLateralsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["LiveLaterals"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["LiveLaterals", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientId. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ClientId or EMPTY</returns>
        public string GetClientId(int workId)
        {
            if (GetRow(workId).IsNull("ClientID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID"];
            }
        }



        /// <summary>
        /// GetClientId Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ClientID or EMPTY</returns>
        public string GetClientIdOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ClientID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["ClientID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetProposedLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetProposedLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("ProposedLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate"];
            }
        }



        /// <summary>
        /// GetProposedLiningDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original ProposedLiningDate or EMPTY</returns>
        public DateTime? GetProposedLiningDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["ProposedLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["ProposedLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>ProposedLiningDate o EMPTY</returns>
        public DateTime? GetDeadlineLiningDate(int workId)
        {
            if (GetRow(workId).IsNull("DeadlineLiningDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate"];
            }
        }



        /// <summary>
        /// GetDeadlineLiningDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DeadlineLiningDate or EMPTY</returns>
        public DateTime? GetDeadlineLiningDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DeadlineLiningDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["DeadlineLiningDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetP1Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>P1 Date o EMPTY</returns>
        public DateTime? GetP1Date(int workId)
        {
            if (GetRow(workId).IsNull("P1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date"];
            }
        }



        /// <summary>
        /// GetP1Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original P1Date or EMPTY</returns>
        public DateTime? GetP1DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["P1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["P1Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetM1Date. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>M1 Date o EMPTY</returns>
        public DateTime? GetM1Date(int workId)
        {
            if (GetRow(workId).IsNull("M1Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M1Date"];
            }
        }



        /// <summary>
        /// GetM1Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original M1Date or EMPTY</returns>
        public DateTime? GetM1DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["M1Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M1Date", DataRowVersion.Original];
            }
        }




        /// <summary>
        /// GetM2Date. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>M2 Date o EMPTY</returns>
        public DateTime? GetM2Date(int workId)
        {
            if (GetRow(workId).IsNull("M2Date"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M2Date"];
            }
        }



        /// <summary>
        /// GetM2Date Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original M2Date or EMPTY</returns>
        public DateTime? GetM2DateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["M2Date"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["M2Date", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInstallDate. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>InstallDate o EMPTY</returns>
        public DateTime? GetInstallDate(int workId)
        {
            if (GetRow(workId).IsNull("InstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InstallDate"];
            }
        }



        /// <summary>
        /// GetInstallDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original InstallDate or EMPTY</returns>
        public DateTime? GetInstallDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["InstallDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["InstallDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>FinalVideoDate o EMPTY</returns>
        public DateTime? GetFinalVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("FinalVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate"];
            }
        }



        /// <summary>
        /// GetFinalVideoDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original FinalVideoDate or EMPTY</returns>
        public DateTime? GetFinalVideoDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["FinalVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["FinalVideoDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIssueIdentified. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueIdentified</returns>
        public bool GetIssueIdentified(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified"];
        }



        /// <summary>
        /// GetIssueIdentified Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueIdentified or EMPTY</returns>
        public bool GetIssueIdentifiedOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueIdentified", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueLFS. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueLFS</returns>
        public bool GetIssueLFS(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS"];
        }



        /// <summary>
        /// GetIssueLFS Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueLFS or EMPTY</returns>
        public bool GetIssueLFSOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueLFS", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueClient</returns>
        public bool GetIssueClient(int workId)
        {
            return (bool)GetRow(workId)["IssueClient"];
        }



        /// <summary>
        /// GetIssueClient Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueClient or EMPTY</returns>
        public bool GetIssueClientOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueClient", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueSales. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueSales</returns>
        public bool GetIssueSales(int workId)
        {
            return (bool)GetRow(workId)["IssueSales"];
        }



        /// <summary>
        /// GetIssueSales Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueSales or EMPTY</returns>
        public bool GetIssueSalesOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueSales", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueGivenToClient. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueGivenToClient</returns>
        public bool GetIssueGivenToClient(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient"];
        }



        /// <summary>
        /// GetIssueGivenToClient Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueGivenToClient or EMPTY</returns>
        public bool GetIssueGivenToClientOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueGivenToClient", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueResolved. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueResolved</returns>
        public bool GetIssueResolved(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved"];
        }



        /// <summary>
        /// GetIssueResolved Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueResolved or EMPTY</returns>
        public bool GetIssueResolvedOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueResolved", DataRowVersion.Original];
        }



        /// <summary>
        /// GetIssueInvestigation. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>IssueInvestigation</returns>
        public bool GetIssueInvestigation(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation"];
        }



        /// <summary>
        /// GetIssueInvestigation Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original IssueInvestigation or EMPTY</returns>
        public bool GetIssueInvestigationOriginal(int workId)
        {
            return (bool)GetRow(workId)["IssueInvestigation", DataRowVersion.Original];
        }




        /// <summary>
        /// GetPreFlushDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreFlushDate o EMPTY</returns>
        public DateTime? GetPreFlushDate(int workId)
        {
            if (GetRow(workId).IsNull("PreFlushDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreFlushDate"];
            }
        }



        /// <summary>
        /// GetPreFlushDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreFlushDate or EMPTY</returns>
        public DateTime? GetPreFlushDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreFlushDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreFlushDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreVideoDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreVideoDate o EMPTY</returns>
        public DateTime? GetPreVideoDate(int workId)
        {
            if (GetRow(workId).IsNull("PreVideoDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideoDate"];
            }
        }



        /// <summary>
        /// GetPreVideoDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PreVideoDate or EMPTY</returns>
        public DateTime? GetPreVideoDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["PreVideoDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["PreVideoDate", DataRowVersion.Original];
            }
        }

        
        
        /// <summary>
        /// GetUsmhDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHDepth or EMPTY</returns>
        public string GetUsmhDepth(int workId)
        {
            if (GetRow(workId).IsNull("USMHDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHDepth"];
            }
        }



        /// <summary>
        /// GetUsmhDepth Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHDepth or EMPTY</returns>
        public string GetUsmhDepthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhDepth. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHDepth or EMPTY</returns>
        public string GetDsmhDepth(int workId)
        {
            if (GetRow(workId).IsNull("DSMHDepth"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHDepth"];
            }
        }



        /// <summary>
        /// GetDsmhDepth Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHDepth or EMPTY</returns>
        public string GetDsmhDepthOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHDepth"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHDepth", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSteelTapeThroughSewer
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SteelTapeThroughSewer or EMPTY</returns>
        public string GetSteelTapeThroughSewer(int workId)
        {
            if (GetRow(workId).IsNull("SteelTapeThroughSewer"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SteelTapeThroughSewer"];
            }
        }



        /// <summary>
        /// GetSteelTapeThroughSewer Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SteelTapeThroughSewer or EMPTY</returns>
        public string GetSteelTapeThroughSewerOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["SteelTapeThroughSewer"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SteelTapeThroughSewer", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMouth12
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>GetUSMHMouth12 or EMPTY</returns>
        public string GetUsmhMouth12(int workId)
        {
            if (GetRow(workId).IsNull("USMHMouth12"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth12"];
            }
        }



        /// <summary>
        /// GetUsmhMouth12 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHMouth12 or EMPTY</returns>
        public string GetUsmhMouth12Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHMouth12"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth12", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMouth1
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHMouth1 or EMPTY</returns>
        public string GetUsmhMouth1(int workId)
        {
            if (GetRow(workId).IsNull("USMHMouth1"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth1"];
            }
        }



        /// <summary>
        /// GetUsmhMouth1 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHMouth1 or EMPTY</returns>
        public string GetUsmhMouth1Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHMouth1"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth1", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMouth2
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHMouth2 or EMPTY</returns>
        public string GetUsmhMouth2(int workId)
        {
            if (GetRow(workId).IsNull("USMHMouth2"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth2"];
            }
        }



        /// <summary>
        /// GetUsmhMouth2 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHMouth2 or EMPTY</returns>
        public string GetUsmhMouth2Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHMouth2"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth2", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMouth3
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHMouth3 or EMPTY</returns>
        public string GetUsmhMouth3(int workId)
        {
            if (GetRow(workId).IsNull("USMHMouth3"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth3"];
            }
        }



        /// <summary>
        /// GetUsmhMouth3 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHMouth3 or EMPTY</returns>
        public string GetUsmhMouth3Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHMouth3"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth3", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMouth4
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHMouth4 or EMPTY</returns>
        public string GetUsmhMouth4(int workId)
        {
            if (GetRow(workId).IsNull("USMHMouth4"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth4"];
            }
        }



        /// <summary>
        /// GetUsmhMouth4 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHMouth4 or EMPTY</returns>
        public string GetUsmhMouth4Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHMouth4"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth4", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhMouth5
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHMouth5 or EMPTY</returns>
        public string GetUsmhMouth5(int workId)
        {
            if (GetRow(workId).IsNull("USMHMouth5"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth5"];
            }
        }



        /// <summary>
        /// GetUsmhMouth5 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHMouth5 or EMPTY</returns>
        public string GetUsmhMouth5Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHMouth5"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHMouth5", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMouth12
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHMouth12 or EMPTY</returns>
        public string GetDsmhMouth12(int workId)
        {
            if (GetRow(workId).IsNull("DSMHMouth12"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth12"];
            }
        }



        /// <summary>
        /// GetDsmhMouth12 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHMouth12 or EMPTY</returns>
        public string GetDsmhMouth12Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHMouth12"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth12", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMouth1
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHMouth1 or EMPTY</returns>
        public string GetDsmhMouth1(int workId)
        {
            if (GetRow(workId).IsNull("DSMHMouth1"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth1"];
            }
        }



        /// <summary>
        /// GetDsmhMouth1 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHMouth1 or EMPTY</returns>
        public string GetDsmhMouth1Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHMouth1"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth1", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMouth2
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHMouth2 or EMPTY</returns>
        public string GetDsmhMouth2(int workId)
        {
            if (GetRow(workId).IsNull("DSMHMouth2"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth2"];
            }
        }



        /// <summary>
        /// GetDsmhMouth2 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHMouth2 or EMPTY</returns>
        public string GetDsmhMouth2Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHMouth2"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth2", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMouth3
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHMouth3 or EMPTY</returns>
        public string GetDsmhMouth3(int workId)
        {
            if (GetRow(workId).IsNull("DSMHMouth3"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth3"];
            }
        }



        /// <summary>
        /// GetDsmhMouth3 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHMouth3 or EMPTY</returns>
        public string GetDsmhMouth3Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHMouth3"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth3", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMouth4
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHMouth4 or EMPTY</returns>
        public string GetDsmhMouth4(int workId)
        {
            if (GetRow(workId).IsNull("DSMHMouth4"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth4"];
            }
        }



        /// <summary>
        /// GetDsmhMouth4 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHMouth4 or EMPTY</returns>
        public string GetDsmhMouth4Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHMouth4"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth4", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhMouth5
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHMouth5 or EMPTY</returns>
        public string GetDsmhMouth5(int workId)
        {
            if (GetRow(workId).IsNull("DSMHMouth5"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth5"];
            }
        }



        /// <summary>
        /// GetDsmhMouth5 Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHMouth5 or EMPTY</returns>
        public string GetDsmhMouth5Original(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHMouth5"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHMouth5", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetUsmhAddress
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHAddress or EMPTY</returns>
        public string GetUsmhAddress(int workId)
        {
            if (GetRow(workId).IsNull("USMHAddress"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHAddress"];
            }
        }



        /// <summary>
        /// GetUsmhAddress Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHAddress or EMPTY</returns>
        public string GetUsmhAddressOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHAddress"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHAddress", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhAddress
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHAddress or EMPTY</returns>
        public string GetDsmhAddress(int workId)
        {
            if (GetRow(workId).IsNull("DSMHAddress"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHAddress"];
            }
        }



        /// <summary>
        /// GetDsmhAddress Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHAddress or EMPTY</returns>
        public string GetDsmhAddressOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHAddress"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHAddress", DataRowVersion.Original];
            }
        }
                         


        /// <summary>
        /// GetUsmhDescription
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>USMHDescription or EMPTY</returns>
        public string GetUsmhDescription(int workId)
        {
            if (GetRow(workId).IsNull("USMHDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHDescription"];
            }
        }



        /// <summary>
        /// GetUsmhDescription Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original USMHDescription or EMPTY</returns>
        public string GetUsmhDescriptionOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["USMHDescription"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["USMHDescription", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDsmhDescription
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DSMHDescription or EMPTY</returns>
        public string GetDsmhDescription(int workId)
        {
            if (GetRow(workId).IsNull("DSMHDescription"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHDescription"];
            }
        }



        /// <summary>
        /// GetDsmhDescription Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original DSMHDescription or EMPTY</returns>
        public string GetDsmhDescriptionOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["DSMHDescription"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["DSMHDescription", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSubArea. If not exists, raise an exception.
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
        /// GetSubArea Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SubArea or EMPTY</returns>
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
        /// GetThickness
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Thickness or EMPTY</returns>
        public string GetThickness(int workId)
        {
            if (GetRow(workId).IsNull("Thickness"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Thickness"];
            }
        }



        /// <summary>
        /// GetThickness Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Thickness or EMPTY</returns>
        public string GetThicknessOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Thickness"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Thickness", DataRowVersion.Original];
            }
        }



    }
}
