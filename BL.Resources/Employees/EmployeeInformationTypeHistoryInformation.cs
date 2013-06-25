using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    ///  EmployeeInformationTypeHistoryInformation
    /// </summary>
    public class  EmployeeInformationTypeHistoryInformation: TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public  EmployeeInformationTypeHistoryInformation()
            : base("TypeHistoryInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public  EmployeeInformationTypeHistoryInformation(DataSet data)
            : base(data, "TypeHistoryInformation")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new EmployeeInformationTDS();
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        /// <summary>
        /// LoadAllByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>              
        /// <param name="companyId">companyId</param>
        public void LoadAllByEmployeeId(int employeeId, int companyId)
        {
            EmployeeInformationTypeHistoryInformationGateway employeeInformationTypeHistoryInformationGateway = new  EmployeeInformationTypeHistoryInformationGateway(Data);
            employeeInformationTypeHistoryInformationGateway.LoadAllByEmployeeId(employeeId, companyId);
        }



        /// <summary>
        /// Insert
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="date">date</param>
        /// <param name="type">type</param>
        /// <param name="deleted">deleted</param>
        /// <param name="companyId">companyId</param>
        /// <param name="inDatabase">inDatabase</param>
        public void Insert(int employeeId, DateTime date, string type, bool deleted, int companyId, bool inDatabase)
        {
            EmployeeInformationTDS.TypeHistoryInformationRow row = ((EmployeeInformationTDS.TypeHistoryInformationDataTable)Table).NewTypeHistoryInformationRow();

            row.RefID = GetNewRefId(employeeId, companyId);
            row.EmployeeID = employeeId;
            row.Date = date;
            row.Type = type;
            row.Deleted = deleted;
            row.COMPANY_ID = companyId;
            row.InDatabase = inDatabase;

            ((EmployeeInformationTDS.TypeHistoryInformationDataTable)Table).AddTypeHistoryInformationRow(row);
        }


        
        /// <summary>
        /// Delete
        /// </summary>        
        /// <param name="employeeId">employeeId</param>
        /// <param name="refId">refId</param>
        public void Delete(int employeeId, int refId)
        {
            EmployeeInformationTDS.TypeHistoryInformationRow row = GetRow(employeeId, refId);
            row.Deleted = true;
        }



        /// <summary>
        /// DeleteAll
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        public void DeleteAll(int employeeId)
        {
            foreach (EmployeeInformationTDS.TypeHistoryInformationRow row in (EmployeeInformationTDS.TypeHistoryInformationDataTable)Table)
            {
                if (row.EmployeeID == employeeId)
                {
                    row.Deleted = true;
                }               
            }
        }



        /// <summary>
        /// Save all to database (direct)
        /// </summary>
        /// <param name="companyId">companyId</param>
        public void Save(int employeeId, int companyId)
        {
            // Delete previous types
            EmployeeTypeHistory employeeTypeHistoryForDelete = new EmployeeTypeHistory(null);
            employeeTypeHistoryForDelete.DeleteAllDirect(employeeId, companyId); 

            // Insert new types
            EmployeeInformationTDS typeHistoryInformationChanges = (EmployeeInformationTDS)Data.GetChanges();

            if (typeHistoryInformationChanges.TypeHistoryInformation.Rows.Count > 0)
            {
                EmployeeInformationTypeHistoryInformationGateway employeeInformationTypeHistoryInformationGateway = new  EmployeeInformationTypeHistoryInformationGateway(typeHistoryInformationChanges);

                foreach (EmployeeInformationTDS.TypeHistoryInformationRow row in (EmployeeInformationTDS.TypeHistoryInformationDataTable)typeHistoryInformationChanges.TypeHistoryInformation)
                {
                    // Insert new typeHistorys 
                    if ((!row.Deleted) && (!row.InDatabase))
                    {
                        EmployeeTypeHistory employeeTypeHistory = new EmployeeTypeHistory(null);
                        employeeTypeHistory.InsertDirect(row.EmployeeID, row.RefID, row.Date, row.Type, row.Deleted, row.COMPANY_ID); 
                    }
                   

                    // Deleted typeHistorys 
                    if ((row.Deleted) && (row.InDatabase))
                    {
                        EmployeeTypeHistory employeeTypeHistory = new EmployeeTypeHistory(null);
                        employeeTypeHistory.DeleteDirect(row.EmployeeID, row.RefID, row.COMPANY_ID);
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        /// <summary>
        /// Get a single row. If not exists, raise an exception.
        /// </summary>
        /// <param name="typeHistoryId">typeHistoryId</param>        
        /// <param name="refId">refId</param>
        /// <returns>Obtained row</returns>
        private EmployeeInformationTDS.TypeHistoryInformationRow GetRow(int typeHistoryId, int refId)
        {
            EmployeeInformationTDS.TypeHistoryInformationRow row = ((EmployeeInformationTDS.TypeHistoryInformationDataTable)Table).FindByEmployeeIDRefID(typeHistoryId, refId);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.Resources.Employees. EmployeeInformationTypeHistoryInformation.GetRow");
            }

            return row;
        }



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
                EmployeeInformationTypeHistoryInformationGateway rr = new EmployeeInformationTypeHistoryInformationGateway();
                rr.LoadAllByEmployeeId(employeeId, companyId);

                foreach (EmployeeInformationTDS.TypeHistoryInformationRow row1 in (EmployeeInformationTDS.TypeHistoryInformationDataTable)rr.Table)
                {
                    if (newRefId < row1.RefID)
                    {
                        newRefId = row1.RefID;
                    }
                }
            }
            else
            {
                foreach (EmployeeInformationTDS.TypeHistoryInformationRow row2 in (EmployeeInformationTDS.TypeHistoryInformationDataTable)Table)
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