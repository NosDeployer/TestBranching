using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeAddTypeHistory
    /// </summary>
    public class EmployeeAddTypeHistory : TableModule
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeAddTypeHistory()
            : base("EmployeeAddTypeHistory")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeAddTypeHistory(DataSet data)
            : base(data, "EmployeeAddTypeHistory")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeesAddTDS();
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        public void LoadAllByEmployeeId(int employeeId, int companyId)
        {
            EmployeeAddTypeHistoryGateway employeeAddTypeHistoryGateway = new EmployeeAddTypeHistoryGateway(Data);
            employeeAddTypeHistoryGateway.LoadAllByEmployeeId(employeeId, companyId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// Insert a new employee type history
        /// </summary>
        /// <param name="employeeId">employeeId</param>        
        /// <param name="date">date</param>
        /// <param name="type">type</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>        
        public void Insert(int employeeId, DateTime date, string type, bool deleted, int companyId, bool inDataBase)
        {
            EmployeesAddTDS.EmployeeAddTypeHistoryRow row = ((EmployeesAddTDS.EmployeeAddTypeHistoryDataTable)Table).NewEmployeeAddTypeHistoryRow();
            row.RefID = GetNewRefId(employeeId, companyId);
            row.EmployeeID = employeeId;
            row.Date = date;
            row.Type = type;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDataBase;
            ((EmployeesAddTDS.EmployeeAddTypeHistoryDataTable)Table).AddEmployeeAddTypeHistoryRow(row);
        }



        /// <summary>
        /// Save
        /// </summary>                
        /// <param name="employeeId">employeeId</param>
        public void Save(int employeeId)
        {
            EmployeesAddTDS employeeAddTypeHistoryChanges = (EmployeesAddTDS)Data.GetChanges();

            if (employeeAddTypeHistoryChanges != null)
            {
                if (employeeAddTypeHistoryChanges.EmployeeAddTypeHistory.Rows.Count > 0)
                {
                    EmployeeAddTypeHistoryGateway employeeAddTypeHistoryGateway = new EmployeeAddTypeHistoryGateway(employeeAddTypeHistoryChanges);

                    foreach (EmployeesAddTDS.EmployeeAddTypeHistoryRow row in (EmployeesAddTDS.EmployeeAddTypeHistoryDataTable)employeeAddTypeHistoryChanges.EmployeeAddTypeHistory)
                    {
                        // Insert new subcontractor hours 
                        if ((!row.Deleted) && (!row.InDatabase))
                        {                                                                                                       
                            EmployeeTypeHistory employeeTypeHistory = new EmployeeTypeHistory(null);
                            employeeTypeHistory.InsertDirect(employeeId, row.RefID, row.Date, row.Type, row.Deleted, row.COMPANY_ID);
                        }
                    }
                }
            } 
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        
        /// GetNewRefId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="companyId">companyId</param>
        /// <returns>New ID</returns>
        public int GetNewRefId(int employeeId, int companyId)
        {
            int newRefId = 0;

            if (Table.Rows.Count == 0)
            {
                EmployeeAddTypeHistoryGateway rr = new EmployeeAddTypeHistoryGateway();
                rr.LoadAllByEmployeeId(employeeId, companyId);

                foreach (EmployeesAddTDS.EmployeeAddTypeHistoryRow row1 in (EmployeesAddTDS.EmployeeAddTypeHistoryDataTable)rr.Table)
                {
                    if (newRefId < row1.RefID)
                    {
                        newRefId = row1.RefID;
                    }
                }
            }
            else
            {
                foreach (EmployeesAddTDS.EmployeeAddTypeHistoryRow row2 in (EmployeesAddTDS.EmployeeAddTypeHistoryDataTable)Table)
                {
                    if (newRefId < row2.RefID)
                    {
                        newRefId = row2.RefID;
                    }
                }

            }

            newRefId++;

            return newRefId;
        }




    }
}