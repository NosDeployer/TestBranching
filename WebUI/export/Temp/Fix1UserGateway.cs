using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.WebUI.export.Temp;

namespace LiquiForce.LFSLive.WebUI
{
    public class Fix1UserGateway : DataTableGateway
    {
    // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Fix1UserGateway()
            : base("USER")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Fix1UserGateway(DataSet data)
            : base(data, "USER")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
            _adapter = new SqlDataAdapter("", DB.Connection);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByLoginId
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>Data</returns>
        public DataSet LoadByLoginId(int loginId)
        {
            FillDataWithStoredProcedure("LFS_RAF_USERGATEWAY_LOADBYLOGINID", new SqlParameter("@loginId", loginId));
            return Data;
        }




        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int loginId)
        {
            string filter = string.Format("LOGIN_ID = {0}", loginId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.UserGateway.GetRow");
            }
        }



        /// <summary>
        /// GetFirstName
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>first Name or EMPTY</returns>
        public string GetFirstName(int loginId)
        {
            if (GetRow(loginId).IsNull("FIRST_NAME"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(loginId)["FIRST_NAME"];
            }
        }



        /// <summary>
        /// GetLastName
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <returns>last Name or EMPTY</returns>
        public string GetLastName(int loginId)
        {
            if (GetRow(loginId).IsNull("LAST_NAME"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(loginId)["LAST_NAME"];
            }
        }



    }
}
