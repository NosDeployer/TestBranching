using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.CWP.RehabAssessment
{
    /// <summary>
    /// RehabAssessmentWorkDetailsGateway
    /// </summary>
    public class RehabAssessmentWorkDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public RehabAssessmentWorkDetailsGateway()
            : base("WorkDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public RehabAssessmentWorkDetailsGateway(DataSet data)
            : base(data, "WorkDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new RehabAssessmentTDS();
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
            tableMapping.DataSetTable = "WorkDetails";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("WorkIDFll", "WorkIDFll");
            tableMapping.ColumnMappings.Add("ClientID", "ClientID");            
            tableMapping.ColumnMappings.Add("P1Date", "P1Date");
            tableMapping.ColumnMappings.Add("M1Date", "M1Date");
            tableMapping.ColumnMappings.Add("CXIsRemoved", "CXIsRemoved");
            tableMapping.ColumnMappings.Add("MeasurementTakenBy", "MeasurementTakenBy");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("SiteDetails", "SiteDetails");
            tableMapping.ColumnMappings.Add("PipeSizeChange", "PipeSizeChange");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");            
            tableMapping.ColumnMappings.Add("MeasurementType", "MeasurementType");
            tableMapping.ColumnMappings.Add("MeasurementFromMH", "MeasurementFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneFromMH", "VideoDoneFromMH");
            tableMapping.ColumnMappings.Add("VideoDoneToMH", "VideoDoneToMH");
            tableMapping.ColumnMappings.Add("VideoDistance", "VideoDistance");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("PreFlushDate", "PreFlushDate");
            tableMapping.ColumnMappings.Add("PreVideoDate", "PreVideoDate");
            tableMapping.ColumnMappings.Add("Material", "Material");
            tableMapping.ColumnMappings.Add("RoboticPrepCompleted", "RoboticPrepCompleted");
            tableMapping.ColumnMappings.Add("RoboticPrepCompletedDate", "RoboticPrepCompletedDate");
            tableMapping.ColumnMappings.Add("AccessType", "AccessType");
            tableMapping.ColumnMappings.Add("P1Completed", "P1Completed");
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
        /// <param name="workId">workID</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_REHABASSESSMENTWORKDETAILSGATEWAY_LOADBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
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
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.RehabAssessment.RehabAssessmentWorkDetailsGateway.GetRow");
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
        /// GetCxisRemoved. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CXIsRemoved or EMPTY</returns>
        public int? GetCxisRemoved(int workId)
        {
            if (GetRow(workId).IsNull("CXIsRemoved"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CXIsRemoved"];
            }
        }



        /// <summary>
        /// GetCxisRemoved Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original CXIsRemoved or EMPTY</returns>
        public int? GetCxisRemovedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["CXIsRemoved"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId)["CXIsRemoved", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenBy(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementTakenBy"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy"];
            }
        }



        /// <summary>
        /// GetMeasurementTakenBy Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementTakenBy or EMPTY</returns>
        public string GetMeasurementTakenByOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementTakenBy"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementTakenBy", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetTrafficControl. If not exists, raise an exception.
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
        /// GetTrafficControl Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TrafficControl or EMPTY</returns>
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
        /// GetSiteDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>SiteDetails or EMPTY</returns>
        public string GetSiteDetails(int workId)
        {
            if (GetRow(workId).IsNull("SiteDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SiteDetails"];
            }
        }



        /// <summary>
        /// GetSiteDetails Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original SiteDetails or EMPTY</returns>
        public string GetSiteDetailsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["SiteDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["SiteDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPipeSizeChange. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PipeSizeChange</returns>
        public bool GetPipeSizeChange(int workId)
        {
            if (GetRow(workId).IsNull("PipeSizeChange"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["PipeSizeChange"];
            }
            
        }



        /// <summary>
        /// GetPipeSizeChange Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original PipeSizeChange or EMPTY</returns>
        public bool GetPipeSizeChangeOriginal(int workId)
        {
            if (GetRow(workId).IsNull("PipeSizeChange"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["PipeSizeChange", DataRowVersion.Original];
            }            
        }



        /// <summary>
        /// GetStandardBypass. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>StandardBypass</returns>
        public bool GetStandardBypass(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypass"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["StandardBypass"];
            }            
        }



        /// <summary>
        /// GetStandardBypass Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original StandardBypass or EMPTY</returns>
        public bool GetStandardBypassOriginal(int workId)
        {
            if (GetRow(workId).IsNull("StandardBypass"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["StandardBypass", DataRowVersion.Original];
            }
        }
        


        /// <summary>
        /// GetStandardBypassComments. If not exists, raise an exception.
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
        /// GetStandardBypassComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original StandardBypassComments or EMPTY</returns>
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
        /// GetTrafficControlDetails. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TrafficControlDetails or EMPTY</returns>
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
        /// GetTrafficControlDetails Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original TrafficControlDetails or EMPTY</returns>
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
        /// GetMeasurementType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementType or EMPTY</returns>
        public string GetMeasurementType(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementType"];
            }
        }



        /// <summary>
        /// GetMeasurementType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementType or EMPTY</returns>
        public string GetMeasurementTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementType", DataRowVersion.Original];
            }
        }
      


        /// <summary>
        /// GetMeasurementFromMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>MeasurementFromMH or EMPTY</returns>
        public string GetMeasurementFromMh(int workId)
        {
            if (GetRow(workId).IsNull("MeasurementFromMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementFromMH"];
            }
        }



        /// <summary>
        /// GetMeasurementFromMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original MeasurementFromMH or EMPTY</returns>
        public string GetMeasurementFromMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["MeasurementFromMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["MeasurementFromMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoDoneFromMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDoneFromMH or EMPTY</returns>
        public string GetVideoDoneFromMh(int workId)
        {
            if (GetRow(workId).IsNull("VideoDoneFromMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneFromMH"];
            }
        }



        /// <summary>
        /// GetVideoDoneFromMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoDoneFromMH or EMPTY</returns>
        public string GetVideoDoneFromMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoDoneFromMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneFromMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoDoneToMh. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDoneToMH or EMPTY</returns>
        public string GetVideoDoneToMh(int workId)
        {
            if (GetRow(workId).IsNull("VideoDoneToMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneToMH"];
            }
        }


               
        /// <summary>
        /// GetVideoDoneToMh Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoDoneToMH or EMPTY</returns>
        public string GetVideoDoneToMhOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoDoneToMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDoneToMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVideoDistance. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>VideoDistance or EMPTY</returns>
        public string GetVideoDistance(int workId)
        {
            if (GetRow(workId).IsNull("VideoDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDistance"];
            }
        }



        /// <summary>
        /// GetVideoDistance Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original VideoDistance or EMPTY</returns>
        public string GetVideoDistanceOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["VideoDistance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["VideoDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetComments. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId)
        {
            if (GetRow(workId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetPreFlushDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>PreFlushDate o null</returns>
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
        /// <returns>Original PreFlushDate or null</returns>
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
        /// GetMaterial. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Material or EMPTY</returns>
        public string GetMaterial(int workId)
        {
            if (GetRow(workId).IsNull("Material"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Material"];
            }
        }



        /// <summary>
        /// GetMaterial Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original Material or EMPTY</returns>
        public string GetMaterialOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["Material"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["Material", DataRowVersion.Original];
            }
        }

               
        
        /// <summary>
        /// GetRoboticPrepCompleted. 
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticPrepCompleted</returns>
        public bool GetRoboticPrepCompleted(int workId)
        {
            if (GetRow(workId).IsNull("RoboticPrepCompleted"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["RoboticPrepCompleted"];
            }
        }



        /// <summary>
        /// GetRoboticPrepCompleted Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RoboticPrepCompleted or EMPTY</returns>
        public bool GetRoboticPrepCompletedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RoboticPrepCompleted"], DataRowVersion.Original))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["RoboticPrepCompleted", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetRoboticPrepCompletedDate. If  not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>RoboticPrepCompletedDate o EMPTY</returns>
        public DateTime? GetRoboticPrepCompletedDate(int workId)
        {
            if (GetRow(workId).IsNull("RoboticPrepCompletedDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RoboticPrepCompletedDate"];
            }
        }



        /// <summary>
        /// GetRoboticPrepCompletedDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original RoboticPrepCompletedDate or EMPTY</returns>
        public DateTime? GetRoboticPrepCompletedDateOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["RoboticPrepCompletedDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId)["RoboticPrepCompletedDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetP1Completed
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>P1Completed</returns>
        public bool GetP1Completed(int workId)
        {
            if (GetRow(workId).IsNull("P1Completed"))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["P1Completed"];
            }
        }



        /// <summary>
        /// GetP1Completed Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original P1Completed</returns>
        public bool GetP1CompletedOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["P1Completed"], DataRowVersion.Original))
            {
                return false;
            }
            else
            {
                return (bool)GetRow(workId)["P1Completed", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetAccessType. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AccessType or EMPTY</returns>
        public string GetAccessType(int workId)
        {
            if (GetRow(workId).IsNull("AccessType"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["AccessType"];
            }
        }



        /// <summary>
        /// GetAccessType Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>Original AccessType or EMPTY</returns>
        public string GetAccessTypeOriginal(int workId)
        {
            if (GetRow(workId).IsNull(Table.Columns["AccessType"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["AccessType", DataRowVersion.Original];
            }
        }


    }
}