using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Employees
{
    /// <summary>
    /// EmployeeStateGateway
    /// </summary>
    public class EmployeeStateGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeStateGateway()
            : base("LFS_RESOURCES_EMPLOYEE_STATE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeStateGateway(DataSet data)
            : base(data, "LFS_RESOURCES_EMPLOYEE_STATE")
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
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEESTATEGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByState
        /// </summary>
        public DataSet LoadByState(string state)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_EMPLOYEESTATEGATEWAY_LOADBYSTATE", new SqlParameter("@state", state));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="state">state</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(string state)
        {
            string filter = string.Format("State = '{0}'", state);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.Resources.Employees.EmployeeStateGateway.GetRow");
            }
        }



        /// <summary>
        /// GetDescription
        /// </summary>
        /// <param name="state">state</param>
        /// <returns>Description</returns>
        public string GetDescription(string state)
        {
            return (string)GetRow(state)["Description"];
        }

    }
}
