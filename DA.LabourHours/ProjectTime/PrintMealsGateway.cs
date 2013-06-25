using System;
using System.Data;
using LiquiForce.LFSLive.DA.Common;

namespace LiquiForce.LFSLive.DA.LabourHours.ProjectTime
{
    /// <summary>
    /// PrintMealsGateway
    /// </summary>
    public class PrintMealsGateway : DataTableGateway
    {
        // ////////////////////////////////////////////////////////////////////////
        // CONSTRUCTORS
        //

        /// <summary>
        /// Constructor
        /// </summary>     
        public PrintMealsGateway()
            : base("PrintMeals")
        {
        }



        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="data">data</param>
        public PrintMealsGateway(DataSet data)
            : base(data, "PrintMeals")
        {
        }



        /// <summary>
        /// InitData
        /// </summary>
        protected override void InitData()
        {
            _data = new PrintMealsTDS();
        }



        /// <summary>
        /// InitAdapter
        /// </summary>
        protected override void InitAdapter()
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS - DATASET
        //

        /// <summary>
        /// Load
        /// </summary>
        public void Load()
        {
            PrintMealsOriginalGateway originalGateway = new PrintMealsOriginalGateway(Data);
            originalGateway.Load();

            this.FillData();
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateProjectTimeState
        /// </summary>
        public void LoadByEmployeeTypeStartDateEndDateProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, string projectTimeState)
        {
            PrintMealsOriginalGateway originalGateway = new PrintMealsOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateProjectTimeState(employeeType, startDate, endDate, projectTimeState);

            this.FillData();
        }



        /// <summary>
        /// LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState
        /// </summary>
        public void LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState)
        {
            PrintMealsOriginalGateway originalGateway = new PrintMealsOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeStartDateEndDateEmployeeIdProjectTimeState(employeeType, startDate, endDate, employeeId, projectTimeState);

            this.FillData();
        }



        /// <summary>
        /// LoadByEmployeeSalariedTypeStartDateEndDateProjectTimeState
        /// </summary>
        public void LoadByEmployeeSalariedTypeStartDateEndDateProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, string projectTimeState, int salaried)
        {
            PrintMealsOriginalGateway originalGateway = new PrintMealsOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeSalariedStartDateEndDateProjectTimeState(employeeType, startDate, endDate, projectTimeState, salaried);

            this.FillData();
        }



        /// <summary>
        /// LoadByEmployeeTypeSalariedEmployeeIdStartDateEndDateProjectTimeState
        /// </summary>
        public void LoadByEmployeeTypeSalariedEmployeeIdStartDateEndDateProjectTimeState(string employeeType, DateTime startDate, DateTime endDate, int employeeId, string projectTimeState, int salaried)
        {
            PrintMealsOriginalGateway originalGateway = new PrintMealsOriginalGateway(Data);
            originalGateway.LoadByEmployeeTypeSalariedStartDateEndDateEmployeeIdProjectTimeState(employeeType, startDate, endDate, employeeId, projectTimeState, salaried);

            this.FillData();
        }



        /// <summary>
        /// FillData
        /// </summary>
        private void FillData()
        {
            PrintMealsOriginalGateway originalGateway = new PrintMealsOriginalGateway(Data);

            foreach (PrintMealsTDS.OriginalRow originalRow in (PrintMealsTDS.OriginalDataTable)originalGateway.Table)
            {
                PrintMealsTDS.PrintMealsRow newRow = ((PrintMealsTDS.PrintMealsDataTable)Table).NewPrintMealsRow();

                newRow.EmployeeID = originalRow.EmployeeID;
                newRow.EmployeeName = originalRow.EmployeeName;
                newRow.Date_ = originalRow.Date_;
                newRow.Salaried = originalRow.Salaried;
                
                if(!originalRow.IsMealsCountryNull())
                {
                    if (originalRow.MealsCountry == 1)
                    {
                        newRow.TotalCA = originalRow.MealsAllowance;
                        newRow.TotalUS = 0;
                    }
                    else
                    {
                        newRow.TotalCA = 0;
                        newRow.TotalUS = originalRow.MealsAllowance;
                    }
                }
                else
                {
                    newRow.TotalCA = 0;
                    newRow.TotalUS = 0;
                }

                if (!originalRow.IsProjectTimeStateNull())
                {
                    newRow.ProjectTimeState = originalRow.ProjectTimeState;
                }
                else
                {
                    newRow.ProjectTimeState = "For Approval";
                }

                if ((newRow.TotalCA != 0) || (newRow.TotalUS != 0))
                {
                    ((PrintMealsTDS.PrintMealsDataTable)Table).AddPrintMealsRow(newRow);
                }
            }
        }



    }
}