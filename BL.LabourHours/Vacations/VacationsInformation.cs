using System;
using System.Data;
using System.Collections;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.LabourHours.Vacations;

namespace LiquiForce.LFSLive.BL.LabourHours.Vacations
{
    /// <summary>
    /// VacationsInformation
    /// </summary>
    public class VacationsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public VacationsInformation()
            : base("VacationsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public VacationsInformation(DataSet data)
            : base(data, "VacationsInformation")
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
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadByEmployeeType
        /// </summary>
        /// <param name="employeeType">employeeType</param>              
        /// <param name="companyId">companyId</param>
        public void LoadByEmployeeType(string employeeType, int companyId)
        {
            VacationsInformationGateway vacationsInformationGateway = new VacationsInformationGateway(Data);
            vacationsInformationGateway.LoadByEmployeeType(employeeType, companyId);
        }



        /// <summary>
        /// LoadByEmployeeIdEmployeeType
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="employeeType">employeeType</param>
        /// <param name="companyId">companyId</param>
        public void LoadByEmployeeIdEmployeeType(int employeeId, string employeeType, int companyId)
        {
            VacationsInformationGateway vacationsInformationGateway = new VacationsInformationGateway(Data);
            vacationsInformationGateway.LoadByEmployeeIdEmployeeType(employeeId, employeeType, companyId);
        }



    }
}