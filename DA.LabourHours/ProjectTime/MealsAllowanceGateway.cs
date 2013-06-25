using System;
using System.Data;
using System.Data.SqlClient;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// MealsAllowanceGateway
    /// </summary>
    public class MealsAllowanceGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MealsAllowanceGateway()
            : base("LFS_MEALS_ALLOWANCE")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MealsAllowanceGateway(DataSet data)
            : base(data, "LFS_MEALS_ALLOWANCE")
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
        /// LoadByCountryIdMealsAllowanceType
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <returns>Data</returns>
        public DataSet LoadByCountryIdMealsAllowanceType(Int64 countryId, string mealsAllowanceType)
        {
            FillDataWithStoredProcedure("LFS_LABOURHOURS_MEALSALLOWANCEGATEWAY_LOADBYCOUNTRYIDMEALSALLOWANCETYPE", new SqlParameter("@countryId", countryId), new SqlParameter("@mealsAllowanceType", mealsAllowanceType));
            return Data;
        }



    }
}
