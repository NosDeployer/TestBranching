using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// ViewJLinersheetJunctionLinerGateway
    /// </summary>
    public class ViewJLinersheetJunctionLinerGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewJLinersheetJunctionLinerGateway()
            : base("JunctionLiner")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ViewJLinersheetJunctionLinerGateway(DataSet data)
            : base(data, "JunctionLiner")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ViewJLinersheetTDS();
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
            tableMapping.DataSetTable = "JunctionLiner";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("DetailID", "DetailID");
            tableMapping.ColumnMappings.Add("MN", "MN");
            tableMapping.ColumnMappings.Add("DistanceFromUSMH", "DistanceFromUSMH");
            tableMapping.ColumnMappings.Add("ConfirmedLatSize", "ConfirmedLatSize");
            tableMapping.ColumnMappings.Add("LateralMaterial", "LateralMaterial");
            tableMapping.ColumnMappings.Add("SharedLateral", "SharedLateral");
            tableMapping.ColumnMappings.Add("CleanoutRequired", "CleanoutRequired");
            tableMapping.ColumnMappings.Add("PitRequired", "PitRequired");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("MainConnection", "MainConnection");
            tableMapping.ColumnMappings.Add("Transition", "Transition");
            tableMapping.ColumnMappings.Add("CleanoutInstalled", "CleanoutInstalled");
            tableMapping.ColumnMappings.Add("PitInstalled", "PitInstalled");
            tableMapping.ColumnMappings.Add("CleanoutGrouted", "CleanoutGrouted");
            tableMapping.ColumnMappings.Add("CleanoutCored", "CleanoutCored");
            tableMapping.ColumnMappings.Add("PrepCompleted", "PrepCompleted");
            tableMapping.ColumnMappings.Add("MeasuredLatLength", "MeasuredLatLength");
            tableMapping.ColumnMappings.Add("MeasurementsTakenBy", "MeasurementsTakenBy");
            tableMapping.ColumnMappings.Add("LinerInstalled", "LinerInstalled");
            tableMapping.ColumnMappings.Add("FinalVideo", "FinalVideo");
            tableMapping.ColumnMappings.Add("RestorationComplete", "RestorationComplete");
            tableMapping.ColumnMappings.Add("LinerOrdered", "LinerOrdered");
            tableMapping.ColumnMappings.Add("LinerInStock", "LinerInStock");
            tableMapping.ColumnMappings.Add("LinerPrice", "LinerPrice");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("Archived", "Archived");
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
        /// LoadById
        /// </summary>        
        /// <param name="id">id</param>           
        /// <param name="companyId">companyId</param>
        /// <returns></returns>
        public DataSet LoadById(Guid id, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_VIEWJLINERSHEETJUNCTIONLINERGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
            return Data;
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.DatabaseGateway.ViewJLinerJunctionLinerGateway.GetRow");
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
        /// GetMN. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>MN o EMPTY</returns>
        public string GetMN(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("MN"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MN"];
            }
        }



        /// <summary>
        /// GetMN Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original MN or EMPTY</returns>
        public string GetMNOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["MN"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MN", DataRowVersion.Original];
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
        /// GetConfirmedLatSize. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>ConfirmedLatSize o EMPTY</returns>
        public string GetConfirmedLatSize(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("ConfirmedLatSize"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ConfirmedLatSize"];
            }
        }



        /// <summary>
        /// GetConfirmedLatSize Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original ConfirmedLatSize or EMPTY</returns>
        public string GetConfirmedLatSizeOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["ConfirmedLatSize"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ConfirmedLatSize", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLateralMaterial. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LateralMaterial o EMPTY</returns>
        public string GetLateralMaterial(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LateralMaterial"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LateralMaterial"];
            }
        }



        /// <summary>
        /// GetLateralMaterial Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LateralMaterial or EMPTY</returns>
        public string GetLateralMaterialOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LateralMaterial"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LateralMaterial", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSharedLateral. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>SharedLateral o EMPTY</returns>
        public string GetSharedLateral(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("SharedLateral"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["SharedLateral"];
            }
        }



        /// <summary>
        /// GetSharedLateral Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original SharedLateral or EMPTY</returns>
        public string GetSharedLateralOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["SharedLateral"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["SharedLateral", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCleanoutRequired. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CleanoutRequired o EMPTY</returns>
        public bool GetCleanoutRequired(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutRequired"];
        }



        /// <summary>
        /// GetCleanoutRequired Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CleanoutRequired or EMPTY</returns>
        public bool GetCleanoutRequiredOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutRequired", DataRowVersion.Original];
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
        /// GetMHShot. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>MHShot o EMPTY</returns>
        public bool GetMHShot(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["MHShot"];
        }



        /// <summary>
        /// GetMHShot Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original MHShot or EMPTY</returns>
        public bool GetMHShotOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["MHShot", DataRowVersion.Original];
        }



        /// <summary>
        /// GetMainConnection. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>MainConnection o EMPTY</returns>
        public string GetMainConnection(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("MainConnection"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MainConnection"];
            }
        }



        /// <summary>
        /// GetMainConnection Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original MainConnection or EMPTY</returns>
        public string GetMainConnectionOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["MainConnection"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MainConnection", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTransition. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Transition o EMPTY</returns>
        public string GetTransition(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("Transition"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Transition"];
            }
        }



        /// <summary>
        /// GetTransition Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Transition or EMPTY</returns>
        public string GetTransitionOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["Transition"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["Transition", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetCleanoutInstalled. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CleanoutInstalled o EMPTY</returns>
        public bool GetCleanoutInstalled(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutInstalled"];
        }



        /// <summary>
        /// GetCleanoutInstalled Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CleanoutInstalled or EMPTY</returns>
        public bool GetCleanoutInstalledOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutInstalled", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPitInstalled. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PitInstalled o EMPTY</returns>
        public bool GetPitInstalled(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["PitInstalled"];
        }



        /// <summary>
        /// GetPitInstalled Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original PitInstalled or EMPTY</returns>
        public bool GetPitInstalledOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["PitInstalled", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCleanoutGrouted. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CleanoutGrouted o EMPTY</returns>
        public bool GetCleanoutGrouted(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutGrouted"];
        }



        /// <summary>
        /// GetCleanoutGrouted Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CleanoutGrouted or EMPTY</returns>
        public bool GetCleanoutGroutedOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutGrouted", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCleanoutCored. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>CleanoutCored o EMPTY</returns>
        public bool GetCleanoutCored(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutCored"];
        }



        /// <summary>
        /// GetCleanoutCored Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original CleanoutCored or EMPTY</returns>
        public bool GetCleanoutCoredOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["CleanoutCored", DataRowVersion.Original];
        }



        /// <summary>
        /// GetPrepCompleted. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PrepCompleted o EMPTY</returns>
        public DateTime? GetPrepCompleted(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("PrepCompleted"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["PrepCompleted"];
            }
        }



        /// <summary>
        /// GetPrepCompleted Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original PrepCompleted or EMPTY</returns>
        public DateTime? GetPrepCompletedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["PrepCompleted"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(id, refId, companyId)["PrepCompleted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasuredLatLength. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>MeasuredLatLength o EMPTY</returns>
        public string GetMeasuredLatLength(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("MeasuredLatLength"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MeasuredLatLength"];
            }
        }



        /// <summary>
        /// GetMeasuredLatLength Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original MeasuredLatLength or EMPTY</returns>
        public string GetMeasuredLatLengthOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["MeasuredLatLength"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MeasuredLatLength", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementsTakenBy. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>MeasurementsTakenBy o EMPTY</returns>
        public string GetMeasurementsTakenBy(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("MeasurementsTakenBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MeasurementsTakenBy"];
            }
        }



        /// <summary>
        /// GetMeasurementsTakenBy Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original MeasurementsTakenBy or EMPTY</returns>
        public string GetMeasurementsTakenByOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["MeasurementsTakenBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["MeasurementsTakenBy", DataRowVersion.Original];
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
        /// GetRestorationComplete. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>RestorationComplete o EMPTY</returns>
        public bool GetRestorationComplete(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["RestorationComplete"];
        }



        /// <summary>
        /// GetRestorationComplete Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original RestorationComplete or EMPTY</returns>
        public bool GetRestorationCompleteOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["RestorationComplete", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLinerOrdered. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LinerOrdered o EMPTY</returns>
        public bool GetLinerOrdered(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["LinerOrdered"];
        }



        /// <summary>
        /// GetLinerOrdered Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerOrdered or EMPTY</returns>
        public bool GetLinerOrderedOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["LinerOrdered", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLinerInStock. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LinerInStock o EMPTY</returns>
        public bool GetLinerInStock(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["LinerInStock"];
        }



        /// <summary>
        /// GetLinerInStock Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerInStock or EMPTY</returns>
        public bool GetLinerInStockOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["LinerInStock", DataRowVersion.Original];
        }



        /// <summary>
        /// GetLinerPrice. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LinerPrice o EMPTY</returns>
        public decimal? GetLinerPrice(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LinerPrice"))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, refId, companyId)["LinerPrice"];
            }
        }



        /// <summary>
        /// GetLinerPrice Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LinerPrice or EMPTY</returns>
        public decimal? GetLinerPriceOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LinerPrice"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (decimal)GetRow(id, refId, companyId)["LinerPrice", DataRowVersion.Original];
            }
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
        /// GetArchived. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Archived o EMPTY</returns>
        public bool GetArchived(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Archived"];
        }



        /// <summary>
        /// GetArchived Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original Archived or EMPTY</returns>
        public bool GetArchivedOriginal(Guid id, int refId, int companyId)
        {
            return (bool)GetRow(id, refId, companyId)["Archived", DataRowVersion.Original];
        }
    }
}
