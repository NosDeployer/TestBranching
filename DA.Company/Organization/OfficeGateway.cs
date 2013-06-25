using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Company.Organization
{
    /// <summary>
    /// OfficeGateway
    /// </summary>
    public class OfficeGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public OfficeGateway() : base("LFS_OFFICE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public OfficeGateway(DataSet data) : base(data, "LFS_OFFICE")
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
        /// LoadByOfficeId
        /// </summary>
        /// <param name="officeId">officeId</param>
        /// <returns>Data</returns>
        public DataSet LoadByOfficeId(int officeId)
        {
            FillDataWithStoredProcedure("LFS_COMPANY_OFFICEGATEWAY_LOADBYOFFICEID", new SqlParameter("@officeId", officeId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="officeId">officeId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int officeId)
        {
            string filter = string.Format("OfficeID = {0}", officeId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Company.OfficeGateway.GetRow");
            }

        }



        /// <summary>
        /// GetIdForProjects
        /// </summary>
        /// <param name="officeId">officeId</param>
        /// <returns>IdForProjects or EMPTY</returns>
        public string GetIdForProjects(int officeId)
        {
            if (GetRow(officeId).IsNull("IdForProjects"))
            {
                return "";
            }
            else
            {
                return (string)GetRow(officeId)["IdForProjects"];
            }
        }



    }
}
