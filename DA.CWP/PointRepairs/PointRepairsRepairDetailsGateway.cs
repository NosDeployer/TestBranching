using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.CWP.PointRepairs
{
    /// <summary>
    /// PointRepairsRepairDetailsGateway
    /// </summary>
    public class PointRepairsRepairDetailsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public PointRepairsRepairDetailsGateway()
            : base("RepairDetails")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PointRepairsRepairDetailsGateway(DataSet data)
            : base(data, "RepairDetails")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PointRepairsTDS();
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
            tableMapping.DataSetTable = "RepairDetails";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("RepairPointID", "RepairPointID");
            tableMapping.ColumnMappings.Add("Type", "Type");
            tableMapping.ColumnMappings.Add("ReamDistance", "ReamDistance");
            tableMapping.ColumnMappings.Add("ReamDate", "ReamDate");
            tableMapping.ColumnMappings.Add("LinerDistance", "LinerDistance");
            tableMapping.ColumnMappings.Add("Direction", "Direction");
            tableMapping.ColumnMappings.Add("Reinstates", "Reinstates");
            tableMapping.ColumnMappings.Add("LTMH", "LTMH");
            tableMapping.ColumnMappings.Add("VTMH", "VTMH");
            tableMapping.ColumnMappings.Add("Distance", "Distance");
            tableMapping.ColumnMappings.Add("Size_", "Size_");
            tableMapping.ColumnMappings.Add("InstallDate", "InstallDate");
            tableMapping.ColumnMappings.Add("MHShot", "MHShot");
            tableMapping.ColumnMappings.Add("GroutDistance", "GroutDistance");
            tableMapping.ColumnMappings.Add("GroutDate", "GroutDate");
            tableMapping.ColumnMappings.Add("Approval", "Approval");
            tableMapping.ColumnMappings.Add("ExtraRepair", "ExtraRepair");
            tableMapping.ColumnMappings.Add("Cancelled", "Cancelled");
            tableMapping.ColumnMappings.Add("Comments", "Comments");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("InDatabase", "InDatabase");
            tableMapping.ColumnMappings.Add("DefectQualifier", "DefectQualifier");
            tableMapping.ColumnMappings.Add("DefectDetails", "DefectDetails");
            tableMapping.ColumnMappings.Add("DistanceOrder", "DistanceOrder");
            tableMapping.ColumnMappings.Add("Length", "Length");
            tableMapping.ColumnMappings.Add("ReinstateDate", "ReinstateDate");
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
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByWorkId(int workId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_POINTREPAIRSREPAIRDETAILSGATEWAY_LOADALLBYWORKID", new SqlParameter("@workId", workId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByWorkId
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet LoadAllByWorkIdRepairPointId(int workId, string repairPointId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_CWP_POINTREPAIRSREPAIRDETAILSGATEWAY_LOADALLBYWORKIDREPAIRPOINTID", new SqlParameter("@workId", workId), new SqlParameter("@repairPointId", repairPointId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId, string repairPointId)
        {
            string filter = string.Format("WorkID = {0} AND RepairPointID = '{1}'", workId, repairPointId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.PointRepairs.PointRepairsRepairDetailsGateway.GetRow");
            }
        }



        /// <summary>
        /// GetReamDistance
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>ReamDistance or EMPTY</returns>
        public string GetReamDistance(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("ReamDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["ReamDistance"];
            }
        }



        /// <summary>
        /// GetReamDistance Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original ReamDistance or EMPTY</returns>
        public string GetReamDistanceOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["ReamDistance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["ReamDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetReamDate
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>ReamDate or EMPTY</returns>
        public DateTime? GetReamDate(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("ReamDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["ReamDate"];
            }
        }



        /// <summary>
        /// GetReamDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original ReamDate or EMPTY</returns>
        public DateTime? GetReamDateOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["ReamDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["ReamDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLinerDistance
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>LinerDistance or EMPTY</returns>
        public string GetLinerDistance(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("LinerDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["LinerDistance"];
            }
        }



        /// <summary>
        /// GetLinerDistance Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original LinerDistance or EMPTY</returns>
        public string GetLinerDistanceOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["LinerDistance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["LinerDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDirection
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Direction or EMPTY</returns>
        public string GetDirection(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Direction"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Direction"];
            }
        }



        /// <summary>
        /// GetDirection Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Direction or EMPTY</returns>
        public string GetDirectionOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Direction"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Direction", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetReinstates
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Reinstates or EMPTY</returns>
        public int? GetReinstates(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Reinstates"))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId, repairPointId)["Reinstates"];
            }
        }



        /// <summary>
        /// GetReinstates Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Reinstates or EMPTY</returns>
        public int? GetReinstatesOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Reinstates"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (int)GetRow(workId, repairPointId)["Reinstates", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLTMH
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>LTMH or EMPTY</returns>
        public string GetLTMH(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("LTMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["LTMH"];
            }
        }



        /// <summary>
        /// GetLTMH Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original LTMH or EMPTY</returns>
        public string GetLTMHOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["LTMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["LTMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetVTMH
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>VTMH or EMPTY</returns>
        public string GetVTMH(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("VTMH"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["VTMH"];
            }
        }



        /// <summary>
        /// GetVTMH Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original VTMH or EMPTY</returns>
        public string GetVTMHOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["VTMH"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["VTMH", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDistance
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Distance or EMPTY</returns>
        public string GetDistance(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Distance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Distance"];
            }
        }



        /// <summary>
        /// GetDistance Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Distance or EMPTY</returns>
        public string GetDistanceOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Distance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Distance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetSize_
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Size_ or EMPTY</returns>
        public string GetSize_(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Size_"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Size_"];
            }
        }



        /// <summary>
        /// GetSize_ Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Size_ or EMPTY</returns>
        public string GetSize_Original(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Size_"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Size_", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetInstallDate
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>InstallDate or EMPTY</returns>
        public DateTime? GetInstallDate(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("InstallDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["InstallDate"];
            }
        }



        /// <summary>
        /// GetInstallDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original InstallDate or EMPTY</returns>
        public DateTime? GetInstallDateOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["InstallDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["InstallDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetMHShot
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>MHShot or EMPTY</returns>
        public string GetMHShot(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("MHShot"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["MHShot"];
            }
        }



        /// <summary>
        /// GetMHShot Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original MHShot or EMPTY</returns>
        public string GetMHShotOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["MHShot"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["MHShot", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGroutDistance
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>GroutDistance or EMPTY</returns>
        public string GetGroutDistance(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("GroutDistance"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["GroutDistance"];
            }
        }



        /// <summary>
        /// GetGroutDistance Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original GroutDistance or EMPTY</returns>
        public string GetGroutDistanceOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["GroutDistance"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["GroutDistance", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetGroutDate
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>GroutDate or EMPTY</returns>
        public DateTime? GetGroutDate(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("GroutDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["GroutDate"];
            }
        }



        /// <summary>
        /// GetGroutDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original GroutDate or EMPTY</returns>
        public DateTime? GetGroutDateOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["GroutDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["GroutDate", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetApproval
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Approval or EMPTY</returns>
        public string GetApproval(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Approval"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Approval"];
            }
        }



        /// <summary>
        /// GetApproval Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Approval or EMPTY</returns>
        public string GetApprovalOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Approval"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Approval", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetExtraRepair
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>ExtraRepair or EMPTY</returns>
        public bool GetExtraRepair(int workId, string repairPointId)
        {
            return (bool)GetRow(workId, repairPointId)["ExtraRepair"];
        }



        /// <summary>
        /// GetExtraRepair Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original ExtraRepair or EMPTY</returns>
        public bool GetExtraRepairOriginal(int workId, string repairPointId)
        {
            return (bool)GetRow(workId, repairPointId)["ExtraRepair", DataRowVersion.Original];
        }



        /// <summary>
        /// GetCancelled
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Cancelled or EMPTY</returns>
        public bool GetCancelled(int workId, string repairPointId)
        {
            return (bool)GetRow(workId, repairPointId)["Cancelled"];
        }



        /// <summary>
        /// GetCancelled Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Cancelled or EMPTY</returns>
        public bool GetCancelledOriginal(int workId, string repairPointId)
        {
            return (bool)GetRow(workId, repairPointId)["Cancelled", DataRowVersion.Original];
        }



        /// <summary>
        /// GetComments
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Comments or EMPTY</returns>
        public string GetComments(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Comments"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Comments"];
            }
        }



        /// <summary>
        /// GetComments Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Comments or EMPTY</returns>
        public string GetCommentsOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Comments"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Comments", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDefectQualifier
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>DefectQualifier or EMPTY</returns>
        public string GetDefectQualifier(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("DefectQualifier"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["DefectQualifier"];
            }
        }



        /// <summary>
        /// GetDefectQualifier Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original DefectQualifier or EMPTY</returns>
        public string GetDefectQualifierOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["DefectQualifier"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["DefectQualifier", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetDefectDetails
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>DefectDetails or EMPTY</returns>
        public string GetDefectDetails(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("DefectDetails"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["DefectDetails"];
            }
        }



        /// <summary>
        /// GetDefectDetails Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original DefectDetails or EMPTY</returns>
        public string GetDefectDetailsOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["DefectDetails"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["DefectDetails", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetLength
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Length or EMPTY</returns>
        public string GetLength(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("Length"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Length"];
            }
        }



        /// <summary>
        /// GetLength Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original Length or EMPTY</returns>
        public string GetLengthOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["Length"], DataRowVersion.Original))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId, repairPointId)["Length", DataRowVersion.Original];
            }
        }



        /// <summary>
        /// GetReinstateDate
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>ReamDate or EMPTY</returns>
        public DateTime? GetReinstateDate(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull("ReinstateDate"))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["ReinstateDate"];
            }
        }



        /// <summary>
        /// GetReinstateDate Original
        /// </summary>
        /// <param name="workId">workId</param>
        /// <param name="repairPointId">repairPointId</param>
        /// <returns>Original ReamDate or EMPTY</returns>
        public DateTime? GetReinstateDateOriginal(int workId, string repairPointId)
        {
            if (GetRow(workId, repairPointId).IsNull(Table.Columns["ReinstateDate"], DataRowVersion.Original))
            {
                return null;
            }
            else
            {
                return (DateTime)GetRow(workId, repairPointId)["ReinstateDate", DataRowVersion.Original];
            }
        }



    }
}