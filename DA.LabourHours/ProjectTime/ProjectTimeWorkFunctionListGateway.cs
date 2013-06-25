using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.DA.Common;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// ProjectTimeWorkFunctionGateway
    /// </summary>
    public class ProjectTimeWorkFunctionListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public ProjectTimeWorkFunctionListGateway()
            : base("LFS_PROJECT_TIME_WORK_FUNCTION")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public ProjectTimeWorkFunctionListGateway(DataSet data)
            : base(data, "LFS_PROJECT_TIME_WORK_FUNCTION")
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
        /// <returns>Data</returns>
        public DataSet Load()
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEWORKFUNCTIONLISTGATEWAY_LOAD");
            return Data;
        }



        /// <summary>
        /// LoadByWork
        /// </summary>
        /// <param name="Work_">Work_</param>
        /// <returns>Data</returns>
        public DataSet LoadByWork(string work_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEWORKFUNCTIONLISTGATEWAY_LOADBYWORK", new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByWork
        /// </summary>
        /// <param name="Work_">Work_</param>
        /// <returns>Data</returns>
        public DataSet LoadActiveForAddByWork(string work_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEWORKFUNCTIONLISTGATEWAY_LOADACTIVEFORADDBYWORK", new SqlParameter("@work_", work_));
            return Data;
        }



        /// <summary>
        /// LoadByWorkFunction
        /// </summary>
        /// <param name="work_">work_</param>
        /// <param name="function_">function_</param>
        /// <returns>Data</returns>
        public DataSet LoadByWorkFunction(string work_, string function_)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_PROJECTTIMEWORKFUNCTIONLISTGATEWAY_LOADBYWORKFUNCTION", new SqlParameter("@work_", work_), new SqlParameter("@function_", function_));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(string work, string function)
        {
            string filter = string.Format("(Work_ = {0})  AND (Function_ = {1})", work, function);

            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.LabourHours.ProjectTime.ProjectTimeWorkFunctionListGateway.GetRow");
            }
        }



        /// <summary>
        /// GetFunction
        /// </summary>
        /// <param name="work">work</param>
        /// <param name="function">function</param>
        /// <returns>Function_</returns>
        public string GetFunction(string work, string function)
        {
            return (string)GetRow(work, function)["Function_"];
        }



    }
}