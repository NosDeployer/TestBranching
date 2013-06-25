using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformationBasicInformation
    /// </summary>
    public class VacationsInformationBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformationBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformationBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadByEmployeeIdYear
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="year">year</param>
        /// <param name="companyId">companyId</param>
        public void LoadByEmployeeIdYear(int employeeId, int year, int companyId)
        {
            VacationsInformationBasicInformationGateway vcationsInformationBasicInformationGateway = new VacationsInformationBasicInformationGateway(Data);
            vcationsInformationBasicInformationGateway.LoadByEmployeeIdYear(employeeId, year, companyId);
        }



    }
}