using System;
using System.Data;
using LiquiForce.LFSLive.BL.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.BL.Resources.Employees
{
    /// <summary>
    /// EmployeeInformationCategoryApproveTimesheetsInformation
    /// </summary>
    public class EmployeeInformationCategoryApproveTimesheetsInformation : TableModule
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>
        public EmployeeInformationCategoryApproveTimesheetsInformation()
            : base("CategoryApproveTimesheetsInformation")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public EmployeeInformationCategoryApproveTimesheetsInformation(DataSet data)
            : base(data, "CategoryApproveTimesheetsInformation")
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
        /// LoadByEmployeeId
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        public void LoadByEmployeeId(int employeeId)
        {
            EmployeeInformationCategoryApproveTimesheetsInformationGateway employeeInformationCategoryApproveTimesheetsInformationGateway = new EmployeeInformationCategoryApproveTimesheetsInformationGateway(Data);
            employeeInformationCategoryApproveTimesheetsInformationGateway.LoadByEmployeeId(employeeId);
        }



        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        public void Insert(int employeeId, string category, bool approveTimesheets)
        {
            EmployeeInformationTDS.CategoryApproveTimesheetsInformationRow row = ((EmployeeInformationTDS.CategoryApproveTimesheetsInformationDataTable)Table).NewCategoryApproveTimesheetsInformationRow();
            
            row.EmployeeID = employeeId;
            row.Category = category;
            row.ApproveTimesheets = approveTimesheets;

            ((EmployeeInformationTDS.CategoryApproveTimesheetsInformationDataTable)Table).AddCategoryApproveTimesheetsInformationRow(row);
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="employeeId">employeeId</param>
        /// <param name="category">category</param>
        /// <param name="approveTimesheets">approveTimesheets</param>
        public void Update(int employeeId, string category, bool approveTimesheets)
        {
            if (((EmployeeInformationTDS.CategoryApproveTimesheetsInformationDataTable)Table).FindByEmployeeIDCategory(employeeId, category) != null)
            {
                EmployeeInformationTDS.CategoryApproveTimesheetsInformationRow row = GetRow(employeeId, category);
                row.ApproveTimesheets = approveTimesheets;
            }
            else
            {
                Insert(employeeId, category, approveTimesheets);
            }
        }



        /// <summary>
        /// Save all categories approve timesheets to database (direct)
        /// </summary>
        public void Save()
        {
            EmployeeInformationTDS categoryApproveTimesheetsInformationChanges = (EmployeeInformationTDS)Data.GetChanges();

            if (categoryApproveTimesheetsInformationChanges.CategoryApproveTimesheetsInformation.Rows.Count > 0)
            {
                EmployeeInformationCategoryApproveTimesheetsInformationGateway employeeInformationCategoryApproveTimesheetsInformationGateway = new EmployeeInformationCategoryApproveTimesheetsInformationGateway(categoryApproveTimesheetsInformationChanges);

                foreach (EmployeeInformationTDS.CategoryApproveTimesheetsInformationRow row in (EmployeeInformationTDS.CategoryApproveTimesheetsInformationDataTable)categoryApproveTimesheetsInformationChanges.CategoryApproveTimesheetsInformation)
                {
                    int employeeId = row.EmployeeID;
                    string category = row.Category;
                    bool deleted = false;

                    // original values
                    bool originalApproveTimesheets = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheetsOriginal(employeeId, category);

                    // new values
                    bool newApproveTimesheets = employeeInformationCategoryApproveTimesheetsInformationGateway.GetApproveTimesheets(employeeId, category);

                    EmployeeCategoryApproveTimesheets employeeCategoryApproveTimesheets = new EmployeeCategoryApproveTimesheets(null);
                    int rowsAffected = employeeCategoryApproveTimesheets.UpdateDirect(employeeId, category, originalApproveTimesheets, deleted, employeeId, category, newApproveTimesheets, deleted);

                    if (rowsAffected == 0)
                    {
                        employeeCategoryApproveTimesheets.InsertDirect(employeeId, category, newApproveTimesheets, deleted);
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
        /// <param name="employeeId">employeeId</param>      
        /// <param name="category">category</param>
        /// <returns>Obtained row</returns>
        private EmployeeInformationTDS.CategoryApproveTimesheetsInformationRow GetRow(int employeeId, string category)
        {
            EmployeeInformationTDS.CategoryApproveTimesheetsInformationRow row = ((EmployeeInformationTDS.CategoryApproveTimesheetsInformationDataTable)Table).FindByEmployeeIDCategory(employeeId,category);

            if (row == null)
            {
                throw new Exception("Unavailable row in LiquiForce.LFSLive.BL.FleetManagement.Resources.EmployeeInformationCategoryApproveTimesheetsInformation.GetRow");
            }

            return row;
        }



    }
}