using System;
using System.Data;
using System.Text.RegularExpressions;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// Salesman
    /// </summary>
    public class Salesman : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public Salesman()
            : base("LFS_SALESMAN")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public Salesman(DataSet data)
            : base(data, "LFS_SALESMAN")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new enployee (direct to DB)
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>       
        /// <param name="idForProjects">idForProjects</param>
        public void InsertDirect(int salesmanId, string idForProjects)
        {
            SalesmanGateway salesmanGateway = new SalesmanGateway(null);
            salesmanGateway.Insert(salesmanId, idForProjects);
        }



        /// <summary>
        /// Update a new enployee (direct to DB)
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>       
        /// <param name="originalIdForProjects">originalIdForProjects</param>
        /// <param name="newIdForProjects">newIdForProjects</param>
        public void UpdateDirect(int salesmanId, string originalIdForProjects, string newIdForProjects)
        {
            SalesmanGateway salesmanGateway = new SalesmanGateway(null);
            salesmanGateway.Update(salesmanId, originalIdForProjects, newIdForProjects);
        }



        /// <summary>
        /// ValidateIdForProjects
        /// </summary>
        /// <param name="idForProjects">idForProjects</param>
        /// <returns>bool</returns>
        public static bool ValidateIdForProjects(string idForProjects)
        {
            Regex regex = new Regex("^[0-9][0-9]$");

            return regex.IsMatch(idForProjects);
        }



    }
}
