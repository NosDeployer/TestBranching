using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsAddBasicInformation
    /// </summary>
    public class VacationsAddBasicInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsAddBasicInformation()
            : base("BasicInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsAddBasicInformation(DataSet data)
            : base(data, "BasicInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new VacationsAddTDS();
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
            VacationsAddBasicInformationGateway vacationsAddBasicInformationGateway = new VacationsAddBasicInformationGateway(Data);
            vacationsAddBasicInformationGateway.LoadByEmployeeIdYear(employeeId, year, companyId);
        }



    }
}