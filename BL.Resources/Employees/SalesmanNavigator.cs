using System;
using System.Data;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Common;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// SalesmanNavigator
    /// </summary>
    public class SalesmanNavigator : TableModule
    {
        //// ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public SalesmanNavigator()
            : base("SalesmanNavigator")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public SalesmanNavigator(DataSet data)
            : base(data, "SalesmanNavigator")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeNavigatorTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadBySalesmanId
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        public void LoadBySalesmanId(int salesmanId)
        {
            SalesmanNavigatorGateway salesmanNavigatorGateway = new SalesmanNavigatorGateway(Data);
            salesmanNavigatorGateway.LoadBySalesmanId(salesmanId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="idForProjects">idForProjects</param>
        public void Insert(int salesmanId, string idForProjects)
        {
            EmployeeNavigatorTDS.SalesmanNavigatorRow row = ((EmployeeNavigatorTDS.SalesmanNavigatorDataTable)Table).NewSalesmanNavigatorRow();

            row.SalesmanID = salesmanId;
            if (idForProjects != "") row.IdForProjects = idForProjects; else row.IsIdForProjectsNull();
            row.InDatabase = false;

            ((EmployeeNavigatorTDS.SalesmanNavigatorDataTable)Table).AddSalesmanNavigatorRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <param name="idForProjects">idForProjects</param>
        public void Update(int salesmanId, string idForProjects)
        {
            EmployeeNavigatorTDS.SalesmanNavigatorRow row = GetRow(salesmanId);
            row.IdForProjects = idForProjects;
        }



        /// <summary>
        /// Save
        /// </summary>
        public void Save()
        {
            EmployeeNavigatorTDS salesmanNavigatorChanges = (EmployeeNavigatorTDS)Data.GetChanges();

            if (salesmanNavigatorChanges.SalesmanNavigator.Rows.Count > 0)
            {
                SalesmanNavigatorGateway salesmanNavigatorGateway = new SalesmanNavigatorGateway(salesmanNavigatorChanges);

                // Update employees
                foreach (EmployeeNavigatorTDS.SalesmanNavigatorRow row in (EmployeeNavigatorTDS.SalesmanNavigatorDataTable)salesmanNavigatorChanges.SalesmanNavigator)
                {
                    Salesman salesman = new Salesman(null);

                    if (!row.InDatabase)
                    {
                        string idForProjects = ""; if (!row.IsIdForProjectsNull()) idForProjects = row.IdForProjects;
                        salesman.InsertDirect(row.SalesmanID, idForProjects);
                    }
                    else
                    {
                        int salesmanId = row.SalesmanID;

                        string originalIdForProjects = salesmanNavigatorGateway.GetIdForProjectsOriginal(salesmanId);
                        string newIdForProjects = salesmanNavigatorGateway.GetIdForProjects(salesmanId);

                        salesman.UpdateDirect(salesmanId, originalIdForProjects, newIdForProjects);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// GetRow
        /// </summary>
        /// <param name="salesmanId">salesmanId</param>
        /// <returns></returns>
        private EmployeeNavigatorTDS.SalesmanNavigatorRow GetRow(int salesmanId)
        {
            return ((EmployeeNavigatorTDS.SalesmanNavigatorDataTable)Table).FindBySalesmanID(salesmanId);
        }



    }
}

