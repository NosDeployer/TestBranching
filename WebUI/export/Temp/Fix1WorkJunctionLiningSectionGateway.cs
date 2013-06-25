using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;


namespace LiquiForce.LFSLive.WebUI.export.Temp
{
    /// <summary>
    /// Fix1WorkJunctionLiningSectionGateway
    /// </summary>
    public class Fix1WorkJunctionLiningSectionGateway: DataTableGateway
    {
        ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1WorkJunctionLiningSectionGateway()
            : base("LFS_WORK_JUNCTIONLINING_SECTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1WorkJunctionLiningSectionGateway(DataSet data)
            : base(data, "LFS_WORK_JUNCTIONLINING_SECTION")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new Fix1WorkJuntionLiningSectionTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            #region Adapter initialization

            this._adapter = new System.Data.SqlClient.SqlDataAdapter();
            System.Data.Common.DataTableMapping tableMapping = new System.Data.Common.DataTableMapping();
            tableMapping.DataSetTable = "LFS_WORK_JUNCTIONLINING_SECTION";
            tableMapping.ColumnMappings.Add("WorkID", "WorkID");
            tableMapping.ColumnMappings.Add("NumLats", "NumLats");
            tableMapping.ColumnMappings.Add("NotLinedYet", "NotLinedYet");
            tableMapping.ColumnMappings.Add("AllMeasured", "AllMeasured");
            tableMapping.ColumnMappings.Add("Deleted", "Deleted");
            tableMapping.ColumnMappings.Add("IssueWithLaterals", "IssueWithLaterals");
            tableMapping.ColumnMappings.Add("NotMeasuredYet", "NotMeasuredYet");
            tableMapping.ColumnMappings.Add("NotDeliveredYet", "NotDeliveredYet");
            tableMapping.ColumnMappings.Add("COMPANY_ID", "COMPANY_ID");
            tableMapping.ColumnMappings.Add("TrafficControl", "TrafficControl");
            tableMapping.ColumnMappings.Add("TrafficControlDetails", "TrafficControlDetails");
            tableMapping.ColumnMappings.Add("StandardBypass", "StandardBypass");
            tableMapping.ColumnMappings.Add("StandardBypassComments", "StandardBypassComments");
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
        /// Load
        /// </summary>        
        /// <param name="companyId">companyId</param>
        /// <returns>data set</returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FIX1_WORKJUNCTIONLININGSECTIONGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }
            

        
        /// <summary>
        /// GetWorkId. If not exists, raise an exception.
        /// </summary>
        /// <returns>GetWorkId or EMPTY</returns>
        public int GetWorkIdTop1()
        {
            return (int)GetRowTop1()["WorkID"];
        }



       
        /// <summary>
        /// GetNumLats. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NumLats</returns>
        public int GetNumLats(int workId)
        {
            return (int)GetRow(workId)["NumLats"];
        }



        /// <summary>
        /// GetNotLinedYet. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NumLats</returns>
        public int GetNotLinedYet(int workId)
        {
            return (int)GetRow(workId)["NotLinedYet"];
        }



        /// <summary>
        /// GetAllMeasured. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetAllMeasured(int workId)
        {
            return (bool)GetRow(workId)["AllMeasured"];
        }



        /// <summary>
        /// GetDeleted. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>TRUE if project deleted</returns>
        public bool GetDeleted(int workId)
        {
            return (bool)GetRow(workId)["Deleted"];
        }



        /// <summary>
        /// GetIssueWithLaterals
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public string GetIssueWithLaterals(int workId)
        {
            if (GetRow(workId).IsNull("IssueWithLaterals"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(workId)["IssueWithLaterals"];
            }
        }



        /// <summary>
        /// GetNotMeasuredYet. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotMeasuredYet</returns>
        public int GetNotMeasuredYet(int workId)
        {
            return (int)GetRow(workId)["NotMeasuredYet"];
        }



        /// <summary>
        /// GetNotDeliveredYet. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>NotDeliveredYet</returns>
        public int GetNotDeliveredYet(int workId)
        {
            return (int)GetRow(workId)["NotDeliveredYet"];
        }



        /// <summary>
        /// GetCompanyID. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>CpmpanyId - CompaniesId</returns>
        public int GetCompanyID(int workId)
        {
            return (int)GetRow(workId)["COMPANY_ID"];
        }



        /// <summary>
        /// GetTrafficControl
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
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
        /// GetTrafficControlDetails
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
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
        /// GetStandardBypass
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
        public bool GetStandardBypass(int workId)
        {
            return (bool)GetRow(workId)["StandardBypass"];
        }



        /// <summary>
        /// GetStandardBypassComments
        /// </summary>
        /// <param name="workId"></param>
        /// <returns></returns>
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
        /// GetAvailableToLine. If project not exists, raise an exception.
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>AvailableToLine</returns>
        public int GetAvailableToLine(int workId)
        {
            return (int)GetRow(workId)["AvailableToLine"];
        }



        /// <summary>
        /// Get a single work
        /// </summary>
        /// <param name="workId">workId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int workId)
        {
            string filter = string.Format("(WorkID = {0})", workId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Works.JunctionLiningSectionGateway.GetRow");
            }
        }



        /// <summary>
        /// Get a single view. If not exists, raise an exception.
        /// </summary>
        /// <returns>DataRow</returns>
        public DataRow GetRowTop1()
        {
            if (Table.Select().Length > 0)
            {
                DataRow row = Table.Select()[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.CWP.Common.WorkFullLengthLiningGateway.GetRow");
            }
        }





        
       
    }
}
