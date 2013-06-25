using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.CWP.DatabaseGateway
{
    /// <summary>
    /// ViewFullLengthLiningLfsM2TablesGateway
    /// </summary>
    public class ViewFullLengthLiningLfsM2TablesGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewFullLengthLiningLfsM2TablesGateway()
            : base("LfsM2Tables")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ViewFullLengthLiningLfsM2TablesGateway(DataSet data)
            : base(data, "LfsM2Tables")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new ViewFullLengthLiningTDS();
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
            tableMapping.DataSetTable = "LfsM2Tables";
            tableMapping.ColumnMappings.Add("ID", "ID");
            tableMapping.ColumnMappings.Add("RefID", "RefID");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("ClockPosition", "ClockPosition");
            tableMapping.ColumnMappings.Add("LiveOrAbandoned", "LiveOrAbandoned");
            tableMapping.ColumnMappings.Add("DistanceToCentreOfLateral", "DistanceToCentreOfLateral");
            tableMapping.ColumnMappings.Add("LateralDiameter", "LateralDiameter");
            tableMapping.ColumnMappings.Add("LateralType", "LateralType");
            tableMapping.ColumnMappings.Add("DateTimeOpened", "DateTimeOpened");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("ReverseSetup", "ReverseSetup");
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
            FillDataWithStoredProcedure("LFS_CWP_VIEWFULLLENGTHLININGLFSM2TABLESGATEWAY_LOADBYID", new SqlParameter("@id", id), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.CWP.DatabaseGateway.ViewFullLengthLiningLfsM2TablesGateway.GetRow");
            }
        }


        
        /// <summary>
        /// GetVideoDistance. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>VideoDistance o EMPTY</returns>
        public float? GetVideoDistance(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("VideoDistance"))
            {
                return null;
            }
            else
            {
                return (float)GetRow(id, refId, companyId)["VideoDistance"];
            }
        }



        /// <summary>
        /// GetVideoDistance Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original VideoDistance or EMPTY</returns>
        public float? GetVideoDistanceOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["VideoDistance"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (float)GetRow(id, refId, companyId)["VideoDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetClockPosition. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>ClockPosition o EMPTY</returns>
        public string GetClockPosition(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("ClockPosition"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ClockPosition"];
            }
        }



        /// <summary>
        /// GetClockPosition Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original ClockPosition or EMPTY</returns>
        public string GetClockPositionOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["ClockPosition"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ClockPosition", DataRowVersion.Original];
            }
        }

        

        /// <summary>
        /// GetLiveOrAbandoned. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LiveOrAbandoned o EMPTY</returns>
        public string GetLiveOrAbandoned(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LiveOrAbandoned"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LiveOrAbandoned"];
            }
        }



        /// <summary>
        /// GetLiveOrAbandoned Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LiveOrAbandoned or EMPTY</returns>
        public string GetLiveOrAbandonedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LiveOrAbandoned"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LiveOrAbandoned", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistanceToCentreOfLateral. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DistanceToCentreOfLateral o EMPTY</returns>
        public string GetDistanceToCentreOfLateral(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("DistanceToCentreOfLateral"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DistanceToCentreOfLateral"];
            }
        }



        /// <summary>
        /// GetDistanceToCentreOfLateral Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original DistanceToCentreOfLateral or EMPTY</returns>
        public string GetDistanceToCentreOfLateralOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["DistanceToCentreOfLateral"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DistanceToCentreOfLateral", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLateralDiameter. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LateralDiameter o EMPTY</returns>
        public string GetLateralDiameter(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LateralDiameter"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LateralDiameter"];
            }
        }



        /// <summary>
        /// GetLateralDiameter Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LateralDiameter or EMPTY</returns>
        public string GetLateralDiameterOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LateralDiameter"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LateralDiameter", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLateralType. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>LateralType o EMPTY</returns>
        public string GetLateralType(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("LateralType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LateralType"];
            }
        }



        /// <summary>
        /// GetLateralType Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original LateralType or EMPTY</returns>
        public string GetLateralTypeOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["LateralType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["LateralType", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDateTimeOpened. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DateTimeOpened o EMPTY</returns>
        public string GetDateTimeOpened(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("DateTimeOpened"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DateTimeOpened"];
            }
        }



        /// <summary>
        /// GetDateTimeOpened Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original DateTimeOpened or EMPTY</returns>
        public string GetDateTimeOpenedOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["DateTimeOpened"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["DateTimeOpened", DataRowVersion.Original];
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
        /// GetReverseSetup. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>ReverseSetup o EMPTY</returns>
        public string GetReverseSetup(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull("ReverseSetup"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ReverseSetup"];
            }
        }



        /// <summary>
        /// GetReverseSetup Original
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Original ReverseSetup or EMPTY</returns>
        public string GetReverseSetupOriginal(Guid id, int refId, int companyId)
        {
            if (GetRow(id, refId, companyId).IsNull(Table.Columns["ReverseSetup"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(id, refId, companyId)["ReverseSetup", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetArchived. If not exists, raise an exception.
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="refId">refId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>NotApproved o EMPTY</returns>
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
