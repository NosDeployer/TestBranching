using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.Resources.Materials
{
    /// <summary>
    /// MaterialsListGateway
    /// </summary>
    public class MaterialsListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MaterialsListGateway()
            : base("LFS_RESOURCES_MATERIAL")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MaterialsListGateway(DataSet data)
            : base(data, "LFS_RESOURCES_MATERIAL")
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
        /// <param name="companyId">companyId</param>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByType
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        public DataSet LoadByType(string type, int companyId)
        {
            FillDataWithStoredProcedure("LFS_RESOURCES_MATERIALSLISTGATEWAY_LOADBYTYPE", new SqlParameter("@type", type), new SqlParameter("@companyId", companyId));
            return Data;
        }
             

    
    }
}