using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;


namespace LiquiForce.LFSLive.DA.CWP.Jliner
{
    /// <summary>
    /// FlatSectionJlinerGateway
    /// </summary>
    public class FlatSectionJlinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public FlatSectionJlinerGateway()
            : base("FlatSectionJliner")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public FlatSectionJlinerGateway(DataSet data)
            : base(data, "FlatSectionJliner")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new FlatSectionJlinerTDS();
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
            tableMapping.DataSetTable = "FlatSectionJliner";
            tableMapping.ColumnMappings.Add("ID_", "ID_");
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("RecordID", "RecordID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("Street", "Street");
            tableMapping.ColumnMappings.Add("Address", "Address");
            tableMapping.ColumnMappings.Add("PipeLocated", "PipeLocated");
            tableMapping.ColumnMappings.Add("ServicesLocated", "ServicesLocated");
            tableMapping.ColumnMappings.Add("CoInstalled", "CoInstalled");
            tableMapping.ColumnMappings.Add("BackfilledConcrete", "BackfilledConcrete");
            tableMapping.ColumnMappings.Add("BackfilledSoil", "BackfilledSoil");
            tableMapping.ColumnMappings.Add("Grouted", "Grouted");
            tableMapping.ColumnMappings.Add("Cored", "Cored");
            tableMapping.ColumnMappings.Add("Prepped", "Prepped");
            tableMapping.ColumnMappings.Add("Measured", "Measured");
            tableMapping.ColumnMappings.Add("LinerSize", "LinerSize");
            tableMapping.ColumnMappings.Add("InProcess", "InProcess");
            tableMapping.ColumnMappings.Add("InStock", "InStock");
            tableMapping.ColumnMappings.Add("Delivered", "Delivered");
            tableMapping.ColumnMappings.Add("BuildRebuild", "BuildRebuild");
            tableMapping.ColumnMappings.Add("PreVideo", "PreVideo");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("DistanceFromDSMH", "DistanceFromDSMH");
            tableMapping.ColumnMappings.Add("Map", "Map");
            tableMapping.ColumnMappings.Add("Issue", "Issue");
            tableMapping.ColumnMappings.Add("Cost", "Cost");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Selected", "Selected");
            tableMapping.ColumnMappings.Add("VideoInspection", "VideoInspection");
            tableMapping.ColumnMappings.Add("CoRequired", "CoRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("USMH", "USMH");
            tableMapping.ColumnMappings.Add("DSMH", "DSMH");
            tableMapping.ColumnMappings.Add("CoPitLocation", "CoPitLocation");
            tableMapping.ColumnMappings.Add("PostContractDigRequired", "PostContractDigRequired");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("History", "History");
            tableMapping.ColumnMappings.Add("CoCutDown", "CoCutDown");
            tableMapping.ColumnMappings.Add("FinalRestoration", "FinalRestoration");
            tableMapping.ColumnMappings.Add("ClientLateralID", "ClientLateralID");
            tableMapping.ColumnMappings.Add("VideoLengthToPropertyLine", "VideoLengthToPropertyLine");
            tableMapping.ColumnMappings.Add("LiningThruCo", "LiningThruCo");
            tableMapping.ColumnMappings.Add("NoticeDelivered", "NoticeDelivered");
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
        /// LoadByIdRefIdSelected
        /// </summary>
        /// <param name="id">LFS_MASTER_AREA ID</param>
        /// <param name="refId">LFS_JUNCTION_LINER2 ID</param>
        /// <param name="companyId">companyId</param>
        /// <param name="select">1 = Selected by default, 0 = Not selected by default</param>
        /// <returns>Data</returns>
        public DataSet LoadByIdRefIdSelected(Guid id, int refId, int companyId, int selected)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLINERGATEWAY_LOADBYIDREFIDSELECTED", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId), new SqlParameter("@selected", selected));
            return Data;
        }



        /// <summary>
        /// LoadByIdRefIdCompanyId
        /// </summary>
        /// <param name="id">LFS_MASTER_AREA ID</param>
        /// <param name="refId">LFS_JUNCTION_LINER2 ID</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>Data</returns>
        public DataSet LoadByIdRefId(Guid id, int refId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_FLATSECTIONJLINERGATEWAY_LOADBYIDREFID", new SqlParameter("@id", id), new SqlParameter("@refId", refId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get DataSet for ODS
        /// </summary>
        /// <param name="flatSectionJlinerTDS">DataSet to return</param>
        /// <returns>DataSet</returns>
        public DataSet GetDataSet(DataSet flatSectionJlinerTDS)
        {
            return flatSectionJlinerTDS;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>        
        /// <returns>DataRow</returns>
        public DataRow GetRow(Guid id, int refId, int companyId)
        {
            string filter = string.Format("(ID = '{0}') AND (RefID = {1}) AND (COMPANY_ID = {2})", id, refId, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.Jliner.FlatSectionJlinerGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDetailID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DetailID o EMPTY</returns>
        public string GetDetailID(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("DetailID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DetailID"];
            }
        }



        /// <summary>
        /// GetDetailID Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original DetailID or EMPTY</returns>
        public string GetDetailIDOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["DetailID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DetailID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAddress. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Address o EMPTY</returns>
        public string GetAddress(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Address"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Address"];
            }
        }



        /// <summary>
        /// GetAddress Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Address or EMPTY</returns>
        public string GetAddressOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Address"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Address", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeLocated. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PipeLocated o EMPTY</returns>
        public DateTime? GetPipeLocated(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("PipeLocated"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["PipeLocated"];
            }
        }



        /// <summary>
        /// GetPipeLocated Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original PipeLocated or EMPTY</returns>
        public DateTime? GetPipeLocatedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["PipeLocated"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["PipeLocated", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetServicesLocated. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>ServicesLocated o EMPTY</returns>
        public DateTime? GetServicesLocated(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("ServicesLocated"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["ServicesLocated"];
            }
        }



        /// <summary>
        /// GetServicesLocated Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original ServicesLocated or EMPTY</returns>
        public DateTime? GetServicesLocatedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["ServicesLocated"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["ServicesLocated", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCoInstalled. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CoInstalled o EMPTY</returns>
        public DateTime? GetCoInstalled(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("CoInstalled"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["CoInstalled"];
            }
        }



        /// <summary>
        /// GetCoInstalled Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CoInstalled or EMPTY</returns>
        public DateTime? GetCoInstalledOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["CoInstalled"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["CoInstalled", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBackfilledConcrete. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>BackfilledConcrete o EMPTY</returns>
        public DateTime? GetBackfilledConcrete(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("BackfilledConcrete"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["BackfilledConcrete"];
            }
        }



        /// <summary>
        /// GetBackfilledConcrete Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original BackfilledConcrete or EMPTY</returns>
        public DateTime? GetBackfilledConcreteOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["BackfilledConcrete"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["BackfilledConcrete", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBackfilledSoil. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>BackfilledSoil o EMPTY</returns>
        public DateTime? GetBackfilledSoil(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("BackfilledSoil"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["BackfilledSoil"];
            }
        }



        /// <summary>
        /// GetBackfilledSoil Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original BackfilledSoil or EMPTY</returns>
        public DateTime? GetBackfilledSoilOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["BackfilledSoil"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["BackfilledSoil", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGrouted. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Grouted o EMPTY</returns>
        public DateTime? GetGrouted(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Grouted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Grouted"];
            }
        }



        /// <summary>
        /// GetGrouted Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Grouted or EMPTY</returns>
        public DateTime? GetGroutedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Grouted"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Grouted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCored. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Cored o EMPTY</returns>
        public DateTime? GetCored(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Cored"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Cored"];
            }
        }



        /// <summary>
        /// GetCored Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Cored or EMPTY</returns>
        public DateTime? GetCoredOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Cored"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Cored", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPrepped. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Prepped o EMPTY</returns>
        public DateTime? GetPrepped(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Prepped"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Prepped"];
            }
        }



        /// <summary>
        /// GetPrepped Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Prepped or EMPTY</returns>
        public DateTime? GetPreppedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Prepped"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Prepped", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasured. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Measured o EMPTY</returns>
        public DateTime? GetMeasured(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Measured"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Measured"];
            }
        }



        /// <summary>
        /// GetMeasured Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Measured or EMPTY</returns>
        public DateTime? GetMeasuredOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Measured"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Measured", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerSize. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LinerSize o EMPTY</returns>
        public string GetLinerSize(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LinerSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LinerSize"];
            }
        }



        /// <summary>
        /// GetLinerSize Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerSize or EMPTY</returns>
        public string GetLinerSizeOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LinerSize"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LinerSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInProcess. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>InProcess o EMPTY</returns>
        public DateTime? GetInProcess(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("InProcess"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["InProcess"];
            }
        }



        /// <summary>
        /// GetInProcess Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original InProcess or EMPTY</returns>
        public DateTime? GetInProcessOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["InProcess"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["InProcess", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInStock. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>InStock o EMPTY</returns>
        public DateTime? GetInStock(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("InStock"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["InStock"];
            }
        }



        /// <summary>
        /// GetInStock Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original InStock or EMPTY</returns>
        public DateTime? GetInStockOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["InStock"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["InStock", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDelivered. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Delivered o EMPTY</returns>
        public DateTime? GetDelivered(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Delivered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Delivered"];
            }
        }



        /// <summary>
        /// GetDelivered Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Delivered or EMPTY</returns>
        public DateTime? GetDeliveredOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Delivered"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["Delivered", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetBuildRebuild. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>BuildRebuild o EMPTY</returns>
        public int? GetBuildRebuild(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("BuildRebuild"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, refId, companyId)["BuildRebuild"];
            }
        }



        /// <summary>
        /// GetBuildRebuild Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original BuildRebuild or EMPTY</returns>
        public int? GetBuildRebuildOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["BuildRebuild"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(id, refId, companyId)["BuildRebuild", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreVideo. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PreVideo o EMPTY</returns>
        public DateTime? GetPreVideo(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("PreVideo"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["PreVideo"];
            }
        }



        /// <summary>
        /// GetPreVideo Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original PreVideo or EMPTY</returns>
        public DateTime? GetPreVideoOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["PreVideo"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["PreVideo", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerInstalled. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LinerInstalled o EMPTY</returns>
        public DateTime? GetLinerInstalled(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LinerInstalled"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["LinerInstalled"];
            }
        }



        /// <summary>
        /// GetLinerInstalled Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerInstalled or EMPTY</returns>
        public DateTime? GetLinerInstalledOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LinerInstalled"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["LinerInstalled", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalVideo. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>FinalVideo o EMPTY</returns>
        public DateTime? GetFinalVideo(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("FinalVideo"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["FinalVideo"];
            }
        }



        /// <summary>
        /// GetFinalVideo Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original FinalVideo or EMPTY</returns>
        public DateTime? GetFinalVideoOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["FinalVideo"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["FinalVideo", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DistanceFromUSMH o EMPTY</returns>
        public double? GetDistanceFromUSMH(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("DistanceFromUSMH"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, refId, companyId)["DistanceFromUSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromUSMH Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original DistanceFromUSMH or EMPTY</returns>
        public double? GetDistanceFromUSMHOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["DistanceFromUSMH"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, refId, companyId)["DistanceFromUSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMH. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DistanceFromDSMH o EMPTY</returns>
        public double? GetDistanceFromDSMH(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("DistanceFromDSMH"))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, refId, companyId)["DistanceFromDSMH"];
            }
        }



        /// <summary>
        /// GetDistanceFromDSMH Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original DistanceFromDSMH or EMPTY</returns>
        public double? GetDistanceFromDSMHOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["DistanceFromDSMH"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (double)GetRow(id, refId, companyId)["DistanceFromDSMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMap. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Map o EMPTY</returns>
        public string GetMap(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Map"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Map"];
            }
        }



        /// <summary>
        /// GetMap Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Map or EMPTY</returns>
        public string GetMapOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Map"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Map", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetIssue. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Issue o EMPTY</returns>
        public string GetIssue(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Issue"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Issue"];
            }
        }



        /// <summary>
        /// GetIssue Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Issue or EMPTY</returns>
        public string GetIssueOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Issue"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Issue", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCost. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Cost o EMPTY</returns>
        public decimal? GetCost(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Cost"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, refId, companyId)["Cost"];
            }
        }



        /// <summary>
        /// GetCost Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Cost or EMPTY</returns>
        public decimal? GetCostOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Cost"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, refId, companyId)["Cost", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoInspection. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>VideoInspection o EMPTY</returns>
        public DateTime? GetVideoInspection(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("VideoInspection"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["VideoInspection"];
            }
        }



        /// <summary>
        /// GetVideoInspection Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original VideoInspection or EMPTY</returns>
        public DateTime? GetVideoInspectionOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["VideoInspection"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["VideoInspection", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCoRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CoRequired o EMPTY</returns>
        public bool GetCoRequired(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CoRequired"];
        }



        /// <summary>
        /// GetCoRequired Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CoRequired or EMPTY</returns>
        public bool GetCoRequiredOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CoRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPitRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PitRequired o EMPTY</returns>
        public bool GetPitRequired(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["PitRequired"];
        }



        /// <summary>
        /// GetPitRequired Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original PitRequired or EMPTY</returns>
        public bool GetPitRequiredOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["PitRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCoPitLocation. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CoPitLocation o EMPTY</returns>
        public string GetCoPitLocation(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("CoPitLocation"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["CoPitLocation"];
            }
        }



        /// <summary>
        /// GetCoPitLocation Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CoPitLocation or EMPTY</returns>
        public string GetCoPitLocationOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["CoPitLocation"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["CoPitLocation", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPostContractDigRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PostContractDigRequired o EMPTY</returns>
        public bool GetPostContractDigRequired(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["PostContractDigRequired"];
        }



        /// <summary>
        /// GetPostContractDigRequired Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original PostContractDigRequired or EMPTY</returns>
        public bool GetPostContractDigRequiredOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["PostContractDigRequired", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Comments o EMPTY</returns>
        public string GetComments(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetHistory. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>History o EMPTY</returns>
        public string GetHistory(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("History"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["History"];
            }
        }



        /// <summary>
        /// GetHistory Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original History or EMPTY</returns>
        public string GetHistoryOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["History"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["History", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCoCutDown. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CoCutDown o EMPTY</returns>
        public DateTime? GetCoCutDown(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("CoCutDown"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["CoCutDown"];
            }
        }



        /// <summary>
        /// GetCoCutDown Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CoCutDown or EMPTY</returns>
        public DateTime? GetCoCutDownOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["CoCutDown"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["CoCutDown", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetFinalRestoration. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>FinalRestoration o EMPTY</returns>
        public DateTime? GetFinalRestoration(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("FinalRestoration"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["FinalRestoration"];
            }
        }



        /// <summary>
        /// GetFinalRestoration Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original FinalRestoration or EMPTY</returns>
        public DateTime? GetFinalRestorationOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["FinalRestoration"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["FinalRestoration", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClientLateralID. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>ClientLateralID o EMPTY</returns>
        public string GetClientLateralID(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("ClientLateralID"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ClientLateralID"];
            }
        }



        /// <summary>
        /// GetClientLateralID Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original ClientLateralID or EMPTY</returns>
        public string GetClientLateralIDOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["ClientLateralID"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ClientLateralID", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoLengthToPropertyLine. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>VideoLengthToPropertyLine o EMPTY</returns>
        public string GetVideoLengthToPropertyLine(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("VideoLengthToPropertyLine"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["VideoLengthToPropertyLine"];
            }
        }



        /// <summary>
        /// GetVideoLengthToPropertyLine Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original VideoLengthToPropertyLine or EMPTY</returns>
        public string GetVideoLengthToPropertyLineOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["VideoLengthToPropertyLine"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["VideoLengthToPropertyLine", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLiningThruCo. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LiningThruCo o EMPTY</returns>
        public bool GetLiningThruCo(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["LiningThruCo"];
        }



        /// <summary>
        /// GetLiningThruCo Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LiningThruCo or EMPTY</returns>
        public bool GetLiningThruCoOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["LiningThruCo", DataRowVersion.Original];
        }



        /// <summary>
        /// GetHamiltonInspectionNumber. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>HamiltonInspectionNumber o EMPTY</returns>
        public string GetHamiltonInspectionNumber(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("HamiltonInspectionNumber"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["HamiltonInspectionNumber"];
            }
        }



        /// <summary>
        /// GetHamiltonInspectionNumber Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original HamiltonInspectionNumber or EMPTY</returns>
        public string GetHamiltonInspectionNumberOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["HamiltonInspectionNumber"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["HamiltonInspectionNumber", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetNoticeDelivered. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>NoticeDelivered o EMPTY</returns>
        public DateTime? GetNoticeDelivered(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("NoticeDelivered"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["NoticeDelivered"];
            }
        }



        /// <summary>
        /// GetNoticeDelivered Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original NoticeDelivered or EMPTY</returns>
        public DateTime? GetNoticeDeliveredOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["NoticeDelivered"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["NoticeDelivered", DataRowVersion.Original];
            }
        }



    }
}