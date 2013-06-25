using System;
using System.Data;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.BL.LabourHours.ProjectTime
{
    /// <summary>
    /// MealsAllowance
    /// </summary>
    public class MealsAllowance : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public MealsAllowance() : base("LFS_MEALS_ALLOWANCE")
        {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public MealsAllowance(DataSet data) : base(data, "LFS_MEALS_ALLOWANCE")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new DataSet();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// GetMealsAllowance
        /// </summary>
        /// <param name="countryId">countryId</param>
        /// <param name="mealsAllowance">mealsAllowance</param>
        /// <param name="mealsAllowanceType">mealsAllowanceType</param>
        /// <returns>decimal</returns>
        public static decimal GetMealsAllowance(Int64? countryId, bool mealsAllowance, string mealsAllowanceType)
        {
            if ((mealsAllowance) && (countryId.HasValue) && (mealsAllowanceType != ""))
            {
                MealsAllowanceGateway mealsAllowanceGateway = new MealsAllowanceGateway(new DataSet());
                mealsAllowanceGateway.LoadByCountryIdMealsAllowanceType((Int64)countryId, mealsAllowanceType);

                if (mealsAllowanceGateway.Table.Rows.Count > 0)
                {
                    return (decimal)mealsAllowanceGateway.Table.Rows[0]["MealsAllowance"];
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }



    }
}
