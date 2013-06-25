using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.FleetManagement.Units
{
    /// <summary>
    /// UnitsListGateway
    /// </summary>
    public class UnitsListGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public UnitsListGateway()
            : base("LFS_FM_UNIT")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public UnitsListGateway(DataSet data)
            : base(data, "LFS_FM_UNIT")
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
        /// <returns> Data </returns>
        public DataSet Load(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOAD", new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByIsTowable
        /// </summary>
        /// <param name="isTowable">isTowable</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByIsTowable(int isTowable, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOADBYISTOWABLE", new SqlParameter("@isTowable", isTowable), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadWithUnitCode
        /// </summary>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadWithUnitCode(int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOADWITHUNITCODE", new SqlParameter("@companyId", companyId));
            return Data;
        }        



        /// <summary>
        /// LoadByIsTowableWithUnitCode
        /// </summary>
        /// <param name="isTowable">isTowable</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByIsTowableWithUnitCode(int isTowable, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOADBYISTOWABLEWITHUNITCODE", new SqlParameter("@isTowable", isTowable), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByIsTowableTypeWithUnitCode
        /// </summary>
        /// <param name="isTowable">isTowable</param>
        /// <param name="type">type</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByIsTowableTypeWithUnitCode(int isTowable, string type, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOADBYISTOWABLETYPEWITHUNITCODE", new SqlParameter("@isTowable", isTowable), new SqlParameter("@type", type), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCategoryWithUnitCode
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByCategoryWithUnitCode(string category, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOADBYCATEGORYWITHUNITCODE", new SqlParameter("@category", category), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// LoadByCategoryCompanyLevelIdWithUnitCodeDescription
        /// </summary>
        /// <param name="category">category</param>
        /// <param name="companyLevelId">companyLevelId</param>
        /// <param name="companyId">companyId</param>
        /// <returns> Data </returns>
        public DataSet LoadByCategoryCompanyLevelIdWithUnitCodeDescription(string category, int companyLevelId, int companyId)
        {
            FillDataWithStoredProcedure("LFS_FM_UNITSLISTGATEWAY_LOADBYCATEGORYCOMPANYLEVELIDWITHUNITCODEDESCRIPTION", new SqlParameter("@category", category), new SqlParameter("@companyLevelId", companyLevelId), new SqlParameter("@companyId", companyId));
            return Data;
        }



        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="unitId">unitId</param>
        /// <returns>DataRow</returns>
        public DataRow GetRow(int unitId)
        {
            string filter = string.Format("UnitID = {0}", unitId);
            if (Table.Select(filter).Length > 0)
            {
                DataRow row = Table.Select(filter)[0];
                return row;
            }
            else
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsListGateway.GetRow");
            }
        }
        


    }
}

