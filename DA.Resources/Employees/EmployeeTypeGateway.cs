using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeTypeGateway
    /// </summary>
    public class EmployeeTypeGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeTypeGateway()
            : base("LFS_RESOURCES_EMPLOYEE_TYPE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeTypeGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_TYPE")
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
        /// Load
        /// </summary>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEETYPEGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByType
        /// </summary>
        public DataSet LoadByType(string type)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEETYPEGATEWAY_LOADBYTYPE", new SqlParameter("@type", type));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(string type)
        {
            string filter = string.Format("Type = '{0}'", type);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeTypeGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="type">type</param>
        /// <returns>Description</returns>
        public string GetDescription(string type)
        {
            return (string)GetRow(type)["Description"];
        }

    }
}
