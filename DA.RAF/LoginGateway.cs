using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.DA.RAF
{
    /// <summary>
    /// LoginGateway
    /// </summary>
    public class LoginGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public LoginGateway()
            : base("LOGIN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public LoginGateway(DataSet data)
            : base(data, "LOGIN")
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
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadByLoginId(int loginId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_LOGINGATEWAY_LOADBYLOGINID", new SqlParameter("@loginId", loginId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadAllByLoginId
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Data</returns>
        public DataSet LoadAllByLoginId(int loginId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RAF_LOGINGATEWAY_LOADALLBYLOGINID", new SqlParameter("@loginId", loginId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int loginId, int companyId)
        {
            string filter = string.Format("LOGIN_ID = {0} AND COMPANY_ID = {1}", loginId, companyId);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.RAF.LoginGateway.GetRow");
            }
        }



        /// <summary>
        /// GetContactsId
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>contact Id</returns>
        public int GetContactsId(int loginId, int companyId)
        {
            return (int)GetRow(loginId, companyId)["CONTACTS_ID"];
        }



        /// <summary>
        /// GetRealName
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>real Name</returns>
        public string GetRealName(int loginId, int companyId)
        {
            return (string)GetRow(loginId, companyId)["REAL_NAME"];
        }



        /// <summary>
        /// GetFirstName
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>       
        /// <returns>first Name or EMPTY</returns>
        public string GetFirstName(int loginId, int companyId)
        {
            if (GetRow(loginId, companyId).IsNull("FIRST_NAME"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(loginId, companyId)["FIRST_NAME"];
            }
        }



        /// <summary>
        /// GetLastName
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>last Name or EMPTY</returns>
        public string GetLastName(int loginId, int companyId)
        {
            if (GetRow(loginId, companyId).IsNull("LAST_NAME"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(loginId, companyId)["LAST_NAME"];
            }
        }



        /// <summary>
        /// GetEmail
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>Email or EMPTY</returns>
        public string GetEmail(int loginId, int companyId)
        {
            if (GetRow(loginId, companyId).IsNull("EMAIL"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(loginId, companyId)["EMAIL"];
            }
        }



        /// <summary>
        /// GetUserName
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>USERNAME</returns>
        public string GetUserName(int loginId, int companyId)
        {
            return (string)GetRow(loginId, companyId)["USERNAME"];
        }



        /// <summary>
        /// GetPassword
        /// </summary>
        /// <param name="loginId">loginId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>PASSWORD</returns>
        public string GetPassword(int loginId, int companyId)
        {
            return (string)GetRow(loginId, companyId)["PASSWORD"];
        }

    }
}
